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
    public partial class ThemPhongThi : Form
    {
        List<KhoaThiBUS> listKT;

        Dictionary<string, string> cbb;


        public ThemPhongThi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void textBox_TT_KeyPress(object sender, KeyPressEventArgs e)
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

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (
                CacHamCheck.isText_NULL(textBox_Ten.Text) ||
                CacHamCheck.isText_NULL(textBox_So.Text)
                )
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            } else
            {
                PhongThiBUS model = new PhongThiBUS();

                //Tên trình độ + P+ số TT
                model.TenPhongThi = KhoaThiBUS.getTrinhDo_Ma(listKT, comboBox1.SelectedValue.ToString()) + "P"+ textBox_Ten.Text;
                model.SoLuong = Int32.Parse( textBox_So.Text );
                model.MaKhoaThi = comboBox1.SelectedValue.ToString();

                if (model.Insert())
                {
                    DialogResult = DialogResult.OK;
                } else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
        }

        private void ThemPhongThi_Load(object sender, EventArgs e)
        {
            listKT = KhoaThiBUS.getAllStatic();

            // GIOI TINH
            cbb = new Dictionary<string, string>();

            for (int i = 0; i < listKT.Count; i++)
            {
                KhoaThiBUS a = listKT[i];

                cbb.Add(a.MaKhoaThi, a.TenKhoaThi);
            }
            comboBox1.DataSource = new BindingSource(cbb, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";

            comboBox1.SelectedIndex = 0;
        }

        private void textBox_Ten_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Ten_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
