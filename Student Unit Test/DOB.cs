using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject2
{
    class DOB
    {
        public static bool DOBValidation(DateTime input)
        {
            
            int n = DateTime.Compare(DateTime.Today, input);
            if(n <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
