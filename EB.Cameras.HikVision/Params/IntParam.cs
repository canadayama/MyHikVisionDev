using EB.Cameras.HikVision.Settings;
using EB.Cameras.HikVision.Extensions.ParameterSettings;

namespace EB.Cameras.HikVision.Params
{
    /// <summary>
    /// 
    /// </summary>
    class IntParam : MVSParam, IIntParam, IIntParamRO
    {
        #region ************************* Properties ************************** 

        /// <summary></summary>
        public long Value
        {
            get => Mvs.GetInt( StrKey );

            set => Mvs.SetInt( StrKey, value );
        }

        /// <summary></summary>
        public long Increment => Mvs.GetInt( StrKey, ParamDet.Increment );

        /// <summary></summary>
        public long Maximum => Mvs.GetInt( StrKey, ParamDet.Maximum );

        /// <summary></summary>
        public long Minumum => Mvs.GetInt( StrKey, ParamDet.Minimum );

        #endregion ************************************************************

        #region ************************* Constructor *************************

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey"></param>
        public IntParam( MVS mvs, string strKey ) : base( mvs, strKey )
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
