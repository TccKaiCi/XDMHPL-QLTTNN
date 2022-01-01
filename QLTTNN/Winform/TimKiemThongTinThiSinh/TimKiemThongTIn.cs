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

namespace Winform.TimKiemThongTinThiSinh
{
    public partial class TimKiemThongTIn : Form
    {

        List<ThiSinhBUS> listTS;

        public TimKiemThongTIn()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 c = new Form1();
            this.Hide();
            c.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CacHamCheck.isText_NULL(textBox1.Text) ||
            CacHamCheck.isText_NULL(textBox2.Text))
                {
                MessageBox.Show("Vui lòng điển đầy đủ thông tin");
                } else
            {
                listTS = ThiSinhBUS.findBy_HoTen_SDT_LIST(ThiSinhBUS.getAllStatic(), textBox1.Text, textBox2.Text);

                dataGridView1.DataSource = listTS;

                dataGridView1.Columns["CMND"].Visible = false;
                dataGridView1.Columns["SDT"].Visible = false;
                dataGridView1.Columns["NgaySinh"].Visible = false;
                dataGridView1.Columns["MaKhoaThi"].Visible = false;
                dataGridView1.Columns["NoiSinh"].Visible = false;

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
    }
}
