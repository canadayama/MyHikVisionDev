using EB.Cameras.HikVision.Settings;

namespace EB.Cameras.HikVision.Params.Controls
{
    /// <summary>
    /// 
    /// </summary>
    class AnalogCtrls : IAnalogCtrls
    {
        #region ************************** Properties **************************

        /// <summary></summary>
        public IFloatParam Gain { get; }

        ///// <summary></summary>
        //public IEnumParam GainAuto { get; }

        /// <summary></summary>
        public IFloatParam AutoGainLowerLimit { get; }

        /// <summary></summary>
        public IFloatParam AutoGainUpperLimit { get; }

        /// <summary></summary>
        public IFloatParam DigitalShift { get; }

        /// <summary></summary>
        public IBoolParam DigitalShiftEnable { get; }

        /// <summary></summary>
        public IIntParam BlackLevel { get; }

        /// <summary></summary>
        public IBoolParam BlackLevelEnable { get; }

        /// <summary></summary>
        public IFloatParam Gamma { get; }

        ///// <summary></summary>
        //public IEnumParam GammaSelector { get; }

        /// <summary></summary>
        public IBoolParam GammaEnable { get; }

        /// <summary></summary>
        public IBoolParam SharpnessEnable { get; }

        /// <summary></summary>
        public IIntParam Sharpness { get; }

        /// <summary></summary>
        public IAutoFunctionCtrls AutoFunction { get; }

        #endregion *************************************************************

        #region ************************* Constructor **************************

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        public AnalogCtrls( MVS mvs )
        {
            Gain = new FloatParam( mvs, MVSConsts.Gain, " dB" );
            //GainAuto = new EnumParam( mvs, MVSConsts.GainAuto );

            AutoGainLowerLimit = new FloatParam( mvs, MVSConsts.AutoGainLowerLimit, " dB" );
            AutoGainUpperLimit = new FloatParam( mvs, MVSConsts.AutoGainUpperLimit, " dB" );

            DigitalShift = new FloatParam( mvs, MVSConsts.DigitalShift );
            DigitalShiftEnable = new BoolParam( mvs, MVSConsts.DigitalShiftEnable );

            BlackLevel = new IntParam( mvs, MVSConsts.BlackLevel );
            BlackLevelEnable = new BoolParam( mvs, MVSConsts.BlackLevelEnable );

            Gamma = new FloatParam( mvs, MVSConsts.Gamma );
            //GammaSelector = new EnumParam( mvs, MVSConsts.GammaSelector );
            GammaEnable = new BoolParam( mvs, MVSConsts.GammaEnable );

            SharpnessEnable = new BoolParam( mvs, MVSConsts.SharpnessEnable );
            Sharpness = new IntParam( mvs, MVSConsts.Sharpness );

            AutoFunction = new AutoFunctionCtrls( mvs );
        }

        #endregion *************************************************************
    }
}
