using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Home : System.Web.UI.Page
{
    database db = new database();
    SqlDataReader reader;
    string query, tableTag = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        updates();
    }

    private void updates()
    {
        query = "select message from Updates";
        DataSet ds = db.data_set(query);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            tableTag = tableTag + ds.Tables[0].Rows[i][0].ToString();
            tableTag += "</br>";
            ltl.Text = tableTag.ToString();
        }
        //ltl.Text = tableTag.ToString();
    }


    protected void lnkSignIn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
    protected void lnkRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registration.aspx");
    }
}