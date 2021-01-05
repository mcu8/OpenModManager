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
            this.mTextBox1 = new CUFramework.Controls.CUTextBox();
            this.mButton1 = new CUFramework.Controls.CUButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mTextBox1
            // 
            this.mTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.mTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mTextBox1.ForeColor = System.Drawing.Color.White;
            this.mTextBox1.Location = new System.Drawing.Point(35, 78);
            this.mTextBox1.Name = "mTextBox1";
            this.mTextBox1.Size = new System.Drawing.Size(601, 20);
            this.mTextBox1.TabIndex = 1;
            // 
            // mButton1
            // 
            this.mButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton1.ForeColor = System.Drawing.Color.White;
            this.mButton1.Location = new System.Drawing.Point(489, 110);
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
            this.label1.Location = new System.Drawing.Point(33, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(561, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Please, enter the asset name\r\n(right click on the asset in the Content Browser, c" +
    "hoose the \"Copy the full name to Clipboard\" option and paste it here)";
            // 
            // AssetRipper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 151);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mButton1);
            this.Controls.Add(this.mTextBox1);
            this.IsMaximizeButtonEnabled = false;
            this.IsResizable = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(10, 10);
            this.Name = "AssetRipper";
            this.Text = "ASSET EXPORTER";
            this.Load += new System.EventHandler(this.AssetRipper_Load);
            this.Controls.SetChildIndex(this.mTextBox1, 0);
            this.Controls.SetChildIndex(this.mButton1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CUTextBox mTextBox1;
        private CUButton mButton1;
        private System.Windows.Forms.Label label1;
    }
}