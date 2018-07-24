
// define namespaces
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicAnalyzer
{
    public partial class Form1 : Form
    {
        private List<DataRow> dataRows = new List<DataRow>();
        protected string[] pFileNames;
        string filePath = @"C:\Users\lar08ug\Documents\Experiments\Real_Life_Eyetracking\Auswertung\Rating\";
        public Form1()
        {
            InitializeComponent();
        }

        // if exit-button is pressed, application will be closed (without saving)
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // define counter and image string
        int counter = 1;
        private string images = string.Empty;

        // define button1 to load in images of subjects
        public void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Title = "Select all images of subject";
            DialogResult dr = ofd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                pFileNames = ofd.FileNames;
                ShowCurrentImage();
            }
        }

        // button 2 defined to load 5th next image into analyzer
        private void button2_Click_1(object sender, EventArgs e)
        {
            SaveCheckBoxStatus();
            counter = counter + 5; // this number can be tweaked depending on how many frames should be analyzed
            string current_image = pFileNames[counter].ToString();
            pictureBox1.Load(current_image);
        }

        // define loading/displaying of image
        protected void ShowCurrentImage()
        {
            if (counter <= pFileNames.Length - 5)
            {
                pictureBox1.Image = Bitmap.FromFile(pFileNames[counter]);
            }
        }

        // define SaveCheckBoxStatus to add existing input to data row
        protected void SaveCheckBoxStatus()
        {
            dataRows.Add(new DataRow(pFileNames[counter].ToString(),checkBox1.Checked, checkBox3.Checked, checkBox5.Checked, checkBox7.Checked));
        }

        // define button3 to save output file
        private void button3_Click_1(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            foreach (DataRow row in dataRows)
            {
                sb.AppendLine(row.getAllCommaSeperated());
            }

            File.WriteAllText(filePath+"test.csv", sb.ToString()); this.Close();

        }

        // load form and define checkbox properties (if anyone thinks this code is redundant, please let me know)
        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}


