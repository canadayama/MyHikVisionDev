namespace EB.Cameras.HikVision.Params
{
    /// <summary>
    /// 
    /// </summary>
    public interface IStringParam
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
        string Value { get; set; }

        /// <summary></summary>
        long MaxLength { get; }

        #endregion *************************************************************
    }
}
