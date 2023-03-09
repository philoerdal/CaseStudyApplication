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
    public partial class PaperSubmissionForm : BaseForm
    {
        private int selectedArea;
        private List<Area> areaList;
        private List<Person> personList;
        public PaperSubmissionForm(IMagazineISWService service) : base(service)
        {
            InitializeComponent();
            ReloadData();
        }

        void ReloadData()
        {
            //Add area names to the areaBox
            areaList = service.GetAreas();
            areaBox.Items.Clear();
            for (int i = 0; i < areaList.Count; i++)
            {
                areaBox.Items.Add(areaList[i].Name);
            }
            areaBox.SelectedIndex = 0;

            personList = service.GetPeople();
            coAuthorsCheckedListBox.Items.Clear();
            for (int i = 0; i < personList.Count; i++)
            {
                coAuthorsCheckedListBox.Items.Add(personList[i].Name);
            }
            coAuthorsCheckedListBox.SelectedIndex = 0;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<Person> peopleSelected = new List<Person>();
                for(int i = 0; i < coAuthorsCheckedListBox.CheckedItems.Count; i++)
                {
                    Person selectedPerson = personList[coAuthorsCheckedListBox.CheckedIndices[i]];
                    peopleSelected.Add(selectedPerson);
                }

                if (coAuthorsCheckedListBox.CheckedItems.Count != 0) 
                {
                    service.SubmitPaperWithCoAuthors(areaList[selectedArea].Id, paperField.Text, DateTime.Today, peopleSelected);
                }
                else
                {
                    service.SubmitPaper(areaList[selectedArea].Id, paperField.Text, DateTime.Today);
                }
                ShowDialog("Paper submitted successfully", "Success", MessageBoxIcon.Information);
                paperField.Text = "";
                ReloadData();
            }
            catch (ServiceException err)
            {
                ShowDialog(err.Message);
            }
        }

        private void areaBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedArea = areaBox.SelectedIndex;
        }

        private void addPersonButton_Click(object sender, EventArgs e)
        {
            try
            {
                service.AddPerson(dniTextBox.Text, nameTextBox.Text, surnameTextBox.Text);

                dniTextBox.Text = "";
                nameTextBox.Text = "";
                surnameTextBox.Text = "";
                ReloadData();

            }
            catch(ServiceException err)
            {
                ShowDialog(err.Message);
            }
        }
    }
}
