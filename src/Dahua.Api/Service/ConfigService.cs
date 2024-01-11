using System;
using System.Runtime.InteropServices;
using Dahua.Api.Abstractions;
using Dahua.Api.Helpers;
using Dahua.Api.Struct;
using Dahua.Api.Struct.Config;
using static Dahua.Api.DHConsts;

namespace Dahua.Api.Service
{
    /// <summary>
    /// ConfigService
    /// </summary>
    public class ConfigService : IConfigService
    {
        private readonly IDahuaApi session;
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigService"/> class.
        /// </summary>
        /// <param name="session">The session.</param>
        public ConfigService(IDahuaApi session)
        {
            this.session = session;
        }

        /// <summary>
        /// Get the device serial number
        /// </summary>
        /// <returns></returns>
        /// <exception cref="DahuaApiException"></exception>
        public string GetDeviceSerialNumber()
        {
            NET_IN_GET_DEVICESERIALNO_INFO in_stuct = default;
            in_stuct.dwSize = Convert.ToUInt32(Marshal.SizeOf(in_stuct));
            NET_OUT_GET_DEVICESERIALNO_INFO out_stuct = default;
            out_stuct.dwSize = Convert.ToUInt32(Marshal.SizeOf(out_stuct));

            SdkHelper.InvokeSDK(() => CLIENT_GetDeviceSerialNo(session.UserId, ref in_stuct, ref out_stuct, session.CommandTimeout));

            return out_stuct.szSN ?? string.Empty;
        }

        /// <summary>
        /// Gets the type of the device.
        /// </summary>
        /// <returns></returns>
        public string GetDeviceType()
        {
            NET_IN_GET_DEVICETYPE_INFO in_stuct = default;
            in_stuct.dwSize = Convert.ToUInt32(Marshal.SizeOf(in_stuct));
            NET_OUT_GET_DEVICETYPE_INFO out_stuct = default;
            out_stuct.dwSize = Convert.ToUInt32(Marshal.SizeOf(out_stuct));
            SdkHelper.InvokeSDK(() => CLIENT_GetDeviceType(session.UserId, ref in_stuct, ref out_stuct, session.CommandTimeout));

            return out_stuct.szTypeEx ?? string.Empty;
        }

        /// <summary>
        /// Get the name of the machine
        /// </summary>
        /// <returns></returns>
        public string GetMachineName()
        {
            NET_IN_GET_MACHINENAME_INFO in_stuct = default;
            in_stuct.dwSize = Convert.ToUInt32(Marshal.SizeOf(in_stuct));
            NET_OUT_GET_MACHINENAME_INFO out_stuct = default;
            out_stuct.dwSize = Convert.ToUInt32(Marshal.SizeOf(out_stuct));

            SdkHelper.InvokeSDK(() => CLIENT_GetMachineName(session.UserId, ref in_stuct, ref out_stuct, session.CommandTimeout));

            return out_stuct.szName ?? string.Empty;
        }

        /// <summary>
        /// Get the RTSP port
        /// </summary>
        /// <returns></returns>
        public int GetRtspPort()
        {
            CFG_RTSP_INFO_OUT item = new CFG_RTSP_INFO_OUT();
            object refObj = item;
            GetNewDevConfig(session.UserId, -1, SDK_NEWDEVCONFIG_CMD.CFG_CMD_RTSP, ref refObj, typeof(CFG_RTSP_INFO_OUT), session.CommandTimeout);
            return item.nPort;
        }

        /// <summary>
        /// Gets the name of the channel.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <returns></returns>
        public string GetChannelName(int channel)
        {
            AV_CFG_ChannelName av_CFG_ChannelName = new AV_CFG_ChannelName();
            object refObj = av_CFG_ChannelName;
            GetNewDevConfig(session.UserId, channel, SDK_NEWDEVCONFIG_CMD.CFG_CMD_CHANNELTITLE, ref refObj, typeof(AV_CFG_ChannelName), session.CommandTimeout);

            return av_CFG_ChannelName.szName ?? string.Empty;
        }

        /// <summary>
        /// Gets the software version.
        /// </summary>
        /// <returns></returns>
        public string GetSoftwareVersion()
        {
            NET_IN_GET_SOFTWAREVERSION_INFO in_stuct = default;
            in_stuct.dwSize = Convert.ToUInt32(Marshal.SizeOf(in_stuct));
            NET_OUT_GET_SOFTWAREVERSION_INFO out_stuct = default;
            out_stuct.dwSize = Convert.ToUInt32(Marshal.SizeOf(out_stuct));

            SdkHelper.InvokeSDK(() => CLIENT_GetSoftwareVersion(session.UserId, ref in_stuct, ref out_stuct, session.CommandTimeout));

            return out_stuct.szVersion ?? string.Empty;
        }

