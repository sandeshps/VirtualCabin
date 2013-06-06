using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class employee_ViewProfile : System.Web.UI.Page
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
            lblFirstName.Text = reader.GetValue(1).ToString();
            lblLastName.Text = reader.GetValue(2).ToString();
            lblMailId.Text = reader.GetValue(3).ToString();
            lblAddress.Text = reader.GetValue(5).ToString();
            lblCountry.Text = reader.GetValue(6).ToString();
            lblState.Text = reader.GetValue(7).ToString();
            lblCity.Text = reader.GetValue(8).ToString();
            lblPhone.Text = reader.GetValue(9).ToString();
            ImgProfile.ImageUrl = reader.GetValue(10).ToString();
            ImgProfile.Visible = true;
            ImgProfile.Width = 100;
            ImgProfile.Height = 100;
        }
    }


}