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
    }
}
