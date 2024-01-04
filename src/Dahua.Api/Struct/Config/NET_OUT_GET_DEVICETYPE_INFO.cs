using System.Runtime.InteropServices;

namespace Dahua.Api.Struct.Config
{
    /// <summary>
    /// GetDeviceType 出参
    /// GetDeviceType output parameter
    /// </summary>
    public struct NET_OUT_GET_DEVICETYPE_INFO
    {
        public uint dwSize;
        /// <summary>
        /// 设备类型,该字段被废弃
        /// Device Types
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string szType;
        /// <summary>
        /// 设备类型, 扩展设备类型建议使用此字段
        /// Device Types
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string szTypeEx;
    }
}