using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BUS;

namespace DAL
{
    public class ThiSinhDAL
    {
        public static int getCount()
        {
            /*
            using (DatabaseDataContext db = new DatabaseDataContext())
            {
                int count = (from u in db.LOAIHINHDULICHes select u).Count();
                return 0;
            }
            */
            return 0;
        }

        public static List<ThiSinh> getAll()
        {
            List<ThiSinh> list = new List<ThiSinh>();
            /*
            using (DatabaseDataContext db = new DatabaseDataContext())
            {
                var result = from u in db.LOAIHINHDULICHes
                             select new
                             {
                                 MaLoaiHinh = u.MaLoaiHinh,
                                 TenLoaiHinh = u.TenLoaiHinh,
                             };

                foreach (var i in result)
                {
                    LoaiHinhDuLichModel tour = new LoaiHinhDuLichModel();

                    tour.MaLoaiHinh = i.MaLoaiHinh;
                    tour.TenLoaiHinh = i.TenLoaiHinh;
                    list.Add(tour);
                }
            }
            */
            return list;
        }
    }
}
