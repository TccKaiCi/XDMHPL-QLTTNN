using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class KhoaThiDAL
    {

        public static int getCount()
        {
            using (DatabaseDataContext db = new DatabaseDataContext())
            {
                int count = (from u in db.KHOATHIs select u).Count();
                return count;
            }
        }

        public static List<KhoaThiBUS> getAll()
        {
            List<KhoaThiBUS> list = new List<KhoaThiBUS>();

            using (DatabaseDataContext db = new DatabaseDataContext())
            {
                var result = from u in db.KHOATHIs
                             select new
                             {
                                 a = u.MaKhoaThi,
                                 b = u.TenKhoaThi,
                                 c = u.TrinhDo,
                                 d = u.NgayThi,
                                 e = u.CaThi
                             };

                foreach (var i in result)
                {
                    KhoaThiBUS model = new KhoaThiBUS();

                    model.MaKhoaThi = i.a;
                    model.TenKhoaThi = i.b;
                    model.TrinhDo = i.c;
                    model.NgayThi = (DateTime)i.d;
                    model.CaThi = i.e;

                    list.Add(model);
                }
            }

            return list;
        }


        public static bool Insert(KhoaThiBUS obj)
        {
            try
            {
                using (DatabaseDataContext db = new DatabaseDataContext())
                {
                    db.KHOATHIs.InsertOnSubmit(new KHOATHI()
                    {
                        MaKhoaThi = obj.MaKhoaThi,
                        TenKhoaThi = obj.TenKhoaThi,
                        TrinhDo = obj.TrinhDo,
                        CaThi = obj.CaThi,
                        NgayThi = obj.NgayThi
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

        public static bool Delete(KhoaThiBUS obj)
        {
            try
            {
                using (DatabaseDataContext db = new DatabaseDataContext())
                {
                    var gia = db.KHOATHIs.Where(p => p.MaKhoaThi.Equals(obj.MaKhoaThi)).SingleOrDefault();
                    db.KHOATHIs.DeleteOnSubmit(gia);
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
