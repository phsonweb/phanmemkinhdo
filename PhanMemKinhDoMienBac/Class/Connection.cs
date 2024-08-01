using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemKinhDoMienBac.Class
{
    public class Connection
    {
        public SqlConnection strConnect = new SqlConnection(@"Data Source=MSI\MAY1;Initial Catalog=PhanMemKinhDoMienBac;Integrated Security=True");
        public void Create_Connect()
        {
            //Mở kết nối
            strConnect.Open();
        }

        public SqlDataReader SelectSql(string sql)
        {
            Create_Connect();
            SqlCommand command = new SqlCommand
            {
                Connection = strConnect
            };
            // Câu truy vấn lấy danh mục
            string str = sql;
            command.CommandText = str;
            // Thi hành truy vấn trả về SqlReader
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }
    }
}
