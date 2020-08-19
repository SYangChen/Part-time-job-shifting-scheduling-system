using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator : System.Web.UI.Page
{
    string source = "D:\\DataBase\\2019LAB\\B063040061_DB_Project_WorkingSchedule\\B063040061_DB_Project_WorkingSchedule\\App_Data\\HW2006_demo.mdb";
    protected void Page_Load(object sender, EventArgs e)
    {
        ListAllAccount();
        /*
        Button buttonListAll = this.FindControl("buttonListAll") as Button;
        buttonListAll.Attributes.Add("onclick", "this.form.target='_blank'");
        Button buttonCreate = this.FindControl("buttonCreate") as Button;
        // buttonCreate.Attributes.Add("onclick", "this.form.target='_blank'");
        */
    }
    protected void ListAllAccount()
    {
        string sql;
        string connstr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+source+";Persist Security Info=True"; //建立連線字串
        Label lblOutput = this.FindControl("lblOutput") as Label;
        OleDbConnection objCon = new OleDbConnection(connstr);
        OleDbDataReader objDR;
        // establish connection  
        objCon.Open(); // connection open  
        // sql query  
        sql = "select * from account order by mode";
        OleDbCommand objCmd = new OleDbCommand(sql, objCon);
        objDR = objCmd.ExecuteReader();
        if (objDR.HasRows)
        {
            lblOutput.Text = "資料表紀錄 <hr/><table border=\"1\" cellpadding=\"1\" cellspacing=\"1\" style=\"background - color: #CCCCFF; border: 1px double #808080;\">";
            lblOutput.Text += "<tr><th>userID</th><th>password</th><th>mode</th><th>student name</th><th>e-mail</th><th>account ID</th><th>lab number</th><th>phone number</th></tr>";
            while (objDR.Read())
            {
                lblOutput.Text += "<tr>";
                lblOutput.Text += "<td>" + objDR["userID"] + "</td>";
                lblOutput.Text += "<td>" + objDR["password"] + "</td>";
                lblOutput.Text += "<td>" + objDR["mode"] + "</td>";
                lblOutput.Text += "<td>" + objDR["studentName"] + "</td>";
                lblOutput.Text += "<td>" + objDR["email"] + "</td>";
                lblOutput.Text += "<td>" + objDR["accountID"] + "</td>";
                lblOutput.Text += "<td>" + objDR["lab"] + "</td>";
                lblOutput.Text += "<td>" + objDR["phoneNum"] + "</td>";
                lblOutput.Text += "</tr>";
            }
            lblOutput.Text += "</table>";
        }
        else
        {
            lblOutput.Text += "沒有紀錄";
        }
        objCon.Close(); // connection close 
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        TextBox TextBox1 = this.FindControl("TextBox1") as TextBox;
        TextBox TextBox2 = this.FindControl("TextBox2") as TextBox;
        string sql;
        string connstr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+source+";Persist Security Info=True"; //建立連線字串
        OleDbConnection con = new OleDbConnection(connstr);
        // establish connection  
        con.Open(); // connection open  
        // sql query  
        DropDownList dropDownListMode = this.FindControl("dropDownListMode") as DropDownList;
        string str = dropDownListMode.SelectedItem.Text.ToString();
        sql = "INSERT INTO Account(userID, [password], mode) VALUES('" + TextBox1.Text + "','" + TextBox2.Text + "','" + str + "')";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.ExecuteNonQuery();
        con.Close();
        Response.Write("<script>alert('Account Created');window.location='Administrator.aspx';</script>");
        // ListAllAccount();
        // Response.Flush();
        // Response.End();
        // Response.Redirect("Administrator.aspx");
    }
    
    protected void ButtonDelUsr_Click( object sender, EventArgs e )
    {
        TextBox TextBoxDelUsr = this.FindControl("TextBoxDelUsr") as TextBox;
        string sql;
        string connstr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+source+";Persist Security Info=True"; //建立連線字串
        OleDbConnection con = new OleDbConnection(connstr);
        // establish connection  
        con.Open(); // connection open  
        // sql query  
        sql = "DELETE * FROM Account WHERE userID = '" + TextBoxDelUsr.Text + "';";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.ExecuteNonQuery();

        sql = "DELETE * FROM Calendar WHERE userID = '" + TextBoxDelUsr.Text + "';";
        cmd = new OleDbCommand(sql, con);
        cmd.ExecuteNonQuery();

        con.Close();
        Response.Write("<script>alert('Account Deleted');window.location='Administrator.aspx';</script>");
        // ListAllAccount();
    }
    /*
    protected void ButtonListAll_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListAllAccount.aspx") ;
    }
    protected void ButtonCreate_Click(object sender, EventArgs e)
    {
        Response.Redirect("CreateNewAccount.aspx");
    }
    */
    protected void ImgBtn_Logout_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}