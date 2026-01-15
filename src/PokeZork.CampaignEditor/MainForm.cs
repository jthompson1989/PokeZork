namespace PokeZork.CampaignEditor
{
    public partial class MainForm : Form
    {
        private const int GROUPBOX_X_POSITION = 467;
        private const int GROUPBOX_Y_POSITION = 45;   
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
        }

        private void btnSaveDialog_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelDialog_Click(object sender, EventArgs e)
        {

        }

        private void btnOpenDialogChoiceForm_Click(object sender, EventArgs e)
        {

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


        private void HideGroupBoxes(GroupBox? except = null)
        {
            this.chapterGroupBox.Visible = ReferenceEquals(except, this.chapterGroupBox);
            this.sceneGroupBox.Visible = ReferenceEquals(except, this.sceneGroupBox);
            this.dialogGroupBox.Visible = ReferenceEquals(except, this.dialogGroupBox);
            this.introGroupBox.Visible = ReferenceEquals(except, this.introGroupBox);

            if(except != null)
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
    }
}
