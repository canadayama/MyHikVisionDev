using System;

using BE.Cameras;
using EB.Cameras.HikVision;

namespace TestConsole
{
    /// <summary>
    /// 
    /// </summary>
    class MVSTests : ITest
    {
        /// <summary>
        /// 
        /// </summary>
        public MVSTests()
        { }

        /// <summary>
        /// 
        /// </summary>
        public void Run()
        {
            MVSHelperTest();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void HandleCamEvent( object sender, CamEventArgs args )
        {
            Console.WriteLine( args.ToString() );
        }

        /// <summary>
        /// 
        /// </summary>
        void MVSHelperTest()
        {
            Console.WriteLine( MVSHelper.GetSDKVersion() );

            using ( MVSCam cam = new MVSCam() { CamName = "TestCam" } )
            {
                cam.OnCamEvent += HandleCamEvent;

                Console.WriteLine( cam.ToString() );

                if ( cam.Start() )
                {
                    Console.WriteLine( cam.ToString() );

                    //DeviceControls( cam );
                    //ImageFormatControls( cam );
                    AcquisitionControls( cam );
                    AnalogControls( cam );
                    LUTControls( cam );
                    DigitalIOControls( cam );

                    TranportLayerControls( cam );
                    UserSetControls( cam );
                }

                cam.Stop();

                Console.WriteLine( cam.ToString() );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cam"></param>
        void DeviceControls( MVSCam cam )
        {
            Console.WriteLine( cam.Device.VendorName );
            Console.WriteLine( cam.Device.ModelName );
            Console.WriteLine( cam.Device.ManufacturerInfo );
            Console.WriteLine( cam.Device.Version );
            Console.WriteLine( cam.Device.FirmwareVersion );
            Console.WriteLine( cam.Device.SerialNumber );
            Console.WriteLine( cam.Device.ID );
            Console.WriteLine( cam.Device.UserID );
            Console.WriteLine( cam.Device.Reset );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cam"></param>
        void ImageFormatControls( MVSCam cam )
        {
            Console.WriteLine( cam.ImageFormat.WidthMax );
            Console.WriteLine( cam.ImageFormat.HeightMax );

            Console.WriteLine( cam.ImageFormat.Width );
            Console.WriteLine( cam.ImageFormat.Height );
            Console.WriteLine( cam.ImageFormat.OffsetX );
            Console.WriteLine( cam.ImageFormat.OffsetY );
            Console.WriteLine( cam.ImageFormat.ReverseX );
            Console.WriteLine( cam.ImageFormat.ReverseY );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cam"></param>
        void AcquisitionControls( MVSCam cam )
        {
            //Console.WriteLine( cam.Acquisition.AcquisitionMode );
            Console.WriteLine( cam.Acquisition.AcquisitionStop );
            Console.WriteLine( cam.Acquisition.AcquisitionBurstFrameCount );
            Console.WriteLine( cam.Acquisition.AcquisitionFrameRate );
            Console.WriteLine( cam.Acquisition.AcquisitionFrameRateEnable );
            Console.WriteLine( cam.Acquisition.ResultingFrameRate );

            //Console.WriteLine( cam.Acquisition.TriggerSelector );
            //Console.WriteLine( cam.Acquisition.TriggerMode );
            Console.WriteLine( cam.Acquisition.TriggerSoftware );
            //Console.WriteLine( cam.Acquisition.TriggerSource );
            Console.WriteLine( cam.Acquisition.TriggerDelay );
            Console.WriteLine( cam.Acquisition.TriggerCacheEnable );
            
            ///Console.WriteLine( cam.Acquisition.ExposureMode );
            Console.WriteLine( cam.Acquisition.ExposureTime );
            //Console.WriteLine( cam.Acquisition.ExposureAuto );
            Console.WriteLine( cam.Acquisition.AutoExposureTimeLowerLimit );
            Console.WriteLine( cam.Acquisition.AutoExposureTimeUpperLimit );
            Console.WriteLine( cam.Acquisition.HDREnable );
            Console.WriteLine( cam.Acquisition.HDRSelector );
            Console.WriteLine( cam.Acquisition.HDRShutter );
            Console.WriteLine( cam.Acquisition.HDRGain );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cam"></param>
        void AnalogControls( MVSCam cam )
        {
            Console.WriteLine( cam.Analog.Gain );
            //Console.WriteLine( cam.Analog.GainAuto );
            Console.WriteLine( cam.Analog.AutoGainLowerLimit );
            Console.WriteLine( cam.Analog.AutoGainUpperLimit );

            Console.WriteLine( cam.Analog.DigitalShift );
            Console.WriteLine( cam.Analog.DigitalShiftEnable );

            Console.WriteLine( cam.Analog.BlackLevel );
            Console.WriteLine( cam.Analog.BlackLevelEnable );

            Console.WriteLine( cam.Analog.Gamma );
            //Console.WriteLine( cam.Analog.GammaSelector );
            Console.WriteLine( cam.Analog.GammaEnable );

            Console.WriteLine( cam.Analog.SharpnessEnable );
            Console.WriteLine( cam.Analog.Sharpness );

            //Console.WriteLine( cam.Analog.AutoFunctionAOISelector );
            Console.WriteLine( cam.Analog.AutoFunction.AOIWidth );
            Console.WriteLine( cam.Analog.AutoFunction.AOIHeight );
            Console.WriteLine( cam.Analog.AutoFunction.AOIOffsetX );
            Console.WriteLine( cam.Analog.AutoFunction.AOIOffsetY );
            Console.WriteLine( cam.Analog.AutoFunction.AOIUsageIntensity );
            Console.WriteLine( cam.Analog.AutoFunction.AOIUsageWhiteBalance );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cam"></param>
        void LUTControls( MVSCam cam )
        {
            //Console.WriteLine( cam.LUT.LUTSelector );
            Console.WriteLine( cam.LUT.LUTEnable );
            Console.WriteLine( cam.LUT.LUTIndex );
            Console.WriteLine( cam.LUT.LUTValue );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cam"></param>
        void DigitalIOControls( MVSCam cam )
        {
            //Console.WriteLine( cam.DigitalIO.LineSelector );
            //Console.WriteLine( cam.DigitalIO.LineMode );
            Console.WriteLine( cam.DigitalIO.LineInverter );
            Console.WriteLine( cam.DigitalIO.LineStatus );
            Console.WriteLine( cam.DigitalIO.LineStatusAll );
            //Console.WriteLine( cam.DigitalIO.LineSource );
            Console.WriteLine( cam.DigitalIO.LineDebouncerTime );

            Console.WriteLine( cam.DigitalIO.StrobeEnable );
            Console.WriteLine( cam.DigitalIO.StrobeLineDuration );
            Console.WriteLine( cam.DigitalIO.StrobeLineDelay );
            Console.WriteLine( cam.DigitalIO.StrobeLinePreDelay );
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="cam"></param>
        void TranportLayerControls( MVSCam cam )
        {
            Console.WriteLine( cam.TransportLayer.PayloadSize );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cam"></param>
        void UserSetControls( MVSCam cam )
        {
            Console.WriteLine( cam.UserSet.Current );
            //Console.WriteLine( cam.UserSet.Selector );
            Console.WriteLine( cam.UserSet.Load );
            Console.WriteLine( cam.UserSet.Save );
            //Console.WriteLine( cam.UserSet.Default );
        }
    }
}
