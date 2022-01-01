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
    public partial class ThemKhoaThi : Form
    {
        string maKhoaThi = KhoaThiBUS.getRandomMa();

        public ThemKhoaThi()
        {
            InitializeComponent();
        }

        private void ThemKhoaThi_Load(object sender, EventArgs e)
        {
            textBox_Ma.Text = maKhoaThi;
        }

        private void textBox_HT_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (
                CacHamCheck.isText_NULL(textBox_KT.Text) ||
                CacHamCheck.isText_NULL(textBox_TT.Text) ||
                CacHamCheck.isText_NULL(textBoxCT.Text)
                ) {
                MessageBox.Show("Vui lòng điền đủ thông tin");
            }
            else
            {
                KhoaThiBUS model = new KhoaThiBUS();

                model.MaKhoaThi = textBox_Ma.Text;
                model.TenKhoaThi = textBox_KT.Text;
                model.CaThi = textBoxCT.Text;
                model.TrinhDo = textBox_TT.Text;
                model.NgayThi = dateTimePicker1.Value;


                if (model.Insert())
                {
                    MessageBox.Show("Them thanh cong");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Them that bai:\n");
                    DialogResult = DialogResult.Cancel;

                }
            }
        }

        private void textBox_TT_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox_TT_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void textBox_TT_KeyUp(object sender, KeyEventArgs e)
        {
            textBox_Ma.Text = maKhoaThi + textBox_TT.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
