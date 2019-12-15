using System;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.Structure;

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


        public VideoSplitter(string srcFile, string tgtFolder)
        {
            InitializeComponent();
            SplitConfig = new VideoSplitConfig(0, 100, srcFile, tgtFolder);
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

            public VideoSplitConfig(int StartFrame, int NFrames, string SourceFile, string TargetFolder)
            {
                this.StartFrame = StartFrame;
                this.NFrames = NFrames;
                this.SourceFile = SourceFile;
                this.TargetFolder = TargetFolder;
                Format = ".jpg";
            }
        }


        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            GetFramesFromVideo();
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SplittingCompleted?.Invoke(this, e);
        }

        public void SaveFrames()
        {
            Worker.RunWorkerAsync();
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
                Frames[i] = Cap.QueryFrame();
                FrameNums[i] = framenum;
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

        public static string GetTemporaryDirectory(string name)
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), name);
            Directory.CreateDirectory(tempDirectory);
            return tempDirectory;
        }
    }
}
