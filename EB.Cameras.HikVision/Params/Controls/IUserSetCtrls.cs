namespace EB.Cameras.HikVision.Params.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserSetCtrls
    {
        #region ************************** Properties **************************

        /// <summary></summary>
        IIntParamRO Current { get; }

        ///// <summary></summary>
        //IEnumParam Selector { get; }

        /// <summary></summary>
        ICommandParam Load { get; }

        /// <summary></summary>
        ICommandParam Save { get; }

        ///// <summary></summary>
        //IEnumParam Default { get; }

        #endregion *************************************************************

    }
}
