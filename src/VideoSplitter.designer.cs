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
            this.LastFrame = new Emgu.CV.UI.ImageBox();
            this.label1 = new System.Windows.Forms.Label();
            this.currentFrameLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FirstFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startFrameControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nFramesControl)).BeginInit();
            this.conversionProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LastFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // FirstFrame
            // 
            this.FirstFrame.Location = new System.Drawing.Point(12, 28);
            this.FirstFrame.Name = "FirstFrame";
            this.FirstFrame.Size = new System.Drawing.Size(150, 100);
            this.FirstFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FirstFrame.TabIndex = 2;
            this.FirstFrame.TabStop = false;
            // 
            // startFrameControl
            // 
            this.startFrameControl.Location = new System.Drawing.Point(110, 27);
            this.startFrameControl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.startFrameControl.Name = "startFrameControl";
            this.startFrameControl.Size = new System.Drawing.Size(120, 20);
            this.startFrameControl.TabIndex = 5;
            this.startFrameControl.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.startFrameControl.ValueChanged += new System.EventHandler(this.startFrameControl_ValueChanged);
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
            this.nFramesControl.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
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
            this.conversionProperties.Location = new System.Drawing.Point(12, 134);
            this.conversionProperties.Name = "conversionProperties";
            this.conversionProperties.Size = new System.Drawing.Size(300, 87);
            this.conversionProperties.TabIndex = 9;
            this.conversionProperties.TabStop = false;
            this.conversionProperties.Text = "Conversion Properties";
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(12, 227);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(146, 23);
            this.convertButton.TabIndex = 10;
            this.convertButton.Text = "Split Images";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // LastFrame
            // 
            this.LastFrame.Location = new System.Drawing.Point(161, 28);
            this.LastFrame.Name = "LastFrame";
            this.LastFrame.Size = new System.Drawing.Size(150, 100);
            this.LastFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LastFrame.TabIndex = 3;
            this.LastFrame.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Starting frame";
            // 
            // currentFrameLabel
            // 
            this.currentFrameLabel.AutoSize = true;
            this.currentFrameLabel.Location = new System.Drawing.Point(161, 8);
            this.currentFrameLabel.Name = "currentFrameLabel";
            this.currentFrameLabel.Size = new System.Drawing.Size(0, 13);
            this.currentFrameLabel.TabIndex = 12;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(164, 227);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(147, 23);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // VideoSplitter
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(324, 259);
            this.ControlBox = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.currentFrameLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.conversionProperties);
            this.Controls.Add(this.LastFrame);
            this.Controls.Add(this.FirstFrame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VideoSplitter";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Split video";
            ((System.ComponentModel.ISupportInitialize)(this.FirstFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startFrameControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nFramesControl)).EndInit();
            this.conversionProperties.ResumeLayout(false);
            this.conversionProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LastFrame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Emgu.CV.UI.ImageBox FirstFrame;
        private System.Windows.Forms.NumericUpDown startFrameControl;
        private System.Windows.Forms.Label startFrameLabel;
        private System.Windows.Forms.Label nFramesLabel;
        private System.Windows.Forms.NumericUpDown nFramesControl;
        private System.Windows.Forms.GroupBox conversionProperties;
        private System.Windows.Forms.Button convertButton;
        private Emgu.CV.UI.ImageBox LastFrame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label currentFrameLabel;
        private System.Windows.Forms.Button cancelButton;
    }
}

