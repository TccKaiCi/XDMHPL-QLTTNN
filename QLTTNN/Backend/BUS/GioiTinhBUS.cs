using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class GioiTinhBUS
    {
        public GioiTinhBUS() { }
        public string GIOITINH { get; set; }

        public List<GioiTinhBUS> getAll() => GioiTinhDAL.getAll();
    }
}
