using System.Runtime.InteropServices;

namespace Dahua.Api.Struct.Config
{
    // CLIENT_GetDeviceSerialNo 出参
    public struct NET_OUT_GET_DEVICESERIALNO_INFO
    {
        public uint dwSize;                               // 结构体大小
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szSN;                              // 序列号
    }
}