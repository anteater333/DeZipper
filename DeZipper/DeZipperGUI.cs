using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace DeZipper
{
    /// <summary>
    /// WinForm GUI 에서 DeZipper 클래스를 호출하고,
    /// DeZipper의 연산 결과를 출력하는데 사용하는 클래스입니다.
    /// </summary>
    class DeZipperGUI : DeZipperUI, IOpenable
    {
        #region Fields
        private int cFiles;
        private int cDirs;
        #endregion

        #region Properties
        public TreeView EntryTree { get; set; }
        public int CountFiles
        {
            get
            {
                return cFiles;
            }
        }
        public int CountDirs
        {
            get
            {
                return cDirs;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        public DeZipperGUI()
        {
            try
            {
                base.deZipper = new DeZipper();
                base.Options = DeleteOptions.None;
                this.cFiles = 0;
                this.cDirs = 0;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 삭제할 ZIP 파일 리스트에서 특정 파일을 제외합니다.
        /// </summary>
        /// <param name="path">제외하려는 TreeNode의 Name</param>
        /// <returns></returns>
        public override bool Delist(string path)
        {
            try
            {
                EntryTree.BeginUpdate();

                foreach (var key in deZipper.Entries.ToList())
                {
                    if (key.Value.FullName.Contains(path))
                    {
                        deZipper.Delist(key.Value.FullName);
                        if (key.Value.Name.Equals(""))
                            cDirs--;
                        else
                            cFiles--;
                    }
                }

                TreeNode delNode = EntryTree.Nodes.Find(path, true)[0];

                EntryTree.Nodes.Remove(delNode);
                EntryTree.EndUpdate();

                return true;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// ZIP 파일 리스트에 따라 파일을 삭제합니다.
        /// </summary>
        public override void Delete()
        {
            try
            {
                deZipper.Options = base.Options;
                deZipper.TargetDirectory = this.TargetDirectory;
                if (deZipper.TargetDirectory.Equals(""))
                    throw new Exception("Empty Path Error");    /// 수정필요

                DeZipperProgressForm deleteProgressForm = new DeZipperProgressForm()
                {
                    ProgressMax = cFiles
                };
                if ((Options & DeleteOptions.DeleteEmptyDirectory) != 0)
                    deleteProgressForm.ProgressMax += cDirs;
                if ((Options & DeleteOptions.DeleteSourceZipFile) != 0)
                    deleteProgressForm.ProgressMax += 1;
                deleteProgressForm.Show();

                int delCount = 0;
                string progressLog = "";
                foreach (string entry in deZipper.ExecuteDelete())
                {
                    if (entry.Contains(DeZipper.FIlE_NOT_FOUND))
                        progressLog = entry.Replace(DeZipper.FIlE_NOT_FOUND, "") + " : 해당 파일이 존재하지 않습니다.";
                    else if (entry.Contains(DeZipper.DIR_NOT_EMPTY))
                        progressLog = entry.Replace(DeZipper.DIR_NOT_EMPTY, "") + " : 빈 폴더가 아니기 때문에 삭제되지 않았습니다.";
                    else if (entry.Contains(DeZipper.DIR_NOT_FOUND))
                        progressLog = entry.Replace(DeZipper.DIR_NOT_FOUND, "") + " : 경로를 찾을 수 없습니다.";
                    else
                    {
                        delCount++;
                        progressLog = entry + " : 정상적으로 삭제되었습니다.";
                    }
                    if (!deleteProgressForm.ProgressPerform(progressLog))
                        break;
                }

                deleteProgressForm.FinishDelete(delCount);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// TreeView 컴포넌트에 파일 리스트를 출력합니다.
        /// </summary>
        public override void PrintList()
        {
            try
            {
                cDirs = 0;
                cFiles = 0;

                EntryTree.BeginUpdate();
                EntryTree.Nodes.Clear();

                List<string> dirList = new List<string>();
                TreeNodeCollection branch = EntryTree.Nodes;

                foreach (KeyValuePair<string, ZipArchiveEntry> entry in deZipper.Entries)
                {
                    string path = entry.Value.FullName;
                    path = path.TrimEnd('/');
                    path = path.Remove(path.LastIndexOf('/') + 1);

                    if (entry.Value.Name.Equals(""))    // Folder
                    {
                        string name = entry.Value.FullName.Split('/')[entry.Value.FullName.Split('/').Length - 2];

                        dirList.Add(entry.Value.FullName);

                        if (dirList.Contains(path))
                            branch.Find(path, true)[0].Nodes.Add(entry.Value.FullName, name, 1, 1);
                        else
                            branch.Add(entry.Value.FullName, name, 1, 1);

                        cDirs++;
                    }
                    else                                // Files
                    {
                        if (dirList.Contains(path))
                            branch.Find(path, true)[0].Nodes.Add(entry.Value.FullName, entry.Value.Name);
                        else
                            branch.Add(entry.Value.FullName, entry.Value.Name);

                        cFiles++;
                    }
                }

                EntryTree.EndUpdate();
                EntryTree.ExpandAll();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 새 ZIP 파일을 엽니다.
        /// </summary>
        /// <param name="zipPath">ZIP 파일 경로</param>
        /// <param name="tgPath">타겟 디렉토리 경로</param>
        public void OpenZip(string zipPath, string tgPath)
        {
            try
            {
                base.TargetDirectory = tgPath;
                deZipper.NewZip(zipPath);
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
