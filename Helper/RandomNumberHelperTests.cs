// File: Plusmore.Einvoice.Common.Tests / RandomNumberHelperTests.cs
// 
// Author: Pay
// Created: 2017-01-12 14:06
// 
// Modified: 2017-01-12 14:14

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using Plusmore.Einvoice.Common.Helper;

namespace Plusmore.Einvoice.Common.Sample.Helper
{
    [TestClass]
    public class RandomNumberHelperTests
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        [TestMethod]
        public void RandomNumberHelperTests_Validate()
        {
            const string num = "1234";
            const string wrongNum1 = "12";
            const string wrongNum2 = "ABCD";

            Assert.IsTrue( Validator.RandomNumber( num ) );
            Assert.IsFalse( Validator.RandomNumber( string.Empty ) );
            Assert.IsFalse( Validator.RandomNumber( null ) );
            Assert.IsFalse( Validator.RandomNumber( wrongNum1 ) );
            Assert.IsFalse( Validator.RandomNumber( wrongNum2 ) );
        }

        [TestMethod]
        public void RandomNumberHelperTests_RandomNumber()
        {
            var r = RandomNumberHelper.RandomNumber();

            Logger.Debug( "random number: {0}", r );

            for ( var i = 0; i <= 1000; i++ )
            {
                r = RandomNumberHelper.RandomNumber();

                Assert.IsTrue( Validator.RandomNumber( r ) );
            }
        }
    }
}