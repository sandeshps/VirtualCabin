using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Compose : System.Web.UI.Page
{
    database db = new database();
    string query;
    protected void Page_Load(object sender, EventArgs e)
    {       
        if (!IsPostBack)
        {
            txtFrom.Text = Session["username"].ToString();
            txtFrom.Enabled = false; // Always disabled
            //if (Session["To"].ToString() != DBNull.Value) // From Mail.aspx.cs (btnReply)
            //{
            //    txtTo.Text = Session["To"].ToString();
            //    txtFrom.Text = Session["username"].ToString();
            //    txtTo.Enabled = false;
            //    txtFrom.Enabled = false;
            //}
        }

    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {

            if (txtTitle.Text.Trim() == "" || txtTo.Text.Trim() == "" || txtSubject.Text.Trim() == "")
            {
                lblInfo.Text = "Some fields are missing";
            }
            else
            {
                query = "insert into Communication (MessageTo,MessageFrom,Title,Subject,MessageDate,Status) values ('" + txtTo.Text.Trim() + "','" + txtFrom.Text.Trim() + "','" + txtTitle.Text.Trim() + "','" + txtSubject.Text.Trim() + "','" + DateTime.Now.ToString("MM/dd/yyyy") + "',0)";
                db.database_command(query);
                lblInfo.Text = "Message has been sent";
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
        txtFrom.Text = txtTo.Text = txtTitle.Text = txtSubject.Text = "";
    }
}