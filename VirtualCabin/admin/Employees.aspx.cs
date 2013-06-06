using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class admin_Employees : System.Web.UI.Page
{
    database db = new database();
    SqlDataReader reader, innerReader;
    string query, innerQuery;
    static int count = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load();
        }

    }

   

    private void load()
    {
        SqlDataAdapter sda;
        DataSet ds = new DataSet();
        query = "select Username from Login where UserType='Employee'";
        reader = db.data_read(query);
        while (reader.Read())
        {
            innerQuery = "select * from Registration where username='" + reader.GetString(0) + "'";
            //innerReader = db.data_read(innerQuery);       
            sda = new SqlDataAdapter(innerQuery, db.database_connect());
            sda.Fill(ds);
            
        }
        grdEmployees.DataSource = ds;
        grdEmployees.DataBind();
        if (grdEmployees.Rows.Count == 0)
        {
            lblMessages.Text = "No employees found";
            lnkDelete.Visible = false;
        }
    }

    protected void grdEmployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdEmployees.PageIndex = e.NewPageIndex;
        load();
    }

    protected void chkdelete_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdEmployees.Rows)
        {
            CheckBox chkbox = (CheckBox)row.FindControl("chkdelete");
            if (chkbox.Checked)
            {
                ((CheckBox)row.FindControl("chkdelete")).Checked = true;
            }
        }
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow row in grdEmployees.Rows)
            {
                CheckBox chkbox = (CheckBox)row.FindControl("chkdelete");
                if (chkbox.Checked)
                {
                    query = "delete from Login where username='" + row.Cells[1].Text + "'";
                    db.database_command(query);
                    query = "delete from Registration where username='" + row.Cells[1].Text + "'";
                    db.database_command(query);
                    query = "delete from EmployeeProjects where username='" + row.Cells[1].Text + "'";
                    db.database_command(query);
                    query = "delete from EmployeeSkills where username='" + row.Cells[1].Text + "'";
                    db.database_command(query);
                    query = "delete from Communication where MessageTo='" + row.Cells[1].Text + "'";
                    db.database_command(query);
                    row.Visible = false;
                    ++count;
                }
            }
            if (count == grdEmployees.Rows.Count) // All rows have been deleted
            {
                lblMessages.Text = "All employees have been deleted";
                grdEmployees.Visible = false;
                lnkDelete.Visible = false;
            }
        }
        catch (Exception ex)
        {
        }
    }
}