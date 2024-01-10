namespace Dahua.Api.Struct
{
    /// <summary>
    /// SDK error code number enumeration
    /// </summary>
    internal enum EM_ErrorCode : uint
    {
        /// <summary>
        /// No error
        /// </summary>
        NET_NOERROR = 0,
        /// <summary>
        /// Unknown error
        /// </summary>
        NET_ERROR = 0xFFFFFFFF,
        /// <summary>
        /// Windows system error
        /// </summary>
        NET_SYSTEM_ERROR = 0x80000000 | 1,
        /// <summary>
        /// Protocol error it may result from network timeout
        /// </summary>
        NET_NETWORK_ERROR = 0x80000000 | 2,
        /// <summary>
        /// Device protocol does not match
        /// </summary>
        NET_DEV_VER_NOMATCH = 0x80000000 | 3,
        /// <summary>
        /// Handle is invalid
        /// </summary>
        NET_INVALID_HANDLE = 0x80000000 | 4,
        /// <summary>
        /// Failed to open channel
        /// </summary>
        NET_OPEN_CHANNEL_ERROR = 0x80000000 | 5,
        /// <summary>
        /// Failed to close channel
        /// </summary>
        NET_CLOSE_CHANNEL_ERROR = 0x80000000 | 6,
        /// <summary>
        /// User parameter is illegal
        /// </summary>
        NET_ILLEGAL_PARAM = 0x80000000 | 7,
        /// <summary>
        /// SDK initialization error
        /// </summary>
        NET_SDK_INIT_ERROR = 0x80000000 | 8,
        /// <summary>
        /// SDK clear error
        /// </summary>
        NET_SDK_UNINIT_ERROR = 0x80000000 | 9,
        /// <summary>
        /// Error occurs when apply for render resources
        /// </summary>
        NET_RENDER_OPEN_ERROR = 0x80000000 | 10,
        /// <summary>
        /// Error occurs when opening the decoder library
        /// </summary>
        NET_DEC_OPEN_ERROR = 0x80000000 | 11,
        /// <summary>
        /// Error occurs when closing the decoder library
        /// </summary>
        NET_DEC_CLOSE_ERROR = 0x80000000 | 12,
        /// <summary>
        /// The detected channel number is 0 in multiple-channel preview
        /// </summary>
        NET_MULTIPLAY_NOCHANNEL = 0x80000000 | 13,
        /// <summary>
        /// Failed to initialize record library
        /// </summary>
        NET_TALK_INIT_ERROR = 0x80000000 | 14,
        /// <summary>
        /// The record library has not been initialized
        /// </summary>
        NET_TALK_NOT_INIT = 0x80000000 | 15,
        /// <summary>
        /// Error occurs when sending out audio data
        /// </summary>
        NET_TALK_SENDDATA_ERROR = 0x80000000 | 16,
        /// <summary>
        /// The real-time has been protected
        /// </summary>
        NET_REAL_ALREADY_SAVING = 0x80000000 | 17,
        /// <summary>
        /// The real-time data has not been save
        /// </summary>
        NET_NOT_SAVING = 0x80000000 | 18,
        /// <summary>
        /// Error occurs when opening the file
        /// </summary>
        NET_OPEN_FILE_ERROR = 0x80000000 | 19,
        /// <summary>
        /// Failed to enable PTZ to control timer
        /// </summary>
        NET_PTZ_SET_TIMER_ERROR = 0x80000000 | 20,
        /// <summary>
        /// Error occurs when verify returned data
        /// </summary>
        NET_RETURN_DATA_ERROR = 0x80000000 | 21,
        /// <summary>
        /// There is no sufficient buffer
        /// </summary>
        NET_INSUFFICIENT_BUFFER = 0x80000000 | 22,
        /// <summary>
        /// The current SDK does not support this fucntion
        /// </summary>
        NET_NOT_SUPPORTED = 0x80000000 | 23,
        /// <summary>
        /// There is no searched result
        /// </summary>
        NET_NO_RECORD_FOUND = 0x80000000 | 24,
        /// <summary>
        /// You have no operation right
        /// </summary>
        NET_NOT_AUTHORIZED = 0x80000000 | 25,
        /// <summary>
        /// Can not operate right now
        /// </summary>
        NET_NOT_NOW = 0x80000000 | 26,
        /// <summary>
        /// There is no audio talk channel
        /// </summary>
        NET_NO_TALK_CHANNEL = 0x80000000 | 27,
        /// <summary>
        /// There is no audio
        /// </summary>
        NET_NO_AUDIO = 0x80000000 | 28,
        /// <summary>
        /// The network SDK has not been initialized
        /// </summary>
        NET_NO_INIT = 0x80000000 | 29,
        /// <summary>
        /// The download completed
        /// </summary>
        NET_DOWNLOAD_END = 0x80000000 | 30,
        /// <summary>
        /// There is no searched result
        /// </summary>
        NET_EMPTY_LIST = 0x80000000 | 31,
        /// <summary>
        /// Failed to get system property setup
        /// </summary>
        NET_ERROR_GETCFG_SYSATTR = 0x80000000 | 32,
        /// <summary>
        /// Failed to get SN
        /// </summary>
        NET_ERROR_GETCFG_SERIAL = 0x80000000 | 33,
        /// <summary>
        /// Failed to get general property
        /// </summary>
        NET_ERROR_GETCFG_GENERAL = 0x80000000 | 34,
        /// <summary>
        /// Failed to get DSP capacity description
        /// </summary>
        NET_ERROR_GETCFG_DSPCAP = 0x80000000 | 35,
        /// <summary>
        /// Failed to get network channel setup
        /// </summary>
        NET_ERROR_GETCFG_NETCFG = 0x80000000 | 36,
        /// <summary>
        /// Failed to get channel name
        /// </summary>
        NET_ERROR_GETCFG_CHANNAME = 0x80000000 | 37,
        /// <summary>
        /// Failed to get video property
        /// </summary>
        NET_ERROR_GETCFG_VIDEO = 0x80000000 | 38,
        /// <summary>
        /// Failed to get record setup
        /// </summary>
        NET_ERROR_GETCFG_RECORD = 0x80000000 | 39,
        /// <summary>
        /// Failed to get decoder protocol name
        /// </summary>
        NET_ERROR_GETCFG_PRONAME = 0x80000000 | 40,
        /// <summary>
        /// Failed to get 232 COM function name
        /// </summary>
        NET_ERROR_GETCFG_FUNCNAME = 0x80000000 | 41,
        /// <summary>
        /// Failed to get decoder property
        /// </summary>
        NET_ERROR_GETCFG_485DECODER = 0x80000000 | 42,
        /// <summary>
        /// Failed to get 232 COM setup
        /// </summary>
        NET_ERROR_GETCFG_232COM = 0x80000000 | 43,
        /// <summary>
        /// Failed to get external alarm input setup
        /// </summary>
        NET_ERROR_GETCFG_ALARMIN = 0x80000000 | 44,
        /// <summary>
        /// Failed to get motion detection alarm
        /// </summary>
        NET_ERROR_GETCFG_ALARMDET = 0x80000000 | 45,
        /// <summary>
        /// Failed to get device time
        /// </summary>
        NET_ERROR_GETCFG_SYSTIME = 0x80000000 | 46,
        /// <summary>
        /// Failed to get preview parameter
        /// </summary>
        NET_ERROR_GETCFG_PREVIEW = 0x80000000 | 47,
        /// <summary>
        /// Failed to get audio maintenance setup
        /// </summary>
        NET_ERROR_GETCFG_AUTOMT = 0x80000000 | 48,
        /// <summary>
        /// Failed to get video matrix setup
        /// </summary>
        NET_ERROR_GETCFG_VIDEOMTRX = 0x80000000 | 49,
        /// <summary>
        /// Failed to get privacy mask zone setup
        /// </summary>
        NET_ERROR_GETCFG_COVER = 0x80000000 | 50,
        /// <summary>
        /// Failed to get video watermark setup
        /// </summary>
        NET_ERROR_GETCFG_WATERMAKE = 0x80000000 | 51,
        /// <summary>
        /// Failed to get config￡omulticast port by channel
        /// </summary>
        NET_ERROR_GETCFG_MULTICAST = 0x80000000 | 52,
        /// <summary>
        /// Failed to modify general property
        /// </summary>
        NET_ERROR_SETCFG_GENERAL = 0x80000000 | 55,
        /// <summary>
        /// Failed to modify channel setup
        /// </summary>
        NET_ERROR_SETCFG_NETCFG = 0x80000000 | 56,
        /// <summary>
        /// Failed to modify channel name
        /// </summary>
        NET_ERROR_SETCFG_CHANNAME = 0x80000000 | 57,
        /// <summary>
        /// Failed to modify video channel
        /// </summary>
        NET_ERROR_SETCFG_VIDEO = 0x80000000 | 58,
        /// <summary>
        /// Failed to modify record setup
        /// </summary>
        NET_ERROR_SETCFG_RECORD = 0x80000000 | 59,
        /// <summary>
        /// Failed to modify decoder property 
        /// </summary>
        NET_ERROR_SETCFG_485DECODER = 0x80000000 | 60,
        /// <summary>
        /// Failed to modify 232 COM setup
        /// </summary>
        NET_ERROR_SETCFG_232COM = 0x80000000 | 61,
        /// <summary>
        /// Failed to modify external input alarm setup
        /// </summary>
        NET_ERROR_SETCFG_ALARMIN = 0x80000000 | 62,
        /// <summary>
        /// Failed to modify motion detection alarm setup
        /// </summary>
        NET_ERROR_SETCFG_ALARMDET = 0x80000000 | 63,
        /// <summary>
        /// Failed to modify device time
        /// </summary>
        NET_ERROR_SETCFG_SYSTIME = 0x80000000 | 64,
        /// <summary>
        /// Failed to modify preview parameter
        /// </summary>
        NET_ERROR_SETCFG_PREVIEW = 0x80000000 | 65,
        /// <summary>
        /// Failed to modify auto maintenance setup
        /// </summary>
        NET_ERROR_SETCFG_AUTOMT = 0x80000000 | 66,
        /// <summary>
        /// Failed to modify video matrix setup
        /// </summary>
        NET_ERROR_SETCFG_VIDEOMTRX = 0x80000000 | 67,
        /// <summary>
        /// Failed to modify privacy mask zone
        /// </summary>
        NET_ERROR_SETCFG_COVER = 0x80000000 | 68,
        /// <summary>
        /// Failed to modify video watermark setup
        /// </summary>
        NET_ERROR_SETCFG_WATERMAKE = 0x80000000 | 69,
        /// <summary>
        /// Failed to modify wireless network information
        /// </summary>
        NET_ERROR_SETCFG_WLAN = 0x80000000 | 70,
        /// <summary>
        /// Failed to select wireless network device
        /// </summary>
        NET_ERROR_SETCFG_WLANDEV = 0x80000000 | 71,
        /// <summary>
        /// Failed to modify the actively registration parameter setup
        /// </summary>
        NET_ERROR_SETCFG_REGISTER = 0x80000000 | 72,
        /// <summary>
        /// Failed to modify camera property
        /// </summary>
        NET_ERROR_SETCFG_CAMERA = 0x80000000 | 73,
        /// <summary>
        /// Failed to modify IR alarm setup
        /// </summary>
        NET_ERROR_SETCFG_INFRARED = 0x80000000 | 74,
        /// <summary>
        /// Failed to modify audio alarm setup
        /// </summary>
        NET_ERROR_SETCFG_SOUNDALARM = 0x80000000 | 75,
        /// <summary>
        /// Failed to modify storage position setup
        /// </summary>
        NET_ERROR_SETCFG_STORAGE = 0x80000000 | 76,
        /// <summary>
        /// The audio encode port has not been successfully initialized
        /// </summary>
        NET_AUDIOENCODE_NOTINIT = 0x80000000 | 77,
        /// <summary>
        /// The data are too long
        /// </summary>
        NET_DATA_TOOLONGH = 0x80000000 | 78,
        /// <summary>
        /// The device does not support current operation
        /// </summary>
        NET_UNSUPPORTED = 0x80000000 | 79,
        /// <summary>
        /// Device resources is not sufficient
        /// </summary>
        NET_DEVICE_BUSY = 0x80000000 | 80,
        /// <summary>
        /// The server has boot up
        /// </summary>
        NET_SERVER_STARTED = 0x80000000 | 81,
        /// <summary>
        /// The server has not fully boot up
        /// </summary>
        NET_SERVER_STOPPED = 0x80000000 | 82,
        /// <summary>
        /// Input serial number is not correct
        /// </summary>
        NET_LISTER_INCORRECT_SERIAL = 0x80000000 | 83,
        /// <summary>
        /// Failed to get HDD information
        /// </summary>
        NET_QUERY_DISKINFO_FAILED = 0x80000000 | 84,
        /// <summary>
        /// Failed to get connect session information
        /// </summary>
        NET_ERROR_GETCFG_SESSION = 0x80000000 | 85,
        /// <summary>
        /// The password you typed is incorrect. You have exceeded the maximum number of retries
        /// </summary>
        NET_USER_FLASEPWD_TRYTIME = 0x80000000 | 86,
        /// <summary>
        /// Password is not correct
        /// </summary>
        NET_LOGIN_ERROR_PASSWORD = 0x80000000 | 100,
        /// <summary>
        /// The account does not exist
        /// </summary>
        NET_LOGIN_ERROR_USER = 0x80000000 | 101,
        /// <summary>
        /// Time out for log in returned value
        /// </summary>
        NET_LOGIN_ERROR_TIMEOUT = 0x80000000 | 102,
        /// <summary>
        /// The account has logged in
        /// </summary>
        NET_LOGIN_ERROR_RELOGGIN = 0x80000000 | 103,
        /// <summary>
        /// The account has been locked
        /// </summary>
        NET_LOGIN_ERROR_LOCKED = 0x80000000 | 104,
        /// <summary>
        /// The account bas been in the BL
        /// </summary>
        NET_LOGIN_ERROR_BLACKLIST = 0x80000000 | 105,
        /// <summary>
        /// Resources are not sufficient. System is busy now
        /// </summary>
        NET_LOGIN_ERROR_BUSY = 0x80000000 | 106,
        /// <summary>
        /// Time out. Please check network and try again
        /// </summary>
        NET_LOGIN_ERROR_CONNECT = 0x80000000 | 107,
        /// <summary>
        /// Network connection failed
        /// </summary>
        NET_LOGIN_ERROR_NETWORK = 0x80000000 | 108,
        /// <summary>
        /// Successfully logged in the device but can not create video channel. Please check network connection
        /// </summary>
        NET_LOGIN_ERROR_SUBCONNECT = 0x80000000 | 109,
        /// <summary>
        /// exceed the max connect number
        /// </summary>
        NET_LOGIN_ERROR_MAXCONNECT = 0x80000000 | 110,
        /// <summary>
        /// protocol 3 support
        /// </summary>
        NET_LOGIN_ERROR_PROTOCOL3_ONLY = 0x80000000 | 111,
        /// <summary>
        /// There is no USB or USB info error
        /// </summary>
        NET_LOGIN_ERROR_UKEY_LOST = 0x80000000 | 112,
        /// <summary>
        /// Client-end IP address has no right to login
        /// </summary>
        NET_LOGIN_ERROR_NO_AUTHORIZED = 0x80000000 | 113,
        /// <summary>
        /// user or password error
        /// </summary>
        NET_LOGIN_ERROR_USER_OR_PASSOWRD = 0X80000000 | 117,
        /// <summary>
        /// Error occurs when Render library open audio
        /// </summary>
        NET_RENDER_SOUND_ON_ERROR = 0x80000000 | 120,
        /// <summary>
        /// Error occurs when Render library close audio
        /// </summary>
        NET_RENDER_SOUND_OFF_ERROR = 0x80000000 | 121,
        /// <summary>
        /// Error occurs when Render library control volume
        /// </summary>
        NET_RENDER_SET_VOLUME_ERROR = 0x80000000 | 122,
        /// <summary>
        /// Error occurs when Render library set video parameter
        /// </summary>
        NET_RENDER_ADJUST_ERROR = 0x80000000 | 123,
        /// <summary>
        /// Error occurs when Render library pause play
        /// </summary>
        NET_RENDER_PAUSE_ERROR = 0x80000000 | 124,
        /// <summary>
        /// Render library snapshot error
        /// </summary>
        NET_RENDER_SNAP_ERROR = 0x80000000 | 125,
        /// <summary>
        /// Render library stepper error
        /// </summary>
        NET_RENDER_STEP_ERROR = 0x80000000 | 126,
        /// <summary>
        /// Error occurs when Render library set frame rate
        /// </summary>
        NET_RENDER_FRAMERATE_ERROR = 0x80000000 | 127,
        /// <summary>
        /// Error occurs when Render lib setting show region
        /// </summary>
        NET_RENDER_DISPLAYREGION_ERROR = 0x80000000 | 128,
        /// <summary>
        /// An error occurred when Render library getting current play time
        /// </summary>
        NET_RENDER_GETOSDTIME_ERROR = 0x80000000 | 129,
        /// <summary>
        /// Group name has been existed
        /// </summary>
        NET_GROUP_EXIST = 0x80000000 | 140,
        /// <summary>
        /// The group name does not exist
        /// </summary>
        NET_GROUP_NOEXIST = 0x80000000 | 141,
        /// <summary>
        /// The group right exceeds the right list
        /// </summary>
        NET_GROUP_RIGHTOVER = 0x80000000 | 142,
        /// <summary>
        /// The group can not be removed since there is user in it
        /// </summary>
        NET_GROUP_HAVEUSER = 0x80000000 | 143,
        /// <summary>
        /// The user has used one of the group right. It can not be removed
        /// </summary>
        NET_GROUP_RIGHTUSE = 0x80000000 | 144,
        /// <summary>
        /// New group name has been existed
        /// </summary>
        NET_GROUP_SAMENAME = 0x80000000 | 145,
        /// <summary>
        /// The user name has been existed
        /// </summary>
        NET_USER_EXIST = 0x80000000 | 146,
        /// <summary>
        /// The account does not exist
        /// </summary>
        NET_USER_NOEXIST = 0x80000000 | 147,
        /// <summary>
        /// User right exceeds the group right
        /// </summary>
        NET_USER_RIGHTOVER = 0x80000000 | 148,
        /// <summary>
        /// Reserved account. It does not allow to be modified
        /// </summary>
        NET_USER_PWD = 0x80000000 | 149,
        /// <summary>
        /// password is not correct
        /// </summary>
        NET_USER_FLASEPWD = 0x80000000 | 150,
        /// <summary>
        /// Password is invalid
        /// </summary>
        NET_USER_NOMATCHING = 0x80000000 | 151,
        /// <summary>
        /// account in use
        /// </summary>
        NET_USER_INUSE = 0x80000000 | 152,
        /// <summary>
        /// Failed to get network card setup
        /// </summary>
        NET_ERROR_GETCFG_ETHERNET = 0x80000000 | 300,
        /// <summary>
        /// Failed to get wireless network information
        /// </summary>
        NET_ERROR_GETCFG_WLAN = 0x80000000 | 301,
        /// <summary>
        /// Failed to get wireless network device
        /// </summary>
        NET_ERROR_GETCFG_WLANDEV = 0x80000000 | 302,
        /// <summary>
        /// Failed to get actively registration parameter
        /// </summary>
        NET_ERROR_GETCFG_REGISTER = 0x80000000 | 303,
        /// <summary>
        /// Failed to get camera property
        /// </summary>
        NET_ERROR_GETCFG_CAMERA = 0x80000000 | 304,
        /// <summary>
        /// Failed to get IR alarm setup
        /// </summary>
        NET_ERROR_GETCFG_INFRARED = 0x80000000 | 305,
        /// <summary>
        /// Failed to get audio alarm setup
        /// </summary>
        NET_ERROR_GETCFG_SOUNDALARM = 0x80000000 | 306,
        /// <summary>
        /// Failed to get storage position
        /// </summary>
        NET_ERROR_GETCFG_STORAGE = 0x80000000 | 307,
        /// <summary>
        /// Failed to get mail setup.
        /// </summary>
        NET_ERROR_GETCFG_MAIL = 0x80000000 | 308,
        /// <summary>
        /// Can not set right now.
        /// </summary>
        NET_CONFIG_DEVBUSY = 0x80000000 | 309,
        /// <summary>
        /// The configuration setup data are illegal.
        /// </summary>
        NET_CONFIG_DATAILLEGAL = 0x80000000 | 310,
        /// <summary>
        /// Failed to get DST setup
        /// </summary>
        NET_ERROR_GETCFG_DST = 0x80000000 | 311,
        /// <summary>
        /// Failed to set DST
        /// </summary>
        NET_ERROR_SETCFG_DST = 0x80000000 | 312,
        /// <summary>
        /// Failed to get video osd setup.
        /// </summary>
        NET_ERROR_GETCFG_VIDEO_OSD = 0x80000000 | 313,
        /// <summary>
        /// Failed to set video osd
        /// </summary>
        NET_ERROR_SETCFG_VIDEO_OSD = 0x80000000 | 314,
        /// <summary>
        /// Failed to get CDMA\GPRS configuration
        /// </summary>
        NET_ERROR_GETCFG_GPRSCDMA = 0x80000000 | 315,
        /// <summary>
        /// Failed to set CDMA\GPRS configuration
        /// </summary>
        NET_ERROR_SETCFG_GPRSCDMA = 0x80000000 | 316,
        /// <summary>
        /// Failed to get IP Filter configuration
        /// </summary>
        NET_ERROR_GETCFG_IPFILTER = 0x80000000 | 317,
        /// <summary>
        /// Failed to set IP Filter configuration
        /// </summary>
        NET_ERROR_SETCFG_IPFILTER = 0x80000000 | 318,
        /// <summary>
        /// Failed to get Talk Encode configuration
        /// </summary>
        NET_ERROR_GETCFG_TALKENCODE = 0x80000000 | 319,
        /// <summary>
        /// Failed to set Talk Encode configuration
        /// </summary>
        NET_ERROR_SETCFG_TALKENCODE = 0x80000000 | 320,
        /// <summary>
        /// Failed to get The length of the video package configuration
        /// </summary>
        NET_ERROR_GETCFG_RECORDLEN = 0x80000000 | 321,
        /// <summary>
        /// Failed to set The length of the video package configuration
        /// </summary>
        NET_ERROR_SETCFG_RECORDLEN = 0x80000000 | 322,
        /// <summary>
        /// Not support Network hard disk partition
        /// </summary>
        NET_DONT_SUPPORT_SUBAREA = 0x80000000 | 323,
        /// <summary>
        /// Failed to get the register server information
        /// </summary>
        NET_ERROR_GET_AUTOREGSERVER = 0x80000000 | 324,
        /// <summary>
        /// Failed to control actively registration
        /// </summary>
        NET_ERROR_CONTROL_AUTOREGISTER = 0x80000000 | 325,
        /// <summary>
        /// Failed to disconnect actively registration
        /// </summary>
        NET_ERROR_DISCONNECT_AUTOREGISTER = 0x80000000 | 326,
        /// <summary>
        /// Failed to get mms configuration
        /// </summary>
        NET_ERROR_GETCFG_MMS = 0x80000000 | 327,
        /// <summary>
        /// Failed to set mms configuration
        /// </summary>
        NET_ERROR_SETCFG_MMS = 0x80000000 | 328,
        /// <summary>
        /// Failed to get SMS configuration
        /// </summary>
        NET_ERROR_GETCFG_SMSACTIVATION = 0x80000000 | 329,
        /// <summary>
        /// Failed to set SMS configuration
        /// </summary>
        NET_ERROR_SETCFG_SMSACTIVATION = 0x80000000 | 330,
        /// <summary>
        /// Failed to get activation of a wireless connection
        /// </summary>
        NET_ERROR_GETCFG_DIALINACTIVATION = 0x80000000 | 331,
        /// <summary>
        /// Failed to set activation of a wireless connection
        /// </summary>
        NET_ERROR_SETCFG_DIALINACTIVATION = 0x80000000 | 332,
        /// <summary>
        /// Failed to get the parameter of video output
        /// </summary>
        NET_ERROR_GETCFG_VIDEOOUT = 0x80000000 | 333,
        /// <summary>
        /// Failed to set the configuration of video output
        /// </summary>
        NET_ERROR_SETCFG_VIDEOOUT = 0x80000000 | 334,
        /// <summary>
        /// Failed to get osd overlay enabling
        /// </summary>
        NET_ERROR_GETCFG_OSDENABLE = 0x80000000 | 335,
        /// <summary>
        /// Failed to set OSD overlay enabling
        /// </summary>
        NET_ERROR_SETCFG_OSDENABLE = 0x80000000 | 336,
        /// <summary>
        /// Failed to set digital input configuration of front encoders
        /// </summary>
        NET_ERROR_SETCFG_ENCODERINFO = 0x80000000 | 337,
        /// <summary>
        /// Failed to get TV adjust configuration
        /// </summary>
        NET_ERROR_GETCFG_TVADJUST = 0x80000000 | 338,
        /// <summary>
        /// Failed to set TV adjust configuration
        /// </summary>
        NET_ERROR_SETCFG_TVADJUST = 0x80000000 | 339,
        /// <summary>
        /// Failed to request to establish a connection
        /// </summary>
        NET_ERROR_CONNECT_FAILED = 0x80000000 | 340,
        /// <summary>
        /// Failed to request to upload burn files
        /// </summary>
        NET_ERROR_SETCFG_BURNFILE = 0x80000000 | 341,
        /// <summary>
        /// Failed to get capture configuration information
        /// </summary>
        NET_ERROR_SNIFFER_GETCFG = 0x80000000 | 342,
        /// <summary>
        /// Failed to set capture configuration information
        /// </summary>
        NET_ERROR_SNIFFER_SETCFG = 0x80000000 | 343,
        /// <summary>
        /// Failed to get download restrictions information
        /// </summary>
        NET_ERROR_DOWNLOADRATE_GETCFG = 0x80000000 | 344,
        /// <summary>
        /// Failed to set download restrictions information
        /// </summary>
        NET_ERROR_DOWNLOADRATE_SETCFG = 0x80000000 | 345,
        /// <summary>
        /// Failed to query serial port parameters
        /// </summary>
        NET_ERROR_SEARCH_TRANSCOM = 0x80000000 | 346,
        /// <summary>
        /// Failed to get the preset info
        /// </summary>
        NET_ERROR_GETCFG_POINT = 0x80000000 | 347,
        /// <summary>
        /// Failed to set the preset info
        /// </summary>
        NET_ERROR_SETCFG_POINT = 0x80000000 | 348,
        /// <summary>
        /// SDK log out the device abnormally
        /// </summary>
        NET_SDK_LOGOUT_ERROR = 0x80000000 | 349,
        /// <summary>
        /// Failed to get vehicle configuration
        /// </summary>
        NET_ERROR_GET_VEHICLE_CFG = 0x80000000 | 350,
        /// <summary>
        /// Failed to set vehicle configuration
        /// </summary>
        NET_ERROR_SET_VEHICLE_CFG = 0x80000000 | 351,
        /// <summary>
        /// Failed to get ATM overlay configuration
        /// </summary>
        NET_ERROR_GET_ATM_OVERLAY_CFG = 0x80000000 | 352,
        /// <summary>
        /// Failed to set ATM overlay configuration
        /// </summary>
        NET_ERROR_SET_ATM_OVERLAY_CFG = 0x80000000 | 353,
        /// <summary>
        /// Failed to get ATM overlay ability
        /// </summary>
        NET_ERROR_GET_ATM_OVERLAY_ABILITY = 0x80000000 | 354,
        /// <summary>
        /// Failed to get decoder tour configuration
        /// </summary>
        NET_ERROR_GET_DECODER_TOUR_CFG = 0x80000000 | 355,
        /// <summary>
        /// Failed to set decoder tour configuration
        /// </summary>
        NET_ERROR_SET_DECODER_TOUR_CFG = 0x80000000 | 356,
        /// <summary>
        /// Failed to control decoder tour
        /// </summary>
        NET_ERROR_CTRL_DECODER_TOUR = 0x80000000 | 357,
        /// <summary>
        /// Beyond the device supports for the largest number of user groups
        /// </summary>
        NET_GROUP_OVERSUPPORTNUM = 0x80000000 | 358,
        /// <summary>
        /// Beyond the device supports for the largest number of users
        /// </summary>
        NET_USER_OVERSUPPORTNUM = 0x80000000 | 359,
        /// <summary>
        /// Failed to get SIP configuration
        /// </summary>
        NET_ERROR_GET_SIP_CFG = 0x80000000 | 368,
        /// <summary>
        /// Failed to set SIP configuration
        /// </summary>
        NET_ERROR_SET_SIP_CFG = 0x80000000 | 369,
        /// <summary>
        /// Failed to get SIP capability
        /// </summary>
        NET_ERROR_GET_SIP_ABILITY = 0x80000000 | 370,
        /// <summary>
        /// Failed to get "WIFI ap' configuration
        /// </summary>
        NET_ERROR_GET_WIFI_AP_CFG = 0x80000000 | 371,
        /// <summary>
        /// Failed to set "WIFI ap" configuration
        /// </summary>
        NET_ERROR_SET_WIFI_AP_CFG = 0x80000000 | 372,
        /// <summary>
        /// Failed to get decode policy
        /// </summary>
        NET_ERROR_GET_DECODE_POLICY = 0x80000000 | 373,
        /// <summary>
        /// Failed to set decode policy
        /// </summary>
        NET_ERROR_SET_DECODE_POLICY = 0x80000000 | 374,
        /// <summary>
        /// refuse talk
        /// </summary>
        NET_ERROR_TALK_REJECT = 0x80000000 | 375,
        /// <summary>
        /// talk has opened by other client
        /// </summary>
        NET_ERROR_TALK_OPENED = 0x80000000 | 376,
        /// <summary>
        /// resource conflict
        /// </summary>
        NET_ERROR_TALK_RESOURCE_CONFLICIT = 0x80000000 | 377,
        /// <summary>
        /// unsupported encode type
        /// </summary>
        NET_ERROR_TALK_UNSUPPORTED_ENCODE = 0x80000000 | 378,
        /// <summary>
        /// no right
        /// </summary>
        NET_ERROR_TALK_RIGHTLESS = 0x80000000 | 379,
        /// <summary>
        /// request failed
        /// </summary>
        NET_ERROR_TALK_FAILED = 0x80000000 | 380,
        /// <summary>
        /// Failed to get device relative config
        /// </summary>
        NET_ERROR_GET_MACHINE_CFG = 0x80000000 | 381,
        /// <summary>
        /// Failed to set device relative config
        /// </summary>
        NET_ERROR_SET_MACHINE_CFG = 0x80000000 | 382,
        /// <summary>
        /// get data failed
        /// </summary>
        NET_ERROR_GET_DATA_FAILED = 0x80000000 | 383,
        /// <summary>
        /// MAC validate failed
        /// </summary>
        NET_ERROR_MAC_VALIDATE_FAILED = 0x80000000 | 384,
        /// <summary>
        /// Failed to get server instance 
        /// </summary>
        NET_ERROR_GET_INSTANCE = 0x80000000 | 385,
        /// <summary>
        /// Generated json string is error
        /// </summary>
        NET_ERROR_JSON_REQUEST = 0x80000000 | 386,
        /// <summary>
        /// The responding json string is error
        /// </summary>
        NET_ERROR_JSON_RESPONSE = 0x80000000 | 387,
        /// <summary>
        /// The protocol version is lower than current version
        /// </summary>
        NET_ERROR_VERSION_HIGHER = 0x80000000 | 388,
        /// <summary>
        /// Hotspare disk operation failed. The capacity is low
        /// </summary>
        NET_SPARE_NO_CAPACITY = 0x80000000 | 389,
        /// <summary>
        /// Display source is used by other output
        /// </summary>
        NET_ERROR_SOURCE_IN_USE = 0x80000000 | 390,
        /// <summary>
        /// advanced users grab low-level user resource
        /// </summary>
        NET_ERROR_REAVE = 0x80000000 | 391,
        /// <summary>
        /// net forbid
        /// </summary>
        NET_ERROR_NETFORBID = 0x80000000 | 392,
        /// <summary>
        /// get MAC filter configuration error
        /// </summary>
        NET_ERROR_GETCFG_MACFILTER = 0x80000000 | 393,
        /// <summary>
        /// set MAC filter configuration error
        /// </summary>
        NET_ERROR_SETCFG_MACFILTER = 0x80000000 | 394,
        /// <summary>
        /// get IP/MAC filter configuration error
        /// </summary>
        NET_ERROR_GETCFG_IPMACFILTER = 0x80000000 | 395,
        /// <summary>
        /// set IP/MAC filter configuration error
        /// </summary>
        NET_ERROR_SETCFG_IPMACFILTER = 0x80000000 | 396,
        /// <summary>
        /// operation over time 
        /// </summary>
        NET_ERROR_OPERATION_OVERTIME = 0x80000000 | 397,
        /// <summary>
        /// senior validation failure
        /// </summary>
        NET_ERROR_SENIOR_VALIDATE_FAILED = 0x80000000 | 398,
        /// <summary>
        /// device ID is not exist
        /// </summary>
        NET_ERROR_DEVICE_ID_NOT_EXIST = 0x80000000 | 399,
        /// <summary>
        /// unsupport operation
        /// </summary>
        NET_ERROR_UNSUPPORTED = 0x80000000 | 400,
        /// <summary>
        /// proxy dll load error
        /// </summary>
        NET_ERROR_PROXY_DLLLOAD = 0x80000000 | 401,
        /// <summary>
        /// proxy user parameter is not legal
        /// </summary>
        NET_ERROR_PROXY_ILLEGAL_PARAM = 0x80000000 | 402,
        /// <summary>
        /// handle invalid
        /// </summary>
        NET_ERROR_PROXY_INVALID_HANDLE = 0x80000000 | 403,
        /// <summary>
        /// login device error
        /// </summary>
        NET_ERROR_PROXY_LOGIN_DEVICE_ERROR = 0x80000000 | 404,
        /// <summary>
        /// start proxy server error
        /// </summary>
        NET_ERROR_PROXY_START_SERVER_ERROR = 0x80000000 | 405,
        /// <summary>
        /// request speak failed
        /// </summary>
        NET_ERROR_SPEAK_FAILED = 0x80000000 | 406,
        /// <summary>
        /// unsupport F6
        /// </summary>
        NET_ERROR_NOT_SUPPORT_F6 = 0x80000000 | 407,
        /// <summary>
        /// CD is not ready
        /// </summary>
        NET_ERROR_CD_UNREADY = 0x80000000 | 408,
        /// <summary>
        /// Directory does not exist
        /// </summary>
        NET_ERROR_DIR_NOT_EXIST = 0x80000000 | 409,
        /// <summary>
        /// The device does not support the segmentation model
        /// </summary>
        NET_ERROR_UNSUPPORTED_SPLIT_MODE = 0x80000000 | 410,
        /// <summary>
        /// Open the window parameter is illegal
        /// </summary>
        NET_ERROR_OPEN_WND_PARAM = 0x80000000 | 411,
        /// <summary>
        /// Open the window more than limit
        /// </summary>
        NET_ERROR_LIMITED_WND_COUNT = 0x80000000 | 412,
        /// <summary>
        /// Request command with the current pattern don't match
        /// </summary>
        NET_ERROR_UNMATCHED_REQUEST = 0x80000000 | 413,
        /// <summary>
        /// Render Library to enable high-definition image internal adjustment strategy error
        /// </summary>
        NET_RENDER_ENABLELARGEPICADJUSTMENT_ERROR = 0x80000000 | 414,
        /// <summary>
        /// Upgrade equipment failure
        /// </summary>
        NET_ERROR_UPGRADE_FAILED = 0x80000000 | 415,
        /// <summary>
        /// Can't find the target device
        /// </summary>
        NET_ERROR_NO_TARGET_DEVICE = 0x80000000 | 416,
        /// <summary>
        /// Can't find the verify device
        /// </summary>
        NET_ERROR_NO_VERIFY_DEVICE = 0x80000000 | 417,
        /// <summary>
        /// No cascade permissions
        /// </summary>
        NET_ERROR_CASCADE_RIGHTLESS = 0x80000000 | 418,
        /// <summary>
        /// low priority
        /// </summary>
        NET_ERROR_LOW_PRIORITY = 0x80000000 | 419,
        /// <summary>
        /// The remote device request timeout
        /// </summary>
        NET_ERROR_REMOTE_REQUEST_TIMEOUT = 0x80000000 | 420,
        /// <summary>
        /// Input source beyond maximum route restrictions
        /// </summary>
        NET_ERROR_LIMITED_INPUT_SOURCE = 0x80000000 | 421,
        /// <summary>
        /// Failed to set log print
        /// </summary>
        NET_ERROR_SET_LOG_PRINT_INFO = 0x80000000 | 422,
        /// <summary>
        /// "dwSize" is not initialized in input param
        /// </summary>
        NET_ERROR_PARAM_DWSIZE_ERROR = 0x80000000 | 423,
        /// <summary>
        /// TV wall exceed limit
        /// </summary>
        NET_ERROR_LIMITED_MONITORWALL_COUNT = 0x80000000 | 424,
        /// <summary>
        /// Fail to execute part of the process
        /// </summary>
        NET_ERROR_PART_PROCESS_FAILED = 0x80000000 | 425,
        /// <summary>
        /// Fail to transmit due to not supported by target
        /// </summary>
        NET_ERROR_TARGET_NOT_SUPPORT = 0x80000000 | 426,
        /// <summary>
        /// Access to the file failed
        /// </summary>
        NET_ERROR_VISITE_FILE = 0x80000000 | 510,
        /// <summary>
        /// Device busy
        /// </summary>
        NET_ERROR_DEVICE_STATUS_BUSY = 0x80000000 | 511,
        /// <summary>
        /// Fail to change the password
        /// </summary>
        NET_USER_PWD_NOT_AUTHORIZED = 0x80000000 | 512,
        /// <summary>
        /// Password strength is not enough
        /// </summary>
        NET_USER_PWD_NOT_STRONG = 0x80000000 | 513,
        /// <summary>
        /// No corresponding setup
        /// </summary>
        NET_ERROR_NO_SUCH_CONFIG = 0x80000000 | 514,
        /// <summary>
        /// Failed to record audio
        /// </summary>
        NET_ERROR_AUDIO_RECORD_FAILED = 0x80000000 | 515,
        /// <summary>
        /// Failed to send out data
        /// </summary>
        NET_ERROR_SEND_DATA_FAILED = 0x80000000 | 516,
        /// <summary>
        /// Abandoned port
        /// </summary>
        NET_ERROR_OBSOLESCENT_INTERFACE = 0x80000000 | 517,
        /// <summary>
        /// Internal buffer is not sufficient 
        /// </summary>
        NET_ERROR_INSUFFICIENT_INTERAL_BUF = 0x80000000 | 518,
        /// <summary>
        /// verify password when changing device IP
        /// </summary>
        NET_ERROR_NEED_ENCRYPTION_PASSWORD = 0x80000000 | 519,
        /// <summary>
        /// device not support the record
        /// </summary>
        NET_ERROR_NOSUPPORT_RECORD = 0x80000000 | 520,
        /// <summary>
        /// Failed to serialize data
        /// </summary>
        NET_ERROR_SERIALIZE_ERROR = 0x80000000 | 1010,
        /// <summary>
        /// Failed to deserialize data
        /// </summary>
        NET_ERROR_DESERIALIZE_ERROR = 0x80000000 | 1011,
        /// <summary>
        /// the wireless id is already existed
        /// </summary>
        NET_ERROR_LOWRATEWPAN_ID_EXISTED = 0x80000000 | 1012,
        /// <summary>
        /// the wireless id limited
        /// </summary>
        NET_ERROR_LOWRATEWPAN_ID_LIMIT = 0x80000000 | 1013,
        /// <summary>
        /// add the wireless id abnormaly
        /// </summary>
        NET_ERROR_LOWRATEWPAN_ID_ABNORMAL = 0x80000000 | 1014,
        /// <summary>
        /// encrypt data fail
        /// </summary>
        NET_ERROR_ENCRYPT = 0x80000000 | 1015,
        /// <summary>
        /// new password illegal
        /// </summary>
        NET_ERROR_PWD_ILLEGAL = 0x80000000 | 1016,
        /// <summary>
        /// device is already init
        /// </summary>
        NET_ERROR_DEVICE_ALREADY_INIT = 0x80000000 | 1017,
        /// <summary>
        /// security code check out fail
        /// </summary>
        NET_ERROR_SECURITY_CODE = 0x80000000 | 1018,
        /// <summary>
        /// security code out of time
        /// </summary>
        NET_ERROR_SECURITY_CODE_TIMEOUT = 0x80000000 | 1019,
        /// <summary>
        /// get passwd specification fail
        /// </summary>
        NET_ERROR_GET_PWD_SPECI = 0x80000000 | 1020,
        /// <summary>
        /// no authority of operation
        /// </summary>
        NET_ERROR_NO_AUTHORITY_OF_OPERATION = 0x80000000 | 1021,
        /// <summary>
        /// decrypt data fail
        /// </summary>
        NET_ERROR_DECRYPT = 0x80000000 | 1022,
        /// <summary>
        /// 2D code check out fail
        /// </summary>
        NET_ERROR_2D_CODE = 0x80000000 | 1023,
        /// <summary>
        /// invalid request
        /// </summary>
        NET_ERROR_INVALID_REQUEST = 0x80000000 | 1024,
        /// <summary>
        /// pwd reset unabled
         /// </summary>
        NET_ERROR_PWD_RESET_DISABLE = 0x80000000 | 1025,
        /// <summary>
        /// failed to display private data,such as rule box
        /// </summary>
        NET_ERROR_PLAY_PRIVATE_DATA = 0x80000000 | 1026,
        /// <summary>
        /// robot operate failed
        /// </summary>
        NET_ERROR_ROBOT_OPERATE_FAILED = 0x80000000 | 1027,
        /// <summary>
        /// channel has already been opened
        /// </summary>
        NET_ERROR_CHANNEL_ALREADY_OPENED = 0x80000000 | 1033,
        /// <summary>
        /// Group ID exceeds the maximum value
        /// </summary>
        NET_ERROR_FACE_RECOGNITION_SERVER_GROUP_ID_EXCEED = 0x80000000 | 1051,
        /// <summary>
        /// VK info decrypt failed
        /// </summary>
        NET_ERROR_VK_INFO_DECRYPT_FAILED = 0x80000000 | 1117,
        /// <summary>
        /// Device does not support high security level login
        /// </summary>
        ERR_NOT_SUPPORT_HIGHLEVEL_SECURITY_LOGIN = 0x80000000 | 1153,
        /// <summary>
        /// invaild channel
        /// </summary>
        ERR_INTERNAL_INVALID_CHANNEL = 0x90001002,
        /// <summary>
        /// reopen channel failed
        /// </summary>
        ERR_INTERNAL_REOPEN_CHANNEL = 0x90001003,
        /// <summary>
        /// send data failed
        /// </summary>
        ERR_INTERNAL_SEND_DATA = 0x90002008,
        /// <summary>
        /// creat socket failed
        /// </summary>
        ERR_INTERNAL_CREATE_SOCKET = 0x90002003,
        ERR_INTERNAL_LISTEN_FAILED = 0x90010010,
    }
}
