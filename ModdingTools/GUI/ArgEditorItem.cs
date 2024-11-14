using CUFramework.Dialogs.Validators;
using ModdingTools.Settings;
using ModdingTools.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;

namespace ModdingTools.GUI
{
    public partial class ArgEditorItem : UserControl
    {
        private OMMSettings.ArgsDefaultsKeys MyKey;
        public ArgEditorItem(OMMSettings.ArgsDefaultsKeys key)
        {
            MyKey = key;
            InitializeComponent();
            RefreshData();
        }

        private void RefreshData()
        {
            label5.Text = OMMSettings.Instance.GetArgumentsFor(MyKey);
            label6.Text = OMMSettings.Instance.GetLocalizedArgKeyName(MyKey);
            if (label5.Text != OMMSettings.ArgsDefaults[MyKey])
            {
                this.label6.Image = global::ModdingTools.Properties.Resources.delete;
            } 
            else
            {
                this.label6.Image = global::ModdingTools.Properties.Resources.ok;
            }
        }

        public ArgEditorItem()
        {
            InitializeComponent();
        }

        private void mButtonBorderless1_Click(object sender, EventArgs e)
        {
            OMMSettings.Instance.ResetArguments(MyKey);
            OMMSettings.Instance.Save();
            RefreshData();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            var iw = CUInputWindow.Ask(this, $"Editing arguments for action: {MyKey}", "", new NonEmptyValidator(), label5.Text, true);
            if (iw != null && iw != label5.Text)
            {
                OMMSettings.Instance.ChangeArgument(MyKey, iw);
                OMMSettings.Instance.Save();
                RefreshData();
            }
        }
    }
}
