using ModdingTools.GUI;
using ModdingTools.Modding;
using ModdingTools.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace ModdingTools.Windows
{
    public partial class UploadOptions : BaseWindow
    {
        private ModObject mod;
        private ModStore store;

        public UploadOptions(ModObject mod)
        {
            InitializeComponent();
            if (!DesignMode)
            {
                mod.Refresh();
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
                this.mod = mod;
                this.store = ModStore.LoadForMod(mod);
                LoadGUITags((store.Tags != null && store.Tags.Count() > 0) ? store.Tags : null);
                textBox1.Text = store.Changelog;
                comboBox3.SelectedIndex = store.Visibility;
                checkBox1.Checked = store.UploadUnCookedContent;
                checkBox2.Checked = store.UploadScripts;

                var wsid = mod.GetUploadedId();
                if (wsid > 0)
                {
                    label6.Text = "WorkshopId: " + wsid;
                    mButton4.Visible = false;
                }
                else
                {
                    mButton4.Visible = true;
                }
            } 
        }

        public void LoadGUITags(string[] tags)
        {
            List<string> tmp = new List<string>();
            if (tags == null)
            {
                var tagsS = ModObject.CombineTags(mod.GetModClasses());
                
                foreach (var tag in tagsS)
                {
                    tmp.Add(ModClass.ClassToNameMapping[tag]);
                }

                foreach (var tag in mod.GetIniTags())
                {
                    if (!tmp.Contains(tag))
                        tmp.Add(tag);
                }

                tags = tmp.ToArray();
            }

            foreach (var c in borderPanel1.Controls)
            {
                if (c is CheckBox)
                {
                    var cb = (CheckBox)c;
                    if (tags.Contains(cb.Text))
                    {
                        cb.Checked = true;
                    }
                }
                else if (c is ComboBox)
                {
                    var cb = (ComboBox)c;
                    int i = 0;
                    foreach (var item in cb.Items)
                    {
                        if (i == 0)
                        {
                            i++;
                            continue;
                        }
                        if (tags.Contains((string)item))
                        {
                            cb.SelectedIndex = i;
                            break;
                        }
                        i++;
                    }
                }
            }
        }

        public string[] GetTags()
        {
            List<string> tags = new List<string>();
            foreach (var c in borderPanel1.Controls)
            {
                if (c is CheckBox)
                {
                    var cb = (CheckBox)c;
                    if (cb.Checked)
                    {
                        tags.Add(cb.Text);
                    }
                }
                else if (c is ComboBox)
                {
                    var cb = (ComboBox)c;
                    if (cb.SelectedIndex > 0)
                    {
                        tags.Add(cb.Text);
                    }
                }
            }

            return tags.ToArray();
        }

        private void mButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mButton2_Click(object sender, EventArgs e)
        {
            var tags = GetTags();
            if (tags.Count() == 0)
            {
                GUI.MessageBox.Show("You should choose at least one tag!");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                GUI.MessageBox.Show("Please, enter the changelog!");
                return;
            }

            store.UploadUnCookedContent = checkBox1.Checked;
            store.UploadScripts = checkBox2.Checked;
            store.Tags = tags;
            store.Visibility = comboBox3.SelectedIndex;
            store.Changelog = textBox1.Text;
            store.SaveForMod(mod);

            Program.Uploader.UploadModAsync(mod, textBox1.Text, store.Tags, checkBox1.Checked, checkBox2.Checked, comboBox3.SelectedIndex);
            this.Close();
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void mButton1_Click(object sender, EventArgs e)
        {
            LoadGUITags(null);
        }

        private void mButton4_Click(object sender, EventArgs e)
        {
            var input = InputWindow.Ask(this, "Steam Workshop URL", "Insert the URL to the Steam Workshop item", new InputWindow.NonEmptyValidator());
            if (input == null) return;

            try
            {
                var parsed = HttpUtility.ParseQueryString(new Uri(input).Query).Get("id");
                var lg = ulong.Parse(parsed);
                if (lg > 100000)
                {
                    mod.SetUploadedId(lg);
                    mod.Refresh();
                    var wsid = mod.GetUploadedId();
                    if (wsid > 0)
                    {
                        label6.Text = "WorkshopId: " + wsid;
                        mButton4.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                GUI.MessageBox.Show("Invalid input: " + input + "\n" + ex.Message + "\n\n" + ex.ToString());
            }
        }
    }

    public class ModStore
    {
        public string[] Tags = null;
        public bool UploadScripts = true;
        public bool UploadUnCookedContent = false;
        public int Visibility = 0;
        public string Changelog = "Initial release!";

        public static ModStore LoadForMod(ModObject mod)
        {
            var path = Path.Combine(mod.RootPath, "uploader.xml");
            if (File.Exists(path))
            {
                try
                {
                    var serializer = new XmlSerializer(typeof(ModStore));
                    using (Stream reader = new FileStream(path, FileMode.Open))
                    {
                        return (ModStore)serializer.Deserialize(reader);
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message + "\n" + e.ToString());
                }
            }
            return new ModStore();    
        }

        public void SaveForMod(ModObject mod)
        {
            var path = Path.Combine(mod.RootPath, "uploader.xml");
            XmlSerializer serializer =
                new XmlSerializer(typeof(ModStore));
            Stream fs = new FileStream(path, FileMode.Create);
            XmlWriter writer =
                new XmlTextWriter(fs, Encoding.Unicode);
            // Serialize using the XmlTextWriter.
            serializer.Serialize(writer, this);
            writer.Close();
        }
    }

}
