using System;
using System.Runtime.InteropServices;

namespace Dahua.Api.Struct.Picture
{
    /// <summary>
    /// SnapPictureToFile function input parameter
    /// SnapPictureToFile函数输入参数
    /// </summary>
    public struct NET_IN_SNAP_PIC_TO_FILE_PARAM
    {
        /// <summary>
        /// structure size
        /// 结构体大小
        /// </summary>
        public uint dwSize;
        /// <summary>
        /// snapshot parameter, mode field is only snapshot for once, fail to support timed or continuous snapshot; except mobile DVR, other devices only support snapshot frequency of one snapshot per second
        /// 抓图参数, 其中mode字段仅一次性抓图, 不支持定时或持续抓图; 除了车载DVR, 其他设备仅支持每秒一张的抓图频率
        /// </summary>
        public NET_SNAP_PARAMS stuParam;
        /// <summary>
        /// write in file address
        /// 写入文件的地址
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szFilePath;
    }
}