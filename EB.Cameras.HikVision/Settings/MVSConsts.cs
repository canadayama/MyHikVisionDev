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

        #region ==================== Image Format Controls =====================

        public const string WidthMax = "WidthMax";
        public const string HeightMax = "HeightMax";
        public const string RegionSelector = "RegionSelector";
        public const string RegionDestination = "RegionDestination";
        public const string Width = "Width";
        public const string Height = "Height";
        public const string OffsetX = "OffsetX";
        public const string OffsetY = "OffsetY";
        public const string ReverseX = "ReverseX";
        public const string ReverseY = "ReverseY";
        public const string PixelFormat = "PixelFormat";
        public const string PixelSize = "PixelSize";
        public const string TestPatternGeneratorSelector = "TestPatternGeneratorSelector";
        public const string TestPattern = "TestPattern";
        public const string BinningSelector = "BinningSelector";
        public const string BinningHorizontal = "BinningHorizontal";
        public const string BinningVertical = "BinningVertical";
        public const string DecimationHorizontal = "DecimationHorizontal";
        public const string DecimationVertical = "DecimationVertical";
        public const string FrameSpecInfoSelector = "FrameSpecInfoSelector";
        public const string FrameSpecInfo = "FrameSpecInfo";

        #endregion =============================================================

        #region ===================== Acquisition Controls =====================

        public const string AcquisitionMode = "AcquisitionMode";
        public const string AcquisitionStop = "AcquisitionStop";
        public const string AcquisitionBurstFrameCount = "AcquisitionBurstFrameCount";
        public const string AcquisitionFrameRate = "AcquisitionFrameRate";
        public const string AcquisitionFrameRateEnable = "AcquisitionFrameRateEnable";

        public const string ResultingFrameRate = "ResultingFrameRate";

        public const string TriggerSelector = "TriggerSelector";
        public const string TriggerMode = "TriggerMode";
        public const string TriggerSoftware = "TriggerSoftware";
        public const string TriggerSource = "TriggerSource";
        public const string TriggerDelay = "TriggerDelay";
        public const string TriggerCacheEnable = "TriggerCacheEnable";

        public const string ExposureMode = "ExposureMode";
        public const string ExposureTime = "ExposureTime";
        public const string ExposureAuto = "ExposureAuto";

        public const string AutoExposureTimeLowerLimit = "AutoExposureTimeLowerLimit";
        public const string AutoExposureTimeUpperLimit = "AutoExposureTimeUpperLimit";

        public const string HDREnable = "HDREnable";
        public const string HDRSelector = "HDRSelector";
        public const string HDRShutter = "HDRShutter";
        public const string HDRGain = "HDRGain";

        #endregion =============================================================

        #region ======================= Analog Controls ========================

        public const string Gain = "Gain";
        public const string GainAuto = "GainAuto";

        public const string AutoGainLowerLimit = "AutoGainLowerLimit";
        public const string AutoGainUpperLimit = "AutoGainUpperLimit";

        public const string DigitalShift = "DigitalShift";
        public const string DigitalShiftEnable = "DigitalShiftEnable";

        public const string BlackLevel = "BlackLevel";
        public const string BlackLevelEnable = "DigitalShiftEnable";

        public const string Gamma = "Gamma";
        public const string GammaSelector = "GammaSelector";
        public const string GammaEnable = "GammaEnable";

        public const string SharpnessEnable = "SharpnessEnable";
        public const string Sharpness = "Sharpness";

        public const string AutoFunctionAOISelector = "AutoFunctionAOISelector";
        public const string AutoFunctionAOIWidth = "AutoFunctionAOIWidth";
        public const string AutoFunctionAOIHeight = "AutoFunctionAOIHeight";
        public const string AutoFunctionAOIOffsetX = "AutoFunctionAOIOffsetX";
        public const string AutoFunctionAOIOffsetY = "AutoFunctionAOIOffsetY";
        public const string AutoFunctionAOIUsageIntensity = "AutoFunctionAOIUsageIntensity";
        public const string AutoFunctionAOIUsageWhiteBalance = "AutoFunctionAOIUsageWhiteBalance";

        #endregion =============================================================

        #region ========================= LUT Controls =========================

        public const string LUTSelector = "LUTSelector";
        public const string LUTEnable = "LUTEnable";
        public const string LUTIndex = "LUTIndex";
        public const string LUTValue = "LUTValue";

        #endregion =============================================================

        #region ====================== Digital IO Controls =====================

        public const string LineSelector = "LineSelector";
        public const string LineMode = "LineMode";
        public const string LineInverter = "LineInverter";
        public const string LineStatus = "LineStatus";
        public const string LineStatusAll = "LineStatusAll";
        public const string LineSource = "LineSource";
        public const string LineDebouncerTime = "LineDebouncerTime";

        public const string StrobeEnable = "StrobeEnable";
        public const string StrobeLineDuration = "StrobeLineDuration";
        public const string StrobeLineDelay = "StrobeLineDelay";
        public const string StrobeLinePreDelay = "StrobeLinePreDelay";

        #endregion =============================================================

        #region ====================== User Set Controls ======================= 

        public const string UserSetCurrent = "UserSetCurrent";
        public const string UserSetSelector = "UserSetSelector";
        public const string UserSetLoad = "UserSetLoad";
        public const string UserSetSave = "UserSetSave";
        public const string UserSetDefault = "UserSetDefault";

        #endregion =============================================================

        #region =================== Transport Layer Controls ===================

        public const string PayloadSize = "PayloadSize";

        #endregion =============================================================

        #endregion *************************************************************
    }
}
