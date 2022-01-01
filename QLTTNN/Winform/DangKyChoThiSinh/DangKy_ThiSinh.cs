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
    public partial class DangKy_ThiSinh : Form
    {
        List<GioiTinhBUS> listGT = GioiTinhBUS.getAllStatic();
        List<DiaDiemBUS> listDD = DiaDiemBUS.getAllStatic();
        List<KhoaThiBUS> listKT = KhoaThiBUS.getAllStatic();
        List<PhongThiBUS> listPT = PhongThiBUS.GetAll();

        Dictionary<string, string> gioiTinh, diaDiem, khoaThi;

        public DangKy_ThiSinh()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 c = new Form1();
            this.Hide();
            c.ShowDialog();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // SAVE
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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
            if (CacHamCheck.isText_NULL(textBox_CMT.Text) ||
                CacHamCheck.isText_NULL(textBox_HT.Text) ||
                CacHamCheck.isText_NULL(textBox_SDT.Text)
                )
            {
                MessageBox.Show("Vui lòng điền hết thông tin");
            } else
            {
                ThiSinhBUS thiSinh = new ThiSinhBUS();

                thiSinh.CMND = textBox_CMT.Text;
                thiSinh.HoTen = textBox_HT.Text;
                thiSinh.SDT = int.Parse(textBox_SDT.Text);

                thiSinh.GioiTinh = comboBox_GIOITINH.SelectedValue.ToString();
                thiSinh.NoiSinh = comboBox_NOISINH.SelectedValue.ToString();
                thiSinh.MaKhoaThi = comboBox_KHOATHI.SelectedValue.ToString();
                thiSinh.ManPhongThi = comboBox_PhongThi.SelectedValue.ToString();

                thiSinh.NgaySinh = dateTimePicker1.Value;

                if ( thiSinh.Insert() )
                    MessageBox.Show("Thêm thành công");
                else
                    MessageBox.Show("Thêm thất bại");
            }
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

        private void textBox_HT_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox_KHOATHI_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox_KHOATHI_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox_KHOATHI_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string maKhoaThi = comboBox_KHOATHI.SelectedValue.ToString();

            List<PhongThiBUS> temp = PhongThiBUS.getPhongThi_MaKhoaThi(listPT, maKhoaThi);

            Dictionary<string, string> phongThi = new Dictionary<string, string>();

            for (int i = 0; i < temp.Count; i++)
            {
                PhongThiBUS a = temp[i];

                phongThi.Add(a.MaPhongThi, a.TenPhongThi);
            }
            comboBox_PhongThi.DataSource = new BindingSource(phongThi, null);
            comboBox_PhongThi.DisplayMember = "Value";
            comboBox_PhongThi.ValueMember = "Key";

            comboBox_PhongThi.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DangKy_ThiSinh_Load(object sender, EventArgs e)
        {
            // GIOI TINH
            gioiTinh = new Dictionary<string, string>();

            for (int i = 0; i < listGT.Count; i++)
            {
                GioiTinhBUS a = listGT[i];

                gioiTinh.Add(a.GIOITINH, a.GIOITINH);
            }
            comboBox_GIOITINH.DataSource = new BindingSource(gioiTinh, null);
            comboBox_GIOITINH.DisplayMember = "Value";
            comboBox_GIOITINH.ValueMember = "Key";

            comboBox_GIOITINH.SelectedIndex = 0;

            // DIA DIEM
            diaDiem = new Dictionary<string, string>();

            for (int i = 0; i < listDD.Count; i++)
            {
                DiaDiemBUS a = listDD[i];

                diaDiem.Add(a.MaDiaDiem, a.TenDiaDiem);
            }
            comboBox_NOISINH.DataSource = new BindingSource(diaDiem, null);
            comboBox_NOISINH.DisplayMember = "Value";
            comboBox_NOISINH.ValueMember = "Key";

            comboBox_NOISINH.SelectedIndex = 0;

            // KHOA THI
            khoaThi = new Dictionary<string, string>();

            for (int i = 0; i < listKT.Count; i++)
            {
                KhoaThiBUS a = listKT[i];

                khoaThi.Add(a.MaKhoaThi, a.TenKhoaThi);
            }
            comboBox_KHOATHI.DataSource = new BindingSource(khoaThi, null);
            comboBox_KHOATHI.DisplayMember = "Value";
            comboBox_KHOATHI.ValueMember = "Key";

            comboBox_KHOATHI.SelectedIndex = 0;
        }
    }
}
