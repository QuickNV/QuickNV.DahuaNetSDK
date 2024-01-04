using System.Runtime.InteropServices;

namespace Dahua.Api.Struct
{

    /// <summary>
    /// НшВзЙи±ёРЕПў
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NET_DEVICEINFO
    {
        /// <summary>
        /// РтБРєЕ[і¤¶И48]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        public byte[] sSerialNumber;

        /// <summary>
        /// DVR±ЁѕЇКдИлёцКэ
        /// </summary>
        public byte byAlarmInPortNum;

        /// <summary>
        /// DVR±ЁѕЇКдіцёцКэ
        /// </summary>
        public byte byAlarmOutPortNum;

        /// <summary>
        /// DVRУІЕМёцКэ
        /// </summary>
        public byte byDiskNum;

        /// <summary>
        /// DVRАаРН
        /// </summary>
        public byte byDVRType;

        /// <summary>
        /// DVRНЁµАёцКэ
        /// </summary>
        public byte byChanNum;

    }
}
