using System;
using System.Windows.Forms;

namespace FrameCoder
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string file = (args.Length > 0) ? args[0] : null;
            Application.Run(new FrameCoder(file));
        }
    }
}
