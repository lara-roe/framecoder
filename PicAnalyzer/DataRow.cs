using System;
using System.Text;

namespace PicAnalyzer
{
    [Serializable]
    class DataRow
    {
        public string SubName { get; set; }
        public string ImageName { get; set; }
        public string Comment { get; set; }
        public bool personPresent { get; set; }
        public bool headFixated { get; set; }
        public bool bodyFixated { get; set; }
        public bool surroundingsFixated { get; set; }
        public bool noFixation { get; set; }

        public DataRow(string SubName, string ImageName, bool personPresent, bool headFixated, bool bodyFixated, bool surroundingsFixated, bool noFixation, string Comment)
        {
            this.SubName                = SubName;
            this.ImageName              = ImageName;
            this.personPresent          = personPresent;
            this.headFixated            = headFixated;
            this.bodyFixated            = bodyFixated;
            this.surroundingsFixated    = surroundingsFixated;
            this.noFixation             = noFixation;
            this.Comment                = Comment;
        }

        public String getAllCommaSeperated()
        {
            StringBuilder row = new StringBuilder();
            row.Append(SubName).Append(";");
            row.Append(ImageName).Append(";");
            row.Append(personPresent ? "1" : "0").Append(";");
            row.Append(headFixated ? "1" : "0").Append(";");
            row.Append(bodyFixated ? "1" : "0").Append(";");
            row.Append(surroundingsFixated ? "1" : "0").Append(";");
            row.Append(noFixation ? "1" : "0").Append(";");
            row.Append(Comment);

            return row.ToString();
        }
    }
}
