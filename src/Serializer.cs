using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PicAnalyzer
{
    public static class Serializer
    {
        public static void SerializeState(string filePath, ApplicationState objToSerialize)
        {
            try
            {
                using (Stream stream = File.Open(filePath, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, objToSerialize);
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
    }

    [Serializable]
    public class ApplicationState
    {
        public int[] version { get; set; }
        public List<DataRow> dataRows { get; set; }
        public ImageReference imgRef { get; set; }
        public string yaml { get; set; }
        public int ImgIndex { get; set; }
        public ApplicationState(int[] version, List<DataRow> dataRows, ImageReference imgRef, string yaml, int ImgIndex)
        {
            this.version = version;
            this.dataRows = dataRows;
            this.yaml = yaml;
            this.imgRef = imgRef;
            this.ImgIndex = ImgIndex;
        }
    }
}