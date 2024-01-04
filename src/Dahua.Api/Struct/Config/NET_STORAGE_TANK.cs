using System;

namespace Dahua.Api.Struct.Config
{
    /// <summary>
    /// storage tank info
    /// 扩展柜信息
    /// </summary>
    public struct NET_STORAGE_TANK
    {
        public uint dwSize;
        /// <summary>
        /// level, the host is 0 level
        /// 级别, 主机是第0级,其它下属级别类推
        /// </summary>
        public int nLevel;
        /// <summary>
        /// extend port number from 0
        /// 同一级扩展柜内的扩展口编号, 从0开始
        /// </summary>
        public int nTankNo;
        /// <summary>
        /// Corresponding cabinet board card no., start from 0
        /// 对应主柜上的板卡号, 从0开始编号  
        /// </summary>   
        public int nSlot;
    }
}