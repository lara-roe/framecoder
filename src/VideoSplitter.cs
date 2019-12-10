using System.IO;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace PicAnalyzer
{
    public class VideoSplitter
    {
        public string format = ".jpg";
        private string source;
        private string target;
        private int nframes;
        private VideoCapture cap;

        public VideoSplitter(string srcFile, string tgtFolder, int nFrames)
        {
            source = srcFile;
            target = tgtFolder;
            nframes = nFrames;
        }

        public void ConvertToImgSeq()
        {
            cap = new VideoCapture(source);
            int count = (int)cap.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameCount);
            int stride = count / nframes;
            int width = count.ToString().Length;
            for (int i = 0; i < nframes; i++)
            {
                int framenum = i * stride;
                cap.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.PosFrames, framenum);
                Mat frame = cap.QueryFrame();
                if (frame != null)
                {
                    string imagename = Path.Combine(target, framenum.ToString().PadLeft(width, "0"[0]) + format);
                    frame.ToImage<Bgr, byte>().Save(imagename);
                }
            }
            MessageBox.Show("Video converted");
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
