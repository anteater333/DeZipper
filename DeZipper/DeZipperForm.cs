using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace DeZipper
{
    public partial class DeZipperForm : Form
    {
        private DeZipperGUI deZipCaller;
        private bool zipLoaded;

        public DeZipperForm()
        {
            try
            {
                zipLoaded = false;
                InitializeComponent();
            }
            catch (Exception ex)
            {
                ShowExceptionMsg(ex);
            }
        }

        #region Events
        private void DeZipperForm_Load(object sender, EventArgs e)
        {
            zipEntryTreeView.ImageList = fileImageList;

            try
            {
                deZipCaller = new DeZipperGUI();
                deZipCaller.EntryTree = zipEntryTreeView;
            }
            catch (Exception ex)
            {
                ShowExceptionMsg(ex);
            }
        }

        private void zipPathButton_Click(object sender, EventArgs e)
        {
            DialogResult dResult = zipOpenDialog.ShowDialog();

            if (dResult == DialogResult.OK)
            {
                zipPath.Text = zipOpenDialog.FileName;
                ZipLoad();
            }
            else
            {
                zipPath.ResetText();
            }
        }

        private void targetPathButton_Click(object sender, EventArgs e)
        {
            DialogResult dResult = folderBrowserDialog.ShowDialog();

            if (dResult == DialogResult.OK)
            {
                tgPath.Text = folderBrowserDialog.SelectedPath;
                deZipCaller.TargetDirectory = tgPath.Text;
            }
        }

        private void excludeButton_Click(object sender, EventArgs e)
        {
            TreeNode selected = zipEntryTreeView.SelectedNode;
            if (selected == null || !zipLoaded)
            {
                // Do Nothing
            }
            else
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    deZipCaller.Delist(selected.Name);
                    UpdateTreeViewCount();
                    Cursor.Current = Cursors.Default;

                    zipEntryTreeView.SelectedNode = null;
                    excludeButton.Enabled = false;
                }
                catch (Exception ex)
                {
                    ShowExceptionMsg(ex);
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (!zipLoaded)
            {

            }
            else if (tgPath.Text.Equals(""))
            {
                MessageBox.Show("삭제 경로를 입력해주세요.", "에러!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string msgboxText = "";
                    string msgboxOptionText = "";
                    int total = deZipCaller.CountFiles;
                    deZipCaller.Options = DeleteOptions.None;
                    if (toRecycleBin.Checked)
                    {
                        deZipCaller.Options |= DeleteOptions.ToRecycleBin;
                        msgboxOptionText += " - 휴지통으로 보내기" + Environment.NewLine;
                    }
                    if (deleteEmptyDirectory.Checked)
                    {
                        deZipCaller.Options |= DeleteOptions.DeleteEmptyDirectory;
                        total += deZipCaller.CountDirs;
                        msgboxOptionText += " - 빈 폴더 삭제" + Environment.NewLine;
                    }
                    if (deleteSourceZipFile.Checked)
                    {
                        deZipCaller.Options |= DeleteOptions.DeleteSourceZipFile;
                        total += 1;
                        msgboxOptionText += " - 원본 zip 파일 삭제" + Environment.NewLine;
                    }
                    deZipCaller.TargetDirectory = this.tgPath.Text;

                    msgboxText += "총 " + total + " 파일이 삭제됩니다." + Environment.NewLine;
                    msgboxText += "선택한 옵션:" + Environment.NewLine;
                    msgboxText += msgboxOptionText + Environment.NewLine;
                    msgboxText += "삭제하시겠습니까?";

                    if (MessageBox.Show(msgboxText, "경고!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        deZipCaller.Delete();
                    }
                }
                catch (Exception ex)
                {
                    ShowExceptionMsg(ex);
                }
            }
        }

        private void zipPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ZipLoad();
            }
        }

        private void zipEntryTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            excludeButton.Enabled = true;
        }

        private void DeZipperForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy | DragDropEffects.Scroll;
        }

        private void DeZipperForm_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] strZips = (string[])e.Data.GetData(DataFormats.FileDrop);
                zipPath.Text = strZips[0];

                ZipLoad();
            }
        }
        #endregion

        #region Private Methods
        private void UpdateTreeViewCount()
        {
            // # File(s), # Folder(s)
            treeViewCount.Text = deZipCaller.CountFiles + " File(s), ";
            treeViewCount.Text += deZipCaller.CountDirs + " Folder(s)";
        }

        private void ZipLoad()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                deZipCaller.OpenZip(zipPath.Text, tgPath.Text);
                deZipCaller.PrintList();
                zipEntryTreeView.Nodes[0].EnsureVisible();
                zipEntryTreeView.Nodes[0].ExpandAll();
                UpdateTreeViewCount();
                Cursor.Current = Cursors.Default;

                if (tgPath.Text.Equals(""))
                {
                    tgPath.Text = ConfigurationManager.AppSettings["DefaultDirectory"];
                }
                zipLoaded = true;
            }
            catch (Exception e)
            {
                ShowExceptionMsg(e);
            }
        }

        private void ShowExceptionMsg(Exception e)
        {
            string errMsg = "예상치 못한 에러가 발생했습니다:" + Environment.NewLine;
            errMsg += e.Message + Environment.NewLine + Environment.NewLine;

#if DEBUG
            errMsg += e.Source + Environment.NewLine;
            errMsg += e.StackTrace + Environment.NewLine;
#endif

            MessageBox.Show(errMsg, "에러!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion
    }
}
