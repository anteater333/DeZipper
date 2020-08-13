using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace DeZipper
{
    /// <summary>
    /// 프로그램 핵심 기능을 담당하는 클래스입니다.
    /// </summary>
    public class DeZipper
    {
        #region Error Message
        public const string FIlE_NOT_FOUND = "<FILE_NOT_FOUND>";
        public const string DIR_NOT_EMPTY = "<DIR_NOT_EMPTY>";
        public const string DIR_NOT_FOUND = "<DIR_NOT_FOUND>";
        #endregion

        #region Fields
        private string zipPath;
        private string tgPath;
        private Dictionary<string, ZipArchiveEntry> entries;
        #endregion

        #region Properties
        /// <summary>
        /// 삭제 시 옵션을 설정할 수 있습니다.
        /// </summary>
        public DeleteOptions Options { get; set; }
        /// <summary>
        /// ZIP 파일에 있는 파일들의 리스트를 HashTable 형태로 가져옵니다.
        /// </summary>
        public Dictionary<string, ZipArchiveEntry> Entries { get { return this.entries; } }
        /// <summary>
        /// 삭제 작업을 수행할 디렉토리 경로를 설정할 수 있습니다. 기호 '\' 는 자동으로 '/' 로 변환됩니다.
        /// </summary>
        public string TargetDirectory
        {
            get
            {
                return tgPath;
            }
            set
            {
                if (value.Equals(""))
                    tgPath = value;
                else if (value[value.Length - 1].Equals('\\') || value[value.Length - 1].Equals('/'))
                    tgPath = value;
                else
                    tgPath = value + "/";
                tgPath = tgPath.Replace('\\', '/');
            }
        }
        #endregion
        
        #region Methods
        /// <summary>
        /// 임시 인스턴스를 만듭니다.
        /// 이 생성자를 통해 생성된 인스턴스는 추가적으로 ZIP 파일 경로를 설정한 다음 사용해야합니다.
        /// ZIP 파일이 열리는 시기가 불확실한 경우 사용합니다.
        /// </summary>
        public DeZipper()
        {
            this.TargetDirectory = "./";
            this.Options = DeleteOptions.None;
            this.entries = new Dictionary<string, ZipArchiveEntry>();
        }
        /// <summary>
        /// ZIP 파일을 엽니다.
        /// </summary>
        /// <param name="zipPath">ZIP 파일 경로</param>
        public DeZipper(string zipPath)
        {
            this.zipPath = zipPath;
            this.zipPath = this.zipPath.Replace('\\', '/');
            this.TargetDirectory = "./";
            this.Options = DeleteOptions.None;

            try
            {
                this.entries = new Dictionary<string, ZipArchiveEntry>();
                NewZip(this.zipPath);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// ZIP 파일을 엽니다.
        /// </summary>
        /// <param name="zipPath">ZIP 파일 경로</param>
        /// <param name="tgPath">타겟 디렉토리 경로</param>
        public DeZipper(string zipPath, string tgPath)
        {
            this.zipPath = zipPath;
            this.zipPath = this.zipPath.Replace('\\', '/');
            this.TargetDirectory = tgPath;
            this.Options = DeleteOptions.None;

            try
            {
                this.entries = new Dictionary<string, ZipArchiveEntry>();
                NewZip(this.zipPath);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// ZIP 파일을 열고 삭제 옵션을 지정합니다.
        /// </summary>
        /// <param name="zipPath">ZIP 파일 경로</param>
        /// <param name="tgPath">타겟 디렉토리 경로</param>
        /// <param name="options">삭제 옵션</param>
        public DeZipper(string zipPath, string tgPath, DeleteOptions options)
        {
            this.zipPath = zipPath;
            this.zipPath = this.zipPath.Replace('\\', '/');
            this.TargetDirectory = tgPath;
            this.Options = options;

            try
            {
                this.entries = new Dictionary<string, ZipArchiveEntry>();
                NewZip(this.zipPath);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 삭제할 ZIP 파일 리스트에서 특정 파일을 제외합니다.
        /// </summary>
        /// <param name="path">제외할 파일의 ZIP 파일 내부 경로</param>
        /// <returns>제외한 파일 엔트리. 해당 파일이 없을 경우 null을 반환합니다.</returns>
        public ZipArchiveEntry Delist(string path)
        {
            ZipArchiveEntry val;
            path = path.Replace('\\', '/');
            try
            {
                if (Entries.TryGetValue(path, out val))
                {
                    Entries.Remove(path);
                    return val;
                }
                else
                    return null;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 새로운 ZIP 파일을 엽니다.
        /// </summary>
        /// <param name="zipPath">ZIP 파일 경로</param>
        public void NewZip(string zipPath)
        {
            this.zipPath = zipPath;
            this.zipPath = this.zipPath.Replace('\\', '/');

            entries.Clear();
            
            try
            {
                List<ZipArchiveEntry> fileList = new List<ZipArchiveEntry>();       // files
                Stack<ZipArchiveEntry> dirStack = new Stack<ZipArchiveEntry>();     // directories
                Stack<ZipArchiveEntry> entryStack = new Stack<ZipArchiveEntry>();   // temporary stack

                using (ZipArchive zipAchv = ZipFile.Open(this.zipPath, ZipArchiveMode.Read))
                {
                    foreach (ZipArchiveEntry entry in zipAchv.Entries)
                    {
                        if (entry.Name == "")
                            dirStack.Push(entry);
                        else
                            fileList.Add(entry);
                    }

                    while (dirStack.Count != 0)
                    {
                        var dirItem = dirStack.Pop();
                        for (int i = fileList.Count - 1; i >= 0; i--)
                        {
                            if (fileList.ElementAt(i).FullName.Contains(dirItem.FullName))
                            {
                                var fileItem = fileList.ElementAt(i);
                                fileList.RemoveAt(i);
                                entryStack.Push(fileItem);
                            }
                        }
                        entryStack.Push(dirItem);
                    }

                    for (int i = fileList.Count - 1; i >= 0; i--)
                    {
                        var item = fileList.ElementAt(i);
                        fileList.RemoveAt(i);
                        entryStack.Push(item);
                    }

                    foreach(ZipArchiveEntry entry in entryStack)
                    {
                        this.Entries.Add(entry.FullName, entry);
                    }
                    
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 파일 삭제를 실행합니다.
        /// </summary>
        /// <returns>삭제한 파일들의 전체 경로.</returns>
        public IEnumerable<string> ExecuteDelete()
        {
            Stack<string> zipDirPaths = new Stack<string>();
            int dirCount = 0;

            string rtStr;

            foreach (KeyValuePair<string, ZipArchiveEntry> entry in Entries)
            {
                if (entry.Value.Name == "")     // if the entry is directory.
                {
                    zipDirPaths.Push(entry.Value.FullName);
                    dirCount++;
                }
                else
                {
                    try
                    {
                        rtStr = tgPath + entry.Value.FullName;
                        if (File.Exists(rtStr))
                            File.Delete(rtStr);
                        else
                            rtStr = FIlE_NOT_FOUND + rtStr;
                    }
                    catch
                    {
                        throw;
                    }
                    yield return rtStr;
                }
            }

            if ((Options & DeleteOptions.DeleteEmptyDirectory) != 0)
            {
                for (int i = 0; i < dirCount; i++)
                {
                    rtStr = tgPath + zipDirPaths.Pop();

                    try
                    {
                        if (!Directory.Exists(rtStr))
                            rtStr = DIR_NOT_FOUND + rtStr;
                        else if (!Directory.EnumerateFileSystemEntries(rtStr).Any())
                            Directory.Delete(rtStr);
                        else
                            rtStr = DIR_NOT_EMPTY + rtStr;
                    }
                    catch (DirectoryNotFoundException)
                    {
                        throw new DirectoryNotFoundException(rtStr);
                    }
                    catch
                    {
                        throw;
                    }

                    yield return rtStr;
                }
            }

            if ((Options & DeleteOptions.DeleteSourceZipFile) != 0)
            {
                try
                {
                    File.Delete(zipPath);
                }
                catch (DirectoryNotFoundException)
                {
                    throw new DirectoryNotFoundException(zipPath);
                }
                catch
                {
                    throw;
                }
                yield return zipPath;
            }
        }
        #endregion
    }
}
