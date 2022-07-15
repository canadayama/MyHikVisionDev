using System.Reflection;

using BE.Cameras;

using static MvCamCtrl.NET.MyCamera;

namespace EB.Cameras.HikVision.Extensions.ImageProcessing
{
    /// <summary>
    /// Image Processing extensions.
    /// </summary>
    public static class MVSImgProcExt
    {
        #region ======================= Image Processing =======================

        /// <summary>
        /// Display one frame.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="pDisplayInfo">Image information,
        /// see MV_DISPLAY_FRAME_INFO for details.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool DisplayOneFrame( this MVS mvs,
                                              ref MV_DISPLAY_FRAME_INFO pDisplayInfo )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_DisplayOneFrame_NET( ref pDisplayInfo );
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
        /// Convert the original image data to picture
        /// and save the pictures to specific memory,
        /// supports setting JPEG encoding quality.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="pSaveParam">Input and output parameters of picture data,
        /// see the structure MV_SAVE_IMAGE_PARAM_EX for details.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool SaveImageEx( this MVS mvs,
                                          ref MV_SAVE_IMAGE_PARAM_EX pSaveParam )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_SaveImageEx_NET( ref pSaveParam );
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
        /// Convert pixel format.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="pstCvtParam">Input and output parameters
        /// of pixel format conversion.
        /// See MV_PIXEL_CONVERT_PARAM for details.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool ConvertPixelType( this MVS mvs,
                                               ref MV_PIXEL_CONVERT_PARAM pstCvtParam )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_ConvertPixelType_NET( ref pstCvtParam );
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
        /// Set the interpolation method of Bayer format.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="nBayerCvtQuality">Interpolation method of Bayer:
        /// 0-nearest neighbors, 1-bilinearity, 2-optimal;
        /// the default value is "0".</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool SetBayerCvtQuality( this MVS mvs,
                                                 uint nBayerCvtQuality )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_SetBayerCvtQuality_NET( nBayerCvtQuality );
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
        /// Set the Gamma value after Bayer interpolation.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="fBayerGammaValue">Gamma value, range: [0.1, 4.0]</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool SetBayerGammaValue( this MVS mvs,
                                                 float fBayerGammaValue )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_SetBayerGammaValue_NET( fBayerGammaValue );
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
        /// Set the Gamma value after Bayer interpolation.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="pstGammaParam">Gamma value, range: [0.1, 4.0]</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool SetBayerGammaParam( this MVS mvs,
                                                 ref MV_CC_GAMMA_PARAM pstGammaParam )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_SetBayerGammaParam_NET( ref pstGammaParam );
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
        /// Color correction after Bayer interpolation.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="pstCCMParam">Color correction structure,
        /// see MV_CC_CCM_PARAM for details.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool SetBayerCCMParam( this MVS mvs,
                                               ref MV_CC_CCM_PARAM pstCCMParam )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_SetBayerCCMParam_NET( ref pstCCMParam );
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
        /// Enable/disable CCM and set CCM parameters of Bayer pattern.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="pstCCMParam">CCM parameters structure.
        /// See MV_CC_CCM_PARAM_EX for details.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool SetBayerCCMParamEx( this MVS mvs,
                                                 ref MV_CC_CCM_PARAM_EX pstCCMParam )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_SetBayerCCMParamEx_NET( ref pstCCMParam );
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
        /// This API is used for LSC calibration.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="pstLSCCalibParam">Structure about LSC calibration parameters.
        /// See MV_CC_LSC_CALIB_PARAM for details.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool LSCCalib( this MVS mvs,
                                       ref MV_CC_LSC_CALIB_PARAM pstLSCCalibParam )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_LSCCalib_NET( ref pstLSCCalibParam );
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
        /// This API is used for LSC correction.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="pstLSCCorrectParam">Structure about LSC correction parameters.
        /// See MV_CC_LSC_CORRECT_PARAM for details.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool LSCCorrect( this MVS mvs,
                                         ref MV_CC_LSC_CORRECT_PARAM pstLSCCorrectParam )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_LSCCorrect_NET( ref pstLSCCorrectParam );
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
        /// Decode lossless compression stream into raw data.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="pstDecodeParam">Lossless decoding parameters structure,
        /// see MV_CC_HB_DECODE_PARAM for details.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool HB_Decode( this MVS mvs,
                                        ref MV_CC_HB_DECODE_PARAM pstDecodeParam )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_HB_Decode_NET( ref pstDecodeParam );
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
        /// Rotate images in MONO8/RGB24/BGR24 format.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="pstRotateParam">Image rotation structure,
        /// see MV_CC_ROTATE_IMAGE_PARAM for details.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool RotateImage( this MVS mvs,
                                          ref MV_CC_ROTATE_IMAGE_PARAM pstRotateParam )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_RotateImage_NET( ref pstRotateParam );
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
        /// Flip images in MONO8/RGB24/BGR24 format.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="pstFlipParam">Image flipping structure,
        /// see MV_CC_FLIP_IMAGE_PARAM for details.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool FlipImage( this MVS mvs,
                                        MV_CC_FLIP_IMAGE_PARAM pstFlipParam )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_FlipImage_NET( ref pstFlipParam );
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
        /// Start recording.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="pstRecordParam">Video parameters,
        /// see the structure MV_CC_RECORD_PARAM for details.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool StartRecord( this MVS mvs,
                                          ref MV_CC_RECORD_PARAM pstRecordParam )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_StartRecord_NET( ref pstRecordParam );
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
        /// Transmit video parameters.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="pstInputFrameInfo">Video parameters,
        /// see the structure MV_CC_INPUT_FRAME_INFO for details.</param>
        /// <returns></returns>
        public static bool InputOneFrame( this MVS mvs,
                                            ref MV_CC_INPUT_FRAME_INFO pstInputFrameInfo )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_InputOneFrame_NET( ref pstInputFrameInfo );
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
        /// Stop recording.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool StopRecord( this MVS mvs )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_StopRecord_NET();
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
        /// Save image to file. Supported image format: BMP, JPEG, PNG, and TIFF.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="pstSaveFileParam">Structure about image saving parameters,
        /// see MV_SAVE_IMG_TO_FILE_PARAM for details.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool MV_CC_SaveImageToFile_NET( this MVS mvs,
                                                        ref MV_SAVE_IMG_TO_FILE_PARAM pstSaveFileParam )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_SaveImageToFile_NET( ref pstSaveFileParam );
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
        /// <param name="mvs"></param>
        /// <param name="pstPointDataParam"></param>
        /// <returns></returns>
        public static bool SavePointCloudData( this MVS mvs,
                                                 ref MV_SAVE_POINT_CLOUD_PARAM pstPointDataParam )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_SavePointCloudData_NET( ref pstPointDataParam );
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
