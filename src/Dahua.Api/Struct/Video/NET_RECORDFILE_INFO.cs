using System.Runtime.InteropServices;

namespace Dahua.Api.Struct.Video
{
    /// <summary>
    /// NET_RECORDFILE_INFO
    /// </summary>
    internal struct NET_RECORDFILE_INFO
    {
        /// <summary>
        /// The ch
        /// </summary>
        public uint ch;
        /// <summary>
        /// The filename
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] filename;
        /// <summary>
        /// The size
        /// </summary>
        public uint size;
        /// <summary>
        /// The starttime
        /// </summary>
        public NET_TIME starttime;
        /// <summary>
        /// The endtime
        /// </summary>
        public NET_TIME endtime;
        /// <summary>
        /// The driveno
        /// </summary>
        public uint driveno;
        /// <summary>
        /// The startcluster
        /// </summary>
        public uint startcluster;
        /// <summary>
        /// The n record file type
        /// </summary>
        public int nRecordFileType;
    }
}
