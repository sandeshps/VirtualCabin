using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class employee_SelectProject : System.Web.UI.Page
{
    database db = new database();
    SqlDataReader reader;
    string query, skillsOfUser = null;
    int i = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            checkForSkills();
            loadProjects();
            //employeeCount();
            listProjectsOnStatus();

        }
    }


    // Load all the projects 
    private void loadProjects()
    {
        query = "select * from Projects";
        grdSelectProject.DataSource = db.data_set(query);
        grdSelectProject.DataBind();
        if (grdSelectProject.Rows.Count == 0)
        {
            lblWarning.Text = "No projects found";
        }
    }

    // Check whether the new user has added any skills into his/her profile
    private void checkForSkills()
    {
        query = "select SkillName from EmployeeSkills where Username='" + Session["username"].ToString() + "'";
        reader = db.data_read(query);
        while (reader.Read())
        {
            skillsOfUser = skillsOfUser + reader.GetString(0);
        }
        if (skillsOfUser == null)
        {
            lblWarning.ForeColor = System.Drawing.Color.Red;
            lblWarning.Text = "You haven't added any skills yet. Please add skills";
            grdSelectProject.Enabled = false;
        }
    }

    protected void grdSelectProject_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdSelectProject.PageIndex = e.NewPageIndex;
        loadProjects();
    }


    // Linkbutton will be deactivated for 'sealed' and 'cancelled' projects
    private void listProjectsOnStatus()
    {
        foreach (GridViewRow row in grdSelectProject.Rows)
        {
            LinkButton lnk = (LinkButton)row.FindControl("lnkProjectTitle");
            if (row.Cells[4].Text.Equals("Sealed") || row.Cells[4].Text.Equals("Cancelled"))
            {
                row.ForeColor = System.Drawing.Color.Red;
                lnk.Enabled = false;
            }
        }
    }


    // This will check the number of employees, and if it exceeds the employer limit, project can't be accessed
    //private void employeeCount()
    //{
    //    int count = 0, projectCount = 0;
    //    foreach (GridViewRow row in grdSelectProject.Rows)
    //    {
    //        LinkButton link = (LinkButton)row.FindControl("lnkProjectTitle");
    //        query = "select EmployeeCount from Projects where Title='" + link.Text + "' AND Description='" + row.Cells[2].Text + "'";
    //        reader = db.data_read(query);
    //        if (reader.Read())
    //        {
    //            count = reader.GetInt32(0); // Count of a particular project
    //        }
    //        if (count > 0) // Project accomodates limited number of employees
    //        {
    //            query = "select COUNT(Status) as Status from EmployeeProjects where Title='" + link.Text + "' AND Description='" + row.Cells[2].Text + "' AND Status='Selected'";
    //            reader = db.data_read(query);
    //            if (reader.Read()) // If the project has more number of employees
    //            {
    //                projectCount = reader.GetInt32(0); // Count of 'Selected' bids(Employees)
    //            }
    //            if (count > projectCount) // Limit has not exceeded
    //            {
    //                link.Enabled = true;
    //            }
    //            else // Limit exceeded. Project can't be accessible
    //            {
    //                link.Enabled = false;
    //                row.Cells[4].Text = "Maximum limit";
    //                row.ForeColor = System.Drawing.Color.BlueViolet;
    //            }
    //        }
    //    }
    //}


    protected void lnkProjectTitle_Click(object sender, EventArgs e)
    {
        //Session["Project_Title"] = grdSelectProject.Rows[grdSelectProject.SelectedRow.RowIndex].Cells[0].Text;
        LinkButton link = (LinkButton)sender;
        GridViewRow gvrow = (GridViewRow)(link.Parent.Parent);
        LinkButton project_title = (LinkButton)gvrow.FindControl("lnkProjectTitle");
        Session["Project"] = project_title.Text;
        Session["Description"] = gvrow.Cells[2].Text;
        Response.Redirect("ViewProject.aspx");
    }




}