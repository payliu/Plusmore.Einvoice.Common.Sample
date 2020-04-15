using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using Plusmore.Einvoice.Common.Sample.Helper;
using Plusmore.Utility.EscPos.Controller.Base;
using Plusmore.Utility.EscPos.Model.Birch;

namespace Plusmore.Einvoice.Common.Sample.Printer
{
    [TestClass]
    public class BirchBpt3bPrinterTest
    {
         private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        #region Printer

        private static BirchBpt3bPrinter _printer;

        public static BirchBpt3bPrinter Printer
        {
            get
            {
                if ( _printer != null )
                {
                    return _printer;
                }

                _printer = new BirchBpt3bPrinter( MyConfig.PrinterPortOfBirchBpt3b )
                {
                    LogoHeight = 66
                };

                _printer.DeviceError += DeviceErrorEvent;
                _printer.DeviceOpened += DeviceOpenedEvent;
                _printer.DeviceClosed += DeviceClosedEvent;

                return _printer;
            }
            set { _printer = value; }
        }

        private static void DeviceErrorEvent( object o, MessageEventArgs e )
        {
            Logger.Error( e.Message );
        }

        private static void DeviceOpenedEvent( object o, EventArgs e )
        {
            Logger.Debug( "COM opened" );
        }

        private static void DeviceClosedEvent( object o, EventArgs e )
        {
            Logger.Debug( "COM closed" );
        }

        #endregion Printer

        #region ClassInitialize and Cleanup

        [ClassInitialize]
        public static void PrinterBasicTests_init( TestContext testContext )
        {
            Printer.Open();
        }

        [ClassCleanup]
        public static void PrinterBaseTest_DesInit()
        {
            Printer.Close();
            Printer = null;
        }

        #endregion ClassInitialize and Cleanup


        [TestMethod]
        public void BirchBpt3bPrinterTests_PrintHelloWorld()
        {
            Printer.InitializePrinter();

            Printer.PrintHelloWorld();

            Printer.CutPaper( full: true );
        }

    }
}
