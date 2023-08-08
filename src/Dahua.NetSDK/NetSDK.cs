using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Dahua.NetSDK
{
    public static class NETClient
    {
        #region << constant >>

        /// <summary>
        /// whether to throw an execption.
        /// 是否抛异常
        /// </summary>
        private static bool m_IsThrowErrorMessage = false;

        /// <summary>
        /// Query splice screen(struct NET_COMPOSITE_CHANNEL)
        /// </summary>
        public static uint NET_DEVSTATE_COMPOSITE_CHN = 0x0047;

        /// <summary>
        /// en-us language
        /// 英文错误码对应的错误信息
        /// </summary>
        private static Dictionary<EM_ErrorCode, string> en_us_String = new Dictionary<EM_ErrorCode, string>()
        {
            {EM_ErrorCode.NET_NOERROR,"No error"},
            {EM_ErrorCode.NET_ERROR,"Unknown error"},
            {EM_ErrorCode.NET_SYSTEM_ERROR,"Windows system error"},
            {EM_ErrorCode.NET_NETWORK_ERROR,"Protocol error it may result from network timeout"},
            {EM_ErrorCode.NET_DEV_VER_NOMATCH,"Device protocol does not match"},
            {EM_ErrorCode.NET_INVALID_HANDLE,"Handle is invalid"},
            {EM_ErrorCode.NET_OPEN_CHANNEL_ERROR,"Failed to open channel"},
            {EM_ErrorCode.NET_CLOSE_CHANNEL_ERROR,"Failed to close channel"},
            {EM_ErrorCode.NET_ILLEGAL_PARAM,"User parameter is illegal"},
            {EM_ErrorCode.NET_SDK_INIT_ERROR,"SDK initialization error"},
            {EM_ErrorCode.NET_SDK_UNINIT_ERROR,"SDK clear error"},
            {EM_ErrorCode.NET_RENDER_OPEN_ERROR,"Error occurs when apply for render resources"},
            {EM_ErrorCode.NET_DEC_OPEN_ERROR,"Error occurs when opening the decoder library"},
            {EM_ErrorCode.NET_DEC_CLOSE_ERROR,"Error occurs when closing the decoder library"},
            {EM_ErrorCode.NET_MULTIPLAY_NOCHANNEL,"The detected channel number is 0 in multiple-channel preview"},
            {EM_ErrorCode.NET_TALK_INIT_ERROR,"Failed to initialize record library"},
            {EM_ErrorCode.NET_TALK_NOT_INIT,"The record library has not been initialized"},
            {EM_ErrorCode.NET_TALK_SENDDATA_ERROR,"Error occurs when sending out audio data"},
            {EM_ErrorCode.NET_REAL_ALREADY_SAVING,"The real-time has been protected"},
            {EM_ErrorCode.NET_NOT_SAVING,"The real-time data has not been save"},
            {EM_ErrorCode.NET_OPEN_FILE_ERROR,"Error occurs when opening the file"},
            {EM_ErrorCode.NET_PTZ_SET_TIMER_ERROR,"Failed to enable PTZ to control timer"},
            {EM_ErrorCode.NET_RETURN_DATA_ERROR,"Error occurs when verify returned data"},
            {EM_ErrorCode.NET_INSUFFICIENT_BUFFER,"There is no sufficient buffer"},
            {EM_ErrorCode.NET_NOT_SUPPORTED,"The current SDK does not support this function"},
            {EM_ErrorCode.NET_NO_RECORD_FOUND,"There is no searched result"},
            {EM_ErrorCode.NET_NOT_AUTHORIZED,"You have no operation right"},
            {EM_ErrorCode.NET_NOT_NOW,"Can not operate right now"},
            {EM_ErrorCode.NET_NO_TALK_CHANNEL,"There is no audio talk channel"},
            {EM_ErrorCode.NET_NO_AUDIO,"There is no audio"},
            {EM_ErrorCode.NET_NO_INIT,"The network SDK has not been initialized"},
            {EM_ErrorCode.NET_DOWNLOAD_END,"The download completed"},
            {EM_ErrorCode.NET_EMPTY_LIST,"There is no searched result"},
            {EM_ErrorCode.NET_ERROR_GETCFG_SYSATTR,"Failed to get system property setup"},
            {EM_ErrorCode.NET_ERROR_GETCFG_SERIAL,"Failed to get SN"},
            {EM_ErrorCode.NET_ERROR_GETCFG_GENERAL,"Failed to get general property"},
            {EM_ErrorCode.NET_ERROR_GETCFG_DSPCAP,"Failed to get DSP capacity description"},
            {EM_ErrorCode.NET_ERROR_GETCFG_NETCFG,"Failed to get network channel setup"},
            {EM_ErrorCode.NET_ERROR_GETCFG_CHANNAME,"Failed to get channel name"},
            {EM_ErrorCode.NET_ERROR_GETCFG_VIDEO,"Failed to get video property"},
            {EM_ErrorCode.NET_ERROR_GETCFG_RECORD,"Failed to get record setup"},
            {EM_ErrorCode.NET_ERROR_GETCFG_PRONAME,"Failed to get decoder protocol name"},
            {EM_ErrorCode.NET_ERROR_GETCFG_FUNCNAME,"Failed to get 232 COM function name"},
            {EM_ErrorCode.NET_ERROR_GETCFG_485DECODER,"Failed to get decoder property"},
            {EM_ErrorCode.NET_ERROR_GETCFG_232COM,"Failed to get 232 COM setup"},
            {EM_ErrorCode.NET_ERROR_GETCFG_ALARMIN,"Failed to get external alarm input setup"},
            {EM_ErrorCode.NET_ERROR_GETCFG_ALARMDET,"Failed to get motion detection alarm"},
            {EM_ErrorCode.NET_ERROR_GETCFG_SYSTIME,"Failed to get device time"},
            {EM_ErrorCode.NET_ERROR_GETCFG_PREVIEW,"Failed to get preview parameter"},
            {EM_ErrorCode.NET_ERROR_GETCFG_AUTOMT,"Failed to get audio maintenance setup"},
            {EM_ErrorCode.NET_ERROR_GETCFG_VIDEOMTRX,"Failed to get video matrix setup"},
            {EM_ErrorCode.NET_ERROR_GETCFG_COVER,"Failed to get privacy mask zone setup"},
            {EM_ErrorCode.NET_ERROR_GETCFG_WATERMAKE,"Failed to get video watermark setup"},
            {EM_ErrorCode.NET_ERROR_GETCFG_MULTICAST,"Failed to get config multicast port by channel"},
            {EM_ErrorCode.NET_ERROR_SETCFG_GENERAL,"Failed to modify general property"},
            {EM_ErrorCode.NET_ERROR_SETCFG_NETCFG,"Failed to modify channel setup"},
            {EM_ErrorCode.NET_ERROR_SETCFG_CHANNAME,"Failed to modify channel name"},
            {EM_ErrorCode.NET_ERROR_SETCFG_VIDEO,"Failed to modify video channel"},
            {EM_ErrorCode.NET_ERROR_SETCFG_RECORD,"Failed to modify record setup"},
            {EM_ErrorCode.NET_ERROR_SETCFG_485DECODER,"Failed to modify decoder property"},
            {EM_ErrorCode.NET_ERROR_SETCFG_232COM,"Failed to modify 232 COM setup"},
            {EM_ErrorCode.NET_ERROR_SETCFG_ALARMIN,"Failed to modify external input alarm setup"},
            {EM_ErrorCode.NET_ERROR_SETCFG_ALARMDET,"Failed to modify motion detection alarm setup"},
            {EM_ErrorCode.NET_ERROR_SETCFG_SYSTIME,"Failed to modify device time"},
            {EM_ErrorCode.NET_ERROR_SETCFG_PREVIEW,"Failed to modify preview parameter"},
            {EM_ErrorCode.NET_ERROR_SETCFG_AUTOMT,"Failed to modify auto maintenance setup"},
            {EM_ErrorCode.NET_ERROR_SETCFG_VIDEOMTRX,"Failed to modify video matrix setup"},
            {EM_ErrorCode.NET_ERROR_SETCFG_COVER,"Failed to modify privacy mask zone"},
            {EM_ErrorCode.NET_ERROR_SETCFG_WATERMAKE,"Failed to modify video watermark setup"},
            {EM_ErrorCode.NET_ERROR_SETCFG_WLAN,"Failed to modify wireless network information"},
            {EM_ErrorCode.NET_ERROR_SETCFG_WLANDEV,"Failed to select wireless network device"},
            {EM_ErrorCode.NET_ERROR_SETCFG_REGISTER,"Failed to modify the actively registration parameter setup"},
            {EM_ErrorCode.NET_ERROR_SETCFG_CAMERA,"Failed to modify camera property"},
            {EM_ErrorCode.NET_ERROR_SETCFG_INFRARED,"Failed to modify IR alarm setup"},
            {EM_ErrorCode.NET_ERROR_SETCFG_SOUNDALARM,"Failed to modify audio alarm setup"},
            {EM_ErrorCode.NET_ERROR_SETCFG_STORAGE,"Failed to modify storage position setup"},
            {EM_ErrorCode.NET_AUDIOENCODE_NOTINIT,"The audio encode port has not been successfully initialized"},
            {EM_ErrorCode.NET_DATA_TOOLONGH,"The data are too long"},
            {EM_ErrorCode.NET_UNSUPPORTED,"The device does not support current operation"},
            {EM_ErrorCode.NET_DEVICE_BUSY,"Device resources is not sufficient"},
            {EM_ErrorCode.NET_SERVER_STARTED,"The server has boot up"},
            {EM_ErrorCode.NET_SERVER_STOPPED,"The server has not fully boot up"},
            {EM_ErrorCode.NET_LISTER_INCORRECT_SERIAL,"Input serial number is not correct"},
            {EM_ErrorCode.NET_QUERY_DISKINFO_FAILED,"Failed to get HDD information"},
            {EM_ErrorCode.NET_ERROR_GETCFG_SESSION,"Failed to get connect session information"},
            {EM_ErrorCode.NET_USER_FLASEPWD_TRYTIME,"The password you typed is incorrect. You have exceeded the maximum number of retries"},
            {EM_ErrorCode.NET_LOGIN_ERROR_PASSWORD,"Password is not correct"},
            {EM_ErrorCode.NET_LOGIN_ERROR_USER,"The account does not exist"},
            {EM_ErrorCode.NET_LOGIN_ERROR_TIMEOUT,"Time out for log in returned value"},
            {EM_ErrorCode.NET_LOGIN_ERROR_RELOGGIN,"The account has logged in"},
            {EM_ErrorCode.NET_LOGIN_ERROR_LOCKED,"The account has been locked"},
            {EM_ErrorCode.NET_LOGIN_ERROR_BLACKLIST,"The account has been in the blocklist"},
            {EM_ErrorCode.NET_LOGIN_ERROR_BUSY,"Resources are not sufficient. System is busy now"},
            {EM_ErrorCode.NET_LOGIN_ERROR_CONNECT,"Time out. Please check network and try again"},
            {EM_ErrorCode.NET_LOGIN_ERROR_NETWORK,"Network connection failed"},
            {EM_ErrorCode.NET_LOGIN_ERROR_SUBCONNECT,"Successfully logged in the device but can not create video channel. Please check network connection"},
            {EM_ErrorCode.NET_LOGIN_ERROR_MAXCONNECT,"exceed the max connect number"},
            {EM_ErrorCode.NET_LOGIN_ERROR_PROTOCOL3_ONLY,"protocol 3 support"},
            {EM_ErrorCode.NET_LOGIN_ERROR_UKEY_LOST,"There is no USB or USB info error"},
            {EM_ErrorCode.NET_LOGIN_ERROR_NO_AUTHORIZED,"Client-end IP address has no right to login"},
            {EM_ErrorCode.NET_LOGIN_ERROR_USER_OR_PASSOWRD,"user or password error"},
            {EM_ErrorCode.NET_RENDER_SOUND_ON_ERROR,"Error occurs when Render library open audio"},
            {EM_ErrorCode.NET_RENDER_SOUND_OFF_ERROR,"Error occurs when Render library close audio"},
            {EM_ErrorCode.NET_RENDER_SET_VOLUME_ERROR,"Error occurs when Render library control volume"},
            {EM_ErrorCode.NET_RENDER_ADJUST_ERROR,"Error occurs when Render library set video parameter"},
            {EM_ErrorCode.NET_RENDER_PAUSE_ERROR,"Error occurs when Render library pause play"},
            {EM_ErrorCode.NET_RENDER_SNAP_ERROR,"Render library snapshot error"},
            {EM_ErrorCode.NET_RENDER_STEP_ERROR,"Render library stepper error"},
            {EM_ErrorCode.NET_RENDER_FRAMERATE_ERROR,"Error occurs when Render library set frame rate"},
            {EM_ErrorCode.NET_RENDER_DISPLAYREGION_ERROR,"Error occurs when Render lib setting show region"},
            {EM_ErrorCode.NET_RENDER_GETOSDTIME_ERROR,"An error occurred when Render library getting current play time"},
            {EM_ErrorCode.NET_GROUP_EXIST,"Group name has been existed"},
            {EM_ErrorCode.NET_GROUP_NOEXIST,"The group name does not exist"},
            {EM_ErrorCode.NET_GROUP_RIGHTOVER,"The group right exceeds the right list"},
            {EM_ErrorCode.NET_GROUP_HAVEUSER,"The group can not be removed since there is user in it"},
            {EM_ErrorCode.NET_GROUP_RIGHTUSE,"The user has used one of the group right. It can not be removed"},
            {EM_ErrorCode.NET_GROUP_SAMENAME,"New group name has been existed"},
            {EM_ErrorCode.NET_USER_EXIST,"The user name has been existed"},
            {EM_ErrorCode.NET_USER_NOEXIST,"The account does not exist"},
            {EM_ErrorCode.NET_USER_RIGHTOVER,"User right exceeds the group right"},
            {EM_ErrorCode.NET_USER_PWD,"Reserved account. It does not allow to be modified"},
            {EM_ErrorCode.NET_USER_FLASEPWD,"password is not correct"},
            {EM_ErrorCode.NET_USER_NOMATCHING,"Password is invalid"},
            {EM_ErrorCode.NET_USER_INUSE,"account in use"},
            {EM_ErrorCode.NET_ERROR_GETCFG_ETHERNET,"Failed to get network card setup"},
            {EM_ErrorCode.NET_ERROR_GETCFG_WLAN,"Failed to get wireless network information"},
            {EM_ErrorCode.NET_ERROR_GETCFG_WLANDEV,"Failed to get wireless network device"},
            {EM_ErrorCode.NET_ERROR_GETCFG_REGISTER,"Failed to get actively registration parameter"},
            {EM_ErrorCode.NET_ERROR_GETCFG_CAMERA,"Failed to get camera property"},
            {EM_ErrorCode.NET_ERROR_GETCFG_INFRARED,"Failed to get IR alarm setup"},
            {EM_ErrorCode.NET_ERROR_GETCFG_SOUNDALARM,"Failed to get audio alarm setup"},
            {EM_ErrorCode.NET_ERROR_GETCFG_STORAGE,"Failed to get storage position"},
            {EM_ErrorCode.NET_ERROR_GETCFG_MAIL,"Failed to get mail setup"},
            {EM_ErrorCode.NET_CONFIG_DEVBUSY,"Can not set right now"},
            {EM_ErrorCode.NET_CONFIG_DATAILLEGAL,"The configuration setup data are illegal"},
            {EM_ErrorCode.NET_ERROR_GETCFG_DST,"Failed to get DST setup"},
            {EM_ErrorCode.NET_ERROR_SETCFG_DST,"Failed to set DST"},
            {EM_ErrorCode.NET_ERROR_GETCFG_VIDEO_OSD,"Failed to get video osd setup"},
            {EM_ErrorCode.NET_ERROR_SETCFG_VIDEO_OSD,"Failed to set video osd"},
            {EM_ErrorCode.NET_ERROR_GETCFG_GPRSCDMA,"Failed to get CDMA\\GPRS configuration"},
            {EM_ErrorCode.NET_ERROR_SETCFG_GPRSCDMA,"Failed to set CDMA\\GPRS configuration"},
            {EM_ErrorCode.NET_ERROR_GETCFG_IPFILTER,"Failed to get IP Filter configuration"},
            {EM_ErrorCode.NET_ERROR_SETCFG_IPFILTER,"Failed to set IP Filter configuration"},
            {EM_ErrorCode.NET_ERROR_GETCFG_TALKENCODE,"Failed to get Talk Encode configuration"},
            {EM_ErrorCode.NET_ERROR_SETCFG_TALKENCODE,"Failed to set Talk Encode configuration"},
            {EM_ErrorCode.NET_ERROR_GETCFG_RECORDLEN,"Failed to get The length of the video package configuration"},
            {EM_ErrorCode.NET_ERROR_SETCFG_RECORDLEN,"Failed to set The length of the video package configuration"},
            {EM_ErrorCode.NET_DONT_SUPPORT_SUBAREA,"Not support Network hard disk partition"},
            {EM_ErrorCode.NET_ERROR_GET_AUTOREGSERVER,"Failed to get the register server information"},
            {EM_ErrorCode.NET_ERROR_CONTROL_AUTOREGISTER,"Failed to control actively registration"},
            {EM_ErrorCode.NET_ERROR_DISCONNECT_AUTOREGISTER,"Failed to disconnect actively registration"},
            {EM_ErrorCode.NET_ERROR_GETCFG_MMS,"Failed to get mms configuration"},
            {EM_ErrorCode.NET_ERROR_SETCFG_MMS,"Failed to set mms configuration"},
            {EM_ErrorCode.NET_ERROR_GETCFG_SMSACTIVATION,"Failed to get SMS configuration"},
            {EM_ErrorCode.NET_ERROR_SETCFG_SMSACTIVATION,"Failed to set SMS configuration"},
            {EM_ErrorCode.NET_ERROR_GETCFG_DIALINACTIVATION,"Failed to get activation of a wireless connection"},
            {EM_ErrorCode.NET_ERROR_SETCFG_DIALINACTIVATION,"Failed to set activation of a wireless connection"},
            {EM_ErrorCode.NET_ERROR_GETCFG_VIDEOOUT,"Failed to get the parameter of video output"},
            {EM_ErrorCode.NET_ERROR_SETCFG_VIDEOOUT,"Failed to set the configuration of video output"},
            {EM_ErrorCode.NET_ERROR_GETCFG_OSDENABLE,"Failed to get osd overlay enabling"},
            {EM_ErrorCode.NET_ERROR_SETCFG_OSDENABLE,"Failed to set OSD overlay enabling"},
            {EM_ErrorCode.NET_ERROR_SETCFG_ENCODERINFO,"Failed to set digital input configuration of front encoders"},
            {EM_ErrorCode.NET_ERROR_GETCFG_TVADJUST,"Failed to get TV adjust configuration"},
            {EM_ErrorCode.NET_ERROR_SETCFG_TVADJUST,"Failed to set TV adjust configuration"},
            {EM_ErrorCode.NET_ERROR_CONNECT_FAILED,"Failed to request to establish a connection"},
            {EM_ErrorCode.NET_ERROR_SETCFG_BURNFILE,"Failed to request to upload burn files"},
            {EM_ErrorCode.NET_ERROR_SNIFFER_GETCFG,"Failed to get capture configuration information"},
            {EM_ErrorCode.NET_ERROR_SNIFFER_SETCFG,"Failed to set capture configuration information"},
            {EM_ErrorCode.NET_ERROR_DOWNLOADRATE_GETCFG,"Failed to get download restrictions information"},
            {EM_ErrorCode.NET_ERROR_DOWNLOADRATE_SETCFG,"Failed to set download restrictions information"},
            {EM_ErrorCode.NET_ERROR_SEARCH_TRANSCOM,"Failed to query serial port parameters"},
            {EM_ErrorCode.NET_ERROR_GETCFG_POINT,"Failed to get the preset info"},
            {EM_ErrorCode.NET_ERROR_SETCFG_POINT,"Failed to set the preset info"},
            {EM_ErrorCode.NET_SDK_LOGOUT_ERROR,"SDK log out the device abnormally"},
            {EM_ErrorCode.NET_ERROR_GET_VEHICLE_CFG,"Failed to get vehicle configuration"},
            {EM_ErrorCode.NET_ERROR_SET_VEHICLE_CFG,"Failed to set vehicle configuration"},
            {EM_ErrorCode.NET_ERROR_GET_ATM_OVERLAY_CFG,"Failed to get ATM overlay configuration"},
            {EM_ErrorCode.NET_ERROR_SET_ATM_OVERLAY_CFG,"Failed to set ATM overlay configuration"},
            {EM_ErrorCode.NET_ERROR_GET_ATM_OVERLAY_ABILITY,"Failed to get ATM overlay ability"},
            {EM_ErrorCode.NET_ERROR_GET_DECODER_TOUR_CFG,"Failed to get decoder tour configuration"},
            {EM_ErrorCode.NET_ERROR_SET_DECODER_TOUR_CFG,"Failed to set decoder tour configuration"},
            {EM_ErrorCode.NET_ERROR_CTRL_DECODER_TOUR,"Failed to control decoder tour"},
            {EM_ErrorCode.NET_GROUP_OVERSUPPORTNUM,"Beyond the device supports for the largest number of user groups"},
            {EM_ErrorCode.NET_USER_OVERSUPPORTNUM,"Beyond the device supports for the largest number of users"},
            {EM_ErrorCode.NET_ERROR_GET_SIP_CFG,"Failed to get SIP configuration"},
            {EM_ErrorCode.NET_ERROR_SET_SIP_CFG,"Failed to set SIP configuration"},
            {EM_ErrorCode.NET_ERROR_GET_SIP_ABILITY,"Failed to get SIP capability"},
            {EM_ErrorCode.NET_ERROR_GET_WIFI_AP_CFG,"Failed to get 'WIFI ap' configuration"},
            {EM_ErrorCode.NET_ERROR_SET_WIFI_AP_CFG,"Failed to set 'WIFI ap' configuration"},
            {EM_ErrorCode.NET_ERROR_GET_DECODE_POLICY,"Failed to get decode policy"},
            {EM_ErrorCode.NET_ERROR_SET_DECODE_POLICY,"Failed to set decode policy"},
            {EM_ErrorCode.NET_ERROR_TALK_REJECT,"refuse talk"},
            {EM_ErrorCode.NET_ERROR_TALK_OPENED,"talk has opened by other client"},
            {EM_ErrorCode.NET_ERROR_TALK_RESOURCE_CONFLICIT,"resource conflict"},
            {EM_ErrorCode.NET_ERROR_TALK_UNSUPPORTED_ENCODE,"unsupported encode type"},
            {EM_ErrorCode.NET_ERROR_TALK_RIGHTLESS,"no right"},
            {EM_ErrorCode.NET_ERROR_TALK_FAILED,"request failed"},
            {EM_ErrorCode.NET_ERROR_GET_MACHINE_CFG,"Failed to get device relative config"},
            {EM_ErrorCode.NET_ERROR_SET_MACHINE_CFG,"Failed to set device relative config"},
            {EM_ErrorCode.NET_ERROR_GET_DATA_FAILED,"get data failed"},
            {EM_ErrorCode.NET_ERROR_MAC_VALIDATE_FAILED,"MAC validate failed"},
            {EM_ErrorCode.NET_ERROR_GET_INSTANCE,"Failed to get server instance"},
            {EM_ErrorCode.NET_ERROR_JSON_REQUEST,"Generated json string is error"},
            {EM_ErrorCode.NET_ERROR_JSON_RESPONSE,"The responding json string is error"},
            {EM_ErrorCode.NET_ERROR_VERSION_HIGHER,"The protocol version is lower than current version"},
            {EM_ErrorCode.NET_SPARE_NO_CAPACITY,"Hotspare disk operation failed. The capacity is low"},
            {EM_ErrorCode.NET_ERROR_SOURCE_IN_USE,"Display source is used by other output"},
            {EM_ErrorCode.NET_ERROR_REAVE,"advanced users grab low-level user resource"},
            {EM_ErrorCode.NET_ERROR_NETFORBID,"net forbid"},
            {EM_ErrorCode.NET_ERROR_GETCFG_MACFILTER,"get MAC filter configuration error"},
            {EM_ErrorCode.NET_ERROR_SETCFG_MACFILTER,"set MAC filter configuration error"},
            {EM_ErrorCode.NET_ERROR_GETCFG_IPMACFILTER,"get IP/MAC filter configuration error"},
            {EM_ErrorCode.NET_ERROR_SETCFG_IPMACFILTER,"set IP/MAC filter configuration error"},
            {EM_ErrorCode.NET_ERROR_OPERATION_OVERTIME,"operation over time"},
            {EM_ErrorCode.NET_ERROR_SENIOR_VALIDATE_FAILED,"senior validation failure"},
            {EM_ErrorCode.NET_ERROR_DEVICE_ID_NOT_EXIST,"device ID is not exist"},
            {EM_ErrorCode.NET_ERROR_UNSUPPORTED,"unsupport operation"},
            {EM_ErrorCode.NET_ERROR_PROXY_DLLLOAD,"proxy dll load error"},
            {EM_ErrorCode.NET_ERROR_PROXY_ILLEGAL_PARAM,"proxy user parameter is not legal"},
            {EM_ErrorCode.NET_ERROR_PROXY_INVALID_HANDLE,"handle invalid"},
            {EM_ErrorCode.NET_ERROR_PROXY_LOGIN_DEVICE_ERROR,"login device error"},
            {EM_ErrorCode.NET_ERROR_PROXY_START_SERVER_ERROR,"start proxy server error"},
            {EM_ErrorCode.NET_ERROR_SPEAK_FAILED,"request speak failed"},
            {EM_ErrorCode.NET_ERROR_NOT_SUPPORT_F6,"unsupport F6"},
            {EM_ErrorCode.NET_ERROR_CD_UNREADY,"CD is not ready"},
            {EM_ErrorCode.NET_ERROR_DIR_NOT_EXIST,"Directory does not exist"},
            {EM_ErrorCode.NET_ERROR_UNSUPPORTED_SPLIT_MODE,"The device does not support the segmentation model"},
            {EM_ErrorCode.NET_ERROR_OPEN_WND_PARAM,"Open the window parameter is illegal"},
            {EM_ErrorCode.NET_ERROR_LIMITED_WND_COUNT,"Open the window more than limit"},
            {EM_ErrorCode.NET_ERROR_UNMATCHED_REQUEST,"Request command with the current pattern don't match"},
            {EM_ErrorCode.NET_RENDER_ENABLELARGEPICADJUSTMENT_ERROR,"Render Library to enable high-definition image internal adjustment strategy error"},
            {EM_ErrorCode.NET_ERROR_UPGRADE_FAILED,"Upgrade equipment failure"},
            {EM_ErrorCode.NET_ERROR_NO_TARGET_DEVICE,"Can't find the target device"},
            {EM_ErrorCode.NET_ERROR_NO_VERIFY_DEVICE,"Can't find the verify device"},
            {EM_ErrorCode.NET_ERROR_CASCADE_RIGHTLESS,"No cascade permissions"},
            {EM_ErrorCode.NET_ERROR_LOW_PRIORITY,"low priority"},
            {EM_ErrorCode.NET_ERROR_REMOTE_REQUEST_TIMEOUT,"The remote device request timeout"},
            {EM_ErrorCode.NET_ERROR_LIMITED_INPUT_SOURCE,"Input source beyond maximum route restrictions"},
            {EM_ErrorCode.NET_ERROR_SET_LOG_PRINT_INFO,"Failed to set log print"},
            {EM_ErrorCode.NET_ERROR_PARAM_DWSIZE_ERROR,"'dwSize' is not initialized in input param"},
            {EM_ErrorCode.NET_ERROR_LIMITED_MONITORWALL_COUNT,"TV wall exceed limit"},
            {EM_ErrorCode.NET_ERROR_PART_PROCESS_FAILED,"Fail to execute part of the process"},
            {EM_ErrorCode.NET_ERROR_TARGET_NOT_SUPPORT,"Fail to transmit due to not supported by target"},
            {EM_ErrorCode.NET_ERROR_VISITE_FILE,"Access to the file failed"},
            {EM_ErrorCode.NET_ERROR_DEVICE_STATUS_BUSY,"Device busy"},
            {EM_ErrorCode.NET_USER_PWD_NOT_AUTHORIZED,"Fail to change the password"},
            {EM_ErrorCode.NET_USER_PWD_NOT_STRONG,"Password strength is not enough"},
            {EM_ErrorCode.NET_ERROR_NO_SUCH_CONFIG,"No corresponding setup"},
            {EM_ErrorCode.NET_ERROR_AUDIO_RECORD_FAILED,"Failed to record audio"},
            {EM_ErrorCode.NET_ERROR_SEND_DATA_FAILED,"Failed to send out data"},
            {EM_ErrorCode.NET_ERROR_OBSOLESCENT_INTERFACE,"Abandoned port"},
            {EM_ErrorCode.NET_ERROR_INSUFFICIENT_INTERAL_BUF,"Internal buffer is not sufficient"},
            {EM_ErrorCode.NET_ERROR_NEED_ENCRYPTION_PASSWORD,"verify password when changing device IP"},
            {EM_ErrorCode.NET_ERROR_NOSUPPORT_RECORD,"device not support the record"},
            {EM_ErrorCode.NET_ERROR_SERIALIZE_ERROR,"Failed to serialize data"},
            {EM_ErrorCode.NET_ERROR_DESERIALIZE_ERROR,"Failed to deserialize data"},
            {EM_ErrorCode.NET_ERROR_LOWRATEWPAN_ID_EXISTED,"the wireless id is already existed"},
            {EM_ErrorCode.NET_ERROR_LOWRATEWPAN_ID_LIMIT,"the wireless id limited"},
            {EM_ErrorCode.NET_ERROR_LOWRATEWPAN_ID_ABNORMAL,"add the wireless id abnormaly"},
            {EM_ErrorCode.NET_ERROR_ENCRYPT, "encrypt data fail"},
            {EM_ErrorCode.NET_ERROR_PWD_ILLEGAL, "new password illegal"},
            {EM_ErrorCode.NET_ERROR_DEVICE_ALREADY_INIT, "device is already init"},
            {EM_ErrorCode.NET_ERROR_SECURITY_CODE, "security code check out fail"},
            {EM_ErrorCode.NET_ERROR_SECURITY_CODE_TIMEOUT, "security code out of time"},
            {EM_ErrorCode.NET_ERROR_GET_PWD_SPECI, "get passwd specification fail"},
            {EM_ErrorCode.NET_ERROR_NO_AUTHORITY_OF_OPERATION, "no authority of operation"},
            {EM_ErrorCode.NET_ERROR_DECRYPT, "decrypt data fail"},
            {EM_ErrorCode.NET_ERROR_2D_CODE, "2D code check out fail"},
            {EM_ErrorCode.NET_ERROR_INVALID_REQUEST, "invalid request"},
            {EM_ErrorCode.NET_ERROR_PWD_RESET_DISABLE, "pwd reset disabled"},
            {EM_ErrorCode.NET_ERROR_PLAY_PRIVATE_DATA, "failed to display private data,such as rule box"},
            {EM_ErrorCode.NET_ERROR_ROBOT_OPERATE_FAILED, "robot operate failed"},
            {EM_ErrorCode.NET_ERROR_CHANNEL_ALREADY_OPENED, "channel has already been opened"},

            {EM_ErrorCode.ERR_INTERNAL_INVALID_CHANNEL,"invaild channel"},
            {EM_ErrorCode.ERR_INTERNAL_REOPEN_CHANNEL,"reopen channel failed"},
            {EM_ErrorCode.ERR_INTERNAL_SEND_DATA,"send data failed"},
            {EM_ErrorCode.ERR_INTERNAL_CREATE_SOCKET,"create socket failed"},
            {EM_ErrorCode.ERR_INTERNAL_LISTEN_FAILED,"Start listen failed"},
            {EM_ErrorCode.NET_ERROR_FACE_RECOGNITION_SERVER_GROUP_ID_EXCEED, "Target recognition server group id exceed " },
            {EM_ErrorCode.ERR_NOT_SUPPORT_HIGHLEVEL_SECURITY_LOGIN, "device not support high level security login" },
        };

        /// <summary>
        /// zh-cn language
        /// 中文错误码对应的错误信息
        /// </summary>
        private static Dictionary<EM_ErrorCode, string> zh_cn_String = new Dictionary<EM_ErrorCode, string>()
        {
            {EM_ErrorCode.NET_NOERROR,"没有错误"},
            {EM_ErrorCode.NET_ERROR,"未知错误"},
            {EM_ErrorCode.NET_SYSTEM_ERROR,"Windows系统出错"},
            {EM_ErrorCode.NET_NETWORK_ERROR,"网络错误,可能是因为网络超时"},
            {EM_ErrorCode.NET_DEV_VER_NOMATCH,"设备协议不匹配"},
            {EM_ErrorCode.NET_INVALID_HANDLE,"句柄无效"},
            {EM_ErrorCode.NET_OPEN_CHANNEL_ERROR,"打开通道失败"},
            {EM_ErrorCode.NET_CLOSE_CHANNEL_ERROR,"关闭通道失败"},
            {EM_ErrorCode.NET_ILLEGAL_PARAM,"用户参数不合法"},
            {EM_ErrorCode.NET_SDK_INIT_ERROR,"SDK初始化出错"},
            {EM_ErrorCode.NET_SDK_UNINIT_ERROR,"SDK清理出错"},
            {EM_ErrorCode.NET_RENDER_OPEN_ERROR,"申请render资源出错"},
            {EM_ErrorCode.NET_DEC_OPEN_ERROR,"打开解码库出错"},
            {EM_ErrorCode.NET_DEC_CLOSE_ERROR,"关闭解码库出错"},
            {EM_ErrorCode.NET_MULTIPLAY_NOCHANNEL,"多画面预览中检测到通道数为0"},
            {EM_ErrorCode.NET_TALK_INIT_ERROR,"录音库初始化失败"},
            {EM_ErrorCode.NET_TALK_NOT_INIT,"录音库未经初始化"},
            {EM_ErrorCode.NET_TALK_SENDDATA_ERROR,"发送音频数据出错"},
            {EM_ErrorCode.NET_REAL_ALREADY_SAVING,"实时数据已经处于保存状态"},
            {EM_ErrorCode.NET_NOT_SAVING,"未保存实时数据"},
            {EM_ErrorCode.NET_OPEN_FILE_ERROR,"打开文件出错"},
            {EM_ErrorCode.NET_PTZ_SET_TIMER_ERROR,"启动云台控制定时器失败"},
            {EM_ErrorCode.NET_RETURN_DATA_ERROR,"对返回数据的校验出错"},
            {EM_ErrorCode.NET_INSUFFICIENT_BUFFER,"没有足够的缓存"},
            {EM_ErrorCode.NET_NOT_SUPPORTED,"当前SDK未支持该功能"},
            {EM_ErrorCode.NET_NO_RECORD_FOUND,"查询不到录象"},
            {EM_ErrorCode.NET_NOT_AUTHORIZED,"无操作权限"},
            {EM_ErrorCode.NET_NOT_NOW,"暂时无法执行"},
            {EM_ErrorCode.NET_NO_TALK_CHANNEL,"未发现对讲通道"},
            {EM_ErrorCode.NET_NO_AUDIO,"未发现音频"},
            {EM_ErrorCode.NET_NO_INIT,"网络SDK未经初始化"},
            {EM_ErrorCode.NET_DOWNLOAD_END,"下载已结束"},
            {EM_ErrorCode.NET_EMPTY_LIST,"查询结果为空"},
            {EM_ErrorCode.NET_ERROR_GETCFG_SYSATTR,"获取系统属性配置失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_SERIAL,"获取序列号失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_GENERAL,"获取常规属性失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_DSPCAP,"获取DSP能力描述失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_NETCFG,"获取网络配置失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_CHANNAME,"获取通道名称失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_VIDEO,"获取视频属性失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_RECORD,"获取录象配置失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_PRONAME,"获取解码器协议名称失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_FUNCNAME,"获取232串口功能名称失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_485DECODER,"获取解码器属性失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_232COM,"获取232串口配置失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_ALARMIN,"获取外部报警输入配置失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_ALARMDET,"获取动态检测报警失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_SYSTIME,"获取设备时间失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_PREVIEW,"获取预览参数失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_AUTOMT,"获取自动维护配置失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_VIDEOMTRX,"获取视频矩阵配置失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_COVER,"获取区域遮挡配置失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_WATERMAKE,"获取图象水印配置失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_MULTICAST,"获取配置失败位置：组播端口按通道配置"},
            {EM_ErrorCode.NET_ERROR_SETCFG_GENERAL,"修改常规属性失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_NETCFG,"修改网络配置失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_CHANNAME,"修改通道名称失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_VIDEO,"修改视频属性失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_RECORD,"修改录象配置失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_485DECODER,"修改解码器属性失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_232COM,"修改232串口配置失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_ALARMIN,"修改外部输入报警配置失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_ALARMDET,"修改动态检测报警配置失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_SYSTIME,"修改设备时间失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_PREVIEW,"修改预览参数失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_AUTOMT,"修改自动维护配置失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_VIDEOMTRX,"修改视频矩阵配置失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_COVER,"修改区域遮挡配置失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_WATERMAKE,"修改图象水印配置失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_WLAN,"修改无线网络信息失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_WLANDEV,"选择无线网络设备失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_REGISTER,"修改主动注册参数配置失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_CAMERA,"修改摄像头属性配置失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_INFRARED,"修改红外报警配置失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_SOUNDALARM,"修改音频报警配置失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_STORAGE,"修改存储位置配置失败"},
            {EM_ErrorCode.NET_AUDIOENCODE_NOTINIT,"音频编码接口没有成功初始化"},
            {EM_ErrorCode.NET_DATA_TOOLONGH,"数据过长"},
            {EM_ErrorCode.NET_UNSUPPORTED,"设备不支持该操作"},
            {EM_ErrorCode.NET_DEVICE_BUSY,"设备资源不足"},
            {EM_ErrorCode.NET_SERVER_STARTED,"服务器已经启动"},
            {EM_ErrorCode.NET_SERVER_STOPPED,"服务器尚未成功启动"},
            {EM_ErrorCode.NET_LISTER_INCORRECT_SERIAL,"输入序列号有误"},
            {EM_ErrorCode.NET_QUERY_DISKINFO_FAILED,"获取硬盘信息失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_SESSION,"获取连接Session信息"},
            {EM_ErrorCode.NET_USER_FLASEPWD_TRYTIME,"输入密码错误超过限制次数"},
            {EM_ErrorCode.NET_LOGIN_ERROR_PASSWORD,"密码不正确"},
            {EM_ErrorCode.NET_LOGIN_ERROR_USER,"帐户不存在"},
            {EM_ErrorCode.NET_LOGIN_ERROR_TIMEOUT,"等待登录返回超时"},
            {EM_ErrorCode.NET_LOGIN_ERROR_RELOGGIN,"帐号已登录"},
            {EM_ErrorCode.NET_LOGIN_ERROR_LOCKED,"帐号已被锁定"},
            {EM_ErrorCode.NET_LOGIN_ERROR_BLACKLIST,"帐号已被列为禁用名单"},
            {EM_ErrorCode.NET_LOGIN_ERROR_BUSY,"资源不足,系统忙"},
            {EM_ErrorCode.NET_LOGIN_ERROR_CONNECT,"登录设备超时,请检查网络并重试"},
            {EM_ErrorCode.NET_LOGIN_ERROR_NETWORK,"网络连接失败"},
            {EM_ErrorCode.NET_LOGIN_ERROR_SUBCONNECT,"登录设备成功,但无法创建视频通道,请检查网络状况"},
            {EM_ErrorCode.NET_LOGIN_ERROR_MAXCONNECT,"超过最大连接数"},
            {EM_ErrorCode.NET_LOGIN_ERROR_PROTOCOL3_ONLY,"只支持3代协议"},
            {EM_ErrorCode.NET_LOGIN_ERROR_UKEY_LOST,"未插入U盾或U盾信息错误"},
            {EM_ErrorCode.NET_LOGIN_ERROR_NO_AUTHORIZED,"客户端IP地址没有登录权限"},
            {EM_ErrorCode.NET_LOGIN_ERROR_USER_OR_PASSOWRD,"账号或密码错误"},
            {EM_ErrorCode.NET_RENDER_SOUND_ON_ERROR,"Render库打开音频出错"},
            {EM_ErrorCode.NET_RENDER_SOUND_OFF_ERROR,"Render库关闭音频出错"},
            {EM_ErrorCode.NET_RENDER_SET_VOLUME_ERROR,"Render库控制音量出错"},
            {EM_ErrorCode.NET_RENDER_ADJUST_ERROR,"Render库设置画面参数出错"},
            {EM_ErrorCode.NET_RENDER_PAUSE_ERROR,"Render库暂停播放出错"},
            {EM_ErrorCode.NET_RENDER_SNAP_ERROR,"Render库抓图出错"},
            {EM_ErrorCode.NET_RENDER_STEP_ERROR,"Render库步进出错"},
            {EM_ErrorCode.NET_RENDER_FRAMERATE_ERROR,"Render库设置帧率出错"},
            {EM_ErrorCode.NET_RENDER_DISPLAYREGION_ERROR,"Render库设置显示区域出错"},
            {EM_ErrorCode.NET_RENDER_GETOSDTIME_ERROR,"Render库获取当前播放时间出错"},
            {EM_ErrorCode.NET_GROUP_EXIST,"组名已存在"},
            {EM_ErrorCode.NET_GROUP_NOEXIST,"组名不存在"},
            {EM_ErrorCode.NET_GROUP_RIGHTOVER,"组的权限超出权限列表范围"},
            {EM_ErrorCode.NET_GROUP_HAVEUSER,"组下有用户,不能删除"},
            {EM_ErrorCode.NET_GROUP_RIGHTUSE,"组的某个权限被用户使用,不能出除"},
            {EM_ErrorCode.NET_GROUP_SAMENAME,"新组名同已有组名重复"},
            {EM_ErrorCode.NET_USER_EXIST,"用户已存在"},
            {EM_ErrorCode.NET_USER_NOEXIST,"用户不存在"},
            {EM_ErrorCode.NET_USER_RIGHTOVER,"用户权限超出组权限"},
            {EM_ErrorCode.NET_USER_PWD,"保留帐号,不容许修改密码"},
            {EM_ErrorCode.NET_USER_FLASEPWD,"密码不正确"},
            {EM_ErrorCode.NET_USER_NOMATCHING,"密码不匹配"},
            {EM_ErrorCode.NET_USER_INUSE,"账号正在使用中"},
            {EM_ErrorCode.NET_ERROR_GETCFG_ETHERNET,"获取网卡配置失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_WLAN,"获取无线网络信息失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_WLANDEV,"获取无线网络设备失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_REGISTER,"获取主动注册参数失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_CAMERA,"获取摄像头属性失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_INFRARED,"获取红外报警配置失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_SOUNDALARM,"获取音频报警配置失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_STORAGE,"获取存储位置配置失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_MAIL,"获取邮件配置失败"},
            {EM_ErrorCode.NET_CONFIG_DEVBUSY,"暂时无法设置"},
            {EM_ErrorCode.NET_CONFIG_DATAILLEGAL,"配置数据不合法"},
            {EM_ErrorCode.NET_ERROR_GETCFG_DST,"获取夏令时配置失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_DST,"设置夏令时配置失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_VIDEO_OSD,"获取视频OSD叠加配置失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_VIDEO_OSD,"设置视频OSD叠加配置失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_GPRSCDMA,"获取CDMA\\GPRS网络配置失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_GPRSCDMA,"设置CDMA\\GPRS网络配置失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_IPFILTER,"获取IP过滤配置失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_IPFILTER,"设置IP过滤配置失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_TALKENCODE,"获取语音对讲编码配置失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_TALKENCODE,"设置语音对讲编码配置失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_RECORDLEN,"获取录像打包长度配置失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_RECORDLEN,"设置录像打包长度配置失败"},
            {EM_ErrorCode.NET_DONT_SUPPORT_SUBAREA,"不支持网络硬盘分区"},
            {EM_ErrorCode.NET_ERROR_GET_AUTOREGSERVER,"获取设备上主动注册服务器信息失败"},
            {EM_ErrorCode.NET_ERROR_CONTROL_AUTOREGISTER,"主动注册重定向注册错误"},
            {EM_ErrorCode.NET_ERROR_DISCONNECT_AUTOREGISTER,"断开主动注册服务器错误"},
            {EM_ErrorCode.NET_ERROR_GETCFG_MMS,"获取mms配置失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_MMS,"设置mms配置失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_SMSACTIVATION,"获取短信激活无线连接配置失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_SMSACTIVATION,"设置短信激活无线连接配置失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_DIALINACTIVATION,"获取拨号激活无线连接配置失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_DIALINACTIVATION,"设置拨号激活无线连接配置失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_VIDEOOUT,"查询视频输出参数配置失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_VIDEOOUT,"设置视频输出参数配置失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_OSDENABLE,"获取osd叠加使能配置失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_OSDENABLE,"设置osd叠加使能配置失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_ENCODERINFO,"设置数字通道前端编码接入配置失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_TVADJUST,"获取TV调节配置失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_TVADJUST,"设置TV调节配置失败"},
            {EM_ErrorCode.NET_ERROR_CONNECT_FAILED,"请求建立连接失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_BURNFILE,"请求刻录文件上传失败"},
            {EM_ErrorCode.NET_ERROR_SNIFFER_GETCFG,"获取抓包配置信息失败"},
            {EM_ErrorCode.NET_ERROR_SNIFFER_SETCFG,"设置抓包配置信息失败"},
            {EM_ErrorCode.NET_ERROR_DOWNLOADRATE_GETCFG,"查询下载限制信息失败"},
            {EM_ErrorCode.NET_ERROR_DOWNLOADRATE_SETCFG,"设置下载限制信息失败"},
            {EM_ErrorCode.NET_ERROR_SEARCH_TRANSCOM,"查询串口参数失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_POINT,"获取预制点信息错误"},
            {EM_ErrorCode.NET_ERROR_SETCFG_POINT,"设置预制点信息错误"},
            {EM_ErrorCode.NET_SDK_LOGOUT_ERROR,"SDK没有正常登出设备"},
            {EM_ErrorCode.NET_ERROR_GET_VEHICLE_CFG,"获取车载配置失败"},
            {EM_ErrorCode.NET_ERROR_SET_VEHICLE_CFG,"设置车载配置失败"},
            {EM_ErrorCode.NET_ERROR_GET_ATM_OVERLAY_CFG,"获取atm叠加配置失败"},
            {EM_ErrorCode.NET_ERROR_SET_ATM_OVERLAY_CFG,"设置atm叠加配置失败"},
            {EM_ErrorCode.NET_ERROR_GET_ATM_OVERLAY_ABILITY,"获取atm叠加能力失败"},
            {EM_ErrorCode.NET_ERROR_GET_DECODER_TOUR_CFG,"获取解码器解码轮巡配置失败"},
            {EM_ErrorCode.NET_ERROR_SET_DECODER_TOUR_CFG,"设置解码器解码轮巡配置失败"},
            {EM_ErrorCode.NET_ERROR_CTRL_DECODER_TOUR,"控制解码器解码轮巡失败"},
            {EM_ErrorCode.NET_GROUP_OVERSUPPORTNUM,"超出设备支持最大用户组数目"},
            {EM_ErrorCode.NET_USER_OVERSUPPORTNUM,"超出设备支持最大用户数目"},
            {EM_ErrorCode.NET_ERROR_GET_SIP_CFG,"获取SIP配置失败"},
            {EM_ErrorCode.NET_ERROR_SET_SIP_CFG,"设置SIP配置失败"},
            {EM_ErrorCode.NET_ERROR_GET_SIP_ABILITY,"获取SIP能力失败"},
            {EM_ErrorCode.NET_ERROR_GET_WIFI_AP_CFG,"获取WIFI ap配置失败"},
            {EM_ErrorCode.NET_ERROR_SET_WIFI_AP_CFG,"设置WIFI ap配置失败"},
            {EM_ErrorCode.NET_ERROR_GET_DECODE_POLICY,"获取解码策略配置失败"},
            {EM_ErrorCode.NET_ERROR_SET_DECODE_POLICY,"设置解码策略配置失败"},
            {EM_ErrorCode.NET_ERROR_TALK_REJECT,"拒绝对讲"},
            {EM_ErrorCode.NET_ERROR_TALK_OPENED,"对讲被其他客户端打开"},
            {EM_ErrorCode.NET_ERROR_TALK_RESOURCE_CONFLICIT,"资源冲突"},
            {EM_ErrorCode.NET_ERROR_TALK_UNSUPPORTED_ENCODE,"不支持的语音编码格式"},
            {EM_ErrorCode.NET_ERROR_TALK_RIGHTLESS,"无权限"},
            {EM_ErrorCode.NET_ERROR_TALK_FAILED,"请求对讲失败"},
            {EM_ErrorCode.NET_ERROR_GET_MACHINE_CFG,"获取机器相关配置失败"},
            {EM_ErrorCode.NET_ERROR_SET_MACHINE_CFG,"设置机器相关配置失败"},
            {EM_ErrorCode.NET_ERROR_GET_DATA_FAILED,"设备无法获取当前请求数据"},
            {EM_ErrorCode.NET_ERROR_MAC_VALIDATE_FAILED,"MAC地址验证失败 "},
            {EM_ErrorCode.NET_ERROR_GET_INSTANCE,"获取服务器实例失败"},
            {EM_ErrorCode.NET_ERROR_JSON_REQUEST,"生成的jason字符串错误"},
            {EM_ErrorCode.NET_ERROR_JSON_RESPONSE,"响应的jason字符串错误"},
            {EM_ErrorCode.NET_ERROR_VERSION_HIGHER,"协议版本低于当前使用的版本"},
            {EM_ErrorCode.NET_SPARE_NO_CAPACITY,"热备操作失败, 容量不足"},
            {EM_ErrorCode.NET_ERROR_SOURCE_IN_USE,"显示源被其他输出占用"},
            {EM_ErrorCode.NET_ERROR_REAVE,"高级用户抢占低级用户资源"},
            {EM_ErrorCode.NET_ERROR_NETFORBID,"禁止入网 "},
            {EM_ErrorCode.NET_ERROR_GETCFG_MACFILTER,"获取MAC过滤配置失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_MACFILTER,"设置MAC过滤配置失败"},
            {EM_ErrorCode.NET_ERROR_GETCFG_IPMACFILTER,"获取IP/MAC过滤配置失败"},
            {EM_ErrorCode.NET_ERROR_SETCFG_IPMACFILTER,"设置IP/MAC过滤配置失败"},
            {EM_ErrorCode.NET_ERROR_OPERATION_OVERTIME,"当前操作超时 "},
            {EM_ErrorCode.NET_ERROR_SENIOR_VALIDATE_FAILED,"高级校验失败"},
            {EM_ErrorCode.NET_ERROR_DEVICE_ID_NOT_EXIST,"设备ID不存在"},
            {EM_ErrorCode.NET_ERROR_UNSUPPORTED,"不支持当前操作"},
            {EM_ErrorCode.NET_ERROR_PROXY_DLLLOAD,"代理库加载失败"},
            {EM_ErrorCode.NET_ERROR_PROXY_ILLEGAL_PARAM,"代理用户参数不合法"},
            {EM_ErrorCode.NET_ERROR_PROXY_INVALID_HANDLE,"代理句柄无效"},
            {EM_ErrorCode.NET_ERROR_PROXY_LOGIN_DEVICE_ERROR,"代理登入前端设备失败"},
            {EM_ErrorCode.NET_ERROR_PROXY_START_SERVER_ERROR,"启动代理服务失败"},
            {EM_ErrorCode.NET_ERROR_SPEAK_FAILED,"请求喊话失败"},
            {EM_ErrorCode.NET_ERROR_NOT_SUPPORT_F6,"设备不支持此F6接口调用"},
            {EM_ErrorCode.NET_ERROR_CD_UNREADY,"光盘未就绪"},
            {EM_ErrorCode.NET_ERROR_DIR_NOT_EXIST,"目录不存在"},
            {EM_ErrorCode.NET_ERROR_UNSUPPORTED_SPLIT_MODE,"设备不支持的分割模式"},
            {EM_ErrorCode.NET_ERROR_OPEN_WND_PARAM,"开窗参数不合法"},
            {EM_ErrorCode.NET_ERROR_LIMITED_WND_COUNT,"开窗数量超过限制"},
            {EM_ErrorCode.NET_ERROR_UNMATCHED_REQUEST,"请求命令与当前模式不匹配"},
            {EM_ErrorCode.NET_RENDER_ENABLELARGEPICADJUSTMENT_ERROR,"Render库启用高清图像内部调整策略出错"},
            {EM_ErrorCode.NET_ERROR_UPGRADE_FAILED,"设备升级失败"},
            {EM_ErrorCode.NET_ERROR_NO_TARGET_DEVICE,"找不到目标设备"},
            {EM_ErrorCode.NET_ERROR_NO_VERIFY_DEVICE,"找不到验证设备"},
            {EM_ErrorCode.NET_ERROR_CASCADE_RIGHTLESS,"无级联权限"},
            {EM_ErrorCode.NET_ERROR_LOW_PRIORITY,"低优先级"},
            {EM_ErrorCode.NET_ERROR_REMOTE_REQUEST_TIMEOUT,"远程设备请求超时"},
            {EM_ErrorCode.NET_ERROR_LIMITED_INPUT_SOURCE,"输入源超出最大路数限制"},
            {EM_ErrorCode.NET_ERROR_SET_LOG_PRINT_INFO,"设置日志打印失败"},
            {EM_ErrorCode.NET_ERROR_PARAM_DWSIZE_ERROR,"入参的dwsize字段出错"},
            {EM_ErrorCode.NET_ERROR_LIMITED_MONITORWALL_COUNT,"电视墙数量超过上限"},
            {EM_ErrorCode.NET_ERROR_PART_PROCESS_FAILED,"部分过程执行失败"},
            {EM_ErrorCode.NET_ERROR_TARGET_NOT_SUPPORT,"该功能不支持转发"},
            {EM_ErrorCode.NET_ERROR_VISITE_FILE,"访问文件失败"},
            {EM_ErrorCode.NET_ERROR_DEVICE_STATUS_BUSY,"设备忙"},
            {EM_ErrorCode.NET_USER_PWD_NOT_AUTHORIZED,"修改密码无权限"},
            {EM_ErrorCode.NET_USER_PWD_NOT_STRONG,"密码强度不够"},
            {EM_ErrorCode.NET_ERROR_NO_SUCH_CONFIG,"没有对应的配置"},
            {EM_ErrorCode.NET_ERROR_AUDIO_RECORD_FAILED,"录音失败"},
            {EM_ErrorCode.NET_ERROR_SEND_DATA_FAILED,"数据发送失败"},
            {EM_ErrorCode.NET_ERROR_OBSOLESCENT_INTERFACE,"废弃接口"},
            {EM_ErrorCode.NET_ERROR_INSUFFICIENT_INTERAL_BUF,"内部缓冲不足"},
            {EM_ErrorCode.NET_ERROR_NEED_ENCRYPTION_PASSWORD,"修改设备ip时,需要校验密码"},
            {EM_ErrorCode.NET_ERROR_NOSUPPORT_RECORD,"设备不支持此记录集"},
            {EM_ErrorCode.NET_ERROR_SERIALIZE_ERROR,"数据序列化错误"},
            {EM_ErrorCode.NET_ERROR_DESERIALIZE_ERROR,"数据反序列化错误"},
            {EM_ErrorCode.NET_ERROR_LOWRATEWPAN_ID_EXISTED,"该无线ID已存在"},
            {EM_ErrorCode.NET_ERROR_LOWRATEWPAN_ID_LIMIT,"无线ID数量已超限"},
            {EM_ErrorCode.NET_ERROR_LOWRATEWPAN_ID_ABNORMAL,"无线异常添加"},
            {EM_ErrorCode.NET_ERROR_ENCRYPT, "加密数据失败"},
            {EM_ErrorCode.NET_ERROR_PWD_ILLEGAL, "新密码不合规范"},
            {EM_ErrorCode.NET_ERROR_DEVICE_ALREADY_INIT, "设备已经初始化"},
            {EM_ErrorCode.NET_ERROR_SECURITY_CODE, "安全码错误"},
            {EM_ErrorCode.NET_ERROR_SECURITY_CODE_TIMEOUT, "安全码超出有效期"},
            {EM_ErrorCode.NET_ERROR_GET_PWD_SPECI, "获取密码规范失败"},
            {EM_ErrorCode.NET_ERROR_NO_AUTHORITY_OF_OPERATION, "无权限进行该操作"},
            {EM_ErrorCode.NET_ERROR_DECRYPT, "解密数据失败"},
            {EM_ErrorCode.NET_ERROR_2D_CODE, "2D code校验失败"},
            {EM_ErrorCode.NET_ERROR_INVALID_REQUEST, "非法的RPC请求"},
            {EM_ErrorCode.NET_ERROR_PWD_RESET_DISABLE, "密码重置功能已关闭"},
            {EM_ErrorCode.NET_ERROR_PLAY_PRIVATE_DATA, "显示私有数据，比如规则框等失败"},
            {EM_ErrorCode.NET_ERROR_ROBOT_OPERATE_FAILED, "机器人操作失败"},
            {EM_ErrorCode.NET_ERROR_CHANNEL_ALREADY_OPENED, "通道已经打开"},

            {EM_ErrorCode.ERR_INTERNAL_INVALID_CHANNEL,"错误的通道号"},
            {EM_ErrorCode.ERR_INTERNAL_REOPEN_CHANNEL,"打开重复通道"},
            {EM_ErrorCode.ERR_INTERNAL_SEND_DATA,"发送消息失败"},
            {EM_ErrorCode.ERR_INTERNAL_CREATE_SOCKET,"创建socket失败"},
            {EM_ErrorCode.ERR_INTERNAL_LISTEN_FAILED,"启动监听失败"},
            {EM_ErrorCode.NET_ERROR_FACE_RECOGNITION_SERVER_GROUP_ID_EXCEED, "组ID超过最大值" },
            {EM_ErrorCode.ERR_NOT_SUPPORT_HIGHLEVEL_SECURITY_LOGIN, "设备不支持高安全等级登录" },

        };
        #endregion //<< constant >>


        #region << C# SDK calls >>

        #region << init and login >>

        /// <summary>
        /// set throw error message
        /// 设置接口抛异常
        /// </summary>
        /// <param name="isThrow">throw expection or not 是否抛异常</param>
        public static void SetThrowErrorMessage(bool isThrow)
        {
            m_IsThrowErrorMessage = isThrow;
        }

        /// <summary>
        /// error code convert to error message 
        /// 错误码转成错误信息
        /// </summary>
        /// <param name="errorCode">SDK error code SDK错误码</param>
        /// <returns>error message description 错误信息描述</returns>
        private static string GetLastErrorMessage(EM_ErrorCode errorCode)
        {
            string result = string.Empty;
            switch (System.Globalization.CultureInfo.CurrentCulture.LCID)
            {
                case 0x00804:
                    zh_cn_String.TryGetValue(errorCode, out result);
                    break;
                default:
                    en_us_String.TryGetValue(errorCode, out result);
                    break;
            }
            if (null == result)
            {
                result = errorCode.ToString("X");
            }
            return result;
        }

        /// <summary>
        /// judge the SDK function is failed or successful
        /// 判断SDK接口函数调用是否成功
        /// </summary>
        /// <typeparam name="T">value type 接口函数返回值类型</typeparam>
        /// <param name="value">the value is SDK function returns value,the value must be value type 接口函数返回值</param>
        private static void NetGetLastError<T>(T value)
            where T : struct
        {
            object temp = value;
            bool isGetLastError = false;
            if (value is IntPtr)
            {
                IntPtr tempValue = (IntPtr)temp;
                if (IntPtr.Zero == tempValue)
                {
                    isGetLastError = true;
                }
            }
            else if (value is int)
            {
                int tempValue = (int)temp;
                if (0 > tempValue)
                {
                    isGetLastError = true;
                }
            }
            else if (value is bool)
            {
                bool tempValue = (bool)temp;
                if (false == tempValue)
                {
                    isGetLastError = true;
                }
            }
            else
            {
                return;
            }
            if (isGetLastError)
            {
                if (!m_IsThrowErrorMessage)
                {
                    return;
                }
                int error = OriginalSDK.CLIENT_GetLastError();
                if (0 != error)
                {

                    string errorMessage = GetLastErrorMessage((EM_ErrorCode)error);
                    throw new NETClientExcetion(error, errorMessage);

                }
            }
        }

        /// <summary>
        /// get last error message
        /// 获取错误信息
        /// </summary>
        /// <returns>error message 错误信息</returns>
        public static string GetLastError()
        {
            string reslut = null;
            int error = OriginalSDK.CLIENT_GetLastError();
            if (0 != error)
            {
                reslut = GetLastErrorMessage((EM_ErrorCode)error);
            }
            return reslut;
        }

        /// <summary>
        /// initialize SDK,can only be called once.Must be called before others SDK function,otherwise others SDK function will fail.
        /// 初始化SDK，只能被调用一次，必须在别的SDK接口函数调用之前调用。
        /// </summary>
        /// <param name="cbDisConnect">disconnect the callback function, see the delegate 断线回调函数</param>
        /// <param name="dwUser">user data, there is no data, please use IntPtr.Zero 用户数据</param>
        /// <param name="initParam">initialization parameter,can input null SDK初始化参数</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool Init(fDisConnectCallBack cbDisConnect, IntPtr dwUser, NETSDK_INIT_PARAM? stuInitParam)
        {
            bool result = false;
            IntPtr lpInitParam = IntPtr.Zero;
            try
            {
                if (null != stuInitParam)
                {
                    lpInitParam = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETSDK_INIT_PARAM)));
                    Marshal.StructureToPtr(stuInitParam, lpInitParam, true);
                }
                result = OriginalSDK.CLIENT_InitEx(cbDisConnect, dwUser, lpInitParam);
                NetGetLastError(result);
            }
            finally
            {
                Marshal.FreeHGlobal(lpInitParam);
            }
            return result;
        }

        /// <summary>
        /// initialize SDK (with default Disconnect Callback and Reconnected Callback),
        /// can only be called once.Must be called before others SDK function,otherwise others SDK function will fail.
        /// 初始化SDK（使用默认的断线重连和重连恢复回调函数），
        /// 只能被调用一次，必须在别的SDK接口函数调用之前调用。
        /// </summary>
        /// <returns></returns>
        public static bool InitWithDefaultSetting(fDisConnectCallBack cbDisConnect, fHaveReConnectCallBack cbReconnect,
                                                  IntPtr dwUser, NETSDK_INIT_PARAM? stuInitParam)
        {
            bool result = false;
            IntPtr lpInitParam = IntPtr.Zero;
            IntPtr pNetParam = IntPtr.Zero;

            try
            {
                if (null != stuInitParam)
                {
                    lpInitParam = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETSDK_INIT_PARAM)));
                    Marshal.StructureToPtr(stuInitParam, lpInitParam, true);
                }
                // init SDK and set disconnect callback (初始化 SDK)
                result = OriginalSDK.CLIENT_InitEx(cbDisConnect, dwUser, lpInitParam);
                NetGetLastError(result);
                if (!result) return false;

                // Timeout of login 登录时尝试建立连接的超时时间
                // Tiemout of sub-connect 设置子连接的超时时间
                NET_PARAM netParam = new NET_PARAM();
                netParam.nConnectTime = 5000;               // 5s
                netParam.nGetConnInfoTime = 3000;           // 3s
                pNetParam = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_PARAM)));
                Marshal.StructureToPtr(netParam, pNetParam, true);
                OriginalSDK.CLIENT_SetNetworkParam(pNetParam);

                // set reconnect callback 设置断线重连回调接口
                OriginalSDK.CLIENT_SetAutoReconnect(cbReconnect, IntPtr.Zero);

                // set reconnect time 设置重连时间，可选
                // Set timeout and number of attempts 设置登录超时时间和尝试次数，可选
                int waitTime = 5000;                        // 5s
                int tryTimes = 3;                           // 3 times
                OriginalSDK.CLIENT_SetConnectTime(waitTime, tryTimes);
            }
            finally
            {
                Marshal.FreeHGlobal(lpInitParam);
                Marshal.FreeHGlobal(pNetParam);
            }
            return result;
        }

        /// <summary>
        ///  empty SDK, release occupied resource,call after all SDK functions
        ///  清空SDK，释放资源
        /// </summary>
        public static void Cleanup()
        {
            OriginalSDK.CLIENT_Cleanup();
        }

        /// <summary>
        /// login to the device
        /// 登陆设备
        /// </summary>
        /// <param name="pchDVRIP">device IP 设备IP</param>
        /// <param name="wDVRPort">device port 设备端口</param>
        /// <param name="pchUserName">username 用户名</param>
        /// <param name="pchPassword">password 密码</param>
        /// <param name="emSpecCap">device supported capacity,when the value is EM_LOGIN_SPAC_CAP_TYPE.SERVER_CONN means active listen mode user login(mobile dvr login) 登陆方式</param>
        /// <param name="pCapParam">nSpecCap compensation parameter，nSpecCap = EM_LOGIN_SPAC_CAP_TYPE.SERVER_CONN，pCapParam fill in device serial number string(mobile dvr login) emSpecCap参数，只有当 EM_LOGIN_SPAC_CAP_TYPE.SERVER_CONN有效</param>
        /// <param name="deviceInfo">device information，for output parmaeter 输出的设备信息</param>
        /// <returns>failed return 0,successful return LoginID,after successful login, device Operation may be via this this value(device handle)corresponding to corresponding device.失败返回0，成功返回大于O的值</returns>
        public static IntPtr Login(string pchDVRIP, ushort wDVRPort, string pchUserName, string pchPassword, EM_LOGIN_SPAC_CAP_TYPE emSpecCap, IntPtr pCapParam, ref NET_DEVICEINFO_Ex deviceInfo)
        {
            IntPtr result = IntPtr.Zero;
            int error = 0;
            result = OriginalSDK.CLIENT_LoginEx2(pchDVRIP, wDVRPort, pchUserName, pchPassword, emSpecCap, pCapParam, ref deviceInfo, ref error);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// login device with high level security
        /// 高安全级别登陆
        /// </summary>
        /// <param name="pchDVRIP">device IP 设备IP</param>
        /// <param name="wDVRPort">device port 设备端口</param>
        /// <param name="pchUserName">username 用户名</param>
        /// <param name="pchPassword">password 密码</param>
        /// <param name="emSpecCap">device supported capacity,when the value is EM_LOGIN_SPAC_CAP_TYPE.SERVER_CONN means active listen mode user login(mobile dvr login) 登陆方式</param>
        /// <param name="pCapParam">nSpecCap compensation parameter，nSpecCap = EM_LOGIN_SPAC_CAP_TYPE.SERVER_CONN，pCapParam fill in device serial number string(mobile dvr login) emSpecCap参数，只有当 EM_LOGIN_SPAC_CAP_TYPE.SERVER_CONN有效</param>
        /// <param name="deviceInfo">device information，for output parmaeter 输出的设备信息</param>
        /// <returns>failed return 0,successful return LoginID,after successful login, device Operation may be via this this value(device handle)corresponding to corresponding device.失败返回0，成功返回大于O的值</returns>
        public static IntPtr LoginWithHighLevelSecurity(string pchDVRIP, ushort wDVRPort, string pchUserName, string pchPassword, EM_LOGIN_SPAC_CAP_TYPE emSpecCap, IntPtr pCapParam, ref NET_DEVICEINFO_Ex deviceInfo)
        {
            IntPtr result = IntPtr.Zero;
            NET_IN_LOGIN_WITH_HIGHLEVEL_SECURITY stuInParam = new NET_IN_LOGIN_WITH_HIGHLEVEL_SECURITY();
            stuInParam.dwSize = (uint)Marshal.SizeOf(stuInParam);
            stuInParam.szIP = pchDVRIP;
            stuInParam.nPort = wDVRPort;
            stuInParam.szUserName = pchUserName;
            stuInParam.szPassword = pchPassword;
            stuInParam.emSpecCap = emSpecCap;
            stuInParam.pCapParam = pCapParam;
            NET_OUT_LOGIN_WITH_HIGHLEVEL_SECURITY stuOutParam = new NET_OUT_LOGIN_WITH_HIGHLEVEL_SECURITY();
            stuOutParam.dwSize = (uint)Marshal.SizeOf(stuOutParam);
            result = OriginalSDK.CLIENT_LoginWithHighLevelSecurity(ref stuInParam, ref stuOutParam);
            deviceInfo = stuOutParam.stuDeviceInfo;
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// log off device
        /// 登出设备
        /// </summary>
        /// <param name="lLoginID">user LoginID:Login's returns value，登陆ID,Login返回值</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool Logout(IntPtr lLoginID)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_Logout(lLoginID);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// set re-connection callback function after disconnection. Internal SDK  auto connect again after disconnection 
        /// 设置自动重连设备
        /// </summary>
        /// <param name="cbAutoConnect">re-connection callback function 重连回调函数</param>
        /// <param name="dwUser">user data, there is no data, please use IntPtr.Zero 用户数据</param>
        public static void SetAutoReconnect(fHaveReConnectCallBack cbAutoConnect, IntPtr dwUser)
        {
            OriginalSDK.CLIENT_SetAutoReconnect(cbAutoConnect, dwUser);
        }

        /// <summary>
        /// set log in network environment
        /// 设置登陆设备的网络参数
        /// </summary>
        /// <param name="netParam">network environment 网络参数</param>
        public static void SetNetworkParam(NET_PARAM? netParam)
        {
            if (null == netParam)
            {
                return;
            }
            IntPtr lpNetParam = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_PARAM)));
            Marshal.StructureToPtr(netParam, lpNetParam, true);
            OriginalSDK.CLIENT_SetNetworkParam(lpNetParam);
            Marshal.FreeHGlobal(lpNetParam);
        }
        #endregion

        #region << real-time monitoring >>
        /// <summary>
        /// start real-time monitor.just only support 32bit
        /// 开始实时预览.只支持32位
        /// </summary>
        /// <param name="lLoginID">user LoginID:Login's returns value 登陆ID,Login返回值</param>
        /// <param name="nChannelID"><para>real time monitor channel NO.(from 0). 通道号</para>
        ///                          <para>if rType is RType_Multiplay, nChannelID is reserved.</para>
        ///                          <para>when rType is RType_Multiplay_1 ~ RType_Multiplay_16, nChannelID determines the preview picture. </para>
        ///                          <para>ex. when RType_Multiplay_4, nChannelID is 4 or 5 or 6 or 7 will display fifth to seventh channels in the four picture preview</para> </param>
        /// <param name="hWnd">display window handle. When value is 0(IntPtr.Zero), data are not decoded or displayed 显示窗口句柄</param>
        /// <param name="rType">realplay type 预览类型</param>
        /// <param name="cbRealData">real data callback 预览数据回调<seealso cref="SetRealDataCallBack"/></param>
        /// <param name="cbDisconnect">video monitor disconnect callback function 预览断线回调</param>
        /// <param name="dwUser">user defined data, used in callback 用户数据</param>
        /// <param name="dwWaitTime">waiting time 等待时间</param>
        /// <returns>failed return 0, successful return the real time monitorID(real time monitor handle),as parameter of related function. 失败返回0，成功返回大于0的值</returns>
        public static IntPtr StartRealPlay(IntPtr lLoginID, int nChannelID, IntPtr hWnd, EM_RealPlayType rType, fRealDataCallBackEx cbRealData, fRealPlayDisConnectCallBack cbDisconnect, IntPtr dwUser, uint dwWaitTime)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_StartRealPlay(lLoginID, nChannelID, hWnd, rType, cbRealData, cbDisconnect, dwUser, dwWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// start real-time monitor.support 32bit and 64bit
        /// 开始实时预览.支持32位和64位
        /// </summary>
        /// <param name="lLoginID">user LoginID:Login's returns value 登陆ID,Login返回值</param>
        /// <param name="nChannelID">real time monitor channel NO.(from 0). 通道号</param>
        /// <param name="hWnd">display window handle. When value is 0(IntPtr.Zero), data are not decoded or displayed 显示窗口句柄</param>
        /// <param name="rType">realplay type 预览类型</param>
        /// <returns>failed return 0, successful return the real time monitorID(real time monitor handle),as parameter of related function. 失败返回0，成功返回大于0的值</returns>
        public static IntPtr RealPlay(IntPtr lLoginID, int nChannelID, IntPtr hWnd, EM_RealPlayType rType = EM_RealPlayType.Realplay)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_RealPlayEx(lLoginID, nChannelID, hWnd, rType);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// stop real time monitoring
        /// 关闭实时预览
        /// </summary>
        /// <param name="lRealHandle">monitor handle StartRealPlay returns value 预览ID StartRealPlay返回值</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool StopRealPlay(IntPtr lRealHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_StopRealPlayEx(lRealHandle);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// set real-time monitor data callback 
        /// 设置实时预览数据回调
        /// </summary>
        /// <param name="lRealHandle">monitor handle 预览句柄</param>
        /// <param name="cbRealData">callback function 回调函数</param>
        /// <param name="dwUser">user data, there is no data, please use IntPtr.Zero 用户数据</param>
        /// <param name="dwFlag">by bit, can combine, when it is 0x1f, callback the five types, 回调数据类型as:
        ///                      <para>0x00000001 is equivalent with original data</para>
        ///                      <para>0x00000002 is MPEG4/H264 standard data</para>
        ///                      <para>0x00000004 YUV data</para>
        ///                      <para>0x00000008 PCM data</para>
        ///                      <para>0x00000010 original audio data</para>
        ///                      <para>0x0000001f above five data type</para></param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool SetRealDataCallBack(IntPtr lRealHandle, fRealDataCallBackEx2 cbRealData, IntPtr dwUser, EM_REALDATA_FLAG dwFlag)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_SetRealDataCallBackEx2(lRealHandle, cbRealData, dwUser, (uint)dwFlag);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// save data to file
        /// 保存实时预览数据到文件
        /// </summary>
        /// <param name="lRealHandle">monitor handle 预览句柄</param>
        /// <param name="pchFileName">save path 保存文件路径</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool SaveRealData(IntPtr lRealHandle, string pchFileName)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_SaveRealData(lRealHandle, pchFileName);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// stop saving data to file
        /// 停止保存数据到文件
        /// </summary>
        /// <param name="lRealHandle">monitor handle 预览句柄</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool StopSaveRealData(IntPtr lRealHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_StopSaveRealData(lRealHandle);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// set snapshot callback function
        /// 设置远程抓图回调
        /// </summary>
        /// <param name="OnSnapRevMessage">snapshot data callback function 抓图数据回调</param>
        /// <param name="dwUser">user data, there is no data, please use IntPtr.Zero 用户数据</param>
        public static void SetSnapRevCallBack(fSnapRevCallBack OnSnapRevMessage, IntPtr dwUser)
        {
            OriginalSDK.CLIENT_SetSnapRevCallBack(OnSnapRevMessage, dwUser);
        }

        /// <summary>
        /// snapshot request
        /// 远程抓图请求
        /// </summary>
        /// <param name="lLoginID">user LoginID:Login's return value 登陆ID，Login返回值</param>
        /// <param name="par">Snapshot parameter(structure) 抓图参数</param>
        /// <param name="reserved">reserved 保留参数</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool SnapPictureEx(IntPtr lLoginID, NET_SNAP_PARAMS par, IntPtr reserved)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_SnapPictureEx(lLoginID, ref par, reserved);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// snap picture to file
        /// 远程抓图到文件
        /// </summary>
        /// <param name="lLoginID">user LoginID:Login's return value 登陆ID，Login返回值</param>
        /// <param name="inParam">snap picture to file in paramter 抓图输入参数</param>
        /// <param name="outParam">snap picture to file out paramter 抓图输出参数</param>
        /// <param name="nWaitTime">waite time 等待时间</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool SnapPictureToFile(IntPtr lLoginID, ref NET_IN_SNAP_PIC_TO_FILE_PARAM inParam, ref NET_OUT_SNAP_PIC_TO_FILE_PARAM outParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_SnapPictureToFile(lLoginID, ref inParam, ref outParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// playback by time, support playback by direction and device must support direction
        /// 按时间回放，支持倒放，但设备要支持
        /// </summary>
        /// <param name="lLoginID">user LoginID:Login's return value 登陆ID，Login返回值</param>
        /// <param name="nChannelID">channel number 通道号</param>
        /// <param name="pstNetIn">record play back parameter in 录像回放输入参数</param>
        /// <param name="pstNetOut">record play back parameter out 录像回放输出参数</param>
        /// <returns>failed return 0, successful return the playback ID(playback handle),as parameter of related function. 失败返回0，成功返回大于0的值</returns>
        public static IntPtr PlayBackByTime(IntPtr lLoginID, int nChannelID, NET_IN_PLAY_BACK_BY_TIME_INFO pstNetIn, ref NET_OUT_PLAY_BACK_BY_TIME_INFO pstNetOut)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_PlayBackByTimeEx2(lLoginID, nChannelID, ref pstNetIn, ref pstNetOut);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Query video files
        /// 查询录像文件
        /// </summary>
        /// <param name="lLoginID">Device handles user login 登陆ID，Login返回值</param>
        /// <param name="nChannelId">channelID 通道号</param>
        /// <param name="nRecordFileType">Video file types 查询录像文件类型</param>
        /// <param name="tmStart">Recording start time 查询开始时间</param>
        /// <param name="tmEnd">Recording end time 查询结束时间</param>
        /// <param name="pchCardid">card number,Only for card number query effectively,In other cases you can fill NULL 卡号</param>
        /// <param name="nriFileinfo">Return to video file information,Is an array of structures NET_RECORDFILE_INFO[Video file information for the specified bar] 查询到文件信息</param>
        /// <param name="maxlen">nriFileinfoThe maximum length of the buffer;[Unit of byte,Dimensional structure of an array of size number*sizeof(NET_RECORDFILE_INFO),Victoria is the size of the array is equal to 1,Recommend less than 200] 最大查询长度</param>
        /// <param name="filecount">The number of documents returned,Maximum output parameters are only found in video recording until the buffer is full，查询到的文件个数</param>
        /// <param name="waittime">Waiting Time 等待时间</param>
        /// <param name="bTime">Whether by time(Currently use false) 是否通过时间，这里用FALSE</param>
        /// <returns>true:success;false:failure 失败返回false 成功返回true</returns>
        public static bool QueryRecordFile(IntPtr lLoginID, int nChannelId, EM_QUERY_RECORD_TYPE nRecordFileType, DateTime tmStart, DateTime tmEnd, string pchCardid, ref NET_RECORDFILE_INFO[] nriFileinfo, ref int filecount, int waittime, bool bTime)
        {
            bool returnValue = false;
            filecount = 0;
            IntPtr pBoxInfo = IntPtr.Zero;
            int maxlen = Marshal.SizeOf(typeof(NET_RECORDFILE_INFO)) * nriFileinfo.Length;
            try
            {
                NET_TIME timeStart = NET_TIME.FromDateTime(tmStart);
                NET_TIME timeEnd = NET_TIME.FromDateTime(tmEnd);
                pBoxInfo = Marshal.AllocHGlobal(maxlen);//Allocation of fixed specified the size of the memory space
                int fileCountMin = 0;
                if (pBoxInfo != IntPtr.Zero)
                {
                    returnValue = OriginalSDK.CLIENT_QueryRecordFile(lLoginID, nChannelId, (int)nRecordFileType, ref timeStart, ref timeEnd, pchCardid, pBoxInfo, maxlen, ref filecount, waittime, bTime);
                    NetGetLastError(returnValue);
                    fileCountMin = (filecount <= nriFileinfo.Length ? filecount : nriFileinfo.Length);
                    for (int dwLoop = 0; dwLoop < fileCountMin; dwLoop++)
                    {
                        // specify the memory space of the data is copied to the purpose in the array in the specified format
                        nriFileinfo[dwLoop] = (NET_RECORDFILE_INFO)Marshal.PtrToStructure(IntPtr.Add(pBoxInfo, Marshal.SizeOf(typeof(NET_RECORDFILE_INFO)) * dwLoop), typeof(NET_RECORDFILE_INFO));
                    }
                }
            }
            finally
            {
                Marshal.FreeHGlobal(pBoxInfo);//Release the fixed memory allocation
                pBoxInfo = IntPtr.Zero;
            }
            return returnValue;
        }


        /// <summary>
        /// Whether there is a video status mask on each day in a month
        /// 某月内的各天是否存在录像的状态
        /// </summary>
        /// <param name="lLoginID">Lonin return value 登陆ID</param>
        /// <param name="nChannelId">channel value 通道ID</param>
        /// <param name="nRecordFileType">record file type 录像类型 EM_QUERY_RECORD_TYPE </param>
        /// <param name="tmMonth">month 月份</param>
        /// <param name="pchCardid">card id 输入卡号, nRecordFileType == EM_RECORD_TYPE_CARD，pchCardid输入卡号; nRecordFileType == EM_RECORD_TYPE_FIELD，pchCardid输入自定义字段</param>
        /// <param name="pRecordStatus">recorde status in some month 某月的各天是否存在录像的状态信息</param>
        /// <param name="waittime">waittime 等待时间</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool QueryRecordStatus(IntPtr lLoginID, int nChannelId, EM_QUERY_RECORD_TYPE nRecordFileType, DateTime tmMonth, string pchCardid, ref NET_RECORD_STATUS pRecordStatus, int waittime = 1000)
        {
            bool returnValue = false;
            NET_TIME timeMonth = NET_TIME.FromDateTime(tmMonth);
            returnValue = OriginalSDK.CLIENT_QueryRecordStatus(lLoginID, nChannelId, (int)nRecordFileType, ref timeMonth, pchCardid, ref pRecordStatus, waittime);
            NetGetLastError(returnValue);
            return returnValue;
        }

        /// <summary>
        /// get current osd time.
        /// 获取当前OSD时间
        /// </summary>
        /// <param name="lPlayHandle">PlayBackByTime returns value PlayBackByTime返回值</param>
        /// <param name="lpOsdTime">return osd time 返回OSD时间</param>
        /// <param name="lpStartTime">start time 开始时间</param>
        /// <param name="lpEndTime">end time 结束时间</param>
        /// <returns>true:success;false:failure 失败返回false 成功返回true</returns>
        public static bool GetPlayBackOsdTime(IntPtr lPlayHandle, ref NET_TIME lpOsdTime, ref NET_TIME lpStartTime, ref NET_TIME lpEndTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_GetPlayBackOsdTime(lPlayHandle, ref lpOsdTime, ref lpStartTime, ref lpEndTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        ///  capture a picture
        ///  本地抓图
        /// </summary>
        /// <param name="hPlayHandle">real handle or palyback handle 实时预览或回放的句柄
        ///                            <para>StartRealPlay returns value StartRealPlay返回值</para>
        ///                            <para>PlayBackByTime returns value PlayBackByTime返回值</para></param>
        /// <param name="pchPicFileName">picture's saving name 保存的文件路径</param>
        /// <param name="eFormat">picture type 图片类型</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool CapturePicture(IntPtr hPlayHandle, string pchPicFileName, EM_NET_CAPTURE_FORMATS eFormat)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_CapturePictureEx(hPlayHandle, pchPicFileName, eFormat);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// download video by time
        /// 按时间下载录像
        /// </summary>
        /// <param name="lLoginID">user LoginID:Login's return value 登陆ID，Login返回值</param>
        /// <param name="nChannelId">channel number 通道号</param>
        /// <param name="nRecordFileType">file type 录像文件类型</param>
        /// <param name="tmStart">start time 开始时间</param>
        /// <param name="tmEnd">end time 结束时间</param>
        /// <param name="sSavedFileName">save file name 保存录像的文件名</param>
        /// <param name="cbTimeDownLoadPos">download by time's pos callback 下载的时间回调</param>
        /// <param name="dwUserData">cbTimeDownLoadPos's user data, there is no data, please use IntPtr.Zero 用户数据</param>
        /// <param name="fDownLoadDataCallBack">video data's callback 下载数据回调</param>
        /// <param name="dwDataUser">fDownLoadDataCallBack's user data, there is no data, please use IntPtr.Zero 用户数据</param>
        /// <param name="pReserved">Reserved 保留参数</param>
        /// <returns>failed return 0, successful return downloadsID,</returns>
        public static IntPtr DownloadByTime(IntPtr lLoginID, int nChannelId, EM_QUERY_RECORD_TYPE nRecordFileType, DateTime tmStart, DateTime tmEnd, string sSavedFileName,
                                                     fTimeDownLoadPosCallBack cbTimeDownLoadPos, IntPtr dwUserData,
                                                     fDataCallBack fDownLoadDataCallBack, IntPtr dwDataUser, IntPtr pReserved)
        {
            IntPtr result = IntPtr.Zero;
            NET_TIME startTime = NET_TIME.FromDateTime(tmStart);
            NET_TIME endTime = NET_TIME.FromDateTime(tmEnd);
            result = OriginalSDK.CLIENT_DownloadByTimeEx(lLoginID, nChannelId, (int)nRecordFileType, ref startTime, ref endTime, sSavedFileName,
                                                     cbTimeDownLoadPos, dwUserData, fDownLoadDataCallBack, dwDataUser, pReserved);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// stop downloads
        /// 停止下载
        /// </summary>
        /// <param name="lFileHandle">downloadsID DownloadByTime returns value 下载ID DownloadByTime返回值</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool StopDownload(IntPtr lFileHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_StopDownload(lFileHandle);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// download the video to get the current position,Can be used to display the download progress does not require real-time interface,Similar to the callback function to download
        /// 当前下载进度
        /// </summary>
        /// <param name="lFileHandle">download handle 下载句柄</param>
        /// <param name="nTotalSize">total download size(KB) 总下载大小</param>
        /// <param name="nDownLoadSize">the size have download(KB) 已经下载的大小</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool GetDownloadPos(IntPtr lFileHandle, ref int nTotalSize, ref int nDownLoadSize)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_GetDownloadPos(lFileHandle, ref nTotalSize, ref nDownLoadSize);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// PTZ control 
        /// PTZ控制接口
        /// </summary>
        /// <param name="lLoginID">user LoginID:Login's returns value 登陆ID，Login返回值</param>
        /// <param name="nChannelID">channel number 通道号</param>
        /// <param name="dwPTZCommand">PTZ control commands 控制命令</param>
        /// <param name="lParam1">Parameter1 details refer to EM_EXTPTZ_ControlType 控制命令的参数1</param>
        /// <param name="lParam2">Parameter2 details refer to EM_EXTPTZ_ControlType 控制命令的参数2</param>
        /// <param name="lParam3">Parameter3 details refer to EM_EXTPTZ_ControlType 控制命令的参数3</param>
        /// <param name="dwStop">stop or not, effective to PTZ eight-directions operation and lens operation. During other operation, this parameter should fill in false  是否停止</param>
        /// <param name="param4"><para>support PTZ control extensive command，support these commands: 控制命令的参数4</para> 
        ///                      <para>EM_EXTPTZ_ControlType.MOVE_ABSOLUTELY:Absolute motion control commands，param4 corresponding struct NET_PTZ_CONTROL_ABSOLUTELY</para>
        ///                      <para>EM_EXTPTZ_ControlType.MOVE_CONTINUOUSLY:Continuous motion control commands，param4 corresponding struct NET_PTZ_CONTROL_CONTINUOUSLY</para>
        ///                      <para>EM_EXTPTZ_ControlType.GOTOPRESET:PTZ control command, at a certain speed to preset locus，parm4 corresponding struct NET_PTZ_CONTROL_GOTOPRESET</para>
        ///                      <para>EM_EXTPTZ_ControlType.SET_VIEW_RANGE:Set to horizon(param4 corresponding struct NET_PTZ_VIEW_RANGE_INFO</para>
        ///                      <para>EM_EXTPTZ_ControlType.FOCUS_ABSOLUTELY:Absolute focus(param4 corresponding struct NET_PTZ_FOCUS_ABSOLUTELY</para>
        ///                      <para>EM_EXTPTZ_ControlType.HORSECTORSCAN:Level fan sweep(param4 corresponding NET_PTZ_CONTROL_SECTORSCAN,param1、param2、param3 is invalid</para>
        ///                      <para>EM_EXTPTZ_ControlType.VERSECTORSCAN:Vertical sweep fan(param4 corresponding NET_PTZ_CONTROL_SECTORSCAN,param1、param2、param3 is invalid</para>
        ///                      <para>EM_EXTPTZ_ControlType.SET_FISHEYE_EPTZ:Control fish eye PTZ，param4corresponding to structure NET_PTZ_CONTROL_SET_FISHEYE_EPTZ</para>
        ///                      <para>EM_EXTPTZ_ControlType.SET_TRACK_START/SET_TRACK_STOP:param4 corresponding to structure NET_PTZ_CONTROL_SET_TRACK_CONTROL,dwStop set as FALSE，param1、param2、param3  is invalid</para></param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool PTZControl(IntPtr lLoginID, int nChannelID, EM_EXTPTZ_ControlType dwPTZCommand, int lParam1, int lParam2, int lParam3, bool dwStop, IntPtr param4)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_DHPTZControlEx2(lLoginID, nChannelID, (uint)dwPTZCommand, lParam1, lParam2, lParam3, dwStop, param4);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// PTZ边界限制下发
        /// </summary>
        /// <param name="lLoginID">登陆ID，Login返回值</param>
        /// <param name="pstInParam">扫描配置入参</param>
        /// <param name="pstOutParam">扫描配置出参</param>
        /// <param name="dwWaitTime">超时时间</param>
        /// <returns></returns>
        public static bool PTZSetPanGroupLimit(IntPtr lLoginID, ref NET_IN_PAN_GROUP_LIMIT_INFO pstInParam, ref NET_OUT_PAN_GROUP_LIMIT_INFO pstOutParam, uint dwWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_PTZSetPanGroupLimit(lLoginID, ref pstInParam, ref pstOutParam, dwWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// PTZ边界限制组（添加/删除）
        /// </summary>
        /// <param name="lLoginID">登陆ID，Login返回值</param>
        /// <param name="pstInParam">入参</param>
        /// <param name="pstOutParam">出参</param>
        /// <param name="dwWaitTime">超时时间</param>
        /// <returns></returns>
        public static bool PTZSetPanGroup(IntPtr lLoginID, ref NET_IN_SET_PAN_GROUP_PARAM pstInParam, ref NET_OUT_SET_PAN_GROUP_PARAM pstOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_PTZSetPanGroup(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
            NetGetLastError(result);
            return result;

        }

        /// <summary>
        /// 获取PTZ边界限制组信息
        /// </summary>
        /// <param name="lLoginID">登陆ID，Login返回值</param>
        /// <param name="pInParam">入参</param>
        /// <param name="pOutParam">出参</param>
        /// <param name="nWaitTime">超时时间</param>
        /// <returns></returns>
        public static bool PTZGetPanGroup(IntPtr lLoginID, ref NET_IN_GET_PAN_GROUP_PARAM pInParam, ref NET_OUT_GET_PAN_GROUP_PARAM pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_PTZGetPanGroup(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// open audio
        /// 打开声音
        /// </summary>
        /// <param name="lPlayHandle">real handle or palyback handle 实时预览或回放的句柄
        ///                            <para>StartRealPlay returns value StartRealPlay返回值</para>
        ///                            <para>PlayBackByTime returns value PlayBackByTime返回值</para></param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool OpenSound(IntPtr lPlayHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_OpenSound(lPlayHandle);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// stop audio
        /// 关闭声音
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool CloseSound()
        {
            bool result = false;
            result = OriginalSDK.CLIENT_CloseSound();
            NetGetLastError(result);
            return result;
        }
        #endregion


        /// <summary>
        /// control playback operation.
        /// 二维字符串数组拼接设置
        /// </summary>
        /// <param name="index"> 在二维数组中的下标 </param>
        /// <param name="maxLen"> 需要替换的数据长度 </param>
        /// <param name="src"> 需要替换的原数据 </param>
        /// <param name="dst"> 原数据 (注:元数据内存由用户自行申请) </param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static void MultiArraySet(int index, int maxLen, string src, ref string dst)
        {
            byte[] srcArray = System.Text.Encoding.Default.GetBytes(src);
            byte[] dstArray = System.Text.Encoding.Default.GetBytes(dst);
            srcArray.CopyTo(dstArray, index * maxLen);
            dst = System.Text.Encoding.Default.GetString(dstArray);
        }

        /// <summary>
        /// control playback operation.
        /// 二维字符串数组读取
        /// </summary>
        /// <param name="index"> 在二维数组中的下标 </param>
        /// <param name="maxLen"> 需要读取的数据长度 </param>
        /// <param name="dst"> 读取结果 </param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static string MultiArrayGet(int index, int maxLen, string dst)
        {
            byte[] dstArray = System.Text.Encoding.Default.GetBytes(dst);
            return System.Text.Encoding.Default.GetString(dstArray, index * maxLen, maxLen);
        }

        /// <summary>
        /// control playback operation.
        /// 控制回放
        /// </summary>
        /// <param name="lPlayHandle">lPlayHandle:palyback handle 回放句柄</param>
        /// <param name="type">control type 控制类型</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool PlayBackControl(IntPtr lPlayHandle, PlayBackType type)
        {
            bool result = false;
            switch (type)
            {
                case PlayBackType.Play:
                    result = OriginalSDK.CLIENT_PausePlayBack(lPlayHandle, false);
                    NetGetLastError(result);
                    break;
                case PlayBackType.Pause:
                    result = OriginalSDK.CLIENT_PausePlayBack(lPlayHandle, true);
                    NetGetLastError(result);
                    break;
                case PlayBackType.Stop:
                    result = OriginalSDK.CLIENT_StopPlayBack(lPlayHandle);
                    NetGetLastError(result);
                    break;
                case PlayBackType.Fast:
                    result = OriginalSDK.CLIENT_FastPlayBack(lPlayHandle);
                    NetGetLastError(result);
                    break;
                case PlayBackType.Slow:
                    result = OriginalSDK.CLIENT_SlowPlayBack(lPlayHandle);
                    NetGetLastError(result);
                    break;
                case PlayBackType.Normal:
                    result = OriginalSDK.CLIENT_NormalPlayBack(lPlayHandle);
                    NetGetLastError(result);
                    break;
                default:
                    break;
            }
            return result;
        }

        /// <summary>
        /// set user work mode
        /// 设置用户工作模式
        /// </summary>
        /// <param name="lLoginID">loginID,login returns value 登陆ID</param>
        /// <param name="emType">user work mode 工作模式类型</param>
        /// <param name="pValue">support these type:对应的结构体
        ///                     <para>EM_USEDEV_MODE.TALK_ENCODE_TYPE:corresponding structure NET_DEV_TALKDECODE_INFO</para>
        ///                     <para>EM_USEDEV_MODE.ALARM_LISTEN_MODE:value type int(0-16)</para>
        ///                     <para>EM_USEDEV_MODE.CONFIG_AUTHORITY_MODE:value type int(0/1)</para>
        ///                     <para>EM_USEDEV_MODE.TALK_TALK_CHANNEL:value type int(channel number)</para>
        ///                     <para>EM_USEDEV_MODE.TALK_SPEAK_PARAM:corresponding structure NET_SPEAK_PARAM</para>
        ///                     <para>EM_USEDEV_MODE.TALK_TRANSFER_MODE:corresponding structure NET_TALK_TRANSFER_PARAM</para>
        ///                     <para>EM_USEDEV_MODE.PLAYBACK_REALTIME_MODE:value type int(0/1)</para>
        ///                     <para>EM_USEDEV_MODE.RECORD_STREAM_TYPE:value type int(0/1/2)</para>
        ///                     <para>EM_USEDEV_MODE.RECORD_TYPE:see to EM_RECORD_TYPE</para>
        ///                     <para>EM_USEDEV_MODE.TALK_VT_PARAM:corresponding structure NET_VT_TALK_PARAM</para>
        ///                     <para>EM_USEDEV_MODE.TARGET_DEV_ID:value type int (0 or other)</para></param>
        /// <returns>failed return false, successful return true  失败返回false 成功返回true</returns>
        public static bool SetDeviceMode(IntPtr lLoginID, EM_USEDEV_MODE emType, IntPtr pValue)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_SetDeviceMode(lLoginID, emType, pValue);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// set alarm callback function 
        /// 设置报警回调
        /// </summary>
        /// <param name="cbMessage">alarm callback 报警回调</param>
        /// <param name="dwUser">user data 用户数据</param>
        public static void SetDVRMessCallBack(fMessCallBackEx cbMessage, IntPtr dwUser)
        {
            OriginalSDK.CLIENT_SetDVRMessCallBackEx1(cbMessage, dwUser);
        }

        /// <summary>
        /// subscribe alarm
        /// 订阅报警
        /// </summary>
        /// <param name="lLoginID">loginID:login returns value 登陆ID</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool StartListen(IntPtr lLoginID)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_StartListenEx(lLoginID);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// unsubscribe alarm
        /// 取消订阅报警
        /// </summary>
        /// <param name="lLoginID">loginID:login returns value 登陆ID</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool StopListen(IntPtr lLoginID)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_StopListen(lLoginID);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// subscribe event
        /// 订阅事件
        /// </summary>
        /// <param name="lLoginID">loginID:login returns value 登陆ID</param>
        /// <param name="nChannelID">channel id 通道号</param>
        /// <param name="dwAlarmType">event type see EM_EVENT_IVS_TYPE 事件类型</param>
        /// <param name="bNeedPicFile">subscribe image file or not,ture-yes,return intelligent image info during callback function,false not return intelligent image info during callback function 是否需要图片</param>
        /// <param name="cbAnalyzerData">intelligent data analysis callback 事件回调函数</param>
        /// <param name="dwUser">user data 用户数据</param>
        /// <param name="reserved">reserved 保留参数</param>
        /// <returns>failed return 0, successful return the analyzerHandle</returns>
        public static IntPtr RealLoadPicture(IntPtr lLoginID, int nChannelID, uint dwAlarmType, bool bNeedPicFile, fAnalyzerDataCallBack cbAnalyzerData, IntPtr dwUser, IntPtr reserved)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_RealLoadPictureEx(lLoginID, nChannelID, dwAlarmType, bNeedPicFile, cbAnalyzerData, dwUser, reserved);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// unsubscribe event
        /// 取消订阅事件
        /// </summary>
        /// <param name="lAnalyzerHandle">analyzerHandle:RealLoadPicture returns value RealLoadPicture返回值</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool StopLoadPic(IntPtr lAnalyzerHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_StopLoadPic(lAnalyzerHandle);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// query system information
        /// 查询系统信息
        /// </summary>
        /// <param name="lLoginID">Login returns value 登陆ID</param>
        /// <param name="nSystemType">query type 查询类型</param>
        /// <param name="pSysInfoBuffer">information buffer 类型对应的数据信息</param>
        /// <param name="maxlen">buffer max len 最大长度</param>
        /// <param name="nSysInfolen">return information len 返回的信息大小</param>
        /// <param name="waittime">wait time 等待时间</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        private static bool QuerySystemInfo(IntPtr lLoginID, EM_SYS_ABILITY nSystemType, IntPtr pSysInfoBuffer, int maxlen, ref int nSysInfolen, int waittime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_QuerySystemInfo(lLoginID, (int)nSystemType, pSysInfoBuffer, maxlen, ref nSysInfolen, waittime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// query system information
        /// 查询系统信息
        /// </summary>
        /// <param name="lLoginID">Login returns value 登陆ID</param>
        /// <param name="nSystemType">query type 查询类型</param>
        /// <param name="obj">return information object 返回信息对像</param>
        /// <param name="waittime">wait time 等待时间</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool QuerySystemInfo(IntPtr lLoginID, EM_SYS_ABILITY nSystemType, ref object obj, int waittime)
        {
            bool result = false;
            IntPtr pBuf = IntPtr.Zero;
            Type type = obj.GetType();
            int len = Marshal.SizeOf(obj);
            int nSysInfolen = 0;
            try
            {
                pBuf = Marshal.AllocHGlobal(len);
                Marshal.StructureToPtr(obj, pBuf, true);
                result = QuerySystemInfo(lLoginID, nSystemType, pBuf, len, ref nSysInfolen, waittime);
                obj = Marshal.PtrToStructure(pBuf, type);
            }
            finally
            {
                Marshal.FreeHGlobal(pBuf);
            }
            return result;
        }

        /// <summary>
        /// query device log
        /// 查询设备日志
        /// </summary>
        /// <param name="lLoginID">Login returns value 登陆ID</param>
        /// <param name="pQueryParam">query param 查询参数</param>
        /// <param name="pLogBuffer">log buffer 日志数据缓存</param>
        /// <param name="nLogBufferLen">buffer len 缓存大小</param>
        /// <param name="pRecLogNum">return log number 返回日志的个数</param>
        /// <param name="waittime">wait time 等待时间</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool QueryDeviceLog(IntPtr lLoginID, ref NET_QUERY_DEVICE_LOG_PARAM pQueryParam, IntPtr pLogBuffer, int nLogBufferLen, ref int pRecLogNum, int waittime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_QueryDeviceLog(lLoginID, ref pQueryParam, pLogBuffer, nLogBufferLen, ref pRecLogNum, waittime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// start talk
        /// 开始对讲
        /// </summary>
        /// <param name="lLoginID">Login returns value 登陆ID</param>
        /// <param name="pfcb">audio data callback 语音回调函数</param>
        /// <param name="dwUser">user data 用户数据</param>
        /// <returns>failed return zero, successful return non-zero(talk handle) 失败返回0,成功返回大于0的值</returns>
        public static IntPtr StartTalk(IntPtr lLoginID, fAudioDataCallBack pfcb, IntPtr dwUser)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_StartTalkEx(lLoginID, pfcb, dwUser);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// stop talk
        /// 关闭对讲
        /// </summary>
        /// <param name="lTalkHandle">StartTalk returns value StartTalk返回值</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool StopTalk(IntPtr lTalkHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_StopTalkEx(lTalkHandle);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// start record
        /// 开始录音
        /// </summary>
        /// <param name="lLoginID">Login returns value 登陆ID</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool RecordStart(IntPtr lLoginID)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_RecordStartEx(lLoginID);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// stop record
        /// 关闭录音
        /// </summary>
        /// <param name="lLoginID">Login returns value 登陆ID</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool RecordStop(IntPtr lLoginID)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_RecordStopEx(lLoginID);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// send data 
        /// 发送数据
        /// </summary>
        /// <param name="lTalkHandle">StartTalk returns value StartTalk返回值</param>
        /// <param name="pSendBuf">send buffer 发送数据缓存</param>
        /// <param name="dwBufSize">buffer size 缓存大小</param>
        /// <returns>failed return zero, successful return non-zero</returns>
        public static int TalkSendData(IntPtr lTalkHandle, IntPtr pSendBuf, uint dwBufSize)
        {
            int result = 0;
            result = OriginalSDK.CLIENT_TalkSendData(lTalkHandle, pSendBuf, dwBufSize);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// audio decode
        /// 语音解码
        /// </summary>
        /// <param name="pAudioDataBuf">audio buffer 语音缓存</param>
        /// <param name="dwBufSize">buffer size 缓存大小</param>
        public static void AudioDec(IntPtr pAudioDataBuf, uint dwBufSize)
        {
            OriginalSDK.CLIENT_AudioDec(pAudioDataBuf, dwBufSize);
        }

        /// <summary>
        /// Device control,user malloc param's memory,please refer to the corresponding structure of type
        /// 设备控制
        /// </summary>
        /// <param name="lLoginID">loginID:login returns value 登陆ID</param>
        /// <param name="type">CtrlType 控制类型</param>
        /// <param name="param">pointer to control param 控制类型对应的信息指针地址</param>
        /// <param name="waittime">wait time 等待时间</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool ControlDevice(IntPtr lLoginID, EM_CtrlType type, IntPtr param, int waittime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_ControlDevice(lLoginID, type, param, waittime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Device control,user malloc param's memory,please refer to the corresponding structure of type
        /// 设备控制Ex
        /// </summary>
        /// <param name="lLoginID">loginID:login returns value 登陆ID</param>
        /// <param name="type">CtrlType 控制类型</param>
        /// <param name="pInBuf">pointer to control in param 控制类型对应的信息入参指针地址</param>
        /// <param name="pOutBuf">pointer to control out param 控制类型对应的信息出参指针地址</param>
        /// <param name="nWaitTime">wait time 等待时间</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool ControlDeviceEx(IntPtr lLoginID, EM_CtrlType emType, IntPtr pInBuf, IntPtr pOutBuf, int nWaitTime = 1000)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_ControlDeviceEx(lLoginID, emType, pInBuf, pOutBuf, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// query device state
        /// 查询设备状态
        /// </summary>
        /// <param name="lLoginID">loginID:login returns value 登陆ID</param>
        /// <param name="nType">query type 查询类型</param>
        /// <param name="obj">return information object 返回信息对像</param>
        /// <param name="typeName">query struct type 查询结构体的类型</param>
        /// <param name="waittime">waittime 等待时间</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool QueryDevState(IntPtr lLoginID, int nType, ref object obj, Type typeName, int waittime)
        {
            bool result = false;
            int pRetLen = 0;
            int nBufLen = 0;
            IntPtr pBuf = IntPtr.Zero;
            try
            {
                nBufLen = Marshal.SizeOf(typeName);
                pBuf = Marshal.AllocHGlobal(Marshal.SizeOf(typeName));
                Marshal.StructureToPtr(obj, pBuf, true);
                result = OriginalSDK.CLIENT_QueryDevState(lLoginID, nType, pBuf, nBufLen, ref pRetLen, waittime);
                NetGetLastError(result);
                obj = Marshal.PtrToStructure(pBuf, typeName);
            }
            finally
            {
                Marshal.FreeHGlobal(pBuf);
                nBufLen = 0;
            }
            return result;
        }

        public static bool QueryDevState(IntPtr lLoginID, EM_DEVICE_STATE nType, ref object obj, Type typeName, int waittime)
        {
            bool result = false;
            int pRetLen = 0;
            int nBufLen = 0;
            IntPtr pBuf = IntPtr.Zero;
            try
            {
                nBufLen = Marshal.SizeOf(typeName);
                pBuf = Marshal.AllocHGlobal(Marshal.SizeOf(typeName));
                Marshal.StructureToPtr(obj, pBuf, true);
                result = OriginalSDK.CLIENT_QueryDevState(lLoginID, (int)nType, pBuf, nBufLen, ref pRetLen, waittime);
                NetGetLastError(result);
                obj = Marshal.PtrToStructure(pBuf, typeName);
            }
            finally
            {
                Marshal.FreeHGlobal(pBuf);
                nBufLen = 0;
            }
            return result;
        }

        /// <summary>
        /// query device state
        /// 查询设备状态
        /// </summary>
        /// <param name="lLoginID">loginID:login returns value 登陆ID</param>
        /// <param name="nType">query type 查询类型</param>
        /// <param name="obj">return information object 返回信息对像</param>
        /// <param name="typeName">query struct type 查询结构体的类型</param>
        /// <param name="waittime">waittime 等待时间</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool QueryDevState(IntPtr lLoginID, int nType, ref object[] objs, Type typeName, int waittime)
        {
            bool result = false;
            int pRetLen = 0;
            int nBufLen = 0;
            IntPtr pBuf = IntPtr.Zero;
            int nQueryNum = objs.Length;
            try
            {
                nBufLen = Marshal.SizeOf(typeName) * nQueryNum;
                pBuf = Marshal.AllocHGlobal(nBufLen);
                for (int index = 0; index < nQueryNum; index++)
                {
                    IntPtr pIndexBuf = IntPtr.Add(pBuf, index * Marshal.SizeOf(typeName));
                    if (objs[index] != null && objs[index].GetType() == typeName)
                    {
                        Marshal.StructureToPtr(objs[index], pIndexBuf, true);
                    }
                    else
                    {
                        for (int i = 0; i < Marshal.SizeOf(typeName); i++)
                        {
                            Marshal.WriteByte(pIndexBuf, i, 0);
                        }
                    }
                }

                result = OriginalSDK.CLIENT_QueryDevState(lLoginID, nType, pBuf, nBufLen, ref pRetLen, waittime);
                NetGetLastError(result);
                if (result)
                {
                    int nRetNum = pRetLen / Marshal.SizeOf(typeName);
                    objs = new object[nRetNum];
                    for (int i = 0; i < nRetNum; i++)
                    {
                        objs[i] = Marshal.PtrToStructure(IntPtr.Add(pBuf, i * Marshal.SizeOf(typeName)), typeName);
                    }
                }

            }
            finally
            {
                Marshal.FreeHGlobal(pBuf);
                nBufLen = 0;
            }
            return result;
        }

        public static bool QueryDevState(IntPtr lLoginID, int nType, ref byte[] byStates, int waittime)
        {
            bool result = false;
            int pRetLen = 0;
            int nBufLen = 1024 * 1024;
            IntPtr pBuf = IntPtr.Zero;
            try
            {
                pBuf = Marshal.AllocHGlobal(nBufLen);
                result = OriginalSDK.CLIENT_QueryDevState(lLoginID, nType, pBuf, nBufLen, ref pRetLen, waittime);
                NetGetLastError(result);
                if (pRetLen == 0)
                {
                    byStates = new byte[0];
                }
                else
                {
                    byStates = new byte[pRetLen];
                    for (int i = 0; i < byStates.Length; i++)
                    {
                        byStates[i] = Marshal.ReadByte(IntPtr.Add(pBuf, i));
                    }
                }
            }
            finally
            {
                Marshal.FreeHGlobal(pBuf);
                nBufLen = 0;
            }
            return result;
        }

        /// <summary>
        /// New Search system capacity information
        /// 查询系统能力信息
        /// </summary>
        /// <param name="lLoginID">CLIENT_Login's return value 登陆ID</param>
        /// <param name="lChannel">Channel id 通道号</param>
        /// <param name="strCommand">Command string 查询命令</param>
        /// <param name="obj">Object correspondence to the Command 返回的数据</param>
        /// <param name="typeName">obj's type 查询命令对应结构体的类型</param>
        /// <param name="waittime">Wait timeout,The default setting is 1000 等待时间</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool QueryNewSystemInfo(IntPtr lLoginID, Int32 lChannel, string strCommand, ref object obj, Type typeName, int waittime)
        {
            bool returnValue = false;
            IntPtr pInBuf = IntPtr.Zero;
            IntPtr pOutBuf = IntPtr.Zero;
            IntPtr pRetLen = IntPtr.Zero;

            UInt32 nRetLen = 0;
            UInt32 nBufSize = 1024 * 1024;
            UInt32 nError = 0;

            try
            {
                pInBuf = Marshal.AllocHGlobal((int)nBufSize);//Allocation of fixed specified the size of the memory space
                pOutBuf = Marshal.AllocHGlobal(Marshal.SizeOf(typeName));
                if (obj.GetType() == typeName)                            //if obj is boxinged type of typeName, some param(ex. dwsize) need trans to unmanaged memory
                {
                    Marshal.StructureToPtr(obj, pOutBuf, true);
                }
                else
                {
                    for (int i = 0; i < Marshal.SizeOf(typeName); i++)
                    {
                        Marshal.WriteByte(pOutBuf, i, 0);
                    }
                }
                pRetLen = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(UInt32)));

                if (pInBuf != IntPtr.Zero && pOutBuf != IntPtr.Zero)
                {
                    returnValue = OriginalSDK.CLIENT_QueryNewSystemInfo(lLoginID, strCommand, lChannel, pInBuf,
                                                         nBufSize, ref nError, waittime);
                    NetGetLastError(returnValue);
                    if (returnValue == true)
                    {
                        returnValue = OriginalSDK.CLIENT_ParseData(strCommand, pInBuf, pOutBuf, (UInt32)Marshal.SizeOf(typeName), pRetLen);
                        nRetLen = (UInt32)Marshal.PtrToStructure(pRetLen, typeof(UInt32));
                        obj = Marshal.PtrToStructure(pOutBuf, typeName);
                    }
                }
                NetGetLastError(returnValue);
            }

            finally
            {
                Marshal.FreeHGlobal(pInBuf);//Release fixed memory allocation
                Marshal.FreeHGlobal(pOutBuf);//Release fixed memory allocation
                Marshal.FreeHGlobal(pRetLen);//Release fixed memory allocation
                pInBuf = IntPtr.Zero;
                pOutBuf = IntPtr.Zero;
                pRetLen = IntPtr.Zero;
            }
            return returnValue;
        }

        /// <summary>
        /// New Search system capacity information
        /// 查询系统能力信息(带额外信息)
        /// </summary>
        /// <param name="lLoginID">CLIENT_Login's return value 登陆ID</param>
        /// <param name="lChannel">Channel id 通道号</param>
        /// <param name="strCommand">Command string 查询命令</param>
        /// <param name="obj">Object correspondence to the Command 返回的数据</param>
        /// <param name="typeName">obj's type 查询命令对应结构体的类型</param>
        /// <param name="waittime">Wait timeout,The default setting is 1000 等待时间</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool QueryNewSystemInfoEx(IntPtr lLoginID, Int32 lChannel, string strCommand,
                                                ref object obj, Type typeName, Object extendInfo, Type extendInfoType, int waittime)
        {
            bool returnValue = false;
            IntPtr pInBuf = IntPtr.Zero;
            IntPtr pOutBuf = IntPtr.Zero;
            IntPtr pRetLen = IntPtr.Zero;

            UInt32 nRetLen = 0;
            UInt32 nBufSize = 1024 * 1024;
            UInt32 nError = 0;

            IntPtr pExtendInfo = IntPtr.Zero;

            try
            {
                if (extendInfo != null && extendInfoType != null)
                {
                    pExtendInfo = Marshal.AllocHGlobal(Marshal.SizeOf(extendInfoType));
                    Marshal.StructureToPtr(extendInfo, pExtendInfo, true);
                }

                pInBuf = Marshal.AllocHGlobal((int)nBufSize);   // Allocation of fixed specified the size of the memory space
                pOutBuf = Marshal.AllocHGlobal(Marshal.SizeOf(typeName));

                pRetLen = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(UInt32)));

                if (pInBuf != IntPtr.Zero && pOutBuf != IntPtr.Zero)
                {
                    returnValue = OriginalSDK.CLIENT_QueryNewSystemInfoEx(lLoginID, strCommand, lChannel, pInBuf,
                                                         nBufSize, ref nError, pExtendInfo, waittime);
                    NetGetLastError(returnValue);
                    if (returnValue == true)
                    {
                        returnValue = OriginalSDK.CLIENT_ParseData(strCommand, pInBuf, pOutBuf, (UInt32)Marshal.SizeOf(typeName), pRetLen);
                        nRetLen = (UInt32)Marshal.PtrToStructure(pRetLen, typeof(UInt32));
                        obj = Marshal.PtrToStructure(pOutBuf, typeName);
                    }
                }
                NetGetLastError(returnValue);
            }

            finally
            {
                Marshal.FreeHGlobal(pExtendInfo);
                Marshal.FreeHGlobal(pInBuf);//Release fixed memory allocation
                Marshal.FreeHGlobal(pOutBuf);//Release fixed memory allocation
                Marshal.FreeHGlobal(pRetLen);//Release fixed memory allocation

                pExtendInfo = IntPtr.Zero;
                pInBuf = IntPtr.Zero;
                pOutBuf = IntPtr.Zero;
                pRetLen = IntPtr.Zero;
            }
            return returnValue;
        }



        /// <summary>
        /// start search record by search filter
        /// 打开查找录像文件
        /// </summary>
        /// <param name="lLoginID">Lonin return value 登陆ID</param>
        /// <param name="emRecordType">Record Type 录像类型</param>
        /// <param name="oCondition">search condition 查找条件</param>
        /// <param name="tyCondition">type of condition struct 查找条件对应结构体的类型</param>
        /// <param name="lFindID">lFindeHandle 返回的查找ID</param>
        /// <param name="waittime">Wait timeout, million second 等待时间</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool FindRecord(IntPtr lLoginID, EM_NET_RECORD_TYPE emRecordType, object oCondition, Type tyCondition, ref IntPtr lFindID, int waittime)
        {
            bool result = false;
            IntPtr pCondition = IntPtr.Zero;
            NET_IN_FIND_RECORD_PARAM stuInParam = new NET_IN_FIND_RECORD_PARAM();
            NET_OUT_FIND_RECORD_PARAM stuOutParam = new NET_OUT_FIND_RECORD_PARAM();
            stuInParam.dwSize = (uint)Marshal.SizeOf(stuInParam);
            stuInParam.emType = emRecordType;
            try
            {
                if (oCondition == null || tyCondition == null)
                {
                    stuInParam.pQueryCondition = IntPtr.Zero;
                }
                else
                {
                    pCondition = Marshal.AllocHGlobal(Marshal.SizeOf(tyCondition));
                    Marshal.StructureToPtr(oCondition, pCondition, true);
                    stuInParam.pQueryCondition = pCondition;
                }
                stuOutParam.dwSize = (uint)Marshal.SizeOf(stuOutParam);
                result = OriginalSDK.CLIENT_FindRecord(lLoginID, ref stuInParam, ref stuOutParam, waittime);
                NetGetLastError(result);
                lFindID = stuOutParam.lFindeHandle;
            }
            finally
            {
                Marshal.FreeHGlobal(pCondition);
            }
            return result;
        }

        /// <summary>
        /// search record :nFilecount: need search items,  return value as media file items  return value
        /// 查找录像文件
        /// </summary>
        /// <param name="lFindeHandle">FindRecord's return value FindRecord返回值</param>
        /// <param name="nMaxNum">max number of search 最大的个数</param>
        /// <param name="nRetNum">return number 返回的个数</param>
        /// <param name="ls">list of Record 返回的录像列表</param>
        /// <param name="tyRecord">typeof Record 查找录像对应的结构的类型</param>
        /// <param name="waittime">Wait timeout, million second 等待时间</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static int FindNextRecord(IntPtr lFindeHandle, int nMaxNum, ref int nRetNum, ref List<object> ls, Type tyRecord, int waittime)
        {
            int result = 0;
            IntPtr pRecordList = IntPtr.Zero;
            try
            {
                NET_IN_FIND_NEXT_RECORD_PARAM stuInParam = new NET_IN_FIND_NEXT_RECORD_PARAM();
                stuInParam.dwSize = (uint)Marshal.SizeOf(stuInParam);
                stuInParam.lFindeHandle = lFindeHandle;
                stuInParam.nFileCount = nMaxNum;

                NET_OUT_FIND_NEXT_RECORD_PARAM stuOutParam = new NET_OUT_FIND_NEXT_RECORD_PARAM();
                stuOutParam.dwSize = (uint)Marshal.SizeOf(stuOutParam);
                stuOutParam.nMaxRecordNum = nMaxNum;

                pRecordList = Marshal.AllocHGlobal(Marshal.SizeOf(tyRecord) * nMaxNum);
                for (int i = 0; i < nMaxNum; i++)
                {
                    Marshal.StructureToPtr(ls[i], IntPtr.Add(pRecordList, Marshal.SizeOf(tyRecord) * i), true);
                }
                stuOutParam.pRecordList = pRecordList;

                result = OriginalSDK.CLIENT_FindNextRecord(ref stuInParam, ref stuOutParam, waittime);

                if (result >= 0)
                {
                    nRetNum = stuOutParam.nRetRecordNum;
                    ls.Clear();
                    for (int i = 0; i < nRetNum; i++)
                    {
                        ls.Add(Marshal.PtrToStructure(IntPtr.Add(pRecordList, Marshal.SizeOf(tyRecord) * i), tyRecord));
                    }
                }
                else
                {
                    NetGetLastError(result);
                }
            }
            finally
            {
                Marshal.FreeHGlobal(pRecordList);
            }

            return result;
        }

        /// <summary>
        /// end record search
        /// 关闭查找
        /// </summary>
        /// <param name="lFindHandle">FindRecord's return value FindRecord返回值</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool FindRecordClose(IntPtr lFindHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_FindRecordClose(lFindHandle);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// search records' count
        /// 查找录像的个数
        /// </summary>
        /// <param name="lFindHandle">FindRecord's return value FindRecord返回值</param>
        /// <param name="nRecordCount">records' count 录像的个数</param>
        /// <param name="waittime">Wait timeout, million second 等待时间</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool QueryRecordCount(IntPtr lFindHandle, ref int nRecordCount, int waittime)
        {
            bool result = false;
            NET_IN_QUEYT_RECORD_COUNT_PARAM stuInParam = new NET_IN_QUEYT_RECORD_COUNT_PARAM();
            stuInParam.dwSize = (uint)Marshal.SizeOf(stuInParam);
            stuInParam.lFindeHandle = lFindHandle;
            NET_OUT_QUEYT_RECORD_COUNT_PARAM stuOutParam = new NET_OUT_QUEYT_RECORD_COUNT_PARAM();
            stuOutParam.dwSize = (uint)Marshal.SizeOf(stuOutParam);

            result = OriginalSDK.CLIENT_QueryRecordCount(ref stuInParam, ref stuOutParam, waittime);
            nRecordCount = stuOutParam.nRecordCount;
            NetGetLastError(result);
            return result;
        }

        #region <<Number State>>
        /// <summary>
        /// start find number state
        /// 打开查找数字统计状态
        /// </summary>
        /// <param name="lLoginID">CLIENT_Login's return value 登陆ID</param>
        /// <param name="pstInParam">In Param 输入参数</param>
        /// <param name="pstOutParam">Out Param, dwsize need assign too 输出参数</param>
        /// <returns>Find Handle 返回查找名柄</returns>
        public static IntPtr StartFindNumberStat(IntPtr lLoginID, ref NET_IN_FINDNUMBERSTAT pstInParam, ref NET_OUT_FINDNUMBERSTAT pstOutParam)
        {
            IntPtr pRet = IntPtr.Zero;
            pRet = OriginalSDK.CLIENT_StartFindNumberStat(lLoginID, ref pstInParam, ref pstOutParam);
            NetGetLastError(pRet);
            return pRet;
        }

        /// <summary>
        /// do find number state
        /// 查找数字统计状态
        /// </summary>
        /// <param name="lFindHandle">StartFindNumberStat return value StartFindNumberStat返回值</param>
        /// <param name="pstInParam">in param 输入参数</param>
        /// <param name="pNumberStats">number stats' array. 数字统计状态的数组</param>
        /// <returns>larger than 0: success. small than 0: fail 大于0成功，小于0失败</returns>
        public static int DoFindNumberStat(IntPtr lFindHandle, ref NET_IN_DOFINDNUMBERSTAT pstInParam, ref NET_NUMBERSTAT[] pNumberStats)
        {
            int nRet = 0;
            uint nMaxCount = pstInParam.nCount;
            IntPtr pBuffer = IntPtr.Zero;
            NET_OUT_DOFINDNUMBERSTAT stuOutParam = new NET_OUT_DOFINDNUMBERSTAT();
            int nUnitBufferSize = Marshal.SizeOf(typeof(NET_NUMBERSTAT));
            try
            {
                pBuffer = Marshal.AllocHGlobal(nUnitBufferSize * (int)nMaxCount);
                stuOutParam.dwSize = (uint)Marshal.SizeOf(stuOutParam);
                stuOutParam.pstuNumberStat = pBuffer;
                stuOutParam.nBufferLen = (int)nMaxCount * nUnitBufferSize;
                stuOutParam.nCount = (int)pstInParam.nCount;

                for (int i = 0; i < nMaxCount; i++)
                {
                    NET_NUMBERSTAT item = new NET_NUMBERSTAT();
                    item.dwSize = (uint)Marshal.SizeOf(item);
                    Marshal.StructureToPtr(item, IntPtr.Add(pBuffer, i * nUnitBufferSize), true);
                }

                nRet = OriginalSDK.CLIENT_DoFindNumberStat(lFindHandle, ref pstInParam, ref stuOutParam);

                NetGetLastError(nRet);

                if (nRet > 0)
                {
                    pNumberStats = new NET_NUMBERSTAT[stuOutParam.nCount];
                    for (int i = 0; i < stuOutParam.nCount; i++)
                    {
                        pNumberStats[i] = (NET_NUMBERSTAT)Marshal.PtrToStructure(IntPtr.Add(pBuffer, i * nUnitBufferSize), typeof(NET_NUMBERSTAT));
                    }
                }
            }

            finally
            {
                Marshal.FreeHGlobal(pBuffer);
                pBuffer = IntPtr.Zero;
            }

            return nRet;
        }

        /// <summary>
        /// stop find number state
        /// 关闭查找数字统计状态
        /// </summary>
        /// <param name="lFindHandle">StartFindNumberStat return value StartFindNumberStat返回值</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool StopFindNumberStat(IntPtr lFindHandle)
        {
            bool bRet = false;
            bRet = OriginalSDK.CLIENT_StopFindNumberStat(lFindHandle);
            NetGetLastError(bRet);
            return bRet;
        }

        /// <summary>
        /// subscribe video statistical summary
        /// 订阅视频统计摘要信息
        /// </summary>
        /// <param name="lLoginID">CLIENT_Login's return value 登陆ID</param>
        /// <param name="pInParam">in param 输入参数</param>
        /// <param name="pOutParam">out param, not useful, dwsize need assign too 输出参数</param>
        /// <param name="nWaitTime">Wait timeout, million second 等待时间</param>
        /// <returns>Attach Handle 订阅句柄</returns>
        public static IntPtr AttachVideoStatSummary(IntPtr lLoginID, ref NET_IN_ATTACH_VIDEOSTAT_SUM pInParam, ref NET_OUT_ATTACH_VIDEOSTAT_SUM pOutParam, int nWaitTime)
        {
            IntPtr pRet = IntPtr.Zero;
            pRet = OriginalSDK.CLIENT_AttachVideoStatSummary(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(pRet);
            return pRet;
        }

        /// <summary>
        /// unsubscribe video statistical summary
        /// 取消订阅视频统计摘要信息
        /// </summary>
        /// <param name="lAttachHandle">AttachVideoStatSummary returns value AttachVideoStatSummary返回值</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool DetachVideoStatSummary(IntPtr lAttachHandle)
        {
            bool bRet = false;
            bRet = OriginalSDK.CLIENT_DetachVideoStatSummary(lAttachHandle);
            NetGetLastError(bRet);
            return bRet;
        }
        #endregion

        #region <<Trans Com>>
        /// <summary>
        /// create transparent serial channel, change front-end device serial to transparent channel status
        /// 创建透明串口通道
        /// </summary>
        /// <param name="lLoginID">Login return value 登陆ID</param>
        /// <param name="TransComType">lower 2 bytes are serial type, 0:serial(232), 1:485 port; higher 2 bytes are channel number, start from 0  TransComType高2个字节表示串口序号,低2个字节表示串口类型</param>
        /// <param name="baudrate">serial baud rate,1~8 as 1200,2400,4800,9600,19200,38400,57600,115200 respectively 串口波特率</param>
        /// <param name="databits">serial data digit 4~8 represent 4~8 digits 串口数据位< /param>
        /// <param name="stopbits">serial stop digit 1 represent 1 digit, 2 represent 1-5 digit(s), 3 represent 2 digits 串口停止位</param>
        /// <param name="parity">serial inspection digit,1:odd,2:even,3: none  串口检测数据</param>
        /// <param name="cbTransCom">serial data callback, recall info sent from front-end device 串口数据回调</param>
        /// <param name="dwUser">user data 用户数据</param>
        /// <returns>successful return to transparent serial ID,failed return to 0. 失败返回0，成功返回大于0的值</returns>
        public static IntPtr CreateTransComChannel(IntPtr lLoginID, int TransComType, uint baudrate, uint databits, uint stopbits, uint parity, fTransComCallBack cbTransCom, IntPtr dwUser)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_CreateTransComChannel(lLoginID, TransComType, baudrate, databits, stopbits, parity, cbTransCom, dwUser);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// send transparent serial data, as sent data to front end data
        /// 透明串口发送数据
        /// </summary>
        /// <param name="lTransComChannel">transparent serial ID, interface CreateTransComChannel value  CreateTransComChannel返回值</param>
        /// <param name="byDatas">transparent serial data to send 发送的数据</param>
        /// <returns>successful return to TRUE,failed return to FALSE. 失败返回false 成功返回true</returns>
        public static bool SendTransComData(IntPtr lTransComChannel, byte[] byDatas)
        {
            bool result = false;
            IntPtr pBuffer = IntPtr.Zero;
            uint dwLength = (uint)byDatas.Length;
            try
            {
                pBuffer = Marshal.AllocHGlobal(byDatas.Length);
                for (int i = 0; i < dwLength; i++)
                {
                    Marshal.WriteByte(pBuffer, i, byDatas[i]);
                }
                result = OriginalSDK.CLIENT_SendTransComData(lTransComChannel, pBuffer, (uint)byDatas.Length);
            }
            finally
            {
                Marshal.FreeHGlobal(pBuffer);
            }

            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// close transparent channel
        /// 关闭透明串口通道
        /// </summary>
        /// <param name="lTransComChannel">transparent serial ID, interface CreateTransComChannel return value CreateTransComChannel返回值</param>
        /// <returns>successful return to TRUE,failed return to FALSE 失败返回false 成功返回true</returns>
        public static bool DestroyTransComChannel(IntPtr lTransComChannel)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_DestroyTransComChannel(lTransComChannel);
            NetGetLastError(result);
            return result;
        }
        #endregion <<Trans Com>>

        #region <<Security>>
        /// <summary>
        /// Set Security Key
        /// 设置安全密钥
        /// </summary>
        /// <param name="lPlayHandle">Play Handle 播放名柄</param>
        /// <param name="szKey">Security Key 安全密钥</param>
        /// <returns>failed return false, successful return true  失败返回false 成功返回true</returns>
        public static bool NetSetSecurityKey(IntPtr lPlayHandle, string szKey)
        {
            bool result = OriginalSDK.CLIENT_SetSecurityKey(lPlayHandle, szKey, (uint)szKey.Length);
            NetGetLastError(result);
            return result;
        }

        #endregion

        #region <<Monitor Wall>>
        public static bool QueryMatrixCardInfo(IntPtr lLoginID, ref NET_MATRIX_CARD_LIST pstuCardList, int nWaitTime)
        {
            bool result = OriginalSDK.CLIENT_QueryMatrixCardInfo(lLoginID, ref pstuCardList, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool GetSplitCaps(IntPtr lLoginId, int nChannel, ref NET_SPLIT_CAPS stuCaps, int nWaitTime)
        {
            bool result = OriginalSDK.CLIENT_GetSplitCaps(lLoginId, nChannel, ref stuCaps, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool GetSplitMode(IntPtr lLoginID, int nChannel, ref NET_SPLIT_MODE_INFO stuSplitInfo, int nWaitTime)
        {
            bool result = OriginalSDK.CLIENT_GetSplitMode(lLoginID, nChannel, ref stuSplitInfo, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool SetSplitMode(IntPtr lLoginID, int nChannel, ref NET_SPLIT_MODE_INFO stuSplitInfo, int nWaitTime)
        {
            bool result = OriginalSDK.CLIENT_SetSplitMode(lLoginID, nChannel, ref stuSplitInfo, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool OpenSplitWindow(IntPtr lLoginID, ref NET_IN_SPLIT_OPEN_WINDOW pInParam, ref NET_OUT_SPLIT_OPEN_WINDOW pOutParam, int nWaitTime)
        {
            bool result = OriginalSDK.CLIENT_OpenSplitWindow(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 设置显示源(pInparam, pOutParam内存由用户申请释放)
        /// set display source,user malloc and free (pInParam's and pOutParam's)memory
        /// </summary>
        public static bool MatrixSetCameras(IntPtr lLoginID, ref NET_IN_MATRIX_SET_CAMERAS pInParam, ref NET_OUT_MATRIX_SET_CAMERAS pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_MatrixSetCameras(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        // get all valid display source, return length is stuCameras.Length
        public static bool MatrixGetCameras(IntPtr lLoginID, out NET_MATRIX_CAMERA_INFO[] stuCameras, int nMaxCameraCount, int nWaitTime)
        {
            bool result = false;
            stuCameras = new NET_MATRIX_CAMERA_INFO[nMaxCameraCount];
            NET_IN_MATRIX_GET_CAMERAS stuInParam = new NET_IN_MATRIX_GET_CAMERAS();
            stuInParam.dwSize = (uint)Marshal.SizeOf(stuInParam.GetType());
            NET_OUT_MATRIX_GET_CAMERAS stuOutParam = new NET_OUT_MATRIX_GET_CAMERAS();
            stuOutParam.dwSize = (uint)Marshal.SizeOf(stuOutParam.GetType());
            try
            {
                int nBuflen = Marshal.SizeOf(typeof(NET_MATRIX_CAMERA_INFO)) * nMaxCameraCount;
                stuOutParam.pstuCameras = Marshal.AllocHGlobal(nBuflen);//开辟内存
                for (int i = 0; i < nMaxCameraCount; i++)
                {
                    stuCameras[i].dwSize = (uint)Marshal.SizeOf(stuCameras[i].GetType());
                    stuCameras[i].stuRemoteDevice.dwSize = (uint)Marshal.SizeOf(stuCameras[i].stuRemoteDevice.GetType());
                    IntPtr pstuCamTemp = IntPtr.Add(stuOutParam.pstuCameras, Marshal.SizeOf(typeof(NET_MATRIX_CAMERA_INFO)) * i);
                    Marshal.StructureToPtr(stuCameras[i], pstuCamTemp, true);
                }
                stuOutParam.nMaxCameraCount = nMaxCameraCount;
                result = OriginalSDK.CLIENT_MatrixGetCameras(lLoginID, ref stuInParam, ref stuOutParam, nWaitTime);
                NetGetLastError(result);
                if (result)
                {
                    int nRetCount = Math.Min(stuOutParam.nMaxCameraCount, stuOutParam.nRetCameraCount);
                    stuCameras = new NET_MATRIX_CAMERA_INFO[nRetCount];
                    for (int i = 0; i < nRetCount; i++)
                    {
                        IntPtr pstuCamTemp = IntPtr.Add(stuOutParam.pstuCameras, Marshal.SizeOf(typeof(NET_MATRIX_CAMERA_INFO)) * i);
                        stuCameras[i] = (NET_MATRIX_CAMERA_INFO)Marshal.PtrToStructure(pstuCamTemp, typeof(NET_MATRIX_CAMERA_INFO));
                    }
                }
            }
            finally
            {
                Marshal.FreeHGlobal(stuOutParam.pstuCameras);
            }
            return result;
        }

        public static bool SetSplitSource(IntPtr lLoginID, int nChannel, int nWindow, NET_SPLIT_SOURCE[] stuSplitSrcs, int nWaitTime)
        {
            bool result = false;
            IntPtr pstuSplitSrc = IntPtr.Zero;
            try
            {
                pstuSplitSrc = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_SPLIT_SOURCE)) * stuSplitSrcs.Length);
                for (int i = 0; i < stuSplitSrcs.Length; i++)
                {
                    IntPtr pstuSplitSrcTemp = IntPtr.Add(pstuSplitSrc, Marshal.SizeOf(typeof(NET_SPLIT_SOURCE)) * i);
                    Marshal.StructureToPtr(stuSplitSrcs[i], pstuSplitSrcTemp, true);
                }
                result = OriginalSDK.CLIENT_SetSplitSource(lLoginID, nChannel, nWindow, pstuSplitSrc, stuSplitSrcs.Length, nWaitTime);
            }
            finally
            {
                Marshal.FreeHGlobal(pstuSplitSrc);
            }
            NetGetLastError(result);
            return result;
        }

        public static bool SetSplitSourceEx(IntPtr lLoginID, NET_IN_SET_SPLIT_SOURCE inParam, ref NET_OUT_SET_SPLIT_SOURCE outParam, int nWaitTime)
        {
            bool result = OriginalSDK.CLIENT_SetSplitSourceEx(lLoginID, ref inParam, ref outParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }
        #endregion



        #region <<config>>

        public static bool GetNewDevConfig(IntPtr lLoginID, Int32 lChannel, string strCommand, ref object obj, Type typeName, int waittime)
        {
            bool returnValue = false;
            IntPtr pInBuf = IntPtr.Zero;
            IntPtr pOutBuf = IntPtr.Zero;
            IntPtr pLastBuf = IntPtr.Zero;

            UInt32 nBufSize = 1024 * 1024;
            int nError = 0;

            try
            {
                pInBuf = Marshal.AllocHGlobal((int)nBufSize);//Allocation of fixed specified the size of the memory space
                for (int i = 0; i < nBufSize; i++)
                {
                    Marshal.WriteByte(pInBuf, i, 0);
                }
                pOutBuf = Marshal.AllocHGlobal(Marshal.SizeOf(typeName));
                if (obj.GetType() == typeName)                            //if obj is boxinged type of typeName, some param(ex. dwsize) need trans to unmanaged memory
                {
                    Marshal.StructureToPtr(obj, pOutBuf, true);
                }
                else
                {
                    for (int i = 0; i < Marshal.SizeOf(typeName); i++)
                    {
                        Marshal.WriteByte(pOutBuf, i, 0);
                    }
                }
                pLastBuf = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(uint)));
                if (pInBuf != IntPtr.Zero && pOutBuf != IntPtr.Zero)
                {
                    returnValue = OriginalSDK.CLIENT_GetNewDevConfig(lLoginID, strCommand, lChannel, pInBuf,
                                                         nBufSize, out nError, waittime);

                    if (returnValue == true)
                    {
                        returnValue = OriginalSDK.CLIENT_ParseData(strCommand, pInBuf, pOutBuf, (UInt32)Marshal.SizeOf(typeName), pLastBuf);

                        obj = Marshal.PtrToStructure(pOutBuf, typeName);
                    }
                }
            }
            finally
            {
                Marshal.FreeHGlobal(pInBuf);//Release fixed memory allocation
                Marshal.FreeHGlobal(pOutBuf);//Release fixed memory allocation
                Marshal.FreeHGlobal(pLastBuf);//Release fixed memory allocation

                pInBuf = IntPtr.Zero;
                pOutBuf = IntPtr.Zero;
                pLastBuf = IntPtr.Zero;

            }
            NetGetLastError(returnValue);
            return returnValue;
        }

        //get 
        public static bool GetNewDevConfig(IntPtr lLoginID, Int32 lChannel, string strCommand, ref object[] objs, Type typeName, int waittime)
        {
            bool returnValue = false;
            IntPtr pInBuf = IntPtr.Zero;
            IntPtr pOutBuf = IntPtr.Zero;
            IntPtr pRetBytes = IntPtr.Zero;//pointer to int
            UInt32 nInBufSize = 1024 * 1024;
            int nOutBufSize = Marshal.SizeOf(typeName) * objs.Length;
            int nError = 0;

            try
            {
                pInBuf = Marshal.AllocHGlobal((int)nInBufSize);//Allocation of fixed specified the size of the memory space
                for (int i = 0; i < nInBufSize; i++)
                {
                    Marshal.WriteByte(pInBuf, i, 0);
                }

                pOutBuf = Marshal.AllocHGlobal(nOutBufSize);
                for (int index = 0; index < objs.Length; index++)
                {
                    IntPtr pOutBufOfIndex = pOutBuf + index * Marshal.SizeOf(typeName);
                    if (objs[index].GetType() == typeName)                            //if obj is boxinged type of typeName, some param(ex. dwsize) need trans to unmanaged memory
                    {
                        Marshal.StructureToPtr(objs[index], pOutBufOfIndex, true);
                    }
                    else
                    {
                        for (int i = 0; i < Marshal.SizeOf(typeName); i++)
                        {
                            Marshal.WriteByte(pOutBufOfIndex, i, 0);
                        }
                    }
                }

                pRetBytes = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(int)));
                Marshal.WriteInt32(pRetBytes, 0);

                if (pInBuf != IntPtr.Zero && pOutBuf != IntPtr.Zero)
                {
                    returnValue = OriginalSDK.CLIENT_GetNewDevConfig(lLoginID, strCommand, lChannel, pInBuf,
                                                         nInBufSize, out nError, waittime);

                    if (returnValue == true)
                    {
                        returnValue = OriginalSDK.CLIENT_ParseData(strCommand, pInBuf, pOutBuf, (uint)nOutBufSize, pRetBytes);
                        if (returnValue)
                        {
                            int nRetStu = Marshal.ReadInt32(pRetBytes) / Marshal.SizeOf(typeName);
                            objs = new object[nRetStu];
                            for (int i = 0; i < nRetStu; i++)
                            {
                                objs[i] = Marshal.PtrToStructure(IntPtr.Add(pOutBuf, i * Marshal.SizeOf(typeName)), typeName);
                            }
                        }
                    }
                }
            }

            finally
            {
                Marshal.FreeHGlobal(pInBuf);//Release fixed memory allocation
                Marshal.FreeHGlobal(pOutBuf);//Release fixed memory allocation
                Marshal.FreeHGlobal(pRetBytes);
                pInBuf = IntPtr.Zero;
                pOutBuf = IntPtr.Zero;
                pRetBytes = IntPtr.Zero;
            }
            NetGetLastError(returnValue);
            return returnValue;
        }

        /// <summary>
        /// new version--Set the device information for internal use command function
        /// </summary>
        /// <param name="lLoginID">Equipment User LoginID:CLIENT_Login return value</param>
        /// <param name="lChannel">Channel number</param>
        /// <param name="dwCommand">Preparation of command</param>
        /// <param name="obj">objectObject</param>
        /// <param name="typeName">Type Name</param>
        /// <param name="waittime">Wait Time</param>
        /// <returns>true:success;false:failure</returns>
        public static bool SetNewDevConfig(IntPtr lLoginID, int lChannel, string strCommand, object obj, Type typeName, int waittime)
        {
            bool returnValue = false;
            IntPtr pInBuf = IntPtr.Zero;
            IntPtr pOutBuf = IntPtr.Zero;

            UInt32 nBufSize = 1024 * 1024;
            int nRestart = 0;
            int nError = 0;

            try
            {
                pInBuf = Marshal.AllocHGlobal(Marshal.SizeOf(typeName));
                for (int i = 0; i < Marshal.SizeOf(typeName); i++)
                {
                    Marshal.WriteByte(pInBuf, i, 0);
                }
                pOutBuf = Marshal.AllocHGlobal((int)nBufSize);

                for (int i = 0; i < nBufSize; i++)
                {
                    Marshal.WriteByte(pOutBuf, i, 0);
                }

                Marshal.StructureToPtr(obj, pInBuf, true);
                returnValue = OriginalSDK.CLIENT_PacketData(strCommand, pInBuf, (UInt32)Marshal.SizeOf(typeName), pOutBuf, nBufSize);

                if (returnValue)
                {
                    returnValue = OriginalSDK.CLIENT_SetNewDevConfig(lLoginID, strCommand, lChannel, pOutBuf,
                                     nBufSize, ref nError, ref nRestart, waittime);
                }
            }

            finally
            {
                Marshal.FreeHGlobal(pInBuf);//Release fixed memory allocation
                Marshal.FreeHGlobal(pOutBuf);//Release fixed memory allocation
                pInBuf = IntPtr.Zero;
                pOutBuf = IntPtr.Zero;
            }
            NetGetLastError(returnValue);
            return returnValue;
        }

        public static bool PacketData(string szCommand, IntPtr lpInBuffer, uint dwInBufferSize, IntPtr szOutBuffer, uint dwOutFufferSize)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_PacketData(szCommand, lpInBuffer, dwInBufferSize, szOutBuffer, dwOutFufferSize);
            NetGetLastError(result);
            return result;
        }

        public static bool SetNewDevConfigs(IntPtr lLoginID, int lChannel, string strCommand, object[] objs, Type typeName, int waittime)
        {
            bool returnValue = false;
            IntPtr pInBuf = IntPtr.Zero;
            IntPtr pOutBuf = IntPtr.Zero;

            UInt32 nBufSize = (uint)(1024 * 1024 * objs.Length);
            int nRestart = 0;
            int nError = 0;

            try
            {
                pInBuf = Marshal.AllocHGlobal(Marshal.SizeOf(typeName) * objs.Length);
                for (int index = 0; index < objs.Length; index++)
                {
                    IntPtr pInBufTemp = IntPtr.Add(pInBuf, index * Marshal.SizeOf(typeName));
                    for (int i = 0; i < Marshal.SizeOf(typeName); i++)
                    {
                        Marshal.WriteByte(pInBufTemp, i, 0);
                    }
                    Marshal.StructureToPtr(objs[index], pInBufTemp, true);
                }



                pOutBuf = Marshal.AllocHGlobal((int)nBufSize);

                for (int i = 0; i < nBufSize; i++)
                {
                    Marshal.WriteByte(pOutBuf, i, 0);
                }
                returnValue = OriginalSDK.CLIENT_PacketData(strCommand, pInBuf, (UInt32)(Marshal.SizeOf(typeName) * objs.Length), pOutBuf, nBufSize);

                if (returnValue)
                {
                    returnValue = OriginalSDK.CLIENT_SetNewDevConfig(lLoginID, strCommand, lChannel, pOutBuf,
                                     nBufSize, ref nError, ref nRestart, waittime);
                }
            }

            finally
            {
                Marshal.FreeHGlobal(pInBuf);//Release fixed memory allocation
                Marshal.FreeHGlobal(pOutBuf);//Release fixed memory allocation
                pInBuf = IntPtr.Zero;
                pOutBuf = IntPtr.Zero;
            }
            NetGetLastError(returnValue);
            return returnValue;
        }

        public static bool GetOperateConfig(IntPtr lLoginID, EM_CFG_OPERATE_TYPE cfg_type, int lChannel, ref object obj, Type typeName, int waittime)
        {
            bool result = false;
            IntPtr outPtr = IntPtr.Zero;
            try
            {
                outPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeName));
                Marshal.StructureToPtr(obj, outPtr, true);
                result = OriginalSDK.CLIENT_GetConfig(lLoginID, (int)cfg_type, lChannel, outPtr, (uint)Marshal.SizeOf(typeName), waittime, IntPtr.Zero);
                NetGetLastError(result);
                obj = Marshal.PtrToStructure(outPtr, typeName);
            }
            finally
            {
                Marshal.FreeHGlobal(outPtr);
            }
            return result;
        }

        public static bool SetOperateConfig(IntPtr lLoginID, EM_CFG_OPERATE_TYPE cfg_type, int lChannel, object obj, Type typeName, int waittime)
        {
            bool result = false;
            IntPtr inPtr = IntPtr.Zero;
            try
            {
                inPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeName));
                Marshal.StructureToPtr(obj, inPtr, true);
                result = OriginalSDK.CLIENT_SetConfig(lLoginID, (int)cfg_type, lChannel, inPtr, (uint)Marshal.SizeOf(typeName), waittime, IntPtr.Zero, IntPtr.Zero);
                NetGetLastError(result);
            }
            finally
            {
                Marshal.FreeHGlobal(inPtr);
            }
            return result;
        }
        /// <summary>
        /// 考勤机 - 读取设置
        /// </summary>
        /// <param name="lLoginID"></param>
        /// <param name="lChannel"></param>
        /// <param name="obj"></param>
        /// <param name="typeName"></param>
        /// <param name="waittime"></param>
        /// <returns></returns>
        public static bool GetAttendanceConfig(IntPtr lLoginID, int lChannel, ref object obj, Type typeName, int waittime)
        {
            bool result = false;
            IntPtr outPtr = IntPtr.Zero;
            try
            {
                outPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeName));
                Marshal.StructureToPtr(obj, outPtr, true);
                result = OriginalSDK.CLIENT_GetConfig(lLoginID, (int)EM_CFG_OPERATE_TYPE.ACCESSCTL_KEYBINDINGINFOCFG, lChannel, outPtr, (uint)Marshal.SizeOf(typeName), waittime, IntPtr.Zero);
                NetGetLastError(!result);
                obj = Marshal.PtrToStructure(outPtr, typeName);
            }
            finally
            {
                Marshal.FreeHGlobal(outPtr);
            }
            return result;
        }

        /// <summary>
        /// 考勤机 - 设置配置
        /// </summary>
        /// <param name="lLoginID"></param>
        /// <param name="lChannel"></param>
        /// <param name="obj"></param>
        /// <param name="typeName"></param>
        /// <param name="waittime"></param>
        /// <returns></returns>
        public static bool SetAttendanceConfig(IntPtr lLoginID, int lChannel, object obj, Type typeName, int waittime)
        {
            bool result = false;
            IntPtr inPtr = IntPtr.Zero;
            try
            {
                inPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeName));
                Marshal.StructureToPtr(obj, inPtr, true);
                result = OriginalSDK.CLIENT_SetConfig(lLoginID, (int)EM_CFG_OPERATE_TYPE.ACCESSCTL_KEYBINDINGINFOCFG, lChannel, inPtr, (uint)Marshal.SizeOf(typeName), waittime, IntPtr.Zero, IntPtr.Zero);
                NetGetLastError(result);
            }
            finally
            {
                Marshal.FreeHGlobal(inPtr);
            }
            return result;
        }

        #endregion

        #region <<Access Control>>
        /// <summary>
        /// Query device time
        /// </summary>
        /// <param name="lLoginID">CLIENT_Login's return value</param>
        /// <param name="DeviceTime">[out] Device Time</param>
        /// <param name="waittime">Wait timeout, million second</param>
        /// <returns>failed return false, successful return true</returns>
        public static bool QueryDeviceTime(IntPtr lLoginID, ref NET_TIME pDeviceTime, int waittime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_QueryDeviceTime(lLoginID, ref pDeviceTime, waittime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Set device time 
        /// </summary>
        /// <param name="lLoginID">CLIENT_Login's return value</param>
        /// <param name="DeviceTime">deivce time</param>
        /// <returns>failed return false, successful return true</returns>
        public static bool SetupDeviceTime(IntPtr lLoginID, NET_TIME DeviceTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_SetupDeviceTime(lLoginID, ref DeviceTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// remove anti-submarine alarm
        /// </summary>
        /// <param name="lLoginID">CLIENT_Login's return value</param>
        /// <param name="pInParam">remove anti-submarine alarm input parameter</param>
        /// <param name="pOutParam">remove anti-submarine alarm output parameter</param>
        /// <param name="nWaitTime">Wait timeout, million second</param>
        /// <returns>failed return false, successful return true</returns>
        public static bool ClearRepeatEnter(IntPtr lLoginID, ref NET_IN_CLEAR_REPEAT_ENTER pInParam, ref NET_OUT_CLEAR_REPEAT_ENTER pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_ClearRepeatEnter(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool FaceInfoOpreate(IntPtr lLoginID, EM_FACEINFO_OPREATE_TYPE emType, IntPtr pInParam, IntPtr pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_FaceInfoOpreate(lLoginID, emType, pInParam, pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static IntPtr StartFindFaceInfo(IntPtr lLoginID, NET_IN_FACEINFO_START_FIND inParam, ref NET_OUT_FACEINFO_START_FIND outParam, int nWaitTime)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_StartFindFaceInfo(lLoginID, ref inParam, ref outParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool DoFindFaceInfo(IntPtr lFindHandle, NET_IN_FACEINFO_DO_FIND inParam, ref NET_OUT_FACEINFO_DO_FIND outParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_DoFindFaceInfo(lFindHandle, ref inParam, ref outParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool StopFindFaceInfo(IntPtr lFindHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_StopFindFaceInfo(lFindHandle);
            NetGetLastError(result);
            return result;
        }

        #endregion

        #region <<access control V2>>

        public static bool InsertOperateAccessUserService(IntPtr lLoginID, NET_ACCESS_USER_INFO[] stInParam, out NET_EM_FAILCODE[] stOutParam, int nWaitTime)
        {
            bool bRet = false;
            int stuCount = stInParam.Length;
            IntPtr pInBuf = IntPtr.Zero;
            IntPtr pOutBuf = IntPtr.Zero;
            IntPtr pInArrayBuf = IntPtr.Zero;
            IntPtr pOutArrayBuf = IntPtr.Zero;
            NET_IN_ACCESS_USER_SERVICE_INSERT stuInInfo = new NET_IN_ACCESS_USER_SERVICE_INSERT();
            NET_OUT_ACCESS_USER_SERVICE_INSERT stuOutInfo = new NET_OUT_ACCESS_USER_SERVICE_INSERT();

            try
            {
                pInBuf = Marshal.AllocHGlobal(Marshal.SizeOf(stuInInfo));
                pOutBuf = Marshal.AllocHGlobal(Marshal.SizeOf(stuOutInfo));
                pInArrayBuf = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_ACCESS_USER_INFO)) * stuCount);
                pOutArrayBuf = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * stuCount);

                for (int i = 0; i < stuCount; i++)
                {
                    IntPtr pDst = IntPtr.Add(pInArrayBuf, Marshal.SizeOf(typeof(NET_ACCESS_USER_INFO)) * i);
                    Marshal.StructureToPtr(stInParam[i], pDst, true);
                }

                stuInInfo.dwSize = (uint)Marshal.SizeOf(stuInInfo);
                stuInInfo.nInfoNum = stuCount;
                stuInInfo.pUserInfo = pInArrayBuf;

                stuOutInfo.dwSize = (uint)Marshal.SizeOf(stuOutInfo);
                stuOutInfo.nMaxRetNum = stuCount;
                stuOutInfo.pFailCode = pOutArrayBuf;


                Marshal.StructureToPtr(stuInInfo, pInBuf, true);
                Marshal.StructureToPtr(stuOutInfo, pOutBuf, true);
                bRet = OriginalSDK.CLIENT_OperateAccessUserService(lLoginID, EM_ACCESS_CTL_USER_SERVICE.INSERT, pInBuf, pOutBuf, nWaitTime);
                stuOutInfo = (NET_OUT_ACCESS_USER_SERVICE_INSERT)Marshal.PtrToStructure(pOutBuf, typeof(NET_OUT_ACCESS_USER_SERVICE_INSERT));
                stOutParam = new NET_EM_FAILCODE[stuOutInfo.nMaxRetNum];
                for (int i = 0; i < stuOutInfo.nMaxRetNum; i++)
                {
                    IntPtr pDst = IntPtr.Add(pOutArrayBuf, Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * i);
                    stOutParam[i] = (NET_EM_FAILCODE)Marshal.PtrToStructure(pDst, typeof(NET_EM_FAILCODE));
                }

                NetGetLastError(bRet);
                return bRet;
            }
            finally
            {
                Marshal.FreeHGlobal(pInBuf);
                Marshal.FreeHGlobal(pOutBuf);
                Marshal.FreeHGlobal(pInArrayBuf);
                Marshal.FreeHGlobal(pOutArrayBuf);
            }
        }

        public static bool InsertOperateAccessCardService(IntPtr lLoginID, NET_ACCESS_CARD_INFO[] stInParam, out NET_EM_FAILCODE[] stOutParam, int nWaitTime)
        {
            bool bRet = false;
            int stuCount = stInParam.Length;
            IntPtr pInBuf = IntPtr.Zero;
            IntPtr pOutBuf = IntPtr.Zero;
            IntPtr pInArrayBuf = IntPtr.Zero;
            IntPtr pOutArrayBuf = IntPtr.Zero;
            NET_IN_ACCESS_CARD_SERVICE_INSERT stuInInfo = new NET_IN_ACCESS_CARD_SERVICE_INSERT();
            NET_OUT_ACCESS_CARD_SERVICE_INSERT stuOutInfo = new NET_OUT_ACCESS_CARD_SERVICE_INSERT();

            try
            {
                pInBuf = Marshal.AllocHGlobal(Marshal.SizeOf(stuInInfo));
                pOutBuf = Marshal.AllocHGlobal(Marshal.SizeOf(stuOutInfo));
                pInArrayBuf = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_ACCESS_CARD_INFO)) * stuCount);
                pOutArrayBuf = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * stuCount);

                for (int i = 0; i < stuCount; i++)
                {
                    IntPtr pDst = IntPtr.Add(pInArrayBuf, Marshal.SizeOf(typeof(NET_ACCESS_CARD_INFO)) * i);
                    Marshal.StructureToPtr(stInParam[i], pDst, true);
                }

                stuInInfo.dwSize = (uint)Marshal.SizeOf(stuInInfo);
                stuInInfo.nInfoNum = stuCount;
                stuInInfo.pCardInfo = pInArrayBuf;

                stuOutInfo.dwSize = (uint)Marshal.SizeOf(stuOutInfo);
                stuOutInfo.nMaxRetNum = stuCount;
                stuOutInfo.pFailCode = pOutArrayBuf;


                Marshal.StructureToPtr(stuInInfo, pInBuf, true);
                Marshal.StructureToPtr(stuOutInfo, pOutBuf, true);
                bRet = OriginalSDK.CLIENT_OperateAccessCardService(lLoginID, EM_ACCESS_CTL_CARD_SERVICE.INSERT, pInBuf, pOutBuf, nWaitTime);
                stuOutInfo = (NET_OUT_ACCESS_CARD_SERVICE_INSERT)Marshal.PtrToStructure(pOutBuf, typeof(NET_OUT_ACCESS_CARD_SERVICE_INSERT));
                stOutParam = new NET_EM_FAILCODE[stuOutInfo.nMaxRetNum];
                for (int i = 0; i < stuOutInfo.nMaxRetNum; i++)
                {
                    IntPtr pDst = IntPtr.Add(pOutArrayBuf, Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * i);
                    stOutParam[i] = (NET_EM_FAILCODE)Marshal.PtrToStructure(pDst, typeof(NET_EM_FAILCODE));
                }

                NetGetLastError(bRet);
                return bRet;
            }
            finally
            {
                Marshal.FreeHGlobal(pInBuf);
                Marshal.FreeHGlobal(pOutBuf);
                Marshal.FreeHGlobal(pInArrayBuf);
                Marshal.FreeHGlobal(pOutArrayBuf);
            }
        }

        public static bool InsertOperateAccessFingerprintService(IntPtr lLoginID, NET_ACCESS_FINGERPRINT_INFO[] stInParam, out NET_EM_FAILCODE[] stOutParam, int nWaitTime)
        {
            bool bRet = false;
            int stuCount = stInParam.Length;
            IntPtr pInBuf = IntPtr.Zero;
            IntPtr pOutBuf = IntPtr.Zero;
            IntPtr pInArrayBuf = IntPtr.Zero;
            IntPtr pOutArrayBuf = IntPtr.Zero;
            NET_IN_ACCESS_FINGERPRINT_SERVICE_INSERT stuInInfo = new NET_IN_ACCESS_FINGERPRINT_SERVICE_INSERT();
            NET_OUT_ACCESS_FINGERPRINT_SERVICE_INSERT stuOutInfo = new NET_OUT_ACCESS_FINGERPRINT_SERVICE_INSERT();

            try
            {
                pInBuf = Marshal.AllocHGlobal(Marshal.SizeOf(stuInInfo));
                pOutBuf = Marshal.AllocHGlobal(Marshal.SizeOf(stuOutInfo));
                pInArrayBuf = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_ACCESS_FINGERPRINT_INFO)) * stuCount);
                pOutArrayBuf = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * stuCount);

                for (int i = 0; i < stuCount; i++)
                {
                    IntPtr pDst = IntPtr.Add(pInArrayBuf, Marshal.SizeOf(typeof(NET_ACCESS_FINGERPRINT_INFO)) * i);
                    Marshal.StructureToPtr(stInParam[i], pDst, true);
                }

                stuInInfo.dwSize = (uint)Marshal.SizeOf(stuInInfo);
                stuInInfo.nFpNum = stuCount;
                stuInInfo.pFingerPrintInfo = pInArrayBuf;

                stuOutInfo.dwSize = (uint)Marshal.SizeOf(stuOutInfo);
                stuOutInfo.nMaxRetNum = stuCount;
                stuOutInfo.pFailCode = pOutArrayBuf;


                Marshal.StructureToPtr(stuInInfo, pInBuf, true);
                Marshal.StructureToPtr(stuOutInfo, pOutBuf, true);
                bRet = OriginalSDK.CLIENT_OperateAccessFingerprintService(lLoginID, EM_ACCESS_CTL_FINGERPRINT_SERVICE.INSERT, pInBuf, pOutBuf, nWaitTime);
                stuOutInfo = (NET_OUT_ACCESS_FINGERPRINT_SERVICE_INSERT)Marshal.PtrToStructure(pOutBuf, typeof(NET_OUT_ACCESS_FINGERPRINT_SERVICE_INSERT));
                stOutParam = new NET_EM_FAILCODE[stuOutInfo.nMaxRetNum];
                for (int i = 0; i < stuOutInfo.nMaxRetNum; i++)
                {
                    IntPtr pDst = IntPtr.Add(pOutArrayBuf, Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * i);
                    stOutParam[i] = (NET_EM_FAILCODE)Marshal.PtrToStructure(pDst, typeof(NET_EM_FAILCODE));
                }

                NetGetLastError(bRet);
                return bRet;
            }
            finally
            {
                Marshal.FreeHGlobal(pInBuf);
                Marshal.FreeHGlobal(pOutBuf);
                Marshal.FreeHGlobal(pInArrayBuf);
                Marshal.FreeHGlobal(pOutArrayBuf);
            }
        }

        public static bool GetOperateAccessUserService(IntPtr lLoginID, string[] userid, out NET_ACCESS_USER_INFO[] stOutParam1, out NET_EM_FAILCODE[] stOutParam2, int nWaitTime)
        {
            bool bRet = false;
            int stuCount = userid.Length;
            IntPtr pInBuf = IntPtr.Zero;
            IntPtr pOutBuf = IntPtr.Zero;
            IntPtr pOutInfoArrayBuf = IntPtr.Zero;
            IntPtr pOutErrorArrayBuf = IntPtr.Zero;
            NET_IN_ACCESS_USER_SERVICE_GET stuInInfo = new NET_IN_ACCESS_USER_SERVICE_GET();

            NET_OUT_ACCESS_USER_SERVICE_GET stuOutInfo = new NET_OUT_ACCESS_USER_SERVICE_GET();

            try
            {
                pInBuf = Marshal.AllocHGlobal(Marshal.SizeOf(stuInInfo));
                pOutBuf = Marshal.AllocHGlobal(Marshal.SizeOf(stuOutInfo));
                pOutInfoArrayBuf = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_ACCESS_USER_INFO)) * stuCount);
                pOutErrorArrayBuf = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * stuCount);



                stuInInfo.dwSize = (uint)Marshal.SizeOf(stuInInfo);
                stuInInfo.szUserID = new NET_STRING_32_USER_ID[100];
                stuInInfo.nUserNum = stuCount;
                for (int i = 0; i < Math.Min(stuCount, stuInInfo.szUserID.Length); i++)
                {
                    stuInInfo.szUserID[i].szUserID = userid[i];
                }

                stuOutInfo.dwSize = (uint)Marshal.SizeOf(stuOutInfo);
                stuOutInfo.nMaxRetNum = stuCount;
                stuOutInfo.pFailCode = pOutErrorArrayBuf;
                stuOutInfo.pUserInfo = pOutInfoArrayBuf;

                Marshal.StructureToPtr(stuInInfo, pInBuf, true);
                Marshal.StructureToPtr(stuOutInfo, pOutBuf, true);
                bRet = OriginalSDK.CLIENT_OperateAccessUserService(lLoginID, EM_ACCESS_CTL_USER_SERVICE.GET, pInBuf, pOutBuf, nWaitTime);
                stuOutInfo = (NET_OUT_ACCESS_USER_SERVICE_GET)Marshal.PtrToStructure(pOutBuf, typeof(NET_OUT_ACCESS_USER_SERVICE_GET));

                stOutParam1 = new NET_ACCESS_USER_INFO[stuOutInfo.nMaxRetNum];
                for (int i = 0; i < stuCount; i++)
                {
                    IntPtr pDst = IntPtr.Add(pOutInfoArrayBuf, Marshal.SizeOf(typeof(NET_ACCESS_USER_INFO)) * i);
                    stOutParam1[i] = (NET_ACCESS_USER_INFO)Marshal.PtrToStructure(pDst, typeof(NET_ACCESS_USER_INFO));
                }
                stOutParam2 = new NET_EM_FAILCODE[stuOutInfo.nMaxRetNum];
                for (int i = 0; i < stuOutInfo.nMaxRetNum; i++)
                {
                    IntPtr pDst = IntPtr.Add(pOutErrorArrayBuf, Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * i);
                    stOutParam2[i] = (NET_EM_FAILCODE)Marshal.PtrToStructure(pDst, typeof(NET_EM_FAILCODE));
                }

                NetGetLastError(bRet);
                return bRet;
            }
            finally
            {
                Marshal.FreeHGlobal(pInBuf);
                Marshal.FreeHGlobal(pOutBuf);
                Marshal.FreeHGlobal(pOutInfoArrayBuf);
                Marshal.FreeHGlobal(pOutErrorArrayBuf);
            }
        }

        public static bool GetOperateAccessCardService(IntPtr lLoginID, string[] Cardid, out NET_ACCESS_CARD_INFO[] stOutParam1, out NET_EM_FAILCODE[] stOutParam2, int nWaitTime)
        {
            bool bRet = false;
            int stuCount = Cardid.Length;
            IntPtr pInBuf = IntPtr.Zero;
            IntPtr pOutBuf = IntPtr.Zero;
            IntPtr pOutInfoArrayBuf = IntPtr.Zero;
            IntPtr pOutErrorArrayBuf = IntPtr.Zero;
            NET_IN_ACCESS_CARD_SERVICE_GET stuInInfo = new NET_IN_ACCESS_CARD_SERVICE_GET();
            NET_OUT_ACCESS_CARD_SERVICE_GET stuOutInfo = new NET_OUT_ACCESS_CARD_SERVICE_GET();

            try
            {
                pInBuf = Marshal.AllocHGlobal(Marshal.SizeOf(stuInInfo));
                pOutBuf = Marshal.AllocHGlobal(Marshal.SizeOf(stuOutInfo));
                pOutInfoArrayBuf = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_ACCESS_CARD_INFO)) * stuCount);
                pOutErrorArrayBuf = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * stuCount);



                stuInInfo.dwSize = (uint)Marshal.SizeOf(stuInInfo);
                stuInInfo.szCardNo = new NET_STRING_32_CARD_NO[100];
                stuInInfo.nCardNum = stuCount;
                for (int i = 0; i < Math.Min(stuCount, stuInInfo.szCardNo.Length); i++)
                {
                    stuInInfo.szCardNo[i].szCardNo = Cardid[i];
                }

                stuOutInfo.dwSize = (uint)Marshal.SizeOf(stuOutInfo);
                stuOutInfo.nMaxRetNum = stuCount;
                stuOutInfo.pFailCode = pOutErrorArrayBuf;
                stuOutInfo.pCardInfo = pOutInfoArrayBuf;

                Marshal.StructureToPtr(stuInInfo, pInBuf, true);
                Marshal.StructureToPtr(stuOutInfo, pOutBuf, true);
                bRet = OriginalSDK.CLIENT_OperateAccessCardService(lLoginID, EM_ACCESS_CTL_CARD_SERVICE.GET, pInBuf, pOutBuf, nWaitTime);
                stuOutInfo = (NET_OUT_ACCESS_CARD_SERVICE_GET)Marshal.PtrToStructure(pOutBuf, typeof(NET_OUT_ACCESS_CARD_SERVICE_GET));

                stOutParam1 = new NET_ACCESS_CARD_INFO[stuOutInfo.nMaxRetNum];
                for (int i = 0; i < stuCount; i++)
                {
                    IntPtr pDst = IntPtr.Add(pOutInfoArrayBuf, Marshal.SizeOf(typeof(NET_ACCESS_CARD_INFO)) * i);
                    stOutParam1[i] = (NET_ACCESS_CARD_INFO)Marshal.PtrToStructure(pDst, typeof(NET_ACCESS_CARD_INFO));
                }
                stOutParam2 = new NET_EM_FAILCODE[stuOutInfo.nMaxRetNum];
                for (int i = 0; i < stuOutInfo.nMaxRetNum; i++)
                {
                    IntPtr pDst = IntPtr.Add(pOutErrorArrayBuf, Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * i);
                    stOutParam2[i] = (NET_EM_FAILCODE)Marshal.PtrToStructure(pDst, typeof(NET_EM_FAILCODE));
                }

                NetGetLastError(bRet);
                return bRet;
            }
            finally
            {
                Marshal.FreeHGlobal(pInBuf);
                Marshal.FreeHGlobal(pOutBuf);
                Marshal.FreeHGlobal(pOutInfoArrayBuf);
                Marshal.FreeHGlobal(pOutErrorArrayBuf);
            }
        }

        public static bool GetOperateAccessFingerprintService(IntPtr lLoginID, string userid, IntPtr pFingerprintData, int dataLen, out NET_ACCESS_FINGERPRINT_INFO stOutParam1, int nWaitTime)
        {
            bool bRet = false;
            IntPtr pInBuf = IntPtr.Zero;
            IntPtr pOutBuf = IntPtr.Zero;

            NET_IN_ACCESS_FINGERPRINT_SERVICE_GET stuInInfo = new NET_IN_ACCESS_FINGERPRINT_SERVICE_GET();

            NET_OUT_ACCESS_FINGERPRINT_SERVICE_GET stuOutInfo = new NET_OUT_ACCESS_FINGERPRINT_SERVICE_GET();

            try
            {
                pInBuf = Marshal.AllocHGlobal(Marshal.SizeOf(stuInInfo));
                pOutBuf = Marshal.AllocHGlobal(Marshal.SizeOf(stuOutInfo));

                stuInInfo.dwSize = (uint)Marshal.SizeOf(stuInInfo);
                stuInInfo.szUserID = userid;
                stuOutInfo.dwSize = (uint)Marshal.SizeOf(stuOutInfo);
                stuOutInfo.nMaxFingerDataLength = dataLen;
                stuOutInfo.pbyFingerData = pFingerprintData;

                Marshal.StructureToPtr(stuInInfo, pInBuf, true);
                Marshal.StructureToPtr(stuOutInfo, pOutBuf, true);
                bRet = OriginalSDK.CLIENT_OperateAccessFingerprintService(lLoginID, EM_ACCESS_CTL_FINGERPRINT_SERVICE.GET, pInBuf, pOutBuf, nWaitTime);
                stuOutInfo = (NET_OUT_ACCESS_FINGERPRINT_SERVICE_GET)Marshal.PtrToStructure(pOutBuf, typeof(NET_OUT_ACCESS_FINGERPRINT_SERVICE_GET));
                stOutParam1 = new NET_ACCESS_FINGERPRINT_INFO();
                stOutParam1.szUserID = userid;
                stOutParam1.nDuressIndex = stuOutInfo.nDuressIndex;
                stOutParam1.nPacketLen = stuOutInfo.nSinglePacketLength;
                stOutParam1.nPacketNum = stuOutInfo.nRetFingerPrintCount;
                stOutParam1.szFingerPrintInfo = stuOutInfo.pbyFingerData;

                return bRet;
            }
            finally
            {
                Marshal.FreeHGlobal(pInBuf);
                Marshal.FreeHGlobal(pOutBuf);
            }

        }

        public static bool RemoveOperateAccessUserService(IntPtr lLoginID, string[] userid, out NET_EM_FAILCODE[] stOutParam, int nWaitTime)
        {
            bool bRet = false;
            int stuCount = userid.Length;
            IntPtr pInBuf = IntPtr.Zero;
            IntPtr pOutBuf = IntPtr.Zero;
            IntPtr pOutArrayBuf = IntPtr.Zero;
            NET_IN_ACCESS_USER_SERVICE_REMOVE stuInInfo = new NET_IN_ACCESS_USER_SERVICE_REMOVE();
            NET_OUT_ACCESS_USER_SERVICE_REMOVE stuOutInfo = new NET_OUT_ACCESS_USER_SERVICE_REMOVE();

            try
            {
                pInBuf = Marshal.AllocHGlobal(Marshal.SizeOf(stuInInfo));
                pOutBuf = Marshal.AllocHGlobal(Marshal.SizeOf(stuOutInfo));
                pOutArrayBuf = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * stuCount);

                stuInInfo.dwSize = (uint)Marshal.SizeOf(stuInInfo);
                stuInInfo.szUserID = new NET_STRING_32_USER_ID[100];
                stuInInfo.nUserNum = stuCount;
                for (int i = 0; i < Math.Min(stuCount, stuInInfo.szUserID.Length); i++)
                {
                    stuInInfo.szUserID[i].szUserID = userid[i];
                }

                stuOutInfo.dwSize = (uint)Marshal.SizeOf(stuOutInfo);
                stuOutInfo.nMaxRetNum = stuCount;
                stuOutInfo.pFailCode = pOutArrayBuf;


                Marshal.StructureToPtr(stuInInfo, pInBuf, true);
                Marshal.StructureToPtr(stuOutInfo, pOutBuf, true);
                bRet = OriginalSDK.CLIENT_OperateAccessUserService(lLoginID, EM_ACCESS_CTL_USER_SERVICE.REMOVE, pInBuf, pOutBuf, nWaitTime);
                stuOutInfo = (NET_OUT_ACCESS_USER_SERVICE_REMOVE)Marshal.PtrToStructure(pOutBuf, typeof(NET_OUT_ACCESS_USER_SERVICE_REMOVE));
                stOutParam = new NET_EM_FAILCODE[stuOutInfo.nMaxRetNum];
                for (int i = 0; i < stuOutInfo.nMaxRetNum; i++)
                {
                    IntPtr pDst = IntPtr.Add(pOutArrayBuf, Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * i);
                    stOutParam[i] = (NET_EM_FAILCODE)Marshal.PtrToStructure(pDst, typeof(NET_EM_FAILCODE));
                }

                NetGetLastError(bRet);
                return bRet;
            }
            finally
            {
                Marshal.FreeHGlobal(pInBuf);
                Marshal.FreeHGlobal(pOutBuf);
                Marshal.FreeHGlobal(pOutArrayBuf);
            }
        }

        public static bool RemoveOperateAccessCardService(IntPtr lLoginID, string[] Cardid, out NET_EM_FAILCODE[] stOutParam, int nWaitTime)
        {
            bool bRet = false;
            int stuCount = Cardid.Length;
            IntPtr pInBuf = IntPtr.Zero;
            IntPtr pOutBuf = IntPtr.Zero;
            IntPtr pOutArrayBuf = IntPtr.Zero;
            NET_IN_ACCESS_CARD_SERVICE_REMOVE stuInInfo = new NET_IN_ACCESS_CARD_SERVICE_REMOVE();
            NET_OUT_ACCESS_CARD_SERVICE_REMOVE stuOutInfo = new NET_OUT_ACCESS_CARD_SERVICE_REMOVE();

            try
            {
                pInBuf = Marshal.AllocHGlobal(Marshal.SizeOf(stuInInfo));
                pOutBuf = Marshal.AllocHGlobal(Marshal.SizeOf(stuOutInfo));
                pOutArrayBuf = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * stuCount);

                stuInInfo.dwSize = (uint)Marshal.SizeOf(stuInInfo);
                stuInInfo.szCardNo = new NET_STRING_32_CARD_NO[100];
                stuInInfo.nCardNum = stuCount;
                for (int i = 0; i < Math.Min(stuCount, stuInInfo.szCardNo.Length); i++)
                {
                    stuInInfo.szCardNo[i].szCardNo = Cardid[i];
                }

                stuOutInfo.dwSize = (uint)Marshal.SizeOf(stuOutInfo);
                stuOutInfo.nMaxRetNum = stuCount;
                stuOutInfo.pFailCode = pOutArrayBuf;


                Marshal.StructureToPtr(stuInInfo, pInBuf, true);
                Marshal.StructureToPtr(stuOutInfo, pOutBuf, true);
                bRet = OriginalSDK.CLIENT_OperateAccessCardService(lLoginID, EM_ACCESS_CTL_CARD_SERVICE.REMOVE, pInBuf, pOutBuf, nWaitTime);
                stuOutInfo = (NET_OUT_ACCESS_CARD_SERVICE_REMOVE)Marshal.PtrToStructure(pOutBuf, typeof(NET_OUT_ACCESS_CARD_SERVICE_REMOVE));
                stOutParam = new NET_EM_FAILCODE[stuOutInfo.nMaxRetNum];
                for (int i = 0; i < stuOutInfo.nMaxRetNum; i++)
                {
                    IntPtr pDst = IntPtr.Add(pOutArrayBuf, Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * i);
                    stOutParam[i] = (NET_EM_FAILCODE)Marshal.PtrToStructure(pDst, typeof(NET_EM_FAILCODE));
                }

                NetGetLastError(bRet);
                return bRet;
            }
            finally
            {
                Marshal.FreeHGlobal(pInBuf);
                Marshal.FreeHGlobal(pOutBuf);
                Marshal.FreeHGlobal(pOutArrayBuf);
            }
        }

        public static bool RemoveOperateAccessFingerprintService(IntPtr lLoginID, string[] userid, out NET_EM_FAILCODE[] stOutParam, int nWaitTime)
        {
            bool bRet = false;
            int stuCount = userid.Length;
            IntPtr pInBuf = IntPtr.Zero;
            IntPtr pOutBuf = IntPtr.Zero;
            IntPtr pOutArrayBuf = IntPtr.Zero;
            NET_IN_ACCESS_FINGERPRINT_SERVICE_REMOVE stuInInfo = new NET_IN_ACCESS_FINGERPRINT_SERVICE_REMOVE();
            NET_OUT_ACCESS_FINGERPRINT_SERVICE_REMOVE stuOutInfo = new NET_OUT_ACCESS_FINGERPRINT_SERVICE_REMOVE();

            try
            {
                pInBuf = Marshal.AllocHGlobal(Marshal.SizeOf(stuInInfo));
                pOutBuf = Marshal.AllocHGlobal(Marshal.SizeOf(stuOutInfo));
                pOutArrayBuf = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * stuCount);

                stuInInfo.dwSize = (uint)Marshal.SizeOf(stuInInfo);
                stuInInfo.szUserID = new NET_STRING_32_USER_ID[100];
                stuInInfo.nUserNum = stuCount;
                for (int i = 0; i < Math.Min(stuCount, stuInInfo.szUserID.Length); i++)
                {
                    stuInInfo.szUserID[i].szUserID = userid[i];
                }

                stuOutInfo.dwSize = (uint)Marshal.SizeOf(stuOutInfo);
                stuOutInfo.nMaxRetNum = stuCount;
                stuOutInfo.pFailCode = pOutArrayBuf;


                Marshal.StructureToPtr(stuInInfo, pInBuf, true);
                Marshal.StructureToPtr(stuOutInfo, pOutBuf, true);
                bRet = OriginalSDK.CLIENT_OperateAccessFingerprintService(lLoginID, EM_ACCESS_CTL_FINGERPRINT_SERVICE.REMOVE, pInBuf, pOutBuf, nWaitTime);
                stuOutInfo = (NET_OUT_ACCESS_FINGERPRINT_SERVICE_REMOVE)Marshal.PtrToStructure(pOutBuf, typeof(NET_OUT_ACCESS_FINGERPRINT_SERVICE_REMOVE));
                stOutParam = new NET_EM_FAILCODE[stuOutInfo.nMaxRetNum];
                for (int i = 0; i < stuOutInfo.nMaxRetNum; i++)
                {
                    IntPtr pDst = IntPtr.Add(pOutArrayBuf, Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * i);
                    stOutParam[i] = (NET_EM_FAILCODE)Marshal.PtrToStructure(pDst, typeof(NET_EM_FAILCODE));
                }

                NetGetLastError(bRet);
                return bRet;
            }
            finally
            {
                Marshal.FreeHGlobal(pInBuf);
                Marshal.FreeHGlobal(pOutBuf);
                Marshal.FreeHGlobal(pOutArrayBuf);
            }
        }

        public static bool ClearOperateAccessUserService(IntPtr lLoginID, int nWaitTime)
        {
            bool bRet = false;
            IntPtr pInBuf = IntPtr.Zero;
            IntPtr pOutBuf = IntPtr.Zero;
            NET_IN_ACCESS_USER_SERVICE_CLEAR stuInInfo = new NET_IN_ACCESS_USER_SERVICE_CLEAR();
            NET_OUT_ACCESS_USER_SERVICE_CLEAR stuOutInfo = new NET_OUT_ACCESS_USER_SERVICE_CLEAR();

            try
            {
                pInBuf = Marshal.AllocHGlobal(Marshal.SizeOf(stuInInfo));
                pOutBuf = Marshal.AllocHGlobal(Marshal.SizeOf(stuOutInfo));


                stuInInfo.dwSize = (uint)Marshal.SizeOf(stuInInfo);
                stuOutInfo.dwSize = (uint)Marshal.SizeOf(stuOutInfo);


                Marshal.StructureToPtr(stuInInfo, pInBuf, true);
                Marshal.StructureToPtr(stuOutInfo, pOutBuf, true);
                bRet = OriginalSDK.CLIENT_OperateAccessUserService(lLoginID, EM_ACCESS_CTL_USER_SERVICE.CLEAR, pInBuf, pOutBuf, nWaitTime);

                NetGetLastError(bRet);
                return bRet;
            }
            finally
            {
                Marshal.FreeHGlobal(pInBuf);
                Marshal.FreeHGlobal(pOutBuf);
            }
        }

        public static bool ClearOperateAccessCardService(IntPtr lLoginID, int nWaitTime)
        {
            bool bRet = false;
            IntPtr pInBuf = IntPtr.Zero;
            IntPtr pOutBuf = IntPtr.Zero;
            NET_IN_ACCESS_CARD_SERVICE_CLEAR stuInInfo = new NET_IN_ACCESS_CARD_SERVICE_CLEAR();
            NET_OUT_ACCESS_CARD_SERVICE_CLEAR stuOutInfo = new NET_OUT_ACCESS_CARD_SERVICE_CLEAR();

            try
            {
                pInBuf = Marshal.AllocHGlobal(Marshal.SizeOf(stuInInfo));
                pOutBuf = Marshal.AllocHGlobal(Marshal.SizeOf(stuOutInfo));


                stuInInfo.dwSize = (uint)Marshal.SizeOf(stuInInfo);
                stuOutInfo.dwSize = (uint)Marshal.SizeOf(stuOutInfo);


                Marshal.StructureToPtr(stuInInfo, pInBuf, true);
                Marshal.StructureToPtr(stuOutInfo, pOutBuf, true);
                bRet = OriginalSDK.CLIENT_OperateAccessCardService(lLoginID, EM_ACCESS_CTL_CARD_SERVICE.CLEAR, pInBuf, pOutBuf, nWaitTime);

                NetGetLastError(bRet);
                return bRet;
            }
            finally
            {
                Marshal.FreeHGlobal(pInBuf);
                Marshal.FreeHGlobal(pOutBuf);
            }
        }

        public static bool ClearOperateAccessFingerprintService(IntPtr lLoginID, int nWaitTime)
        {
            bool bRet = false;
            IntPtr pInBuf = IntPtr.Zero;
            IntPtr pOutBuf = IntPtr.Zero;
            NET_IN_ACCESS_FINGERPRINT_SERVICE_CLEAR stuInInfo = new NET_IN_ACCESS_FINGERPRINT_SERVICE_CLEAR();
            NET_OUT_ACCESS_FINGERPRINT_SERVICE_CLEAR stuOutInfo = new NET_OUT_ACCESS_FINGERPRINT_SERVICE_CLEAR();

            try
            {
                pInBuf = Marshal.AllocHGlobal(Marshal.SizeOf(stuInInfo));
                pOutBuf = Marshal.AllocHGlobal(Marshal.SizeOf(stuOutInfo));


                stuInInfo.dwSize = (uint)Marshal.SizeOf(stuInInfo);
                stuOutInfo.dwSize = (uint)Marshal.SizeOf(stuOutInfo);


                Marshal.StructureToPtr(stuInInfo, pInBuf, true);
                Marshal.StructureToPtr(stuOutInfo, pOutBuf, true);
                bRet = OriginalSDK.CLIENT_OperateAccessFingerprintService(lLoginID, EM_ACCESS_CTL_FINGERPRINT_SERVICE.CLEAR, pInBuf, pOutBuf, nWaitTime);

                NetGetLastError(bRet);
                return bRet;
            }
            finally
            {
                Marshal.FreeHGlobal(pInBuf);
                Marshal.FreeHGlobal(pOutBuf);
            }
        }

        public static bool UpdateOperateAccessCardService(IntPtr lLoginID, NET_ACCESS_CARD_INFO[] stInParam, out NET_EM_FAILCODE[] stOutParam, int nWaitTime)
        {
            bool bRet = false;
            int stuCount = stInParam.Length;
            IntPtr pInBuf = IntPtr.Zero;
            IntPtr pOutBuf = IntPtr.Zero;
            IntPtr pInArrayBuf = IntPtr.Zero;
            IntPtr pOutArrayBuf = IntPtr.Zero;
            NET_IN_ACCESS_CARD_SERVICE_UPDATE stuInInfo = new NET_IN_ACCESS_CARD_SERVICE_UPDATE();
            NET_OUT_ACCESS_CARD_SERVICE_UPDATE stuOutInfo = new NET_OUT_ACCESS_CARD_SERVICE_UPDATE();

            try
            {
                pInBuf = Marshal.AllocHGlobal(Marshal.SizeOf(stuInInfo));
                pOutBuf = Marshal.AllocHGlobal(Marshal.SizeOf(stuOutInfo));
                pInArrayBuf = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_ACCESS_CARD_INFO)) * stuCount);
                pOutArrayBuf = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * stuCount);

                for (int i = 0; i < stuCount; i++)
                {
                    IntPtr pDst = IntPtr.Add(pInArrayBuf, Marshal.SizeOf(typeof(NET_ACCESS_CARD_INFO)) * i);
                    Marshal.StructureToPtr(stInParam[i], pDst, true);
                }

                stuInInfo.dwSize = (uint)Marshal.SizeOf(stuInInfo);
                stuInInfo.nInfoNum = stuCount;
                stuInInfo.pCardInfo = pInArrayBuf;

                stuOutInfo.dwSize = (uint)Marshal.SizeOf(stuOutInfo);
                stuOutInfo.nMaxRetNum = stuCount;
                stuOutInfo.pFailCode = pOutArrayBuf;


                Marshal.StructureToPtr(stuInInfo, pInBuf, true);
                Marshal.StructureToPtr(stuOutInfo, pOutBuf, true);
                bRet = OriginalSDK.CLIENT_OperateAccessCardService(lLoginID, EM_ACCESS_CTL_CARD_SERVICE.UPDATE, pInBuf, pOutBuf, nWaitTime);
                stuOutInfo = (NET_OUT_ACCESS_CARD_SERVICE_UPDATE)Marshal.PtrToStructure(pOutBuf, typeof(NET_OUT_ACCESS_CARD_SERVICE_UPDATE));
                stOutParam = new NET_EM_FAILCODE[stuOutInfo.nMaxRetNum];
                for (int i = 0; i < stuOutInfo.nMaxRetNum; i++)
                {
                    IntPtr pDst = IntPtr.Add(pOutArrayBuf, Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * i);
                    stOutParam[i] = (NET_EM_FAILCODE)Marshal.PtrToStructure(pDst, typeof(NET_EM_FAILCODE));
                }

                NetGetLastError(bRet);
                return bRet;
            }
            finally
            {
                Marshal.FreeHGlobal(pInBuf);
                Marshal.FreeHGlobal(pOutBuf);
                Marshal.FreeHGlobal(pInArrayBuf);
                Marshal.FreeHGlobal(pOutArrayBuf);
            }
        }

        public static bool UpdateOperateAccessFingerprintService(IntPtr lLoginID, NET_ACCESS_FINGERPRINT_INFO[] stInParam, out NET_EM_FAILCODE[] stOutParam, int nWaitTime)
        {
            bool bRet = false;
            int stuCount = stInParam.Length;
            IntPtr pInBuf = IntPtr.Zero;
            IntPtr pOutBuf = IntPtr.Zero;
            IntPtr pInArrayBuf = IntPtr.Zero;
            IntPtr pOutArrayBuf = IntPtr.Zero;
            NET_IN_ACCESS_FINGERPRINT_SERVICE_UPDATE stuInInfo = new NET_IN_ACCESS_FINGERPRINT_SERVICE_UPDATE();
            NET_OUT_ACCESS_FINGERPRINT_SERVICE_UPDATE stuOutInfo = new NET_OUT_ACCESS_FINGERPRINT_SERVICE_UPDATE();

            try
            {
                pInBuf = Marshal.AllocHGlobal(Marshal.SizeOf(stuInInfo));
                pOutBuf = Marshal.AllocHGlobal(Marshal.SizeOf(stuOutInfo));
                pInArrayBuf = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_ACCESS_FINGERPRINT_INFO)) * stuCount);
                pOutArrayBuf = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * stuCount);

                for (int i = 0; i < stuCount; i++)
                {
                    IntPtr pDst = IntPtr.Add(pInArrayBuf, Marshal.SizeOf(typeof(NET_ACCESS_FINGERPRINT_INFO)) * i);
                    Marshal.StructureToPtr(stInParam[i], pDst, true);
                }

                stuInInfo.dwSize = (uint)Marshal.SizeOf(stuInInfo);
                stuInInfo.nFpNum = stuCount;
                stuInInfo.pFingerPrintInfo = pInArrayBuf;

                stuOutInfo.dwSize = (uint)Marshal.SizeOf(stuOutInfo);
                stuOutInfo.nMaxRetNum = stuCount;
                stuOutInfo.pFailCode = pOutArrayBuf;


                Marshal.StructureToPtr(stuInInfo, pInBuf, true);
                Marshal.StructureToPtr(stuOutInfo, pOutBuf, true);
                bRet = OriginalSDK.CLIENT_OperateAccessFingerprintService(lLoginID, EM_ACCESS_CTL_FINGERPRINT_SERVICE.UPDATE, pInBuf, pOutBuf, nWaitTime);
                stuOutInfo = (NET_OUT_ACCESS_FINGERPRINT_SERVICE_UPDATE)Marshal.PtrToStructure(pOutBuf, typeof(NET_OUT_ACCESS_FINGERPRINT_SERVICE_UPDATE));
                stOutParam = new NET_EM_FAILCODE[stuOutInfo.nMaxRetNum];
                for (int i = 0; i < stuOutInfo.nMaxRetNum; i++)
                {
                    IntPtr pDst = IntPtr.Add(pOutArrayBuf, Marshal.SizeOf(typeof(NET_EM_FAILCODE)) * i);
                    stOutParam[i] = (NET_EM_FAILCODE)Marshal.PtrToStructure(pDst, typeof(NET_EM_FAILCODE));
                }

                NetGetLastError(bRet);
                return bRet;
            }
            finally
            {
                Marshal.FreeHGlobal(pInBuf);
                Marshal.FreeHGlobal(pOutBuf);
                Marshal.FreeHGlobal(pInArrayBuf);
                Marshal.FreeHGlobal(pOutArrayBuf);
            }
        }


        #endregion //access control

        #region <<Face Module>>
        public static bool OperateFaceRecognitionDB(IntPtr lLoginID, ref NET_IN_OPERATE_FACERECONGNITIONDB pstInParam, ref NET_OUT_OPERATE_FACERECONGNITIONDB pstOutParam, Int32 nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_OperateFaceRecognitionDB(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Search according to the condition
        /// </summary>
        /// <param name="lLoginID">CLIENT_Login's return value</param>
        /// <param name="emType">find type</param>
        /// <param name="oQueryCondition">search condition</param>
        /// <param name="tyCondition">type of condition struct</param>
        /// <param name="lFindID"></param>
        /// <param name="waittime">Wait timeout, million second</param>
        /// <returns>lFindeHandle</returns>
        public static IntPtr FindFile(IntPtr lLoginID, EM_FILE_QUERY_TYPE emType, object oQueryCondition, Type tyCondition, int waittime)
        {
            IntPtr result = IntPtr.Zero;
            IntPtr pCondition = IntPtr.Zero;
            try
            {
                if (oQueryCondition == null || tyCondition == null)
                {
                    pCondition = IntPtr.Zero;
                }
                else
                {
                    int nBufLen = Marshal.SizeOf(tyCondition);
                    int n1 = Marshal.SizeOf(oQueryCondition);
                    pCondition = Marshal.AllocHGlobal(nBufLen);
                    Marshal.StructureToPtr(oQueryCondition, pCondition, true);
                }
                result = OriginalSDK.CLIENT_FindFileEx(lLoginID, emType, pCondition, IntPtr.Zero, waittime);
                NetGetLastError(result);
            }
            finally
            {
                Marshal.FreeHGlobal(pCondition);
            }
            return result;
        }

        public static int FindNextFile(IntPtr lFindHandle, int nFilecount, List<object> lsOMediaFileInfo, Type tyFile, int waittime)
        {

            int result = 0;
            IntPtr pMediaFileInfo = IntPtr.Zero;
            int singleBufLen = Marshal.SizeOf(tyFile);
            int maxBufLen = singleBufLen * nFilecount;

            try
            {
                pMediaFileInfo = Marshal.AllocHGlobal(maxBufLen);
                for (int i = 0; i < nFilecount; i++)
                {
                    Marshal.StructureToPtr(lsOMediaFileInfo[i], IntPtr.Add(pMediaFileInfo, i * singleBufLen), true);
                }
                result = OriginalSDK.CLIENT_FindNextFileEx(lFindHandle, nFilecount, pMediaFileInfo, maxBufLen, IntPtr.Zero, waittime);
                if (result >= 0)
                {
                    for (int i = 0; i < result; i++)
                    {
                        lsOMediaFileInfo[i] = Marshal.PtrToStructure(IntPtr.Add(pMediaFileInfo, i * singleBufLen), tyFile);
                    }
                }
                else
                {
                    NetGetLastError(result);
                }
            }
            finally
            {
                Marshal.FreeHGlobal(pMediaFileInfo);
            }
            return result;
        }

        public static bool FindClose(IntPtr lFindHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_FindCloseEx(lFindHandle);
            NetGetLastError(result);
            return result;
        }

        public static bool DetectFace(IntPtr lLoginID, ref NET_IN_DETECT_FACE pstInParam, ref NET_OUT_DETECT_FACE pstOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_DetectFace(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);

            NetGetLastError(result);
            return result;
        }

        public static IntPtr AttachFaceFindState(IntPtr lLoginID, ref NET_IN_FACE_FIND_STATE pstInParam, ref NET_OUT_FACE_FIND_STATE pstOutParam, Int32 nWaitTime)
        {
            IntPtr nHanddle = IntPtr.Zero;
            nHanddle = OriginalSDK.CLIENT_AttachFaceFindState(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
            NetGetLastError(nHanddle);
            return nHanddle;
        }

        public static bool DetachFaceFindState(IntPtr lAttachHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_DetachFaceFindState(lAttachHandle);
            NetGetLastError(result);
            return result;
        }

        public static bool StartFindFaceRecognition(IntPtr lLoginID, ref NET_IN_STARTFIND_FACERECONGNITION pstInParam, ref NET_OUT_STARTFIND_FACERECONGNITION pstOutParam, int waittime)
        {
            bool result = false;
            IntPtr inPtr = IntPtr.Zero;
            IntPtr outPtr = IntPtr.Zero;
            try
            {
                inPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_IN_STARTFIND_FACERECONGNITION)));
                Marshal.StructureToPtr(pstInParam, inPtr, true);
                outPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_OUT_STARTFIND_FACERECONGNITION)));
                Marshal.StructureToPtr(pstOutParam, outPtr, true);
                result = OriginalSDK.CLIENT_StartFindFaceRecognition(lLoginID, inPtr, outPtr, waittime);
                NetGetLastError(result);
                if (result)
                {
                    pstOutParam = (NET_OUT_STARTFIND_FACERECONGNITION)Marshal.PtrToStructure(outPtr, typeof(NET_OUT_STARTFIND_FACERECONGNITION));
                }
            }
            finally
            {
                Marshal.FreeHGlobal(inPtr);
                Marshal.FreeHGlobal(outPtr);
            }
            return result;
        }

        public static bool StartMultiFindFaceRecognition(IntPtr lLoginID, ref NET_IN_STARTMULTIFIND_FACERECONGNITION pstInParam, ref NET_OUT_STARTMULTIFIND_FACERECONGNITION pstOutParam, int waittime)
        {
            bool result = false;
            IntPtr inPtr = IntPtr.Zero;
            IntPtr outPtr = IntPtr.Zero;
            try
            {
                inPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_IN_STARTMULTIFIND_FACERECONGNITION)));
                Marshal.StructureToPtr(pstInParam, inPtr, true);
                outPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_OUT_STARTMULTIFIND_FACERECONGNITION)));
                Marshal.StructureToPtr(pstOutParam, outPtr, true);
                result = OriginalSDK.CLIENT_StartMultiFindFaceRecognition(lLoginID, inPtr, outPtr, waittime);
                NetGetLastError(result);
                if (result)
                {
                    pstOutParam = (NET_OUT_STARTMULTIFIND_FACERECONGNITION)Marshal.PtrToStructure(outPtr, typeof(NET_OUT_STARTMULTIFIND_FACERECONGNITION));
                }
            }
            finally
            {
                Marshal.FreeHGlobal(inPtr);
                Marshal.FreeHGlobal(outPtr);
            }
            return result;
        }

        public static bool DoFindFaceRecognition(ref NET_IN_DOFIND_FACERECONGNITION pstInParam, ref NET_OUT_DOFIND_FACERECONGNITION pstOutParam,
            int waittime)
        {
            bool result = false;
            IntPtr inPtr = IntPtr.Zero;
            IntPtr outPtr = IntPtr.Zero;
            try
            {
                inPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_IN_DOFIND_FACERECONGNITION)));
                Marshal.StructureToPtr(pstInParam, inPtr, true);
                outPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_OUT_DOFIND_FACERECONGNITION)));
                Marshal.StructureToPtr(pstOutParam, outPtr, true);
                result = OriginalSDK.CLIENT_DoFindFaceRecognition(inPtr, outPtr, waittime);
                NetGetLastError(result);
                if (result)
                {
                    pstOutParam = (NET_OUT_DOFIND_FACERECONGNITION)Marshal.PtrToStructure(outPtr, typeof(NET_OUT_DOFIND_FACERECONGNITION));
                }
            }
            finally
            {
                Marshal.FreeHGlobal(inPtr);
                Marshal.FreeHGlobal(outPtr);
            }
            return result;
        }

        public static bool StopFindFaceRecognition(IntPtr lFindHandle)
        {
            bool result = OriginalSDK.CLIENT_StopFindFaceRecognition(lFindHandle);
            NetGetLastError(result);
            return result;
        }

        public static bool DoFindFaceRecognitionRecordEx(NET_IN_DOFIND_FACERECONGNITIONRECORD_EX inParam, ref NET_OUT_DOFIND_FACERECONGNITIONRECORD_EX outParam, int nWaitTime)
        {
            bool result = OriginalSDK.CLIENT_DoFindFaceRecognitionRecordEx(ref inParam, ref outParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool FaceRecognitionPutDisposition(IntPtr lLoginID, NET_IN_FACE_RECOGNITION_PUT_DISPOSITION_INFO inParam, ref NET_OUT_FACE_RECOGNITION_PUT_DISPOSITION_INFO outParam, int nWaitTime)
        {
            bool result = false;
            IntPtr inPtr = IntPtr.Zero;
            IntPtr outPtr = IntPtr.Zero;
            try
            {
                inPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_IN_FACE_RECOGNITION_PUT_DISPOSITION_INFO)));
                Marshal.StructureToPtr(inParam, inPtr, true);
                outPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_OUT_FACE_RECOGNITION_PUT_DISPOSITION_INFO)));
                Marshal.StructureToPtr(outParam, outPtr, true);
                result = OriginalSDK.CLIENT_FaceRecognitionPutDisposition(lLoginID, inPtr, outPtr, nWaitTime);
                NetGetLastError(result);
                if (result)
                {
                    outParam = (NET_OUT_FACE_RECOGNITION_PUT_DISPOSITION_INFO)Marshal.PtrToStructure(outPtr, typeof(NET_OUT_FACE_RECOGNITION_PUT_DISPOSITION_INFO));
                }
            }
            finally
            {
                Marshal.FreeHGlobal(inPtr);
                Marshal.FreeHGlobal(outPtr);
            }
            return result;
        }

        public static bool FaceRecognitionDelDisposition(IntPtr lLoginID, NET_IN_FACE_RECOGNITION_DEL_DISPOSITION_INFO inParam, ref NET_OUT_FACE_RECOGNITION_DEL_DISPOSITION_INFO outParam, int nWaitTime)
        {
            bool result = OriginalSDK.CLIENT_FaceRecognitionDelDisposition(lLoginID, ref inParam, ref outParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool GetTotalFileCount(IntPtr lFindHandle, ref Int32 pTotalCount, IntPtr pReserved, Int32 nWaittime)
        {
            bool bReturn = false;
            bReturn = OriginalSDK.CLIENT_GetTotalFileCount(lFindHandle, ref pTotalCount, pReserved, nWaittime);
            NetGetLastError(bReturn);
            return bReturn;
        }

        public static bool SetFindingJumpOption(IntPtr lFindHandle, ref NET_FINDING_JUMP_OPTION_INFO pOption, IntPtr reserved, int waittime)
        {
            bool bReturn = false;
            bReturn = OriginalSDK.CLIENT_SetFindingJumpOption(lFindHandle, ref pOption, reserved, waittime);
            NetGetLastError(bReturn);
            return bReturn;
        }

        public static bool FindGroupInfo(IntPtr lLoginID, ref NET_IN_FIND_GROUP_INFO pstInParam, ref NET_OUT_FIND_GROUP_INFO pstOutParam, int nWaitTime)
        {
            bool bReturn = false;
            bReturn = OriginalSDK.CLIENT_FindGroupInfo(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
            NetGetLastError(bReturn);
            return bReturn;
        }

        public static bool OperateFaceRecognitionGroup(IntPtr lLoginID, ref NET_IN_OPERATE_FACERECONGNITION_GROUP pstInParam, ref NET_OUT_OPERATE_FACERECONGNITION_GROUP pstOutParam, int nWaitTime)
        {
            bool bReturn = false;
            bReturn = OriginalSDK.CLIENT_OperateFaceRecognitionGroup(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
            NetGetLastError(bReturn);
            return bReturn;
        }

        public static bool RenderPrivateData(IntPtr lPlayHandle, bool bTrue)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_RenderPrivateData(lPlayHandle, bTrue);
            NetGetLastError(result);
            return result;
        }
        #endregion

        #region Query device info
        /// <summary>
        /// query device info(storage device info)
        /// 查询设备信息(存储设备信息)
        /// </summary>
        /// <param name="lLoginID">CLIENT_Login's return value 登陆ID</param>
        /// <param name="stuInInfo">in param 输入参数</param>
        /// <param name="stuOutInfo">out param 输出参数</param>
        /// <param name="nWaitTime">Wait timeout, million second 等待时间</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool QueryDevInfo(IntPtr lLoginID, ref NET_IN_STORAGE_DEV_INFOS stuInInfo, ref NET_OUT_STORAGE_DEV_INFOS stuOutInfo, int nWaitTime)
        {
            bool bRet = false;
            IntPtr pInBuf = IntPtr.Zero;
            IntPtr pOutBuf = IntPtr.Zero;
            try
            {
                pInBuf = Marshal.AllocHGlobal(Marshal.SizeOf(stuInInfo));
                pOutBuf = Marshal.AllocHGlobal(Marshal.SizeOf(stuOutInfo));
                Marshal.StructureToPtr(stuInInfo, pInBuf, true);
                Marshal.StructureToPtr(stuOutInfo, pOutBuf, true);
                bRet = OriginalSDK.CLIENT_QueryDevInfo(lLoginID, 0x02, pInBuf, pOutBuf, IntPtr.Zero, nWaitTime);
                if (bRet)
                {
                    stuOutInfo = (NET_OUT_STORAGE_DEV_INFOS)Marshal.PtrToStructure(pOutBuf, typeof(NET_OUT_STORAGE_DEV_INFOS));
                }
                NetGetLastError(bRet);
                return bRet;
            }
            finally
            {
                Marshal.FreeHGlobal(pInBuf);
                Marshal.FreeHGlobal(pOutBuf);
            }
        }

        #endregion //Query device info

        /// <summary>
        /// Get OSD Config
        /// 获取OSD配置
        /// </summary>
        /// <param name="lLoginID">Lonin return value 登陆ID</param>
        /// <param name="emCfgOpType">config type 配置类型</param>
        /// <param name="nChannelID">channel id 通道号</param>
        /// <param name="obj">config struct 配置结构体</param>
        /// <param name="waittime">waittime 等待时间</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool GetOSDConfig(IntPtr lLoginID, EM_CFG_OSD_TYPE emCfgOpType, int nChannelID, ref object obj, int waittime)
        {
            bool result = false;
            Type type = obj.GetType();
            IntPtr outPtr = IntPtr.Zero;
            try
            {
                outPtr = Marshal.AllocHGlobal(Marshal.SizeOf(type));
                Marshal.StructureToPtr(obj, outPtr, true);
                result = OriginalSDK.CLIENT_GetConfig(lLoginID, (int)emCfgOpType, nChannelID, outPtr, (uint)Marshal.SizeOf(type), waittime, IntPtr.Zero);
                NetGetLastError(result);
                obj = Marshal.PtrToStructure(outPtr, type);
            }
            finally
            {
                Marshal.FreeHGlobal(outPtr);
            }
            return result;
        }

        /// <summary>
        /// Set OSD config
        /// 设置OSD配置
        /// </summary>
        /// <param name="lLoginID">Lonin return value 登陆ID</param>
        /// <param name="emCfgOpType">config type 配置类型</param>
        /// <param name="nChannelID">channel id 通道号</param>
        /// <param name="obj">config struct 配置结构体</param>
        /// <param name="waittime">waittime 等待时间</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool SetOSDConfig(IntPtr lLoginID, EM_CFG_OSD_TYPE emCfgOpType, int nChannelID, object obj, int waittime)
        {
            bool result = false;
            Type type = obj.GetType();
            IntPtr inPtr = IntPtr.Zero;
            try
            {
                inPtr = Marshal.AllocHGlobal(Marshal.SizeOf(type));
                Marshal.StructureToPtr(obj, inPtr, true);
                result = OriginalSDK.CLIENT_SetConfig(lLoginID, (int)emCfgOpType, nChannelID, inPtr, (uint)Marshal.SizeOf(type), waittime, IntPtr.Zero, IntPtr.Zero);
                NetGetLastError(result);
            }
            finally
            {
                Marshal.FreeHGlobal(inPtr);
            }
            return result;
        }


        /// <summary>
        /// Get Encode Config
        /// 获取编码配置
        /// </summary>
        /// <param name="lLoginID">Lonin return value 登陆ID</param>
        /// <param name="emCfgOpType">config type 配置类型</param>
        /// <param name="nChannelID">channel id 通道号</param>
        /// <param name="obj">config struct 配置结构体</param>
        /// <param name="waittime">waittime 等待时间</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool GetEncodeConfig(IntPtr lLoginID, EM_CFG_ENCODE_TYPE emCfgOpType, int nChannelID, ref object obj, int waittime)
        {
            bool result = false;
            Type type = obj.GetType();
            IntPtr outPtr = IntPtr.Zero;
            try
            {
                outPtr = Marshal.AllocHGlobal(Marshal.SizeOf(type));
                Marshal.StructureToPtr(obj, outPtr, true);
                result = OriginalSDK.CLIENT_GetConfig(lLoginID, (int)emCfgOpType, nChannelID, outPtr, (uint)Marshal.SizeOf(type), waittime, IntPtr.Zero);
                NetGetLastError(result);
                obj = Marshal.PtrToStructure(outPtr, type);
            }
            finally
            {
                Marshal.FreeHGlobal(outPtr);
            }
            return result;
        }

        /// <summary>
        /// Set Encode config
        /// 设置编码配置
        /// </summary>
        /// <param name="lLoginID">Lonin return value 登陆ID</param>
        /// <param name="emCfgOpType">config type 配置类型</param>
        /// <param name="nChannelID">channel id 通道号</param>
        /// <param name="obj">config struct 配置结构体</param>
        /// <param name="waittime">waittime 等待时间</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool SetEncodeConfig(IntPtr lLoginID, EM_CFG_ENCODE_TYPE emCfgOpType, int nChannelID, object obj, int waittime)
        {
            bool result = false;
            Type type = obj.GetType();
            IntPtr inPtr = IntPtr.Zero;
            try
            {
                inPtr = Marshal.AllocHGlobal(Marshal.SizeOf(type));
                Marshal.StructureToPtr(obj, inPtr, true);
                result = OriginalSDK.CLIENT_SetConfig(lLoginID, (int)emCfgOpType, nChannelID, inPtr, (uint)Marshal.SizeOf(type), waittime, IntPtr.Zero, IntPtr.Zero);
                NetGetLastError(result);
            }
            finally
            {
                Marshal.FreeHGlobal(inPtr);
            }
            return result;
        }

        public static bool SetTrafficVoiceBroadcast(IntPtr lLoginID, NET_CFG_TRAFFIC_VOICE_BROADCAST_INFO info, int waittime)
        {
            bool result = false;
            Type type = info.GetType();
            IntPtr inPtr = IntPtr.Zero;
            try
            {
                inPtr = Marshal.AllocHGlobal(Marshal.SizeOf(type));
                Marshal.StructureToPtr(info, inPtr, true);
                result = OriginalSDK.CLIENT_SetConfig(lLoginID, (int)10001, -1, inPtr, (uint)Marshal.SizeOf(type), waittime, IntPtr.Zero, IntPtr.Zero);
                NetGetLastError(result);
            }
            finally
            {
                Marshal.FreeHGlobal(inPtr);
            }
            return result;
        }
        public static bool GetTrafficVoiceBroadcast(IntPtr lLoginID, ref NET_CFG_TRAFFIC_VOICE_BROADCAST_INFO info, int waittime)
        {
            bool result = false;
            Type type = info.GetType();
            IntPtr outPtr = IntPtr.Zero;
            try
            {
                outPtr = Marshal.AllocHGlobal(Marshal.SizeOf(type));
                Marshal.StructureToPtr(info, outPtr, true);
                result = OriginalSDK.CLIENT_GetConfig(lLoginID, (int)10001, -1, outPtr, (uint)Marshal.SizeOf(type), waittime, IntPtr.Zero);
                NetGetLastError(result);
                info = (NET_CFG_TRAFFIC_VOICE_BROADCAST_INFO)Marshal.PtrToStructure(outPtr, type);
            }
            finally
            {
                Marshal.FreeHGlobal(outPtr);
            }
            return result;
        }

        public static bool SetTrafficLatticeScreen(IntPtr lLoginID, NET_CFG_TRAFFIC_LATTICE_SCREEN_INFO info, int waittime)
        {
            bool result = false;
            Type type = info.GetType();
            IntPtr inPtr = IntPtr.Zero;
            try
            {
                inPtr = Marshal.AllocHGlobal(Marshal.SizeOf(type));
                Marshal.StructureToPtr(info, inPtr, true);
                result = OriginalSDK.CLIENT_SetConfig(lLoginID, (int)10000, -1, inPtr, (uint)Marshal.SizeOf(type), waittime, IntPtr.Zero, IntPtr.Zero);
                NetGetLastError(result);
            }
            finally
            {
                Marshal.FreeHGlobal(inPtr);
            }
            return result;
        }
        public static bool GetTrafficLatticeScreen(IntPtr lLoginID, ref NET_CFG_TRAFFIC_LATTICE_SCREEN_INFO info, int waittime)
        {
            bool result = false;
            Type type = info.GetType();
            IntPtr outPtr = IntPtr.Zero;
            try
            {
                outPtr = Marshal.AllocHGlobal(Marshal.SizeOf(type));
                Marshal.StructureToPtr(info, outPtr, true);
                result = OriginalSDK.CLIENT_GetConfig(lLoginID, (int)10000, -1, outPtr, (uint)Marshal.SizeOf(type), waittime, IntPtr.Zero);
                NetGetLastError(result);
                info = (NET_CFG_TRAFFIC_LATTICE_SCREEN_INFO)Marshal.PtrToStructure(outPtr, type);
            }
            finally
            {
                Marshal.FreeHGlobal(outPtr);
            }
            return result;
        }

        public static bool SetSpecialDaysScheduleConfig(IntPtr lLoginID, NET_CFG_ACCESSCTL_SPECIALDAY_GROUP_INFO info, int waittime)
        {
            bool result = false;
            Type type = info.GetType();
            IntPtr inPtr = IntPtr.Zero;
            try
            {
                inPtr = Marshal.AllocHGlobal(Marshal.SizeOf(type));
                Marshal.StructureToPtr(info, inPtr, true);
                result = OriginalSDK.CLIENT_SetConfig(lLoginID, (int)3902, -1, inPtr, (uint)Marshal.SizeOf(type), waittime, IntPtr.Zero, IntPtr.Zero);
                NetGetLastError(result);
            }
            finally
            {
                Marshal.FreeHGlobal(inPtr);
            }
            return result;
        }
        public static bool GetSpecialDaysScheduleConfig(IntPtr lLoginID, ref object[] objs, Type typeName, int waittime)
        {
            bool result = false;
            IntPtr outPtr = IntPtr.Zero;
            try
            {
                int nOutBufSize = Marshal.SizeOf(typeName) * objs.Length;
                outPtr = Marshal.AllocHGlobal(nOutBufSize);
                result = OriginalSDK.CLIENT_GetConfig(lLoginID, (int)3902, -1, outPtr, (uint)nOutBufSize, waittime, IntPtr.Zero);
                NetGetLastError(result);
                for (int i = 0; i < objs.Length; ++i)
                {
                    objs[i] = Marshal.PtrToStructure(IntPtr.Add(outPtr, i * Marshal.SizeOf(typeName)), typeName);
                }

            }
            finally
            {
                Marshal.FreeHGlobal(outPtr);
            }
            return result;
        }

        public static bool GetSplitWindowsInfo(IntPtr lLoginID, object inParam, ref object outParam, int nWaitTime)
        {
            bool result = false;
            IntPtr inPtr = IntPtr.Zero;
            IntPtr outPtr = IntPtr.Zero;
            try
            {
                inPtr = Marshal.AllocHGlobal(Marshal.SizeOf(inParam.GetType()));
                Marshal.StructureToPtr(inParam, inPtr, true);
                outPtr = Marshal.AllocHGlobal(Marshal.SizeOf(outParam.GetType()));
                Marshal.StructureToPtr(outParam, outPtr, true);
                result = OriginalSDK.CLIENT_GetSplitWindowsInfo(lLoginID, inPtr, outPtr, nWaitTime);
                NetGetLastError(result);
                if (result)
                {
                    outParam = Marshal.PtrToStructure(outPtr, outParam.GetType());
                }
            }
            finally
            {
                Marshal.FreeHGlobal(inPtr);
                Marshal.FreeHGlobal(outPtr);
            }
            return result;
        }

        public static bool OperateSplit(IntPtr lLoginID, EM_NET_SPLIT_OPERATE_TYPE emType, object inParam, ref object outParam, int nWaitTime)
        {
            bool result = false;
            IntPtr inPtr = IntPtr.Zero;
            IntPtr outPtr = IntPtr.Zero;
            try
            {
                inPtr = Marshal.AllocHGlobal(Marshal.SizeOf(inParam.GetType()));
                Marshal.StructureToPtr(inParam, inPtr, true);
                outPtr = Marshal.AllocHGlobal(Marshal.SizeOf(outParam.GetType()));
                Marshal.StructureToPtr(outParam, outPtr, true);
                result = OriginalSDK.CLIENT_OperateSplit(lLoginID, emType, inPtr, outPtr, nWaitTime);
                NetGetLastError(result);
                if (result)
                {
                    outParam = Marshal.PtrToStructure(outPtr, outParam.GetType());
                }
            }
            finally
            {
                Marshal.FreeHGlobal(inPtr);
                Marshal.FreeHGlobal(outPtr);
            }
            return result;
        }

        public static bool OperateSplitPlayer(IntPtr lLoginID, EM_NET_PLAYER_OPERATE_TYPE emType, object inParam, ref object outParam, int nWaitTime)
        {
            bool result = false;
            IntPtr inPtr = IntPtr.Zero;
            IntPtr outPtr = IntPtr.Zero;
            try
            {
                inPtr = Marshal.AllocHGlobal(Marshal.SizeOf(inParam.GetType()));
                Marshal.StructureToPtr(inParam, inPtr, true);
                outPtr = Marshal.AllocHGlobal(Marshal.SizeOf(outParam.GetType()));
                Marshal.StructureToPtr(outParam, outPtr, true);
                result = OriginalSDK.CLIENT_OperateSplitPlayer(lLoginID, emType, inPtr, outPtr, nWaitTime);
                NetGetLastError(result);
                if (result)
                {
                    outParam = Marshal.PtrToStructure(outPtr, outParam.GetType());
                }
            }
            finally
            {
                Marshal.FreeHGlobal(inPtr);
                Marshal.FreeHGlobal(outPtr);
            }
            return result;
        }

        public static bool WindowRegionEnlarge(IntPtr lLoginID, NET_IN_WINDOW_REGION_ENLARGE inParam, ref NET_OUT_WINDOW_REGION_ENLARGE outParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_WindowRegionEnlarge(lLoginID, ref inParam, ref outParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool WindowEnlargeReduction(IntPtr lLoginID, NET_IN_WINDOW_ENLARGE_REDUCTION inParam, ref NET_OUT_WINDOW_ENLARGE_REDUCTION outParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_WindowEnlargeReduction(lLoginID, ref inParam, ref outParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool OperateTrafficList(IntPtr lLoginID, NET_IN_OPERATE_TRAFFIC_LIST_RECORD inParam, ref NET_OUT_OPERATE_TRAFFIC_LIST_RECORD outParam, int waittime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_OperateTrafficList(lLoginID, ref inParam, ref outParam, waittime);
            NetGetLastError(result);
            return result;
        }

        public static IntPtr FileTransmit(IntPtr lLoginID, EM_FIELTRANSMIT_TYPE nTransType, object obj, fTransFileCallBack cbTransFile, IntPtr dwUserData, int waittime)
        {
            IntPtr result = IntPtr.Zero;
            IntPtr bufPtr = IntPtr.Zero;
            try
            {
                bufPtr = Marshal.AllocHGlobal(Marshal.SizeOf(obj.GetType()));
                Marshal.StructureToPtr(obj, bufPtr, true);
                result = OriginalSDK.CLIENT_FileTransmit(lLoginID, (int)nTransType, bufPtr, Marshal.SizeOf(obj.GetType()), cbTransFile, dwUserData, waittime);
                NetGetLastError(result);
            }
            finally
            {
                Marshal.FreeHGlobal(bufPtr);
            }
            return result;
        }

        public static bool QueryUserInfoNew(IntPtr lLoginID, ref NET_USER_MANAGE_INFO_NEW info, int waittime)
        {
            bool result = false;
            IntPtr inPtr = Marshal.AllocHGlobal((int)info.dwSize);
            Marshal.StructureToPtr(info, inPtr, true);
            result = OriginalSDK.CLIENT_QueryUserInfoNew(lLoginID, inPtr, IntPtr.Zero, waittime);
            NetGetLastError(result);
            if (result)
            {
                info = (NET_USER_MANAGE_INFO_NEW)Marshal.PtrToStructure(inPtr, typeof(NET_USER_MANAGE_INFO_NEW));
            }
            Marshal.FreeHGlobal(inPtr);
            return result;
        }

        public static bool OperateUserInfoNew(IntPtr lLoginID, EM_OPERATE_USER_TYPE nOperateType, IntPtr opParam, IntPtr subParam, int waittime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_OperateUserInfoNew(lLoginID, (int)nOperateType, opParam, subParam, IntPtr.Zero, waittime);
            NetGetLastError(result);
            return result;
        }

        public static IntPtr StartSearchDevice(fSearchDevicesCB cbSearchDevice, IntPtr pUserData, IntPtr szLocalIp)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_StartSearchDevices(cbSearchDevice, pUserData, szLocalIp);
            NetGetLastError(result);
            return result;
        }

        public static bool ModifyDevice(DEVICE_NET_INFO_EX devNetInfo, uint dwWaitTime)
        {
            bool result = false;
            int error = 0;
            result = OriginalSDK.CLIENT_ModifyDevice(ref devNetInfo, dwWaitTime, ref error, null, IntPtr.Zero);
            NetGetLastError(result);
            return result;
        }

        public static bool StopSearchDevice(IntPtr lSearchHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_StopSearchDevices(lSearchHandle);
            NetGetLastError(result);
            return result;
        }

        public static bool DownloadRemoteFile(IntPtr lLoginID, ref NET_IN_DOWNLOAD_REMOTE_FILE inParam, ref NET_OUT_DOWNLOAD_REMOTE_FILE outParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_DownloadRemoteFile(lLoginID, ref inParam, ref outParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool GetDevEncodeCaps(IntPtr lLoginID, NET_IN_ENCODE_CFG_CAPS stuInParam, ref NET_OUT_ENCODE_CFG_CAPS stuOutParam, int nWaitTime)
        {
            bool result = false;
            NET_INTERNAL_IN_ENCODE_CAPS stuIn = new NET_INTERNAL_IN_ENCODE_CAPS
            {
                dwSize = (uint)Marshal.SizeOf(typeof(NET_INTERNAL_IN_ENCODE_CAPS)),
                stuInEncodeCaps = stuInParam,
            };
            NET_INTERNAL_OUT_ENCODE_CAPS stuOut = new NET_INTERNAL_OUT_ENCODE_CAPS
            {
                dwSize = (uint)Marshal.SizeOf(typeof(NET_INTERNAL_OUT_ENCODE_CAPS)),
                stuOutEncodeCaps = stuOutParam,
            };
            int size = Marshal.SizeOf(typeof(NET_INTERNAL_OUT_ENCODE_CAPS));
            for (int i = 0; i < 3; i++)
            {
                stuOut.stuOutEncodeCaps.stuMainFormatCaps[i].dwSize = (uint)Marshal.SizeOf(typeof(NET_STREAM_CFG_CAPS));
                stuOut.stuOutEncodeCaps.stuExtraFormatCaps[i].dwSize = (uint)Marshal.SizeOf(typeof(NET_STREAM_CFG_CAPS));
                if (i != 2)
                {
                    stuOut.stuOutEncodeCaps.stuSnapFormatCaps[i].dwSize = (uint)Marshal.SizeOf(typeof(NET_STREAM_CFG_CAPS));
                }
            }

            uint nBufSize = 1024 * 1024;
            string strCommand = "Encode";
            IntPtr pInBuf = IntPtr.Zero;
            int nError = 0;
            try
            {
                stuIn.pchEncodeJson = Marshal.AllocHGlobal((int)nBufSize);
            }
            catch (OutOfMemoryException)
            {
                result = false;
                return result;
            }

            result = OriginalSDK.CLIENT_GetNewDevConfig(lLoginID, strCommand, stuInParam.nChannelId, stuIn.pchEncodeJson,
                                                         nBufSize, out nError, nWaitTime);
            if (result)
            {
                IntPtr intPtr = IntPtr.Zero;
                IntPtr outPtr = IntPtr.Zero;
                try
                {
                    intPtr = Marshal.AllocHGlobal((int)stuIn.dwSize);
                    outPtr = Marshal.AllocHGlobal((int)stuOut.dwSize);
                }
                catch (OutOfMemoryException)
                {
                    Marshal.FreeHGlobal(stuIn.pchEncodeJson);
                    result = false;
                    return result;
                }

                Marshal.StructureToPtr(stuIn, intPtr, true);
                Marshal.StructureToPtr(stuOut, outPtr, true);
                result = OriginalSDK.CLIENT_GetDevCaps(lLoginID, 0x02, intPtr, outPtr, nWaitTime);
                if (result)
                {
                    stuOut = (NET_INTERNAL_OUT_ENCODE_CAPS)Marshal.PtrToStructure(outPtr, typeof(NET_INTERNAL_OUT_ENCODE_CAPS));
                    stuOutParam = stuOut.stuOutEncodeCaps;
                }
                else
                {
                    NetGetLastError(result);
                }

                Marshal.FreeHGlobal(intPtr);
                Marshal.FreeHGlobal(outPtr);
            }
            Marshal.FreeHGlobal(stuIn.pchEncodeJson);
            return result;
        }

        public static bool QueryChannelName(IntPtr lLoginID, IntPtr pChannelName, int maxlen, ref int nChannelCount, int waittime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_QueryChannelName(lLoginID, pChannelName, maxlen, ref nChannelCount, waittime);
            NetGetLastError(result);
            return result;
        }

        public static bool SetDeviceSearchParam(NET_DEVICE_SEARCH_PARAM inParam)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_SetDeviceSearchParam(ref inParam);
            NetGetLastError(result);
            return result;
        }

        public static bool GetDevConfig(IntPtr lLoginID, EM_DEV_CFG_TYPE type, int lChannel, IntPtr lpOutBuffer, uint dwOutBufferSize, ref uint bytesReturned, int waittime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_GetDevConfig(lLoginID, (uint)type, lChannel, lpOutBuffer, dwOutBufferSize, ref bytesReturned, waittime);
            NetGetLastError(result);
            return result;
        }

        public static bool SetDevConfig(IntPtr lLoginID, EM_DEV_CFG_TYPE type, int lChannel, IntPtr lpInBuffer, uint dwInBufferSize, int waittime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_SetDevConfig(lLoginID, (uint)type, lChannel, lpInBuffer, dwInBufferSize, waittime);
            NetGetLastError(result);
            return result;
        }

        public static IntPtr DownloadByRecordFile(IntPtr lLoginID, ref NET_RECORDFILE_INFO lpRecordFile, string sSavedFileName, fDownLoadPosCallBack cbDownLoadPos, IntPtr dwUserData)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_DownloadByRecordFile(lLoginID, ref lpRecordFile, sSavedFileName, cbDownLoadPos, dwUserData);
            NetGetLastError(result);
            return result;
        }

        public static bool RebootDev(IntPtr lLoginID)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_RebootDev(lLoginID);
            NetGetLastError(result);
            return result;
        }

        public static bool Attendance_AddUser(IntPtr lLoginID, NET_IN_ATTENDANCE_ADDUSER stuInAddUser, ref NET_OUT_ATTENDANCE_ADDUSER stuOutAddUser, int nWaitTime)
        {
            bool result = false;

            result = OriginalSDK.CLIENT_Attendance_AddUser(lLoginID, ref stuInAddUser, ref stuOutAddUser, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool Attendance_DelUser(IntPtr lLoginID, NET_IN_ATTENDANCE_DELUSER stuInDelUser, ref NET_OUT_ATTENDANCE_DELUSER stuOutDelUser, int nWaitTime)
        {
            bool result = false;

            result = OriginalSDK.CLIENT_Attendance_DelUser(lLoginID, ref stuInDelUser, ref stuOutDelUser, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool Attendance_ModifyUser(IntPtr lLoginID, NET_IN_ATTENDANCE_ModifyUSER stuInModifyUser, ref NET_OUT_ATTENDANCE_ModifyUSER stuOutModifyUser, int nWaitTime)
        {
            bool result = false;

            result = OriginalSDK.CLIENT_Attendance_ModifyUser(lLoginID, ref stuInModifyUser, ref stuOutModifyUser, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool Attendance_GetUser(IntPtr lLoginID, NET_IN_ATTENDANCE_GetUSER stuInGetUser, ref NET_OUT_ATTENDANCE_GetUSER stuOutGetUser, int nWaitTime)
        {
            bool result = false;

            result = OriginalSDK.CLIENT_Attendance_GetUser(lLoginID, ref stuInGetUser, ref stuOutGetUser, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool Attendance_FindUser(IntPtr lLoginID, NET_IN_ATTENDANCE_FINDUSER stuInFindUser, ref NET_OUT_ATTENDANCE_FINDUSER stuOutFindUser, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_Attendance_FindUser(lLoginID, ref stuInFindUser, ref stuOutFindUser, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool Attendance_InsertFingerByUserID(IntPtr lLoginID, ref NET_IN_FINGERPRINT_INSERT_BY_USERID stuInInsert, ref NET_OUT_FINGERPRINT_INSERT_BY_USERID stuOutInsert, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_Attendance_InsertFingerByUserID(lLoginID, ref stuInInsert, ref stuOutInsert, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool Attendance_RemoveFingerByUserID(IntPtr lLoginID, ref NET_CTRL_IN_FINGERPRINT_REMOVE_BY_USERID stuInRemove, ref NET_CTRL_OUT_FINGERPRINT_REMOVE_BY_USERID stuOutRemove, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_Attendance_RemoveFingerByUserID(lLoginID, ref stuInRemove, ref stuOutRemove, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool Attendance_GetFingerByUserID(IntPtr lLoginID, ref NET_IN_FINGERPRINT_GETBYUSER stuIn, ref NET_OUT_FINGERPRINT_GETBYUSER stuOut, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_Attendance_GetFingerByUserID(lLoginID, ref stuIn, ref stuOut, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static IntPtr AttachMotionData(IntPtr lLoginID, NET_IN_ATTACH_MOTION_DATA inParam, int nWaitTime)
        {
            IntPtr result = IntPtr.Zero;
            NET_OUT_ATTACH_MOTION_DATA outParam = new NET_OUT_ATTACH_MOTION_DATA();
            outParam.dwSize = (uint)Marshal.SizeOf(typeof(NET_OUT_ATTACH_MOTION_DATA));
            result = OriginalSDK.CLIENT_AttachMotionData(lLoginID, ref inParam, ref outParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool DetachMotionData(IntPtr lAttachHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_DetachMotionData(lAttachHandle);
            NetGetLastError(result);
            return result;
        }

        public static bool SearchDevicesByIPs(NET_DEVICE_IP_SEARCH_INFO pIpSearchInfo, fSearchDevicesCB cbSearchDevices, IntPtr dwUserData, string szLocalIp, uint dwWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_SearchDevicesByIPs(ref pIpSearchInfo, cbSearchDevices, dwUserData, szLocalIp, dwWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool InitDevAccount(NET_IN_INIT_DEVICE_ACCOUNT pInitAccountIn, ref NET_OUT_INIT_DEVICE_ACCOUNT pInitAccountOut, uint dwWaitTime, string szLocalIp)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_InitDevAccount(ref pInitAccountIn, ref pInitAccountOut, dwWaitTime, szLocalIp);
            NetGetLastError(result);
            return result;
        }

        public static bool GetDevCaps(IntPtr lLoginID, EM_DEVCAP_TYPE nType, IntPtr pInBuf, IntPtr pOutBuf, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_GetDevCaps(lLoginID, (int)nType, pInBuf, pOutBuf, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static IntPtr ListenServer(string ip, ushort port, int nTimeout, fServiceCallBack cbListen, IntPtr dwUserData)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_ListenServer(ip, port, nTimeout, cbListen, dwUserData);
            NetGetLastError(result);
            return result;
        }

        public static bool StopListenServer(IntPtr lServerHandle)
        {
            bool result = OriginalSDK.CLIENT_StopListenServer(lServerHandle);
            NetGetLastError(result);
            return result;
        }

        public static bool QueryProductionDefinition(IntPtr lLoginID, ref NET_PRODUCTION_DEFNITION pstuProdDef, int nWaitTime)
        {
            bool result = OriginalSDK.CLIENT_QueryProductionDefinition(lLoginID, ref pstuProdDef, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool QueryDevInfo(IntPtr lLoginID, EM_QUERY_DEV_INFO emQueryType, IntPtr pInBuf, IntPtr pOutBuf, int nWaitTime = 1000)
        {
            bool result = OriginalSDK.CLIENT_QueryDevInfo(lLoginID, (int)emQueryType, pInBuf, pOutBuf, IntPtr.Zero, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static IntPtr AttachCameraState(IntPtr lLoginID, NET_IN_CAMERASTATE pstInParam, ref NET_OUT_CAMERASTATE pstOutParam, int nWaitTime = 3000)
        {
            IntPtr lAttachHandle = IntPtr.Zero;
            lAttachHandle = OriginalSDK.CLIENT_AttachCameraState(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
            NetGetLastError(lAttachHandle);
            return lAttachHandle;
        }

        public static bool DetachCameraState(IntPtr lAttachHandle)
        {
            bool result = OriginalSDK.CLIENT_DetachCameraState(lAttachHandle);
            NetGetLastError(result);
            return result;
        }

        public static bool GetSoftwareVersion(IntPtr lLoginID, NET_IN_GET_SOFTWAREVERSION_INFO pstInParam, ref NET_OUT_GET_SOFTWAREVERSION_INFO pstOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_GetSoftwareVersion(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool GetDeviceType(IntPtr lLoginID, NET_IN_GET_DEVICETYPE_INFO pstInParam, ref NET_OUT_GET_DEVICETYPE_INFO pstOutParam, int nWaitTime)
        {
            bool result = OriginalSDK.CLIENT_GetDeviceType(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool LogOpen(NET_LOG_SET_PRINT_INFO pstLogPrintInfo)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_LogOpen(ref pstLogPrintInfo);
            NetGetLastError(result);
            return result;
        }

        public static bool AudioDecEx(IntPtr lTalkHandle, IntPtr pAudioDataBuf, uint dwBufSize)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_AudioDecEx(lTalkHandle, pAudioDataBuf, dwBufSize);
            NetGetLastError(result);
            return result;
        }

        public static bool Attendance_GetFingerRecord(IntPtr lLoginID, ref NET_CTRL_IN_FINGERPRINT_GET pstuInGet, ref NET_CTRL_OUT_FINGERPRINT_GET pstuOutGet, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_Attendance_GetFingerRecord(lLoginID, ref pstuInGet, ref pstuOutGet, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool Attendance_RemoveFingerRecord(IntPtr lLoginID, ref NET_CTRL_IN_FINGERPRINT_REMOVE pstuInRemove, ref NET_CTRL_OUT_FINGERPRINT_REMOVE pstuOutRemove, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_Attendance_RemoveFingerRecord(lLoginID, ref pstuInRemove, ref pstuOutRemove, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool OperateAccessFingerprintService(IntPtr lLoginID, EM_ACCESS_CTL_FINGERPRINT_SERVICE emtype, IntPtr pstInParam, IntPtr pstOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_OperateAccessFingerprintService(lLoginID, emtype, pstInParam, pstOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool OperateAccessControlManager(IntPtr lLoginID, NET_EM_ACCESS_CTL_MANAGER emtype, IntPtr pstInParam, IntPtr pstOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_OperateAccessControlManager(lLoginID, emtype, pstInParam, pstInParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool EncryptString(NET_IN_ENCRYPT_STRING pInParam, ref NET_OUT_ENCRYPT_STRING pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_EncryptString(ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);

            return result;
        }

        public static IntPtr DownloadMediaFile(IntPtr lLoginID, EM_FILE_QUERY_TYPE emType, IntPtr lpMediaFileInfo, string sSavedFileName, fDownLoadPosCallBack cbDownLoadPos, IntPtr dwUserData, IntPtr reserved)
        {
            IntPtr result = IntPtr.Zero;
            IntPtr file_name = Marshal.StringToHGlobalAnsi(sSavedFileName);
            result = OriginalSDK.CLIENT_DownloadMediaFile(lLoginID, emType, lpMediaFileInfo, file_name, cbDownLoadPos, dwUserData, reserved);
            Marshal.FreeHGlobal(file_name);
            NetGetLastError(result);
            return result;
        }

        public static bool StopDownloadMediaFile(IntPtr lFileHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_StopDownloadMediaFile(lFileHandle);
            NetGetLastError(result);
            return result;
        }

        public static IntPtr SCADAAlarmAttachInfo(IntPtr lLoginID, NET_IN_SCADA_ALARM_ATTACH_INFO pInParam, NET_OUT_SCADA_ALARM_ATTACH_INFO pOutParam, int nWaitTime = 3000)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_SCADAAlarmAttachInfo(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool SCADAAlarmDetachInfo(IntPtr lAttachHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_SCADAAlarmDetachInfo(lAttachHandle);
            NetGetLastError(result);
            return result;
        }

        public static IntPtr SCADAAttachInfo(IntPtr lLoginID, NET_IN_SCADA_ATTACH_INFO pInParam, NET_OUT_SCADA_ATTACH_INFO pOutParam, int nWaitTime)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_SCADAAttachInfo(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool SCADADetachInfo(IntPtr lAttachHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_SCADADetachInfo(lAttachHandle);
            NetGetLastError(result);
            return result;
        }

        public static IntPtr AttachPTZStatusProc(IntPtr lLoginID, NET_IN_PTZ_STATUS_PROC pstuInPtzStatusProc, ref NET_OUT_PTZ_STATUS_PROC pstuOutPtzStatusProc, int nWaitTime = 3000)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_AttachPTZStatusProc(lLoginID, ref pstuInPtzStatusProc, ref pstuOutPtzStatusProc, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool DetachPTZStatusProc(IntPtr lAttachHandle)
        {
            bool result = true;
            result = OriginalSDK.CLIENT_DetachPTZStatusProc(lAttachHandle);
            NetGetLastError(result);
            return result;
        }

        public static bool StartFind(IntPtr lLoginID, EM_FIND emType, IntPtr pInBuf, IntPtr pOutBuf, int nWaitTime = 1000)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_StartFind(lLoginID, emType, pInBuf, pOutBuf, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool DoFind(IntPtr lLoginID, EM_FIND emType, IntPtr pInBuf, IntPtr pOutBuf, int nWaitTime = 1000)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_DoFind(lLoginID, emType, pInBuf, pOutBuf, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool StopFind(IntPtr lLoginID, EM_FIND emType, IntPtr pInBuf, IntPtr pOutBuf, int nWaitTime = 1000)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_StopFind(lLoginID, emType, pInBuf, pOutBuf, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static IntPtr RadiometryAttach(IntPtr lLoginID, NET_IN_RADIOMETRY_ATTACH pInParam, ref NET_OUT_RADIOMETRY_ATTACH pOutParam, int nWaitTime)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_RadiometryAttach(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool RadiometryDetach(IntPtr lAttachHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_RadiometryDetach(lAttachHandle);
            NetGetLastError(result);
            return result;
        }

        public static bool RadiometryFetch(IntPtr lLoginID, NET_IN_RADIOMETRY_FETCH pInParam, ref NET_OUT_RADIOMETRY_FETCH pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_RadiometryFetch(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// RealPlay By Stream Data Type  指定回调数据类型 实施预览(预览)
        /// </summary>
        /// <param name="lLoginID">user LoginID:Login's return value 登陆ID，Login返回值</param>
        /// <param name="pstInParam">real play  parameter in 预览输入参数</param>
        /// <param name="pstOutParam">real play  parameter out 预览输出参数</param>
        /// <param name="dwWaitTime">Waiting Time 等待时间</param>
        /// <returns>failed return 0, successful return the realplay ID(realplay handle),as parameter of related function. 失败返回0，成功返回大于0的值</returns>
        public static IntPtr RealPlayByDataType(IntPtr lLoginID, NET_IN_REALPLAY_BY_DATA_TYPE pstInParam, ref NET_OUT_REALPLAY_BY_DATA_TYPE pstOutParam, uint dwWaitTime)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_RealPlayByDataType(lLoginID, ref pstInParam, ref pstOutParam, dwWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Playback By Stream Data Type  指定回调数据类型回放 
        /// </summary>
        /// <param name="lLoginID">user LoginID:Login's return value 登陆ID，Login返回值</param>
        /// <param name="pstInParam">playback  parameter in 回放输入参数</param>
        /// <param name="pstOutParam">playback  parameter out 回放输出参数</param>
        /// <param name="dwWaitTime">Waiting Time 等待时间</param>
        /// <returns>failed return 0, successful return the playback ID(playback handle),as parameter of related function. 失败返回0，成功返回大于0的值</returns>
        public static IntPtr PlayBackByDataType(IntPtr lLoginID, NET_IN_PLAYBACK_BY_DATA_TYPE pstInParam, ref NET_OUT_PLAYBACK_BY_DATA_TYPE pstOutParam, uint dwWaitTime)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_PlayBackByDataType(lLoginID, ref pstInParam, ref pstOutParam, dwWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Download By Stream Data Type  指定回调数据类型下载 
        /// </summary>
        /// <param name="lLoginID">user LoginID:Login's return value 登陆ID，Login返回值</param>
        /// <param name="pstInParam">download parameter in 下载输入参数</param>
        /// <param name="pstOutParam">download parameter Out 下载输出参数</param>
        /// <param name="dwWaitTime">Waiting Time 等待时间</param>
        /// <returns>failed return 0, successful return the download ID(download handle),as parameter of related function. 失败返回0，成功返回大于0的值</returns>
        public static IntPtr DownloadByDataType(IntPtr lLoginID, NET_IN_DOWNLOAD_BY_DATA_TYPE pstInParam, ref NET_OUT_DOWNLOAD_BY_DATA_TYPE pstOutParam, uint dwWaitTime)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_DownloadByDataType(lLoginID, ref pstInParam, ref pstOutParam, dwWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Get Alarm ext module status 报警主机获取扩展模块在线状态接口
        /// </summary>
        /// <param name="lLoginID">user LoginID:Login's return value 登陆ID，Login返回值</param>
        /// <param name="pstInParam">Get Alarm ext module status parameter in 输入参数</param>
        /// <param name="pstOutParam">Get Alarm ext module status parameter Out 输出参数</param>
        /// <param name="dwWaitTime">Waiting Time 等待时间</param>
        /// <returns></returns>
        public static bool GetConnectionStatus(IntPtr lLoginID, NET_IN_GETCONNECTION_STATUS pstInParam, ref NET_OUT_GETCONNECTION_STATUS pstOutParam, int dwWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_GetConnectionStatus(lLoginID, ref pstInParam, ref pstOutParam, dwWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool GetDefenceArmMode(IntPtr lLoginID, NET_IN_GET_DEFENCEMODE pstInParam, ref NET_OUT_GET_DEFENCEMODE pstOutParam, int dwWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_GetDefenceArmMode(lLoginID, ref pstInParam, ref pstOutParam, dwWaitTime);
            NetGetLastError(result);
            return result;
        }

        public static bool SetDefenceArmMode(IntPtr lLoginID, NET_IN_SET_DEFENCEMODE pstInParam, int dwWaitTime)
        {
            bool result = false;
            NET_OUT_SET_DEFENCEMODE outParam = new NET_OUT_SET_DEFENCEMODE();
            outParam.dwSize = (uint)Marshal.SizeOf(typeof(NET_OUT_SET_DEFENCEMODE));
            result = OriginalSDK.CLIENT_SetDefenceArmMode(lLoginID, ref pstInParam, ref outParam, dwWaitTime);
            NetGetLastError(result);
            return result;
        }


        public static bool SetParkingSpaceLightPlan(IntPtr lLoginID, NET_IN_SET_PARKING_SPACE_LIGHT_PLAN pstInParam, int nWaitTime)
        {
            bool result = false;
            NET_OUT_SET_PARKING_SPACE_LIGHT_PLAN outParam = new NET_OUT_SET_PARKING_SPACE_LIGHT_PLAN();
            outParam.dwSize = (uint)Marshal.SizeOf(typeof(NET_OUT_SET_PARKING_SPACE_LIGHT_PLAN));
            result = OriginalSDK.CLIENT_SetParkingSpaceLightPlan(lLoginID, ref pstInParam, ref outParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 下发人脸开门比对数据
        /// </summary>
        /// <param name="lLoginID">登录句柄</param>
        /// <param name="pInParam">入参</param>
        /// <param name="pOutParam">出参</param>
        /// <param name="nWaitTime">超时时间</param>
        /// <returns></returns>
        public static bool FaceOpenDoor(IntPtr lLoginID, NET_IN_FACE_OPEN_DOOR pInParam, NET_OUT_FACE_OPEN_DOOR pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_FaceOpenDoor(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 向服务器提交多张大图，从中检测人脸图片, pstInParam = NET_IN_FACE_RECOGNITION_DETECT_MULTI_FACE_INFO 与pstOutParam内存由用户申请释放
        /// submit multiple large images to the server, and detect face images from it, user malloc and free (pstInParam's = NET_IN_FACE_RECOGNITION_DETECT_MULTI_FACE_INFO and pstOutParam's) memory
        /// </summary>
        public static bool FaceRecognitionDetectMultiFace(IntPtr lLoginID, IntPtr pstInParam, ref NET_OUT_FACE_RECOGNITION_DETECT_MULTI_FACE_INFO pstOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_FaceRecognitionDetectMultiFace(lLoginID, pstInParam, ref pstOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 订阅大图检测小图进度,配合CLIENT_FaceRecognitionDetectMultiFace使用, pstInParam与pstOutParam内存由用户申请释放
        /// attach the progress of detect face images form the big images, cooperate with CLIENT_FaceRecognitionDetectMultiFace, user malloc and free (pstInParam's and pstOutParam's) memory
        /// </summary>
        public static IntPtr AttachDetectMultiFaceState(IntPtr lLoginID, ref NET_IN_MULTIFACE_DETECT_STATE pstInParam, ref NET_OUT_MULTIFACE_DETECT_STATE pstOutParam, int nWaitTime)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_AttachDetectMultiFaceState(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 取消订阅大图检测小图进度, lAttachHandle为CLIENT_AttachDetectMultiFaceState 返回的句柄
        /// detach the progress of detect face images form the big images, lAttachHandleis returned by CLIENT_AttachDetectMultiFaceState
        /// </summary>
        public static bool DetachDetectMultiFaceState(IntPtr lAttachHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_DetachDetectMultiFaceState(lAttachHandle);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 西欧报警主机获取操作
        /// Get operate of alarm region
        /// </summary>
        public static bool GetAlarmRegionInfo(IntPtr lLoginID, EM_A_NET_EM_GET_ALARMREGION_INFO emType, IntPtr pstuInParam, IntPtr pstuOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_GetAlarmRegionInfo(lLoginID, emType, pstuInParam, pstuOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }


        #region<< gps >>

        /// <summary>
        /// GPS inforamtion subscribe
        /// </summary>
        /// <param name="lLoginID">login handle</param>
        /// <param name="bStart">TRUE:subscribe  FALSE:cancle subscribe</param>
        /// <param name="KeepTime">subscribe time last (unit second) value:-1  means indefinite duration last</param>
        /// <param name="InterTime">GPS send rate in subscribe time</param>
        /// <returns>failed return false, successful return true</returns>
        public static bool SubcribeGPS(IntPtr lLoginID, bool bStart, int KeepTime, int InterTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_SubcribeGPS(lLoginID, bStart, KeepTime, InterTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Set GPS subscription callback function
        /// </summary>
        /// <param name="OnGPSMessage">callback method</param>
        /// <param name="dwUser"></param>
        public static void SetSubcribeGPSCallBack(fGPSRevEx2 OnGPSMessage, IntPtr dwUser)
        {
            OriginalSDK.CLIENT_SetSubcribeGPSCallBackEX2(OnGPSMessage, dwUser);
        }
        #endregion GPS

        #region Analyze Task

        /// <summary>
        /// 订阅智能分析任务状态
        /// </summary>
        /// <param name="lLoginID">Lonin return value 登陆ID</param>
        /// <param name="stuInParam">入参</param>
        /// <param name="nWaitTime">waittime 等待时间</param>
        /// <returns>failed return Intptr.Zero, successful return other; 失败返回Intptr.Zero 成功返回其他值</returns>
        public static IntPtr AttachAnalyseTaskState(IntPtr lLoginID, ref NET_IN_ATTACH_ANALYSE_TASK_STATE pInParam, int nWaitTime)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_AttachAnalyseTaskState(lLoginID, ref pInParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 取消订阅智能分析任务状态
        /// </summary>
        /// <param name="lAttachHandle">AttachAnalyseTaskState return value; 订阅返回句柄ID</param>
        /// <returns></returns>
        public static bool DetachAnalyseTaskState(IntPtr lAttachHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_DetachAnalyseTaskState(lAttachHandle);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 推送需要智能分析的图片
        /// </summary>
        /// <param name="lLoginID">Lonin return value; 登陆ID</param>
        /// <param name="stuInParam">入参</param>
        /// <param name="stuOutParam">出参</param>
        /// <param name="nWaitTime">waittime; 等待时间</param>
        /// <returns>failed return false, successful return true; 失败返回false 成功返回true</returns>
        public static bool PushAnalysePictureFile(IntPtr lLoginID, ref NET_IN_PUSH_ANALYSE_PICTURE_FILE pInParam, ref NET_OUT_PUSH_ANALYSE_PICTURE_FILE pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_PushAnalysePictureFile(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 推送智能分析图片文件和规则信息,当CLIENT_AddAnalyseTask的数据源类型emDataSourceType为 EM_DATA_SOURCE_PUSH_PICFILE_BYRULE 时使用
        /// Push intelligent analysis of picture files and rule information when the client_ The data source type emdatasourcetype of addanalysistask is em_ DATA_ SOURCE_ PUSH_ PICFILE_ Used when byrule
        /// </summary>
        /// <param name="lLoginID">Lonin return value; 登陆ID</param>
        /// <param name="stuInParam">入参</param>
        /// <param name="stuOutParam">出参</param>
        /// <param name="nWaitTime">waittime; 等待时间</param>
        /// <returns>failed return false, successful return true; 失败返回false 成功返回true</returns>
        public static bool PushAnalysePictureFileByRule(IntPtr lLoginID, ref NET_IN_PUSH_ANALYSE_PICTURE_FILE_BYRULE pInParam, ref NET_OUT_PUSH_ANALYSE_PICTURE_FILE_BYRULE pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_PushAnalysePictureFileByRule(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }


        /// <summary>
        /// 添加智能分析任务(图片方式)
        /// </summary>
        /// <param name="lLoginID">Lonin return value 登陆ID</param>
        /// <param name="stuPushInfo">推送图片文件信息</param>
        /// <param name="stuOutParam">出参</param>
        /// <param name="nWaitTime">waittime 等待时间</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool AddAnalyseTask_PushPicFile(IntPtr lLoginID, NET_PUSH_PICFILE_INFO stuPushInfo, ref NET_OUT_ADD_ANALYSE_TASK pOutParam, int nWaitTime)
        {
            bool result = false;
            IntPtr pInParam = IntPtr.Zero;
            EM_DATA_SOURCE_TYPE emDataSourceType = EM_DATA_SOURCE_TYPE.PUSH_PICFILE;
            try
            {
                pInParam = Marshal.AllocHGlobal(Marshal.SizeOf(stuPushInfo));
                Marshal.StructureToPtr(stuPushInfo, pInParam, true);
                result = OriginalSDK.CLIENT_AddAnalyseTask(lLoginID, emDataSourceType, pInParam, ref pOutParam, nWaitTime); ;
                NetGetLastError(result);
                return result;
            }
            finally
            {
                Marshal.FreeHGlobal(pInParam);
            }
        }

        public static bool AddAnalyseTask(IntPtr lLoginID, EM_DATA_SOURCE_TYPE emDataSourceType, IntPtr pInParam, ref NET_OUT_ADD_ANALYSE_TASK pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_AddAnalyseTask(lLoginID, emDataSourceType, pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 删除智能分析任务
        /// </summary>
        /// <param name="lLoginID">Lonin return value 登陆ID</param>
        /// <param name="stuInParam">入参</param>
        /// <param name="stuOutParam">出参</param>
        /// <param name="nWaitTime">waittime 等待时间</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool RemoveAnalyseTask(IntPtr lLoginID, ref NET_IN_REMOVE_ANALYSE_TASK pInParam, ref NET_OUT_REMOVE_ANALYSE_TASK pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_RemoveAnalyseTask(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 订阅智能分析结果
        /// </summary>
        /// <param name="lLoginID">Lonin return value 登陆ID</param>
        /// <param name="stuInParam">入参</param>
        /// <param name="nWaitTime">waittime 等待时间</param>
        /// <returns>failed return Intptr.Zero, successful return other; 失败返回Intptr.Zero 成功返回其他值</returns>
        public static IntPtr AttachAnalyseTaskResult(IntPtr lLoginID, ref NET_IN_ATTACH_ANALYSE_RESULT pInParam, int nWaitTime)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_AttachAnalyseTaskResult(lLoginID, ref pInParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 取消订阅智能分析结果
        /// </summary>
        /// <param name="lAttachHandle">AttachAnalyseTaskResult返回结果</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool DetachAnalyseTaskResult(IntPtr lAttachHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_DetachAnalyseTaskResult(lAttachHandle);
            NetGetLastError(result);
            return result;
        }

        public static bool FindAnalyseTask(IntPtr lLoginID, ref NET_IN_FIND_ANALYSE_TASK stuInParam, ref NET_OUT_FIND_ANALYSE_TASK stuOutParam, int nWaitTime)
        {
            bool result = false;
            IntPtr pOut = IntPtr.Zero;
            try
            {
                pOut = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NET_OUT_FIND_ANALYSE_TASK)));
                result = OriginalSDK.CLIENT_FindAnalyseTask(lLoginID, ref stuInParam, pOut, nWaitTime);
                if (result)
                {
                    stuOutParam = (NET_OUT_FIND_ANALYSE_TASK)Marshal.PtrToStructure(pOut, typeof(NET_OUT_FIND_ANALYSE_TASK));
                }

            }
            finally
            {
                Marshal.FreeHGlobal(pOut);
            }

            NetGetLastError(result);
            return result;
        }


        #endregion


        /// <summary>
        /// Open PlayGroup
        /// 打开播放组
        /// </summary>
        /// <returns>failed return 0,successful return PlayGroupID 失败返回0，成功返回大于O的值</returns>
        public static IntPtr OpenPlayGroup()
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_OpenPlayGroup();
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        ///  Add PlayHandle To PlayGroup
        /// 将播放句柄加入播放组，保证同步播放
        /// </summary>
        /// <param name="pInParam">输入数据</param>
        /// <param name="pOutParam">输出数据</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool AddPlayHandleToPlayGroup(ref NET_IN_ADD_PLAYHANDLE_TO_PLAYGROUP pInParam, ref NET_OUT_ADD_PLAYHANDLE_TO_PLAYGROUP pOutParam)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_AddPlayHandleToPlayGroup(ref pInParam, ref pOutParam);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Pause or Play PlayGroup
        /// 暂停或继续播放组
        /// </summary>
        /// <param name="lPlayGroupHandle">PlayGroupID 播放组ID</param>
        /// <param name="bPause">false:play；true:pause  false:播放；true:暂停 </param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool PausePlayGroup(IntPtr lPlayGroupHandle, bool bPause)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_PausePlayGroup(lPlayGroupHandle, bPause);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Query the time of PlayGroup
        /// 查询播放组的播放时间
        /// </summary>
        /// <param name="pInParam"></param>
        /// <param name="pOutParam"></param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool QueryPlayGroupTime(ref NET_IN_QUERY_PLAYGROUP_TIME pInParam, ref NET_OUT_QUERY_PLAYGROUP_TIME pOutParam)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_QueryPlayGroupTime(ref pInParam, ref pOutParam);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Delete From PlayGroup
        /// 将指定句柄从播放组中删除
        /// </summary>
        /// <param name="pInParam"></param>
        /// <param name="pOutParam"></param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool DeletePlayHandleFromPlayGroup(ref NET_IN_DELETE_FROM_PLAYGROUP pInParam, ref NET_OUT_DELETE_FROM_PLAYGROUP pOutParam)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_DeleteFromPlayGroup(ref pInParam, ref pOutParam);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// close PlayGroup
        /// 关闭播放组
        /// </summary>
        /// <param name="lPlayGroupHandle">播放组ID</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool ClosePlayGroup(IntPtr lPlayGroupHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_ClosePlayGroup(lPlayGroupHandle);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Set PlayGroup Direction
        /// 设置播放组播放方向
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool SetPlayGroupDirection(ref NET_IN_SET_PLAYGROUP_DIRECTION pInParam, ref NET_OUT_SET_PLAYGROUP_DIRECTION pOutParam)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_SetPlayGroupDirection(ref pInParam, ref pOutParam);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Set PlayGroup Speed
        /// 设置播放组播放速度
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool SetPlayGroupSpeed(ref NET_IN_SET_PLAYGROUP_SPEED pInParam, ref NET_OUT_SET_PLAYGROUP_SPEED pOutParam)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_SetPlayGroupSpeed(ref pInParam, ref pOutParam);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// PlayGroup play fast
        /// 播放组快放
        /// </summary>
        /// <param name="lPlayGroupHandle">播放组ID</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool FastPlayGroup(IntPtr lPlayGroupHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_FastPlayGroup(lPlayGroupHandle);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// PlayGroup play slow
        /// 播放组慢放
        /// </summary>
        /// <param name="lPlayGroupHandle">播放组ID</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool SlowPlayGroup(IntPtr lPlayGroupHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_SlowPlayGroup(lPlayGroupHandle);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// PlayGroup play normal
        /// 播放组正常播放
        /// </summary>
        /// <param name="lPlayGroupHandle">播放组ID</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool NormalPlayGroup(IntPtr lPlayGroupHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_NormalPlayGroup(lPlayGroupHandle);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// start upload remote file
        /// 开始上传文件
        /// </summary>
        /// <param name="pInParam"></param>
        /// <param name="pOutParam"></param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static IntPtr StartUploadRemoteFile(IntPtr lLoginID, ref NET_IN_UPLOAD_REMOTE_FILE pInParam, ref NET_OUT_UPLOAD_REMOTE_FILE pOutParam, fUploadFileCallBack cbUploadFile, IntPtr dwUser)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_StartUploadRemoteFile(lLoginID, ref pInParam, ref pOutParam, cbUploadFile, dwUser);
            NetGetLastError(result);
            return result;
        }
        /// <summary>
        /// stop upload remote file
        /// 停止文件上传
        /// </summary>
        /// <param name="lPlayGroupHandle">上传ID</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool StopUploadRemoteFile(IntPtr lPlayGroupHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_StopUploadRemoteFile(lPlayGroupHandle);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 开始打标签
        /// </summary>
        /// <param name="pInParam"></param>
        /// <param name="pOutParam"></param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool TagManagerStartTag(IntPtr lLoginID, ref NET_IN_TAGMANAGER_STARTTAG_INFO pInParam, ref NET_OUT_TAGMANAGER_STARTTAG_INFO pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_TagManagerStartTag(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 停止打标签
        /// </summary>
        /// <param name="pInParam"></param>
        /// <param name="pOutParam"></param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool TagManagerStopTag(IntPtr lLoginID, ref NET_IN_TAGMANAGER_STOPTAG_INFO pInParam, ref NET_OUT_TAGMANAGER_STOPTAG_INFO pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_TagManagerStopTag(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 获取标签状态
        /// </summary>
        /// <param name="pInParam"></param>
        /// <param name="pOutParam"></param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool TagManagerGetTagState(IntPtr lLoginID, ref NET_IN_TAGMANAGER_GETTAGSTATE_INFO pInParam, ref NET_OUT_TAGMANAGER_GETTAGSTATE_INFO pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_TagManagerGetTagState(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 开始查询标签信息
        /// </summary>
        /// <param name="pInParam"></param>
        /// <param name="pOutParam"></param>
        /// <returns>failed return 0, successful return the handle 失败返回0，成功返回大于0的值</returns>
        public static IntPtr TagManagerStartFind(IntPtr lLoginID, ref NET_IN_TAGMANAGER_STARTFIND_INFO pInParam, ref NET_OUT_TAGMANAGER_STARTFIND_INFO pOutParam, int nWaitTime)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_TagManagerStartFind(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 获取标签查询结果信息
        /// </summary>
        /// <param name="pInParam"></param>
        /// <param name="pOutParam"></param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool TagManagerDoFind(IntPtr lLoginID, ref NET_IN_TAGMANAGER_DOFIND_INFO pInParam, ref NET_OUT_TAGMANAGER_DOFIND_INFO pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_TagManagerDoFind(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 获取标签查询能力
        /// </summary>
        /// <param name="pInParam"></param>
        /// <param name="pOutParam"></param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool TagManagerGetCaps(IntPtr lLoginID, ref NET_IN_TAGMANAGER_GETCAPS_INFO pInParam, ref NET_OUT_TAGMANAGER_GETCAPS_INFO pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_TagManagerGetCaps(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 停止打标签
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool TagManagerStopFind(IntPtr lLoginID)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_TagManagerStopFind(lLoginID);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 获取黑体异常报警能力
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool GetHumanRadioCaps(IntPtr lLoginID, ref NET_IN_GET_HUMAN_RADIO_CAPS pInParam, ref NET_OUT_GET_HUMAN_RADIO_CAPS pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_GetHumanRadioCaps(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 异步添加自定义设备
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool AsyncAddCustomDevice(IntPtr lLoginID, ref NET_IN_ASYNC_ADD_CUSTOM_DEVICE pInParam, ref NET_OUT_ASYNC_ADD_CUSTOM_DEVICE pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_AsyncAddCustomDevice(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 删除设备
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool RemoveDevice(IntPtr lLoginID, ref NET_IN_REMOVE_DEVICE pInParam, ref NET_OUT_REMOVE_DEVICE pOutParam, int nWaitTime)
        {
            bool result = false;
            IntPtr inPtr = Marshal.AllocHGlobal((int)pInParam.dwSize);
            Marshal.StructureToPtr(pInParam, inPtr, true);

            IntPtr outPtr = Marshal.AllocHGlobal((int)pOutParam.dwSize);
            Marshal.StructureToPtr(pOutParam, outPtr, true);

            result = OriginalSDK.CLIENT_RemoveDevice(lLoginID, inPtr, outPtr, nWaitTime);
            NetGetLastError(result);
            if (result)
            {
                pOutParam = (NET_OUT_REMOVE_DEVICE)Marshal.PtrToStructure(outPtr, typeof(NET_OUT_REMOVE_DEVICE));
            }
            Marshal.FreeHGlobal(inPtr);
            Marshal.FreeHGlobal(outPtr);
            return result;
        }

        /// <summary>
        /// 下载离线智能分析数据－图片
        /// </summary>
        /// <returns>failed return 0, successful return the handle 失败返回0，成功返回大于0的值</returns>
        public static IntPtr LoadOffLineFile(IntPtr lLoginID, int nChannelID, uint dwAlarmType, NET_TIME_EX lpStartTime, NET_TIME_EX lpEndTime, fAnalyzerDataCallBack cbAnalyzerData, IntPtr dwUser)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_LoadOffLineFile(lLoginID, nChannelID, dwAlarmType, lpStartTime, lpEndTime, cbAnalyzerData, dwUser);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 获取回放帧速
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool GetFramePlayBack(IntPtr lPlayBackID, ref int nfileframerate, ref int nplayframerate)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_GetFramePlayBack(lPlayBackID, ref nfileframerate, ref nplayframerate);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 设置回放帧速
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool SetFramePlayBack(IntPtr lPlayBackID, int framerate)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_SetFramePlayBack(lPlayBackID, framerate);
            NetGetLastError(result);
            return result;
        }

        public static IntPtr StartSearchDevicesEx(ref NET_IN_STARTSERACH_DEVICE pInBuf, ref NET_OUT_STARTSERACH_DEVICE pOutBuf)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_StartSearchDevicesEx(ref pInBuf, ref pOutBuf);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// search device log item
        /// 查询设备日志条数
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool QueryDevLogCount(IntPtr lLoginID, ref NET_IN_GETCOUNT_LOG_PARAM pInParam, ref NET_OUT_GETCOUNT_LOG_PARAM pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_QueryDevLogCount(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Start query log(support BSC only)
        /// 开始查询日志(目前只支持门禁BSC系列)
        /// </summary>
        /// <returns>failed return 0, successful return non-0 失败返回0 成功返回非0</returns>
        public static IntPtr StartQueryLog(IntPtr lLoginID, ref NET_IN_START_QUERYLOG pInParam, ref NET_OUT_START_QUERYLOG pOutParam, int nWaitTime)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_StartQueryLog(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Query next log(support BSC only)
        /// 获取日志(目前只支持门禁BSC系列)
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool QueryNextLog(IntPtr lFindLogID, ref NET_IN_QUERYNEXTLOG pInParam, ref NET_OUT_QUERYNEXTLOG pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_QueryNextLog(lFindLogID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }
        /// <summary>
        /// Stop query log(support BSC only)
        /// 结束查询日志(目前只支持门禁BSC系列)
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool StopQueryLog(IntPtr lFindLogID)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_StopQueryLog(lFindLogID);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 开始升级设备程序--扩展,pchFileName由用户申请释放内存，大小为MAX_PATH
        /// </summary>
        /// <returns>failed return 0, successful return the handle 失败返回0，成功返回大于0的值</returns>
        public static IntPtr StartUpgrade(IntPtr lLoginID, EM_UPGRADE_TYPE emType, string pchFileName, fUpgradeCallBack cbUpgrade, IntPtr dwUser)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_StartUpgradeEx(lLoginID, emType, pchFileName, cbUpgrade, dwUser);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 重启系统,恢复出厂默认(包括清空配置和删除账户)并重启，实现硬复位功能
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool ResetSystem(IntPtr lLoginID, ref NET_IN_RESET_SYSTEM pInParam, ref NET_OUT_RESET_SYSTEM pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_ResetSystem(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 恢复出厂配置扩展接口(包括清空配置和删除账户)，实现硬复位及软复位功能
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool ResetSystemEx(IntPtr lLoginID, ref NET_IN_RESET_SYSTEM_EX pInParam, ref NET_OUT_RESET_SYSTEM_EX pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_ResetSystemEx(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="lUpgradeID">StartUpgrade返回值</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool SendUpgrade(IntPtr lUpgradeID)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_SendUpgrade(lUpgradeID);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 结束升级设备程序
        /// </summary>
        /// <param name="lUpgradeID">StartUpgrade返回值</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool StopUpgrade(IntPtr lUpgradeID)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_StopUpgrade(lUpgradeID);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 开始查询人员信息
        /// </summary>
        /// <returns>failed return 0, successful return the handle 失败返回0，成功返回大于0的值</returns>
        public static IntPtr StartFindUserInfo(IntPtr lLoginID, ref NET_IN_USERINFO_START_FIND pstIn, ref NET_OUT_USERINFO_START_FIND pstOut, int nWaitTime)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_StartFindUserInfo(lLoginID, ref pstIn, ref pstOut, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 获取人员信息 ,lFindHandle 为StartFindUserInfo接口返回值
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool DoFindUserInfo(IntPtr lFindHandle, ref NET_IN_USERINFO_DO_FIND pstIn, ref NET_OUT_USERINFO_DO_FIND pstOut, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_DoFindUserInfo(lFindHandle, ref pstIn, ref pstOut, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 停止查询人员信息 ,lFindHandle 为StartFindUserInfo接口返回值
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool StopFindUserInfo(IntPtr lFindHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_StopFindUserInfo(lFindHandle);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 开始查询卡片信息
        /// </summary>
        /// <returns>failed return 0, successful return the handle 失败返回0，成功返回大于0的值</returns>
        public static IntPtr StartFindCardInfo(IntPtr lLoginID, ref NET_IN_CARDINFO_START_FIND pstIn, ref NET_OUT_CARDINFO_START_FIND pstOut, int nWaitTime)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_StartFindCardInfo(lLoginID, ref pstIn, ref pstOut, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 获取卡片信息,lFindHandle 为StartFindCardInfo接口返回值
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool DoFindCardInfo(IntPtr lFindHandle, ref NET_IN_CARDINFO_DO_FIND pstIn, ref NET_OUT_CARDINFO_DO_FIND pstOut, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_DoFindCardInfo(lFindHandle, ref pstIn, ref pstOut, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 停止查询卡片信息,lFindHandle 为StartFindCardInfo接口返回值
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool StopFindCardInfo(IntPtr lFindHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_StopFindCardInfo(lFindHandle);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 门禁人脸信息管理接口
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool OperateAccessFaceService(IntPtr lLoginID, EM_NET_ACCESS_CTL_FACE_SERVICE emtype, IntPtr pstInParam, IntPtr pstOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_OperateAccessFaceService(lLoginID, emtype, pstInParam, pstOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 订阅雷达的报警点信息
        /// </summary>
        /// <param name="lLoginID"></param>
        /// <param name="pInParam"></param>
        /// <param name="pOutParam"></param>
        /// <param name="nWaitTime"></param>
        /// <returns></returns>
        public static IntPtr AttachRadarAlarmPointInfo(IntPtr lLoginID, NET_IN_RADAR_ALARMPOINTINFO pInParam, ref NET_OUT_RADAR_ALARMPOINTINFO pOutParam, int nWaitTime)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_AttachRadarAlarmPointInfo(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }


        /// <summary>
        /// 取消订阅雷达的报警点信息
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool DetachRadarAlarmPointInfo(IntPtr lAttachHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_DetachRadarAlarmPointInfo(lAttachHandle);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 雷达操作
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool RadarOperate(IntPtr lLoginID, EM_RADAR_OPERATE_TYPE emtype, IntPtr pInBuf, IntPtr pOutBuf, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_RadarOperate(lLoginID, emtype, pInBuf, pOutBuf, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Radar add link-SD
        /// 用于雷达联动球机添加
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool AddRadarLinkSD(IntPtr lLoginID, ref NET_IN_RADAR_ADD_RADARLINKSD pstInParam, ref NET_OUT_RADAR_ADD_RADARLINKSD pstOutParam, int nWaitTime)
        {
            bool result = OriginalSDK.CLIENT_AddRadarLinkSD(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Radar delete link-SD
        /// 用于雷达联动球机删除
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool DelRadarLinkSD(IntPtr lLoginID, ref NET_IN_RADAR_DEL_RADARLINKSD pstInParam, ref NET_OUT_RADAR_DEL_RADARLINKSD pstOutParam, int nWaitTime)
        {
            bool result = OriginalSDK.CLIENT_DelRadarLinkSD(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// radar get link SD state
        /// 获取雷达联动的远程球机状态
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool GetRadarLinkSDState(IntPtr lLoginID, ref NET_IN_RADAR_GET_LINKSTATE pstInParam, ref NET_OUT_RADAR_GET_LINKSTATE pstOutParam, int nWaitTime)
        {
            bool result = OriginalSDK.CLIENT_GetRadarLinkSDState(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Search IO status
        /// 查询IO状态(pState内存由用户申请释放,根据emType对应的类型找到相应的结构体，进而确定申请内存大小)
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool QueryIOControlState(IntPtr lLoginID, EM_NET_IOTYPE emType, IntPtr pState, int maxlen, ref int nIOCount, int waittime = 1000)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_QueryIOControlState(lLoginID, emType, pState, maxlen, ref nIOCount, waittime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// IO control,user malloc memory of pState, please refer to corresponding structure of emType
        /// IO控制(pState内存由用户申请释放,根据emType对应的类型找到相应的结构体，进而确定申请内存大小)
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool IOControl(IntPtr lLoginID, EM_NET_IOTYPE emType, IntPtr pState, int maxlen)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_IOControl(lLoginID, emType, pState, maxlen);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 获取设备点位信息
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool SCADAGetAttributeInfo(IntPtr lLoginID, IntPtr pstInParam, IntPtr pstOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_SCADAGetAttributeInfo(lLoginID, pstInParam, pstOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 根据楼层号获取对应梯控模块映射关系
        /// </summary>
        /// <returns></returns>
        public static bool GetFloorInfo(IntPtr lLoginID, ref NET_IN_GET_FLOOR_INFO pstInParam, ref NET_OUT_GET_FLOOR_INFO pstOutParam, uint dwWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_GetFloorInfo(lLoginID, ref pstInParam, ref pstOutParam, dwWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 自定义定时抓图订阅接口(目前智慧养殖猪温检测在用)
        /// </summary>
        /// <returns>failed return 0, successful return the handle 失败返回0，成功返回不等于0的值</returns>
        public static IntPtr AttachCustomSnapInfo(IntPtr lLoginID, ref NET_IN_ATTACH_CUSTOM_SNAP_INFO pstInParam, ref NET_OUT_ATTACH_CUSTOM_SNAP_INFO pstOutParam, int nWaitTime)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_AttachCustomSnapInfo(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 取消自定义定时抓图订阅接口(目前智慧养殖猪温检测在用)
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool DetachCustomSnapInfo(IntPtr lFindHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_DetachCustomSnapInfo(lFindHandle);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// operate Monitor Wall,user malloc memory of pInParam and pOutParam,please refer to the corresponding structure of emType
        /// 电视墙操作,pInParam与pOutParam内存由用户申请释放,大小参照emType对应的结构体
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool OperateMonitorWall(IntPtr lLoginID, NET_MONITORWALL_OPERATE_TYPE emType, IntPtr pInParam, IntPtr pOutParam, int nWaitTime = 5000)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_OperateMonitorWall(lLoginID, emType, pInParam, pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 获取电视墙场景,pInParam与pOutParam内存由用户申请释放
        /// get scene of monitor wall ,user malloc memory of pInParam and pOutParam
        /// </summary>
        /// <param name="pInParam"></param>
        /// <param name="pOutParam"></param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool MonitorWallGetScene(IntPtr lLoginID, ref NET_A_IN_MONITORWALL_GET_SCENE pInParam, ref NET_A_OUT_MONITORWALL_GET_SCENE pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_MonitorWallGetScene(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 获取设备序列号
        /// </summary>
        /// <returns></returns>
        public static bool GetDeviceSerialNo(IntPtr lLoginID, ref NET_IN_GET_DEVICESERIALNO_INFO pstInParam, ref NET_OUT_GET_DEVICESERIALNO_INFO pstOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_GetDeviceSerialNo(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 获取机器名称
        /// </summary>
        /// <returns></returns>
        public static bool GetMachineName(IntPtr lLoginID, ref NET_IN_GET_MACHINENAME_INFO pstInParam, ref NET_OUT_GET_MACHINENAME_INFO pstOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_GetMachineName(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Subscribe to Bus status
        /// 订阅Bus状态
        /// </summary>
        /// <returns>failed return 0, successful return the handle 失败返回0，成功返回不等于0的值</returns>
        public static IntPtr AttachBusState(IntPtr lLoginID, ref NET_IN_BUS_ATTACH pstuInBus, ref NET_OUT_BUS_ATTACH pstuOutBus, int nWaitTime = 3000)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_AttachBusState(lLoginID, ref pstuInBus, ref pstuOutBus, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Stop subscribing to Bus status
        /// 停止订阅Bus状态
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool DetachBusState(IntPtr lAttachHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_DetachBusState(lAttachHandle);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Set playback speed
        /// 设置录像回放速度
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool SetPlayBackSpeed(IntPtr lPlayHandle, EM_PLAY_BACK_SPEED emSpeed)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_SetPlayBackSpeed(lPlayHandle, emSpeed);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Record by time marker
        /// 按时间标记录像
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool SetMarkFileByTime(IntPtr lLoginID, ref NET_IN_SET_MARK_FILE_BY_TIME pInParam, ref NET_OUT_SET_MARK_FILE_BY_TIME pOutParam, int nWaitTime = 1000)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_SetMarkFileByTime(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Acquire sign video info
        /// 获取标记录像信息
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool GetMarkInfo(IntPtr lLoginID, ref NET_IN_GET_MARK_INFO pInParam, ref NET_OUT_GET_MARK_INFO pOutParam, int nWaitTime = 1000)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_GetMarkInfo(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Interface of get record state
        /// 获取录像状态
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool GetRecordState(IntPtr lLoginID, ref NET_IN_GET_RECORD_STATE pInParam, ref NET_OUT_GET_RECORD_STATE pOutParam, int nWaitTime = 1000)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_GetRecordState(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Start or stop record
        /// 开启/关闭指定通道录像
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool SetCourseRecordState(IntPtr lLoginID, ref NET_IN_SET_COURSE_RECORD_STATE pInParam, ref NET_OUT_SET_COURSE_RECORD_STATE pOutParam, int nWaitTime = 1000)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_SetCourseRecordState(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Get code rate, bit rate
        /// 获取码率，比特率
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool GetVideoEncodeBitrate(IntPtr lLoginID, ref NET_IN_GET_VIDEO_ENCODE_BITRATE_INFO pInParam, ref NET_OUT_GET_VIDEO_ENCODE_BITRATE_INFO pOutParam, int nWaitTime = 1000)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_GetVideoEncodeBitrate(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// pre-upload remote file to remote device
        /// 通过存储设备远程预上传文件至前端设备,用于识别前端设备是否具备接收文件的条件
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool RemotePreUploadFile(IntPtr lLoginID, ref NET_IN_REMOTE_PREUPLOAD_FILE pInParam, ref NET_OUT_REMOTE_PREUPLOAD_FILE pOutParam, int nWaitTime = 1000)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_RemotePreUploadFile(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Start to upload remote file to remote device. pInParam and pOutParam managed by users
        /// 开始异步通过存储设备上传文件到前端设备 pInParam与pOutParam内存由用户申请释放
        /// </summary>
        /// <returns>failed return 0, successful return the handle 失败返回0，成功返回不等于0的值</returns>
        public static IntPtr StartRemoteUploadFile(IntPtr lLoginID, ref NET_IN_REMOTE_UPLOAD_FILE pInParam, ref NET_OUT_REMOTE_UPLOAD_FILE pOutParam, int nWaitTime = 1000)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_StartRemoteUploadFile(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Stop to upload remote file to remote device
        /// 停止异步通过存储设备上传文件到前端设备
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool StopRemoteUploadFile(IntPtr lRemoteUploadFileID)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_StopRemoteUploadFile(lRemoteUploadFileID);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Get the file information in the remote specified directory (including files / subdirectories), pInParam and pOutParam managed by users
        /// 得到远程指定目录下文件信息（含文件/子目录）pInParam与pOutParam内存由用户申请释放
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool RemoteList(IntPtr lLoginID, ref NET_IN_REMOTE_LIST pInParam, ref NET_OUT_REMOTE_LIST pOutParam, int nWaitTime = 1000)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_RemoteList(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Delete multiple remote files or directories, pInParam and pOutParam managed by users
        /// 删除多个远程文件或目录 pInParam与pOutParam内存由用户申请释放
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool RemoteRemoveFiles(IntPtr lLoginID, ref NET_IN_REMOTE_REMOVE_FILES pInParam, ref NET_OUT_REMOTE_REMOVE_FILES pOutParam, int nWaitTime = 1000)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_RemoteRemoveFiles(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Set upload file length, user malloc memory of pInParam and pOutParam
        /// 设置文件长度, pInParam与pOutParam内存由用户申请释放
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool PreUploadRemoteFile(IntPtr lLoginID, ref NET_IN_PRE_UPLOAD_REMOTE_FILE pInParam, ref NET_OUT_PRE_UPLOAD_REMOTE_FILE pOutParam, int nWaitTime = 1000)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_PreUploadRemoteFile(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// sybcgribize fule upload,user malloc memory of pInParam and pOutParam
        /// 同步文件上传, 只适用于小文件,pInParam与pOutParam内存由用户申请释放
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool UploadRemoteFile(IntPtr lLoginID, ref NET_IN_UPLOAD_REMOTE_FILE pInParam, ref NET_OUT_UPLOAD_REMOTE_FILE pOutParam, int nWaitTime = 1000)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_UploadRemoteFile(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// display files and subdirectories in a directory,user malloc memory of pInParam and pOutParam
        /// 显示目录中文件和子目录,pInParam与pOutParam内存由用户申请释放
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool ListRemoteFile(IntPtr lLoginID, ref NET_IN_LIST_REMOTE_FILE pInParam, ref NET_OUT_LIST_REMOTE_FILE pOutParam, int nWaitTime = 1000)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_ListRemoteFile(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// remove file,user malloc memory of pInParam and pOutParam
        /// 删除文件或目录,pInParam与pOutParam内存由用户申请释放
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool RemoveRemoteFiles(IntPtr lLoginID, ref NET_IN_REMOVE_REMOTE_FILES pInParam, ref NET_OUT_REMOVE_REMOTE_FILES pOutParam, int nWaitTime = 1000)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_RemoveRemoteFiles(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// multimodal Target recognition
        /// 开始目标识别多通道查询
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool StartMultiFindFaceRecognitionRecord(IntPtr lLoginID, ref NET_IN_STARTMULTIFIND_FACERECONGNITIONRECORD pInParam, ref NET_OUT_STARTMULTIFIND_FACERECONGNITIONRECORD pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_StartMultiFindFaceRecognitionRecord(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// multi channel Search file:nFilecount:the searched amount. The return value is media file amount. The search in the specified time completed if return <nFilecount.
        /// 多通道查找文件:nFilecount:需要查询的条数, 返回值为媒体文件条数 返回值<nFilecount则相应时间段内的文件查询完毕
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool DoFindFaceRecognitionRecord(ref NET_IN_DOFIND_FACERECONGNITIONRECORD inParam, ref NET_OUT_DOFIND_FACERECONGNITIONRECORD outParam, int nWaitTime)
        {
            bool result = OriginalSDK.CLIENT_DoFindFaceRecognitionRecord(ref inParam, ref outParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// end search
        /// 结束查询
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool StopFindFaceRecognitionRecord(IntPtr lFindHandle)
        {
            bool result = OriginalSDK.CLIENT_StopFindFaceRecognitionRecord(lFindHandle);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Alarm upload function. Enable service. dwTimeOut paramter is invalid 
        /// 警上传功能,启动服务；dwTimeOut参数已无效
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool StartService(uint wPort, IntPtr pIp, fServiceCallBack pfscb, uint dwTimeOut = 0xffffffff, IntPtr dwUserData = new IntPtr())
        {
            bool result = OriginalSDK.CLIENT_StartService(wPort, pIp, pfscb, dwTimeOut, dwUserData);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// add logical cameras by group,user malloc and free (pInParam's and pOutParam's) memory
        /// 批量添加视频源,pInParam与pOutParam内存由用户申请释放
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool MatrixAddCamerasByGroup(IntPtr lLoginID, ref NET_IN_ADD_LOGIC_BYGROUP_CAMERA pInParam, ref NET_OUT_ADD_LOGIC_BYGROUP_CAMERA pOutParam, int nWaitTime = 1000)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_MatrixAddCamerasByGroup(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// get camera all by group, user malloc and free (pInParam's and pOutParam's) memory
        /// 按组获取视频通道
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool MatrixGetCameraAllByGroup(IntPtr lLoginID, ref NET_IN_GET_CAMERA_ALL_BY_GROUP pInParam, ref NET_OUT_GET_CAMERA_ALL_BY_GROUP pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_MatrixGetCameraAllByGroup(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// delete camera by group, user malloc and free (pInParam's and pOutParam's) memory
        /// 按组删除视频通道
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool MatrixDeleteCameraByGroup(IntPtr lLoginID, ref NET_IN_DELETE_CAMERA_BY_GROUP pInParam, ref NET_OUT_DELETE_CAMERA_BY_GROUP pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_MatrixDeleteCameraByGroup(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// open burning session, return to burning session handle,user malloc and free (pstInParam's and pstOutParam's) memory
        /// 打开刻录会话, 返回刻录会话句柄,pstInParam与pstOutParam内存由用户申请释放
        /// </summary>
        /// <returns>failed return 0, successful return the handle 失败返回0，成功返回不等于0的值</returns> 
        public static IntPtr StartBurnSession(IntPtr lLoginID, ref NET_IN_START_BURN_SESSION pstInParam, ref NET_OUT_START_BURN_SESSION pstOutParam, int nWaitTime)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_StartBurnSession(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// close burning session
        /// 关闭刻录会话
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns> 
        public static bool StopBurnSession(IntPtr lBurnSession)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_StopBurnSession(lBurnSession);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// start burning,user malloc and free (pstInParam's and pstOutParam's) memory
        /// 开始刻录,pstInParam与pstOutParam内存由用户申请释放
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns> 
        public static bool StartBurn(IntPtr lBurnSession, ref NET_IN_START_BURN pstInParam, ref NET_OUT_START_BURN pstOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_StartBurn(lBurnSession, ref pstInParam, ref pstOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// stop burning
        /// 停止刻录
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns> 
        public static bool StopBurn(IntPtr lBurnSession)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_StopBurn(lBurnSession);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// pause/recover burning
        /// 暂停/恢复刻录
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns> 
        public static bool PauseBurn(IntPtr lBurnSession, bool bPause)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_PauseBurn(lBurnSession, bPause);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// attach burn state,user malloc and free (pstInParam's and pstOutParam's) memory
        /// 监听刻录状态,pstInParam与pstOutParam内存由用户申请释放
        /// </summary>
        /// <returns>failed return 0, successful return the handle 失败返回0，成功返回不等于0的值</returns> 
        public static IntPtr AttachBurnState(IntPtr lLoginID, ref NET_IN_ATTACH_STATE pstInParam, ref NET_OUT_ATTACH_STATE pstOutParam, int nWaitTime = 1000)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_AttachBurnState(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// cancel listening burning status, lAttachHandle is CLIENT_AttachBurnState return value
        /// 取消监听刻录状态,lAttachHandle是CLIENT_AttachBurnState返回值
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns> 
        public static bool DetachBurnState(IntPtr lAttachHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_DetachBurnState(lAttachHandle);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// key mark,user malloc and free (pstInParam's and pstOutParam's) memory
        /// 重点标记,pstInParam与pstOutParam内存由用户申请释放
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns> 
        public static bool BurnMarkTag(IntPtr lBurnSession, ref NET_IN_BURN_MARK_TAG pstInParam, ref NET_OUT_BURN_MARK_TAG pstOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_BurnMarkTag(lBurnSession, ref pstInParam, ref pstOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// get burning status,user malloc and free (pstInParam's and pstOutParam's) memory
        /// 获取刻录状态,pstInParam与pstOutParam内存由用户申请释放
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool BurnGetState(IntPtr lBurnSession, ref NET_IN_BURN_GET_STATE pstInParam, ref NET_OUT_BURN_GET_STATE pstOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_BurnGetState(lBurnSession, ref pstInParam, ref pstOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Start the backup task, and the memory of pstInParam and pstOutParam will be released by the user
        /// 开始备份任务,pstInParam与pstOutParam内存由用户申请释放
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool StartBackupTask(IntPtr lLoginID, ref NET_IN_START_BACKUP_TASK_INFO pstInParam, ref NET_OUT_START_BACKUP_TASK_INFO pstOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_StartBackupTask(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Subscribe to the backup status, pstInParam and pstOutParam memory are released by the user's application
        /// 订阅备份状态,pstInParam与pstOutParam内存由用户申请释放
        /// </summary>
        /// <returns>failed return 0, successful return the handle 失败返回0，成功返回不等于0的值</returns>
        public static IntPtr AttachBackupTaskState(IntPtr lLoginID, ref NET_IN_ATTACH_BACKUP_STATE pstInParam, ref NET_OUT_ATTACH_BACKUP_STATE pstOutParam, int nWaitTime)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_AttachBackupTaskState(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Unsubscribe the backup state, lAttachHandle is the return value of CLIENT_AttachBackupTaskState
        /// 取消订阅备份状态,lAttachHandle是CLIENT_AttachBackupTaskState返回值
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool DetachBackupTaskState(IntPtr lAttachHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_DetachBackupTaskState(lAttachHandle);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Real-time monitoring - Extends the Ex2 interface
        /// 实时预览--扩展Ex2接口
        /// </summary>
        /// <returns>failed return 0, successful return the handle 失败返回0，成功返回不等于0的值</returns>
        public static IntPtr RealPlayEx2(IntPtr lLoginID, ref NET_IN_REALPLAY pInParam, ref NET_OUT_REALPLAY pOutParam, uint dwWaitTime)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_RealPlayEx2(lLoginID, ref pInParam, ref pOutParam, dwWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Set screen overlay callback 
        /// 设置屏幕叠加回调
        /// </summary>
        public static void RigisterDrawFun(fDrawCallBack cbDraw, IntPtr dwUser)
        {
            OriginalSDK.CLIENT_RigisterDrawFun(cbDraw, dwUser);
        }

        /// <summary>
        /// 计算两张人脸图片的相似度faceRecognitionServer.matchTwoFace,pstInParam与pstOutParam内存由用户申请释放
        /// calculate the similarity of two face images,user malloc and free memory of pstInParam and pstOutParam
        /// </summary>
        public static bool MatchTwoFaceImage(IntPtr lLoginID, ref NET_MATCH_TWO_FACE_IN pstInParam, ref NET_MATCH_TWO_FACE_OUT pstOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_MatchTwoFaceImage(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 根据查询条件返回录像备份任务的信息表,pInParam与pOutParam内存由用户申请释放
        /// The information table of video backup task is returned according to the query conditions. The memory of pInParam and pOutParam is released by the user.
        /// </summary>
        /// <param name="lLoginID">CLIENT_Login's return value</param>
        /// <param name="pInParam">input info 输入参数</param>
        /// <param name="pOutParam">output info 输出参数</param>
        /// <param name="waittime">Wait timeout, million second</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool FindRecordBackupRestoreTaskInfos(IntPtr lLoginID, ref NET_IN_FIND_REC_BAK_RST_TASK pInParam, ref NET_OUT_FIND_REC_BAK_RST_TASK pOutParam, int nWaitTime = 3000)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_FindRecordBackupRestoreTaskInfos(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 添加考试录像计划
        /// Add test video plan
        /// </summary>
        /// <param name="lLoginID">CLIENT_Login's return value</param>
        /// <param name="pstuInParam">input info 输入参数</param>
        /// <param name="pstuOutParam">output info 输出参数</param>
        /// <param name="waittime">Wait timeout, million second</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool SetExamRecordingPlans(IntPtr lLoginID, ref NET_IN_SET_EXAM_RECORDING_PLANS pstuInParam, ref NET_OUT_SET_EXAM_RECORDING_PLANS pstuOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_SetExamRecordingPlans(lLoginID, ref pstuInParam, ref pstuOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 手动抓图, 支持并发调用
        /// Manual snap, Indicates concurrent calls
        /// </summary>
        public static bool ManualSnap(IntPtr lLoginID, ref NET_IN_MANUAL_SNAP pInParam, ref NET_OUT_MANUAL_SNAP pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_ManualSnap(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Open stream
        /// 打开流
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool PlayOpenStream(int nPort, IntPtr pFileHeadBuf, uint nSize, uint nBufPoolSize)
        {
            bool result = false;
            result = OriginalSDK.PLAY_OpenStream(nPort, pFileHeadBuf, nSize, nBufPoolSize);
            return result;
        }

        /// <summary>
        /// Turn on playback, playback starts, the size of the playback video screen will be adjusted according to the hWnd window, to display full screen, as long as the hWnd window is enlarged to full screen. Start decoding thread, if the incoming display window handle is NULL, it is not displayed, but it does not affect decoding
        /// 开启播放，播放开始，播放视频画面大小将根据hWnd窗口调整，要全屏显示，只要把hWnd窗口放大到全屏。开始解码线程，若送入的显示窗口句柄为NULL，则不显示，但是不影响解码
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool PlayPlay(int nPort, IntPtr hWnd)
        {
            bool result = false;
            result = OriginalSDK.PLAY_Play(nPort, hWnd);
            return result;
        }

        /// <summary>
        /// Input data stream, to be used after PlayPlay
        /// 输入数据流，PlayPlay之后使用
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool PlayInputData(int nPort, IntPtr pBuf, uint nSize)
        {
            bool result = false;
            result = OriginalSDK.PLAY_InputData(nPort, pBuf, nSize);
            return result;
        }

        /// <summary>
        /// Stop play
        /// 关闭播放
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool PlayStop(int nPort)
        {
            bool result = false;
            result = OriginalSDK.PLAY_Stop(nPort);
            return result;
        }

        /// <summary>
        /// Close stream
        /// 关闭流
        /// </summary>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool PlayCloseStream(int nPort)
        {
            bool result = false;
            result = OriginalSDK.PLAY_CloseStream(nPort);
            return result;
        }

        /// <summary>
        /// Get monitor wall collections
        /// 获取电视墙预案
        /// </summary>
        /// <param name="lLoginID">Lonin return value 登陆ID</param>
        /// <param name="pInParam">input struct info 输入结构体</param>
        /// <param name="pOutParam">output struct info 输出结构体</param>
        /// <param name="waittime">waittime 等待时间</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool GetMonitorWallCollections(IntPtr lLoginID, ref NET_IN_WM_GET_COLLECTIONS pInParam, ref NET_OUT_WM_GET_COLLECTIONS pOutParam, int nWaitTime = 1000)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_GetMonitorWallCollections(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Load monitor wall collections
        /// 加载电视墙预案
        /// </summary>
        /// <param name="lLoginID">Lonin return value 登陆ID</param>
        /// <param name="pInParam">input struct info 输入结构体</param>
        /// <param name="pOutParam">output struct info 输出结构体</param>
        /// <param name="waittime">waittime 等待时间</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool LoadMonitorWallCollection(IntPtr lLoginID, ref NET_IN_WM_LOAD_COLLECTION pInParam, ref NET_OUT_WM_LOAD_COLLECTION pOutParam, int nWaitTime = 1000)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_LoadMonitorWallCollection(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Save monitor wall collections
        /// 添加电视墙预案
        /// </summary>
        /// <param name="lLoginID">Lonin return value 登陆ID</param>
        /// <param name="pInParam">input struct info 输入结构体</param>
        /// <param name="pOutParam">output struct info 输出结构体</param>
        /// <param name="waittime">waittime 等待时间</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool SaveMonitorWallCollection(IntPtr lLoginID, ref NET_IN_WM_SAVE_COLLECTION pInParam, ref NET_OUT_WM_SAVE_COLLECTION pOutParam, int nWaitTime = 1000)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_SaveMonitorWallCollection(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Rename monitor wall collections(If the original plan name is empty, the plan will be deleted)
        /// 修改电视墙预案名称(原预案名为空则为删除该预案)
        /// </summary>
        /// <param name="lLoginID">Lonin return value 登陆ID</param>
        /// <param name="pInParam">input struct info 输入结构体</param>
        /// <param name="pOutParam">output struct info 输出结构体</param>
        /// <param name="waittime">waittime 等待时间</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool RenameMonitorWallCollection(IntPtr lLoginID, ref NET_IN_WM_RENAME_COLLECTION pInParam, ref NET_OUT_WM_RENAME_COLLECTION pOutParam, int nWaitTime = 1000)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_RenameMonitorWallCollection(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// Web information upload interface
        /// web信息上传接口
        /// </summary>
        /// <param name="lLoginID">Lonin return value 登陆ID</param>
        /// <param name="pInParam">input info 输入参数</param>
        /// <param name="pOutParam">output info 输出参数</param>
        /// <param name="waittime">waittime 等待时间</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool TransmitInfoForWebEx(IntPtr lLoginID, ref NET_IN_TRANSMIT_INFO pInParam, ref NET_OUT_TRANSMIT_INFO pOutParam, int nWaittime = 3000)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_TransmitInfoForWebEx(lLoginID, ref pInParam, ref pOutParam, nWaittime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 获取流量统计信息,pstInParam与pstOutParam内存由用户申请释放
        /// start find flux state,user malloc and free (pstInParam's and pstOutParam's) memory
        /// </summary>
        /// <param name="lLoginID">Lonin return value 登陆ID</param>
        /// <param name="pstInParam">input info 输入参数</param>
        /// <param name="pstOutParam">output info 输出参数</param>
        /// <returns>failed return 0, successful return lFindHandle 失败返回0 成功返回lFindHandle</returns>
        public static IntPtr StartFindFluxStat(IntPtr lLoginID, ref NET_IN_TRAFFICSTARTFINDSTAT pstInParam, ref NET_OUT_TRAFFICSTARTFINDSTAT pstOutParam)
        {
            return OriginalSDK.CLIENT_StartFindFluxStat(lLoginID, ref pstInParam, ref pstOutParam);
        }
        /// <summary>
        /// 继续查询流量统计,pstInParam与pstOutParam内存由用户申请释放
        /// do find flux state,user malloc and free (pstInParam's and pstOutParam's) memory
        /// </summary>
        /// <param name="lFindHandle">FindHandle value 登陆ID</param>
        /// <param name="pstInParam">input info 输入参数</param>
        /// <param name="pstOutParam">output info 输出参数</param>
        /// <returns>failed return -1, successful return 1 失败返回 -1 成功返回 1 </returns>
        public static int DoFindFluxStat(IntPtr lFindHandle, ref NET_IN_TRAFFICDOFINDSTAT pstInParam, ref NET_OUT_TRAFFICDOFINDSTAT pstOutParam)
        {
            int result = 0;
            result = OriginalSDK.CLIENT_DoFindFluxStat(lFindHandle, ref pstInParam, ref pstOutParam);
            if (result == -1) NetGetLastError(result);
            return result;
        }
        /// <summary>
        /// 结束查询流量统计
        /// stop find flux state
        /// </summary>
        /// <param name="lFindHandle">FindHandle value 登陆ID</param>
        /// <returns>failed return false, successful return true 失败返回false 成功返回true</returns>
        public static bool StopFindFluxStat(IntPtr lFindHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_StopFindFluxStat(lFindHandle);
            NetGetLastError(result);
            return result;
        }

        // <summary>
        /// 添加人脸库下载任务
        /// Add task of download face data base
        /// </summary>
        public static bool AddFaceDbDownLoadTask(IntPtr lLoginID, ref NET_IN_ADD_FACEDB_DOWNLOAD_TASK pInParam, ref NET_OUT_ADD_FACEDB_DOWNLOAD_TASK pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_AddFaceDbDownLoadTask(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 订阅人脸库下载结果
        /// Attach the result of downloading face data base
        /// </summary>
        public static IntPtr AttachFaceDbDownLoadResult(IntPtr lLoginID, ref NET_IN_ATTACH_FACEDB_DOWNLOAD_RESULT pInParam, ref NET_OUT_ATTACH_FACEDB_DOWNLOAD_RESULT pOutParam, int nWaitTime)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_AttachFaceDbDownLoadResult(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 取消订阅人脸库下载结果 lAttachHandle为 AttachFaceDbDownLoadResult 接口的返回值
        /// Detach Attach the result of downloading face data base
        /// </summary>
        ///@brief , 
        public static bool DetachFaceDbDownLoadResult(IntPtr lAttachHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_DetachFaceDbDownLoadResult(lAttachHandle);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 设置解码窗口输出OSD信息扩展接口(pInparam, pOutParam内存由用户申请释放)
        /// set splite output OSD info ----expand interface (the memory of pInParam and pOutParam applyed and released by user),user malloc and free (pInParam's and pOutParam's)memory
        /// </summary>
        public static bool SetSplitOSDEx(IntPtr lLoginID, ref NET_IN_SPLIT_SET_OSD_EX pInParam, ref NET_OUT_SPLIT_SET_OSD_EX pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_SetSplitOSDEx(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }
        /// <summary>
        /// 获取解码窗口输出OSD信息扩展接口(pInparam, pOutParam内存由用户申请释放)
        /// get splite output OSD info ----expand interface (the memory of pInParam and pOutParam applyed and released by user),user malloc and free (pInParam's and pOutParam's)memory
        /// </summary>
        public static bool GetSplitOSDEx(IntPtr lLoginID, ref NET_IN_SPLIT_GET_OSD_EX pInParam, ref NET_OUT_SPLIT_GET_OSD_EX pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_GetSplitOSDEx(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 在线升级检查是否有可用升级包, pInParam和pOutParam内存由用户申请和释放
        /// Check Cloud Upgrader, user mallloc memory of pInParam and pOutParam
        /// </summary>
        public static bool CheckCloudUpgrader(IntPtr lLoginID, ref NET_IN_CHECK_CLOUD_UPGRADER pInParam, ref NET_OUT_CHECK_CLOUD_UPGRADER pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_CheckCloudUpgrader(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 执行在线云升级, pInParam和pOutParam内存由用户申请和释放
        /// Execute Cloud Upgrader, user mallloc memory of pInParam and pOutParam
        /// </summary>
        public static bool ExecuteCloudUpgrader(IntPtr lLoginID, ref NET_IN_EXECUTE_CLOUD_UPGRADER pInParam, ref NET_OUT_EXECUTE_CLOUD_UPGRADER pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_ExecuteCloudUpgrader(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 获取云升级在线升级状态, pInParam和pOutParam内存由用户申请和释放
        /// Get Cloud Upgrader State, user mallloc memory of pInParam and pOutParam
        /// </summary>
        public static bool GetCloudUpgraderState(IntPtr lLoginID, ref NET_IN_GET_CLOUD_UPGRADER_STATE pInParam, ref NET_OUT_GET_CLOUD_UPGRADER_STATE pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_GetCloudUpgraderState(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 开始人脸检测/注册库的多通道查询(IVSS产品特色功能以图搜图支持两段式查询。第一步先上传大图并从中识别出目标小图，返回小图的SmallID，第二步用SmallID进行以图搜图)
        /// Start the multi-channel query of face detection / registry (IVSS product features the function of image search, which supports two-stage query. The first step is to upload the large image and identify the target small image, return the smallid of the small image, and the second step is to search the image with smallid)
        /// </summary>
        /// <param name="lLoginID">[in] lLoginID 登录句柄; [in] lLoginID Login handle</param>
        /// <param name="pstInParam">[in] pstInParam 接口输入参数; [in] pstInParam Interface input parameters</param>
        /// <param name="pstOutParam">[out]pstOutParam 接口输出参数; [out] pstOutParam Interface output parameters</param>
        /// <param name="nWaitTime">[in] nWaitTime 接口超时时间, 单位毫秒; [in] nWaitTime Interface timeout in milliseconds</param>
        /// <returns>TRUE表示成功 FALSE表示失败; True indicates success and false indicates failure</returns>
        public static bool StartMultiPersonFindFaceR(IntPtr lLoginID, ref NET_IN_STARTMULTIPERSONFIND_FACER pstInParam, ref NET_OUT_STARTMULTIPERSONFIND_FACER pstOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_StartMultiPersonFindFaceR(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 获取人脸检测令牌
        /// Get face detection token
        /// </summary>
        /// <param name="lLoginID">[in] lLoginID 登录句柄; [in] lLoginID Login handle</param>
        /// <param name="pInParam">[in] pInParam 接口输入参数; [in] pInParam Interface input parameters</param>
        /// <param name="pOutParam">[out]pOutParam 接口输出参数; [out] pOutParam Interface output parameters</param>
        /// <param name="nWaitTime">[in] nWaitTime 接口超时时间, 单位毫秒; [in] nWaitTime Interface timeout in milliseconds</param>
        /// <returns>TRUE表示成功 FALSE表示失败; True indicates success and false indicates failure</returns>
        public static bool FaceRServerGetDetectToken(IntPtr lLoginID, ref NET_IN_FACERSERVER_GETDETEVTTOKEN pInParam, ref NET_OUT_FACERSERVER_GETDETEVTTOKEN pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_FaceRServerGetDetectToken(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 指定时间段内录像自定义重命名
        /// Rename the recording within the specified time period
        /// </summary>
        /// <param name="lLoginID">[in] lLoginID: 登录句柄; [in] lLoginID: Login handle</param>
        /// <param name="pstuInParam">[in] pstuInParam: 接口输入参数, 内存资源由用户申请和释放; [in] pstuInParam: Interface input parameters, memory resources are requested and released by the user</param>
        /// <param name="pstuOutParam">[out] pstuOutParam: 接口输出参数, 内存资源由用户申请和释放; [out] pstuOutParam: Interface output parameters, memory resources are requested and released by the user</param>
        /// <param name="nWaitTime">[in] nWaitTime: 接口超时时间, 单位毫秒; [in] nWaitTime: Interface timeout, in milliseconds</param>
        /// <returns>TRUE表示成功FALSE表示失败; TRUE means success, FALSE means failure</returns>
        public static bool SetFileAlias(IntPtr lLoginID, ref NET_IN_SET_FILE_ALIAS_INFO pstuInParam, ref NET_OUT_SET_FILE_ALIAS_INFO pstuOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_SetFileAlias(lLoginID, ref pstuInParam, ref pstuOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 根据录像的命名调取录像
        /// Query the video according to the name of the video
        /// </summary>
        /// <param name="lLoginID">[in] lLoginID: 登录句柄; [in] lLoginID: Login handle</param>
        /// <param name="pstuInParam">[in] pstuInParam: 接口输入参数, 内存资源由用户申请和释放; [in] pstuInParam: Interface input parameters, memory resources are requested and released by the user</param>
        /// <param name="pstuOutParam">[out] pstuOutParam: 接口输出参数, 内存资源由用户申请和释放; [out] pstuOutParam: Interface output parameters, memory resources are requested and released by the user</param>
        /// <param name="nWaitTime">[in] nWaitTime: 接口超时时间, 单位毫秒; [in] nWaitTime: Interface timeout, in milliseconds</param>
        /// <returns>TRUE表示成功FALSE表示失败; TRUE means success, FALSE means failure</returns>
        public static bool SearchFileByAlias(IntPtr lLoginID, ref NET_IN_SEARCH_FILE_BYALIAS_INFO pstuInParam, ref NET_OUT_SEARCH_FILE_BYALIAS_INFO pstuOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_SearchFileByAlias(lLoginID, ref pstuInParam, ref pstuOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 获取水质检测能力
        /// Acquire water quality detection capability
        /// </summary>
        /// <param name="lLoginID">[in] lLoginID 登录句柄; [in] lLoginID Login handle</param>
        /// <param name="pstuInParam">[in] pstuInParam 接口输入参数; [in] pstuInParam Interface input parameters</param>
        /// <param name="pstuOutParam">[out]pstuOutParam 接口输出参数; [out]pstuOutParam Interface output parameters</param>
        /// <param name="nWaitTime">[in] nWaitTime 接口超时时间, 单位毫秒; [in] nWaitTime Interface timeout in milliseconds</param>
        /// <returns>TRUE表示成功 FALSE表示失败; TRUE indicates success FALSE indicates failure</returns>
        public static IntPtr GetWaterDataStatServerCaps(IntPtr lLoginID, ref NET_IN_WATERDATA_STAT_SERVER_GETCAPS_INFO pstuInParam, ref NET_OUT_WATERDATA_STAT_SERVER_GETCAPS_INFO pstuOutParam, int nWaitTime)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_GetWaterDataStatServerCaps(lLoginID, ref pstuInParam, ref pstuOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 开始水质检测报表数据查询
        /// Start data query of water quality test report
        /// </summary>
        /// <param name="lLoginID">[in] lLoginID 登录句柄; [in] lLoginID Login handle</param>
        /// <param name="pstuInParam">[in] pstuInParam 接口输入参数; [in] pstuInParam Interface input parameters</param>
        /// <param name="pstuOutParam">[out]pstuOutParam 接口输出参数; [out]pstuOutParam Interface output parameters</param>
        /// <param name="nWaitTime">[in] nWaitTime 接口超时时间, 单位毫秒; [in] nWaitTime Interface timeout in milliseconds</param>
        /// <returns>TRUE表示成功 FALSE表示失败; TRUE indicates success FALSE indicates failure</returns>
        public static IntPtr StartFindWaterDataStatServer(IntPtr lLoginID, ref NET_IN_START_FIND_WATERDATA_STAT_SERVER_INFO pstuInParam, ref NET_OUT_START_FIND_WATERDATA_STAT_SERVER_INFO pstuOutParam, int nWaitTime)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_StartFindWaterDataStatServer(lLoginID, ref pstuInParam, ref pstuOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 水质检测报表数据查询
        /// Data query of water quality test report
        /// </summary>
        /// <param name="lLoginID">[in] lLoginID 登录句柄; [in] lLoginID Login handle</param>
        /// <param name="pstuInParam">[in] pstuInParam 接口输入参数; [in] pstuInParam Interface input parameters</param>
        /// <param name="pstuOutParam">[out]pstuOutParam 接口输出参数; [out]pstuOutParam Interface output parameters</param>
        /// <param name="nWaitTime">[in] nWaitTime 接口超时时间, 单位毫秒; [in] nWaitTime Interface timeout in milliseconds</param>
        /// <returns>TRUE表示成功 FALSE表示失败; TRUE indicates success FALSE indicates failure</returns>
        public static IntPtr DoFindWaterDataStatServer(IntPtr lLoginID, ref NET_IN_DO_FIND_WATERDATA_STAT_SERVER_INFO pstuInParam, ref NET_OUT_DO_FIND_WATERDATA_STAT_SERVER_INFO pstuOutParam, int nWaitTime)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_DoFindWaterDataStatServer(lLoginID, ref pstuInParam, ref pstuOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 停止水质检测报表数据查询
        /// Stop data query of water quality test report
        /// </summary>
        /// <param name="lLoginID">[in] lLoginID 登录句柄; [in] lLoginID Login handle</param>
        /// <param name="pstuInParam">[in] pstuInParam 接口输入参数; [in] pstuInParam Interface input parameters</param>
        /// <param name="pstuOutParam">[out]pstuOutParam 接口输出参数; [out]pstuOutParam Interface output parameters</param>
        /// <param name="nWaitTime">[in] nWaitTime 接口超时时间, 单位毫秒; [in] nWaitTime Interface timeout in milliseconds</param>
        /// <returns>TRUE表示成功 FALSE表示失败; TRUE indicates success FALSE indicates failure</returns>
        public static IntPtr StopFindWaterDataStatServer(IntPtr lLoginID, ref NET_IN_STOP_FIND_WATERDATA_STAT_SERVER_INFO pstuInParam, ref NET_OUT_STOP_FIND_WATERDATA_STAT_SERVER_INFO pstuOutParam, int nWaitTime)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_StopFindWaterDataStatServer(lLoginID, ref pstuInParam, ref pstuOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 水质检测实时数据获取
        /// Real time data acquisition of water quality detection
        /// </summary>
        /// <param name="lLoginID">[in] lLoginID 登录句柄; [in] lLoginID Login handle</param>
        /// <param name="pstuInParam">[in] pstuInParam 接口输入参数; [in] pstuInParam Interface input parameters</param>
        /// <param name="pstuOutParam">[out]pstuOutParam 接口输出参数; [out]pstuOutParam Interface output parameters</param>
        /// <param name="nWaitTime">[in] nWaitTime 接口超时时间, 单位毫秒; [in] nWaitTime Interface timeout in milliseconds</param>
        /// <returns>TRUE表示成功 FALSE表示失败; TRUE indicates success FALSE indicates failure</returns>
        public static IntPtr GetWaterDataStatServerWaterData(IntPtr lLoginID, ref NET_IN_WATERDATA_STAT_SERVER_GETDATA_INFO pstuInParam, ref NET_OUT_WATERDATA_STAT_SERVER_GETDATA_INFO pstuOutParam, int nWaitTime)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_GetWaterDataStatServerWaterData(lLoginID, ref pstuInParam, ref pstuOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }


        /// <summary>
        /// 获取设备状态, DMSS专用接口, pInParam与pOutParam内存由用户申请释放
        /// </summary>
        public static bool GetUnifiedStatus(IntPtr lLoginID, ref NET_IN_UNIFIEDINFOCOLLECT_GET_DEVSTATUS pInParam, ref NET_OUT_UNIFIEDINFOCOLLECT_GET_DEVSTATUS pOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_GetUnifiedStatus(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 订阅统计通道数据,pInParam与pOutParam内存由用户申请释放
        /// Subscribe to statistical channel data, and the memory of pinparam and outparam is released by user application
        /// </summary>
        public static IntPtr AttachVideoStatStream(IntPtr lLoginID, ref NET_IN_ATTACH_VIDEOSTAT_STREAM pInParam, ref NET_OUT_ATTACH_VIDEOSTAT_STREAM pOutParam, int nWaitTime)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_AttachVideoStatStream(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 取消订阅统计通道数据
        /// Unsubscribe statistics channel data
        /// </summary>
        public static bool DetachVideoStatStream(IntPtr lAttachHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_DetachVideoStatStream(lAttachHandle);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 添加多个人员信息和人脸样本
        /// batch append persons, user malloc and free (pstInParam's and pstOutParam's) memory
        /// </summary>
        public static bool BatchAppendFaceRecognition(IntPtr lLoginID, ref NET_IN_BATCH_APPEND_FACERECONGNITION pstInParam, ref NET_OUT_BATCH_APPEND_FACERECONGNITION pstOutParam, int nWaitTime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_BatchAppendFaceRecognition(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// :设置GPS信息UUID
        /// :set gps uuid
        /// </summary>
        /// <param name="lLoginID">[in]: LLONG :lLoginID 登陆句柄; [in]: LLONG :lLoginID login handle</param>
        /// <param name="pInParam">[in]: NET_IN_SUBCRIBE_GPS_INFO :pInParam 接口输入参数, 内存资源由用户申请和释放; [in]: NET_IN_SUBCRIBE_GPS_INFO :pInParam Interface input parameters, memory resources are applied and released by the user</param>
        /// <param name="pOutParam">[out]: NET_OUT_SET_GPS_UUID_INFO :pOutParam 接口输出参数, 内存资源由用户申请和释放; [out]: NET_OUT_SET_GPS_UUID_INFO :pOutParam Interface output parameters, memory resources are applied and released by the user</param>
        /// <returns>TRUE表示成功 FALSE表示失败; True indicates success and false indicates failure</returns>
        public static bool SetGPSUuidInfo(IntPtr lLoginID, ref NET_IN_SET_GPS_UUID_INFO pInParam, ref NET_OUT_SET_GPS_UUID_INFO pOutParam)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_SetGPSUuidInfo(lLoginID, ref pInParam, ref pOutParam);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 人脸库导入接口
        /// interface of import face DB
        /// </summary>
        public static IntPtr ImportFaceDB(IntPtr lLoginID, ref NET_IN_IMPORT_FACE_DB pInParam, ref NET_OUT_IMPORT_FACE_DB pOutParam)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_ImportFaceDB(lLoginID, ref pInParam, ref pOutParam);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 停止人脸库导入
        /// interface of stopping import face DB
        /// </summary>
        public static bool StopImportFaceDB(IntPtr lImportFaceDbHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_StopImportFaceDB(lImportFaceDbHandle);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 人脸库导出接口
        /// interface of export face DB
        /// </summary>
        public static IntPtr ExportFaceDB(IntPtr lLoginID, ref NET_IN_EXPORT_FACE_DB pInParam, ref NET_OUT_EXPORT_FACE_DB pOutParam)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_ExportFaceDB(lLoginID, ref pInParam, ref pOutParam);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 停止人脸库导出
        /// interface of stop export upload face DB
        /// </summary>
        public static bool StopExportFaceDB(IntPtr lExportFaceDbHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_StopExportFaceDB(lExportFaceDbHandle);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 订阅事件重传,pInParam内存由用户申请释放
        /// attach event restore,user malloc and free memory of pInParam
        /// </summary>
        public static IntPtr AttachEventRestore(IntPtr lLoginID, ref NET_IN_ATTACH_EVENT_RESTORE pInParam, int nWaitTime)
        {
            IntPtr result = IntPtr.Zero;
            result = OriginalSDK.CLIENT_AttachEventRestore(lLoginID, ref pInParam, nWaitTime);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 停止订阅事件重传,pInParam内存由用户申请释放
        /// detach event restore ,user malloc and free memory of pInParam
        /// </summary>
        public static bool DetachEventRestore(IntPtr lAttachHandle)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_DetachEventRestore(lAttachHandle);
            NetGetLastError(result);
            return result;
        }

        /// <summary>
        /// 查询远程设备状态,nType为DEVSTATE_ALARM_FRONTDISCONNECT时，通道号从1开始(pBuf内存由用户申请释放)
        /// query remote device state,when nType = DEVSTATE_ALARM_FRONTDISCONNECT,the number form 1.
        /// </summary>
        public static bool QueryRemotDevState(IntPtr lLoginID, int nType, int nChannelID, IntPtr pBuf, int nBufLen, IntPtr pRetLen, int waittime)
        {
            bool result = false;
            result = OriginalSDK.CLIENT_QueryRemotDevState(lLoginID, nType, nChannelID, pBuf, nBufLen, pRetLen, waittime);
            NetGetLastError(result);
            return result;
        }

        #endregion //<< C# SDK calls >>
    }

    /// <summary>
    /// throw SDK exception Class
    /// SDK异常类
    /// </summary>
    public class NETClientExcetion : Exception
    {
        /// <summary>
        /// SDK error code property
        /// SDK错误码属性
        /// </summary>
        public int ErrorCode { get; private set; }

        /// <summary>
        /// SDK error message property
        /// SDK错误信息属性
        /// </summary>
        new public string Message { get; private set; }

        /// <summary>
        /// construct function.
        /// 构造函数
        /// </summary>
        /// <param name="errorCode">SDK error code number</param>
        /// <param name="message">SDK error message</param>
        public NETClientExcetion(int errorCode, string message)
        {
            ErrorCode = errorCode;
            Message = message;
        }
    }

    #region << delegate >>

    /// <summary>
    /// network disconnection callback function original shape
    /// 断线回调函数
    /// </summary>
    /// <param name="lLoginID">user LoginID:Login's returns value 登陆ID</param>
    /// <param name="pchDVRIP">device IP 设备IP</param>
    /// <param name="nDVRPort">device prot 设备端口</param>
    /// <param name="dwUser">user data from Init function 用户数据</param>
    public delegate void fDisConnectCallBack(IntPtr lLoginID, IntPtr pchDVRIP, int nDVRPort, IntPtr dwUser);

    /// <summary>
    /// network re-connection callback function original shape
    /// 重连回调函数
    /// </summary>
    /// <param name="lLoginID">user LoginID:Login's returns value 登陆ID</param>
    /// <param name="pchDVRIP">device IP,string type 设备IP</param>
    /// <param name="nDVRPort">device prot 设备端口</param>
    /// <param name="dwUser">user data from SetAutoReconnect function 用户数据</param>
    public delegate void fHaveReConnectCallBack(IntPtr lLoginID, IntPtr pchDVRIP, int nDVRPort, IntPtr dwUser);

    /// <summary>
    /// real-time monitor data callback function original shape---extensive. just only support 32bit.
    /// 实时预览数据回调函数,只支持32位,不支持64位.
    /// </summary>
    /// <param name="lRealHandle">monitor handle 预览句柄</param>
    /// <param name="dwDataType">callback data type ,only data set in dwFlag will be callback：回调数据类型
    ///                         <para>0 original data (identicla SaveRealData saveddata)</para>
    ///                         <para>1 frame data</para>
    ///                         <para>2 yuv data</para>
    ///                         <para>3 pcm audio data</para></param>
    /// <param name="pBuffer">byte array, length is dwBufSize 回调数据缓存
    ///                      <para>callback data, except type 0, other type is base on frame, one frame data per callback</para></param>
    /// <param name="dwBufSize">pBuffer's size 回调数据的缓存大小</param>
    /// <param name="param">pointer to parameter structure,based on different type 参数结构体的指针
    ///                    <para>if type is 0(original) or 2(yuv), param is 0</para>
    ///                    <para>if callback data is frame data, pointer to NET_VideoFrameParam</para>
    ///                    <para>if callback data is PCM data, pointer to NET_CBPCMDataParam</para></param>
    /// <param name="dwUser">user data,which input above</param>
    public delegate void fRealDataCallBackEx(IntPtr lRealHandle, uint dwDataType, IntPtr pBuffer, uint dwBufSize, int param, IntPtr dwUser);

    /// <summary>
    /// real-time monitor data callback function original shape---extensive. support 32bit and 64bit
    /// 实时预览数据回调函数.支持32位和64位.
    /// </summary>
    /// <param name="lRealHandle">monitor handle 预览句柄</param>
    /// <param name="dwDataType">callback data type ,only data set in dwFlag will be callback：回调数据类型
    ///                         <para>0 original data (identicla SaveRealData saveddata)</para>
    ///                         <para>1 frame data</para>
    ///                         <para>2 yuv data</para>
    ///                         <para>3 pcm audio data</para></param>
    /// <param name="pBuffer">byte array, length is dwBufSize 回调数据缓存
    ///                      <para>callback data, except type 0, other type is base on frame, one frame data per callback</para></param>
    /// <param name="dwBufSize">pBuffer's size 回调数据的缓存大小</param>
    /// <param name="param">pointer to parameter structure,based on different type 参数结构体的指针
    ///                    <para>if type is 0(original) or 2(yuv), param is 0</para>
    ///                    <para>if callback data is frame data, pointer to NET_VideoFrameParam</para>
    ///                    <para>if callback data is PCM data, pointer to NET_CBPCMDataParam</para></param>
    /// <param name="dwUser">user data,which input above</param>
    public delegate void fRealDataCallBackEx2(IntPtr lRealHandle, uint dwDataType, IntPtr pBuffer, uint dwBufSize, IntPtr param, IntPtr dwUser);

    /// <summary>
    /// Real-time monitoring of the raw codestream data callback function (pBuffer memory is freed by SDK internal request)
    /// 实时预览原始码流数据回调函数(pBuffer内存由SDK内部申请释放)
    /// </summary>
    /// <param name="lRealHandle">monitor handle 预览句柄</param>
    /// <param name="pBuffer">byte array, length is dwBufSize 回调数据缓存</param>
    /// <param name="dwBufSize">pBuffer's size 回调数据的缓存大小</param>
    /// <param name="dwUser">user data,which input above</param>
    public delegate void fOriginalRealDataCallBack(IntPtr lRealHandle, IntPtr pBuffer, uint dwBufSize, IntPtr dwUser);

    /// <summary>
    /// Real-time monitoring of encrypted data callback functions (pBuffer memory is freed by SDK internal request)
    /// 实时预览加密数据回调函数(pBuffer内存由SDK内部申请释放)
    /// </summary>
    /// <param name="lRealHandle">monitor handle 预览句柄</param>
    /// <param name="pBuffer">byte array, length is dwBufSize 回调数据缓存</param>
    /// <param name="dwBufSize">pBuffer's size 回调数据的缓存大小</param>
    /// <param name="dwUser">user data,which input above</param>
    public delegate void fEncryptRealDataCallBackEx(IntPtr lRealHandle, IntPtr pBuffer, uint dwBufSize, IntPtr dwUser);

    /// <summary>
    /// monitor disconnect callback function
    /// 实时预览断线回调函数
    /// </summary>
    /// <param name="lRealHandle">monitoring handle 预览句柄</param>
    /// <param name="dwEventType">event type 断线类型</param>
    /// <param name="param">event parameter,currently not used 断线事件的数据指针</param>
    /// <param name="dwUser">user data,which input above 用户数据</param>
    public delegate void fRealPlayDisConnectCallBack(IntPtr lRealHandle, EM_REALPLAY_DISCONNECT_EVENT_TYPE dwEventType, IntPtr param, IntPtr dwUser);

    /// <summary>
    /// VK info callback,dwError value for example:NET_NOERROR,NET_ERROR_VK_INFO_DECRYPT_FAILED
    /// VK信息回调(pBuffer内存由SDK内部申请释放),dwError值示例比如NET_NOERROR,NET_ERROR_VK_INFO_DECRYPT_FAILED等
    /// </summary>
    /// <param name="lRealHandle">monitoring handle 预览句柄</param>
    /// <param name="pBuffer">NET_VKINFO struct, length is dwBufSize 回调数据缓存NET_VKINFO</param>
    /// <param name="dwError">error code for example:NET_NOERROR,NET_ERROR_VK_INFO_DECRYPT_FAILED 错误码</param>
    /// <param name="dwUser">user data,which input above 用户数据</param>
    /// <param name="pReserved">reserved 预留字段</param>
    public delegate void fVKInfoCallBack(IntPtr lRealHandle, IntPtr pBuffer, uint dwError, IntPtr dwUser, IntPtr pReserved);

    /// <summary>
    /// snapshot callback function original shape
    /// 远程抓图数据回调
    /// </summary>
    /// <param name="lLoginID">loginID,login returns value 登陆ID</param>
    /// <param name="pBuf">byte array, length is RevLen 数据缓存
    ///                    <para>pointer to data</para></param>
    /// <param name="RevLen">pBuf's size 数据缓存大小</param>
    /// <param name="EncodeType">image encode type：0：mpeg4 I frame;10：jpeg 编码类型</param>
    /// <param name="CmdSerial">operation NO.,not used in Synchronous capture conditions 序列号</param>
    /// <param name="dwUser">user data,which input above 用户数据</param>
    public delegate void fSnapRevCallBack(IntPtr lLoginID, IntPtr pBuf, uint RevLen, uint EncodeType, uint CmdSerial, IntPtr dwUser);

    /// <summary>
    /// vt event callback
    /// vt事件回调
    /// </summary>
    /// <param name="instId">vt instance id vt实例ID</param>
    /// <param name="ulRegisterId">register id 注册ID</param>
    /// <param name="ulSessionId">session id </param>
    /// <param name="nEvent">evnet see EM_AUDIO_CB_FLAG 事件类型</param>
    /// <param name="pDataBuf">date buffer,IntPtr.Zero now 数据缓存</param>
    /// <param name="dwBufSize">data size,0 now 数据缓存大小</param>
    /// <param name="dwUser">user data 用户数据</param>
    /// <returns>reserved 保留</returns>
    public delegate int fVtEventCallBack(IntPtr instId, IntPtr ulRegisterId, IntPtr ulSessionId, int nEvent, IntPtr pDataBuf, uint dwBufSize, IntPtr dwUser);

    /// <summary>
    /// play back progress's data callback function
    /// 回放进度的数据回调函数
    /// </summary>
    /// <param name="lPlayHandle">playback handle 回放句柄</param>
    /// <param name="dwTotalSize">total size of this play(kb) 总大小</param>
    /// <param name="dwDownLoadSize">played size(kb) 当前的大小
    ///                             <para>-1:playback has over</para>
    ///                             <para>-2:write file failed</para></param>
    /// <param name="dwUser">user data,which input above 用户数据</param>
    public delegate void fDownLoadPosCallBack(IntPtr lPlayHandle, uint dwTotalSize, uint dwDownLoadSize, IntPtr dwUser);

    /// <summary>
    /// playback data callback function
    /// 回放数据回调函数
    /// </summary>
    /// <param name="lRealHandle">playback handle 回放数据</param>
    /// <param name="dwDataType">data type 数据类型</param>
    /// <param name="pBuffer">byte array, length is dwBufSize 数据缓存</param>
    /// <param name="dwBufSize">pBuffer's size 数据缓存大小</param>
    /// <param name="dwUser">user data,which input above 用户数据</param>
    /// <returns>reserved</returns>
    public delegate int fDataCallBack(IntPtr lRealHandle, uint dwDataType, IntPtr pBuffer, uint dwBufSize, IntPtr dwUser);


    /// <summary>
    /// Prototype of playback data callback function (extended)
    /// 回放数据回调函数（扩展）
    /// </summary>
    /// <param name="lRealHandle">playback handle 回放数据</param>
    /// <param name="pDataCallBack">NET_DATA_CALL_BACK_INFO 数据内容</param>
    /// <param name="dwUser">user data,which input above 用户数据</param>
    /// <returns>reserved</returns>
    public delegate int fDataCallBackEx(IntPtr lRealHandle, IntPtr pDataCallBack, IntPtr dwUser);

    /// <summary>
    /// download progress callback function
    /// 下载进度回调函数
    /// </summary>
    /// <param name="lPlayHandle">download handle 下载句柄</param>
    /// <param name="dwTotalSize">total size of this play(kb) 下载总大小</param>
    /// <param name="dwDownLoadSize">played size(kb) 已下载的大小</param>
    /// <param name="index">file index 文件序列</param>
    /// <param name="recordfileinfo">record file information 录像文件信息</param>
    /// <param name="dwUser">user data,which input above 用户数据</param>
    public delegate void fTimeDownLoadPosCallBack(IntPtr lPlayHandle, uint dwTotalSize, uint dwDownLoadSize, int index, NET_RECORDFILE_INFO recordfileinfo, IntPtr dwUser);

    /// <summary>
    /// alarm message callback function original shape
    /// 报警回调函数
    /// </summary>
    /// <param name="lCommand">alarm type,see EM_ALARM_TYPE 报警类型</param>
    /// <param name="lLoginID">loginID:login returns value 登陆ID</param>
    /// <param name="pBuf">alarm data 报警数据缓存</param>
    /// <param name="dwBufLen">alarm data length 数据大小</param>
    /// <param name="pchDVRIP">device ip,string type 设备IP</param>
    /// <param name="nDVRPort">device port 设备端口</param>
    /// <param name="bAlarmAckFlag">true:the event is affirmable event;false:the event is not affirmable event TRUE,该事件为可以进行确认的事件；FALSE,该事件无法进行确认</param>
    /// <param name="nEventID">used to AlarmAck function,when the bAlarmAckFlag is true,this paramter is valid 用于对 CLIENT_AlarmAck 接口的入参进行赋值,当 bAlarmAckFlag 为 TRUE 时,该数据有效</param>
    /// <param name="dwUser">user data from SetDVRMessCallBack function 用户数据</param>
    /// <returns>reserved</returns>
    public delegate bool fMessCallBackEx(int lCommand, IntPtr lLoginID, IntPtr pBuf, uint dwBufLen, IntPtr pchDVRIP, int nDVRPort, bool bAlarmAckFlag, int nEventID, IntPtr dwUser);

    /// <summary>
    /// event data callback
    /// 事件数据回调函数
    /// </summary>
    /// <param name="lAnalyzerHandle">analyzerHandle:RealLoadPicture returns value 事件句柄</param>
    /// <param name="dwEventType">event type,see EM_EVENT_IVS_TYPE 事件类型</param>
    /// <param name="pEventInfo">event information 事件信息</param>
    /// <param name="pBuffer">picture buffer 数据缓存</param>
    /// <param name="dwBufSize">picture buffer size 数据缓存大小</param>
    /// <param name="dwUser">user data from RealLoadPicture function 用户数据</param>
    /// <param name="nSequence">means status of the same uploaded image, when it is 0, it appears first time.When it is 2, it appears last time or appears once.When it is 1, it will appear again. 序列号</param>
    /// <param name="reserved">int nState = (int) reserved means current callback data status;when it is 1, it means current data is real time and current callback data is offline;when it is 2,it means offline data send structure 保留</param>
    /// <returns>reserved 保留</returns>
    public delegate int fAnalyzerDataCallBack(IntPtr lAnalyzerHandle, uint dwEventType, IntPtr pEventInfo, IntPtr pBuffer, uint dwBufSize, IntPtr dwUser, int nSequence, IntPtr reserved);

    /// <summary>
    /// 统计通道数据回调函数
    /// Statistics channel data callback function
    /// </summary>
    public delegate void fVideoStatStreamCallBack(IntPtr lAttachHandle, IntPtr pBuf, int nBufLen, IntPtr dwUser);

    /// <summary>
    /// audio data callback
    /// 语音数据回调函数
    /// </summary>
    /// <param name="lTalkHandle">StartTalk returns value StartTalk返回值</param>
    /// <param name="pDataBuf">audio data 语音数据缓存</param>
    /// <param name="dwBufSize">audio data size 数据缓存大小</param>
    /// <param name="byAudioFlag">audio flag,for send or dec 标志用于发送语音或解码</param>
    /// <param name="dwUser">user data 用户数据</param>
    public delegate void fAudioDataCallBack(IntPtr lTalkHandle, IntPtr pDataBuf, uint dwBufSize, byte byAudioFlag, IntPtr dwUser);

    /// <summary>
    ///  video statistical summary callback function type
    ///  视频统计摘要信息回调函数
    /// </summary>
    /// <param name="lAttachHandle">return value of AttachVideoStatSummary AttachVideoStatSummary返回值</param>
    /// <param name="pBuf">pointer to NET_VIDEOSTAT_SUMMARY 数据缓存</param>
    /// <param name="dwBufLen">buffer length 数据缓存大小</param>
    /// <param name="dwUser">user data of AttachVideoStatSummary 用户数据</param>
    public delegate void fVideoStatSumCallBack(IntPtr lAttachHandle, IntPtr pBuf, uint dwBufLen, IntPtr dwUser);

    /// <summary>
    /// Transparent COM callback function original shape
    /// 透明串口回调函数
    /// </summary>
    /// <param name="lLoginID">loginID:login returns value 登陆ID</param>
    /// <param name="lTransComChannel">TransCom Channel 串口通道</param>
    /// <param name="pBuffer">pointer to TransCom data 数据缓存</param>
    /// <param name="dwBufSize">buffer length 数据缓存大小</param>
    /// <param name="dwUser">user data from CreateTransComChannel 用户数据</param>
    public delegate void fTransComCallBack(IntPtr lLoginID, IntPtr lTransComChannel, IntPtr pBuffer, uint dwBufSize, IntPtr dwUser);

    public delegate void fFaceFindStateCallBack(IntPtr lLoginID, IntPtr lAttachHandle, IntPtr pstStates, Int32 nStateNum, UInt32 dwUser);

    public delegate void fTransFileCallBack(IntPtr lHandle, int nTransType, int nState, int nSendSize, int nTotalSize, IntPtr dwUser);

    /// <summary>
    /// 异步搜索设备回调
    /// </summary>
    public delegate void fSearchDevicesCB(IntPtr pDevNetInfo, IntPtr pUserData);

    public delegate void fAttachMotionDataCB(IntPtr lAttachHandle, IntPtr pBuf, IntPtr dwUser);

    public delegate int fServiceCallBack(IntPtr lHandle, IntPtr pIp, ushort wPort, int lCommand, IntPtr pParam, uint dwParamLen, IntPtr dwUserData);

    public delegate void fCameraStateCallBack(IntPtr lLoginID, IntPtr lAttachHandle, IntPtr pBuf, int nBufLen, IntPtr dwUser);

    // 订阅云台元数据接口回调函数原型
    // pBuf 现阶段主要为 DH_PTZ_LOCATION_INFO 类型
    public delegate void fPTZStatusProcCallBack(IntPtr lLoginID, IntPtr lAttachHandle, IntPtr pBuf, int nBufLen, IntPtr dwUser);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lAttachHandle"></param>
    /// <param name="pInfo">NET_SCADA_NOTIFY_POINT_ALARM_INFO_LIST</param>
    /// <param name="nBufLen"></param>
    /// <param name="dwUser"></param>
    public delegate void fSCADAAlarmAttachInfoCallBack(IntPtr lAttachHandle, IntPtr pInfo, int nBufLen, IntPtr dwUser);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lLoginID"></param>
    /// <param name="lAttachHandle"></param>
    /// <param name="pInfo">NET_SCADA_NOTIFY_POINT_INFO_LIST</param>
    /// <param name="nBufLen"></param>
    /// <param name="dwUser"></param>
    public delegate void fSCADAAttachInfoCallBack(IntPtr lLoginID, IntPtr lAttachHandle, IntPtr pInfo, int nBufLen, IntPtr dwUser);

    public delegate void fRadiometryAttachCB(IntPtr lAttachHandle, IntPtr pBuf, int nBufLen, IntPtr dwUser);

    /// <summary>
    /// GPS message subscription callback
    /// </summary>
    /// <param name="lLoginID">loginID:login returns value</param>
    /// <param name="pGpsInfo">GPS info, struct is NET_GPS_LOCATION_INFO</param>
    /// <param name="dwUserData">user data from _SetSubcribeGPSCallBackEX2 function 用户数据</param>
    /// <param name="reserved">reserved</param>
    public delegate void fGPSRevEx2(IntPtr lLoginID, IntPtr pGpsInfo, IntPtr dwUserData, IntPtr reserved);


    /// <summary>
    /// 智能分析状态订阅函数原型, lAttachHandle 为 CLIENT_AttachAnalyseTaskState 函数的返回值
    /// </summary>
    /// <param name="lAttachHandle"></param>
    /// <param name="pstAnalyseTaskStateInfo">NET_CB_ANALYSE_TASK_STATE_INFO*</param>
    /// <param name="dwUser"></param>
    public delegate void fAnalyseTaskStateCallBack(IntPtr lAttachHandle, IntPtr pstAnalyseTaskStateInfo, IntPtr dwUser);


    /// <summary>
    /// 智能分析结果订阅函数原型, lAttachHandle 为 CLIENT_AttachAnalyseResultState 函数的返回值
    /// </summary>
    /// <param name="lAttachHandle"></param>
    /// <param name="pstAnalyseTaskResult">NET_CB_ANALYSE_TASK_RESULT_INFO</param>
    /// <param name="pBuf"></param>
    /// <param name="dwBufSize"></param>
    /// <param name="dwUser"></param>
    public delegate void fAnalyseTaskResultCallBack(IntPtr lAttachHandle, IntPtr pstAnalyseTaskResult, IntPtr pBuf, uint dwBufSize, IntPtr dwUser);

    /// <summary>
    /// Upload File callback function
    /// 异步文件上传回调函数
    /// </summary>
    /// <param name="lRealHandle">uploadfile handle 上传文件数据</param>
    /// <param name="nTotalSize">file total size 文件总数据大小</param>
    /// <param name="nSendSize">file send size 文件已上传数据大小</param>
    /// <param name="dwUser">user data,which input above 用户数据</param>
    /// <returns>reserved</returns>
    public delegate int fUploadFileCallBack(IntPtr lUploadFileHandle, int nTotalSize, int nSendSize, IntPtr dwUser);

    // SDK日志回调
    public delegate int fSDKLogCallBack(IntPtr lUploadFileHandle, uint nLogSize, IntPtr dwUser);

    // 异步搜索设备回调(pDevNetInfo内存由SDK内部申请释放)
    public delegate void fSearchDevicesCBEx(IntPtr lSearchHandle, IntPtr pDevNetInfo, IntPtr dwUser);

    // 升级设备程序回调函数原形
    // nTotalSize = 0, nSendSize = -1 表示升级完成
    // nTotalSize = 0, nSendSize = -2 表示升级出错
    // nTotalSize = 0, nSendSize = -3 用户没有权限升级
    // nTotalSize = 0, nSendSize = -4 升级程序版本过低
    // nTotalSize = -1, nSendSize = XX 表示升级进度
    // nTotalSize = XX, nSendSize = XX 表示升级文件发送进度
    // Upgrade device callback function original shape
    // nTotalSize = 0, nSendSize = -1 Indicates Upgrade Finish
    // nTotalSize = 0, nSendSize = -2 Indicates Upgrade Failed
    // nTotalSize = 0, nSendSize = -3 User do not have permission to upgrade
    // nTotalSize = 0, nSendSize = -4 Upgrade version  too low
    // nTotalSize = -1, nSendSize = XX Indicates Upgrade Progress
    // nTotalSize = XX, nSendSize = XX Upgrade file transmission progress
    public delegate void fUpgradeCallBack(IntPtr lLoginID, IntPtr lUpgradechannel, int nTotalSize, int nSendSize, IntPtr dwUser);

    // 升级设备程序回调函数原形支持G以上升级文件
    // nTotalSize = 0, nSendSize = -1 表示升级完成
    // nTotalSize = 0, nSendSize = -2 表示升级出错
    // nTotalSize = 0, nSendSize = -3 用户没有权限升级
    // nTotalSize = 0, nSendSize = -4 升级程序版本过低
    // nTotalSize = -1, nSendSize = XX 表示升级进度
    // nTotalSize = XX, nSendSize = XX 表示升级文件发送进度 
    public delegate void fUpgradeCallBackEx(IntPtr lLoginID, IntPtr lUpgradechannel, long nTotalSize, long nSendSize, IntPtr dwUser);

    //雷达报警点信息回调函数指针
    public delegate void fRadarAlarmPointInfoCallBack(IntPtr lLoginId, IntPtr lAttachHandle, IntPtr pBuf, uint dwBufLen, IntPtr pReserved, IntPtr dwUser);

 	/// <summary>
    /// 自定义定时抓图订阅回调函数原型, lAttachHandle为 CLIENT_AttachCustomSnapInfo 接口的返回值
    /// </summary>
    /// <param name="lAttachHandle"></param>
    /// <param name="pstResult">NET_CB_CUSTOM_SNAP_INFO</param>
    /// <param name="pBuf"></param>
    /// <param name="dwBufSize"></param>
    /// <param name="dwUser"></param>
    public delegate void fAttachCustomSnapInfo(IntPtr lAttachHandle, IntPtr pstResult, IntPtr pBuf, uint dwBufSize, IntPtr dwUser);

    /// <summary>
    /// Subscribe to the Bus state callback function prototype
    /// 订阅Bus状态回调函数原型, lAttachHandle为 CLIENT_AttachBusState 接口的返回值
    /// </summary>
    public delegate void fBusStateCallBack(IntPtr lAttachHandle, int lCommand, IntPtr pBuf, uint dwBufLen, IntPtr dwUser);

    /// <summary>
    /// Start to upload remote file to remote device process callback,lRemoteUploadFileID is return by CLIENT_StartRemoteUploadFile
    /// 开始异步文件上传至前端的调函数原形,lRemoteUploadFileID 为 CLIENT_StartRemoteUploadFile 接口返回值
    /// </summary>
    public delegate void fRemoteUploadFileCallBack(IntPtr lRemoteUploadFileID, int nTotalSize, int nSendSize, EM_UPLOAD_PROCESS_STATUS emStatus, IntPtr dwUser);

    /// <summary>
    /// burning device callback function original, lAttachHandle is CLIENT_AttachBurnState return value,each 1 item, pBuf->dwSize == nBufLen
    /// 刻录设备回调函数原形,lAttachHandle是CLIENT_AttachBurnState返回值, 每次1条,pBuf->dwSize == nBufLen,pBuf类型为NET_CB_BURNSTATE
    /// </summary>
    public delegate void fAttachBurnStateCB(IntPtr lLoginID, IntPtr lAttachHandle, IntPtr pBuf, int nBufLen, IntPtr dwUser);

    /// <summary>
    /// burning device callback extension function original
    /// 刻录设备回调扩展函数原形,pBuf类型为NET_OUT_BURN_GET_STATE
    /// </summary>
    public delegate void fAttachBurnStateCBEx(IntPtr lLoginID, IntPtr lAttachHandle, IntPtr pBuf, int nBufLen, IntPtr dwUser);

    /// <summary>
    /// The prototype of the callback function of the burning device, lAttachHandle is the return value of CLIENT_AttachBackupTaskState
    /// 刻录设备回调函数原形,lAttachHandle是CLIENT_AttachBackupTaskState返回值,pBuf类型为NET_CB_BACKUPTASK_STATE
    /// </summary>
    public delegate void fAttachBackupTaskStateCB(IntPtr lAttachHandle, IntPtr pBuf, IntPtr dwUser);

    /// <summary>
    /// OSD callback function original shape
    /// 屏幕叠加回调函数原形
    /// </summary>
    public delegate void fDrawCallBack(IntPtr lLoginID, IntPtr lPlayHandle, IntPtr hDC, IntPtr dwUser);

    /// <summary>
    /// 订阅人脸库下载进度回调函数原型, lAttachHandle为 CLIENT_AttachFaceDbDownLoadResult 接口的返回值 < pstResult = NET_CB_FACEDB_DOWNLOAD_RESULT >
    /// Callback function of downloading remote face data base, lAttachHandle is returned by CLIENT_AttachFaceDbDownLoadResult < pstResult = NET_CB_FACEDB_DOWNLOAD_RESULT >
    /// </summary>
    public delegate void fFaceDbDownLoadResult(IntPtr lAttachHandle, IntPtr pstResult, IntPtr dwUser);

    /// <summary>
    /// 订阅大图检测小图进度回调函数原型 < pstStates = NET_CB_MULTIFACE_DETECT_STATE >
    /// the callback function of detection small image form the large image < pstStates = NET_CB_MULTIFACE_DETECT_STATE >
    /// </summary>
    public delegate void fMultiFaceDetectState(IntPtr lAttachHandle, IntPtr pstStates, IntPtr dwUser);

    /// <summary>
    /// 订阅大图检测小图进度回调函数原型 < pstStates = NET_CB_MULTIFACE_DETECT_STATE_EX >
    /// The callback function about attach to large image to detect small image < pstStates = NET_CB_MULTIFACE_DETECT_STATE_EX >
    /// </summary>
    public delegate void fMultiFaceDetectStateEx(IntPtr lAttachHandle, IntPtr pstStates, IntPtr dwUser);

    /// <summary>
    /// 回放数据原始回调函数原形
    /// pBuffer: 数据缓冲区，内存由SDK内部申请释放
    /// 无论设备传的码流是不是加密的，都回调原始码流
    /// Playback data callback function prototype
    /// pBuffer: data buffer, memory malloc or free was managed by SDK interior
    /// Whether the stream is encrypted or not,dwDataType: 0-original stream
    /// </summary>
    public delegate int fOriDataCallBack(IntPtr lRealHandle, uint dwDataType, IntPtr pBuffer, uint dwBufSize, IntPtr dwUser);

    /// <summary>
    /// 导入人脸库回调函数原形 pstFaceDbState : NET_IMPORT_FACEDB_STATE
    /// the callback function of import face DB, pstFaceDbState : NET_IMPORT_FACEDB_STATE
    /// </summary>
    public delegate void fImportFaceDbCallBack(IntPtr lImportFaceDbHandle, IntPtr pstFaceDbState, IntPtr dwUser);

    /// <summary>
    /// 导出人脸库回调函数原形 pstFaceDbState : NET_EXPORT_FACEDB_STATE
    /// the callback function of export face DB, pstFaceDbState : NET_EXPORT_FACEDB_STATE
    /// </summary>
    public delegate void fExportStateCallBack(IntPtr lExportFaceDbHandle, IntPtr pstFaceDbState, IntPtr dwUser);

    #endregion //<< delegate >>

}
