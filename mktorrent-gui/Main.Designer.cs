namespace mktorrent_gui
{
    partial class Main
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
            this.cmbxPieceSize = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSourcePath = new System.Windows.Forms.TextBox();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.chkSubItems = new System.Windows.Forms.CheckBox();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.chkPrivate = new System.Windows.Forms.CheckBox();
            this.txtTracker = new System.Windows.Forms.RichTextBox();
            this.txtWeb = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radFolder = new System.Windows.Forms.RadioButton();
            this.radFile = new System.Windows.Forms.RadioButton();
            this.btnBrowseSource = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCreate = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNodes = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbxPieceSize
            // 
            this.cmbxPieceSize.FormattingEnabled = true;
            this.cmbxPieceSize.Items.AddRange(new object[] {
            "Auto",
            "32 KiB",
            "64 KiB",
            "128 KiB",
            "256 KiB",
            "512 KiB",
            "1 MiB",
            "2 MiB",
            "4 MiB",
            "8 MiB",
            "16 MiB",
            "32 MiB",
            "64 MiB",
            "128 MiB",
            "256 MiB"});
            this.cmbxPieceSize.Location = new System.Drawing.Point(105, 31);
            this.cmbxPieceSize.Name = "cmbxPieceSize";
            this.cmbxPieceSize.Size = new System.Drawing.Size(125, 21);
            this.cmbxPieceSize.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Source Path:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Piece Size:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Tracker URLs:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 239);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "Web URLs:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 320);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 38;
            this.label11.Text = "Comment:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 362);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 39;
            this.label12.Text = "Source:";
            // 
            // txtSourcePath
            // 
            this.txtSourcePath.Location = new System.Drawing.Point(102, 18);
            this.txtSourcePath.Name = "txtSourcePath";
            this.txtSourcePath.Size = new System.Drawing.Size(211, 20);
            this.txtSourcePath.TabIndex = 10;
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(105, 360);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(250, 20);
            this.txtSource.TabIndex = 24;
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(105, 318);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(250, 20);
            this.txtComment.TabIndex = 22;
            // 
            // chkSubItems
            // 
            this.chkSubItems.AutoSize = true;
            this.chkSubItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSubItems.Location = new System.Drawing.Point(269, 56);
            this.chkSubItems.Name = "chkSubItems";
            this.chkSubItems.Size = new System.Drawing.Size(95, 17);
            this.chkSubItems.TabIndex = 12;
            this.chkSubItems.Text = "Use Sub Items";
            this.chkSubItems.UseVisualStyleBackColor = true;
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Location = new System.Drawing.Point(242, 34);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(119, 17);
            this.chkDate.TabIndex = 16;
            this.chkDate.Text = "Store Creation Date";
            this.chkDate.UseVisualStyleBackColor = true;
            // 
            // chkPrivate
            // 
            this.chkPrivate.AutoSize = true;
            this.chkPrivate.Location = new System.Drawing.Point(128, 408);
            this.chkPrivate.Name = "chkPrivate";
            this.chkPrivate.Size = new System.Drawing.Size(96, 17);
            this.chkPrivate.TabIndex = 28;
            this.chkPrivate.Text = "Private Torrent";
            this.chkPrivate.UseVisualStyleBackColor = true;
            // 
            // txtTracker
            // 
            this.txtTracker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTracker.Location = new System.Drawing.Point(106, 74);
            this.txtTracker.Name = "txtTracker";
            this.txtTracker.Size = new System.Drawing.Size(248, 100);
            this.txtTracker.TabIndex = 18;
            this.txtTracker.Text = "";
            // 
            // txtWeb
            // 
            this.txtWeb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWeb.Location = new System.Drawing.Point(106, 196);
            this.txtWeb.Name = "txtWeb";
            this.txtWeb.Size = new System.Drawing.Size(248, 100);
            this.txtWeb.TabIndex = 20;
            this.txtWeb.Text = "";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.radFolder);
            this.panel1.Controls.Add(this.radFile);
            this.panel1.Controls.Add(this.btnBrowseSource);
            this.panel1.Controls.Add(this.txtSourcePath);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.chkSubItems);
            this.panel1.Location = new System.Drawing.Point(15, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 90);
            this.panel1.TabIndex = 41;
            // 
            // radFolder
            // 
            this.radFolder.AutoSize = true;
            this.radFolder.Location = new System.Drawing.Point(178, 55);
            this.radFolder.Name = "radFolder";
            this.radFolder.Size = new System.Drawing.Size(87, 17);
            this.radFolder.TabIndex = 36;
            this.radFolder.Text = "Select Folder";
            this.radFolder.UseVisualStyleBackColor = true;
            // 
            // radFile
            // 
            this.radFile.AutoSize = true;
            this.radFile.Checked = true;
            this.radFile.Location = new System.Drawing.Point(100, 55);
            this.radFile.Name = "radFile";
            this.radFile.Size = new System.Drawing.Size(74, 17);
            this.radFile.TabIndex = 35;
            this.radFile.TabStop = true;
            this.radFile.Text = "Select File";
            this.radFile.UseVisualStyleBackColor = true;
            // 
            // btnBrowseSource
            // 
            this.btnBrowseSource.Location = new System.Drawing.Point(319, 17);
            this.btnBrowseSource.Name = "btnBrowseSource";
            this.btnBrowseSource.Size = new System.Drawing.Size(30, 22);
            this.btnBrowseSource.TabIndex = 11;
            this.btnBrowseSource.Text = "..";
            this.btnBrowseSource.UseVisualStyleBackColor = true;
            this.btnBrowseSource.Click += new System.EventHandler(this.btnBrowseSource_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnCreate);
            this.panel2.Controls.Add(this.txtSource);
            this.panel2.Controls.Add(this.txtWeb);
            this.panel2.Controls.Add(this.cmbxPieceSize);
            this.panel2.Controls.Add(this.txtTracker);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.chkPrivate);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.chkDate);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtComment);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Location = new System.Drawing.Point(15, 115);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(375, 450);
            this.panel2.TabIndex = 42;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(230, 402);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(125, 28);
            this.btnCreate.TabIndex = 30;
            this.btnCreate.Text = "Create Torrent(s)";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.AutoSize = false;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblNodes});
            this.statusStrip.Location = new System.Drawing.Point(0, 587);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(404, 24);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 44;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = false;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(220, 19);
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNodes
            // 
            this.lblNodes.AutoSize = false;
            this.lblNodes.Name = "lblNodes";
            this.lblNodes.Size = new System.Drawing.Size(160, 19);
            this.lblNodes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 611);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.Text = "Create Torrent";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbxPieceSize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSourcePath;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.CheckBox chkSubItems;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.CheckBox chkPrivate;
        private System.Windows.Forms.RichTextBox txtTracker;
        private System.Windows.Forms.RichTextBox txtWeb;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnBrowseSource;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblNodes;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.RadioButton radFolder;
        private System.Windows.Forms.RadioButton radFile;
    }
}

