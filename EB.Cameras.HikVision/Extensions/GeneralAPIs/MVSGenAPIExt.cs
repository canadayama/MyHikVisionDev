using System;
using System.Reflection;

using BE.Cameras;
using BE.Cameras.Exceptions;

using static MvCamCtrl.NET.MyCamera;

namespace EB.Cameras.HikVision.Extensions.GeneralAPIs
{
    /// <summary>
    /// 
    /// </summary>
    public static class MVSGenAPIExt
    {
        #region ========================= General APIs =========================

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="pstFileAccess"></param>
        public static bool FileAccessRead( this MVS mvs,
                                             ref MV_CC_FILE_ACCESS pstFileAccess )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_FileAccessRead_NET( ref pstFileAccess );
                if ( rslt == MV_OK )
                {
                    return true;
                }

                mvs.LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
                return false;
            }

            mvs.LastErrorMessage
                = CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                     MethodBase.GetCurrentMethod().Name );
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="pstFileAccess"></param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool FileAccessWrite( this MVS mvs,
                                              ref MV_CC_FILE_ACCESS pstFileAccess )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_FileAccessWrite_NET( ref pstFileAccess );
                if ( rslt == MV_OK )
                {
                    return true;
                }

                mvs.LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
                return false;
            }

            mvs.LastErrorMessage
                = CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                     MethodBase.GetCurrentMethod().Name );
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="pFilename"></param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool FeatureLoad( this MVS mvs, string pFilename )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_FeatureLoad_NET( pFilename );
                if ( rslt == MV_OK )
                {
                    return true;
                }

                mvs.LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
                return false;
            }

            mvs.LastErrorMessage
                = CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                     MethodBase.GetCurrentMethod().Name );
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="pFilename"></param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool FeatureSave( this MVS mvs, string pFilename )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_FeatureSave_NET( pFilename );
                if ( rslt == MV_OK )
                {
                    return true;
                }

                mvs.LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
                return false;
            }

            mvs.LastErrorMessage
                = CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                     MethodBase.GetCurrentMethod().Name );
            return false;
        }

        /// <summary>
        /// Get the information of all types.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="pstInfo">Information structure,
        /// see MV_ALL_MATCH_INFO for details.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool GetAllMatchInfo( this MVS mvs, ref MV_ALL_MATCH_INFO pstInfo )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_GetAllMatchInfo_NET( ref pstInfo );
                if ( rslt == MV_OK )
                {
                    return true;
                }
                mvs.LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
                return false;
            }

            mvs.LastErrorMessage
                = CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                     MethodBase.GetCurrentMethod().Name );
            return false;
        }

        /// <summary>
        /// Get the progress of importing and exporting camera parameters.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="pstFileAccessProgress">
        /// Progress, see details in MV_CC_FILE_ACCESS_PROGRESS .</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool GetFileAccessProgress( this MVS mvs,
                                                    ref MV_CC_FILE_ACCESS_PROGRESS pstFileAccessProgress )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_GetFileAccessProgress_NET( ref pstFileAccessProgress );
                if ( rslt == MV_OK )
                {
                    return true;
                }

                mvs.LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
                return false;
            }

            mvs.LastErrorMessage
                = CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                     MethodBase.GetCurrentMethod().Name );
            return false;
        }

        /// <summary>
        /// Clear GenICam node cache.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool MV_CC_InvalidateNodes( this MVS mvs )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_InvalidateNodes_NET();
                if ( rslt == MV_OK )
                {
                    return true;
                }

                mvs.LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
                return false;
            }

            mvs.LastErrorMessage
                = CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                     MethodBase.GetCurrentMethod().Name );
            return false;
        }

        /// <summary>
        /// Check if device is connected.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <returns>true if connected; false if disconnected.</returns>
        /// <exception cref="CamNotOpenException"></exception>
        public static bool IsDeviceConnected( this MVS mvs )
        {
            if ( mvs.IsOpen )
            {
                return mvs.Cam.MV_CC_IsDeviceConnected_NET();
            }

            throw new CamNotOpenException( CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                                                MethodBase.GetCurrentMethod().Name ) );
        }

        /// <summary>
        /// Register the callback function for all events.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="cbEvent">Callback function for receiving events.</param>
        /// <param name="pUser">User data.</param>
        /// <returns>true if connected; false if disconnected.</returns>
        public static bool RegisterAllEventCallBack( this MVS mvs,
                                                       cbEventdelegateEx cbEvent,
                                                       IntPtr? pUser = null )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_RegisterAllEventCallBack_NET( cbEvent, pUser ?? IntPtr.Zero );
                if ( rslt == MV_OK )
                {
                    return true;
                }

                mvs.LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
                return false;
            }

            mvs.LastErrorMessage
                = CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                     MethodBase.GetCurrentMethod().Name );
            return false;
        }

        /// <summary>
        /// Register single event callback function.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="pEventName">Event name.</param>
        /// <param name="cbEvent">Callback function for receiving the event.</param>
        /// <param name="pUser">User data.</param>
        /// <returns>true if connected; false if disconnected.</returns>
        public static bool RegisterEventCallBackEx( this MVS mvs,
                                                      string pEventName,
                                                      cbEventdelegateEx cbEvent,
                                                      IntPtr? pUser )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_RegisterEventCallBackEx_NET( pEventName, cbEvent, pUser ?? IntPtr.Zero );
                if ( rslt == MV_OK )
                {
                    return true;
                }

                mvs.LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
                return false;
            }

            mvs.LastErrorMessage
                = CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                     MethodBase.GetCurrentMethod().Name );
            return false;
        }

        /// <summary>
        /// Register callback function for exception information.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="cbException">Callback function for receiving exception message.</param>
        /// <param name="pUser">User data.</param>
        /// <returns>true if connected; false if disconnected.</returns>
        public static bool RegisterExceptionCallBack( this MVS mvs,
                                                        cbExceptiondelegate cbException,
                                                        IntPtr? pUser = null )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_RegisterExceptionCallBack_NET( cbException, pUser ?? IntPtr.Zero );
                if ( rslt == MV_OK )
                {
                    return true;
                }

                mvs.LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
                return false;
            }

            mvs.LastErrorMessage
                = CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                     MethodBase.GetCurrentMethod().Name );
            return false;
        }

        /// <summary>
        /// Set number of image buffer nodes.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="nNum">Number of image buffer nodes;
        /// its value should be larger than or equal to 1,
        /// and the default value is "1".</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool SetImageNodeNum( this MVS mvs, uint nNum )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_SetImageNodeNum_NET( nNum );
                if ( rslt == MV_OK )
                {
                    return true;
                }

                mvs.LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
                return false;
            }

            mvs.LastErrorMessage
                = CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                     MethodBase.GetCurrentMethod().Name );
            return false;
        }

        /// <summary>
        /// Set the streaming strategy.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="enGrabStrategy">Streaming strategy,
        /// see the enumeration MV_GRAB_STRATEGY for details.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool SetGrabStrategy( this MVS mvs,
                                              MV_GRAB_STRATEGY enGrabStrategy )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_SetGrabStrategy_NET( enGrabStrategy );
                if ( rslt == MV_OK )
                {
                    return true;
                }

                mvs.LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
                return false;
            }

            mvs.LastErrorMessage
                = CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                     MethodBase.GetCurrentMethod().Name );
            return false;
        }

        /// <summary>
        /// Set the output queue size.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="nOutputQueueSize">Output queue size, range: [1,10].</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool SetOutputQueueSize( this MVS mvs, uint nOutputQueueSize )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_SetOutputQueueSize_NET( nOutputQueueSize );
                if ( rslt == MV_OK )
                {
                    return true;
                }

                mvs.LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
                return false;
            }

            mvs.LastErrorMessage
                = CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                     MethodBase.GetCurrentMethod().Name );
            return false;
        }

        #endregion ==============================================================
    }
}
