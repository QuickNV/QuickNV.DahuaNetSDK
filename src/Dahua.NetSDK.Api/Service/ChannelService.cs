using Dahua.NetSDK.Api;
using System;
using System.Collections.Generic;
namespace Dahua.NetSDK.Api.Service
{
    public class ChannelService
    {
        private DhSession session;
        private int rtspPort;
        public IReadOnlyCollection<DhChannel> AllChannels { get; private set; }

        internal ChannelService(DhSession session, NET_DEVICEINFO_Ex deviceInfo)
        {
            this.session = session;
            RefreshChannelsInfo(deviceInfo);
            rtspPort = session.ConfigService.GetRtspPort();
        }

        private void RefreshChannelsInfo(NET_DEVICEINFO_Ex deviceInfo)
        {
            List<DhChannel> list = new List<DhChannel>();
            for (var i = 1; i <= deviceInfo.nChanNum; i++)
            {
                list.Add(new DhChannel(i));
            }
            AllChannels = list;
        }

        public void RefreshChannelName(DhChannel channel)
        {
            AV_CFG_ChannelName av_CFG_ChannelName = new AV_CFG_ChannelName();
            object refObj = av_CFG_ChannelName;
            if (!NETClient.GetNewDevConfig(session.UserId, channel.Id, SDK_NEWDEVCONFIG_CMD.CFG_CMD_CHANNELTITLE, ref refObj, typeof(AV_CFG_ChannelName), session.CommandTimeout))
                throw new DahuaException(NETClient.GetLastError());
            channel.Name = av_CFG_ChannelName.szName;
        }

        public void RefreshChannelsName()
        {
            foreach (var channel in AllChannels)
                RefreshChannelName(channel);
        }

        public void PTZControl(int channelId, EM_EXTPTZ_ControlType ptzCommand, bool isStop, int speed)
        {
            if (!NETClient.PTZControl(session.UserId, channelId, ptzCommand, 0, speed, 0, isStop, IntPtr.Zero))
                throw new DahuaException(NETClient.GetLastError());
        }

        public string GetRtspUrl(DhChannel channel, DhStreamType streamType)
        {
            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Scheme = "rtsp";
            uriBuilder.Host = session.Host;
            uriBuilder.Port = rtspPort;
            uriBuilder.UserName = session.UserName;
            uriBuilder.Password = session.Password;
            uriBuilder.Path = $"/cam/realmonitor?channel={channel.Id}&subtype={(int)streamType}";
            return uriBuilder.ToString();
        }

    }
}
