using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class PhoneNumber_Tests
    {
        [TestMethod]
        public void PhoneNumberTest01() 
        {
            var result = PhoneNumberValidation.IsValidPhoneNumber("0358075274");
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void PhoneNumberTest02() 
        {
            var result = PhoneNumberValidation.IsValidPhoneNumber("1358075274");
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void PhoneNumberTest03() 
        {
            var result = PhoneNumberValidation.IsValidPhoneNumber("035807w27b");
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void PhoneNumberTest04() 
        {
            var result = PhoneNumberValidation.IsValidPhoneNumber("03580752745");
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void PhoneNumberTest05() 
        {
            var result = PhoneNumberValidation.IsValidPhoneNumber("");
            Assert.AreEqual(false, result);
        }
    }
}
