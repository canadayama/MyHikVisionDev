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

        /// <summary></summary>
        public IAcquisitionCtrls Acquisition { get; }

        /// <summary></summary>
        public IAnalogCtrls Analog { get; }

        ///// <summary></summary>
        //public ColorTranformation { get; }

        /// <summary></summary>
        public ILUTCtrls LUT { get; }

        /// <summary></summary>
        public IDigitalIOCtrls DigitalIO { get; }

        ///// <summary></summary>
        //public IActionControl Action { get; }

        ///// <summary></summary>
        //public ICounterAndTimerCtrls CounterAndTimer { get; }
        
        ///// <summary></summary>
        //public IFileAccessCtrls FileAccess { get; }
        
        ///// <summary></summary>
        //public IEventCtrls Event { get; }
        
        ///// <summary></summary>
        //public IChunkDataCtrls ChunkData { get; }
        
        /// <summary></summary>
        public ITransportLayerCtrls TransportLayer { get; }

        /// <summary></summary>
        public IUserSetCtrls UserSet { get; }

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
            Acquisition = new AcquisitionCtrls( this );
            Analog = new AnalogCtrls( this );
            //ColorTranformation = ;
            LUT = new LUTCtrls( this );
            DigitalIO = new DigitalIOCtrls( this );
            //Action = ;
            //CounterAndTimer = ;
            //FileAccess = ;
            //EventChunkData = ;
            TransportLayer = new TransportLayerCtrls( this );
            UserSet = new UserSetCtrls( this );
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
