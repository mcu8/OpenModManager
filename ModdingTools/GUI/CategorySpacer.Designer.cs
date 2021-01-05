using CUFramework.Controls;

namespace ModdingTools.GUI
{
    partial class CategorySpacer
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CUButtonBorderless1 = new CUButtonBorderless();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Location = new System.Drawing.Point(3, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(617, 3);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(210, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "CONSOLE";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(219, 7);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(365, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "CONSOLE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // CUButtonBorderless1
            // 
            this.CUButtonBorderless1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CUButtonBorderless1.BackColor = System.Drawing.Color.Transparent;
            this.CUButtonBorderless1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.CUButtonBorderless1.FlatAppearance.BorderSize = 0;
            this.CUButtonBorderless1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CUButtonBorderless1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.CUButtonBorderless1.Image = global::ModdingTools.Properties.Resources.icon_043;
            this.CUButtonBorderless1.Location = new System.Drawing.Point(590, 0);
            this.CUButtonBorderless1.Name = "CUButtonBorderless1";
            this.CUButtonBorderless1.Padding = new System.Windows.Forms.Padding(3);
            this.CUButtonBorderless1.Size = new System.Drawing.Size(30, 26);
            this.CUButtonBorderless1.TabIndex = 6;
            this.CUButtonBorderless1.UseVisualStyleBackColor = false;
            this.CUButtonBorderless1.Click += new System.EventHandler(this.CUButtonBorderless1_Click);
            // 
            // CategorySpacer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CUButtonBorderless1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CategorySpacer";
            this.Size = new System.Drawing.Size(623, 31);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private CUButtonBorderless CUButtonBorderless1;
    }
}
