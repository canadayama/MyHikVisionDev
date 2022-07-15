namespace EB.Cameras.HikVision.Params
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICommandParam
    {
        #region ************************** Properties **************************

        #region ========================= Access　Mode =========================

        /// <summary></summary>
        bool IsAvailable { get; }

        /// <summary></summary>
        bool IsReadable { get; }

        /// <summary></summary>
        bool IsWriteable { get; }

        #endregion =============================================================

        /// <summary></summary>
        string Name { get; }

        #endregion *************************************************************

        #region *********************** Instance Methods ***********************

        /// <summary>
        /// 
        /// </summary>
        bool Execute();

        #endregion *************************************************************
    }
}
