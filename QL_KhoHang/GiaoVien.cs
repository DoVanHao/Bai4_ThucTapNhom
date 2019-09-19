using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Main
{
    public class GiaoVien
    {
        public Giao_Vien()
        {
            InitializeComponent();
        }

        GiaoVien gv = new GiaoVien();
        int chon;
        TimKiem tk = new TimKiem();


        public void KhoiTao()
        {
            txtHoTenGV.Enabled = txtLuong.Enabled = txtSDT.Enabled = cbGTGV.Enabled = cbMonHoc.Enabled = txtDiaChi.Enabled = false;
            dtpNgaySinhGV.Enabled = false;
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = true;
            btnLuu.Enabled = false;
        }

        public void Mo()
        {
            txtHoTenGV.Enabled = txtLuong.Enabled = txtSDT.Enabled = cbGTGV.Enabled = cbMonHoc.Enabled = txtDiaChi.Enabled = true;
            dtpNgaySinhGV.Enabled = true;
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = false;
            btnLuu.Enabled = true;
        }

        public void SetNull()
        {
            txtMaGV.Text = txtHoTenGV.Text = txtDiaChi.Text = txtLuong.Text = cbGTGV.Text = cbMonHoc.Text = cbTKGV.Text = txtTKGV.Text = txtSDT.Text = "";
            dtpNgaySinhGV.Text = DateTime.Now.ToShortDateString();
        }

        private void Giao_Vien_Load(object sender, EventArgs e)
        {
            KhoiTao();
            dgvGiaoVien.DataSource = gv.Show();

            cbMonHoc.DataSource = gv.LayThongTinMonHoc();
            cbMonHoc.DisplayMember = "TenMon";
            cbMonHoc.ValueMember = "MaMon";
            cbMonHoc.SelectedValue = "MaMon";
            chon = 0;
            string sql = "Xoa_HS";
            SqlConnection conn = new SqlConnection(ConnectDB.getconnect());
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaHS", MaHS);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }

        private void dgvGiaoVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaGV.Text = dgvGiaoVien.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtHoTenGV.Text = dgvGiaoVien.Rows[e.RowIndex].Cells[1].Value.ToString();
            cbGTGV.Text = dgvGiaoVien.Rows[e.RowIndex].Cells[2].Value.ToString();
            dtpNgaySinhGV.Text = dgvGiaoVien.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtDiaChi.Text = dgvGiaoVien.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSDT.Text = dgvGiaoVien.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtLuong.Text = dgvGiaoVien.Rows[e.RowIndex].Cells[6].Value.ToString();
            cbMonHoc.Text = dgvGiaoVien.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn muốn xóa Giáo viên này?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                gv.Xoa_GV(txtMaGV.Text);
                MessageBox.Show("Xóa thành công!");
                Giao_Vien_Load(sender, e);
                SetNull();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Mo();
            SetNull();
            txtTKGV.Enabled = cbTKGV.Enabled = true;
            chon = 1;
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            Giao_Vien_Load(sender, e);
            SetNull();
        }

       
        private void txtTKGV_TextChanged(object sender, EventArgs e)
        {
            if (cbTKGV.Text == "Mã")
                dgvGiaoVien.DataSource = tk.TK_Ma_GiaoVien(txtTKGV.Text);
            else
                dgvGiaoVien.DataSource = tk.TKTenGiaoVien(txtTKGV.Text);
        }
    }
}
