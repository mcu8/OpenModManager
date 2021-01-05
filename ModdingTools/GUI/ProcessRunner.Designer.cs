using CUFramework.Controls;

namespace ModdingTools.GUI
{
    partial class ProcessRunner
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cuGroupBox1 = new CUFramework.Controls.CUGroupBox();
            this.consoleControl1 = new CUFramework.Controls.CUConsoleControl();
            this.mButton1 = new CUFramework.Controls.CUButton();
            this.mButton3 = new CUFramework.Controls.CUButton();
            this.cuGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cuGroupBox1
            // 
            this.cuGroupBox1.BorderSize = 0;
            this.cuGroupBox1.Controls.Add(this.consoleControl1);
            this.cuGroupBox1.Controls.Add(this.mButton1);
            this.cuGroupBox1.Controls.Add(this.mButton3);
            this.cuGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cuGroupBox1.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cuGroupBox1.HeaderFontColor = System.Drawing.Color.White;
            this.cuGroupBox1.HeaderHeight = 25;
            this.cuGroupBox1.HeaderText = "CONSOLE";
            this.cuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.cuGroupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.cuGroupBox1.Name = "cuGroupBox1";
            this.cuGroupBox1.Padding = new System.Windows.Forms.Padding(2, 27, 2, 2);
            this.cuGroupBox1.Size = new System.Drawing.Size(688, 368);
            this.cuGroupBox1.TabIndex = 10;
            // 
            // consoleControl1
            // 
            this.consoleControl1.BackColor = System.Drawing.Color.Black;
            this.consoleControl1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.consoleControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleControl1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleControl1.ForeColor = System.Drawing.Color.Plum;
            this.consoleControl1.Location = new System.Drawing.Point(2, 27);
            this.consoleControl1.Name = "consoleControl1";
            this.consoleControl1.ReadOnly = true;
            this.consoleControl1.Size = new System.Drawing.Size(684, 339);
            this.consoleControl1.TabIndex = 10;
            this.consoleControl1.Text = "";
            // 
            // mButton1
            // 
            this.mButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mButton1.BackColor = System.Drawing.Color.DimGray;
            this.mButton1.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.mButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton1.ForeColor = System.Drawing.Color.White;
            this.mButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mButton1.Location = new System.Drawing.Point(566, 1);
            this.mButton1.Name = "mButton1";
            this.mButton1.Size = new System.Drawing.Size(121, 23);
            this.mButton1.TabIndex = 9;
            this.mButton1.Text = "CLEAR OUTPUT";
            this.mButton1.UseVisualStyleBackColor = false;
            this.mButton1.Click += new System.EventHandler(this.mButton1_Click);
            // 
            // mButton3
            // 
            this.mButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mButton3.BackColor = System.Drawing.Color.DimGray;
            this.mButton3.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.mButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton3.ForeColor = System.Drawing.Color.White;
            this.mButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mButton3.Location = new System.Drawing.Point(404, 1);
            this.mButton3.Name = "mButton3";
            this.mButton3.Size = new System.Drawing.Size(161, 23);
            this.mButton3.TabIndex = 7;
            this.mButton3.Text = "CANCEL OR CLOSE";
            this.mButton3.UseVisualStyleBackColor = false;
            this.mButton3.Click += new System.EventHandler(this.mButton3_Click);
            // 
            // ProcessRunner
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.cuGroupBox1);
            this.Name = "ProcessRunner";
            this.Size = new System.Drawing.Size(688, 368);
            this.cuGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private CUButton mButton3;
        private CUButton mButton1;
        private CUGroupBox cuGroupBox1;
        private CUConsoleControl consoleControl1;
    }
}
