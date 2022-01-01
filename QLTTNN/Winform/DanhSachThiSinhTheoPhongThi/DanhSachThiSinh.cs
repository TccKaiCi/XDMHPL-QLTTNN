using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Backend;

namespace Winform
{
    public partial class DanhSachThiSinh : Form
    {
        List<ThiSinhBUS> listTS;

        public DanhSachThiSinh()
        {
            InitializeComponent();
        }

        private void DanhSachThiSinh_Load(object sender, EventArgs e)
        {
            readData();
        }

        public void readData()
        {
            listTS = ThiSinhBUS.getAllStatic();

            dataGridView1.DataSource = listTS;

            dataGridView1.Columns["CaThi"].Visible = false;
            dataGridView1.Columns["diemNghe"].Visible = false;
            dataGridView1.Columns["diemNoi"].Visible = false;
            dataGridView1.Columns["diemDoc"].Visible = false;
            dataGridView1.Columns["diemViet"].Visible = false;
            dataGridView1.Columns["NoiSinh"].Visible = false;
            dataGridView1.Columns["ManPhongThi"].Visible = false;
            dataGridView1.Columns["MaKhoaThi"].Visible = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 c = new Form1();
            this.Hide();
            c.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            readData();
        }
    }
}
