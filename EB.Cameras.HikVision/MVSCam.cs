using System;

using EB.Cameras.HikVision.Params.Controls;

namespace EB.Cameras.HikVision
{
    /// <summary>
    /// 
    /// </summary>
    public class MVSCam : MVS
    {
        #region ************************** Properties **************************

        /// <summary></summary>
        public IDeviceCtrls Device { get; }

        /// <summary></summary>
        public IImageFormatCtrls ImageFormat { get; }

        #endregion *************************************************************

        #region ************************* Constructor **************************

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public MVSCam( int index = -1 ) : base( index )
        {
            Device = new DeviceCtrls( this );
            ImageFormat = new ImageFormatCtrls( this );
        }

        #endregion *************************************************************

        #region *********************** Instance Methods ***********************

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Start()
        {
            return Open();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Stop()
        {
            try
            {
                Close();
                return true;
            }
            catch ( Exception ex )
            {
                LastErrorMessage = ex.Message;
            }

            return false;
        }

        #endregion *************************************************************
    }
}
