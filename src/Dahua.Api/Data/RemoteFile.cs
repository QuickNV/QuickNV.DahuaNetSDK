using Dahua.Api.Struct.Video;
using System;

namespace Dahua.Api.Data
{
    /// <summary>
    /// Remote File
    /// </summary>
    /// <seealso cref="Dahua.Api.Data.IRemoteFile" />
    public class RemoteFile: IRemoteFile
    {
        internal readonly NET_RECORDFILE_INFO Original;

        internal RemoteFile(NET_RECORDFILE_INFO findData)
        {
            Original = findData;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name => System.Text.Encoding.UTF8.GetString(Original.filename).TrimEnd('\0');

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime Date => Original.starttime.ToDateTime();

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        public int Duration => (int)(Original.endtime.ToDateTime() - Original.starttime.ToDateTime()).TotalSeconds;

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public uint Size => Original.size;
    }
}
