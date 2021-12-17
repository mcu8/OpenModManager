using CUFramework.Dialogs;
using CUFramework.Dialogs.Validators;
using CUFramework.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModdingTools.Windows
{
    public partial class ArrayInputWindow : CUWindow
    {
        public bool AllowDuplicates { get; set; }

        public IValidator Validator;

        public ArrayInputWindow(IValidator validator = null)
        {
            InitializeComponent();
            this.Validator = validator;
        }

        public static List<string> Ask(string title, string desc, string[] defaultItems, IValidator validator)
        {   
            var a = new ArrayInputWindow(validator);
            a.label1.Text = desc;
            a.Text = title;
            if (defaultItems != null)
                a.listBox1.Items.AddRange(defaultItems);
            var result = a.ShowDialog();
            if (result == DialogResult.OK)
            {
                var res = new List<string>();
                foreach (var i in a.listBox1.Items)
                    res.Add((string)i);
                return res;
            }
            return null;
        }

        private void cuButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cuButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void cuButton3_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Contains(cuTextBox1.Text) && !AllowDuplicates)
            {
                CUMessageBox.Show("The list already contains an element with this name!");
                return;
            }
            var result = Validator != null ? Validator.Validate(cuTextBox1.Text) : "";
            if (string.IsNullOrEmpty(result))
            {
                listBox1.Items.Add(cuTextBox1.Text);
                cuTextBox1.Text = "";
            }
            else
            {
                CUMessageBox.Show(result);
            }
        }

        private void cuButton5_Click(object sender, EventArgs e)
        {
            MoveItem(-1);
        }

        // https://stackoverflow.com/questions/4796109/how-to-move-item-in-listbox-up-and-down
        public void MoveItem(int direction)
        {
            // Checking selected item
            if (listBox1.SelectedItem == null || listBox1.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            int newIndex = listBox1.SelectedIndex + direction;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= listBox1.Items.Count)
                return; // Index out of range - nothing to do

            object selected = listBox1.SelectedItem;

            // Removing removable element
            listBox1.Items.Remove(selected);
            // Insert it in new position
            listBox1.Items.Insert(newIndex, selected);
            // Restore selection
            listBox1.SetSelected(newIndex, true);
        }

        private void cuButton6_Click(object sender, EventArgs e)
        {
            MoveItem(1);
        }

        private void cuButton4_Click(object sender, EventArgs e)
        {
            while (listBox1.SelectedItems.Count > 0)
                listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void cuTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cuButton3_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
