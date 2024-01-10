using System.Runtime.InteropServices;

namespace Dahua.Api.Struct.Picture
{
    /// <summary>
    /// SnapPictureToFile function input parameter
    /// </summary>
    internal struct NET_IN_SNAP_PIC_TO_FILE_PARAM
    {
        /// <summary>
        /// structure size
        /// </summary>
        public uint dwSize;
        /// <summary>
        /// snapshot parameter, mode field is only snapshot for once, fail to support timed or continuous snapshot; except mobile DVR, other devices only support snapshot frequency of one snapshot per second
        /// </summary>
        public NET_SNAP_PARAMS stuParam;
        /// <summary>
        /// write in file address
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szFilePath;
    }
}