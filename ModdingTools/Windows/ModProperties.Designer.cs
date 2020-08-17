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
            this.processRunner1 = new ModdingTools.GUI.ProcessRunner();
            this.chapterInfoInput = new ModdingTools.GUI.MTextBox();
            this.mButton7 = new ModdingTools.GUI.MButton();
            this.mButton6 = new ModdingTools.GUI.MButton();
            this.mButton5 = new ModdingTools.GUI.MButton();
            this.label4 = new System.Windows.Forms.Label();
            this.arList1 = new ModdingTools.GUI.ARList();
            this.tabControl2 = new Manina.Windows.Forms.TabControl();
            this.tab5 = new Manina.Windows.Forms.Tab();
            this.tab6 = new Manina.Windows.Forms.Tab();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tab7 = new Manina.Windows.Forms.Tab();
            this.tab8 = new Manina.Windows.Forms.Tab();
            this.contentBrowser1 = new ModdingTools.GUI.ContentBrowser();
            this.tab1 = new Manina.Windows.Forms.Tab();
            this.mButton8 = new ModdingTools.GUI.MButton();
            this.label10 = new System.Windows.Forms.Label();
            this.flagDesc = new System.Windows.Forms.Label();
            this.flagIcon = new System.Windows.Forms.Label();
            this.flagCook = new System.Windows.Forms.Label();
            this.flagTitle = new System.Windows.Forms.Label();
            this.flagTags = new System.Windows.Forms.Label();
            this.tab2 = new Manina.Windows.Forms.Tab();
            this.configList1 = new ModdingTools.GUI.ConfigList();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mButton9 = new ModdingTools.GUI.MButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tab5.SuspendLayout();
            this.tab6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tab7.SuspendLayout();
            this.tab8.SuspendLayout();
            this.tab1.SuspendLayout();
            this.tab2.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.panel7.Location = new System.Drawing.Point(11, 37);
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
            this.modName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.modName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.modName.Location = new System.Drawing.Point(79, 41);
            this.modName.Name = "modName";
            this.modName.Size = new System.Drawing.Size(336, 25);
            this.modName.TabIndex = 13;
            this.modName.Text = "ModName";
            this.modName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.modName.Click += new System.EventHandler(this.modName_Click);
            // 
            // modFolderName
            // 
            this.modFolderName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.modFolderName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.modFolderName.Location = new System.Drawing.Point(82, 65);
            this.modFolderName.Name = "modFolderName";
            this.modFolderName.Size = new System.Drawing.Size(333, 18);
            this.modFolderName.TabIndex = 14;
            this.modFolderName.Text = "ModFolderName";
            this.modFolderName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.modFolderName.Click += new System.EventHandler(this.modFolderName_Click);
            // 
            // mButton1
            // 
            this.mButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(64)))));
            this.mButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(64)))));
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
            this.mButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(64)))));
            this.mButton3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(64)))));
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
            this.mButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(64)))));
            this.mButton4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(64)))));
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
            this.panel5.Location = new System.Drawing.Point(413, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(289, 412);
            this.panel5.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 351);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "LEVEL TYPE";
            // 
            // levelType
            // 
            this.levelType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.levelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.levelType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.levelType.FormattingEnabled = true;
            this.levelType.Location = new System.Drawing.Point(6, 374);
            this.levelType.Name = "levelType";
            this.levelType.Size = new System.Drawing.Size(275, 23);
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
            this.tagsList.Size = new System.Drawing.Size(275, 195);
            this.tagsList.TabIndex = 12;
            this.tagsList.TileSize = new System.Drawing.Size(280, 36);
            this.tagsList.UseCompatibleStateImageBehavior = false;
            this.tagsList.View = System.Windows.Forms.View.Tile;
            // 
            // cbCoOp
            // 
            this.cbCoOp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCoOp.AutoSize = true;
            this.cbCoOp.Location = new System.Drawing.Point(178, 242);
            this.cbCoOp.Name = "cbCoOp";
            this.cbCoOp.Size = new System.Drawing.Size(87, 19);
            this.cbCoOp.TabIndex = 11;
            this.cbCoOp.Text = "Co-Op only";
            this.cbCoOp.UseVisualStyleBackColor = true;
            // 
            // cbOnlineParty
            // 
            this.cbOnlineParty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbOnlineParty.AutoSize = true;
            this.cbOnlineParty.Location = new System.Drawing.Point(9, 242);
            this.cbOnlineParty.Name = "cbOnlineParty";
            this.cbOnlineParty.Size = new System.Drawing.Size(91, 19);
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
            this.label3.Size = new System.Drawing.Size(288, 32);
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
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(404, 412);
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
            this.label2.Size = new System.Drawing.Size(402, 32);
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
            this.ModDescriptionEdit.Size = new System.Drawing.Size(393, 367);
            this.ModDescriptionEdit.TabIndex = 8;
            // 
            // processRunner1
            // 
            this.processRunner1.BackColor = System.Drawing.Color.Black;
            this.processRunner1.Font = new System.Drawing.Font("Segoe UI Semilight", 9F);
            this.processRunner1.Location = new System.Drawing.Point(5, 95);
            this.processRunner1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.processRunner1.Name = "processRunner1";
            this.processRunner1.Size = new System.Drawing.Size(693, 318);
            this.processRunner1.TabIndex = 15;
            // 
            // chapterInfoInput
            // 
            this.chapterInfoInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.chapterInfoInput.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.chapterInfoInput.ForeColor = System.Drawing.Color.White;
            this.chapterInfoInput.Location = new System.Drawing.Point(91, 11);
            this.chapterInfoInput.Name = "chapterInfoInput";
            this.chapterInfoInput.Size = new System.Drawing.Size(514, 23);
            this.chapterInfoInput.TabIndex = 16;
            // 
            // mButton7
            // 
            this.mButton7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton7.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(64)))));
            this.mButton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mButton7.ForeColor = System.Drawing.Color.White;
            this.mButton7.Location = new System.Drawing.Point(609, 10);
            this.mButton7.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.mButton7.Name = "mButton7";
            this.mButton7.Size = new System.Drawing.Size(77, 24);
            this.mButton7.TabIndex = 15;
            this.mButton7.Text = "DETECT";
            this.mButton7.UseVisualStyleBackColor = false;
            this.mButton7.Click += new System.EventHandler(this.mButton7_Click);
            // 
            // mButton6
            // 
            this.mButton6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(64)))));
            this.mButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mButton6.ForeColor = System.Drawing.Color.White;
            this.mButton6.Image = global::ModdingTools.Properties.Resources.settings_icon;
            this.mButton6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mButton6.Location = new System.Drawing.Point(509, 42);
            this.mButton6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.mButton6.Name = "mButton6";
            this.mButton6.Size = new System.Drawing.Size(177, 39);
            this.mButton6.TabIndex = 13;
            this.mButton6.Text = "COOK MOD";
            this.mButton6.UseVisualStyleBackColor = false;
            this.mButton6.Click += new System.EventHandler(this.mButton6_Click);
            // 
            // mButton5
            // 
            this.mButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(64)))));
            this.mButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mButton5.ForeColor = System.Drawing.Color.White;
            this.mButton5.Image = global::ModdingTools.Properties.Resources.settings_icon;
            this.mButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mButton5.Location = new System.Drawing.Point(322, 42);
            this.mButton5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.mButton5.Name = "mButton5";
            this.mButton5.Size = new System.Drawing.Size(184, 39);
            this.mButton5.TabIndex = 12;
            this.mButton5.Text = "COMPILE SCRIPTS";
            this.mButton5.UseVisualStyleBackColor = false;
            this.mButton5.Click += new System.EventHandler(this.mButton5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Chapter info";
            // 
            // arList1
            // 
            this.arList1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.arList1.BackColor = System.Drawing.Color.Black;
            this.arList1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.arList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.arList1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.arList1.Location = new System.Drawing.Point(0, 0);
            this.arList1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.arList1.Name = "arList1";
            this.arList1.Size = new System.Drawing.Size(706, 418);
            this.arList1.TabIndex = 0;
            // 
            // tabControl2
            // 
            this.tabControl2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabControl2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tabControl2.ContentAlignment = Manina.Windows.Forms.Alignment.Center;
            this.tabControl2.Controls.Add(this.tab5);
            this.tabControl2.Controls.Add(this.tab6);
            this.tabControl2.Controls.Add(this.tab7);
            this.tabControl2.Controls.Add(this.tab8);
            this.tabControl2.Controls.Add(this.tab1);
            this.tabControl2.Controls.Add(this.tab2);
            this.tabControl2.Location = new System.Drawing.Point(10, 107);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.Size = new System.Drawing.Size(805, 418);
            this.tabControl2.TabIndex = 16;
            this.tabControl2.TabLocation = ((Manina.Windows.Forms.TabLocation)((Manina.Windows.Forms.TabLocation.Near | Manina.Windows.Forms.TabLocation.Left)));
            this.tabControl2.TabPadding = new System.Windows.Forms.Padding(10);
            this.tabControl2.TabSize = new System.Drawing.Size(100, 50);
            this.tabControl2.TabSizing = Manina.Windows.Forms.TabSizing.Fixed;
            this.tabControl2.PageChanging += new System.EventHandler<Manina.Windows.Forms.PageChangingEventArgs>(this.tabControl2_PageChanging);
            // 
            // tab5
            // 
            this.tab5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tab5.Controls.Add(this.panel5);
            this.tab5.Controls.Add(this.panel3);
            this.tab5.Location = new System.Drawing.Point(100, 0);
            this.tab5.Name = "tab5";
            this.tab5.Size = new System.Drawing.Size(706, 418);
            this.tab5.Text = "Mod info";
            // 
            // tab6
            // 
            this.tab6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tab6.Controls.Add(this.panel1);
            this.tab6.Controls.Add(this.processRunner1);
            this.tab6.Location = new System.Drawing.Point(100, 0);
            this.tab6.Name = "tab6";
            this.tab6.Size = new System.Drawing.Size(706, 418);
            this.tab6.Text = "Building";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.mButton6);
            this.panel1.Controls.Add(this.mButton7);
            this.panel1.Controls.Add(this.chapterInfoInput);
            this.panel1.Controls.Add(this.mButton5);
            this.panel1.Location = new System.Drawing.Point(5, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(693, 88);
            this.panel1.TabIndex = 17;
            // 
            // tab7
            // 
            this.tab7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tab7.Controls.Add(this.arList1);
            this.tab7.Location = new System.Drawing.Point(100, 0);
            this.tab7.Name = "tab7";
            this.tab7.Size = new System.Drawing.Size(706, 418);
            this.tab7.Text = "Asset replace.";
            // 
            // tab8
            // 
            this.tab8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tab8.Controls.Add(this.contentBrowser1);
            this.tab8.Location = new System.Drawing.Point(100, 0);
            this.tab8.Name = "tab8";
            this.tab8.Size = new System.Drawing.Size(706, 418);
            this.tab8.Text = "Content";
            // 
            // contentBrowser1
            // 
            this.contentBrowser1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.contentBrowser1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contentBrowser1.ForeColor = System.Drawing.Color.White;
            this.contentBrowser1.Location = new System.Drawing.Point(3, 3);
            this.contentBrowser1.Name = "contentBrowser1";
            this.contentBrowser1.Size = new System.Drawing.Size(700, 412);
            this.contentBrowser1.TabIndex = 0;
            // 
            // tab1
            // 
            this.tab1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tab1.Controls.Add(this.mButton8);
            this.tab1.Controls.Add(this.label10);
            this.tab1.Controls.Add(this.flagDesc);
            this.tab1.Controls.Add(this.flagIcon);
            this.tab1.Controls.Add(this.flagCook);
            this.tab1.Controls.Add(this.flagTitle);
            this.tab1.Controls.Add(this.flagTags);
            this.tab1.Location = new System.Drawing.Point(100, 0);
            this.tab1.Name = "tab1";
            this.tab1.Size = new System.Drawing.Size(706, 418);
            this.tab1.Text = "Uploading";
            // 
            // mButton8
            // 
            this.mButton8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton8.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton8.ForeColor = System.Drawing.Color.White;
            this.mButton8.Image = global::ModdingTools.Properties.Resources.steam1;
            this.mButton8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mButton8.Location = new System.Drawing.Point(155, 317);
            this.mButton8.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.mButton8.Name = "mButton8";
            this.mButton8.Size = new System.Drawing.Size(368, 46);
            this.mButton8.TabIndex = 19;
            this.mButton8.Text = "UPLOAD / UPDATE THE MOD";
            this.mButton8.UseVisualStyleBackColor = false;
            this.mButton8.Click += new System.EventHandler(this.mButton8_Click_1);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Segoe UI", 13.25F);
            this.label10.Location = new System.Drawing.Point(155, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(368, 50);
            this.label10.TabIndex = 18;
            this.label10.Text = "ARE YOU READY TO UPLOAD?";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flagDesc
            // 
            this.flagDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.flagDesc.Image = global::ModdingTools.Properties.Resources.ok;
            this.flagDesc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.flagDesc.Location = new System.Drawing.Point(155, 174);
            this.flagDesc.Name = "flagDesc";
            this.flagDesc.Size = new System.Drawing.Size(368, 38);
            this.flagDesc.TabIndex = 15;
            this.flagDesc.Text = "Mod Description";
            this.flagDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flagIcon
            // 
            this.flagIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.flagIcon.Image = global::ModdingTools.Properties.Resources.ok;
            this.flagIcon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.flagIcon.Location = new System.Drawing.Point(155, 214);
            this.flagIcon.Name = "flagIcon";
            this.flagIcon.Size = new System.Drawing.Size(368, 38);
            this.flagIcon.TabIndex = 16;
            this.flagIcon.Text = "Square Mod Icon";
            this.flagIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flagCook
            // 
            this.flagCook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.flagCook.Image = global::ModdingTools.Properties.Resources.delete;
            this.flagCook.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.flagCook.Location = new System.Drawing.Point(155, 94);
            this.flagCook.Name = "flagCook";
            this.flagCook.Size = new System.Drawing.Size(368, 38);
            this.flagCook.TabIndex = 13;
            this.flagCook.Text = "Cooked Mod";
            this.flagCook.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flagTitle
            // 
            this.flagTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.flagTitle.Image = global::ModdingTools.Properties.Resources.ok;
            this.flagTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.flagTitle.Location = new System.Drawing.Point(155, 134);
            this.flagTitle.Name = "flagTitle";
            this.flagTitle.Size = new System.Drawing.Size(368, 38);
            this.flagTitle.TabIndex = 14;
            this.flagTitle.Text = "Mod Title";
            this.flagTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flagTags
            // 
            this.flagTags.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.flagTags.Image = global::ModdingTools.Properties.Resources.ok;
            this.flagTags.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.flagTags.Location = new System.Drawing.Point(155, 254);
            this.flagTags.Name = "flagTags";
            this.flagTags.Size = new System.Drawing.Size(368, 38);
            this.flagTags.TabIndex = 17;
            this.flagTags.Text = "Mod Tags";
            this.flagTags.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tab2
            // 
            this.tab2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tab2.Controls.Add(this.configList1);
            this.tab2.Location = new System.Drawing.Point(100, 0);
            this.tab2.Name = "tab2";
            this.tab2.Size = new System.Drawing.Size(706, 418);
            this.tab2.Text = "Mod config";
            // 
            // configList1
            // 
            this.configList1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.configList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.configList1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.configList1.Location = new System.Drawing.Point(0, 0);
            this.configList1.Margin = new System.Windows.Forms.Padding(0);
            this.configList1.Name = "configList1";
            this.configList1.Size = new System.Drawing.Size(706, 418);
            this.configList1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            this.label5.Location = new System.Drawing.Point(83, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(332, 18);
            this.label5.TabIndex = 17;
            this.label5.Text = "ModVersion";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(200, 7);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(191, 23);
            this.comboBox1.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(89, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 24);
            this.label6.TabIndex = 19;
            this.label6.Text = "TEST MOD";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mButton9
            // 
            this.mButton9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton9.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(64)))));
            this.mButton9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mButton9.ForeColor = System.Drawing.Color.White;
            this.mButton9.Location = new System.Drawing.Point(396, 4);
            this.mButton9.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.mButton9.Name = "mButton9";
            this.mButton9.Size = new System.Drawing.Size(146, 30);
            this.mButton9.TabIndex = 20;
            this.mButton9.Text = "LAUNCH GAME";
            this.mButton9.UseVisualStyleBackColor = false;
            this.mButton9.Click += new System.EventHandler(this.mButton9_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.mButton9);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Location = new System.Drawing.Point(271, 531);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(545, 36);
            this.panel2.TabIndex = 21;
            // 
            // ModProperties
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(0)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(824, 573);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.mButton1);
            this.Controls.Add(this.mButton3);
            this.Controls.Add(this.mButton4);
            this.Controls.Add(this.mButton2);
            this.Controls.Add(this.modFolderName);
            this.Controls.Add(this.modName);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.btnEditor);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("Segoe UI Semilight", 9F);
            this.IsResizable = false;
            this.MinimumSize = new System.Drawing.Size(824, 532);
            this.Name = "ModProperties";
            this.Text = "-";
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.btnEditor, 0);
            this.Controls.SetChildIndex(this.panel7, 0);
            this.Controls.SetChildIndex(this.modName, 0);
            this.Controls.SetChildIndex(this.modFolderName, 0);
            this.Controls.SetChildIndex(this.mButton2, 0);
            this.Controls.SetChildIndex(this.mButton4, 0);
            this.Controls.SetChildIndex(this.mButton3, 0);
            this.Controls.SetChildIndex(this.mButton1, 0);
            this.Controls.SetChildIndex(this.tabControl2, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel7.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tab5.ResumeLayout(false);
            this.tab6.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tab7.ResumeLayout(false);
            this.tab8.ResumeLayout(false);
            this.tab1.ResumeLayout(false);
            this.tab2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion
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
        private GUI.ProcessRunner processRunner1;
        private Manina.Windows.Forms.TabControl tabControl2;
        private Manina.Windows.Forms.Tab tab5;
        private Manina.Windows.Forms.Tab tab6;
        private Manina.Windows.Forms.Tab tab7;
        private Manina.Windows.Forms.Tab tab8;
        private System.Windows.Forms.Panel panel1;
        private Manina.Windows.Forms.Tab tab1;
        private GUI.MButton mButton8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label flagDesc;
        private System.Windows.Forms.Label flagIcon;
        private System.Windows.Forms.Label flagCook;
        private System.Windows.Forms.Label flagTitle;
        private System.Windows.Forms.Label flagTags;
        private GUI.ContentBrowser contentBrowser1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        private GUI.MButton mButton9;
        private System.Windows.Forms.Panel panel2;
        private Manina.Windows.Forms.Tab tab2;
        private GUI.ConfigList configList1;
    }
}