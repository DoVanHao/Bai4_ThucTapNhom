using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;

namespace QL_KhoHang
{
    public partial class frmNhapXuat : Form
    {
        public frmNhapXuat()
        {
            InitializeComponent();
        }

        PhieuNhap pn = new PhieuNhap();
        ChiTietPhieuNhap ctpn = new ChiTietPhieuNhap();
        PhieuXuat px = new PhieuXuat();
        ChiTietPhieuXuat ctpx = new ChiTietPhieuXuat();
        private void frmNhapXuat_Load(object sender, EventArgs e)
        {
            dgvPN.DataSource = pn.ShowPN("");
            dgvCTPN.DataSource = ctpn.ShowCTPN("");
            dgvXuat.DataSource = px.ShowPX("");
            dgvCTXuat.DataSource = ctpx.ShowCTPX("");
        }

        private void btnThemPN_Click(object sender, EventArgs e)
        {
            frmThemPN frm = new frmThemPN();
            frm.Show();
        }

        private void btnThemPX_Click(object sender, EventArgs e)
        {
            frmThemPX frm = new frmThemPX();
            frm.Show();
        }

        private void btnRe_Click(object sender, EventArgs e)
        {
            frmNhapXuat_Load(sender, e);
        }

        private void btnReFresh_Click(object sender, EventArgs e)
        {
            frmNhapXuat_Load(sender, e);
        }

        private void dgvXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvCTXuat.DataSource = ctpx.HienThi(dgvXuat.Rows[e.RowIndex].Cells[1].Value.ToString());
        }

        private void dgvPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvCTPN.DataSource = ctpn.HienThi(dgvPN.Rows[e.RowIndex].Cells[1].Value.ToString());
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            dgvPN.DataSource = pn.HT_PN(dtp1.Text, dtp2.Text);
            dgvCTPN.DataSource = pn.HT_CTPN(dtp1.Text, dtp2.Text);
        }

        private void btnTKX_Click(object sender, EventArgs e)
        {
            dgvXuat.DataSource = px.HT_PX(dtp3.Text, dtp4.Text);
            dgvCTXuat.DataSource = px.HT_CTPX(dtp3.Text, dtp4.Text);
        }
        private void frmNhapXuat_change(object sender, EventArgs e)
        {
            dgvPN.DataSource = pn.ShowPN("");
            dgvCTPN.DataSource = ctpn.ShowCTPN("");
            dgvXuat.DataSource = px.ShowPX("");
            dgvCTXuat.DataSource = ctpx.ShowCTPX("");
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

        private void btnThemPN1_Click(object sender, EventArgs e)
        {
            frmThemPN frm = new frmThemPN();
            frm.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
