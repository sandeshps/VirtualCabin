using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class admin_AddState : System.Web.UI.Page
{
    database db = new database();
    SqlDataReader reader;
    string query, cid;
    string stateCount;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load_country_list();
        }

    }

    /* The following function will load the name of countries stored in the database, onto the drop-down-list.
       Incase if the admin chooses to add list of states later and also if the admin directly goes to 'AddState' page
    */

    private void load_country_list()
    {
        query = "select CName from Country";
        reader = db.data_read(query);
        while (reader.Read())
        {
            drpCountry.Items.Add(reader.GetString(0));
        }
    }

    private string AutoGeneration()
    {
        query = "select MAX(Sid) as StateId from State";
        reader = db.data_read(query);
        while (reader.Read())
        {
            if (reader.IsDBNull(0))
            {
                stateCount = "1";
                //stateCount = Convert.ToString(string.Concat("S", stateCount));
                stateCount = Convert.ToString(stateCount);
            }
            else
            {
                int cc = int.Parse(reader["StateId"].ToString());
                stateCount = Convert.ToString( cc + 1); // "S" + cc.ToString();
            }
        }
        return stateCount;

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {

            query = "select Cid from Country where CName='" + drpCountry.SelectedItem.ToString() + "'";
            reader = db.data_read(query);
            if (reader.Read())
            {
                cid = reader.GetString(0);
            }
            query = "select SName from State where SName='" + txtState.Text + "' and countryid='" + cid + "'";
            reader = db.data_read(query);
            if (reader.Read())
            {
                lblMessage.Text = "State already exists";
            }
            else
            {
                query = "insert into State (Sid,SName,CountryId) values ('" + AutoGeneration() + "','" + txtState.Text + "','" + cid + "')";
                db.database_command(query);
                txtState.Text = "";
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void drpCountry_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}