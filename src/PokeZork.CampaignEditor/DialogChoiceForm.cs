using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PokeZork.Common.Enum;
using PokeZork.Common.Extensions;
using PokeZork.Common.Managers.JsonModels;

namespace PokeZork.CampaignEditor
{
    public partial class DialogChoiceForm : Form
    {
        List<CommandEntry> CommandEntries;
        Dialog Dialog;
        public DialogChoiceForm(ref Dialog dialog)
        {
            InitializeComponent();
            this.Dialog = dialog;
            this.CommandEntries = new List<CommandEntry>();
            foreach (var command in Enum.GetValues<Command>())
            {
                cbxCommands.Items.Add(command.ToFriendlyString());
            }
            LoadCommandListBox();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtDialogChoiceText_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelDialogChoice_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddCommand_Click(object sender, EventArgs e)
        {
            string selectedCommand = cbxCommands.SelectedItem?.ToString() ?? string.Empty;
            string parameter = txtParameter.Text.Trim();
            if (!selectedCommand.IsEmpty())
            {
                this.CommandEntries.Add(new CommandEntry() { Command = selectedCommand, Value = parameter });
            }
            txtParameter.Text = string.Empty;
            LoadCommandListBox();
        }

        private void btnDeleteCommand_Click(object sender, EventArgs e)
        {
            var selectedIndex = this.commandListBox.SelectedIndex;
            this.CommandEntries.RemoveAt(selectedIndex);
            LoadCommandListBox();
        }

        private void LoadCommandListBox()
        {
            this.commandListBox.Items.Clear();
            foreach (var command in this.CommandEntries)
            {
                this.commandListBox.Items.Add($"{command.Command} - {command.Value}");
            }
        }

        private void btnSaveDialogChoice_Click(object sender, EventArgs e)
        {
            string key = txtDialogChoiceKey.Text?.Trim() ?? string.Empty;
            if (key.IsEmpty())
            {
                MessageBox.Show("Key cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogChoice dc = new DialogChoice();
            dc.Key = key;
            dc.Text = txtDialogChoiceText.Text;
            dc.Commands = new List<CommandEntry>(this.CommandEntries);

            int existingIndex = this.Dialog.Choices.FindIndex(c => c.Key == dc.Key);
            if (existingIndex < 0)
            {
                this.Dialog.Choices.Add(dc);
            }
            else
            {
                this.Dialog.Choices[existingIndex] = dc;
            }

            this.DialogResult = DialogResult.OK;
            MessageBox.Show("Dialog Choice Saved", "Success");
            this.Close();
        }
    }
}
