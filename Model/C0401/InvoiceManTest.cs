using System.Globalization;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using Plusmore.Einvoice.Common.Sample.Helper;
using Plusmore.Utility.EscPos.Model.Birch;
using Plusmore.Utility.EscPos.Model.WinPos;

namespace Plusmore.Einvoice.Common.Sample.Model.C0401
{
    [TestClass]
    public partial class InvoiceManTest
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        //public static Wpt810Printer Prt = new Wpt810Printer( MyConfig.PrinterPortOfWpt810 );

        public static WinPosWpk650Printer Prt_Unsued = new WinPosWpk650Printer( MyConfig.PrinterPortOfWpk650 );

        public static BirchBpt3bPrinter Prt = new BirchBpt3bPrinter( MyConfig.PrinterPortOfBirchBpt3b );

        #region ClassInitialize and Cleanup

        [ClassInitialize]
        public static void InvoiceManTest_ClassInit( TestContext testContext )
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
                
            Prt.Open();
        }

        [ClassCleanup]
        public static void InvoiceManTest_ClassCleanup()
        {
            Prt.Close();
            Prt = null;
        }

        #endregion ClassInitialize and Cleanup

    }
}
