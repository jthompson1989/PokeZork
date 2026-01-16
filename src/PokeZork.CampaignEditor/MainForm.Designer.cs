namespace PokeZork.CampaignEditor
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            statusStrip1 = new StatusStrip();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newCampaignToolStripMenuItem = new ToolStripMenuItem();
            loadCampaignToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            helpMeToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            campaignTreeView = new TreeView();
            chapterGroupBox = new GroupBox();
            btnAddScene = new Button();
            btnCancelChapter = new Button();
            btnSaveChapter = new Button();
            txtChapterId = new TextBox();
            label2 = new Label();
            txtChapterName = new TextBox();
            label1 = new Label();
            sceneGroupBox = new GroupBox();
            btnAddDialog = new Button();
            cbx = new ComboBox();
            label5 = new Label();
            btnCancelScene = new Button();
            btnSaveScene = new Button();
            txtSceneId = new TextBox();
            label3 = new Label();
            txtSceneName = new TextBox();
            label4 = new Label();
            dialogGroupBox = new GroupBox();
            btnDeleteSelectedDialogChoice = new Button();
            btnOpenDialogChoiceForm = new Button();
            lstBxDialogChoices = new ListBox();
            txtNextDialogCode = new TextBox();
            label9 = new Label();
            comboBox1 = new ComboBox();
            label8 = new Label();
            btnCancelDialog = new Button();
            btnSaveDialog = new Button();
            txtDialogId = new TextBox();
            label6 = new Label();
            txtDialogText = new TextBox();
            label7 = new Label();
            btnNewChapter = new Button();
            btnCreateScene = new Button();
            btnCreateDialog = new Button();
            introGroupBox = new GroupBox();
            menuStrip1.SuspendLayout();
            chapterGroupBox.SuspendLayout();
            sceneGroupBox.SuspendLayout();
            dialogGroupBox.SuspendLayout();
            introGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(28, 28);
            statusStrip1.Location = new Point(0, 494);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 8, 0);
            statusStrip1.Size = new Size(1110, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(28, 28);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(4, 1, 0, 1);
            menuStrip1.Size = new Size(1110, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newCampaignToolStripMenuItem, loadCampaignToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 22);
            fileToolStripMenuItem.Text = "File";
            // 
            // newCampaignToolStripMenuItem
            // 
            newCampaignToolStripMenuItem.Name = "newCampaignToolStripMenuItem";
            newCampaignToolStripMenuItem.Size = new Size(180, 22);
            newCampaignToolStripMenuItem.Text = "New Campaign";
            newCampaignToolStripMenuItem.Click += newCampaignToolStripMenuItem_Click;
            // 
            // loadCampaignToolStripMenuItem
            // 
            loadCampaignToolStripMenuItem.Name = "loadCampaignToolStripMenuItem";
            loadCampaignToolStripMenuItem.Size = new Size(180, 22);
            loadCampaignToolStripMenuItem.Text = "Load Campaign";
            loadCampaignToolStripMenuItem.Click += loadCampaignToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { helpMeToolStripMenuItem, aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 22);
            helpToolStripMenuItem.Text = "Help";
            // 
            // helpMeToolStripMenuItem
            // 
            helpMeToolStripMenuItem.Name = "helpMeToolStripMenuItem";
            helpMeToolStripMenuItem.Size = new Size(119, 22);
            helpMeToolStripMenuItem.Text = "Help Me";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(119, 22);
            aboutToolStripMenuItem.Text = "About";
            // 
            // campaignTreeView
            // 
            campaignTreeView.Dock = DockStyle.Left;
            campaignTreeView.Enabled = false;
            campaignTreeView.Location = new Point(0, 24);
            campaignTreeView.Margin = new Padding(2);
            campaignTreeView.Name = "campaignTreeView";
            campaignTreeView.Size = new Size(264, 470);
            campaignTreeView.TabIndex = 2;
            campaignTreeView.AfterSelect += campaignTreeView_AfterSelect;
            // 
            // chapterGroupBox
            // 
            chapterGroupBox.Controls.Add(btnAddScene);
            chapterGroupBox.Controls.Add(btnCancelChapter);
            chapterGroupBox.Controls.Add(btnSaveChapter);
            chapterGroupBox.Controls.Add(txtChapterId);
            chapterGroupBox.Controls.Add(label2);
            chapterGroupBox.Controls.Add(txtChapterName);
            chapterGroupBox.Controls.Add(label1);
            chapterGroupBox.Location = new Point(299, 225);
            chapterGroupBox.Margin = new Padding(2);
            chapterGroupBox.Name = "chapterGroupBox";
            chapterGroupBox.Padding = new Padding(2);
            chapterGroupBox.Size = new Size(365, 236);
            chapterGroupBox.TabIndex = 3;
            chapterGroupBox.TabStop = false;
            chapterGroupBox.Text = "Chapter";
            // 
            // btnAddScene
            // 
            btnAddScene.Enabled = false;
            btnAddScene.Location = new Point(16, 148);
            btnAddScene.Margin = new Padding(2);
            btnAddScene.Name = "btnAddScene";
            btnAddScene.Size = new Size(76, 20);
            btnAddScene.TabIndex = 6;
            btnAddScene.Text = "Add Scene";
            btnAddScene.UseVisualStyleBackColor = true;
            btnAddScene.Click += btnAddScene_Click;
            // 
            // btnCancelChapter
            // 
            btnCancelChapter.Location = new Point(268, 112);
            btnCancelChapter.Margin = new Padding(2);
            btnCancelChapter.Name = "btnCancelChapter";
            btnCancelChapter.Size = new Size(76, 20);
            btnCancelChapter.TabIndex = 5;
            btnCancelChapter.Text = "Cancel";
            btnCancelChapter.UseVisualStyleBackColor = true;
            btnCancelChapter.Click += btnCancelChapter_Click;
            // 
            // btnSaveChapter
            // 
            btnSaveChapter.Location = new Point(183, 112);
            btnSaveChapter.Margin = new Padding(2);
            btnSaveChapter.Name = "btnSaveChapter";
            btnSaveChapter.Size = new Size(76, 20);
            btnSaveChapter.TabIndex = 4;
            btnSaveChapter.Text = "Save";
            btnSaveChapter.UseVisualStyleBackColor = true;
            btnSaveChapter.Click += btnSaveChapter_Click;
            // 
            // txtChapterId
            // 
            txtChapterId.Location = new Point(63, 30);
            txtChapterId.Margin = new Padding(2);
            txtChapterId.Name = "txtChapterId";
            txtChapterId.Size = new Size(236, 23);
            txtChapterId.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 30);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(20, 15);
            label2.TabIndex = 2;
            label2.Text = "Id:";
            // 
            // txtChapterName
            // 
            txtChapterName.Location = new Point(63, 58);
            txtChapterName.Margin = new Padding(2);
            txtChapterName.Name = "txtChapterName";
            txtChapterName.Size = new Size(236, 23);
            txtChapterName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 58);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 0;
            label1.Text = "Name:";
            // 
            // sceneGroupBox
            // 
            sceneGroupBox.Controls.Add(btnAddDialog);
            sceneGroupBox.Controls.Add(cbx);
            sceneGroupBox.Controls.Add(label5);
            sceneGroupBox.Controls.Add(btnCancelScene);
            sceneGroupBox.Controls.Add(btnSaveScene);
            sceneGroupBox.Controls.Add(txtSceneId);
            sceneGroupBox.Controls.Add(label3);
            sceneGroupBox.Controls.Add(txtSceneName);
            sceneGroupBox.Controls.Add(label4);
            sceneGroupBox.Location = new Point(266, 258);
            sceneGroupBox.Margin = new Padding(2);
            sceneGroupBox.Name = "sceneGroupBox";
            sceneGroupBox.Padding = new Padding(2);
            sceneGroupBox.Size = new Size(365, 236);
            sceneGroupBox.TabIndex = 4;
            sceneGroupBox.TabStop = false;
            sceneGroupBox.Text = "Scene";
            // 
            // btnAddDialog
            // 
            btnAddDialog.Enabled = false;
            btnAddDialog.Location = new Point(25, 174);
            btnAddDialog.Margin = new Padding(2);
            btnAddDialog.Name = "btnAddDialog";
            btnAddDialog.Size = new Size(76, 20);
            btnAddDialog.TabIndex = 7;
            btnAddDialog.Text = "Add Dialog";
            btnAddDialog.UseVisualStyleBackColor = true;
            btnAddDialog.Click += btnAddDialog_Click;
            // 
            // cbx
            // 
            cbx.FormattingEnabled = true;
            cbx.Location = new Point(63, 40);
            cbx.Margin = new Padding(2);
            cbx.Name = "cbx";
            cbx.Size = new Size(236, 23);
            cbx.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(4, 40);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 8;
            label5.Text = "Chapter:";
            // 
            // btnCancelScene
            // 
            btnCancelScene.Location = new Point(268, 140);
            btnCancelScene.Margin = new Padding(2);
            btnCancelScene.Name = "btnCancelScene";
            btnCancelScene.Size = new Size(76, 20);
            btnCancelScene.TabIndex = 7;
            btnCancelScene.Text = "Cancel";
            btnCancelScene.UseVisualStyleBackColor = true;
            btnCancelScene.Click += btnCancelScene_Click;
            // 
            // btnSaveScene
            // 
            btnSaveScene.Location = new Point(183, 140);
            btnSaveScene.Margin = new Padding(2);
            btnSaveScene.Name = "btnSaveScene";
            btnSaveScene.Size = new Size(76, 20);
            btnSaveScene.TabIndex = 6;
            btnSaveScene.Text = "Save";
            btnSaveScene.UseVisualStyleBackColor = true;
            btnSaveScene.Click += btnSaveScene_Click;
            // 
            // txtSceneId
            // 
            txtSceneId.Location = new Point(63, 68);
            txtSceneId.Margin = new Padding(2);
            txtSceneId.Name = "txtSceneId";
            txtSceneId.Size = new Size(236, 23);
            txtSceneId.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 68);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(20, 15);
            label3.TabIndex = 2;
            label3.Text = "Id:";
            // 
            // txtSceneName
            // 
            txtSceneName.Location = new Point(63, 96);
            txtSceneName.Margin = new Padding(2);
            txtSceneName.Name = "txtSceneName";
            txtSceneName.Size = new Size(236, 23);
            txtSceneName.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 96);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 0;
            label4.Text = "Name:";
            // 
            // dialogGroupBox
            // 
            dialogGroupBox.Controls.Add(btnDeleteSelectedDialogChoice);
            dialogGroupBox.Controls.Add(btnOpenDialogChoiceForm);
            dialogGroupBox.Controls.Add(lstBxDialogChoices);
            dialogGroupBox.Controls.Add(txtNextDialogCode);
            dialogGroupBox.Controls.Add(label9);
            dialogGroupBox.Controls.Add(comboBox1);
            dialogGroupBox.Controls.Add(label8);
            dialogGroupBox.Controls.Add(btnCancelDialog);
            dialogGroupBox.Controls.Add(btnSaveDialog);
            dialogGroupBox.Controls.Add(txtDialogId);
            dialogGroupBox.Controls.Add(label6);
            dialogGroupBox.Controls.Add(txtDialogText);
            dialogGroupBox.Controls.Add(label7);
            dialogGroupBox.Location = new Point(644, 20);
            dialogGroupBox.Margin = new Padding(2);
            dialogGroupBox.Name = "dialogGroupBox";
            dialogGroupBox.Padding = new Padding(2);
            dialogGroupBox.Size = new Size(365, 470);
            dialogGroupBox.TabIndex = 7;
            dialogGroupBox.TabStop = false;
            dialogGroupBox.Text = "Dialog";
            dialogGroupBox.Enter += dialogGroupBox_Enter;
            // 
            // btnDeleteSelectedDialogChoice
            // 
            btnDeleteSelectedDialogChoice.Location = new Point(153, 324);
            btnDeleteSelectedDialogChoice.Margin = new Padding(2);
            btnDeleteSelectedDialogChoice.Name = "btnDeleteSelectedDialogChoice";
            btnDeleteSelectedDialogChoice.Size = new Size(192, 20);
            btnDeleteSelectedDialogChoice.TabIndex = 16;
            btnDeleteSelectedDialogChoice.Text = "Delete Selected Dialog Choice";
            btnDeleteSelectedDialogChoice.UseVisualStyleBackColor = true;
            btnDeleteSelectedDialogChoice.Click += btnDeleteSelectedDialogChoice_Click;
            // 
            // btnOpenDialogChoiceForm
            // 
            btnOpenDialogChoiceForm.Location = new Point(23, 324);
            btnOpenDialogChoiceForm.Margin = new Padding(2);
            btnOpenDialogChoiceForm.Name = "btnOpenDialogChoiceForm";
            btnOpenDialogChoiceForm.Size = new Size(117, 20);
            btnOpenDialogChoiceForm.TabIndex = 15;
            btnOpenDialogChoiceForm.Text = "Add Dialog Choice";
            btnOpenDialogChoiceForm.UseVisualStyleBackColor = true;
            btnOpenDialogChoiceForm.Click += btnOpenDialogChoiceForm_Click;
            // 
            // lstBxDialogChoices
            // 
            lstBxDialogChoices.FormattingEnabled = true;
            lstBxDialogChoices.Location = new Point(23, 353);
            lstBxDialogChoices.Margin = new Padding(2);
            lstBxDialogChoices.Name = "lstBxDialogChoices";
            lstBxDialogChoices.Size = new Size(324, 109);
            lstBxDialogChoices.TabIndex = 14;
            // 
            // txtNextDialogCode
            // 
            txtNextDialogCode.Location = new Point(86, 235);
            txtNextDialogCode.Margin = new Padding(2);
            txtNextDialogCode.Name = "txtNextDialogCode";
            txtNextDialogCode.Size = new Size(215, 23);
            txtNextDialogCode.TabIndex = 13;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(11, 235);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(71, 15);
            label9.TabIndex = 12;
            label9.Text = "Next Dialog:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(65, 28);
            comboBox1.Margin = new Padding(2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(236, 23);
            comboBox1.TabIndex = 11;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(11, 28);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(41, 15);
            label8.TabIndex = 10;
            label8.Text = "Scene:";
            // 
            // btnCancelDialog
            // 
            btnCancelDialog.Location = new Point(276, 277);
            btnCancelDialog.Margin = new Padding(2);
            btnCancelDialog.Name = "btnCancelDialog";
            btnCancelDialog.Size = new Size(76, 20);
            btnCancelDialog.TabIndex = 5;
            btnCancelDialog.Text = "Cancel";
            btnCancelDialog.UseVisualStyleBackColor = true;
            btnCancelDialog.Click += btnCancelDialog_Click;
            // 
            // btnSaveDialog
            // 
            btnSaveDialog.Location = new Point(191, 277);
            btnSaveDialog.Margin = new Padding(2);
            btnSaveDialog.Name = "btnSaveDialog";
            btnSaveDialog.Size = new Size(76, 20);
            btnSaveDialog.TabIndex = 4;
            btnSaveDialog.Text = "Save";
            btnSaveDialog.UseVisualStyleBackColor = true;
            btnSaveDialog.Click += btnSaveDialog_Click;
            // 
            // txtDialogId
            // 
            txtDialogId.Location = new Point(65, 57);
            txtDialogId.Margin = new Padding(2);
            txtDialogId.Name = "txtDialogId";
            txtDialogId.Size = new Size(236, 23);
            txtDialogId.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(34, 57);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(20, 15);
            label6.TabIndex = 2;
            label6.Text = "Id:";
            // 
            // txtDialogText
            // 
            txtDialogText.Location = new Point(24, 110);
            txtDialogText.Margin = new Padding(2);
            txtDialogText.Multiline = true;
            txtDialogText.Name = "txtDialogText";
            txtDialogText.Size = new Size(328, 111);
            txtDialogText.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(26, 93);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(28, 15);
            label7.TabIndex = 0;
            label7.Text = "Text";
            // 
            // btnNewChapter
            // 
            btnNewChapter.Location = new Point(19, 32);
            btnNewChapter.Margin = new Padding(2);
            btnNewChapter.Name = "btnNewChapter";
            btnNewChapter.Size = new Size(318, 20);
            btnNewChapter.TabIndex = 8;
            btnNewChapter.Text = "Create Chapter";
            btnNewChapter.UseVisualStyleBackColor = true;
            btnNewChapter.Click += btnNewChapter_Click;
            // 
            // btnCreateScene
            // 
            btnCreateScene.Location = new Point(19, 72);
            btnCreateScene.Margin = new Padding(2);
            btnCreateScene.Name = "btnCreateScene";
            btnCreateScene.Size = new Size(318, 20);
            btnCreateScene.TabIndex = 9;
            btnCreateScene.Text = "Create Scene";
            btnCreateScene.UseVisualStyleBackColor = true;
            btnCreateScene.Click += btnCreateScene_Click;
            // 
            // btnCreateDialog
            // 
            btnCreateDialog.Location = new Point(19, 115);
            btnCreateDialog.Margin = new Padding(2);
            btnCreateDialog.Name = "btnCreateDialog";
            btnCreateDialog.Size = new Size(318, 20);
            btnCreateDialog.TabIndex = 10;
            btnCreateDialog.Text = "Create Dialog";
            btnCreateDialog.UseVisualStyleBackColor = true;
            btnCreateDialog.Click += btnCreateDialog_Click;
            // 
            // introGroupBox
            // 
            introGroupBox.Controls.Add(btnNewChapter);
            introGroupBox.Controls.Add(btnCreateDialog);
            introGroupBox.Controls.Add(btnCreateScene);
            introGroupBox.Location = new Point(272, 22);
            introGroupBox.Margin = new Padding(2);
            introGroupBox.Name = "introGroupBox";
            introGroupBox.Padding = new Padding(2);
            introGroupBox.Size = new Size(368, 190);
            introGroupBox.TabIndex = 11;
            introGroupBox.TabStop = false;
            introGroupBox.Text = "Campaign";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1110, 516);
            Controls.Add(introGroupBox);
            Controls.Add(dialogGroupBox);
            Controls.Add(sceneGroupBox);
            Controls.Add(chapterGroupBox);
            Controls.Add(campaignTreeView);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2);
            Name = "MainForm";
            Text = "PokeZork Campaign Editor";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            chapterGroupBox.ResumeLayout(false);
            chapterGroupBox.PerformLayout();
            sceneGroupBox.ResumeLayout(false);
            sceneGroupBox.PerformLayout();
            dialogGroupBox.ResumeLayout(false);
            dialogGroupBox.PerformLayout();
            introGroupBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newCampaignToolStripMenuItem;
        private ToolStripMenuItem loadCampaignToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem helpMeToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private TreeView campaignTreeView;
        private GroupBox chapterGroupBox;
        private TextBox txtChapterName;
        private Label label1;
        private TextBox txtChapterId;
        private Label label2;
        private Button btnCancelChapter;
        private Button btnSaveChapter;
        private GroupBox sceneGroupBox;
        private Button btnCancelScene;
        private Button btnSaveScene;
        private TextBox txtSceneId;
        private Label label3;
        private TextBox txtSceneName;
        private Label label4;
        private Button btnAddScene;
        private Label label5;
        private ComboBox cbx;
        private Button btnAddDialog;
        private GroupBox dialogGroupBox;
        private Button btnCancelDialog;
        private Button btnSaveDialog;
        private TextBox txtDialogId;
        private Label label6;
        private TextBox txtDialogText;
        private Label label7;
        private ComboBox comboBox1;
        private Label label8;
        private TextBox txtNextDialogCode;
        private Label label9;
        private Button btnDeleteSelectedDialogChoice;
        private Button btnOpenDialogChoiceForm;
        private ListBox lstBxDialogChoices;
        private Button btnNewChapter;
        private Button btnCreateScene;
        private Button btnCreateDialog;
        private GroupBox introGroupBox;
    }
}
