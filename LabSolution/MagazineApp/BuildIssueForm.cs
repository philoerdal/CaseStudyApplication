using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Magazine.Entities;
using Magazine.Services;

namespace MagazineApp
{
    public partial class BuildIssueForm : BaseForm
    {
        private int issueId;
        private List<Area> areaList;

        private List<Paper> areaPaperList = new List<Paper>(); //Papers on the area selected
        private List<Paper> publishedPaperList = new List<Paper>(); //Papers already published

        DateTime? selectedDate;
        DateTime selectedDateNotNull;
        bool initialized = false;

        public BuildIssueForm(IMagazineISWService service) : base(service)
        {
            InitializeComponent();
            Initialize();
        }

        void Initialize()
        {
            issueId = service.GetLastIssueId();
            Issue issue = service.GetIssueById(issueId);
            magazineNumLabel.Text = "Magazine number: " + service.GetMagazineNumber();
            issueNumLabel.Text = "Issue number: " + issue.Number;

            areaList = service.GetAreas();
            for (int i = 0; i < areaList.Count; i++)
            {
                areasComboBox.Items.Add(areaList[i].Name);
            }
            areasComboBox.SelectedIndex = 0;


            RemoveDate();
        }

        #region DatePicker
        private void publishDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (!initialized) { initialized = true; return; }
            if (publishDateTimePicker.Value < DateTime.Today)
            {
                if (selectedDateNotNull >= DateTime.Today)
                    publishDateTimePicker.Value = selectedDateNotNull;
                else
                    publishDateTimePicker.Value = DateTime.Today;
                ShowDialog("Invalid date");
                return;
            }
            else
            {
                publishDateTimePicker.Format = DateTimePickerFormat.Long;
                selectedDate = publishDateTimePicker.Value;
                selectedDateNotNull = selectedDate.Value;
            }
        }

        private void RemoveDateButton_Click(object sender, EventArgs e)
        {
            RemoveDate();
        }

        void RemoveDate()
        {
            initialized = false;
            selectedDate = null;
            selectedDateNotNull = DateTime.Today.AddDays(-1);
            publishDateTimePicker.Value = DateTime.Today.AddDays(-1);
            publishDateTimePicker.Format = DateTimePickerFormat.Custom;
        }
        #endregion

        void ReloadLists()
        {
            if (areaPapers.Items != null) areaPapers.Items.Clear();
            if (areaPaperList != null) areaPaperList.Clear();
            if (publishedPapers.Items != null) publishedPapers.Items.Clear();
            if(publishedPaperList != null) publishedPaperList.Clear();

            publishedPaperList = service.GetPapersNotYetPublishedInIssue(issueId);
            if (publishedPaperList != null)
            {
                for (int i = 0; i < publishedPaperList.Count; i++)
                {
                    publishedPapers.Items.Add(publishedPaperList[i].Title);
                }
            }
            areaPaperList = service.GetPapersPendingPublication(areaList[areasComboBox.SelectedIndex].Id);
            for (int i = 0; i < areaPaperList.Count; i++)
            {
                areaPapers.Items.Add(areaPaperList[i].Title);
            }
        }

        private void areasComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadLists();
        }

        private void areaPapers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = areaPapers.SelectedIndex;
            if (index == -1) return;
            service.PublishPaper(areaPaperList[index].Id);
            ReloadLists();
            areaPapers.SelectedIndex = -1;
        }

        private void papersPublished_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = publishedPapers.SelectedIndex;
            if (index == -1) return;
            service.UnPublishPaper(publishedPaperList[index].Id);
            ReloadLists();
            areaPapers.SelectedIndex = -1;
        }

        private void publishIssue_Click(object sender, EventArgs e)
        {
            try
            {
                service.BuildIssue(issueId, selectedDate);
                ShowDialog("Issue built successfully", "Success", MessageBoxIcon.Information);
                Initialize();
                ReloadLists();
            }
            catch (ServiceException err)
            {
                ShowDialog(err.Message);
            }
        }
    }
}
