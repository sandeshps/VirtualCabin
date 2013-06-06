using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class admin_ProjectMessages : System.Web.UI.Page
{
    database db = new database();
    SqlDataReader reader;
    int count, return_count;
    string query;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load();
        }

    }



    private void load()
    {
        lblUsername.Text = Session["username"].ToString();
        lblTitle.Text = Session["title"].ToString();
        lblPeriod.Text = Session["period"].ToString();
        lblPostDate.Text = Session["postdate"].ToString();
    }

    private int AutoGeneration()
    {
        query = "select MAX(Id) as Id from ProjectMessage";
        reader = db.data_read(query);
        while (reader.Read())
        {
            if (reader.IsDBNull(0))
            {
                count = 1;
                return_count = count;
            }
            else
            {
                int c = int.Parse(reader["Id"].ToString());
                return_count = c + 1;
            }
        }
        return return_count;
    }





    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtMessage.Text.Trim() == "")
            {
                lblTextRequired.Text = "This field is must";
                lblTextRequired.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                query = "insert into ProjectMessage (Id,UserName,Message,MessageDate) values (" + AutoGeneration() + ",'" + lblUsername.Text + "','" + txtMessage.Text + "','" + DateTime.Now.ToString("MM/dd/yyyy") + "')";
                db.database_command(query);
                lblMessageSent.Text = "Message sent to " + lblUsername.Text + "";
                query = "insert into Communication (MessageTo,MessageFrom,Title,Subject,MessageDate,Status) values ('" + lblUsername.Text + "','admin','" + lblTitle.Text + "','" + "'Warning message about the above mentioned project'" + "','" + DateTime.Now.ToString("MM/dd/yyyy") + "',0)";
                db.database_command(query);
                txtMessage.Enabled = false;
                btnSend.Enabled = false;
            }
        }
        catch (Exception ex)
        {
        }
    }
}