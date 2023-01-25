namespace ModdingTools.Windows
{
    partial class ChangelogWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangelogWindow));
            this.cuButton1 = new CUFramework.Controls.CUButton();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cuButton2 = new CUFramework.Controls.CUButton();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cuButton1
            // 
            this.cuButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.cuButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cuButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.cuButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cuButton1.ForeColor = System.Drawing.Color.White;
            this.cuButton1.Location = new System.Drawing.Point(266, 3);
            this.cuButton1.Name = "cuButton1";
            this.cuButton1.NoFocus = false;
            this.cuButton1.Size = new System.Drawing.Size(257, 34);
            this.cuButton1.TabIndex = 1;
            this.cuButton1.Text = "YES";
            this.cuButton1.UseVisualStyleBackColor = false;
            this.cuButton1.Click += new System.EventHandler(this.cuButton1_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(4, 317);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(521, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Do you want to download this update now?";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.cuButton2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cuButton1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 343);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(526, 40);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // cuButton2
            // 
            this.cuButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cuButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cuButton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.cuButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cuButton2.ForeColor = System.Drawing.Color.White;
            this.cuButton2.Location = new System.Drawing.Point(3, 3);
            this.cuButton2.Name = "cuButton2";
            this.cuButton2.NoFocus = false;
            this.cuButton2.Size = new System.Drawing.Size(257, 34);
            this.cuButton2.TabIndex = 2;
            this.cuButton2.Text = "NO";
            this.cuButton2.UseVisualStyleBackColor = false;
            this.cuButton2.Click += new System.EventHandler(this.cuButton2_Click_1);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(2, 34);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(526, 280);
            this.webBrowser1.TabIndex = 11;
            // 
            // ChangelogWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 385);
            this.ControlBoxVisible = false;
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsCloseButtonEnabled = false;
            this.IsMaximizeButtonEnabled = false;
            this.IsMinimizeButtonEnabled = false;
            this.IsResizable = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ChangelogWindow";
            this.Text = "A NEWER VERSION OF OMM IS NOW AVAILABLE!";
            this.TitlebarColor = System.Drawing.Color.Black;
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.webBrowser1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CUFramework.Controls.CUButton cuButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CUFramework.Controls.CUButton cuButton2;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}