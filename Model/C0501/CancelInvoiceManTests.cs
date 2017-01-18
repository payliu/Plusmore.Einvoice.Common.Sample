// File: Plusmore.Einvoice.Common.Tests / CancelInvoiceManTests.cs
// 
// Created: 2016-12-31 15:56
// Modified: 2016-12-31 19:44

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using Plusmore.Einvoice.Common.Model.C0501;

namespace Plusmore.Einvoice.Common.Sample.Model.C0501
{
    [TestClass]
    public class CancelInvoiceManTests
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly string _path = Environment.GetFolderPath( Environment.SpecialFolder.Desktop );

        [TestMethod]
        public void CancelInvoiceManTests_toJson()
        {
            var cim = new CancelInvoiceMan
            {
                InvoiceNumber = "TW00000004",
                InvoiceDate = new DateTime( 2016, 11, 3, 0, 1, 1 ),
                BuyerId = "12345678",
                CancelDate = DateTime.Now,
                CancelReason = "開立錯誤"
            };

            Logger.Debug( "CancelInvoiceMan.json: {0}", cim.ToJson() );

            cim.Save( String.Format( @"{0}\delme\C0501\C0501-{1}.json", this._path, cim.InvoiceNumber ) );
        }
    }
}