﻿// File: Plusmore.Einvoice.Common.Tests / CancelAllowanceManTests.cs
// 
// Author: Pay
// Created: 2016-12-31 20:03
// 
// Modified: 2017-01-17 13:23

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using Plusmore.Einvoice.Common.Model.D0501;
using Plusmore.Einvoice.Common.Sample.Helper;

namespace Plusmore.Einvoice.Common.Tests.Model.D0501
{
    [TestClass]
    public class CancelAllowanceManTests
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();


        [TestMethod]
        public void CancelAllowanceManTests_toJson()
        {
            var cam = new CancelAllowanceMan
            {
                AllowanceNumber = "AN2016110300001",
                AllowanceDate = new DateTime( 2016, 11, 3, 0, 1, 1 ),
                BuyerId = "12345678",
                CancelDate = DateTime.Now,
                CancelReason = "開立錯誤"
            };

            Logger.Debug( "CancelAllowanceMan.json: {0}", cam.ToJson() );

            cam.Save( String.Format( @"{0}\D0501\D0501-{1}.json", MyConfig.Folder, cam.AllowanceNumber ) );
        }
    }
}