using EB.Cameras.HikVision.Settings;

namespace EB.Cameras.HikVision.Params.Controls
{
    /// <summary>
    /// 
    /// </summary>
    class AcquisitionCtrls : IAcquisitionCtrls
    {
        #region ************************** Properties **************************

        ///// <summary></summary>
        //public IEnumParam AcquisitionMode { get; }

        /// <summary></summary>
        public ICommandParam AcquisitionStop { get; }

        /// <summary></summary>
        public IIntParam AcquisitionBurstFrameCount { get; }

        /// <summary></summary>
        public IFloatParam AcquisitionFrameRate { get; }

        /// <summary></summary>
        public IBoolParam AcquisitionFrameRateEnable { get; }

        /// <summary></summary>
        public IFloatParamRO ResultingFrameRate { get; }

        ///// <summary></summary>
        //public IEnumParam TriggerSelector { get; }
        
        ///// <summary></summary>
        //public IEnumParam TriggerMode { get; }

        /// <summary></summary>
        public ICommandParam TriggerSoftware { get; }

        ///// <summary></summary>
        //public IEnumParam TriggerSource { get; }

        /// <summary></summary>
        public IFloatParam TriggerDelay { get; }

        /// <summary></summary>
        public IBoolParam TriggerCacheEnable { get; }

        ///// <summary></summary>
        //public IEnumParam ExposureMode { get; }

        /// <summary></summary>
        public IFloatParam ExposureTime { get; }

        ///// <summary></summary>
        //public IEnumParam ExposureAuto { get; }

        /// <summary></summary>
        public IIntParam AutoExposureTimeLowerLimit { get; }

        /// <summary></summary>
        public IIntParam AutoExposureTimeUpperLimit { get; }

        /// <summary></summary>
        public IBoolParam HDREnable { get; }

        /// <summary></summary>
        public IIntParam HDRSelector { get; }

        /// <summary></summary>
        public IIntParam HDRShutter { get; }

        /// <summary></summary>
        public IFloatParam HDRGain { get; }

        #endregion *************************************************************

        #region ************************* Constructor **************************

        /// <summary>
        ///
        /// </summary>
        /// <param name="mvs"></param>
        public AcquisitionCtrls( MVS mvs )
        {
            //AcquisitionMode = new EnumParam( mvs, MVSConsts );
            AcquisitionStop = new CommandParam( mvs, MVSConsts.AcquisitionStop );
            AcquisitionBurstFrameCount = new IntParam( mvs, MVSConsts.AcquisitionBurstFrameCount );
            AcquisitionFrameRate = new FloatParam( mvs, MVSConsts.AcquisitionFrameRate, " fps" );
            AcquisitionFrameRateEnable = new BoolParam( mvs, MVSConsts.AcquisitionFrameRateEnable );

            ResultingFrameRate = new FloatParam( mvs, MVSConsts.ResultingFrameRate, " fps" );

            //TriggerSelector = new EnumParams( mvs, MVSConsts.TriggerSelector );
            //TriggerMode = new EnumParams( mvs, MVSConsts.TriggerMode );
            TriggerSoftware = new CommandParam( mvs, MVSConsts.TriggerSoftware );
            //TriggerSource = new EnumParam( mvs, MVSConsts.TriggerSource );
            TriggerDelay = new FloatParam( mvs, MVSConsts.TriggerDelay, "μs" );
            TriggerCacheEnable = new BoolParam( mvs, MVSConsts.TriggerCacheEnable );

            //ExposureMode = new EnumParam( mvs, MVSConsts.ExposureMode );
            ExposureTime = new FloatParam( mvs, MVSConsts.ExposureTime, "μs" );
            //ExposureAuto = new IEnumParam( mvs, MVSConsts.ExposureAuto );

            AutoExposureTimeLowerLimit = new IntParam( mvs, MVSConsts.AutoExposureTimeLowerLimit, "μs" );
            AutoExposureTimeUpperLimit = new IntParam( mvs, MVSConsts.AutoExposureTimeUpperLimit, "μs" );

            HDREnable = new BoolParam( mvs, MVSConsts.HDREnable );
            HDRSelector = new IntParam( mvs, MVSConsts.HDRSelector );
            HDRShutter = new IntParam( mvs, MVSConsts.HDRShutter, "μs" );
            HDRGain = new FloatParam( mvs, MVSConsts.HDRGain, " dB" );
        }

        #endregion *************************************************************
    }
}
