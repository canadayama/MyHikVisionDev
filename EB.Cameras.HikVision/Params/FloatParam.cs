using EB.Cameras.HikVision.Settings;
using EB.Cameras.HikVision.Extensions.ParameterSettings;

namespace EB.Cameras.HikVision.Params
{
    /// <summary>
    /// 
    /// </summary>
    class FloatParam : MVSParam, IFloatParam, IFloatParamRO
    {
        #region ************************* Properties ************************** 

        /// <summary>Float value property.</summary>
        public float FValue
        {
            get => Mvs.GetFloat( StrKey );

            set => Mvs.SetFloat( StrKey, value );
        }

        /// <summary></summary>
        public float Maximum => Mvs.GetFloat( StrKey, ParamDet.Maximum );

        /// <summary></summary>
        public float Minumum => Mvs.GetFloat( StrKey, ParamDet.Minimum );

        #endregion ************************************************************

        #region ************************* Constructor *************************

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey"></param>
        /// <param name="units"></param>
        public FloatParam( MVS mvs, string strKey, string units = null )
                                                    : base( mvs, strKey, units )
        { }

        #endregion *************************************************************

        #region *********************** Instance Methods ***********************

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if ( IsAvailable )
            {
                return string.Format( "{0} {1}{2} {3}",
                                        base.ToString(),
                                            FValue,
                                                Units,
                                                    FormatAccessModeString() );
            }

            return string.Format( "{0} not available!", StrKey );
        }

        #endregion *************************************************************
    }
}
