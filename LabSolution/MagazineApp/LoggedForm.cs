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
    public partial class LoggedForm : BaseForm
    {
        BaseForm submitPaperForm, evaluatePaperForm, buildIssueForm, listPapersForm;
        public LoggedForm(IMagazineISWService service) : base(service)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            loggedAsLabel.Text = "Logged as " + service.GetUserLogin();
        }

        private void paperSubmissionButton_Click(object sender, EventArgs e)
        {
            CloseAllOpenedMdiForms();

            submitPaperForm = new PaperSubmissionForm(service);
            //Set parent form for the child window 
            submitPaperForm.MdiParent = HBoxContainer.MdiForm;
            submitPaperForm.WindowState = FormWindowState.Maximized;
            //Display the child window
            submitPaperForm.Show();
        }

        private void evaluatePaperButton_Click(object sender, EventArgs e)
        {
            CloseAllOpenedMdiForms();
            try
            {
                evaluatePaperForm = new EvaluatePaperForm(service);
                //Set parent form for the child window 
                evaluatePaperForm.MdiParent = HBoxContainer.MdiForm;
                evaluatePaperForm.WindowState = FormWindowState.Maximized;

                //Display the child window
                evaluatePaperForm.Show();
            }
            catch (ServiceException err)
            {
                ShowDialog(err.Message);
                CloseAllOpenedMdiForms();
            }
        }

        private void buildIssueButton_Click(object sender, EventArgs e)
        {
            CloseAllOpenedMdiForms();
            try
            {
                buildIssueForm = new BuildIssueForm(service);
                //Set parent form for the child window 
                buildIssueForm.MdiParent = HBoxContainer.MdiForm;
                buildIssueForm.WindowState = FormWindowState.Maximized;

                //Display the child window
                buildIssueForm.Show();
            }
            catch (ServiceException err)
            {
                ShowDialog(err.Message);
                CloseAllOpenedMdiForms();
            }
        }

        private void listPapersButton_Click(object sender, EventArgs e)
        {
            CloseAllOpenedMdiForms();
            try
            {
                listPapersForm = new ListAllPapersForm(service);
                //Set parent form for the child window 
                listPapersForm.MdiParent = HBoxContainer.MdiForm;
                listPapersForm.WindowState = FormWindowState.Maximized;

                //Display the child window
                listPapersForm.Show();
            }
            catch (ServiceException err)
            {
                ShowDialog(err.Message);
                CloseAllOpenedMdiForms();
            }
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            service.Logout();
            this.Hide();
            UnLoggedForm unloggedForm = new UnLoggedForm(service);
            unloggedForm.ShowDialog();
            this.Dispose();
        }

        void CloseAllOpenedMdiForms()
        {
            if (submitPaperForm != null) {
                submitPaperForm.Close();
            }
            if (evaluatePaperForm != null)
            {
                evaluatePaperForm.Close();
            }
            if (buildIssueForm != null)
            {
                buildIssueForm.Close();
            }
            if (listPapersForm != null)
            {
                listPapersForm.Close();
            }
        }
    }
}
