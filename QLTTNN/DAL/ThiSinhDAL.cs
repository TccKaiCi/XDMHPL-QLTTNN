using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BUS;

namespace DAL
{
    public class ThiSinhDAL
    {
        public static int getCount()
        {
            using (DatabaseDataContext db = new DatabaseDataContext())
            {
                int count = (from u in db.THISINHs select u).Count();
                return count;
            }
        }

        public static List<ThiSinh> getAll()
        {
            List<ThiSinh> list = new List<ThiSinh>();

            using (DatabaseDataContext db = new DatabaseDataContext())
            {
                var result = from u in db.THISINHs
                             select new
                             {
                                 a = u.CMND,
                                 b = u.HoTen,
                                 c = u.GioiTinh,
                                 d = u.NgaySinh,
                                 e = u.NoiSinh,
                                 f = u.SDT
                             };

                foreach (var i in result)
                {
                    ThiSinh model = new ThiSinh();

                    model.MaCMND = i.a;
                    model.HoTen = i.b;
                    model.GioiTinh = i.c;
                    model.NgaySinh = (DateTime) i.d;
                    model.NoiSinh = i.e;
                    model.SDT = (int)i.f;

                    list.Add(model);
                }
            }

            return list;
        }
    }
}
