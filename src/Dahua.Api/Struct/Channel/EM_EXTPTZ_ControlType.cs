namespace Dahua.Api.Struct.Channel
{

    /// <summary>
    /// PTZ control command enumeration
    /// 云台控制命令
    /// </summary>
    public enum EM_EXTPTZ_ControlType : uint
    {
        /// <summary>
        /// Up
        /// 上
        /// </summary>
        UP_CONTROL = 0,
        /// <summary>
        /// Down
        /// 下
        /// </summary>
        DOWN_CONTROL,
        /// <summary>
        /// Left
        /// 左
        /// </summary>
        LEFT_CONTROL,
        /// <summary>
        /// Right
        /// 右
        /// </summary>
        RIGHT_CONTROL,
        /// <summary>
        /// +Zoom in 
        /// 变倍+
        /// </summary>
        ZOOM_ADD_CONTROL,
        /// <summary>
        /// -Zoom out
        /// 变倍-
        /// </summary>
        ZOOM_DEC_CONTROL,
        /// <summary>
        /// +Focus 
        /// 调焦+
        /// </summary>
        FOCUS_ADD_CONTROL,
        /// <summary>
        /// -Focus
        /// 调焦-
        /// </summary>
        FOCUS_DEC_CONTROL,
        /// <summary>
        /// + Aperture 
        /// 光圈+
        /// </summary>
        APERTURE_ADD_CONTROL,
        /// <summary>
        /// -Aperture
        /// 光圈-
        /// </summary>
        APERTURE_DEC_CONTROL,
        /// <summary>
        /// Go to preset 
        /// 转至预置点
        /// </summary>
        POINT_MOVE_CONTROL,
        /// <summary>
        /// Set
        /// 设置
        /// </summary>
        POINT_SET_CONTROL,
        /// <summary>
        /// Delete
        /// 删除
        /// </summary>
        POINT_DEL_CONTROL,
        /// <summary>
        /// Tour
        /// 点间巡航
        /// </summary>
        POINT_LOOP_CONTROL,
        /// <summary>
        /// Light and wiper 
        /// 灯光雨刷
        /// </summary>
        LAMP_CONTROL,
        /// <summary>
        /// Upper left
        /// 左上
        /// </summary>
        LEFTTOP = 0x20,
        /// <summary>
        /// Upper right
        /// 右上
        /// </summary>
        RIGHTTOP,
        /// <summary>
        /// Down left
        /// 左下
        /// </summary>
        LEFTDOWN,
        /// <summary>
        /// Down right 
        /// 右下
        /// </summary>
        RIGHTDOWN,
        /// <summary>
        ///  Add preset to tour	tour preset value
        /// 加入预置点到巡航 巡航线路 预置点值
        /// </summary>
        ADDTOLOOP,
        /// <summary>
        /// Delete preset in tour tour preset value
        /// 删除巡航中预置点 巡航线路 预置点值
        /// </summary>
        DELFROMLOOP,
        /// <summary>
        /// Delete tour tour
        /// 清除巡航 巡航线路
        /// </summary>
        CLOSELOOP,
        /// <summary>
        /// Begin pan rotation
        /// 开始水平旋转
        /// </summary>
        STARTPANCRUISE,
        /// <summary>
        /// Stop pan rotation
        /// 停止水平旋转
        /// </summary>
        STOPPANCRUISE,
        /// <summary>
        /// Set left limit
        /// 设置左边界
        /// </summary>
        SETLEFTBORDER,
        /// <summary>
        /// Set right limit
        /// 设置右边界
        /// </summary>
        SETRIGHTBORDER,
        /// <summary>
        /// Begin scanning	
        /// 开始线扫
        /// </summary>
        STARTLINESCAN,
        /// <summary>
        /// Stop scanning
        /// 停止线扫
        /// </summary>
        CLOSELINESCAN,
        /// <summary>
        /// Start mode	mode line	
        /// 设置模式开始    模式线路
        /// </summary>
        SETMODESTART,
        /// <summary>
        /// Stop mode	mode line	
        /// 设置模式结束    模式线路
        /// </summary>
        SETMODESTOP,
        /// <summary>
        /// Enable mode	Mode line
        /// 运行模式    模式线路
        /// </summary>
        RUNMODE,
        /// <summary>
        /// unable mode	Mode line
        /// 停止模式    模式线路
        /// </summary>
        STOPMODE,
        /// <summary>
        /// Delete mode	Mode line
        /// 清除模式    模式线路
        /// </summary>
        DELETEMODE,
        /// <summary>
        /// Flip
        /// 翻转命令
        /// </summary>
        REVERSECOMM,
        /// <summary>
        /// 3D position	X address(8192)	Y address(8192)	zoom(4)
        /// 快速定位 水平坐标(8192) 垂直坐标(8192) 变倍(4)
        /// </summary>
        FASTGOTO,
        /// <summary>
        /// auxiliary open	Auxiliary point(param4 corresponding struct PTZ_CONTROL_AUXILIARY,param1、param2、param3 is invalid,dwStop set to FALSE)
        /// 辅助开关开 辅助点(param4对应 PTZ_CONTROL_AUXILIARY,param1、param2、param3无效,dwStop设置为FALSE)
        /// </summary>
        AUXIOPEN,
        /// <summary>
        /// Auxiliary close	Auxiliary point(param4 corresponding struct PTZ_CONTROL_AUXILIARY,param1、param2、param3 is invalid,dwStop set to FALSE)
        /// 辅助开关关 辅助点(param4对应 PTZ_CONTROL_AUXILIARY,param1、param2、param3无效,dwStop设置为FALSE)
        /// </summary>
        AUXICLOSE,
        /// <summary>
        /// Open dome menu 
        /// 打开球机菜单
        /// </summary>
        OPENMENU = 0x36,
        /// <summary>
        /// Close menu 
        /// 关闭菜单
        /// </summary>
        CLOSEMENU,
        /// <summary>
        /// Confirm menu 
        /// 菜单确定
        /// </summary>
        MENUOK,
        /// <summary>
        /// Cancel menu 
        /// 菜单取消
        /// </summary>
        MENUCANCEL,
        /// <summary>
        /// menu up 
        /// 菜单上
        /// </summary>
        MENUUP,
        /// <summary>
        /// menu down
        /// 菜单下
        /// </summary>
        MENUDOWN,
        /// <summary>
        /// menu left
        /// 菜单左
        /// </summary>
        MENULEFT,
        /// <summary>
        /// Menu right
        /// 菜单右
        /// </summary>
        MENURIGHT,
        /// <summary>
        /// Alarm activate PTZ parm1:Alarm input channel;parm2:Alarm activation type  1-preset 2-scan 3-tour;parm 3:activation value,such as preset value.
        /// 报警联动云台 parm1：报警输入通道；parm2：报警联动类型1-预置点2-线扫3-巡航；parm3：联动值,如预置点号
        /// </summary>
        ALARMHANDLE = 0x40,
        /// <summary>
        /// Matrix switch parm1:monitor number(video output number);parm2:video input number;parm3:matrix number 
        /// 矩阵切换 parm1：预览器号(视频输出号)；parm2：视频输入号；parm3：矩阵号
        /// </summary>
        MATRIXSWITCH = 0x41,
        /// <summary>
        /// Light controller
        /// 灯光控制器
        /// </summary>
        LIGHTCONTROL,
        /// <summary>
        /// 3D accurately positioning parm1:Pan degree(0~3600); parm2: tilt coordinates(0~900); parm3:zoom(1~128)
        /// 三维精确定位 parm1：水平角度(0~3600)；parm2：垂直坐标(0~900)；parm3：变倍(1~128)
        /// </summary>
        EXACTGOTO,
        /// <summary>
        /// Reset  3D positioning as zero 
        /// 三维定位重设零位
        /// </summary>
        RESETZERO,
        /// <summary>
        /// Absolute motion control command,param4 corresponding struct NET_PTZ_CONTROL_ABSOLUTELY
        /// 绝对移动控制命令,param4对应结构 NET_PTZ_CONTROL_ABSOLUTELY
        /// </summary>
        MOVE_ABSOLUTELY,
        /// <summary>
        /// Continuous motion control command,param4 corresponding struct NET_PTZ_CONTROL_CONTINUOUSLY
        /// 持续移动控制命令,param4对应结构 NET_PTZ_CONTROL_CONTINUOUSLY
        /// </summary>
        MOVE_CONTINUOUSLY,
        /// <summary>
        /// PTZ control command, at a certain speed to preset locu,parm4 corresponding struct NET_PTZ_CONTROL_GOTOPRESET
        /// 云台控制命令,以一定速度转到预置位点,parm4对应结构NET_PTZ_CONTROL_GOTOPRESET
        /// </summary>
        GOTOPRESET,
        /// <summary>
        /// Set to horizon(param4 corresponding struct NET_PTZ_VIEW_RANGE_INFO)
        /// 设置可视域(param4对应结构 NET_PTZ_VIEW_RANGE_INFO)
        /// </summary>
        SET_VIEW_RANGE = 0x49,
        /// <summary>
        /// Absolute focus(param4 corresponding struct NET_PTZ_FOCUS_ABSOLUTELY)
        /// 绝对聚焦(param4对应结构NET_PTZ_FOCUS_ABSOLUTELY)
        /// </summary>
        FOCUS_ABSOLUTELY = 0x4A,
        /// <summary>
        /// Level fan sweep(param4 corresponding NET_PTZ_CONTROL_SECTORSCAN,param1,param2,param3 is invalid)
        /// 水平扇扫(param4对应PTZ_CONTROL_SECTORSCAN,param1、param2、param3无效)
        /// </summary>
        HORSECTORSCAN = 0x4B,
        /// <summary>
        /// Vertical sweep fan(param4 corresponding NET_PTZ_CONTROL_SECTORSCAN,param1,param2,param3 is invalid)
        /// 垂直扇扫(param4对应PTZ_CONTROL_SECTORSCAN,param1、param2、param3无效)
        /// </summary>
        VERSECTORSCAN = 0x4C,
        /// <summary>
        /// Set absolute focus, focus on value, param1 for focal length, range: [0255], param2 as the focus, scope: [0255], param3, param4 is invalid
        /// 设定绝对焦距、聚焦值,param1为焦距,范围:[0,255],param2为聚焦,范围:[0,255],param3、param4无效
        /// </summary>
        SET_ABS_ZOOMFOCUS = 0x4D,
        /// <summary>
        /// Control fish eye PTZ,param4corresponding to structure NET_PTZ_CONTROL_SET_FISHEYE_EPTZ  
        /// 控制鱼眼电子云台,param4对应结构 PTZ_CONTROL_SET_FISHEYE_EPTZ
        /// </summary>
        SET_FISHEYE_EPTZ = 0x4E,
        /// <summary>
        /// Track start control(param4 corresponding to structure  NET_PTZ_CONTROL_SET_TRACK_CONTROL,dwStop set as FALSE， param1、param2、param3 is invalid)
        /// 轨道机开始控制(param4对应结构体为 PTZ_CONTROL_SET_TRACK_CONTROL,dwStop传FALSE, param1、param2、param3无效)
        /// </summary>
        SET_TRACK_START = 0x4F,
        /// <summary>
        /// Track stop control (param4 corresponding to structure NET_PTZ_CONTROL_SET_TRACK_CONTROL,dwStop set as FALSE，param1、param2、param3  is invalid)
        /// 轨道机停止控制(param4对应结构体为 PTZ_CONTROL_SET_TRACK_CONTROL,dwStop传FALSE,param1、param2、param3无效)
        /// </summary>
        SET_TRACK_STOP = 0x50,
        /// <summary>
        /// Up + TELE param1=speed (1-8) 
        /// 上 + TELE param1=速度(1-8),下同
        /// </summary>                                                     
        UP_TELE = 0x70,
        /// <summary>
        /// Down + TELE
        /// 下 + TELE
        /// </summary>
        DOWN_TELE,
        /// <summary>
        /// Left + TELE
        /// 左 + TELE
        /// </summary>
        LEFT_TELE,
        /// <summary>
        /// Right + TELE
        /// 右 + TELE
        /// </summary>
        RIGHT_TELE,
        /// <summary>
        /// Upper left + TELE
        /// 左上 + TELE
        /// </summary>
        LEFTUP_TELE,
        /// <summary>
        /// Down left + TELE
        /// 左下 + TELE
        /// </summary>
        LEFTDOWN_TELE,
        /// <summary>
        /// Upper right + TELE
        /// 右上 + TELE
        /// </summary>
        TIGHTUP_TELE,
        /// <summary>
        /// Down right + TELE
        /// 右下 + TELE
        /// </summary>
        RIGHTDOWN_TELE,
        /// <summary>
        /// Up + WIDE param1=speed (1-8) 
        /// 上 + WIDE param1=速度(1-8),下同
        /// </summary>
        UP_WIDE,
        /// <summary>
        /// Down + WIDE
        /// 下 + WIDE
        /// </summary>
        DOWN_WIDE,
        /// <summary>
        /// Left + WIDE
        /// 左 + WIDE
        /// </summary>
        LEFT_WIDE,
        /// <summary>
        /// Right + WIDE
        /// 右 + WIDE
        /// </summary>
        RIGHT_WIDE,
        /// <summary>
        /// Upper left + WIDE
        /// 左上 + WIDE
        /// </summary>
        LEFTUP_WIDE,
        /// <summary>
        /// Down left+ WIDE
        /// 左下 + WIDE
        /// </summary>
        LEFTDOWN_WIDE,
        /// <summary>
        /// Upper right + WIDE
        /// 右上 + WIDE
        /// </summary>
        TIGHTUP_WIDE,
        /// <summary>
        /// Down right + WIDE
        /// 右下 + WIDE
        /// </summary>
        RIGHTDOWN_WIDE,
        /// <summary>
        /// Go to preset point and take a picture
        /// 至预置点并抓图
        /// </summary>
        GOTOPRESETSNAP = 0x80,
        /// <summary>
        /// Calibrate the PTZ direction (two-way calibration)
        /// 校准云台方向（双方向校准）
        /// </summary>
        DIRECTIONCALIBRATION = 0x82,
        /// <summary>
        /// Calibrate the PTZ direction (one-way calibration) param4 -> NET_IN_CALIBRATE_SINGLEDIRECTION
        /// 校准云台方向（单防线校准）, param4 -> NET_IN_CALIBRATE_SINGLEDIRECTION
        /// </summary>
        SINGLEDIRECTIONCALIBRATION = 0x83,
        /// <summary>
        /// Relative positioning of PTZ, param4 -> NET_IN_MOVERELATIVELY_INFO
        /// 云台相对定位, param4 -> NET_IN_MOVERELATIVELY_INFO
        /// </summary>
        MOVE_RELATIVELY = 0x84,
        /// <summary>
        /// Set direction for PTZ, param4 -> NET_IN_SET_DIRECTION_INFO
        /// 设置云台方向, param4 -> NET_IN_SET_DIRECTION_INFO
        /// </summary>
        SET_DIRECTION = 0x85,
        /// <summary>
        /// Precisely and absolutely movement control command, param4 -> NET_IN_PTZBASE_MOVEABSOLUTELY_INFO use CFG_CAP_CMD_PTZ command to get the capability of PTZ
        /// if CFG_PTZ_PROTOCOL_CAPS_INFO -> bSupportReal equals TRUE means this device supports this feature
        /// 精准绝对移动控制命令, param4 -> NET_IN_PTZBASE_MOVEABSOLUTELY_INFO（通过 CFG_CAP_CMD_PTZ 命令获取云台能力集( CFG_PTZ_PROTOCOL_CAPS_INFO )
        /// 若bSupportReal为TRUE则设备支持该操作）
        /// </summary>
        BASE_MOVE_ABSOLUTELY = 0x86,
        /// <summary>
        /// Continuously movement control command, param4 -> NET_IN_PTZBASE_MOVECONTINUOUSLY_INFO. use CFG_CAP_CMD_PTZ command to get the capability of PTZ 
        /// if CFG_PTZ_PROTOCOL_CAPS_INFO -> stuMoveContinuously equals -> stuType.bSupportExtra equals TRUE means this device supports this feature
        /// 云台连续移动控制命令, param4 -> NET_IN_PTZBASE_MOVECONTINUOUSLY_INFO.  通过 CFG_CAP_CMD_PTZ 命令获取云台能力集
        /// 若 CFG_PTZ_PROTOCOL_CAPS_INFO 中 stuMoveContinuously 字段的  为 TRUE, 表示设备支持该操作
        /// </summary>
        BASE_MOVE_CONTINUOUSLY,
        /// <summary>
        /// Maximum command value
        /// 最大命令值
        /// </summary>
        TOTAL,
    }
}