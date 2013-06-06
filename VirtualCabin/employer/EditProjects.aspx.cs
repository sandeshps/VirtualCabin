using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class employer_EditProjects : System.Web.UI.Page
{
    string query, _title, _subject, messageQuery;
    database db = new database();
    SqlDataReader reader;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            listMyProjects();
        }
    }


    // List out the projects of the current user
    private void listMyProjects()
    {
        query = "select * from Projects where username='" + Session["username"].ToString() + "' AND status<>'Cancelled' AND status<>'Sealed'";
        grdEditProjects.DataSource = db.data_set(query);
        grdEditProjects.DataBind();
        if (grdEditProjects.Rows.Count == 0) // No projects found
        {
            lblMessage.Text = "No projects found";
            lblMessage.ForeColor = System.Drawing.Color.Red;
            btnOk.Visible = false;
        }
    }

    protected void grdEditProjects_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdEditProjects.PageIndex = e.NewPageIndex;
        listMyProjects();
    }


    
    protected void rdbtnStatus_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdEditProjects.Rows)
        {
            RadioButtonList rblist = (RadioButtonList)row.FindControl("rdbtnStatus");
            for (int i = 0; i < rblist.Items.Count; i++)
            {
                if (rblist.Items[i].Selected == true) // Sealed or cancelled ?
                {
                    query = "update Projects set Status='" + rblist.Items[i].Text + "' where Username='" + Session["username"].ToString() + "' AND Title='" + row.Cells[1].Text + "' AND Description='" + row.Cells[2].Text + "'";
                    db.database_command(query);
                    /* If a particular project has been cancelled, then the status of all the employees' of the same 
                     * project can be set to 'rejected' */
                    if (rblist.Items[i].Text.Equals("Cancelled"))
                    {
                        query = "update EmployeeProjects set Status='Rejected' where Title='" + row.Cells[1].Text + "' AND Description='" + row.Cells[2].Text + "'";
                        db.database_command(query);
                        //A message to all the users of the cancelled project
                        _title = "Cancelled";
                        _subject = "The project { " + row.Cells[1].Text + " } has been cancelled";
                        messageQuery = "select Username from EmployeeProjects where Title='"+row.Cells[1].Text+"' AND Description='"+row.Cells[2].Text+"' AND Status='Rejected'";
                        reader = db.data_read(messageQuery);
                        while (reader.Read())
                        {
                            query = "insert into Communication (MessageTo,MessageFrom,Title,Subject,MessageDate,Status) values ('" + reader.GetString(0) + "','" + Session["username"].ToString() + "','" + _title + "','" + _subject + "','" + DateTime.Now.ToString("MM/dd/yyyy") + "',0)";
                            db.database_command(query);
                        }

                       
                    }
                    /* If a particular project has been sealed, then the status of the employees who have 'pending' as 
                     * status, can be set to rejected */
                    if (rblist.Items[i].Text.Equals("Sealed"))
                    {
                        query = "update EmployeeProjects set Status='Rejected' where Title='" + row.Cells[1].Text + "' AND Description='" + row.Cells[2].Text + "' AND Status='Pending'";
                        db.database_command(query);
                        //A message to all Rejected users of the sealed project
                        _title = "Rejected";
                        _subject = "You have been rejected from the project { " + row.Cells[1].Text + " }";
                        messageQuery = "select Username from EmployeeProjects where Title='" + row.Cells[1].Text + "' AND Description='" + row.Cells[2].Text + "' AND Status='Rejected'";
                        reader = db.data_read(messageQuery);
                        while (reader.Read())
                        {
                            query = "insert into Communication (MessageTo,MessageFrom,Title,Subject,MessageDate,Status) values ('" + reader.GetString(0) + "','" + Session["username"].ToString() + "','" + _title + "','" + _subject + "','" + DateTime.Now.ToString("MM/dd/yyyy") + "',0)";
                            db.database_command(query);
                        }

                    }
                   
                }
            }
            row.ForeColor = System.Drawing.Color.Red; // Set the color of 'sealed' or 'cancelled' row to red
            rblist.Enabled = false; // Disable the radio-button-list of a particular row
        }
    }

}