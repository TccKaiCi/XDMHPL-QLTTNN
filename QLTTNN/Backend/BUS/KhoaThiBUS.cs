﻿using System;
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
        public string CaThi { get; set; }
        public DateTime NgayThi { get; set; }

        public List<KhoaThiBUS> getAll() => KhoaThiDAL.getAll();
        public static List<KhoaThiBUS> getAllStatic() => KhoaThiDAL.getAll();
        public int getCount() => KhoaThiDAL.getCount();
        public static string getRandomMa()
        {
            Random r = new Random();
            return "K" + r.Next(1, 1000000);
        }

        public Boolean Insert() => KhoaThiDAL.Insert(this);
        public Boolean Delete() => KhoaThiDAL.Delete(this);

        public static string getTrinhDoByKhoa(List<KhoaThiBUS> list,string ma)
        {
            string s = null;
            list.ForEach(x => {
                if (x.MaKhoaThi.Contains(ma))
                {
                    s = x.TrinhDo;
                }
            });

            return s;
        }

        public static string getTrinhDo_Ma(List<KhoaThiBUS> list,string key)
        {
            string res = "";
            list.ForEach(x => {
                if (x.MaKhoaThi.Equals(key))
                {
                    res = x.TrinhDo;
                }
            });

            return res;
        }
    }
}
