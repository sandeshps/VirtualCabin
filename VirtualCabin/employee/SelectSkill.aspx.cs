using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using AjaxControlToolkit;

public partial class employee_SelectSkill : System.Web.UI.Page
{
    CheckBoxList chkSkills;
    Button btn;
    database db = new database();
    SqlDataAdapter da;
    SqlDataReader reader;
    DataSet ds = new DataSet();
    //AjaxControlToolkit.AccordionPane pn;
    static int paneCount;
    //string query, skills;
    //SqlCommand cmd;
    string query, username, skills, skillset, checkboxlist_query;
    string[] skill_list;
    int skill_id, count, return_count, head_count_id;
    static int status = 0;
    //DataSet ds = new DataSet();
    //SqlDataAdapter da;
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();  
        username = Session["username"].ToString();
        if (!IsPostBack)
        {
            load_skill_head_list();
            load_skill_list();
            load_checked_skill_list();
            //skillSetAccordion();
            //loadAll();
        }
    }


    //protected void loadAll()
    //{
    //    string previous_head_value, current_head_value = "";
    //    query = "SELECT s.Head, sk.Name FROM SkillHead AS s INNER JOIN Skills AS sk ON s.Id = sk.HeadId ORDER BY s.Head ASC";
    //    da = new SqlDataAdapter(db.database_command_sqlcommand(query));
    //    da.Fill(ds);

    //    if (ds.Tables[0].Rows.Count != 0)
    //    {
    //        Label lblTitle;
    //        Label lblContent;
    //        LinkButton lnkTitle;
    //        //LinkButton lnkContent;

    //        int i = 0;     // This is just to use for assigning pane an id
    //        foreach (DataRow dr in ds.Tables[0].Rows)
    //        {

    //            lblTitle = new Label();
    //            lblContent = new Label();
    //            lnkTitle = new LinkButton();
    //            previous_head_value = current_head_value;
    //            lnkTitle.Text = dr["Head"].ToString();
    //            //lblTitle.Text = dr["Head"].ToString();
    //            current_head_value = lnkTitle.Text;
    //            // If the skillhead is same, then append skills of that particular skillhead
    //            if (previous_head_value.Equals(lnkTitle.Text))
    //            {
    //                chkSkills.Items.Add(dr["Name"].ToString());
    //                //lblContent.Text = dr["Name"].ToString();
    //                pn.ContentContainer.Controls.Add(chkSkills);
    //                Accordion1.Panes.Add(pn);

    //            }
    //            // If the skillhead is new, then create a new pane and check-box-list
    //            else
    //            {
    //                pn = new AjaxControlToolkit.AccordionPane();
    //                pn.ID = "Pane" + i;
    //                chkSkills = new CheckBoxList();
    //                chkSkills.ID = "chklist" + i;
    //                pn.HeaderContainer.Controls.Add(lnkTitle);
    //                //pn.HeaderContainer.Controls.Add(lblTitle);
    //                ++i;
    //                if (previous_head_value.Equals(""))
    //                {
    //                    chkSkills.Items.Add(dr["Name"].ToString());
    //                    pn.ContentContainer.Controls.Add(chkSkills);
    //                    Accordion1.Panes.Add(pn);
    //                }
    //                else
    //                {
    //                    chkSkills.Items.Add(dr["Name"].ToString());
    //                    pn.ContentContainer.Controls.Add(chkSkills);
    //                    Accordion1.Panes.Add(pn);
    //                }
    //            }
    //           // ++i;
    //        }
    //        //paneCount = Accordion1.Panes.Count - 1;
    //    }

    //}

    //protected void skillSetAccordion()
    //{

    //    query = "select Head from SkillHead";
    //    da = new SqlDataAdapter(db.database_command_sqlcommand(query));
    //    da.Fill(ds);
    //    if (ds.Tables[0].Rows.Count != 0)
    //    {
    //        Label lblTitle;
    //        Label lblDetail;
    //        AjaxControlToolkit.AccordionPane pane;
    //        CheckBoxList chklist;
    //        int i = 0;     // This is just to use for assigning pane an id
    //        foreach (DataRow dr in ds.Tables[0].Rows)
    //        {
    //            //lbTitle = new Label();
    //            //lbContent = new Label();
    //            //lbTitle.Text = dr["Title"].ToString();
    //            //lbContent.Text = dr["Detail"].ToString();
    //            lblTitle = new Label();
    //            lblDetail = new Label();
    //            lblTitle.Text = dr["Head"].ToString();
    //            //lblDetail.Text = dr["Name"].ToString();
    //            pane = new AjaxControlToolkit.AccordionPane();
    //            pane.ID = "Pane" + i;
    //            pane.HeaderContainer.Controls.Add(lblTitle);

    //            //pane.ContentContainer.Controls.Add(lblDetail);
    //            Accordion1.Panes.Add(pane);
    //            ++i;
    //        }
    //    }
    //}


    private int AutoGeneration()
    {
        query = "select MAX(Id) as Id from EmployeeSkills";
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


    private void load_skill_head_list()
    {
        query = "select Head from SkillHead";
        reader = db.data_read(query);
        while (reader.Read())
        {
            drpSkillHead.Items.Add(reader.GetString(0));
        }
    }

    // This function will load all the skill names onto the drop-down-list, based on skill head item from the drop-down-list
    private void load_skill_list()
    {
        chkskillset.Items.Clear();
        query = "select Id from SkillHead where Head='" + drpSkillHead.SelectedItem.ToString() + "'";
        reader = db.data_read(query);
        if (reader.Read())
        {
            skill_id = int.Parse(reader.GetString(0));
        }
        query = "select Name from Skills where HeadId='" + skill_id + "'";
        reader = db.data_read(query);
        while (reader.Read())
        {
            chkskillset.Items.Add(reader.GetString(0));
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {

            if (status == 1) // Some skill items are present in the database, go for updation
            {
                for (int i = 0; i < chkskillset.Items.Count; i++)
                {
                    if (chkskillset.Items[i].Selected == true)
                    {
                        skillset = skillset + chkskillset.Items[i].Text + ",";
                    }
                }
                query = "update EmployeeSkills set SkillName='" + skillset + "' where username='" + username + "' AND SkillHead='" + drpSkillHead.SelectedItem.ToString() + "'";
                db.database_command(query);
                lblMessage.Text = "Changes saved";
                load_checked_skill_list();
            }
            else // No skill items are present in the database, go for insertion
            {
                for (int i = 0; i < chkskillset.Items.Count; i++)
                {
                    if (chkskillset.Items[i].Selected == true)
                    {
                        skillset = skillset + chkskillset.Items[i].Text + ",";
                    }
                }
                query = "insert into EmployeeSkills (Id,UserName,SkillHead,SkillName) values (" + AutoGeneration() + ",'" + username + "','" + drpSkillHead.SelectedItem.ToString() + "','" + skillset + "')";
                db.database_command(query);
                lblMessage.Text = "Items added";
                load_checked_skill_list();
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void drpSkillHead_SelectedIndexChanged(object sender, EventArgs e)
    {
        status = 0;
        lblMessage.Text = "";
        load_skill_list();
        load_checked_skill_list();
    }

    private void load_checked_skill_list()
    {
        query = "select skillname from EmployeeSkills where Username='" + username + "' and skillhead='" + drpSkillHead.SelectedItem.ToString() + "'";
        reader = db.data_read(query);
        if (reader.Read())
        {
            status = 1;
            skills = reader.GetString(0);
            skill_list = skills.Split(',');
            for (int i = 0; i < skill_list.Length; i++)
            {
                for (int j = 0; j < chkskillset.Items.Count; j++)
                    if (skill_list[i] == chkskillset.Items[j].Text)
                    {
                        chkskillset.Items[j].Selected = true;
                        chkskillset.Items[j].Attributes.Add("style", "color:red"); // To set text color for checked item                       

                    }
            }
        }
        //else
        //{.
        //    lblMessage.Text = "No skills added";
        //}
    }



    // This function will check how many panes the form has, and it will check for matching skill-head with the database
    // Then it will store the selected skills to a string variable
    /*protected void btnSave_Click(object sender, EventArgs e)
    {
        int i = 0;
        if (Accordion1.Panes.Count > 0)
        {
            foreach (AccordionPane ap in Accordion1.Panes)
            {
                //CheckBoxList chklst = new CheckBoxList();
                CheckBoxList chklst = (CheckBoxList)ap.ContentContainer.FindControl("chklist" + i);
                foreach (ListItem lstitem in chklst.Items)
                {
                    if (lstitem.Selected == true)
                    {
                        skills = skills + lstitem.Text + ",";
                    }
                }
                ++i;
            }
        }*/
    //query = "SELECT s.Head, sk.Name FROM SkillHead AS s INNER JOIN Skills AS sk ON s.Id = sk.HeadId ORDER BY s.Head ASC";
    //query = "select Head from SkillHead";
    //da = new SqlDataAdapter(db.database_command_sqlcommand(query));
    //da.Fill(ds);
    //if (ds.Tables[0].Rows.Count != 0)
    //{
    //    foreach (DataRow dr in ds.Tables[0].Rows)
    //    {
    //        foreach (AccordionPane ap in Accordion1.Panes)
    //        {
    //            if (ap.Header.Equals(dr["Head"].ToString()))
    //            {
    //                skills = chkSkills.SelectedItem.Text;
    //            }
    //        }
    //    }
    //}
    //reader = db.data_read(query);
    //while (reader.Read())
    //{
    //    foreach (AccordionPane ap in Accordion1.Panes)
    //    {
    //        if (ap.Header.Equals(reader["Head"].ToString()))
    //        {
    //            skills = chkSkills.SelectedItem.Text;
    //        }
    //    }
    //}
   
}

