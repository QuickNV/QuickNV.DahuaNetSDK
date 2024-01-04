using System;
using System.Text;
using Dahua.Api.Service;
using Dahua.Api.Struct;

namespace Dahua.Api
{
    public class DahuaApi
    {
        /// <summary>
        /// 断开回调
        /// </summary>
        private static fDisConnect disConnect;
        private NET_DEVICEINFO deviceInfo;
        private ConfigService _ConfigService;
        private ChannelService _ChannelService;
        private PictureService _PictureService;

        private VideoService _VideoService;

        public int CommandTimeout { get; set; } = 5000;
        public long UserId { get; private set; }
        public bool Connected { get; private set; } = true;

        /// <summary>
        /// When connection is lost
        /// </summary>
        public event EventHandler Disconnected;

        private DahuaApi(long userId, NET_DEVICEINFO deviceInfo)
        {
            UserId = userId;
            this.deviceInfo = deviceInfo;
        }

        public string Host { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }


        public ChannelService ChannelService
        {
            get
            {
                if (_ChannelService == null)
                    _ChannelService = new ChannelService(this, deviceInfo);
                return _ChannelService;
            }
        }

        public VideoService VideoService
        {
            get
            {
                if (_VideoService == null)
                    _VideoService = new VideoService(this);
                return _VideoService;
            }
        }

        public PictureService PictureService
        {
            get
            {
                if (_PictureService == null)
                    _PictureService = new PictureService(this);
                return _PictureService;
            }
        }

        public ConfigService ConfigService
        {
            get
            {
                if (_ConfigService == null)
                    _ConfigService = new ConfigService(this);
                return _ConfigService;
            }
        }

        public static void Init()
        {
            disConnect = new fDisConnect(DisConnectEvent);
            DHClient.Init();
        }

        public void Logout()
        {
            if (!Connected)
                return;
            DHClient.DHLogout(UserId);
            OnDisconnected();
        }

        public static void Cleanup()
        {
            DHClient.Cleanup();
        }

        /// <summary>
        /// 设备断开连接处理
        /// </summary>
        /// <param name="lLoginID">登录ID</param>
        /// <param name="pchDVRIP">DVR设备IP</param>
        /// <param name="nDVRPort">DVR设备端口</param>
        /// <param name="dwUser">用户数据</param>
        private static void DisConnectEvent(int lLoginID, StringBuilder pchDVRIP, int nDVRPort, IntPtr dwUser)
        {
            Console.WriteLine("user disconnect");
        }

        public static DahuaApi Login(string host, int port, string username, string password)
        {
            var deviceInfo = new NET_DEVICEINFO();
            int error = 0;
            var pLoginID = DHClient.DHLogin(host, (ushort)port, username, password, out deviceInfo, out error);

            return new DahuaApi(pLoginID, deviceInfo);
        }

        private void OnDisconnected()
        {
            Connected = false;
            Disconnected?.Invoke(this, EventArgs.Empty);
        }
    }
}
