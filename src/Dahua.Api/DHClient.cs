using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using Dahua.Api.Struct;
using Dahua.Api.Struct.Video;

namespace Dahua.Api
{
    /// <summary>
    /// 断线回调函数，回调出当前网络已经断开的设备, 对调用SDK的ClIENT_LogOut()函数主动断开的设备不回调
    /// </summary>
    /// <param name="lLoginID">设备用户登录句柄</param>
    /// <param name="pchDVRIP">DVR设备IP</param>
    /// <param name="nDVRPort">DVR设备连接端口</param>
    /// <param name="dwUser">用户数据</param>
    public delegate void fDisConnect(
        int lLoginID, StringBuilder pchDVRIP, int nDVRPort, IntPtr dwUser);

    /// <summary>
    /// 进度回调函数
    /// </summary>
    /// <param name="lPlayHandle">播放句柄:<seealso cref="CLIENT_PlayBackByRecordFile"/>返回值</param>
    /// <param name="dwTotalSize">指本次播放总大小，单位为KB</param>
    /// <param name="dwDownLoadSize">指已经播放的大小，单位为KB，当其值为-1时表示本次回防结束</param>
    /// <param name="dwUser">用户数据</param>
    public delegate void fDownLoadPosCallBack(long lPlayHandle, UInt32 dwTotalSize, UInt32 dwDownLoadSize, IntPtr dwUser);

    public sealed partial class DHClient
    {
        const string LIBRARYNETSDK = @"SDK\dhnetsdk.dll";
        const string LIBRARYCONFIGSDK = @"SDK\dhconfigsdk.dll";
        const string LIBRARYPLAYSDK = @"SDK\dhplay.dll";


        /// <summary>
        /// en-us language
        /// Error information corresponding to English error codes
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

        private static bool initialized = false;

        /// <summary>
        /// Whether to throw errors [default is not thrown, only error information is returned to the property Last Operation Info]
        /// </summary>
        private static bool pShowException = false;

        /// <summary>
        /// 最后操作信息
        /// </summary>
        private static OPERATION_INFO pErrInfo;

        /// <summary>
        /// Last operation information [Last operation error and success, this attribute is only read]
        /// </summary>
        public static OPERATION_INFO LastOperationInfo
        {
            get
            {
                return pErrInfo;
            }
        }

        /// <summary>
        /// 初始化数字录像机
        /// </summary>
        public static void Init()
        {
            if (initialized == false)
            {
                var returnValue = CLIENT_Init(null, IntPtr.Zero);
                DHThrowLastError(returnValue);
                initialized = true;
            }
        }

        /// <summary>
        /// 注册用户到设备，当设备端把用户设置为复用（设备默认的用户如admin,不能设置为复用），则使用该帐号可以多次向设备注册
        /// </summary>
        /// <param name="pchDVRIP">设备IP</param>
        /// <param name="wDVRPort">设备端口</param>
        /// <param name="pchUserName">用户名</param>
        /// <param name="pchPassword">用户密码</param>
        /// <param name="lpDeviceInfo">设备信息,属于输出参数</param>
        /// <param name="error">返回登录错误码</param>
        /// <returns>失败返回0，成功返回设备ID</returns>
        public static long DHLogin(string pchDVRIP, ushort wDVRPort, string pchUserName, string pchPassword, out NET_DEVICEINFO lpDeviceInfo, out int error)
        {
            var result = CLIENT_Login(pchDVRIP, wDVRPort, pchUserName, pchPassword, out lpDeviceInfo, out error);
            DHThrowLastError((int)result);
            return result;
        }


        /// <summary>
        /// 注销设备用户
        /// </summary>
        /// <param name="lLoginID">设备用户登录ID:<seealso cref="CLIENT_Login"/>的返回值</param>
        /// <returns>true:成功;false:失败</returns>
        public static bool DHLogout(long lLoginID)
        {
            bool returnValue = false;
            returnValue = CLIENT_Logout(lLoginID);
            DHThrowLastError(returnValue);
            return returnValue;
        }

        /// <summary>
        ///  empty SDK, release occupied resource,call after all SDK functions
        ///  清空SDK，释放资源
        /// </summary>
        public static void Cleanup()
        {
            CLIENT_Cleanup();
        }

        /// <summary>
        /// An exception is thrown when the SDK call fails. No exception information is returned when successful, and the operation information is assigned to the Last Operation Info.
        /// </summary>
        /// <exception cref="Win32Exception">Digital video recorder is native to abnormal, triggers when SDK call fails</exception>
        private static void DHThrowLastError()
        {
            Int32 errorCode = CLIENT_GetLastError();
            if (errorCode != 0)
            {
                pErrInfo.errCode = errorCode.ToString();
                pErrInfo.errMessage = DHGetLastErrorName((uint)errorCode);
                if (pShowException == true)
                {
                    throw new Win32Exception(errorCode, pErrInfo.errMessage);
                }
                else
                {
                    Console.WriteLine(pErrInfo.errMessage);
                }
            }
            else
            {
                pErrInfo.errCode = "0";
                pErrInfo.errMessage = "Never abnormally happened recently";
            }
        }

