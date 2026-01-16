namespace PokeZork.CampaignEditor
{
    partial class DialogChoiceForm
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
            label1 = new Label();
            label2 = new Label();
            txtDialogChoiceKey = new TextBox();
            txtDialogChoiceText = new TextBox();
            groupBox1 = new GroupBox();
            btnDeleteCommand = new Button();
            btnAddCommand = new Button();
            label4 = new Label();
            txtParameter = new TextBox();
            label3 = new Label();
            cbxCommands = new ComboBox();
            commandListBox = new ListBox();
            btnSaveDialogChoice = new Button();
            btnCancelDialogChoice = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 20);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 0;
            label1.Text = "Key:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 57);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 1;
            label2.Text = "Text:";
            label2.Click += label2_Click;
            // 
            // txtDialogChoiceKey
            // 
            txtDialogChoiceKey.Location = new Point(70, 17);
            txtDialogChoiceKey.Name = "txtDialogChoiceKey";
            txtDialogChoiceKey.Size = new Size(100, 23);
            txtDialogChoiceKey.TabIndex = 2;
            // 
            // txtDialogChoiceText
            // 
            txtDialogChoiceText.Location = new Point(70, 57);
            txtDialogChoiceText.Multiline = true;
            txtDialogChoiceText.Name = "txtDialogChoiceText";
            txtDialogChoiceText.Size = new Size(369, 80);
            txtDialogChoiceText.TabIndex = 3;
            txtDialogChoiceText.TextChanged += txtDialogChoiceText_TextChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDeleteCommand);
            groupBox1.Controls.Add(btnAddCommand);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtParameter);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cbxCommands);
            groupBox1.Controls.Add(commandListBox);
            groupBox1.Location = new Point(12, 163);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(542, 264);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Commands";
            // 
            // btnDeleteCommand
            // 
            btnDeleteCommand.Location = new Point(452, 42);
            btnDeleteCommand.Name = "btnDeleteCommand";
            btnDeleteCommand.Size = new Size(75, 23);
            btnDeleteCommand.TabIndex = 6;
            btnDeleteCommand.Text = "Delete";
            btnDeleteCommand.UseVisualStyleBackColor = true;
            btnDeleteCommand.Click += btnDeleteCommand_Click;
            // 
            // btnAddCommand
            // 
            btnAddCommand.Location = new Point(371, 42);
            btnAddCommand.Name = "btnAddCommand";
            btnAddCommand.Size = new Size(75, 23);
            btnAddCommand.TabIndex = 5;
            btnAddCommand.Text = "Add";
            btnAddCommand.UseVisualStyleBackColor = true;
            btnAddCommand.Click += btnAddCommand_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(216, 25);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 4;
            label4.Text = "Parameter";
            // 
            // txtParameter
            // 
            txtParameter.Location = new Point(216, 43);
            txtParameter.Name = "txtParameter";
            txtParameter.Size = new Size(145, 23);
            txtParameter.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 25);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 2;
            label3.Text = "Commands";
            // 
            // cbxCommands
            // 
            cbxCommands.FormattingEnabled = true;
            cbxCommands.Location = new Point(21, 43);
            cbxCommands.Name = "cbxCommands";
            cbxCommands.Size = new Size(171, 23);
            cbxCommands.TabIndex = 1;
            // 
            // commandListBox
            // 
            commandListBox.FormattingEnabled = true;
            commandListBox.Location = new Point(6, 89);
            commandListBox.Name = "commandListBox";
            commandListBox.Size = new Size(530, 169);
            commandListBox.TabIndex = 0;
            // 
            // btnSaveDialogChoice
            // 
            btnSaveDialogChoice.Location = new Point(383, 448);
            btnSaveDialogChoice.Name = "btnSaveDialogChoice";
            btnSaveDialogChoice.Size = new Size(75, 23);
            btnSaveDialogChoice.TabIndex = 5;
            btnSaveDialogChoice.Text = "Save";
            btnSaveDialogChoice.UseVisualStyleBackColor = true;
            btnSaveDialogChoice.Click += btnSaveDialogChoice_Click;
            // 
            // btnCancelDialogChoice
            // 
            btnCancelDialogChoice.Location = new Point(479, 448);
            btnCancelDialogChoice.Name = "btnCancelDialogChoice";
            btnCancelDialogChoice.Size = new Size(75, 23);
            btnCancelDialogChoice.TabIndex = 6;
            btnCancelDialogChoice.Text = "Cancel";
            btnCancelDialogChoice.UseVisualStyleBackColor = true;
            btnCancelDialogChoice.Click += btnCancelDialogChoice_Click;
            // 
            // DialogChoiceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(566, 483);
            Controls.Add(btnCancelDialogChoice);
            Controls.Add(btnSaveDialogChoice);
            Controls.Add(groupBox1);
            Controls.Add(txtDialogChoiceText);
            Controls.Add(txtDialogChoiceKey);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "DialogChoiceForm";
            Text = "PokeZork - Dialog Choice";
            TopMost = true;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtDialogChoiceKey;
        private TextBox txtDialogChoiceText;
        private GroupBox groupBox1;
        private ListBox listBox1;
        private Button button1;
        private Button btnAddCommand;
        private Label label4;
        private TextBox textBox1;
        private Label label3;
        private ComboBox cbxCommands;
        private Button btnSaveDialogChoice;
        private Button btnDeleteCommand;
        private ListBox commandListBox;
        private TextBox txtParameter;
        private GroupBox groupBox2;
        private Button btnCancelDialogChoice;
    }
}