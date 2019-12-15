namespace FrameCoder
{
    partial class VideoSplitter
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.FirstFrame = new Emgu.CV.UI.ImageBox();
            this.startFrameControl = new System.Windows.Forms.NumericUpDown();
            this.startFrameLabel = new System.Windows.Forms.Label();
            this.nFramesLabel = new System.Windows.Forms.Label();
            this.nFramesControl = new System.Windows.Forms.NumericUpDown();
            this.conversionProperties = new System.Windows.Forms.GroupBox();
            this.convertButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.LastFrame = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.FirstFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startFrameControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nFramesControl)).BeginInit();
            this.conversionProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LastFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // FirstFrame
            // 
            this.FirstFrame.Location = new System.Drawing.Point(12, 12);
            this.FirstFrame.Name = "FirstFrame";
            this.FirstFrame.Size = new System.Drawing.Size(150, 100);
            this.FirstFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FirstFrame.TabIndex = 2;
            this.FirstFrame.TabStop = false;
            // 
            // startFrameControl
            // 
            this.startFrameControl.Location = new System.Drawing.Point(110, 27);
            this.startFrameControl.Name = "startFrameControl";
            this.startFrameControl.Size = new System.Drawing.Size(120, 20);
            this.startFrameControl.TabIndex = 5;
            this.startFrameControl.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // startFrameLabel
            // 
            this.startFrameLabel.AutoSize = true;
            this.startFrameLabel.Location = new System.Drawing.Point(14, 29);
            this.startFrameLabel.Name = "startFrameLabel";
            this.startFrameLabel.Size = new System.Drawing.Size(75, 13);
            this.startFrameLabel.TabIndex = 6;
            this.startFrameLabel.Text = "Starting Frame";
            // 
            // nFramesLabel
            // 
            this.nFramesLabel.AutoSize = true;
            this.nFramesLabel.Location = new System.Drawing.Point(14, 55);
            this.nFramesLabel.Name = "nFramesLabel";
            this.nFramesLabel.Size = new System.Drawing.Size(90, 13);
            this.nFramesLabel.TabIndex = 8;
            this.nFramesLabel.Text = "Number of frames";
            // 
            // nFramesControl
            // 
            this.nFramesControl.Location = new System.Drawing.Point(110, 53);
            this.nFramesControl.Name = "nFramesControl";
            this.nFramesControl.Size = new System.Drawing.Size(120, 20);
            this.nFramesControl.TabIndex = 7;
            this.nFramesControl.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // conversionProperties
            // 
            this.conversionProperties.Controls.Add(this.nFramesControl);
            this.conversionProperties.Controls.Add(this.nFramesLabel);
            this.conversionProperties.Controls.Add(this.startFrameControl);
            this.conversionProperties.Controls.Add(this.startFrameLabel);
            this.conversionProperties.Location = new System.Drawing.Point(12, 218);
            this.conversionProperties.Name = "conversionProperties";
            this.conversionProperties.Size = new System.Drawing.Size(300, 87);
            this.conversionProperties.TabIndex = 9;
            this.conversionProperties.TabStop = false;
            this.conversionProperties.Text = "Conversion Properties";
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(12, 311);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(104, 23);
            this.convertButton.TabIndex = 10;
            this.convertButton.Text = "Split Images";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(208, 311);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(104, 23);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "Save and exit";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // LastFrame
            // 
            this.LastFrame.Location = new System.Drawing.Point(162, 112);
            this.LastFrame.Name = "LastFrame";
            this.LastFrame.Size = new System.Drawing.Size(150, 100);
            this.LastFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LastFrame.TabIndex = 3;
            this.LastFrame.TabStop = false;
            // 
            // VideoSplitter
            // 
            this.ClientSize = new System.Drawing.Size(323, 342);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.conversionProperties);
            this.Controls.Add(this.LastFrame);
            this.Controls.Add(this.FirstFrame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VideoSplitter";
            this.ShowIcon = false;
            this.Text = "framecoder video splitter";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.FirstFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startFrameControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nFramesControl)).EndInit();
            this.conversionProperties.ResumeLayout(false);
            this.conversionProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LastFrame)).EndInit();
            this.ResumeLayout(false);

        }

        private Emgu.CV.UI.ImageBox FirstFrame;
        private System.Windows.Forms.NumericUpDown startFrameControl;
        private System.Windows.Forms.Label startFrameLabel;
        private System.Windows.Forms.Label nFramesLabel;
        private System.Windows.Forms.NumericUpDown nFramesControl;
        private System.Windows.Forms.GroupBox conversionProperties;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.Button saveButton;
        private Emgu.CV.UI.ImageBox LastFrame;
    }
}

