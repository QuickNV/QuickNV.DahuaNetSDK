using System;
using System.Runtime.InteropServices;

namespace Dahua.NetSDK
{
    internal static class OriginalSDK
    {
        const string LIBRARYNETSDK = "dhnetsdk";
        const string LIBRARYCONFIGSDK = "dhconfigsdk";
        const string LIBRARYPLAYSDK = "dhplay";

        [DllImport(LIBRARYNETSDK)]
        public static extern int CLIENT_GetLastError();

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_InitEx(fDisConnectCallBack cbDisConnect, IntPtr dwUser, IntPtr lpInitParam);

        [DllImport(LIBRARYNETSDK)]
        public static extern void CLIENT_SetConnectTime(int nWaitTime, int nTryTimes);

        [DllImport(LIBRARYNETSDK)]
        public static extern void CLIENT_Cleanup();

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_LoginEx2(string pchDVRIP, ushort wDVRPort, string pchUserName, string pchPassword, EM_LOGIN_SPAC_CAP_TYPE emSpecCap, IntPtr pCapParam, ref NET_DEVICEINFO_Ex lpDeviceInfo, ref int error);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_Logout(IntPtr lLoginID);

        [DllImport(LIBRARYNETSDK)]
        public static extern void CLIENT_SetAutoReconnect(fHaveReConnectCallBack cbAutoConnect, IntPtr dwUser);

