namespace ClipboardBasket
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lstHistory = new System.Windows.Forms.ListBox();
            this.rtbView = new System.Windows.Forms.RichTextBox();
            this.picView = new System.Windows.Forms.PictureBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.notifier = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctxMnu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsViewBasket = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.chkDisableNotifications = new System.Windows.Forms.CheckBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.lblPageNo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPageCount = new System.Windows.Forms.Label();
            this.btnShowDatabase = new System.Windows.Forms.Button();
            this.chkStartWithWindows = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picView)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.ctxMnu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstHistory
            // 
            this.lstHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstHistory.FormattingEnabled = true;
            this.lstHistory.Location = new System.Drawing.Point(12, 36);
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.Size = new System.Drawing.Size(218, 342);
            this.lstHistory.TabIndex = 1;
            this.lstHistory.SelectedIndexChanged += new System.EventHandler(this.lstHistory_SelectedIndexChanged);
            this.lstHistory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstHistory_MouseDoubleClick);
            // 
            // rtbView
            // 
            this.rtbView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbView.Location = new System.Drawing.Point(237, 13);
            this.rtbView.Name = "rtbView";
            this.rtbView.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.rtbView.Size = new System.Drawing.Size(590, 367);
            this.rtbView.TabIndex = 2;
            this.rtbView.Text = "";
            // 
            // picView
            // 
            this.picView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picView.Location = new System.Drawing.Point(237, 13);
            this.picView.Name = "picView";
            this.picView.Size = new System.Drawing.Size(590, 367);
            this.picView.TabIndex = 4;
            this.picView.TabStop = false;
            this.picView.Visible = false;
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopy.Location = new System.Drawing.Point(311, 391);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(74, 28);
            this.btnCopy.TabIndex = 8;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(385, 391);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(74, 28);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 445);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(839, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(48, 17);
            this.lblStatus.Text = "Ready...";
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteAll.Location = new System.Drawing.Point(459, 391);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(74, 28);
            this.btnDeleteAll.TabIndex = 10;
            this.btnDeleteAll.Text = "Delete All";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // notifier
            // 
            this.notifier.ContextMenuStrip = this.ctxMnu;
            this.notifier.Icon = ((System.Drawing.Icon)(resources.GetObject("notifier.Icon")));
            this.notifier.Text = "Clipboard Basket";
            this.notifier.Visible = true;
            this.notifier.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifier_MouseDoubleClick);
            // 
            // ctxMnu
            // 
            this.ctxMnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsViewBasket,
            this.toolStripMenuItem1,
            this.tsStatistics,
            this.toolStripMenuItem3,
            this.tsAbout,
            this.exitToolStripMenuItem1,
            this.tsExit});
            this.ctxMnu.Name = "ctxMnu";
            this.ctxMnu.Size = new System.Drawing.Size(153, 110);
            // 
            // tsViewBasket
            // 
            this.tsViewBasket.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsViewBasket.Name = "tsViewBasket";
            this.tsViewBasket.Size = new System.Drawing.Size(152, 22);
            this.tsViewBasket.Text = "View Basket...";
            this.tsViewBasket.Click += new System.EventHandler(this.tsViewBasket_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // tsStatistics
            // 
            this.tsStatistics.Name = "tsStatistics";
            this.tsStatistics.Size = new System.Drawing.Size(152, 22);
            this.tsStatistics.Text = "Statistics...";
            this.tsStatistics.Click += new System.EventHandler(this.tsStatistics_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(149, 6);
            // 
            // tsAbout
            // 
            this.tsAbout.Name = "tsAbout";
            this.tsAbout.Size = new System.Drawing.Size(152, 22);
            this.tsAbout.Text = "About...";
            this.tsAbout.Click += new System.EventHandler(this.tsAbout_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // tsExit
            // 
            this.tsExit.Name = "tsExit";
            this.tsExit.Size = new System.Drawing.Size(152, 22);
            this.tsExit.Text = "Exit";
            this.tsExit.Click += new System.EventHandler(this.tsExit_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(12, 13);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(218, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "Search...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // chkDisableNotifications
            // 
            this.chkDisableNotifications.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDisableNotifications.AutoSize = true;
            this.chkDisableNotifications.Location = new System.Drawing.Point(705, 396);
            this.chkDisableNotifications.Name = "chkDisableNotifications";
            this.chkDisableNotifications.Size = new System.Drawing.Size(122, 17);
            this.chkDisableNotifications.TabIndex = 12;
            this.chkDisableNotifications.Text = "Disable Notifications";
            this.chkDisableNotifications.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdate.Location = new System.Drawing.Point(237, 391);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(74, 28);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFirst.Location = new System.Drawing.Point(9, 393);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(36, 23);
            this.btnFirst.TabIndex = 3;
            this.btnFirst.Text = "|<";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrevious.Location = new System.Drawing.Point(51, 393);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(36, 23);
            this.btnPrevious.TabIndex = 4;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNext.Location = new System.Drawing.Point(153, 393);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(36, 23);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLast.Location = new System.Drawing.Point(195, 393);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(36, 23);
            this.btnLast.TabIndex = 6;
            this.btnLast.Text = ">|";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // lblPageNo
            // 
            this.lblPageNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPageNo.AutoSize = true;
            this.lblPageNo.Location = new System.Drawing.Point(96, 398);
            this.lblPageNo.Name = "lblPageNo";
            this.lblPageNo.Size = new System.Drawing.Size(17, 13);
            this.lblPageNo.TabIndex = 10;
            this.lblPageNo.Text = "xx";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 398);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "/";
            // 
            // lblPageCount
            // 
            this.lblPageCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPageCount.AutoSize = true;
            this.lblPageCount.Location = new System.Drawing.Point(128, 398);
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.Size = new System.Drawing.Size(17, 13);
            this.lblPageCount.TabIndex = 10;
            this.lblPageCount.Text = "xx";
            // 
            // btnShowDatabase
            // 
            this.btnShowDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnShowDatabase.Location = new System.Drawing.Point(533, 391);
            this.btnShowDatabase.Name = "btnShowDatabase";
            this.btnShowDatabase.Size = new System.Drawing.Size(102, 28);
            this.btnShowDatabase.TabIndex = 11;
            this.btnShowDatabase.Text = "Show Database";
            this.btnShowDatabase.UseVisualStyleBackColor = true;
            this.btnShowDatabase.Click += new System.EventHandler(this.btnShowDatabase_Click);
            // 
            // chkStartWithWindows
            // 
            this.chkStartWithWindows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkStartWithWindows.AutoSize = true;
            this.chkStartWithWindows.Location = new System.Drawing.Point(705, 419);
            this.chkStartWithWindows.Name = "chkStartWithWindows";
            this.chkStartWithWindows.Size = new System.Drawing.Size(117, 17);
            this.chkStartWithWindows.TabIndex = 12;
            this.chkStartWithWindows.Text = "Start with Windows";
            this.chkStartWithWindows.UseVisualStyleBackColor = true;
            this.chkStartWithWindows.CheckedChanged += new System.EventHandler(this.chkStartWithWindows_CheckedChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 467);
            this.Controls.Add(this.btnShowDatabase);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPageCount);
            this.Controls.Add(this.lblPageNo);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.chkStartWithWindows);
            this.Controls.Add(this.chkDisableNotifications);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.rtbView);
            this.Controls.Add(this.lstHistory);
            this.Controls.Add(this.picView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clipboard Basket";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picView)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ctxMnu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lstHistory;
        private System.Windows.Forms.RichTextBox rtbView;
        private System.Windows.Forms.PictureBox picView;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.NotifyIcon notifier;
        private System.Windows.Forms.ContextMenuStrip ctxMnu;
        private System.Windows.Forms.ToolStripMenuItem tsViewBasket;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsAbout;
        private System.Windows.Forms.ToolStripSeparator exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsExit;
        private System.Windows.Forms.ToolStripMenuItem tsStatistics;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.CheckBox chkDisableNotifications;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Label lblPageNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPageCount;
        private System.Windows.Forms.Button btnShowDatabase;
        private System.Windows.Forms.CheckBox chkStartWithWindows;
    }
}

