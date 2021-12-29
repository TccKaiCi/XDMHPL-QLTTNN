using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    class GioiTinhDAL
    {
        public static List<GioiTinhBUS> getAll()
        {
            List<GioiTinhBUS> list = new List<GioiTinhBUS>();

            using (DatabaseDataContext db = new DatabaseDataContext())
            {
                var result = from u in db.GIOITINHs
                             select new
                             {
                                 a = u.GIOITINH1
                             };

                foreach (var i in result)
                {
                    GioiTinhBUS model = new GioiTinhBUS();

                    model.GIOITINH = i.a;

                    list.Add(model);
                }
            }

            return list;
        }
    }
}
