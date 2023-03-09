
namespace MagazineApp
{
    partial class BuildIssueForm
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
            this.panelContainer = new System.Windows.Forms.Panel();
            this.RemoveDateButton = new System.Windows.Forms.Button();
            this.publishDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.areasComboBox = new System.Windows.Forms.ComboBox();
            this.issueNumLabel = new System.Windows.Forms.Label();
            this.magazineNumLabel = new System.Windows.Forms.Label();
            this.buildIssuePanel = new System.Windows.Forms.TableLayoutPanel();
            this.selectedAreaLabel = new System.Windows.Forms.Label();
            this.areaPapers = new System.Windows.Forms.ListBox();
            this.label1papers = new System.Windows.Forms.Label();
            this.publishedPapers = new System.Windows.Forms.ListBox();
            this.papersPublishing = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.publishIssue = new System.Windows.Forms.Button();
            this.panelContainer.SuspendLayout();
            this.buildIssuePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.RemoveDateButton);
            this.panelContainer.Controls.Add(this.publishDateTimePicker);
            this.panelContainer.Controls.Add(this.areasComboBox);
            this.panelContainer.Controls.Add(this.issueNumLabel);
            this.panelContainer.Controls.Add(this.magazineNumLabel);
            this.panelContainer.Controls.Add(this.buildIssuePanel);
            this.panelContainer.Location = new System.Drawing.Point(12, 12);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(776, 372);
            this.panelContainer.TabIndex = 0;
            // 
            // RemoveDateButton
            // 
            this.RemoveDateButton.Location = new System.Drawing.Point(343, 80);
            this.RemoveDateButton.Name = "RemoveDateButton";
            this.RemoveDateButton.Size = new System.Drawing.Size(84, 23);
            this.RemoveDateButton.TabIndex = 5;
            this.RemoveDateButton.Text = "Remove Date";
            this.RemoveDateButton.UseVisualStyleBackColor = true;
            this.RemoveDateButton.Click += new System.EventHandler(this.RemoveDateButton_Click);
            // 
            // publishDateTimePicker
            // 
            this.publishDateTimePicker.CustomFormat = " ";
            this.publishDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.publishDateTimePicker.Location = new System.Drawing.Point(128, 80);
            this.publishDateTimePicker.Name = "publishDateTimePicker";
            this.publishDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.publishDateTimePicker.TabIndex = 4;
            this.publishDateTimePicker.ValueChanged += new System.EventHandler(this.publishDateTimePicker_ValueChanged);
            // 
            // areasComboBox
            // 
            this.areasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.areasComboBox.FormattingEnabled = true;
            this.areasComboBox.Location = new System.Drawing.Point(128, 40);
            this.areasComboBox.Name = "areasComboBox";
            this.areasComboBox.Size = new System.Drawing.Size(185, 21);
            this.areasComboBox.TabIndex = 2;
            this.areasComboBox.SelectedIndexChanged += new System.EventHandler(this.areasComboBox_SelectedIndexChanged);
            // 
            // issueNumLabel
            // 
            this.issueNumLabel.AutoSize = true;
            this.issueNumLabel.Location = new System.Drawing.Point(3, 16);
            this.issueNumLabel.Name = "issueNumLabel";
            this.issueNumLabel.Size = new System.Drawing.Size(53, 13);
            this.issueNumLabel.TabIndex = 1;
            this.issueNumLabel.Text = "issueNum";
            // 
            // magazineNumLabel
            // 
            this.magazineNumLabel.AutoSize = true;
            this.magazineNumLabel.Location = new System.Drawing.Point(3, 0);
            this.magazineNumLabel.Name = "magazineNumLabel";
            this.magazineNumLabel.Size = new System.Drawing.Size(49, 13);
            this.magazineNumLabel.TabIndex = 0;
            this.magazineNumLabel.Text = "magNum";
            // 
            // buildIssuePanel
            // 
            this.buildIssuePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buildIssuePanel.ColumnCount = 3;
            this.buildIssuePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3045F));
            this.buildIssuePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.022491F));
            this.buildIssuePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.67301F));
            this.buildIssuePanel.Controls.Add(this.selectedAreaLabel, 0, 0);
            this.buildIssuePanel.Controls.Add(this.areaPapers, 2, 3);
            this.buildIssuePanel.Controls.Add(this.label1papers, 2, 2);
            this.buildIssuePanel.Controls.Add(this.publishedPapers, 0, 3);
            this.buildIssuePanel.Controls.Add(this.papersPublishing, 0, 2);
            this.buildIssuePanel.Controls.Add(this.label1, 0, 1);
            this.buildIssuePanel.Location = new System.Drawing.Point(3, 43);
            this.buildIssuePanel.Name = "buildIssuePanel";
            this.buildIssuePanel.RowCount = 4;
            this.buildIssuePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.buildIssuePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.buildIssuePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.buildIssuePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.buildIssuePanel.Size = new System.Drawing.Size(770, 326);
            this.buildIssuePanel.TabIndex = 0;
            // 
            // selectedAreaLabel
            // 
            this.selectedAreaLabel.AutoSize = true;
            this.selectedAreaLabel.Location = new System.Drawing.Point(3, 0);
            this.selectedAreaLabel.Name = "selectedAreaLabel";
            this.selectedAreaLabel.Size = new System.Drawing.Size(73, 13);
            this.selectedAreaLabel.TabIndex = 0;
            this.selectedAreaLabel.Text = "Selected area";
            // 
            // areaPapers
            // 
            this.areaPapers.FormattingEnabled = true;
            this.areaPapers.Location = new System.Drawing.Point(289, 96);
            this.areaPapers.Name = "areaPapers";
            this.areaPapers.Size = new System.Drawing.Size(250, 147);
            this.areaPapers.TabIndex = 6;
            this.areaPapers.SelectedIndexChanged += new System.EventHandler(this.areaPapers_SelectedIndexChanged);
            // 
            // label1papers
            // 
            this.label1papers.AutoSize = true;
            this.label1papers.Location = new System.Drawing.Point(289, 80);
            this.label1papers.Name = "label1papers";
            this.label1papers.Size = new System.Drawing.Size(135, 13);
            this.label1papers.TabIndex = 4;
            this.label1papers.Text = "Papers pending publication";
            // 
            // publishedPapers
            // 
            this.publishedPapers.FormattingEnabled = true;
            this.publishedPapers.Location = new System.Drawing.Point(3, 96);
            this.publishedPapers.Name = "publishedPapers";
            this.publishedPapers.Size = new System.Drawing.Size(250, 147);
            this.publishedPapers.TabIndex = 7;
            this.publishedPapers.SelectedIndexChanged += new System.EventHandler(this.papersPublished_SelectedIndexChanged);
            // 
            // papersPublishing
            // 
            this.papersPublishing.AutoSize = true;
            this.papersPublishing.Location = new System.Drawing.Point(3, 80);
            this.papersPublishing.Name = "papersPublishing";
            this.papersPublishing.Size = new System.Drawing.Size(152, 13);
            this.papersPublishing.TabIndex = 3;
            this.papersPublishing.Text = "Papers selected for publication";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Issue publication date";
            // 
            // publishIssue
            // 
            this.publishIssue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.publishIssue.Location = new System.Drawing.Point(661, 390);
            this.publishIssue.Name = "publishIssue";
            this.publishIssue.Size = new System.Drawing.Size(127, 48);
            this.publishIssue.TabIndex = 12;
            this.publishIssue.Text = "Publish issue";
            this.publishIssue.UseVisualStyleBackColor = true;
            this.publishIssue.Click += new System.EventHandler(this.publishIssue_Click);
            // 
            // BuildIssueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.publishIssue);
            this.Controls.Add(this.panelContainer);
            this.Name = "BuildIssueForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BuildIssueForm";
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            this.buildIssuePanel.ResumeLayout(false);
            this.buildIssuePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.TableLayoutPanel buildIssuePanel;
        private System.Windows.Forms.Label magazineNumLabel;
        private System.Windows.Forms.Label issueNumLabel;
        private System.Windows.Forms.Label selectedAreaLabel;
        private System.Windows.Forms.ComboBox areasComboBox;
        private System.Windows.Forms.Label papersPublishing;
        private System.Windows.Forms.Label label1papers;
        private System.Windows.Forms.ListBox areaPapers;
        private System.Windows.Forms.ListBox publishedPapers;
        private System.Windows.Forms.DateTimePicker publishDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RemoveDateButton;
        private System.Windows.Forms.Button publishIssue;
    }
}