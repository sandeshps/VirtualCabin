using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class employer_ViewProfile : System.Web.UI.Page
{
    database db = new database();
    SqlDataReader reader;
    string query;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadProfile();

        }

    }

    private void loadProfile()
    {
        query = "select * from Registration where username='" + Session["username"].ToString() + "'";
        reader = db.data_read(query);
        if (reader.Read())
        {
            lblUsername.Text = Session["username"].ToString();
            lblFirstName.Text = reader.GetString(1);
            lblLastName.Text = reader.GetString(2);
            lblMailId.Text = reader.GetString(3);
            lblAddress.Text = reader.GetString(5);
            lblCountry.Text = reader.GetString(6);
            lblState.Text = reader.GetString(7);
            lblCity.Text = reader.GetString(8);
            lblPhone.Text = reader.GetString(9);
            ImgProfile.ImageUrl = reader.GetString(10);
            ImgProfile.Visible = true;
            ImgProfile.Width = 100;
            ImgProfile.Height = 100;
        }
    }
}