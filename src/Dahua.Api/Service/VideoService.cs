using System;
using System.Linq;
using System.Runtime.InteropServices;
using Dahua.Api.Struct.Video;

namespace Dahua.Api.Service
{
    public class VideoService
    {
        /// <summary>
        /// Most query files
        /// </summary>
        private const int intFilesMaxCount = 1024;

        /// <summary>
        /// File information query results
        /// </summary>
        private NET_RECORDFILE_INFO[] nriFileInfo = Array.Empty<NET_RECORDFILE_INFO>();

        /// <summary>
        /// Download back adjustment
        /// </summary>
        private fDownLoadPosCallBack downLoadFun;


        private DahuaApi session;
        internal VideoService(DahuaApi session)
        {
            this.session = session;
            downLoadFun = new fDownLoadPosCallBack(DownLoadPosFun);
        }

        public NET_RECORDFILE_INFO[] GetVideos(int channelId, DateTime tmStart, DateTime tmEnd)
        {
            nriFileInfo = new NET_RECORDFILE_INFO[intFilesMaxCount];
            int intFileCount = default;

            try
            {
                bool blnQueryRecordFile = false;
                blnQueryRecordFile = DHClient.DHQueryRecordFile(
                    session.UserId,
                    channelId,
                    RECORD_FILE_TYPE.ALLRECORDFILE,
                    tmStart,
                    tmEnd,
                    null,
                    ref nriFileInfo,
                    intFilesMaxCount * Marshal.SizeOf(typeof(NET_RECORDFILE_INFO)),
                    out intFileCount,
                    5000,
                    false);
            }
            catch
            {
                throw;
            }

            return nriFileInfo.Where(x => x.filename?.Length > 0 ).ToArray();
        }


        public long DownloadByRecordFile(NET_RECORDFILE_INFO fileInfo, string path)
        {
            var strFileName = path.ToLower();
            if (!strFileName.EndsWith(".dav"))
            {
                strFileName += ".dav";
            }

            var result = DHClient.DHDownloadByRecordFile(session.UserId, fileInfo, strFileName, downLoadFun, IntPtr.Zero);
            return result;
        }


        public (bool blnReturnValue, int nTotalSize, int nDownLoadSize) GetDownloadPos(long lFileHandle)
        {
            bool blnReturnValue;
            blnReturnValue = DHClient.DHGetDownloadPos(lFileHandle, out int nTotalSize, out int nDownLoadSize);
            return (blnReturnValue, nTotalSize, nDownLoadSize);
        }

        public bool StopDownload(long lPlayHandle)
        {
            return DHClient.DHStopDownload(lPlayHandle);
        }

        /// <summary>
        /// Download callback
        /// </summary>
        /// <param name="lPlayHandle">Play handle</param>
        /// <param name="dwTotalSize">Total size</param>
        /// <param name="dwDownLoadSize">Download Size</param>
        /// <param name="dwUser">User data</param>
        private void DownLoadPosFun(long lPlayHandle, UInt32 dwTotalSize, UInt32 dwDownLoadSize, IntPtr dwUser)
        {
            if (lPlayHandle > 0)
            {
                if (0xFFFFFFFF == dwDownLoadSize || 0xFFFFFFFE == dwDownLoadSize)
                {
                    DHClient.DHStopDownload(lPlayHandle);
                }
            }
        }
    }
}
