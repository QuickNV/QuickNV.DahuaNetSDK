using System.Runtime.InteropServices;

namespace Dahua.Api.Struct.Picture
{
    /// <summary>
    /// snapshot parameter structure
    /// 抓图参数结构体
    /// </summary>
    public struct NET_SNAP_PARAMS
    {
        /// <summary>
        /// Snapshot channel
        /// 抓图的通道
        /// </summary>
        public uint Channel;
        /// <summary>
        /// Image quality:level 1 to level 6
        /// 画质；1~6
        /// </summary>
        public uint Quality;
        /// <summary>
        /// Video size;0:QCIF,1:CIF,2:D1
        /// 画面大小；0：QCIF,1：CIF,2：D1
        /// </summary>
        public uint ImageSize;
        /// <summary>
        /// Snapshot mode;0:request one frame,1:send out requestion regularly,2: Request consecutively
        /// 抓图模式；0xFFFFFFFF:表示停止抓图, 0：表示请求一帧, 1：表示定时发送请求, 2：表示连续请求
        /// </summary>
        public uint mode;
        /// <summary>
        /// Time unit is second.If mode=1, it means send out requestion regularly. The time is valid.
        /// 时间单位秒；若mode=1表示定时发送请求时只有部分特殊设备(如：车载设备)支持通过该字段实现定时抓图时间间隔的配置建议通过 CFG_CMD_ENCODE 配置的stuSnapFormat[nSnapMode].stuVideoFormat.nFrameRate字段实现相关功能
        /// </summary>
        public uint InterSnap;
        /// <summary>
        /// Request serial number
        /// 请求序列号，有效值范围 0~65535，超过范围会被截断为 unsigned short
        /// </summary>
        public uint CmdSerial;
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public uint[] Reserved;
    }
}