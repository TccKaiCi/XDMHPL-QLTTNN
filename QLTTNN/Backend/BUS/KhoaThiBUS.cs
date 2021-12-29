using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class KhoaThiBUS
    {
        public KhoaThiBUS() { }

        public string MaKhoaThi { get; set; }
        public string TenKhoaThi { get; set; }
        public string TrinhDo { get; set; }
        public DateTime NgayThi { get; set; }

        public List<KhoaThiBUS> getAll() => KhoaThiDAL.getAll();
        public static List<KhoaThiBUS> getAllStatic() => KhoaThiDAL.getAll();
        public int getCount() => KhoaThiDAL.getCount();
        public Boolean Insert() => KhoaThiDAL.Insert(this);

    }
}
