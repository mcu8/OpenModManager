using CUFramework.Controls;

namespace ModdingTools.Windows
{
    partial class ConfigWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mButton3 = new CUFramework.Controls.CUButton();
            this.mButton2 = new CUFramework.Controls.CUButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mButton3
            // 
            this.mButton3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(0)))));
            this.mButton3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton3.ForeColor = System.Drawing.Color.Black;
            this.mButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mButton3.Location = new System.Drawing.Point(125, 3);
            this.mButton3.Name = "mButton3";
            this.mButton3.NoFocus = false;
            this.mButton3.Size = new System.Drawing.Size(117, 32);
            this.mButton3.TabIndex = 8;
            this.mButton3.Text = "CANCEL";
            this.mButton3.UseVisualStyleBackColor = false;
            this.mButton3.Click += new System.EventHandler(this.mButton3_Click);
            // 
            // mButton2
            // 
            this.mButton2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton2.ForeColor = System.Drawing.Color.White;
            this.mButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mButton2.Location = new System.Drawing.Point(3, 3);
            this.mButton2.Name = "mButton2";
            this.mButton2.NoFocus = false;
            this.mButton2.Size = new System.Drawing.Size(116, 32);
            this.mButton2.TabIndex = 7;
            this.mButton2.Text = "SAVE";
            this.mButton2.UseVisualStyleBackColor = false;
            this.mButton2.Click += new System.EventHandler(this.mButton2_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.mButton2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mButton3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 349);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(245, 38);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(12, 91);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(226, 44);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.Text = "Enable meme - needs some elevator music placed in the program directory - it must" +
    " be named \"lol.wav\"";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(12, 47);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(226, 39);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Don\'t load workshop mods on list\r\n(faster) // requires restart";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.Location = new System.Drawing.Point(12, 141);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(216, 34);
            this.checkBox4.TabIndex = 10;
            this.checkBox4.Text = "Enable multilanguage cooking support (experimental)";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.Location = new System.Drawing.Point(12, 181);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(216, 34);
            this.checkBox5.TabIndex = 11;
            this.checkBox5.Text = "Enable update checker";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // ConfigWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 389);
            this.ControlBoxVisible = false;
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(249, 389);
            this.Name = "ConfigWindow";
            this.Text = "OMM Configuration";
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.checkBox2, 0);
            this.Controls.SetChildIndex(this.checkBox1, 0);
            this.Controls.SetChildIndex(this.checkBox4, 0);
            this.Controls.SetChildIndex(this.checkBox5, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private CUButton mButton3;
        private CUButton mButton2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
    }
}