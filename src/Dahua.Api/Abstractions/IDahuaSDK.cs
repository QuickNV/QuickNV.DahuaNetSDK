namespace Dahua.Api.Abstractions
{
    /// <summary>
    /// Dahua SDK
    /// </summary>
    public interface IDahuaSDK
    {
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        void Initialize();
        /// <summary>
        /// Logins the specified ip address.
        /// </summary>
        /// <param name="ipAddress">The ip address.</param>
        /// <param name="port">The port.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        IDahuaApi Login(string ipAddress, int port, string userName, string password);

        /// <summary>
        /// Cleanups this instance.
        /// </summary>
        void Cleanup();
    }
}
