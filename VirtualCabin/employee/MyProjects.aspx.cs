using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class employee_MyProjects : System.Web.UI.Page
{
    database db = new database();
    string query;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();  
        if (!IsPostBack)
        {
            drpStatusTypeProjects.Items[0].Selected = true; // First item is selected at run time by default
            //listMyProjects();
            listProjectOnStatus();
        }

    }


    private void listMyProjects()
    {
        query = "select * from EmployeeProjects where Username='" + Session["username"].ToString() + "'";
        grdMyProjects.DataSource = db.data_set(query);
        grdMyProjects.DataBind();
    }



    // Select the appropriate project title and redirect to the project main page.

    protected void lnkProject_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdMyProjects.Rows)
        {
            LinkButton link = (LinkButton)sender;
            GridViewRow lnkrow = (GridViewRow)(link.Parent.Parent);
            LinkButton trow = ((LinkButton)lnkrow.FindControl("lnkProject"));
            Session["Project"] = trow.Text;
            Session["Description"] = lnkrow.Cells[2].Text;
            Response.Redirect("ViewProject.aspx");
        }
    }






    private void listProjectOnStatus()
    {
        lblInfo.Text = "";
        if (drpStatusTypeProjects.Items[0].Selected == true) // Pending projects
        {
            query = "select * from EmployeeProjects where Username='" + Session["username"].ToString() + "' AND Status='" + drpStatusTypeProjects.Items[0].Text + "'";
            grdMyProjects.DataSource = db.data_set(query);
            grdMyProjects.DataBind();
            if (grdMyProjects.Rows.Count == 0)
            {
                lblInfo.Text = "No Pending Projects";

            }
        }
        else if (drpStatusTypeProjects.Items[1].Selected == true) // Selected projects
        {
            query = "select * from EmployeeProjects where Username='" + Session["username"].ToString() + "' AND Status='" + drpStatusTypeProjects.Items[1].Text + "'";
            grdMyProjects.DataSource = db.data_set(query);
            grdMyProjects.DataBind();
            if (grdMyProjects.Rows.Count == 0)
            {
                lblInfo.Text = "No Selected Projects";

            }
        }
        else if (drpStatusTypeProjects.Items[2].Selected == true) // Rejected projects
        {
            query = "select * from EmployeeProjects where Username='" + Session["username"].ToString() + "' AND Status='" + drpStatusTypeProjects.Items[2].Text + "'";
            grdMyProjects.DataSource = db.data_set(query);
            grdMyProjects.DataBind();
            if (grdMyProjects.Rows.Count == 0)
            {
                lblInfo.Text = "No Rejected Projects";

            }

        }
        else // Finished projects
        {
            query = "select * from EmployeeProjects where Username='" + Session["username"].ToString() + "' AND Status='" + drpStatusTypeProjects.Items[3].Text + "'";
            grdMyProjects.DataSource = db.data_set(query);
            grdMyProjects.DataBind();
            if (grdMyProjects.Rows.Count == 0)
            {
                lblInfo.Text = "No Finished Projects";
            }
        }
    }




    // List out the projects based on the status
    protected void drpStatusTypeProjects_SelectedIndexChanged(object sender, EventArgs e)
    {
        listProjectOnStatus();
    }

    //protected void lnkdelete_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        LinkButton btn = (LinkButton)sender;
    //        GridViewRow row = (GridViewRow)(btn.Parent.Parent);
    //        LinkButton lbtn = ((LinkButton)row.FindControl("lnkProject"));
    //        query = "delete from EmployeeProjects where username='" + Session["username"].ToString() + "' AND Title='" + lbtn.Text + "' AND Description='" + row.Cells[2].Text + "'";
    //        db.database_command(query);
    //        row.Visible = false; // Make the deleted row invisible
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
}