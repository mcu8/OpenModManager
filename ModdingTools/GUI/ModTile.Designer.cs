namespace ModdingTools.GUI
{
    partial class ModTile
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cookModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compileScriptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cookModToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.compileCookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.titleScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spaceshipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mafiaTownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hatInTimeEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInVSC = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptWatcherToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptWatcherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptWatcherToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.compileLaunchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compileAndCookAndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchGameSteamModsLastMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchGameNoWorkshopModsSpecifyMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchGameWorkshopModsSpecifyMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 104);
            this.panel1.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(0, -1);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::ModdingTools.Properties.Resources.uploaded;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.Location = new System.Drawing.Point(110, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(34, 30);
            this.panel2.TabIndex = 1;
            this.panel2.Visible = false;
            this.panel2.Click += new System.EventHandler(this.panel2_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "<PLACEHOLDER>";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.Black;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cookModToolStripMenuItem,
            this.testModToolStripMenuItem,
            this.toolStripSeparator1,
            this.openDirectoryToolStripMenuItem,
            this.openInVSC,
            this.moveToToolStripMenuItem,
            this.scriptingToolStripMenuItem,
            this.deleteModToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(156, 186);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // cookModToolStripMenuItem
            // 
            this.cookModToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compileLaunchToolStripMenuItem,
            this.compileScriptsToolStripMenuItem,
            this.cookModToolStripMenuItem1,
            this.compileCookToolStripMenuItem,
            this.compileAndCookAndToolStripMenuItem});
            this.cookModToolStripMenuItem.Name = "cookModToolStripMenuItem";
            this.cookModToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.cookModToolStripMenuItem.Text = "Build";
            // 
            // compileScriptsToolStripMenuItem
            // 
            this.compileScriptsToolStripMenuItem.Name = "compileScriptsToolStripMenuItem";
            this.compileScriptsToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.compileScriptsToolStripMenuItem.Text = "Compile scripts";
            this.compileScriptsToolStripMenuItem.Click += new System.EventHandler(this.compileScriptsToolStripMenuItem_Click);
            // 
            // cookModToolStripMenuItem1
            // 
            this.cookModToolStripMenuItem1.Name = "cookModToolStripMenuItem1";
            this.cookModToolStripMenuItem1.Size = new System.Drawing.Size(252, 22);
            this.cookModToolStripMenuItem1.Text = "Cook mod";
            this.cookModToolStripMenuItem1.Click += new System.EventHandler(this.cookModToolStripMenuItem1_Click);
            // 
            // compileCookToolStripMenuItem
            // 
            this.compileCookToolStripMenuItem.Name = "compileCookToolStripMenuItem";
            this.compileCookToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.compileCookToolStripMenuItem.Text = "Compile and cook";
            this.compileCookToolStripMenuItem.Click += new System.EventHandler(this.compileCookToolStripMenuItem_Click);
            // 
            // testModToolStripMenuItem
            // 
            this.testModToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.titleScreenToolStripMenuItem,
            this.spaceshipToolStripMenuItem,
            this.mafiaTownToolStripMenuItem,
            this.hatInTimeEntryToolStripMenuItem});
            this.testModToolStripMenuItem.Name = "testModToolStripMenuItem";
            this.testModToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.testModToolStripMenuItem.Text = "Test mod";
            // 
            // titleScreenToolStripMenuItem
            // 
            this.titleScreenToolStripMenuItem.Name = "titleScreenToolStripMenuItem";
            this.titleScreenToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.titleScreenToolStripMenuItem.Text = "Title screen";
            this.titleScreenToolStripMenuItem.Click += new System.EventHandler(this.titleScreenToolStripMenuItem_Click);
            // 
            // spaceshipToolStripMenuItem
            // 
            this.spaceshipToolStripMenuItem.Name = "spaceshipToolStripMenuItem";
            this.spaceshipToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.spaceshipToolStripMenuItem.Text = "Spaceship";
            this.spaceshipToolStripMenuItem.Click += new System.EventHandler(this.spaceshipToolStripMenuItem_Click);
            // 
            // mafiaTownToolStripMenuItem
            // 
            this.mafiaTownToolStripMenuItem.Name = "mafiaTownToolStripMenuItem";
            this.mafiaTownToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.mafiaTownToolStripMenuItem.Text = "Mafia town";
            this.mafiaTownToolStripMenuItem.Click += new System.EventHandler(this.mafiaTownToolStripMenuItem_Click);
            // 
            // hatInTimeEntryToolStripMenuItem
            // 
            this.hatInTimeEntryToolStripMenuItem.Name = "hatInTimeEntryToolStripMenuItem";
            this.hatInTimeEntryToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.hatInTimeEntryToolStripMenuItem.Text = "HatInTimeEntry";
            this.hatInTimeEntryToolStripMenuItem.Click += new System.EventHandler(this.hatInTimeEntryToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // openDirectoryToolStripMenuItem
            // 
            this.openDirectoryToolStripMenuItem.Name = "openDirectoryToolStripMenuItem";
            this.openDirectoryToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.openDirectoryToolStripMenuItem.Text = "Open directory";
            this.openDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openDirectoryToolStripMenuItem_Click);
            // 
            // openInVSC
            // 
            this.openInVSC.Name = "openInVSC";
            this.openInVSC.Size = new System.Drawing.Size(155, 22);
            this.openInVSC.Text = "Open in VS Code";
            this.openInVSC.Click += new System.EventHandler(this.openInVSC_Click);
            // 
            // moveToToolStripMenuItem
            // 
            this.moveToToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.moveToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem});
            this.moveToToolStripMenuItem.Name = "moveToToolStripMenuItem";
            this.moveToToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.moveToToolStripMenuItem.Text = "Move to";
            this.moveToToolStripMenuItem.DropDownOpening += new System.EventHandler(this.moveoToolStripMenuItem_DropDownOpening);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.testToolStripMenuItem.Text = "test";
            // 
            // scriptingToolStripMenuItem
            // 
            this.scriptingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scriptWatcherToolStripMenuItem2});
            this.scriptingToolStripMenuItem.Name = "scriptingToolStripMenuItem";
            this.scriptingToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.scriptingToolStripMenuItem.Text = "Scripting";
            // 
            // scriptWatcherToolStripMenuItem2
            // 
            this.scriptWatcherToolStripMenuItem2.Name = "scriptWatcherToolStripMenuItem2";
            this.scriptWatcherToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.scriptWatcherToolStripMenuItem2.Text = "Script Watcher";
            this.scriptWatcherToolStripMenuItem2.Click += new System.EventHandler(this.scriptWatcherToolStripMenuItem2_Click);
            // 
            // deleteModToolStripMenuItem
            // 
            this.deleteModToolStripMenuItem.Name = "deleteModToolStripMenuItem";
            this.deleteModToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.deleteModToolStripMenuItem.Text = "Delete mod";
            this.deleteModToolStripMenuItem.Click += new System.EventHandler(this.deleteModToolStripMenuItem_Click);
            // 
            // scriptWatcherToolStripMenuItem
            // 
            this.scriptWatcherToolStripMenuItem.Name = "scriptWatcherToolStripMenuItem";
            this.scriptWatcherToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // scriptWatcherToolStripMenuItem1
            // 
            this.scriptWatcherToolStripMenuItem1.Name = "scriptWatcherToolStripMenuItem1";
            this.scriptWatcherToolStripMenuItem1.Size = new System.Drawing.Size(32, 19);
            // 
            // compileLaunchToolStripMenuItem
            // 
            this.compileLaunchToolStripMenuItem.Name = "compileLaunchToolStripMenuItem";
            this.compileLaunchToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.compileLaunchToolStripMenuItem.Text = "Compile scripts and launch editor";
            this.compileLaunchToolStripMenuItem.Click += new System.EventHandler(this.compileLaunchToolStripMenuItem_Click);
            // 
            // compileAndCookAndToolStripMenuItem
            // 
            this.compileAndCookAndToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.launchGameSteamModsLastMapToolStripMenuItem,
            this.launchGameToolStripMenuItem,
            this.launchGameNoWorkshopModsSpecifyMapToolStripMenuItem,
            this.launchGameWorkshopModsSpecifyMapToolStripMenuItem});
            this.compileAndCookAndToolStripMenuItem.Name = "compileAndCookAndToolStripMenuItem";
            this.compileAndCookAndToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.compileAndCookAndToolStripMenuItem.Text = "Compile and cook and...";
            // 
            // launchGameSteamModsLastMapToolStripMenuItem
            // 
            this.launchGameSteamModsLastMapToolStripMenuItem.Name = "launchGameSteamModsLastMapToolStripMenuItem";
            this.launchGameSteamModsLastMapToolStripMenuItem.Size = new System.Drawing.Size(350, 22);
            this.launchGameSteamModsLastMapToolStripMenuItem.Text = "Launch game (No workshop mods, last played map)";
            this.launchGameSteamModsLastMapToolStripMenuItem.Click += new System.EventHandler(this.launchGameSteamModsLastMapToolStripMenuItem_Click);
            // 
            // launchGameToolStripMenuItem
            // 
            this.launchGameToolStripMenuItem.Name = "launchGameToolStripMenuItem";
            this.launchGameToolStripMenuItem.Size = new System.Drawing.Size(350, 22);
            this.launchGameToolStripMenuItem.Text = "Launch game (Workshop mods, last played map)";
            this.launchGameToolStripMenuItem.Click += new System.EventHandler(this.launchGameToolStripMenuItem_Click);
            // 
            // launchGameNoWorkshopModsSpecifyMapToolStripMenuItem
            // 
            this.launchGameNoWorkshopModsSpecifyMapToolStripMenuItem.Name = "launchGameNoWorkshopModsSpecifyMapToolStripMenuItem";
            this.launchGameNoWorkshopModsSpecifyMapToolStripMenuItem.Size = new System.Drawing.Size(350, 22);
            this.launchGameNoWorkshopModsSpecifyMapToolStripMenuItem.Text = "Launch game (No workshop mods, specify map...)";
            this.launchGameNoWorkshopModsSpecifyMapToolStripMenuItem.Click += new System.EventHandler(this.launchGameNoWorkshopModsSpecifyMapToolStripMenuItem_Click);
            // 
            // launchGameWorkshopModsSpecifyMapToolStripMenuItem
            // 
            this.launchGameWorkshopModsSpecifyMapToolStripMenuItem.Name = "launchGameWorkshopModsSpecifyMapToolStripMenuItem";
            this.launchGameWorkshopModsSpecifyMapToolStripMenuItem.Size = new System.Drawing.Size(350, 22);
            this.launchGameWorkshopModsSpecifyMapToolStripMenuItem.Text = "Launch game (Workshop mods, specify map...)";
            this.launchGameWorkshopModsSpecifyMapToolStripMenuItem.Click += new System.EventHandler(this.launchGameWorkshopModsSpecifyMapToolStripMenuItem_Click);
            // 
            // ModTile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "ModTile";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cookModToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compileScriptsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cookModToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem testModToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem titleScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spaceshipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mafiaTownToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem openDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptWatcherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptWatcherToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem scriptingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptWatcherToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem deleteModToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hatInTimeEntryToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem compileCookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openInVSC;
        private System.Windows.Forms.ToolStripMenuItem compileLaunchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compileAndCookAndToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem launchGameSteamModsLastMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem launchGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem launchGameNoWorkshopModsSpecifyMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem launchGameWorkshopModsSpecifyMapToolStripMenuItem;
    }
}
