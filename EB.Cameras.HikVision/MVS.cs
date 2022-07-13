using System;

using BE.Cameras;

using MvCamCtrl.NET;
using static MvCamCtrl.NET.MyCamera;

namespace EB.Cameras.HikVision
{
    /// <summary>
    /// 
    /// </summary>
    public class MVS : IDisposable
    {
        #region ********************** Instance Variables **********************

        /// <summary></summary>
        public event EventHandler<CamEventArgs> OnCamEvent;

        int m_index;
        bool m_isOpen = false;
        bool m_isGrabbing = false;
        string m_camName = string.Empty;

        #endregion *************************************************************

        #region ************************** Properties **************************

        /// <summary>Index number; used if part of an array and assigned on initialization.</summary>
        public int Index { get { return m_index; } }

        /// <summary></summary>
        public bool IsOpen { get { return IsSet && m_isOpen; } }

        /// <summary></summary>
        public bool IsGrabbing { get { return IsSet && m_isGrabbing; } }

        /// <summary></summary>
        public string CamName
        {
            get { return string.IsNullOrWhiteSpace( m_camName )
                                ? MVSHelper.GetCamName( Index ) : m_camName; }

            set { m_camName = value?.Trim(); }
        }

        /// <summary></summary>
        public ICamDevice CamDevice { get; private set; }

        /// <summary></summary>
        public string LastErrorMessage { get; protected internal set; }

        /// <summary></summary>
        protected bool IsSet { get { return ( Cam != null ); } }

        /// <summary>HikVision MVS camera.</summary>
        protected internal MyCamera Cam { get; private set; }

        #endregion *************************************************************

        #region ************************* Constructor **************************

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public MVS( int index = -1 )
        {
            m_index = index;
        }

        #endregion *************************************************************

        #region ************************* IDisposable **************************

        bool disposedValue;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose( bool disposing )
        {
            if ( !disposedValue )
            {
                if ( disposing )
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~MVS()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose( disposing: true );
            GC.SuppressFinalize( this );
        }

        /// <summary>
        /// Clean up on dispose;
        /// on override call as last method.
        /// </summary>
        protected virtual void CleanupOnDispose()
        {
            Close();
        }

        #endregion *************************************************************

        #region **************************** Events ****************************

        /// <summary>
        /// Called right before the device is created;
        /// override to preform preparations before creating camera.
        /// Note: Method placeholder no need to call base method.
        /// </summary>
        protected virtual void BeforeCreateDevice() { }

        /// <summary>
        /// Called after the device is created but before being opened;
        /// override to preform preparations before opening camera.
        /// Note: Method placeholder no need to call base method.
        /// </summary>
        /// <param name="sender"></param>
        protected virtual void AfterCreateDevice() { }

        /// <summary>
        /// Called before device is destroyed;
        /// override to preform cleanup before device is destroyed.
        /// Note: Method placeholder; no need to call base method.
        /// </summary>
        protected virtual void BeforeDestroyDevice() { }

        /// <summary>
        /// Called after the device is destroyed;
        /// override to preform cleanup after device is destroyed.
        /// Note: Method placeholder; no need to call base method.
        /// </summary>
        protected virtual void AfterDestroyDevice() { }

        #endregion *************************************************************

        #region ===================== Camera Event Methods =====================

        /// <summary>
        /// Override to handle Camera opening;
        /// base calls Notify with CamEvnt.Opening.
        /// </summary>
        protected virtual void HandleCameraOpening()
        {
            Notify( CamEvnt.Opening );
        }

        /// <summary>
        /// Override to handle Camera opened;
        /// base calls Notify with CamEvnt.Opened.
        /// </summary>
        protected virtual void HandleCameraOpened()
        {
            Notify( CamEvnt.Opened );
        }

        /// <summary>
        /// Override to handle Camera closing;
        /// base calls Notify with CamEvnt.Closing.
        /// </summary>
        protected virtual void HandleCameraClosing()
        {
            Notify( CamEvnt.Closing );
        }

        /// <summary>
        /// Override to handle Camera closed;
        /// base calls Notify with CamEvnt.Closed.
        /// </summary>
        protected virtual void HandleCameraClosed()
        {
            Notify( CamEvnt.Closed );
        }

        #endregion =============================================================

        #region ====================== Grab Event Methods ======================

        #endregion =============================================================

        #region *********************** Instance Methods ***********************

        /// <summary>
        /// 
        /// </summary>
        /// <param name="camEvent"></param>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        protected internal void Notify( CamEvnt camEvent,
                                            string message = "",
                                                Exception ex = null )
        {
            if ( ex != null )
            {
                OnCamEvent?.Invoke( this, new CamEventArgs( ex, message) );
                return;
            }

            OnCamEvent?.Invoke( this, new CamEventArgs( camEvent, message ) );      
        }

