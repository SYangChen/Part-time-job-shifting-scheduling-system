<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administrator.aspx.cs" Inherits="Administrator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Administrator</h1>
            <br />
            <div>
                <asp:Label ID="lblOutput" runat="server" ForeColor="Blue"></asp:Label>
            </div>
            <br />
                <div>
                <table>  
                <tr>
                    <td>Create Account : </td>
                    <td><asp:Label ID="Label1" runat="server" Text="Username"></asp:Label></td>
                    <td><asp:TextBox ID="TextBox1" runat="server" Width="146px"></asp:TextBox></td> 
                
                    <td><asp:Label ID="Label2" runat="server" Text="Password"></asp:Label></td>
                    <td><asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Width="147px"></asp:TextBox></td>
                    <td>
                        <asp:dropdownlist id=dropDownListMode runat="server">
                            <asp:listitem value="1" text="Student"></asp:listitem>
                            <asp:listitem value="2" text="Office"></asp:listitem>
                            <asp:listitem value="3" text="Administrator"></asp:listitem>
                        </asp:dropdownlist>
                    </td>
                    <td><asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Create" /></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label3" runat="server"></asp:Label></td>
                </tr>
            </table>
            </div>
            <div>
            <table>  
            <tr>
                <td>Delete Account : </td>
                <td><asp:Label ID="LabelDelUsr" runat="server" Text="Username"></asp:Label></td>
                <td><asp:TextBox ID="TextBoxDelUsr" runat="server" Width="146px"></asp:TextBox></td> 
                
                
                <td><asp:Button ID="ButtonDelUsr" runat="server" onclick="ButtonDelUsr_Click" Text="Delete" /></td>
            </tr>
            </table>
            </div>
            <br />
            <asp:ImageButton ID="ImageButtonLogout" runat="server" ImageAlign="Left" ImageUrl ="images/Logout.png" OnClick="ImgBtn_Logout_Click" Width="30"></asp:ImageButton>
        </div>
    </form>
</body>
</html>
