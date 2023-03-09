
namespace MagazineApp
{
    partial class ListAllPapersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.paperGridView = new System.Windows.Forms.DataGridView();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuthorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaperState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.papersbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.areaSelectedBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.selectionBox = new System.Windows.Forms.ComboBox();
            this.filterby = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.paperGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.papersbindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // paperGridView
            // 
            this.paperGridView.AllowUserToAddRows = false;
            this.paperGridView.AllowUserToDeleteRows = false;
            this.paperGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paperGridView.AutoGenerateColumns = false;
            this.paperGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.paperGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.paperGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title,
            this.AuthorName,
            this.PaperState});
            this.paperGridView.DataSource = this.papersbindingSource;
            this.paperGridView.Location = new System.Drawing.Point(0, 0);
            this.paperGridView.Name = "paperGridView";
            this.paperGridView.ReadOnly = true;
            this.paperGridView.Size = new System.Drawing.Size(776, 399);
            this.paperGridView.TabIndex = 0;
            // 
            // Title
            // 
            this.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Title.DataPropertyName = "ds_title";
            this.Title.FillWeight = 98.43295F;
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Title.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Title.Width = 150;
            // 
            // AuthorName
            // 
            this.AuthorName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AuthorName.DataPropertyName = "ds_author";
            this.AuthorName.FillWeight = 69.50707F;
            this.AuthorName.HeaderText = "Author Name";
            this.AuthorName.Name = "AuthorName";
            this.AuthorName.ReadOnly = true;
            this.AuthorName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AuthorName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // PaperState
            // 
            this.PaperState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PaperState.DataPropertyName = "ds_state";
            this.PaperState.FillWeight = 105.9178F;
            this.PaperState.HeaderText = "State";
            this.PaperState.Name = "PaperState";
            this.PaperState.ReadOnly = true;
            this.PaperState.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PaperState.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // areaSelectedBox
            // 
            this.areaSelectedBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.areaSelectedBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.areaSelectedBox.FormattingEnabled = true;
            this.areaSelectedBox.Location = new System.Drawing.Point(584, 0);
            this.areaSelectedBox.Name = "areaSelectedBox";
            this.areaSelectedBox.Size = new System.Drawing.Size(192, 21);
            this.areaSelectedBox.TabIndex = 2;
            this.areaSelectedBox.SelectedIndexChanged += new System.EventHandler(this.areaSelectedBox_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.selectionBox);
            this.panel1.Controls.Add(this.filterby);
            this.panel1.Controls.Add(this.areaSelectedBox);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 426);
            this.panel1.TabIndex = 4;
            // 
            // selectionBox
            // 
            this.selectionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectionBox.FormattingEnabled = true;
            this.selectionBox.Items.AddRange(new object[] {
            "Area",
            "Issue number"});
            this.selectionBox.Location = new System.Drawing.Point(51, 0);
            this.selectionBox.Name = "selectionBox";
            this.selectionBox.Size = new System.Drawing.Size(192, 21);
            this.selectionBox.TabIndex = 5;
            this.selectionBox.SelectedIndexChanged += new System.EventHandler(this.selectionBox_SelectedIndexChanged);
            // 
            // filterby
            // 
            this.filterby.AutoSize = true;
            this.filterby.Location = new System.Drawing.Point(3, 1);
            this.filterby.Name = "filterby";
            this.filterby.Size = new System.Drawing.Size(46, 13);
            this.filterby.TabIndex = 3;
            this.filterby.Text = "Filter by:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.paperGridView);
            this.panel2.Location = new System.Drawing.Point(12, 39);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(776, 399);
            this.panel2.TabIndex = 4;
            // 
            // ListAllPapersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ListAllPapersForm";
            this.Text = "ListAllPapersForm";
            this.Load += new System.EventHandler(this.ListAllPapersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.paperGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.papersbindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView paperGridView;
        private System.Windows.Forms.BindingSource papersbindingSource;
        private System.Windows.Forms.ComboBox areaSelectedBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuthorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaperState;
        private System.Windows.Forms.ComboBox selectionBox;
        private System.Windows.Forms.Label filterby;
    }
}