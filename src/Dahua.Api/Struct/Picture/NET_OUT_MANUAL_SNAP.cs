using System;
using System.Runtime.InteropServices;
using QuickNV.DahuaNetSDK;

namespace Dahua.Api.Struct.Picture
{
    /// <summary>
    /// Output param of CLIENT_ManualSnap
    /// </summary>
    internal struct NET_OUT_MANUAL_SNAP
    {
        /// <summary>
        /// Struct size
        /// </summary>
        public uint dwSize;
        /// <summary>
        /// The length of pRcvBuf. Its value is specified by the user
        /// </summary>
        public uint nMaxBufLen;
        /// <summary>
        /// Buffer of capture, It is Used to store snapshot data.The space is applied and released by the user, and the application size is nmaxbuflen.
        /// </summary>
        public IntPtr pRcvBuf;
        /// <summary>
        /// Actual received picture size
        /// </summary>
        public uint nRetBufLen;
        /// <summary>
        /// Picture encoding format
        /// </summary>
        public EM_SNAP_ENCODE_TYPE emEncodeType;
        /// <summary>
        /// Serial number
        /// </summary>
        public uint nCmdSerial;
        /// <summary>
        /// Byte alignment
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] bReserved;
    }
}