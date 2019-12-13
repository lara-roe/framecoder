using System;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using Emgu.CV;
using Emgu.CV.Structure;

namespace FrameCoder
{
    public class VideoSplitter
    {
        public string format = ".jpg";
        private string source;
        private string target;
        private int nframes;
        private int startframe;
        private VideoCapture cap;
        private readonly BackgroundWorker worker = new BackgroundWorker();

        public event EventHandler<EventArgs> SplittingCompleted;


        public VideoSplitter(string srcFile, string tgtFolder, int nFrames, int startFrame)
        {
            source = srcFile;
            target = tgtFolder;
            nframes = nFrames;
            startframe = startFrame;

            // background worker stuff
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }


        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            ConvertToImgSeq();
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SplittingCompleted?.Invoke(this, e);
        }

        public void SaveFrames()
        {
            worker.RunWorkerAsync();
        }

        private void ConvertToImgSeq()
        {
            cap = new VideoCapture(source);
            int count = (int)cap.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameCount) - startframe;
            int stride = count / nframes;
            int width = count.ToString().Length;
            for (int i = 0; i < nframes; i++)
            {
                int framenum = i * stride + startframe;
                cap.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.PosFrames, framenum);
                Mat frame = cap.QueryFrame();
                if (frame != null)
                {
                    string imagename = Path.Combine(target, framenum.ToString().PadLeft(width, "0"[0]) + format);
                    frame.ToImage<Bgr, byte>().Save(imagename);
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
