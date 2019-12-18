// define namespaces
using System;
using System.Collections.Generic; // for list functionality
using System.IO;
using System.Text;
using System.Windows.Forms;
using WK.Libraries.BetterFolderBrowserNS;
using System.Reflection;

namespace FrameCoder
{
    partial class FrameCoder : Form
    {
        // Properties
        private Version stateVersion = new Version(3, 0);
        private Version appVersion = Assembly.GetExecutingAssembly().GetName().Version;
        private List<DataRow> dataRows;
        private ImageReference imgRef;
        private BoundControls bdCtrls;
        private string fileArg;
        private string currentImage;
        private string subName = string.Empty;
        private int ImgIndex = 0;
        
        // constructor
        public FrameCoder(string file)
        {
            InitializeComponent();
            Size = new System.Drawing.Size(800, 600);
            MinimumSize = new System.Drawing.Size(800, 600); // set minimum size of window
            fileArg = file;
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
            string yamlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "config.yaml");
            bdCtrls.LoadYamlFile(yamlFile);
            // parse YAML
            bdCtrls.ParseYaml();
            // create the controls to add to the data entry box
            bdCtrls.CreateControls();
            // add the shortcuts
            bdCtrls.RegisterShortcuts(shortKeys);
            // disable the data box
            dataBox.Enabled = false;
            // load icon as image
            imageBox.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "splash.png"));

            // if opened with file, load it!
            if (fileArg != null)
            {
                UnserializeSession(fileArg);
            }
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
            OpenFileDialog ofd = new OpenFileDialog
            {
                AddExtension = true,
                DefaultExt = "fcs",
                Filter = "Framecoder Session (*.fcs)|*.fcs"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                UnserializeSession(ofd.FileName);
            }
        }

        // On-screen buttons
        // button 2 = next image
        private void NextButton_Click()
        {
            if (NextButton.Enabled)
            {
                SaveDataRow();
                ImgIndex = ImgIndex + 1;
                UpdateImage();
                if (dataRows.Count > ImgIndex)
                {
                    LoadDataRow(); // this does not work!
                }
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
            string src = VideoSplitter.PickVideoFile();
            if (src == null)
            {
                return;
            }
            string name = Path.GetFileNameWithoutExtension(src);
            VideoSplitter splitter = new VideoSplitter(src);
            splitter.ShowDialog();
            string tgt = splitter.GetFolder();
            if (tgt == null)
            {
                return;
            }
            imgRef = new ImageReference(tgt);
            LoadFiles();
            // splitter.SaveFrames();
        }

        // ----------------------- Used Methods ----------------------------------

        protected void UpdateFrameLabel()
        {
            frameLabel.Text = 
                (ImgIndex + 1) + " / " + imgRef.count + Environment.NewLine +
                Path.GetFileName(currentImage);
        }

        protected void UpdateImage()
        {
            if (ImgIndex <= imgRef.count - 1)
            {
                currentImage = imgRef.FileNames[ImgIndex].ToString();
                imageBox.Load(currentImage);
                UpdateFrameLabel();
                PreviousButton.Enabled = ImgIndex != 0;
                NextButton.Enabled = ImgIndex < imgRef.count - 1;
                dataBox.Enabled = imgRef.status == ImageReference.RefStatus.Available;
                exportToolStripMenuItem.Enabled = imgRef.status == ImageReference.RefStatus.Available;
                saveSessionToolStripMenuItem.Enabled = imgRef.status == ImageReference.RefStatus.Available;
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
            DataRow dr = new DataRow(subName, currentImage, data);
            if (dataRows.Count > ImgIndex)
            {
                dataRows[ImgIndex] = dr;
            }
            else
            {
                dataRows.Add(dr);
            }
        }

        protected void LoadDataRow()
        {
            Dictionary<string, object> data = dataRows[ImgIndex].Data;
            bdCtrls.SetData(data);
        }

        protected void RemoveDataRow()
        {
            dataRows.RemoveAt(ImgIndex);
        }

        protected void ExportToCSV()
        {
            StringBuilder sb = new StringBuilder();
            // basic colnames
            sb.Append("Subject;Image;");
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
                DefaultExt = "fcs",
                Filter = "Framecoder session (*.fcs)|*.fcs"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Serializer.SerializeState(sfd.FileName, state);
            }
        }

        protected void UnserializeSession(string fileName)
        {
            ApplicationState state = Serializer.UnserializeState(fileName);

            if (state.version.Major == stateVersion.Major & state.version.Minor <= stateVersion.Minor)
            {
                // check if images are available and repair if necessary.
                ImageReference newRef = new ImageReference(state.imgRef.Dir);
                newRef.ParseDir();
                if (newRef.status == ImageReference.RefStatus.Missing || newRef.status == ImageReference.RefStatus.Empty)
                {
                    DialogResult repair = MessageBox.Show("Images could not be found. Press OK to select the folder.", "Frames missing", MessageBoxButtons.YesNo);
                    if (repair == DialogResult.Yes)
                    {
                        // repair the image link
                        newRef.RepairImageLink();
                        if (!Serializer.ImgRefIsValid(newRef, state.imgRef))
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                // image reference is now correct, proceed with loading the session!

                // set properties using state
                dataRows = state.dataRows;
                imgRef = newRef;
                subName = imgRef.GetSubName();
                ImgIndex = state.ImgIndex;

                // update controls
                bdCtrls.RemoveControls();
                bdCtrls.yaml = state.yaml;
                bdCtrls.ParseYaml();
                bdCtrls.CreateControls();
                bdCtrls.RegisterShortcuts(shortKeys);

                // finally, load the image
                imgRef.ParseDir();
                UpdateImage();
            }
            else
            {
                MessageBox.Show("Incompatible Framecoder Session version: " + state.version.ToString(2), "State version error.");
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox(appVersion.ToString(2), stateVersion.ToString(2));
            aboutBox.ShowDialog();
        }
        

        private void howToUseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/vankesteren/framecoder#input-format");
        }

        private void configEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YamlEditor editor = new YamlEditor(bdCtrls.yaml);
            
            if (editor.ShowDialog() == DialogResult.OK)
            {
                // update controls
                bdCtrls.RemoveControls();
                bdCtrls.yaml = editor.yaml;
                bdCtrls.ParseYaml();
                bdCtrls.CreateControls();
                bdCtrls.RegisterShortcuts(shortKeys);
            }
        }
    }

}



