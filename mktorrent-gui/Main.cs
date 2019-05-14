using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace mktorrent_gui
{
    public partial class Main : Form
    {
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
                isFile();
            }
            else if (Directory.Exists(txtSourcePath.Text))
            {
                if (chkSubItems.Checked)
                {
                    isFolder();
                }
                else
                {
                    isFile();
                }
            }
            else
            {
                MessageBox.Show(txtSourcePath.Text + " is not found", "Creating Torrent File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void isFolder()
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

        private void isFile()
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
            ProcessStartInfo cmdStartInfo = new ProcessStartInfo();
            cmdStartInfo.FileName = "mktorrent.exe";
            cmdStartInfo.RedirectStandardOutput = true;
            cmdStartInfo.RedirectStandardError = true;
            cmdStartInfo.RedirectStandardInput = true;
            cmdStartInfo.UseShellExecute = false;
            cmdStartInfo.CreateNoWindow = true;
            string arguments = "";

            foreach (string tracker in torrent.trackers.Split(','))
            {
                arguments += "-a " + tracker + " ";
            }

            if (torrent.comments.Trim(' ').Length > 0)
                arguments += "-c \"" + torrent.comments + "\" ";

            if (!torrent.date)
                arguments += "-d ";

            if (torrent.pieces > 0)
                arguments += "-l " + (torrent.pieces + 14) + " ";

            arguments += "-n \"" + torrent.name + "\" ";

            arguments += "-o \"" + torrent.destPath + "\" ";

            if (torrent.privateTorrent)
                arguments += "-p ";

            if (torrent.source.Trim(' ').Length > 0)
                arguments += "-s \"" + torrent.source + "\" ";

            if (torrent.webURLs.Trim(' ').Length > 0)
                arguments += "-w " + torrent.webURLs;

            arguments += " \"" + torrent.sourcePath + "\"";

            cmdStartInfo.Arguments = arguments;
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
            TorrentInfo torrent = (TorrentInfo)e.Argument;

            string destPath = (torrent.destPath.EndsWith("\\")) ? torrent.destPath : (torrent.destPath + "\\");

            if (torrent.subItems)
            {
                string[] dirs = Directory.GetDirectories(torrent.sourcePath);
                string[] fi = Directory.GetFiles(torrent.sourcePath);
                int count = 0;
                int total = dirs.Length + fi.Length;

                foreach (string s in dirs)
                {
                    count++;
                    backgroundWorker.ReportProgress(0, count + " / " + total);
                    torrent.sourcePath = s;
                    torrent.name = Path.GetFileName(s);
                    torrent.destPath = destPath + Path.GetFileName(s) + ".torrent";
                    mktorrent(torrent);
                }

                foreach (string s in fi)
                {
                    count++;
                    backgroundWorker.ReportProgress(0, count + " / " + total);
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

        private void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            lblNodes.Text = e.UserState.ToString();
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

    }
}
