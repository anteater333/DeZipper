using System;

namespace DeZipper
{
    /// <summary>
    /// 삭제 시 옵션을 지정합니다.
    /// </summary>
    [Flags]
    public enum DeleteOptions
    {
        None = 0x0,                     // 000
        ToRecycleBin = 0x1,             // 001
        DeleteEmptyDirectory = 0x2,     // 010
        DeleteSourceZipFile = 0x4       // 100
    }
}
