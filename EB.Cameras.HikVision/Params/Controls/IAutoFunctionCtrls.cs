namespace EB.Cameras.HikVision.Params.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAutoFunctionCtrls
    {
        #region ************************** Properties **************************

        ///// <summary></summary>
        //IEnumParam AutoFunctionAOISelector { get; }

        /// <summary></summary>
        IIntParam AOIWidth { get; }

        /// <summary></summary>
        IIntParam AOIHeight { get; }

        /// <summary></summary>
        IIntParam AOIOffsetX { get; }

        /// <summary></summary>
        IIntParam AOIOffsetY { get; }

        /// <summary></summary>
        IBoolParam AOIUsageIntensity { get; }

        /// <summary></summary>
        IBoolParam AOIUsageWhiteBalance { get; }

        #endregion *************************************************************
    }
}