        /// <summary>
        /// Gets the device time.
        /// </summary>
        /// <returns></returns>
        public DateTime GetTime()
        {
            NET_TIME m_struTimeCfg = default;
            uint dwReturn = 0;
            int nSize = Marshal.SizeOf(m_struTimeCfg);
            IntPtr ptrTimeCfg = Marshal.AllocHGlobal(nSize);
            try
            {
                Marshal.StructureToPtr(m_struTimeCfg, ptrTimeCfg, false);

                SdkHelper.InvokeSDK(() => CLIENT_GetDevConfig(session.UserId, (uint)EM_DEV_CFG_TYPE.TIMECFG, -1, ptrTimeCfg, (uint)nSize, ref dwReturn, session.CommandTimeout));

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

        /// <summary>
        /// Sets the device time.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        public void SetTime(DateTime dateTime)
        {
            NET_TIME m_struTimeCfg = NET_TIME.FromDateTime(dateTime);
            int nSize = Marshal.SizeOf(m_struTimeCfg);
            IntPtr ptrTimeCfg = Marshal.AllocHGlobal(nSize);
            try
            {
                Marshal.StructureToPtr(m_struTimeCfg, ptrTimeCfg, false);
                SdkHelper.InvokeSDK(() => CLIENT_SetDevConfig(session.UserId, (uint)EM_DEV_CFG_TYPE.TIMECFG, -1, ptrTimeCfg, (uint)nSize, session.CommandTimeout));
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

        private bool GetNewDevConfig(long lLoginID, int lChannel, string strCommand, ref object obj, Type typeName, int waittime)
        {
            bool returnValue = false;
            IntPtr pInBuf = IntPtr.Zero;
            IntPtr pOutBuf = IntPtr.Zero;
            IntPtr pLastBuf = IntPtr.Zero;

            uint nBufSize = 1024 * 1024;
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
                    returnValue = SdkHelper.InvokeSDK(() => CLIENT_GetNewDevConfig(lLoginID, strCommand, lChannel, pInBuf, nBufSize, out nError, waittime));

                    if (returnValue)
                    {
                        returnValue = SdkHelper.InvokeSDK(() => CLIENT_ParseData(strCommand, pInBuf, pOutBuf, (uint)Marshal.SizeOf(typeName), pLastBuf));

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

            return returnValue;
        }


        [DllImport(LIBRARYNETSDK)]
        private static extern bool CLIENT_GetDeviceSerialNo(long lLoginID, ref NET_IN_GET_DEVICESERIALNO_INFO pstInParam, ref NET_OUT_GET_DEVICESERIALNO_INFO pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        private static extern bool CLIENT_GetDeviceType(long lLoginID, ref NET_IN_GET_DEVICETYPE_INFO pstInParam, ref NET_OUT_GET_DEVICETYPE_INFO pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        private static extern bool CLIENT_GetMachineName(long lLoginID, ref NET_IN_GET_MACHINENAME_INFO pstInParam, ref NET_OUT_GET_MACHINENAME_INFO pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        private static extern bool CLIENT_GetNewDevConfig(long lLoginId, string szCommand, int nChannelId, IntPtr szOutBUffer, uint dwOutBufferSize, out int error, int nwaitTime);

        [DllImport(LIBRARYCONFIGSDK)]
        private static extern bool CLIENT_ParseData(string szCommand, IntPtr szInBuffer, IntPtr lpOutBuffer, UInt32 dwOutBufferSize, IntPtr pReserved);

        [DllImport(LIBRARYNETSDK)]
        private static extern bool CLIENT_GetSoftwareVersion(long lLoginID, ref NET_IN_GET_SOFTWAREVERSION_INFO pstInParam, ref NET_OUT_GET_SOFTWAREVERSION_INFO pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        private static extern bool CLIENT_GetDevConfig(long lLoginID, uint dwCommand, int lChannel, IntPtr lpOutBuffer, uint dwOutBufferSize, ref uint bytesReturned, int waittime);

        [DllImport(LIBRARYNETSDK)]
        private static extern bool CLIENT_SetDevConfig(long lLoginID, uint dwCommand, int lChannel, IntPtr lpInBuffer, uint dwInBufferSize, int waittime);

    }
}
