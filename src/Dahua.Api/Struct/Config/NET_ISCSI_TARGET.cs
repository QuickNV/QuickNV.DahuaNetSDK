using System;
using System.Runtime.InteropServices;

namespace Dahua.Api.Struct.Config
{
    /// <summary>
    /// ISCSI Target Info
    /// ISCSI Target信息
    /// </summary>
    public struct NET_ISCSI_TARGET
    {
        public uint dwSize;
        /// <summary>
        /// Name
        /// 名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string szName;
        /// <summary>
        /// service address
        /// 服务器地址
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szAddress;
        /// <summary>
        /// user name
        /// 用户名
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string szUser;
        /// <summary>
        /// port
        /// 端口
        /// </summary>
        public int nPort;
        /// <summary>
        /// status, 0- unknow, 1-connected, 2-un connected, 3-connect failed, 4-authentication failed, 5-connect time out	
        /// 状态, 0-未知, 1-已连接, 2-未连接, 3-连接失败, 4-认证失败, 5-连接超时, 6-不存在
        /// </summary>
        public uint nStatus;
    }
}