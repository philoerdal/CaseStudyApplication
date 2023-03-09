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
    public partial class ListAllPapersForm : BaseForm
    {
        private List<Area> areaList;
        private List<Issue> issueList;
        public ListAllPapersForm(IMagazineISWService service) : base(service)
        {
            InitializeComponent();
            service.CheckChiefEditor();
            selectionBox.SelectedIndex = 0;
        }

        void ShowByArea()
        {
            int areaId = areaList[areaSelectedBox.SelectedIndex].Id;
            BindingList<object> bindinglist = new BindingList<object>();
            try
            {
                List<Paper> PEpapers = service.GetPapersPendingEvaluation(areaId);
                if (PEpapers != null)
                    AddToBinding(bindinglist, PEpapers, "Pending Evaluation");
            }
            catch { }

            try
            {
                List<Paper> PPpapers = service.GetPapersPendingPublication(areaId);
                if (PPpapers != null)
                    AddToBinding(bindinglist, PPpapers, "Pending Publication");
            }
            catch { }

            try
            {
                List<Paper> REpapers = service.GetPapersRejected(areaId);
                if (REpapers != null)
                    AddToBinding(bindinglist, REpapers, "Rejected");
            }
            catch { }

            try
            {
                List<Paper> TBPUpapers = service.GetPapersNotYetPublished(areaId);
                if (TBPUpapers != null)
                    AddToBinding(bindinglist, TBPUpapers, "To Be Published");
            }
            catch (ServiceException err) { ShowDialog(err.Message); }

            try
            {
                List<Paper> TBPUpapers = service.GetPapersToBePublished(areaId);
                if (TBPUpapers != null)
                    foreach (var paper in TBPUpapers)
                    {
                        List<Paper> papers = new List<Paper>();
                        papers.Add(paper);
                        AddToBinding(bindinglist, papers, "Published, avaliable on " + service.GetPaperIssue(paper).PublicationDate.Value.ToShortDateString());
                    }
            }
            catch (ServiceException err) { ShowDialog(err.Message); }

            try
            {
                List<Paper> PUpapers = service.GetPapersPublished(areaId);
                if (PUpapers != null)
                    AddToBinding(bindinglist, PUpapers, "Published");
            }
            catch { }

            paperGridView.DataSource = bindinglist;
        }

        void ShowByIssue()
        {
            int areaId = areaList[areaSelectedBox.SelectedIndex].Id-1;
            BindingList<object> bindinglist = new BindingList<object>();

            try
            {
                List<Paper> TBPUpapers = service.GetPapersNotYetPublishedInIssue(areaId);
                if (TBPUpapers != null)
                    AddToBinding(bindinglist, TBPUpapers, "To Be Published");
            }
            catch (ServiceException err) { ShowDialog(err.Message); }

            try
            {
                List<Paper> TBPUpapers = service.GetPapersToBePublishedInIssue(areaId);
                if (TBPUpapers != null)
                    foreach (var paper in TBPUpapers)
                    {
                        List<Paper> papers = new List<Paper>();
                        papers.Add(paper);
                        AddToBinding(bindinglist, papers, "Published, avaliable on " + service.GetPaperIssue(paper).PublicationDate.Value.ToShortDateString());
                    }
            }
            catch (ServiceException err) { ShowDialog(err.Message); }

            try
            {
                List<Paper> PUpapers = service.GetPapersPublishedInIssue(areaId);
                if (PUpapers != null)
                    AddToBinding(bindinglist, PUpapers, "Published");
            }
            catch { }

            paperGridView.DataSource = bindinglist;
        }

        void AddToBinding(BindingList<object> bindinglist, List<Paper> papers, string state)
        {
            foreach (var paper in papers)
            {
                bindinglist.Add(new
                {
                    //ds_... are DataPropertyNames defined in the DataGridView object
                    //see DataGridView column definitions in Visual Studio Designer
                    ds_title = paper.Title,
                    ds_author = paper.Responsible.Name,
                    ds_state = state
                });
            }
        }

        private void areaSelectedBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selection = selectionBox.SelectedIndex;
            if (selection == 0)
                ShowByArea();
            else if (selection == 1)
                ShowByIssue();
        }

        private void selectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (selectionBox.SelectedIndex == 0)
                    ReloadAreas();
                else if (selectionBox.SelectedIndex == 1)
                    ReloadIssues();

                areaSelectedBox.SelectedIndex = 0;
            }
            catch (ServiceException err)
            {
                ShowDialog(err.Message);
                selectionBox.SelectedIndex = 0;
            }
        }

        public void ReloadAreas()
        {
            service.CheckChiefEditor();
            areaList = service.GetAreas();
            areaSelectedBox.Items.Clear();
            for (int i = 0; i < areaList.Count; i++)
            {
                areaSelectedBox.Items.Add(areaList[i].Name);
            }
            areaSelectedBox.SelectedIndex = 0;
        }
        public void ReloadIssues()
        {
            service.CheckChiefEditor();
            issueList = service.GetIssues();
            areaSelectedBox.Items.Clear();
            for (int i = 0; i < issueList.Count; i++)
            {
                areaSelectedBox.Items.Add(issueList[i].Number);
            }
            areaSelectedBox.SelectedIndex = 0;
        }

        private void ListAllPapersForm_Load(object sender, EventArgs e)
        {

        }
    }
}
