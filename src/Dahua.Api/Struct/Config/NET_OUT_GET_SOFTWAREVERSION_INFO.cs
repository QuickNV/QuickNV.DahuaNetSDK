using System.Runtime.InteropServices;

namespace Dahua.Api.Struct.Config
{
    /// <summary>
    /// GetSoftwareVersion output parameter
    /// </summary>
    internal struct NET_OUT_GET_SOFTWAREVERSION_INFO
    {
        public uint dwSize;
        /// <summary>
        /// software version
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szVersion;
        /// <summary>
        /// version build date,exact to the second
        /// </summary>
        public NET_TIME stuBuildDate;
        /// <summary>
        /// web version info
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string szWebVersion;
        /// <summary>
        /// Security baseline version
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szSecurityVersion;
        /// <summary>
        /// Number of peripherals returned
        /// </summary>
        public int nPeripheralNum;
        /// <summary>
        /// Device's peripheral software version
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public NET_PERIPHERAL_VERSIONS[] stuPeripheralVersions;
        /// <summary>
        /// Algorithm training external code
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szAlgorithmTrainingVersion;
    }
}