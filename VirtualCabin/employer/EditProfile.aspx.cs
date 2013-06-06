using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class employer_EditProfile : System.Web.UI.Page
{
    database db = new database();
    SqlDataReader reader;
    static int globalStatus = 0;
    string query, update_query, userphoto_path, path, str;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblUsername.Text = Session["username"].ToString();
        if (!IsPostBack)
        {
            userDetails();
            loadCountry();


            drpState.Enabled = false;
            drpCity.Enabled = false;

        }
    }


    private void loadCountry()
    {
        query = "select CName from Country";
        reader = db.data_read(query);
        while (reader.Read())
        {
            drpCountry.Items.Add(reader.GetString(0));
        }
    }

    private void userDetails()
    {
        query = "select * from Registration where username='" + Session["username"].ToString() + "'";
        reader = db.data_read(query);
        if (reader.Read())
        {
            lblUsername.Text = reader.GetString(0);
            txtFirstName.Text = reader.GetString(1);
            txtLastName.Text = reader.GetString(2);

            txtMailId.Text = reader.GetValue(3).ToString();
            txtAddress.Text = reader.GetValue(5).ToString();
            //drpCountry.Items.Add(reader.GetString(6));
            //drpState.Items.Add(reader.GetString(7));
            //drpCity.Items.Add(reader.GetString(8));
            txtPhone.Text = reader.GetValue(9).ToString();
        }

    }

    private void fileUpload()
    {
        path = Server.MapPath("~/photos/");
        
        if (FileUpload1.HasFile)
        {
            string extension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
            if (extension == ".jpg" || extension == ".jpeg" || extension == ".gif" || extension == ".png")
            {
                
                FileUpload1.SaveAs(path + Session["username"].ToString() + FileUpload1.FileName);
                userphoto_path = "~/photos/" + Session["username"].ToString() + FileUpload1.FileName;
                str = "update Registration set Logo='" + userphoto_path + "' where username='" + Session["username"].ToString() + "'";
                db.database_command(str);
                //lbluploadmessage.Text = "File Uploaded Successfully";
            }
            else
            {
                lblPhoto.Text = "Format not supported";
                globalStatus = 1;
                //lblfileupload.Text = "Supported formats are .jpg and .jpeg";
            }
        }
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            fileUpload();
            if (globalStatus == 1) // Photo of not a valid format
            {
                lblMessage.Text = "Error in uploading photo";
            }
            else
            {
                update_query = "update Registration set FirstName='" + txtFirstName.Text + "',LastName='" + txtLastName.Text + "',EmailId='" + txtMailId.Text + "',Address='" + txtAddress.Text + "',Country='" + drpCountry.SelectedValue + "',State='" + drpState.SelectedValue + "',City='" + drpCity.SelectedValue + "',Mobile='" + txtPhone.Text + "' where username='" + lblUsername.Text + "'";
                db.database_command(update_query);
                lblMessage.Text = "Changes saved";
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void drpCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        int countryid = 0, status = 0;
        drpState.Items.Clear();
        drpCity.Items.Clear();
        query = "select Cid from Country where CName='" + drpCountry.SelectedItem.Text + "'";
        reader = db.data_read(query);
        if (reader.Read()) // Get the selected country's Id
        {
            countryid = int.Parse(reader.GetString(0));
        }
        query = "select SName from State where CountryId='" + countryid.ToString() + "'";
        reader = db.data_read(query);
        while (reader.Read()) // With the country id, get all the state names
        {
            status = 1;
            drpState.Enabled = true;
            drpState.Items.Add(reader.GetString(0));
        }
        if (status == 0) // No state list in the database, for a particular country
        {
            drpState.Enabled = false;
            drpCity.Enabled = false;
        }
    }
    protected void drpState_SelectedIndexChanged(object sender, EventArgs e)
    {
        int stateid = 0, status = 0;
        drpCity.Items.Clear();
        query = "select Sid from State where SName='" + drpState.SelectedItem.Text + "'";
        reader = db.data_read(query);
        if (reader.Read()) // Get the selected state's Id
        {
            stateid = int.Parse(reader.GetString(0));
        }
        query = "select CIName from City where StateId='" + stateid.ToString() + "'";
        reader = db.data_read(query);
        while (reader.Read()) // With the state id, get all the city names
        {
            status = 1;
            drpCity.Enabled = true;
            drpCity.Items.Add(reader.GetString(0));
        }
        if (status == 0) // No city list in the database for a particular state
        {
            drpCity.Enabled = false;
        }
    }
}