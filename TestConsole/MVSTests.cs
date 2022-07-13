using System;

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
        void MVSHelperTest()
        {
            Console.WriteLine( MVSHelper.GetSDKVersion() );
        }
    }
}
