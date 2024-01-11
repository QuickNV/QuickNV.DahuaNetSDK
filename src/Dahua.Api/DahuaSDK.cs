using Dahua.Api.Abstractions;

namespace Dahua.Api
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Dahua.Api.Abstractions.IDahuaSDK" />
    public class DahuaSDK : IDahuaSDK
    {
        /// <summary>
        /// Cleanups this instance.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Cleanup()
        {
            DahuaApi.Cleanup();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Initialize()
        {
            DahuaApi.Init();
        }

        /// <summary>
        /// Logins the specified ip address.
        /// </summary>
        /// <param name="ipAddress">The ip address.</param>
        /// <param name="port">The port.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IDahuaApi Login(string ipAddress, int port, string userName, string password)
        {
            return DahuaApi.Login(ipAddress, port, userName, password);
        }
    }
}
