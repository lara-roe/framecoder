namespace PicAnalyzer
{
        partial class PicAnalyzer
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.NextButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.PersonPresent = new System.Windows.Forms.CheckBox();
            this.Fixations = new System.Windows.Forms.GroupBox();
            this.InvalidFixation = new System.Windows.Forms.RadioButton();
            this.SurroundingFixation = new System.Windows.Forms.RadioButton();
            this.BodyFixation = new System.Windows.Forms.RadioButton();
            this.HeadFixation = new System.Windows.Forms.RadioButton();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSubjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CommentTextBox = new System.Windows.Forms.TextBox();
            this.CommentLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Fixations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(41, -77);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(600, 800);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 0);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // NextButton
            // 
            this.NextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NextButton.AutoSize = true;
            this.NextButton.Location = new System.Drawing.Point(674, 676);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(126, 50);
            this.NextButton.TabIndex = 2;
            this.NextButton.Text = "Next Image";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click_1);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.AutoSize = true;
            this.SaveButton.Location = new System.Drawing.Point(844, 676);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(126, 50);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Save/ Close";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click_1);
            // 
            // PersonPresent
            // 
            this.PersonPresent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PersonPresent.AutoSize = true;
            this.PersonPresent.BackColor = System.Drawing.SystemColors.Menu;
            this.PersonPresent.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PersonPresent.Location = new System.Drawing.Point(832, 82);
            this.PersonPresent.Name = "PersonPresent";
            this.PersonPresent.Size = new System.Drawing.Size(97, 17);
            this.PersonPresent.TabIndex = 4;
            this.PersonPresent.Text = "Person present";
            this.PersonPresent.UseVisualStyleBackColor = false;
            this.PersonPresent.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Fixations
            // 
            this.Fixations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Fixations.AutoSize = true;
            this.Fixations.Controls.Add(this.InvalidFixation);
            this.Fixations.Controls.Add(this.SurroundingFixation);
            this.Fixations.Controls.Add(this.BodyFixation);
            this.Fixations.Controls.Add(this.HeadFixation);
            this.Fixations.Location = new System.Drawing.Point(832, 105);
            this.Fixations.Name = "Fixations";
            this.Fixations.Size = new System.Drawing.Size(140, 139);
            this.Fixations.TabIndex = 11;
            this.Fixations.TabStop = false;
            this.Fixations.Text = "Fixations";
            this.Fixations.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // InvalidFixation
            // 
            this.InvalidFixation.AutoSize = true;
            this.InvalidFixation.Location = new System.Drawing.Point(16, 103);
            this.InvalidFixation.Name = "InvalidFixation";
            this.InvalidFixation.Size = new System.Drawing.Size(56, 17);
            this.InvalidFixation.TabIndex = 3;
            this.InvalidFixation.TabStop = true;
            this.InvalidFixation.Text = "Invalid";
            this.InvalidFixation.UseVisualStyleBackColor = true;
            this.InvalidFixation.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged_1);
            // 
            // SurroundingFixation
            // 
            this.SurroundingFixation.AutoSize = true;
            this.SurroundingFixation.Location = new System.Drawing.Point(16, 80);
            this.SurroundingFixation.Name = "SurroundingFixation";
            this.SurroundingFixation.Size = new System.Drawing.Size(87, 17);
            this.SurroundingFixation.TabIndex = 2;
            this.SurroundingFixation.TabStop = true;
            this.SurroundingFixation.Text = "Surroundings";
            this.SurroundingFixation.UseVisualStyleBackColor = true;
            this.SurroundingFixation.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged_1);
            // 
            // BodyFixation
            // 
            this.BodyFixation.AutoSize = true;
            this.BodyFixation.Location = new System.Drawing.Point(16, 57);
            this.BodyFixation.Name = "BodyFixation";
            this.BodyFixation.Size = new System.Drawing.Size(49, 17);
            this.BodyFixation.TabIndex = 1;
            this.BodyFixation.TabStop = true;
            this.BodyFixation.Text = "Body";
            this.BodyFixation.UseVisualStyleBackColor = true;
            this.BodyFixation.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // HeadFixation
            // 
            this.HeadFixation.AutoSize = true;
            this.HeadFixation.Location = new System.Drawing.Point(16, 34);
            this.HeadFixation.Name = "HeadFixation";
            this.HeadFixation.Size = new System.Drawing.Size(51, 17);
            this.HeadFixation.TabIndex = 0;
            this.HeadFixation.TabStop = true;
            this.HeadFixation.Text = "Head";
            this.HeadFixation.UseVisualStyleBackColor = true;
            this.HeadFixation.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged_1);
            // 
            // PreviousButton
            // 
            this.PreviousButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PreviousButton.AutoSize = true;
            this.PreviousButton.Location = new System.Drawing.Point(23, 676);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(126, 50);
            this.PreviousButton.TabIndex = 12;
            this.PreviousButton.Text = "Previous Image";
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Location = new System.Drawing.Point(23, 82);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(777, 588);
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(338, 595);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 14;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(984, 24);
            this.menuStrip.TabIndex = 15;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSubjectToolStripMenuItem,
            this.saveSessionToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openSubjectToolStripMenuItem
            // 
            this.openSubjectToolStripMenuItem.Name = "openSubjectToolStripMenuItem";
            this.openSubjectToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.openSubjectToolStripMenuItem.Text = "Open subject";
            this.openSubjectToolStripMenuItem.Click += new System.EventHandler(this.openSubjectToolStripMenuItem_Click);
            // 
            // saveSessionToolStripMenuItem
            // 
            this.saveSessionToolStripMenuItem.Name = "saveSessionToolStripMenuItem";
            this.saveSessionToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.saveSessionToolStripMenuItem.Text = "Save session";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // CommentTextBox
            // 
            this.CommentTextBox.Location = new System.Drawing.Point(832, 314);
            this.CommentTextBox.Multiline = true;
            this.CommentTextBox.Name = "CommentTextBox";
            this.CommentTextBox.Size = new System.Drawing.Size(140, 78);
            this.CommentTextBox.TabIndex = 16;
            this.CommentTextBox.TextChanged += new System.EventHandler(this.CommentTextBox_TextChanged);
            // 
            // CommentLabel
            // 
            this.CommentLabel.AutoSize = true;
            this.CommentLabel.Enabled = false;
            this.CommentLabel.Location = new System.Drawing.Point(832, 295);
            this.CommentLabel.Name = "CommentLabel";
            this.CommentLabel.Size = new System.Drawing.Size(51, 13);
            this.CommentLabel.TabIndex = 17;
            this.CommentLabel.Text = "Comment";
            this.CommentLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // PicAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 742);
            this.Controls.Add(this.CommentLabel);
            this.Controls.Add(this.CommentTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.Fixations);
            this.Controls.Add(this.PersonPresent);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "PicAnalyzer";
            this.Text = "PicAnalyzer";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Fixations.ResumeLayout(false);
            this.Fixations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

            #endregion

            private System.Windows.Forms.PictureBox pictureBox1;
            private System.Windows.Forms.Button NextButton;
            private System.Windows.Forms.Button SaveButton;
            private System.Windows.Forms.CheckBox PersonPresent;
            private System.Windows.Forms.GroupBox Fixations;
            private System.Windows.Forms.RadioButton SurroundingFixation;
            private System.Windows.Forms.RadioButton BodyFixation;
            private System.Windows.Forms.RadioButton HeadFixation;
            private System.Windows.Forms.RadioButton InvalidFixation;
            private System.Windows.Forms.Button PreviousButton;
            private System.Windows.Forms.PictureBox pictureBox2;
            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.MenuStrip menuStrip;
            private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
            private System.Windows.Forms.ToolStripMenuItem openSubjectToolStripMenuItem;
            private System.Windows.Forms.ToolStripMenuItem saveSessionToolStripMenuItem;
            private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
            private System.Windows.Forms.TextBox CommentTextBox;
            private System.Windows.Forms.Label CommentLabel;
    }
    }

