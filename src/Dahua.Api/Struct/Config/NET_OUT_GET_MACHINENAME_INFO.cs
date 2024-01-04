using System;
using System.Runtime.InteropServices;

namespace Dahua.Api.Struct.Config
{
    // CLIENT_GetMachineName 出参
    public struct NET_OUT_GET_MACHINENAME_INFO
    {
        public uint dwSize;                                 // 结构体大小
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szName;                                // 本机名称
    }
}