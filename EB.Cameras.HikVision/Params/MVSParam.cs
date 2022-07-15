using EB.Cameras.HikVision.Extensions.CameraInternalAPIs;

using BE.Cameras;

using static MvCamCtrl.NET.MyCamera;

namespace EB.Cameras.HikVision.Params
{
    /// <summary>
    /// MVS base parameter.
    /// </summary>
    abstract class MVSParam
    {
        #region ************************** Inner Enum **************************
        /// <summary></summary>
        enum AccModeType { IsAvailable, IsReadable, IsWriteable }

        #endregion *************************************************************

        #region ********************** Instance Variables **********************

        /// <summary></summary>
        MV_XML_AccessMode m_xmlAccessMode = new MV_XML_AccessMode();

        #endregion *************************************************************

        #region ************************** Properties **************************

        #region ========================= Access　Mode =========================

        /// <summary></summary>
        public bool IsAvailable { get => GetAccessMode( AccModeType.IsAvailable ); }

        /// <summary></summary>
        public bool IsReadable { get => GetAccessMode( AccModeType.IsReadable ); }

        /// <summary></summary>
        public bool IsWriteable { get => GetAccessMode( AccModeType.IsWriteable ); }

        #endregion =============================================================

        /// <summary></summary>
        public string Name { get => StrKey; }

        #region ========================== Protected ===========================

        /// <summary></summary>
        protected MVS Mvs { get; }

        /// <summary></summary>
        protected string StrKey { get; }

        /// <summary></summary>
        protected MV_XML_AccessMode XmlAccessMode { get { return m_xmlAccessMode; } }

        #endregion =============================================================

        #endregion *************************************************************

        #region ************************* Constructor **************************

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mvs"></param>
        /// <param name="strKey"></param>
        public MVSParam( MVS mvs, string strKey )
        {
            this.Mvs = mvs;
            this.StrKey = strKey;
        }

        #endregion *************************************************************

        #region *********************** Instance Methods ***********************

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool GetAccessMode( AccModeType accModeType )
        {
            if ( Mvs.GetNodeAccessMode( StrKey, ref m_xmlAccessMode ) )
            {
                switch ( accModeType )
                {
                    case AccModeType.IsAvailable:
                        return ( XmlAccessMode == MV_XML_AccessMode.AM_RW )
                                || ( XmlAccessMode == MV_XML_AccessMode.AM_RO )
                                || ( XmlAccessMode == MV_XML_AccessMode.AM_WO );

                    case AccModeType.IsReadable:
                        return ( XmlAccessMode == MV_XML_AccessMode.AM_RW )
                                || ( XmlAccessMode == MV_XML_AccessMode.AM_RO );

                    case AccModeType.IsWriteable:
                        return ( XmlAccessMode == MV_XML_AccessMode.AM_RW )
                                || ( XmlAccessMode == MV_XML_AccessMode.AM_WO );

                    default:
                        Mvs.Notify( CamEvnt.GetErr, "Unknown accModeType " + accModeType );
                        return false;
                }
            }

            Mvs.Notify( CamEvnt.GetErr, Mvs.LastErrorMessage );
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string FormatAccessModeString()
        {
            return string.Format( "[A:{0}, R:{1}, W:{2}]",
                                    IsAvailable, IsReadable, IsWriteable );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format( "{0}({1}):", Name, GetType().Name );
        }

        #endregion *************************************************************
    }
}
