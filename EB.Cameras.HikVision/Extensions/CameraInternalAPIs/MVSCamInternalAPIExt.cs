using System;
using System.Reflection;

using BE.Cameras;

using static MvCamCtrl.NET.MyCamera;

namespace EB.Cameras.HikVision.Extensions.CameraInternalAPIs
{
    /// <summary>
    /// 
    /// </summary>
    public static class MVSCamInternalAPIExt
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="pFilePathName">Upgrade packet path,
        /// including the absolute path or relative path.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool MV_CC_LocalUpgrade_NET( this MVS mvs,
                                                   string pFilePathName )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_LocalUpgrade_NET( pFilePathName );
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
        /// Get the current upgrade progress.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="pnProcess">Current upgrade progress, percentage: from 0 to 100.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool GetUpgradeProcess( this MVS mvs,
                                              ref uint pnProcess )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_GetUpgradeProcess_NET( ref pnProcess );
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
        /// Get the camera description file in XML format.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="pData">The XML file buffer address.</param>
        /// <param name="nDataSize">The XML file buffer size.</param>
        /// <param name="pnDataLen">The XML file length.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool GetGenICamXML( this MVS mvs,
                                          IntPtr pData,
                                          uint nDataSize,
                                          ref uint pnDataLen )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_XML_GetGenICamXML_NET( pData, nDataSize, ref pnDataLen );
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
        /// Get the current node type.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="strKey">Node name.</param>
        /// <param name="pInterfaceType">API type corresponds to each node,
        /// see the enumeration MV_XML_InterfaceType for details.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool GetNodeInterfaceType( this MVS mvs,
                                                 string strKey,
                                                 ref MV_XML_InterfaceType pInterfaceType)
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_XML_GetNodeInterfaceType_NET( strKey, ref pInterfaceType );
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
        /// Get current node access mode.
        /// </summary>
        /// <param name="mvs">MVS object.</param>
        /// <param name="strKey">Node name.</param>
        /// <param name="stAccessMode">Node access mode,
        /// see the enumeration MV_XML_AccessMode for details.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool GetNodeAccessMode( this MVS mvs,
                                              string strKey,
                                              ref MV_XML_AccessMode stAccessMode )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_XML_GetNodeAccessMode_NET( strKey, ref stAccessMode );
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
    }
}
