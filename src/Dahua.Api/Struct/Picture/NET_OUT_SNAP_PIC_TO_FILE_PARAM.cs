using System;

namespace Dahua.Api.Struct.Picture
{
    /// <summary>
    /// SnapPictureToFile function output parameter 
    /// SnapPictureToFile函数输出参数
    /// </summary>
    public struct NET_OUT_SNAP_PIC_TO_FILE_PARAM
    {
        /// <summary>
        /// structure size
        /// 结构体大小
        /// </summary>
        public uint dwSize;
        /// <summary>
        /// picture content, user memory allocation, memory size is dwPicBufLen
        /// 图片内容,用户分配内存,大小为dwPicBufLen
        /// </summary>
        public IntPtr szPicBuf;
        /// <summary>
        /// picture content memory size, unit: byte
        /// 图片内容内存大小, 单位:字节
        /// </summary>
        public uint dwPicBufLen;
        /// <summary>
        /// returned picture size, unit:byte
        /// 返回的图片大小, 单位:字节
        /// </summary>
        public uint dwPicBufRetLen;
    }
}