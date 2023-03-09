
namespace MagazineApp
{
    partial class LoggedForm
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
            this.listPapersButton = new System.Windows.Forms.Button();
            this.evaluatePaperButton = new System.Windows.Forms.Button();
            this.buildIssueButton = new System.Windows.Forms.Button();
            this.paperSubmissionButton = new System.Windows.Forms.Button();
            this.logOutButton = new System.Windows.Forms.Button();
            this.VBox = new System.Windows.Forms.TableLayoutPanel();
            this.loggedAsLabel = new System.Windows.Forms.Label();
            this.HBox = new System.Windows.Forms.TableLayoutPanel();
            this.HBoxContainer = new MagazineApp.MdiClientPanel();
            this.VBox.SuspendLayout();
            this.HBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // listPapersButton
            // 
            this.listPapersButton.Location = new System.Drawing.Point(3, 161);
            this.listPapersButton.Name = "listPapersButton";
            this.listPapersButton.Size = new System.Drawing.Size(200, 40);
            this.listPapersButton.TabIndex = 4;
            this.listPapersButton.Text = "List all Papers";
            this.listPapersButton.UseVisualStyleBackColor = true;
            this.listPapersButton.Click += new System.EventHandler(this.listPapersButton_Click);
            // 
            // evaluatePaperButton
            // 
            this.evaluatePaperButton.Location = new System.Drawing.Point(3, 69);
            this.evaluatePaperButton.Name = "evaluatePaperButton";
            this.evaluatePaperButton.Size = new System.Drawing.Size(200, 40);
            this.evaluatePaperButton.TabIndex = 2;
            this.evaluatePaperButton.Text = "Evaluate a Paper";
            this.evaluatePaperButton.UseVisualStyleBackColor = true;
            this.evaluatePaperButton.Click += new System.EventHandler(this.evaluatePaperButton_Click);
            // 
            // buildIssueButton
            // 
            this.buildIssueButton.Location = new System.Drawing.Point(3, 115);
            this.buildIssueButton.Name = "buildIssueButton";
            this.buildIssueButton.Size = new System.Drawing.Size(200, 40);
            this.buildIssueButton.TabIndex = 3;
            this.buildIssueButton.Text = "Build an Issue";
            this.buildIssueButton.UseVisualStyleBackColor = true;
            this.buildIssueButton.Click += new System.EventHandler(this.buildIssueButton_Click);
            // 
            // paperSubmissionButton
            // 
            this.paperSubmissionButton.Location = new System.Drawing.Point(3, 23);
            this.paperSubmissionButton.Name = "paperSubmissionButton";
            this.paperSubmissionButton.Size = new System.Drawing.Size(200, 40);
            this.paperSubmissionButton.TabIndex = 1;
            this.paperSubmissionButton.Text = "Submit a Paper";
            this.paperSubmissionButton.UseVisualStyleBackColor = true;
            this.paperSubmissionButton.Click += new System.EventHandler(this.paperSubmissionButton_Click);
            // 
            // logOutButton
            // 
            this.logOutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.logOutButton.Location = new System.Drawing.Point(3, 385);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(89, 40);
            this.logOutButton.TabIndex = 5;
            this.logOutButton.Text = "Log Out";
            this.logOutButton.UseVisualStyleBackColor = true;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // VBox
            // 
            this.VBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VBox.ColumnCount = 1;
            this.VBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.VBox.Controls.Add(this.logOutButton, 0, 5);
            this.VBox.Controls.Add(this.listPapersButton, 0, 4);
            this.VBox.Controls.Add(this.buildIssueButton, 0, 3);
            this.VBox.Controls.Add(this.evaluatePaperButton, 0, 2);
            this.VBox.Controls.Add(this.paperSubmissionButton, 0, 1);
            this.VBox.Controls.Add(this.loggedAsLabel, 0, 0);
            this.VBox.Location = new System.Drawing.Point(0, 0);
            this.VBox.Margin = new System.Windows.Forms.Padding(0);
            this.VBox.Name = "VBox";
            this.VBox.RowCount = 6;
            this.VBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.VBox.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.VBox.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.VBox.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.VBox.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.VBox.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.VBox.Size = new System.Drawing.Size(212, 428);
            this.VBox.TabIndex = 6;
            // 
            // loggedAsLabel
            // 
            this.loggedAsLabel.AutoSize = true;
            this.loggedAsLabel.Location = new System.Drawing.Point(3, 0);
            this.loggedAsLabel.Name = "loggedAsLabel";
            this.loggedAsLabel.Size = new System.Drawing.Size(80, 13);
            this.loggedAsLabel.TabIndex = 6;
            this.loggedAsLabel.Text = "Logged as user";
            // 
            // HBox
            // 
            this.HBox.ColumnCount = 2;
            this.HBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.HBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 564F));
            this.HBox.Controls.Add(this.VBox, 0, 0);
            this.HBox.Controls.Add(this.HBoxContainer, 1, 0);
            this.HBox.Location = new System.Drawing.Point(12, 13);
            this.HBox.Margin = new System.Windows.Forms.Padding(0);
            this.HBox.Name = "HBox";
            this.HBox.RowCount = 1;
            this.HBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.HBox.Size = new System.Drawing.Size(776, 428);
            this.HBox.TabIndex = 7;
            // 
            // HBoxContainer
            // 
            this.HBoxContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.HBoxContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HBoxContainer.Location = new System.Drawing.Point(212, 0);
            this.HBoxContainer.Margin = new System.Windows.Forms.Padding(0);
            this.HBoxContainer.Name = "HBoxContainer";
            this.HBoxContainer.Size = new System.Drawing.Size(564, 428);
            this.HBoxContainer.TabIndex = 7;
            // 
            // LoggedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.HBox);
            this.Name = "LoggedForm";
            this.Text = "MagazineApp";
            this.VBox.ResumeLayout(false);
            this.VBox.PerformLayout();
            this.HBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button listPapersButton;
        private System.Windows.Forms.Button evaluatePaperButton;
        private System.Windows.Forms.Button buildIssueButton;
        private System.Windows.Forms.Button paperSubmissionButton;
        private System.Windows.Forms.Button logOutButton;
        private System.Windows.Forms.TableLayoutPanel VBox;
        private System.Windows.Forms.TableLayoutPanel HBox;
        private MdiClientPanel HBoxContainer;
        private System.Windows.Forms.Label loggedAsLabel;
    }
}