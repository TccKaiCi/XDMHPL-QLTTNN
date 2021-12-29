using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class ThiSinhBUS
    {
        public ThiSinhBUS() { }

        public string CMND { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public string NoiSinh { get; set; }
        public int SDT { get; set; }
        public DateTime NgaySinh { get; set; }

        public List<ThiSinhBUS> getAll() => ThiSinhDAL.getAll();
        public static List<ThiSinhBUS> getAllStatic() => ThiSinhDAL.getAll();
        public Boolean Insert() => ThiSinhDAL.Insert(this);


        public PhieuDuThiBUS PhieuDuThiBUS { get; set; }

        public static ThiSinhBUS getAllBy_HoTen_SDT(string hoten, string sdt) => ThiSinhDAL.getAll(hoten, sdt);
        public static ThiSinhBUS findBy_HoTen_SDT(List<ThiSinhBUS> list, string hoten, string sdt)
        {
            ThiSinhBUS res = new ThiSinhBUS();

            list.ForEach(x => {
                if (x.HoTen.Equals(hoten) && x.SDT == Int32.Parse(sdt))
                {
                    res.GioiTinh = x.GioiTinh;
                    res.PhieuDuThiBUS.SoBaoDanh = x.PhieuDuThiBUS.SoBaoDanh;
                    res.PhieuDuThiBUS.TenPhongThi = x.PhieuDuThiBUS.TenPhongThi;
                }
            });

            return res;
        }
    }
}
