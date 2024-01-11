namespace Dahua.Api.Struct.Video
{
    /// <summary>
    /// Video file type
    /// </summary>
    internal enum RECORD_FILE_TYPE
    {
        /// <summary>
        /// 0: All video files
        /// </summary>
        ALLRECORDFILE,
        /// <summary>
        /// 1:External alarm
        /// </summary>
        OUTALARM,
        /// <summary>
        /// 2:Dynamic testing alarm
        /// </summary>
        DYNAMICSCANALARM,
        /// <summary>
        /// 3:All the alarm
        /// </summary>
        ALLALARM,
        /// <summary>
        /// 4:Card number query
        /// </summary>
        CARDNOSEACH,
        /// <summary>
        /// 5:Combining condition query
        /// </summary>
        COMBINEDSEACH
    }
}
