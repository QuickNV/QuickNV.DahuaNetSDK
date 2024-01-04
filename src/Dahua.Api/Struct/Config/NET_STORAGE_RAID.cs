using System;
using System.Runtime.InteropServices;

namespace Dahua.Api.Struct.Config
{
    /// <summary>
    /// RAID Info
    /// RAID信息
    /// </summary>
    public struct NET_STORAGE_RAID
    {
        public uint dwSize;
        /// <summary>
        /// level
        /// 等级  
        /// </summary>
        public int nLevel;
        /// <summary>
        /// RAID state combination NET_RAID_STATE_ACTIVE | NET_RAID_STATE_DEGRADED
        /// RAID状态组合, 如 NET_RAID_STATE_ACTIVE | NET_RAID_STATE_DEGRADED
        /// </summary>
        public int nState;
        /// <summary>
        /// member amount
        /// 成员数量
        /// </summary>
        public int nMemberNum;
        /// <summary>
        /// RAID member
        /// RAID成员
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public NET_STORAGE_NAME_LEN_String[] szMembers;
        /// <summary>
        /// Sync percentage, 0~100, RAID status has"Recovering" or "Resyncing" valid
        /// 同步百分比, 0~100, RAID状态中有"Recovering"或"Resyncing"时有效
        /// </summary>
        public float fRecoverPercent;
        /// <summary>
        /// Sync speed, unit MBps, RAID status has"Recovering" or "Resyncing" valid
        /// 同步速度, 单位MBps, RAID状态中有"Recovering"或"Resyncing"时有效
        /// </summary>
        public float fRecoverMBps;
        /// <summary>
        /// Sync remaining time, unit minute, RAID status has "Recovering" or "Resyncing" valid
        /// 同步剩余时间, 单位分钟, RAID状态中有"Recovering"或"Resyncing"时有效
        /// </summary>
        public float fRecoverTimeRemain;
        /// <summary>
        /// RAID member info
        /// RAID成员信息
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public NET_RAID_MEMBER_INFO[] stuMemberInfos;
        /// <summary>
        /// The number of RAID device
        /// RAID设备个数
        /// </summary>
        public int nRaidDevices;
        /// <summary>
        /// The total count of RAID device
        /// RAID设备总数
        /// </summary>
        public int nTotalDevices;
        /// <summary>
        /// The number of active device
        /// 活动设备个数
        /// </summary>
        public int nActiveDevices;
        /// <summary>
        /// The number of working device
        /// 工作设备个数
        /// </summary>
        public int nWorkingDevices;
        /// <summary>
        /// The number of failed device
        /// 失败设备个数
        /// </summary>
        public int nFailedDevices;
        /// <summary>
        /// The number of hot-spare device
        /// 热备设备个数    
        /// </summary>
        public int nSpareDevices;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
        public string szAliasName;// RAID别名,UTF-8编码
    }
}