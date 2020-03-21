// File: Plusmore.Utility.EscPos.Tests.UnitTest / Wpt810InvoiceTests.cs
// 
// Author: Pay
// Created: 2017-01-06 14:48
// 
// Modified: 2017-01-07 12:41

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using Plusmore.Einvoice.Common.Sample.Helper;
using Plusmore.Utility.EscPos.Controller;
using Plusmore.Utility.EscPos.Controller.Base;
using Plusmore.Utility.EscPos.Domain;
using Plusmore.Utility.EscPos.Model.WinPos;

namespace Plusmore.Einvoice.Common.Sample.Printer
{
    [TestClass]
    public class Wpt810InvoiceTests
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        #region Printer

        private static Wpt810Printer _printer;

        public static Wpt810Printer Printer
        {
            get
            {
                if ( _printer != null )
                {
                    return _printer;
                }

                _printer = new Wpt810Printer( MyConfig.PrinterPortOfWpt810 )
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
        public void Wpt810InvoiceTests_Test()
        {
        }

        [TestMethod]
        public void Wpt810InvoiceTests_PrintHelloWorld()
        {
            Printer.InitializePrinter();

            Printer.PrintHelloWorld();

            Printer.CutPaper( full: true );
        }

        [TestMethod]
        public void Wpt810InvoiceTests_DetectPrinterStatus()
        {
            PrinterStatus printerStatus = Printer.DetectPrinterStatus();

            var s = String.Format( "printerStatus.IsUnknown:{0}\n" +
                                   "printerStatus.offline:{1}\n",
                                   printerStatus.IsUnknown,
                                   printerStatus.Offline );

            Logger.Debug( s );

            if ( printerStatus.IsUnknown == true )
            {
                Logger.Warn( "無回應, 未知原因, 稍後再試, 或 進行檢查" );
            }
            else if ( printerStatus.Offline == true )
            {
                Logger.Warn( "離線狀態, 請進行檢查" );
            }
            else
            {
                // IsUnknown = false, offline = false 
                Logger.Info( "online, 正常" );
            }
        }

        [TestMethod]
        public void Wpt810InvoiceTests_DetectPaperStatus()
        {
            PaperStatus paperStatus = Printer.DetectPaperStatus();

            var s = String.Format( "paperStatus.IsUnknown:{0}\n" +
                                   "paperStatus.IsEnd:{1}\n" +
                                   "paperStatus.IsNearEnd:{2}\n",
                                   paperStatus.IsUnknown,
                                   paperStatus.IsEnd,
                                   paperStatus.IsNearEnd );

            Logger.Debug( s );

            if ( paperStatus.IsUnknown == true )
            {
                Logger.Warn( "無回應, 未知原因, 稍後再試, 或 進行檢查" );
            }
            else if ( paperStatus.IsEnd == false )
            {
                if ( paperStatus.IsNearEnd == false )
                {
                    // IsEnd = false, IsNearEnd = false 
                    Logger.Info( "紙卷, 正常" );
                }
                else
                {
                    // IsEnd = false, IsNearEnd = true 
                    Logger.Warn( "快沒有紙, 請進行更換" );
                }
            }
            else
            {
                // IsEnd = true, IsNearEnd = true or false 
                Logger.Warn( "紙卷用完, 紙卷沒有安裝好 或 沒有安裝紙卷, 請進行檢查" );
            }
        }
    }
}