<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 7px;
        }
        .style2
        {
            width: 100%;
            height: 285px;
        }
        .style5
        {
            width: 100%;
        }
        .style6
        {
            width: 376px;
            text-align: left;
            color: #0099FF;
            height: 220px;
        }
        .style7
        {
            color: #0033CC;
            text-align: center;
        }
        .style8
        {
            text-decoration: underline;
        }
        .style9
        {
            height: 220px;
        }
        .style10
        {
            height: 220px;
            width: 226px;
        }
    </style>
   
</head>
<body>
    <form id="form1" runat="server">
    <div id="wrapper">
    <table class="style1">
        <tr>
            <td>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/logo.jpg" 
                   Width="973px" />
                </td>
        </tr>
    </table>

        <table bgcolor="#0066FF" border="2" class="style1">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" ForeColor="White" 
                        Text="&lt;marquee behavior=&quot;left&quot;&gt;Welcome to Virtual Cabin : A place where you can work and earn &lt;/marquee&gt; "></asp:Label>
                </td>
            </tr>
        </table>


        


        <table class="style2">
            <tr>
                <td colspan="2">
                    <asp:Image ID="Image2" runat="server" BorderStyle="Solid" BorderWidth="1px" 
                        Height="266px" ImageUrl="~/gif/home page.gif" Width="972px" 
                        style="margin-top: 0px" />
                </td>
            </tr>
            
        </table>

        
        <table class="style5">
            <tr>
                <td class="style6" style="border:1px">
                    <strong style="text-align: left"><span class="style7">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <span class="style8">What is Virtual Cabin </span>?</span></strong><strong 
                        style="color: #000000; text-align: left"><br />
                    Virtual Cabin is like 
                    a workplace with a difference. Instead of working in a 
                    office setup, you work in a virtual setup. You can be an employer or an 
                    employee. You can post works and also do the works available in our website.</strong></td>
                <td class="style10" valign="top">
                
                <br />
                    <br />
                    <br />
                    New users please&nbsp;
                    <asp:LinkButton ID="lnkRegister" runat="server" 
                        style="height: 20px; width: 60px" onclick="lnkRegister_Click">click here</asp:LinkButton>
                    <br />
                    Existing users please 
                    <asp:LinkButton ID="lnkSignIn" runat="server" onclick="lnkSignIn_Click">click here</asp:LinkButton></td>
                <td class="style9" valign="top">
                    <br />
                    <asp:Panel ID="pnlUpdates" runat="server" Height="191px" BorderStyle="None" 
                        BorderWidth="1px">
                 <marquee loop="infinite" direction="up" behavior="scroll" onmouseover="this.stop()" onmouseout="this.start()" scrollamount="3" style="height: 186px">
                 <asp:Literal ID="ltl" runat="server"></asp:Literal>
                 </marquee>
                 </asp:Panel><br />
                    
                </td>
            </tr>
        </table>





        


    </div>
    </form>
</body>
</html>
