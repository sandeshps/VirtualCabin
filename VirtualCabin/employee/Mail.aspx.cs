﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class employee_Mail : System.Web.UI.Page
{
    database db = new database();
    string query;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            mail();
        }
    }

    private void mail()
    {
        lblFrom.Text = Session["From"].ToString();
        lblTitle.Text = Session["Title"].ToString();
        lblSubject.Text = Session["Subject"].ToString();
        query = "update Communication set Status=1 where MessageFrom='" + lblFrom.Text + "' AND Title='" + lblTitle.Text + "' AND Subject='" + lblSubject.Text + "'";
        db.database_command(query);
        //query = "select * from Communication where MessageTo='" + Session["username"].ToString() + "'";
    }

    protected void btnReply_Click(object sender, EventArgs e)
    {
        Session["To"] = lblFrom.Text;
        Response.Redirect("Reply.aspx");
    }
}