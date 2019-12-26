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
            this.endFrameControl = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.ControlTabs = new System.Windows.Forms.TabControl();
            this.NFramesTab = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.FrameIntervalTab = new System.Windows.Forms.TabPage();
            this.frameIntervalControl = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.TimeIntervalTab = new System.Windows.Forms.TabPage();
            this.timeIntervalControl = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.convertButton = new System.Windows.Forms.Button();
            this.LastFrame = new Emgu.CV.UI.ImageBox();
            this.label1 = new System.Windows.Forms.Label();
            this.currentFrameLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FirstFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startFrameControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nFramesControl)).BeginInit();
            this.conversionProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.endFrameControl)).BeginInit();
            this.ControlTabs.SuspendLayout();
            this.NFramesTab.SuspendLayout();
            this.FrameIntervalTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frameIntervalControl)).BeginInit();
            this.TimeIntervalTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeIntervalControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // FirstFrame
            // 
            this.FirstFrame.Location = new System.Drawing.Point(12, 28);
            this.FirstFrame.Name = "FirstFrame";
            this.FirstFrame.Size = new System.Drawing.Size(148, 99);
            this.FirstFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FirstFrame.TabIndex = 2;
            this.FirstFrame.TabStop = false;
            // 
            // startFrameControl
            // 
            this.startFrameControl.Location = new System.Drawing.Point(78, 23);
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
            this.startFrameLabel.Location = new System.Drawing.Point(14, 25);
            this.startFrameLabel.Name = "startFrameLabel";
            this.startFrameLabel.Size = new System.Drawing.Size(61, 13);
            this.startFrameLabel.TabIndex = 6;
            this.startFrameLabel.Text = "Start Frame";
            // 
            // nFramesLabel
            // 
            this.nFramesLabel.AutoSize = true;
            this.nFramesLabel.Location = new System.Drawing.Point(6, 26);
            this.nFramesLabel.Name = "nFramesLabel";
            this.nFramesLabel.Size = new System.Drawing.Size(90, 13);
            this.nFramesLabel.TabIndex = 8;
            this.nFramesLabel.Text = "Number of frames";
            // 
            // nFramesControl
            // 
            this.nFramesControl.Location = new System.Drawing.Point(102, 24);
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
            this.conversionProperties.Controls.Add(this.endFrameControl);
            this.conversionProperties.Controls.Add(this.label2);
            this.conversionProperties.Controls.Add(this.ControlTabs);
            this.conversionProperties.Controls.Add(this.startFrameControl);
            this.conversionProperties.Controls.Add(this.startFrameLabel);
            this.conversionProperties.Location = new System.Drawing.Point(12, 134);
            this.conversionProperties.Name = "conversionProperties";
            this.conversionProperties.Size = new System.Drawing.Size(300, 176);
            this.conversionProperties.TabIndex = 9;
            this.conversionProperties.TabStop = false;
            this.conversionProperties.Text = "Conversion Properties";
            // 
            // endFrameControl
            // 
            this.endFrameControl.Location = new System.Drawing.Point(78, 50);
            this.endFrameControl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.endFrameControl.Name = "endFrameControl";
            this.endFrameControl.Size = new System.Drawing.Size(120, 20);
            this.endFrameControl.TabIndex = 10;
            this.endFrameControl.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.endFrameControl.ValueChanged += new System.EventHandler(this.endFrameControl_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "End Frame";
            // 
            // ControlTabs
            // 
            this.ControlTabs.Controls.Add(this.NFramesTab);
            this.ControlTabs.Controls.Add(this.FrameIntervalTab);
            this.ControlTabs.Controls.Add(this.TimeIntervalTab);
            this.ControlTabs.Location = new System.Drawing.Point(17, 80);
            this.ControlTabs.Name = "ControlTabs";
            this.ControlTabs.SelectedIndex = 0;
            this.ControlTabs.Size = new System.Drawing.Size(268, 82);
            this.ControlTabs.TabIndex = 9;
            // 
            // NFramesTab
            // 
            this.NFramesTab.Controls.Add(this.label5);
            this.NFramesTab.Controls.Add(this.nFramesControl);
            this.NFramesTab.Controls.Add(this.nFramesLabel);
            this.NFramesTab.Location = new System.Drawing.Point(4, 22);
            this.NFramesTab.Name = "NFramesTab";
            this.NFramesTab.Padding = new System.Windows.Forms.Padding(3);
            this.NFramesTab.Size = new System.Drawing.Size(260, 56);
            this.NFramesTab.TabIndex = 0;
            this.NFramesTab.Text = "Number of frames";
            this.NFramesTab.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label5.Location = new System.Drawing.Point(6, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(217, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Pick x equally spaced frames from the video.\r\n";
            // 
            // FrameIntervalTab
            // 
            this.FrameIntervalTab.Controls.Add(this.label6);
            this.FrameIntervalTab.Controls.Add(this.frameIntervalControl);
            this.FrameIntervalTab.Controls.Add(this.label3);
            this.FrameIntervalTab.Location = new System.Drawing.Point(4, 22);
            this.FrameIntervalTab.Name = "FrameIntervalTab";
            this.FrameIntervalTab.Padding = new System.Windows.Forms.Padding(3);
            this.FrameIntervalTab.Size = new System.Drawing.Size(260, 56);
            this.FrameIntervalTab.TabIndex = 1;
            this.FrameIntervalTab.Text = "Frame Interval";
            this.FrameIntervalTab.UseVisualStyleBackColor = true;
            // 
            // frameIntervalControl
            // 
            this.frameIntervalControl.Location = new System.Drawing.Point(85, 24);
            this.frameIntervalControl.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.frameIntervalControl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.frameIntervalControl.Name = "frameIntervalControl";
            this.frameIntervalControl.Size = new System.Drawing.Size(120, 20);
            this.frameIntervalControl.TabIndex = 12;
            this.frameIntervalControl.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Frame interval";
            // 
            // TimeIntervalTab
            // 
            this.TimeIntervalTab.Controls.Add(this.label7);
            this.TimeIntervalTab.Controls.Add(this.timeIntervalControl);
            this.TimeIntervalTab.Controls.Add(this.label4);
            this.TimeIntervalTab.Location = new System.Drawing.Point(4, 22);
            this.TimeIntervalTab.Name = "TimeIntervalTab";
            this.TimeIntervalTab.Padding = new System.Windows.Forms.Padding(3);
            this.TimeIntervalTab.Size = new System.Drawing.Size(260, 56);
            this.TimeIntervalTab.TabIndex = 2;
            this.TimeIntervalTab.Text = "Time interval";
            this.TimeIntervalTab.UseVisualStyleBackColor = true;
            // 
            // timeIntervalControl
            // 
            this.timeIntervalControl.DecimalPlaces = 3;
            this.timeIntervalControl.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.timeIntervalControl.Location = new System.Drawing.Point(101, 24);
            this.timeIntervalControl.Minimum = new decimal(new int[] {
            33333333,
            0,
            0,
            393216});
            this.timeIntervalControl.Name = "timeIntervalControl";
            this.timeIntervalControl.Size = new System.Drawing.Size(120, 20);
            this.timeIntervalControl.TabIndex = 14;
            this.timeIntervalControl.Value = new decimal(new int[] {
            33333333,
            0,
            0,
            393216});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Time interval (ms)";
            // 
            // convertButton
            // 
            this.convertButton.Location = new System.Drawing.Point(13, 316);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(146, 23);
            this.convertButton.TabIndex = 10;
            this.convertButton.Text = "Split Images";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // LastFrame
            // 
            this.LastFrame.Location = new System.Drawing.Point(164, 28);
            this.LastFrame.Name = "LastFrame";
            this.LastFrame.Size = new System.Drawing.Size(148, 99);
            this.LastFrame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LastFrame.TabIndex = 3;
            this.LastFrame.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Start Frame";
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
            this.cancelButton.Location = new System.Drawing.Point(165, 316);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(147, 23);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label6.Location = new System.Drawing.Point(6, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Pick each xth frame from the video.\r\n";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label7.Location = new System.Drawing.Point(6, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(171, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Pick frames at x milliseconds apart.";
            // 
            // VideoSplitter
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(324, 351);
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
            ((System.ComponentModel.ISupportInitialize)(this.endFrameControl)).EndInit();
            this.ControlTabs.ResumeLayout(false);
            this.NFramesTab.ResumeLayout(false);
            this.NFramesTab.PerformLayout();
            this.FrameIntervalTab.ResumeLayout(false);
            this.FrameIntervalTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frameIntervalControl)).EndInit();
            this.TimeIntervalTab.ResumeLayout(false);
            this.TimeIntervalTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeIntervalControl)).EndInit();
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
        private System.Windows.Forms.NumericUpDown endFrameControl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl ControlTabs;
        private System.Windows.Forms.TabPage NFramesTab;
        private System.Windows.Forms.TabPage FrameIntervalTab;
        private System.Windows.Forms.NumericUpDown frameIntervalControl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage TimeIntervalTab;
        private System.Windows.Forms.NumericUpDown timeIntervalControl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

