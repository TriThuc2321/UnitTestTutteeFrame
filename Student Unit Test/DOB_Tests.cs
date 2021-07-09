using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    //  Mô phỏng lại ngày tháng năm dc chọn từ DateTimePicker nên không sai format của input
    [TestClass]
    public class DOB_Tests
    {
        [TestMethod]
        public void DOB01()
        {
            var result = DOB.DOBValidation(new DateTime(18/08/2001));
            Assert.AreEqual("Ngay sinh hop le", result);
        }

        [TestMethod]
        public void DOB02()
        {
            var result = DOB.DOBValidation(new DateTime(18/08/2021));
            Assert.AreEqual("Ngay sinh khong hop le", result);
        }
        [TestMethod]
        public void DOB03() 
        {
            var result = DOB.DOBValidation(new DateTime(01/08/2007));
            Assert.AreEqual("Ngay sinh hop le", result);
        }
        [TestMethod]
        public void DOB04() 
        {
            var result = DOB.DOBValidation(new DateTime(29/02/2016));
            Assert.AreEqual("Ngay sinh hop le", result);
        }
        [TestMethod]
        public void DOB05() 
        {
            var result = DOB.DOBValidation(new DateTime(29/02/2017));
            Assert.AreEqual("Ngay sinh khong hop le", result);
        }
        [TestMethod]
        public void DOB06() 
        {
            var result = DOB.DOBValidation(new DateTime(31/04/2001));
            Assert.AreEqual("Ngay sinh khong hop le", result);
        }
    }
}
