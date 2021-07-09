using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject2
{
    class PhoneNumberValidation
    {
        public static bool IsValidPhoneNumber(String phonenumber)
        {
            if (phonenumber == "") return false;
            return phonenumber[0] == '0' && phonenumber.Length == 10 && IsDigit(phonenumber);
        }
        static bool IsDigit(string phonenumber) {
            foreach(char c in phonenumber)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }
    }
}
