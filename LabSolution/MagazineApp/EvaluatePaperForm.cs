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
    public partial class EvaluatePaperForm : BaseForm
    {
        private List<Area> areaList;
        List<Paper> papers;
        public EvaluatePaperForm(IMagazineISWService service) : base(service)
        {
            InitializeComponent();
            ReloadData();
        }

        void ReloadData()
        {
            //Add area names to the areaBox
            if (areaSelectedBox.Items != null) areaSelectedBox.Items.Clear();
             areaList = service.GetAreasWhereEditor();
            for (int i = 0; i < areaList.Count; i++)
            {
                areaSelectedBox.Items.Add(areaList[i].Name);
            }
            areaSelectedBox.SelectedIndex = 0;
            acceptedCheckBox.Checked = false;
            commentField.Text = "";
        }

        private void areaSelectedBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadPapers();
        }

        void ReloadPapers()
        {
            papersListBox.Items.Clear();
            papers = service.GetPapersPendingEvaluation(areaList[areaSelectedBox.SelectedIndex].Id);
            foreach (var paper in papers)
                papersListBox.Items.Add(paper.Title);
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (papersListBox.SelectedIndex == -1) throw new ServiceException("No paper was selected");
                service.EvaluatePaper(acceptedCheckBox.Checked, commentField.Text, DateTime.Today, papers[papersListBox.SelectedIndex].Id);
                ShowDialog("Paper evaluated successfully", "Success", MessageBoxIcon.Information);
                ReloadPapers();
                ReloadData();
            }
            catch (ServiceException err)
            {
                ShowDialog(err.Message);
            }
        }
    }
}
