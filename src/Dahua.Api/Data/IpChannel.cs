namespace Dahua.Api.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class IpChannel
    {
        /// <summary>
        /// Channel number
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Channel name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        internal IpChannel(int id)
        {
            Id = id;
        }
    }
}
