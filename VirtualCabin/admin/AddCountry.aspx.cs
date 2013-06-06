using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class admin_AddCountry : System.Web.UI.Page
{
    database db = new database();
    SqlDataReader reader;
    string query;
    string countryId;
    string countryCount;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private string AutoGeneration()
    {
        query = "select MAX(Cid) as CountryId from Country";
        reader = db.data_read(query);
        while (reader.Read())
        {
            if (reader.IsDBNull(0))
            {
                countryCount = "1";
                //countryCount = Convert.ToString(string.Concat("C", countryCount));
                countryCount = Convert.ToString(countryCount);
            }
            else
            {
                int cc = int.Parse(reader["CountryId"].ToString());
                //countryCount = Convert.ToString(string.Concat("C", cc + 1)); // "C" + cc.ToString();
                countryCount = Convert.ToString(cc + 1);
            }
        }
        return countryCount;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            query = "select CName from Country where CName='" + txtCountry.Text + "'";
            reader = db.data_read(query);
            if (reader.Read())
            {
                lblMessage.Text = "Country already exists";
            }
            else
            {
                //countryId = AutoGeneration();
                query = "insert into Country (Cid,CName) values ('" + AutoGeneration() + "','" + txtCountry.Text + "')";
                db.database_command(query);
                txtCountry.Text = "";
            }
        }
        catch (Exception ex)
        {
        }

    }
}