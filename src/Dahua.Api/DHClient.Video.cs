using System;
using System.Runtime.InteropServices;
using Dahua.Api.Struct;
using Dahua.Api.Struct.Video;

namespace Dahua.Api
{
    public partial class DHClient
    {
        /// <summary>
        /// Query video file
        /// </summary>
        /// <param name="lLoginID">Device user login handle</param>
        /// <param name="nChannelId">通道ID</param>
        /// <param name="nRecordFileType">录像文件类型 </param>
        /// <param name="tmStart">录像开始时间</param>
        /// <param name="tmEnd">录像结束时间</param>
        /// <param name="pchCardid">卡号,只针对卡号查询有效，其他情况下可以填NULL</param>
        /// <param name="nriFileinfo">返回的录像文件信息，是一个NET_RECORDFILE_INFO结构数组[录像文件信息为指定条]</param>
        /// <param name="maxlen">nriFileinfo缓冲的最大长度;[单位字节，大小为结构数组维数*sizeof(NET_RECORDFILE_INFO),数组维为大小等于1，建议小于２００]</param>
        /// <param name="filecount">返回的文件个数,属于输出参数最大只能查到缓冲满为止的录像记录</param>
        /// <param name="waittime">等待时间</param>
        /// <param name="bTime">是否按时间查(目前无效)</param>
        /// <returns>true:成功;false:失败</returns>
        public static bool DHQueryRecordFile(long lLoginID, int nChannelId, RECORD_FILE_TYPE nRecordFileType, DateTime tmStart, DateTime tmEnd, string pchCardid, ref NET_RECORDFILE_INFO[] nriFileinfo, int maxlen, out int filecount, int waittime, bool bTime)
        {
            bool returnValue = false;
            filecount = 0;
            IntPtr pBoxInfo = IntPtr.Zero;
            try
            {
                NET_TIME timeStart = ToNetTime(tmStart);
                NET_TIME timeEnd = ToNetTime(tmEnd);
                pBoxInfo = Marshal.AllocHGlobal(maxlen);//Allocate a fixed -specified memory space
                ulong fileCountMin = 0;
                if (pBoxInfo != IntPtr.Zero)
                {
                    returnValue = CLIENT_QueryRecordFile(lLoginID, nChannelId, (int)nRecordFileType, ref timeStart, ref timeEnd, pchCardid, pBoxInfo, maxlen, out filecount, waittime, bTime);
                    fileCountMin = ((ulong)filecount <= (ulong)nriFileinfo.Length ? (ulong)filecount : (ulong)nriFileinfo.Length);
                    for (ulong dwLoop = 0; dwLoop < fileCountMin; dwLoop++)
                    {
                        //Copy the data of the specified memory space in the specified format to the destination array
                        nriFileinfo[dwLoop] = (NET_RECORDFILE_INFO)Marshal.PtrToStructure((IntPtr)((UInt64)pBoxInfo + (ulong)Marshal.SizeOf(typeof(NET_RECORDFILE_INFO)) * dwLoop), typeof(NET_RECORDFILE_INFO));
                    }
                }
                DHThrowLastError(returnValue);

            }
            catch (Exception e)
            {
                DHThrowLastError(e);
                returnValue = false;
            }
            finally
            {
                Marshal.FreeHGlobal(pBoxInfo);//释放固定内存分配
                pBoxInfo = IntPtr.Zero;
            }
            return returnValue;
        }

        /// <summary>
        /// Download video files by file, download by queried file information
        /// </summary>
        /// <param name="lLoginID">Return value of CLIENT Login</param>
        /// <param name="lpRecordFile">Recording file information</param>
        /// <param name="sSavedFileName">Name of the video file to be saved, full path</param>
        /// <param name="cbDownLoadPos">Download progress callback function</param>
        /// <param name="dwUserData">Download progress callback user-defined data</param>
        /// <returns>The download ID is returned successfully, and 0 is returned if failed</returns>
        public static long DHDownloadByRecordFile(long lLoginID, NET_RECORDFILE_INFO lpRecordFile, string sSavedFileName, fDownLoadPosCallBack cbDownLoadPos, IntPtr dwUserData)
        {
            long intReturnValue = 0;
            intReturnValue = CLIENT_DownloadByRecordFile(lLoginID, ref lpRecordFile, sSavedFileName, cbDownLoadPos, dwUserData);
            DHThrowLastError();
            return intReturnValue;
        }

