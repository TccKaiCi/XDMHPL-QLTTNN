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
    public partial class SuaPhongThi : Form
    {
        List<KhoaThiBUS> listKT;
        Dictionary<string, string> cbb;
        string maPhong, tenPhong;

        PhongThiBUS model;

        public SuaPhongThi(string key)
        {
            InitializeComponent();
            maPhong = key;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void SuaPhongThi_Load(object sender, EventArgs e)
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

            model = PhongThiBUS.getObj_Ma(PhongThiBUS.GetAll(), maPhong);

            tenPhong = model.TenPhongThi;

            textBox1.Text = model.TenPhongThi;
            textBox_So.Text = model.SoLuong.ToString();
            comboBox1.SelectedValue = model.MaKhoaThi;

            string[] arr = tenPhong.Split('P');
            tenPhong = arr[0];
            textBox_Ten.Text = arr[1];
        }

        private void textBox_So_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox_Ten_KeyUp(object sender, KeyEventArgs e)
        {
            textBox1.Text = tenPhong + "P" + textBox_Ten.Text;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (
                CacHamCheck.isText_NULL(textBox_Ten.Text)|| 
                CacHamCheck.isText_NULL(textBox_So.Text)|| 
                CacHamCheck.isText_NULL(textBox_So.Text) )
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông itn");
            } else
            {
                PhongThiBUS model = new PhongThiBUS();
                
                model.MaPhongThi = maPhong;
                model.TenPhongThi = textBox1.Text;
                model.SoLuong = Int32.Parse(textBox_So.Text);
                model.MaKhoaThi = comboBox1.SelectedValue.ToString();

                model.Update();
                DialogResult = DialogResult.OK;

            }
        }

    }
}
