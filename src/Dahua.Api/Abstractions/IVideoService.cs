using Dahua.Api.Data;
using System;
using System.Collections.Generic;

namespace Dahua.Api.Abstractions
{
    /// <summary>
    /// Video Service
    /// </summary>
    public interface IVideoService
    {
        /// <summary>
        /// Gets the videos.
        /// </summary>
        /// <param name="channelId">The channel identifier.</param>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <returns></returns>
        IReadOnlyCollection<IRemoteFile> GetVideos(int channelId, DateTime startTime, DateTime endTime);

        /// <summary>
        /// Downloads the by record file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        long DownloadByRecordFile(IRemoteFile file, string path);

        /// <summary>
        /// Gets the download position.
        /// </summary>
        /// <param name="fileHandler">The file handler.</param>
        /// <returns></returns>
        (bool success, int totalSize, int downloadSize) GetDownloadPos(long fileHandler);

        /// <summary>
        /// Stops the download.
        /// </summary>
        /// <param name="fileHandler">The file handler.</param>
        /// <returns></returns>
        bool StopDownload(long fileHandler);
    }
}
