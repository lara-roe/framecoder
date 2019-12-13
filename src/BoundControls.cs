using System;
using System.IO;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;
using YamlDotNet.Serialization;

namespace PicAnalyzer
{
    public class BoundControls
    {
        public string yaml;
        private GroupBox parent;
        private List<YamlControl> yamlControls;

        public BoundControls(GroupBox Parent)
        {
            // constructor
            parent = Parent;
        }

        public class YamlControl
        {
            public string type { get; set; }
            public string title { get; set; }
            public string name { get; set; }
            public int key { get; set; }
            public List<YamlControl> options { get; set; }

            public Keys GetKey()
            {
                switch (key)
                {
                    case 1:
                        return Keys.D1;
                    case 2:
                        return Keys.D2;
                    case 3:
                        return Keys.D3;
                    case 4:
                        return Keys.D4;
                    case 5:
                        return Keys.D5;
                    case 6:
                        return Keys.D6;
                    case 7:
                        return Keys.D7;
                    case 8:
                        return Keys.D8;
                    case 9:
                        return Keys.D9;
                    default:
                        return Keys.Attn; // placeholder key, not used
                }
            }
        }

        public void LoadYamlFile(string yamlPath)
        {
            yaml = File.ReadAllText(yamlPath);
        }

        public void ParseYaml()
        {
            IDeserializer deserializer = new DeserializerBuilder().Build();
            yamlControls = deserializer.Deserialize<List<YamlControl>>(yaml);
        }


        // Control creation
        public void CreateControls()
        {
            int currentHeight = 21;
            for (int i = 0; i < yamlControls.Count; i++)
            {
                switch (yamlControls[i].type)
                {
                    case "checkbox":
                        CheckBox cb = CreateCheckBox(yamlControls[i]);
                        cb.Location = new Point(6, currentHeight);
                        parent.Controls.Add(cb);
                        currentHeight += cb.Size.Height + 6;
                        break;
                    case "radiobutton":
                        GroupBox gb = CreateRadioControl(yamlControls[i]);
                        gb.Location = new Point(6, currentHeight);
                        parent.Controls.Add(gb);
                        currentHeight += gb.Size.Height + 6;
                        break;
                    case "textfield":
                        TextBox tb = CreateTextBox(yamlControls[i]);
                        tb.Location = new Point(6, currentHeight);
                        parent.Controls.Add(tb);
                        currentHeight += tb.Size.Height + 6;
                        break;
                    default:
                        break;
                }
            }
        }

        private CheckBox CreateCheckBox(YamlControl comp)
        {
            CheckBox cbx = new CheckBox();
            cbx.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            cbx.AutoSize = true;
            cbx.BackColor = SystemColors.ControlLightLight;
            cbx.ForeColor = SystemColors.ActiveCaptionText;
            cbx.Name = comp.name;
            cbx.Size = new Size(97, 17);
            cbx.Text = comp.title;
            cbx.UseVisualStyleBackColor = false;
            return cbx;
        }

        private TextBox CreateTextBox(YamlControl comp)
        {
            TextBox tbx = new TextBox
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Multiline = true,
                Name = comp.name,
                Size = new System.Drawing.Size(165, 103)
            };
            return tbx;
        }

        private GroupBox CreateRadioControl(YamlControl comp)
        {
            GroupBox container = new GroupBox
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Size = new System.Drawing.Size(165, 32),
                AutoSize = true,
                Name = comp.name,
                TabStop = false,
                Text = comp.title
            };

            // then, add a list of radiobutton controls starting at height 3
            int currentHeight = 21;
            for (int i = 0; i < comp.options.Count; i++)
            {
                RadioButton btn = new RadioButton
                {
                    AutoSize = true,
                    Name = comp.options[i].name,
                    Location = new Point(6, currentHeight),
                    Size = new System.Drawing.Size(34, 17),
                    TabStop = true,
                    Text = comp.options[i].title,
                    UseVisualStyleBackColor = true
                };
                currentHeight += 23;
                container.Controls.Add(btn);
            }

            return container;
        }

        public void RegisterShortcuts(Dictionary<Keys, Action> shortcuts)
        {
            for (int i = 0; i < yamlControls.Count; i++)
            {
                switch (yamlControls[i].type)
                {
                    case "checkbox":
                        string cbname = yamlControls[i].name;
                        shortcuts[yamlControls[i].GetKey()] = () =>
                        {
                            CheckBox cb = parent.Controls.Find(cbname, true)[0] as CheckBox;
                            cb.Checked = !cb.Checked;
                        };
                        break;
                    case "radiobutton":
                        for (int j = 0; j < yamlControls[i].options.Count; j++)
                        {
                            string rbname = yamlControls[i].options[j].name;
                            shortcuts[yamlControls[i].options[j].GetKey()] = () =>
                            {
                                RadioButton rb = parent.Controls.Find(rbname, true)[0] as RadioButton;
                                rb.Checked = true;
                            };
                        }
                        break;
                    case "textfield":
                        string tfname = yamlControls[i].name;
                        shortcuts[yamlControls[i].GetKey()] = () =>
                        {
                            TextBox tb = parent.Controls.Find(tfname, true)[0] as TextBox;
                            tb.Focus();
                        };
                        break;
                    default:
                        break;
                };
            }
        }

        // Get and set data from the UI elements
        public Dictionary<string, object> GetData()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            for (int i = 0; i < yamlControls.Count; i++)
            {
                switch (yamlControls[i].type)
                {
                    case "checkbox":
                        string cbname = yamlControls[i].name;
                        CheckBox cb = parent.Controls.Find(cbname, true)[0] as CheckBox;
                        dict.Add(cbname, cb.Checked ? 1 : 0);
                        break;
                    case "radiobutton":
                        string gbname = yamlControls[i].name;
                        for (int j = 0; j < yamlControls[i].options.Count; j++)
                        {
                            string rbname = yamlControls[i].options[j].name;
                            RadioButton rb = parent.Controls.Find(rbname, true)[0] as RadioButton;
                            if (rb.Checked)
                            {
                                dict.Add(gbname, rbname);
                            }
                        }
                        break;
                    case "textfield":
                        string tfname = yamlControls[i].name;
                        TextBox tb = parent.Controls.Find(tfname, true)[0] as TextBox;
                        dict.Add(tfname, tb.Text);
                        break;
                    default:
                        break;
                }
            }
            return dict;
        }

        public void SetData(Dictionary<string, object> Data)
        {
            foreach (string key in Data.Keys)
            {
                Control ctrl = parent.Controls.Find(key, true)[0];
                string type = ctrl.GetType().ToString();
                switch (ctrl.GetType().ToString())
                {
                    case "System.Windows.Forms.CheckBox":
                        (ctrl as CheckBox).Checked = (int)Data[key] == 1;
                        break;
                    case "System.Windows.Forms.TextBox":
                        ctrl.Text = Data[key].ToString();
                        break;
                    case "System.Windows.Forms.GroupBox":
                        RadioButton rbtn = ctrl.Controls.Find(Data[key].ToString(), true)[0] as RadioButton;
                        rbtn.Checked = true;
                        break;
                    default:
                        break;
                }
            }
        }

        public void RemoveControls()
        {
            foreach (YamlControl obj in yamlControls)
            {
                Control ctrl = parent.Controls.Find(obj.name, true)[0];
                ctrl.Dispose();
            }
        }

        public string[] GetNames()
        {
            int n = yamlControls.Count;
            string[] names = new string[n];
            for (int i = 0; i < n; i++)
            {
                names[i] = yamlControls[i].name;
            }
            return names;
        }
    }
}

