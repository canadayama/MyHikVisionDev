namespace EB.Cameras.HikVision.Settings
{
    /// <summary></summary>
    public enum MVSGrabStrategy : int
    {
        OneByOne = 0,
        LatestImagesOnly = 1,
        LatestImages = 2,
        UpcomingImage = 3
    }

    /// <summary></summary>
    public enum ImgCallBackType : int
    {
        Default,
        BGR,
        RGB
    }

    /// <summary>Parameter detail</summary>
    public enum ParamDet : int
    {
        Increment,
        Minimum,
        Maximum
    }
}
