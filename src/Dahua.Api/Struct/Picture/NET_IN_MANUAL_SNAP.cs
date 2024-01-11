using System.Runtime.InteropServices;

namespace Dahua.Api.Struct.Picture
{
    /// <summary>
    /// Input param of CLIENT_ManualSnap
    /// </summary>
    internal struct NET_IN_MANUAL_SNAP
    {
        /// <summary>
        /// Struct size
        /// </summary>
        public uint dwSize;
        /// <summary>
        /// Capture channel number
        /// </summary>
        public uint nChannel;
        /// <summary>
        /// Serial number
        /// </summary>
        public uint nCmdSerial;
        /// <summary>
        /// Capture save path
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szFilePath;
    }
}