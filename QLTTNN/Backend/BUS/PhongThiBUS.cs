using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class PhongThiBUS
    {
        public PhongThiBUS() { }
        public string MaPhongThi { get; set; }
        public string TenPhongThi { get; set; }
        public string MaKhoaThi { get; set; }
        public int SoLuong { get; set; }



        public string TenKhoaThi { get; set; }
        public string TrinhDo { get; set; }
        public string CaThi { get; set; }
        public DateTime NgayThi { get; set; }


        public static List<PhongThiBUS> GetAll() => PhongThiDAL.getAll();
        public List<PhongThiBUS> getAll() => PhongThiDAL.getAll();
        public Boolean Insert() => PhongThiDAL.Insert(this);
        public Boolean Update() => PhongThiDAL.Update(this);
        public Boolean Delete() => PhongThiDAL.Delete(this);

        public static string getPhongThiByMaKhoaThi(List<PhongThiBUS> list, string ma)
        {
            string s = null;
            list.ForEach(x => {
                if (x.MaKhoaThi.Contains(ma))
                {
                    s = x.TenPhongThi;
                }
            });

            return s;
        }

        public static string getMaKhoaThi_MaPhongThi(List<PhongThiBUS> list, string ma)
        {
            string s = null;
            list.ForEach(x => {
                if (x.MaPhongThi.Contains(ma))
                {
                    s = x.MaKhoaThi;
                }
            });

            return s;
        }

        public static List<PhongThiBUS> getPhongThi_MaKhoaThi(List<PhongThiBUS> listPT ,string ma)
        {
            List<PhongThiBUS> list = new List<PhongThiBUS>();

            listPT.ForEach(x => {
                if (x.MaKhoaThi.Contains(ma))
                {
                    PhongThiBUS s = new PhongThiBUS();


                    s.MaPhongThi = x.MaPhongThi;
                    s.TenPhongThi = x.TenPhongThi;
                    s.SoLuong = x.SoLuong;
                    s.MaKhoaThi = x.MaKhoaThi;

                    list.Add(s);
                }
            });

            return list;
        }

        public static string getMaPhong_MaKhoaThi(List<PhongThiBUS> list, string ma)
        {
            string s = null;
            list.ForEach(x => {
                if (x.MaKhoaThi.Contains(ma))
                {
                    s = x.MaPhongThi;
                }
            });

            return s;
        }

        public static PhongThiBUS getObj_Ma(List<PhongThiBUS> list, string key)
        {
            PhongThiBUS model = new PhongThiBUS();

            string s = null;
            list.ForEach(x => {
                if (x.MaPhongThi.Contains(key) )
                {
                    model.MaPhongThi = x.MaPhongThi;
                    model.TenPhongThi = x.TenPhongThi;
                    model.SoLuong = x.SoLuong;
                    model.MaKhoaThi = x.MaKhoaThi;

                    model.TenPhongThi = x.TenPhongThi;
                    model.TrinhDo = x.TrinhDo;
                    model.NgayThi = x.NgayThi;
                    model.CaThi = x.CaThi;
                }
            });

            return model;
        }
    }
}
