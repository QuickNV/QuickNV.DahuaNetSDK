namespace Dahua.Api.Struct.Config
{
    /************************************************************************
    ** 配置命令 对应CLIENT_GetNewDevConfig和CLIENT_SetNewDevConfig接口
    ***********************************************************************/
    /// <summary>
    /// Configuration command  CLIENT_GetNewDevConfig / CLIENT_SetNewDevConfig 
    /// 配置命令 对应 CLIENT_GetNewDevConfig 和 CLIENT_SetNewDevConfig 接口
    /// </summary>
    public static class SDK_NEWDEVCONFIG_CMD
    {
        /// <summary>
        /// 通道名称(对应 AV_CFG_ChannelName)
        /// </summary>
        public const string CFG_CMD_CHANNELTITLE = "ChannelTitle";
        /// <summary>
        /// RTSP的配置( 对应 CFG_RTSP_INFO_IN和CFG_RTSP_INFO_OUT )
        /// </summary>
        public const string CFG_CMD_RTSP = "RTSP";
        /// <summary>
        /// ecording storage point mapping configuration (corresponding to NET_A_CFG_RECORDTOSTORAGEPOINT_INFO)
        /// 录像存储点映射配置(对应 NET_A_CFG_RECORDTOSTORAGEPOINT_INFO)
        /// </summary>
        public const string CFG_CMD_RECORD_STORAGEPOINT = "RecordStoragePoint";
        /// <summary>
        /// Video storage point mapping configuration extension (corresponding to NET_A_CFG_RECORDTOSTORAGEPOINT_EX_INFO)
        /// 录像存储点映射配置扩展 (对应 NET_A_CFG_RECORDTOSTORAGEPOINT_EX_INFO)
        /// </summary>
        public const string CFG_CMD_RECORD_STORAGEPOINT_EX = "RecordStoragePoint";
        /// <summary>
        /// UPnP configuration extension (corresponding to NET_A_CFG_UPNP_INFO)
        /// UPnP配置(对应 NET_A_CFG_UPNP_INFO )
        /// </summary>
        public const string CFG_CMD_UPNP = "UPnP";
        /// <summary>
        /// Timed Recording Configuration (corresponding to NET_CFG_RECORD_INFO)
        /// 定时录像配置(对应 NET_CFG_RECORD_INFO)
        /// </summary>
        public const string CFG_CMD_RECORD = "Record";
        /// <summary>
        /// Fish eye details configuration (corresponding to NET_A_CFG_FISHEYE_DETAIL_INFO)
        /// 鱼眼详细信息配置(NET_A_CFG_FISHEYE_DETAIL_INFO)
        /// </summary>
        public const string CFG_CMD_FISHEYE_INFO = "FishEye";
        /// <summary>
        /// Login Failure Alarm Configuration (corresponding to NET_A_CFG_LOGIN_FAILURE_ALARM)
        /// 登陆失败报警配置(对应结构体 NET_A_CFG_LOGIN_FAILURE_ALARM)
        /// </summary>
        public const string CFG_CMD_LOGIN_FAILURE_ALARM = "LoginFailureAlarm";
        /// <summary>
        /// Fog penetration setting configuration (corresponding to NET_A_CFG_VIDEOINDEFOG_LIST)
        /// 透雾设置配置(对应结构体 NET_A_CFG_VIDEOINDEFOG_LIST )
        /// </summary>
        public const string CFG_CMD_VIDEOINDEFOG = "VideoInDefog";
    }
}