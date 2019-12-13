using System;
using System.Text;
using System.Collections.Generic;

namespace PicAnalyzer
{
    [Serializable]
    public class DataRow
    {
        public string SubName { get; set; }
        public Dictionary<string, object> Data { get; set; }

        public DataRow(string SubName, Dictionary<string, object> Data)
        {
            this.SubName = SubName;
            this.Data = Data;
        }
        
        public string getAllCommaSeperated()
        {
            StringBuilder row = new StringBuilder();
            row.Append(SubName).Append(";");
            foreach (string key in Data.Keys)
            {
                row.Append(Data[key]).Append(";");
            }
            return row.ToString();
        }
    }
}
