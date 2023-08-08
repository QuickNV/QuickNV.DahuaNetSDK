using Dahua.NetSDK;

var host = "127.0.0.1";
var port = 37777;
var user = "admin";
var password = "123456";

try
{
    if(!NETClient.Init(null, IntPtr.Zero, null))
        throw new IOException($"初始化失败！");
    Console.WriteLine("初始化成功！");
    //登录
    Console.WriteLine("正在登录...");
    var m_DeviceInfo = new NET_DEVICEINFO_Ex();
    var loginID = NETClient.LoginWithHighLevelSecurity(host, Convert.ToUInt16(port), user, password, EM_LOGIN_SPAC_CAP_TYPE.TCP, IntPtr.Zero, ref m_DeviceInfo);
    if (loginID == IntPtr.Zero)
        throw new IOException($"登录失败，错误信息：{NETClient.GetLastError()}");
    Console.WriteLine("登录成功！");
    //退出登录
    bool result = NETClient.Logout(loginID);
    if (!result)
        throw new IOException($"退出登录失败，错误信息：{NETClient.GetLastError()}");
    Console.WriteLine("退出登录完成");
    //清理
    NETClient.Cleanup();
    Console.WriteLine("清理完成");
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}