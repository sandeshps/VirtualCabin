using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

    public class database
    {
        public SqlConnection database_connect()
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\VirtualOffice.mdf;Integrated Security=True;user Instance=True");
            con.Open();
            return con;
        }
        public void database_command(string sql)
        { 
            SqlCommand cmd = new SqlCommand(sql, database_connect());
            cmd.ExecuteNonQuery();
        }
        public SqlCommand database_command_sqlcommand(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, database_connect());
            return cmd;
        }

        public SqlDataReader data_read(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, database_connect());
            return cmd.ExecuteReader();
        }
        public DataSet data_set(string sql)
        {
            SqlDataAdapter adp = new SqlDataAdapter(sql, database_connect());
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds;
        }
        public int ExecuteScalar(string sql)
        {

            SqlCommand cmd = new SqlCommand(sql, database_connect());
            return (Convert.ToInt32(cmd.ExecuteScalar()));

        }
        public string Scalar(string sql)
        {

            SqlCommand cmd = new SqlCommand(sql, database_connect());
            return Convert.ToString(cmd.ExecuteScalar());
        }



    }

