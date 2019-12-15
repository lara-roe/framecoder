using System;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.Structure;
using WK.Libraries.BetterFolderBrowserNS;

namespace FrameCoder
{
    public partial class VideoSplitter : Form
    {
        private VideoSplitConfig SplitConfig;
        private VideoCapture Cap;
        private List<Mat> Frames;
        private List<int> FrameNums;
        private readonly BackgroundWorker Worker = new BackgroundWorker();

        public event EventHandler<EventArgs> SplittingCompleted;


        public VideoSplitter(string srcFile)
        {
            InitializeComponent();
            SplitConfig = new VideoSplitConfig(0, 100, srcFile);
            Frames = new List<Mat>(SplitConfig.NFrames);
            FrameNums = new List<int>(SplitConfig.NFrames);

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
            public string TargetFolder { get; set; }
            public string Format { get; set; }

            public VideoSplitConfig(int StartFrame, int NFrames, string SourceFile)
            {
                this.StartFrame = StartFrame;
                this.NFrames = NFrames;
                this.SourceFile = SourceFile;
                Format = ".jpg";
            }
        }


        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            GetFramesFromVideo();
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Default;
            SplittingCompleted?.Invoke(this, e);
        }

        public void SaveFrames()
        {
            Worker.RunWorkerAsync();
        }

        public string GetFolder()
        {
            return SplitConfig.TargetFolder;
        }

        private void GetFramesFromVideo()
        {
            Frames = new List<Mat>(SplitConfig.NFrames);
            FrameNums = new List<int>(SplitConfig.NFrames);
            Cap = new VideoCapture(SplitConfig.SourceFile);
            SplitConfig.FrameCount = (int)Cap.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameCount);
            int stride = (SplitConfig.FrameCount - SplitConfig.StartFrame) / SplitConfig.NFrames;
            for (int i = 0; i < SplitConfig.NFrames; i++)
            {
                int framenum = i * stride + SplitConfig.StartFrame;
                Cap.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.PosFrames, framenum);
                Frames.Add(Cap.QueryFrame());
                FrameNums.Add(framenum);
                LoadFrameInWindow(i);
            }
        }

        private void LoadFrameInWindow(int FrameIndex)
        {
            // Do something in the interface
            if (FrameIndex == 0)
            {
                FirstFrame.Image = Frames[FrameIndex];
            }
            if (FrameIndex == SplitConfig.NFrames - 1)
            {
                LastFrame.Image = Frames[FrameIndex];
            }
        }

        private void SaveFramesToDisk()
        {
            int width = SplitConfig.FrameCount.ToString().Length;
            for (int i = 0; i < Frames.Count; i++)
            {
                if (Frames[i] != null)
                {
                    string imagename = Path.Combine(
                        SplitConfig.TargetFolder, 
                        FrameNums[i].ToString().PadLeft(width, "0"[0]) + SplitConfig.Format
                    );
                    Frames[i].ToImage<Bgr, byte>().Save(imagename);
                }
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
            SplitConfig.NFrames = (int)nFramesControl.Value;
            SplitConfig.StartFrame = (int)startFrameControl.Value;
            Cursor = Cursors.WaitCursor;
            if (Worker.IsBusy)
            {
                Worker.CancelAsync();
            }
            Worker.RunWorkerAsync();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            BetterFolderBrowser bfb = new BetterFolderBrowser
            {
                Multiselect = false,
                Title = "Subject folder"
            };
            if (bfb.ShowDialog() == DialogResult.OK)
            {
                SplitConfig.TargetFolder = bfb.SelectedPath;
                Cursor = Cursors.WaitCursor;
                SaveFramesToDisk();
                SplittingCompleted?.Invoke(this, e);
                Close();
            }
        }
    }
}
