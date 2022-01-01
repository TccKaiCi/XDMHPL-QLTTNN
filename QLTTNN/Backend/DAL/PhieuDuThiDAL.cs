using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class PhieuDuThiDAL
    {
        public static int getCount()
        {
            using (DatabaseDataContext db = new DatabaseDataContext())
            {
                int count = (from u in db.PHIEUDUTHIs select u).Count();
                return count;
            }
        }

        public static List<PhieuDuThiBUS> getAll()
        {
            List<PhieuDuThiBUS> list = new List<PhieuDuThiBUS>();

            using (DatabaseDataContext db = new DatabaseDataContext())
            {
                var result = from u in db.PHIEUDUTHIs
                             from v in db.PHONGTHIs
                             where u.MaPhongThi == v.MaPhongThi
                             select new
                             {
                                 x = v.TenPhongThi,
                                 a = u.MaPhongThi,
                                 b = u.CMND,
                                 d = u.SoBaoDanh,
                                 e = u.MaKhoaThi
                             };

                foreach (var i in result)
                {
                    PhieuDuThiBUS model = new PhieuDuThiBUS();

                    model.TenPhongThi = i.x;
                    model.MaPhongThi = i.a;
                    model.CMND = i.b;
                    model.SoBaoDanh = i.d;
                    model.MaKhoaThi = i.e;

                    list.Add(model);
                }
            }

            return list;
        }

        public static PhieuDuThiBUS getAll(string CMND)
        {
            using (DatabaseDataContext db = new DatabaseDataContext())
            {
                var result = from u in db.PHIEUDUTHIs
                             from v in db.PHONGTHIs
                             where u.MaPhongThi == v.MaPhongThi
                             & u.CMND == CMND
                             select new
                             {
                                 a = v.TenPhongThi,
                                 aa = u.MaPhongThi,
                                 b = u.CMND,
                                 d = u.SoBaoDanh,
                                 e = u.MaKhoaThi
                             };

                foreach (var i in result)
                {
                    PhieuDuThiBUS model = new PhieuDuThiBUS();

                    model.TenPhongThi = i.a;
                    model.MaPhongThi = i.aa;
                    model.CMND = i.b;
                    model.SoBaoDanh = i.d;
                    model.MaKhoaThi = i.e;

                    return model;
                }
            }

            return null;
        }

        public static bool Insert(PhieuDuThiBUS obj)
        {
            try
            {
                using (DatabaseDataContext db = new DatabaseDataContext())
                {
                    db.PHIEUDUTHIs.InsertOnSubmit(new PHIEUDUTHI()
                    {
                        CMND = obj.CMND,
                        MaPhongThi = obj.MaPhongThi,
                        SoBaoDanh = obj.SoBaoDanh
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