        /// <summary>
        /// Obtain the current position of the downloaded video, which can be used for interfaces that do not need to display the download progress in real time. It has a similar function to the download callback function.
        /// </summary>
        /// <param name="lFileHandle">Return value of CLIENT Download By Record File</param>
        /// <param name="nTotalSize">Total length of download, unit KB</param>
        /// <param name="nDownLoadSize">Downloaded length, unit KB</param>
        /// <returns>true: success; false: failure</returns>
        public static bool DHGetDownloadPos(long lFileHandle, out int nTotalSize, out int nDownLoadSize)
        {
            bool blnReturnValue = false;
            blnReturnValue = CLIENT_GetDownloadPos(lFileHandle, out nTotalSize, out nDownLoadSize);
            //DHThrowLastError();
            return blnReturnValue;
        }

        /// <summary>
        /// 停止下载录像文件
        /// </summary>
        /// <param name="lFileHandle">CLIENT_DownloadByRecordFile的返回值</param>
        /// <returns>true:成功;false:失败</returns>
        public static bool DHStopDownload(long lFileHandle)
        {
            bool blnReturnValue = false;
            blnReturnValue = CLIENT_StopDownload(lFileHandle);
            //DHThrowLastError(blnReturnValue);
            return blnReturnValue;
        }

        /// <summary>
        /// 查询录像文件
        /// </summary>
        /// <param name="lLoginID">设备用户登录句柄</param>
        /// <param name="nChannelId">通道ID</param>
        /// <param name="nRecordFileType">录像文件类型 </param>
        /// <param name="tmStart">录像开始时间</param>
        /// <param name="tmEnd">录像结束时间</param>
        /// <param name="pchCardid">卡号,只针对卡号查询有效，其他情况下可以填NULL</param>
        /// <param name="nriFileinfo">返回的录像文件信息，是一个NET_RECORDFILE_INFO结构数组</param>
        /// <param name="maxlen">nriFileinfo缓冲的最大长度;（单位字节，建议在100-200*sizeof(NET_RECORDFILE_INFO)之间）</param>
        /// <param name="filecount">返回的文件个数,属于输出参数最大只能查到缓冲满为止的录像记录</param>
        /// <param name="waittime">等待时间</param>
        /// <param name="bTime">是否按时间查(目前无效)</param>
        /// <returns>true:成功;false:失败</returns>
        [DllImport(LIBRARYNETSDK)]
        private static extern bool CLIENT_QueryRecordFile(long lLoginID, int nChannelId, int nRecordFileType, ref NET_TIME tmStart, ref NET_TIME tmEnd, string pchCardid, IntPtr nriFileinfo, int maxlen, out int filecount, int waittime, bool bTime);

        /// <summary>
        /// 按文件下载录像文件, 通过查询到的文件信息下载
        /// </summary>
        /// <param name="lLoginID">CLIENT_Login的返回值</param>
        /// <param name="lpRecordFile">录像文件信息</param>
        /// <param name="sSavedFileName">要保存的录像文件名，全路径</param>
        /// <param name="cbDownLoadPos">下载进度回调函数</param>
        /// <param name="dwUserData">下载进度回调用户自定义数据</param>
        /// <returns>成功返回下载ID，失败返回0</returns>
        [DllImport(LIBRARYNETSDK)]
        private static extern long CLIENT_DownloadByRecordFile(long lLoginID, ref NET_RECORDFILE_INFO lpRecordFile, string sSavedFileName, fDownLoadPosCallBack cbDownLoadPos, IntPtr dwUserData);

        /// <summary>
        /// Obtain the current position of the downloaded video, which can be used for interfaces that do not need to display the download progress in real time. It has a similar function to the download callback function.
        /// </summary>
        /// <param name="lFileHandle">Return value of CLIENT Download By Record File</param>
        /// <param name="nTotalSize">Total length of download, unit KB</param>
        /// <param name="nDownLoadSize">Downloaded length, unit KB</param>
        /// <returns>true: success; false: failure</returns>
        [DllImport(LIBRARYNETSDK)]
        private static extern bool CLIENT_GetDownloadPos(long lFileHandle, out int nTotalSize, out int nDownLoadSize);

        /// <summary>
        /// Stop downloading video files
        /// </summary>
        /// <param name="lFileHandle">Return value of CLIENT Download By Record File</param>
        /// <returns>true: success; false: failure</returns>
        [DllImport(LIBRARYNETSDK)]
        private static extern bool CLIENT_StopDownload(long lFileHandle);

    }
}
