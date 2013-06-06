using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class admin_SkillHead : System.Web.UI.Page
{

    database db = new database();
    string query, skill_Head_Count, skillId;
    SqlDataReader reader;
    static int[] numbers = new int[5];
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //private int[] extractDigit(string strText)
    //{
    //    if (strText.Length > 0)
    //    {
    //        char[] chars = strText.ToCharArray();
    //        //int[] numbers = new int[5];
    //        for (int i = 0, j = 0; i < chars.Length; i++, j++)
    //        {
    //            if (chars[i] >= 0 || chars[i] <= 9)
    //            {
    //                numbers[j] = chars[i];
    //            }
    //            else
    //            {
    //                continue;
    //            }
    //        }
    //    }
    //    return numbers;
    //}



    private string AutoGeneration()
    {
        query = "select MAX(Id) as SkillId from SkillHead";
        reader = db.data_read(query);
        while (reader.Read())
        {
            if (reader.IsDBNull(0))
            {
                skill_Head_Count = "1";
                //skillCount = Convert.ToString(string.Concat("SK", skillCount));
                skill_Head_Count = Convert.ToString(skill_Head_Count);
            }
            else
            {
                int sk = int.Parse(reader["SkillId"].ToString());
                //skillCount = Convert.ToString(string.Concat("SK", sk + 1)); // "SK" + cc.ToString();
                skill_Head_Count = Convert.ToString(sk + 1);
            }
        }
        return skill_Head_Count;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtSkillHead.Text.Trim() == "") // Cannot be blank
            {
                lblMessage.Text = "Field can't be blank";
            }
            else
            {
                query = "select Head from SkillHead where Head='" + txtSkillHead.Text + "'";
                reader = db.data_read(query);
                if (reader.Read())
                {
                    lblMessage.Text = "Skill Head already exists";
                }
                else
                {
                    query = "insert into SkillHead (Id,Head) values ('" + AutoGeneration() + "','" + txtSkillHead.Text + "')";
                    db.database_command(query);
                    txtSkillHead.Text = "";
                    lblMessage.Text = "Skill head added";
                }
            }
        }
        catch (Exception ex)
        {
        }

    }

}