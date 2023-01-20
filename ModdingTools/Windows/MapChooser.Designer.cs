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
            this.label6 = new System.Windows.Forms.Label();
            this.mButton9 = new CUFramework.Controls.CUButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
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
            this.mButton9.Location = new System.Drawing.Point(269, 34);
            this.mButton9.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.mButton9.Name = "mButton9";
            this.mButton9.NoFocus = false;
            this.mButton9.Size = new System.Drawing.Size(58, 55);
            this.mButton9.TabIndex = 23;
            this.mButton9.UseVisualStyleBackColor = false;
            this.mButton9.Click += new System.EventHandler(this.mButton9_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(54, 52);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(203, 21);
            this.comboBox1.TabIndex = 22;
            // 
            // MapChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 92);
            this.ControlBoxVisible = false;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mButton9);
            this.Controls.Add(this.comboBox1);
            this.IsResizable = false;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "MapChooser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MapChooser";
            this.TopMost = true;
            this.Controls.SetChildIndex(this.comboBox1, 0);
            this.Controls.SetChildIndex(this.mButton9, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private CUFramework.Controls.CUButton mButton9;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}