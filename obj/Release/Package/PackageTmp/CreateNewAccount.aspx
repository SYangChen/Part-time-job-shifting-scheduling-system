<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateNewAccount.aspx.cs" Inherits="CreateNewAccount" %>

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
                <strong>Login Form</strong>  
            </caption>
            <tr>
                <td><asp:Label ID="Label1" runat="server" Text="Username"></asp:Label></td>
                <td><asp:TextBox ID="TextBox1" runat="server" Width="146px" required ></asp:TextBox></td> 
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"   
                         ControlToValidate="TextBox1" ErrorMessage="Enter username." ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label2" runat="server" Text="Password"></asp:Label></td>
                <td><asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Width="147px"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"   
                         ControlToValidate="TextBox2" ErrorMessage="Enter password." ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr> 
            <tr>
                <td>
                    <asp:dropdownlist id=dropDownListMode runat="server">
                        <asp:listitem value="0">-----請選擇-----</asp:listitem>
                        <asp:listitem value="1" text="Student"></asp:listitem>
                        <asp:listitem value="2" text="Office"></asp:listitem>
                        <asp:listitem value="3" text="Administrator"></asp:listitem>
                    </asp:dropdownlist>
                </td>
            </tr>
            <tr>
                <td><asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Create Account" /></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label3" runat="server"></asp:Label></td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>
