using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject2
{
    class User
    {
        string username;
        string password;

       public  User(string name, string pass)
        {
            this.username = name;
            this.password = pass;
        }
        public string Getname()
        {
            return username;
        }
        public void Setname(string name)
        {
            this.username = name;
        }
        public string Getpass()
        {
            return password;
        }
        public void Setpass(string pass)
        {
            this.password = pass;
        }
    }
    class CheckPassword
    {
        public static string CheckPass(List<User> user, string inname, string inpass)
        {
           foreach(User u in user)
            {
                if(inname == u.Getname())
                {
                    if (inpass == u.Getpass()) return "Dang nhap thanh cong";
                    return "Sai mat khau";
                }
            }
            return "Khong ton tai ten nguoi dung nay";
        }
    }
}
