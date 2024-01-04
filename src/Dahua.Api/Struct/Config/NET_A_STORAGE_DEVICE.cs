using System;
using System.Runtime.InteropServices;

namespace Dahua.Api.Struct.Config
{
    /// <summary>
    /// 存储设备信息
    /// Storage device info
    /// </summary>
    public struct NET_A_STORAGE_DEVICE
    {
        public uint dwSize;
        /// <summary>
        /// 名称
        /// name
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string szName;
        /// <summary>
        /// 总空间, byte
        /// Total space, byte
        /// </summary>
        public long nTotalSpace;
        /// <summary>
        /// 剩余空间, byte
        /// free space, byte
        /// </summary>
        public long nFreeSpace;
        /// <summary>
        /// 介质, 0-DISK, 1-CDROM, 2-FLASH
        /// Media, 0-DISK, 1-CDROM, 2-FLASH medium,
        /// </summary>
        public byte byMedia;
        /// <summary>
        /// 总线, 0-ATA, 1-SATA, 2-USB, 3-SDIO, 4-SCSI
        /// BUS, 0-ATA, 1-SATA, 2-USB, 3-SDIO, 4-SCSI main line 0-ATA, 1-SATA, 2-USB, 3-SDIO, 4-SCSI
        /// </summary>
        public byte byBUS;
        /// <summary>
        /// 卷类型, 0-物理卷, 1-Raid卷, 2-VG虚拟卷, 3-ISCSI, 4-独立物理卷, 5-全局热备卷, 6-NAS卷(包括FTP, SAMBA, NFS)
        /// volume type, 0-physics, 1-Raid, 2- VG virtual 3-ISCSI, 4-Invidual Physical Volume, 5-VolumeGroup, 6-NAS ( FTP, SAMBA, NFS), 7-Invidual Raid Volume
        /// </summary>
        public byte byVolume;
        /// <summary>
        /// 物理硬盘状态, 取值为 NET_STORAGE_DEV_OFFLINE 和 NET_STORAGE_DEV_RUNNING 等
        /// Physics disk state, 0-physics disk offline state 1-physics disk 2- RAID activity 3- RAID sync 4-RAID hotspare 5-RAID invalidation 6- RAID re-creation 7- RAID delete
        /// </summary>
        public byte byState;
        /// <summary>
        /// 同类设备存储接口的物理编号
        /// storage interface of devices of same type logic number
        /// </summary>
        public int nPhysicNo;
        /// <summary>
        /// 同类设备存储接口的逻辑编号
        /// storage interface of devices of same type physics number
        /// </summary>
        public int nLogicNo;
        /// <summary>
        /// 上级存储组名称
        /// superior storage group name
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string szParent;
        /// <summary>
        /// 设备模块
        /// device module
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string szModule;
        /// <summary>
        /// 设备序列号
        /// device serial number
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48)]
        public string szSerial;
        /// <summary>
        /// 固件版本
        /// Firmware version
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szFirmware;
        /// <summary>
        /// 分区数
        /// partition number
        /// </summary>
        public int nPartitionNum;
        /// <summary>
        /// 分区信息
        /// partition info
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public NET_A_STORAGE_PARTITION[] stuPartitions;
        /// <summary>
        /// RAID信息, 只对RAID有效(byVolume == 1)
        /// Raid info, for RAID use only(byVolume == 1)
        /// </summary>
        public NET_STORAGE_RAID stuRaid;
        /// <summary>
        /// ISCSI信息, 只对ISCSI盘有效(byVolume == 3)
        /// Iscsi info, for iscsi use only (byVolume == 2)
        /// </summary>
        public NET_ISCSI_TARGET stuISCSI;
        /// <summary>
        /// 扩展柜使能
        /// tank enable
        /// </summary>
        public bool abTank;
        /// <summary>
        /// 硬盘所在扩展柜信息, abTank为TRUE时有效
        /// tank info, effective when abTank = TRUE
        /// </summary>
        public NET_STORAGE_TANK stuTank;
        /// <summary>
        /// 硬盘电源状态
        /// hard disk power mode
        /// </summary>
        public EM_STORAGE_DISK_POWERMODE emPowerMode;
        /// <summary>
        /// 硬盘预检状态
        /// pre disk check(EVS)
        /// </summary>
        public EM_STORAGE_DISK_PREDISKCHECK emPreDiskCheck;
        /// <summary>
        /// 设备操作状态: 0: 正常工作状态, 1: 休眠中, 2: 等待格式化, 3: 格式化进行中,
        /// 4: 等待碎片整理, 5: 碎片整理中, 6: 等待创建RAID 7: 创建RAID中, 8: 等待删除RAID, 9: 删除RAID中,
        /// 10: 等待文件系统修复, 11: 文件系统修复中, 12: 等待预检, 13: 正在预检
        /// Equipment operation status: 0: normal working state, 1: sleeping, 2: waiting for formatting, 3: formatting in progress,
        /// 4: waiting for defragmentation, 5: defragmenting, 6: waiting for RAID creation7: In creating raid, 8: waiting to delete raid, 9: deleting raid,
        /// 10: waiting for file system repair, 11: file system repair, 12: waiting for pre inspection, 13: pre inspection
        /// </summary>
        public int nOpState;
    }
}