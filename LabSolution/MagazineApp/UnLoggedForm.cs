using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Magazine.Services;
using Magazine.Persistence;

namespace MagazineApp
{
    public partial class UnLoggedForm : BaseForm
    {
        BaseForm login, register;
        public UnLoggedForm(IMagazineISWService service) : base(service)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            removeDataDB.Visible = false;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            login = new LoginForm(service, this);
            login.ShowDialog();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            register = new RegisterForm(service, this);
            register.ShowDialog();
        }

        private void removeDataDB_Click(object sender, EventArgs e)
        {
            service.RestartDB();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Console.WriteLine("Works");
            switch (keyData)
            {
                case Keys.F3: // left arrow key
                    removeDataDB.Visible = !removeDataDB.Visible;
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void UserLogged()
        {
            if (login != null) login.Hide();
            if (register != null) register.Hide();
            this.Hide();
            LoggedForm loggedForm = new LoggedForm(service);
            loggedForm.ShowDialog();

            if (login != null) login.Close();
            login = null;
            if (register != null) register.Close();
            register = null;
            this.Dispose();

        }
    }
}
