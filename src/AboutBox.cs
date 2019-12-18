// define namespaces
using System;
using System.IO;
using System.Windows.Forms;

namespace FrameCoder
{
    public partial class AboutBox : Form
    {

        public AboutBox(string version, string stateversion)
        {
            InitializeComponent();
            pictureBox1.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "icon.png");
            label1.Text =
                "Framecoder version " + version + Environment.NewLine +
                "State version " + stateversion + Environment.NewLine +
                "GPL-3 Licensed open-source application" + Environment.NewLine +
                "(c) 2019 Lara Rösler, Erik-Jan van Kesteren";
        }
    }

}
