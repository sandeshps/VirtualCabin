using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class employer_Inbox : System.Web.UI.Page
{
    string query;
    SqlDataReader reader;
    database db = new database();
    static int count = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            inbox();
        }
    }
    private void inbox()
    {
        try
        {
            query = "select * from Communication where MessageTo='" + Session["username"].ToString() + "'";
            grdInbox.DataSource = db.data_set(query);
            grdInbox.DataBind();
            if (grdInbox.Rows.Count == 0)
            {
                chkSelectAll.Visible = false;
                lnkDelete.Visible = false;
                lblMessage.Text = "Inbox empty";
                lblMessage.ForeColor = System.Drawing.Color.Blue;
                lblMessage.Font.Bold = true;
            }
            else
            {
                foreach (GridViewRow row in grdInbox.Rows) // Highlight unread mails
                {
                    LinkButton btn = (LinkButton)row.FindControl("lnkTitle");
                    query = "select Status from Communication where MessageFrom='" + row.Cells[1].Text + "' AND MessageTo='" + Session["username"].ToString() + "' AND Title='" + btn.Text + "'";
                    reader = db.data_read(query);
                    while (reader.Read())
                    {
                        if (reader.GetInt32(0) == 0) // Mail not checked yet
                        {
                            row.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
        }
        catch (Exception exptn)
        {
        }

    }

    private void checkedToTrue()
    {
        foreach (GridViewRow row in grdInbox.Rows)
        {
            CheckBox chkbox = ((CheckBox)row.FindControl("chkSelect"));
            if (chkbox.Checked == true)
            {
                ((CheckBox)row.FindControl("chkSelect")).Checked = true;
            }
        }
    }

    //protected void chkSelect_CheckedChanged(object sender, EventArgs e)
    //{
    //    checkedToTrue();
    //}

    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        if (chkSelectAll.Checked == true)
        {
            foreach (GridViewRow row in grdInbox.Rows)
            {
                ((CheckBox)row.FindControl("chkSelect")).Checked = true;  
            }
        }
        else
        {
            foreach (GridViewRow row in grdInbox.Rows)
            {
                ((CheckBox)row.FindControl("chkSelect")).Checked = false;
            }
        }
       // checkedToTrue();
    }
    // Delete mails
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        //checkedToTrue();
        /* Go through each row and find which rows have been checked. 
         * Delete all the checked rows */

        foreach (GridViewRow row in grdInbox.Rows)
        {
            LinkButton lnk=(LinkButton)row.FindControl("lnkTitle");
            CheckBox chkbox = (CheckBox)row.FindControl("chkSelect");
            if (chkbox.Checked == true)
            {
                query = "delete from Communication where MessageTo='" + Session["username"].ToString() + "'AND MessageFrom='" + row.Cells[1].Text + "' AND Title='" + lnk.Text + "'";
                db.database_command(query);
                row.Visible = false;
                ++count;
            }
        }
        if (count == grdInbox.Rows.Count)
        {
            lblMessage.Text = "All mails have been deleted";
            grdInbox.Visible = false;
            lnkDelete.Visible = false;
            chkSelectAll.Visible = false;
        }
    }

    // To go to Mail.aspx
    protected void lnkTitle_Click(object sender, EventArgs e)
    {
        LinkButton link = (LinkButton)sender;
        GridViewRow gvrow = (GridViewRow)(link.Parent.Parent);
        LinkButton project_title = (LinkButton)gvrow.FindControl("lnkTitle");
        Session["Title"] = project_title.Text;
        Session["From"] = gvrow.Cells[1].Text;
        Session["Date"] = gvrow.Cells[4].Text;
        query = "select Subject from Communication where MessageFrom='" + gvrow.Cells[1].Text + "' AND Title='" + project_title.Text + "' AND MessageTo='" + Session["username"].ToString() + "'";
        reader = db.data_read(query);
        if (reader.Read())
        {
            Session["Subject"] = reader.GetString(0);
        }
        Response.Redirect("Mail.aspx");
    }

}