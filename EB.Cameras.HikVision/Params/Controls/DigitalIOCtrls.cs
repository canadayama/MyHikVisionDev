using EB.Cameras.HikVision.Settings;

namespace EB.Cameras.HikVision.Params.Controls
{
    /// <summary>
    /// 
    /// </summary>
    class DigitalIOCtrls : IDigitalIOCtrls
    {
        #region ************************** Properties **************************

        ///// <summary></summary>
        //public IEnumParam LineSelector { get; }

        ///// <summary></summary>
        //public IEnumParam LineMode { get; }

        /// <summary></summary>
        public IBoolParam LineInverter { get; }

        /// <summary></summary>
        public IBoolParam LineStatus { get; }

        /// <summary></summary>
        public IIntParam LineStatusAll { get; }

        ///// <summary></summary>
        //public IEnumParam LineSource { get; }

        /// <summary></summary>
        public IIntParam LineDebouncerTime { get; }

        /// <summary></summary>
        public IBoolParam StrobeEnable { get; }

        /// <summary></summary>
        public IIntParam StrobeLineDuration { get; }
        
        /// <summary></summary>
        public IIntParam StrobeLineDelay { get; }
        
        /// <summary></summary>
        public IIntParam StrobeLinePreDelay { get; }

        #endregion *************************************************************

        #region ************************* Constructor **************************

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        public DigitalIOCtrls( MVS mvs )
        {
            //LineSelector = new EnumParam( mvs, MVSConsts.LineSelector );
            //LineMode = new EnumParam( mvs, MVSConsts.LineMode );
            LineInverter = new BoolParam( mvs, MVSConsts.LineInverter );
            LineStatus = new BoolParam( mvs, MVSConsts.LineStatus );
            LineStatusAll = new IntParam( mvs, MVSConsts.LineStatusAll );
            //LineSource = new EnumParam( mvs, MVSConsts.LineSource );
            LineDebouncerTime = new IntParam( mvs, MVSConsts.LineDebouncerTime, "μs" );

            StrobeEnable = new BoolParam( mvs, MVSConsts.StrobeEnable );
            StrobeLineDuration = new IntParam( mvs, MVSConsts.StrobeLineDuration, "μs" );
            StrobeLineDelay = new IntParam( mvs, MVSConsts.StrobeLineDelay, "μs" );
            StrobeLinePreDelay = new IntParam( mvs, MVSConsts.StrobeLinePreDelay, "μs" );
        }

        #endregion *************************************************************
    }
}
