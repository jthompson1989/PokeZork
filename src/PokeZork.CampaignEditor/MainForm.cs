using PokeZork.Common.Managers;
using PokeZork.Common.Managers.JsonModels;
namespace PokeZork.CampaignEditor
{
    public partial class MainForm : Form
    {
        private const int GROUPBOX_X_POSITION = 467;
        private const int GROUPBOX_Y_POSITION = 45;
        private string CampaignFilePath = string.Empty;
        private Campaign? LoadedCampaign;
        private Chapter? SelectedChapter;
        private Scene? SelectedScene;
        private Dialog? SelectedDialog;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Make sure all group boxes are hidden on load
            HideGroupBoxes(this.introGroupBox);

        }

        private void dialogGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void btnSaveChapter_Click(object sender, EventArgs e)
        {
            if (this.LoadedCampaign == null)
            {
                MessageBox.Show("No campaign is loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtChapterId.Text, out int parsedId))
            {
                MessageBox.Show("Chapter ID must be a valid integer.", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string title = txtChapterName.Text?.Trim() ?? string.Empty;
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Chapter title cannot be empty.", "Invalid Title", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // If editing an existing chapter, update it. Otherwise create a new one.
            if (this.SelectedChapter == null)
            {
                if (this.LoadedCampaign.Chapters.Any(c => c.Id == parsedId))
                {
                    MessageBox.Show($"A chapter with ID {parsedId} already exists.", "Duplicate ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.SelectedChapter = new Chapter
                {
                    Id = parsedId,
                    Title = title,
                    Scenes = new List<Scene>()
                };
                this.LoadedCampaign.Chapters.Add(this.SelectedChapter);
            }
            else
            {

                var existingWithId = this.LoadedCampaign.Chapters.FirstOrDefault(c => c.Id == parsedId && !ReferenceEquals(c, this.SelectedChapter));
                if (existingWithId != null)
                {
                    MessageBox.Show($"Another chapter with ID {parsedId} already exists.", "Duplicate ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.SelectedChapter.Title = title;
                this.SelectedChapter.Id = parsedId;
            }

            // Refresh UI
            LoadComboBoxChaptersFromCampaign();
            campaignTreeView.Nodes.Clear();
            LoadCampignTree();

            HideGroupBoxes(this.introGroupBox);
        }

        private void btnCancelChapter_Click(object sender, EventArgs e)
        {
            HideGroupBoxes(this.introGroupBox);
        }

        private void btnAddScene_Click(object sender, EventArgs e)
        {
            this.SelectedScene = null;
            HideGroupBoxes(this.sceneGroupBox);
        }

        private void btnSaveScene_Click(object sender, EventArgs e)
        {
            if (this.LoadedCampaign == null)
            {
                MessageBox.Show("No campaign is loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtSceneId.Text, out int parsedId))
            {
                MessageBox.Show("Scene ID must be a valid integer.", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string title = txtSceneName.Text?.Trim() ?? string.Empty;
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Scene title cannot be empty.", "Invalid Title", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.SelectedChapter == null)
            {
                if (cbxChapters.SelectedItem == null)
                {
                    MessageBox.Show("No chapter selected. Please select a chapter first.", "No Chapter Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedText = cbxChapters.SelectedItem.ToString() ?? string.Empty;
                var parts = selectedText.Split(new[] { '-' }, 2);
                if (parts.Length == 0 || !int.TryParse(parts[0], out int chapterId))
                {
                    MessageBox.Show("Unable to determine selected chapter. Please reselect a chapter.", "Invalid Chapter", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.SelectedChapter = this.LoadedCampaign.Chapters.FirstOrDefault(c => c.Id == chapterId);
                if (this.SelectedChapter == null)
                {
                    MessageBox.Show("Selected chapter not found in the loaded campaign.", "Chapter Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            // If editing an existing scene, update it. Otherwise create a new one.
            if (this.SelectedScene == null)
            {
                if (this.SelectedChapter.Scenes.Any(s => s.Id == parsedId))
                {
                    MessageBox.Show($"A scene with ID {parsedId} already exists in chapter {this.SelectedChapter.Id}.", "Duplicate ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.SelectedScene = new Scene
                {
                    Id = parsedId,
                    Title = title,
                    Dialogs = new List<Dialog>()
                };
                this.SelectedChapter.Scenes.Add(this.SelectedScene);
            }
            else
            {
                var existingWithId = this.SelectedChapter.Scenes.FirstOrDefault(s => s.Id == parsedId && !ReferenceEquals(s, this.SelectedScene));
                if (existingWithId != null)
                {
                    MessageBox.Show($"Another scene with ID {parsedId} already exists in chapter {this.SelectedChapter.Id}.", "Duplicate ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.SelectedScene.Title = title;
                this.SelectedScene.Id = parsedId;
            }

            // Refresh UI
            LoadComboBoxSceneFromCampaign();
            campaignTreeView.Nodes.Clear();
            LoadCampignTree();

            HideGroupBoxes(this.introGroupBox);
        }

        private void btnCancelScene_Click(object sender, EventArgs e)
        {
            HideGroupBoxes(this.introGroupBox);
        }

        private void btnAddDialog_Click(object sender, EventArgs e)
        {
            HideGroupBoxes(this.dialogGroupBox);
            if (this.SelectedDialog == null)
            {
                this.SelectedDialog = new Dialog();
            }
            else
            {
                txtDialogId.Text = this.SelectedDialog.Id.ToString();
                txtDialogText.Text = this.SelectedDialog.Text;


            }
        }

        private void btnSaveDialog_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelDialog_Click(object sender, EventArgs e)
        {
            this.SelectedDialog = null;
            HideGroupBoxes(this.introGroupBox);
        }

        private void btnOpenDialogChoiceForm_Click(object sender, EventArgs e)
        {
            if (this.SelectedDialog == null)
            {
                this.SelectedDialog = new Dialog();
            }
            DialogChoiceForm dialogChoiceForm = new DialogChoiceForm(ref this.SelectedDialog);
            dialogChoiceForm.Show();
        }

        private void btnDeleteSelectedDialogChoice_Click(object sender, EventArgs e)
        {

        }

        private void btnNewChapter_Click(object sender, EventArgs e)
        {
            HideGroupBoxes(this.chapterGroupBox);
        }

        private void btnCreateScene_Click(object sender, EventArgs e)
        {
            HideGroupBoxes(this.sceneGroupBox);
        }

        private void btnCreateDialog_Click(object sender, EventArgs e)
        {
            HideGroupBoxes(this.dialogGroupBox);
        }

        private void newCampaignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadedCampaign = new Campaign()
            {
                Id = 3,
                Name = "New Campaign",
                Chapters = new List<Chapter>()
            };
        }

        private void loadCampaignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Campaign Files (*.campaign)|*.campaign|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.CampaignFilePath = openFileDialog.FileName;
                JsonManager jsonManager = new JsonManager(this.CampaignFilePath);
                this.LoadedCampaign = jsonManager.LoadCampaignFromJson();
                LoadCampignTree();
                LoadComboBoxChaptersFromCampaign();
                LoadComboBoxSceneFromCampaign();
            }

        }

        private void LoadChapter(int id, int? campaignId)
        {
            this.SelectedChapter = this.LoadedCampaign?.Chapters.FirstOrDefault(c => c.Id == id);
            if (this.SelectedChapter != null)
            {
                txtChapterName.Text = this.SelectedChapter.Title;
                txtChapterId.Text = this.SelectedChapter.Id.ToString();
            }
            HideGroupBoxes(this.chapterGroupBox);
        }

        private void LoadScene(int id, int? chapterId)
        {
            this.SelectedScene = GetSceneFromCampaign(id);
            this.SelectedChapter = this.LoadedCampaign?.Chapters.FirstOrDefault(c => c.Id == chapterId);
            if (this.SelectedChapter != null)
            {
                cbxChapters.SelectedItem = $"{this.SelectedChapter.Id}-{this.SelectedChapter.Title}";
                if (this.SelectedScene != null)
                {
                    txtSceneName.Text = this.SelectedScene.Title;
                    txtSceneId.Text = this.SelectedScene.Id.ToString();
                }
                HideGroupBoxes(this.sceneGroupBox);
            }
        }

        private void LoadDialog(int id, int? sceneId)
        {
            this.SelectedScene = GetSceneFromCampaign(sceneId ?? -1);
            if (this.SelectedScene != null)
            {
                this.SelectedDialog = GetDialogFromCampaign(id);
                cbxScenes.SelectedItem = $"{this.SelectedScene.Id}-{this.SelectedScene.Title}";
                if (this.SelectedDialog != null)
                {
                    txtDialogId.Text = this.SelectedDialog.Id.ToString();
                    txtDialogText.Text = this.SelectedDialog.Text;
                    txtNextDialogCode.Text = this.SelectedDialog.NextDialog;
                    lstBxDialogChoices.Items.Clear();
                    foreach (var choice in this.SelectedDialog.Choices)
                    {
                        lstBxDialogChoices.Items.Add($"{choice.Key}-{choice.Text}");
                    }
                }
                HideGroupBoxes(this.dialogGroupBox);
            }
        }


        private void HideGroupBoxes(GroupBox? except = null)
        {
            this.chapterGroupBox.Visible = ReferenceEquals(except, this.chapterGroupBox);
            this.sceneGroupBox.Visible = ReferenceEquals(except, this.sceneGroupBox);
            this.dialogGroupBox.Visible = ReferenceEquals(except, this.dialogGroupBox);
            this.introGroupBox.Visible = ReferenceEquals(except, this.introGroupBox);

            if (except != null)
            {
                except.Location = new Point(GROUPBOX_X_POSITION, GROUPBOX_Y_POSITION);
            }

            if (except != null
                && !ReferenceEquals(except, this.chapterGroupBox)
                && !ReferenceEquals(except, this.sceneGroupBox)
                && !ReferenceEquals(except, this.dialogGroupBox)
                && !ReferenceEquals(except, this.introGroupBox))
            {
                except.Visible = true;
            }
        }


        private void LoadCampignTree()
        {
            if (this.LoadedCampaign != null)
            {
                foreach (var chapter in this.LoadedCampaign.Chapters)
                {
                    TreeNode chapterNode = new TreeNode(chapter.Title);
                    chapterNode.Tag = chapter;
                    foreach (var scene in chapter.Scenes)
                    {
                        TreeNode sceneNode = new TreeNode(scene.Title);
                        sceneNode.Tag = scene;
                        foreach (var dialog in scene.Dialogs)
                        {
                            TreeNode dialogNode =
                                new TreeNode($"Dialog {dialog.Id} - {chapter.Id}:{scene.Id}:{dialog.Id}");
                            dialogNode.Tag = dialog;
                            sceneNode.Nodes.Add(dialogNode);
                        }
                        chapterNode.Nodes.Add(sceneNode);
                    }
                    campaignTreeView.Nodes.Add(chapterNode);
                }
                campaignTreeView.Enabled = true;
                campaignTreeView.NodeMouseClick += CampaignTree_NodeMouseClick;
            }
        }
        private void CampaignTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var selectedNode = e.Node;
            if (selectedNode != null)
            {
                var parentNode = selectedNode.Parent;
                if (selectedNode.Tag is Chapter chapter)
                {
                    var campaignNode = parentNode?.Tag as Campaign ?? null;
                    LoadChapter(chapter.Id, campaignNode?.Id);
                }
                else if (selectedNode.Tag is Scene scene)
                {
                    var chapterNode = parentNode?.Tag as Chapter ?? null;
                    LoadScene(scene.Id, chapterNode?.Id);
                }
                else if (selectedNode.Tag is Dialog dialog)
                {
                    var sceneNode = parentNode?.Tag as Scene ?? null;
                    LoadDialog(dialog.Id, sceneNode?.Id);
                }
            }
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void campaignTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private Scene? GetSceneFromCampaign(int sceneId)
        {
            if (this.LoadedCampaign == null)
                return null;

            return this.LoadedCampaign.Chapters
                .SelectMany(c => c.Scenes)
                .FirstOrDefault(s => s.Id == sceneId);
        }

        private Dialog? GetDialogFromCampaign(int dialogId)
        {
            if (this.LoadedCampaign == null)
                return null;

            return this.LoadedCampaign.Chapters
                .SelectMany(c => c.Scenes)
                .SelectMany(s => s.Dialogs)
                .FirstOrDefault(d => d.Id == dialogId);
        }

        private void LoadComboBoxChaptersFromCampaign()
        {
            cbxChapters.Items.Clear();
            if (this.LoadedCampaign == null)
                return;

            var chapters = this.LoadedCampaign?.Chapters;
            foreach (var chapter in chapters)
            {
                cbxChapters.Items.Add($"{chapter.Id}-{chapter.Title}");
            }
        }

        private void LoadComboBoxSceneFromCampaign()
        {
            cbxScenes.Items.Clear();
            if (this.LoadedCampaign == null)
                return;

            var scenes = this.LoadedCampaign.Chapters
                .SelectMany(c => c.Scenes)
                .ToList();
            foreach (var scene in scenes)
            {
                cbxScenes.Items.Add($"{scene.Id}-{scene.Title}");
            }
        }

        private void btnWriteCampaignChanges_Click(object sender, EventArgs e)
        {
            if (this.LoadedCampaign == null)
                return;

            var finalApproval = MessageBox.Show("Are you sure you want to write changes to the campaign file?", "Confirm Write", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (finalApproval == DialogResult.Yes)
            {
                // Write the changes to the campaign file
                JsonManager jsonManager = new JsonManager(this.CampaignFilePath);
                jsonManager.SaveCampaignToJson(this.LoadedCampaign);
            }
            else
            {
                MessageBox.Show("Write operation cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lstBxDialogChoices_DoubleClick(object sender, EventArgs e)
        {
            var selectedItem = lstBxDialogChoices.SelectedItem;
            if (selectedItem != null)
            {
                var choice = this.SelectedDialog.Choices
                    .Where(c => $"{c.Key}-{c.Text}" == selectedItem.ToString()).FirstOrDefault();

                if (choice != null)
                {
                    DialogChoiceForm dialogChoiceForm = new DialogChoiceForm(ref choice, ref this.SelectedDialog);
                    dialogChoiceForm.Show();
                }

            }
        }
    }
}
