using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class employee_Reply : System.Web.UI.Page
{
    database db = new database();
    string query;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFrom.Text = Session["username"].ToString();
            txtTo.Text = Session["To"].ToString();
            txtFrom.Enabled = false;
            txtTo.Enabled = false;
        }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtTo.Text.Trim() == "" || txtTitle.Text.Trim() == "" || txtSubject.Text.Trim() == "")
            {
                lblInfo.Text = "Some fields are missing";
            }
            else
            {
                query = "insert into Communication (MessageTo,MessageFrom,Title,Subject,MessageDate,Status) values ('" + txtTo.Text + "','" + txtFrom.Text + "','" + txtTitle.Text.Trim() + "','" + txtSubject.Text.Trim() + "','" + DateTime.Now.ToString("MM/dd/yyyy") + "',0)";
                db.database_command(query);
                lblInfo.Text = "Reply has been sent";
                lblInfo.ForeColor = System.Drawing.Color.Red;
                txtTitle.Text = txtSubject.Text = "";
            }
        }
        catch (Exception ex)
        {
        }

    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtTitle.Text = txtSubject.Text = "";
    }
}