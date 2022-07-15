using System;

namespace EB.Cameras.HikVision.Params
{
    class FloatParam : MVSParam, IFloatParam, IFloatParamRO
    {
        #region ************************* Properties ************************** 

        /// <summary></summary>
        public float Value
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
        public FloatParam( MVS mvs, string strKey ) : base( mvs, strKey )
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
