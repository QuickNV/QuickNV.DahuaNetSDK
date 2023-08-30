# QuickNV.DahuaNetSDK.Api
* Avaliable as [nuget](https://www.nuget.org/packages/QuickNV.DahuaNetSDK.Api/) 

* [![NuGet Downloads](https://img.shields.io/nuget/dt/QuickNV.DahuaNetSDK.Api.svg)](https://www.nuget.org/packages/QuickNV.DahuaNetSDK.Api/)

* Api for Dahua NetSDK.

示例
```
using QuickNV.DahuaNetSDK.Api;

var host = "127.0.0.1";
var port = 37777;
var user = "admin";
var password = "123456";

try
{
    DhSession.Init();
    Console.WriteLine("初始化成功！");
    //登录
    Console.WriteLine("正在登录...");
    var session = DhSession.Login(host, port, user, password);
    Console.WriteLine("登录成功！");
    Console.WriteLine("设备时间: " + session.ConfigService.GetTime());
    Console.WriteLine("机器名称: " + session.ConfigService.GetMachineName());
    Console.WriteLine("设备序列号: " + session.ConfigService.GetDeviceSerialNumber());
    Console.WriteLine("设备类型: " + session.ConfigService.GetDeviceType());
    Console.WriteLine("正在读取通道名称...");
    session.ChannelService.RefreshChannelsName();
    Console.WriteLine("通道：" + string.Join(",", session.ChannelService.AllChannels.Select(t => $"通道{t.Id}_{t.Name}")));

    //退出登录
    session.Logout();
    Console.WriteLine("退出登录完成");

    //清理
    DhSession.Cleanup();
    Console.WriteLine("清理完成");
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
```