using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


public partial class employee_EmployeeHome : System.Web.UI.Page
{
    string username, _usernameOriginal, query;
    SqlDataReader reader;
    database db = new database();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();  
        username = Session["username"].ToString();
        _usernameOriginal = Session["username"].ToString(); // For database interaction
        if (!IsPostBack)
        {
            displayWelcomeMessage();
            PendingProjectsCount();
            unreadMessages();
            loadPhoto();
        }
        
    }

    


    



    // Convert the first letter of a string to uppercase
    private string toUpper(string str)
    {
        char[] array = str.ToCharArray();
        array[0] = char.ToUpper(array[0]);
        return new string(array);


    }

    private void displayWelcomeMessage()
    {
        lblUsername.Text = toUpper(username);
    }



    private void loadPhoto()
    {
        query = "select Logo from Registration where username='" + Session["username"].ToString() + "'";
        reader = db.data_read(query);
        if (reader.Read())
        {
            imgProfilePhoto.ImageUrl = reader.GetValue(0).ToString();
        }
    }
    

    // Count how many pending projects
    private void PendingProjectsCount()
    {
        query = "select COUNT(Status) as Status from EmployeeProjects where Username='" + _usernameOriginal + "' AND Status='Pending'";
        reader = db.data_read(query);
        if (reader.Read())
        {
            lblPendingCount.Text = reader.GetInt32(0) + " unfinished project(s)";
        }
    }

    private void unreadMessages()
    {
        query = "select COUNT(Status) as Status from Communication where MessageTo='" + Session["username"].ToString() + "' AND Status=0";
        reader = db.data_read(query);
        if (reader.Read())
        {
            lblMessages.Text = reader.GetInt32(0) + " new message(s)";
        }
    }


}