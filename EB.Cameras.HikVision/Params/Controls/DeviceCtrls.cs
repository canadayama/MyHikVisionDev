using EB.Cameras.HikVision.Settings;

namespace EB.Cameras.HikVision.Params.Controls
{
    /// <summary>
    /// 
    /// </summary>
    class DeviceCtrls : IDeviceCtrls
    {
        #region ************************** Properties **************************

        ///// <summary></summary>
        //public IEnumParamRO Type { get; }

        ///// <summary></summary>
        //public IEnumParamRO ScanType { get; }

        /// <summary></summary>
        public IStringParamRO VendorName { get; }

        /// <summary></summary>
        public IStringParamRO ModelName { get; }

        /// <summary></summary>
        public IStringParamRO ManufacturerInfo { get; }

        /// <summary></summary>
        public IStringParamRO Version { get; }

        /// <summary></summary>
        public IStringParamRO FirmwareVersion { get; }

        /// <summary></summary>
        public IStringParamRO SerialNumber { get; }

        /// <summary></summary>
        public IStringParamRO ID { get; }

        /// <summary></summary>
        public IStringParam UserID { get; }

        /// <summary></summary>
        public ICommandParam Reset { get; }

        #endregion *************************************************************

        #region ************************* Constructor **************************

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        public DeviceCtrls( MVS mvs )
        {
            //Type = new EnumParam( mvs, MVSConsts.DeviceType, MVSConsts.DeviceTypeDic );
            //ScanType = new EnumParam( mvs, MVSConsts.DeviceScanType, MVSConsts.DeviceScanTypeDic );

            VendorName = new StringParam( mvs, MVSConsts.DeviceVendorName );
            ModelName = new StringParam( mvs, MVSConsts.DeviceModelName );
            ManufacturerInfo = new StringParam( mvs, MVSConsts.DeviceManufacturerInfo );
            Version = new StringParam( mvs, MVSConsts.DeviceVersion );
            FirmwareVersion = new StringParam( mvs, MVSConsts.DeviceFirmwareVersion );
            SerialNumber = new StringParam( mvs, MVSConsts.DeviceSerialNumber );
            ID = new StringParam( mvs, MVSConsts.DeviceID );
            UserID = new StringParam( mvs, MVSConsts.DeviceUserID );
            
            Reset = new CommandParam( mvs, MVSConsts.DeviceReset );
        }

        #endregion *************************************************************
    }
}
