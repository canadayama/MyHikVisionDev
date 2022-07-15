using EB.Cameras.HikVision.Extensions.ParameterSettings;

namespace EB.Cameras.HikVision.Params
{
    /// <summary>
    /// 
    /// </summary>
    class BoolParam : MVSParam, IBoolParam, IBoolParamRO
    {
        #region ************************** Properties **************************

        /// <summary></summary>
        public bool Value
        {
            get => Mvs.GetBool( StrKey );

            set => Mvs.SetBool( StrKey, value );
        }

        #endregion *************************************************************

        #region ************************* Constructor **************************

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey"></param>
        public BoolParam( MVS mvs, string strKey ) : base( mvs, strKey )
        { }

        #endregion *************************************************************

        #region *********************** Instance Methods ***********************

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format( "{0} {1} {2}",
                                    base.ToString(),
                                        Value,
                                            FormatAccessModeString() );
        }

        #endregion *************************************************************
    }
}
