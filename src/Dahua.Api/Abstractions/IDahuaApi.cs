using Dahua.Api.Data;
using Dahua.Api.Struct;
using System;
using System.Collections.Generic;

namespace Dahua.Api.Abstractions
{
    /// <summary>
    /// Dahua Api
    /// </summary>
    public interface IDahuaApi
    {
        /// <summary>
        /// Occurs when [disconnected].
        /// </summary>
        event EventHandler Disconnected;
        /// <summary>
        /// Gets all channels.
        /// </summary>
        /// <value>
        /// All channels.
        /// </value>
        IReadOnlyCollection<IpChannel> AllChannels { get; }

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        long UserId {  get; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IDahuaApi"/> is connected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if connected; otherwise, <c>false</c>.
        /// </value>
        bool Connected { get; }

        /// <summary>
        /// Gets the host.
        /// </summary>
        /// <value>
        /// The host.
        /// </value>
        string Host {  get; }

        /// <summary>
        /// Gets the video service.
        /// </summary>
        /// <value>
        /// The video service.
        /// </value>
        IVideoService VideoService { get; }
        /// <summary>
        /// Gets the picture service.
        /// </summary>
        /// <value>
        /// The picture service.
        /// </value>
        IPictureService PictureService { get; }

        /// <summary>
        /// Gets the configuration service.
        /// </summary>
        /// <value>
        /// The configuration service.
        /// </value>
        IConfigService ConfigService { get; }

        /// <summary>
        /// Logouts this instance.
        /// </summary>
        void Logout();

        /// <summary>
        /// Gets the RTSP URL.
        /// </summary>
        /// <param name="channelId">The channel identifier.</param>
        /// <param name="streamType">Type of the stream.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        string GetRtspUrl(int channelId, DahuaStreamType streamType, string userName, string password);
    }
}
