using System;
using System.Runtime.InteropServices;
using Dahua.Api.Struct.Channel;

namespace Dahua.Api
{
    public partial class DHClient
    {
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
        public static bool PTZControl(long lLoginID, int nChannelID, EM_EXTPTZ_ControlType dwPTZCommand, int lParam1, int lParam2, int lParam3, bool dwStop, IntPtr param4)
        {
            bool result = false;
            result = CLIENT_DHPTZControlEx2(lLoginID, nChannelID, (uint)dwPTZCommand, lParam1, lParam2, lParam3, dwStop, param4);
            DHThrowLastError(result);
            return result;
        }

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_DHPTZControlEx2(long lLoginID, int nChannelID, uint dwPTZCommand, int lParam1, int lParam2, int lParam3, bool dwStop, IntPtr param4);

    }
}
