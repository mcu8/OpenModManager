namespace ModdingTools
{
    partial class ModProperties
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new Manina.Windows.Forms.TabControl();
            this.tab1 = new Manina.Windows.Forms.Tab();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ModFolderEdit = new System.Windows.Forms.TextBox();
            this.ModNameEdit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ModDescriptionEdit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tab2 = new Manina.Windows.Forms.Tab();
            this.tab3 = new Manina.Windows.Forms.Tab();
            this.tab4 = new Manina.Windows.Forms.Tab();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tab1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(3, 440);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(819, 53);
            this.panel1.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tab1);
            this.tabControl1.Controls.Add(this.tab2);
            this.tabControl1.Controls.Add(this.tab3);
            this.tabControl1.Controls.Add(this.tab4);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ForeColor = System.Drawing.Color.White;
            this.tabControl1.Location = new System.Drawing.Point(7, 37);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Size = new System.Drawing.Size(810, 400);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.TabLocation = ((Manina.Windows.Forms.TabLocation)((Manina.Windows.Forms.TabLocation.Near | Manina.Windows.Forms.TabLocation.Left)));
            this.tabControl1.TabSize = new System.Drawing.Size(100, 48);
            this.tabControl1.TabSizing = Manina.Windows.Forms.TabSizing.Fixed;
            // 
            // tab1
            // 
            this.tab1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tab1.Controls.Add(this.textBox1);
            this.tab1.Controls.Add(this.panel2);
            this.tab1.Location = new System.Drawing.Point(100, 1);
            this.tab1.Name = "tab1";
            this.tab1.Size = new System.Drawing.Size(709, 398);
            this.tab1.Text = "Information";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.ModFolderEdit);
            this.panel2.Controls.Add(this.ModNameEdit);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.ModDescriptionEdit);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(20, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(327, 360);
            this.panel2.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mod Name";
            // 
            // ModFolderEdit
            // 
            this.ModFolderEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ModFolderEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ModFolderEdit.ForeColor = System.Drawing.Color.White;
            this.ModFolderEdit.Location = new System.Drawing.Point(13, 83);
            this.ModFolderEdit.Margin = new System.Windows.Forms.Padding(2);
            this.ModFolderEdit.Name = "ModFolderEdit";
            this.ModFolderEdit.Size = new System.Drawing.Size(296, 27);
            this.ModFolderEdit.TabIndex = 10;
            // 
            // ModNameEdit
            // 
            this.ModNameEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ModNameEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ModNameEdit.ForeColor = System.Drawing.Color.White;
            this.ModNameEdit.Location = new System.Drawing.Point(13, 27);
            this.ModNameEdit.Margin = new System.Windows.Forms.Padding(2);
            this.ModNameEdit.Name = "ModNameEdit";
            this.ModNameEdit.Size = new System.Drawing.Size(296, 27);
            this.ModNameEdit.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 61);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Mod Folder";
            // 
            // ModDescriptionEdit
            // 
            this.ModDescriptionEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ModDescriptionEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ModDescriptionEdit.ForeColor = System.Drawing.Color.White;
            this.ModDescriptionEdit.Location = new System.Drawing.Point(13, 142);
            this.ModDescriptionEdit.Margin = new System.Windows.Forms.Padding(2);
            this.ModDescriptionEdit.Multiline = true;
            this.ModDescriptionEdit.Name = "ModDescriptionEdit";
            this.ModDescriptionEdit.Size = new System.Drawing.Size(296, 205);
            this.ModDescriptionEdit.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 120);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mod Description";
            // 
            // tab2
            // 
            this.tab2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tab2.Location = new System.Drawing.Point(100, 1);
            this.tab2.Name = "tab2";
            this.tab2.Size = new System.Drawing.Size(712, 402);
            this.tab2.Text = "Scripting";
            // 
            // tab3
            // 
            this.tab3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tab3.Location = new System.Drawing.Point(100, 1);
            this.tab3.Name = "tab3";
            this.tab3.Size = new System.Drawing.Size(712, 402);
            this.tab3.Text = "Content";
            // 
            // tab4
            // 
            this.tab4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tab4.Location = new System.Drawing.Point(100, 1);
            this.tab4.Name = "tab4";
            this.tab4.Size = new System.Drawing.Size(712, 402);
            this.tab4.Text = "Publish";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(402, 47);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(296, 332);
            this.textBox1.TabIndex = 13;
            // 
            // ModProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 495);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Name = "ModProperties";
            this.Text = "-";
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.tabControl1.ResumeLayout(false);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Manina.Windows.Forms.TabControl tabControl1;
        private Manina.Windows.Forms.Tab tab1;
        private Manina.Windows.Forms.Tab tab2;
        private Manina.Windows.Forms.Tab tab3;
        private Manina.Windows.Forms.Tab tab4;
        private System.Windows.Forms.TextBox ModFolderEdit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ModDescriptionEdit;
        private System.Windows.Forms.TextBox ModNameEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
    }
}