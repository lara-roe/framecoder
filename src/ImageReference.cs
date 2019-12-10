using System;
using System.IO;

namespace PicAnalyzer
{
    [Serializable]
    public class ImageReference
    {
        public string Dir;
        public string[] FileNames;
        public int count;
        public RefStatus status;

        public ImageReference(string srcDir)
        {
            Dir = srcDir;
            ParseDir();
        }

        public enum RefStatus
        {
            Available, // dir exists, files available
            Empty, // dir exists, files not available
            Missing // dir does not exist
        }


        public void ParseDir()
        {
            if (!Directory.Exists(Dir))
            {
                status = RefStatus.Missing;
            }
            else
            {
                FileNames = Directory.GetFiles(Dir, "*.jpg", SearchOption.TopDirectoryOnly);
                count = FileNames.Length;
                status = (count == 0) ? RefStatus.Empty : RefStatus.Available;
            }
        }

        public string GetSubName()
        {
            return Path.GetFileNameWithoutExtension(Dir);
        }

        public void ExportFolder(string tgtFolder)
        {
            for (int i = 0; i < count; i++)
            {
                string fullName = FileNames[i];
                string fileName = Path.GetFileName(fullName);
                File.Copy(fullName, Path.Combine(tgtFolder, fileName), true);
            }

            Dir = tgtFolder;
            ParseDir();
        }

        /// Create a method for recovering the directory!
    }
}
