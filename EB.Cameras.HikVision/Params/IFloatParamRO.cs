namespace EB.Cameras.HikVision.Params
{
    /// <summary>
    /// 
    /// </summary>
    public interface IFloatParamRO
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
        float FValue { get; }

        /// <summary></summary>
        float Maximum { get; }

        /// <summary></summary>
        float Minumum { get; }

        #endregion *************************************************************
    }
}
