namespace PicAnalyzer
{
        partial class Form1
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
                this.button1 = new System.Windows.Forms.Button();
                this.button2 = new System.Windows.Forms.Button();
                this.button3 = new System.Windows.Forms.Button();
                this.checkBox1 = new System.Windows.Forms.CheckBox();
                this.checkBox3 = new System.Windows.Forms.CheckBox();
                this.checkBox5 = new System.Windows.Forms.CheckBox();
                this.checkBox7 = new System.Windows.Forms.CheckBox();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
                this.SuspendLayout();
                // 
                // pictureBox1
                // 
                this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                this.pictureBox1.Location = new System.Drawing.Point(189, 0);
                this.pictureBox1.Name = "pictureBox1";
                this.pictureBox1.Size = new System.Drawing.Size(963, 358);
                this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                this.pictureBox1.TabIndex = 0;
                this.pictureBox1.TabStop = false;
                // 
                // button1
                // 
                this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                this.button1.Location = new System.Drawing.Point(41, 543);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(187, 62);
                this.button1.TabIndex = 1;
                this.button1.Text = "Choose Subject";
                this.button1.UseVisualStyleBackColor = true;
                this.button1.Click += new System.EventHandler(this.button1_Click_1);
                // 
                // button2
                // 
                this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.button2.Location = new System.Drawing.Point(846, 543);
                this.button2.Name = "button2";
                this.button2.Size = new System.Drawing.Size(187, 62);
                this.button2.TabIndex = 2;
                this.button2.Text = "Next Image";
                this.button2.UseVisualStyleBackColor = true;
                this.button2.Click += new System.EventHandler(this.button2_Click_1);
                // 
                // button3
                // 
                this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.button3.Location = new System.Drawing.Point(1043, 543);
                this.button3.Name = "button3";
                this.button3.Size = new System.Drawing.Size(187, 62);
                this.button3.TabIndex = 3;
                this.button3.Text = "Save/ Close";
                this.button3.UseVisualStyleBackColor = true;
                this.button3.Click += new System.EventHandler(this.button3_Click_1);
                // 
                // checkBox1
                // 
                this.checkBox1.AutoSize = true;
                this.checkBox1.BackColor = System.Drawing.SystemColors.Menu;
                this.checkBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                this.checkBox1.Location = new System.Drawing.Point(317, 567);
                this.checkBox1.Name = "checkBox1";
                this.checkBox1.Size = new System.Drawing.Size(97, 17);
                this.checkBox1.TabIndex = 4;
                this.checkBox1.Text = "Person present";
                this.checkBox1.UseVisualStyleBackColor = false;
                this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
                // 
                // checkBox3
                // 
                this.checkBox3.AutoSize = true;
                this.checkBox3.Location = new System.Drawing.Point(439, 567);
                this.checkBox3.Name = "checkBox3";
                this.checkBox3.Size = new System.Drawing.Size(86, 17);
                this.checkBox3.TabIndex = 6;
                this.checkBox3.Text = "Head fixated";
                this.checkBox3.UseVisualStyleBackColor = true;
                this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
                // 
                // checkBox5
                // 
                this.checkBox5.AutoSize = true;
                this.checkBox5.Location = new System.Drawing.Point(551, 567);
                this.checkBox5.Name = "checkBox5";
                this.checkBox5.Size = new System.Drawing.Size(84, 17);
                this.checkBox5.TabIndex = 8;
                this.checkBox5.Text = "Body fixated";
                this.checkBox5.UseVisualStyleBackColor = true;
                this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
                // 
                // checkBox7
                // 
                this.checkBox7.AutoSize = true;
                this.checkBox7.Location = new System.Drawing.Point(675, 567);
                this.checkBox7.Name = "checkBox7";
                this.checkBox7.Size = new System.Drawing.Size(76, 17);
                this.checkBox7.TabIndex = 10;
                this.checkBox7.Text = "No fixation";
                this.checkBox7.UseVisualStyleBackColor = true;
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(1255, 645);
                this.Controls.Add(this.checkBox7);
                this.Controls.Add(this.checkBox5);
                this.Controls.Add(this.checkBox3);
                this.Controls.Add(this.checkBox1);
                this.Controls.Add(this.button3);
                this.Controls.Add(this.button2);
                this.Controls.Add(this.button1);
                this.Controls.Add(this.pictureBox1);
                this.Name = "Form1";
                this.Text = "Form1";
                this.Load += new System.EventHandler(this.Form1_Load_1);
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
                this.ResumeLayout(false);
                this.PerformLayout();

            }

            #endregion

            private System.Windows.Forms.PictureBox pictureBox1;
            private System.Windows.Forms.Button button1;
            private System.Windows.Forms.Button button2;
            private System.Windows.Forms.Button button3;
            private System.Windows.Forms.CheckBox checkBox1;
            private System.Windows.Forms.CheckBox checkBox3;
            private System.Windows.Forms.CheckBox checkBox5;
            private System.Windows.Forms.CheckBox checkBox7;
        }
    }

