using System.Runtime.InteropServices;

namespace Dahua.Api.Struct.Config
{
    /// <summary>
    /// AV_CFG_ChannelName
    /// </summary>
    internal struct AV_CFG_ChannelName
    {
        /// <summary>
        /// The n structure size
        /// </summary>
        public int nStructSize;
        /// <summary>
        /// The unique number of the camera
        /// </summary>
        public int nSerial;
        /// <summary>
        /// Channel name
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string szName;
    }
}