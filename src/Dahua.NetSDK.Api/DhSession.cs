using Dahua.NetSDK.Api.Service;
using System;
using System.Collections.Generic;

namespace Dahua.NetSDK.Api
{
    public class DhSession : IDisposable
    {
        private static Dictionary<IntPtr, DhSession> sessionDict = new Dictionary<IntPtr, DhSession>();
        private static fDisConnectCallBack fDisConnectCallBack;
        private static void NETClient_fDisConnectCallBack(IntPtr lLoginID, IntPtr pchDVRIP, int nDVRPort, IntPtr dwUser)
        {
            DhSession session = null;
            lock (sessionDict)
            {
                if (!sessionDict.TryGetValue(lLoginID, out session))
                    return;
                sessionDict.Remove(lLoginID);
            }
            session.OnDisconnected();
        }

        public static void Init()
        {
            fDisConnectCallBack = new fDisConnectCallBack(NETClient_fDisConnectCallBack);
            if (!NETClient.Init(fDisConnectCallBack, IntPtr.Zero, null))
                throw new DahuaException("初始化失败");
        }
        
        public static void Cleanup()
        {
            NETClient.Cleanup();
        }

        public static DhSession Login(string host, int port, string username, string password)
        {
            return Login(host, port, username, password, EM_LOGIN_SPAC_CAP_TYPE.TCP);
        }

        public static DhSession Login(string host, int port, string username, string password, EM_LOGIN_SPAC_CAP_TYPE loginType)
        {
            var m_DeviceInfo = new NET_DEVICEINFO_Ex();
            var loginId = NETClient.LoginWithHighLevelSecurity(host, Convert.ToUInt16(port), username, password, loginType, IntPtr.Zero, ref m_DeviceInfo);
            if (IntPtr.Zero == loginId)
                throw new DahuaException(NETClient.GetLastError());
            var session = new DhSession(loginId, m_DeviceInfo);
            lock (sessionDict)
                sessionDict[session.UserId] = session;
            return session;
        }

        public int CommandTimeout { get; set; } = 5000;
        public string Host { get; private set; }
        public int Port { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public IntPtr UserId { get; private set; }
        private NET_DEVICEINFO_Ex deviceInfo;

        /// <summary>
        /// 是否连接
        /// </summary>
        public bool Connected { get; private set; } = true;
        
        /// <summary>
        /// 连接断开时
        /// </summary>
        public event EventHandler Disconnected;
        private void OnDisconnected()
        {
            Connected = false;
            Disconnected?.Invoke(this, EventArgs.Empty);
        }

        private DhSession(IntPtr userId, NET_DEVICEINFO_Ex deviceInfo)
        {
            UserId = userId;
            this.deviceInfo = deviceInfo;
        }

        public void Logout()
        {
            if (!Connected)
                return;
            NETClient.Logout(UserId);
            OnDisconnected();
        }

        public void Dispose()
        {
            Logout();
        }

        private ChannelService _ChannelService;
        public ChannelService ChannelService
        {
            get
            {
                if (_ChannelService == null)
                    _ChannelService = new ChannelService(this, deviceInfo);
                return _ChannelService;
            }
        }
        private ConfigService _ConfigService;
        public ConfigService ConfigService
        {
            get
            {
                if (_ConfigService == null)
                    _ConfigService = new ConfigService(this);
                return _ConfigService;
            }
        }
    }
}