        #region ========================= MVS Methods ==========================

        /// <summary>
        /// Destroys device instance and resources.
        /// </summary>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        void DestroyDevice()
        {
            if ( IsSet )
            {
                try
                {
                    int rslt = Cam.MV_CC_DestroyDevice_NET();
                    if ( rslt == MV_OK )
                    {
                        return;
                    }

                    // Should not happen but Notify if it does.
                    Notify( CamEvnt.ERROR, MVSHelper.FormatMVSErr( rslt ) );
                }
                finally
                {
                    Cam = null;
                }
            }
        }

        /// <summary>
        /// Open Cam(MyCamera) device; sets IsOpen to true on success.
        /// </summary>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        bool OpenDevice()
        {
            int rslt = Cam.MV_CC_OpenDevice_NET();
            if ( rslt == MV_OK )
            {
                m_isOpen = true;
                return true;
            }

            LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
            return false;
        }

        /// <summary>
        /// Close Cam(MyCamera) device.
        /// </summary>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        bool CloseDevice()
        {
            int rslt = Cam.MV_CC_CloseDevice_NET();
            if ( rslt == MV_OK )
            {
                m_isOpen = false;
                return true;
            }

            LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
            return false;
        }

        /// <summary>
        /// Get MV_CC_DEVICE_INFO from cam(MyCamera).
        /// </summary>
        /// <param name="pstDevInfo">Reference to MV_CC_DEVICE_INFO.</param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        protected bool GetDeviceInfo( ref MV_CC_DEVICE_INFO pstDevInfo )
        {
            if ( IsSet )
            {
                int rslt = Cam.MV_CC_GetDeviceInfo_NET( ref pstDevInfo );
                if ( rslt == MV_OK )
                {
                    return true;
                }

                LastErrorMessage = MVSHelper.FormatMVSErr( rslt );
                return false;
            }

            LastErrorMessage = "Cam NOT set!";
            return false;
        }

        #endregion =============================================================

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceName"></param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        protected bool Open( string deviceName = null )
        {
            ICamDevice camDevice = null; 

            if ( !string.IsNullOrWhiteSpace( deviceName) )
            {
                camDevice = MVSHelper.GetDevice( deviceName );
                if ( camDevice == null )
                {
                    LastErrorMessage = string.Format( "'{0}'が見つかりません。", deviceName );
                    return false;
                }
            }

            return Open( camDevice );
        }

        /// <summary>
        /// Open camera using ICamDevice.
        /// </summary>
        /// <param name="camDevice">
        /// ICamDevice to open;
        /// if null it will open first avaliable camera device.
        /// Note: to reset just feed CamDevice to this method.
        /// </param>
        /// <returns>true on success; false on fail w/ LastErrorMessage set.</returns>
        protected bool Open( ICamDevice camDevice )
        {
            // Close if already open.
            if ( IsOpen )
            {
                Close();
            }

            try
            {
                if ( camDevice == null )
                {
                    camDevice = MVSHelper.GetDevice();
                    if ( camDevice == null )
                    {
                        LastErrorMessage = "No Camera Devices!";
                        return false;
                    }
                }

                BeforeCreateDevice();
                
                Cam = MVSHelper.CreateDevice( camDevice );
                
                AfterCreateDevice();
                
                HandleCameraOpening();
                if ( OpenDevice() )
                {
                    CamDevice = camDevice;
                    HandleCameraOpened();
                    return true;
                }

                BeforeDestroyDevice();
                
                DestroyDevice();
                
                AfterDestroyDevice();
            }
            catch ( Exception ex )
            {
                LastErrorMessage = ex.Message;
            }

            return false;
        }
        
        /// <summary>
        /// Close the camera device;
        /// any errors encountered will be sent through OnCamEvent.
        /// </summary>
        protected void Close()
        {
            //  Is already closed do nothing.
            if ( !IsOpen )
            {
                return;
            }

            try
            {
                HandleCameraClosing();
                if ( CloseDevice() )
                {
                    return;
                }
                
                Notify( CamEvnt.CloseErr, LastErrorMessage );
            }
            finally
            {
                m_isOpen = false;
                HandleCameraClosed();
                
                BeforeDestroyDevice();
                
                DestroyDevice();
                
                AfterDestroyDevice();
            }
        }

        #endregion *************************************************************
    }
}
