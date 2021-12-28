using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;

namespace BUS
{
    public class ThiSinh
    {
        public string MaCMND { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public string NgaySinh { get; set; }
        public string NoiSinh { get; set; }
        public string SDT { get; set; }

        public ThiSinh(){}

        public static int getCount()
        {
            return 0;
        }

        public List<ThiSinh> getAll()
        {
            return ThiSinhDAL.getAll();
        }


    }
}
