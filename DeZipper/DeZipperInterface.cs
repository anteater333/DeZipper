using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeZipper
{
    /// <summary>
    /// 프로그램에서 ZIP 파일이 열리는 시기가 불확실한 경우를 제어할 수 있습니다.
    /// </summary>
    interface IOpenable
    {
        void OpenZip(string zipPath, string tgPath);
    }
}
