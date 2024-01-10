using System;
using System.Runtime.InteropServices;
using Dahua.Api.Helpers;
using Dahua.Api.Struct.Picture;
using static Dahua.Api.DHConsts;

namespace Dahua.Api.Service
{
    /// <summary>
    /// Picture Service
    /// </summary>
    public class PictureService
    {
        private readonly DahuaApi session;
        internal PictureService(DahuaApi session)
        {
            this.session = session;
        }

        /// <summary>
        /// Manual snap, Indicates concurrent calls
        /// </summary>
        public byte[] ManualSnap(int channelId)
        {
            NET_IN_MANUAL_SNAP in_stuct = default;
            in_stuct.dwSize = Convert.ToUInt32(Marshal.SizeOf(in_stuct));
            in_stuct.nChannel = Convert.ToUInt32(channelId);

            NET_OUT_MANUAL_SNAP out_stuct = default;
            out_stuct.dwSize = Convert.ToUInt32(Marshal.SizeOf(out_stuct));
            //Allocate 1MB space Save screenshot
            out_stuct.nMaxBufLen = 1 * 1024 * 1024;
            out_stuct.pRcvBuf = Marshal.AllocHGlobal(Convert.ToInt32(out_stuct.nMaxBufLen));

            try
            {

                SdkHelper.InvokeSDK(() => CLIENT_ManualSnap(session.UserId, ref in_stuct, ref out_stuct, session.CommandTimeout));

                var retBuffer = new byte[out_stuct.nRetBufLen];
                Marshal.Copy(out_stuct.pRcvBuf, retBuffer, 0, retBuffer.Length);
                return retBuffer;
            }
            catch
            {
                throw;
            }
            finally
            {
                Marshal.FreeHGlobal(out_stuct.pRcvBuf);
            }
        }

        /// <summary>
        /// Snaps the picture to file.
        /// </summary>
        /// <param name="channelId">The channel identifier.</param>
        /// <param name="fileName">Name of the file.</param>
        public void SnapPictureToFile(int channelId, string fileName)
        {
            NET_IN_SNAP_PIC_TO_FILE_PARAM in_stuct = default;
            in_stuct.dwSize = Convert.ToUInt32(Marshal.SizeOf(in_stuct));
            in_stuct.szFilePath = fileName;
            in_stuct.stuParam = new NET_SNAP_PARAMS()
            {
                Channel = Convert.ToUInt32(channelId),
                ImageSize = 2,
                mode = 0,
                Quality = 6
            };

            NET_OUT_SNAP_PIC_TO_FILE_PARAM out_stuct = default;
            out_stuct.dwSize = Convert.ToUInt32(Marshal.SizeOf(out_stuct));

            SdkHelper.InvokeSDK(() => CLIENT_SnapPictureToFile(session.UserId, ref in_stuct, ref out_stuct, session.CommandTimeout));

        }
        /// <summary>
        /// Snaps the picture to file.
        /// </summary>
        /// <param name="channelId">The channel identifier.</param>
        public void SnapPictureToFile(int channelId)
        {
            var in_param = new NET_SNAP_PARAMS()
            {
                Channel = Convert.ToUInt32(channelId),
                ImageSize = 2,
                mode = 0,
                Quality = 6
            };

            SdkHelper.InvokeSDK(() => CLIENT_SnapPictureEx(session.UserId, ref in_param, IntPtr.Zero));
        }

        /// <summary>
        /// Clients the manual snap.
        /// </summary>
        /// <param name="lLoginID">The l login identifier.</param>
        /// <param name="pInParam">The p in parameter.</param>
        /// <param name="pOutParam">The p out parameter.</param>
        /// <param name="nWaitTime">The n wait time.</param>
        /// <returns></returns>
        [DllImport(LIBRARYNETSDK)]
        private static extern bool CLIENT_ManualSnap(long lLoginID, ref NET_IN_MANUAL_SNAP pInParam, ref NET_OUT_MANUAL_SNAP pOutParam, int nWaitTime);


        /// <summary>
        /// snap picture to file
        /// </summary>
        /// <param name="lLoginID">user LoginID:Login's return value</param>
        /// <param name="inParam">snap picture to file in paramter</param>
        /// <param name="outParam">snap picture to file out paramter</param>
        /// <param name="nWaitTime">wait time</param>
        /// <returns>failed return false, successful return true</returns>
        [DllImport(LIBRARYNETSDK)]
        private static extern bool CLIENT_SnapPictureToFile(long lLoginID, ref NET_IN_SNAP_PIC_TO_FILE_PARAM inParam, ref NET_OUT_SNAP_PIC_TO_FILE_PARAM outParam, int nWaitTime);

        /// <summary>
        /// snapshot request
        /// </summary>
        /// <param name="lLoginID">user LoginID:Login's return value</param>
        /// <param name="par">Snapshot parameter(structure)</param>
        /// <param name="reserved">reserved</param>
        /// <returns>failed return false, successful return true</returns>
        [DllImport(LIBRARYNETSDK)]
        private static extern bool CLIENT_SnapPictureEx(long lLoginID, ref NET_SNAP_PARAMS par, IntPtr reserved);
    }
}
