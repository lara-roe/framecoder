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
            this.LastFrame = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.FirstFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // FirstFrame
            // 
            this.FirstFrame.Location = new System.Drawing.Point(12, 12);
            this.FirstFrame.Name = "FirstFrame";
            this.FirstFrame.Size = new System.Drawing.Size(300, 200);
            this.FirstFrame.TabIndex = 2;
            this.FirstFrame.TabStop = false;
            // 
            // LastFrame
            // 
            this.LastFrame.Location = new System.Drawing.Point(472, 12);
            this.LastFrame.Name = "LastFrame";
            this.LastFrame.Size = new System.Drawing.Size(300, 200);
            this.LastFrame.TabIndex = 3;
            this.LastFrame.TabStop = false;
            // 
            // VideoSplitter
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
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
            ((System.ComponentModel.ISupportInitialize)(this.LastFrame)).EndInit();
            this.ResumeLayout(false);

        }

        private Emgu.CV.UI.ImageBox FirstFrame;
        private Emgu.CV.UI.ImageBox LastFrame;
    }
}

