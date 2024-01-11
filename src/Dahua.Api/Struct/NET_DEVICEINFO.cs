using System.Runtime.InteropServices;

namespace Dahua.Api.Struct
{
    /// <summary>
    /// NET_DEVICEINFO
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct NET_DEVICEINFO
    {
        /// <summary>
        /// The serial number
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        public byte[] sSerialNumber;

        /// <summary>
        /// The by alarm in port number
        /// </summary>
        public byte byAlarmInPortNum;

        /// <summary>
        /// The by alarm out port number
        /// </summary>
        public byte byAlarmOutPortNum;

        /// <summary>
        /// The by disk number
        /// </summary>
        public byte byDiskNum;

        /// <summary>
        /// The by DVR type
        /// </summary>
        public byte byDVRType;

        /// <summary>
        /// The by chan number
        /// </summary>
        public byte byChanNum;
    }
}
