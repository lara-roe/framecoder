// define namespaces
using System;
using System.Collections.Generic; // for list functionality
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using WK.Libraries.BetterFolderBrowserNS;

namespace PicAnalyzer
{
    partial class PicAnalyzer : Form
    {
        // Properties
        private int[] stateVersion = { 1, 0 }; // major, minor
        private List<DataRow> dataRows;
        private ImageReference imgRef;
        private string currentImage;
        private string subName = string.Empty;
        private int counter = 0;

        // constructor
        public PicAnalyzer()
        {
            InitializeComponent();
            MinimumSize = new System.Drawing.Size(1000, 800); // set minimum size of window
        }

        // On loading of mainwindow
        private void MainWindow_Load(object sender, EventArgs e)
        {
            // Do nothing
        }


        // Menu items
        private void openSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BetterFolderBrowser bfb = new BetterFolderBrowser
            {
                Multiselect = false,
                Title = "Open subject folder"
            };
            if (bfb.ShowDialog() == DialogResult.OK)
            {
                imgRef = new ImageReference(bfb.SelectedPath);
                imgRef.ParseDir();
                LoadFiles();
            }
        }

        private void saveSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SerializeSession();
        }

        private void loadSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnserializeSession();
        }

        // On-screen buttons
        // button 2 = next image
        private void NextButton_Click_1(object sender, EventArgs e)
        {
            SaveDataRow();
            counter = counter + 1;
            if (dataRows.Count > counter) LoadDataRow();
            UpdateImage();
        }

        // button 4: load previous image and erase previously added row in datarows
        private void PreviousButton_Click_1(object sender, EventArgs e)
        {
            counter = counter - 1;
            LoadDataRow();
            UpdateImage();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportToCSV();
        }

        private void splitVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: we need some dialog box for this, maybe in PickVideoFile()?
            int nframe = 100; 
            int startframe = 0;
            string src = VideoSplitter.PickVideoFile();
            string name = Path.GetFileNameWithoutExtension(src);
            string tgt = VideoSplitter.GetTemporaryDirectory(name);
            VideoSplitter splitter = new VideoSplitter(src, tgt, nframe, startframe);
            imgRef = new ImageReference(tgt);
            splitter.SplittingCompleted += LoadFiles;
            splitter.SaveFrames();
        }

        // ----------------------- Used Methods ----------------------------------
        protected void UpdateImage()
        {
            if (counter <= imgRef.count - 1)
            {
                currentImage = imgRef.FileNames[counter].ToString();
                imageBox.Load(currentImage);
                PreviousButton.Enabled = (counter != 0);
                NextButton.Enabled = (counter < imgRef.count - 1);
            }
        }

        protected void LoadFiles()
        {
            imgRef.ParseDir();
            subName = imgRef.GetSubName();
            dataRows = new List<DataRow>(imgRef.count);
            UpdateImage();
        }

        // overload for event-driven loading of files
        protected void LoadFiles(object sender, EventArgs e)
        {
            LoadFiles();
        }

        protected void SaveDataRow()
        {
            DataRow data = new DataRow(
                SubName:                subName,
                ImageName:              currentImage,
                personPresent:          PersonPresent.Checked,
                headFixated:            HeadFixation.Checked,
                bodyFixated:            BodyFixation.Checked,
                surroundingsFixated:    SurroundingFixation.Checked,
                noFixation:             InvalidFixation.Checked,
                Comment:                CommentTextBox.Text
            );
            dataRows.Insert(counter, data);
        }

        protected void LoadDataRow()
        {
            DataRow data = dataRows[counter];
            PersonPresent.Checked       = data.personPresent;
            HeadFixation.Checked        = data.headFixated;
            BodyFixation.Checked        = data.bodyFixated;
            SurroundingFixation.Checked = data.surroundingsFixated;
            InvalidFixation.Checked     = data.noFixation;
            CommentTextBox.Text         = data.Comment;
        }

        protected void RemoveDataRow()
        {
            dataRows.RemoveAt(counter);
        }

        protected void ExportToCSV()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Subject;Image;Person;Head;Surroundings;Body;Fixation;Comment");
            foreach (DataRow row in dataRows)
            {
                sb.AppendLine(row.getAllCommaSeperated());
            }
            SaveFileDialog sf = new SaveFileDialog
            {
                FileName = subName,
                DefaultExt = ".csv",
                AddExtension = true,
                Filter = "(*.csv)|*.csv"
            };
            if (sf.ShowDialog() == DialogResult.OK)
            {
                string savepath = sf.FileName.ToString();
                File.WriteAllText(savepath, sb.ToString());
            }
        }

        protected void SerializeSession()
        {
            ApplicationState state = new ApplicationState(stateVersion, dataRows, imgRef, counter);
            SaveFileDialog sfd = new SaveFileDialog
            {
                AddExtension = true,
                DefaultExt = "paz",
                Filter = "(*.paz)|*.paz"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Serializer.SerializeState(sfd.FileName, state);
            }
        }

        protected void UnserializeSession()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                AddExtension = true,
                DefaultExt = "paz",
                Filter = "(*.paz)|*.paz"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ApplicationState state = Serializer.UnserializeState(ofd.FileName);

                if (state.version[0] == stateVersion[0] & state.version[1] < stateVersion[1])
                {
                    // set properties using state
                    dataRows = state.dataRows;
                    imgRef = state.imgRef;
                    counter = state.counter;
                    UpdateImage();
                }
            }
        }

        private void exportVideoFramesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BetterFolderBrowser bfb = new BetterFolderBrowser
            {
                Title = "Save images in this folder",
                Multiselect = false
            };

            if (bfb.ShowDialog() == DialogResult.OK)
            {
                imgRef.ExportFolder(bfb.SelectedPath);
                Process.Start(@bfb.SelectedPath);
            }
        }
    }

}



