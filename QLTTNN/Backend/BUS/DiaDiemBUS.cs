using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class DiaDiemBUS
    {
        public DiaDiemBUS() { }
        public DiaDiemBUS(string MaDiaDiem, string TenDiaDiem)
        {
            this.MaDiaDiem = MaDiaDiem;
            this.TenDiaDiem = TenDiaDiem;
        }
        public string MaDiaDiem { get; set; }
        public string TenDiaDiem { get; set; }
        public List<DiaDiemBUS> getAll() => DiaDiemDAL.getAll();
        public static List<DiaDiemBUS> getAllStatic() => DiaDiemDAL.getAll();
    }
}
