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

                cam.Stop();

                Console.WriteLine( cam.ToString() );
            }
        }
    }
}
