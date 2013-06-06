using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Sent : System.Web.UI.Page
{
    string query;
    database db = new database();
    int count = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadSentAll();
        }
    }
    private void loadSentAll()
    {
        query = "select * from Communication where MessageFrom='" + Session["username"].ToString() + "'";
        grdSent.DataSource = db.data_set(query);
        grdSent.DataBind();
        if (grdSent.Rows.Count == 0) // No sent mails
        {
            lblInfo.Text = "No sent mails";
            lnkDelete.Visible = false;
        }
    }


    protected void grdSent_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdSent.PageIndex = e.NewPageIndex;
        //grdEmployees.DataBind();
        loadSentAll();
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        // Go through each row and delete all the checked rows
        foreach (GridViewRow row in grdSent.Rows)
        {
            
            CheckBox chkbox = (CheckBox)row.FindControl("chkSentSelect");
            if (chkbox.Checked == true)
            {
                query = "delete from Communication where MessageFrom='" + Session["username"].ToString() + "' AND MessageTo='" + row.Cells[1].Text + "' AND Title='" + row.Cells[2].Text + "' AND Subject='" + row.Cells[3].Text + "'";
                db.database_command(query);
                row.Visible = false;
                ++count;
            }
        }
        if (count == grdSent.Rows.Count)
        {
            lblInfo.Text = "All mails have been deleted";
            grdSent.Visible = false;
        }
    }
    

    protected void chkSentSelect_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdSent.Rows)
        {
            CheckBox chkbox = ((CheckBox)row.FindControl("chkSentSelect"));
            if (chkbox.Checked == true)
            {
                ((CheckBox)row.FindControl("chkSentSelect")).Checked = true;
            }
            else
            {
                ((CheckBox)row.FindControl("chkSentSelect")).Checked = false;
            }
        }
    }
}