namespace Dahua.Api
{
    public class DhChannel
    {
        /// <summary>
        /// 通道编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 通道名称
        /// </summary>
        public string Name { get; set; }

        internal DhChannel(int id)
        {
            Id = id;
        }
    }
}
