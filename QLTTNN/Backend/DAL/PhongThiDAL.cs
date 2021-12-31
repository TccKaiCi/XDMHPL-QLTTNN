using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class PhongThiDAL
    {

        public static List<PhongThiBUS> getAll()
        {
            List<PhongThiBUS> list = new List<PhongThiBUS>();

            using (DatabaseDataContext db = new DatabaseDataContext())
            {
                var result = from u in db.PHONGTHIs
                             select new
                             {
                                 a = u.TenPhongThi,
                                 b = u.MaKhoaThi,
                                 c = u.SoLuong
                             };

                foreach (var i in result)
                {
                    PhongThiBUS model = new PhongThiBUS();

                    model.TenPhongThi = i.a;
                    model.MaKhoaThi = i.b;
                    model.SoLuong = i.c;

                    list.Add(model);
                }
            }

            return list;
        }


    }
}
