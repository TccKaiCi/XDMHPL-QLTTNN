using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BUS;

namespace DAL
{
    public class DiaDiemDAL
    {
        public static List<DiaDiem> getAll()
        {
            List<DiaDiem> list = new List<DiaDiem>();

            using (DatabaseDataContext db = new DatabaseDataContext())
            {
                var result = from u in db.DIADDIEMs
                             select new
                             {
                                 a = u.MADIADIEM,
                                 b = u.TENDIADIEM
                             };

                foreach (var i in result)
                {
                    DiaDiem model = new DiaDiem();

                    model.MaDiaDiem = i.a;
                    model.TenDiaDiem = i.b;

                    list.Add(model);
                }
            }

            return list;
        }
    }
}
