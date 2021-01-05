namespace ModdingTools.GUI
{
    partial class GUIWorker
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
            this.label4 = new System.Windows.Forms.Label();
            this.cuGradientTextBox1 = new CUFramework.Controls.CUGradientTextBox();
            this.huehProgressBar1 = new ModdingTools.GUI.HuehProgressBar();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.label4.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 376);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5);
            this.label4.Size = new System.Drawing.Size(660, 31);
            this.label4.TabIndex = 9;
            this.label4.Text = "Please wait...";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cuGradientTextBox1
            // 
            this.cuGradientTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cuGradientTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.cuGradientTextBox1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cuGradientTextBox1.Location = new System.Drawing.Point(3, -2);
            this.cuGradientTextBox1.Name = "cuGradientTextBox1";
            this.cuGradientTextBox1.Size = new System.Drawing.Size(402, 375);
            this.cuGradientTextBox1.TabIndex = 10;
            this.cuGradientTextBox1.Text = "cuGradientTextBox1";
            this.cuGradientTextBox1.TextAlign = CUFramework.Controls.CUGradientTextBox.ETextAlign.Left;
            // 
            // huehProgressBar1
            // 
            this.huehProgressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.huehProgressBar1.ForeColor = System.Drawing.Color.White;
            this.huehProgressBar1.Location = new System.Drawing.Point(412, 32);
            this.huehProgressBar1.Name = "huehProgressBar1";
            this.huehProgressBar1.Size = new System.Drawing.Size(246, 365);
            this.huehProgressBar1.TabIndex = 11;
            this.huehProgressBar1.Value = 0;
            // 
            // GUIWorker
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.Controls.Add(this.label4);
            this.Controls.Add(this.huehProgressBar1);
            this.Controls.Add(this.cuGradientTextBox1);
            this.Name = "GUIWorker";
            this.Size = new System.Drawing.Size(660, 407);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private CUFramework.Controls.CUGradientTextBox cuGradientTextBox1;
        private HuehProgressBar huehProgressBar1;
    }
}
