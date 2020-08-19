using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Web.Security;

public partial class _Login : System.Web.UI.Page
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
        TextBox TextBox1 = this.FindControl("TextBox1") as TextBox;
        TextBox TextBox2 = this.FindControl("TextBox2") as TextBox;
        Label Label2 = this.FindControl("Label2") as Label;
        string sql; int row;
        string connstr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+source+";Persist Security Info=True"; //建立連線字串
        OleDbConnection con = new OleDbConnection(connstr);
        OleDbDataReader objDR;
        // establish connection  
        con.Open(); // connection open  
        // sql query  
        sql = "select * from account where userID='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        // row = (int)cmd.ExecuteScalar(); // cast into integer and ExecuteScalar() get single value from database. 
        objDR = cmd.ExecuteReader();
        if (objDR.HasRows)
        {
            objDR.Read();
            Label2.Text = "Username or Password is valid...";
            if ((string)objDR["mode"] == "Administrator")
                Response.Redirect("Administrator.aspx");
            else if (objDR.IsDBNull(objDR.GetOrdinal("studentName")))
                Response.Redirect("Registration.aspx?id=" + (string)objDR["userID"]);     // passing value to another page
            else if ((string)objDR["mode"] == "Office")
                Response.Redirect("CSEOffice.aspx");
            else
            {
                // passing multiple value to another page
                string url = String.Format("Calendar.aspx?id={0}&name={1}", (string)objDR["userID"], (string)objDR["studentName"]);
                Response.Redirect(url);
            }
        }
        else if (string.IsNullOrWhiteSpace(TextBox2.Text))
        {
            sql = "select count(*) from account where userID='" + TextBox1.Text + "' ;";
            cmd = new OleDbCommand(sql, con);
            row = (int)cmd.ExecuteScalar();
            if (row > 0)
                Response.Write("<script>alert('Your ID has already been created!');</script>");
            else
            {
                string password = Membership.GeneratePassword(8, 0);
                Label2.Text = "Created! Please check your email!";
                // Response.Write("<script>alert('Account Created."+Environment.NewLine+"Please check your email.');</script>");
                sql = "INSERT INTO Account( userid, [password], mode ) values('" + TextBox1.Text + "', '" + password + "', 'Student' )";
                cmd = new OleDbCommand(sql, con);
                cmd.ExecuteNonQuery();
                // https://ithelp.ithome.com.tw/articles/10190120
                // try
                // {
                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                msg.To.Add(TextBox1.Text + "@student.nsysu.edu.tw");
                //msg.To.Add("b@b.com");可以發送給多人
                //msg.CC.Add("c@c.com");
                //msg.CC.Add("c@c.com");可以抄送副本給多人 
                //這裡可以隨便填，不是很重要
                msg.From = new MailAddress("dbmsnsysu@gmail.com", "DBMS_demo", System.Text.Encoding.UTF8);
                /* 上面3個參數分別是發件人地址（可以隨便寫），發件人姓名，編碼*/
                msg.Subject = "[Working_Scheduler] Create Account";//郵件標題
                msg.SubjectEncoding = System.Text.Encoding.UTF8;//郵件標題編碼
                msg.Body = "This is your password : " + password; //郵件內容
                msg.BodyEncoding = System.Text.Encoding.UTF8;//郵件內容編碼 
                                                             // msg.Attachments.Add(new Attachment(@"D:\DataBase\2019LAB\test.docx"));  //附件
                msg.IsBodyHtml = true;//是否是HTML郵件 
                                      //msg.Priority = MailPriority.High;//郵件優先級 

                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential("dbmsnsysu@gmail.com", "nsysudbms"); //這裡要填正確的帳號跟密碼
                client.Host = "smtp.gmail.com"; //設定smtp Server
                client.Port = 25; //設定Port
                client.EnableSsl = true; //gmail預設開啟驗證
                client.Send(msg); //寄出信件
                client.Dispose();
                msg.Dispose();
                // MessageBox.Show(this, "郵件寄送成功！");
                // }
                // catch (Exception ex)
                // {
                // MessageBox.Show(this, ex.Message);
                //    Response.Redirect("Default.aspx");
                // }
            }
        }
        else
            Label2.Text = "Username or Password is invalid...";
        con.Close(); // connection close 
    }
}