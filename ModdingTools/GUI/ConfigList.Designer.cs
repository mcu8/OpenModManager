using CUFramework.Controls;

namespace ModdingTools.GUI
{
    partial class ConfigList
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.mButtonBorderless1 = new CUFramework.Controls.CUButtonBorderless();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cuGroupBox1 = new CUFramework.Controls.CUGroupBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.cuGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 27);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(442, 444);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.SizeChanged += new System.EventHandler(this.flowLayoutPanel1_SizeChanged);
            // 
            // mButtonBorderless1
            // 
            this.mButtonBorderless1.BackColor = System.Drawing.Color.Purple;
            this.mButtonBorderless1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mButtonBorderless1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.mButtonBorderless1.FlatAppearance.BorderSize = 0;
            this.mButtonBorderless1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButtonBorderless1.ForeColor = System.Drawing.Color.White;
            this.mButtonBorderless1.Location = new System.Drawing.Point(0, 473);
            this.mButtonBorderless1.Margin = new System.Windows.Forms.Padding(0);
            this.mButtonBorderless1.Name = "mButtonBorderless1";
            this.mButtonBorderless1.Size = new System.Drawing.Size(446, 40);
            this.mButtonBorderless1.TabIndex = 23;
            this.mButtonBorderless1.Text = "ADD NEW";
            this.mButtonBorderless1.UseVisualStyleBackColor = false;
            this.mButtonBorderless1.Click += new System.EventHandler(this.mButtonBorderless1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.cuGroupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mButtonBorderless1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(446, 513);
            this.tableLayoutPanel1.TabIndex = 24;
            // 
            // cuGroupBox1
            // 
            this.cuGroupBox1.BorderSize = 0;
            this.cuGroupBox1.Controls.Add(this.flowLayoutPanel1);
            this.cuGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cuGroupBox1.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(0)))));
            this.cuGroupBox1.HeaderFontColor = System.Drawing.Color.Black;
            this.cuGroupBox1.HeaderHeight = 25;
            this.cuGroupBox1.HeaderText = "MOD CONFIG EDITOR";
            this.cuGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.cuGroupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.cuGroupBox1.Name = "cuGroupBox1";
            this.cuGroupBox1.Padding = new System.Windows.Forms.Padding(2, 27, 2, 2);
            this.cuGroupBox1.Size = new System.Drawing.Size(446, 473);
            this.cuGroupBox1.TabIndex = 24;
            // 
            // ConfigList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ConfigList";
            this.Size = new System.Drawing.Size(446, 513);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.cuGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private CUButtonBorderless mButtonBorderless1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CUGroupBox cuGroupBox1;
    }
}
