using System.Runtime.InteropServices;

namespace Dahua.Api.Struct.Video
{

    /// <summary>
    /// ВјПсОДјюРЕПў
    /// </summary>
    public struct NET_RECORDFILE_INFO
    {
        /// <summary>
        /// НЁµАєЕ
        /// </summary>
        public uint ch;
        /// <summary>
        /// ОДјюГы
        /// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 128)]
        //public char[] filename;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] filename;
        //public string filename;
        /// <summary>
        /// ОДјюі¤¶И
        /// </summary>
        public uint size;
        /// <summary>
        /// їЄКјК±јд
        /// </summary>
        public NET_TIME starttime;
        /// <summary>
        /// ЅбКшК±јд
        /// </summary>
        public NET_TIME endtime;
        /// <summary>
        /// ґЕЕМєЕ
        /// </summary>
        public uint driveno;
        /// <summary>
        /// ЖрКјґШєЕ
        /// </summary>
        public uint startcluster;
        /// <summary>
        /// ВјПсОДјюАаРН  0ЈєЖХНЁВјПсЈ»1Јє±ЁѕЇВј
        /// </summary>
        public int nRecordFileType;
    }
}
