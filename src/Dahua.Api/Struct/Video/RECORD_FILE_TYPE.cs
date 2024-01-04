namespace Dahua.Api.Struct.Video
{
    /// <summary>
    /// 录像文件类型
    /// </summary>
    public enum RECORD_FILE_TYPE
    {
        /// <summary>
        /// 0:所有录像文件
        /// </summary>
        ALLRECORDFILE,
        /// <summary>
        /// 1:外部报警
        /// </summary>
        OUTALARM,
        /// <summary>
        /// 2:动态检测报警
        /// </summary>
        DYNAMICSCANALARM,
        /// <summary>
        /// 3:所有报警
        /// </summary>
        ALLALARM,
        /// <summary>
        /// 4:卡号查询
        /// </summary>
        CARDNOSEACH,
        /// <summary>
        /// 5:组合条件查询
        /// </summary>
        COMBINEDSEACH
    }
}
