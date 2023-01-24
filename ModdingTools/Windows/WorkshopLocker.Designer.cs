namespace ModdingTools.Windows
{
    partial class WorkshopLocker
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
            this.mButton2 = new CUFramework.Controls.CUButton();
            this.cuButton1 = new CUFramework.Controls.CUButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cuGroupBox1 = new CUFramework.Controls.CUGroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cuGroupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.mButton2.Location = new System.Drawing.Point(89, 283);
            this.mButton2.Name = "mButton2";
            this.mButton2.NoFocus = false;
            this.mButton2.Size = new System.Drawing.Size(219, 50);
            this.mButton2.TabIndex = 8;
            this.mButton2.Text = "LOCK WORKSHOP FOLDER ACCESS";
            this.mButton2.UseVisualStyleBackColor = false;
            this.mButton2.Click += new System.EventHandler(this.mButton2_Click);
            // 
            // cuButton1
            // 
            this.cuButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cuButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.cuButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.cuButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cuButton1.ForeColor = System.Drawing.Color.White;
            this.cuButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cuButton1.Location = new System.Drawing.Point(314, 283);
            this.cuButton1.Name = "cuButton1";
            this.cuButton1.NoFocus = false;
            this.cuButton1.Size = new System.Drawing.Size(219, 50);
            this.cuButton1.TabIndex = 9;
            this.cuButton1.Text = "UNLOCK WORKSHOP FOLDER ACCESS";
            this.cuButton1.UseVisualStyleBackColor = false;
            this.cuButton1.Click += new System.EventHandler(this.cuButton1_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(3, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 69);
            this.label1.TabIndex = 23;
            this.label1.Text = "N/A";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(86, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(444, 52);
            this.label2.TabIndex = 24;
            this.label2.Text = "Use this tool if you wanteżt to temporarily prevent the game and/or editor from l" +
    "oading mods from the Workshop folder.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cuGroupBox1
            // 
            this.cuGroupBox1.BorderSize = 3;
            this.cuGroupBox1.Controls.Add(this.label1);
            this.cuGroupBox1.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(0)))));
            this.cuGroupBox1.HeaderFontColor = System.Drawing.Color.Black;
            this.cuGroupBox1.HeaderHeight = 25;
            this.cuGroupBox1.HeaderText = "CURRENT STATE:";
            this.cuGroupBox1.Location = new System.Drawing.Point(211, 157);
            this.cuGroupBox1.Name = "cuGroupBox1";
            this.cuGroupBox1.Padding = new System.Windows.Forms.Padding(3, 28, 3, 3);
            this.cuGroupBox1.Size = new System.Drawing.Size(200, 100);
            this.cuGroupBox1.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(86, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(444, 48);
            this.label3.TabIndex = 26;
            this.label3.Text = "DO NOT FORGET TO RE-ENABLE THE ACCESS, AS IT WILL EVEN BLOCK STEAM FROM ACCESSING" +
    " IT!";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // WorkshopLocker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 348);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cuGroupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cuButton1);
            this.Controls.Add(this.mButton2);
            this.IsMaximizeButtonEnabled = false;
            this.IsMinimizeButtonEnabled = false;
            this.IsResizable = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "WorkshopLocker";
            this.Text = "WORKSHOP FOLDER BLOCKER";
            this.Controls.SetChildIndex(this.mButton2, 0);
            this.Controls.SetChildIndex(this.cuButton1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.cuGroupBox1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.cuGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CUFramework.Controls.CUButton mButton2;
        private CUFramework.Controls.CUButton cuButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CUFramework.Controls.CUGroupBox cuGroupBox1;
        private System.Windows.Forms.Label label3;
    }
}