
namespace MagazineApp
{
    partial class EvaluatePaperForm
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
            this.commentField = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pendingLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.papersListBox = new System.Windows.Forms.ListBox();
            this.areaSelectedBox = new System.Windows.Forms.ComboBox();
            this.AreaLabel = new System.Windows.Forms.Label();
            this.acceptedCheckBox = new System.Windows.Forms.CheckBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // commentField
            // 
            this.commentField.Location = new System.Drawing.Point(167, 154);
            this.commentField.Name = "commentField";
            this.commentField.Size = new System.Drawing.Size(192, 20);
            this.commentField.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Comment";
            // 
            // pendingLabel
            // 
            this.pendingLabel.AutoSize = true;
            this.pendingLabel.Location = new System.Drawing.Point(3, 27);
            this.pendingLabel.Name = "pendingLabel";
            this.pendingLabel.Size = new System.Drawing.Size(133, 13);
            this.pendingLabel.TabIndex = 7;
            this.pendingLabel.Text = "Papers pending evaluation";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.63566F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.36434F));
            this.tableLayoutPanel1.Controls.Add(this.papersListBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.areaSelectedBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pendingLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.AreaLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.commentField, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.acceptedCheckBox, 1, 3);
            this.tableLayoutPanel1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(387, 255);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // papersListBox
            // 
            this.papersListBox.FormattingEnabled = true;
            this.papersListBox.Location = new System.Drawing.Point(167, 30);
            this.papersListBox.Name = "papersListBox";
            this.papersListBox.Size = new System.Drawing.Size(192, 95);
            this.papersListBox.TabIndex = 2;
            // 
            // areaSelectedBox
            // 
            this.areaSelectedBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.areaSelectedBox.FormattingEnabled = true;
            this.areaSelectedBox.Location = new System.Drawing.Point(167, 3);
            this.areaSelectedBox.Name = "areaSelectedBox";
            this.areaSelectedBox.Size = new System.Drawing.Size(192, 21);
            this.areaSelectedBox.TabIndex = 1;
            this.areaSelectedBox.SelectedIndexChanged += new System.EventHandler(this.areaSelectedBox_SelectedIndexChanged);
            // 
            // AreaLabel
            // 
            this.AreaLabel.AutoSize = true;
            this.AreaLabel.Location = new System.Drawing.Point(3, 0);
            this.AreaLabel.Name = "AreaLabel";
            this.AreaLabel.Size = new System.Drawing.Size(74, 13);
            this.AreaLabel.TabIndex = 19;
            this.AreaLabel.Text = "Selected Area";
            // 
            // acceptedCheckBox
            // 
            this.acceptedCheckBox.AutoSize = true;
            this.acceptedCheckBox.Location = new System.Drawing.Point(167, 131);
            this.acceptedCheckBox.Name = "acceptedCheckBox";
            this.acceptedCheckBox.Size = new System.Drawing.Size(72, 17);
            this.acceptedCheckBox.TabIndex = 3;
            this.acceptedCheckBox.Text = "Accepted";
            this.acceptedCheckBox.UseVisualStyleBackColor = true;
            // 
            // submitButton
            // 
            this.submitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.submitButton.Location = new System.Drawing.Point(272, 273);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(127, 48);
            this.submitButton.TabIndex = 21;
            this.submitButton.Text = "Evaluate paper";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // EvaluatePaperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 330);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EvaluatePaperForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EvaluatePaperForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox commentField;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label pendingLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox areaSelectedBox;
        private System.Windows.Forms.Label AreaLabel;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.ListBox papersListBox;
        private System.Windows.Forms.CheckBox acceptedCheckBox;
    }
}