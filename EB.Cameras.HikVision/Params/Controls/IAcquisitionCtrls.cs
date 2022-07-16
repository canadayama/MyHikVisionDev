namespace EB.Cameras.HikVision.Params.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAcquisitionCtrls
    {
        #region ************************** Properties **************************

        ///// <summary></summary>
        //IEnumParam AcquisitionMode { get; }

        /// <summary></summary>
        ICommandParam AcquisitionStop { get; }

        /// <summary></summary>
        IIntParam AcquisitionBurstFrameCount { get; }

        /// <summary></summary>
        IFloatParam AcquisitionFrameRate { get; }

        /// <summary></summary>
        IBoolParam AcquisitionFrameRateEnable { get; }

        /// <summary></summary>
        IFloatParamRO ResultingFrameRate { get; }

        ///// <summary></summary>
        //IEnumParam TriggerSelector { get; }

        ///// <summary></summary>
        //IEnumParam TriggerMode { get; }

        /// <summary></summary>
        ICommandParam TriggerSoftware { get; }

        ///// <summary></summary>
        //IEnumParam TriggerSource { get; }

        /// <summary></summary>
        IFloatParam TriggerDelay { get; }

        /// <summary></summary>
        IBoolParam TriggerCacheEnable { get; }

        ///// <summary></summary>
        //IEnumParam ExposureMode { get; }

        /// <summary></summary>
        IFloatParam ExposureTime { get; }

        ///// <summary></summary>
        //IEnumParam ExposureAuto { get; }

        /// <summary></summary>
        IIntParam AutoExposureTimeLowerLimit { get; }

        /// <summary></summary>
        IIntParam AutoExposureTimeUpperLimit { get; }

        /// <summary></summary>
        IBoolParam HDREnable { get; }

        /// <summary></summary>
        IIntParam HDRSelector { get; }

        /// <summary></summary>
        IIntParam HDRShutter { get; }

        /// <summary></summary>
        IFloatParam HDRGain { get; }

        #endregion *************************************************************
    }
}
