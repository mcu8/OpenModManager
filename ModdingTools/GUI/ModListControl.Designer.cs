using CUFramework.Controls;
using System.Windows.Forms;

namespace ModdingTools.GUI
{
    partial class ModListControl
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.modContainer = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.mButtonBorderless2 = new CUFramework.Controls.CUButtonBorderless();
            this.mButtonBorderless1 = new CUFramework.Controls.CUButtonBorderless();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.DimGray;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(734, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "MOD LIST";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 457);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(606, 21);
            this.label1.TabIndex = 4;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // modContainer
            // 
            this.modContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modContainer.AutoScroll = true;
            this.modContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.modContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 724F));
            this.modContainer.Location = new System.Drawing.Point(0, 31);
            this.modContainer.Margin = new System.Windows.Forms.Padding(0);
            this.modContainer.Name = "modContainer";
            this.modContainer.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.modContainer.Size = new System.Drawing.Size(734, 426);
            this.modContainer.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Font = new System.Drawing.Font("Segoe UI Semilight", 6F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(607, 456);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label5.Size = new System.Drawing.Size(127, 22);
            this.label5.TabIndex = 9;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mButtonBorderless2
            // 
            this.mButtonBorderless2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mButtonBorderless2.BackColor = System.Drawing.Color.DarkGreen;
            this.mButtonBorderless2.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.mButtonBorderless2.FlatAppearance.BorderSize = 0;
            this.mButtonBorderless2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButtonBorderless2.ForeColor = System.Drawing.Color.White;
            this.mButtonBorderless2.Location = new System.Drawing.Point(503, 2);
            this.mButtonBorderless2.Name = "mButtonBorderless2";
            this.mButtonBorderless2.Size = new System.Drawing.Size(136, 27);
            this.mButtonBorderless2.TabIndex = 6;
            this.mButtonBorderless2.Text = "BUILD SELECTED";
            this.mButtonBorderless2.UseVisualStyleBackColor = false;
            this.mButtonBorderless2.Click += new System.EventHandler(this.mButtonBorderless2_Click);
            // 
            // mButtonBorderless1
            // 
            this.mButtonBorderless1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mButtonBorderless1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mButtonBorderless1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.mButtonBorderless1.FlatAppearance.BorderSize = 0;
            this.mButtonBorderless1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButtonBorderless1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.mButtonBorderless1.Location = new System.Drawing.Point(640, 2);
            this.mButtonBorderless1.Name = "mButtonBorderless1";
            this.mButtonBorderless1.Size = new System.Drawing.Size(91, 27);
            this.mButtonBorderless1.TabIndex = 5;
            this.mButtonBorderless1.Text = "REFRESH";
            this.mButtonBorderless1.UseVisualStyleBackColor = false;
            this.mButtonBorderless1.Click += new System.EventHandler(this.mButtonBorderless1_Click);
            // 
            // ModListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.mButtonBorderless2);
            this.Controls.Add(this.mButtonBorderless1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.modContainer);
            this.Controls.Add(this.label5);
            this.DoubleBuffered = true;
            this.Name = "ModListControl";
            this.Size = new System.Drawing.Size(734, 478);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private CUButtonBorderless mButtonBorderless1;
        private CUButtonBorderless mButtonBorderless2;
        private TableLayoutPanel modContainer;
        private System.Windows.Forms.Label label5;
    }
}
