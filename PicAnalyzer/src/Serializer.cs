using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PicAnalyzer
{
    public static class Serializer
    {
        public static void Save(string filePath, object objToSerialize)
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

        public static ApplicationState Load(string filePath)
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
        public List<DataRow> dataRows { get; set; }
        public string[] pFileNames { get; set; }
        public int counter { get; set; }
        public ApplicationState(List<DataRow> dataRows, string[] pFileNames, int counter)
        {
            this.dataRows = dataRows;
            this.pFileNames = pFileNames;
            this.counter = counter;
        }
    }
}