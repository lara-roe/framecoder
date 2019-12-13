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
        private int[] stateVersion = { 2, 0 }; // major, minor
        private List<DataRow> dataRows;
        private ImageReference imgRef;
        private BoundControls bdCtrls;
        private string currentImage;
        private string subName = string.Empty;
        private int ImgIndex = 0;
        
        // constructor
        public PicAnalyzer()
        {
            InitializeComponent();
            MinimumSize = new System.Drawing.Size(1000, 800); // set minimum size of window
        }

        // On loading of mainwindow: dynamic component generation
        private void MainWindow_Load(object sender, EventArgs e)
        {
            // Register the default shortcuts
            RegisterDefaultShortcuts();
            // Dynamically create components from yaml
            // Parse yaml and create data objects
            bdCtrls = new BoundControls(dataBox);
            // find default YAML file
            string assetsDir = Path.Combine(Environment.CurrentDirectory, "assets", "config.yaml");
            bdCtrls.LoadYamlFile(assetsDir);
            // parse YAML
            bdCtrls.ParseYaml();
            // create the controls to add to the data entry box
            bdCtrls.CreateControls();
            // add the shortcuts
            bdCtrls.RegisterShortcuts(shortKeys);
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
        private void NextButton_Click()
        {
            if (NextButton.Enabled)
            {
                SaveDataRow();
                ImgIndex = ImgIndex + 1;
                if (dataRows.Count > ImgIndex)
                {
                    LoadDataRow(); // this does not work!
                }
                UpdateImage();
            }   
        }
        private void NextButton_Click_1(object sender, EventArgs e)
        {
            NextButton_Click();
        }



        // button 4: load previous image and erase previously added row in datarows
        private void PreviousButton_Click()
        {
            if (PreviousButton.Enabled)
            {
                SaveDataRow();
                ImgIndex = ImgIndex - 1;
                LoadDataRow();
                UpdateImage();
            }
        }
        private void PreviousButton_Click_1(object sender, EventArgs e)
        {
            PreviousButton_Click();
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
            if (ImgIndex <= imgRef.count - 1)
            {
                currentImage = imgRef.FileNames[ImgIndex].ToString();
                imageBox.Load(currentImage);
                PreviousButton.Enabled = (ImgIndex != 0);
                NextButton.Enabled = (ImgIndex < imgRef.count - 1);
            }
        }

        protected void LoadFiles()
        {
            imgRef.ParseDir();
            subName = imgRef.GetSubName();
            dataRows = new List<DataRow>(imgRef.count);
            UpdateImage();
        }
        protected void LoadFiles(object sender, EventArgs e)
        {
            LoadFiles();
        }

        protected void SaveDataRow()
        {
            Dictionary<string, object> data = bdCtrls.GetData();
            DataRow dr = new DataRow(subName, data);
            dataRows.Insert(ImgIndex, dr);
        }

        protected void LoadDataRow()
        {
            DataRow dr = dataRows[ImgIndex];
            bdCtrls.SetData(dr.Data);
        }

        protected void RemoveDataRow()
        {
            dataRows.RemoveAt(ImgIndex);
        }

        protected void ExportToCSV()
        {
            StringBuilder sb = new StringBuilder();
            // basic colnames
            sb.Append("Subject;");
            // data-bound colnames
            string[] colnames = bdCtrls.GetNames();
            foreach (string name in colnames)
            {
                sb.Append(name).Append(";");
            }
            sb.Append(Environment.NewLine);

            // then append a line for data
            foreach (DataRow row in dataRows)
            {
                sb.AppendLine(row.getAllCommaSeperated());
            }

            // save
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
            ApplicationState state = new ApplicationState(
                version: stateVersion, 
                dataRows: dataRows, 
                imgRef: imgRef, 
                yaml: bdCtrls.yaml, 
                ImgIndex: ImgIndex
            );
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

                if (state.version[0] == stateVersion[0] & state.version[1] <= stateVersion[1])
                {
                    // set properties using state
                    dataRows = state.dataRows;
                    imgRef = state.imgRef;
                    ImgIndex = state.ImgIndex;

                    // update controls
                    bdCtrls.RemoveControls();
                    bdCtrls.yaml = state.yaml;
                    bdCtrls.ParseYaml();
                    bdCtrls.CreateControls();
                    
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



