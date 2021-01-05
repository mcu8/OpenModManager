using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModdingTools.Windows;
using ModdingTools.Modding;
using CUFramework.Dialogs.Validators;

namespace ModdingTools.GUI
{
    public partial class ConfigItem : UserControl
    {
        ModObject.ModConfigItem Conf;
        ModObject Obj;

        public ConfigItem(ModObject.ModConfigItem item, ModObject ob)
        {
            InitializeComponent();
            Conf = item;
            Obj = ob;

            label4.Text = Conf.PropertyName;
            label3.Text = Conf.Description.Replace("[br]", Environment.NewLine);
            label5.Text = Conf.Name;

            RepopulateOptionsDict(true);
        }

        private void mButtonBorderless1_Click(object sender, EventArgs e)
        {
            CallUpdateEvent();
            if (this.Parent is FlowLayoutPanel)
            {
                this.Parent.Controls.Remove(this);
            }
            Obj.Config.Remove(Conf);
        }

        private void CallUpdateEvent()
        {
            if (this.Parent.Parent is ConfigList)
                ((ConfigList)this.Parent.Parent).CallOnUpdateEvent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            var a = CUInputWindow.Ask(this, "Config Editor", "Please, enter config property name (var config int <name>)", new NonEmptyValidator(), label4.Text);
            if (a != null)
            {
                label4.Text = a;
                Conf.PropertyName = a;
                CallUpdateEvent();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            var a = CUInputWindow.Ask(this, "Config Editor", "Please, enter the description", new NonEmptyValidator(), label3.Text, true);
            if (a != null)
            {
                label3.Text = a;
                Conf.Description = a.Replace(Environment.NewLine, "[br]");
                CallUpdateEvent();
            }
        }

        private void ConfigItem_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            var a = CUInputWindow.Ask(this, "Config Editor", "Please, enter config display name", new NonEmptyValidator(), label5.Text);
            if (a != null)
            {
                label5.Text = a;
                Conf.Name = a;
                CallUpdateEvent();
            }
        }

        private void RepopulateOptionsDict(bool firstRun = false)
        {
            int i = 0;
            if (!firstRun)
            {
                Conf.Options.Clear();   
                foreach (var item in listBox1.Items)
                {
                    Conf.Options.Add(i, (string)item);
                    i++;
                }
            }
            else
            {
                foreach (var conf in Conf.Options)
                {
                    listBox1.Items.Add(conf.Value);
                }
            }

            comboBox1.Items.Clear();
            i = 0;
            foreach (var item in listBox1.Items)
            {
                comboBox1.Items.Add((string)item);
                if (i == Conf.DefaultIndex)
                {
                    comboBox1.SelectedIndex = i;
                }
                i++;
            }

        }

        private void mButtonBorderless3_Click(object sender, EventArgs e)
        {
            var a = CUInputWindow.Ask(this, "Config Editor", "Please, enter a new value name", new NonEmptyValidator());
            if (a != null)
            {
                listBox1.Items.Add(a);
                RepopulateOptionsDict();
                CallUpdateEvent();
            }
        }

        private void mButtonBorderless2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
            RepopulateOptionsDict();
            CallUpdateEvent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Conf.DefaultIndex != comboBox1.SelectedIndex)
                CallUpdateEvent();

            Conf.DefaultIndex = comboBox1.SelectedIndex;
        }
    }
}
