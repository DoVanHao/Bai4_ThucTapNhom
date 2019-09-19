using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BTL_QLNS.BUS;
namespace BTL_QLNS
{
    public partial class Quanlyduan : Form
    {
        public Quanlyduan()
        {
            InitializeComponent();
        }
        DuAn_BUS dab = new DuAn_BUS();
        private void btnExit_Click(object sender, EventArgs e)
        {
            ManHinhChinh frmmch = new ManHinhChinh();
            frmmch.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManHinhChinh frmmch = new ManHinhChinh();
            frmmch.Show();
            this.Hide();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvDuAn.DataSource=dab.Search(txtSearch.Text);
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            int sonv = 0;
            if (txtMaDA.Text.Trim() == "")
                MessageBox.Show("Mã dự án không được để trống !");
            else if (txtTenDA.Text.Trim() == "")
                MessageBox.Show("Tên dự án không được để trống !");
            else
                dab.insertDA(txtMaDA.Text, txtTenDA.Text, sonv, txtMotaDA.Text);
            Quanlyduan_Load(sender, e);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvDuAn.DataSource=dab.Search(txtSearch.Text);
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            int sonv = 0;
            if (txtMaDA.Text.Trim() == "")
                MessageBox.Show("Mã dự án không được để trống !");
            else if (txtTenDA.Text.Trim() == "")
                MessageBox.Show("Tên dự án không được để trống !");
            else
                dab.insertDA(txtMaDA.Text, txtTenDA.Text, sonv, txtMotaDA.Text);
            Quanlyduan_Load(sender, e);
        }
		        private void btnDangky_Click(object sender, EventArgs e)
        {
            User_BUS ub = new User_BUS();
            try
            {
                if (txtNhaplai.Text == txtMatkhau.Text)
                {
                    ub.insertUser(txtTaikhoan.Text, txtMatkhau.Text, txtMaNv.Text);
                    MessageBox.Show("Đăng ký tài khoản thành công !");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mật khẩu nhập lại không đúng !");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Bạn nhập sai cú pháp !");
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi kết nối CSDL!");
            }

        }
		        private void btnThemSP_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvSPX.Rows.Count; i++)
            {
                if (dgvSPX.Rows[i].Cells[0].Value == dgvSP.Rows[dgvSP.SelectedRows[0].Index].Cells[0].Value)
                {
                    MessageBox.Show("Sản phẩm đã được chọn !!!", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (dgvSP.SelectedRows.Count > 0)
            {
                dgvSPX.Rows.AddRange(new DataGridViewRow());
                dgvSPX.Rows[dgvSPX.RowCount - 2].Cells[0].Value = dgvSP.Rows[dgvSP.SelectedRows[0].Index].Cells[0].Value;
                dgvSPX.Rows[dgvSPX.RowCount - 2].Cells[1].Value = numericUpDownSL.Value;
                dgvSPX.Rows[dgvSPX.RowCount - 2].Cells[2].Value = numericUpDownGN.Value;
                dgvSPX.Rows[dgvSPX.RowCount - 2].Cells[3].Value = int.Parse(numericUpDownSL.Value.ToString()) * long.Parse(numericUpDownGN.Value.ToString());
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            int sonv = 0;
            if (txtMaDA.Text.Trim() == "")
                MessageBox.Show("Mã dự án không được để trống !");
            else if (txtTenDA.Text.Trim() == "")
                MessageBox.Show("Tên dự án không được để trống !");
            else
            {
                try
                {
                    dab.updateDA(txtMaDA.Text, txtTenDA.Text, int.Parse(txtSoNVDA.Text), txtMotaDA.Text);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Số nhân viên phải là kiểu số nguyên !" + ex.Message);
                }
            }
            Quanlyduan_Load(sender, e);
        }
		        private void btnDangky_Click(object sender, EventArgs e)
        {
            User_BUS ub = new User_BUS();
            try
            {
                if (txtNhaplai.Text == txtMatkhau.Text)
                {
                    ub.insertUser(txtTaikhoan.Text, txtMatkhau.Text, txtMaNv.Text);
                    MessageBox.Show("Đăng ký tài khoản thành công !");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mật khẩu nhập lại không đúng !");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Bạn nhập sai cú pháp !");
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi kết nối CSDL!");
            }

        }
		
private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String mapb, mada;
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaNv.Text = dgvNhanVien.Rows[row].Cells[0].Value.ToString();
                txtTenNv.Text = dgvNhanVien.Rows[row].Cells[1].Value.ToString();
                dtpNgaysinh.Text = dgvNhanVien.Rows[row].Cells[2].Value.ToString();
                txtDiachi.Text = dgvNhanVien.Rows[row].Cells[3].Value.ToString();
                txtLuong.Text = dgvNhanVien.Rows[row].Cells[4].Value.ToString();
                mapb = dgvNhanVien.Rows[row].Cells[5].Value.ToString();
                mada = dgvNhanVien.Rows[row].Cells[6].Value.ToString();
                cbxPhongban.Text = nvb.selectPB(mapb);
                cbxDuan.Text = nvb.selectDA(mada);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = nvb.Search(txtSearch.Text);
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtDiachi.Text = "";
            txtLuong.Text = "";
            txtMaNv.Text = "";
            txtSearch.Text = "";
            txtTenNv.Text = "";
        }
		
		        private void btnDangky_Click(object sender, EventArgs e)
        {
            User_BUS ub = new User_BUS();
            try
            {
                if (txtNhaplai.Text == txtMatkhau.Text)
                {
                    ub.insertUser(txtTaikhoan.Text, txtMatkhau.Text, txtMaNv.Text);
                    MessageBox.Show("Đăng ký tài khoản thành công !");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mật khẩu nhập lại không đúng !");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Bạn nhập sai cú pháp !");
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi kết nối CSDL!");
            }

        }

        private void ExportExcel(DataGridView dgv, string duongDan, string tenTap)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;

            // Lấy cái Header DataGridView
            for (int i = 1; i < dgv.Columns.Count + 1; i++)
            {
                obj.Cells[1, i] = dgv.Columns[i - 1].HeaderText;
            }
            //
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    if (dgv.Rows[i].Cells[j].Value != null)
                    {
                        obj.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            obj.ActiveWorkbook.SaveCopyAs(duongDan + tenTap + ".xlsx");
            obj.ActiveWorkbook.Saved = true;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            dab.deleteDA(txtMaDA.Text);
            Quanlyduan_Load(sender, e);
        }

        private void Quanlyduan_Load(object sender, EventArgs e)
        {
            dgvDuAn.DataSource = dab.getDUAN();
        }

        private void dgvDuAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaDA.Text = dgvDuAn.Rows[index].Cells[0].Value.ToString();
                txtTenDA.Text = dgvDuAn.Rows[index].Cells[1].Value.ToString();
                txtSoNVDA.Text = dgvDuAn.Rows[index].Cells[2].Value.ToString();
                txtMotaDA.Text = dgvDuAn.Rows[index].Cells[3].Value.ToString();
            }
        }
		        private void btnDangky_Click(object sender, EventArgs e)
        {
            User_BUS ub = new User_BUS();
            try
            {
                if (txtNhaplai.Text == txtMatkhau.Text)
                {
                    ub.insertUser(txtTaikhoan.Text, txtMatkhau.Text, txtMaNv.Text);
                    MessageBox.Show("Đăng ký tài khoản thành công !");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mật khẩu nhập lại không đúng !");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Bạn nhập sai cú pháp !");
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi kết nối CSDL!");
            }

        }
		// thêm
		private void dgvNhanVien_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            String mapb, mada;
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaNv.Text = dgvNhanVien.Rows[row].Cells[0].Value.ToString();
                txtTenNv.Text = dgvNhanVien.Rows[row].Cells[1].Value.ToString();
                dtpNgaysinh.Text = dgvNhanVien.Rows[row].Cells[2].Value.ToString();
                txtDiachi.Text = dgvNhanVien.Rows[row].Cells[3].Value.ToString();
                txtLuong.Text = dgvNhanVien.Rows[row].Cells[4].Value.ToString();
                mapb = dgvNhanVien.Rows[row].Cells[5].Value.ToString();
                mada = dgvNhanVien.Rows[row].Cells[6].Value.ToString();
                cbxPhongban.Text = nvb.selectPB(mapb);
                cbxDuan.Text = nvb.selectDA(mada);
            }
        }

        private void btnTim_Click_1(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = nvb.Search(txtSearch.Text);
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtDiachi.Text = "";
            txtLuong.Text = "";
            txtMaNv.Text = "";
            txtSearch.Text = "";
            txtTenNv.Text = "";
        }
		private void btnthem_Click_1(object sender, EventArgs e)
        {
            int sonv = 0;
            if (txtMaDA.Text.Trim() == "")
                MessageBox.Show("Mã dự án không được để trống !");
            else if (txtTenDA.Text.Trim() == "")
                MessageBox.Show("Tên dự án không được để trống !");
            else
                dab.insertDA(txtMaDA.Text, txtTenDA.Text, sonv, txtMotaDA.Text);
            Quanlyduan_Load(sender, e);
        }
		
    }
}
