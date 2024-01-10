using System.Runtime.InteropServices;

namespace Dahua.Api.Struct.Config
{
    /// <summary>
    /// CLIENT_GetMachineName output
    /// </summary>
    internal struct NET_OUT_GET_MACHINENAME_INFO
    {
        /// <summary>
        /// Structure
        /// </summary>
        public uint dwSize;
        /// <summary>
        /// The name of this machine
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szName;
    }
}