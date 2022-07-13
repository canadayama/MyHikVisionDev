using System;
using System.Reflection;

using BE.Cameras;

using static MvCamCtrl.NET.MyCamera;

namespace EB.Cameras.HikVision
{
    /// <summary>
    /// 
    /// </summary>
    public static class MVSGigEAPIExt
    {
        #region ************************** GigE APIs ***************************

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <returns></returns>
        internal static bool GetOptimalPacketSize( this MVS mvs )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_GetOptimalPacketSize_NET();
                if ( rslt == MV_OK )
                {
                    return true;
                }

                mvs.LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
                return false;
            }

            mvs.LastErrorMessage
                = CamHelper.StdCameraNotOpenMessage(mvs.CamName,
                                                     MethodBase.GetCurrentMethod().Name );
            return false;
        }

        #endregion *************************************************************
    }
}
