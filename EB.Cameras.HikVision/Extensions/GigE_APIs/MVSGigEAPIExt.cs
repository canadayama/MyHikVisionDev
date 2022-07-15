using System.Reflection;

using BE.Cameras;
using BE.Cameras.Exceptions;

using MvCamCtrl.NET;
using static MvCamCtrl.NET.MyCamera;

namespace EB.Cameras.HikVision.Extensions.GigE_APIs
{
    /// <summary>
    /// 
    /// </summary>
    public static class MVSGigEAPIExt
    {
        #region ========================== GigE APIs ===========================

        /// <summary>
        /// Get the optimal size of packet.
        /// *Only GigEVision cameras*
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <returns>Optimal size of packet.</returns>
        /// <exception cref="CamException"></exception>
        /// <exception cref="CamNotOpenException"></exception>
        public static int GetOptimalPacketSize( this MVS mvs )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_GetOptimalPacketSize_NET();
                if ( rslt > 0 )
                {
                    return rslt;
                }

                throw new CamException( MVSHelper.FormatMVSErr( rslt ) );
            }

            throw new CamNotOpenException( CamHelper.StdCameraNotOpenMessage( mvs.CamName,
                                                                              MethodBase.GetCurrentMethod().Name ) );
        }

        /// <summary>
        /// Force camera network parameter, including IP address, subnet mask, default gateway.
        /// *Only GigEVision cameras*
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="nIP">Configured IP address.</param>
        /// <param name="nSubNetMask">Subnet mask.</param>
        /// <param name="nDefaultGateWay">Default gateway.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool ForceIpEx( this MVS mvs,
                                        uint nIP, uint nSubNetMask, uint nDefaultGateWay )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_GIGE_ForceIpEx_NET( nIP, nSubNetMask, nDefaultGateWay );
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
        /// Get GVSP streaming timeout.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="pnMillisec">Timeout period, unit: millisecond.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool GetGvspTimeout( this MVS mvs, ref uint pnMillisec )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_GIGE_GetGvspTimeout_NET( ref pnMillisec );
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
        /// Set GVSP streaming timeout.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="nMillisec">Timeout period, which is 300 by default,
        /// and its minimum value is 10, unit: millisecond.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool MV_GIGE_SetGvspTimeout_NET( this MVS mvs, uint nMillisec )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_GIGE_SetGvspTimeout_NET( nMillisec );
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
        /// Get the maximum times one packet can be resent.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="pnRetryTimes">The maximum times one packet can be resent.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool GetResendMaxRetryTimes( this MVS mvs,
                                                   ref uint pnRetryTimes )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_GIGE_GetResendMaxRetryTimes_NET( ref pnRetryTimes );
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
        /// Set the maximum times one packet can be resent.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="nRetryTimes">The maximum times one packet can be resent,
        /// which is 20 by default, and the minimum value is 0.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool SetResendMaxRetryTimes( this MVS mvs,
                                                   uint nRetryTimes )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_GIGE_SetResendMaxRetryTimes_NET( nRetryTimes );
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
        /// Get the packet resending interval.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="pnMillisec">Packet resending interval,
        /// unit: millisecond.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool GetResendTimeInterval( this MVS mvs,
                                                  ref uint pnMillisec )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_GIGE_GetResendTimeInterval_NET( ref pnMillisec );
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
        /// Set the packet resending interval.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="nMillisec">Packet resending interval,
        /// which is 10 by default, unit: millisecond.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool SetResendTimeInterval( this MVS mvs,
                                                  uint nMillisec )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_GIGE_SetResendTimeInterval_NET( nMillisec );
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
        /// Set transmission mode.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="nTransmissionType">Transmission mode,
        /// see the structure MV_CC_TRANSMISSION_TYPE for details.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool SetTransmissionType( this MVS mvs,
                                                ref MV_CC_TRANSMISSION_TYPE nTransmissionType )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_GIGE_SetTransmissionType_NET( ref nTransmissionType );
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
        /// Get the device multicast status.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="pstDevInfo">Device information structure,
        /// see MV_CC_DEVICE_INFO for details.</param>
        /// <param name="pStatus">Status: "true"-in multicast,
        /// "false"-not in multicast.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool GetMulticastStatus( this MVS mvs,
                                               ref MV_CC_DEVICE_INFO pstDevInfo,
                                               ref bool pStatus )
        {
            int rslt = MyCamera.MV_GIGE_GetMulticastStatus_NET( ref pstDevInfo, ref pStatus );
            if ( rslt == MV_OK )
            {
                return true;
            }

            mvs.LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
            return false;
        }

        /// <summary>
        /// Get network transmission information,
        /// including received data size, number of lost frames.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="pstInfo">Network transmission information,
        /// including received data size, number of lost frames, and so on.
        /// See MV_NETTRANS_INFO for details.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool GetNetTransInfo( this MVS mvs,
                                            ref MV_NETTRANS_INFO pstInfo )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_GIGE_GetNetTransInfo_NET( ref pstInfo );
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
        /// Send PTP (Precision Time Protocol) command of taking photo.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="pstActionCmdInfo">Command information,
        /// see the structure MV_ACTION_CMD_INFO for details.</param>
        /// <param name="pstActionCmdResults">Returned information list,
        /// see the structure MV_ACTION_CMD_RESULT_LIST for details.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool IssueActionCommand( this MVS mvs,
                                               ref MV_ACTION_CMD_INFO pstActionCmdInfo,
                                               ref MV_ACTION_CMD_RESULT_LIST pstActionCmdResults )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_GIGE_IssueActionCommand_NET( ref pstActionCmdInfo, ref pstActionCmdResults );
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
        /// Set the prior network mode.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="nType">Network mode;
        /// MyCamera.MV_NET_TRANS_DRIVER
        /// MyCamera.MV_NET_TRANS_SOCKET</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool SetNetTransMode( this MVS mvs,
                                            uint nType )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_GIGE_SetNetTransMode_NET( nType );
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
        /// Set IP address configuration mode.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="nType">IP address configuration mode;
        /// MyCamera.MV_IP_CFG_STATIC,
        /// MyCamera.MV_IP_CFG_DHCP,
        /// MyCamera.MV_IP_CFG_LLA.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool SetIpConfig( this MVS mvs,
                                        uint nType )
        {
            
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_GIGE_SetIpConfig_NET( nType );
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
        /// Set parameters of resending packets.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="bEnable">Enable resending packet: 0-Disable, 1-Enable.</param>
        /// <param name="nMaxResendPercent">Maximum packet resending percentage, range: [0,100].</param>
        /// <param name="nResendTimeout">Packet resending timeout, unit: millisecond.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool SetResend( this MVS mvs,
                                      uint bEnable,
                                      uint nMaxResendPercent,
                                      uint nResendTimeout )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_GIGE_SetResend_NET( bEnable, nMaxResendPercent, nResendTimeout );
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
