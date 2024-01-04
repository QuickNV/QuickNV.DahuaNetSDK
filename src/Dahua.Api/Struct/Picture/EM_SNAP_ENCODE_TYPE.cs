using System;

namespace QuickNV.DahuaNetSDK
{
    /// <summary>
    /// 抓图图片编码格式
    /// Picture encoding format
    /// </summary>
    public enum EM_SNAP_ENCODE_TYPE
    {
        /// <summary>
        /// 未知
        /// Unknwon
        /// </summary>
        EM_SNAP_ENCODE_TYPE_UNKNOWN,
        /// <summary>
        /// jpeg图片
        /// Jpeg
        /// </summary>
        EM_SNAP_ENCODE_TYPE_JPEG,
        /// <summary>
        /// mpeg4的i 帧
        /// I frame of MPEG4
        /// </summary>
        EM_SNAP_ENCODE_TYPE_MPEG4_I,
    }
}