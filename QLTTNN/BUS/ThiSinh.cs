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
        public String MaCMND { get; set; }
        public String HoTen { get; set; }
        public String GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public String NoiSinh { get; set; }
        public int SDT { get; set; }

        public ThiSinh(){}

        public static int getCount()
        {
            return ThiSinhDAL.getCount();
        }

        public List<ThiSinh> getAll()
        {
            return ThiSinhDAL.getAll();
        }


    }
}
