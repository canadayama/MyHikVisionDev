using EB.Cameras.HikVision.Extensions.ParameterSettings;

namespace EB.Cameras.HikVision.Params
{
    /// <summary>
    /// 
    /// </summary>
    class StringParam : MVSParam, IStringParam, IStringParamRO
    {
        #region ************************** Properties **************************

        /// <summary>String value property.</summary>
        public string SValue
        {
            get => Mvs.GetString( StrKey );

            set => Mvs.SetString( StrKey, value );
        }

        /// <summary></summary>
        public long MaxLength => Mvs.GetStringMaxLength( StrKey );

        #endregion *************************************************************

        #region ************************* Constructor **************************

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey"></param>
        public StringParam( MVS mvs, string strKey ) : base( mvs, strKey )
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
                                        SValue,
                                            FormatAccessModeString() );
        }

        #endregion *************************************************************
    }
}
