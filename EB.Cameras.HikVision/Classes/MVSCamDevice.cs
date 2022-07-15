using System.Runtime.InteropServices;

using BE.Cameras;

using MvCamCtrl.NET;
using static MvCamCtrl.NET.MyCamera;

namespace EB.Cameras.HikVision.Classes
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class MVSCamDevice : ICamDevice
    {
        #region ******************** Static(Class) Methods *********************

        /// <summary>
        /// 
        /// </summary>
        /// <param name="camSettings"></param>
        public static implicit operator MV_CC_DEVICE_INFO( MVSCamDevice mvsCamDevice )
        {
            return mvsCamDevice.DeviceInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static string FormatDeviceName( string devType, string devName, string serialNo )
        {
            return string.Format( "[{0}] {1}({2})", devType, devName, serialNo );
        }

        #endregion *************************************************************

        #region ************************** Properties **************************

        /// <summary></summary>
        public string Maker { get; }

        /// <summary></summary>
        public string DeviceName { get; }

        /// <summary>Basler Pylon ICameraInfo.</summary>
        internal MV_CC_DEVICE_INFO DeviceInfo { get; }

        #endregion *************************************************************

        #region ************************* Constructor **************************

        /// <summary>
        /// Constructor with devInfo.
        /// </summary>
        /// <param name="deviceInfo"></param>
        public MVSCamDevice( MV_CC_DEVICE_INFO deviceInfo )
        {
            DeviceInfo = deviceInfo;

            switch ( deviceInfo.nTLayerType )
            {
                case MV_USB_DEVICE:
                    {
                        MV_USB3_DEVICE_INFO usbInfo = (MV_USB3_DEVICE_INFO)Marshal.PtrToStructure( Marshal.UnsafeAddrOfPinnedArrayElement( deviceInfo.SpecialInfo.stUsb3VInfo, 0 ),
                                                                                                                                typeof( MV_USB3_DEVICE_INFO ) );
                        Maker = usbInfo.chManufacturerName;
                        DeviceName = FormatDeviceName( "USB",
                                                       string.IsNullOrWhiteSpace( usbInfo.chUserDefinedName )
                                                            ? usbInfo.chModelName : usbInfo.chUserDefinedName,
                                                       usbInfo.chSerialNumber );
                    }
                    break;

                case MV_GIGE_DEVICE:
                    {
                        MV_GIGE_DEVICE_INFO gigeInfo = (MV_GIGE_DEVICE_INFO)Marshal.PtrToStructure( Marshal.UnsafeAddrOfPinnedArrayElement( deviceInfo.SpecialInfo.stGigEInfo, 0 ),
                                                                                                                            typeof( MV_GIGE_DEVICE_INFO ) );
                        Maker = gigeInfo.chManufacturerName;
                        DeviceName = FormatDeviceName( "GIGE",
                                                       string.IsNullOrWhiteSpace( gigeInfo.chUserDefinedName )
                                                            ? gigeInfo.chModelName : gigeInfo.chUserDefinedName,
                                                       gigeInfo.chSerialNumber );
                    }
                    break;

                case MV_CAMERALINK_DEVICE:
                    {
                        MV_CamL_DEV_INFO camlinkInfo = (MV_CamL_DEV_INFO)Marshal.PtrToStructure( Marshal.UnsafeAddrOfPinnedArrayElement( deviceInfo.SpecialInfo.stCamLInfo, 0 ),
                                                                                                                            typeof( MV_CamL_DEV_INFO ) );
                        Maker = camlinkInfo.chManufacturerName;
                        DeviceName = FormatDeviceName( "CamLink", camlinkInfo.chModelName, camlinkInfo.chSerialNumber );
                    }
                    break;

                case MV_1394_DEVICE:
                default:
                    break;
            }
        }

        #endregion *************************************************************

        #region *********************** Instance Methods ***********************

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return DeviceName;
        }

        #endregion *************************************************************
    }
}
