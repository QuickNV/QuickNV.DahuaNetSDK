using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Dahua.NetSDK.Api.Service
{
    public class ConfigService
    {
        private DhSession session;
        internal ConfigService(DhSession session)
        {
            this.session = session;
        }

        public DateTime GetTime()
        {
            NET_TIME m_struTimeCfg = default;
            uint dwReturn = 0;
            int nSize = Marshal.SizeOf(m_struTimeCfg);
            IntPtr ptrTimeCfg = Marshal.AllocHGlobal(nSize);
            try
            {
                Marshal.StructureToPtr(m_struTimeCfg, ptrTimeCfg, false);

                if (!NETClient.GetDevConfig(session.UserId, EM_DEV_CFG_TYPE.TIMECFG, -1, ptrTimeCfg, (uint)nSize, ref dwReturn, session.CommandTimeout))
                    throw new DahuaException(NETClient.GetLastError());

                m_struTimeCfg = Marshal.PtrToStructure<NET_TIME>(ptrTimeCfg);
                return m_struTimeCfg.ToDateTime();
            }
            catch
            {
                throw;
            }
            finally
            {
                Marshal.FreeHGlobal(ptrTimeCfg);
            }
        }

        public void SetTime(DateTime dateTime)
        {
            NET_TIME m_struTimeCfg = NET_TIME.FromDateTime(dateTime);
            int nSize = Marshal.SizeOf(m_struTimeCfg);
            IntPtr ptrTimeCfg = Marshal.AllocHGlobal(nSize);
            try
            {
                Marshal.StructureToPtr(m_struTimeCfg, ptrTimeCfg, false);
                if (!NETClient.SetDevConfig(session.UserId, EM_DEV_CFG_TYPE.TIMECFG, -1, ptrTimeCfg, (uint)nSize, session.CommandTimeout))
                    throw new DahuaException(NETClient.GetLastError());
            }
            catch
            {
                throw;
            }
            finally
            {
                Marshal.FreeHGlobal(ptrTimeCfg);
            }
        }

        /// <summary>
        /// 获取设备序列号
        /// </summary>
        /// <returns></returns>
        /// <exception cref="DahuaException"></exception>
        public string GetDeviceSerialNumber()
        {
            NET_IN_GET_DEVICESERIALNO_INFO in_stuct = default;
            in_stuct.dwSize =Convert.ToUInt32(Marshal.SizeOf(in_stuct));
            NET_OUT_GET_DEVICESERIALNO_INFO out_stuct = default;
            out_stuct.dwSize = Convert.ToUInt32(Marshal.SizeOf(out_stuct));

            if (!NETClient.GetDeviceSerialNo(session.UserId,ref in_stuct,ref out_stuct,session.CommandTimeout))
                throw new DahuaException(NETClient.GetLastError());
            return out_stuct.szSN;
        }

        public string GetDeviceType()
        {
            NET_IN_GET_DEVICETYPE_INFO in_stuct = default;
            in_stuct.dwSize = Convert.ToUInt32(Marshal.SizeOf(in_stuct));
            NET_OUT_GET_DEVICETYPE_INFO out_stuct = default;
            out_stuct.dwSize = Convert.ToUInt32(Marshal.SizeOf(out_stuct));

            if (!NETClient.GetDeviceType(session.UserId, in_stuct, ref out_stuct, session.CommandTimeout))
                throw new DahuaException(NETClient.GetLastError());
            return out_stuct.szTypeEx;
        }

        public string GetMachineName()
        {
            NET_IN_GET_MACHINENAME_INFO in_stuct = default;
            in_stuct.dwSize = Convert.ToUInt32(Marshal.SizeOf(in_stuct));
            NET_OUT_GET_MACHINENAME_INFO out_stuct = default;
            out_stuct.dwSize = Convert.ToUInt32(Marshal.SizeOf(out_stuct));

            if (!NETClient.GetMachineName(session.UserId, ref in_stuct, ref out_stuct, session.CommandTimeout))
                throw new DahuaException(NETClient.GetLastError());
            return out_stuct.szName;
        }

        public string GetSoftwareVersion()
        {
            NET_IN_GET_SOFTWAREVERSION_INFO in_stuct = default;
            in_stuct.dwSize = Convert.ToUInt32(Marshal.SizeOf(in_stuct));
            NET_OUT_GET_SOFTWAREVERSION_INFO out_stuct = default;
            out_stuct.dwSize = Convert.ToUInt32(Marshal.SizeOf(out_stuct));
            
            if (!NETClient.GetSoftwareVersion(session.UserId, in_stuct, ref out_stuct, session.CommandTimeout))
                throw new DahuaException(NETClient.GetLastError());
            return out_stuct.szVersion;
        }
        
        /// <summary>
        /// 获取RTSP端口
        /// </summary>
        /// <returns></returns>
        public int GetRtspPort()
        {
            CFG_RTSP_INFO_OUT item = new CFG_RTSP_INFO_OUT();
            object refObj = item;

            if (!NETClient.GetNewDevConfig(session.UserId, -1, SDK_NEWDEVCONFIG_CMD.CFG_CMD_RTSP, ref refObj, typeof(CFG_RTSP_INFO_OUT), session.CommandTimeout))
                throw new DahuaException(NETClient.GetLastError());
            return item.nPort;
        }
    }
}
