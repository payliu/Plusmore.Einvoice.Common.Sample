// File: Plusmore.Einvoice.Common.Sample / MyConfig.cs
// 
// Author: Pay
// Created: 2017-01-19 12:11
// 
// Modified: 2017-01-19 14:27

using System;

namespace Plusmore.Einvoice.Common.Sample.Helper
{
    public class MyConfig
    {
        public static string PrinterPortOfWpt810 = "COM4";
        public static string PrinterPortOfWpk650 = "COM6";
        public static string PrinterPortOfBirchBpt3b = "COM9";
        public static string CompanyName = "多多資訊"; // 發票 title 用
        public static string AesKey = "D6E2543010DE06ED9B42734016A02890";  
        public static string Folder  = String.Format( @"{0}\delme", Environment.GetFolderPath( Environment.SpecialFolder.Desktop ) );
    }
}