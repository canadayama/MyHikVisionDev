namespace EB.Cameras.HikVision.Params
{
    /// <summary>
    /// 
    /// </summary>
    public interface IIntParam
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

        /// <summary></summary>
        long Value { get; set; }

        /// <summary></summary>
        long Increment { get; }

        /// <summary></summary>
        long Maximum { get; }

        /// <summary></summary>
        long Minumum { get; }

        #endregion *************************************************************

        #region *********************** Instance Methods ***********************

        #endregion *************************************************************
    }
}
