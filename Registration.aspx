<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center" style="width:25%;">  
            <caption class="style1">  
                <strong>Registration Form</strong>  
            </caption>
            <tr>
                <td><asp:Label ID="Label1" runat="server" Text="Name" Width="150px"></asp:Label></td>
                <td><asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox></td> 
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"   
                         ControlToValidate="TextBox1" ErrorMessage="Required." ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label2" runat="server" Text="eMail"></asp:Label></td>
                <td><asp:TextBox ID="TextBox2" runat="server" Width="200px"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"   
                         ControlToValidate="TextBox2" ErrorMessage="Required." ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr> 
            <tr>
                <td><asp:Label ID="Label3" runat="server" Text="Bank Account"></asp:Label></td>
                <td><asp:TextBox ID="TextBox3" runat="server" Width="200px" Text="None"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                         ControlToValidate="TextBox3" ErrorMessage="Required." ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label4" runat="server" Text="Lab/Office #"></asp:Label></td>
                <td><asp:TextBox ID="TextBox4" runat="server" Width="200px"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"   
                         ControlToValidate="TextBox4" ErrorMessage="Required." ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label5" runat="server" Text="Phone #"></asp:Label></td>
                <td><asp:TextBox ID="TextBox5" runat="server" Width="200px"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"   
                         ControlToValidate="TextBox5" ErrorMessage="Required." ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label6" runat="server" Text="New Password"></asp:Label></td>
                <td><asp:TextBox ID="TextBox6" runat="server" TextMode="Password" Width="200px"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"   
                         ControlToValidate="TextBox6" ErrorMessage="Required." ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td><asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Submit" /></td>
            </tr>
            <tr>
                <td colspan="3"><asp:Label ID="Label7" runat="server"></asp:Label></td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>
