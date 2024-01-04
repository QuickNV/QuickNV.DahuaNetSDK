using System;
using System.Runtime.InteropServices;

namespace Dahua.Api.Struct.Config
{
    /// <summary>
    /// 存储分区信息
    /// Storage partition info
    /// </summary>
    public struct NET_A_STORAGE_PARTITION
    {
        public uint dwSize;
        /// <summary>
        /// 名称
        /// Name
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string szName;
        /// <summary>
        /// 总空间, byte
        /// Total space(MB)
        /// </summary>
        public long nTotalSpace;
        /// <summary>
        /// 剩余空间, byte
        /// free space(MB)
        /// </summary>
        public long nFreeSpace;
        /// <summary>
        /// 挂载点
        /// Mount point
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szMountOn;
        /// <summary>
        /// 文件系统
        /// File system
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string szFileSystem;
        /// <summary>
        /// 分区状态, 0-LV不可用, 1-LV可用
        /// partition state, 0-LV not available, 1-LV available
        /// </summary>
        public int nStatus;
        /// <summary>
        /// 设备是否支持当前文件系统, TRUE:支持， FALSE:不支持
        /// Whether the device supports the current file system, TRUE: Yes, FALSE: No
        /// </summary>
        public bool bIsSupportFs;
    }
}