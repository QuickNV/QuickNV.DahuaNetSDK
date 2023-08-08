using Dahua.NetSDK.Api.Service;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Dahua.NetSDK.Api
{
    public class DhSession : IDisposable
    {
        private static fDisConnectCallBack fDisConnectCallBack;
        private static void NETClient_fDisConnectCallBack(IntPtr lLoginID, IntPtr pchDVRIP, int nDVRPort, IntPtr dwUser)
        {

        }

        public static void Init()
        {
            fDisConnectCallBack = new fDisConnectCallBack(NETClient_fDisConnectCallBack);
            if (!NETClient.Init(fDisConnectCallBack, IntPtr.Zero, null))
                throw new DahuaException("初始化失败");
        }

        public static DhSession Login(string host, int port, string username, string password)
        {
            var m_DeviceInfo = new NET_DEVICEINFO_Ex();
            var loginId = NETClient.LoginWithHighLevelSecurity(host, Convert.ToUInt16(port), username, password, EM_LOGIN_SPAC_CAP_TYPE.TCP, IntPtr.Zero, ref m_DeviceInfo);
            if (IntPtr.Zero == loginId)
                throw new DahuaException(NETClient.GetLastError());
            return new DhSession(loginId, m_DeviceInfo);
        }

        public string Host { get; private set; }
        public int Port { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public IntPtr UserId { get; private set; }
        private NET_DEVICEINFO_Ex deviceInfo;
        public bool IsOnline { get; private set; } = true;

        private DhSession(IntPtr userId, NET_DEVICEINFO_Ex deviceInfo)
        {
            UserId = userId;
            this.deviceInfo = deviceInfo;
        }

        public void Logout()
        {
            if (!IsOnline)
                return;
            IsOnline = false;
            NETClient.Logout(UserId);
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
