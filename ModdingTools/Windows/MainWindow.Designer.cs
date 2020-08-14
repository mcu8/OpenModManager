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
            this.modListControl1 = new ModdingTools.GUI.ModListControl();
            this.mButton3 = new ModdingTools.GUI.MButton();
            this.mButton4 = new ModdingTools.GUI.MButton();
            this.mTextBox1 = new ModdingTools.GUI.MTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mButton1 = new ModdingTools.GUI.MButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.borderlessTabControl1 = new ModdingTools.GUI.BorderlessTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.processRunner1 = new ModdingTools.GUI.ProcessRunner();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.assetExporterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipbookGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mButton6 = new ModdingTools.GUI.MButton();
            this.mButton5 = new ModdingTools.GUI.MButton();
            this.mButton2 = new ModdingTools.GUI.MButton();
            this.panel1.SuspendLayout();
            this.borderlessTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // modListControl1
            // 
            this.modListControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.modListControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.modListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modListControl1.Location = new System.Drawing.Point(0, 0);
            this.modListControl1.Name = "modListControl1";
            this.modListControl1.Size = new System.Drawing.Size(944, 411);
            this.modListControl1.TabIndex = 3;
            // 
            // mButton3
            // 
            this.mButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(0)))));
            this.mButton3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton3.ForeColor = System.Drawing.Color.Black;
            this.mButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mButton3.Location = new System.Drawing.Point(198, 35);
            this.mButton3.Name = "mButton3";
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
            this.mButton4.Location = new System.Drawing.Point(4, 36);
            this.mButton4.Name = "mButton4";
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
            this.mTextBox1.Location = new System.Drawing.Point(637, 42);
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
            this.label5.Location = new System.Drawing.Point(579, 46);
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
            this.mButton1.Location = new System.Drawing.Point(741, 3);
            this.mButton1.Name = "mButton1";
            this.mButton1.Size = new System.Drawing.Size(145, 30);
            this.mButton1.TabIndex = 4;
            this.mButton1.Text = "LAUNCH EDITOR";
            this.mButton1.UseVisualStyleBackColor = false;
            this.mButton1.Click += new System.EventHandler(this.mButton1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.modListControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 411);
            this.panel1.TabIndex = 32;
            // 
            // borderlessTabControl1
            // 
            this.borderlessTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.borderlessTabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.borderlessTabControl1.Controls.Add(this.tabPage1);
            this.borderlessTabControl1.Controls.Add(this.tabPage2);
            this.borderlessTabControl1.ItemSize = new System.Drawing.Size(58, 0);
            this.borderlessTabControl1.Location = new System.Drawing.Point(4, 72);
            this.borderlessTabControl1.Multiline = true;
            this.borderlessTabControl1.Name = "borderlessTabControl1";
            this.borderlessTabControl1.Padding = new System.Drawing.Point(0, 0);
            this.borderlessTabControl1.SelectedIndex = 0;
            this.borderlessTabControl1.Size = new System.Drawing.Size(952, 440);
            this.borderlessTabControl1.TabIndex = 33;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(944, 411);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.processRunner1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(944, 411);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // processRunner1
            // 
            this.processRunner1.BackColor = System.Drawing.Color.Black;
            this.processRunner1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processRunner1.Location = new System.Drawing.Point(0, 0);
            this.processRunner1.Margin = new System.Windows.Forms.Padding(0);
            this.processRunner1.Name = "processRunner1";
            this.processRunner1.Size = new System.Drawing.Size(944, 411);
            this.processRunner1.TabIndex = 12;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.Black;
            this.contextMenuStrip1.DropShadowEnabled = false;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.assetExporterToolStripMenuItem,
            this.flipbookGeneratorToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(171, 48);
            this.contextMenuStrip1.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.contextMenuStrip1_Closed);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // assetExporterToolStripMenuItem
            // 
            this.assetExporterToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.assetExporterToolStripMenuItem.Name = "assetExporterToolStripMenuItem";
            this.assetExporterToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.assetExporterToolStripMenuItem.Text = "ASSET EXPORTER";
            this.assetExporterToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.assetExporterToolStripMenuItem.Click += new System.EventHandler(this.assetExporterToolStripMenuItem_Click);
            // 
            // flipbookGeneratorToolStripMenuItem
            // 
            this.flipbookGeneratorToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.flipbookGeneratorToolStripMenuItem.Name = "flipbookGeneratorToolStripMenuItem";
            this.flipbookGeneratorToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.flipbookGeneratorToolStripMenuItem.Text = "FLIPBOOK GENERATOR";
            this.flipbookGeneratorToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.flipbookGeneratorToolStripMenuItem.Click += new System.EventHandler(this.flipbookGeneratorToolStripMenuItem_Click);
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
            this.mButton6.Location = new System.Drawing.Point(563, 2);
            this.mButton6.Name = "mButton6";
            this.mButton6.Size = new System.Drawing.Size(82, 32);
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
            this.mButton5.Location = new System.Drawing.Point(660, 3);
            this.mButton5.Name = "mButton5";
            this.mButton5.Size = new System.Drawing.Size(35, 31);
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
            this.mButton2.Location = new System.Drawing.Point(699, 4);
            this.mButton2.Name = "mButton2";
            this.mButton2.Size = new System.Drawing.Size(37, 30);
            this.mButton2.TabIndex = 5;
            this.mButton2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mButton2.UseVisualStyleBackColor = false;
            this.mButton2.Click += new System.EventHandler(this.mButton2_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 515);
            this.Controls.Add(this.mButton6);
            this.Controls.Add(this.mButton5);
            this.Controls.Add(this.borderlessTabControl1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mTextBox1);
            this.Controls.Add(this.mButton4);
            this.Controls.Add(this.mButton3);
            this.Controls.Add(this.mButton2);
            this.Controls.Add(this.mButton1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(958, 515);
            this.Name = "MainWindow";
            this.Text = "OPEN MOD MANAGER - FOR A HAT IN TIME (!GAMEDAT ANNIVERSARY EDITION)";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResizeBegin += new System.EventHandler(this.MainWindow_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.MainWindow_ResizeEnd);
            this.Controls.SetChildIndex(this.mButton1, 0);
            this.Controls.SetChildIndex(this.mButton2, 0);
            this.Controls.SetChildIndex(this.mButton3, 0);
            this.Controls.SetChildIndex(this.mButton4, 0);
            this.Controls.SetChildIndex(this.mTextBox1, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.borderlessTabControl1, 0);
            this.Controls.SetChildIndex(this.mButton5, 0);
            this.Controls.SetChildIndex(this.mButton6, 0);
            this.panel1.ResumeLayout(false);
            this.borderlessTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GUI.ModListControl modListControl1;
        private GUI.MButton mButton1;
        private GUI.MButton mButton2;
        private GUI.MButton mButton3;
        private GUI.MButton mButton4;
        private GUI.MTextBox mTextBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private GUI.BorderlessTabControl borderlessTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private GUI.ProcessRunner processRunner1;
        private GUI.MButton mButton5;
        private GUI.MButton mButton6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem assetExporterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flipbookGeneratorToolStripMenuItem;
    }
}

