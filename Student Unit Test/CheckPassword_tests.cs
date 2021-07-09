using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class CheckPassword_tests
    {
       
        [TestMethod]
        public void CheckLogin_valid() //case: Đăng nhập thành công
        {
            User u1 = new User("thayhoang", "123456");
            User u2 = new User("thaylong", "112233");
            List<User> users = new List<User>();
            users.Add(u1);
            users.Add(u2);

            var result = CheckPassword.CheckPass(users, "thayhoang", "123456");

            Assert.AreEqual("Dang nhap thanh cong", result);
        }

        [TestMethod]
        public void CheckLogin_notvalid1() //case: Đăng nhập sai mat khau
        {
            User u1 = new User("thayhoang", "123456");
            User u2 = new User("thaylong", "112233");
            List<User> users = new List<User>();
            users.Add(u1);
            users.Add(u2);

            var result = CheckPassword.CheckPass(users, "thayhoang", "1234567");

            Assert.AreEqual("Sai mat khau", result);
        }

        [TestMethod]
        public void CheckLogin_notvalid2() //case: khong co ten trong he thong
        {
            User u1 = new User("thayhoang", "123456");
            User u2 = new User("thaylong", "112233");
            List<User> users = new List<User>();
            users.Add(u1);
            users.Add(u2);

            var result = CheckPassword.CheckPass(users, "thaythien", "1234567");

            Assert.AreEqual("Khong ton tai ten nguoi dung nay", result);
        }
    }
}
