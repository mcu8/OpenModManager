namespace ModdingTools.GUI
{
    partial class ArgEditorItem
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.mButtonBorderless1 = new CUFramework.Controls.CUButtonBorderless();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(2, 50);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(620, 66);
            this.label5.TabIndex = 8;
            this.label5.Text = "---";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Image = global::ModdingTools.Properties.Resources.msg_exc;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Location = new System.Drawing.Point(4, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(426, 50);
            this.label6.TabIndex = 7;
            this.label6.Text = "CONF. NAME";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mButtonBorderless1
            // 
            this.mButtonBorderless1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mButtonBorderless1.BackColor = System.Drawing.Color.Transparent;
            this.mButtonBorderless1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.mButtonBorderless1.FlatAppearance.BorderSize = 0;
            this.mButtonBorderless1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButtonBorderless1.ForeColor = System.Drawing.Color.White;
            this.mButtonBorderless1.Image = global::ModdingTools.Properties.Resources.refresh;
            this.mButtonBorderless1.Location = new System.Drawing.Point(434, 0);
            this.mButtonBorderless1.Margin = new System.Windows.Forms.Padding(0);
            this.mButtonBorderless1.Name = "mButtonBorderless1";
            this.mButtonBorderless1.NoFocus = false;
            this.mButtonBorderless1.Size = new System.Drawing.Size(188, 50);
            this.mButtonBorderless1.TabIndex = 9;
            this.mButtonBorderless1.Text = "Restore default value";
            this.mButtonBorderless1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.mButtonBorderless1.UseVisualStyleBackColor = false;
            this.mButtonBorderless1.Click += new System.EventHandler(this.mButtonBorderless1_Click);
            // 
            // ArgEditorItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.mButtonBorderless1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "ArgEditorItem";
            this.Size = new System.Drawing.Size(626, 120);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private CUFramework.Controls.CUButtonBorderless mButtonBorderless1;
    }
}
