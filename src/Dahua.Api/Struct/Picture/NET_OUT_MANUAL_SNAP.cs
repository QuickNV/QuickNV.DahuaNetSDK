using System;
using System.Runtime.InteropServices;
using QuickNV.DahuaNetSDK;

namespace Dahua.Api.Struct.Picture
{
    /// <summary>
    /// CLIENT_ManualSnap 接口输出参数
    /// Output param of CLIENT_ManualSnap
    /// </summary>
    public struct NET_OUT_MANUAL_SNAP
    {
        /// <summary>
        /// 结构体大小
        /// Struct size
        /// </summary>
        public uint dwSize;
        /// <summary>
        /// pRcvBuf的长度,由用户指定
        /// The length of pRcvBuf. Its value is specified by the user
        /// </summary>
        public uint nMaxBufLen;
        /// <summary>
        /// 接收图片缓冲, 用于存放抓图数据, 空间由用户申请和释放, 申请大小为nMaxBufLen
        /// Buffer of capture, It is Used to store snapshot data.The space is applied and released by the user, and the application size is nmaxbuflen.
        /// </summary>
        public IntPtr pRcvBuf;
        /// <summary>
        /// 实际接收到的图片大小
        /// Actual received picture size
        /// </summary>
        public uint nRetBufLen;
        /// <summary>
        /// 图片编码格式
        /// Picture encoding format
        /// </summary>
        public EM_SNAP_ENCODE_TYPE emEncodeType;
        /// <summary>
        /// 请求序列号
        /// Serial number
        /// </summary>
        public uint nCmdSerial;
        /// <summary>
        /// 字节对齐
        /// Byte alignment
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] bReserved;
    }
}