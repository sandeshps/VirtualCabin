using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class employer_ProjectDetails : System.Web.UI.Page
{
    string query;
    string _title, _subject;
    database db = new database();
    SqlDataReader reader;
    static int count = 0, checkCount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            displayProjectDetail();
            listAllEmployees();
        }

    }


    // Display the Project title and description on label
    private void displayProjectDetail()
    {
        lblProjectTitle.Text = Session["ProjectTitle"].ToString();
        lblProjectTitle.Font.Bold = true;
        lblProjectTitle.Font.Size = 17;
        lblProjectTitle.ForeColor = System.Drawing.Color.BlueViolet;
        lblProjectDescription.Text = Session["ProjectDescription"].ToString();
        lblProjectDescription.Font.Size = 15;
    }


    


    // List out all the employees who have bid on the current employer's project
    private void listAllEmployees()
    {
        query = "select * from EmployeeProjects where Title='" + Session["ProjectTitle"].ToString() + "' AND Description='" + Session["ProjectDescription"].ToString() + "' AND Status<>'Selected' AND Status<>'Rejected' AND Status<>'Finished'";
        grdProjectDetails.DataSource = db.data_set(query);
        grdProjectDetails.DataBind();
        if (grdProjectDetails.Rows.Count == 0) // No Projects found in the database
        {
            btnSelect.Visible = false;
            btnReject.Visible = false;
            lblMessage.Text = "No employee has bid on this project";
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }
    }

    // Set all checked checkboxes to 'true'
    protected void chkSelect_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdProjectDetails.Rows)
        {
            CheckBox chkbox = ((CheckBox)row.FindControl("chkSelect"));
            if (chkbox.Checked == true)
            {
                ((CheckBox)row.FindControl("chkSelect")).Checked = true;
            }
            else
            {
                ((CheckBox)row.FindControl("chkSelect")).Checked = false;
            }
        }
    }

    // This module will select or reject employees
    protected void btnSelect_Click(object sender, EventArgs e)
    {        
        foreach (GridViewRow row in grdProjectDetails.Rows)
        {
            CheckBox chkbox = ((CheckBox)row.FindControl("chkSelect")); // To identify checkbox of a particular row 
            // If a particular row is checked, that user will be selected for the project
            if (chkbox.Checked == true)
            {
                _title = "Selected";
                _subject = "You have been selected for the project { " +lblProjectTitle.Text + " }";
                query = "update EmployeeProjects set Status='Selected' where Username='" + row.Cells[1].Text + "' AND Title='" + Session["ProjectTitle"].ToString() + "' AND Description='" + Session["ProjectDescription"].ToString() + "'";
                db.database_command(query);
                chkbox.Enabled = false; // Disable the checkbox for further checking 
                row.Cells[3].Text = "Selected"; // Update the status             
                row.ForeColor = System.Drawing.Color.Green; // Set the color of selected employee's row to green
                // Send message to the employee
                query = "insert into Communication (MessageTo,MessageFrom,Title,Subject,MessageDate,Status) values ('" + row.Cells[1].Text + "','" + Session["username"].ToString() + "','" + _title + "','" + _subject + "','" + DateTime.Now.ToString("MM/dd/yyyy") + "',0)";
                db.database_command(query);
                ++count;
            }           
        }
        if (count == 0) // Nothing has been selected
        {
            lblMessage.Text = "Please select";
        }
        else if (count == grdProjectDetails.Rows.Count)
        {
            lblMessage.Text = "No list for selection";
            btnSelect.Visible = false;
        }
    }

    // Rejection 
    protected void btnReject_Click(object sender, EventArgs e)
    {
         
        foreach (GridViewRow row in grdProjectDetails.Rows)
        {
            CheckBox chkbox = ((CheckBox)row.FindControl("chkSelect"));
            if (chkbox.Checked == true)
            {
                _title = "Rejected";
                _subject = "You have been rejected from the project { " + lblProjectTitle.Text + " }";
                query = "update EmployeeProjects set Status='Rejected' where Username='" + row.Cells[1].Text + "' AND Title='" + Session["ProjectTitle"].ToString() + "' AND Description='" + Session["ProjectDescription"].ToString() + "'";
                db.database_command(query);
                chkbox.Enabled = false;
                row.ForeColor = System.Drawing.Color.Red; // Set the color of rejected employee's row to red
                // Send message to the employee
                query = "insert into Communication (MessageTo,MessageFrom,Title,Subject,MessageDate,Status) values ('" + row.Cells[1].Text + "','" + Session["username"].ToString() + "','" + _title + "','" + _subject + "','" + DateTime.Now.ToString("MM/dd/yyyy") + "',0)";
                db.database_command(query);
                ++count;
            }
        }
        if (count == 0)
        {
            lblMessage.Text = "Please select";
        }
        else if (count == grdProjectDetails.Rows.Count)
        {
            lblMessage.Text = "No list for selection";
            btnSelect.Visible = false;
        }            
    }
}