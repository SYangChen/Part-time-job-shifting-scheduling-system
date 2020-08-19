using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registration : System.Web.UI.Page
{
    string source = "D:\\DataBase\\2019LAB\\B063040061_DB_Project_WorkingSchedule\\B063040061_DB_Project_WorkingSchedule\\App_Data\\HW2006_demo.mdb";
    protected void Page_Load(object sender, EventArgs e)
    {
        UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        TextBox TextBox1 = this.FindControl("TextBox1") as TextBox;
        if (!IsPostBack)
            TextBox1.Focus(); // blink cursor in TextBox1  
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"];
        TextBox TextBox1 = this.FindControl("TextBox1") as TextBox;
        TextBox TextBox2 = this.FindControl("TextBox2") as TextBox;
        TextBox TextBox3 = this.FindControl("TextBox3") as TextBox;
        TextBox TextBox4 = this.FindControl("TextBox4") as TextBox;
        TextBox TextBox5 = this.FindControl("TextBox5") as TextBox;
        TextBox TextBox6 = this.FindControl("TextBox6") as TextBox;
        string connstr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+source+";Persist Security Info=True"; //建立連線字串
        OleDbConnection objCon = new OleDbConnection(connstr);
        objCon.Open(); // connection open  
        // sql query  
        string sql = "UPDATE Account Set studentName = '"+TextBox1.Text+"', email = '"+TextBox2.Text+"', accountID = '"+TextBox3.Text+"', lab = '"+TextBox4.Text+"', phoneNum = '"+TextBox5.Text+"', [password] = '"+TextBox6.Text+"' WHERE userID = '"+id+"' ;";
        OleDbCommand cmd = new OleDbCommand(sql, objCon);
        cmd.ExecuteNonQuery();
        Response.Write("<script>alert('Save!Please login again.'); window.location='Login.aspx'; </script>");
        // Response.Redirect("Login.aspx");
    }
}