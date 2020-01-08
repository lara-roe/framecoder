// define namespaces
using System;
using System.IO;
using System.Windows.Forms;
using System.Text;
using System.Text.RegularExpressions;

namespace FrameCoder
{
    public partial class YamlEditor : Form
    {
        public string yaml;
        public YamlEditor(string yaml)
        {
            InitializeComponent();
            this.yaml = yaml;
            editorBox.Text = yaml;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            // load default yaml
            string yamlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "config.default.yaml");
            using (StreamReader streamReader = new StreamReader(yamlFile, Encoding.UTF8))
            {
                string text = streamReader.ReadToEnd();
                yaml = Regex.Replace(text, @"\r\n|\n\r|\n|\r", "\r\n"); // ensure CRLF line endings
            }
            editorBox.Text = yaml;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "YAML files (*.yaml)|*.yaml",
                AddExtension = true,
                Multiselect = false
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader streamReader = new StreamReader(ofd.FileName, Encoding.UTF8))
                {
                    string text = streamReader.ReadToEnd();
                    yaml = Regex.Replace(text, @"\r\n|\n\r|\n|\r", "\r\n"); // ensure CRLF line endings
                }
                editorBox.Text = yaml;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            yaml = editorBox.Text;
            string yamlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "config.yaml");
            File.WriteAllText(yamlFile, yaml);
        }
    }
}