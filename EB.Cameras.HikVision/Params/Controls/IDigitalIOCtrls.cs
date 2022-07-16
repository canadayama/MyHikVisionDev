namespace EB.Cameras.HikVision.Params.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDigitalIOCtrls
    {
        ///// <summary></summary>
        //IEnumParam LineSelector { get; }

        ///// <summary></summary>
        //IEnumParam LineMode { get; }

        /// <summary></summary>
        IBoolParam LineInverter { get; }

        /// <summary></summary>
        IBoolParam LineStatus { get; }

        /// <summary></summary>
        IIntParam LineStatusAll { get; }

        ///// <summary></summary>
        //IEnumParam LineSource { get; }

        /// <summary></summary>
        IBoolParam StrobeEnable { get; }

        /// <summary></summary>
        IIntParam StrobeLineDuration { get; }

        /// <summary></summary>
        IIntParam StrobeLineDelay { get; }

        /// <summary></summary>
        IIntParam StrobeLinePreDelay { get; }

        /// <summary></summary>
        IIntParam LineDebouncerTime { get; }
    }
}
