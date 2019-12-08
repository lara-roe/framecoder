using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicAnalyzer2
{
    class DataRow
    {
        public string SubName { get; set; }
        public string ImageName2 { get; set; }
        public bool personPresent { get; set; }
        public bool headFixated { get; set; }
        public bool bodyFixated { get; set; }
        public bool surroundingsFixated { get; set; }
        public bool noFixation { get; set; }

        public DataRow(string SubName, string ImageName2 , bool personPresent, bool headFixated, bool bodyFixated, bool surroundingsFixated, bool noFixation)
        {
            this.SubName = SubName;
            this.ImageName2 = ImageName2;
            this.personPresent = personPresent;
            this.headFixated = headFixated;
            this.bodyFixated = bodyFixated;
            this.surroundingsFixated = surroundingsFixated;
            this.noFixation = noFixation;
        }

        public String getAllCommaSeperated()
        {
            StringBuilder row = new StringBuilder();
            row.Append(SubName).Append(";");
            row.Append(ImageName2).Append(";");
            row.Append(personPresent ? "1" : "0").Append(";");
            row.Append(headFixated ? "1" : "0").Append(";");
            row.Append(bodyFixated ? "1" : "0").Append(";");
            row.Append(surroundingsFixated ? "1" : "0").Append(";");
            row.Append(noFixation ? "1" : "0");

            return row.ToString();
        }
    }
}
