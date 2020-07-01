namespace ModdingTools
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.processRunner1 = new ModdingTools.GUI.ProcessRunner();
            this.modListControl1 = new ModdingTools.GUI.ModListControl();
            this.mButton1 = new ModdingTools.GUI.MButton();
            this.mButton2 = new ModdingTools.GUI.MButton();
            this.mButton3 = new ModdingTools.GUI.MButton();
            this.mButton4 = new ModdingTools.GUI.MButton();
            this.mTextBox1 = new ModdingTools.GUI.MTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // processRunner1
            // 
            this.processRunner1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processRunner1.BackColor = System.Drawing.Color.Black;
            this.processRunner1.Location = new System.Drawing.Point(5, 385);
            this.processRunner1.Name = "processRunner1";
            this.processRunner1.Size = new System.Drawing.Size(1011, 165);
            this.processRunner1.TabIndex = 2;
            // 
            // modListControl1
            // 
            this.modListControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modListControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.modListControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.modListControl1.Location = new System.Drawing.Point(5, 64);
            this.modListControl1.Name = "modListControl1";
            this.modListControl1.Size = new System.Drawing.Size(811, 315);
            this.modListControl1.TabIndex = 3;
            // 
            // mButton1
            // 
            this.mButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton1.ForeColor = System.Drawing.Color.White;
            this.mButton1.Image = global::ModdingTools.Properties.Resources.icon_164;
            this.mButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mButton1.Location = new System.Drawing.Point(822, 303);
            this.mButton1.Name = "mButton1";
            this.mButton1.Size = new System.Drawing.Size(192, 52);
            this.mButton1.TabIndex = 4;
            this.mButton1.Text = "LAUNCH EDITOR";
            this.mButton1.UseVisualStyleBackColor = false;
            this.mButton1.Click += new System.EventHandler(this.mButton1_Click);
            // 
            // mButton2
            // 
            this.mButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton2.ForeColor = System.Drawing.Color.White;
            this.mButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mButton2.Location = new System.Drawing.Point(822, 245);
            this.mButton2.Name = "mButton2";
            this.mButton2.Size = new System.Drawing.Size(192, 52);
            this.mButton2.TabIndex = 5;
            this.mButton2.Text = "CONFIGURE";
            this.mButton2.UseVisualStyleBackColor = false;
            this.mButton2.Click += new System.EventHandler(this.mButton2_Click);
            // 
            // mButton3
            // 
            this.mButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(0)))));
            this.mButton3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton3.ForeColor = System.Drawing.Color.Black;
            this.mButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mButton3.Location = new System.Drawing.Point(822, 187);
            this.mButton3.Name = "mButton3";
            this.mButton3.Size = new System.Drawing.Size(192, 52);
            this.mButton3.TabIndex = 6;
            this.mButton3.Text = "MAFIA PUNCH\r\n(KILL EDITOR)";
            this.mButton3.UseVisualStyleBackColor = false;
            this.mButton3.Click += new System.EventHandler(this.mButton3_Click);
            // 
            // mButton4
            // 
            this.mButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mButton4.BackColor = System.Drawing.Color.DarkGreen;
            this.mButton4.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.mButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton4.ForeColor = System.Drawing.Color.White;
            this.mButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mButton4.Location = new System.Drawing.Point(822, 37);
            this.mButton4.Name = "mButton4";
            this.mButton4.Size = new System.Drawing.Size(192, 52);
            this.mButton4.TabIndex = 7;
            this.mButton4.Text = "NEW MOD";
            this.mButton4.UseVisualStyleBackColor = false;
            this.mButton4.Click += new System.EventHandler(this.mButton4_Click);
            // 
            // mTextBox1
            // 
            this.mTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.mTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mTextBox1.ForeColor = System.Drawing.Color.White;
            this.mTextBox1.Location = new System.Drawing.Point(506, 38);
            this.mTextBox1.Name = "mTextBox1";
            this.mTextBox1.Size = new System.Drawing.Size(310, 20);
            this.mTextBox1.TabIndex = 8;
            this.mTextBox1.TextChanged += new System.EventHandler(this.mTextBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.DarkGray;
            this.label5.Location = new System.Drawing.Point(452, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "SEARCH";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 555);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mTextBox1);
            this.Controls.Add(this.mButton4);
            this.Controls.Add(this.mButton3);
            this.Controls.Add(this.mButton2);
            this.Controls.Add(this.mButton1);
            this.Controls.Add(this.modListControl1);
            this.Controls.Add(this.processRunner1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "OPEN MOD MANAGER - FOR A HAT IN TIME (#SAVETHEMODDING EDITION)";
            this.Controls.SetChildIndex(this.processRunner1, 0);
            this.Controls.SetChildIndex(this.modListControl1, 0);
            this.Controls.SetChildIndex(this.mButton1, 0);
            this.Controls.SetChildIndex(this.mButton2, 0);
            this.Controls.SetChildIndex(this.mButton3, 0);
            this.Controls.SetChildIndex(this.mButton4, 0);
            this.Controls.SetChildIndex(this.mTextBox1, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GUI.ProcessRunner processRunner1;
        private GUI.ModListControl modListControl1;
        private GUI.MButton mButton1;
        private GUI.MButton mButton2;
        private GUI.MButton mButton3;
        private GUI.MButton mButton4;
        private GUI.MTextBox mTextBox1;
        private System.Windows.Forms.Label label5;
    }
}

