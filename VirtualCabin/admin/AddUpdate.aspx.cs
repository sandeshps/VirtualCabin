using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_AddUpdate : System.Web.UI.Page
{
    database db = new database();
    string query;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (txtUpdate.Text.Trim() == "")
        {
            lblMessage.Text = "Can't be blank";
        }
        else
        {
            query = "insert into Updates (message) values ('" + txtUpdate.Text.Trim() + "')";
            db.database_command(query);
            txtUpdate.Text = "";
        }

    }
}