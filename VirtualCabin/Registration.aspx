<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<style type="text/css">
    .style1
{
    width:100%;
}
    .style2
    {}
    .style3
    {
        height: 28px;
        width: 222px;
    }
    .style4
    {
        height: 29px;
    }
    .style5
    {
        height: 26px;
    }
</style>
    <title></title>
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>

    <body>
    <form id="form2" runat="server">
    <div id="wrapper">
    <table class="style1">
        <tr>
            <td>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/logo.jpg" 
                    Width="971px" />
    
            </td>
        </tr>
    </table>
    <table class="style1" bgcolor="#0099CC" border="2">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="White" 
                        
                        Text="&lt;marquee behavior=&quot;Alternate&quot; marquee-speed=&quot;Fast&quot;&gt; Welcome to Virtual Cabin &lt;/marquee&gt;"></asp:Label>
                </td>
            </tr>
        </table>
        

        <table class="style1">
            <tr>
                <td>
                    <asp:Image ID="Image2" runat="server" Height="166px" 
                        ImageUrl="~/images/registration.png" Width="973px" />
                </td>
            </tr>
        </table>
        

    <table class="style1" frame="box">
        <tr>
            <td bgcolor="#6699FF" class="style2">
              <table class="style1" bgcolor="White">
        <tr>
            <td class="style4">
                Username</td>
            <td class="style3">
                <asp:TextBox ID="txtUserName"  OnTextChanged="txtUserName_TextChanged" runat="server"
                     Width="219px" AutoPostBack="True"></asp:TextBox>
            </td>
            <td class="style8">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtUsername" ErrorMessage="This field cannot be left blank" 
                    style="color: #FF3300"></asp:RequiredFieldValidator>
                <asp:Label ID="lblUsername" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style4">
                First name</td>
            <td class="style3">
                <asp:TextBox ID="txtFirstName" runat="server" height="22px" width="219px"></asp:TextBox>
            </td>
            <td class="style8">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                Last name</td>
            <td class="style3">
                <asp:TextBox ID="txtLastName" runat="server" height="22px" width="219px"></asp:TextBox>
            </td>
            <td class="style8">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                Password</td>
            <td class="style3">
                <asp:TextBox ID="txtPassword" runat="server" height="22px" TextMode="Password" 
                    width="219px"></asp:TextBox>
            </td>
            <td class="style8">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                Confirm password</td>
            <td class="style3">
                <asp:TextBox ID="txtCPassword" runat="server" height="22px" TextMode="Password" 
                    width="219px"></asp:TextBox>
            </td>
            <td class="style8">
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="txtPassword" ControlToValidate="txtCPassword" 
                    ErrorMessage="Passwords should match" style="color: #FF5050" 
                    ForeColor="Black"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Date of birth</td>
            <td class="style3">
                <asp:TextBox ID="txtDob" runat="server" height="22px" width="219px"></asp:TextBox>
                <asp:CalendarExtender ID="txtDob_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtDob">
                </asp:CalendarExtender>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <%--<asp:CalendarExtender ID="txtDob_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtDob">
                </asp:CalendarExtender>--%>
            </td>
            <td class="style8">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                I&#39;m an </td>
            <td class="style3">
                <asp:DropDownList ID="drpUserType" runat="server" Width="105px">
                    <asp:ListItem>Employee</asp:ListItem>
                    <asp:ListItem>Employer</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style8">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style3">
                <asp:Button ID="btnRegister" runat="server" onclick="btnRegister_Click" 
                    Text="Register" Width="76px" />
            </td>
            <td class="style8">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style3">
                <asp:Label ID="lblInfo" runat="server" Font-Bold="True" ForeColor="#0066FF"></asp:Label>
            </td>
            <td class="style8">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5" colspan="2">
                </td>
            <td class="style5">
                </td>
        </tr>
    </table>
                </td>
        </tr>
    </table>
   
        
            
        
           

    </div>
    
   
    </form>
</body>
</html>
