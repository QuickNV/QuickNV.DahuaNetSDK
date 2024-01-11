using System.Runtime.InteropServices;

namespace Dahua.Api.Struct.Config
{
    /// <summary>
    /// CLIENT_GetDeviceSerialNo output
    /// </summary>
    internal struct NET_OUT_GET_DEVICESERIALNO_INFO
    {
        /// <summary>
        /// Structure
        /// </summary>
        public uint dwSize;
        /// <summary>
        /// serial number
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szSN;
    }
}