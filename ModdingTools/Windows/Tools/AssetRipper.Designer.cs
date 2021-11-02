using CUFramework.Controls;

namespace ModdingTools.Windows.Tools
{
    partial class AssetRipper
    {
        /// <summary>
        /// Required designer variable.B
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssetRipper));
            this.mTextBox1 = new CUFramework.Controls.CUTextBox();
            this.mButton1 = new CUFramework.Controls.CUButton();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cuProgressBar1 = new CUFramework.Controls.CUProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mTextBox1
            // 
            this.mTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.mTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mTextBox1.ForeColor = System.Drawing.Color.White;
            this.mTextBox1.Location = new System.Drawing.Point(5, 39);
            this.mTextBox1.Multiline = true;
            this.mTextBox1.Name = "mTextBox1";
            this.mTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.mTextBox1.Size = new System.Drawing.Size(601, 296);
            this.mTextBox1.TabIndex = 1;
            // 
            // mButton1
            // 
            this.mButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton1.ForeColor = System.Drawing.Color.White;
            this.mButton1.Location = new System.Drawing.Point(458, 341);
            this.mButton1.Name = "mButton1";
            this.mButton1.NoFocus = false;
            this.mButton1.Size = new System.Drawing.Size(147, 23);
            this.mButton1.TabIndex = 2;
            this.mButton1.Text = "EXPORT";
            this.mButton1.UseVisualStyleBackColor = false;
            this.mButton1.Click += new System.EventHandler(this.mButton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(561, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Please, enter the asset name (one per line)\r\n(right click on the asset in the Con" +
    "tent Browser, choose the \"Copy the full name to Clipboard\" option and paste it h" +
    "ere)";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(4, 347);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(190, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Automatically convert TGA to PNG";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cuProgressBar1
            // 
            this.cuProgressBar1.BorderSize = 2;
            this.cuProgressBar1.ForeColor = System.Drawing.Color.White;
            this.cuProgressBar1.Location = new System.Drawing.Point(33, 422);
            this.cuProgressBar1.MaxValue = 100F;
            this.cuProgressBar1.Name = "cuProgressBar1";
            this.cuProgressBar1.ProgressBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.cuProgressBar1.Size = new System.Drawing.Size(601, 23);
            this.cuProgressBar1.TabIndex = 5;
            this.cuProgressBar1.Text = "...";
            this.cuProgressBar1.Value = 0F;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.mTextBox1);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.mButton1);
            this.panel1.Location = new System.Drawing.Point(29, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(616, 370);
            this.panel1.TabIndex = 6;
            // 
            // AssetRipper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 463);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cuProgressBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMaximizeButtonEnabled = false;
            this.IsResizable = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(10, 10);
            this.Name = "AssetRipper";
            this.Text = "ASSET EXPORTER";
            this.Load += new System.EventHandler(this.AssetRipper_Load);
            this.Controls.SetChildIndex(this.cuProgressBar1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CUTextBox mTextBox1;
        private CUButton mButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private CUProgressBar cuProgressBar1;
        private System.Windows.Forms.Panel panel1;
    }
}