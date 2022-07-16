using EB.Cameras.HikVision.Settings;

namespace EB.Cameras.HikVision.Params.Controls
{
    /// <summary>
    /// 
    /// </summary>
    class LUTCtrls : ILUTCtrls
    {
        #region ************************** Properties **************************

        ///// <summary></summary>
        //public IEnumParam LUTSelector { get; }

        /// <summary></summary>
        public IBoolParam LUTEnable { get; }

        /// <summary></summary>
        public IIntParam LUTIndex { get; }
        
        /// <summary></summary>
        public IIntParam LUTValue { get; }

        #endregion *************************************************************

        #region ************************* Constructor **************************

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        public LUTCtrls( MVS mvs )
        {
            //LUTSelector = new EnumParam( mvs, MVSConsts.LUTSelector );
            LUTEnable = new BoolParam( mvs, MVSConsts.LUTEnable );
            LUTIndex = new IntParam( mvs, MVSConsts.LUTIndex );
            LUTValue = new IntParam( mvs, MVSConsts.LUTValue );
        }

        #endregion *************************************************************
    }
}
