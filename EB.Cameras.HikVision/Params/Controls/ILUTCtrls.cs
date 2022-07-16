namespace EB.Cameras.HikVision.Params.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILUTCtrls
    {
        #region ************************** Properties **************************

        ///// <summary></summary>
        //IEnumParam LUTSelector { get; }

        /// <summary></summary>
        IBoolParam LUTEnable { get; }

        /// <summary></summary>
        IIntParam LUTIndex { get; }

        /// <summary></summary>
        IIntParam LUTValue { get; }

        #endregion *************************************************************
    }
}
