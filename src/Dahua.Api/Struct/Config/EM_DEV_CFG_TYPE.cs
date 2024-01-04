namespace Dahua.Api.Struct.Config
{
    /// <summary>
    /// Configuration type
    /// 配置类型
    /// </summary>
    public enum EM_DEV_CFG_TYPE
    {
        /// <summary>
        /// Device property setup
        /// 设备属性配置
        /// </summary>
        DEVICECFG = 0x0001,
        /// <summary>
        /// Network setup 
        /// 网络配置
        /// </summary>
        NETCFG = 0x0002,
        /// <summary>
        /// Video channel setup
        /// 图象通道配置
        /// </summary>
        CHANNELCFG = 0x0003,
        /// <summary>
        /// Preview parameter setup
        /// 预览参数配置
        /// </summary>
        PREVIEWCFG = 0x0004,
        /// <summary>
        /// Record setup
        /// 录像配置
        /// </summary>
        RECORDCFG = 0x0005,
        /// <summary>
        /// COM property setup
        /// 串口属性配置
        /// </summary>
        COMMCFG = 0x0006,
        /// <summary>
        /// Alarm property setup
        /// 报警属性配置
        /// </summary>
        ALARMCFG = 0x0007,
        /// <summary>
        /// DVR time setup
        /// DVR时间配置
        /// </summary>
        TIMECFG = 0x0008,
        /// <summary>
        /// Audio talk parameter setup 
        /// 对讲参数配置
        /// </summary>
        TALKCFG = 0x0009,
        /// <summary>
        /// Auto matrix setup， corresponding to NET_DEV_AUTOMT_CFG
        /// 自动维护配置,对应结构体NET_DEV_AUTOMT_CFG
        /// </summary>
        AUTOMTCFG = 0x000A,
        /// <summary>
        /// Local matrix control strategy setup
        /// 本机矩阵控制策略配置
        /// </summary>
        VEDIO_MARTIX = 0x000B,
        /// <summary>
        /// Multiple DDNS setup
        /// 多ddns服务器配置
        /// </summary>
        MULTI_DDNS = 0x000C,
        /// <summary>
        /// Snapshot corresponding setup 
        /// 抓图相关配置
        /// </summary>
        SNAP_CFG = 0x000D,
        /// <summary>
        /// HTTP path setup 
        /// HTTP路径配置
        /// </summary>
        WEB_URL_CFG = 0x000E,
        /// <summary>
        /// FTP upload setup
        /// FTP上传配置
        /// </summary>
        FTP_PROTO_CFG = 0x000F,
        /// <summary>
        /// Plaform embedded setup. Now the channel parameter represents the platform type.  channel=4:Bell alcatel;channel=10: Netview;channel=11:U CNC  channel = 51 AMP
        /// 平台接入配置,此时channel参数代表平台类型,channel=4： 代表贝尔阿尔卡特；channel=10：代表ZX力维；channel=11：代表U网通；channel=51：代表天地阳光
        /// </summary>
        INTERVIDEO_CFG = 0x0010,
        /// <summary>
        /// Privacy mask setup
        /// 区域遮挡配置
        /// </summary>
        VIDEO_COVER = 0x0011,
        /// <summary>
        /// Transmission strategy. Video quality\Fluency
        /// 传输策略配置,画质优先\流畅性优先
        /// </summary>
        TRANS_STRATEGY = 0x0012,
        /// <summary>
        /// Record download strategy setup:high-speed\general download
        /// 录象下载策略配置,高速下载\普通下载
        /// </summary>
        DOWNLOAD_STRATEGY = 0x0013,
        /// <summary>
        /// Video watermark setup
        /// 图象水印配置
        /// </summary>
        WATERMAKE_CFG = 0x0014,
        /// <summary>
        /// Wireless network setup
        /// 无线网络配置
        /// </summary>
        WLAN_CFG = 0x0015,
        /// <summary>
        /// Search wireless device setup
        /// 搜索无线设备配置
        /// </summary>
        WLAN_DEVICE_CFG = 0x0016,
        /// <summary>
        /// Auto register parameter setup, NET_DEV_REGISTER_SERVER
        /// 主动注册参数配置,NET_DEV_REGISTER_SERVER
        /// </summary>
        REGISTER_CFG = 0x0017,
        /// <summary>
        /// Camera property setup < NET_A_DEV_CAMERA_CFG >
        /// 摄像头属性配置 < NET_A_DEV_CAMERA_CFG >
        /// </summary>
        CAMERA_CFG = 0x0018,
        /// <summary>
        /// IR alarm setup
        /// 红外报警配置
        /// </summary>
        INFRARED_CFG = 0x0019,
        /// <summary>
        /// Sniffer setup
        /// Sniffer抓包配置
        /// </summary>
        SNIFFER_CFG = 0x001A,
        /// <summary>
        /// Mail setup < NET_A_DEV_MAIL_CFG >
        /// 邮件配置 < NET_A_DEV_MAIL_CFG >
        /// </summary>
        MAIL_CFG = 0x001B,
        /// <summary>
        /// DNS setup
        /// DNS服务器配置
        /// </summary>
        DNS_CFG = 0x001C,
        /// <summary>
        /// NTP setup
        /// NTP配置
        /// </summary>
        NTP_CFG = 0x001D,
        /// <summary>
        /// Audio detection setup 
        /// 音频检测配置
        /// </summary>
        AUDIO_DETECT_CFG = 0x001E,
        /// <summary>
        /// Storage position setup 
        /// 存储位置配置
        /// </summary>
        STORAGE_STATION_CFG = 0x001F,
        /// <summary>
        /// PTZ operation property(It is invalid now. Please use CLIENT_GetPtzOptAttr to get PTZ operation property.)
        /// 云台操作属性(已经废除,请使用CLIENT_GetPtzOptAttr获取云台操作属性)
        /// </summary>
        PTZ_OPT_CFG = 0x0020,
        /// <summary>
        /// Daylight Saving Time (DST)setup
        /// 夏令时配置
        /// </summary>
        DST_CFG = 0x0021,
        /// <summary>
        /// Alarm center setup
        /// 报警中心配置
        /// </summary>
        ALARM_CENTER_CFG = 0x0022,
        /// <summary>
        /// VIdeo OSD setup
        /// 视频OSD叠加配置
        /// </summary>
        VIDEO_OSD_CFG = 0x0023,
        /// <summary>
        /// CDMA\GPRS configuration
        /// CDMA\GPRS网络配置
        /// </summary>
        CDMAGPRS_CFG = 0x0024,
        /// <summary>
        /// IP Filter configuration
        /// IP过滤配置
        /// </summary>
        IPFILTER_CFG = 0x0025,
        /// <summary>
        /// Talk encode configuration
        /// 语音对讲编码配置
        /// </summary>
        TALK_ENCODE_CFG = 0x0026,
        /// <summary>
        /// The length of the video package configuration
        /// 录像打包长度配置
        /// </summary>
        RECORD_PACKET_CFG = 0x0027,
        /// <summary>
        /// SMS MMS configuration
        /// 短信MMS配置
        /// </summary>
        MMS_CFG = 0x0028,
        /// <summary>
        /// SMS to activate the wireless connection configuration
        /// 短信激活无线连接配置
        /// </summary>
        SMSACTIVATION_CFG = 0x0029,
        /// <summary>
        /// Dial-up activation of a wireless connection configuration
        /// 拨号激活无线连接配置
        /// </summary>
        DIALINACTIVATION_CFG = 0x002A,
        /// <summary>
        /// Capture network configuration
        /// 网络抓包配置
        /// </summary>
        SNIFFER_CFG_EX = 0x0030,
        /// <summary>
        /// Download speed limit
        /// 下载速度限制
        /// </summary>
        DOWNLOAD_RATE_CFG = 0x0031,
        /// <summary>
        /// Panorama switch alarm configuration
        /// 全景切换报警配置
        /// </summary>
        PANORAMA_SWITCH_CFG = 0x0032,
        /// <summary>
        /// Lose focus alarm configuration
        /// 失去焦点报警配置
        /// </summary>
        LOST_FOCUS_CFG = 0x0033,
        /// <summary>
        /// Alarm decoder configuration
        /// 报警解码器配置
        /// </summary>
        ALARM_DECODE_CFG = 0x0034,
        /// <summary>
        /// Video output configuration
        /// 视频输出参数配置
        /// </summary>
        VIDEOOUT_CFG = 0x0035,
        /// <summary>
        /// Preset enable configuration
        /// 预制点使能配置
        /// </summary>
        POINT_CFG = 0x0036,
        /// <summary>
        /// IP conflication configurationIp
        /// Ip冲突检测报警配置
        /// </summary>
        IP_COLLISION_CFG = 0x0037,
        /// <summary>
        /// OSD overlay enable configuration
        /// OSD叠加使能配置
        /// </summary>
        OSD_ENABLE_CFG = 0x0038,
        /// <summary>
        /// Local alarm configuration(Structure NET_ALARMIN_CFG_EX)
        /// 本地报警配置(结构体NET_ALARMIN_CFG_EX)
        /// </summary>
        LOCALALARM_CFG = 0x0039,
        /// <summary>
        /// Network alarm configuration(Structure NET_ALARMIN_CFG_EX)
        /// 网络报警配置(结构体NET_ALARMIN_CFG_EX)
        /// </summary>
        NETALARM_CFG = 0x003A,
        /// <summary>
        /// Motion detection configuration(Structure NET_MOTION_DETECT_CFG_EX)
        /// 动检报警配置(结构体NET_MOTION_DETECT_CFG_EX)
        /// </summary>
        MOTIONALARM_CFG = 0x003B,
        /// <summary>
        /// Video loss configuration(Structure NET_VIDEO_LOST_CFG_EX)
        /// 视频丢失报警配置(结构体NET_VIDEO_LOST_CFG_EX)
        /// </summary>
        VIDEOLOSTALARM_CFG = 0x003C,
        /// <summary>
        /// Camera masking configuration(Structure NET_BLIND_CFG_EX)
        /// 视频遮挡报警配置(结构体NET_BLIND_CFG_EX)
        /// </summary>
        BLINDALARM_CFG = 0x003D,
        /// <summary>
        /// HDD alarm configuration(Structure NET_DISK_ALARM_CFG_EX)
        /// 硬盘报警配置(结构体NET_DISK_ALARM_CFG_EX)
        /// </summary>
        DISKALARM_CFG = 0x003E,
        /// <summary>
        /// Network disconnection alarm configuration(Structure NET_NETBROKEN_ALARM_CFG_EX)
        /// 网络中断报警配置(结构体NET_NETBROKEN_ALARM_CFG_EX)
        /// </summary>
        NETBROKENALARM_CFG = 0x003F,
        /// <summary>
        /// Digital channel info of front encoders(Hybrid DVR use,Structure DEV_ENCODER_CFG)
        /// 数字通道的前端编码器信息（混合DVR使用,结构体DEV_ENCODER_CFG）
        /// </summary>
        ENCODER_CFG = 0x0040,
        /// <summary>
        /// TV adjust configuration(Now the channel parameter represents the TV numble(from 0), Structure DHDEV_TVADJUST_CFG)
        /// TV调节配置（channel代表TV号(0开始),类型结构体）
        /// </summary>
        TV_ADJUST_CFG = 0x0041,
        /// <summary>
        /// about vehicle configuration
        /// 车载相关配置,北京公交使用
        /// </summary>
        ABOUT_VEHICLE_CFG = 0x0042,
        /// <summary>
        /// ATM ability information
        /// 获取atm叠加支持能力信息
        /// </summary>
        ATM_OVERLAY_ABILITY = 0x0043,
        /// <summary>
        /// ATM overlay configuration
        /// atm叠加配置,新atm特有
        /// </summary>
        ATM_OVERLAY_CFG = 0x0044,
        /// <summary>
        /// Decoder tour configuration
        /// 解码器解码轮巡配置
        /// </summary>
        DECODER_TOUR_CFG = 0x0045,
        /// <summary>
        /// SIP configuration
        /// SIP配置
        /// </summary>
        SIP_CFG = 0x0046,
        /// <summary>
        /// wifi ap configuration
        ///  wifi ap配置
        /// </summary>
        VICHILE_WIFI_AP_CFG = 0x0047,
        /// <summary>
        /// Static
        /// 静态报警配置
        /// </summary>
        STATICALARM_CFG = 0x0048,
        /// <summary>
        /// decode policy configuration(Structure DHDEV_DECODEPOLICY_CFG,channel start with 0)
        /// 设备的解码策略配置(结构体DHDEV_DECODEPOLICY_CFG,channel为解码通道0开始)
        /// </summary>
        DECODE_POLICY_CFG = 0x0049,
        /// <summary>
        /// Device relative config (Structure DHDEV_MACHINE_CFG)
        /// 机器相关的配置(结构体DHDEV_MACHINE_CFG)
        /// </summary>
        MACHINE_CFG = 0x004A,
        /// <summary>
        /// MACconflication configuration(Structure ALARM_MAC_COLLISION_CFG)
        /// MAC冲突检测配置(结构体 ALARM_MAC_COLLISION_CFG)
        /// </summary>
        MAC_COLLISION_CFG = 0x004B,
        /// <summary>
        /// RTSP configuration(structure DHDEV_RTSP_CFG)
        /// RTSP配置(对应结构体DHDEV_RTSP_CFG)
        /// </summary>
        RTSP_CFG = 0x004C,
        /// <summary>
        /// 232 com card signal event configuration(structure COM_CARD_SIGNAL_LINK_CFG)
        /// 232串口卡号信号事件配置(对应结构体COM_CARD_SIGNAL_LINK_CFG)
        /// </summary>
        NET_232_COM_CARD_CFG = 0x004E,
        /// <summary>
        /// 485 com card signal event configuration(structure COM_CARD_SIGNAL_LINK_CFG)
        /// 485串口卡号信号事件配置(对应结构体COM_CARD_SIGNAL_LINK_CFG)
        /// </summary>
        NET_485_COM_CARD_CFG = 0x004F,
        /// <summary>
        /// extend FTP upload setup(Structure DHDEV_FTP_PROTO_CFG_EX)
        /// FTP上传扩展配置(对应结构体DHDEV_FTP_PROTO_CFG_EX)
        /// </summary>
        FTP_PROTO_CFG_EX = 0x0050,
        /// <summary>
        /// SYSLOG remote server config (Structure DHDEV_SYSLOG_REMOTE_SERVER)
        /// SYSLOG 远程服务器配置(对应结构体DHDEV_SYSLOG_REMOTE_SERVER)
        /// </summary>
        SYSLOG_REMOTE_SERVER = 0x0051,
        /// <summary>
        /// Extended com configuration(structure DHDEV_COMM_CFG_EX)
        /// 扩展串口属性配置(对应结构体DHDEV_COMM_CFG_EX)  
        /// </summary>
        COMMCFG_EX = 0x0052,
        /// <summary>
        /// net card configuration(structure DHDEV_NETCARD_CFG)
        /// 卡口信息配置(对应结构体DHDEV_NETCARD_CFG)
        /// </summary>
        NETCARD_CFG = 0x0053,
        /// <summary>
        /// Video backup format(structure DHDEV_BACKUP_VIDEO_FORMAT)
        /// 视频备份格式配置(对应结构体DHDEV_BACKUP_VIDEO_FORMAT)
        /// </summary>
        BACKUP_VIDEO_FORMAT = 0x0054,
        /// <summary>
        /// stream encrypt configuration(structure DHEDV_STREAM_ENCRYPT)
        /// 码流加密配置(对应结构体DHEDV_STREAM_ENCRYPT)
        /// </summary>
        STREAM_ENCRYPT_CFG = 0x0055,
        /// <summary>
        /// IP filter extended configuration(structure DHDEV_IPIFILTER_CFG_EX)
        /// IP过滤配置扩展(对应结构体DHDEV_IPIFILTER_CFG_EX)
        /// </summary>
        IPFILTER_CFG_EX = 0x0056,
        /// <summary>
        /// custom configuration(structure DHDEV_CUSTOM_CFG)
        /// 用户自定义配置(对应结构体DHDEV_CUSTOM_CFG)
        /// </summary>
        CUSTOM_CFG = 0x0057,
        /// <summary>
        /// Search wireless device extended setup(structure DHDEV_WLAN_DEVICE_LIST_EX)
        /// 搜索无线设备扩展配置(对应结构体DHDEV_WLAN_DEVICE_LIST_EX)
        /// </summary>
        WLAN_DEVICE_CFG_EX = 0x0058,
        /// <summary>
        /// ACC power off configuration(structure DHDEV_ACC_POWEROFF_CFG)
        /// ACC断线事件配置(对应结构体DHDEV_ACC_POWEROFF_CFG)
        /// </summary>
        ACC_POWEROFF_CFG = 0x0059,
        /// <summary>
        /// explosion proof alarm configuration(structure DHDEV_EXPLOSION_PROOF_CFG)
        /// 防爆盒报警事件配置(对应结构体DHDEV_EXPLOSION_PROOF_CFG)
        /// </summary>
        EXPLOSION_PROOF_CFG = 0x005a,
        /// <summary>
        /// Network extended setup(struct DHDEV_NET_CFG_EX)
        /// 网络扩展配置(对应结构体DHDEV_NET_CFG_EX)
        /// </summary>
        NETCFG_EX = 0x005b,
        /// <summary>
        /// light control config(struct DHDEV_LIGHTCONTROL_CFG)
        /// 灯光控制配置(对应结构体DHDEV_LIGHTCONTROL_CFG)
        /// </summary>
        LIGHTCONTROL_CFG = 0x005c,
        /// <summary>
        /// 3G flow info config(struct DHDEV_3GFLOW_INFO_CFG)
        /// 3G流量信息配置(对应结构体DHDEV_3GFLOW_INFO_CFG)
        /// </summary>
        NET_3GFLOW_CFG = 0x005d,
        /// <summary>
        /// IPv6 config(struct DHDEV_IPV6_CFG)
        /// IPv6配置(对应结构体DHDEV_IPV6_CFG)
        /// </summary>
        IPV6_CFG = 0x005e,
        /// <summary>
        /// Snmp config(struct DHDEV_NET_SNMP_CFG)
        /// Snmp配置(对应结构体DHDEV_NET_SNMP_CFG), 设置完成后需要重启设备
        /// </summary>
        SNMP_CFG = 0x005f,
        /// <summary>
        /// snap control config(struct DHDEV_SNAP_CONTROL_CFG)
        /// 抓图开关配置(对应结构体DHDEV_SNAP_CONTROL_CFG)
        /// </summary>
        SNAP_CONTROL_CFG = 0x0060,
        /// <summary>
        /// GPS mode config(struct DHDEV_GPS_MODE_CFG)
        /// GPS定位模式配置(对应结构体DHDEV_GPS_MODE_CFG)
        /// </summary>
        GPS_MODE_CFG = 0x0061,
        /// <summary>
        /// Snap upload config(struct DHDEV_SNAP_UPLOAD_CFG)
        /// 图片上传配置信息(对应结构体 DHDEV_SNAP_UPLOAD_CFG)
        /// </summary>
        SNAP_UPLOAD_CFG = 0x0062,
        /// <summary>
        /// Speed limit config(struct DHDEV_SPEED_LIMIT_CFG)
        /// 限速配置信息(对应结构体DHDEV_SPEED_LIMIT_CFG)
        /// </summary>
        SPEED_LIMIT_CFG = 0x0063,
        /// <summary>
        /// iSCSI config(struct DHDEV_ISCSI_CFG), need reboot
        /// iSCSI配置(对应结构体DHDEV_ISCSI_CFG), 设置完成后需要重启设备
        /// </summary>
        ISCSI_CFG = 0x0064,
        /// <summary>
        /// wifi config(struc DHDEV_WIRELESS_ROUTING_CFG)
        /// 无线路由配置(对应结构体DHDEV_WIRELESS_ROUTING_CFG)
        /// </summary>
        WIRELESS_ROUTING_CFG = 0x0065,
        /// <summary>
        /// enclosure config(stuct DHDEV_ENCLOSURE_CFG)
        /// 电子围栏配置(对应结构体DHDEV_ENCLOSURE_CFG)
        /// </summary>
        ENCLOSURE_CFG = 0x0066,
        /// <summary>
        /// enclosure version config(struct DHDEV_ENCLOSURE_VERSION_CFG)
        /// 电子围栏版本号配置(对应结构体DHDEV_ENCLOSURE_VERSION_CFG)
        /// </summary>
        ENCLOSURE_VERSION_CFG = 0x0067,
        /// <summary>
        /// Raid event config(struct DHDEV_RAID_EVENT_CFG)
        /// Raid事件配置(对应结构体DHDEV_RAID_EVENT_CFG)
        /// </summary>
        RIAD_EVENT_CFG = 0x0068,
        /// <summary>
        /// fire alarm config(struct DHDEV_FIRE_ALARM_CFG)
        /// 火警报警配置(对应结构体DHDEV_FIRE_ALARM_CFG)
        /// </summary>
        FIRE_ALARM_CFG = 0x0069,
        /// <summary>
        /// local alarm name config(string like "Name1&&name2&&name3...")
        /// 本地名称报警配置(对应Name1&&name2&&name3...格式字符串)
        /// </summary>
        LOCALALARM_NAME_CFG = 0x006a,
        /// <summary>
        /// urgency storage config(struct DHDEV_URGENCY_RECORD_CFG)
        /// 紧急存储配置(对应结构体DHDEV_URGENCY_RECORD_CFG)
        /// </summary>
        URGENCY_RECORD_CFG = 0x0070,
        /// <summary>
        /// elevator parameter config(struct DHDEV_ELEVATOR_ATTRI_CFG)
        /// 电梯运行参数配置(对应结构体DHDEV_ELEVATOR_ATTRI_CFG)
        /// </summary>
        ELEVATOR_ATTRI_CFG = 0x0071,
        /// <summary>
        /// TM overlay function. For latest ATM series product only.  Support devices of 32-channel or higher.( struct DHDEV_ATM_OVERLAY_CONFIG_EX)
        /// atm叠加配置,新atm特有,支持大于32通道的设备(对应结构体DHDEV_ATM_OVERLAY_CONFIG_EX)
        /// </summary>
        ATM_OVERLAY_CFG_EX = 0x0072,
        /// <summary>
        /// MAC filter config(struct DHDEV_MACFILTER_CFG)
        /// MAC过滤配置(对应结构体DHDEV_MACFILTER_CFG)
        /// </summary>
        MACFILTER_CFG = 0x0073,
        /// <summary>
        /// MAC,IP filter config(need ip,mac one to one corresponding)(struct DHDEV_MACIPFILTER_CFG)
        /// MAC,IP过滤(要求ip,mac是一一对应的)配置(对应结构体DHDEV_MACIPFILTER_CFG)
        /// </summary>
        MACIPFILTER_CFG = 0x0074,
        /// <summary>
        /// stream encrypt(encryot plan)(struct DHEDV_STREAM_ENCRYPT)
        /// 码流加密(加密计划)配置(对应结构体DHEDV_STREAM_ENCRYPT)
        /// </summary>
        STREAM_ENCRYPT_TIME_CFG = 0x0075,
        /// <summary>
        /// limit bit rate config(struct DHDEV_LIMIT_BIT_RATE) 
        /// 限码流配置(对应结构体 DHDEV_LIMIT_BIT_RATE) 
        /// </summary>
        LIMIT_BIT_RATE_CFG = 0x0076,
        /// <summary>
        /// snap extern config(struct DHDEV_SNAP_CFG_EX)
        /// 抓图相关配置扩展(对应结构体 DHDEV_SNAP_CFG_EX)
        /// </summary>
        SNAP_CFG_EX = 0x0077,
        /// <summary>
        /// decoder url config(struct DHDEV_DECODER_URL_CFG)
        /// 解码器url配置(对应结构体DHDEV_DECODER_URL_CFG)
        /// </summary>
        DECODER_URL_CFG = 0x0078,
        /// <summary>
        /// toyr enable config(struct DHDEV_TOUR_ENABLE_CFG)
        /// 轮巡使能配置(对应结构体DHDEV_TOUR_ENABLE_CFG)
        /// </summary>
        TOUR_ENABLE_CFG = 0x0079,
        /// <summary>
        /// wifi ap extern config(struct DHDEV_VEHICLE_WIFI_AP_CFG_EX)
        /// wifi ap配置扩展(对应结构体DHDEV_VEHICLE_WIFI_AP_CFG_EX)
        /// </summary>
        VICHILE_WIFI_AP_CFG_EX = 0x007a,
        /// <summary>
        /// encoder extern config(struct DEV_ENCODER_CFG_EX)
        /// 数字通道的前端编码器信息扩展,(对应结构体 DEV_ENCODER_CFG_EX)
        /// </summary>
        ENCODER_CFG_EX = 0x007b,
        /// <summary>
        /// encoder extern config(struct DEV_ENCODER_CFG_EX2)
        /// 数字通道的前端编码器信息扩展,(对应结构体 DEV_ENCODER_CFG_EX2)
        /// </summary>
        ENCODER_CFG_EX2 = 0x007c,
    }
}