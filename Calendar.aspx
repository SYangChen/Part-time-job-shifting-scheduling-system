<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="Calender" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <header><h1>Student Working Schedule</h1></header>
    <center>
        <form id="form1" runat="server">
            <table border="0" cellpadding="1" cellspacing="1" style="background-color: #FFFFFF; border: 1px double #FFFFFF;">
                <tr>
                    <td bgcolor="#FFFFFF" align="left" valign="middle" width="100">
                        &nbsp;
                    </td>
                    <td bgcolor="#FFFFFF" align="right" valign="middle" width="100">
                        <asp:ImageButton ID="ImgBtn_PreviousMonth" runat="server" ImageUrl="images/ToPrevious.png" OnClick="ImgBtn_PreviousMonth_Click"></asp:ImageButton>
                    </td>
                    <td bgcolor="#FFFFFF" align="center" valign="middle" width="300">
                        <asp:Label ID="Calendar_L" runat="server" Text="" Font-Size="14" Font-Names="微軟正黑體" ForeColor="Black" Font-Bold="True"></asp:Label>
                    </td>
                    <td bgcolor="#FFFFFF" align="left" valign="middle" width="100">
                        <asp:ImageButton ID="ImgBtn_NextMonth" runat="server" ImageUrl="images/ToNext.png" OnClick="ImgBtn_NextMonth_Click"></asp:ImageButton>
                    </td>
                    <td bgcolor="#FFFFFF" align="right" valign="middle" width="100">
                        &nbsp;
                    </td>
                </tr>
            </table>
            <table border="1" cellpadding="1" cellspacing="1" style="background-color: #CCCCFF; border: 1px double #808080;">
                <tr>
                    <td bgcolor="#FFCFCF" align="center" valign="middle" width="100">
                        <asp:Label ID="Week0" runat="server" Text="SUN(日)" Font-Size="12" Font-Names="微軟正黑體" ForeColor="Black" Font-Bold="True"></asp:Label>
                    </td>
                    <td bgcolor="#CFCFCF" align="center" valign="middle" width="100">
                        <asp:Label ID="Week1" runat="server" Text="MON(一)" Font-Size="12" Font-Names="微軟正黑體" ForeColor="Black" Font-Bold="True"></asp:Label>
                    </td>
                    <td bgcolor="#CFCFCF" align="center" valign="middle" width="100">
                        <asp:Label ID="Week2" runat="server" Text="TUE(二)" Font-Size="12" Font-Names="微軟正黑體" ForeColor="Black" Font-Bold="True"></asp:Label>
                    </td>
                    <td bgcolor="#CFCFCF" align="center" valign="middle" width="100">
                        <asp:Label ID="Week3" runat="server" Text="WED(三)" Font-Size="12" Font-Names="微軟正黑體" ForeColor="Black" Font-Bold="True"></asp:Label>
                    </td>
                    <td bgcolor="#CFCFCF" align="center" valign="middle" width="100">
                        <asp:Label ID="Week4" runat="server" Text="THU(四)" Font-Size="12" Font-Names="微軟正黑體" ForeColor="Black" Font-Bold="True"></asp:Label>
                    </td>
                    <td bgcolor="#CFCFCF" align="center" valign="middle" width="100">
                        <asp:Label ID="Week5" runat="server" Text="FRI(五)" Font-Size="12" Font-Names="微軟正黑體" ForeColor="Black" Font-Bold="True"></asp:Label>
                    </td>
                    <td bgcolor="#FFCFCF" align="center" valign="middle" width="100">
                        <asp:Label ID="Week6" runat="server" Text="SAT(六)" Font-Size="12" Font-Names="微軟正黑體" ForeColor="Black" Font-Bold="True"></asp:Label>
                    </td>
                </tr>

                <asp:DataList ID="DL_BookingCalendar" runat="server" BorderWidth="1" cellpadding="1" cellspacing="1">
                    <ItemTemplate>
                        <tr>
                            <td align="left" valign="top" style="border: 1px groove #C0C0C0; background-color: #FFFFFF; width: 100px;">
                                <asp:Label ID="SUN_Title" runat="server" Text='<%# Bind("SUN_T") %>' Font-Size="12" Font-Names="微軟正黑體" ForeColor="Black" Font-Bold="True"></asp:Label>
                                <br />
                                <div style="background-color: #AFEEEE">
                                <asp:Label ID="SUN_Body" runat="server" Text='<%# Bind("SUN_B") %>' Font-Size="10" Font-Names="微軟正黑體" ForeColor="Blue"></asp:Label>
                                </div>
                                <div style="background-color: #FFDAB9">
                                <asp:Label ID="SUN_Body2" runat="server" Text='<%# Bind("SUN_B2") %>' Font-Size="10" Font-Names="微軟正黑體" ForeColor="Red"></asp:Label>
                                </div>
                            </td>
                            <td align="left" valign="top" style="border: 1px groove #C0C0C0; background-color: #FFFFFF; width: 100px;">
                                <asp:Label ID="MON_Title" runat="server" Text='<%# Bind("MON_T") %>' Font-Size="12" Font-Names="微軟正黑體" ForeColor="Black" Font-Bold="True"></asp:Label>
                                <br />
                                <div style="background-color: #AFEEEE">
                                <asp:Label ID="MON_Body" runat="server" Text='<%# Bind("MON_B") %>' Font-Size="10" Font-Names="微軟正黑體" ForeColor="Blue"></asp:Label>
                                </div>
                                <div style="background-color: #FFDAB9">
                                <asp:Label ID="MON_Body2" runat="server" Text='<%# Bind("MON_B2") %>' Font-Size="10" Font-Names="微軟正黑體" ForeColor="Red"></asp:Label>
                                </div>
                            </td>
                            <td align="left" valign="top" style="border: 1px groove #C0C0C0; background-color: #FFFFFF; width: 100px;">
                                <asp:Label ID="TUE_Title" runat="server" Text='<%# Bind("TUE_T") %>' Font-Size="12" Font-Names="微軟正黑體" ForeColor="Black" Font-Bold="True"></asp:Label>
                                <br />
                                <div style="background-color: #AFEEEE">
                                <asp:Label ID="TUE_Body" runat="server" Text='<%# Bind("TUE_B") %>' Font-Size="10" Font-Names="微軟正黑體" ForeColor="Blue"></asp:Label>
                                </div>
                                <div style="background-color: #FFDAB9">
                                <asp:Label ID="TUE_Body2" runat="server" Text='<%# Bind("TUE_B2") %>' Font-Size="10" Font-Names="微軟正黑體" ForeColor="Red"></asp:Label>
                                </div>
                            </td>
                            <td align="left" valign="top" style="border: 1px groove #C0C0C0; background-color: #FFFFFF; width: 100px;">
                                <asp:Label ID="WED_Title" runat="server" Text='<%# Bind("WED_T") %>' Font-Size="12" Font-Names="微軟正黑體" ForeColor="Black" Font-Bold="True"></asp:Label>
                                <br />
                                <div style="background-color: #AFEEEE">
                                <asp:Label ID="WED_Body" runat="server" Text='<%# Bind("WED_B") %>' Font-Size="10" Font-Names="微軟正黑體" ForeColor="Blue"></asp:Label>
                                </div>
                                <div style="background-color: #FFDAB9">
                                <asp:Label ID="WED_Body2" runat="server" Text='<%# Bind("WED_B2") %>' Font-Size="10" Font-Names="微軟正黑體" ForeColor="Red"></asp:Label>
                                </div>
                            </td>
                            <td align="left" valign="top" style="border: 1px groove #C0C0C0; background-color: #FFFFFF; width: 100px;">
                                <asp:Label ID="THU_Title" runat="server" Text='<%# Bind("THU_T") %>' Font-Size="12" Font-Names="微軟正黑體" ForeColor="Black" Font-Bold="True"></asp:Label>
                                <br />
                                <div style="background-color: #AFEEEE">
                                <asp:Label ID="THU_Body" runat="server" Text='<%# Bind("THU_B") %>' Font-Size="10" Font-Names="微軟正黑體" ForeColor="Blue"></asp:Label>
                                </div>
                                <div style="background-color: #FFDAB9">
                                <asp:Label ID="THU_Body2" runat="server" Text='<%# Bind("THU_B2") %>' Font-Size="10" Font-Names="微軟正黑體" ForeColor="Red"></asp:Label>
                                </div>
                            </td>
                            <td align="left" valign="top" style="border: 1px groove #C0C0C0; background-color: #FFFFFF; width: 100px;">
                                <asp:Label ID="FRI_Title" runat="server" Text='<%# Bind("FRI_T") %>' Font-Size="12" Font-Names="微軟正黑體" ForeColor="Black" Font-Bold="True"></asp:Label>
                                <br />
                                <div style="background-color: #AFEEEE">
                                <asp:Label ID="FRI_Body" runat="server" Text='<%# Bind("FRI_B") %>' Font-Size="10" Font-Names="微軟正黑體" ForeColor="Blue"></asp:Label>
                                </div>
                                <div style="background-color: #FFDAB9">
                                <asp:Label ID="FRI_Body2" runat="server" Text='<%# Bind("FRI_B2") %>' Font-Size="10" Font-Names="微軟正黑體" ForeColor="Red"></asp:Label>
                                </div>
                            </td>
                            <td align="left" valign="top" style="border: 1px groove #C0C0C0; background-color: #FFFFFF; width: 100px;">
                                <asp:Label ID="SAT_Title" runat="server" Text='<%# Bind("SAT_T") %>' Font-Size="12" Font-Names="微軟正黑體" ForeColor="Black" Font-Bold="True"></asp:Label>
                                <br />
                                <div style="background-color: #AFEEEE">
                                <asp:Label ID="SAT_Body" runat="server" Text='<%# Bind("SAT_B") %>' Font-Size="10" Font-Names="微軟正黑體" ForeColor="Blue"></asp:Label>
                                </div>
                                <div style="background-color: #FFDAB9">
                                <asp:Label ID="SAT_Body2" runat="server" Text='<%# Bind("SAT_B2") %>' Font-Size="10" Font-Names="微軟正黑體" ForeColor="Red"></asp:Label>
                                </div>
                            </td>
                        </tr>
	                </ItemTemplate>
	            </asp:DataList>
            </table>
            <table border="0" cellpadding="5" cellspacing="0" width="750">
                <tr>
                    <td>
                        <asp:ImageButton ID="ImageButtonLogout" runat="server" ImageAlign="Left" ImageUrl ="images/Logout.png" OnClick="ImgBtn_Logout_Click" Width="30"></asp:ImageButton>
                    </td>
                    <td align="right" valign="meddle" colspan="7">
                        <asp:ImageButton ID="ImgBtn_Print" runat="server" ImageUrl="images/print.jpg" OnClick="ImgBtn_Print_Click" Width="30"></asp:ImageButton>
                        <asp:ImageButton ID="ImgBtn_NowMonth" runat="server" ImageUrl="images/Refresh.png" OnClick="ImgBtn_NowMonth_Click" Width="30"></asp:ImageButton>
                    </td>
                </tr>
            </table>
            <br />
            <asp:Label ID="schudule" runat="server" Text="Schudule" Width="100px"></asp:Label>
            <asp:TextBox ID="inputDate" runat="server" placeholder="From" Text="2019-12-26" Type="date" required></asp:TextBox>
            <asp:DropDownList ID ="ddlAMorPM" runat="server">
                <asp:ListItem Text="AM">上午</asp:ListItem>
                <asp:ListItem Text="PM">下午</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="ButtonSchedule" runat="server" onclick="ButtonSchedule_Click" Text="Submit" />
            <br />
            <asp:Label ID="lblTemporaryPost" runat="server" Text="Temporary Post" Width="150px"></asp:Label>
            <asp:TextBox ID="tbTPName" runat="server" Width="134px"></asp:TextBox>
            <asp:Button ID="btnTemporaryPost" runat="server" onclick="ButtonTemporaryPost_Click" Text="Changed" />
        </form>
    </center>
</body>
</html>
