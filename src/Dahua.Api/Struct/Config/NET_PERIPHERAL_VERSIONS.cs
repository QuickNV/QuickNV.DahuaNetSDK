using System.Runtime.InteropServices;

namespace Dahua.Api.Struct.Config
{
    /// <summary>
    /// Device's peripheral software version
    /// </summary>
    internal struct NET_PERIPHERAL_VERSIONS
    {
        /// <summary>
        /// Corresponding version information of the peripherals
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string szVersion;
        /// <summary>
        /// Peripheral
        /// </summary>
        public EM_PERIPHERAL_TYPE emPeripheralType;
        /// <summary>
        /// Retain byte
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 252)]
        public byte[] byReserved;
    }
}