namespace EB.Cameras.HikVision.Params.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAnalogCtrls
    {
        #region ************************** Properties **************************

        /// <summary></summary>
        IFloatParam Gain { get; }

        ///// <summary></summary>
        //IEnumParam GainAuto { get; }

        /// <summary></summary>
        IFloatParam AutoGainLowerLimit { get; }

        /// <summary></summary>
        IFloatParam AutoGainUpperLimit { get; }

        /// <summary></summary>
        IFloatParam DigitalShift { get; }

        /// <summary></summary>
        IBoolParam DigitalShiftEnable { get; }

        /// <summary></summary>
        IIntParam BlackLevel { get; }

        /// <summary></summary>
        IBoolParam BlackLevelEnable { get; }

        /// <summary></summary>
        IFloatParam Gamma { get; }

        ///// <summary></summary>
        //IEnumParam GammaSelector { get; }

        /// <summary></summary>
        IBoolParam GammaEnable { get; }

        /// <summary></summary>
        IBoolParam SharpnessEnable { get; }

        /// <summary></summary>
        IIntParam Sharpness { get; }

        /// <summary></summary>
        IAutoFunctionCtrls AutoFunction { get; }
        
        #endregion *************************************************************
    }
}
