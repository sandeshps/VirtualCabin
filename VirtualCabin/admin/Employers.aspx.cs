using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class admin_Employers : System.Web.UI.Page
{
    string query, innerQuery;
    SqlDataReader reader;
    database db = new database();
    static int count = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            load();
    }

    private void load()
    {
        SqlDataAdapter sda;
        DataSet ds = new DataSet();
        query = "select Username from Login where UserType='Employer'";
        reader = db.data_read(query);
        while (reader.Read())
        {
            innerQuery = "select * from Registration where username='" + reader.GetString(0) + "'";
            //innerReader = db.data_read(innerQuery);       
            sda = new SqlDataAdapter(innerQuery, db.database_connect());
            sda.Fill(ds);

        }
        grdEmployers.DataSource = ds;
        grdEmployers.DataBind();
        if (grdEmployers.Rows.Count == 0) // No employers in the database
        {
            lblMessage.Text = "No employers found";
            lnkDelete.Visible = false;
        }
    }

    protected void grdEmployers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdEmployers.PageIndex = e.NewPageIndex;
        //grdEmployees.DataBind();
        load();
    }

    protected void chkdelete_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdEmployers.Rows)
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
        foreach (GridViewRow row in grdEmployers.Rows)
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
        if (count == grdEmployers.Rows.Count) // All rows have been deleted
        {
            lblMessage.Text = "All employers have been deleted";
            grdEmployers.Visible = false;
            lnkDelete.Visible = false;
        }
    }
}