using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
  
    [TestClass]
    public class EmailValidation_Tests {
        [TestMethod]
        public void EmailTest01()
        {
            var result = EmailValidation.IsValidEmail("theostevenson1880@gmail.com");
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void EmailTest02()
        {
            var result = EmailValidation.IsValidEmail("theostevenson@@gmaile.com");
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void EmailTest03()
        {
            var result = EmailValidation.IsValidEmail("pvdthien@gmaile.com");
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void EmailTest04()
        {
            var result = EmailValidation.IsValidEmail("");
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void EmailTest05()
        {
            var result = EmailValidation.IsValidEmail("aa");
            Assert.AreEqual(false, result);
        }
    }
    
}
