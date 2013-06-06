using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Registration : System.Web.UI.Page
{
    SqlDataReader reader;
    string query_registration;
    string query_login;
    string query_username_check;
    database db = new database();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();  
        
    }


    private void setCalendar()
    {
        
    }


    protected void btnRegister_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtPassword.Text.Trim() == "" || txtCPassword.Text.Trim() == "")
            {
                lblInfo.Text = "Some fields are missing";
            }
            else
            {
                query_username_check = "select username from Registration where username='" + txtUserName.Text + "'";
                reader = db.data_read(query_username_check);
                if (reader.Read()) // Username already exists
                {
                    lblUsername.Text = "Username already exists";
                }
                else // Username available. Proceed with registration
                {
                    query_registration = "insert into Registration (Username,FirstName,LastName,DOB) values('" + txtUserName.Text + "','" + txtLastName.Text + "','" + txtLastName.Text + "','" + txtDob.Text + "')";
                    db.database_command(query_registration);
                    query_login = "insert into Login (UserName,Password,UserType) values('" + txtUserName.Text + "','" + txtPassword.Text + "','" + drpUserType.SelectedValue.ToString() + "')";
                    db.database_command(query_login);
                    Response.Redirect("Login.aspx");
                }
            }
        }
        catch (Exception ex)
        {
        }


    }
    protected void lnkLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

    private void usernameCheck() // Check whether the username already exists in the database or not
    {
        query_username_check = "select username from Registration where username='" + txtUserName.Text + "'";
        reader = db.data_read(query_username_check);
        if (reader.Read()) // Username already exists
        {
            lblUsername.Text = "Username already exists";
        }
        else // Username available
        {
            lblUsername.Text = "Username available";
        }
    }
    

    protected void txtUserName_TextChanged(object sender, EventArgs e)
    {
        usernameCheck();
    }

}