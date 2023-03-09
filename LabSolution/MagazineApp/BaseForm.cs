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
    public partial class BaseForm : Form
    {
        public IMagazineISWService service;

        public BaseForm()
        {
            InitializeComponent();
        }

        public BaseForm(IMagazineISWService service) : this()
        {
            this.service = service;
        }

        public void ShowDialog(string text, string error = "Error", MessageBoxIcon errorIcon = MessageBoxIcon.Error) 
        {
            DialogResult answer = MessageBox.Show(this, text, error, MessageBoxButtons.OK, errorIcon);
        }
    }
}
