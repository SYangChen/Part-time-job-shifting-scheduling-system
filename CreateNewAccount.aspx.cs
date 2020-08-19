using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class CreateNewAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        TextBox TextBox1 = this.FindControl("TextBox1") as TextBox;
        if (!IsPostBack)
            TextBox1.Focus(); // blink cursor in TextBox1  
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        TextBox TextBox1 = this.FindControl("TextBox1") as TextBox;
        TextBox TextBox2 = this.FindControl("TextBox2") as TextBox;
        Label Label2 = this.FindControl("Label2") as Label;
        string sql; int row;
        string connstr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\DataBase\\2019LAB\\B063040061_DB_Project_WorkingSchedule\\B063040061_DB_Project_WorkingSchedule\\App_Data\\HW2006_demo.mdb;Persist Security Info=True"; //建立連線字串
        OleDbConnection con = new OleDbConnection(connstr);
        // establish connection  
        con.Open(); // connection open  
        // sql query  
        DropDownList dropDownListMode = this.FindControl("dropDownListMode") as DropDownList;
        string str = dropDownListMode.SelectedItem.Text.ToString();
        sql = "INSERT INTO Account(userID, [password], mode) VALUES('" + TextBox1.Text + "','" + TextBox2.Text + "','" + str + "')";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.ExecuteNonQuery();
        Response.Write("<script>alert('Account Created');window.location='Administrator.aspx';</script>");
        // Response.Flush();
        // Response.End();
        // Response.Redirect("Administrator.aspx");
    }
}