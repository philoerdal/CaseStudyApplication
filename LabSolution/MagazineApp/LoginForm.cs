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
    public partial class LoginForm : BaseForm
    {
        UnLoggedForm parentForm;
        public LoginForm(IMagazineISWService service, UnLoggedForm parentForm) : base(service)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.parentForm = parentForm;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                service.Login(loginField.Text, passwordField.Text);
                parentForm.UserLogged();
            }
            catch (Exception err)
            {
                ShowDialog(err.Message);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
