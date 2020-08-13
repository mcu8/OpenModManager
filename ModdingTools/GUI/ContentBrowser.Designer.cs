namespace ModdingTools.GUI
{
    partial class ContentBrowser
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContentBrowser));
            this.ContentTreeView = new System.Windows.Forms.TreeView();
            this.AssetDescriptionLabel = new System.Windows.Forms.Label();
            this.AssetNameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TreeViewImageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // ContentTreeView
            // 
            this.ContentTreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ContentTreeView.ForeColor = System.Drawing.Color.White;
            this.ContentTreeView.ImageIndex = 0;
            this.ContentTreeView.ImageList = this.TreeViewImageList;
            this.ContentTreeView.ItemHeight = 32;
            this.ContentTreeView.Location = new System.Drawing.Point(16, 16);
            this.ContentTreeView.Margin = new System.Windows.Forms.Padding(2);
            this.ContentTreeView.Name = "ContentTreeView";
            this.ContentTreeView.SelectedImageIndex = 0;
            this.ContentTreeView.Size = new System.Drawing.Size(290, 304);
            this.ContentTreeView.TabIndex = 0;
            this.ContentTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ContentTreeView_AfterSelect);
            // 
            // AssetDescriptionLabel
            // 
            this.AssetDescriptionLabel.AutoSize = true;
            this.AssetDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssetDescriptionLabel.ForeColor = System.Drawing.Color.Red;
            this.AssetDescriptionLabel.Location = new System.Drawing.Point(319, 88);
            this.AssetDescriptionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AssetDescriptionLabel.Name = "AssetDescriptionLabel";
            this.AssetDescriptionLabel.Size = new System.Drawing.Size(58, 13);
            this.AssetDescriptionLabel.TabIndex = 2;
            this.AssetDescriptionLabel.Text = "Asset Error";
            // 
            // AssetNameLabel
            // 
            this.AssetNameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AssetNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssetNameLabel.Location = new System.Drawing.Point(318, 53);
            this.AssetNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AssetNameLabel.Name = "AssetNameLabel";
            this.AssetNameLabel.Size = new System.Drawing.Size(272, 27);
            this.AssetNameLabel.TabIndex = 1;
            this.AssetNameLabel.Text = "Asset Name";
            this.AssetNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(319, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Asset name:";
            // 
            // TreeViewImageList
            // 
            this.TreeViewImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeViewImageList.ImageStream")));
            this.TreeViewImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.TreeViewImageList.Images.SetKeyName(0, "folder");
            this.TreeViewImageList.Images.SetKeyName(1, "package");
            this.TreeViewImageList.Images.SetKeyName(2, "error");
            this.TreeViewImageList.Images.SetKeyName(3, "localization");
            this.TreeViewImageList.Images.SetKeyName(4, "dye");
            this.TreeViewImageList.Images.SetKeyName(5, "hat");
            this.TreeViewImageList.Images.SetKeyName(6, "badge");
            this.TreeViewImageList.Images.SetKeyName(7, "rift");
            this.TreeViewImageList.Images.SetKeyName(8, "map");
            this.TreeViewImageList.Images.SetKeyName(9, "treasure");
            this.TreeViewImageList.Images.SetKeyName(10, "remix");
            this.TreeViewImageList.Images.SetKeyName(11, "sticker");
            this.TreeViewImageList.Images.SetKeyName(12, "weapon");
            // 
            // ContentBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AssetDescriptionLabel);
            this.Controls.Add(this.ContentTreeView);
            this.Controls.Add(this.AssetNameLabel);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "ContentBrowser";
            this.Size = new System.Drawing.Size(612, 338);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView ContentTreeView;
        private System.Windows.Forms.Label AssetDescriptionLabel;
        private System.Windows.Forms.Label AssetNameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList TreeViewImageList;
    }
}
