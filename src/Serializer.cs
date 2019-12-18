using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace FrameCoder
{
    public static class Serializer
    {
        public static void SerializeState(string filePath, ApplicationState appState)
        {
            try
            {
                using (Stream stream = File.Open(filePath, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, appState);
                }
            }
            catch (IOException)
            {
            }
        }

        public static ApplicationState UnserializeState(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                BinaryFormatter bin = new BinaryFormatter();
                return (ApplicationState)bin.Deserialize(stream);
            }
        }

        public static bool ImgRefIsValid(ImageReference newRef, ImageReference oldRef)
        {
            // see if newRef is correct based on oldRef
            if (newRef.status == ImageReference.RefStatus.Missing)
            {
                return false;
            }
            if (newRef.status == ImageReference.RefStatus.Empty)
            {
                MessageBox.Show("Frame loading failed: no .jpg frames in folder", "Frame loading error.");
                return false;
            }
            if (newRef.count != oldRef.count)
            {
                MessageBox.Show(
                    "Frame loading failed: different number of frames in selected folder." + Environment.NewLine +
                    "New count: " + newRef.count + Environment.NewLine + 
                    "Old count: " + oldRef.count + ".", 
                    "Frame loading error.");
                return false;
            }
            for (int i = 0; i < newRef.count; i++)
            {
                if (Path.GetFileName(newRef.FileNames[i]) != Path.GetFileName(oldRef.FileNames[i]))
                {
                    MessageBox.Show(
                        "Warning: frame names changed." + Environment.NewLine +
                        "Exported csv may be affected.",
                        "Frame loading warning."
                    );
                    break;
                }
            }
            if (newRef.GetSubName() != oldRef.GetSubName())
            {
                MessageBox.Show(
                    "Warning: different folder / subject name." + Environment.NewLine +
                    "New name: " + newRef.GetSubName() + Environment.NewLine +
                    "Old name: " + oldRef.GetSubName() + Environment.NewLine +
                    "Exported csv may be affected.",
                    "Frame loading warning."
                );
            }
            return true;
        }
    }

    [Serializable]
    public class ApplicationState
    {
        public Version version { get; set; }
        public List<DataRow> dataRows { get; set; }
        public ImageReference imgRef { get; set; }
        public string yaml { get; set; }
        public int ImgIndex { get; set; }
        public ApplicationState(Version version, List<DataRow> dataRows, ImageReference imgRef, string yaml, int ImgIndex)
        {
            this.version = version;
            this.dataRows = dataRows;
            this.yaml = yaml;
            this.imgRef = imgRef;
            this.ImgIndex = ImgIndex;
        }
    }
}