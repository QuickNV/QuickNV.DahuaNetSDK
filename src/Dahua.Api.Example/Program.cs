using Dahua.Api;

var host = "192.168.1.63";
var port = 37777;
var user = "admin";
var password = "password";
string DateFormat = "yyyyMMdd_HHmmss";
string TimeFormat = "HHmmss";

try
{
    DahuaApi.Init();
    Console.WriteLine("Initialization successful!");
    //Log in
    Console.WriteLine("Logging in...");
    var session = DahuaApi.Login(host, port, user, password);
    Console.WriteLine("Login successful!");
    Console.WriteLine("Device time: " + session.ConfigService.GetTime());
    Console.WriteLine("Machine name: " + session.ConfigService.GetMachineName());
    Console.WriteLine("Device serial number: " + session.ConfigService.GetDeviceSerialNumber());
    Console.WriteLine("Device type: " + session.ConfigService.GetDeviceType());


    var videos = session.VideoService.GetVideos(0, DateTime.Today, DateTime.Now);


    Console.WriteLine($"Found {videos.Length} videos");
    foreach (var video in videos)
    {

        var name = $"{video.starttime.ToDateTime().ToString(DateFormat)}_{video.endtime.ToDateTime().ToString(TimeFormat)}.dav";

        var destinationPath = Path.Combine("C:\\Users\\vkhmelovskyi\\Desktop\\bin", name);
        var downloadId = session.VideoService.DownloadByRecordFile(video, destinationPath);
        if (downloadId > 0)
        {
            Console.WriteLine($"Downloding {destinationPath}");
            do
            {
                await Task.Delay(5000);
                var downloadProgress = session.VideoService.GetDownloadPos(downloadId);
                Console.WriteLine($"Downloding {downloadProgress} %");
                if (downloadProgress.nDownLoadSize == downloadProgress.nTotalSize)
                {
                    session.VideoService.StopDownload(downloadId);
                    break;
                }
                else if (!downloadProgress.blnReturnValue)
                {
                    throw new InvalidOperationException($"UpdateDownloadProgress failed, progress value = {downloadProgress}");
                }
            }
            while (true);
            Console.WriteLine($"Downloaded {destinationPath}");
        }
        break;
    }


    session.ChannelService.RefreshChannelsName();
    Console.WriteLine("Channel:" + string.Join(",", session.ChannelService.AllChannels.Select(t => $"Channel{t.Id}_{t.Name}")));

    //sign out
    session.Logout();
    Console.WriteLine("Logout completed");

    //Clean up
    DahuaApi.Cleanup();
    Console.WriteLine("Cleaning completed");
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}