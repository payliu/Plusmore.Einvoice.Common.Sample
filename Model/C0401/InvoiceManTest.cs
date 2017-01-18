using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using Plusmore.Utility.EscPos.Model.WinPos;

namespace Plusmore.Einvoice.Common.Sample.Model.C0401
{
    [TestClass]
    public partial class InvoiceManTest
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public readonly string CompanyName = "多多資訊";
        public readonly string AsKey = "DB2085D96577312E83E4DA5E826075FF";
        private readonly string _path = Environment.GetFolderPath( Environment.SpecialFolder.Desktop );

        public static Wpt810Printer Prt = new Wpt810Printer( "COM4" );

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
