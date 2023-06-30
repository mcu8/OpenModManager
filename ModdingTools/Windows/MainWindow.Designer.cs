using CUFramework.Controls;
using CUFramework.Controls.Tabs;

namespace ModdingTools.Windows
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.mButton3 = new CUFramework.Controls.CUButton();
            this.mButton4 = new CUFramework.Controls.CUButton();
            this.mTextBox1 = new CUFramework.Controls.CUTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mButton1 = new CUFramework.Controls.CUButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.assetExporterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipbookGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wORKSHOPBLOCKERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mButton6 = new CUFramework.Controls.CUButton();
            this.mButton5 = new CUFramework.Controls.CUButton();
            this.mButton2 = new CUFramework.Controls.CUButton();
            this.cardController1 = new CUFramework.Controls.Tabs.CUCardController();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cuButton1 = new CUFramework.Controls.CUButton();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mButton3
            // 
            this.mButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(0)))));
            this.mButton3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton3.ForeColor = System.Drawing.Color.Black;
            this.mButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mButton3.Location = new System.Drawing.Point(196, 1);
            this.mButton3.Name = "mButton3";
            this.mButton3.NoFocus = false;
            this.mButton3.Size = new System.Drawing.Size(243, 33);
            this.mButton3.TabIndex = 6;
            this.mButton3.Text = "MAFIA PUNCH (KILL EDITOR)";
            this.mButton3.UseVisualStyleBackColor = false;
            this.mButton3.Click += new System.EventHandler(this.mButton3_Click);
            // 
            // mButton4
            // 
            this.mButton4.BackColor = System.Drawing.Color.DarkGreen;
            this.mButton4.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.mButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton4.ForeColor = System.Drawing.Color.White;
            this.mButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mButton4.Location = new System.Drawing.Point(2, 2);
            this.mButton4.Name = "mButton4";
            this.mButton4.NoFocus = false;
            this.mButton4.Size = new System.Drawing.Size(192, 32);
            this.mButton4.TabIndex = 7;
            this.mButton4.Text = "NEW MOD";
            this.mButton4.UseVisualStyleBackColor = false;
            this.mButton4.Click += new System.EventHandler(this.mButton4_Click);
            // 
            // mTextBox1
            // 
            this.mTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.mTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mTextBox1.ForeColor = System.Drawing.Color.White;
            this.mTextBox1.Location = new System.Drawing.Point(638, 8);
            this.mTextBox1.Name = "mTextBox1";
            this.mTextBox1.Size = new System.Drawing.Size(310, 20);
            this.mTextBox1.TabIndex = 8;
            this.mTextBox1.TextChanged += new System.EventHandler(this.mTextBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.DarkGray;
            this.label5.Location = new System.Drawing.Point(580, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "SEARCH";
            // 
            // mButton1
            // 
            this.mButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton1.ForeColor = System.Drawing.Color.White;
            this.mButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mButton1.Location = new System.Drawing.Point(666, 3);
            this.mButton1.Name = "mButton1";
            this.mButton1.NoFocus = false;
            this.mButton1.Size = new System.Drawing.Size(145, 30);
            this.mButton1.TabIndex = 4;
            this.mButton1.Text = "LAUNCH EDITOR";
            this.mButton1.UseVisualStyleBackColor = false;
            this.mButton1.Click += new System.EventHandler(this.mButton1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.Black;
            this.contextMenuStrip1.DropShadowEnabled = false;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.assetExporterToolStripMenuItem,
            this.flipbookGeneratorToolStripMenuItem,
            this.wORKSHOPBLOCKERToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(218, 70);
            this.contextMenuStrip1.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.contextMenuStrip1_Closed);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // assetExporterToolStripMenuItem
            // 
            this.assetExporterToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.assetExporterToolStripMenuItem.Name = "assetExporterToolStripMenuItem";
            this.assetExporterToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.assetExporterToolStripMenuItem.Text = "ASSET EXPORTER";
            this.assetExporterToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.assetExporterToolStripMenuItem.Click += new System.EventHandler(this.assetExporterToolStripMenuItem_Click);
            // 
            // flipbookGeneratorToolStripMenuItem
            // 
            this.flipbookGeneratorToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.flipbookGeneratorToolStripMenuItem.Name = "flipbookGeneratorToolStripMenuItem";
            this.flipbookGeneratorToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.flipbookGeneratorToolStripMenuItem.Text = "FLIPBOOK GENERATOR";
            this.flipbookGeneratorToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.flipbookGeneratorToolStripMenuItem.Click += new System.EventHandler(this.flipbookGeneratorToolStripMenuItem_Click);
            // 
            // wORKSHOPBLOCKERToolStripMenuItem
            // 
            this.wORKSHOPBLOCKERToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.wORKSHOPBLOCKERToolStripMenuItem.Name = "wORKSHOPBLOCKERToolStripMenuItem";
            this.wORKSHOPBLOCKERToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.wORKSHOPBLOCKERToolStripMenuItem.Text = "WORKSHOP BLOCKER (ADMIN)";
            this.wORKSHOPBLOCKERToolStripMenuItem.Click += new System.EventHandler(this.wORKSHOPBLOCKERToolStripMenuItem_Click);
            // 
            // mButton6
            // 
            this.mButton6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mButton6.BackColor = System.Drawing.Color.Black;
            this.mButton6.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.mButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton6.ForeColor = System.Drawing.Color.White;
            this.mButton6.Image = global::ModdingTools.Properties.Resources.tools;
            this.mButton6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mButton6.Location = new System.Drawing.Point(473, 2);
            this.mButton6.Name = "mButton6";
            this.mButton6.NoFocus = false;
            this.mButton6.Size = new System.Drawing.Size(82, 30);
            this.mButton6.TabIndex = 35;
            this.mButton6.Text = "TOOLS";
            this.mButton6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mButton6.UseVisualStyleBackColor = false;
            this.mButton6.Click += new System.EventHandler(this.mButton6_Click);
            // 
            // mButton5
            // 
            this.mButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mButton5.BackColor = System.Drawing.Color.Black;
            this.mButton5.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.mButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton5.ForeColor = System.Drawing.Color.White;
            this.mButton5.Image = global::ModdingTools.Properties.Resources.console1;
            this.mButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mButton5.Location = new System.Drawing.Point(556, 3);
            this.mButton5.Name = "mButton5";
            this.mButton5.NoFocus = false;
            this.mButton5.Size = new System.Drawing.Size(35, 29);
            this.mButton5.TabIndex = 34;
            this.mButton5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mButton5.UseVisualStyleBackColor = false;
            this.mButton5.Click += new System.EventHandler(this.mButton5_Click);
            // 
            // mButton2
            // 
            this.mButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mButton2.BackColor = System.Drawing.Color.Black;
            this.mButton2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.mButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton2.ForeColor = System.Drawing.Color.White;
            this.mButton2.Image = global::ModdingTools.Properties.Resources.settings_icon;
            this.mButton2.Location = new System.Drawing.Point(592, 4);
            this.mButton2.Name = "mButton2";
            this.mButton2.NoFocus = false;
            this.mButton2.Size = new System.Drawing.Size(37, 28);
            this.mButton2.TabIndex = 5;
            this.mButton2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mButton2.UseVisualStyleBackColor = false;
            this.mButton2.Click += new System.EventHandler(this.mButton2_Click);
            // 
            // cardController1
            // 
            this.cardController1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardController1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.cardController1.Location = new System.Drawing.Point(4, 71);
            this.cardController1.Margin = new System.Windows.Forms.Padding(0);
            this.cardController1.Name = "cardController1";
            this.cardController1.Size = new System.Drawing.Size(950, 440);
            this.cardController1.TabIndex = 36;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mButton4);
            this.panel1.Controls.Add(this.mButton3);
            this.panel1.Controls.Add(this.mTextBox1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(954, 35);
            this.panel1.TabIndex = 37;
            // 
            // cuButton1
            // 
            this.cuButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cuButton1.BackColor = System.Drawing.Color.Black;
            this.cuButton1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cuButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cuButton1.ForeColor = System.Drawing.Color.White;
            this.cuButton1.Image = global::ModdingTools.Properties.Resources.about;
            this.cuButton1.Location = new System.Drawing.Point(631, 4);
            this.cuButton1.Name = "cuButton1";
            this.cuButton1.NoFocus = false;
            this.cuButton1.Size = new System.Drawing.Size(32, 28);
            this.cuButton1.TabIndex = 38;
            this.cuButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cuButton1.UseVisualStyleBackColor = false;
            this.cuButton1.Click += new System.EventHandler(this.cuButton1_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 515);
            this.Controls.Add(this.cuButton1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cardController1);
            this.Controls.Add(this.mButton6);
            this.Controls.Add(this.mButton5);
            this.Controls.Add(this.mButton2);
            this.Controls.Add(this.mButton1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimumSize = new System.Drawing.Size(958, 515);
            this.Name = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResizeBegin += new System.EventHandler(this.MainWindow_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.MainWindow_ResizeEnd);
            this.Controls.SetChildIndex(this.mButton1, 0);
            this.Controls.SetChildIndex(this.mButton2, 0);
            this.Controls.SetChildIndex(this.mButton5, 0);
            this.Controls.SetChildIndex(this.mButton6, 0);
            this.Controls.SetChildIndex(this.cardController1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.cuButton1, 0);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private CUButton mButton1;
        private CUButton mButton2;
        private CUButton mButton3;
        private CUButton mButton4;
        private CUTextBox mTextBox1;
        private System.Windows.Forms.Label label5;
        private CUButton mButton5;
        private CUButton mButton6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem assetExporterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flipbookGeneratorToolStripMenuItem;
        private CUCardController cardController1;
        private System.Windows.Forms.Panel panel1;
        private CUButton cuButton1;
        private System.Windows.Forms.ToolStripMenuItem wORKSHOPBLOCKERToolStripMenuItem;
    }
}

