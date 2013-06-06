using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class employer_RateProjects : System.Web.UI.Page
{
    database db = new database();
    string query;
    int count = 0;
    static string title, description;
    string _title, _subject;
    SqlDataReader reader;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            listAllSelectedProjects();
        }
    }


    // This will list all the selected projects 
    private void listAllSelectedProjects()
    {
        query = "select Title,Description from Projects where Username='" + Session["username"].ToString() + "'";
        reader = db.data_read(query);
        while (reader.Read())
        {
            title = reader.GetString(0);
            description = reader.GetString(1);
            query = "select * from EmployeeProjects where Title='" + title + "' AND Description='" + description + "' AND Status='Selected'";
            grdRateProjects.DataSource = db.data_set(query);
            grdRateProjects.DataBind();
        }
        if (grdRateProjects.Rows.Count == 0) // No selected projects found in the database
        {
            lblNoProjects.Text = "No Selected projects found";
            lblNoProjects.ForeColor = System.Drawing.Color.Red;
            btnSubmit.Visible = false;
        }
    }


    // Determine which value is selected in each of the radio-button-list
    protected void rdbtnRateList_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdRateProjects.Rows)
        {
            RadioButtonList list = (RadioButtonList)row.FindControl("rdbtnRateList");
            for (int i = 0; i < list.Items.Count; i++)
            {
                if (list.Items[i].Selected == true)
                {
                    ((RadioButtonList)row.FindControl("rdbtnRateList")).Items[i].Selected = true;
                }
            }
        }
    }

    // Convert a status of a project from 'Selected' to 'Finished'
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdRateProjects.Rows)
        {
            RadioButtonList list = (RadioButtonList)row.FindControl("rdbtnRateList");
            for (int i = 0; i < list.Items.Count; i++)
            {
                if (list.Items[i].Selected == true)
                {
                    query = "update EmployeeProjects set Status='Finished',Rating='" + list.Items[i].Text + "' where username='" + row.Cells[1].Text + "' AND title='" + row.Cells[2].Text + "' AND description='" + row.Cells[3].Text + "' AND status='Selected'";
                    db.database_command(query);
                    _title = "Finished";
                    _subject = "You have finshed the project {" + row.Cells[2].Text + "} with " + list.Items[i].Text + " rating";
                    query = "insert into Communication (MessageTo,MessageFrom,Title,Subject,MessageDate,Status) values ('" + row.Cells[1].Text + "','" + Session["username"].ToString() + "','" + _title + "','" + _subject + "','" + DateTime.Now.ToString("MM/dd/yyyy") + "',0)";
                    db.database_command(query);
                    row.Visible = false;
                    // Check how many rows are visible. If zero, then disable the button
                    foreach (GridViewRow vrow in grdRateProjects.Rows)
                    {
                        if (vrow.Visible == true)
                        {
                            ++count;
                            break;
                        }
                    }
                    if (count == 0) // No visible rows, make gridview invisible
                    {
                        grdRateProjects.Visible = false;
                        lblNoProjects.Text = "Data empty";
                        lblNoProjects.ForeColor = System.Drawing.Color.Red;
                        btnSubmit.Visible = false;
                    }
                }
            }
        }
    }
}