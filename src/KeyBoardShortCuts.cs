using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PicAnalyzer
{
    partial class PicAnalyzer : Form
    {
        private Dictionary<Keys, Action> shortKeys = new Dictionary<Keys, Action>();

        // Default keyboard shortcuts
        private void RegisterDefaultShortcuts()
        {
            shortKeys.Add(Keys.Right, NextButton_Click);
            shortKeys.Add(Keys.Left, PreviousButton_Click);
        }

        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (shortKeys.ContainsKey(keyData))
            {
                shortKeys[keyData]();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        
    }
}