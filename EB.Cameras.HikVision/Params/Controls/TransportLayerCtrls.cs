using EB.Cameras.HikVision.Settings;

namespace EB.Cameras.HikVision.Params.Controls
{
    /// <summary>
    /// 
    /// </summary>
    class TransportLayerCtrls : ITransportLayerCtrls
    {
        #region ************************** Properties **************************

        /// <summary></summary>
        public IIntParamRO PayloadSize { get; }

        #endregion *************************************************************

        #region ************************* Constructor **************************

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        public TransportLayerCtrls( MVS mvs )
        {
            PayloadSize = new IntParam( mvs, MVSConsts.PayloadSize, " Bytes" );
        }

        #endregion *************************************************************
    }
}
