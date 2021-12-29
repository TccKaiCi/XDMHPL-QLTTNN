using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class PhongThiDAL
    {

        public static int getCount()
        {
            using (DatabaseDataContext db = new DatabaseDataContext())
            {
                int count = (from u in db.THISINHs select u).Count();
                return count;
            }
        }

        public static List<ThiSinhBUS> getAll()
        {
            List<ThiSinhBUS> list = new List<ThiSinhBUS>();

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
                    ThiSinhBUS model = new ThiSinhBUS();

                    model.CMND = i.a;
                    model.HoTen = i.b;
                    model.GioiTinh = i.c;
                    model.NgaySinh = (DateTime)i.d;
                    model.NoiSinh = i.e;
                    model.SDT = (int)i.f;

                    list.Add(model);
                }
            }

            return list;
        }


        public static bool Insert(ThiSinhBUS obj)
        {
            try
            {
                using (DatabaseDataContext db = new DatabaseDataContext())
                {
                    db.THISINHs.InsertOnSubmit(new THISINH()
                    {
                        CMND = obj.CMND,
                        HoTen = obj.HoTen,
                        GioiTinh = obj.GioiTinh,
                        NgaySinh = obj.NgaySinh,
                        NoiSinh = obj.NoiSinh,
                        SDT = obj.SDT
                    });

                    db.SubmitChanges();

                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
