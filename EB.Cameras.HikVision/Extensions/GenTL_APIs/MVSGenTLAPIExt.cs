using System.Reflection;

using BE.Cameras;

using MvCamCtrl.NET;
using static MvCamCtrl.NET.MyCamera;

namespace EB.Cameras.HikVision.Extensions.GenTL_APIs
{
    /// <summary>
    /// 
    /// </summary>
    public static class MVSGenTLAPIExt
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="stDevInfo"></param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool CreateDeviceByGenTL( this MVS mvs,
                                                          ref MV_GENTL_DEV_INFO stDevInfo )
        {
            if ( mvs.IsOpen )
            {
                int rslt = mvs.Cam.MV_CC_CreateDeviceByGenTL_NET( ref stDevInfo );
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
        /// <param name="stIFInfo"></param>
        /// <param name="stDevList"></param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool EnumDevicesByGenTL( this MVS mvs,
                                               ref MV_GENTL_IF_INFO stIFInfo,
                                               ref MV_GENTL_DEV_INFO_LIST stDevList )
        {
            int rslt = MyCamera.MV_CC_EnumDevicesByGenTL_NET( ref stIFInfo, ref stDevList );
            if ( rslt == MV_OK )
            {
                return true;
            }

            mvs.LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="stIFInfoList"></param>
        /// <param name="pGenTLPath"></param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        public static bool EnumInterfacesByGenTL( this MVS mvs,
                                                  ref MV_GENTL_IF_INFO_LIST stIFInfoList,
                                                  string pGenTLPath )
        {
            int rslt = MyCamera.MV_CC_EnumInterfacesByGenTL_NET( ref stIFInfoList, pGenTLPath );
            if ( rslt == MV_OK )
            {
                return true;
            }

            mvs.LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
            return false;
        }
    }
}
