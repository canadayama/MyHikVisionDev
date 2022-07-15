using System;
using System.Reflection;

using BE.Cameras;

using static MvCamCtrl.NET.MyCamera;

namespace EB.Cameras.HikVision.Extensions.ImageAcquisition
{
    /// <summary>
    /// 
    /// </summary>
    public static class MVSImgAcqExt
    {
        #region ====================== Image Acquisition =======================

        /// <summary>
        /// Clear streaming data buffer.
        /// </summary>
        /// <param name="mvs"></param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool ClearImageBuffer( this MVS mvs )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_ClearImageBuffer_NET();
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
        /// Release image buffer (this API is used to release the image buffer, which is no longer used, and it
        /// should be used with API: MV_CC_GetImageBuffer_NET).
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="pFrame"></param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool FreeImageBuffer( this MVS mvs, ref MV_FRAME_OUT pFrame )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_FreeImageBuffer_NET( ref pFrame );
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
        /// Get one image frame, supports getting chunk information and setting timeout.
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="pFrame">Image data and information, see the structure MV_FRAME_OUT for details.</param>
        /// <param name="nMsec">Timeout period, unit: millisecond.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool GetImageBuffer( this MVS mvs,
                                             ref MV_FRAME_OUT pFrame,
                                             int nMsec )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_GetImageBuffer_NET( ref pFrame, nMsec );
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
        /// Get one picture frame in BGR24 format,
        /// search for the frames in the memory
        /// and transform them to BGR24 format for return,
        /// supports setting timeout.
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="pData"></param>
        /// <param name="nDataSize"></param>
        /// <param name="pFrameInfo"></param>
        /// <param name="nMsec"></param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool GetImageForBGR( this MVS mvs,
                                                       IntPtr pData,
                                                       uint nDataSize,
                                                       ref MV_FRAME_OUT_INFO_EX pFrameInfo,
                                                       int nMsec )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_GetImageForBGR_NET( pData, nDataSize,
                                                                ref pFrameInfo, nMsec );
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
        /// Get one picture frame in RGB24 format, search for the frames in the memory and transform them
        /// to RGB24 format for return, supports setting timeout.
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="pData"></param>
        /// <param name="nDataSize"></param>
        /// <param name="pFrameInfo"></param>
        /// <param name="nMsec"></param>
        /// <returns></returns>
        public static bool GetImageForRGB( this MVS mvs,
                                             IntPtr pData,
                                             uint nDataSize,
                                             ref MV_FRAME_OUT_INFO_EX pFrameInfo,
                                             int nMsec )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_GetImageForRGB_NET( pData, nDataSize, ref pFrameInfo, nMsec );
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
        /// Get one picture frame,
        /// supports getting chunk information and setting timeout.
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="pData"></param>
        /// <param name="nDataSize"></param>
        /// <param name="pFrameInfo"></param>
        /// <param name="nMsec"></param>
        /// <returns></returns>
        public static bool GetOneFrameTimeout( this MVS mvs,
                                                           IntPtr pData,
                                                           uint nDataSize,
                                                           ref MV_FRAME_OUT_INFO_EX pFrameInfo,
                                                           int nMsec )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_GetOneFrameTimeout_NET( pData, nDataSize, ref pFrameInfo, nMsec );
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
        /// Register callback function for image data,
        /// supports getting chunk information.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="cbOutput">Image data callback function.</param>
        /// <param name="pUser">User data.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool RegisterImageCallBackEx( this MVS mvs,
                                                      cbOutputExdelegate cbOutput,
                                                      IntPtr? pUser = null )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_RegisterImageCallBackEx_NET( cbOutput, pUser ?? IntPtr.Zero );
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
        /// Register callback function for BGR24 image data,
        /// supports getting chunk information.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="cbOutput">Callback function for BGR24 picture.</param>
        /// <param name="pUser">User data.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool RegisterImageCallBackForBGR( this MVS mvs,
                                                          cbOutputExdelegate cbOutput,
                                                          IntPtr? pUser = null )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_RegisterImageCallBackForBGR_NET( cbOutput, pUser ?? IntPtr.Zero );
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
        /// Register callback function for RGB24 image data,
        /// supports getting chunk information.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="cbOutput">Callback function for RBG24 picture.</param>
        /// <param name="pUser">User data.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool RegisterImageCallBackForRGB( this MVS mvs,
                                                          cbOutputExdelegate cbOutput,
                                                          IntPtr? pUser = null )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_RegisterImageCallBackForRGB_NET( cbOutput, pUser ?? IntPtr.Zero );
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
        /// Start the image acquisition.
        /// *Not supported by CameraLink device.*
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool StartGrabbing( this MVS mvs )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_StartGrabbing_NET();
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
        /// Stop the image acquisition.
        /// *Not supported by CameraLink device.*
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool StopGrabbing( this MVS mvs )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_StopGrabbing_NET();
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

        #endregion =============================================================
    }
}
