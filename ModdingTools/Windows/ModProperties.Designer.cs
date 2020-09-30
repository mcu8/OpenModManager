using ModdingTools.GUI;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModProperties));
            this.btnEditor = new ModdingTools.GUI.MButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.iconView = new System.Windows.Forms.Panel();
            this.modName = new System.Windows.Forms.Label();
            this.modFolderName = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.levelType = new System.Windows.Forms.ComboBox();
            this.tagsList = new System.Windows.Forms.ListView();
            this.cbCoOp = new System.Windows.Forms.CheckBox();
            this.cbOnlineParty = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SteamDescription = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ModDescriptionEdit = new System.Windows.Forms.TextBox();
            this.processRunner1 = new ModdingTools.GUI.ProcessRunner();
            this.chapterInfoInput = new ModdingTools.GUI.MTextBox();
            this.mButton7 = new ModdingTools.GUI.MButton();
            this.label4 = new System.Windows.Forms.Label();
            this.arList1 = new ModdingTools.GUI.ARList();
            this.tabControl2 = new ModdingTools.GUI.BorderlessTabControl();
            this.tab3 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tab5 = new System.Windows.Forms.TabPage();
            this.tab6 = new System.Windows.Forms.TabPage();
            this.ModClass = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mButton10 = new ModdingTools.GUI.MButton();
            this.mButton6 = new ModdingTools.GUI.MButton();
            this.mButton5 = new ModdingTools.GUI.MButton();
            this.label17 = new System.Windows.Forms.Label();
            this.tab7 = new System.Windows.Forms.TabPage();
            this.tab8 = new System.Windows.Forms.TabPage();
            this.contentBrowser1 = new ModdingTools.GUI.ContentBrowser();
            this.tab2 = new System.Windows.Forms.TabPage();
            this.configList1 = new ModdingTools.GUI.ConfigList();
            this.tab1 = new System.Windows.Forms.TabPage();
            this.mButton8 = new ModdingTools.GUI.MButton();
            this.label10 = new System.Windows.Forms.Label();
            this.flagDesc = new System.Windows.Forms.Label();
            this.flagIcon = new System.Windows.Forms.Label();
            this.flagCook = new System.Windows.Forms.Label();
            this.flagTitle = new System.Windows.Forms.Label();
            this.flagTags = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.mButton9 = new ModdingTools.GUI.MButton();
            this.label7 = new System.Windows.Forms.Label();
            this.tabController1 = new ModdingTools.GUI.TabController();
            this.mButton1 = new ModdingTools.GUI.MButton();
            this.mButton3 = new ModdingTools.GUI.MButton();
            this.mButton4 = new ModdingTools.GUI.MButton();
            this.mButton2 = new ModdingTools.GUI.MButton();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tab3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tab5.SuspendLayout();
            this.tab6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tab7.SuspendLayout();
            this.tab8.SuspendLayout();
            this.tab2.SuspendLayout();
            this.tab1.SuspendLayout();
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
            this.panel7.Location = new System.Drawing.Point(18, 57);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(1);
            this.panel7.Size = new System.Drawing.Size(171, 171);
            this.panel7.TabIndex = 12;
            // 
            // iconView
            // 
            this.iconView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.iconView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.iconView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iconView.Location = new System.Drawing.Point(1, 1);
            this.iconView.Name = "iconView";
            this.iconView.Size = new System.Drawing.Size(169, 169);
            this.iconView.TabIndex = 10;
            this.iconView.Click += new System.EventHandler(this.iconView_Click);
            // 
            // modName
            // 
            this.modName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.modName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.modName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.modName.Location = new System.Drawing.Point(220, 71);
            this.modName.Name = "modName";
            this.modName.Size = new System.Drawing.Size(456, 32);
            this.modName.TabIndex = 13;
            this.modName.Text = "ModName";
            this.modName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.modName.Click += new System.EventHandler(this.modName_Click);
            // 
            // modFolderName
            // 
            this.modFolderName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.modFolderName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.modFolderName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.modFolderName.Location = new System.Drawing.Point(220, 134);
            this.modFolderName.Name = "modFolderName";
            this.modFolderName.Size = new System.Drawing.Size(456, 32);
            this.modFolderName.TabIndex = 14;
            this.modFolderName.Text = "ModFolderName";
            this.modFolderName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.modFolderName.Click += new System.EventHandler(this.modFolderName_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.levelType);
            this.panel5.Controls.Add(this.tagsList);
            this.panel5.Controls.Add(this.cbCoOp);
            this.panel5.Controls.Add(this.cbOnlineParty);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Location = new System.Drawing.Point(-1, 247);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(700, 219);
            this.panel5.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(306, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "LEVEL TYPE";
            // 
            // levelType
            // 
            this.levelType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.levelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.levelType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.levelType.FormattingEnabled = true;
            this.levelType.Location = new System.Drawing.Point(309, 186);
            this.levelType.Name = "levelType";
            this.levelType.Size = new System.Drawing.Size(379, 23);
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
            this.tagsList.Location = new System.Drawing.Point(6, 34);
            this.tagsList.Name = "tagsList";
            this.tagsList.Size = new System.Drawing.Size(294, 176);
            this.tagsList.TabIndex = 12;
            this.tagsList.TileSize = new System.Drawing.Size(280, 36);
            this.tagsList.UseCompatibleStateImageBehavior = false;
            this.tagsList.View = System.Windows.Forms.View.Tile;
            // 
            // cbCoOp
            // 
            this.cbCoOp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCoOp.AutoSize = true;
            this.cbCoOp.Location = new System.Drawing.Point(309, 64);
            this.cbCoOp.Name = "cbCoOp";
            this.cbCoOp.Size = new System.Drawing.Size(87, 19);
            this.cbCoOp.TabIndex = 11;
            this.cbCoOp.Text = "Co-Op only";
            this.cbCoOp.UseVisualStyleBackColor = true;
            this.cbCoOp.CheckedChanged += new System.EventHandler(this.cbCoOp_CheckedChanged);
            // 
            // cbOnlineParty
            // 
            this.cbOnlineParty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbOnlineParty.AutoSize = true;
            this.cbOnlineParty.Location = new System.Drawing.Point(309, 39);
            this.cbOnlineParty.Name = "cbOnlineParty";
            this.cbOnlineParty.Size = new System.Drawing.Size(91, 19);
            this.cbOnlineParty.TabIndex = 10;
            this.cbOnlineParty.Text = "Online Party";
            this.cbOnlineParty.UseVisualStyleBackColor = true;
            this.cbOnlineParty.CheckedChanged += new System.EventHandler(this.cbOnlineParty_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(0)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(0, -1);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(5);
            this.label3.Size = new System.Drawing.Size(699, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "TAGS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.checkBox1);
            this.panel3.Controls.Add(this.SteamDescription);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.ModDescriptionEdit);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(700, 467);
            this.panel3.TabIndex = 13;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(0)))));
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.checkBox1.ForeColor = System.Drawing.Color.Black;
            this.checkBox1.Location = new System.Drawing.Point(343, 224);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(351, 17);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "USE A SEPARATE DESCRIPTION FOR THE STEAM WORKSHOP";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // SteamDescription
            // 
            this.SteamDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SteamDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.SteamDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SteamDescription.ForeColor = System.Drawing.Color.White;
            this.SteamDescription.Location = new System.Drawing.Point(2, 247);
            this.SteamDescription.Margin = new System.Windows.Forms.Padding(2);
            this.SteamDescription.Multiline = true;
            this.SteamDescription.Name = "SteamDescription";
            this.SteamDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SteamDescription.Size = new System.Drawing.Size(694, 216);
            this.SteamDescription.TabIndex = 18;
            this.SteamDescription.TextChanged += new System.EventHandler(this.SteamDescription_TextChanged);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(0)))));
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(0, 219);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Padding = new System.Windows.Forms.Padding(5);
            this.label15.Size = new System.Drawing.Size(699, 26);
            this.label15.TabIndex = 17;
            this.label15.Text = "MOD DESCRIPTION (STEAM WORKSHOP)";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(0)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5);
            this.label2.Size = new System.Drawing.Size(699, 26);
            this.label2.TabIndex = 16;
            this.label2.Text = "MOD DESCRIPTION (IN-GAME)";
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
            this.ModDescriptionEdit.Location = new System.Drawing.Point(2, 28);
            this.ModDescriptionEdit.Margin = new System.Windows.Forms.Padding(2);
            this.ModDescriptionEdit.Multiline = true;
            this.ModDescriptionEdit.Name = "ModDescriptionEdit";
            this.ModDescriptionEdit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ModDescriptionEdit.Size = new System.Drawing.Size(694, 189);
            this.ModDescriptionEdit.TabIndex = 8;
            this.ModDescriptionEdit.TextChanged += new System.EventHandler(this.ModDescriptionEdit_TextChanged);
            // 
            // processRunner1
            // 
            this.processRunner1.BackColor = System.Drawing.Color.Black;
            this.processRunner1.Font = new System.Drawing.Font("Segoe UI Semilight", 9F);
            this.processRunner1.Location = new System.Drawing.Point(5, 97);
            this.processRunner1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.processRunner1.Name = "processRunner1";
            this.processRunner1.Size = new System.Drawing.Size(698, 342);
            this.processRunner1.TabIndex = 15;
            // 
            // chapterInfoInput
            // 
            this.chapterInfoInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.chapterInfoInput.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.chapterInfoInput.ForeColor = System.Drawing.Color.White;
            this.chapterInfoInput.Location = new System.Drawing.Point(91, 14);
            this.chapterInfoInput.Name = "chapterInfoInput";
            this.chapterInfoInput.Size = new System.Drawing.Size(518, 23);
            this.chapterInfoInput.TabIndex = 16;
            this.chapterInfoInput.TextChanged += new System.EventHandler(this.chapterInfoInput_TextChanged);
            // 
            // mButton7
            // 
            this.mButton7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton7.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(64)))));
            this.mButton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mButton7.ForeColor = System.Drawing.Color.White;
            this.mButton7.Location = new System.Drawing.Point(614, 13);
            this.mButton7.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.mButton7.Name = "mButton7";
            this.mButton7.Size = new System.Drawing.Size(77, 24);
            this.mButton7.TabIndex = 15;
            this.mButton7.Text = "DETECT";
            this.mButton7.UseVisualStyleBackColor = false;
            this.mButton7.Click += new System.EventHandler(this.mButton7_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 17);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "CHAPTER INFO";
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
            this.arList1.Size = new System.Drawing.Size(708, 473);
            this.arList1.TabIndex = 0;
            // 
            // tabControl2
            // 
            this.tabControl2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabControl2.Controls.Add(this.tab3);
            this.tabControl2.Controls.Add(this.tab5);
            this.tabControl2.Controls.Add(this.tab6);
            this.tabControl2.Controls.Add(this.tab7);
            this.tabControl2.Controls.Add(this.tab8);
            this.tabControl2.Controls.Add(this.tab2);
            this.tabControl2.Controls.Add(this.tab1);
            this.tabControl2.ImageList = this.imageList1;
            this.tabControl2.Location = new System.Drawing.Point(109, 93);
            this.tabControl2.Multiline = true;
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(708, 473);
            this.tabControl2.TabIndex = 16;
            // 
            // tab3
            // 
            this.tab3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.tab3.Controls.Add(this.panel4);
            this.tab3.ImageIndex = 4;
            this.tab3.Location = new System.Drawing.Point(0, 0);
            this.tab3.Name = "tab3";
            this.tab3.Size = new System.Drawing.Size(708, 473);
            this.tab3.TabIndex = 0;
            this.tab3.Text = "MOD INFO";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.lblAuthor);
            this.panel4.Controls.Add(this.modFolderName);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.modName);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(700, 467);
            this.panel4.TabIndex = 24;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(196)))), ((int)(((byte)(0)))));
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(0, 0);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(5);
            this.label14.Size = new System.Drawing.Size(699, 25);
            this.label14.TabIndex = 15;
            this.label14.Text = "GENERAL";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(423, 178);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 15);
            this.label13.TabIndex = 23;
            this.label13.Text = "AUTHOR:";
            // 
            // lblAuthor
            // 
            this.lblAuthor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lblAuthor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblAuthor.Location = new System.Drawing.Point(425, 196);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(251, 32);
            this.lblAuthor.TabIndex = 22;
            this.lblAuthor.Text = "ModAuthor";
            this.lblAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAuthor.Click += new System.EventHandler(this.lblAuthor_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 15);
            this.label12.TabIndex = 21;
            this.label12.Text = "ICON:";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label5.Location = new System.Drawing.Point(220, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 32);
            this.label5.TabIndex = 17;
            this.label5.Text = "ModVersion";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(218, 178);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 15);
            this.label11.TabIndex = 20;
            this.label11.Text = "VERSION:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(217, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 15);
            this.label9.TabIndex = 19;
            this.label9.Text = "FOLDER NAME:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(217, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 15);
            this.label8.TabIndex = 18;
            this.label8.Text = "MOD NAME:";
            // 
            // tab5
            // 
            this.tab5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tab5.Controls.Add(this.panel3);
            this.tab5.ImageIndex = 3;
            this.tab5.Location = new System.Drawing.Point(0, 0);
            this.tab5.Name = "tab5";
            this.tab5.Size = new System.Drawing.Size(708, 473);
            this.tab5.TabIndex = 1;
            this.tab5.Text = "DESCRIPTION";
            // 
            // tab6
            // 
            this.tab6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tab6.Controls.Add(this.ModClass);
            this.tab6.Controls.Add(this.panel1);
            this.tab6.Controls.Add(this.label17);
            this.tab6.Controls.Add(this.processRunner1);
            this.tab6.ImageIndex = 0;
            this.tab6.Location = new System.Drawing.Point(0, 0);
            this.tab6.Name = "tab6";
            this.tab6.Size = new System.Drawing.Size(708, 473);
            this.tab6.TabIndex = 2;
            this.tab6.Text = "BUILD";
            // 
            // ModClass
            // 
            this.ModClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ModClass.Cursor = System.Windows.Forms.Cursors.Default;
            this.ModClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ModClass.Location = new System.Drawing.Point(87, 445);
            this.ModClass.Name = "ModClass";
            this.ModClass.Size = new System.Drawing.Size(616, 21);
            this.ModClass.TabIndex = 19;
            this.ModClass.Text = "Class";
            this.ModClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ModClass.Click += new System.EventHandler(this.label16_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.mButton10);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.mButton6);
            this.panel1.Controls.Add(this.mButton7);
            this.panel1.Controls.Add(this.chapterInfoInput);
            this.panel1.Controls.Add(this.mButton5);
            this.panel1.Location = new System.Drawing.Point(5, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(698, 88);
            this.panel1.TabIndex = 17;
            // 
            // mButton10
            // 
            this.mButton10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton10.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(64)))));
            this.mButton10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mButton10.ForeColor = System.Drawing.Color.White;
            this.mButton10.Image = global::ModdingTools.Properties.Resources.compncook;
            this.mButton10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mButton10.Location = new System.Drawing.Point(504, 45);
            this.mButton10.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.mButton10.Name = "mButton10";
            this.mButton10.Size = new System.Drawing.Size(191, 39);
            this.mButton10.TabIndex = 17;
            this.mButton10.Text = "COMPILE AND COOK";
            this.mButton10.UseVisualStyleBackColor = false;
            this.mButton10.Click += new System.EventHandler(this.mButton10_Click);
            // 
            // mButton6
            // 
            this.mButton6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(64)))));
            this.mButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mButton6.ForeColor = System.Drawing.Color.White;
            this.mButton6.Image = global::ModdingTools.Properties.Resources.cook;
            this.mButton6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mButton6.Location = new System.Drawing.Point(325, 45);
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
            this.mButton5.Image = global::ModdingTools.Properties.Resources.compile;
            this.mButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mButton5.Location = new System.Drawing.Point(146, 45);
            this.mButton5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.mButton5.Name = "mButton5";
            this.mButton5.Size = new System.Drawing.Size(177, 39);
            this.mButton5.TabIndex = 12;
            this.mButton5.Text = "COMPILE SCRIPTS";
            this.mButton5.UseVisualStyleBackColor = false;
            this.mButton5.Click += new System.EventHandler(this.mButton5_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 448);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(73, 15);
            this.label17.TabIndex = 20;
            this.label17.Text = "MOD CLASS:";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // tab7
            // 
            this.tab7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tab7.Controls.Add(this.arList1);
            this.tab7.ImageIndex = 5;
            this.tab7.Location = new System.Drawing.Point(0, 0);
            this.tab7.Name = "tab7";
            this.tab7.Size = new System.Drawing.Size(708, 473);
            this.tab7.TabIndex = 3;
            this.tab7.Text = "ASSET REPLACE";
            // 
            // tab8
            // 
            this.tab8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tab8.Controls.Add(this.contentBrowser1);
            this.tab8.ImageIndex = 2;
            this.tab8.Location = new System.Drawing.Point(0, 0);
            this.tab8.Name = "tab8";
            this.tab8.Size = new System.Drawing.Size(708, 473);
            this.tab8.TabIndex = 4;
            this.tab8.Text = "CONTENT";
            // 
            // contentBrowser1
            // 
            this.contentBrowser1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.contentBrowser1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contentBrowser1.Font = new System.Drawing.Font("Segoe UI Semilight", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.contentBrowser1.ForeColor = System.Drawing.Color.White;
            this.contentBrowser1.Location = new System.Drawing.Point(3, 3);
            this.contentBrowser1.Name = "contentBrowser1";
            this.contentBrowser1.Size = new System.Drawing.Size(700, 467);
            this.contentBrowser1.TabIndex = 0;
            // 
            // tab2
            // 
            this.tab2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tab2.Controls.Add(this.configList1);
            this.tab2.ImageIndex = 1;
            this.tab2.Location = new System.Drawing.Point(0, 0);
            this.tab2.Name = "tab2";
            this.tab2.Size = new System.Drawing.Size(708, 473);
            this.tab2.TabIndex = 5;
            this.tab2.Text = "MOD CONFIG";
            // 
            // configList1
            // 
            this.configList1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.configList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.configList1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.configList1.Location = new System.Drawing.Point(0, 0);
            this.configList1.Margin = new System.Windows.Forms.Padding(0);
            this.configList1.Name = "configList1";
            this.configList1.Size = new System.Drawing.Size(708, 473);
            this.configList1.TabIndex = 0;
            // 
            // tab1
            // 
            this.tab1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.tab1.Controls.Add(this.mButton8);
            this.tab1.Controls.Add(this.label10);
            this.tab1.Controls.Add(this.flagDesc);
            this.tab1.Controls.Add(this.flagIcon);
            this.tab1.Controls.Add(this.flagCook);
            this.tab1.Controls.Add(this.flagTitle);
            this.tab1.Controls.Add(this.flagTags);
            this.tab1.ImageIndex = 6;
            this.tab1.Location = new System.Drawing.Point(0, 0);
            this.tab1.Name = "tab1";
            this.tab1.Size = new System.Drawing.Size(708, 473);
            this.tab1.TabIndex = 6;
            this.tab1.Text = "UPLOADING";
            // 
            // mButton8
            // 
            this.mButton8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton8.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.mButton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton8.ForeColor = System.Drawing.Color.White;
            this.mButton8.Image = global::ModdingTools.Properties.Resources.steam1;
            this.mButton8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mButton8.Location = new System.Drawing.Point(160, 354);
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
            this.label10.Location = new System.Drawing.Point(160, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(368, 50);
            this.label10.TabIndex = 18;
            this.label10.Text = "ARE YOU READY TO UPLOAD?";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flagDesc
            // 
            this.flagDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.flagDesc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flagDesc.Image = global::ModdingTools.Properties.Resources.ok;
            this.flagDesc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.flagDesc.Location = new System.Drawing.Point(160, 211);
            this.flagDesc.Name = "flagDesc";
            this.flagDesc.Size = new System.Drawing.Size(368, 38);
            this.flagDesc.TabIndex = 15;
            this.flagDesc.Text = "Mod Description";
            this.flagDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.flagDesc.Click += new System.EventHandler(this.flagDesc_Click);
            // 
            // flagIcon
            // 
            this.flagIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.flagIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flagIcon.Image = global::ModdingTools.Properties.Resources.ok;
            this.flagIcon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.flagIcon.Location = new System.Drawing.Point(160, 251);
            this.flagIcon.Name = "flagIcon";
            this.flagIcon.Size = new System.Drawing.Size(368, 38);
            this.flagIcon.TabIndex = 16;
            this.flagIcon.Text = "Square Mod Icon";
            this.flagIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.flagIcon.Click += new System.EventHandler(this.flagIcon_Click);
            // 
            // flagCook
            // 
            this.flagCook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.flagCook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flagCook.Image = global::ModdingTools.Properties.Resources.delete;
            this.flagCook.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.flagCook.Location = new System.Drawing.Point(160, 131);
            this.flagCook.Name = "flagCook";
            this.flagCook.Size = new System.Drawing.Size(368, 38);
            this.flagCook.TabIndex = 13;
            this.flagCook.Text = "Cooked Mod";
            this.flagCook.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.flagCook.Click += new System.EventHandler(this.flagCook_Click);
            // 
            // flagTitle
            // 
            this.flagTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.flagTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flagTitle.Image = global::ModdingTools.Properties.Resources.ok;
            this.flagTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.flagTitle.Location = new System.Drawing.Point(160, 171);
            this.flagTitle.Name = "flagTitle";
            this.flagTitle.Size = new System.Drawing.Size(368, 38);
            this.flagTitle.TabIndex = 14;
            this.flagTitle.Text = "Mod Title";
            this.flagTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.flagTitle.Click += new System.EventHandler(this.flagTitle_Click);
            // 
            // flagTags
            // 
            this.flagTags.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.flagTags.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flagTags.Image = global::ModdingTools.Properties.Resources.ok;
            this.flagTags.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.flagTags.Location = new System.Drawing.Point(160, 291);
            this.flagTags.Name = "flagTags";
            this.flagTags.Size = new System.Drawing.Size(368, 38);
            this.flagTags.TabIndex = 17;
            this.flagTags.Text = "Mod Tags";
            this.flagTags.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.flagTags.Click += new System.EventHandler(this.flagTags_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "nav_build.png");
            this.imageList1.Images.SetKeyName(1, "nav_config.png");
            this.imageList1.Images.SetKeyName(2, "nav_content.png");
            this.imageList1.Images.SetKeyName(3, "nav_description.png");
            this.imageList1.Images.SetKeyName(4, "nav_info.png");
            this.imageList1.Images.SetKeyName(5, "nav_replace.png");
            this.imageList1.Images.SetKeyName(6, "nav_upload.png");
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(51, 7);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(203, 23);
            this.comboBox1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(0)))), ((int)(((byte)(70)))));
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.mButton9);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Location = new System.Drawing.Point(5, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(289, 36);
            this.panel2.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 15);
            this.label6.TabIndex = 21;
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
            this.mButton9.Location = new System.Drawing.Point(255, 6);
            this.mButton9.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.mButton9.Name = "mButton9";
            this.mButton9.Size = new System.Drawing.Size(29, 25);
            this.mButton9.TabIndex = 20;
            this.mButton9.UseVisualStyleBackColor = false;
            this.mButton9.Click += new System.EventHandler(this.mButton9_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 15);
            this.label7.TabIndex = 22;
            this.label7.Text = "*";
            // 
            // tabController1
            // 
            this.tabController1.DisabledColor = System.Drawing.Color.DarkGray;
            this.tabController1.InactiveColor = System.Drawing.Color.Transparent;
            this.tabController1.Location = new System.Drawing.Point(3, 93);
            this.tabController1.Name = "tabController1";
            this.tabController1.ParentTabControl = this.tabControl2;
            this.tabController1.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.tabController1.Size = new System.Drawing.Size(105, 473);
            this.tabController1.TabIndex = 23;
            this.tabController1.Text = "tabController1";
            this.tabController1.PageChange += new System.EventHandler<ModdingTools.GUI.TabController.TabControllerPageChangeEventArgs>(this.tabController1_PageChange);
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
            this.mButton1.Size = new System.Drawing.Size(202, 46);
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
            this.mButton3.Size = new System.Drawing.Size(131, 46);
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
            this.mButton4.Size = new System.Drawing.Size(59, 46);
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
            // ModProperties
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(0)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(824, 573);
            this.Controls.Add(this.tabController1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.mButton1);
            this.Controls.Add(this.mButton3);
            this.Controls.Add(this.mButton4);
            this.Controls.Add(this.mButton2);
            this.Controls.Add(this.btnEditor);
            this.Font = new System.Drawing.Font("Segoe UI Semilight", 9F);
            this.IsResizable = false;
            this.MinimumSize = new System.Drawing.Size(824, 532);
            this.Name = "ModProperties";
            this.Text = "-";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModProperties_FormClosing);
            this.Load += new System.EventHandler(this.ModProperties_Load);
            this.Controls.SetChildIndex(this.btnEditor, 0);
            this.Controls.SetChildIndex(this.mButton2, 0);
            this.Controls.SetChildIndex(this.mButton4, 0);
            this.Controls.SetChildIndex(this.mButton3, 0);
            this.Controls.SetChildIndex(this.mButton1, 0);
            this.Controls.SetChildIndex(this.tabControl2, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.tabController1, 0);
            this.panel7.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tab3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tab5.ResumeLayout(false);
            this.tab6.ResumeLayout(false);
            this.tab6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tab7.ResumeLayout(false);
            this.tab8.ResumeLayout(false);
            this.tab2.ResumeLayout(false);
            this.tab1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    #endregion
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
        private BorderlessTabControl tabControl2;
        private System.Windows.Forms.TabPage tab5;
        private System.Windows.Forms.TabPage tab6;
        private System.Windows.Forms.TabPage tab7;
        private System.Windows.Forms.TabPage tab8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tab1;
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
        private GUI.MButton mButton9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabPage tab2;
        private GUI.ConfigList configList1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tab3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel4;
        private TabController tabController1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox SteamDescription;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label ModClass;
        private System.Windows.Forms.Label label17;
        private MButton mButton10;
    }
}