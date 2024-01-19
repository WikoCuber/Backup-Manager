using BM_Core;
using BM_Core.Helpers;
using BM_Data;

namespace BM_UI.Forms
{
    public partial class MainForm : Form
    {
        private readonly List<string> currentSubelements; //Full path to current subelements

        private string? selectedPath;

        public MainForm()
        {
            InitializeComponent();

            currentSubelements = [];

            SetDefaults();
        }

        private void SetDefaults()
        {
            foreach (var item in SaveFile.Data.Elements)
                elementsListBox.Items.Add(item.Path);

            deleteAdditionalFileCheckBox.Checked = SaveFile.Data.IsDeleteAdditionalElements;
            checkFileSizeCheckBox.Checked = SaveFile.Data.IsCheckFileSize;
        }

        private void ChangeFormState(bool isOn)
        {
            progressBar.Visible = !isOn;
            elementsCountLabel.Visible = !isOn;
            elementsTextLabel.Visible = !isOn;
            selectDirectoryButton.Enabled = isOn;
            selectFileButton.Enabled = isOn;
            makeCopyButton.Enabled = isOn;
            elementsListBox.Enabled = isOn;
            unselectAllButton.Enabled = isOn;
            selectAllButtton.Enabled = isOn;
            subelementsListBox.Enabled = isOn;
            checkFileSizeCheckBox.Enabled = isOn;
            deleteAdditionalFileCheckBox.Enabled = isOn;
        }

        private void MakeCopy()
        {
            CheckFiles worker = new();

            worker.InfoEvent += (s) => MessageBox.Show(s, "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Thread labelLoop = new(() =>
            {
                while (!worker.IsDone)
                {
                    //Get status from worker
                    string text = worker.GetStatus();
                    if (elementsCountLabel.Text != text)
                        BeginInvoke(() => elementsCountLabel.Text = text);

                    Thread.Sleep(10);
                }
            })
            {
                IsBackground = true,
                Name = "Label loop"
            };
            labelLoop.Start();

            //Doesn't block UI
            Task.Run(() =>
            {
                var result = worker.Check(SaveFile.Data.Elements);

                BeginInvoke(() => ChangeFormState(true));

                //Error case
                if (worker.ErrorMessage != "")
                {
                    MessageBox.Show(worker.ErrorMessage, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                CopyForm form = new(result, worker.TotalSize, worker.TotalElements);
                BeginInvoke(() => form.ShowDialog());
            });
        }

        private void selectFileButton_Click(object sender, EventArgs e)
        {
            selectFileDialog.Multiselect = true;

            DialogResult drSelectFile = selectFileDialog.ShowDialog();
            if (drSelectFile != DialogResult.OK)
                return;

            foreach (var path in selectFileDialog.FileNames)
            {
                if (!elementsListBox.Items.Contains(path))
                {
                    //Add new file
                    SaveFile.Data.Elements.Add(new Element(path));
                    SaveFile.Save();

                    elementsListBox.Items.Add(path);
                    elementsListBox.SelectedIndex = elementsListBox.Items.Count - 1;
                }
                else
                    MessageBox.Show("Plik " + path + " został już wybrany.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void selectDirectoryButton_Click(object sender, EventArgs e)
        {
            DialogResult drSelectDirectory = selectDirectoryDialog.ShowDialog();
            if (drSelectDirectory != DialogResult.OK)
                return;

            if (!elementsListBox.Items.Contains(selectDirectoryDialog.SelectedPath))
            {
                //Add new directory
                SaveFile.Data.Elements.Add(new Element(selectDirectoryDialog.SelectedPath));
                SaveFile.Save();

                elementsListBox.Items.Add(selectDirectoryDialog.SelectedPath);
                elementsListBox.SelectedIndex = elementsListBox.Items.Count - 1;
            }
            else
                MessageBox.Show("Ten folder został już wybrany.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void selectAllButtton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < subelementsListBox.Items.Count; i++)
                subelementsListBox.SetItemChecked(i, true);
        }

        private void unsellectAllButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < subelementsListBox.Items.Count; i++)
                subelementsListBox.SetItemChecked(i, false);
        }

        private void makeCopyButton_Click(object sender, EventArgs e)
        {
            //Empty elements list
            if (elementsListBox.Items.Count == 0)
            {
                MessageBox.Show("Nie wybrano żadnego elementu.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ChangeFormState(false);

            MakeCopy();
        }

        private void fileCheckingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SaveFile.Data.IsCheckFileSize = checkFileSizeCheckBox.Checked;
            SaveFile.Save();
        }

        private void deleteAdditionalFileCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SaveFile.Data.IsDeleteAdditionalElements = deleteAdditionalFileCheckBox.Checked;
            SaveFile.Save();
        }

        private void whiteListCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SaveFile.Data.Elements.First(x => x.Path == selectedPath).IsWhiteList = whiteListCheckBox.Checked;
            SaveFile.Save();
        }

        private void elementsListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && elementsListBox.SelectedIndex != -1)
            {
                SaveFile.Data.Elements.Remove(SaveFile.Data.Elements.First(x => x.Path == selectedPath));
                SaveFile.Save();

                elementsListBox.Items.RemoveAt(elementsListBox.SelectedIndex);
            }
        }

        private void elementsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Clear subelements
            subelementsListBox.Items.Clear();
            currentSubelements.Clear();
            elementNotExistLabel.Visible = false;
            whiteListCheckBox.Enabled = false;

            if (elementsListBox.SelectedItem == null)
                return;

            selectedPath = elementsListBox.SelectedItem.ToString();

            //If element is file show nothing and if element doesn't exists show message
            if (elementsListBox.SelectedIndex == -1 || FileHelper.IsFile(selectedPath!) == 1)
                return;
            else if (FileHelper.IsFile(selectedPath!) == -1)
                elementNotExistLabel.Visible = true;
            else
            {
                whiteListCheckBox.Enabled = true;
                whiteListCheckBox.Checked = SaveFile.Data.Elements.First(x => x.Path == selectedPath).IsWhiteList;

                List<string> pathes =
                [
                    .. Directory.GetDirectories(selectedPath!),
                    .. Directory.GetFiles(selectedPath!)
                ];

                foreach (string path in pathes)
                {
                    currentSubelements.Add(path); //Full path
                    subelementsListBox.Items.Add(FileHelper.GetNameFromPath(path)); //Add only name

                    if (SaveFile.Data.Elements.First(x => x.Path == selectedPath).Subelements.Contains(path))
                        subelementsListBox.SetItemChecked(subelementsListBox.Items.Count - 1, true);
                    else
                        subelementsListBox.SetItemChecked(subelementsListBox.Items.Count - 1, false);
                }
            }
        }

        private void subelementsListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked && !SaveFile.Data.Elements.First(x => x.Path == selectedPath).Subelements.Contains(currentSubelements[e.Index].ToString()!))
            {
                SaveFile.Data.Elements.First(x => x.Path == selectedPath).Subelements.Add(currentSubelements[e.Index].ToString()!);
                SaveFile.Save();
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                SaveFile.Data.Elements.First(x => x.Path == selectedPath).Subelements.Remove(currentSubelements[e.Index].ToString()!);
                SaveFile.Save();
            }
        }
    }
}
