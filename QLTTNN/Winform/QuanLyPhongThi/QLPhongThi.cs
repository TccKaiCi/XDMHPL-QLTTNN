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
    public partial class QLPhongThi : Form
    {
        List<PhongThiBUS> listPT;
        public QLPhongThi()
        {
            InitializeComponent();
        }

        private void QLPhongThi_Load(object sender, EventArgs e)
        {
            reloadData();
        }

        public void reloadData()
        {
            listPT = PhongThiBUS.GetAll();
            dataGridView1.DataSource = listPT;

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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string MaPhong = dataGridView1.SelectedCells[0].Value.ToString();
            string tenPhong = dataGridView1.SelectedCells[1].Value.ToString();
            XoaPhongThi c = new XoaPhongThi(tenPhong);
            c.ShowDialog();

            if (c.DialogResult == DialogResult.OK)
            {
                PhongThiBUS model = new PhongThiBUS();
                model.MaPhongThi = MaPhong;


                if (model.Delete())
                {
                    MessageBox.Show("Xóa thành công");
                    reloadData();
                } else
                {
                    MessageBox.Show("Xóa thất bại");
                }

            }
            c.Dispose();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ThemPhongThi c = new ThemPhongThi();
            c.ShowDialog();

            if (c.DialogResult == DialogResult.OK)
            {
                reloadData();
            }
            c.Dispose();
        }

        private void buttonMod_Click(object sender, EventArgs e)
        {
            string tenPhong = dataGridView1.SelectedCells[0].Value.ToString();
            SuaPhongThi c = new SuaPhongThi(tenPhong);
            c.ShowDialog();

            if (c.DialogResult == DialogResult.OK)
            {
                reloadData();
            }
            c.Dispose();
        }
    }
}
