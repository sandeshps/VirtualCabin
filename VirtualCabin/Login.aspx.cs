using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    database db = new database();
    SqlDataReader reader;
    string query;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();  
        txtUsername.Focus();
    }
    
    protected void lnkRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registration.aspx");

    }



    protected void btnSignIn_Click(object sender, ImageClickEventArgs e)
    {
        if (txtUsername.Text.Trim() == "" || txtPassword.Text.Trim() == "")
            lblMessage.Text = "Both fields are required";
        else
        {
            query = "select usertype from Login where username='" + txtUsername.Text + "' AND Password='" + txtPassword.Text + "'";
            reader = db.data_read(query);
            if (reader.Read())
            {
                if (reader.GetString(0).Trim() == "Employee") // Go to employee's home page
                {
                    Session["username"] = txtUsername.Text;
                    reader.Close();
                    Response.Redirect("~/employee/EmployeeHome.aspx"); 
                }
                else if (reader.GetString(0).Trim() == "Employer")// Go to employer's home page
                {
                    Session["username"] = txtUsername.Text;
                    reader.Close();
                    Response.Redirect("~/employer/EmployerHome.aspx");
                }
                else // Go to admin's home page
                {
                    Session["username"] = txtUsername.Text;
                    Response.Redirect("~/admin/Home.aspx");
                }
            }
            else
            {
                lblMessage.Text = "Invalid Username/Password or no such user exists";
            }
        }
    }
}