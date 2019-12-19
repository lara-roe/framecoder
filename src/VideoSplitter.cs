using System;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using Emgu.CV;
using Emgu.CV.Structure;
using WK.Libraries.BetterFolderBrowserNS;

namespace FrameCoder
{
    public partial class VideoSplitter : Form
    {
        private VideoSplitConfig SplitConfig;
        private VideoCapture Cap;
        private string[] Frames;
        private int[] FrameNums;
        private readonly BackgroundWorker Worker = new BackgroundWorker();

        public VideoSplitter(string srcFile)
        {
            InitializeComponent();
            SplitConfig = new VideoSplitConfig(0, 100, srcFile, Path.GetTempPath());
            Cap = new VideoCapture(SplitConfig.SourceFile);
            SplitConfig.FrameCount = (int)Cap.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameCount);
            startFrameControl.Maximum = new decimal(SplitConfig.FrameCount);
            nFramesControl.Maximum = new decimal(SplitConfig.FrameCount);
            Cap.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.PosFrames, 0);
            FirstFrame.Image = Cap.QuerySmallFrame();
            Frames = new string[SplitConfig.NFrames];
            FrameNums = new int[SplitConfig.NFrames];

            // background worker stuff
            Worker.WorkerReportsProgress = true;
            Worker.WorkerSupportsCancellation = true;
            Worker.DoWork += Worker_DoWork;
            Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        public class VideoSplitConfig
        {
            public int StartFrame { get; set; }
            public int NFrames { get; set; }
            public int FrameCount { get; set; }
            public string SourceFile { get; set; }
            public string TempFolder { get; set; }
            public string TargetFolder { get; set; }
            public string Format { get; set; }

            public VideoSplitConfig(int StartFrame, int NFrames, string SourceFile, string TempFolder)
            {
                this.StartFrame = StartFrame;
                this.NFrames = NFrames;
                this.SourceFile = SourceFile;
                this.TempFolder = TempFolder;
                Format = ".jpg";
            }
        }


        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            GetFramesFromVideo();
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UseWaitCursor = false;
            Close();
        }

        public string GetFolder()
        {
            return SplitConfig.TargetFolder;
        }

        private void GetFramesFromVideo()
        {
            Frames = new string[SplitConfig.NFrames];
            FrameNums = new int[SplitConfig.NFrames];
            int width = SplitConfig.FrameCount.ToString().Length;
            int stride = (SplitConfig.FrameCount - SplitConfig.StartFrame) / SplitConfig.NFrames;
            for (int i = 0; i < SplitConfig.NFrames; i++)
            {
                int framenum = i * stride + SplitConfig.StartFrame;
                Cap.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.PosFrames, framenum);
                Mat frame = Cap.QueryFrame();
                LoadFrameInWindow(frame, SplitConfig.NFrames, i);
                if (SplitConfig.TargetFolder == null) break;
                string imagename = Path.Combine(
                    SplitConfig.TargetFolder,
                    (framenum + 1).ToString().PadLeft(width, "0"[0]) + SplitConfig.Format
                );
                Frames[i] = imagename;
                FrameNums[i] = framenum;
                frame.ToImage<Bgr, byte>().Save(imagename);
            }
        }

        private void LoadFrameInWindow(Mat frame, int totalFrames, int currentFrameNum)
        {
            SetFrameLabelText("Frame " + currentFrameNum + " of " + totalFrames + ".");
            LastFrame.Image = frame;
        }

        private delegate void SetFrameLabelTextCallback(string text);

        private void SetFrameLabelText(string text)
        {
            // pattern blatantly stolen from
            // https://stackoverflow.com/a/10775421/8311759
            if (currentFrameLabel.InvokeRequired)
            {
                SetFrameLabelTextCallback d = new SetFrameLabelTextCallback(SetFrameLabelText);
                Invoke(d, new object[] { text });
            }
            else
            {
                currentFrameLabel.Text = text;
            }
        }

        public static string PickVideoFile()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Video files (*.mov;*.avi;*.mp4;*.mkv)|*.mov;*.avi;*.mp4;*.mkv"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                return ofd.FileName;
            }
            else
            {
                return null;
            }
        }
        
        private void convertButton_Click(object sender, EventArgs e)
        {
            BetterFolderBrowser bfb = new BetterFolderBrowser
            {
                Multiselect = false,
                Title = "Subject folder"
            };
            if (bfb.ShowDialog() == DialogResult.OK)
            {
                SplitConfig.TargetFolder = bfb.SelectedPath;
                SplitConfig.NFrames = (int)nFramesControl.Value;
                SplitConfig.StartFrame = (int)startFrameControl.Value - 1;
                UseWaitCursor = true;
                if (Worker.IsBusy)
                {
                    Worker.CancelAsync();
                }
                Worker.RunWorkerAsync();
            }
        }

        private void startFrameControl_ValueChanged(object sender, EventArgs e)
        {
            Cap.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.PosFrames, (int)startFrameControl.Value - 1);
            FirstFrame.Image = Cap.QuerySmallFrame();
            int maxframes = SplitConfig.FrameCount + 1 - (int)startFrameControl.Value;
            nFramesControl.Maximum = new decimal(maxframes);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (Worker.IsBusy)
            {
                Worker.CancelAsync();
            }
            SplitConfig.TargetFolder = null;
        }
    }
}
