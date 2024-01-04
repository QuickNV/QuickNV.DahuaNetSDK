using System;
using System.Runtime.InteropServices;
using Dahua.Api.Struct.Config;

namespace Dahua.Api
{
    public partial class DHClient
    {
        /// <summary>
        /// 获取设备序列号
        /// </summary>
        /// <returns></returns>
        public static bool GetDeviceSerialNo(long lLoginID, ref NET_IN_GET_DEVICESERIALNO_INFO pstInParam, ref NET_OUT_GET_DEVICESERIALNO_INFO pstOutParam, int nWaitTime)
        {
            bool result = false;
            result = CLIENT_GetDeviceSerialNo(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
            DHThrowLastError(result);
            return result;
        }

        public static bool GetDeviceType(long lLoginID, NET_IN_GET_DEVICETYPE_INFO pstInParam, ref NET_OUT_GET_DEVICETYPE_INFO pstOutParam, int nWaitTime)
        {
            bool result = CLIENT_GetDeviceType(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
            DHThrowLastError(result);
            return result;
        }

        /// <summary>
        /// 获取机器名称
        /// </summary>
        /// <returns></returns>
        public static bool GetMachineName(long lLoginID, ref NET_IN_GET_MACHINENAME_INFO pstInParam, ref NET_OUT_GET_MACHINENAME_INFO pstOutParam, int nWaitTime)
        {
            bool result = false;
            result = CLIENT_GetMachineName(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
            DHThrowLastError(result);
            return result;
        }


        public static bool GetNewDevConfig(long lLoginID, Int32 lChannel, string strCommand, ref object obj, Type typeName, int waittime)
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
                    returnValue = CLIENT_GetNewDevConfig(lLoginID, strCommand, lChannel, pInBuf,
                                                         nBufSize, out nError, waittime);

                    if (returnValue == true)
                    {
                        returnValue = CLIENT_ParseData(strCommand, pInBuf, pOutBuf, (UInt32)Marshal.SizeOf(typeName), pLastBuf);

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
            DHThrowLastError(returnValue);
            return returnValue;
        }

        public static bool GetSoftwareVersion(long lLoginID, NET_IN_GET_SOFTWAREVERSION_INFO pstInParam, ref NET_OUT_GET_SOFTWAREVERSION_INFO pstOutParam, int nWaitTime)
        {
            bool result = false;
            result = CLIENT_GetSoftwareVersion(lLoginID, ref pstInParam, ref pstOutParam, nWaitTime);
            DHThrowLastError(result);
            return result;
        }

        public static bool GetDevConfig(long lLoginID, EM_DEV_CFG_TYPE type, int lChannel, IntPtr lpOutBuffer, uint dwOutBufferSize, ref uint bytesReturned, int waittime)
        {
            bool result = false;
            result = CLIENT_GetDevConfig(lLoginID, (uint)type, lChannel, lpOutBuffer, dwOutBufferSize, ref bytesReturned, waittime);
            DHThrowLastError(result);
            return result;
        }

        public static bool SetDevConfig(long lLoginID, EM_DEV_CFG_TYPE type, int lChannel, IntPtr lpInBuffer, uint dwInBufferSize, int waittime)
        {
            bool result = false;
            result = CLIENT_SetDevConfig(lLoginID, (uint)type, lChannel, lpInBuffer, dwInBufferSize, waittime);
            DHThrowLastError(result);
            return result;
        }

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetDeviceSerialNo(long lLoginID, ref NET_IN_GET_DEVICESERIALNO_INFO pstInParam, ref NET_OUT_GET_DEVICESERIALNO_INFO pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetDeviceType(long lLoginID, ref NET_IN_GET_DEVICETYPE_INFO pstInParam, ref NET_OUT_GET_DEVICETYPE_INFO pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetMachineName(long lLoginID, ref NET_IN_GET_MACHINENAME_INFO pstInParam, ref NET_OUT_GET_MACHINENAME_INFO pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetNewDevConfig(long lLoginId, string szCommand, int nChannelId, IntPtr szOutBUffer, uint dwOutBufferSize, out int error, int nwaitTime);

        [DllImport(LIBRARYCONFIGSDK)]
        public static extern bool CLIENT_ParseData(string szCommand, IntPtr szInBuffer, IntPtr lpOutBuffer, UInt32 dwOutBufferSize, IntPtr pReserved);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetSoftwareVersion(long lLoginID, ref NET_IN_GET_SOFTWAREVERSION_INFO pstInParam, ref NET_OUT_GET_SOFTWAREVERSION_INFO pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetDevConfig(long lLoginID, uint dwCommand, int lChannel, IntPtr lpOutBuffer, uint dwOutBufferSize, ref uint bytesReturned, int waittime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SetDevConfig(long lLoginID, uint dwCommand, int lChannel, IntPtr lpInBuffer, uint dwInBufferSize, int waittime);

    }
}
