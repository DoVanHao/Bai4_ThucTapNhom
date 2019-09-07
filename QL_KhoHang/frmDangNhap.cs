using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using BusinessLogic;
namespace QL_KhoHang
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        DangNhap dn = new DangNhap();

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (dn.DangNhapHT(txtUserName.Text, txtPass.Text) == true)
            {
                // bool x = false;
                MessageBox.Show("Bạn đăng nhập thành công ^^", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Main frm1 = new Main();
                frm1.Show();
                Hide();
            }
            else MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai. Mời bạn nhập lại !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ban có chắc muốn thoát ??", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Close();
        }


        private void frmDangNhap_Load(object sender, EventArgs e)
        {
           
        }
    }
}
