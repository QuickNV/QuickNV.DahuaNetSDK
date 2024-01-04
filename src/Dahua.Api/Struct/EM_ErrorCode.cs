namespace Dahua.Api.Struct
{
    /// <summary>
    /// SDK error code number enumeration
    /// SDK错误码枚举
    /// </summary>
    public enum EM_ErrorCode : uint
    {
        /// <summary>
        /// No error
        /// 没有错误
        /// </summary>
        NET_NOERROR = 0,
        /// <summary>
        /// Unknown error
        /// 未知错误
        /// </summary>
        NET_ERROR = 0xFFFFFFFF,
        /// <summary>
        /// Windows system error
        /// Windows系统错误
        /// </summary>
        NET_SYSTEM_ERROR = 0x80000000 | 1,
        /// <summary>
        /// Protocol error it may result from network timeout
        /// 网络错误,可能是因为网络超时
        /// </summary>
        NET_NETWORK_ERROR = 0x80000000 | 2,
        /// <summary>
        /// Device protocol does not match
        /// 设备协议不匹配
        /// </summary>
        NET_DEV_VER_NOMATCH = 0x80000000 | 3,
        /// <summary>
        /// Handle is invalid
        /// 句柄无效
        /// </summary>
        NET_INVALID_HANDLE = 0x80000000 | 4,
        /// <summary>
        /// Failed to open channel
        /// 打开通道失败
        /// </summary>
        NET_OPEN_CHANNEL_ERROR = 0x80000000 | 5,
        /// <summary>
        /// Failed to close channel
        /// 关闭通道失败
        /// </summary>
        NET_CLOSE_CHANNEL_ERROR = 0x80000000 | 6,
        /// <summary>
        /// User parameter is illegal
        /// 用户参数不合法
        /// </summary>
        NET_ILLEGAL_PARAM = 0x80000000 | 7,
        /// <summary>
        /// SDK initialization error
        /// SDK初始化出错
        /// </summary>
        NET_SDK_INIT_ERROR = 0x80000000 | 8,
        /// <summary>
        /// SDK clear error 
        /// SDK清理出错
        /// </summary>
        NET_SDK_UNINIT_ERROR = 0x80000000 | 9,
        /// <summary>
        /// Error occurs when apply for render resources
        /// 申请render资源出错
        /// </summary>
        NET_RENDER_OPEN_ERROR = 0x80000000 | 10,
        /// <summary>
        /// Error occurs when opening the decoder library
        /// 打开解码库出错
        /// </summary>
        NET_DEC_OPEN_ERROR = 0x80000000 | 11,
        /// <summary>
        /// Error occurs when closing the decoder library
        /// 关闭解码库出错
        /// </summary>
        NET_DEC_CLOSE_ERROR = 0x80000000 | 12,
        /// <summary>
        /// The detected channel number is 0 in multiple-channel preview
        /// 多画面预览中检测到通道数为0
        /// </summary>
        NET_MULTIPLAY_NOCHANNEL = 0x80000000 | 13,
        /// <summary>
        /// Failed to initialize record library
        /// 录音库初始化失败
        /// </summary>
        NET_TALK_INIT_ERROR = 0x80000000 | 14,
        /// <summary>
        /// The record library has not been initialized
        /// 录音库未经初始化
        /// </summary>
        NET_TALK_NOT_INIT = 0x80000000 | 15,
        /// <summary>
        /// Error occurs when sending out audio data
        /// 发送音频数据出错
        /// </summary>
        NET_TALK_SENDDATA_ERROR = 0x80000000 | 16,
        /// <summary>
        /// The real-time has been protected
        /// 实时数据已经处于保存状态
        /// </summary>
        NET_REAL_ALREADY_SAVING = 0x80000000 | 17,
        /// <summary>
        /// The real-time data has not been save
        /// 未保存实时数据
        /// </summary>
        NET_NOT_SAVING = 0x80000000 | 18,
        /// <summary>
        /// Error occurs when opening the file
        /// 打开文件出错
        /// </summary>
        NET_OPEN_FILE_ERROR = 0x80000000 | 19,
        /// <summary>
        /// Failed to enable PTZ to control timer
        /// 启动云台控制定时器失败
        /// </summary>
        NET_PTZ_SET_TIMER_ERROR = 0x80000000 | 20,
        /// <summary>
        /// Error occurs when verify returned data
        /// 对返回数据的校验出错
        /// </summary>
        NET_RETURN_DATA_ERROR = 0x80000000 | 21,
        /// <summary>
        /// There is no sufficient buffer
        /// 没有足够的缓存
        /// </summary>
        NET_INSUFFICIENT_BUFFER = 0x80000000 | 22,
        /// <summary>
        /// The current SDK does not support this fucntion
        /// 当前SDK未支持该功能
        /// </summary>
        NET_NOT_SUPPORTED = 0x80000000 | 23,
        /// <summary>
        /// There is no searched result
        /// 查询不到录象
        /// </summary>
        NET_NO_RECORD_FOUND = 0x80000000 | 24,
        /// <summary>
        /// You have no operation right
        /// 无操作权限
        /// </summary>
        NET_NOT_AUTHORIZED = 0x80000000 | 25,
        /// <summary>
        /// Can not operate right now
        /// 暂时无法执行
        /// </summary>
        NET_NOT_NOW = 0x80000000 | 26,
        /// <summary>
        /// There is no audio talk channel
        /// 未发现对讲通道
        /// </summary>
        NET_NO_TALK_CHANNEL = 0x80000000 | 27,
        /// <summary>
        /// There is no audio
        /// 未发现音频
        /// </summary>
        NET_NO_AUDIO = 0x80000000 | 28,
        /// <summary>
        /// The network SDK has not been initialized
        /// 网络SDK未经初始化
        /// </summary>
        NET_NO_INIT = 0x80000000 | 29,
        /// <summary>
        /// The download completed
        /// 下载已结束
        /// </summary>
        NET_DOWNLOAD_END = 0x80000000 | 30,
        /// <summary>
        /// There is no searched result
        /// 查询结果为空
        /// </summary>
        NET_EMPTY_LIST = 0x80000000 | 31,
        /// <summary>
        /// Failed to get system property setup
        /// 获取系统属性配置失败
        /// </summary>
        NET_ERROR_GETCFG_SYSATTR = 0x80000000 | 32,
        /// <summary>
        /// Failed to get SN
        /// 获取序列号失败
        /// </summary>
        NET_ERROR_GETCFG_SERIAL = 0x80000000 | 33,
        /// <summary>
        /// Failed to get general property
        /// 获取常规属性失败
        /// </summary>
        NET_ERROR_GETCFG_GENERAL = 0x80000000 | 34,
        /// <summary>
        /// Failed to get DSP capacity description
        /// 获取DSP能力描述失败
        /// </summary>
        NET_ERROR_GETCFG_DSPCAP = 0x80000000 | 35,
        /// <summary>
        /// Failed to get network channel setup
        /// 获取网络配置失败
        /// </summary>
        NET_ERROR_GETCFG_NETCFG = 0x80000000 | 36,
        /// <summary>
        /// Failed to get channel name
        /// 获取通道名称失败
        /// </summary>
        NET_ERROR_GETCFG_CHANNAME = 0x80000000 | 37,
        /// <summary>
        /// Failed to get video property
        /// 获取视频属性失败
        /// </summary>
        NET_ERROR_GETCFG_VIDEO = 0x80000000 | 38,
        /// <summary>
        /// Failed to get record setup
        /// 获取录象配置失败
        /// </summary>
        NET_ERROR_GETCFG_RECORD = 0x80000000 | 39,
        /// <summary>
        /// Failed to get decoder protocol name
        /// 获取解码器协议名称失败
        /// </summary>
        NET_ERROR_GETCFG_PRONAME = 0x80000000 | 40,
        /// <summary>
        /// Failed to get 232 COM function name
        /// 获取232串口功能名称失败
        /// </summary>
        NET_ERROR_GETCFG_FUNCNAME = 0x80000000 | 41,
        /// <summary>
        /// Failed to get decoder property
        /// 获取解码器属性失败
        /// </summary>
        NET_ERROR_GETCFG_485DECODER = 0x80000000 | 42,
        /// <summary>
        /// Failed to get 232 COM setup
        /// 获取232串口配置失败
        /// </summary>
        NET_ERROR_GETCFG_232COM = 0x80000000 | 43,
        /// <summary>
        /// Failed to get external alarm input setup
        /// 获取外部报警输入配置失败
        /// </summary>
        NET_ERROR_GETCFG_ALARMIN = 0x80000000 | 44,
        /// <summary>
        /// Failed to get motion detection alarm
        /// 获取动态检测报警失败
        /// </summary>
        NET_ERROR_GETCFG_ALARMDET = 0x80000000 | 45,
        /// <summary>
        /// Failed to get device time
        /// 获取设备时间失败
        /// </summary>
        NET_ERROR_GETCFG_SYSTIME = 0x80000000 | 46,
        /// <summary>
        /// Failed to get preview parameter
        /// 获取预览参数失败
        /// </summary>
        NET_ERROR_GETCFG_PREVIEW = 0x80000000 | 47,
        /// <summary>
        /// Failed to get audio maintenance setup
        /// 获取自动维护配置失败
        /// </summary>
        NET_ERROR_GETCFG_AUTOMT = 0x80000000 | 48,
        /// <summary>
        /// Failed to get video matrix setup
        /// 获取视频矩阵配置失败
        /// </summary>
        NET_ERROR_GETCFG_VIDEOMTRX = 0x80000000 | 49,
        /// <summary>
        /// Failed to get privacy mask zone setup
        /// 获取区域遮挡配置失败
        /// </summary>
        NET_ERROR_GETCFG_COVER = 0x80000000 | 50,
        /// <summary>
        /// Failed to get video watermark setup
        /// 获取图象水印配置失败
        /// </summary>
        NET_ERROR_GETCFG_WATERMAKE = 0x80000000 | 51,
        /// <summary>
        /// Failed to get config￡omulticast port by channel
        /// 获取配置失败位置：组播端口按通道配置
        /// </summary>
        NET_ERROR_GETCFG_MULTICAST = 0x80000000 | 52,
        /// <summary>
        /// Failed to modify general property
        /// 修改常规属性失败
        /// </summary>
        NET_ERROR_SETCFG_GENERAL = 0x80000000 | 55,
        /// <summary>
        /// Failed to modify channel setup
        /// 修改网络配置失败
        /// </summary>
        NET_ERROR_SETCFG_NETCFG = 0x80000000 | 56,
        /// <summary>
        /// Failed to modify channel name
        /// 修改通道名称失败
        /// </summary>
        NET_ERROR_SETCFG_CHANNAME = 0x80000000 | 57,
        /// <summary>
        /// Failed to modify video channel
        /// 修改视频属性失败
        /// </summary>
        NET_ERROR_SETCFG_VIDEO = 0x80000000 | 58,
        /// <summary>
        /// Failed to modify record setup
        /// 修改录象配置失败
        /// </summary>
        NET_ERROR_SETCFG_RECORD = 0x80000000 | 59,
        /// <summary>
        /// Failed to modify decoder property 
        /// 修改解码器属性失败
        /// </summary>
        NET_ERROR_SETCFG_485DECODER = 0x80000000 | 60,
        /// <summary>
        /// Failed to modify 232 COM setup
        /// 修改232串口配置失败
        /// </summary>
        NET_ERROR_SETCFG_232COM = 0x80000000 | 61,
        /// <summary>
        /// Failed to modify external input alarm setup
        /// 修改外部输入报警配置失败
        /// </summary>
        NET_ERROR_SETCFG_ALARMIN = 0x80000000 | 62,
        /// <summary>
        /// Failed to modify motion detection alarm setup
        /// 修改动态检测报警配置失败
        /// </summary>
        NET_ERROR_SETCFG_ALARMDET = 0x80000000 | 63,
        /// <summary>
        /// Failed to modify device time
        /// 修改设备时间失败
        /// </summary>
        NET_ERROR_SETCFG_SYSTIME = 0x80000000 | 64,
        /// <summary>
        /// Failed to modify preview parameter
        /// 修改预览参数失败
        /// </summary>
        NET_ERROR_SETCFG_PREVIEW = 0x80000000 | 65,
        /// <summary>
        /// Failed to modify auto maintenance setup
        /// 修改自动维护配置失败
        /// </summary>
        NET_ERROR_SETCFG_AUTOMT = 0x80000000 | 66,
        /// <summary>
        /// Failed to modify video matrix setup
        /// 修改视频矩阵配置失败
        /// </summary>
        NET_ERROR_SETCFG_VIDEOMTRX = 0x80000000 | 67,
        /// <summary>
        /// Failed to modify privacy mask zone
        /// 修改区域遮挡配置失败
        /// </summary>
        NET_ERROR_SETCFG_COVER = 0x80000000 | 68,
        /// <summary>
        /// Failed to modify video watermark setup
        /// 修改图象水印配置失败
        /// </summary>
        NET_ERROR_SETCFG_WATERMAKE = 0x80000000 | 69,
        /// <summary>
        /// Failed to modify wireless network information
        /// 修改无线网络信息失败
        /// </summary>
        NET_ERROR_SETCFG_WLAN = 0x80000000 | 70,
        /// <summary>
        /// Failed to select wireless network device
        /// 选择无线网络设备失败
        /// </summary>
        NET_ERROR_SETCFG_WLANDEV = 0x80000000 | 71,
        /// <summary>
        /// Failed to modify the actively registration parameter setup
        /// 修改主动注册参数配置失败
        /// </summary>
        NET_ERROR_SETCFG_REGISTER = 0x80000000 | 72,
        /// <summary>
        /// Failed to modify camera property
        /// 修改摄像头属性配置失败
        /// </summary>
        NET_ERROR_SETCFG_CAMERA = 0x80000000 | 73,
        /// <summary>
        /// Failed to modify IR alarm setup
        /// 修改红外报警配置失败
        /// </summary>
        NET_ERROR_SETCFG_INFRARED = 0x80000000 | 74,
        /// <summary>
        /// Failed to modify audio alarm setup
        /// 修改音频报警配置失败
        /// </summary>
        NET_ERROR_SETCFG_SOUNDALARM = 0x80000000 | 75,
        /// <summary>
        /// Failed to modify storage position setup
        /// 修改存储位置配置失败
        /// </summary>
        NET_ERROR_SETCFG_STORAGE = 0x80000000 | 76,
        /// <summary>
        /// The audio encode port has not been successfully initialized
        /// 音频编码接口没有成功初始化
        /// </summary>
        NET_AUDIOENCODE_NOTINIT = 0x80000000 | 77,
        /// <summary>
        /// The data are too long
        /// 数据过长
        /// </summary>
        NET_DATA_TOOLONGH = 0x80000000 | 78,
        /// <summary>
        /// The device does not support current operation
        /// 设备不支持该操作
        /// </summary>
        NET_UNSUPPORTED = 0x80000000 | 79,
        /// <summary>
        /// Device resources is not sufficient
        /// 设备资源不足
        /// </summary>
        NET_DEVICE_BUSY = 0x80000000 | 80,
        /// <summary>
        /// The server has boot up
        /// 服务器已经启动
        /// </summary>
        NET_SERVER_STARTED = 0x80000000 | 81,
        /// <summary>
        /// The server has not fully boot up
        /// 服务器尚未成功启动
        /// </summary>
        NET_SERVER_STOPPED = 0x80000000 | 82,
        /// <summary>
        /// Input serial number is not correct
        /// 输入序列号有误
        /// </summary>
        NET_LISTER_INCORRECT_SERIAL = 0x80000000 | 83,
        /// <summary>
        /// Failed to get HDD information
        /// 获取硬盘信息失败
        /// </summary>
        NET_QUERY_DISKINFO_FAILED = 0x80000000 | 84,
        /// <summary>
        /// Failed to get connect session information
        /// 获取连接Session信息
        /// </summary>
        NET_ERROR_GETCFG_SESSION = 0x80000000 | 85,
        /// <summary>
        /// The password you typed is incorrect. You have exceeded the maximum number of retries
        /// 输入密码错误超过限制次数
        /// </summary>
        NET_USER_FLASEPWD_TRYTIME = 0x80000000 | 86,
        /// <summary>
        /// Password is not correct
        /// 密码不正确
        /// </summary>
        NET_LOGIN_ERROR_PASSWORD = 0x80000000 | 100,
        /// <summary>
        /// The account does not exist
        /// 帐户不存在
        /// </summary>
        NET_LOGIN_ERROR_USER = 0x80000000 | 101,
        /// <summary>
        /// Time out for log in returned value
        /// 等待登录返回超时
        /// </summary>
        NET_LOGIN_ERROR_TIMEOUT = 0x80000000 | 102,
        /// <summary>
        /// The account has logged in
        /// 帐号已登录
        /// </summary>
        NET_LOGIN_ERROR_RELOGGIN = 0x80000000 | 103,
        /// <summary>
        /// The account has been locked
        /// 帐号已被锁定
        /// </summary>
        NET_LOGIN_ERROR_LOCKED = 0x80000000 | 104,
        /// <summary>
        /// The account bas been in the BL
        /// 帐号已被列为禁止名单
        /// </summary>
        NET_LOGIN_ERROR_BLACKLIST = 0x80000000 | 105,
        /// <summary>
        /// Resources are not sufficient. System is busy now
        /// 资源不足,系统忙
        /// </summary>
        NET_LOGIN_ERROR_BUSY = 0x80000000 | 106,
        /// <summary>
        /// Time out. Please check network and try again
        /// 登录设备超时,请检查网络并重试
        /// </summary>
        NET_LOGIN_ERROR_CONNECT = 0x80000000 | 107,
        /// <summary>
        /// Network connection failed
        /// 网络连接失败
        /// </summary>
        NET_LOGIN_ERROR_NETWORK = 0x80000000 | 108,
        /// <summary>
        /// Successfully logged in the device but can not create video channel. Please check network connection
        /// 登录设备成功,但无法创建视频通道,请检查网络状况
        /// </summary>
        NET_LOGIN_ERROR_SUBCONNECT = 0x80000000 | 109,
        /// <summary>
        /// exceed the max connect number
        /// 超过最大连接数
        /// </summary>
        NET_LOGIN_ERROR_MAXCONNECT = 0x80000000 | 110,
        /// <summary>
        /// protocol 3 support
        /// 只支持3代协议
        /// </summary>
        NET_LOGIN_ERROR_PROTOCOL3_ONLY = 0x80000000 | 111,
        /// <summary>
        /// There is no USB or USB info error
        /// 未插入U盾或U盾信息错误
        /// </summary>
        NET_LOGIN_ERROR_UKEY_LOST = 0x80000000 | 112,
        /// <summary>
        /// Client-end IP address has no right to login
        /// 客户端IP地址没有登录权限
        /// </summary>
        NET_LOGIN_ERROR_NO_AUTHORIZED = 0x80000000 | 113,
        /// <summary>
        /// user or password error
        /// 账号或密码错误 
        /// </summary>
        NET_LOGIN_ERROR_USER_OR_PASSOWRD = 0X80000000 | 117,
        /// <summary>
        /// Error occurs when Render library open audio
        /// Render库打开音频出错
        /// </summary>
        NET_RENDER_SOUND_ON_ERROR = 0x80000000 | 120,
        /// <summary>
        /// Error occurs when Render library close audio
        /// Render库关闭音频出错
        /// </summary>
        NET_RENDER_SOUND_OFF_ERROR = 0x80000000 | 121,
        /// <summary>
        /// Error occurs when Render library control volume
        /// Render库控制音量出错
        /// </summary>
        NET_RENDER_SET_VOLUME_ERROR = 0x80000000 | 122,
        /// <summary>
        /// Error occurs when Render library set video parameter
        /// Render库设置画面参数出错
        /// </summary>
        NET_RENDER_ADJUST_ERROR = 0x80000000 | 123,
        /// <summary>
        /// Error occurs when Render library pause play
        /// Render库暂停播放出错
        /// </summary>
        NET_RENDER_PAUSE_ERROR = 0x80000000 | 124,
        /// <summary>
        /// Render library snapshot error
        /// Render库抓图出错
        /// </summary>
        NET_RENDER_SNAP_ERROR = 0x80000000 | 125,
        /// <summary>
        /// Render library stepper error
        /// Render库步进出错
        /// </summary>
        NET_RENDER_STEP_ERROR = 0x80000000 | 126,
        /// <summary>
        /// Error occurs when Render library set frame rate
        /// Render库设置帧率出错
        /// </summary>
        NET_RENDER_FRAMERATE_ERROR = 0x80000000 | 127,
        /// <summary>
        /// Error occurs when Render lib setting show region
        /// Render库设置显示区域出错
        /// </summary>
        NET_RENDER_DISPLAYREGION_ERROR = 0x80000000 | 128,
        /// <summary>
        /// An error occurred when Render library getting current play time
        /// Render库获取当前播放时间出错
        /// </summary>
        NET_RENDER_GETOSDTIME_ERROR = 0x80000000 | 129,
        /// <summary>
        /// Group name has been existed
        /// 组名已存在
        /// </summary>
        NET_GROUP_EXIST = 0x80000000 | 140,
        /// <summary>
        /// The group name does not exist
        /// 组名不存在
        /// </summary>
        NET_GROUP_NOEXIST = 0x80000000 | 141,
        /// <summary>
        /// The group right exceeds the right list
        /// 组的权限超出权限列表范围
        /// </summary>
        NET_GROUP_RIGHTOVER = 0x80000000 | 142,
        /// <summary>
        /// The group can not be removed since there is user in it
        /// 组下有用户,不能删除
        /// </summary>
        NET_GROUP_HAVEUSER = 0x80000000 | 143,
        /// <summary>
        /// The user has used one of the group right. It can not be removed
        /// 组的某个权限被用户使用,不能出除
        /// </summary>
        NET_GROUP_RIGHTUSE = 0x80000000 | 144,
        /// <summary>
        /// New group name has been existed
        /// 新组名同已有组名重复
        /// </summary>
        NET_GROUP_SAMENAME = 0x80000000 | 145,
        /// <summary>
        /// The user name has been existed
        /// 用户已存在
        /// </summary>
        NET_USER_EXIST = 0x80000000 | 146,
        /// <summary>
        /// The account does not exist
        /// 用户不存在
        /// </summary>
        NET_USER_NOEXIST = 0x80000000 | 147,
        /// <summary>
        /// User right exceeds the group right
        /// 用户权限超出组权限
        /// </summary>
        NET_USER_RIGHTOVER = 0x80000000 | 148,
        /// <summary>
        /// Reserved account. It does not allow to be modified
        /// 保留帐号,不容许修改密码
        /// </summary>
        NET_USER_PWD = 0x80000000 | 149,
        /// <summary>
        /// password is not correct
        /// 密码不正确
        /// </summary>
        NET_USER_FLASEPWD = 0x80000000 | 150,
        /// <summary>
        /// Password is invalid
        /// 密码不匹配
        /// </summary>
        NET_USER_NOMATCHING = 0x80000000 | 151,
        /// <summary>
        /// account in use
        /// 账号正在使用中
        /// </summary>
        NET_USER_INUSE = 0x80000000 | 152,
        /// <summary>
        /// Failed to get network card setup
        /// 获取网卡配置失败
        /// </summary>
        NET_ERROR_GETCFG_ETHERNET = 0x80000000 | 300,
        /// <summary>
        /// Failed to get wireless network information
        /// 获取无线网络信息失败
        /// </summary>
        NET_ERROR_GETCFG_WLAN = 0x80000000 | 301,
        /// <summary>
        /// Failed to get wireless network device
        /// 获取无线网络设备失败
        /// </summary>
        NET_ERROR_GETCFG_WLANDEV = 0x80000000 | 302,
        /// <summary>
        /// Failed to get actively registration parameter
        /// 获取主动注册参数失败
        /// </summary>
        NET_ERROR_GETCFG_REGISTER = 0x80000000 | 303,
        /// <summary>
        /// Failed to get camera property
        /// 获取摄像头属性失败
        /// </summary>
        NET_ERROR_GETCFG_CAMERA = 0x80000000 | 304,
        /// <summary>
        /// Failed to get IR alarm setup
        /// 获取红外报警配置失败
        /// </summary>
        NET_ERROR_GETCFG_INFRARED = 0x80000000 | 305,
        /// <summary>
        /// Failed to get audio alarm setup
        /// 获取音频报警配置失败
        /// </summary>
        NET_ERROR_GETCFG_SOUNDALARM = 0x80000000 | 306,
        /// <summary>
        /// Failed to get storage position
        /// 获取存储位置配置失败
        /// </summary>
        NET_ERROR_GETCFG_STORAGE = 0x80000000 | 307,
        /// <summary>
        /// Failed to get mail setup.
        /// 获取邮件配置失败
        /// </summary>
        NET_ERROR_GETCFG_MAIL = 0x80000000 | 308,
        /// <summary>
        /// Can not set right now.
        /// 暂时无法设置
        /// </summary>
        NET_CONFIG_DEVBUSY = 0x80000000 | 309,
        /// <summary>
        /// The configuration setup data are illegal.
        /// 配置数据不合法
        /// </summary>
        NET_CONFIG_DATAILLEGAL = 0x80000000 | 310,
        /// <summary>
        /// Failed to get DST setup
        /// 获取夏令时配置失败
        /// </summary>
        NET_ERROR_GETCFG_DST = 0x80000000 | 311,
        /// <summary>
        /// Failed to set DST 
        /// 设置夏令时配置失败
        /// </summary>
        NET_ERROR_SETCFG_DST = 0x80000000 | 312,
        /// <summary>
        /// Failed to get video osd setup.
        /// 获取视频OSD叠加配置失败
        /// </summary>
        NET_ERROR_GETCFG_VIDEO_OSD = 0x80000000 | 313,
        /// <summary>
        /// Failed to set video osd 
        /// 设置视频OSD叠加配置失败
        /// </summary>
        NET_ERROR_SETCFG_VIDEO_OSD = 0x80000000 | 314,
        /// <summary>
        /// Failed to get CDMA\GPRS configuration
        /// 获取CDMA\GPRS网络配置失败
        /// </summary>
        NET_ERROR_GETCFG_GPRSCDMA = 0x80000000 | 315,
        /// <summary>
        /// Failed to set CDMA\GPRS configuration
        /// 设置CDMA\GPRS网络配置失败
        /// </summary>
        NET_ERROR_SETCFG_GPRSCDMA = 0x80000000 | 316,
        /// <summary>
        /// Failed to get IP Filter configuration
        /// 获取IP过滤配置失败
        /// </summary>
        NET_ERROR_GETCFG_IPFILTER = 0x80000000 | 317,
        /// <summary>
        /// Failed to set IP Filter configuration
        /// 设置IP过滤配置失败
        /// </summary>
        NET_ERROR_SETCFG_IPFILTER = 0x80000000 | 318,
        /// <summary>
        /// Failed to get Talk Encode configuration
        /// 获取语音对讲编码配置失败
        /// </summary>
        NET_ERROR_GETCFG_TALKENCODE = 0x80000000 | 319,
        /// <summary>
        /// Failed to set Talk Encode configuration
        /// 设置语音对讲编码配置失败
        /// </summary>
        NET_ERROR_SETCFG_TALKENCODE = 0x80000000 | 320,
        /// <summary>
        /// Failed to get The length of the video package configuration
        /// 获取录像打包长度配置失败
        /// </summary>
        NET_ERROR_GETCFG_RECORDLEN = 0x80000000 | 321,
        /// <summary>
        /// Failed to set The length of the video package configuration
        /// 设置录像打包长度配置失败
        /// </summary>
        NET_ERROR_SETCFG_RECORDLEN = 0x80000000 | 322,
        /// <summary>
        /// Not support Network hard disk partition
        /// 不支持网络硬盘分区
        /// </summary>
        NET_DONT_SUPPORT_SUBAREA = 0x80000000 | 323,
        /// <summary>
        /// Failed to get the register server information
        /// 获取设备上主动注册服务器信息失败
        /// </summary>
        NET_ERROR_GET_AUTOREGSERVER = 0x80000000 | 324,
        /// <summary>
        /// Failed to control actively registration
        /// 主动注册重定向注册错误
        /// </summary>
        NET_ERROR_CONTROL_AUTOREGISTER = 0x80000000 | 325,
        /// <summary>
        /// Failed to disconnect actively registration
        /// 断开主动注册服务器错误
        /// </summary>
        NET_ERROR_DISCONNECT_AUTOREGISTER = 0x80000000 | 326,
        /// <summary>
        /// Failed to get mms configuration
        /// 获取mms配置失败
        /// </summary>
        NET_ERROR_GETCFG_MMS = 0x80000000 | 327,
        /// <summary>
        /// Failed to set mms configuration
        /// 设置mms配置失败
        /// </summary>
        NET_ERROR_SETCFG_MMS = 0x80000000 | 328,
        /// <summary>
        /// Failed to get SMS configuration
        /// 获取短信激活无线连接配置失败
        /// </summary>
        NET_ERROR_GETCFG_SMSACTIVATION = 0x80000000 | 329,
        /// <summary>
        /// Failed to set SMS configuration
        /// 设置短信激活无线连接配置失败
        /// </summary>
        NET_ERROR_SETCFG_SMSACTIVATION = 0x80000000 | 330,
        /// <summary>
        /// Failed to get activation of a wireless connection
        /// 获取拨号激活无线连接配置失败
        /// </summary>
        NET_ERROR_GETCFG_DIALINACTIVATION = 0x80000000 | 331,
        /// <summary>
        /// Failed to set activation of a wireless connection
        /// 设置拨号激活无线连接配置失败
        /// </summary>
        NET_ERROR_SETCFG_DIALINACTIVATION = 0x80000000 | 332,
        /// <summary>
        /// Failed to get the parameter of video output
        /// 查询视频输出参数配置失败
        /// </summary>
        NET_ERROR_GETCFG_VIDEOOUT = 0x80000000 | 333,
        /// <summary>
        /// Failed to set the configuration of video output
        /// 设置视频输出参数配置失败
        /// </summary>
        NET_ERROR_SETCFG_VIDEOOUT = 0x80000000 | 334,
        /// <summary>
        /// Failed to get osd overlay enabling
        /// 获取osd叠加使能配置失败
        /// </summary>
        NET_ERROR_GETCFG_OSDENABLE = 0x80000000 | 335,
        /// <summary>
        /// Failed to set OSD overlay enabling
        /// 设置osd叠加使能配置失败
        /// </summary>
        NET_ERROR_SETCFG_OSDENABLE = 0x80000000 | 336,
        /// <summary>
        /// Failed to set digital input configuration of front encoders
        /// 设置数字通道前端编码接入配置失败
        /// </summary>
        NET_ERROR_SETCFG_ENCODERINFO = 0x80000000 | 337,
        /// <summary>
        /// Failed to get TV adjust configuration
        /// 获取TV调节配置失败
        /// </summary>
        NET_ERROR_GETCFG_TVADJUST = 0x80000000 | 338,
        /// <summary>
        /// Failed to set TV adjust configuration
        /// 设置TV调节配置失败
        /// </summary>
        NET_ERROR_SETCFG_TVADJUST = 0x80000000 | 339,
        /// <summary>
        /// Failed to request to establish a connection
        /// 请求建立连接失败
        /// </summary>
        NET_ERROR_CONNECT_FAILED = 0x80000000 | 340,
        /// <summary>
        /// Failed to request to upload burn files
        /// 请求刻录文件上传失败
        /// </summary>
        NET_ERROR_SETCFG_BURNFILE = 0x80000000 | 341,
        /// <summary>
        /// Failed to get capture configuration information
        /// 获取抓包配置信息失败
        /// </summary>
        NET_ERROR_SNIFFER_GETCFG = 0x80000000 | 342,
        /// <summary>
        /// Failed to set capture configuration information
        /// 设置抓包配置信息失败
        /// </summary>
        NET_ERROR_SNIFFER_SETCFG = 0x80000000 | 343,
        /// <summary>
        /// Failed to get download restrictions information
        /// 查询下载限制信息失败
        /// </summary>
        NET_ERROR_DOWNLOADRATE_GETCFG = 0x80000000 | 344,
        /// <summary>
        /// Failed to set download restrictions information
        /// 设置下载限制信息失败
        /// </summary>
        NET_ERROR_DOWNLOADRATE_SETCFG = 0x80000000 | 345,
        /// <summary>
        /// Failed to query serial port parameters
        /// 查询串口参数失败
        /// </summary>
        NET_ERROR_SEARCH_TRANSCOM = 0x80000000 | 346,
        /// <summary>
        /// Failed to get the preset info
        /// 获取预制点信息错误
        /// </summary>
        NET_ERROR_GETCFG_POINT = 0x80000000 | 347,
        /// <summary>
        /// Failed to set the preset info
        /// 设置预制点信息错误
        /// </summary>
        NET_ERROR_SETCFG_POINT = 0x80000000 | 348,
        /// <summary>
        /// SDK log out the device abnormally
        /// SDK没有正常登出设备
        /// </summary>
        NET_SDK_LOGOUT_ERROR = 0x80000000 | 349,
        /// <summary>
        /// Failed to get vehicle configuration
        /// 获取车载配置失败
        /// </summary>
        NET_ERROR_GET_VEHICLE_CFG = 0x80000000 | 350,
        /// <summary>
        /// Failed to set vehicle configuration
        /// 设置车载配置失败
        /// </summary>
        NET_ERROR_SET_VEHICLE_CFG = 0x80000000 | 351,
        /// <summary>
        /// Failed to get ATM overlay configuration
        /// 获取atm叠加配置失败
        /// </summary>
        NET_ERROR_GET_ATM_OVERLAY_CFG = 0x80000000 | 352,
        /// <summary>
        /// Failed to set ATM overlay configuration
        /// 设置atm叠加配置失败
        /// </summary>
        NET_ERROR_SET_ATM_OVERLAY_CFG = 0x80000000 | 353,
        /// <summary>
        /// Failed to get ATM overlay ability
        /// 获取atm叠加能力失败
        /// </summary>
        NET_ERROR_GET_ATM_OVERLAY_ABILITY = 0x80000000 | 354,
        /// <summary>
        /// Failed to get decoder tour configuration
        /// 获取解码器解码轮巡配置失败
        /// </summary>
        NET_ERROR_GET_DECODER_TOUR_CFG = 0x80000000 | 355,
        /// <summary>
        /// Failed to set decoder tour configuration
        /// 设置解码器解码轮巡配置失败
        /// </summary>
        NET_ERROR_SET_DECODER_TOUR_CFG = 0x80000000 | 356,
        /// <summary>
        /// Failed to control decoder tour
        /// 控制解码器解码轮巡失败
        /// </summary>
        NET_ERROR_CTRL_DECODER_TOUR = 0x80000000 | 357,
        /// <summary>
        /// Beyond the device supports for the largest number of user groups
        /// 超出设备支持最大用户组数目
        /// </summary>
        NET_GROUP_OVERSUPPORTNUM = 0x80000000 | 358,
        /// <summary>
        /// Beyond the device supports for the largest number of users
        /// 超出设备支持最大用户数目
        /// </summary>
        NET_USER_OVERSUPPORTNUM = 0x80000000 | 359,
        /// <summary>
        /// Failed to get SIP configuration
        /// 获取SIP配置失败
        /// </summary>
        NET_ERROR_GET_SIP_CFG = 0x80000000 | 368,
        /// <summary>
        /// Failed to set SIP configuration
        /// 设置SIP配置失败
        /// </summary>
        NET_ERROR_SET_SIP_CFG = 0x80000000 | 369,
        /// <summary>
        /// Failed to get SIP capability
        /// 获取SIP能力失败
        /// </summary>
        NET_ERROR_GET_SIP_ABILITY = 0x80000000 | 370,
        /// <summary>
        /// Failed to get "WIFI ap' configuration
        /// 获取WIFI ap配置失败
        /// </summary>
        NET_ERROR_GET_WIFI_AP_CFG = 0x80000000 | 371,
        /// <summary>
        /// Failed to set "WIFI ap" configuration
        /// 设置WIFI ap配置失败
        /// </summary>
        NET_ERROR_SET_WIFI_AP_CFG = 0x80000000 | 372,
        /// <summary>
        /// Failed to get decode policy
        /// 获取解码策略配置失败
        /// </summary>
        NET_ERROR_GET_DECODE_POLICY = 0x80000000 | 373,
        /// <summary>
        /// Failed to set decode policy
        /// 设置解码策略配置失败
        /// </summary>
        NET_ERROR_SET_DECODE_POLICY = 0x80000000 | 374,
        /// <summary>
        /// refuse talk
        /// 拒绝对讲
        /// </summary>
        NET_ERROR_TALK_REJECT = 0x80000000 | 375,
        /// <summary>
        /// talk has opened by other client
        /// 对讲被其他客户端打开
        /// </summary>
        NET_ERROR_TALK_OPENED = 0x80000000 | 376,
        /// <summary>
        /// resource conflict
        /// 资源冲突
        /// </summary>
        NET_ERROR_TALK_RESOURCE_CONFLICIT = 0x80000000 | 377,
        /// <summary>
        /// unsupported encode type
        /// 不支持的语音编码格式
        /// </summary>
        NET_ERROR_TALK_UNSUPPORTED_ENCODE = 0x80000000 | 378,
        /// <summary>
        /// no right
        /// 无权限
        /// </summary>
        NET_ERROR_TALK_RIGHTLESS = 0x80000000 | 379,
        /// <summary>
        /// request failed
        /// 请求对讲失败
        /// </summary>
        NET_ERROR_TALK_FAILED = 0x80000000 | 380,
        /// <summary>
        /// Failed to get device relative config
        /// 获取机器相关配置失败
        /// </summary>
        NET_ERROR_GET_MACHINE_CFG = 0x80000000 | 381,
        /// <summary>
        /// Failed to set device relative config
        /// 设置机器相关配置失败
        /// </summary>
        NET_ERROR_SET_MACHINE_CFG = 0x80000000 | 382,
        /// <summary>
        /// get data failed
        /// 设备无法获取当前请求数据
        /// </summary>
        NET_ERROR_GET_DATA_FAILED = 0x80000000 | 383,
        /// <summary>
        /// MAC validate failed
        /// MAC地址验证失败 
        /// </summary>
        NET_ERROR_MAC_VALIDATE_FAILED = 0x80000000 | 384,
        /// <summary>
        /// Failed to get server instance 
        /// 获取服务器实例失败
        /// </summary>
        NET_ERROR_GET_INSTANCE = 0x80000000 | 385,
        /// <summary>
        /// Generated json string is error
        /// 生成的jason字符串错误
        /// </summary>
        NET_ERROR_JSON_REQUEST = 0x80000000 | 386,
        /// <summary>
        /// The responding json string is error
        /// 响应的jason字符串错误
        /// </summary>
        NET_ERROR_JSON_RESPONSE = 0x80000000 | 387,
        /// <summary>
        /// The protocol version is lower than current version
        /// 协议版本低于当前使用的版本
        /// </summary>
        NET_ERROR_VERSION_HIGHER = 0x80000000 | 388,
        /// <summary>
        /// Hotspare disk operation failed. The capacity is low
        /// 热备操作失败, 容量不足
        /// </summary>
        NET_SPARE_NO_CAPACITY = 0x80000000 | 389,
        /// <summary>
        /// Display source is used by other output
        /// 显示源被其他输出占用
        /// </summary>
        NET_ERROR_SOURCE_IN_USE = 0x80000000 | 390,
        /// <summary>
        /// advanced users grab low-level user resource
        /// 高级用户抢占低级用户资源
        /// </summary>
        NET_ERROR_REAVE = 0x80000000 | 391,
        /// <summary>
        /// net forbid
        /// 禁止入网
        /// </summary>
        NET_ERROR_NETFORBID = 0x80000000 | 392,
        /// <summary>
        /// get MAC filter configuration error
        /// 获取MAC过滤配置失败
        /// </summary>
        NET_ERROR_GETCFG_MACFILTER = 0x80000000 | 393,
        /// <summary>
        /// set MAC filter configuration error
        /// 设置MAC过滤配置失败
        /// </summary>
        NET_ERROR_SETCFG_MACFILTER = 0x80000000 | 394,
        /// <summary>
        /// get IP/MAC filter configuration error
        /// 获取IP/MAC过滤配置失败
        /// </summary>
        NET_ERROR_GETCFG_IPMACFILTER = 0x80000000 | 395,
        /// <summary>
        /// set IP/MAC filter configuration error
        /// 设置IP/MAC过滤配置失败
        /// </summary>
        NET_ERROR_SETCFG_IPMACFILTER = 0x80000000 | 396,
        /// <summary>
        /// operation over time 
        /// 当前操作超时
        /// </summary>
        NET_ERROR_OPERATION_OVERTIME = 0x80000000 | 397,
        /// <summary>
        /// senior validation failure
        /// 高级校验失败
        /// </summary>
        NET_ERROR_SENIOR_VALIDATE_FAILED = 0x80000000 | 398,
        /// <summary>
        /// device ID is not exist
        /// 设备ID不存在
        /// </summary>
        NET_ERROR_DEVICE_ID_NOT_EXIST = 0x80000000 | 399,
        /// <summary>
        /// unsupport operation
        /// 不支持当前操作
        /// </summary>
        NET_ERROR_UNSUPPORTED = 0x80000000 | 400,
        /// <summary>
        /// proxy dll load error
        /// 代理库加载失败
        /// </summary>
        NET_ERROR_PROXY_DLLLOAD = 0x80000000 | 401,
        /// <summary>
        /// proxy user parameter is not legal
        /// 代理用户参数不合法
        /// </summary>
        NET_ERROR_PROXY_ILLEGAL_PARAM = 0x80000000 | 402,
        /// <summary>
        /// handle invalid
        /// 代理句柄无效
        /// </summary>
        NET_ERROR_PROXY_INVALID_HANDLE = 0x80000000 | 403,
        /// <summary>
        /// login device error
        /// 代理登入前端设备失败
        /// </summary>
        NET_ERROR_PROXY_LOGIN_DEVICE_ERROR = 0x80000000 | 404,
        /// <summary>
        /// start proxy server error
        /// 启动代理服务失败
        /// </summary>
        NET_ERROR_PROXY_START_SERVER_ERROR = 0x80000000 | 405,
        /// <summary>
        /// request speak failed
        /// 请求喊话失败
        /// </summary>
        NET_ERROR_SPEAK_FAILED = 0x80000000 | 406,
        /// <summary>
        /// unsupport F6
        /// 设备不支持此F6接口调用
        /// </summary>
        NET_ERROR_NOT_SUPPORT_F6 = 0x80000000 | 407,
        /// <summary>
        /// CD is not ready
        /// 光盘未就绪
        /// </summary>
        NET_ERROR_CD_UNREADY = 0x80000000 | 408,
        /// <summary>
        /// Directory does not exist
        /// 目录不存在
        /// </summary>
        NET_ERROR_DIR_NOT_EXIST = 0x80000000 | 409,
        /// <summary>
        /// The device does not support the segmentation model
        /// 设备不支持的分割模式
        /// </summary>
        NET_ERROR_UNSUPPORTED_SPLIT_MODE = 0x80000000 | 410,
        /// <summary>
        /// Open the window parameter is illegal
        /// 开窗参数不合法
        /// </summary>
        NET_ERROR_OPEN_WND_PARAM = 0x80000000 | 411,
        /// <summary>
        /// Open the window more than limit
        /// 开窗数量超过限制
        /// </summary>
        NET_ERROR_LIMITED_WND_COUNT = 0x80000000 | 412,
        /// <summary>
        /// Request command with the current pattern don't match
        /// 请求命令与当前模式不匹配
        /// </summary>
        NET_ERROR_UNMATCHED_REQUEST = 0x80000000 | 413,
        /// <summary>
        /// Render Library to enable high-definition image internal adjustment strategy error
        /// Render库启用高清图像内部调整策略出错
        /// </summary>
        NET_RENDER_ENABLELARGEPICADJUSTMENT_ERROR = 0x80000000 | 414,
        /// <summary>
        /// Upgrade equipment failure
        /// 设备升级失败
        /// </summary>
        NET_ERROR_UPGRADE_FAILED = 0x80000000 | 415,
        /// <summary>
        /// Can't find the target device
        /// 找不到目标设备
        /// </summary>
        NET_ERROR_NO_TARGET_DEVICE = 0x80000000 | 416,
        /// <summary>
        /// Can't find the verify device
        /// 找不到验证设备
        /// </summary>
        NET_ERROR_NO_VERIFY_DEVICE = 0x80000000 | 417,
        /// <summary>
        /// No cascade permissions
        /// 无级联权限
        /// </summary>
        NET_ERROR_CASCADE_RIGHTLESS = 0x80000000 | 418,
        /// <summary>
        /// low priority
        /// 低优先级
        /// </summary>
        NET_ERROR_LOW_PRIORITY = 0x80000000 | 419,
        /// <summary>
        /// The remote device request timeout
        /// 远程设备请求超时
        /// </summary>
        NET_ERROR_REMOTE_REQUEST_TIMEOUT = 0x80000000 | 420,
        /// <summary>
        /// Input source beyond maximum route restrictions
        /// 输入源超出最大路数限制
        /// </summary>
        NET_ERROR_LIMITED_INPUT_SOURCE = 0x80000000 | 421,
        /// <summary>
        /// Failed to set log print
        /// 设置日志打印失败
        /// </summary>
        NET_ERROR_SET_LOG_PRINT_INFO = 0x80000000 | 422,
        /// <summary>
        /// "dwSize" is not initialized in input param
        /// 入参的dwsize字段出错
        /// </summary>
        NET_ERROR_PARAM_DWSIZE_ERROR = 0x80000000 | 423,
        /// <summary>
        /// TV wall exceed limit
        /// 电视墙数量超过上限
        /// </summary>
        NET_ERROR_LIMITED_MONITORWALL_COUNT = 0x80000000 | 424,
        /// <summary>
        /// Fail to execute part of the process
        /// 部分过程执行失败
        /// </summary>
        NET_ERROR_PART_PROCESS_FAILED = 0x80000000 | 425,
        /// <summary>
        /// Fail to transmit due to not supported by target
        /// 该功能不支持转发
        /// </summary>
        NET_ERROR_TARGET_NOT_SUPPORT = 0x80000000 | 426,
        /// <summary>
        /// Access to the file failed
        /// 访问文件失败
        /// </summary>
        NET_ERROR_VISITE_FILE = 0x80000000 | 510,
        /// <summary>
        /// Device busy
        /// 设备忙
        /// </summary>
        NET_ERROR_DEVICE_STATUS_BUSY = 0x80000000 | 511,
        /// <summary>
        /// Fail to change the password
        /// 修改密码无权限
        /// </summary>
        NET_USER_PWD_NOT_AUTHORIZED = 0x80000000 | 512,
        /// <summary>
        /// Password strength is not enough
        /// 密码强度不够
        /// </summary>
        NET_USER_PWD_NOT_STRONG = 0x80000000 | 513,
        /// <summary>
        /// No corresponding setup
        /// 没有对应的配置
        /// </summary>
        NET_ERROR_NO_SUCH_CONFIG = 0x80000000 | 514,
        /// <summary>
        /// Failed to record audio
        /// 录音失败
        /// </summary>
        NET_ERROR_AUDIO_RECORD_FAILED = 0x80000000 | 515,
        /// <summary>
        /// Failed to send out data 
        /// 数据发送失败
        /// </summary>
        NET_ERROR_SEND_DATA_FAILED = 0x80000000 | 516,
        /// <summary>
        /// Abandoned port 
        /// 废弃接口
        /// </summary>
        NET_ERROR_OBSOLESCENT_INTERFACE = 0x80000000 | 517,
        /// <summary>
        /// Internal buffer is not sufficient 
        /// 内部缓冲不足
        /// </summary>
        NET_ERROR_INSUFFICIENT_INTERAL_BUF = 0x80000000 | 518,
        /// <summary>
        /// verify password when changing device IP
        /// 修改设备ip时,需要校验密码
        /// </summary>
        NET_ERROR_NEED_ENCRYPTION_PASSWORD = 0x80000000 | 519,
        /// <summary>
        /// device not support the record
        /// 设备不支持此记录集
        /// </summary>
        NET_ERROR_NOSUPPORT_RECORD = 0x80000000 | 520,
        /// <summary>
        /// Failed to serialize data
        /// 数据序列化错误
        /// </summary>
        NET_ERROR_SERIALIZE_ERROR = 0x80000000 | 1010,
        /// <summary>
        /// Failed to deserialize data
        /// 数据序列化错误
        /// </summary>
        NET_ERROR_DESERIALIZE_ERROR = 0x80000000 | 1011,
        /// <summary>
        /// the wireless id is already existed
        /// 数据反序列化错误
        /// </summary>
        NET_ERROR_LOWRATEWPAN_ID_EXISTED = 0x80000000 | 1012,
        /// <summary>
        /// the wireless id limited
        /// 该无线ID已存在
        /// </summary>
        NET_ERROR_LOWRATEWPAN_ID_LIMIT = 0x80000000 | 1013,
        /// <summary>
        /// add the wireless id abnormaly
        /// 无线ID数量已超限
        /// </summary>
        NET_ERROR_LOWRATEWPAN_ID_ABNORMAL = 0x80000000 | 1014,
        /// <summary>
        /// encrypt data fail
        /// 加密数据失败
        /// </summary>
        NET_ERROR_ENCRYPT = 0x80000000 | 1015,
        /// <summary>
        /// new password illegal
        /// 新密码不合规范
        /// </summary>
        NET_ERROR_PWD_ILLEGAL = 0x80000000 | 1016,
        /// <summary>
        /// device is already init
        /// 设备已经初始化
        /// </summary>
        NET_ERROR_DEVICE_ALREADY_INIT = 0x80000000 | 1017,
        /// <summary>
        /// security code check out fail
        /// 安全码错误
        /// </summary>
        NET_ERROR_SECURITY_CODE = 0x80000000 | 1018,
        /// <summary>
        /// security code out of time
        /// 安全码超出有效期
        /// </summary>
        NET_ERROR_SECURITY_CODE_TIMEOUT = 0x80000000 | 1019,
        /// <summary>
        /// get passwd specification fail
        /// 获取密码规范失败
        /// </summary>
        NET_ERROR_GET_PWD_SPECI = 0x80000000 | 1020,
        /// <summary>
        /// no authority of operation 
        /// 无权限进行该操作
        /// </summary>
        NET_ERROR_NO_AUTHORITY_OF_OPERATION = 0x80000000 | 1021,
        /// <summary>
        /// decrypt data fail
        /// 解密数据失败
        /// </summary>
        NET_ERROR_DECRYPT = 0x80000000 | 1022,
        /// <summary>
        /// 2D code check out fail
        /// 2D code校验失败
        /// </summary>
        NET_ERROR_2D_CODE = 0x80000000 | 1023,
        /// <summary>
        /// invalid request
        /// 非法的RPC请求
        /// </summary>
        NET_ERROR_INVALID_REQUEST = 0x80000000 | 1024,
        /// <summary>
        /// pwd reset unabled
        /// 密码重置功能已关闭
        /// </summary>
        NET_ERROR_PWD_RESET_DISABLE = 0x80000000 | 1025,
        /// <summary>
        /// failed to display private data,such as rule box
        /// 显示私有数据，比如规则框等失败
        /// </summary>
        NET_ERROR_PLAY_PRIVATE_DATA = 0x80000000 | 1026,
        /// <summary>
        /// robot operate failed
        /// 机器人操作失败
        /// </summary>
        NET_ERROR_ROBOT_OPERATE_FAILED = 0x80000000 | 1027,
        /// <summary>
        /// channel has already been opened
        /// 通道已经打开
        /// </summary>
        NET_ERROR_CHANNEL_ALREADY_OPENED = 0x80000000 | 1033,
        /// <summary>
        /// 组ID超过最大值
        /// </summary>
        NET_ERROR_FACE_RECOGNITION_SERVER_GROUP_ID_EXCEED = 0x80000000 | 1051,
        /// <summary>
        /// VK info decrypt failed
        /// VK信息解密失败
        /// </summary>
        NET_ERROR_VK_INFO_DECRYPT_FAILED = 0x80000000 | 1117,
        /// <summary>
        /// 设备不支持高安全等级登录
        /// </summary>
        ERR_NOT_SUPPORT_HIGHLEVEL_SECURITY_LOGIN = 0x80000000 | 1153,
        /// <summary>
        /// invaild channel
        /// 无效的通道
        /// </summary>
        ERR_INTERNAL_INVALID_CHANNEL = 0x90001002,
        /// <summary>
        /// reopen channel failed
        /// 重新打开通道失败
        /// </summary>
        ERR_INTERNAL_REOPEN_CHANNEL = 0x90001003,
        /// <summary>
        /// send data failed
        /// 发送数据失败
        /// </summary>
        ERR_INTERNAL_SEND_DATA = 0x90002008,
        /// <summary>
        /// creat socket failed
        /// 创建套接字失败
        /// </summary>
        ERR_INTERNAL_CREATE_SOCKET = 0x90002003,
        ERR_INTERNAL_LISTEN_FAILED = 0x90010010,
    }

}
