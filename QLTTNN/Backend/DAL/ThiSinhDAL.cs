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
                             from w in db.KETQUAs
                             from x in db.KHOATHIs
                             where u.CMND == v.CMND &
                             v.SoBaoDanh == w.SoBaoDanh &
                             v.MaKhoaThi == x.MaKhoaThi
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
                                 j = x.CaThi,
                                 k = v.MaKhoaThi,

                                 l = w.DiemDoc,
                                 m = w.DiemNghe,
                                 n = w.DiemNoi,
                                 o = w.DiemViet
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

                    model.SoBaoDanh = i.g;
                    model.TenPhongThi = i.h;
                    model.CaThi = i.j;
                    model.MaKhoaThi = i.k;

                    model.diemDoc = i.l;
                    model.diemNghe = i.m;
                    model.diemNoi = i.n;
                    model.diemViet = i.o;

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

                    // Phieu Du Thi
                    db.PHIEUDUTHIs.InsertOnSubmit(new PHIEUDUTHI()
                    {
                        CMND = obj.CMND,
                        SoBaoDanh = obj.SoBaoDanh,
                        TenPhongThi = obj.TenPhongThi,
                        MaKhoaThi = obj.MaKhoaThi
                    });

                    // Diem
                    db.KETQUAs.InsertOnSubmit(new KETQUA()
                    {
                        SoBaoDanh = obj.SoBaoDanh,
                        MaKhoaThi = obj.MaKhoaThi,
                        DiemDoc = 0,
                        DiemNghe = 0,
                        DiemViet = 0,
                        DiemNoi = 0
                    });

                    db.SubmitChanges();

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
