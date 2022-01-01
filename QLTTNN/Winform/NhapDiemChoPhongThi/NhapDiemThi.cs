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
    public partial class NhapDiemThi : Form
    {
        List<ThiSinhBUS> listTS;
        List<PhongThiBUS> listPT = PhongThiBUS.GetAll();

        Dictionary<string, string> phongThi;

        public NhapDiemThi()
        {
            InitializeComponent();
        }

        private void NhapDiemThi_Load(object sender, EventArgs e)
        {
            readData();
            // GIOI TINH
            phongThi = new Dictionary<string, string>();

            for (int i = 0; i < listPT.Count; i++)
            {
                PhongThiBUS a = listPT[i];

                phongThi.Add(a.MaPhongThi, a.TenPhongThi);
            }
            comboBox1.DataSource = new BindingSource(phongThi, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";

            comboBox1.SelectedIndex = 0;
        }
        public void readData()
        {
            listTS = ThiSinhBUS.getAllStatic();

            dataGridView1.DataSource = listTS;

            dataGridView1.Columns["CaThi"].Visible = false;
            dataGridView1.Columns["CMND"].Visible = false;
            dataGridView1.Columns["SDT"].Visible = false;
            dataGridView1.Columns["NgaySinh"].Visible = false;
            dataGridView1.Columns["NoiSinh"].Visible = false;
            dataGridView1.Columns["ManPhongThi"].Visible = false;
            dataGridView1.Columns["MaKhoaThi"].Visible = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CacHamCheck.isText_NULL(textBox2.Text))
            {
                MessageBox.Show("Vui long nhap diem");
            } else
            {
                ThiSinhBUS model = new ThiSinhBUS();

                model.MaKhoaThi = PhongThiBUS.getMaKhoaThi_MaPhongThi(listPT, comboBox1.SelectedValue.ToString());
                model.diemDoc = Int32.Parse( textBox2.Text );
                model.diemNghe = Int32.Parse( textBox2.Text );
                model.diemNoi = Int32.Parse( textBox2.Text );
                model.diemViet = Int32.Parse( textBox2.Text );

                if (!model.UpdateDiem() )
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }


            listTS = null;
            listTS = ThiSinhBUS.findBy_MaPhongThi(ThiSinhBUS.getAllStatic(), comboBox1.SelectedValue.ToString());

            dataGridView1.DataSource = listTS;

            dataGridView1.Columns["CaThi"].Visible = false;
            dataGridView1.Columns["CMND"].Visible = false;
            dataGridView1.Columns["SDT"].Visible = false;
            dataGridView1.Columns["NgaySinh"].Visible = false;
            dataGridView1.Columns["NoiSinh"].Visible = false;
            dataGridView1.Columns["ManPhongThi"].Visible = false;
            dataGridView1.Columns["MaKhoaThi"].Visible = false;


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string maKhoaThi = comboBox1.SelectedValue.ToString();

            listTS = null;
            listTS = ThiSinhBUS.findBy_MaPhongThi(ThiSinhBUS.getAllStatic(), maKhoaThi);

            dataGridView1.DataSource = listTS;

            dataGridView1.Columns["CaThi"].Visible = false;
            dataGridView1.Columns["CMND"].Visible = false;
            dataGridView1.Columns["SDT"].Visible = false;
            dataGridView1.Columns["NgaySinh"].Visible = false;
            dataGridView1.Columns["NoiSinh"].Visible = false;
            dataGridView1.Columns["ManPhongThi"].Visible = false;
            dataGridView1.Columns["MaKhoaThi"].Visible = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void textBox2_MouseUp(object sender, MouseEventArgs e)
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
    }
}