        [DllImport(LIBRARYNETSDK)]
        public static extern void CLIENT_SetNetworkParam(IntPtr pNetParam);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_StartRealPlay(IntPtr lLoginID, int nChannelID, IntPtr hWnd, EM_RealPlayType rType, fRealDataCallBackEx cbRealData, fRealPlayDisConnectCallBack cbDisconnect, IntPtr dwUser, uint dwWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StopRealPlayEx(IntPtr lRealHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_RealPlayEx(IntPtr lLoginID, int nChannelID, IntPtr hWnd, EM_RealPlayType rType);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SetRealDataCallBackEx2(IntPtr lRealHandle, fRealDataCallBackEx2 cbRealData, IntPtr dwUser, uint dwFlag);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SaveRealData(IntPtr lRealHandle, string pchFileName);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StopSaveRealData(IntPtr lRealHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern void CLIENT_SetSnapRevCallBack(fSnapRevCallBack OnSnapRevMessage, IntPtr dwUser);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SnapPictureEx(IntPtr lLoginID, ref NET_SNAP_PARAMS par, IntPtr reserved);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SnapPictureToFile(IntPtr lLoginID, ref NET_IN_SNAP_PIC_TO_FILE_PARAM inParam, ref NET_OUT_SNAP_PIC_TO_FILE_PARAM outParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_PlayBackByTimeEx2(IntPtr lLoginID, int nChannelID, ref NET_IN_PLAY_BACK_BY_TIME_INFO pstNetIn, ref NET_OUT_PLAY_BACK_BY_TIME_INFO pstNetOut);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_QueryRecordFile(IntPtr lLoginID, int nChannelId, int nRecordFileType, ref NET_TIME tmStart, ref NET_TIME tmEnd, string pchCardid, IntPtr nriFileinfo, int maxlen, ref int filecount, int waittime, bool bTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_QueryRecordStatus(IntPtr lLoginID, int nChannelId, int nRecordFileType, ref NET_TIME tmMonth, string pchCardid, ref NET_RECORD_STATUS pRecordStatus, int waittime = 1000);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetPlayBackOsdTime(IntPtr lPlayHandle, ref NET_TIME lpOsdTime, ref NET_TIME lpStartTime, ref NET_TIME lpEndTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_CapturePictureEx(IntPtr hPlayHandle, string pchPicFileName, EM_NET_CAPTURE_FORMATS eFormat);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StopPlayBack(IntPtr lPlayHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_DownloadByTimeEx(IntPtr lLoginID, int nChannelId, int nRecordFileType, ref NET_TIME tmStart, ref NET_TIME tmEnd, string sSavedFileName,
            fTimeDownLoadPosCallBack cbTimeDownLoadPos, IntPtr dwUserData,
            fDataCallBack fDownLoadDataCallBack, IntPtr dwDataUser, IntPtr pReserved);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StopDownload(IntPtr lFileHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetDownloadPos(IntPtr lFileHandle, ref int nTotalSize, ref int nDownLoadSize);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_DHPTZControlEx2(IntPtr lLoginID, int nChannelID, uint dwPTZCommand, int lParam1, int lParam2, int lParam3, bool dwStop, IntPtr param4);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_OpenSound(IntPtr hPlayHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_CloseSound();

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_PausePlayBack(IntPtr lPlayHandle, bool bPause);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_FastPlayBack(IntPtr lPlayHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SlowPlayBack(IntPtr lPlayHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_NormalPlayBack(IntPtr lPlayHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SetDeviceMode(IntPtr lLoginID, EM_USEDEV_MODE emType, IntPtr pValue);

        [DllImport(LIBRARYNETSDK)]
        public static extern void CLIENT_SetDVRMessCallBackEx1(fMessCallBackEx cbMessage, IntPtr dwUser);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StartListenEx(IntPtr lLoginID);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StopListen(IntPtr lLoginID);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_RealLoadPictureEx(IntPtr lLoginID, int nChannelID, uint dwAlarmType, bool bNeedPicFile, fAnalyzerDataCallBack cbAnalyzerData, IntPtr dwUser, IntPtr reserved);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StopLoadPic(IntPtr lAnalyzerHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_QuerySystemInfo(IntPtr lLoginID, int nSystemType, IntPtr pSysInfoBuffer, int maxlen, ref int nSysInfolen, int waittime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_QueryDeviceLog(IntPtr lLoginID, ref NET_QUERY_DEVICE_LOG_PARAM pQueryParam, IntPtr pLogBuffer, int nLogBufferLen, ref int pRecLogNum, int waittime);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_StartTalkEx(IntPtr lLoginID, fAudioDataCallBack pfcb, IntPtr dwUser);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StopTalkEx(IntPtr lTalkHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_RecordStartEx(IntPtr lLoginID);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_RecordStopEx(IntPtr lLoginID);

        [DllImport(LIBRARYNETSDK)]
        public static extern int CLIENT_TalkSendData(IntPtr lTalkHandle, IntPtr pSendBuf, uint dwBufSize);

        [DllImport(LIBRARYNETSDK)]
        public static extern void CLIENT_AudioDec(IntPtr pAudioDataBuf, uint dwBufSize);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_ControlDevice(IntPtr lLoginID, EM_CtrlType type, IntPtr param, int waittime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_ControlDeviceEx(IntPtr lLoginID, EM_CtrlType emType, IntPtr pInBuf, IntPtr pOutBuf, int nWaitTime);
        
        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_QueryDevState(IntPtr lLoginID, int nType, IntPtr pBuf, int nBufLen, ref int pRetLen, int waittime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_QueryNewSystemInfo(IntPtr lLoginID, string szCommand, Int32 nChannelID, IntPtr szOutBuffer, UInt32 dwOutBufferSize, ref UInt32 error, Int32 waittime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_QueryNewSystemInfoEx(IntPtr lLoginID, string szCommand, Int32 nChannelID, IntPtr szOutBuffer, UInt32 dwOutBufferSize, ref UInt32 error, IntPtr pExtendInfo, Int32 waittime);
        
        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_FindRecord(IntPtr lLoginID, ref NET_IN_FIND_RECORD_PARAM pInParam, ref NET_OUT_FIND_RECORD_PARAM pOutParam, int waittime);

        [DllImport(LIBRARYNETSDK)]
        public static extern int CLIENT_FindNextRecord(ref NET_IN_FIND_NEXT_RECORD_PARAM pInParam, ref NET_OUT_FIND_NEXT_RECORD_PARAM pOutParam, int waittime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_QueryRecordCount(ref NET_IN_QUEYT_RECORD_COUNT_PARAM pInParam, ref NET_OUT_QUEYT_RECORD_COUNT_PARAM pOutParam, int waittime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_FindRecordClose(IntPtr lFindHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_StartFindNumberStat(IntPtr lLoginID, ref NET_IN_FINDNUMBERSTAT pstInParam, ref NET_OUT_FINDNUMBERSTAT pstOutParam);

        [DllImport(LIBRARYNETSDK)]
        public static extern int CLIENT_DoFindNumberStat(IntPtr lFindHandle, ref NET_IN_DOFINDNUMBERSTAT pstInParam, ref NET_OUT_DOFINDNUMBERSTAT pstOutParam);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StopFindNumberStat(IntPtr lFindHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_AttachVideoStatSummary(IntPtr lLoginID, ref NET_IN_ATTACH_VIDEOSTAT_SUM pInParam, ref NET_OUT_ATTACH_VIDEOSTAT_SUM pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_DetachVideoStatSummary(IntPtr lAttachHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_CreateTransComChannel(IntPtr lLoginID, int TransComType, uint baudrate, uint databits, uint stopbits, uint parity, fTransComCallBack cbTransCom, IntPtr dwUser);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SendTransComData(IntPtr lTransComChannel, IntPtr pBuffer, uint dwBufSize);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_DestroyTransComChannel(IntPtr lTransComChannel);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SetSecurityKey(IntPtr lPlayHandle, string szKey, uint nKeyLen);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_QueryMatrixCardInfo(IntPtr lLoginID, ref NET_MATRIX_CARD_LIST pstuCardList, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SetNewDevConfig(IntPtr lLoginID, string szCommand, int nChannelId, IntPtr szInBuffer, uint dwInBufferSize, ref int error, ref int restart, int waittime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetNewDevConfig(IntPtr lLoginId, string szCommand, int nChannelId, IntPtr szOutBUffer, uint dwOutBufferSize, out int error, int nwaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetSplitCaps(IntPtr lLoginId, int nChannel, ref NET_SPLIT_CAPS pstuCaps, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetSplitMode(IntPtr lLoginID, int nChannel, ref NET_SPLIT_MODE_INFO pstuSplitInfo, int nWaitTime = 1000);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SetSplitMode(IntPtr lLoginID, int nChannel, ref NET_SPLIT_MODE_INFO pstuSplitInfo, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_OpenSplitWindow(IntPtr lLoginID, ref NET_IN_SPLIT_OPEN_WINDOW pInParam, ref NET_OUT_SPLIT_OPEN_WINDOW pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_MatrixSetCameras(IntPtr lLoginID, ref NET_IN_MATRIX_SET_CAMERAS pInParam, ref NET_OUT_MATRIX_SET_CAMERAS pOutParam, int nWaitTime = 1000);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_MatrixGetCameras(IntPtr lLoginID, ref NET_IN_MATRIX_GET_CAMERAS pInParam, ref NET_OUT_MATRIX_GET_CAMERAS pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SetSplitSource(IntPtr lLoginID, int nChannel, int nWindow, IntPtr pstuSplitSrc, int nSrcCount, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SetSplitSourceEx(IntPtr lLoginID, ref NET_IN_SET_SPLIT_SOURCE pInparam, ref NET_OUT_SET_SPLIT_SOURCE pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_OperateFaceRecognitionDB(IntPtr lLoginID, ref NET_IN_OPERATE_FACERECONGNITIONDB pstInParam, ref NET_OUT_OPERATE_FACERECONGNITIONDB pstOutParam, Int32 nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_DetectFace(IntPtr lLoginID, ref NET_IN_DETECT_FACE pstInParam, ref NET_OUT_DETECT_FACE pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_FindFileEx(IntPtr lLoginID, EM_FILE_QUERY_TYPE emType, IntPtr pQueryCondition, IntPtr reserved, int waittime);

        [DllImport(LIBRARYNETSDK)]
        public static extern int CLIENT_FindNextFileEx(IntPtr lFindHandle, int nFilecount, IntPtr pMediaFileInfo, int maxlen, IntPtr reserved, int waittime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_FindCloseEx(IntPtr lFindHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_AttachFaceFindState(IntPtr lLoginID, ref NET_IN_FACE_FIND_STATE pstInParam, ref NET_OUT_FACE_FIND_STATE pstOutParam, Int32 nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_DetachFaceFindState(IntPtr lAttachHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StartFindFaceRecognition(IntPtr lLoginID, IntPtr pstInParam, IntPtr pstOutParam, Int32 nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StartMultiFindFaceRecognition(IntPtr lLoginID, IntPtr pInParam, IntPtr pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_DoFindFaceRecognition(IntPtr pstInParam, IntPtr pstOutParam, Int32 nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StopFindFaceRecognition(IntPtr lFindHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetTotalFileCount(IntPtr lFindHandle, ref Int32 pTotalCount, IntPtr reserved, Int32 waittime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SetFindingJumpOption(IntPtr lFindHandle, ref NET_FINDING_JUMP_OPTION_INFO pOption, IntPtr reserved, int waittime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_QueryDeviceTime(IntPtr lLoginID, ref NET_TIME pDeviceTime, int waittime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SetupDeviceTime(IntPtr lLoginID, ref NET_TIME pDeviceTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_ClearRepeatEnter(IntPtr lLoginID, ref NET_IN_CLEAR_REPEAT_ENTER pInParam, ref NET_OUT_CLEAR_REPEAT_ENTER pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_QueryDevInfo(IntPtr lLoginID, int nQueryType, IntPtr pInBuf, IntPtr pOutBuf, IntPtr pReserved, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_FindGroupInfo(IntPtr lLoginID, ref NET_IN_FIND_GROUP_INFO pstInParam, ref NET_OUT_FIND_GROUP_INFO pstOutParam, int nWaitTime);

        [DllImport(LIBRARYCONFIGSDK)]
        public static extern bool CLIENT_ParseData(string szCommand, IntPtr szInBuffer, IntPtr lpOutBuffer, UInt32 dwOutBufferSize, IntPtr pReserved);

        [DllImport(LIBRARYCONFIGSDK)]
        public static extern bool CLIENT_PacketData(string szCommand, IntPtr lpInBuffer, uint dwInBufferSize, IntPtr szOutBuffer, uint dwOutFufferSize);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_OperateFaceRecognitionGroup(IntPtr lLoginID, ref NET_IN_OPERATE_FACERECONGNITION_GROUP pstInParam, ref NET_OUT_OPERATE_FACERECONGNITION_GROUP pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetConfig(IntPtr lLoginID, int emCfgOpType, int nChannelID, IntPtr szOutBuffer, uint dwOutBufferSize, int waittime, IntPtr reserve);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SetConfig(IntPtr lLoginID, int emCfgOpType, int nChannelID, IntPtr szInBuffer, uint dwInBufferSize, int waittime, IntPtr restart, IntPtr reserve);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_OperateSplit(IntPtr lLoginID, EM_NET_SPLIT_OPERATE_TYPE emType, IntPtr pInParam, IntPtr pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_OperateSplitPlayer(IntPtr lLoginID, EM_NET_PLAYER_OPERATE_TYPE emType, IntPtr pInParam, IntPtr pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetSplitWindowsInfo(IntPtr lLoginID, IntPtr pInParam, IntPtr pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_WindowRegionEnlarge(IntPtr lLoginID, ref NET_IN_WINDOW_REGION_ENLARGE pInParam, ref NET_OUT_WINDOW_REGION_ENLARGE pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_WindowEnlargeReduction(IntPtr lLoginID, ref NET_IN_WINDOW_ENLARGE_REDUCTION pInParam, ref NET_OUT_WINDOW_ENLARGE_REDUCTION pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_RenderPrivateData(IntPtr lPlayHandle, bool bTrue);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_OperateTrafficList(IntPtr lLoginID, ref NET_IN_OPERATE_TRAFFIC_LIST_RECORD pstInParam, ref NET_OUT_OPERATE_TRAFFIC_LIST_RECORD pstOutParam, int waittime);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_FileTransmit(IntPtr lLoginID, int nTransType, IntPtr szInBuf, int nInBufLen, fTransFileCallBack cbTransFile, IntPtr dwUserData, int waittime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_OperateUserInfoNew(IntPtr lLoginID, int nOperateType, IntPtr opParam, IntPtr subParam, IntPtr pReserved, int waittime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_QueryUserInfoNew(IntPtr lLoginID, IntPtr pInfo, IntPtr pReserved, int waittime);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_StartSearchDevices(fSearchDevicesCB cbSearchDevice, IntPtr pUserData, IntPtr szLocalIp);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StopSearchDevices(IntPtr lSearchHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_DownloadRemoteFile(IntPtr lLoginID, ref NET_IN_DOWNLOAD_REMOTE_FILE pInParam, ref NET_OUT_DOWNLOAD_REMOTE_FILE pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_DoFindFaceRecognitionRecordEx(ref NET_IN_DOFIND_FACERECONGNITIONRECORD_EX pstInParam, ref NET_OUT_DOFIND_FACERECONGNITIONRECORD_EX pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_FaceRecognitionPutDisposition(IntPtr lLoginID, IntPtr pstInParam, IntPtr pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_FaceRecognitionDelDisposition(IntPtr lLoginID, ref NET_IN_FACE_RECOGNITION_DEL_DISPOSITION_INFO pstInParam, ref NET_OUT_FACE_RECOGNITION_DEL_DISPOSITION_INFO pstOutParam, int nWaitTime);
        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_QueryChannelName(IntPtr lLoginID, IntPtr pChannelName, int maxlen, ref int nChannelCount, int waittime = 1000);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_FaceInfoOpreate(IntPtr lLoginID, EM_FACEINFO_OPREATE_TYPE emType, IntPtr pInParam, IntPtr pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_StartFindFaceInfo(IntPtr lLoginID, ref NET_IN_FACEINFO_START_FIND pstIn, ref NET_OUT_FACEINFO_START_FIND pstOut, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_DoFindFaceInfo(IntPtr lFindHandle, ref NET_IN_FACEINFO_DO_FIND pstIn, ref NET_OUT_FACEINFO_DO_FIND pstOut, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StopFindFaceInfo(IntPtr lFindHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_ModifyDevice(ref DEVICE_NET_INFO_EX pDevNetInfo, uint dwWaitTime, ref int iError, string szLocalIp, IntPtr reserved);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SetDeviceSearchParam(ref NET_DEVICE_SEARCH_PARAM pstParam);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetDevConfig(IntPtr lLoginID, uint dwCommand, int lChannel, IntPtr lpOutBuffer, uint dwOutBufferSize, ref uint bytesReturned, int waittime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SetDevConfig(IntPtr lLoginID, uint dwCommand, int lChannel, IntPtr lpInBuffer, uint dwInBufferSize, int waittime);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_DownloadByRecordFile(IntPtr lLoginID, ref NET_RECORDFILE_INFO lpRecordFile, string sSavedFileName, fDownLoadPosCallBack cbDownLoadPos, IntPtr dwUserData);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_RebootDev(IntPtr lLoginID);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_Attendance_AddUser(IntPtr lLoginID, ref NET_IN_ATTENDANCE_ADDUSER pstuInAddUser, ref NET_OUT_ATTENDANCE_ADDUSER pstuOutAddUser, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_Attendance_DelUser(IntPtr lLoginID, ref NET_IN_ATTENDANCE_DELUSER pstuInDelUser, ref NET_OUT_ATTENDANCE_DELUSER pstuOutDelUser, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_Attendance_ModifyUser(IntPtr lLoginID, ref NET_IN_ATTENDANCE_ModifyUSER pstuInModifyUser, ref NET_OUT_ATTENDANCE_ModifyUSER pstuOutModifyUser, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_Attendance_GetUser(IntPtr lLoginID, ref NET_IN_ATTENDANCE_GetUSER pstuInGetUser, ref NET_OUT_ATTENDANCE_GetUSER pstuOutGetUser, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_Attendance_FindUser(IntPtr lLoginID, ref NET_IN_ATTENDANCE_FINDUSER pstuInFindUser, ref NET_OUT_ATTENDANCE_FINDUSER pstuOutFindUser, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_Attendance_InsertFingerByUserID(IntPtr lLoginID, ref NET_IN_FINGERPRINT_INSERT_BY_USERID pstuInInsert, ref NET_OUT_FINGERPRINT_INSERT_BY_USERID pstuOutInsert, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_Attendance_RemoveFingerByUserID(IntPtr lLoginID, ref NET_CTRL_IN_FINGERPRINT_REMOVE_BY_USERID pstuInRemove, ref NET_CTRL_OUT_FINGERPRINT_REMOVE_BY_USERID pstuOutRemove, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_Attendance_GetFingerByUserID(IntPtr lLoginID, ref NET_IN_FINGERPRINT_GETBYUSER pstuIn, ref NET_OUT_FINGERPRINT_GETBYUSER pstuOut, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_AttachMotionData(IntPtr lLoginID, ref NET_IN_ATTACH_MOTION_DATA pstInParam, ref NET_OUT_ATTACH_MOTION_DATA pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_DetachMotionData(IntPtr lAttachHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SearchDevicesByIPs(ref NET_DEVICE_IP_SEARCH_INFO pIpSearchInfo, fSearchDevicesCB cbSearchDevices, IntPtr dwUserData, string szLocalIp, uint dwWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_InitDevAccount(ref NET_IN_INIT_DEVICE_ACCOUNT pInitAccountIn, ref NET_OUT_INIT_DEVICE_ACCOUNT pInitAccountOut, uint dwWaitTime, string szLocalIp);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetDevCaps(IntPtr lLoginID, int nType, IntPtr pInBuf, IntPtr pOutBuf, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_ListenServer(string ip, ushort port, int nTimeout, fServiceCallBack cbListen, IntPtr dwUserData);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StopListenServer(IntPtr lServerHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_QueryProductionDefinition(IntPtr lLoginID, ref NET_PRODUCTION_DEFNITION pstuProdDef, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_AttachCameraState(IntPtr lLoginID, ref NET_IN_CAMERASTATE pstInParam, ref NET_OUT_CAMERASTATE pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_DetachCameraState(IntPtr lAttachHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetSoftwareVersion(IntPtr lLoginID, ref NET_IN_GET_SOFTWAREVERSION_INFO pstInParam, ref NET_OUT_GET_SOFTWAREVERSION_INFO pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetDeviceType(IntPtr lLoginID, ref NET_IN_GET_DEVICETYPE_INFO pstInParam, ref NET_OUT_GET_DEVICETYPE_INFO pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_LogOpen(ref NET_LOG_SET_PRINT_INFO pstLogPrintInfo);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_Attendance_GetFingerRecord(IntPtr lLoginID, ref NET_CTRL_IN_FINGERPRINT_GET pstuInGet, ref NET_CTRL_OUT_FINGERPRINT_GET pstuOutGet, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_Attendance_RemoveFingerRecord(IntPtr lLoginID, ref NET_CTRL_IN_FINGERPRINT_REMOVE pstuInRemove, ref NET_CTRL_OUT_FINGERPRINT_REMOVE pstuOutRemove, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_AudioDecEx(IntPtr lTalkHandle, IntPtr pAudioDataBuf, uint dwBufSize);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_OperateAccessFingerprintService(IntPtr lLoginID, EM_ACCESS_CTL_FINGERPRINT_SERVICE emtype, IntPtr pstInParam, IntPtr pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_OperateAccessControlManager(IntPtr lLoginID, NET_EM_ACCESS_CTL_MANAGER emtype, IntPtr pstInParam, IntPtr pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_EncryptString(ref NET_IN_ENCRYPT_STRING pInParam, ref NET_OUT_ENCRYPT_STRING pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_DownloadMediaFile(IntPtr lLoginID, EM_FILE_QUERY_TYPE emType, IntPtr lpMediaFileInfo, IntPtr sSavedFileName, fDownLoadPosCallBack cbDownLoadPos, IntPtr dwUserData, IntPtr reserved);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StopDownloadMediaFile(IntPtr lFileHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_SCADAAlarmAttachInfo(IntPtr lLoginID, ref NET_IN_SCADA_ALARM_ATTACH_INFO pInParam, ref NET_OUT_SCADA_ALARM_ATTACH_INFO pOutParam, int nWaitTime = 3000);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SCADAAlarmDetachInfo(IntPtr lAttachHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_SCADAAttachInfo(IntPtr lLoginID, ref NET_IN_SCADA_ATTACH_INFO pInParam, ref NET_OUT_SCADA_ATTACH_INFO pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SCADADetachInfo(IntPtr lAttachHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StartFind(IntPtr lLoginID, EM_FIND emType, IntPtr pInBuf, IntPtr pOutBuf, int nWaitTime = 1000);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_DoFind(IntPtr lLoginID, EM_FIND emType, IntPtr pInBuf, IntPtr pOutBuf, int nWaitTime = 1000);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StopFind(IntPtr lLoginID, EM_FIND emType, IntPtr pInBuf, IntPtr pOutBuf, int nWaitTime = 1000);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_RadiometryAttach(IntPtr lLoginID, ref NET_IN_RADIOMETRY_ATTACH pInParam, ref NET_OUT_RADIOMETRY_ATTACH pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_RadiometryDetach(IntPtr lAttachHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_RadiometryFetch(IntPtr lLoginID, ref NET_IN_RADIOMETRY_FETCH pInParam, ref NET_OUT_RADIOMETRY_FETCH pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_RealPlayByDataType(IntPtr lLoginID, ref NET_IN_REALPLAY_BY_DATA_TYPE pstInParam, ref NET_OUT_REALPLAY_BY_DATA_TYPE pstOutParam, uint dwWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_PlayBackByDataType(IntPtr lLoginID, ref NET_IN_PLAYBACK_BY_DATA_TYPE pstInParam, ref NET_OUT_PLAYBACK_BY_DATA_TYPE pstOutParam, uint dwWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_DownloadByDataType(IntPtr lLoginID, ref NET_IN_DOWNLOAD_BY_DATA_TYPE pstInParam, ref NET_OUT_DOWNLOAD_BY_DATA_TYPE pstOutParam, uint dwWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_AttachPTZStatusProc(IntPtr lLoginID, ref NET_IN_PTZ_STATUS_PROC pstuInPtzStatusProc, ref NET_OUT_PTZ_STATUS_PROC pstuOutPtzStatusProc, int nWaitTime = 3000);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_DetachPTZStatusProc(IntPtr lAttachHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SubcribeGPS(IntPtr lLoginID, bool bStart, int KeepTime, int InterTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern void CLIENT_SetSubcribeGPSCallBackEX2(fGPSRevEx2 OnGPSMessage, IntPtr dwUser);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_AttachAnalyseTaskState(IntPtr lLoginID, ref NET_IN_ATTACH_ANALYSE_TASK_STATE pInParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_DetachAnalyseTaskState(IntPtr lAttachHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_PushAnalysePictureFile(IntPtr lLoginID, ref NET_IN_PUSH_ANALYSE_PICTURE_FILE pInParam, ref NET_OUT_PUSH_ANALYSE_PICTURE_FILE pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_PushAnalysePictureFileByRule(IntPtr lLoginID, ref NET_IN_PUSH_ANALYSE_PICTURE_FILE_BYRULE pInParam, ref NET_OUT_PUSH_ANALYSE_PICTURE_FILE_BYRULE pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_AddAnalyseTask(IntPtr lLoginID, EM_DATA_SOURCE_TYPE emDataSourceType, IntPtr pInParam, ref NET_OUT_ADD_ANALYSE_TASK pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_RemoveAnalyseTask(IntPtr lLoginID, ref NET_IN_REMOVE_ANALYSE_TASK pInParam, ref NET_OUT_REMOVE_ANALYSE_TASK pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_AttachAnalyseTaskResult(IntPtr lLoginID, ref NET_IN_ATTACH_ANALYSE_RESULT pInParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_DetachAnalyseTaskResult(IntPtr lAttachHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_FindAnalyseTask(IntPtr lLoginID, ref NET_IN_FIND_ANALYSE_TASK pInParam, IntPtr pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetConnectionStatus(IntPtr lLoginID, ref NET_IN_GETCONNECTION_STATUS pInParam, ref NET_OUT_GETCONNECTION_STATUS pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetDefenceArmMode(IntPtr lLoginID, ref NET_IN_GET_DEFENCEMODE pInParam, ref NET_OUT_GET_DEFENCEMODE pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SetDefenceArmMode(IntPtr lLoginID, ref NET_IN_SET_DEFENCEMODE pInParam, ref NET_OUT_SET_DEFENCEMODE pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SetParkingSpaceLightPlan(IntPtr lLoginID, ref NET_IN_SET_PARKING_SPACE_LIGHT_PLAN pInParam, ref NET_OUT_SET_PARKING_SPACE_LIGHT_PLAN pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_OpenPlayGroup();

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_AddPlayHandleToPlayGroup(ref NET_IN_ADD_PLAYHANDLE_TO_PLAYGROUP pInParam, ref NET_OUT_ADD_PLAYHANDLE_TO_PLAYGROUP pOutParam);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_PausePlayGroup(IntPtr lPlayGroupHandle, bool bPause);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_QueryPlayGroupTime(ref NET_IN_QUERY_PLAYGROUP_TIME pInParam, ref NET_OUT_QUERY_PLAYGROUP_TIME pOutParam);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SetPlayGroupBaseChannel(ref NET_IN_SET_PLAYGROUP_BASECHANNEL pInParam, ref NET_OUT_SET_PLAYGROUP_BASECHANNEL pOutParam);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_DeleteFromPlayGroup(ref NET_IN_DELETE_FROM_PLAYGROUP pInParam, ref NET_OUT_DELETE_FROM_PLAYGROUP pOutParam);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_ClosePlayGroup(IntPtr lPlayGroupHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SetPlayGroupDirection(ref NET_IN_SET_PLAYGROUP_DIRECTION pInParam, ref NET_OUT_SET_PLAYGROUP_DIRECTION pOutParam);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SetPlayGroupSpeed(ref NET_IN_SET_PLAYGROUP_SPEED pInParam, ref NET_OUT_SET_PLAYGROUP_SPEED pOutParam);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_FastPlayGroup(IntPtr lPlayGroupHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SlowPlayGroup(IntPtr lPlayGroupHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_NormalPlayGroup(IntPtr lPlayGroupHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_StartUploadRemoteFile(IntPtr lLoginID, ref NET_IN_UPLOAD_REMOTE_FILE pInParam, ref NET_OUT_UPLOAD_REMOTE_FILE pOutParam, fUploadFileCallBack cbUploadFile, IntPtr dwUser);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StopUploadRemoteFile(IntPtr lUploadFileID);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_TagManagerStartTag(IntPtr lLoginID, ref NET_IN_TAGMANAGER_STARTTAG_INFO pInParam, ref NET_OUT_TAGMANAGER_STARTTAG_INFO pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_TagManagerGetTagState(IntPtr lLoginID, ref NET_IN_TAGMANAGER_GETTAGSTATE_INFO pInParam, ref NET_OUT_TAGMANAGER_GETTAGSTATE_INFO pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_TagManagerStartFind(IntPtr lLoginID, ref NET_IN_TAGMANAGER_STARTFIND_INFO pInParam, ref NET_OUT_TAGMANAGER_STARTFIND_INFO pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_TagManagerDoFind(IntPtr lLoginID, ref NET_IN_TAGMANAGER_DOFIND_INFO pInParam, ref NET_OUT_TAGMANAGER_DOFIND_INFO pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_TagManagerStopFind(IntPtr lLoginID);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_TagManagerGetCaps(IntPtr lLoginID, ref NET_IN_TAGMANAGER_GETCAPS_INFO pInParam, ref NET_OUT_TAGMANAGER_GETCAPS_INFO pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_TagManagerStopTag(IntPtr lLoginID, ref NET_IN_TAGMANAGER_STOPTAG_INFO pInParam, ref NET_OUT_TAGMANAGER_STOPTAG_INFO pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_OperateAccessUserService(IntPtr lLoginID, EM_ACCESS_CTL_USER_SERVICE emtype, IntPtr pstInParam, IntPtr pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_OperateAccessCardService(IntPtr lLoginID, EM_ACCESS_CTL_CARD_SERVICE emtype, IntPtr pstInParam, IntPtr pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_LoginWithHighLevelSecurity(ref NET_IN_LOGIN_WITH_HIGHLEVEL_SECURITY pstInParam, ref NET_OUT_LOGIN_WITH_HIGHLEVEL_SECURITY pstOutParam);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetHumanRadioCaps(IntPtr lLoginID, ref NET_IN_GET_HUMAN_RADIO_CAPS pInParam, ref NET_OUT_GET_HUMAN_RADIO_CAPS pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_AsyncAddCustomDevice(IntPtr lLoginID, ref NET_IN_ASYNC_ADD_CUSTOM_DEVICE pInParam, ref NET_OUT_ASYNC_ADD_CUSTOM_DEVICE pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_RemoveDevice(IntPtr lLoginID, IntPtr pInParam, IntPtr pOutParam, int nWaitTime);
        
		[DllImport(LIBRARYNETSDK)]
        public static extern void CLIENT_SetGDPREnable(bool bEnable);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_PTZSetPanGroupLimit(IntPtr lLoginID, ref NET_IN_PAN_GROUP_LIMIT_INFO pstInParam, ref NET_OUT_PAN_GROUP_LIMIT_INFO pstOutParam, uint dwWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_PTZSetPanGroup(IntPtr lLoginID, ref NET_IN_SET_PAN_GROUP_PARAM pInParam, ref NET_OUT_SET_PAN_GROUP_PARAM pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_PTZGetPanGroup(IntPtr lLoginID, ref NET_IN_GET_PAN_GROUP_PARAM pInParam, ref NET_OUT_GET_PAN_GROUP_PARAM pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_FaceOpenDoor(IntPtr lLoginID, ref NET_IN_FACE_OPEN_DOOR pInParam, ref NET_OUT_FACE_OPEN_DOOR pOutParam, int nWaitTime);
		
		[DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_LoadOffLineFile(IntPtr lLoginID, int nChannelID, uint dwAlarmType, NET_TIME_EX lpStartTime, NET_TIME_EX lpEndTime, fAnalyzerDataCallBack cbAnalyzerData, IntPtr dwUser);
		
		[DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetFramePlayBack(IntPtr lPlayHandle, ref int fileframerate, ref int playframerate);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SetFramePlayBack(IntPtr lPlayHandle, int framerate);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_QueryDevLogCount(IntPtr lLoginID, ref NET_IN_GETCOUNT_LOG_PARAM pInParam, ref NET_OUT_GETCOUNT_LOG_PARAM pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_StartQueryLog(IntPtr lLoginID, ref NET_IN_START_QUERYLOG pInParam, ref NET_OUT_START_QUERYLOG pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_QueryNextLog(IntPtr lLoginID, ref NET_IN_QUERYNEXTLOG pInParam, ref NET_OUT_QUERYNEXTLOG pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StopQueryLog(IntPtr lLoginID);
		
        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_StartUpgradeEx(IntPtr lLoginID, EM_UPGRADE_TYPE emType, string pchFileName, fUpgradeCallBack cbUpgrade, IntPtr dwUser);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_ResetSystem(IntPtr lLoginID, ref NET_IN_RESET_SYSTEM pInParam, ref NET_OUT_RESET_SYSTEM pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_ResetSystemEx(IntPtr lLoginID, ref NET_IN_RESET_SYSTEM_EX pInParam, ref NET_OUT_RESET_SYSTEM_EX pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SendUpgrade(IntPtr lUpgradeID);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StopUpgrade(IntPtr lUpgradeID);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_StartFindUserInfo(IntPtr lLoginID, ref NET_IN_USERINFO_START_FIND pstIn, ref NET_OUT_USERINFO_START_FIND pstOut, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_DoFindUserInfo(IntPtr lFindHandle, ref NET_IN_USERINFO_DO_FIND pstIn, ref NET_OUT_USERINFO_DO_FIND pstOut, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StopFindUserInfo(IntPtr lFindHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_StartFindCardInfo(IntPtr lLoginID, ref NET_IN_CARDINFO_START_FIND pstIn, ref NET_OUT_CARDINFO_START_FIND pstOut, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_DoFindCardInfo(IntPtr lFindHandle, ref NET_IN_CARDINFO_DO_FIND pstIn, ref NET_OUT_CARDINFO_DO_FIND pstOut, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StopFindCardInfo(IntPtr lFindHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_OperateAccessFaceService(IntPtr lLoginID, EM_NET_ACCESS_CTL_FACE_SERVICE emtype, IntPtr pstInParam, IntPtr pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_StartSearchDevicesEx(ref NET_IN_STARTSERACH_DEVICE pstIn, ref NET_OUT_STARTSERACH_DEVICE pstOut);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_AttachRadarAlarmPointInfo(IntPtr lLoginID, ref NET_IN_RADAR_ALARMPOINTINFO pstInParam, ref NET_OUT_RADAR_ALARMPOINTINFO pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_DetachRadarAlarmPointInfo(IntPtr lAttachHandle);

		[DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_RadarOperate(IntPtr lLoginID, EM_RADAR_OPERATE_TYPE emType, IntPtr pInBuf, IntPtr pOutBuf, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_AddRadarLinkSD(IntPtr lLoginID, ref NET_IN_RADAR_ADD_RADARLINKSD pstInParam, ref NET_OUT_RADAR_ADD_RADARLINKSD pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_DelRadarLinkSD(IntPtr lLoginID, ref NET_IN_RADAR_DEL_RADARLINKSD pstInParam, ref NET_OUT_RADAR_DEL_RADARLINKSD pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetRadarLinkSDState(IntPtr lLoginID, ref NET_IN_RADAR_GET_LINKSTATE pstInParam, ref NET_OUT_RADAR_GET_LINKSTATE pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_QueryIOControlState(IntPtr lLoginID, EM_NET_IOTYPE emType, IntPtr pState, int maxlen, ref int nIOCount, int waittime = 1000);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_IOControl(IntPtr lLoginID, EM_NET_IOTYPE emType, IntPtr pState, int maxlen);

		[DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SCADAGetAttributeInfo(IntPtr lLoginID, IntPtr pstInParam, IntPtr pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetFloorInfo(IntPtr lLoginID, ref NET_IN_GET_FLOOR_INFO pstInParam, ref NET_OUT_GET_FLOOR_INFO pstOutParam, uint dwWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_AttachCustomSnapInfo(IntPtr lLoginID, ref NET_IN_ATTACH_CUSTOM_SNAP_INFO pstInParam, ref NET_OUT_ATTACH_CUSTOM_SNAP_INFO pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_DetachCustomSnapInfo(IntPtr lFindHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_OperateMonitorWall(IntPtr lLoginID, NET_MONITORWALL_OPERATE_TYPE emType, IntPtr pInParam, IntPtr pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_MonitorWallGetScene(IntPtr lLoginID, ref NET_A_IN_MONITORWALL_GET_SCENE pInParam, ref NET_A_OUT_MONITORWALL_GET_SCENE pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetDeviceSerialNo(IntPtr lLoginID, ref NET_IN_GET_DEVICESERIALNO_INFO pstInParam, ref NET_OUT_GET_DEVICESERIALNO_INFO pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetMachineName(IntPtr lLoginID, ref NET_IN_GET_MACHINENAME_INFO pstInParam, ref NET_OUT_GET_MACHINENAME_INFO pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_AttachBusState(IntPtr lLoginID, ref NET_IN_BUS_ATTACH pstuInBus, ref NET_OUT_BUS_ATTACH pstuOutBus, int nWaitTime = 3000);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_DetachBusState(IntPtr lAttachHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SetPlayBackSpeed(IntPtr lPlayHandle, EM_PLAY_BACK_SPEED emSpeed);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SetMarkFileByTime(IntPtr lLoginID, ref NET_IN_SET_MARK_FILE_BY_TIME pInParam, ref NET_OUT_SET_MARK_FILE_BY_TIME pOutParam, int nWaitTime = 1000);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetMarkInfo(IntPtr lLoginID, ref NET_IN_GET_MARK_INFO pInParam, ref NET_OUT_GET_MARK_INFO pOutParam, int nWaitTime = 1000);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetRecordState(IntPtr lLoginID, ref NET_IN_GET_RECORD_STATE pInParam, ref NET_OUT_GET_RECORD_STATE pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SetCourseRecordState(IntPtr lLoginID, ref NET_IN_SET_COURSE_RECORD_STATE pInParam, ref NET_OUT_SET_COURSE_RECORD_STATE pOutParam, int nWaitTime);
		
		[DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetVideoEncodeBitrate(IntPtr lLoginID, ref NET_IN_GET_VIDEO_ENCODE_BITRATE_INFO pInParam, ref NET_OUT_GET_VIDEO_ENCODE_BITRATE_INFO pOutParam, int nWaitTime);
    
        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_RemotePreUploadFile(IntPtr lLoginID, ref NET_IN_REMOTE_PREUPLOAD_FILE pInParam, ref NET_OUT_REMOTE_PREUPLOAD_FILE pOutParam, int nWaitTime);
   
        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_StartRemoteUploadFile(IntPtr lLoginID, ref NET_IN_REMOTE_UPLOAD_FILE pInParam, ref NET_OUT_REMOTE_UPLOAD_FILE pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StopRemoteUploadFile(IntPtr lRemoteUploadFileID);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_RemoteList(IntPtr lLoginID, ref NET_IN_REMOTE_LIST pInParam, ref NET_OUT_REMOTE_LIST pOutParam, int nWaitTime);
        
        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_RemoteRemoveFiles(IntPtr lLoginID, ref NET_IN_REMOTE_REMOVE_FILES pInParam, ref NET_OUT_REMOTE_REMOVE_FILES pOutParam, int nWaitTime);
    
        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_PreUploadRemoteFile(IntPtr lLoginID, ref NET_IN_PRE_UPLOAD_REMOTE_FILE pInParam, ref NET_OUT_PRE_UPLOAD_REMOTE_FILE pOutParam, int nWaitTime);
    
        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_UploadRemoteFile(IntPtr lLoginID, ref NET_IN_UPLOAD_REMOTE_FILE pInParam, ref NET_OUT_UPLOAD_REMOTE_FILE pOutParam, int nWaitTime = 1000);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_ListRemoteFile(IntPtr lLoginID, ref NET_IN_LIST_REMOTE_FILE pInParam, ref NET_OUT_LIST_REMOTE_FILE pOutParam, int nWaitTime = 1000);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_RemoveRemoteFiles(IntPtr lLoginID, ref NET_IN_REMOVE_REMOTE_FILES pInParam, ref NET_OUT_REMOVE_REMOTE_FILES pOutParam, int nWaitTime = 1000);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StartMultiFindFaceRecognitionRecord(IntPtr lLoginID, ref NET_IN_STARTMULTIFIND_FACERECONGNITIONRECORD pInParam, ref NET_OUT_STARTMULTIFIND_FACERECONGNITIONRECORD pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_DoFindFaceRecognitionRecord(ref NET_IN_DOFIND_FACERECONGNITIONRECORD pstInParam, ref NET_OUT_DOFIND_FACERECONGNITIONRECORD pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StopFindFaceRecognitionRecord(IntPtr lFindHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StartService(uint wPort, IntPtr pIp = new IntPtr(), fServiceCallBack pfscb = null, uint dwTimeOut = 0xffffffff, IntPtr dwUserData = new IntPtr());

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_MatrixAddCamerasByGroup(IntPtr lLoginID, ref NET_IN_ADD_LOGIC_BYGROUP_CAMERA pInParam, ref NET_OUT_ADD_LOGIC_BYGROUP_CAMERA pOutParam, int nWaitTime = 1000);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_MatrixGetCameraAllByGroup(IntPtr lLoginID, ref NET_IN_GET_CAMERA_ALL_BY_GROUP pInParam, ref NET_OUT_GET_CAMERA_ALL_BY_GROUP pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_MatrixDeleteCameraByGroup(IntPtr lLoginID, ref NET_IN_DELETE_CAMERA_BY_GROUP pInParam, ref NET_OUT_DELETE_CAMERA_BY_GROUP pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_StartBurnSession(IntPtr lLoginID, ref NET_IN_START_BURN_SESSION pstInParam, ref NET_OUT_START_BURN_SESSION pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StopBurnSession(IntPtr lBurnSession);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StartBurn(IntPtr lBurnSession, ref NET_IN_START_BURN pstInParam, ref NET_OUT_START_BURN pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StopBurn(IntPtr lBurnSession);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_PauseBurn(IntPtr lBurnSession, bool bPause);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_AttachBurnState(IntPtr lLoginID, ref NET_IN_ATTACH_STATE pstInParam, ref NET_OUT_ATTACH_STATE pstOutParam, int nWaitTime = 1000);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_DetachBurnState(IntPtr lAttachHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_BurnMarkTag(IntPtr lBurnSession, ref NET_IN_BURN_MARK_TAG pstInParam, ref NET_OUT_BURN_MARK_TAG pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_BurnGetState(IntPtr lBurnSession, ref NET_IN_BURN_GET_STATE pstInParam, ref NET_OUT_BURN_GET_STATE pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StartBackupTask(IntPtr lLoginID, ref NET_IN_START_BACKUP_TASK_INFO pstInParam, ref NET_OUT_START_BACKUP_TASK_INFO pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_AttachBackupTaskState(IntPtr lLoginID, ref NET_IN_ATTACH_BACKUP_STATE pstInParam, ref NET_OUT_ATTACH_BACKUP_STATE pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_DetachBackupTaskState(IntPtr lAttachHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_RealPlayEx2(IntPtr lLoginID, ref NET_IN_REALPLAY pInParam, ref NET_OUT_REALPLAY pOutParam, uint dwWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern void CLIENT_RigisterDrawFun(fDrawCallBack cbDraw, IntPtr dwUser);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_MatchTwoFaceImage(IntPtr lLoginID, ref NET_MATCH_TWO_FACE_IN pstInParam, ref NET_MATCH_TWO_FACE_OUT pstOutParam, int nWaitTime = 3000);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetMonitorWallCollections(IntPtr lLoginID, ref NET_IN_WM_GET_COLLECTIONS pInParam, ref NET_OUT_WM_GET_COLLECTIONS pOutParam, int nWaitTime = 1000);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_LoadMonitorWallCollection(IntPtr lLoginID, ref NET_IN_WM_LOAD_COLLECTION pInParam, ref  NET_OUT_WM_LOAD_COLLECTION pOutParam, int nWaitTime = 1000);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SaveMonitorWallCollection(IntPtr lLoginID, ref NET_IN_WM_SAVE_COLLECTION pInParam, ref NET_OUT_WM_SAVE_COLLECTION pOutParam, int nWaitTime = 1000);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_RenameMonitorWallCollection(IntPtr lLoginID, ref NET_IN_WM_RENAME_COLLECTION pInParam, ref NET_OUT_WM_RENAME_COLLECTION pOutParam, int nWaitTime = 1000);

        ///@brief web信息上传接口:该接口淘汰，请使用 CLIENT_TransmitInfoForWebEx
        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_TransmitInfoForWebEx(IntPtr lLoginID, ref NET_IN_TRANSMIT_INFO pInParam, ref NET_OUT_TRANSMIT_INFO pOutParam, int nWaittime = 3000);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_FindRecordBackupRestoreTaskInfos(IntPtr lLoginID, ref NET_IN_FIND_REC_BAK_RST_TASK pInParam, ref NET_OUT_FIND_REC_BAK_RST_TASK pOutParam, int nWaitTime = 3000);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SetExamRecordingPlans(IntPtr lLoginID, ref NET_IN_SET_EXAM_RECORDING_PLANS pstuInParam, ref NET_OUT_SET_EXAM_RECORDING_PLANS pstuOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_ManualSnap(IntPtr lLoginID, ref NET_IN_MANUAL_SNAP pInParam, ref NET_OUT_MANUAL_SNAP pOutParam, int nWaitTime);

        /// <summary>
        /// 获取流量统计信息,pstInParam与pstOutParam内存由用户申请释放
        /// start find flux state,user malloc and free (pstInParam's and pstOutParam's) memory
        /// </summary>
        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_StartFindFluxStat(IntPtr lLoginID, ref NET_IN_TRAFFICSTARTFINDSTAT pstInParam, ref NET_OUT_TRAFFICSTARTFINDSTAT pstOutParam);

        /// <summary>
        /// 继续查询流量统计,pstInParam与pstOutParam内存由用户申请释放
        /// do find flux state,user malloc and free (pstInParam's and pstOutParam's) memory
        /// </summary>
        [DllImport(LIBRARYNETSDK)]
        public static extern int CLIENT_DoFindFluxStat(IntPtr lFindHandle, ref NET_IN_TRAFFICDOFINDSTAT pstInParam, ref NET_OUT_TRAFFICDOFINDSTAT pstOutParam);

        /// <summary>
        /// 结束查询流量统计
        /// stop find flux state
        /// </summary>
        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StopFindFluxStat(IntPtr lFindHandle);

        // <summary>
        /// 添加人脸库下载任务
        /// Add task of download face data base
        /// </summary>
        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_AddFaceDbDownLoadTask(IntPtr lLoginID, ref NET_IN_ADD_FACEDB_DOWNLOAD_TASK pInParam, ref NET_OUT_ADD_FACEDB_DOWNLOAD_TASK pOutParam, int nWaitTime);

        /// <summary>
        /// 订阅人脸库下载结果
        /// Attach the result of downloading face data base
        /// </summary>
        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_AttachFaceDbDownLoadResult(IntPtr lLoginID, ref NET_IN_ATTACH_FACEDB_DOWNLOAD_RESULT pInParam, ref NET_OUT_ATTACH_FACEDB_DOWNLOAD_RESULT pOutParam, int nWaitTime);

        /// <summary>
        /// 取消订阅人脸库下载结果 lAttachHandle为 CLIENT_AttachFaceDbDownLoadResult 接口的返回值
        /// Detach Attach the result of downloading face data base
        /// </summary>
        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_DetachFaceDbDownLoadResult(IntPtr lAttachHandle);

        /// <summary>
        /// 设置解码窗口输出OSD信息扩展接口(pInparam, pOutParam内存由用户申请释放)
        /// set splite output OSD info ----expand interface (the memory of pInParam and pOutParam applyed and released by user),user malloc and free (pInParam's and pOutParam's)memory
        /// </summary>
        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SetSplitOSDEx(IntPtr lLoginID, ref NET_IN_SPLIT_SET_OSD_EX pInParam, ref NET_OUT_SPLIT_SET_OSD_EX pOutParam, int nWaitTime);

        /// <summary>
        /// 获取解码窗口输出OSD信息扩展接口(pInparam, pOutParam内存由用户申请释放)
        /// get splite output OSD info ----expand interface (the memory of pInParam and pOutParam applyed and released by user),user malloc and free (pInParam's and pOutParam's)memory
        /// </summary>
        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetSplitOSDEx(IntPtr lLoginID, ref NET_IN_SPLIT_GET_OSD_EX pInParam, ref NET_OUT_SPLIT_GET_OSD_EX pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_CheckCloudUpgrader(IntPtr lLoginID, ref NET_IN_CHECK_CLOUD_UPGRADER pInParam, ref NET_OUT_CHECK_CLOUD_UPGRADER pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_ExecuteCloudUpgrader(IntPtr lLoginID, ref NET_IN_EXECUTE_CLOUD_UPGRADER pInParam, ref NET_OUT_EXECUTE_CLOUD_UPGRADER pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetCloudUpgraderState(IntPtr lLoginID, ref NET_IN_GET_CLOUD_UPGRADER_STATE pInParam, ref NET_OUT_GET_CLOUD_UPGRADER_STATE pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_FaceRecognitionDetectMultiFace(IntPtr lLoginID, IntPtr pstInParam, ref NET_OUT_FACE_RECOGNITION_DETECT_MULTI_FACE_INFO pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_AttachDetectMultiFaceState(IntPtr lLoginID, ref NET_IN_MULTIFACE_DETECT_STATE pstInParam, ref NET_OUT_MULTIFACE_DETECT_STATE pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_DetachDetectMultiFaceState(IntPtr lAttachHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StartMultiPersonFindFaceR(IntPtr lLoginID, ref NET_IN_STARTMULTIPERSONFIND_FACER pstInParam, ref NET_OUT_STARTMULTIPERSONFIND_FACER pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_FaceRServerGetDetectToken(IntPtr lLoginID, ref NET_IN_FACERSERVER_GETDETEVTTOKEN pInParam, ref NET_OUT_FACERSERVER_GETDETEVTTOKEN pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SetFileAlias(IntPtr lLoginID, ref NET_IN_SET_FILE_ALIAS_INFO pstuInParam, ref NET_OUT_SET_FILE_ALIAS_INFO pstuOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SearchFileByAlias(IntPtr lLoginID, ref NET_IN_SEARCH_FILE_BYALIAS_INFO pstuInParam, ref NET_OUT_SEARCH_FILE_BYALIAS_INFO pstuOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_GetWaterDataStatServerCaps(IntPtr lLoginID, ref NET_IN_WATERDATA_STAT_SERVER_GETCAPS_INFO pstuInParam, ref NET_OUT_WATERDATA_STAT_SERVER_GETCAPS_INFO pstuOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_StartFindWaterDataStatServer(IntPtr lLoginID, ref NET_IN_START_FIND_WATERDATA_STAT_SERVER_INFO pstuInParam, ref NET_OUT_START_FIND_WATERDATA_STAT_SERVER_INFO pstuOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_DoFindWaterDataStatServer(IntPtr lLoginID, ref NET_IN_DO_FIND_WATERDATA_STAT_SERVER_INFO pstuInParam, ref NET_OUT_DO_FIND_WATERDATA_STAT_SERVER_INFO pstuOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_StopFindWaterDataStatServer(IntPtr lLoginID, ref NET_IN_STOP_FIND_WATERDATA_STAT_SERVER_INFO pstuInParam, ref NET_OUT_STOP_FIND_WATERDATA_STAT_SERVER_INFO pstuOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_GetWaterDataStatServerWaterData(IntPtr lLoginID, ref NET_IN_WATERDATA_STAT_SERVER_GETDATA_INFO pstuInParam, ref NET_OUT_WATERDATA_STAT_SERVER_GETDATA_INFO pstuOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetUnifiedStatus(IntPtr lLoginID, ref NET_IN_UNIFIEDINFOCOLLECT_GET_DEVSTATUS pInParam, ref NET_OUT_UNIFIEDINFOCOLLECT_GET_DEVSTATUS pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetAlarmRegionInfo(IntPtr lLoginID, EM_A_NET_EM_GET_ALARMREGION_INFO emType, IntPtr pstuInParam, IntPtr pstuOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_AttachVideoStatStream(IntPtr lLoginID, ref NET_IN_ATTACH_VIDEOSTAT_STREAM pInParam, ref NET_OUT_ATTACH_VIDEOSTAT_STREAM pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_DetachVideoStatStream(IntPtr lAttachHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_BatchAppendFaceRecognition(IntPtr lLoginID, ref NET_IN_BATCH_APPEND_FACERECONGNITION pstInParam, ref NET_OUT_BATCH_APPEND_FACERECONGNITION pstOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SetGPSUuidInfo(IntPtr lLoginID, ref NET_IN_SET_GPS_UUID_INFO pInParam, ref NET_OUT_SET_GPS_UUID_INFO pOutParam);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_ImportFaceDB(IntPtr lLoginID, ref NET_IN_IMPORT_FACE_DB pInParam, ref NET_OUT_IMPORT_FACE_DB pOutParam);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StopImportFaceDB(IntPtr lImportFaceDbHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_ExportFaceDB(IntPtr lLoginID, ref NET_IN_EXPORT_FACE_DB pInParam, ref NET_OUT_EXPORT_FACE_DB pOutParam);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StopExportFaceDB(IntPtr lExportFaceDbHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_AttachEventRestore(IntPtr lLoginID, ref NET_IN_ATTACH_EVENT_RESTORE pInParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_DetachEventRestore(IntPtr lAttachHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_QueryRemotDevState(IntPtr lLoginID, int nType, int nChannelID, IntPtr pBuf, int nBufLen, IntPtr pRetLen, int waittime);

        /*******************PlaySDK*********************/

        [DllImport(LIBRARYPLAYSDK)]
        public static extern bool PLAY_OpenStream(int nPort, IntPtr pFileHeadBuf, uint nSize, uint nBufPoolSize);

        [DllImport(LIBRARYPLAYSDK)]
        public static extern bool PLAY_Play(int nPort, IntPtr hWnd);
        
        [DllImport(LIBRARYPLAYSDK)]
        public static extern bool PLAY_InputData(int nPort, IntPtr pBuf, uint nSize);

        [DllImport(LIBRARYPLAYSDK)]
        public static extern bool PLAY_Stop(int nPort);

        [DllImport(LIBRARYPLAYSDK)]
        public static extern bool PLAY_CloseStream(int nPort);
    }
}
