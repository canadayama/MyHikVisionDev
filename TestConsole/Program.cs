using System;

namespace TestConsole
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        internal static void Pause()
        {
            Console.WriteLine( "Press Enter to Continue..." );
            Console.ReadLine();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main( string[] args )
        {
            try
            {
                ITest tst = new MVSTests();

                tst.Run();
            }
            catch ( Exception ex )
            {
                Console.WriteLine( ">>>Unhandled例外: " + ex.ToString() );
            }

            Pause();
        }
    }
}
