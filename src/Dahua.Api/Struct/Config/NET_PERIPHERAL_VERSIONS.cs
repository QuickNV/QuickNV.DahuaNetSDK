using System;
using System.Runtime.InteropServices;

namespace Dahua.Api.Struct.Config
{
    // 设备的外设软件版本
    public struct NET_PERIPHERAL_VERSIONS
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string szVersion;// 对应外设的版本信息
        public EM_PERIPHERAL_TYPE emPeripheralType;       // 外设类型
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 252)]
        public byte[] byReserved;                     // 保留字节
    }
}