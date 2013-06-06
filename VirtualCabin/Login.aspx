<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<script language="javascript" type="text/javascript">
    window.history.forward(1);
</script>
    <title></title>
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 210px;
        }
        .style3
        {
            width: 38%;
            z-index: 1;
            left: 766px;
            top: 442px;
            position: absolute;
            height: 195px;
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
    


    <table style="height: 351px; width: 541px">
        <tr>
            <td>
                <asp:Image ID="Image4" runat="server" Height="503px" 
                    ImageUrl="~/images/virtual-office-earthlink-business.jpg" Width="549px" />
            </td>
        </tr>
    </table>


    <table style="z-index: 1; left: 713px; top: 135px; position: absolute; height: 194px; width: 460px">
    <tr>
    <td align="left" class="style2">
    
        &nbsp;</td>
    <td>
    
        <asp:ImageButton ID="btnSignIn" runat="server" Height="106px" 
            ImageUrl="~/images/loginbutton.png" onclick="btnSignIn_Click" 
            style="z-index: 1; top: 163px; position: absolute; left: 204px" />
       <%-- <asp:Image ID="Image3" runat="server" Height="197px" 
            ImageUrl="~/images/logindesign.jpg" Width="349px" />--%>
        <asp:TextBox ID="txtPassword" runat="server" 
            
            
            
            style="z-index: 1; left: 207px; top: 151px; position: absolute; height: 19px; width: 200px" 
            TextMode="Password"></asp:TextBox>
        <asp:TextBox ID="txtUsername" runat="server" 
            
            
            
            
            style="z-index: 1; left: 208px; top: 94px; position: absolute; height: 20px; width: 200px" 
            TabIndex="1"></asp:TextBox>

            <asp:Label ID="lblMessage" runat="server" 
        
            
            
            
            style="z-index: 1; left: 103px; top: 238px; position: absolute; right: 41px; height: 25px;" 
            Font-Bold="True" ForeColor="White"></asp:Label>
    
        <asp:Image ID="Image5" runat="server" Height="283px" 
            ImageUrl="~/designs/black-laptop-ico1n.jpg" Width="421px" 
            style="margin-left: 9px" />
    
    </td>
     
    </tr>
    
    </table>


    


        <table class="style3">
            <tr>
                <td valign="bottom">
                   
                    <asp:Image ID="Image6" runat="server" Height="181px" ImageUrl="~/gif/login.gif" 
                        Width="365px" />
                   
                    </td>
            </tr>
        </table>



    </div>
   
    
   
    </form>
    
    
    
</body>
</html>
