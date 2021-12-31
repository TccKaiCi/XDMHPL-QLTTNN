using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform
{
    public class CacHamCheck
    {
        public static Boolean isText_NULL(String s)
        {
            if (s == "" || s == null)
                return true;
            return false;
        }
    }
}
