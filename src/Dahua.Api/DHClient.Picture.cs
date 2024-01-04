using System;
using System.Runtime.InteropServices;
using Dahua.Api.Struct.Picture;

namespace Dahua.Api
{
    public partial class DHClient
    {
        /// <summary>
        /// Manual snap, Indicates concurrent calls
        /// </summary>
        public static bool ManualSnap(long lLoginID, ref NET_IN_MANUAL_SNAP pInParam, ref NET_OUT_MANUAL_SNAP pOutParam, int nWaitTime)
        {
            bool result = false;
            result = CLIENT_ManualSnap(lLoginID, ref pInParam, ref pOutParam, nWaitTime);
            DHThrowLastError(result);
            return result;
        }

        /// <summary>
        /// snap picture to file
        /// </summary>
        /// <param name="lLoginID">user LoginID:Login's return value</param>
        /// <param name="inParam">snap picture to file in paramter</param>
        /// <param name="outParam">snap picture to file out paramter</param>
        /// <param name="nWaitTime">wait time</param>
        /// <returns>failed return false, successful return true</returns>
        public static bool SnapPictureToFile(long lLoginID, ref NET_IN_SNAP_PIC_TO_FILE_PARAM inParam, ref NET_OUT_SNAP_PIC_TO_FILE_PARAM outParam, int nWaitTime)
        {
            bool result = false;
            result = CLIENT_SnapPictureToFile(lLoginID, ref inParam, ref outParam, nWaitTime);
            DHThrowLastError(result);
            return result;
        }

        /// <summary>
        /// snapshot request
        /// </summary>
        /// <param name="lLoginID">user LoginID:Login's return value</param>
        /// <param name="par">Snapshot parameter(structure)</param>
        /// <param name="reserved">reserved</param>
        /// <returns>failed return false, successful return true</returns>
        public static bool SnapPictureEx(long lLoginID, NET_SNAP_PARAMS par, IntPtr reserved)
        {
            bool result = false;
            result = CLIENT_SnapPictureEx(lLoginID, ref par, reserved);
            DHThrowLastError(result);
            return result;
        }

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_ManualSnap(long lLoginID, ref NET_IN_MANUAL_SNAP pInParam, ref NET_OUT_MANUAL_SNAP pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SnapPictureToFile(long lLoginID, ref NET_IN_SNAP_PIC_TO_FILE_PARAM inParam, ref NET_OUT_SNAP_PIC_TO_FILE_PARAM outParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SnapPictureEx(long lLoginID, ref NET_SNAP_PARAMS par, IntPtr reserved);
    }
}
