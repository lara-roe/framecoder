// define format of data row

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicAnalyzer
{
    class DataRow
    {
        public bool personPresent { get; set; }
        public bool headFixed { get; set; }
        public bool bodyFixated { get; set; }
        public bool noFixation { get; set; }

        public DataRow(bool personPresent, bool headFixed, bool bodyFixated, bool noFixation)
        {
            this.personPresent = personPresent;
            this.headFixed = headFixed;
            this.bodyFixated = bodyFixated;
            this.noFixation = noFixation;
        }

        public String getAllCommaSeperated()
        {
            StringBuilder row = new StringBuilder();
            row.Append(personPresent ? "1" : "0").Append(",");
            row.Append(headFixed ? "1" : "0").Append(",");
            row.Append(bodyFixated ? "1" : "0").Append(",");
            row.Append(noFixation ? "1" : "0");

            return row.ToString();
        }
    }
}
