namespace ModdingTools.Windows
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
            this.btnEditor = new ModdingTools.GUI.MButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.iconView = new System.Windows.Forms.Panel();
            this.modName = new System.Windows.Forms.Label();
            this.modFolderName = new System.Windows.Forms.Label();
            this.mButton1 = new ModdingTools.GUI.MButton();
            this.mButton3 = new ModdingTools.GUI.MButton();
            this.mButton4 = new ModdingTools.GUI.MButton();
            this.mButton2 = new ModdingTools.GUI.MButton();
            this.tabControl1 = new Manina.Windows.Forms.TabControl();
            this.tab1 = new Manina.Windows.Forms.Tab();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.levelType = new System.Windows.Forms.ComboBox();
            this.tagsList = new System.Windows.Forms.ListView();
            this.cbCoOp = new System.Windows.Forms.CheckBox();
            this.cbOnlineParty = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.ModDescriptionEdit = new System.Windows.Forms.TextBox();
            this.tab2 = new Manina.Windows.Forms.Tab();
            this.chapterInfoInput = new ModdingTools.GUI.MTextBox();
            this.mButton7 = new ModdingTools.GUI.MButton();
            this.mButton6 = new ModdingTools.GUI.MButton();
            this.mButton5 = new ModdingTools.GUI.MButton();
            this.label4 = new System.Windows.Forms.Label();
            this.tab3 = new Manina.Windows.Forms.Tab();
            this.arList1 = new ModdingTools.GUI.ARList();
            this.tab4 = new Manina.Windows.Forms.Tab();
            this.mButton8 = new ModdingTools.GUI.MButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel7.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tab1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tab2.SuspendLayout();
            this.tab3.SuspendLayout();
            this.tab4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEditor
            // 
            this.btnEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.btnEditor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.btnEditor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditor.ForeColor = System.Drawing.Color.White;
            this.btnEditor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditor.Location = new System.Drawing.Point(607, 3);
            this.btnEditor.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.btnEditor.Name = "btnEditor";
            this.btnEditor.Size = new System.Drawing.Size(142, 30);
            this.btnEditor.TabIndex = 14;
            this.btnEditor.Text = "LAUNCH EDITOR";
            this.btnEditor.UseVisualStyleBackColor = false;
            this.btnEditor.Click += new System.EventHandler(this.btnEditor_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.panel7.Controls.Add(this.iconView);
            this.panel7.Location = new System.Drawing.Point(9, 37);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(1);
            this.panel7.Size = new System.Drawing.Size(64, 64);
            this.panel7.TabIndex = 12;
            // 
            // iconView
            // 
            this.iconView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.iconView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.iconView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iconView.Location = new System.Drawing.Point(1, 1);
            this.iconView.Name = "iconView";
            this.iconView.Size = new System.Drawing.Size(62, 62);
            this.iconView.TabIndex = 10;
            this.iconView.Click += new System.EventHandler(this.iconView_Click);
            // 
            // modName
            // 
            this.modName.AutoSize = true;
            this.modName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.modName.Location = new System.Drawing.Point(79, 44);
            this.modName.Name = "modName";
            this.modName.Size = new System.Drawing.Size(110, 25);
            this.modName.TabIndex = 13;
            this.modName.Text = "ModName";
            this.modName.Click += new System.EventHandler(this.modName_Click);
            // 
            // modFolderName
            // 
            this.modFolderName.AutoSize = true;
            this.modFolderName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.modFolderName.Location = new System.Drawing.Point(82, 75);
            this.modFolderName.Name = "modFolderName";
            this.modFolderName.Size = new System.Drawing.Size(120, 18);
            this.modFolderName.TabIndex = 14;
            this.modFolderName.Text = "ModFolderName";
            this.modFolderName.Click += new System.EventHandler(this.modFolderName_Click);
            // 
            // mButton1
            // 
            this.mButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(0)))), ((int)(((byte)(49)))));
            this.mButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton1.ForeColor = System.Drawing.Color.White;
            this.mButton1.Image = global::ModdingTools.Properties.Resources.steam1;
            this.mButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mButton1.Location = new System.Drawing.Point(613, 43);
            this.mButton1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.mButton1.Name = "mButton1";
            this.mButton1.Size = new System.Drawing.Size(202, 59);
            this.mButton1.TabIndex = 11;
            this.mButton1.Text = "VIEW IN STEAM WORKSHOP";
            this.mButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.mButton1.UseVisualStyleBackColor = false;
            this.mButton1.Click += new System.EventHandler(this.mButton1_Click);
            // 
            // mButton3
            // 
            this.mButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(0)))), ((int)(((byte)(49)))));
            this.mButton3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton3.ForeColor = System.Drawing.Color.White;
            this.mButton3.Image = global::ModdingTools.Properties.Resources.folder;
            this.mButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mButton3.Location = new System.Drawing.Point(480, 43);
            this.mButton3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.mButton3.Name = "mButton3";
            this.mButton3.Size = new System.Drawing.Size(131, 59);
            this.mButton3.TabIndex = 12;
            this.mButton3.Text = "BROWSE MOD";
            this.mButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.mButton3.UseVisualStyleBackColor = false;
            this.mButton3.Click += new System.EventHandler(this.mButton3_Click);
            // 
            // mButton4
            // 
            this.mButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(0)))), ((int)(((byte)(49)))));
            this.mButton4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton4.ForeColor = System.Drawing.Color.White;
            this.mButton4.Image = global::ModdingTools.Properties.Resources.save;
            this.mButton4.Location = new System.Drawing.Point(419, 43);
            this.mButton4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.mButton4.Name = "mButton4";
            this.mButton4.Size = new System.Drawing.Size(59, 59);
            this.mButton4.TabIndex = 13;
            this.mButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.mButton4.UseVisualStyleBackColor = false;
            this.mButton4.Click += new System.EventHandler(this.mButton4_Click);
            // 
            // mButton2
            // 
            this.mButton2.BackColor = System.Drawing.Color.Black;
            this.mButton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton2.FlatAppearance.BorderSize = 0;
            this.mButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton2.ForeColor = System.Drawing.Color.White;
            this.mButton2.Image = global::ModdingTools.Properties.Resources.refresh;
            this.mButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mButton2.Location = new System.Drawing.Point(512, 4);
            this.mButton2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.mButton2.Name = "mButton2";
            this.mButton2.Size = new System.Drawing.Size(93, 27);
            this.mButton2.TabIndex = 10;
            this.mButton2.Text = "REFRESH";
            this.mButton2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mButton2.UseVisualStyleBackColor = false;
            this.mButton2.Click += new System.EventHandler(this.mButton2_Click);
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
            this.tabControl1.Location = new System.Drawing.Point(7, 106);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Size = new System.Drawing.Size(810, 379);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.TabLocation = ((Manina.Windows.Forms.TabLocation)((Manina.Windows.Forms.TabLocation.Near | Manina.Windows.Forms.TabLocation.Left)));
            this.tabControl1.TabSize = new System.Drawing.Size(100, 48);
            this.tabControl1.TabSizing = Manina.Windows.Forms.TabSizing.Fixed;
            // 
            // tab1
            // 
            this.tab1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.tab1.Controls.Add(this.panel5);
            this.tab1.Controls.Add(this.panel3);
            this.tab1.Location = new System.Drawing.Point(100, 1);
            this.tab1.Name = "tab1";
            this.tab1.Size = new System.Drawing.Size(709, 377);
            this.tab1.Text = "Mod info";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.levelType);
            this.panel5.Controls.Add(this.tagsList);
            this.panel5.Controls.Add(this.cbCoOp);
            this.panel5.Controls.Add(this.cbOnlineParty);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Location = new System.Drawing.Point(362, 10);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(339, 360);
            this.panel5.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "LEVEL TYPE";
            // 
            // levelType
            // 
            this.levelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.levelType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.levelType.FormattingEnabled = true;
            this.levelType.Location = new System.Drawing.Point(6, 324);
            this.levelType.Name = "levelType";
            this.levelType.Size = new System.Drawing.Size(325, 28);
            this.levelType.TabIndex = 13;
            this.levelType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tagsList
            // 
            this.tagsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.tagsList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tagsList.ForeColor = System.Drawing.Color.White;
            this.tagsList.FullRowSelect = true;
            this.tagsList.HideSelection = false;
            this.tagsList.Location = new System.Drawing.Point(6, 41);
            this.tagsList.Name = "tagsList";
            this.tagsList.Size = new System.Drawing.Size(325, 142);
            this.tagsList.TabIndex = 12;
            this.tagsList.TileSize = new System.Drawing.Size(280, 36);
            this.tagsList.UseCompatibleStateImageBehavior = false;
            this.tagsList.View = System.Windows.Forms.View.Tile;
            // 
            // cbCoOp
            // 
            this.cbCoOp.AutoSize = true;
            this.cbCoOp.Location = new System.Drawing.Point(219, 187);
            this.cbCoOp.Name = "cbCoOp";
            this.cbCoOp.Size = new System.Drawing.Size(103, 24);
            this.cbCoOp.TabIndex = 11;
            this.cbCoOp.Text = "Co-Op only";
            this.cbCoOp.UseVisualStyleBackColor = true;
            // 
            // cbOnlineParty
            // 
            this.cbOnlineParty.AutoSize = true;
            this.cbOnlineParty.Location = new System.Drawing.Point(9, 187);
            this.cbOnlineParty.Name = "cbOnlineParty";
            this.cbOnlineParty.Size = new System.Drawing.Size(106, 24);
            this.cbOnlineParty.TabIndex = 10;
            this.cbOnlineParty.Text = "Online Party";
            this.cbOnlineParty.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label3.Location = new System.Drawing.Point(0, -1);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(5);
            this.label3.Size = new System.Drawing.Size(338, 32);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tags";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.ModDescriptionEdit);
            this.panel3.Location = new System.Drawing.Point(9, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(346, 360);
            this.panel3.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.label2.Location = new System.Drawing.Point(0, -1);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5);
            this.label2.Size = new System.Drawing.Size(343, 32);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mod Description";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ModDescriptionEdit
            // 
            this.ModDescriptionEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ModDescriptionEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ModDescriptionEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ModDescriptionEdit.ForeColor = System.Drawing.Color.White;
            this.ModDescriptionEdit.Location = new System.Drawing.Point(5, 40);
            this.ModDescriptionEdit.Margin = new System.Windows.Forms.Padding(2);
            this.ModDescriptionEdit.Multiline = true;
            this.ModDescriptionEdit.Name = "ModDescriptionEdit";
            this.ModDescriptionEdit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ModDescriptionEdit.Size = new System.Drawing.Size(333, 312);
            this.ModDescriptionEdit.TabIndex = 8;
            // 
            // tab2
            // 
            this.tab2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.tab2.Controls.Add(this.chapterInfoInput);
            this.tab2.Controls.Add(this.mButton7);
            this.tab2.Controls.Add(this.mButton6);
            this.tab2.Controls.Add(this.mButton5);
            this.tab2.Controls.Add(this.label4);
            this.tab2.Location = new System.Drawing.Point(100, 1);
            this.tab2.Name = "tab2";
            this.tab2.Size = new System.Drawing.Size(709, 377);
            this.tab2.Text = "Building";
            // 
            // chapterInfoInput
            // 
            this.chapterInfoInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.chapterInfoInput.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.chapterInfoInput.ForeColor = System.Drawing.Color.White;
            this.chapterInfoInput.Location = new System.Drawing.Point(26, 60);
            this.chapterInfoInput.Name = "chapterInfoInput";
            this.chapterInfoInput.Size = new System.Drawing.Size(560, 27);
            this.chapterInfoInput.TabIndex = 16;
            // 
            // mButton7
            // 
            this.mButton7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton7.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mButton7.ForeColor = System.Drawing.Color.White;
            this.mButton7.Location = new System.Drawing.Point(590, 60);
            this.mButton7.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.mButton7.Name = "mButton7";
            this.mButton7.Size = new System.Drawing.Size(88, 27);
            this.mButton7.TabIndex = 15;
            this.mButton7.Text = "DETECT";
            this.mButton7.UseVisualStyleBackColor = false;
            this.mButton7.Click += new System.EventHandler(this.mButton7_Click);
            // 
            // mButton6
            // 
            this.mButton6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mButton6.ForeColor = System.Drawing.Color.White;
            this.mButton6.Image = global::ModdingTools.Properties.Resources.settings_icon;
            this.mButton6.Location = new System.Drawing.Point(506, 318);
            this.mButton6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.mButton6.Name = "mButton6";
            this.mButton6.Size = new System.Drawing.Size(184, 38);
            this.mButton6.TabIndex = 13;
            this.mButton6.Text = "COOK MOD";
            this.mButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.mButton6.UseVisualStyleBackColor = false;
            // 
            // mButton5
            // 
            this.mButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mButton5.ForeColor = System.Drawing.Color.White;
            this.mButton5.Image = global::ModdingTools.Properties.Resources.settings_icon;
            this.mButton5.Location = new System.Drawing.Point(312, 318);
            this.mButton5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.mButton5.Name = "mButton5";
            this.mButton5.Size = new System.Drawing.Size(184, 38);
            this.mButton5.TabIndex = 12;
            this.mButton5.Text = "COMPILE SCRIPTS";
            this.mButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.mButton5.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 38);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Chapter info";
            // 
            // tab3
            // 
            this.tab3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.tab3.Controls.Add(this.arList1);
            this.tab3.Location = new System.Drawing.Point(100, 1);
            this.tab3.Name = "tab3";
            this.tab3.Size = new System.Drawing.Size(709, 377);
            this.tab3.Text = "Content";
            // 
            // arList1
            // 
            this.arList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.arList1.BackColor = System.Drawing.Color.Black;
            this.arList1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.arList1.Location = new System.Drawing.Point(4, 5);
            this.arList1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.arList1.Name = "arList1";
            this.arList1.Size = new System.Drawing.Size(701, 367);
            this.arList1.TabIndex = 0;
            // 
            // tab4
            // 
            this.tab4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.tab4.Controls.Add(this.mButton8);
            this.tab4.Controls.Add(this.label10);
            this.tab4.Controls.Add(this.label9);
            this.tab4.Controls.Add(this.label8);
            this.tab4.Controls.Add(this.label7);
            this.tab4.Controls.Add(this.label6);
            this.tab4.Controls.Add(this.label5);
            this.tab4.Location = new System.Drawing.Point(100, 1);
            this.tab4.Name = "tab4";
            this.tab4.Size = new System.Drawing.Size(709, 377);
            this.tab4.Text = "Publish";
            // 
            // mButton8
            // 
            this.mButton8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton8.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton8.ForeColor = System.Drawing.Color.White;
            this.mButton8.Image = global::ModdingTools.Properties.Resources.steam1;
            this.mButton8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mButton8.Location = new System.Drawing.Point(162, 295);
            this.mButton8.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.mButton8.Name = "mButton8";
            this.mButton8.Size = new System.Drawing.Size(368, 46);
            this.mButton8.TabIndex = 12;
            this.mButton8.Text = "UPLOAD / UPDATE THE MOD";
            this.mButton8.UseVisualStyleBackColor = false;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Segoe UI", 13.25F);
            this.label10.Location = new System.Drawing.Point(162, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(368, 50);
            this.label10.TabIndex = 5;
            this.label10.Text = "ARE YOU READY TO UPLOAD?";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label9.Image = global::ModdingTools.Properties.Resources.ok;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Location = new System.Drawing.Point(162, 232);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(368, 38);
            this.label9.TabIndex = 4;
            this.label9.Text = "Mod Tags";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label8.Image = global::ModdingTools.Properties.Resources.ok;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Location = new System.Drawing.Point(162, 192);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(368, 38);
            this.label8.TabIndex = 3;
            this.label8.Text = "Square Mod Icon";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label7.Image = global::ModdingTools.Properties.Resources.ok;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Location = new System.Drawing.Point(162, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(368, 38);
            this.label7.TabIndex = 2;
            this.label7.Text = "Mod Description";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label6.Image = global::ModdingTools.Properties.Resources.ok;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(162, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(368, 38);
            this.label6.TabIndex = 1;
            this.label6.Text = "Mod Title";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.label5.Image = global::ModdingTools.Properties.Resources.ok;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(162, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(368, 38);
            this.label5.TabIndex = 0;
            this.label5.Text = "Cooked Mod";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ModProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(0)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(824, 532);
            this.Controls.Add(this.mButton1);
            this.Controls.Add(this.mButton3);
            this.Controls.Add(this.mButton4);
            this.Controls.Add(this.mButton2);
            this.Controls.Add(this.modFolderName);
            this.Controls.Add(this.modName);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.btnEditor);
            this.Controls.Add(this.tabControl1);
            this.IsResizable = false;
            this.MinimumSize = new System.Drawing.Size(824, 532);
            this.Name = "ModProperties";
            this.Text = "-";
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.btnEditor, 0);
            this.Controls.SetChildIndex(this.panel7, 0);
            this.Controls.SetChildIndex(this.modName, 0);
            this.Controls.SetChildIndex(this.modFolderName, 0);
            this.Controls.SetChildIndex(this.mButton2, 0);
            this.Controls.SetChildIndex(this.mButton4, 0);
            this.Controls.SetChildIndex(this.mButton3, 0);
            this.Controls.SetChildIndex(this.mButton1, 0);
            this.panel7.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tab1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tab2.ResumeLayout(false);
            this.tab2.PerformLayout();
            this.tab3.ResumeLayout(false);
            this.tab4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private Manina.Windows.Forms.TabControl tabControl1;
    private Manina.Windows.Forms.Tab tab1;
    private Manina.Windows.Forms.Tab tab2;
    private Manina.Windows.Forms.Tab tab3;
    private Manina.Windows.Forms.Tab tab4;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox ModDescriptionEdit;
    private System.Windows.Forms.Label label4;
    private GUI.MButton mButton4;
    private GUI.MButton mButton3;
    private GUI.MButton mButton2;
    private GUI.MButton mButton1;
    private GUI.MButton btnEditor;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Panel panel5;
    private System.Windows.Forms.ListView tagsList;
    private System.Windows.Forms.CheckBox cbCoOp;
    private System.Windows.Forms.CheckBox cbOnlineParty;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Panel iconView;
    private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label modName;
        private System.Windows.Forms.Label modFolderName;
        private GUI.ARList arList1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox levelType;
        private GUI.MButton mButton6;
        private GUI.MButton mButton5;
        private GUI.MButton mButton7;
        private GUI.MTextBox chapterInfoInput;
        private System.Windows.Forms.Label label5;
        private GUI.MButton mButton8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}