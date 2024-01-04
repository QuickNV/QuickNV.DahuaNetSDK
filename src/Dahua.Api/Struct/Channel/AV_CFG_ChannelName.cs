using System.Runtime.InteropServices;

namespace Dahua.Api.Struct.Channel
{
    public struct AV_CFG_ChannelName
    {
        public int nStructSize;
        /// <summary>
        /// 摄像头唯一编号
        /// </summary>
        public int nSerial;
        /// <summary>
        /// 通道名
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string szName;
    }
}