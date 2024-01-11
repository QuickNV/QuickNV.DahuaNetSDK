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
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <param name="channelId">The channel identifier.</param>
        /// <returns></returns>
        IReadOnlyCollection<IRemoteFile> FindFiles(DateTime startTime, DateTime endTime, int channelId);

        /// <summary>
        /// Finds the files.
        /// </summary>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <returns></returns>
        IReadOnlyCollection<IRemoteFile> FindFiles(DateTime startTime, DateTime endTime);

        /// <summary>
        /// Downloads the by record file.
        /// </summary>
        /// <param name="remoteFile">The file.</param>
        /// <param name="destinationPath">The path.</param>
        /// <returns></returns>
        long StartDownloadFile(IRemoteFile remoteFile, string destinationPath);

        /// <summary>
        /// Gets the download position.
        /// </summary>
        /// <param name="fileHandler">The file handler.</param>
        /// <returns></returns>
        (bool success, int totalSize, int downloadSize) GetDownloadPosition(long fileHandler);

        /// <summary>
        /// Stops the download.
        /// </summary>
        /// <param name="fileHandler">The file handler.</param>
        /// <returns></returns>
        bool StopDownloadFile(long fileHandler);
    }
}
