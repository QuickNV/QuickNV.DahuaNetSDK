using System;
using System.Runtime.InteropServices;
using Dahua.Api.Struct.Picture;

namespace Dahua.Api.Service
{
    public class PictureService
    {
        private DahuaApi session;
        internal PictureService(DahuaApi session)
        {
            this.session = session;
        }

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
                DHClient.ManualSnap(session.UserId, ref in_stuct, ref out_stuct, session.CommandTimeout);

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

            DHClient.SnapPictureToFile(session.UserId, ref in_stuct, ref out_stuct, session.CommandTimeout);

        }
        public void SnapPictureToFile(int channelId)
        {
            DHClient.SnapPictureEx(session.UserId, new NET_SNAP_PARAMS()
            {
                Channel = Convert.ToUInt32(channelId),
                ImageSize = 2,
                mode = 0,
                Quality = 6
            }, IntPtr.Zero);
        }
    }
}
