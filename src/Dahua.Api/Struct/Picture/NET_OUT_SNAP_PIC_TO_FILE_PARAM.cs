using System;

namespace Dahua.Api.Struct.Picture
{
    /// <summary>
    /// SnapPictureToFile function output parameter 
    /// </summary>
    internal struct NET_OUT_SNAP_PIC_TO_FILE_PARAM
    {
        /// <summary>
        /// structure size
        /// </summary>
        public uint dwSize;
        /// <summary>
        /// picture content, user memory allocation, memory size is dwPicBufLen
        /// </summary>
        public IntPtr szPicBuf;
        /// <summary>
        /// picture content memory size, unit: byte
        /// </summary>
        public uint dwPicBufLen;
        /// <summary>
        /// returned picture size, unit:byte
        /// </summary>
        public uint dwPicBufRetLen;
    }
}