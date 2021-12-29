using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;

namespace BUS
{
    public class DiaDiem
    {
        public String MaDiaDiem;
        public String TenDiaDiem;

        public List<DiaDiem> getAll()
        {
            return DiaDiemDAL.getAll();
        }

    }
}
