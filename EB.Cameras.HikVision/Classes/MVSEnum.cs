namespace EB.Cameras.HikVision.Classes
{
    /// <summary>
    /// MVS Enumeration Value.
    /// </summary>
    public class MVSEnum
    {
        #region ******************** Static(Class) Methods *********************

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvsEnum"></param>
        public static implicit operator uint( MVSEnum mvsEnum )
        {
            return mvsEnum.EValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvsEnum"></param>
        public static implicit operator string( MVSEnum mvsEnum )
        {
            return mvsEnum.EStr;
        }

        #endregion *************************************************************

        #region ************************** Properties **************************

        /// <summary>Enum Value</summary>
        public uint EValue { get; }

        /// <summary></summary>
        public string EStr { get; }

        #endregion *************************************************************

        #region ************************* Constructor **************************

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eValue"></param>
        /// <param name="eStr"></param>
        public MVSEnum( uint eValue, string eStr )
        {
            this.EValue = eValue;
            this.EStr = eStr;
        }

        #endregion *************************************************************

        #region *********************** Instance Methods ***********************

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return EStr;
        }

        #endregion *************************************************************
    }
}
