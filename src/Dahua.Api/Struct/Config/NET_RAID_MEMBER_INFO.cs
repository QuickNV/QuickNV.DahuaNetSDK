using System;

namespace Dahua.Api.Struct.Config
{
    /// <summary>
    /// RAID member info
    /// RAID成员信息
    /// </summary>
    public struct NET_RAID_MEMBER_INFO
    {
        public uint dwSize;
        /// <summary>
        /// disk no., may use to describe disk cabinet slot
        /// 磁盘号, 可用于描述磁盘在磁柜的槽位
        /// </summary>
        public uint dwID;
        /// <summary>
        /// partial hot device, true-partial hot device, false-RAID sub disk
        /// 是否局部热备, true-局部热备, false-RAID子盘
        /// </summary>
        public bool bSpare;
    }
}