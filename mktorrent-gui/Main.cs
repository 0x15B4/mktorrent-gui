using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace mktorrent_gui
{
    public partial class Main : Form
    {
        private int total;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            cmbxPieceSize.SelectedIndex = 0;
        }

        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            if (radFolder.Checked)
            {
                CommonOpenFileDialog theDialog = new CommonOpenFileDialog();
                theDialog.IsFolderPicker = true;
                if (theDialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    try
                    {
                        txtSourcePath.Text = theDialog.FileName;
                        if (!chkSubItems.Checked)
                        {
                            lblPieces.Text = calculatePieces(txtSourcePath.Text) + " pieces";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Select Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (radFile.Checked)
            {
                OpenFileDialog theDialog = new OpenFileDialog();
                theDialog.Title = "Select File";
                theDialog.Filter = "All Files (*.*)|*.*";
                if (theDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        txtSourcePath.Text = theDialog.FileName;
                        lblPieces.Text = calculatePieces(txtSourcePath.Text) + " pieces";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Select File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (getTrackers().Length < 1)
            {
                MessageBox.Show("Tracker List is empty. Please add trackers.", "Creating Torrent File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (File.Exists(txtSourcePath.Text))
            {
                isAFile();
            }
            else if (Directory.Exists(txtSourcePath.Text))
            {
                if (chkSubItems.Checked)
                {
                    isAFolder();
                }
                else
                {
                    isAFile();
                }
            }
            else
            {
                MessageBox.Show(txtSourcePath.Text + " is not found", "Creating Torrent File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void isAFolder()
        {
            CommonOpenFileDialog theDialog = new CommonOpenFileDialog();
            theDialog.IsFolderPicker = true;
            if (theDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                btnCreate.Enabled = false;
                backgroundWorker.RunWorkerAsync(new TorrentInfo(txtSourcePath.Text,
                    theDialog.FileName,
                    getTrackers(),
                    getWebURLs(),
                    txtComment.Text,
                    txtSource.Text,
                    Path.GetFileName(txtSourcePath.Text),
                    cmbxPieceSize.SelectedIndex,
                    chkPrivate.Checked,
                    chkDate.Checked,
                    chkSubItems.Checked));
            }
        }

        private void isAFile()
        {
            SaveFileDialog theDialog = new SaveFileDialog();
            theDialog.Title = "Create Torrent";
            theDialog.Filter = "Torrent Files (*.torrent)|*.torrent|All Files (*.*)|*.*";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                btnCreate.Enabled = false;
                lblNodes.Text = "1 / 1";
                backgroundWorker.RunWorkerAsync(new TorrentInfo(txtSourcePath.Text,
                    theDialog.FileName,
                    getTrackers(),
                    getWebURLs(),
                    txtComment.Text,
                    txtSource.Text,
                    Path.GetFileName(txtSourcePath.Text),
                    cmbxPieceSize.SelectedIndex,
                    chkPrivate.Checked,
                    chkDate.Checked,
                    false));
            }
        }

        private void mktorrent(TorrentInfo torrent)
        {
            if (File.Exists("mktorrent.exe"))
            {
                ProcessStartInfo cmdStartInfo = new ProcessStartInfo();
                StringBuilder arguments = new StringBuilder();

                cmdStartInfo.FileName = "mktorrent.exe";
                cmdStartInfo.RedirectStandardOutput = true;
                cmdStartInfo.RedirectStandardError = true;
                cmdStartInfo.RedirectStandardInput = true;
                cmdStartInfo.UseShellExecute = false;
                cmdStartInfo.CreateNoWindow = true;

                foreach (string tracker in torrent.trackers.Split(','))
                {
                    arguments.Append("-a ");
                    arguments.Append(tracker);
                    arguments.Append(" ");
                }

                if (torrent.comments.Trim(' ').Length > 0)
                {
                    arguments.Append("-c \"");
                    arguments.Append(torrent.comments);
                    arguments.Append("\" ");
                }

                if (!torrent.date)
                {
                    arguments.Append("-d ");
                }

                if (torrent.pieces > 0)
                {
                    arguments.Append("-l ");
                    arguments.Append(torrent.pieces + 14);
                    arguments.Append(" ");
                }

                arguments.Append("-n \"");
                arguments.Append(torrent.name);
                arguments.Append("\" ");

                arguments.Append("-o \"");
                arguments.Append(torrent.destPath);
                arguments.Append("\" ");

                if (torrent.privateTorrent)
                {
                    arguments.Append("-p ");
                }

                if (torrent.source.Trim(' ').Length > 0)
                {
                    arguments.Append("-s \"");
                    arguments.Append(torrent.source);
                    arguments.Append("\" ");
                }

                if (torrent.webURLs.Trim(' ').Length > 0)
                {
                    arguments.Append("-w ");
                    arguments.Append(torrent.webURLs);
                }

                arguments.Append(" \"");
                arguments.Append(torrent.sourcePath);
                arguments.Append("\"");

                cmdStartInfo.Arguments = arguments.ToString();

                Process cmdProcess = new Process();
                cmdProcess.StartInfo = cmdStartInfo;
                cmdProcess.ErrorDataReceived += cmd_Error;
                cmdProcess.OutputDataReceived += new DataReceivedEventHandler(cmd_DataReceived);
                cmdProcess.EnableRaisingEvents = true;
                cmdProcess.Start();
                cmdProcess.BeginOutputReadLine();
                cmdProcess.BeginErrorReadLine();
                cmdProcess.WaitForExit();
            }
            else
            {
                throw new FileNotFoundException("mktorrent.exe is missing");
            }
        }

        private void cmd_DataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null && e.Data.StartsWith("Hashed"))
            {
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    lblStatus.Text = "  " + e.Data;
                }));
            }
        }

        private void cmd_Error(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                MessageBox.Show(e.Data, "Creating Torrent File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                TorrentInfo torrent = (TorrentInfo)e.Argument;

                string destPath = (torrent.destPath.EndsWith("\\")) ? torrent.destPath : (torrent.destPath + "\\");

                if (torrent.subItems)
                {
                    string[] dirs = Directory.GetDirectories(torrent.sourcePath);
                    string[] fi = Directory.GetFiles(torrent.sourcePath);
                    int count = 0;
                    total = dirs.Length + fi.Length;

                    foreach (string s in dirs)
                    {
                        count++;
                        backgroundWorker.ReportProgress(count);
                        torrent.sourcePath = s;
                        torrent.name = Path.GetFileName(s);
                        torrent.destPath = destPath + Path.GetFileName(s) + ".torrent";
                        mktorrent(torrent);
                    }

                    foreach (string s in fi)
                    {
                        count++;
                        backgroundWorker.ReportProgress(count);
                        torrent.sourcePath = s;
                        torrent.name = Path.GetFileName(s);
                        torrent.destPath = destPath + Path.GetFileName(s) + ".torrent";
                        mktorrent(torrent);
                    }
                }
                else
                {
                    mktorrent(torrent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Creating Torrent File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            lblNodes.Text = e.ProgressPercentage + " / " + total;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            btnCreate.Enabled = true;
            lblStatus.Text = "  Completed";
        }

        private string getTrackers()
        {
            string result = "";

            foreach (string line in txtTracker.Lines)
            {
                if (line.Trim(' ').Length > 0)
                    result += line.Trim(' ') + ",";
            }

            if (result.Length > 0)
                result = result.Remove(result.Length - 1, 1);

            return result;
        }

        private string getWebURLs()
        {
            string result = "";

            foreach (string line in txtWeb.Lines)
            {
                if (line.Trim(' ').Length > 0)
                    result += line.Trim(' ') + ",";
            }

            if (result.Length > 0)
                result = result.Remove(result.Length - 1, 1);

            return result;
        }

        private int calculatePieces(string path)
        {
            double pieceSize = (cmbxPieceSize.SelectedIndex == 0) ? Math.Pow(2, 18) : Math.Pow(2, cmbxPieceSize.SelectedIndex + 14);
            if (Directory.Exists(path))
            {
                DirectoryInfo di = new DirectoryInfo(path);
                double totalSize = 0;

                foreach (FileInfo fi in di.GetFiles("*", SearchOption.AllDirectories))
                {
                    totalSize += fi.Length;
                }
                return (int)Math.Ceiling(totalSize / pieceSize);
            }
            else if (File.Exists(path))
            {
                FileInfo fi = new FileInfo(path);
                return (int)Math.Ceiling(fi.Length / pieceSize);
            }

            return 0;
        }

        private void cmbxPieceSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!chkSubItems.Checked)
            {
                lblPieces.Text = calculatePieces(txtSourcePath.Text) + " pieces";
            }
        }
    }
}
