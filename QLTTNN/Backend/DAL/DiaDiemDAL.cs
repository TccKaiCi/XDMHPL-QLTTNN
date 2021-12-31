using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class DiaDiemDAL
    {
        public static List<DiaDiemBUS> getAll()
        {
            List<DiaDiemBUS> list = new List<DiaDiemBUS>();

            using (DatabaseDataContext db = new DatabaseDataContext())
            {
                var result = from u in db.DIADIEMs
                             select new
                             {
                                 a = u.MADIADIEM,
                                 b = u.TENDIADIEM
                             };

                foreach (var i in result)
                {
                    DiaDiemBUS model = new DiaDiemBUS();

                    model.MaDiaDiem = i.a;
                    model.TenDiaDiem = i.b;

                    list.Add(model);
                }
            }

            return list;
        }
    }
}
