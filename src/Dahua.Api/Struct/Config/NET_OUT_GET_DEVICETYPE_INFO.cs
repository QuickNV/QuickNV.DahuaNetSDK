using System.Runtime.InteropServices;

namespace Dahua.Api.Struct.Config
{
    /// <summary>
    /// GetDeviceType output parameter
    /// </summary>
    internal struct NET_OUT_GET_DEVICETYPE_INFO
    {
        public uint dwSize;
        /// <summary>
        /// Device Types
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string szType;
        /// <summary>
        /// Device Types
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string szTypeEx;
    }
}