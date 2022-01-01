using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class PhieuDuThiBUS
    {
        public PhieuDuThiBUS() { }
        public string SoBaoDanh { get; set; }
        public string MaPhongThi { get; set; }
        public string TenPhongThi { get; set; }
        public string CMND { get; set; }
        public string CaThi { get; set; }
        public string MaKhoaThi { get; set; }


        public List<PhieuDuThiBUS> getAll() => PhieuDuThiDAL.getAll();
        public static PhieuDuThiBUS getObj(string CMND) => PhieuDuThiDAL.getAll(CMND);
        public static List<PhieuDuThiBUS> getAllStatic() => PhieuDuThiDAL.getAll();
        public Boolean Insert() => PhieuDuThiDAL.Insert(this);


        public static string getNextSBD(List<PhieuDuThiBUS> list, string type)
        {
            int count = 1;

            list.ForEach(x => {
                if (x.SoBaoDanh.Contains(type))
                {
                    count++;
                }
            });

            if (count < 10)
                return type + "00"  + count;
            else
                return type + "0"  + count;
        }


    }
}
