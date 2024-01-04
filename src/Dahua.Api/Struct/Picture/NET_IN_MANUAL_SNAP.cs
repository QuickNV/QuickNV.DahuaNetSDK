using System.Runtime.InteropServices;

namespace Dahua.Api.Struct.Picture
{
    /// <summary>
    /// CLIENT_ManualSnap 接口输入参数
    /// Input param of CLIENT_ManualSnap
    /// </summary>
    public struct NET_IN_MANUAL_SNAP
    {
        /// <summary>
        /// 结构体大小
        /// Struct size
        /// </summary>
        public uint dwSize;
        /// <summary>
        /// 抓图通道号
        /// Capture channel number
        /// </summary>
        public uint nChannel;
        /// <summary>
        /// 请求序列号
        /// Serial number
        /// </summary>
        public uint nCmdSerial;
        /// <summary>
        /// 抓图保存路径
        /// Capture save path
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szFilePath;
    }
}