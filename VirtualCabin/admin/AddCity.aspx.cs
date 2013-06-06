using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class admin_AddCity : System.Web.UI.Page
{
    database db = new database();
    SqlDataReader reader;
    string query, cid, sid, cityCount;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load_country_list();
        }
    }
    private void load_country_list()
    {
        query = "select CName from Country";
        reader = db.data_read(query);
        while (reader.Read())
        {
            drpCountry.Items.Add(reader.GetString(0));
        }
        if (drpCountry.Items.Count == 1)
        {
            load_state_list();
        }

    }
    /* If the admin directly visits this page, the function will load all the countries and the admin can
     * directly select any country and state and add city */
    /* private void list_check()
     {
         if (!IsPostBack)
         {
             if ((Session["city"] == null))
             {
                 query = "select * from Country";
                 reader = db.data_read(query);
                 while (reader.Read())
                 {
                     drpCountry.Items.Add(reader["CName"].ToString()); // List all countries onto the drop down list
                 }
             }
         }
     }*/

    private string AutoGeneration()
    {
        query = "select MAX(CityId) as CityId from City";
        reader = db.data_read(query);
        while (reader.Read())
        {
            if (reader.IsDBNull(0))
            {
                cityCount = "1";
                cityCount = Convert.ToString(cityCount);
            }
            else
            {
                int cc = int.Parse(reader["CityId"].ToString());
                cityCount = Convert.ToString(cc + 1); // "C" + cc.ToString();
            }
        }
        return cityCount;
    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            query = "select Sid from State where SName='" + drpState.SelectedItem.ToString() + "'";
            reader = db.data_read(query);
            if (reader.Read())
            {
                sid = reader.GetString(0);
            }
            query = "select CIName from City where CIName='" + txtCity.Text + "' AND StateId='" + sid + "'";
            reader = db.data_read(query);
            if (reader.Read())
            {
                lblMessage.Text = "City already exists";
            }
            else
            {
                query = "insert into City (CityId,CIName,StateId) values ('" + AutoGeneration() + "','" + txtCity.Text + "','" + sid + "')";
                db.database_command(query);
                txtCity.Text = "";
            }
        }
        catch (Exception ex)
        {
        }

    }
    private void load_state_list()
    {
        query = "select Cid from Country where CName='" + drpCountry.SelectedItem.ToString() + "'";
        reader = db.data_read(query);
        if (reader.Read())
        {
            cid = reader.GetString(0);
        }
        query = "select Sname from State where Countryid='" + cid + "'";
        reader = db.data_read(query);
        while (reader.Read())
        {
            drpState.Items.Add(reader.GetString(0));
        }

    }
    protected void drpCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_state_list();
    }

}