using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListStudentDetails : System.Web.UI.Page
{
    string source = "D:\\DataBase\\2019LAB\\B063040061_DB_Project_WorkingSchedule\\B063040061_DB_Project_WorkingSchedule\\App_Data\\HW2006_demo.mdb";
    protected void Page_Load(object sender, EventArgs e)
    {
        string sql;
        string connstr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+source+";Persist Security Info=True"; //建立連線字串
        Label lblOutput = this.FindControl("lblOutput") as Label;
        OleDbConnection objCon = new OleDbConnection(connstr);
        OleDbDataReader objDR;
        // establish connection  
        objCon.Open(); // connection open  
        // sql query  
        sql = "SELECT DISTINCT Account.* FROM Account, Calendar WHERE Account.userid = Calendar.userid AND workingDay = #" + Request.QueryString["date"] + "#;";
        OleDbCommand objCmd = new OleDbCommand(sql, objCon);
        objDR = objCmd.ExecuteReader();
        if (objDR.HasRows)
        {
            lblOutput.Text = "Detail of Day : <hr/><table border=\"1\" cellpadding=\"1\" cellspacing=\"1\" style=\"background - color: #CCCCFF; border: 1px double #808080;\">";
            lblOutput.Text += "<tr><th>userID</th><th>Name</th><th>email</th><th>Account ID</th><th>Lab</th><th>Phone</th></tr>";
            while (objDR.Read())
            {
                lblOutput.Text += "<tr>";
                lblOutput.Text += "<td>" + objDR["userID"] + "</td>";
                lblOutput.Text += "<td>" + objDR["studentName"] + "</td>";
                lblOutput.Text += "<td>" + objDR["email"] + "</td>";
                lblOutput.Text += "<td>" + objDR["accountid"] + "</td>";
                lblOutput.Text += "<td>" + objDR["lab"] + "</td>";
                lblOutput.Text += "<td>" + objDR["phonenum"] + "</td>";
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