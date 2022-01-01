using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class PhongThiDAL
    {

        public static List<PhongThiBUS> getAll()
        {
            List<PhongThiBUS> list = new List<PhongThiBUS>();

            using (DatabaseDataContext db = new DatabaseDataContext())
            {
                var result = from u in db.PHONGTHIs
                             from v in db.KHOATHIs
                             where u.MaKhoaThi == v.MaKhoaThi
                             select new
                             {
                                 a = u.TenPhongThi,
                                 b = u.MaKhoaThi,
                                 c = u.SoLuong,

                                 d = v.TenKhoaThi,
                                 e = v.CaThi,
                                 f = v.TrinhDo,
                                 g = v.NgayThi
                             };

                foreach (var i in result)
                {
                    PhongThiBUS model = new PhongThiBUS();

                    model.TenPhongThi = i.a;
                    model.MaKhoaThi = i.b;
                    model.SoLuong = i.c;

                    model.TenKhoaThi = i.d;
                    model.CaThi = i.e;
                    model.TrinhDo = i.f;
                    model.NgayThi = i.g;

                    list.Add(model);
                }
            }

            return list;
        }


        public static bool Insert(PhongThiBUS obj)
        {
            try
            {
                using (DatabaseDataContext db = new DatabaseDataContext())
                {
                    db.PHONGTHIs.InsertOnSubmit(new PHONGTHI()
                    {
                        TenPhongThi = obj.TenPhongThi,
                        SoLuong = obj.SoLuong,
                        MaKhoaThi = obj.MaKhoaThi

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

        // delete
        public static bool Delete(PhongThiBUS obj)
        {
            try
            {
                using (DatabaseDataContext db = new DatabaseDataContext())
                {
                    var gia = db.PHONGTHIs.Where(p => p.TenPhongThi.Equals(obj.TenPhongThi)).SingleOrDefault();
                    db.PHONGTHIs.DeleteOnSubmit(gia);
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

        public static bool Update(PhongThiBUS obj)
        {
            try
            {
                using (DatabaseDataContext db = new DatabaseDataContext())
                {
                    var tour = db.PHONGTHIs.Where(p => p.TenPhongThi.Equals(obj.TenPhongThi)).SingleOrDefault();
                    tour.SoLuong = obj.SoLuong;
                    tour.MaKhoaThi = obj.MaKhoaThi;

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
