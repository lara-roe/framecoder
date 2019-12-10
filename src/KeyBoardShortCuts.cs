using System;
using System.Windows.Forms;

namespace PicAnalyzer
{
    partial class PicAnalyzer : Form
    {
        // --------------------- Keyboard Shortcuts --------------------------------
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Right:
                    if (NextButton.Enabled) NextButton_Click_1(this, EventArgs.Empty);
                    return true;
                case Keys.Left:
                    if (PreviousButton.Enabled) PreviousButton_Click_1(this, EventArgs.Empty);
                    return true;
                case Keys.D1:
                    // do something...
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }
    }
}