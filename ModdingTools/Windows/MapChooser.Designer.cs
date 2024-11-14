namespace ModdingTools.Windows
{
    partial class MapChooser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapChooser));
            this.label6 = new System.Windows.Forms.Label();
            this.mButton9 = new CUFramework.Controls.CUButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cuButton1 = new CUFramework.Controls.CUButton();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 69);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "MAP:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mButton9
            // 
            this.mButton9.BackColor = System.Drawing.Color.Green;
            this.mButton9.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.mButton9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mButton9.ForeColor = System.Drawing.Color.White;
            this.mButton9.Image = global::ModdingTools.Properties.Resources.play;
            this.mButton9.Location = new System.Drawing.Point(373, 59);
            this.mButton9.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.mButton9.Name = "mButton9";
            this.mButton9.NoFocus = false;
            this.mButton9.Size = new System.Drawing.Size(45, 36);
            this.mButton9.TabIndex = 23;
            this.mButton9.UseVisualStyleBackColor = false;
            this.mButton9.Click += new System.EventHandler(this.mButton9_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(72, 64);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(288, 24);
            this.comboBox1.TabIndex = 22;
            // 
            // cuButton1
            // 
            this.cuButton1.BackColor = System.Drawing.Color.Red;
            this.cuButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.cuButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cuButton1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuButton1.ForeColor = System.Drawing.Color.White;
            this.cuButton1.Location = new System.Drawing.Point(155, 98);
            this.cuButton1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.cuButton1.Name = "cuButton1";
            this.cuButton1.NoFocus = false;
            this.cuButton1.Size = new System.Drawing.Size(128, 32);
            this.cuButton1.TabIndex = 25;
            this.cuButton1.Text = "Cancel";
            this.cuButton1.UseVisualStyleBackColor = false;
            this.cuButton1.Click += new System.EventHandler(this.cuButton1_Click);
            // 
            // MapChooser
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(439, 140);
            this.ControlBoxVisible = false;
            this.Controls.Add(this.cuButton1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mButton9);
            this.Controls.Add(this.comboBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsResizable = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(2560, 1268);
            this.Name = "MapChooser";
            this.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHOOSE THE MAP TO LAUNCH";
            this.TopMost = true;
            this.Controls.SetChildIndex(this.comboBox1, 0);
            this.Controls.SetChildIndex(this.mButton9, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.cuButton1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private CUFramework.Controls.CUButton mButton9;
        private System.Windows.Forms.ComboBox comboBox1;
        private CUFramework.Controls.CUButton cuButton1;
    }
}