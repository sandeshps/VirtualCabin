using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class employee_ViewProject : System.Web.UI.Page
{
    string skills, skillsOfUser = null;
    string[] skillset = new string[100];
    string[] skillsInProject = new string[100];
    string description;
    string query, projectTitle, status;
    int count = 0, bidCount, projectCount, employeeProjectCount;
    SqlDataReader reader;
    database db = new database();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadProject();
            displayProjectBids();
            checkBidder();
            checkIfProjectFinished();

        }
        displayProjectBids();
    }





    // This function will display all the project details on to the page 
    protected void loadProject()
    {
        projectTitle = Session["Project"].ToString(); // Common from MyProjects.aspx and SelectProject.aspx
        description = Session["Description"].ToString(); // From MyProjects.aspx
        query = "select Title,Description,Skills,convert(varchar(10),PostDate,103)as PostDate,Bids from Projects where Title='" + projectTitle + "' AND Description='" + description + "'";
        reader = db.data_read(query);
        if (reader.Read())
        {
            lblTitle.Text = projectTitle;
            lblDescription.Text = Session["Description"].ToString();
            lblBids.Text = reader["Bids"].ToString();
            skills = reader["Skills"].ToString();
            lblSkills.Text = skills;
            lblPostDate.Text = reader["PostDate"].ToString();
        }
        query = "select SkillName from EmployeeSkills where Username='" + Session["username"].ToString() + "'";
        reader = db.data_read(query);
        while (reader.Read())
        {
            skillsOfUser = skillsOfUser + reader.GetString(0);
        }
        skillset = skillsOfUser.Split(',');
        skillsInProject = lblSkills.Text.Split(',');
        // This will check each skill the project requires with the skills of the user
        for (int i = 0; i < skillsInProject.Length; i++)
        {
            for (int j = 0; j < skillset.Length; j++)
            {
                if (skillsInProject[i].Equals(skillset[j]))
                {
                    ++count;
                }
            }
        }
        // User doesn't have the required skills to proceed with the project
        if (count < skillsInProject.Length)
        {
            btnPostBid.Enabled = false;
            txtComment.Enabled = false;
            lblSkillsMessage.Text = "You don't have the required skills";

        }

    }


    // This will check whether the current user has already placed the bid
    private void checkBidder()
    {
        query = "select Username,Title,Description from EmployeeProjects where Username='" + Session["username"].ToString() + "' AND Title='" + lblTitle.Text + "' AND Description='" + lblDescription.Text + "'";
        reader = db.data_read(query);
        if (reader.Read()) // The user has already placed the bid. Disable the button
        {
            lblBidStatus.Text = "You have already placed the bid";
            lblBidStatus.ForeColor = System.Drawing.Color.Red;
            txtComment.Enabled = false;
            btnPostBid.Enabled = false;
        }
    }

    // Check if the status of a particular project is 'Finished' or not. If it is finished disable bidding button
    private void checkIfProjectFinished()
    {
        query = "select Status from EmployeeProjects where username='" + Session["username"].ToString() + "' AND Title='" + lblTitle.Text + "' AND Description='" + lblDescription.Text + "'";
        reader = db.data_read(query);
        if (reader.Read())
        {
            if (reader.GetString(0).Equals("Finished"))
            {
                lblBidStatus.Text = "You have finished this project";
                lblBidStatus.ForeColor = System.Drawing.Color.Red;
                txtComment.Enabled = false;
                btnPostBid.Enabled = false;
            }
        }
    }







    // Display all users who have bid on the current project
    private void displayProjectBids()
    {
        query = "select * from EmployeeProjects where Title='" + lblTitle.Text + "' AND Description='" + lblDescription.Text + "' AND Status<>'Finished'" + "";
        grdProjects.DataSource = db.data_set(query);
        grdProjects.DataBind();
        foreach (GridViewRow row in grdProjects.Rows) // Highlight the current user's project details
        {
            if (row.Cells[1].Text.Equals(Session["username"].ToString()))
            {
                row.ForeColor = System.Drawing.Color.Red;
            }
        }
    }


    // Check the number of bids in the database of a particular project
    private int _bidCount()
    {
        query = "select Bids from Projects where Title='" + lblTitle.Text + "' AND Description='" + lblDescription.Text + "'";
        reader = db.data_read(query);
        if (reader.Read())
        {
            if (reader.IsDBNull(0))
            {
                bidCount = 1;
            }
            else
            {
                bidCount = reader.GetInt32(0);
                bidCount = bidCount + 1;
            }
        }
        return bidCount;
    }


    private int AutoGeneration()
    {
        int return_count = 0;
        query = "select MAX(Id) as Id from EmployeeProjects";
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

    // Check for project limit. If the limit has reached, set the status of the project as 'Sealed'
    //private void checkLimitOfProject()
    //{
    //    query = "select EmployeeCount from Projects where Title='" + lblTitle.Text + "' AND Description='" + lblDescription.Text + "'";
    //    reader = db.data_read(query);
    //    if (reader.Read())
    //    {
    //        projectCount = reader.GetInt32(0);
    //    }
    //    query = "select COUNT(Status) as Status from EmployeeProjects where Title='" + lblTitle.Text + "' AND Description='" + lblDescription.Text + "'";
    //    reader = db.data_read(query);
    //    if (reader.Read())
    //    {
    //        employeeProjectCount = reader.GetInt32(0);
    //    }
    //    if (projectCount == employeeProjectCount) // Limit reached. Set status of project as 'Sealed'
    //    {
    //        query = "update Projects set Status='Sealed' where Title='" + lblTitle.Text + "' AND Description='" + lblDescription.Text + "'";
    //        db.database_command(query);
    //    }
    //}



    protected void btnPostBid_Click(object sender, EventArgs e)
    {
        try
        {
            query = "update Projects set Bids=" + _bidCount() + " where Title='" + lblTitle.Text + "' AND Description='" + lblDescription.Text + "'";
            db.database_command(query);
            status = "Pending";
            query = "insert into EmployeeProjects (Id,Username,Title,Description,BidDate,Status,Message) values (" + AutoGeneration() + ",'" + Session["username"].ToString() + "','" + lblTitle.Text + "','" + lblDescription.Text + "','" + DateTime.Now.ToString("MM/dd/yyyy") + "','" + status + "','" + txtComment.Text + "')";
            db.database_command(query);
            lblBidStatus.Text = "Bidding Successfull";
            btnPostBid.Enabled = false; // To avoid bidding multiple times
            txtComment.Text = ""; // Clear the TextBox
            txtComment.Enabled = false; // Disable the TextBox
            //checkLimitOfProject();
            displayProjectBids();

        }
        catch (Exception ex)
        {
        }

    }
}