using System;
using System.Collections.Generic;
using Dahua.Api.Struct;
using Dahua.Api.Struct.Channel;
using Dahua.Api.Struct.Config;

namespace Dahua.Api.Service
{
    public class ChannelService
    {
        private int rtspPort;
        private DahuaApi session;
        internal ChannelService(DahuaApi session, NET_DEVICEINFO deviceInfo)
        {
            this.session = session;
            RefreshChannelsInfo(deviceInfo);
            rtspPort = session.ConfigService.GetRtspPort();
        }

        public IReadOnlyCollection<DhChannel> AllChannels { get; private set; }

        public string GetRtspUrl(DhChannel channel, DhStreamType streamType)
        {
            UriBuilder uriBuilder = new UriBuilder() { Scheme = "rtsp", Host = session.Host, Port = rtspPort, UserName = session.UserName, Password = session.Password, Path = $"/cam/realmonitor?channel={channel.Id}&subtype={(int)streamType}" };
            return uriBuilder.ToString();
        }

        public void PTZControl(int channelId, EM_EXTPTZ_ControlType ptzCommand, bool isStop, int speed)
        {
            DHClient.PTZControl(session.UserId, channelId, ptzCommand, 0, speed, 0, isStop, IntPtr.Zero);
        }

        public void RefreshChannelName(DhChannel channel)
        {
            AV_CFG_ChannelName av_CFG_ChannelName = new AV_CFG_ChannelName();
            object refObj = av_CFG_ChannelName;
            DHClient.GetNewDevConfig(session.UserId, channel.Id, SDK_NEWDEVCONFIG_CMD.CFG_CMD_CHANNELTITLE, ref refObj, typeof(AV_CFG_ChannelName), session.CommandTimeout);

            channel.Name = av_CFG_ChannelName.szName;
        }

        public void RefreshChannelsName()
        {
            foreach (var channel in AllChannels)
                RefreshChannelName(channel);
        }

        private void RefreshChannelsInfo(NET_DEVICEINFO deviceInfo)
        {
            List<DhChannel> list = new List<DhChannel>();
            for (var i = 1; i <= deviceInfo.byChanNum; i++)
            {
                list.Add(new DhChannel(i));
            }
            AllChannels = list;
        }
    }
}
