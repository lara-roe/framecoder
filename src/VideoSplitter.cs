using System;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
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
            SplitConfig = new VideoSplitConfig(srcFile);



            // parse video properties (better use ffprobe?)
            Cap = new VideoCapture(SplitConfig.SourceFile);
            int fc = (int)Cap.GetCaptureProperty(CapProp.FrameCount);
            int fps = (int)Cap.GetCaptureProperty(CapProp.Fps);

            // save properties to splitconfig
            SplitConfig.SourceFrameCount = fc;
            SplitConfig.SourceFPS = fps;

            // update UI based on video properties
            decimal fcd = new decimal(fc);
            startFrameControl.Maximum = fcd;
            endFrameControl.Maximum = fcd;
            endFrameControl.Value = fcd;
            nFramesControl.Maximum = fcd;
            frameIntervalControl.Maximum = fcd;

            decimal ivld = new decimal(1000 / (double)fps);
            timeIntervalControl.Maximum = new decimal(1000 * fc / (double)fps);
            timeIntervalControl.Minimum = ivld;
            timeIntervalControl.Value = ivld;

            // load image into UI
            Cap.SetCaptureProperty(CapProp.PosFrames, 0);
            FirstFrame.Image = Cap.QuerySmallFrame();

            // Init background worker for the conversion
            Worker.WorkerReportsProgress = true;
            Worker.WorkerSupportsCancellation = true;
            Worker.DoWork += Worker_DoWork;
            Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        public class VideoSplitConfig
        {
            // User-specified settings
            public UserPreference UserPref { get; set; }
            public int UserStartFrame { get; set; }
            public int UserEndFrame { get; set; }
            public double UserTimeInterval { get; set; }
            public int UserFrameInterval { get; set; }
            public int UserNFrames { get; set; }
            public string UserTargetFolder { get; set; }

            // How to process the user settings to get frameidx
            public enum UserPreference
            {
                NFrames,
                TimeInterval,
                FrameInterval
            }

            // Source properties
            public string SourceFile { get; set; }
            public int SourceFrameCount { get; set; }
            public double SourceFPS { get; set; }

            // Other properties
            public string Format { get; set; }

            // constructor
            public VideoSplitConfig(string SourceFile)
            {
                Format = ".jpg";
                this.SourceFile = SourceFile;
            }

            // the magical method!
            public int[] GetFrameIDX()
            {
                // TODO
                switch (UserPref)
                {
                    case UserPreference.NFrames:
                        {
                            int FrameInterval = (UserEndFrame - UserStartFrame) / UserNFrames;
                            int[] idx = new int[UserNFrames];
                            for (int i = 0; i < UserNFrames; i++)
                            {
                                idx[i] = (i * FrameInterval) + UserStartFrame;
                            }
                            return idx;
                        };
                    case UserPreference.FrameInterval:
                        {
                            int NFrames = (int)Math.Floor((double)(UserEndFrame - UserStartFrame) / UserFrameInterval);
                            int[] idx = new int[NFrames];
                            for (int i = 0; i < NFrames; i++)
                            {
                                idx[i] = (i * UserFrameInterval) + UserStartFrame;
                            }
                            return idx;
                        };
                    case UserPreference.TimeInterval:
                        {
                            double TotalTime = 1000 * (UserEndFrame - UserStartFrame) / (double)SourceFPS;
                            int NFrames = (int)Math.Floor(TotalTime / UserTimeInterval);
                            int[] idx = new int[NFrames];
                            for (int i = 0; i < NFrames; i++)
                            {
                                idx[i] = (int)Math.Floor((SourceFPS * i * UserTimeInterval / 1000)) + UserStartFrame;
                            }
                            return idx;
                        };
                    default:
                        return new int[] { 1, 2, 3, 4, 5 };
                }
                
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
            return SplitConfig.UserTargetFolder;
        }

        private void GetFramesFromVideo()
        {
            // TODO: work with SplitConfig.GetFrameIDX();
            FrameNums = SplitConfig.GetFrameIDX();
            Frames = new string[FrameNums.Length];
            int width = SplitConfig.SourceFrameCount.ToString().Length;
            int i = 0;
            foreach (int framenum in FrameNums)
            {
                // get frame
                Cap.SetCaptureProperty(CapProp.PosFrames, framenum);
                Mat frame = Cap.QueryFrame();

                // load into interface
                SetFrameLabelText("Frame " + i + " of " + FrameNums.Length + ".");
                LastFrame.Image = frame;

                // save to disk
                if (SplitConfig.UserTargetFolder == null) return;
                string imagename = Path.Combine(
                    SplitConfig.UserTargetFolder,
                    (framenum + 1).ToString().PadLeft(width, "0"[0]) + SplitConfig.Format
                );
                Frames[i] = imagename;
                frame.ToImage<Bgr, byte>().Save(imagename);

                // forward
                i++;
            }
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
                // Update SplitConfig user settings
                SplitConfig.UserTargetFolder = bfb.SelectedPath;
                SplitConfig.UserNFrames = (int)nFramesControl.Value;
                SplitConfig.UserStartFrame = (int)startFrameControl.Value - 1;
                SplitConfig.UserEndFrame = (int)endFrameControl.Value - 1;
                SplitConfig.UserFrameInterval = (int)frameIntervalControl.Value;
                SplitConfig.UserTimeInterval = (double)timeIntervalControl.Value;
                switch (ControlTabs.SelectedTab.Name)
                {
                    case "NFramesTab":
                        SplitConfig.UserPref = VideoSplitConfig.UserPreference.NFrames;
                        break;
                    case "FrameIntervalTab":
                        SplitConfig.UserPref = VideoSplitConfig.UserPreference.FrameInterval;
                        break;
                    case "TimeIntervalTab":
                        SplitConfig.UserPref = VideoSplitConfig.UserPreference.TimeInterval;
                        break;
                    default:
                        SplitConfig.UserPref = VideoSplitConfig.UserPreference.NFrames;
                        break;
                }

                // Do the conversion!
                UseWaitCursor = true;
                if (Worker.IsBusy)
                {
                    Worker.CancelAsync();
                }
                Worker.RunWorkerAsync();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (Worker.IsBusy)
            {
                Worker.CancelAsync();
            }
            SplitConfig.UserTargetFolder = null;
        }

        private void startFrameControl_ValueChanged(object sender, EventArgs e)
        {
            Cap.SetCaptureProperty(CapProp.PosFrames, (int)startFrameControl.Value - 1);
            FirstFrame.Image = Cap.QuerySmallFrame();
            int maxframes = (int)endFrameControl.Value - (int)startFrameControl.Value;
            
            // set maxima
            nFramesControl.Maximum = new decimal(maxframes);
            frameIntervalControl.Maximum = new decimal(maxframes);
            timeIntervalControl.Maximum = new decimal(1000 * maxframes / SplitConfig.SourceFPS);
        }

        private void endFrameControl_ValueChanged(object sender, EventArgs e)
        {
            Cap.SetCaptureProperty(CapProp.PosFrames, (int)endFrameControl.Value - 1);
            LastFrame.Image = Cap.QuerySmallFrame();
            SetFrameLabelText("End Frame");
            int maxframes = (int)endFrameControl.Value - (int)startFrameControl.Value;

            // set maxima
            nFramesControl.Maximum = new decimal(maxframes);
            frameIntervalControl.Maximum = new decimal(maxframes);
            timeIntervalControl.Maximum = new decimal(1000 * maxframes / SplitConfig.SourceFPS);
        }
    }
}
