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
using CUFramework.Controls;
using CUFramework.Windows;
using CUFramework.Dialogs;
using CUFramework.Dialogs.Validators;
using ModdingTools.Windows.Tools;
using ModdingTools.Windows.Validators;

namespace ModdingTools.Windows
{
    public partial class UploadOptions : CUWindow
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
                checkBox13.Checked = store.ForceNoTags;
                checkBox12.Checked = store.IsLanguagePack;

                listBox1.Items.AddRange(store.IgnoredFiles.ToArray());

                checkBox13_CheckedChanged(null, null);

                var wsid = mod.GetUploadedId();
                if (wsid > 0)
                {
                    label6.Text = "WorkshopId: " + wsid;
                    mButton4.Visible = false;
                    cuButton1.Visible = true;
                }
                else
                {
                    mButton4.Visible = true;
                    cuButton1.Visible = false;
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
            var tags = checkBox13.Checked ? new string[0] : GetTags();
            if (tags.Count() == 0 && !checkBox13.Checked)
            {
                CUMessageBox.Show("You should choose at least one tag!\n(or check the \"Upload without tags\" option)");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                CUMessageBox.Show("Please, enter the changelog!");
                return;
            }

            store.UploadUnCookedContent = checkBox1.Checked;
            store.UploadScripts = checkBox2.Checked;
            store.Tags = tags;
            store.Visibility = comboBox3.SelectedIndex;
            store.Changelog = textBox1.Text;
            store.ForceNoTags = checkBox13.Checked;
            store.IsLanguagePack = checkBox12.Checked;

            store.IgnoredFiles = new List<string>();
            foreach (var x in listBox1.Items)
            {
                store.IgnoredFiles.Add((string)x);
            }

            store.SaveForMod(mod);

            var iconPath = Path.Combine(mod.RootPath, mod.Icon);
            if (store.CheckIcon(mod))
            {
                var loc = store.GetGifLocation(mod);
                if (!File.Exists(loc))
                {
                    CUMessageBox.Show("You set the GIF icon for the mod but I can't find it at the '" + loc + "' path!");
                    return;
                }
                else
                {
                    iconPath = loc;
                }
            }

            Program.Uploader.UploadModAsync(mod, textBox1.Text, store.Tags, checkBox1.Checked, checkBox2.Checked, comboBox3.SelectedIndex, store.UseSeparateDescriptionForSteam ? store.GetDescription() : mod.GetDescription(), iconPath, store.IgnoredFiles);
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
            var input = CUInputWindow.Ask(this, "Steam Workshop URL", "Insert the URL to the Steam Workshop item", new NonEmptyValidator());
            if (input == null) return;

            try
            {
                var parsed = HttpUtility.ParseQueryString(new Uri(input).Query).Get("id");
                var lg = long.Parse(parsed);
                if (lg > 100000)
                {
                    mod.SetUploadedId(lg);
                    mod.Refresh();
                    var wsid = mod.GetUploadedId();
                    if (wsid > 0)
                    {
                        label6.Text = "WorkshopId: " + wsid;
                        mButton4.Visible = false;
                        cuButton1.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                CUMessageBox.Show("Invalid input: " + input + "\n" + ex.Message + "\n\n" + ex.ToString());
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            mButton1.Enabled = !checkBox13.Checked;
            borderPanel1.Enabled = !checkBox13.Checked;
        }

        private void cuButton1_Click(object sender, EventArgs e)
        {
            mod.SetUploadedId(0);
            mButton4.Visible = true;
            cuButton1.Visible = false;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            while(listBox1.SelectedItems.Count > 0)
            {
                listBox1.Items.Remove(listBox1.SelectedItems[0]);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            var modName = CUInputWindow.Ask(this, "New mod", "Please enter a file name (or wildcard) to exclude while uploading\nExamples: `CompiledScripts\\*.u` `icon.pdn` `OtherStuff\\*.*`", new WildcardValidator());
            if (string.IsNullOrEmpty(modName)) return;
            listBox1.Items.Add(modName.Replace("/", "\\").Trim());
        }
    }

    public class ModStore
    {
        public string[] Tags = null;
        public bool UploadScripts = true;
        public bool UploadUnCookedContent = false;
        public int Visibility = 0;
        public string Changelog = "Initial release!";
        public bool ForceNoTags = false;
        public bool UseSeparateDescriptionForSteam = false;
        public string Description = "";
        public string AnimatedIconFileName = "";
        public bool IsLanguagePack = false;
        public List<string> IgnoredFiles = new List<string>();

        public void SetDescription(string desc)
        {
            Description = desc.Replace(Environment.NewLine, "[br]");
        }

        public string GetDescription()
        {
            return Description.Replace("[br]", Environment.NewLine);
        }

        public bool CheckIcon(ModObject mod)
        {
            if (string.IsNullOrEmpty(AnimatedIconFileName))
                return false;

            var path = Path.Combine(mod.RootPath, AnimatedIconFileName);

            if (!File.Exists(path)) return false;

            try
            {
                return ModObject.ValidateIcon(path);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string GetGifLocation(ModObject mod)
        {
            return Path.Combine(mod.RootPath, AnimatedIconFileName);
        }

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
