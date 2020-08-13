namespace DeZipper
{
    partial class DeZipperForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeZipperForm));
            this.deleteButton = new System.Windows.Forms.Button();
            this.zipEntryTreeView = new System.Windows.Forms.TreeView();
            this.optionPanel = new System.Windows.Forms.Panel();
            this.toRecycleBin = new System.Windows.Forms.CheckBox();
            this.deleteSourceZipFile = new System.Windows.Forms.CheckBox();
            this.deleteEmptyDirectory = new System.Windows.Forms.CheckBox();
            this.excludeButton = new System.Windows.Forms.Button();
            this.tgPath = new System.Windows.Forms.TextBox();
            this.zipPath = new System.Windows.Forms.TextBox();
            this.zipPathButton = new System.Windows.Forms.Button();
            this.fileImageList = new System.Windows.Forms.ImageList(this.components);
            this.targetPathButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.targetPathPanel = new System.Windows.Forms.Panel();
            this.zipPathPanel = new System.Windows.Forms.Panel();
            this.executionPanel = new System.Windows.Forms.Panel();
            this.treeViewCount = new System.Windows.Forms.Label();
            this.zipOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.optionPanel.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.targetPathPanel.SuspendLayout();
            this.zipPathPanel.SuspendLayout();
            this.executionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Verdana", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Location = new System.Drawing.Point(8, 176);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(184, 55);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "DELETE";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // zipEntryTreeView
            // 
            this.zipEntryTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zipEntryTreeView.Location = new System.Drawing.Point(203, 67);
            this.zipEntryTreeView.Name = "zipEntryTreeView";
            this.zipEntryTreeView.Size = new System.Drawing.Size(422, 469);
            this.zipEntryTreeView.TabIndex = 3;
            this.zipEntryTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.zipEntryTreeView_AfterSelect);
            // 
            // optionPanel
            // 
            this.optionPanel.Controls.Add(this.toRecycleBin);
            this.optionPanel.Controls.Add(this.deleteSourceZipFile);
            this.optionPanel.Controls.Add(this.deleteEmptyDirectory);
            this.optionPanel.Location = new System.Drawing.Point(8, 80);
            this.optionPanel.Name = "optionPanel";
            this.optionPanel.Size = new System.Drawing.Size(184, 92);
            this.optionPanel.TabIndex = 2;
            // 
            // toRecycleBin
            // 
            this.toRecycleBin.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toRecycleBin.Location = new System.Drawing.Point(16, 64);
            this.toRecycleBin.Name = "toRecycleBin";
            this.toRecycleBin.Size = new System.Drawing.Size(168, 32);
            this.toRecycleBin.TabIndex = 3;
            this.toRecycleBin.Text = "휴지통(미구현)";
            this.toRecycleBin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toRecycleBin.UseVisualStyleBackColor = true;
            // 
            // deleteSourceZipFile
            // 
            this.deleteSourceZipFile.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deleteSourceZipFile.Location = new System.Drawing.Point(16, 32);
            this.deleteSourceZipFile.Name = "deleteSourceZipFile";
            this.deleteSourceZipFile.Size = new System.Drawing.Size(168, 32);
            this.deleteSourceZipFile.TabIndex = 2;
            this.deleteSourceZipFile.Text = "원본 zip 파일 삭제";
            this.deleteSourceZipFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deleteSourceZipFile.UseVisualStyleBackColor = true;
            // 
            // deleteEmptyDirectory
            // 
            this.deleteEmptyDirectory.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deleteEmptyDirectory.Location = new System.Drawing.Point(16, 0);
            this.deleteEmptyDirectory.Name = "deleteEmptyDirectory";
            this.deleteEmptyDirectory.Size = new System.Drawing.Size(168, 32);
            this.deleteEmptyDirectory.TabIndex = 1;
            this.deleteEmptyDirectory.Text = "빈 폴더 삭제";
            this.deleteEmptyDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deleteEmptyDirectory.UseVisualStyleBackColor = true;
            // 
            // excludeButton
            // 
            this.excludeButton.Enabled = false;
            this.excludeButton.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.excludeButton.Location = new System.Drawing.Point(8, 16);
            this.excludeButton.Name = "excludeButton";
            this.excludeButton.Size = new System.Drawing.Size(184, 55);
            this.excludeButton.TabIndex = 1;
            this.excludeButton.Text = "선택 파일 제외";
            this.excludeButton.UseVisualStyleBackColor = true;
            this.excludeButton.Click += new System.EventHandler(this.excludeButton_Click);
            // 
            // tgPath
            // 
            this.tgPath.AllowDrop = true;
            this.tgPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tgPath.Location = new System.Drawing.Point(0, 0);
            this.tgPath.Name = "tgPath";
            this.tgPath.Size = new System.Drawing.Size(387, 25);
            this.tgPath.TabIndex = 4;
            // 
            // zipPath
            // 
            this.zipPath.AllowDrop = true;
            this.zipPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.zipPath.Location = new System.Drawing.Point(0, 0);
            this.zipPath.Name = "zipPath";
            this.zipPath.Size = new System.Drawing.Size(387, 25);
            this.zipPath.TabIndex = 5;
            this.zipPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.zipPath_KeyDown);
            // 
            // zipPathButton
            // 
            this.zipPathButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.zipPathButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.zipPathButton.FlatAppearance.BorderSize = 0;
            this.zipPathButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zipPathButton.ImageIndex = 0;
            this.zipPathButton.ImageList = this.fileImageList;
            this.zipPathButton.Location = new System.Drawing.Point(387, 1);
            this.zipPathButton.Name = "zipPathButton";
            this.zipPathButton.Size = new System.Drawing.Size(25, 23);
            this.zipPathButton.TabIndex = 6;
            this.zipPathButton.UseVisualStyleBackColor = true;
            this.zipPathButton.Click += new System.EventHandler(this.zipPathButton_Click);
            // 
            // fileImageList
            // 
            this.fileImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("fileImageList.ImageStream")));
            this.fileImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.fileImageList.Images.SetKeyName(0, "zip_placeholder.ico");
            this.fileImageList.Images.SetKeyName(1, "folder_placeholder.ico");
            // 
            // targetPathButton
            // 
            this.targetPathButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.targetPathButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.targetPathButton.FlatAppearance.BorderSize = 0;
            this.targetPathButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.targetPathButton.ImageIndex = 1;
            this.targetPathButton.ImageList = this.fileImageList;
            this.targetPathButton.Location = new System.Drawing.Point(387, 1);
            this.targetPathButton.Name = "targetPathButton";
            this.targetPathButton.Size = new System.Drawing.Size(25, 23);
            this.targetPathButton.TabIndex = 7;
            this.targetPathButton.UseVisualStyleBackColor = true;
            this.targetPathButton.Click += new System.EventHandler(this.targetPathButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(69, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 32);
            this.label1.TabIndex = 8;
            this.label1.Text = "Zip File :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(69, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 32);
            this.label2.TabIndex = 9;
            this.label2.Text = "Target Directory :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.targetPathPanel, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.zipEntryTreeView, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.zipPathPanel, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.executionPanel, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.treeViewCount, 1, 3);
            this.tableLayoutPanel.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(628, 565);
            this.tableLayoutPanel.TabIndex = 10;
            // 
            // targetPathPanel
            // 
            this.targetPathPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.targetPathPanel.Controls.Add(this.tgPath);
            this.targetPathPanel.Controls.Add(this.targetPathButton);
            this.targetPathPanel.Location = new System.Drawing.Point(203, 35);
            this.targetPathPanel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.targetPathPanel.Name = "targetPathPanel";
            this.targetPathPanel.Size = new System.Drawing.Size(425, 26);
            this.targetPathPanel.TabIndex = 2;
            // 
            // zipPathPanel
            // 
            this.zipPathPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zipPathPanel.Controls.Add(this.zipPath);
            this.zipPathPanel.Controls.Add(this.zipPathButton);
            this.zipPathPanel.Location = new System.Drawing.Point(203, 3);
            this.zipPathPanel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.zipPathPanel.Name = "zipPathPanel";
            this.zipPathPanel.Size = new System.Drawing.Size(425, 26);
            this.zipPathPanel.TabIndex = 1;
            // 
            // executionPanel
            // 
            this.executionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.executionPanel.Controls.Add(this.excludeButton);
            this.executionPanel.Controls.Add(this.optionPanel);
            this.executionPanel.Controls.Add(this.deleteButton);
            this.executionPanel.Location = new System.Drawing.Point(3, 303);
            this.executionPanel.Name = "executionPanel";
            this.executionPanel.Size = new System.Drawing.Size(194, 233);
            this.executionPanel.TabIndex = 4;
            // 
            // treeViewCount
            // 
            this.treeViewCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewCount.Font = new System.Drawing.Font("굴림", 11F);
            this.treeViewCount.Location = new System.Drawing.Point(203, 539);
            this.treeViewCount.Name = "treeViewCount";
            this.treeViewCount.Size = new System.Drawing.Size(422, 23);
            this.treeViewCount.TabIndex = 10;
            this.treeViewCount.Text = "0 File(s), 0 Folder(s)";
            this.treeViewCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // zipOpenDialog
            // 
            this.zipOpenDialog.FileName = "*.zip";
            this.zipOpenDialog.Filter = "Zip 파일|*.zip";
            this.zipOpenDialog.Title = "Zip 파일 열기";
            // 
            // DeZipperForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 578);
            this.Controls.Add(this.tableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(440, 590);
            this.Name = "DeZipperForm";
            this.Text = "DeZipper";
            this.Load += new System.EventHandler(this.DeZipperForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.DeZipperForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.DeZipperForm_DragEnter);
            this.optionPanel.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.targetPathPanel.ResumeLayout(false);
            this.targetPathPanel.PerformLayout();
            this.zipPathPanel.ResumeLayout(false);
            this.zipPathPanel.PerformLayout();
            this.executionPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TreeView zipEntryTreeView;
        private System.Windows.Forms.Panel optionPanel;
        private System.Windows.Forms.CheckBox deleteEmptyDirectory;
        private System.Windows.Forms.CheckBox toRecycleBin;
        private System.Windows.Forms.CheckBox deleteSourceZipFile;
        private System.Windows.Forms.Button excludeButton;
        private System.Windows.Forms.TextBox tgPath;
        private System.Windows.Forms.TextBox zipPath;
        private System.Windows.Forms.Button zipPathButton;
        private System.Windows.Forms.Button targetPathButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Panel targetPathPanel;
        private System.Windows.Forms.Panel zipPathPanel;
        private System.Windows.Forms.Panel executionPanel;
        private System.Windows.Forms.ImageList fileImageList;
        private System.Windows.Forms.Label treeViewCount;
        private System.Windows.Forms.OpenFileDialog zipOpenDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}