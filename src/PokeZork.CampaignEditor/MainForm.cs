using PokeZork.Common.Managers;
using PokeZork.Common.Managers.JsonModels;
namespace PokeZork.CampaignEditor
{
    public partial class MainForm : Form
    {
        private const int GROUPBOX_X_POSITION = 467;
        private const int GROUPBOX_Y_POSITION = 45;
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

        }

        private void btnCancelChapter_Click(object sender, EventArgs e)
        {
            HideGroupBoxes(this.introGroupBox);
        }

        private void btnAddScene_Click(object sender, EventArgs e)
        {
            HideGroupBoxes(this.sceneGroupBox);
        }

        private void btnSaveScene_Click(object sender, EventArgs e)
        {

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
                string campaignFilePath = openFileDialog.FileName;
                JsonManager jsonManager = new JsonManager(campaignFilePath);
                this.LoadedCampaign = jsonManager.LoadCampaignFromJson();
                LoadCampignTree();
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
            if (this.SelectedChapter != null)
            {
                this.SelectedScene = this.SelectedChapter.Scenes.FirstOrDefault(s => s.Id == id);
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
            if (this.SelectedScene != null)
            {
                this.SelectedDialog = this.SelectedScene.Dialogs.FirstOrDefault(d => d.Id == id);
                if (this.SelectedDialog != null)
                {
                    txtDialogId.Text = this.SelectedDialog.Id.ToString();
                    txtDialogText.Text = this.SelectedDialog.Text;
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
                            TreeNode dialogNode = new TreeNode($"Dialog {dialog.Id}");
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
    }
}
