using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class admin_Home : System.Web.UI.Page
{
    database db = new database();
    SqlDataReader reader;
    string query;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            newMessages();
        }
    }

    private void newMessages()
    {
        query = "select COUNT(Status) as Status from Communication where MessageTo='admin' AND Status=0";
        reader = db.data_read(query);
        if (reader.Read())
        {
            lblMessages.Text = reader.GetInt32(0) + " new messages";
        }
    }

}