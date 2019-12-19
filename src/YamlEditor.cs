// define namespaces
using System;
using System.IO;
using System.Windows.Forms;

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
            yaml = File.ReadAllText(yamlFile);
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
                yaml = File.ReadAllText(ofd.FileName);
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