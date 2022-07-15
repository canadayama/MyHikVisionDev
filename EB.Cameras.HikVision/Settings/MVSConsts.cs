using System;

using static MvCamCtrl.NET.MyCamera;

namespace EB.Cameras.HikVision.Settings
{
    /// <summary>
    /// 
    /// </summary>
    public static class MVSConsts
    {
        #region ************************** CONSTANTS ***************************

        public const int STD_TL_TYPES = MV_GIGE_DEVICE | MV_USB_DEVICE;

        #region ======================= Device Controls ========================

        public const string DeviceType = "DeviceType";
        public const string DeviceScanType = "DeviceScanType";
        public const string DeviceVendorName = "DeviceVendorName";
        public const string DeviceModelName = "DeviceModelName";
        public const string DeviceManufacturerInfo = "DeviceManufacturerInfo";
        public const string DeviceVersion = "DeviceVersion";
        public const string DeviceFirmwareVersion = "DeviceFirmwareVersion";
        public const string DeviceSerialNumber = "DeviceSerialNumber";
        public const string DeviceID = "DeviceID";
        public const string DeviceUserID = "DeviceUserID";
        public const string DeviceReset = "DeviceReset";
        
        #endregion =============================================================

        #endregion *************************************************************
    }
}
