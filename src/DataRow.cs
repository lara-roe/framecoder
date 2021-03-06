﻿using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace FrameCoder
{
    [Serializable]
    public class DataRow
    {
        public string SubName { get; set; }
        public string CurrentImage { get; set; }
        public Dictionary<string, object> Data { get; set; }

        public DataRow(string SubName, string CurrentImage, Dictionary<string, object> Data)
        {
            this.SubName = SubName;
            this.CurrentImage = CurrentImage;
            this.Data = Data;
        }
        
        public string getAllCommaSeperated()
        {
            StringBuilder row = new StringBuilder();
            row.Append(SubName).Append(";");
            row.Append(Path.GetFileName(CurrentImage)).Append(";");
            foreach (string key in Data.Keys)
            {
                row.Append(Data[key]).Append(";");
            }
            return row.ToString();
        }
    }
}
