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
    partial class PicAnalyzer : Form
    {
        // Properties
        private List<DataRow> dataRows;
        private string[] pFileNames;
        private string current_image;
        private string images = string.Empty;
        private string subname = string.Empty;
        private int counter = 0;

        // constructor
        public PicAnalyzer()
        {
            InitializeComponent();
            MinimumSize = new System.Drawing.Size(1000, 800); // set minimum size of window
        }


        // Menu items
        private void openSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Title = "Select all images of subject"; // defines text that is displayed in upper bar of dialogue window
            DialogResult dr = ofd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                pFileNames = ofd.FileNames;
                string dirname = Directory.GetParent(pFileNames[0]).ToString();
                subname = Path.GetFileNameWithoutExtension(dirname);
                dataRows = new List<DataRow>(pFileNames.Length);
                UpdateImage();
            }
        }


        // On-screen buttons
        // button 2 = next image
        private void NextButton_Click_1(object sender, EventArgs e)
        {
            SaveDataRow();
            counter = counter + 1;
            if (!(counter <= pFileNames.Length - 1)) // if there are no more images to load
            {
                SaveAndExit();
            }
            UpdateImage();
        }

        // button 4: load previous image and erase previously added row in datarows
        private void PreviousButton_Click_1(object sender, EventArgs e)
        {
            counter = counter - 1;
            UpdateImage();
        }

        // button3 = close app
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // button 3 = save & exit

        private void SaveButton_Click_1(object sender, EventArgs e)
        {
            SaveAndExit();
        }

        

        // ----------------------- Used Methods ----------------------------------

        protected void UpdateImage()
        {
            if (counter <= pFileNames.Length - 1)
            {
                current_image = pFileNames[counter].ToString();
                pictureBox2.Load(current_image);
                label1.Text = Path.GetFileName(this.current_image);
            }
        }

        protected void SaveDataRow()
        {
            DataRow data = new DataRow(subname, current_image, PersonPresent.Checked, HeadFixation.Checked, BodyFixation.Checked, SurroundingFixation.Checked, InvalidFixation.Checked, CommentTextBox.Text);
            dataRows.Insert(counter, data);
        }

        protected void LoadDataRow(int index)
        {
            DataRow data = dataRows[index];
            PersonPresent.Checked = data.personPresent;
            HeadFixation.Checked = data.headFixated;
            BodyFixation.Checked = data.bodyFixated;
            SurroundingFixation.Checked = data.surroundingsFixated;
            InvalidFixation.Checked = data.noFixation;
            CommentTextBox.Text = data.Comment;
        }

        protected void RemoveDataRow(int index)
        {
            dataRows.RemoveAt(index);
        }

        protected void SaveAndExit()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Subject;Image;Person;Head;Surroundings;Body;Fixation;Comment");
            foreach (DataRow row in dataRows)
            {
                sb.AppendLine(row.getAllCommaSeperated());
            }
            SaveFileDialog sf = new SaveFileDialog();
            // Feed the dummy name to the save dialog
            sf.FileName = subname;
            sf.DefaultExt = ".csv";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                string savepath = sf.FileName.ToString();
                File.WriteAllText(savepath, sb.ToString());
                this.Close();
            }
        }

        //   ------------------- define properties of radio buttons so that change will call next image  --------------------------------
        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (HeadFixation.Checked)
            {
                SaveDataRow();
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
            if (BodyFixation.Checked)
            {
                SaveDataRow();
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
            if (SurroundingFixation.Checked)
            {
                SaveDataRow();
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
            if (InvalidFixation.Checked)
            {
                SaveDataRow();
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CommentTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }
    }

}



