namespace EB.Cameras.HikVision.Params.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public interface IImageFormatCtrls
    {
        #region ************************** Properties **************************

        /// <summary></summary>
        IIntParamRO WidthMax { get; }

        /// <summary></summary>
        IIntParamRO HeightMax { get; }

        ///// <summary></summary>
        //IEnumParam RegionSelector { get; }

        ///// <summary></summary>
        //IEnumParam RegionDestination { get; }

        /// <summary></summary>
        IIntParam Width { get; }

        /// <summary></summary>
        IIntParam Height { get; }

        /// <summary></summary>
        IIntParam OffsetX { get; }

        /// <summary></summary>
        IIntParam OffsetY { get; }

        /// <summary></summary>
        IBoolParam ReverseX { get; }

        /// <summary></summary>
        IBoolParam ReverseY { get; }

        ///// <summary></summary>
        //IEnumParam PixelFormat { get; }

        ///// <summary></summary>
        //IEnumParamRO PixelSize { get; }

        ///// <summary></summary>
        //IEnumParam TestPatternGenerator { get; }

        ///// <summary></summary>
        //IEnumParamRO TestPattern { get; }

        ///// <summary></summary>
        //IEnumParam BinningSelector { get; }

        ///// <summary></summary>
        //IEnumParam BinningHorizontal { get; }

        ///// <summary></summary>
        //IEnumParam BinningVertical { get; }

        ///// <summary></summary>
        //IEnumParam DecimationHorizontal { get; }

        ///// <summary></summary>
        //IEnumParam DecimationVertical { get; }

        ///// <summary></summary>
        //IEnumParam EmbeddedImageInfoSelector { get; }
        
        ///// <summary></summary>
        //IBoolParam FrameSpecInfo { get; }

        #endregion *************************************************************

    }
}
