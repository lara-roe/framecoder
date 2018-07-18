using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicAnalyzer
{
    class DataRow
    {
        public string VpName { get; set; }
        public string ImageName2 { get; set; }
        public bool personPresent { get; set; }
        public bool headFixed { get; set; }
        public bool bodyFixated { get; set; }
        public bool surroundingsFixated { get; set; }
        public bool noFixation { get; set; }

        public DataRow(string VpName, string ImageName2, bool personPresent, bool headFixed, bool surroundingsFixated, bool bodyFixated, bool noFixation)
        {
            this.VpName = VpName;
            this.ImageName2 = ImageName2;
            this.personPresent = personPresent;
            this.headFixed = headFixed;
            this.bodyFixated = bodyFixated;
            this.surroundingsFixated = surroundingsFixated;
            this.noFixation = noFixation;
        }

        public String getAllCommaSeperated()
        {
            StringBuilder row = new StringBuilder();
            row.Append(VpName).Append(";");
            row.Append(ImageName2).Append(";");
            row.Append(personPresent ? "1" : "0").Append(";");
            row.Append(headFixed ? "1" : "0").Append(";");
            row.Append(bodyFixated ? "1" : "0").Append(";");
            row.Append(surroundingsFixated ? "1" : "0").Append(";");
            row.Append(noFixation ? "1" : "0");

            return row.ToString();
        }
    }
}
