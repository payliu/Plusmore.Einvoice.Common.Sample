using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plusmore.Einvoice.Common.Helper;

namespace Plusmore.Einvoice.Common.Sample.Helper
{
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        public void ValidatorTests_Vat()
        {
            const string vat = "24592118";
            const string tenZero = "0000000000";
            const string wrong1 = "245921188888";
            const string wrong2 = "1234567";

            Assert.IsTrue( Validator.Vat( vat ) );
            Assert.IsFalse( Validator.Vat( tenZero ) );
            Assert.IsFalse( Validator.Vat( wrong1 ) );
            Assert.IsFalse( Validator.Vat( wrong2 ) );
            Assert.IsFalse( Validator.Vat( null ) );
            Assert.IsFalse( Validator.Vat( string.Empty ) );
            Assert.IsFalse( Validator.Vat( "   " ) );
        }

        [TestMethod]
        public void ValidatorTests_LoveCode()
        {
            const string code1 = "123";
            const string code2 = "00132";
            const string code3 = "1234567";
            const string wrong1 = "12345678";
            const string wrong2 = "245921188888";
            const string wrong3 = "1";
            const string wrong4 = "12";

            Assert.IsTrue( Validator.LoveCode( code1 ) );
            Assert.IsTrue( Validator.LoveCode( code2 ) );
            Assert.IsTrue( Validator.LoveCode( code3 ) );
            Assert.IsFalse( Validator.LoveCode( wrong1 ) );
            Assert.IsFalse( Validator.LoveCode( wrong2 ) );
            Assert.IsFalse( Validator.LoveCode( wrong3 ) );
            Assert.IsFalse( Validator.LoveCode( wrong4 ) );
            Assert.IsFalse( Validator.LoveCode( null ) );
            Assert.IsFalse( Validator.LoveCode( string.Empty ) );
            Assert.IsFalse( Validator.LoveCode( "   " ) );
        }

        [TestMethod]
        public void ValidatorTests_InvoiceNumber()
        {
            const string invoiceNumber = "AB12345678";
            const string wrong1 = "AB245921188888";
            const string wrong2 = "AB1234567";

            Assert.IsTrue( Validator.InvoiceNumber( invoiceNumber ) );
            Assert.IsFalse( Validator.InvoiceNumber( string.Empty ) );
            Assert.IsFalse( Validator.InvoiceNumber( null ) );
            Assert.IsFalse( Validator.InvoiceNumber( wrong1 ) );
            Assert.IsFalse( Validator.InvoiceNumber( wrong2 ) );
        }

        [TestMethod]
        public void ValidatorTests_MobilePhoneCode()
        {
            const string code1 = "/Y6G17YP";
            const string code2 = "/Y6G17Y.";
            const string code3 = "/Y6G17Y-";
            const string code4 = "/Y++--Y-";
            const string wrong1 = "Y6G17YP";
            var wrong2 = "/Y6G17YP".ToLower();
            const string wrong3 = "1";
            const string wrong4 = "12";

            Assert.IsTrue( Validator.MobilePhoneCode( code1 ) );
            Assert.IsTrue( Validator.MobilePhoneCode( code2 ) );
            Assert.IsTrue( Validator.MobilePhoneCode( code3 ) );
            Assert.IsTrue( Validator.MobilePhoneCode( code4 ) );
            Assert.IsFalse( Validator.MobilePhoneCode( wrong1 ) );
            Assert.IsFalse( Validator.MobilePhoneCode( wrong2 ) );
            Assert.IsFalse( Validator.MobilePhoneCode( wrong3 ) );
            Assert.IsFalse( Validator.MobilePhoneCode( wrong4 ) );
            Assert.IsFalse( Validator.MobilePhoneCode( null ) );
            Assert.IsFalse( Validator.MobilePhoneCode( string.Empty ) );
            Assert.IsFalse( Validator.MobilePhoneCode( "   " ) );
        }

         [TestMethod]
        public void ValidatorTests_CitizenDigitalCertificate()
        {
            const string code1 = "AB12345678901234";
            const string wrong1 = "AB1234567890";
            var wrong2 = code1.ToLower();
            const string wrong3 = "AB1234567890123400000000";
            const string wrong4 = "12";

            Assert.IsTrue( Validator.CitizenDigitalCertificate( code1 ) );
            Assert.IsFalse( Validator.CitizenDigitalCertificate( wrong1 ) );
            Assert.IsFalse( Validator.CitizenDigitalCertificate( wrong2 ) );
            Assert.IsFalse( Validator.CitizenDigitalCertificate( wrong3 ) );
            Assert.IsFalse( Validator.CitizenDigitalCertificate( wrong4 ) );
            Assert.IsFalse( Validator.CitizenDigitalCertificate( null ) );
            Assert.IsFalse( Validator.CitizenDigitalCertificate( string.Empty ) );
            Assert.IsFalse( Validator.CitizenDigitalCertificate( "   " ) );
        }
    }
}