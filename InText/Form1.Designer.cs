namespace InText
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
            this.cbDirectory = new System.Windows.Forms.ComboBox();
            this.lblSelect = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.lbResults = new System.Windows.Forms.ListBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSelectDirectory = new System.Windows.Forms.Button();
            this.pbSearchProgress = new System.Windows.Forms.ProgressBar();
            this.btnParallelSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbDirectory
            // 
            this.cbDirectory.FormattingEnabled = true;
            this.cbDirectory.Location = new System.Drawing.Point(98, 36);
            this.cbDirectory.Name = "cbDirectory";
            this.cbDirectory.Size = new System.Drawing.Size(102, 21);
            this.cbDirectory.TabIndex = 13;
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Location = new System.Drawing.Point(9, 40);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(82, 13);
            this.lblSelect.TabIndex = 12;
            this.lblSelect.Text = "Select Directory";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(437, 399);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(93, 23);
            this.btnStop.TabIndex = 11;
            this.btnStop.Text = "Stop Searching";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lbResults
            // 
            this.lbResults.FormattingEnabled = true;
            this.lbResults.HorizontalExtent = 1;
            this.lbResults.HorizontalScrollbar = true;
            this.lbResults.Location = new System.Drawing.Point(12, 65);
            this.lbResults.Name = "lbResults";
            this.lbResults.Size = new System.Drawing.Size(518, 329);
            this.lbResults.TabIndex = 10;
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(206, 6);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(95, 23);
            this.btSearch.TabIndex = 9;
            this.btSearch.Text = "Search";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(98, 8);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(102, 20);
            this.txtSearch.TabIndex = 8;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(9, 11);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(71, 13);
            this.lblSearch.TabIndex = 7;
            this.lblSearch.Text = "Search String";
            // 
            // btnSelectDirectory
            // 
            this.btnSelectDirectory.Location = new System.Drawing.Point(206, 34);
            this.btnSelectDirectory.Name = "btnSelectDirectory";
            this.btnSelectDirectory.Size = new System.Drawing.Size(95, 23);
            this.btnSelectDirectory.TabIndex = 14;
            this.btnSelectDirectory.Text = "Select Directory";
            this.btnSelectDirectory.UseVisualStyleBackColor = true;
            this.btnSelectDirectory.Click += new System.EventHandler(this.btnSelectDirectory_Click);
            // 
            // pbSearchProgress
            // 
            this.pbSearchProgress.Location = new System.Drawing.Point(13, 399);
            this.pbSearchProgress.Name = "pbSearchProgress";
            this.pbSearchProgress.Size = new System.Drawing.Size(418, 23);
            this.pbSearchProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbSearchProgress.TabIndex = 15;
            // 
            // btnParallelSearch
            // 
            this.btnParallelSearch.Location = new System.Drawing.Point(308, 6);
            this.btnParallelSearch.Name = "btnParallelSearch";
            this.btnParallelSearch.Size = new System.Drawing.Size(87, 23);
            this.btnParallelSearch.TabIndex = 16;
            this.btnParallelSearch.Text = "Parallel Search";
            this.btnParallelSearch.UseVisualStyleBackColor = true;
            this.btnParallelSearch.Click += new System.EventHandler(this.btnParallelSearch_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 431);
            this.Controls.Add(this.btnParallelSearch);
            this.Controls.Add(this.pbSearchProgress);
            this.Controls.Add(this.btnSelectDirectory);
            this.Controls.Add(this.cbDirectory);
            this.Controls.Add(this.lblSelect);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lbResults);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Name = "frmMain";
            this.Text = "Search in Files";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDirectory;
        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ListBox lbResults;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button btnSelectDirectory;
        private System.Windows.Forms.ProgressBar pbSearchProgress;
        private System.Windows.Forms.Button btnParallelSearch;
    }
}

