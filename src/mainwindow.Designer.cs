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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PicAnalyzer));
            this.NextButton = new System.Windows.Forms.Button();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSubjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportVideoFramesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // NextButton
            // 
            this.NextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NextButton.AutoSize = true;
            this.NextButton.Enabled = false;
            this.NextButton.Location = new System.Drawing.Point(772, 612);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(126, 50);
            this.NextButton.TabIndex = 2;
            this.NextButton.Text = "Next Image";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click_1);
            // 
            // PreviousButton
            // 
            this.PreviousButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PreviousButton.AutoSize = true;
            this.PreviousButton.Enabled = false;
            this.PreviousButton.Location = new System.Drawing.Point(12, 612);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(126, 50);
            this.PreviousButton.TabIndex = 12;
            this.PreviousButton.Text = "Previous Image";
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click_1);
            // 
            // imageBox
            // 
            this.imageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageBox.Location = new System.Drawing.Point(12, 27);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(886, 577);
            this.imageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBox.TabIndex = 13;
            this.imageBox.TabStop = false;
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Window;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1093, 24);
            this.menuStrip.TabIndex = 15;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSubjectToolStripMenuItem,
            this.splitVideoToolStripMenuItem,
            this.toolStripSeparator2,
            this.saveSessionToolStripMenuItem,
            this.loadSessionToolStripMenuItem,
            this.toolStripSeparator1,
            this.exportToolStripMenuItem,
            this.exportVideoFramesToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openSubjectToolStripMenuItem
            // 
            this.openSubjectToolStripMenuItem.Name = "openSubjectToolStripMenuItem";
            this.openSubjectToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.openSubjectToolStripMenuItem.Text = "Open subject folder";
            this.openSubjectToolStripMenuItem.Click += new System.EventHandler(this.openSubjectToolStripMenuItem_Click);
            // 
            // splitVideoToolStripMenuItem
            // 
            this.splitVideoToolStripMenuItem.Name = "splitVideoToolStripMenuItem";
            this.splitVideoToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.splitVideoToolStripMenuItem.Text = "Open subject video";
            this.splitVideoToolStripMenuItem.Click += new System.EventHandler(this.splitVideoToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(175, 6);
            // 
            // saveSessionToolStripMenuItem
            // 
            this.saveSessionToolStripMenuItem.Name = "saveSessionToolStripMenuItem";
            this.saveSessionToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.saveSessionToolStripMenuItem.Text = "Save session";
            this.saveSessionToolStripMenuItem.Click += new System.EventHandler(this.saveSessionToolStripMenuItem_Click);
            // 
            // loadSessionToolStripMenuItem
            // 
            this.loadSessionToolStripMenuItem.Name = "loadSessionToolStripMenuItem";
            this.loadSessionToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.loadSessionToolStripMenuItem.Text = "Load session";
            this.loadSessionToolStripMenuItem.Click += new System.EventHandler(this.loadSessionToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.exportToolStripMenuItem.Text = "Export .csv";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // exportVideoFramesToolStripMenuItem
            // 
            this.exportVideoFramesToolStripMenuItem.Name = "exportVideoFramesToolStripMenuItem";
            this.exportVideoFramesToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.exportVideoFramesToolStripMenuItem.Text = "Export images";
            this.exportVideoFramesToolStripMenuItem.Click += new System.EventHandler(this.exportVideoFramesToolStripMenuItem_Click);
            // 
            // dataBox
            // 
            this.dataBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataBox.Location = new System.Drawing.Point(904, 27);
            this.dataBox.Name = "dataBox";
            this.dataBox.Size = new System.Drawing.Size(177, 604);
            this.dataBox.TabIndex = 19;
            this.dataBox.TabStop = false;
            this.dataBox.Text = "Data Entry";
            // 
            // PicAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1093, 671);
            this.Controls.Add(this.dataBox);
            this.Controls.Add(this.imageBox);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "PicAnalyzer";
            this.Text = "PicAnalyzer";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

            #endregion
        
            private System.Windows.Forms.Button NextButton;
            private System.Windows.Forms.Button PreviousButton;
            private System.Windows.Forms.PictureBox imageBox;
            private System.Windows.Forms.MenuStrip menuStrip;
            private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
            private System.Windows.Forms.ToolStripMenuItem openSubjectToolStripMenuItem;
            private System.Windows.Forms.ToolStripMenuItem saveSessionToolStripMenuItem;
            private System.Windows.Forms.ToolStripMenuItem loadSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem splitVideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exportVideoFramesToolStripMenuItem;
        private System.Windows.Forms.GroupBox dataBox;
    }
    }

