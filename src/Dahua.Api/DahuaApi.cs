using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Dahua.Api.Abstractions;
using Dahua.Api.Data;
using Dahua.Api.Helpers;
using Dahua.Api.Service;
using Dahua.Api.Struct;

namespace Dahua.Api
{
    /// <summary>
    /// DahuaApi
    /// </summary>
    public class DahuaApi : IDahuaApi, IDisposable
    {
        /// <summary>
        /// Disconnection callback function, which calls back the devices that have been disconnected from the current network. It does not call back the devices that are actively disconnected by calling the Cl IENT Log Out() function of the SDK.
        /// </summary>
        /// <param name="lLoginID">Device user login handle</param>
        /// <param name="pchDVRIP">DVR device IP</param>
        /// <param name="nDVRPort">DVR device connection port</param>
        /// <param name="dwUser">User data</param>
        private delegate void fDisConnect(int lLoginID, StringBuilder pchDVRIP, int nDVRPort, IntPtr dwUser);

        private static bool initialized = false;
        private IConfigService configService;
        private IPictureService pictureService;
        private IVideoService videoService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DahuaApi"/> class.
        /// </summary>
        public DahuaApi() { }

        private DahuaApi(long userId, string host, NET_DEVICEINFO deviceInfo)
        {
            UserId = userId;
            Host = host;
            RefreshChannelsInfo(deviceInfo);
        }

        /// <summary>
        /// When connection is lost
        /// </summary>
        public event EventHandler Disconnected;

        /// <summary>
        /// Gets all channels.
        /// </summary>
        /// <value>
        /// All channels.
        /// </value>
        public IReadOnlyCollection<IpChannel> AllChannels { get; private set; } = new List<IpChannel>();
        /// <summary>
        /// Gets or sets the command timeout.
        /// </summary>
        /// <value>
        /// The command timeout.
        /// </value>
        public int CommandTimeout { get; set; } = 5000;
        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public long UserId { get; private set; }
        /// <summary>
        /// Gets a value indicating whether this <see cref="DahuaApi" /> is connected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if connected; otherwise, <c>false</c>.
        /// </value>
        public bool Connected { get; private set; } = true;

        /// <summary>
        /// Gets the host.
        /// </summary>
        /// <value>
        /// The host.
        /// </value>
        public string Host { get; private set; }

        /// <summary>
        /// Gets the video service.
        /// </summary>
        /// <value>
        /// The video service.
        /// </value>
        public IVideoService VideoService
        {
            get
            {
                return videoService ??= new VideoService(this);
            }
        }

        /// <summary>
        /// Gets the picture service.
        /// </summary>
        /// <value>
        /// The picture service.
        /// </value>
        public IPictureService PictureService
        {
            get
            {
                return pictureService ??= new PictureService(this);
            }
        }

        /// <summary>
        /// Gets the configuration service.
        /// </summary>
        /// <value>
        /// The configuration service.
        /// </value>
        public IConfigService ConfigService
        {
            get
            {
                return configService ??= new ConfigService(this);
            }
        }

        /// <summary>
        /// Initialize digital video recorder
        /// </summary>
        public static void Init()
        {
            if (initialized == false)
            {
                SdkHelper.InvokeSDK(() => CLIENT_Init(null, IntPtr.Zero));
                initialized = true;
            }
        }

        /// <summary>
        /// Logouts this instance.
        /// </summary>
        public void Logout()
        {
            if (!Connected)
                return;
            SdkHelper.InvokeSDK(() => CLIENT_Logout(UserId));
            OnDisconnected();
        }

        /// <summary>
        ///  empty SDK, release occupied resource,call after all SDK functions
        /// </summary>
        public static void Cleanup()
        {
            CLIENT_Cleanup();
        }

        /// <summary>
        /// Logins the specified host.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="port">The port.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static DahuaApi Login(string host, int port, string username, string password)
        {
            var deviceInfo = new NET_DEVICEINFO();
            int error = 0;
            long loginId = SdkHelper.InvokeSDK<long>(() => CLIENT_Login(host, (ushort)port, username,password , ref deviceInfo, ref error));

            return new DahuaApi(loginId, host, deviceInfo);
        }

        /// <summary>
        /// Gets the RTSP URL.
        /// </summary>
        /// <param name="channelId">The channel identifier.</param>
        /// <param name="streamType">Type of the stream.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public string GetRtspUrl(int channelId, DahuaStreamType streamType, string userName, string password)
        {
            var rtspPort = ConfigService.GetRtspPort();
            UriBuilder uriBuilder = new UriBuilder() { Scheme = "rtsp", Host = this.Host, Port = rtspPort, UserName = userName, Password = password, Path = $"/cam/realmonitor?channel={channelId}&subtype={(int)streamType}" };
            return uriBuilder.ToString();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Logout();
        }

        private void OnDisconnected()
        {
            Connected = false;
            Disconnected?.Invoke(this, EventArgs.Empty);
        }

        private void RefreshChannelsInfo(NET_DEVICEINFO deviceInfo)
        {
            List<IpChannel> list = new List<IpChannel>();
            for (var i = 1; i <= deviceInfo.byChanNum; i++)
            {
                list.Add(new IpChannel(i));
            }
            AllChannels = list;
        }

        /// <summary>
        ///Register a user to the device. When the device sets the user to reuse (the device's default user, such as admin, cannot be set to reuse), you can use this account to register with the device multiple times.
        /// </summary>
        /// <param name="pchDVRIP">Device IP</param>
        /// <param name="wDVRPort">Device port</param>
        /// <param name="pchUserName">username</param>
        /// <param name="pchPassword">user password</param>
        /// <param name="lpDeviceInfo">Equipment information, belongs to the output parameter</param>
        /// <param name="error">Return to login error code</param>
        /// <returns>Failure to return 0, successfully return device ID</returns>
        [DllImport(DHConsts.LIBRARYNETSDK)]
        private static extern long CLIENT_Login(string pchDVRIP, ushort wDVRPort, string pchUserName, string pchPassword, ref NET_DEVICEINFO lpDeviceInfo, ref int error);

        /// <summary>
        /// Clients the cleanup.
        /// </summary>
        [DllImport(DHConsts.LIBRARYNETSDK)]
        private static extern void CLIENT_Cleanup();

        /// <summary>
        /// Initialize SDK
        /// </summary>
        /// <param name="cbDisConnect">
        /// Retrofit rejection function, see commissioned commission<seealso cref="fDisConnect"/>
        /// </param>
        /// <param name="dwUser">User Info</param>
        /// <returns>true: Success; False: Failure</returns>
        [DllImport(DHConsts.LIBRARYNETSDK)]
        private static extern bool CLIENT_Init(fDisConnect cbDisConnect, IntPtr dwUser);

        /// <summary>
        /// Logging out device users
        /// </summary>
        /// <param name="lLoginID">Device user login ID:<seealso cref="CLIENT_Login"/>The return value</param>
        /// <returns>true: Success; False: Failure</returns>
        [DllImport(DHConsts.LIBRARYNETSDK)]
        private static extern bool CLIENT_Logout(long lLoginID);
    }
}
