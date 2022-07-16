using EB.Cameras.HikVision.Settings;

namespace EB.Cameras.HikVision.Params.Controls
{
    /// <summary>
    /// 
    /// </summary>
    class ImageFormatCtrls : IImageFormatCtrls
    {
        #region ************************** Properties **************************

        /// <summary></summary>
        public IIntParamRO WidthMax { get; }

        /// <summary></summary>
        public IIntParamRO HeightMax { get; }

        ///// <summary></summary>
        //public IEnumParam RegionSelector { get; }

        ///// <summary></summary>
        //public IEnumParam RegionDestination { get; }

        /// <summary></summary>
        public IIntParam Width { get; }

        /// <summary></summary>
        public IIntParam Height { get; }

        /// <summary></summary>
        public IIntParam OffsetX { get; }

        /// <summary></summary>
        public IIntParam OffsetY { get; }

        /// <summary></summary>
        public IBoolParam ReverseX { get; }

        /// <summary></summary>
        public IBoolParam ReverseY { get; }

        ///// <summary></summary>
        //public IEnumParam PixelFormat { get; }

        ///// <summary></summary>
        //public IEnumParamRO PixelSize { get; }

        ///// <summary></summary>
        //public IEnumParam TestPatternGenerator { get; }

        ///// <summary></summary>
        //public IEnumParamRO TestPattern { get; }

        ///// <summary></summary>
        //public IEnumParam BinningSelector { get; }

        ///// <summary></summary>
        //public IEnumParam BinningHorizontal { get; }

        ///// <summary></summary>
        //public IEnumParam BinningVertical { get; }

        ///// <summary></summary>
        //public IEnumParam DecimationHorizontal { get; }

        ///// <summary></summary>
        //public IEnumParam DecimationVertical { get; }

        ///// <summary></summary>
        //public IEnumParam EmbeddedImageInfoSelector { get; }

        ///// <summary></summary>
        //public IBoolParam FrameSpecInfo { get; }

        #endregion *************************************************************

        #region ************************* Constructor **************************

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        public ImageFormatCtrls( MVS mvs )
        {
            WidthMax = new IntParam( mvs, MVSConsts.WidthMax );
            HeightMax = new IntParam( mvs, MVSConsts.HeightMax );

            //RegionSelector = ;
            //RegionDestination = ;

            Width = new IntParam( mvs, MVSConsts.Width );
            Height = new IntParam( mvs, MVSConsts.Height );

            OffsetX = new IntParam( mvs, MVSConsts.OffsetX );
            OffsetY = new IntParam( mvs, MVSConsts.OffsetY );
            
            ReverseX = new BoolParam( mvs, MVSConsts.ReverseX );
            ReverseY = new BoolParam( mvs, MVSConsts.ReverseY );

            //PixelFormat = ;
            //PixelSize = ;

            //TestPatternGenerator = ;
            //TestPattern = ;

            //BinningSelector = ;
            //BinningHorizontal = ;
            //BinningVertical = ;
            
            //DecimationHorizontal = ;
            //DecimationVertical = ;
            
            //EmbeddedImageInfoSelector = ;
            //FrameSpecInfo = ;
        }

        #endregion *************************************************************
    }
}
