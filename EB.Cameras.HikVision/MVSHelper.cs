using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using EB.Cameras.HikVision.Classes;

using BE.Cameras;
using BE.Cameras.Exceptions;
using EB.Cameras.HikVision.Settings;

using MvCamCtrl.NET;
using static MvCamCtrl.NET.MyCamera;

namespace EB.Cameras.HikVision
{
    /// <summary>
    /// 
    /// </summary>
    public static class MVSHelper
    {
        #region ******************* Static(Class) Properties *******************

        /// <summary></summary>
        static Dictionary<int, string> ErrDic { get; }

        #endregion *************************************************************

        #region ******************* Static(Class) Constructor ******************

        /// <summary>
        ///
        /// </summary>
        static MVSHelper()
        {
            ErrDic = new Dictionary<int, string>()
            {
                // General Error Codes
                { MV_E_HANDLE, "Error or invalid handle." },
                { MV_E_SUPPORT, "Not supported function." },
                { MV_E_BUFOVER, "Buffer is full." },
                { MV_E_CALLORDER, "Incorrect calling order." },
                { MV_E_PARAMETER, "Incorrect parameter." },
                { MV_E_RESOURCE, "Applying resource failed." },
                { MV_E_NODATA, "No data." },
                { MV_E_PRECONDITION, "Precondition error, or the running environment changed." },
                { MV_E_VERSION, "Version mismatches." },
                { MV_E_NOENOUGH_BUF, "Insufficient memory." },
                { MV_E_ABNORMAL_IMAGE, "Abnormal image. Incomplete image caused by packet loss." },
                { MV_E_LOAD_LIBRARY, "Importing DLL (Dynamic Link Library) failed." },
                { MV_E_NOOUTBUF, "No buffer node can be outputted." },
                { MV_E_ENCRYPT, "Encryption error." },
                { MV_E_UNKNOW, "Unknown error." },
                // GenICam Series Error Codes
                { MV_E_GC_GENERIC, "Generic error." },
                { MV_E_GC_ARGUMENT, "Illegal parameters." },
                { MV_E_GC_RANGE, "The value is out of range." },
                { MV_E_GC_PROPERTY, "Attribute error." },
                { MV_E_GC_RUNTIME, "Running environment error." },
                { MV_E_GC_LOGICAL, "Incorrect logic." },
                { MV_E_GC_ACCESS, "Node accessing condition error." },
                { MV_E_GC_TIMEOUT, "Timed out." },
                { MV_E_GC_DYNAMICCAST, "Conversion exception." },
                { MV_E_GC_UNKNOW, "GenICam unknown error." },
                // GigE Error Codes
                { MV_E_NOT_IMPLEMENTED, "The command is not supported by the device." },
                { MV_E_INVALID_ADDRESS, "The target address being accessed does not exist." },
                { MV_E_WRITE_PROTECT, "The target address is not writable." },
                { MV_E_ACCESS_DENIED, "The device has no access permission." },
                { MV_E_BUSY, "Device is busy, or the network disconnected." },
                { MV_E_PACKET, "Network packet error." },
                { MV_E_NETER, "Network error." },
                { MV_E_IP_CONFLICT, "Device IP address conflicted." },
                // USB_STATUS Error Codes
                { MV_E_USB_READ, "Reading USB error." },
                { MV_E_USB_WRITE, "Writing USB error." },
                { MV_E_USB_DEVICE, "Device exception." },
                { MV_E_USB_GENICAM, "GenICam error." },
                { MV_E_USB_BANDWIDTH, "Insufficient bandwidth." },
                { MV_E_USB_UNKNOW, "USB unknown error." },
                // Upgrade Error Codes
                { MV_E_UPG_FILE_MISMATCH, "Firmware mismatches." },
                { MV_E_UPG_LANGUSGE_MISMATCH, "Firmware language mismatches." },
                { MV_E_UPG_CONFLICT, "Upgrading conflicted (repeated upgrading requests during device upgrade)." },
                { MV_E_UPG_INNER_ERR, "Camera internal error during upgrade." },
                { MV_E_UPG_UNKNOW, "Unknown error during upgrade." },
                // Exception Error Codes
                { MV_EXCEPTION_DEV_DISCONNECT, "Device disconnected." },
                { MV_EXCEPTION_VERSION_CHECK, "SDK doesn't match the driver version." },
                // General Error Codes
                //{ MV_ALG_OK, "OK" },
                { MV_ALG_ERR, "Unknown error." },
                // Capability Related Error Codes
                { MV_ALG_E_ABILITY_ARG, "Invalid parameters of capabilities." },
                // Memory Related Error Codes
                { MV_ALG_E_MEM_NULL, "The memory address is empty." },
                { MV_ALG_E_MEM_ALIGN, "The memory alignment is not satisfactory." },
                { MV_ALG_E_MEM_LACK, "Not enough memory space." },
                { MV_ALG_E_MEM_SIZE_ALIGN, "The memory space does not meet the requirement of alignment." },
                { MV_ALG_E_MEM_ADDR_ALIGN, "The memory address does not meet the requirement of alignment." },
                // Image Related Error Codes
                { MV_ALG_E_IMG_FORMAT, "Incorrect image format or the image format is not supported." },
                { MV_ALG_E_IMG_SIZE, "Invalid image width and height." },
                { MV_ALG_E_IMG_STEP, "The image width/height and step parameters mismatched." },
                { MV_ALG_E_IMG_DATA_NULL, "The storage address of image is empty." },
                // Input/Output Related Error Codes
                { MV_ALG_E_CFG_TYPE, "Incorrect type for setting/ getting." },
                { MV_ALG_E_CFG_SIZE, "Incorrect size for setting/ getting parameters." },
                { MV_ALG_E_PRC_TYPE, "Incorrect processing type." },
                { MV_ALG_E_PRC_SIZE, "Incorrect parameter size for processing." },
                { MV_ALG_E_FUNC_TYPE, "Incorrect sub-process type." },
                { MV_ALG_E_FUNC_SIZE, "Incorrect parameter size for subprocessing." },
                // Operation Parameters Related Error Codes
                { MV_ALG_E_PARAM_INDEX, "Incorrect index parameter." },
                { MV_ALG_E_PARAM_VALUE, "Incorrect or invalid value parameter." },
                { MV_ALG_E_PARAM_NUM, "Incorrect param_num parameter." },
                // API Calling Related Error Codes
                { MV_ALG_E_NULL_PTR, "Pointer to function is empty." },
                { MV_ALG_E_OVER_MAX_MEM, "The maximum memory reached." },
                { MV_ALG_E_CALL_BACK, "Callback function error." },
                // Algorithm Library Encryption Related Error Codes
                { MV_ALG_E_ENCRYPT, "Encryption error." },
                { MV_ALG_E_EXPIRE, "Incorrect algorithm library service life." },
                // Basic Errors of Inner Module
                { MV_ALG_E_BAD_ARG, "Incorrect value range of the parameter." },
                { MV_ALG_E_DATA_SIZE, "Incorrect data size." },
                { MV_ALG_E_STEP, "Incorrect data step." },
                // Other Error Codes
                { MV_ALG_E_CPUID, "The instruction set of optimized code does not supported by the CPU." },
                { MV_ALG_WARNING, "Warning." },
                { MV_ALG_E_TIME_OUT, "Algorithm library timed out." },
                { MV_ALG_E_LIB_VERSION, "Algorithm version No. error." },
                { MV_ALG_E_MODEL_VERSION, "Model version No. error." },
                { MV_ALG_E_GPU_MEM_ALLOC, "GUP memory allocation error." },
                { MV_ALG_E_FILE_NON_EXIST, "The file does not exist." },
                { MV_ALG_E_NONE_STRING, "The string is empty." },
                { MV_ALG_E_IMAGE_CODEC, "Image decoder error." },
                { MV_ALG_E_FILE_OPEN, "Opening file failed." },
                { MV_ALG_E_FILE_READ, "Reading file failed." },
                { MV_ALG_E_FILE_WRITE, "Writing to file failed." },
                { MV_ALG_E_FILE_READ_SIZE, "Incorrect file read size." },
                { MV_ALG_E_FILE_TYPE, "Incorrect file type." },
                { MV_ALG_E_MODEL_TYPE, "Incorrect model type." },
                { MV_ALG_E_MALLOC_MEM, "Memory allocation error." },
                { MV_ALG_E_BIND_CORE_FAILED, "Binding thread to core failed." },
                // Denoising Related Error Codes
                { MV_ALG_E_DENOISE_NE_IMG_FORMAT, "Incorrect image format of noise characteristics." },
                { MV_ALG_E_DENOISE_NE_FEATURE_TYPE, "Incorrect noise characteristics type." },
                { MV_ALG_E_DENOISE_NE_PROFILE_NUM, "Incorrect number of noise characteristics." },
                { MV_ALG_E_DENOISE_NE_GAIN_NUM, "Incorrect number of noise characteristics gain." },
                { MV_ALG_E_DENOISE_NE_GAIN_VAL, "Incorrect noise curve gain value." },
                { MV_ALG_E_DENOISE_NE_BIN_NUM, "Incorrect number of noise curves." },
                { MV_ALG_E_DENOISE_NE_INIT_GAIN, "Incorrect settings of noise initial gain." },
                { MV_ALG_E_DENOISE_NE_NOT_INIT, "The noise is uninitialized." },
                { MV_ALG_E_DENOISE_COLOR_MODE, "Incorrect color mode." },
                { MV_ALG_E_DENOISE_ROI_NUM, "Incorrect number of ROIs." },
                { MV_ALG_E_DENOISE_ROI_ORI_PT, "Incorrect ROI origin." },
                { MV_ALG_E_DENOISE_ROI_SIZE, "Incorrect ROI size." },
                { MV_ALG_E_DENOISE_GAIN_NOT_EXIST, "The camera gain does not exist (The maximum number of gains reached)." },
                { MV_ALG_E_DENOISE_GAIN_BEYOND_RANGE, "Invalid camera gain." },
                { MV_ALG_E_DENOISE_NP_BUF_SIZE, "Incorrect noise characteristics memory size." },
                { MV_OK, "OK" },
            };
        }

