using System.Reflection;

using BE.Cameras;

using static MvCamCtrl.NET.MyCamera;

namespace EB.Cameras.HikVision.Extensions.CameraLink

{
    /// <summary>
    /// 
    /// </summary>
    public static class MVSCamLinkExt
    {
        #region ========================== CameraLink ==========================

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="pnCurrentBaudrate"></param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool GetDeviceBauderate( this MVS mvs, ref uint pnCurrentBaudrate )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CAML_GetDeviceBauderate_NET(ref pnCurrentBaudrate );
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
        /// <param name="pnBuadrateAbility"></param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool GetSupportBauderates( this MVS mvs, ref uint pnBuadrateAbility )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CAML_GetSupportBauderates_NET( ref pnBuadrateAbility );
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
        /// <param name="nBaudrate"></param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool SetDeviceBauderate( this MVS mvs, uint nBaudrate )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CAML_SetDeviceBauderate_NET( nBaudrate );
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
        /// <param name="nMillisec"></param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool SetGenCPTimeOut( this MVS mvs, uint nMillisec )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CAML_SetGenCPTimeOut_NET( nMillisec );
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
