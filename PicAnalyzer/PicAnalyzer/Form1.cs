// define namespaces
using System;
using System.Collections.Generic; // for list functionality
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace PicAnalyzer
{
    public partial class PicAnalyzer : Form
    {
        // initialize basic variables
        private List<DataRow> dataRows = new List<DataRow>();
        protected string[] pFileNames;
        string dummyFileName = "Save Here";
        protected string realFile;
        protected string folderName;
        protected string current_image;
        int counter = 0;
        private string images = string.Empty;

        public PicAnalyzer()
        {
            InitializeComponent();
            MinimumSize = new System.Drawing.Size(1000, 800); // set minimum size of window
        }

        // button 1 = load images
        public void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Title = "Select all images of subject"; // defines text that is displayed in upper bar of dialogue window
            DialogResult dr = ofd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                pFileNames = ofd.FileNames;
                ShowCurrentImage();
            }
        }

        // button 2 = next image
        private void button2_Click_1(object sender, EventArgs e)
        {
            SaveCheckBoxStatus();
            counter = counter + 1;
            if (!(counter <= pFileNames.Length - 1)) // if there are no more images to load
            {
                SaveAndExit();
            }
            string current_image = pFileNames[counter].ToString();
            pictureBox2.Load(current_image);
            realFile = Path.GetFileName(current_image);
            label1.Text = realFile;
        }


        // button3 = close app
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // button 3 = save & exit

        private void button3_Click_1(object sender, EventArgs e)
        {
            SaveAndExit();
        }

        // button 4: load previous image and erase previously added row in datarows
        private void button4_Click(object sender, EventArgs e)
        {
            counter = counter - 1;
            string current_image = pFileNames[counter].ToString();
            pictureBox2.Load(current_image);
            dataRows.RemoveAt(dataRows.Count - 1);
            realFile = Path.GetFileName(current_image);
            label1.Text = realFile;
        }

        // ----------------------- Used Methods ----------------------------------

        protected void ShowCurrentImage()
        {
            if (counter <= pFileNames.Length - 1)
            {
                pictureBox2.Image = Bitmap.FromFile(pFileNames[counter]);
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                string current_image = pFileNames[counter].ToString();
                realFile = Path.GetFileName(current_image);

                label1.Text = realFile;
            }
        }

        protected void SaveCheckBoxStatus()
        {
            string ImageName = pFileNames[counter].ToString();
            int startPos = ImageName.LastIndexOf(Path.GetDirectoryName(ImageName)) + Path.GetDirectoryName(ImageName).Length + 1;
            int length = ImageName.IndexOf(".jpg") - startPos;
            string ImageName2 = ImageName.Substring(startPos, length);
            string UpperDir = Path.GetDirectoryName(ImageName);
            int startPos2 = ImageName.LastIndexOf(Path.GetDirectoryName(UpperDir)) + Path.GetDirectoryName(UpperDir).Length + 1;
            int length2 = 2; 
            string SubName = ImageName.Substring(startPos2, length2);
            dataRows.Add(new DataRow(SubName, ImageName2, checkBox1.Checked, radioButton1.Checked, radioButton2.Checked, radioButton3.Checked, radioButton4.Checked));
        }

        protected void UpdateImage()
        {
            string current_image = pFileNames[counter].ToString();
            pictureBox2.Load(current_image);
            realFile = Path.GetFileName(current_image);
            label1.Text = realFile;
        }

        protected void SaveAndExit()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Subject;Image;Person;Head;Surroundings;Body;Fixation");
            foreach (DataRow row in dataRows)
            {
                sb.AppendLine(row.getAllCommaSeperated());
            }
            string ImageName = pFileNames[counter - 1].ToString();
            string UpperDir = Path.GetDirectoryName(ImageName);
            int startPos2 = ImageName.LastIndexOf(Path.GetDirectoryName(UpperDir)) + Path.GetDirectoryName(UpperDir).Length + 1;
            int length2 = 2;  
            string SubName = ImageName.Substring(startPos2, length2);
            ChooseFolder();
            string savepath2 = folderName.ToString();
            File.WriteAllText(savepath2 + "\\" + SubName.ToString() + ".csv", sb.ToString()); this.Close();
            this.Close();
        }

        public void ChooseFolder()
        {
            SaveFileDialog sf = new SaveFileDialog();
            // Feed the dummy name to the save dialog
            sf.FileName = dummyFileName;

            if (sf.ShowDialog() == DialogResult.OK)
            {
                // Now here's the save folder
                 folderName = Path.GetDirectoryName(sf.FileName);
            }

        }
    
        //   ------------------- define properties of radio buttons so that change will call next image  --------------------------------
        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                SaveCheckBoxStatus();
                counter = counter + 1;
                if (!(counter <= pFileNames.Length - 1))
                {
                    SaveAndExit();
                }
                UpdateImage();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                SaveCheckBoxStatus();
                counter = counter + 1;
                if (!(counter <= pFileNames.Length - 1))
                {
                    SaveAndExit();
                }
                UpdateImage();
            }
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                SaveCheckBoxStatus();
                counter = counter + 1;
                if (!(counter <= pFileNames.Length - 1))
                {
                    SaveAndExit();
                }
                UpdateImage();
            }
        }

        private void radioButton4_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                SaveCheckBoxStatus();
                counter = counter + 1;
                if (!(counter <= pFileNames.Length - 1))
                {
                    SaveAndExit();
                }
                UpdateImage();
            }
        }

        // define/load different objects and their properties (if this is unnecessary and you know it, please let me know so I can make my code cleaner :) )

        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

    }

}



