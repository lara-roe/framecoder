// define namespaces
using System;
using System.Collections.Generic; // for list functionality
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PicAnalyzer
{
    partial class PicAnalyzer : Form
    {
        // Properties
        private List<DataRow> dataRows;
        private string[] pFileNames;
        private string current_image;
        private string images = string.Empty;
        private string subname = string.Empty;
        private string workdir;
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
            OpenFileDialog ofd = new OpenFileDialog
            {
                Multiselect = true,
                Title = "Select all images of subject" // defines text that is displayed in upper bar of dialogue window
            };
            DialogResult dr = ofd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                pFileNames = ofd.FileNames;
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
            int nframe = 100; // we need some dialog box for this, maybe in PickVideoFile()?
            string src = VideoSplitter.PickVideoFile();
            string tgt = VideoSplitter.GetTemporaryDirectory();
            VideoSplitter splitter = new VideoSplitter(src, tgt, nframe);
            splitter.ConvertToImgSeq();
            pFileNames = Directory.GetFiles(tgt, "*" + splitter.format);
            LoadFiles();
        }

        // ----------------------- Used Methods ----------------------------------

        protected void UpdateImage()
        {
            if (counter <= pFileNames.Length - 1)
            {
                current_image = pFileNames[counter].ToString();
                imageBox.Load(current_image);
                PreviousButton.Enabled = (counter != 0);
                NextButton.Enabled = (counter < pFileNames.Length - 1);
            }
        }

        protected void LoadFiles()
        {
            string dirname = Directory.GetParent(pFileNames[0]).ToString();
            subname = Path.GetFileNameWithoutExtension(dirname);
            dataRows = new List<DataRow>(pFileNames.Length);
            UpdateImage();
        }

        protected void SaveDataRow()
        {
            DataRow data = new DataRow(subname, current_image, PersonPresent.Checked, HeadFixation.Checked, BodyFixation.Checked, SurroundingFixation.Checked, InvalidFixation.Checked, CommentTextBox.Text);
            dataRows.Insert(counter, data);
        }

        protected void LoadDataRow()
        {
            DataRow data = dataRows[counter];
            PersonPresent.Checked = data.personPresent;
            HeadFixation.Checked = data.headFixated;
            BodyFixation.Checked = data.bodyFixated;
            SurroundingFixation.Checked = data.surroundingsFixated;
            InvalidFixation.Checked = data.noFixation;
            CommentTextBox.Text = data.Comment;
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
                FileName = subname,
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
            ApplicationState state = new ApplicationState(dataRows, pFileNames, counter);
            SaveFileDialog sfd = new SaveFileDialog
            {
                AddExtension = true,
                DefaultExt = "paz",
                Filter = "(*.paz)|*.paz"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Serializer.Save(sfd.FileName, state);
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
                ApplicationState state = Serializer.Load(ofd.FileName);

                // set properties using state
                dataRows = state.dataRows;
                pFileNames = state.pFileNames;
                counter = state.counter;
                UpdateImage();
            }

        }

    }

}



