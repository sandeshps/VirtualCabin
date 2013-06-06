using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class employer_EmployerHome : System.Web.UI.Page
{
    database db = new database();
    SqlDataReader reader;
    string query;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            updates();
        }
    }

    

    private void updates()
    {
        try
        {
            lblUsername.Text = Session["username"].ToString();
            query = "select COUNT(Status) as Status from Communication where MessageTo='" + Session["username"].ToString() + "' AND Status=0";
            reader = db.data_read(query);
            if (reader.Read())
            {
                lblMessages.Text = reader.GetInt32(0) + " new message(s)";
            }
            // For displaying profile photo
            query = "select Logo from Registration where username='" + Session["username"].ToString() + "'";
            reader = db.data_read(query);
            if (reader.Read())
            {
                imgProfilePhoto.ImageUrl = reader.GetString(0);
            }
        }
        catch (Exception ex)
        {
        }
    }


   
}