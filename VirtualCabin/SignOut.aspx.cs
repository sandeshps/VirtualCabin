using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.Caching;

public partial class employer_SignOut : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();  
        //Session.Abandon();
        //FormsAuthentication.SignOut();
        
        //Response.Redirect("../Home.aspx");
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        //FormsAuthentication.SignOut();
        Response.Redirect("Home.aspx");  

    }
}