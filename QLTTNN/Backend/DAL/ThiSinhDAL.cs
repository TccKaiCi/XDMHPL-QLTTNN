using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
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

        public static List<ThiSinhBUS> getAll()
        {
            List<ThiSinhBUS> list = new List<ThiSinhBUS>();

            using (DatabaseDataContext db = new DatabaseDataContext())
            {
                var result = from u in db.THISINHs
                             from v in db.PHIEUDUTHIs
                             where u.CMND == v.CMND
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
                    model.SDT = i.f;

                    model.PhieuDuThiBUS = PhieuDuThiBUS.getObj(model.CMND);

                    list.Add(model);
                }
            }

            return list;
        }

        public static ThiSinhBUS getAll(string hoten, string sdt)
        {
            int sdtx = Int32.Parse(sdt);

            using (DatabaseDataContext db = new DatabaseDataContext())
            {
                var result = from u in db.THISINHs
                             from v in db.PHIEUDUTHIs
                             where u.CMND == v.CMND &
                             u.HoTen == hoten &
                             u.SDT == sdtx
                             select new
                             {
                                 a = u.CMND,
                                 b = u.HoTen,
                                 c = u.GioiTinh,
                                 d = u.NgaySinh,
                                 e = u.NoiSinh,
                                 f = u.SDT,

                                 g = v.SoBaoDanh,
                                 h = v.TenPhongThi,
                                 i = v.CMND,
                                 j = v.CaThi,
                                 k = v.MaKhoaThi

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

                    model.PhieuDuThiBUS.SoBaoDanh = i.g;
                    model.PhieuDuThiBUS.TenPhongThi = i.h;
                    model.PhieuDuThiBUS.CMND = i.i;
                    model.PhieuDuThiBUS.CaThi = i.j;
                    model.PhieuDuThiBUS.MaKhoaThi = i.k;

                    return model;
                }
            }
            return null;

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
