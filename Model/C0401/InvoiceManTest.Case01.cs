using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plusmore.Einvoice.Common.Helper;
using Plusmore.Einvoice.Common.Model.C0401;
using Plusmore.Einvoice.Common.Model.General;
using Plusmore.Einvoice.Common.Sample.Helper;

namespace Plusmore.Einvoice.Common.Sample.Model.C0401
{
    partial class InvoiceManTest
    {
        public InvoiceMan Sample1InvoiceMan
        {
            get
            {
                return new InvoiceMan
                {
                    Main = new InvoiceMan.InvMain
                    {
                        InvoiceNumber = "TW12345678",
                        InvoiceDate = new DateTime( 2016, 11, 4, 0, 24, 58 ),

                        Seller = new InvRole
                        {
                            Identifier = "24592118",
                            Name = "多多資訊有限公司"
                        },

                        PrintMark = YnEnum.Y,
                        RandomNumber = RandomNumberHelper.RandomNumber(),
                        RelateNumber = "Order-12345"  //訂單編號, 列印明細用, 可以省略
                    },

                    Detail = new InvoiceMan.InvDetail
                    {
                        ProductItems = new List<InvoiceMan.InvDetail.ProductItem>
                    {
                        new InvoiceMan.InvDetail.ProductItem
                        {
                              SequenceNumber = "001",
                              RelateNumber = "NX-200021", //產品編號, 列印明細用, 可以省略
                              Description = "王子麵",
                              UnitPrice = 10,
                              Quantity = 10,
                              Amount = 100
                        },
                        new InvoiceMan.InvDetail.ProductItem
                        {
                              SequenceNumber = "002",
                              RelateNumber = "NT-300001",  //產品編號, 列印明細用, 可以省略
                              Description = "可樂果",
                              UnitPrice = 20,
                              Quantity = 10,
                              Amount = 200
                        }
                    }
                    },

                    Amount = new InvoiceMan.InvAmount
                    {
                        SalesAmount = 300,
                        TotalAmount = 300
                    }
                };
            }
        }

        /// <summary>
        ///     一般消費者 
        /// </summary>
        [TestMethod]
        public void InvoiceManTest_Case01_general_buyer()
        {
            var im = this.Sample1InvoiceMan;

            im.Main.InvoiceNumber = "TW00000001";

            // 正式上線, 可以不用驗證 假如需要驗證, 有驗證異常的發票, 要進行異常處理程序 
            var v = im.Validate();

            if ( v.IsValid == false )
            {
                Logger.Debug( v.ToString() );
            }

            Assert.IsTrue( v.IsValid );

            // 得到 上傳的 json data 
            Logger.Debug( im.ToJson() );

            // 儲存 上傳的檔案 
            im.Save( String.Format( @"{0}\C0401\C0401-{1}.json", MyConfig.Folder, im.Main.InvoiceNumber ) );

            // hasPrintList=true: 消費者要求列印明細 reprint=true: 消費者因為發票破損無法辨識 qrcode, barcode...再列印一張"補印字樣"的發票, 需要記錄 補印 最好限印一次 
            im.Print( Prt, MyConfig.AesKey, hasPrintList: false, reprint: false );
        }

        /// <summary>
        ///     打統編 
        /// </summary>
        [TestMethod]
        public void InvoiceManTest_Case01_vat_buyer()
        {
            var im = this.Sample1InvoiceMan;

            im.Main.InvoiceNumber = "TW00000002";

            im.Main.Buyer = new InvRole()
            {
                Identifier = "12345678",
                Name = "福氣有限公司"  //非必填
            };

            // 打統編發票, 需要拆算 SalesAmount and TaxAmount 
            im.Amount.SalesAmount = 286;
            im.Amount.TaxAmount = 14;

            // 正式上線, 可以不用驗證 假如需要驗證, 有驗證異常的發票, 要進行異常處理程序 
            var v = im.Validate();

            if ( v.IsValid == false )
            {
                Logger.Debug( v.ToString() );
            }

            Assert.IsTrue( v.IsValid );

            // 得到 上傳的 json data 
            Logger.Debug( im.ToJson() );

            // 儲存 上傳的檔案 
            im.Save( String.Format( @"{0}\C0401\C0401-{1}.json", MyConfig.Folder, im.Main.InvoiceNumber ) );

            // 打統編的發票, 一律列印明細, 可以列印多次 不會有補印字樣, 
            im.Print( Prt, MyConfig.AesKey );
        }
    }
}