using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BusinessLogic
{
    public class NhaCungCap
    {
        KetNoiDB da = new KetNoiDB();
        public DataTable ShowNCC(string DieuKien)
        {
            string sql = @"SELECT * FROM dbo.NHACUNGCAP " + DieuKien;
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(KetNoiDB.getconnect());
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            ad.Fill(dt);
            return dt;
        }
        
      
    }
}
