using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DangKy_ThiSinh c = new DangKy_ThiSinh();
            this.Hide();
            c.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DanhSachThiSinh c = new DanhSachThiSinh();
            this.Hide();
            c.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TimKiemThongTinThiSinh.TimKiemThongTIn c = new TimKiemThongTinThiSinh.TimKiemThongTIn();
            this.Hide();
            c.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QLPhongThi c = new QLPhongThi();
            this.Hide();
            c.ShowDialog();
            this.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            QLKhoaThi c = new QLKhoaThi();
            this.Hide();
            c.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NhapDiemThi c = new NhapDiemThi();
            this.Hide();
            c.ShowDialog();
            this.Close();
        }
    }
}