        private static void DHThrowLastError(int returnValue)
        {
            if (returnValue == 0)
            {
                DHThrowLastError();
            }
            else
            {
                pErrInfo.errCode = "0";
                pErrInfo.errMessage = "Never abnormally happened recently";
            }
        }

        private static void DHThrowLastError(bool returnValue)
        {
            if (returnValue == false)
            {
                DHThrowLastError();
            }
            else
            {
                pErrInfo.errCode = "0";
                pErrInfo.errMessage = "Never abnormally happened recently";
            }
        }

        /// <summary>
        /// SDK调用失败时抛出异常
        /// </summary>
        /// <param name="e"></param>
        private static void DHThrowLastError(Exception e)
        {

            pErrInfo.errCode = e.ToString();
            pErrInfo.errMessage = e.Message;
            if (pShowException == true)
            {
                throw e;
            }
        }

        /// <summary>
        /// Windows系统标准时间格式转为自定义格式
        /// </summary>
        /// <param name="dateTime">系统时间对象</param>
        /// <returns>自定义时间格式的时间数据</returns>
        private static NET_TIME ToNetTime(DateTime dateTime)
        {
            NET_TIME result = new NET_TIME();
            result.dwYear = dateTime.Year;
            result.dwMonth = dateTime.Month;
            result.dwDay = dateTime.Day;
            result.dwHour = dateTime.Hour;
            result.dwMinute = dateTime.Minute;
            result.dwSecond = dateTime.Second;
            return result;
        }

        /// <summary>
        /// 错误代码转换为标准备的错误信息描述
        /// </summary>
        /// <param name="errorCode">错误代码</param>
        /// <returns>标准备错误信息描述</returns>
        private static string DHGetLastErrorName(uint errorCode)
        {
            return GetLastErrorMessage((EM_ErrorCode)errorCode);
        }

        /// <summary>
        /// error code convert to error message 
        /// Error code turn into error information
        /// </summary>
        /// <param name="errorCode">SDK error code SDK error code</param>
        /// <returns>error message description Error information description</returns>
        private static string GetLastErrorMessage(EM_ErrorCode errorCode)
        {
            string result = string.Empty;
            en_us_String.TryGetValue(errorCode, out result);
            if (null == result)
            {
                result = errorCode.ToString("X");
            }
            return result;
        }

        /// <summary>
        /// 注册用户到设备，当设备端把用户设置为复用（设备默认的用户如admin,不能设置为复用），则使用该帐号可以多次向设备注册
        /// </summary>
        /// <param name="pchDVRIP">设备IP</param>
        /// <param name="wDVRPort">设备端口</param>
        /// <param name="pchUserName">用户名</param>
        /// <param name="pchPassword">用户密码</param>
        /// <param name="lpDeviceInfo">设备信息,属于输出参数</param>
        /// <param name="error">返回登录错误码</param>
        /// <returns>失败返回0，成功返回设备ID</returns>
        [DllImport(LIBRARYNETSDK)]
        private static extern long CLIENT_Login(string pchDVRIP, ushort wDVRPort, string pchUserName,
                                                 string pchPassword, out NET_DEVICEINFO lpDeviceInfo, out int error);

        /// <summary>
        /// 返回函数执行失败代码
        /// </summary>
        /// <returns>执行失败代码</returns>
        [DllImport(LIBRARYNETSDK)]
        private static extern Int32 CLIENT_GetLastError();

        /// <summary>
        /// 初始化SDK
        /// </summary>
        /// <param name="cbDisConnect">
        /// 断线回调函数,参见委托<seealso cref="fDisConnect"/>
        /// </param>
        /// <param name="dwUser">用户信息</param>
        /// <returns>true:成功;false:失败</returns>
        [DllImport(LIBRARYNETSDK)]
        private static extern bool CLIENT_Init(fDisConnect cbDisConnect, IntPtr dwUser);

        /// <summary>
        /// 注销设备用户
        /// </summary>
        /// <param name="lLoginID">设备用户登录ID:<seealso cref="CLIENT_Login"/>的返回值</param>
        /// <returns>true:成功;false:失败</returns>
        [DllImport(LIBRARYNETSDK)]
        private static extern bool CLIENT_Logout(long lLoginID);

        [DllImport(LIBRARYNETSDK)]
        private static extern void CLIENT_Cleanup();
    }
}