using System;

namespace Dahua.Api.Abstractions
{
    /// <summary>
    ///  ConfigService
    /// </summary>
    public interface IConfigService
    {
        /// <summary>
        /// Gets the device serial number.
        /// </summary>
        /// <returns></returns>
        string GetDeviceSerialNumber();
        /// <summary>
        /// Gets the type of the device.
        /// </summary>
        /// <returns></returns>
        string GetDeviceType();
        /// <summary>
        /// Gets the name of the machine.
        /// </summary>
        /// <returns></returns>
        string GetMachineName();
        /// <summary>
        /// Gets the RTSP port.
        /// </summary>
        /// <returns></returns>
        int GetRtspPort();
        /// <summary>
        /// Gets the name of the channel.
        /// </summary>
        /// <param name="channel">The channel.</param>
        /// <returns></returns>
        string GetChannelName(int channel);
        /// <summary>
        /// Gets the software version.
        /// </summary>
        /// <returns></returns>
        string GetSoftwareVersion();
        /// <summary>
        /// Gets the time.
        /// </summary>
        /// <returns></returns>
        DateTime GetTime();
        /// <summary>
        /// Sets the time.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        void SetTime(DateTime dateTime);
    }
}
