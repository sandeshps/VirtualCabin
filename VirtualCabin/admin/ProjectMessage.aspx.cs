using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;



public partial class admin_ProjectMessage : System.Web.UI.Page
{
    database db = new database();
    string query, username;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load_Project_Details();
        }
    }
    protected void lnkSend_Click(object sender, EventArgs e)
    {
        GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow; // Used to find out which row is clicked
        Session["username"] = clickedRow.Cells[1].Text;
        Session["title"] = clickedRow.Cells[2].Text;
        Session["description"] = clickedRow.Cells[3].Text;
        Session["period"] = clickedRow.Cells[4].Text;
        Session["postdate"] = clickedRow.Cells[5].Text;
        Response.Redirect("ProjectMessages.aspx");
        //GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
        //Label lblID = (Label)clickedRow.FindControl("lblID");

        //Session["username"] = lblID.Text;
    }

    private void load_Project_Details()
    {
        query = "select * from Projects where Status='Approved'";
        grdProjects.DataSource = db.data_set(query);
        grdProjects.DataBind();
    }
    //protected void grdProjects_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    GridViewRow row = grdProjects.SelectedRow;
    //    Session["username"] = row.Cells[1].Text;
    //    Session["title"] = row.Cells[2].Text;
    //    Session["description"] = row.Cells[3].Text;
    //    Session["period"] = row.Cells[4].Text;
    //    Session["postdate"] = row.Cells[5].Text;
    //}
}