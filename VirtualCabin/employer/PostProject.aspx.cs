using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class employer_PostProject : System.Web.UI.Page
{
    string query, period, salary, username, status, skills, skillset;
    int skill_id, return_count;
    SqlDataReader reader;
    database db = new database();
    static string skill_set;
    string[] skill_list = new string[100];
    static int count = 0, _status = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        username = Session["username"].ToString();

        if (!IsPostBack)
        {

            lstSkills.Visible = false; // Make it visible only on click of the button 'Add'
            txtTitle.Focus();
            load_skill_head_list();
            load_skill_list();
            select_Period();
        }
    }

    




    // This function will load all the 'Skill Head' present in the database onto the drop-down-list
    private void load_skill_head_list()
    {
        query = "select Head from SkillHead";
        reader = db.data_read(query);
        while (reader.Read())
        {
            drpSkillsRequired.Items.Add(reader.GetString(0));
        }
    }

    // This function will load all the skills based on the 'Skill head' selected from the drop-down-list
    private void load_skill_list()
    {
        chkSkillsRequired.Items.Clear();
        query = "select Id from SkillHead where Head='" + drpSkillsRequired.SelectedItem.ToString() + "'";
        reader = db.data_read(query);
        if (reader.Read())
        {
            skill_id = int.Parse(reader.GetString(0));
        }
        query = "select Name from Skills where HeadId='" + skill_id + "'";
        reader = db.data_read(query);
        while (reader.Read())
        {
            chkSkillsRequired.Items.Add(reader.GetString(0));
        }
    }


    protected void drpSkillsRequired_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_skill_list();
       
    }

    private int AutoGeneration()
    {
        query = "select MAX(Id) as Id from Projects";
        reader = db.data_read(query);
        while (reader.Read())
        {
            if (reader.IsDBNull(0))
            {
                count = 1;
                return_count = count;
            }
            else
            {
                int c = int.Parse(reader["Id"].ToString());
                return_count = c + 1;
            }
        }
        return return_count;
    }


    // This function will display number of days, number of weeks, number of months according to the selection made by the user
    private void select_Period()
    {
        if (drpPeriod.SelectedItem.ToString().Trim() == "Day(s)")
        {
            drpPeriodList.Items.Clear();
            for (int i = 1; i <= 31; i++)
            {
                drpPeriodList.Items.Add(i.ToString());
            }
        }
        else if (drpPeriod.SelectedItem.ToString().Trim() == "Week(s)")
        {
            drpPeriodList.Items.Clear();
            drpPeriodList.Items.Add("< 1 week");
            drpPeriodList.Items.Add("1-2 weeks");
            drpPeriodList.Items.Add("2-4 weeks");
            drpPeriodList.Items.Add("4 weeks and above");
        }
        else if (drpPeriod.SelectedItem.ToString().Trim() == "Month(s)")
        {
            drpPeriodList.Items.Clear();
            for (int i = 1; i <= 12; i++)
            {
                drpPeriodList.Items.Add(i.ToString());
            }
        }
        else
        {
            drpPeriodList.Items.Clear();
            for (int i = 1; i <= 5; i++)
            {
                drpPeriodList.Items.Add(i.ToString());
            }
        }
    }


    // Post the project
    protected void btnPost_Click(object sender, EventArgs e)
    {
        try
        {
            if (lstSkills.Items.Count == 0) // No skills found
            {
                lblInfo.Text = "No skills have been added";
            }
            else
            {
                period = drpPeriodList.SelectedItem.Text + drpPeriod.SelectedItem.Text;
                salary = drpSalary.SelectedItem.Text;
                for (int i = 0; i < lstSkills.Items.Count; i++)
                {
                    skill_set = skill_set + lstSkills.Items[i].Text + ",";
                }
                skill_set = skill_set.Remove(skill_set.LastIndexOf(","));
                status = "Approved";

                query = "insert into Projects (Id,Username,Title,Description,Period,Salary,Skills,PostDate,Status) values (" + AutoGeneration() + ",'" + username + "','" + txtTitle.Text + "','" + txtDescription.Text + "','" + period + "','" + salary + "','" + skill_set + "','" + DateTime.Now.ToString("MM/dd/yyyy") + "','" + status + "')";
                db.database_command(query);

                txtTitle.Text = txtDescription.Text = "";
                lstSkills.Items.Clear(); // Clear the listbox
            }

        }
        catch (Exception ex)
        {
        }
    }
    protected void drpPeriod_SelectedIndexChanged(object sender, EventArgs e)
    {
        select_Period();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        getSelectedSkills();
        //load_Checked_Skills();
        //++count;
    }

    // Utility function used in this page. Used to store selected items in a check-box-list to a string variable for future use
    private void getSelectedSkills()
    {
        int flag = 0;
        lstSkills.Visible = true;
        for (int i = 0; i < chkSkillsRequired.Items.Count; i++)
        {
            flag = 0;
            if (chkSkillsRequired.Items[i].Selected == true)
            {
                for (int l = 0; l < lstSkills.Items.Count; l++)
                {
                    if (chkSkillsRequired.Items[i].Text.Equals(lstSkills.Items[l].Text))
                    {
                        flag = 1;
                    }

                }
                if (lstSkills.Items.Count == 0 || flag == 0)
                {
                    lstSkills.Items.Add(chkSkillsRequired.Items[i].Text);
                }
            }
            else
            {
                for (int l = 0; l < lstSkills.Items.Count; l++)
                {
                    if (chkSkillsRequired.Items[i].Text.Equals(lstSkills.Items[l].Text))
                    {
                        lstSkills.Items.Remove(chkSkillsRequired.Items[i].Text);
                    }
                }
            }
        }

    }





    protected void chkSkillsRequired_SelectedIndexChanged(object sender, EventArgs e)
    {


    }


    //protected void chkOptional_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (chkOptional.Checked)
    //        drpNumber.Enabled = false;
    //    else
    //        drpNumber.Enabled = true;
    //}
}














