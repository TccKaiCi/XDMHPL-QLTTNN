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
        public Boolean Insert() {
            //phieu du thi
            SoBaoDanh = PhieuDuThiBUS.getNextSBD(PhieuDuThiBUS.getAllStatic()
                , KhoaThiBUS.getTrinhDoByKhoa(KhoaThiBUS.getAllStatic(), MaKhoaThi) );
            TenPhongThi = PhongThiBUS.getPhongThiByMaKhoaThi(PhongThiBUS.GetAll(), MaKhoaThi);
            CaThi = "Ca sáng";

            return ThiSinhDAL.Insert(this);
        }



        public string SoBaoDanh { get; set; }
        public string TenPhongThi { get; set; }
        public string CaThi { get; set; }
        public string MaKhoaThi { get; set; }

        public int diemNghe { get; set; }
        public int diemNoi { get; set; }
        public int diemViet { get; set; }
        public int diemDoc { get; set; }

        public static ThiSinhBUS findBy_HoTen_SDT(List<ThiSinhBUS> list, string hoten, string sdt)
        {
            ThiSinhBUS res = new ThiSinhBUS();

            list.ForEach(x => {
                if (x.HoTen.Equals(hoten) && x.SDT == Int32.Parse(sdt))
                {
                    res.SoBaoDanh = x.SoBaoDanh;
                    res.TenPhongThi = x.TenPhongThi;
                    res.diemViet = x.diemViet;
                    res.diemNoi = x.diemNoi;
                    res.diemNghe = x.diemNghe;
                    res.diemDoc = x.diemDoc;
                    res.HoTen = x.HoTen;
                }
            });

            return res;
        }

        public static List<ThiSinhBUS> findBy_HoTen_SDT_LIST(List<ThiSinhBUS> list, string hoten, string sdt)
        {
            List<ThiSinhBUS> resList = new List<ThiSinhBUS>();

            list.ForEach(x => {
                if (x.HoTen.Equals(hoten) && x.SDT == Int32.Parse(sdt))
                {
                    ThiSinhBUS res = new ThiSinhBUS();

                    res.HoTen = x.HoTen;
                    res.MaKhoaThi = x.MaKhoaThi;
                    res.SoBaoDanh = x.SoBaoDanh;
                    res.TenPhongThi = x.TenPhongThi;
                    res.GioiTinh = x.GioiTinh;
                    res.diemViet = x.diemViet;
                    res.diemNoi = x.diemNoi;
                    res.diemNghe = x.diemNghe;
                    res.diemDoc = x.diemDoc;
                    res.CaThi = x.CaThi;
                    res.SDT = x.SDT;

                    resList.Add(res);
                }
            });

            return resList;
        }

        public static ThiSinhBUS findBy_SBD(List<ThiSinhBUS> list, string sbd)
        {
            ThiSinhBUS res = new ThiSinhBUS();

            list.ForEach(x => {
                if (x.SoBaoDanh.Equals(sbd))
                {
                    res.SoBaoDanh = sbd;
                    res.HoTen = x.HoTen;
                    res.GioiTinh = x.GioiTinh;
                    res.NgaySinh = x.NgaySinh;
                    res.NoiSinh = res.NoiSinh;
                    res.TenPhongThi = x.TenPhongThi;
                    res.diemViet = x.diemViet;
                    res.diemNoi = x.diemNoi;
                    res.diemNghe = x.diemNghe;
                    res.diemDoc = x.diemDoc;
                }
            });

            return res;
        }

        public static List<ThiSinhBUS> findBy_MaKhoaThi_TenPhongThi(List<ThiSinhBUS> list, string khoathi, string phongthi)
        {
            List<ThiSinhBUS> resList = new List<ThiSinhBUS>();

            list.ForEach(x => {
                if (x.MaKhoaThi.Equals(khoathi) && x.TenPhongThi.Equals(phongthi) )
                {
                    ThiSinhBUS res = new ThiSinhBUS();
                    res.SoBaoDanh = x.SoBaoDanh;
                    res.HoTen = x.HoTen;
                    res.GioiTinh = x.GioiTinh;
                    res.SDT = x.SDT;

                    resList.Add(res);
                }
            });

            return resList;
        }

    }
}
