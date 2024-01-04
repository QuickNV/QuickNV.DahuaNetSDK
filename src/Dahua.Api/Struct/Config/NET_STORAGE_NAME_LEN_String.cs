using System;
using System.Runtime.InteropServices;

namespace Dahua.Api.Struct.Config
{
    /// <summary>
    /// Store NET_STORAGE_NAME string
    /// 临时放成员名字字符串
    /// </summary>
    public struct NET_STORAGE_NAME_LEN_String
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string szSTORAGE_NAME;
    }
}