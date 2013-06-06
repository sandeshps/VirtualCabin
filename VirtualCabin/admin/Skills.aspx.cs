using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class admin_Skill : System.Web.UI.Page
{
    database db = new database();
    SqlDataReader reader;
    string query, skillCount;
    int skill_id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load_skill_head();
        }
    }

    // This function will load all the skillhead names onto the drop-down-list

    private void load_skill_head()
    {
        query = "select Head from SkillHead";
        reader = db.data_read(query);
        while (reader.Read())
        {
            drpSkillHead.Items.Add(reader.GetString(0));
        }
    }

    /*private string AutoGeneration()
    {
        query = "select MAX(Id) as SkillId from SkillHead";
        reader = db.data_read(query);
        while (reader.Read())
        {
            if (reader.IsDBNull(0))
            {
                skillCount = "1";
                //skillCount = Convert.ToString(string.Concat("SK", skillCount));
                skillCount = Convert.ToString(skillCount);
            }
            else
            {
                int sk = int.Parse(reader["SkillId"].ToString());
                //skillCount = Convert.ToString(string.Concat("SK", sk + 1)); // "SK" + cc.ToString();
                skillCount = Convert.ToString(sk + 1);
            }
        }
        return skillCount;
    }
    */
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (drpSkillHead.Items.Count == 0) // No skill head in the database, disable the button
            {
                btnAdd.Enabled = false;
                lblMessage.Text = "No skill head present";
            }
            else if (txtSkillName.Text.Trim() == "")
            {
                lblMessage.Text = "Field cannot be blank";
            }
            else
            {
                query = "select Name from Skills where Name='" + txtSkillName.Text + "'";
                reader = db.data_read(query);
                if (reader.Read())
                {
                    lblMessage.Text = "Skill already exists";
                }
                else
                {
                    query = "select Id from SkillHead where Head='" + drpSkillHead.SelectedItem.ToString() + "'";
                    reader = db.data_read(query);
                    if (reader.Read())
                    {
                        skill_id = int.Parse(reader.GetString(0));
                    }
                    query = "insert into Skills (Name,HeadId) values ('" + txtSkillName.Text + "','" + skill_id + "')";
                    db.database_command(query);
                    txtSkillName.Text = "";
                    lblMessage.Text = "Skill added";
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
}