using BM_Core;
using BM_Core.Helpers;
using BM_Data;
using System.Diagnostics;

namespace BM_UI.Forms
{
    public partial class CopyForm : Form
    {
        private readonly List<Element> elements;
        private readonly int totalElements;
        private readonly long totalSize;

        private Thread? workThread;
        private CancellationTokenSource? tokenSource;

        public CopyForm(List<Element> elements, long totalSize, int totalElements)
        {
            InitializeComponent();

            this.elements = elements;
            this.totalSize = totalSize;
            this.totalElements = totalElements;

            string? copyDirectory = SaveFile.Data.CopyDirectory;
            if (copyDirectory != null) //If copy directory was saved
            {
                //Drive doesn't exists
                if (!DriveInfo.GetDrives().Where(x => x.Name[0] == copyDirectory[0]).Any() || !Directory.Exists(copyDirectory))
                {
                    SaveFile.Data.CopyDirectory = null;
                    SaveFile.Save();
                }
                else if (DriveHelper.GetFreeSpace(copyDirectory[0]) >= totalSize)
                    directoryPathLabel.Text = copyDirectory;
                else //Drive hasn't enough available space
                {
                    //Warn user
                    MessageBox.Show("Na ostatnio wybranym dysku nie ma miejsca na całkowicie nową kopie. Jeżeli ostatnia kopia jest dalej w tym miejscu i nowe pliki nie ważą więcej niż pozostałe miejsce to możesz kontynuować.", "Ostrzeżenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    directoryPathLabel.Text = copyDirectory;
                }
            }
        }

        private void ChangeFormState(bool isOn)
        {
            startButton.Enabled = isOn;
            cancelButton.Enabled = !isOn;
            filesProgressBar.Value = 0;
            filesProgressBar.Visible = !isOn;
            sizeProgressBar.Value = 0;
            sizeProgressBar.Visible = !isOn;
            sizeLabel.Visible = !isOn;
            sizeTextLabel.Visible = !isOn;
            filesCountLabel.Visible = !isOn;
            filesCountTextLabel.Visible = !isOn;
            selectDirectoryButton.Enabled = isOn;
            currentFileLabel.Visible = !isOn;
            currentFileTextLabel.Visible = !isOn;
        }

        private void MakeCopy()
        {
            tokenSource = new();
            CancellationToken token = tokenSource.Token;

            CopyWorker worker = new();
            Task workerTask = worker.Start(elements, directoryPathLabel.Text, token);

            //Update progress bars
            while (!workerTask.IsCompleted)
            {
                if (!worker.IsDeleting)
                {
                    BeginInvoke(() =>
                    {
                        sizeProgressBar.Value = (int)((float)worker.Size / totalSize * 1000);
                        filesProgressBar.Value = (int)((float)worker.Files / totalElements * 1000);
                        filesCountLabel.Text = worker.Files + " / " + totalElements;
                        sizeLabel.Text = worker.Size / 1000000 + "MB / " + totalSize / 1000000 + "MB";
                        currentFileLabel.Text = worker.CurrentFile;
                    });
                }
                else
                {
                    BeginInvoke(() =>
                    {
                        sizeProgressBar.Value = 1000;
                        filesProgressBar.Value = 1000;
                        filesCountTextLabel.Text = "";
                        filesCountLabel.Text = "";
                        currentFileLabel.Text = "";
                        currentFileTextLabel.Text = "";
                        sizeLabel.Text = "";
                        sizeTextLabel.Text = "Trwa usuwanie plików i katalogów nienależących do kopi zapasowej";
                    });
                }

                Thread.Sleep(10);
            }

            BeginInvoke(() => ChangeFormState(true));

            //When user cancel, don't message him about success
            if (!token.IsCancellationRequested)
            {
                MessageBox.Show("Utworzenie kopi przebiegło pomyślnie.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Start explorer with path
                Process explorer = new();
                ProcessStartInfo processStartInfo = new("explorer.exe", directoryPathLabel.Text);
                explorer.StartInfo = processStartInfo;
                explorer.Start();

                //Close this form after delay to wait to end this thread
                Task.Run(() =>
                {
                    Task.Delay(10);
                    BeginInvoke(Close);
                });
            }
        }

        private void selectDirectoryButton_Click(object sender, EventArgs e)
        {
            DialogResult drSelectDirectory = selectDirectoryDialog.ShowDialog();
            if (drSelectDirectory != DialogResult.OK)
                return;

            DirectoryInfo di = new(selectDirectoryDialog.SelectedPath);

            //Not enough free space
            if (DriveHelper.GetFreeSpace(di.FullName[0]) <= totalSize)
            {
                DialogResult dr = MessageBox.Show("Na ostatnio wybranym dysku nie ma miejsca na całkowicie nową kopie. Jeżeli ostatnia kopia jest dalej w tym miejscu i nowe pliki nie ważą więcej niż pozostałe miejsce to możesz kontynuować.", "Ostrzeżenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr != DialogResult.Yes)
                    return;
            }

            directoryPathLabel.Text = di.FullName;

            SaveFile.Data.CopyDirectory = di.FullName;
            SaveFile.Save();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (SaveFile.Data.CopyDirectory != null)
            {
                //Remove addtional elements warning
                DirectoryInfo di = new(SaveFile.Data.CopyDirectory);
                if ((di.GetFiles().Length != 0 || di.GetDirectories().Length != 0) && SaveFile.Data.IsDeleteAdditionalElements)
                {
                    DialogResult dr = MessageBox.Show("Wybrany folder nie jest pusty. Pliki i katalogi, które nie należą do kopi zostaną usuniętę. Czy chcesz kontynuować?", "Ostrzeżenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr != DialogResult.Yes)
                        return;
                }

                ChangeFormState(false);

                workThread = new(MakeCopy)
                {
                    IsBackground = true,
                    Name = "Copy worker"
                };

                workThread.Start();
            }
            else
                MessageBox.Show("Nie wybrano folderu docelowego.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            tokenSource?.Cancel();
            workThread?.Join();
        }

        private void CopyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (workThread != null && workThread.IsAlive)
            {
                //Make sure user want to close
                DialogResult dr = MessageBox.Show("Czy na pewno chcesz anulować wykonywanie kopi?", "Ostrzeżenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr != DialogResult.Yes)
                    e.Cancel = true;
                else
                    cancelButton_Click(sender, e);
            }
        }
    }
}
