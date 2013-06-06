using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class admin_CancelProjects : System.Web.UI.Page
{
    string query, username;
    string date;
    database db = new database();
    SqlDataReader reader;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            startUp();
    }


    protected void chkdelete_CheckedChanged(object sender, EventArgs e)
    {
        //GridViewRow clickedRow = ((CheckBox)sender).NamingContainer as GridViewRow;
        foreach (GridViewRow row in grdCancelProjects.Rows)
        {
            CheckBox chkbox = ((CheckBox)row.FindControl("chkdelete"));
            if (chkbox.Checked == true)
                ((CheckBox)row.FindControl("chkdelete")).Checked = true;
            else
                ((CheckBox)row.FindControl("chkdelete")).Checked = false;
        }

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdCancelProjects.Rows)
        {
            CheckBox chkbox = ((CheckBox)row.FindControl("chkdelete"));
            if (chkbox.Checked) // code for deletion
            {
               
                query = "delete from Projects where username='" + row.Cells[1].Text + "' AND title='" + row.Cells[2].Text + "' AND description='" + row.Cells[3].Text + "'";
                db.database_command(query);
                row.Visible = false;
            }
        }
    }

    /* When the page is loaded, the automatic selection will be 'cancelled'. So we execute 
     * the code based on rejected projects */
    private void startUp()
    {
        query = "select * from Projects where status='Rejected'";
        grdCancelProjects.DataSource = db.data_set(query);
        grdCancelProjects.DataBind();
        if (grdCancelProjects.Rows.Count == 0)
        {
            lblInfo.Text = "No rejected projects found";
            btnDelete.Visible = false;
        }
    }


    protected void drpProjectCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpProjectCategory.Items[0].Selected == true)
        {
            query = "select * from Projects where status='Rejected'";
            grdCancelProjects.DataSource = db.data_set(query);
            grdCancelProjects.DataBind();
            if (grdCancelProjects.Rows.Count == 0)
            {
                lblInfo.Text = "No rejected projects found";
                btnDelete.Visible = false;
            }
        }
        else
        {
            query = "select MessageDate from ProjectMessage";
            reader = db.data_read(query);
            if (reader.Read())
            {
                date = reader.GetDateTime(0).ToString();
            }
            DateTime postedDate = DateTime.Parse(date);
            if ((DateTime.Now - postedDate).Days >= 3) // If the number of days is greater than or equal to 3
            {
                query = "select * from Projects where status='Approved'";
                grdCancelProjects.DataSource = db.data_set(query);
                grdCancelProjects.DataBind();
                if (grdCancelProjects.Rows.Count == 0)
                {
                    lblInfo.Text = "No time out projects found";
                    btnDelete.Visible = false;
                }
            }

        }
    }
}


