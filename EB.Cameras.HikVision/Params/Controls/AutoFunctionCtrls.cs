using EB.Cameras.HikVision.Settings;

namespace EB.Cameras.HikVision.Params.Controls
{
    /// <summary>
    /// 
    /// </summary>
    class AutoFunctionCtrls : IAutoFunctionCtrls
    {
        #region ************************** Properties **************************

        ///// <summary></summary>
        //public IEnumParam AutoFunctionAOISelector { get; }

        /// <summary></summary>
        public IIntParam AOIWidth { get; }

        /// <summary></summary>
        public IIntParam AOIHeight { get; }

        /// <summary></summary>
        public IIntParam AOIOffsetX { get; }

        /// <summary></summary>
        public IIntParam AOIOffsetY { get; }

        /// <summary></summary>
        public IBoolParam AOIUsageIntensity { get; }

        /// <summary></summary>
        public IBoolParam AOIUsageWhiteBalance { get; }

        #endregion *************************************************************

        #region ************************* Constrcutor **************************

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        public AutoFunctionCtrls( MVS mvs )
        {
            //AOISelector = new EnumParam( mvs, MVSConsts.AutoFunctionAOISelector );
            AOIWidth = new IntParam( mvs, MVSConsts.AutoFunctionAOIWidth );
            AOIHeight = new IntParam( mvs, MVSConsts.AutoFunctionAOIHeight );
            AOIOffsetX = new IntParam( mvs, MVSConsts.AutoFunctionAOIOffsetX );
            AOIOffsetY = new IntParam( mvs, MVSConsts.AutoFunctionAOIOffsetY );
            AOIUsageIntensity = new BoolParam( mvs, MVSConsts.AutoFunctionAOIUsageIntensity );
            AOIUsageWhiteBalance = new BoolParam( mvs, MVSConsts.AutoFunctionAOIUsageWhiteBalance );
        }

        #endregion *************************************************************

    }
}
