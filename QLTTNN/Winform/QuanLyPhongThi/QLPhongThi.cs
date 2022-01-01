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
            XoaPhongThi c = new XoaPhongThi(dataGridView1.SelectedCells[0].Value.ToString());
            c.ShowDialog();

            if (c.DialogResult == DialogResult.OK)
            {
                //KhoaThiBUS model = new KhoaThiBUS();
                //model.MaKhoaThi = dataGridView1.SelectedCells[0].Value.ToString();
                //model.Delete();

                MessageBox.Show("Xóa thành công");
                reloadData();
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
    }
}
