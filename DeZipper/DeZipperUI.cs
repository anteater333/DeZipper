using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeZipper
{
    /// <summary>
    /// UI 추상 기반 클래스
    /// </summary>
    public abstract class DeZipperUI
    {
        #region Fields
        protected string zipPath;
        protected string tgPath;
        protected DeZipper deZipper;
        #endregion

        #region Properties
        /// <summary>
        /// 삭제 시 옵션을 설정할 수 있습니다.
        /// </summary>
        public DeleteOptions Options { get; set; }
        /// <summary>
        /// 삭제 작업에 사용할 ZIP 파일 경로입니다.
        /// </summary>
        public string ZipDirectory
        {
            get
            {
                return this.zipPath;
            }
            set
            {
                this.zipPath = value;
            }
        }
        /// <summary>
        /// 삭제 작업을 수행할 디렉토리 경로입니다.
        /// </summary>
        public string TargetDirectory
        {
            get
            {
                return this.tgPath;
            }
            set
            {
                this.tgPath = value;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// ZIP 파일이 포함하는 파일들의 리스트를 출력합니다.
        /// </summary>
        public abstract void PrintList();

        /// <summary>
        /// 삭제할 ZIP 파일 리스트에서 특정 파일을 제외합니다.
        /// </summary>
        /// <param name="path">제외할 파일의 ZIP 파일 내부 경로</param>
        /// <returns>파일 제외 성공 여부</returns>
        public abstract bool Delist(string path);

        /// <summary>
        /// ZIP 파일 리스트에 따라 파일을 삭제합니다.
        /// </summary>
        public abstract void Delete();
        #endregion
    }
}
