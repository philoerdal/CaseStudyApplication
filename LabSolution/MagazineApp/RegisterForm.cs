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
using Magazine.Entities;

namespace MagazineApp
{
    public partial class RegisterForm : BaseForm
    {
        UnLoggedForm parentForm;
        public RegisterForm(IMagazineISWService service, UnLoggedForm parentForm) : base(service)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.parentForm = parentForm;

            try
            {
                List<Area> areas = service.GetAreas();
                foreach (Area area in areas)
                    aoiBox.Items.Add(area.Name);
            }
            catch (ServiceException err)
            {
                ShowDialog(err.Message);
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                string areasSelectedResult = "";
                CheckedListBox.CheckedItemCollection areas = aoiBox.CheckedItems;
                if(areas.Count > 0)
                {
                    for (int i = 0; i < areas.Count - 1; i++)
                        areasSelectedResult += areas[i] + ";";

                    areasSelectedResult += areas[areas.Count - 1];
                }

                service.RegisterUser(dniField.Text, nameField.Text, surnameField.Text, alertedCheckBox.Checked, areasSelectedResult, emailField.Text, loginField.Text, passwordField.Text);
                service.Login(loginField.Text, passwordField.Text);
                parentForm.UserLogged();
            }
            catch (ServiceException err) 
            {
                ShowDialog(err.Message);
            }
        }
    }
}