        #endregion *************************************************************

        #region ********************* Static(Class) Methods ********************

        /// <summary>
        /// Gets the error code desciption.
        /// </summary>
        /// <param name="errCode">error code</param>
        /// <returns>Formatted description of error code.</returns>
        public static string FormatMVSErr( int errCode )
        {
            if ( ErrDic.TryGetValue( errCode, out string errStr ) )
            {
                return string.Format( "{0} (0x{1:X8})", errStr, errCode );
            }

            return string.Format( "Unknown MVS_ERR(0x{0:X8})", errCode );
        }

        #region =================== Static MyCamera Methods ====================

        #region --------------------------- General ----------------------------

        /// <summary>
        /// Gets the SDK Version.
        /// </summary>
        /// <returns>Version</returns>
        public static Version GetSDKVersion()
        {
            int[] verComps = new int[] { 0, 0, 0, 0 };
            
            uint version = MV_CC_GetSDKVersion_NET();
            for ( int i = 0; i < verComps.Length; i++, version >>= 8 )
            {
                verComps[i] = (int)( version & 0xFF );  // mask first byte
            }

            return new Version( verComps[3], verComps[2], verComps[1], verComps[0] );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int EnumerateTls()
        {
            return MV_CC_EnumerateTls_NET();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tlayerType"></param>
        /// <param name="deviceList"></param>
        /// <returns></returns>
        /// <exception cref="CamException">Thrown on MVS error; contains detail of error.</exception>
        public static MV_CC_DEVICE_INFO_LIST EnumDevices( uint tlayerType )
        {
            MV_CC_DEVICE_INFO_LIST deviceList = new MV_CC_DEVICE_INFO_LIST();

            int rslt = MV_CC_EnumDevices_NET( tlayerType, ref deviceList );
            if ( rslt == MV_OK )
            {
                return deviceList;
            }

            throw new CamException( FormatMVSErr( rslt ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tlayerType"></param>
        /// <param name="manufacturerName"></param>
        /// <returns></returns>
        /// <exception cref="CamException">Thrown on MVS error; contains detail of error.</exception>
        public static MV_CC_DEVICE_INFO_LIST EnumDevicesEx( uint tlayerType,
                                                            string manufacturerName )
        {
            MV_CC_DEVICE_INFO_LIST deviceList = new MV_CC_DEVICE_INFO_LIST();
            
            int rslt = MV_CC_EnumDevicesEx_NET( tlayerType, ref deviceList, manufacturerName );
            if ( rslt == MV_OK )
            {
                return deviceList;
            }

            throw new CamException( FormatMVSErr( rslt ) ); 
        }

        /// <summary>
        /// Check whether the device is accessible.
        /// </summary>
        /// <param name="deviceInfo"></param>
        /// <param name="accessMode"></param>
        /// <returns>true if accessible; false NOT accessible.</returns>
        public static bool IsDeviceAccessible( ref MV_CC_DEVICE_INFO deviceInfo,
                                               uint accessMode = MV_ACCESS_Exclusive )
        {
            return MV_CC_IsDeviceAccessible_NET( ref deviceInfo, accessMode );
        }
                
        /// <summary>
        /// Create handle with/without generating logs.
        /// </summary>
        /// <param name="deviceInfo"></param>
        /// <returns>Created MyCamera.</returns>
        /// <exception cref="CamException">Thrown on MVS error; contains detail of error.</exception>
        public static MyCamera CreateDevice( ref MV_CC_DEVICE_INFO deviceInfo,
                                             bool withLog = false )
        {
            MyCamera camera = new MyCamera();
            
            int rslt = withLog ? camera.MV_CC_CreateDevice_NET( ref deviceInfo )
                               : camera.MV_CC_CreateDeviceWithoutLog_NET( ref deviceInfo );
            if ( rslt == MV_OK )
            {
                return camera;
            }

            throw new CamException( FormatMVSErr( rslt ) );
        }

        #endregion -------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sdkLogPath"></param>
        /// <exception cref="CamException"></exception>
        public static void SetSDKLogPath( string sdkLogPath )
        {
            int rslt = MV_CC_SetSDKLogPath_NET( sdkLogPath );
            if ( rslt == MV_OK )
            {
                return;
            }

            throw new CamException( FormatMVSErr( rslt ) );
        }
        
        #endregion =============================================================

        #region ========================= MVS Methods ==========================

        /// <summary>
        /// 
        /// </summary>
        /// <param name="all"></param>
        /// <returns></returns>
        /// <exception cref="CamException">Thrown on MVS error; contains detail of error.</exception>
        public static List<ICamDevice> GetAvailableDevices( bool all = false,
                                                            uint tLayerTypes = MVSConsts.STD_TL_TYPES )
        {
            List<ICamDevice> deviceList = new List<ICamDevice>();

            MV_CC_DEVICE_INFO_LIST devInfoList = EnumDevices( tLayerTypes );
            for ( int i = 0; i < devInfoList.nDeviceNum; i++ )
            {
                MV_CC_DEVICE_INFO devInfo = (MV_CC_DEVICE_INFO)Marshal.PtrToStructure( devInfoList.pDeviceInfo[i], typeof( MV_CC_DEVICE_INFO ) );
                if ( !all && !IsDeviceAccessible( ref devInfo ) )
                {
                    continue;
                }

                var mvsCamDevice = new MVSCamDevice( devInfo );
                if ( !deviceList.Any( item => ( item.DeviceName == mvsCamDevice.DeviceName ) ) )
                {
                    deviceList.Add( mvsCamDevice );
                }
            }

            return deviceList;
        }

        /// <summary>
        /// Gets the ICamDevice given/not given the device name.
        /// </summary>
        /// <param name="deviceName">
        /// Name of device;
        /// if null or empty will get the first available camera device.</param>
        /// <returns>ICamDevice on success;
        /// null if deviceName does not exist or no devices to get first.</returns>
        public static ICamDevice GetDevice( string deviceName = null )
        {
            var devices = GetAvailableDevices();
            if ( devices.Count > 0 )
            {
                if ( string.IsNullOrWhiteSpace( deviceName ) )
                {
                    return devices[0];
                }

                return devices.Find( x => string.Compare( x.DeviceName, deviceName ) == 0 );
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="camDevice"></param>
        /// <returns></returns>
        public static bool IsAccessible( ICamDevice camDevice )
        {
            if ( camDevice is MVSCamDevice mvsCamDevice )
            {
                MV_CC_DEVICE_INFO deviceInfo = mvsCamDevice.DeviceInfo;
                return IsDeviceAccessible( ref deviceInfo );
            }

            throw new ArgumentException( string.Format( "{0}は[{1}]ではありません",
                                                            nameof( camDevice ),
                                                            nameof( MVSCamDevice ) ) );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="camDevice"></param>
        /// <param name="withLog"></param>
        /// <returns></returns>
        /// <exception cref="CamException">Thrown on MVS error; contains detail of error.</exception>
        /// <exception cref="ArgumentException">Thrown if camDevice is not a MVSCamDevice.</exception>
        public static MyCamera CreateDevice( ICamDevice camDevice,
                                             bool withLog = false )
        {
            if ( camDevice is MVSCamDevice mvsCamDevice )
            {
                MV_CC_DEVICE_INFO deviceInfo = mvsCamDevice.DeviceInfo;
                return CreateDevice( ref deviceInfo, withLog );
            }

            throw new ArgumentException( string.Format( "{0}は[{1}]ではありません",
                                                            nameof( camDevice ),
                                                            nameof( MVSCamDevice ) ) );
        }

        #endregion =============================================================

        #region ================== String Formatting Methods ===================

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string GetCamName( int index )
        {
            return string.Format( "Cam{0}", ( index < 0 )
                                                    ? ""
                                                    : ( index + 1 ).ToString() );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strKey"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public static string StdGetSetErrHeader( string strKey, string methodName )
        {
            return string.Format( "{0}({1})", strKey, methodName );
        }

        #endregion =============================================================

        #endregion *************************************************************
    }
}
