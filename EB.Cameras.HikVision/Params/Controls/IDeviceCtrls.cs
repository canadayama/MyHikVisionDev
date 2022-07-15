namespace EB.Cameras.HikVision.Params.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDeviceCtrls
    {
        #region ************************** Properties **************************

        ///// <summary></summary>
        //IEnumParamRO Type { get; }

        ///// <summary></summary>
        //IEnumParamRO ScanType { get; }

        /// <summary></summary>
        IStringParamRO VendorName { get; }

        /// <summary></summary>
        IStringParamRO ModelName { get; }

        /// <summary></summary>
        IStringParamRO ManufacturerInfo { get; }

        /// <summary></summary>
        IStringParamRO Version { get; }

        /// <summary></summary>
        IStringParamRO FirmwareVersion { get; }

        /// <summary></summary>
        IStringParamRO SerialNumber { get; }

        /// <summary></summary>
        IStringParamRO ID { get; }

        /// <summary></summary>
        IStringParam UserID { get; }

        /// <summary></summary>
        ICommandParam Reset { get; }

        #endregion *************************************************************
    }
}
