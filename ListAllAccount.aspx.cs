using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class ListAllAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string sql;
        string connstr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\DataBase\\2019LAB\\B063040061_DB_Project_WorkingSchedule\\B063040061_DB_Project_WorkingSchedule\\App_Data\\HW2006_demo.mdb;Persist Security Info=True"; //建立連線字串
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
                lblOutput.Text += "<td>" + objDR["userID"] + "</td>" ;
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
}