using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class employer_ProjectsPosted : System.Web.UI.Page
{
    database db = new database();
    SqlDataReader reader;
    string query;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            listProjects();
            listProjectsOnStatus();
        }        
    }

    // Linkbutton will be deactivated for 'sealed' and 'cancelled' projects
    private void listProjectsOnStatus()
    {
        foreach (GridViewRow row in grdPostedProjects.Rows)
        {
            if (row.Cells[3].Text.Equals("Sealed") || row.Cells[3].Text.Equals("Cancelled"))
            {
                LinkButton lnk = (LinkButton)row.FindControl("lnkProject");
                row.ForeColor = System.Drawing.Color.Red;
                lnk.Enabled = false;
            }
        }
    }

    // List all the projects of the current employer
    private void listProjects()
    {
        query = "select * from Projects where Username='" + Session["username"].ToString() + "'";
        grdPostedProjects.DataSource = db.data_set(query);
        grdPostedProjects.DataBind();
        if (grdPostedProjects.Rows.Count == 0) // No projects found 
        {
            lblMessage.Text = "No Projects have been posted";
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }
    }


    protected void lnkProject_Click(object sender, EventArgs e)
    {
        LinkButton link = (LinkButton)sender;
        GridViewRow gvrow = (GridViewRow)(link.Parent.Parent);
        LinkButton project_title = (LinkButton)gvrow.FindControl("lnkProject");
        Session["ProjectTitle"] = project_title.Text;
        Session["ProjectDescription"] = gvrow.Cells[2].Text;
        Response.Redirect("ProjectDetails.aspx");
    }
}