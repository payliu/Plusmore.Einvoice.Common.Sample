// File: Plusmore.Einvoice.Common.Sample / AllowanceManTests.cs
// 
// Author: Pay
// Created: 2017-01-18 14:03
// 
// Modified: 2017-01-18 14:04

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using Plusmore.Einvoice.Common.Model.D0401;
using Plusmore.Einvoice.Common.Model.General;

namespace Plusmore.Einvoice.Common.Sample.Model.D0401
{
    [TestClass]
    public class AllowanceManTests
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly string _path = Environment.GetFolderPath( Environment.SpecialFolder.Desktop );

        [TestMethod]
        public void AllowanceManTests_ToJson()
        {
            var am = new AllowanceMan
            {
                Main = new AllowanceMan.AllowMain
                {
                    AllowanceNumber = "AN2016110300001",
                    AllowanceDate = new DateTime( 2016, 11, 4, 0, 24, 58, DateTimeKind.Local ),

                    Seller = new InvRole
                    {
                        Identifier = "24592118",
                        Name = "多多資訊有限公司"
                    },

                    Buyer = new InvRole
                    {
                        Identifier = "12345678",
                        Name = "福氣有限公司"
                    }
                },

                Amount = new AllowanceMan.AllowAmount
                {
                    TaxAmount = 14,
                    TotalAmount = 300
                },

                Detail = new AllowanceMan.AllowDetail
                {
                    ProductItems = new List<AllowanceMan.AllowDetail.ProductItem>
                    {
                        new AllowanceMan.AllowDetail.ProductItem
                        {
                            AllowanceSequenceNumber = "001",
                            OriginalInvoiceNumber = "TW00000002",
                            OriginalInvoiceDate = new DateTime( 2016, 11, 1, 0, 1, 2 ),
                            OriginalSequenceNumber = "001",
                            OriginalDescription = "王子麵",
                            UnitPrice = 10,
                            Quantity = 10,
                            Amount = 100,
                            TaxAmount = 5,
                            TaxType = TaxTypeEnum.TaxableSpecialTax
                        },
                        new AllowanceMan.AllowDetail.ProductItem
                        {
                            AllowanceSequenceNumber = "002",
                            OriginalInvoiceNumber = "TW00000002",
                            OriginalInvoiceDate = new DateTime( 2016, 11, 1, 0, 1, 2 ),
                            OriginalSequenceNumber = "002",
                            OriginalDescription = "可樂果",
                            UnitPrice = 20,
                            Quantity = 10,
                            Amount = 200,
                            TaxAmount = 10
                        },
                    }
                }
            };

            Logger.Debug( "AllowanceMan.json: {0}", am.ToJson() );

            am.Save( String.Format( @"{0}\D0401\D0401-{1}.json", this._path, am.Main.AllowanceNumber ) );
        }
    }
}