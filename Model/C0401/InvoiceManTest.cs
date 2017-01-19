using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using Plusmore.Einvoice.Common.Sample.Helper;
using Plusmore.Utility.EscPos.Model.WinPos;

namespace Plusmore.Einvoice.Common.Sample.Model.C0401
{
    [TestClass]
    public partial class InvoiceManTest
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        
        public static Wpt810Printer Prt = new Wpt810Printer( MyConfig.PrinterPort );

        #region ClassInitialize and Cleanup

        [ClassInitialize]
        public static void InvoiceManTest_ClassInit( TestContext testContext )
        {
            Prt.Open();
            Prt.InitializePrinter();
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
