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
    public partial class QLKhoaThi : Form
    {
        List<KhoaThiBUS> listKT;
        public QLKhoaThi()
        {
            InitializeComponent();
        }

        private void QLKhoaThi_Load(object sender, EventArgs e)
        {
            reloadData();
        }

        public void reloadData()
        {
            listKT = KhoaThiBUS.getAllStatic();
            dataGridView1.DataSource = listKT;

            //dataGridViewTourDuLich.Columns["MaTour"].Visible = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 c = new Form1();
            this.Hide();
            c.ShowDialog();
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ThemKhoaThi c = new ThemKhoaThi();
            c.ShowDialog();

            if (c.DialogResult == DialogResult.OK)
            {
                reloadData();
            }
            c.Dispose();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            XoaKhoaThi c = new XoaKhoaThi();
            c.ShowDialog();

            if (c.DialogResult == DialogResult.OK)
            {
                KhoaThiBUS model = new KhoaThiBUS();
                model.MaKhoaThi = dataGridView1.SelectedCells[0].Value.ToString();
                model.Delete();

                MessageBox.Show("Xóa thành công");
                reloadData();
            }
            c.Dispose();
        }
    }
}
