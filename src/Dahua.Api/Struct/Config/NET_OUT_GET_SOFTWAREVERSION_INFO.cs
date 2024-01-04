using System;
using System.Runtime.InteropServices;

namespace Dahua.Api.Struct.Config
{
    /// <summary>
    /// GetSoftwareVersion 出参
    /// GetSoftwareVersion output parameter
    /// </summary>
    public struct NET_OUT_GET_SOFTWAREVERSION_INFO
    {
        public uint dwSize;
        /// <summary>
        /// 软件版本
        /// software version
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szVersion;
        /// <summary>
        /// 日期
        /// version build date,exact to the second
        /// </summary>
        public NET_TIME stuBuildDate;
        /// <summary>
        /// web软件信息
        /// web version info
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string szWebVersion;
        /// <summary>
        /// 安全基线版本
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szSecurityVersion;
        /// <summary>
        /// 返回的外设数量
        /// </summary>
        public int nPeripheralNum;
        /// <summary>
        /// 设备的外设软件版本
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public NET_PERIPHERAL_VERSIONS[] stuPeripheralVersions;
        /// <summary>
        /// 算法训练对外代号
        /// Algorithm training external code
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szAlgorithmTrainingVersion;
    }
}