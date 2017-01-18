﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using Plusmore.Einvoice.Common.Helper;
using Plusmore.Einvoice.Common.Model.General;

namespace Plusmore.Einvoice.Common.Sample.Model.C0401
{
    partial class InvoiceManTest
    {
        /// <summary>
        ///     消費者 持 自然人憑證
        ///     1. Print Mark = N
        ///     2. Carrier Type = CQ0001
        ///     3. CarrierId1 = 自然人憑證條碼
        /// </summary>
        [TestMethod]
        public void InvoiceManTest_Case07_CitizenDigitalCertificate()
        {
            var im = this.Sample1InvoiceMan;

            im.Main.InvoiceNumber = "TW00000009";

            //自然人憑證條碼
            const string code = "AB12345678901234";

            // 驗證 手機條碼 
            Assert.IsTrue( Validator.CitizenDigitalCertificate( code ) );

            im.Main.PrintMark = YnEnum.N;
            im.Main.CarrierType = "CQ0001";
            im.Main.CarrierId1 = code;

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
            im.Save( String.Format( @"{0}\delme\C0401\C0401-{1}.json", this._path, im.Main.InvoiceNumber ) );

            // PrintMark = N, 無法列印 
            im.Print( Prt, this.AsKey, hasPrintList: false, reprint: false );

            // 可選擇列印明細 
            im.PrintList( Prt );
        }
    }
}