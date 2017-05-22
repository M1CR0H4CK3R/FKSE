namespace FKSE
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.goldTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.generalTab = new System.Windows.Forms.TabPage();
            this.itemsTab = new System.Windows.Forms.TabPage();
            this.itemsPanel = new System.Windows.Forms.Panel();
            this.itemsBack = new System.Windows.Forms.Button();
            this.itemsNext = new System.Windows.Forms.Button();
            this.itemPageLabel = new System.Windows.Forms.Label();
            this.monstersTab = new System.Windows.Forms.TabPage();
            this.monsterEditorPanel = new System.Windows.Forms.Panel();
            this.monsterItemQuantity3 = new System.Windows.Forms.TextBox();
            this.monsterItem3 = new System.Windows.Forms.ComboBox();
            this.monsterItemQuantity2 = new System.Windows.Forms.TextBox();
            this.monsterItem2 = new System.Windows.Forms.ComboBox();
            this.monsterItemQuantity1 = new System.Windows.Forms.TextBox();
            this.monsterItem1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.monsterAssignable = new System.Windows.Forms.CheckBox();
            this.monsterOwned = new System.Windows.Forms.CheckBox();
            this.monsterEXP = new System.Windows.Forms.TextBox();
            this.monsterDefence = new System.Windows.Forms.TextBox();
            this.monsterAttack = new System.Windows.Forms.TextBox();
            this.monsterHP = new System.Windows.Forms.TextBox();
            this.monsterActionPoints = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.selectedMonster = new System.Windows.Forms.Label();
            this.monsterBack = new System.Windows.Forms.Button();
            this.monsterNext = new System.Windows.Forms.Button();
            this.monsterPageLabel = new System.Windows.Forms.Label();
            this.monsterTip = new System.Windows.Forms.ToolTip(this.components);
            this.monsterRed = new System.Windows.Forms.TrackBar();
            this.monsterGreen = new System.Windows.Forms.TrackBar();
            this.monsterBlue = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.monsterRGBPreview = new System.Windows.Forms.Panel();
            this.redBox = new System.Windows.Forms.TextBox();
            this.greenBox = new System.Windows.Forms.TextBox();
            this.blueBox = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.generalTab.SuspendLayout();
            this.itemsTab.SuspendLayout();
            this.itemsPanel.SuspendLayout();
            this.monstersTab.SuspendLayout();
            this.monsterEditorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monsterActionPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterBlue)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(539, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // goldTextBox
            // 
            this.goldTextBox.Location = new System.Drawing.Point(44, 9);
            this.goldTextBox.Name = "goldTextBox";
            this.goldTextBox.Size = new System.Drawing.Size(86, 20);
            this.goldTextBox.TabIndex = 1;
            this.goldTextBox.TextChanged += new System.EventHandler(this.goldTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Gold:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.generalTab);
            this.tabControl1.Controls.Add(this.itemsTab);
            this.tabControl1.Controls.Add(this.monstersTab);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(515, 457);
            this.tabControl1.TabIndex = 3;
            // 
            // generalTab
            // 
            this.generalTab.Controls.Add(this.goldTextBox);
            this.generalTab.Controls.Add(this.label1);
            this.generalTab.Location = new System.Drawing.Point(4, 22);
            this.generalTab.Name = "generalTab";
            this.generalTab.Padding = new System.Windows.Forms.Padding(3);
            this.generalTab.Size = new System.Drawing.Size(507, 431);
            this.generalTab.TabIndex = 0;
            this.generalTab.Text = "General";
            this.generalTab.UseVisualStyleBackColor = true;
            // 
            // itemsTab
            // 
            this.itemsTab.Controls.Add(this.itemsPanel);
            this.itemsTab.Location = new System.Drawing.Point(4, 22);
            this.itemsTab.Name = "itemsTab";
            this.itemsTab.Padding = new System.Windows.Forms.Padding(3);
            this.itemsTab.Size = new System.Drawing.Size(507, 431);
            this.itemsTab.TabIndex = 1;
            this.itemsTab.Text = "Items";
            this.itemsTab.UseVisualStyleBackColor = true;
            // 
            // itemsPanel
            // 
            this.itemsPanel.AutoScroll = true;
            this.itemsPanel.Controls.Add(this.itemsBack);
            this.itemsPanel.Controls.Add(this.itemsNext);
            this.itemsPanel.Controls.Add(this.itemPageLabel);
            this.itemsPanel.Location = new System.Drawing.Point(6, 6);
            this.itemsPanel.Name = "itemsPanel";
            this.itemsPanel.Size = new System.Drawing.Size(495, 419);
            this.itemsPanel.TabIndex = 0;
            // 
            // itemsBack
            // 
            this.itemsBack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsBack.Location = new System.Drawing.Point(140, 393);
            this.itemsBack.Name = "itemsBack";
            this.itemsBack.Size = new System.Drawing.Size(75, 23);
            this.itemsBack.TabIndex = 2;
            this.itemsBack.Text = "Previous";
            this.itemsBack.UseVisualStyleBackColor = true;
            this.itemsBack.Click += new System.EventHandler(this.itemsBack_Click);
            // 
            // itemsNext
            // 
            this.itemsNext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsNext.Location = new System.Drawing.Point(279, 393);
            this.itemsNext.Name = "itemsNext";
            this.itemsNext.Size = new System.Drawing.Size(75, 23);
            this.itemsNext.TabIndex = 1;
            this.itemsNext.Text = "Next";
            this.itemsNext.UseVisualStyleBackColor = true;
            this.itemsNext.Click += new System.EventHandler(this.itemsNext_Click);
            // 
            // itemPageLabel
            // 
            this.itemPageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemPageLabel.AutoSize = true;
            this.itemPageLabel.Location = new System.Drawing.Point(221, 398);
            this.itemPageLabel.Name = "itemPageLabel";
            this.itemPageLabel.Size = new System.Drawing.Size(52, 13);
            this.itemPageLabel.TabIndex = 0;
            this.itemPageLabel.Text = "Page 1/8";
            // 
            // monstersTab
            // 
            this.monstersTab.Controls.Add(this.monsterEditorPanel);
            this.monstersTab.Controls.Add(this.monsterBack);
            this.monstersTab.Controls.Add(this.monsterNext);
            this.monstersTab.Controls.Add(this.monsterPageLabel);
            this.monstersTab.Location = new System.Drawing.Point(4, 22);
            this.monstersTab.Name = "monstersTab";
            this.monstersTab.Size = new System.Drawing.Size(507, 431);
            this.monstersTab.TabIndex = 2;
            this.monstersTab.Text = "Monsters";
            this.monstersTab.UseVisualStyleBackColor = true;
            // 
            // monsterEditorPanel
            // 
            this.monsterEditorPanel.Controls.Add(this.blueBox);
            this.monsterEditorPanel.Controls.Add(this.greenBox);
            this.monsterEditorPanel.Controls.Add(this.redBox);
            this.monsterEditorPanel.Controls.Add(this.monsterRGBPreview);
            this.monsterEditorPanel.Controls.Add(this.label11);
            this.monsterEditorPanel.Controls.Add(this.label10);
            this.monsterEditorPanel.Controls.Add(this.label9);
            this.monsterEditorPanel.Controls.Add(this.label8);
            this.monsterEditorPanel.Controls.Add(this.monsterBlue);
            this.monsterEditorPanel.Controls.Add(this.monsterGreen);
            this.monsterEditorPanel.Controls.Add(this.monsterRed);
            this.monsterEditorPanel.Controls.Add(this.monsterItemQuantity3);
            this.monsterEditorPanel.Controls.Add(this.monsterItem3);
            this.monsterEditorPanel.Controls.Add(this.monsterItemQuantity2);
            this.monsterEditorPanel.Controls.Add(this.monsterItem2);
            this.monsterEditorPanel.Controls.Add(this.monsterItemQuantity1);
            this.monsterEditorPanel.Controls.Add(this.monsterItem1);
            this.monsterEditorPanel.Controls.Add(this.label2);
            this.monsterEditorPanel.Controls.Add(this.monsterAssignable);
            this.monsterEditorPanel.Controls.Add(this.monsterOwned);
            this.monsterEditorPanel.Controls.Add(this.monsterEXP);
            this.monsterEditorPanel.Controls.Add(this.monsterDefence);
            this.monsterEditorPanel.Controls.Add(this.monsterAttack);
            this.monsterEditorPanel.Controls.Add(this.monsterHP);
            this.monsterEditorPanel.Controls.Add(this.monsterActionPoints);
            this.monsterEditorPanel.Controls.Add(this.label7);
            this.monsterEditorPanel.Controls.Add(this.label6);
            this.monsterEditorPanel.Controls.Add(this.label5);
            this.monsterEditorPanel.Controls.Add(this.label4);
            this.monsterEditorPanel.Controls.Add(this.label3);
            this.monsterEditorPanel.Controls.Add(this.selectedMonster);
            this.monsterEditorPanel.Location = new System.Drawing.Point(304, 4);
            this.monsterEditorPanel.Name = "monsterEditorPanel";
            this.monsterEditorPanel.Size = new System.Drawing.Size(200, 424);
            this.monsterEditorPanel.TabIndex = 6;
            // 
            // monsterItemQuantity3
            // 
            this.monsterItemQuantity3.Location = new System.Drawing.Point(155, 274);
            this.monsterItemQuantity3.Name = "monsterItemQuantity3";
            this.monsterItemQuantity3.Size = new System.Drawing.Size(30, 20);
            this.monsterItemQuantity3.TabIndex = 19;
            // 
            // monsterItem3
            // 
            this.monsterItem3.FormattingEnabled = true;
            this.monsterItem3.Location = new System.Drawing.Point(28, 274);
            this.monsterItem3.Name = "monsterItem3";
            this.monsterItem3.Size = new System.Drawing.Size(121, 21);
            this.monsterItem3.TabIndex = 18;
            // 
            // monsterItemQuantity2
            // 
            this.monsterItemQuantity2.Location = new System.Drawing.Point(155, 248);
            this.monsterItemQuantity2.Name = "monsterItemQuantity2";
            this.monsterItemQuantity2.Size = new System.Drawing.Size(30, 20);
            this.monsterItemQuantity2.TabIndex = 17;
            // 
            // monsterItem2
            // 
            this.monsterItem2.FormattingEnabled = true;
            this.monsterItem2.Location = new System.Drawing.Point(28, 248);
            this.monsterItem2.Name = "monsterItem2";
            this.monsterItem2.Size = new System.Drawing.Size(121, 21);
            this.monsterItem2.TabIndex = 16;
            // 
            // monsterItemQuantity1
            // 
            this.monsterItemQuantity1.Location = new System.Drawing.Point(155, 222);
            this.monsterItemQuantity1.Name = "monsterItemQuantity1";
            this.monsterItemQuantity1.Size = new System.Drawing.Size(30, 20);
            this.monsterItemQuantity1.TabIndex = 15;
            // 
            // monsterItem1
            // 
            this.monsterItem1.FormattingEnabled = true;
            this.monsterItem1.Location = new System.Drawing.Point(28, 222);
            this.monsterItem1.Name = "monsterItem1";
            this.monsterItem1.Size = new System.Drawing.Size(121, 21);
            this.monsterItem1.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Items";
            // 
            // monsterAssignable
            // 
            this.monsterAssignable.AutoSize = true;
            this.monsterAssignable.Location = new System.Drawing.Point(105, 182);
            this.monsterAssignable.Name = "monsterAssignable";
            this.monsterAssignable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.monsterAssignable.Size = new System.Drawing.Size(80, 17);
            this.monsterAssignable.TabIndex = 12;
            this.monsterAssignable.Text = ":Assignable";
            this.monsterAssignable.UseVisualStyleBackColor = true;
            this.monsterAssignable.CheckedChanged += new System.EventHandler(this.monsterAssignable_CheckedChanged);
            // 
            // monsterOwned
            // 
            this.monsterOwned.AutoSize = true;
            this.monsterOwned.Location = new System.Drawing.Point(6, 182);
            this.monsterOwned.Name = "monsterOwned";
            this.monsterOwned.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.monsterOwned.Size = new System.Drawing.Size(63, 17);
            this.monsterOwned.TabIndex = 11;
            this.monsterOwned.Text = ":Owned";
            this.monsterOwned.UseVisualStyleBackColor = true;
            this.monsterOwned.CheckedChanged += new System.EventHandler(this.monsterOwned_CheckedChanged);
            // 
            // monsterEXP
            // 
            this.monsterEXP.Location = new System.Drawing.Point(60, 149);
            this.monsterEXP.Name = "monsterEXP";
            this.monsterEXP.Size = new System.Drawing.Size(125, 20);
            this.monsterEXP.TabIndex = 10;
            this.monsterEXP.TextChanged += new System.EventHandler(this.monsterEXP_TextChanged);
            // 
            // monsterDefence
            // 
            this.monsterDefence.Location = new System.Drawing.Point(60, 119);
            this.monsterDefence.Name = "monsterDefence";
            this.monsterDefence.Size = new System.Drawing.Size(125, 20);
            this.monsterDefence.TabIndex = 9;
            this.monsterDefence.TextChanged += new System.EventHandler(this.monsterDefence_TextChanged);
            // 
            // monsterAttack
            // 
            this.monsterAttack.Location = new System.Drawing.Point(60, 89);
            this.monsterAttack.Name = "monsterAttack";
            this.monsterAttack.Size = new System.Drawing.Size(125, 20);
            this.monsterAttack.TabIndex = 8;
            this.monsterAttack.TextChanged += new System.EventHandler(this.monsterAttack_TextChanged);
            // 
            // monsterHP
            // 
            this.monsterHP.Location = new System.Drawing.Point(60, 59);
            this.monsterHP.Name = "monsterHP";
            this.monsterHP.Size = new System.Drawing.Size(125, 20);
            this.monsterHP.TabIndex = 7;
            this.monsterHP.TextChanged += new System.EventHandler(this.monsterHP_TextChanged);
            // 
            // monsterActionPoints
            // 
            this.monsterActionPoints.AutoSize = false;
            this.monsterActionPoints.BackColor = System.Drawing.SystemColors.Window;
            this.monsterActionPoints.Location = new System.Drawing.Point(81, 29);
            this.monsterActionPoints.Maximum = 12;
            this.monsterActionPoints.Minimum = 1;
            this.monsterActionPoints.Name = "monsterActionPoints";
            this.monsterActionPoints.Size = new System.Drawing.Size(104, 20);
            this.monsterActionPoints.TabIndex = 6;
            this.monsterActionPoints.Value = 1;
            this.monsterActionPoints.Scroll += new System.EventHandler(this.monsterActionPoints_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "EXP:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Defence:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Attack:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Max HP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Action Points:";
            // 
            // selectedMonster
            // 
            this.selectedMonster.Location = new System.Drawing.Point(3, 3);
            this.selectedMonster.Name = "selectedMonster";
            this.selectedMonster.Size = new System.Drawing.Size(194, 23);
            this.selectedMonster.TabIndex = 0;
            this.selectedMonster.Text = "No Monster Selected";
            this.selectedMonster.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // monsterBack
            // 
            this.monsterBack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.monsterBack.Location = new System.Drawing.Point(44, 405);
            this.monsterBack.Name = "monsterBack";
            this.monsterBack.Size = new System.Drawing.Size(75, 23);
            this.monsterBack.TabIndex = 5;
            this.monsterBack.Text = "Previous";
            this.monsterBack.UseVisualStyleBackColor = true;
            this.monsterBack.Click += new System.EventHandler(this.monsterBack_Click);
            // 
            // monsterNext
            // 
            this.monsterNext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.monsterNext.Location = new System.Drawing.Point(189, 405);
            this.monsterNext.Name = "monsterNext";
            this.monsterNext.Size = new System.Drawing.Size(75, 23);
            this.monsterNext.TabIndex = 4;
            this.monsterNext.Text = "Next";
            this.monsterNext.UseVisualStyleBackColor = true;
            this.monsterNext.Click += new System.EventHandler(this.monsterNext_Click);
            // 
            // monsterPageLabel
            // 
            this.monsterPageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.monsterPageLabel.AutoSize = true;
            this.monsterPageLabel.Location = new System.Drawing.Point(125, 410);
            this.monsterPageLabel.Name = "monsterPageLabel";
            this.monsterPageLabel.Size = new System.Drawing.Size(58, 13);
            this.monsterPageLabel.TabIndex = 3;
            this.monsterPageLabel.Text = "Page 1/15";
            // 
            // monsterRed
            // 
            this.monsterRed.AutoSize = false;
            this.monsterRed.BackColor = System.Drawing.SystemColors.Window;
            this.monsterRed.Location = new System.Drawing.Point(48, 315);
            this.monsterRed.Maximum = 255;
            this.monsterRed.Name = "monsterRed";
            this.monsterRed.Size = new System.Drawing.Size(104, 20);
            this.monsterRed.TabIndex = 20;
            this.monsterRed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.monsterRed.Value = 1;
            this.monsterRed.Scroll += new System.EventHandler(this.monsterRed_Scroll);
            // 
            // monsterGreen
            // 
            this.monsterGreen.AutoSize = false;
            this.monsterGreen.BackColor = System.Drawing.SystemColors.Window;
            this.monsterGreen.Location = new System.Drawing.Point(48, 341);
            this.monsterGreen.Maximum = 255;
            this.monsterGreen.Name = "monsterGreen";
            this.monsterGreen.Size = new System.Drawing.Size(104, 20);
            this.monsterGreen.TabIndex = 21;
            this.monsterGreen.TickStyle = System.Windows.Forms.TickStyle.None;
            this.monsterGreen.Value = 1;
            this.monsterGreen.Scroll += new System.EventHandler(this.monsterGreen_Scroll);
            // 
            // monsterBlue
            // 
            this.monsterBlue.AutoSize = false;
            this.monsterBlue.BackColor = System.Drawing.SystemColors.Window;
            this.monsterBlue.Location = new System.Drawing.Point(48, 367);
            this.monsterBlue.Maximum = 255;
            this.monsterBlue.Name = "monsterBlue";
            this.monsterBlue.Size = new System.Drawing.Size(104, 20);
            this.monsterBlue.TabIndex = 22;
            this.monsterBlue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.monsterBlue.Value = 1;
            this.monsterBlue.Scroll += new System.EventHandler(this.monsterBlue_Scroll);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 298);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Orb RGB";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 315);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Red:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 341);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Green:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 367);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Blue:";
            // 
            // monsterRGBPreview
            // 
            this.monsterRGBPreview.BackColor = System.Drawing.Color.Transparent;
            this.monsterRGBPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.monsterRGBPreview.Location = new System.Drawing.Point(167, 391);
            this.monsterRGBPreview.Name = "monsterRGBPreview";
            this.monsterRGBPreview.Size = new System.Drawing.Size(30, 30);
            this.monsterRGBPreview.TabIndex = 27;
            // 
            // redBox
            // 
            this.redBox.Location = new System.Drawing.Point(158, 315);
            this.redBox.Name = "redBox";
            this.redBox.Size = new System.Drawing.Size(30, 20);
            this.redBox.TabIndex = 28;
            this.redBox.TextChanged += new System.EventHandler(this.redBox_TextChanged);
            // 
            // greenBox
            // 
            this.greenBox.Location = new System.Drawing.Point(158, 341);
            this.greenBox.Name = "greenBox";
            this.greenBox.Size = new System.Drawing.Size(30, 20);
            this.greenBox.TabIndex = 29;
            this.greenBox.TextChanged += new System.EventHandler(this.greenBox_TextChanged);
            // 
            // blueBox
            // 
            this.blueBox.Location = new System.Drawing.Point(158, 367);
            this.blueBox.Name = "blueBox";
            this.blueBox.Size = new System.Drawing.Size(30, 20);
            this.blueBox.TabIndex = 30;
            this.blueBox.TextChanged += new System.EventHandler(this.blueBox_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 496);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "FKSE";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.generalTab.ResumeLayout(false);
            this.generalTab.PerformLayout();
            this.itemsTab.ResumeLayout(false);
            this.itemsPanel.ResumeLayout(false);
            this.itemsPanel.PerformLayout();
            this.monstersTab.ResumeLayout(false);
            this.monstersTab.PerformLayout();
            this.monsterEditorPanel.ResumeLayout(false);
            this.monsterEditorPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monsterActionPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monsterBlue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.TextBox goldTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage generalTab;
        private System.Windows.Forms.TabPage itemsTab;
        private System.Windows.Forms.TabPage monstersTab;
        private System.Windows.Forms.Panel itemsPanel;
        private System.Windows.Forms.Label itemPageLabel;
        private System.Windows.Forms.Button itemsBack;
        private System.Windows.Forms.Button itemsNext;
        private System.Windows.Forms.ToolTip monsterTip;
        private System.Windows.Forms.Button monsterBack;
        private System.Windows.Forms.Button monsterNext;
        private System.Windows.Forms.Label monsterPageLabel;
        private System.Windows.Forms.Panel monsterEditorPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label selectedMonster;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar monsterActionPoints;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox monsterHP;
        private System.Windows.Forms.TextBox monsterEXP;
        private System.Windows.Forms.TextBox monsterDefence;
        private System.Windows.Forms.TextBox monsterAttack;
        private System.Windows.Forms.CheckBox monsterAssignable;
        private System.Windows.Forms.CheckBox monsterOwned;
        private System.Windows.Forms.TextBox monsterItemQuantity3;
        private System.Windows.Forms.ComboBox monsterItem3;
        private System.Windows.Forms.TextBox monsterItemQuantity2;
        private System.Windows.Forms.ComboBox monsterItem2;
        private System.Windows.Forms.TextBox monsterItemQuantity1;
        private System.Windows.Forms.ComboBox monsterItem1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar monsterBlue;
        private System.Windows.Forms.TrackBar monsterGreen;
        private System.Windows.Forms.TrackBar monsterRed;
        private System.Windows.Forms.Panel monsterRGBPreview;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox blueBox;
        private System.Windows.Forms.TextBox greenBox;
        private System.Windows.Forms.TextBox redBox;
    }
}

