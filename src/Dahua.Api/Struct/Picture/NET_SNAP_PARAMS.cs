using System.Runtime.InteropServices;

namespace Dahua.Api.Struct.Picture
{
    /// <summary>
    /// snapshot parameter structure
    /// </summary>
    internal struct NET_SNAP_PARAMS
    {
        /// <summary>
        /// Snapshot channel
        /// </summary>
        public uint Channel;
        /// <summary>
        /// Image quality:level 1 to level 6
        /// </summary>
        public uint Quality;
        /// <summary>
        /// Video size;0:QCIF,1:CIF,2:D1
        /// </summary>
        public uint ImageSize;
        /// <summary>
        /// Snapshot mode;0:request one frame,1:send out requestion regularly,2: Request consecutively
        /// </summary>
        public uint mode;
        /// <summary>
        /// Time unit is second.If mode=1, it means send out requestion regularly. The time is valid.
        /// </summary>
        public uint InterSnap;
        /// <summary>
        /// Request serial number
        /// </summary>
        public uint CmdSerial;
        /// <summary>
        /// Reserved
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public uint[] Reserved;
    }
}