using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;


public partial class Calender : System.Web.UI.Page
{
    string source = "D:\\DataBase\\2019LAB\\B063040061_DB_Project_WorkingSchedule\\B063040061_DB_Project_WorkingSchedule\\App_Data\\HW2006_demo.mdb";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            ReloadCalendar(DateTime.Now.Date.ToString());
    }
    private void ReloadCalendar(string InquireMonth)
    {
        //清空頁面的DataList物件
        DL_BookingCalendar.DataBind();
        //需求顯示的年份
        string IM_Year = "";
        //需求顯示的月份
        string IM_Month = "";
        //需求顯示月份的第一天
        string IM_First = "";
        //需求顯示月份的最後一天
        string IM_Last = "";

        IM_Year = DateTime.Parse(InquireMonth).Year.ToString();
        IM_Month = DateTime.Parse(InquireMonth).Month.ToString();
        IM_First = IM_Year + "/" + IM_Month + "/1";
        IM_Last = DateTime.DaysInMonth(int.Parse(IM_Year), int.Parse(IM_Month)).ToString();
        string test = "2020/1/1";
        string testAMorPM = "AM";
        string[] holidays = new string[] { "2020/1/1", "2020/2/28", "2020/4/4", "2020/4/5", "2020/5/1", "2020/10/10" };

        //設定顯示的抬頭字樣
        Calendar_L.Text = "";
        Calendar_L.Text = IM_Year + "年" + IM_Month + "月";

        DataTable DT_BC = new DataTable();
        DT_BC.Columns.Add("SUN_T");
        DT_BC.Columns.Add("SUN_B");
        DT_BC.Columns.Add("SUN_B2");
        DT_BC.Columns.Add("MON_T");
        DT_BC.Columns.Add("MON_B");
        DT_BC.Columns.Add("MON_B2");
        DT_BC.Columns.Add("TUE_T");
        DT_BC.Columns.Add("TUE_B");
        DT_BC.Columns.Add("TUE_B2");
        DT_BC.Columns.Add("WED_T");
        DT_BC.Columns.Add("WED_B");
        DT_BC.Columns.Add("WED_B2");
        DT_BC.Columns.Add("THU_T");
        DT_BC.Columns.Add("THU_B");
        DT_BC.Columns.Add("THU_B2");
        DT_BC.Columns.Add("FRI_T");
        DT_BC.Columns.Add("FRI_B");
        DT_BC.Columns.Add("FRI_B2");
        DT_BC.Columns.Add("SAT_T");
        DT_BC.Columns.Add("SAT_B");
        DT_BC.Columns.Add("SAT_B2");

        //設定第一週的內容
        int iM = 0;
        switch (DateTime.Parse(IM_First).DayOfWeek.ToString())
        {
            case "Sunday":
                {
                    DataRow DR_BC = DT_BC.NewRow();
                    DR_BC["SUN_T"] = "1";
                    DR_BC["SUN_B"] = "weekend";
                    DR_BC["SUN_B2"] = "weekend";

                    DR_BC["MON_T"] = "2";
                    DR_BC["MON_B"] = "";
                    DR_BC["MON_B2"] = "";

                    DR_BC["TUE_T"] = "3";
                    DR_BC["TUE_B"] = "";
                    DR_BC["TUE_B2"] = "";

                    DR_BC["WED_T"] = "4";
                    DR_BC["WED_B"] = "";
                    DR_BC["WED_B2"] = "";

                    DR_BC["THU_T"] = "5";
                    DR_BC["THU_B"] = "";
                    DR_BC["THU_B2"] = "";

                    DR_BC["FRI_T"] = "6";
                    DR_BC["FRI_B"] = "";
                    DR_BC["FRI_B2"] = "";

                    DR_BC["SAT_T"] = "7";
                    DR_BC["SAT_B"] = "weekend";
                    DR_BC["SAT_B2"] = "weekend";

                    DT_BC.Rows.Add(DR_BC);
                    iM = 7;
                    break;
                }
            case "Monday":
                {
                    DataRow DR_BC = DT_BC.NewRow();
                    DR_BC["SUN_T"] = "";
                    DR_BC["SUN_B"] = "";
                    DR_BC["SUN_B2"] = "";

                    DR_BC["MON_T"] = "1";
                    DR_BC["MON_B"] = "";
                    DR_BC["MON_B2"] = "";

                    DR_BC["TUE_T"] = "2";
                    DR_BC["TUE_B"] = "";
                    DR_BC["TUE_B2"] = "";

                    DR_BC["WED_T"] = "3";
                    DR_BC["WED_B"] = "";
                    DR_BC["WED_B2"] = "";

                    DR_BC["THU_T"] = "4";
                    DR_BC["THU_B"] = "";
                    DR_BC["THU_B2"] = "";

                    DR_BC["FRI_T"] = "5";
                    DR_BC["FRI_B"] = "";
                    DR_BC["FRI_B2"] = "";

                    DR_BC["SAT_T"] = "6";
                    DR_BC["SAT_B"] = "weekend";
                    DR_BC["SAT_B2"] = "weekend";
                    DT_BC.Rows.Add(DR_BC);
                    iM = 6;
                    break;
                }
            case "Tuesday":
                {
                    DataRow DR_BC = DT_BC.NewRow();
                    DR_BC["SUN_T"] = "";
                    DR_BC["SUN_B"] = "";
                    DR_BC["SUN_B2"] = "";

                    DR_BC["MON_T"] = "";
                    DR_BC["MON_B"] = "";
                    DR_BC["MON_B2"] = "";

                    DR_BC["TUE_T"] = "1";
                    DR_BC["TUE_B"] = "";
                    DR_BC["TUE_B2"] = "";

                    DR_BC["WED_T"] = "2";
                    DR_BC["WED_B"] = "";
                    DR_BC["WED_B2"] = "";

                    DR_BC["THU_T"] = "3";
                    DR_BC["THU_B"] = "";
                    DR_BC["THU_B2"] = "";

                    DR_BC["FRI_T"] = "4";
                    DR_BC["FRI_B"] = "";
                    DR_BC["FRI_B2"] = "";

                    DR_BC["SAT_T"] = "5";
                    DR_BC["SAT_B"] = "weekend";
                    DR_BC["SAT_B2"] = "weekend";
                    DT_BC.Rows.Add(DR_BC);
                    iM = 5;
                    break;
                }
            case "Wednesday":
                {
                    DataRow DR_BC = DT_BC.NewRow();
                    DR_BC["SUN_T"] = "";
                    DR_BC["SUN_B"] = "";
                    DR_BC["SUN_B2"] = "";

                    DR_BC["MON_T"] = "";
                    DR_BC["MON_B"] = "";
                    DR_BC["MON_B2"] = "";

                    DR_BC["TUE_T"] = "";
                    DR_BC["TUE_B"] = "";
                    DR_BC["TUE_B2"] = "";

                    DR_BC["WED_T"] = "1";
                    DR_BC["WED_B"] = "";
                    DR_BC["WED_B2"] = "";

                    DR_BC["THU_T"] = "2";
                    DR_BC["THU_B"] = "";
                    DR_BC["THU_B2"] = "";

                    DR_BC["FRI_T"] = "3";
                    DR_BC["FRI_B"] = "";
                    DR_BC["FRI_B2"] = "";

                    DR_BC["SAT_T"] = "4";
                    DR_BC["SAT_B"] = "weekend";
                    DR_BC["SAT_B2"] = "weekend";
                    DT_BC.Rows.Add(DR_BC);
                    iM = 4;
                    break;
                }
            case "Thursday":
                {
                    DataRow DR_BC = DT_BC.NewRow();
                    DR_BC["SUN_T"] = "";
                    DR_BC["SUN_B"] = "";
                    DR_BC["SUN_B2"] = "";

                    DR_BC["MON_T"] = "";
                    DR_BC["MON_B"] = "";
                    DR_BC["MON_B2"] = "";

                    DR_BC["TUE_T"] = "";
                    DR_BC["TUE_B"] = "";
                    DR_BC["TUE_B2"] = "";

                    DR_BC["WED_T"] = "";
                    DR_BC["WED_B"] = "";
                    DR_BC["WED_B2"] = "";

                    DR_BC["THU_T"] = "1";
                    DR_BC["THU_B"] = "";
                    DR_BC["THU_B2"] = "";

                    DR_BC["FRI_T"] = "2";
                    DR_BC["FRI_B"] = "";
                    DR_BC["FRI_B2"] = "";

                    DR_BC["SAT_T"] = "3";
                    DR_BC["SAT_B"] = "weekend";
                    DR_BC["SAT_B2"] = "weekend";
                    DT_BC.Rows.Add(DR_BC);
                    iM = 3;
                    break;
                }
            case "Friday":
                {
                    DataRow DR_BC = DT_BC.NewRow();
                    DR_BC["SUN_T"] = "";
                    DR_BC["SUN_B"] = "";
                    DR_BC["SUN_B2"] = "";

                    DR_BC["MON_T"] = "";
                    DR_BC["MON_B"] = "";
                    DR_BC["MON_B2"] = "";

                    DR_BC["TUE_T"] = "";
                    DR_BC["TUE_B"] = "";
                    DR_BC["TUE_B2"] = "";

                    DR_BC["WED_T"] = "";
                    DR_BC["WED_B"] = "";
                    DR_BC["WED_B2"] = "";

                    DR_BC["THU_T"] = "";
                    DR_BC["THU_B"] = "";
                    DR_BC["THU_B2"] = "";

                    DR_BC["FRI_T"] = "1";
                    DR_BC["FRI_B"] = "";
                    DR_BC["FRI_B2"] = "";

                    DR_BC["SAT_T"] = "2";
                    DR_BC["SAT_B"] = "weekend";
                    DR_BC["SAT_B2"] = "weekend";
                    DT_BC.Rows.Add(DR_BC);
                    iM = 2;
                    break;
                }
            case "Saturday":
                {
                    DataRow DR_BC = DT_BC.NewRow();
                    DR_BC["SUN_T"] = "";
                    DR_BC["SUN_B"] = "";
                    DR_BC["SUN_B2"] = "";

                    DR_BC["MON_T"] = "";
                    DR_BC["MON_B"] = "";
                    DR_BC["MON_B2"] = "";

                    DR_BC["TUE_T"] = "";
                    DR_BC["TUE_B"] = "";
                    DR_BC["TUE_B2"] = "";

                    DR_BC["WED_T"] = "";
                    DR_BC["WED_B"] = "";
                    DR_BC["WED_B2"] = "";

                    DR_BC["THU_T"] = "";
                    DR_BC["THU_B"] = "";
                    DR_BC["THU_B2"] = "";

                    DR_BC["FRI_T"] = "";
                    DR_BC["FRI_B"] = "";
                    DR_BC["FRI_B2"] = "";

                    DR_BC["SAT_T"] = "1";
                    DR_BC["SAT_B"] = "weekend";
                    DR_BC["SAT_B2"] = "weekend";
                    DT_BC.Rows.Add(DR_BC);
                    iM = 1;
                    break;
                }
        }
        if (iM > 0)
        {
            //設定未達最後一週的內容
            iM++;
            while ((iM + 7) <= int.Parse(IM_Last))
            {
                DataRow DR_BC = DT_BC.NewRow();
                DR_BC["SUN_T"] = (iM++).ToString();
                DR_BC["SUN_B"] = "weekend";
                DR_BC["SUN_B2"] = "weekend";

                DR_BC["MON_T"] = (iM++).ToString();
                DR_BC["MON_B"] = "";
                DR_BC["MON_B2"] = "";

                DR_BC["TUE_T"] = (iM++).ToString();
                DR_BC["TUE_B"] = "";
                DR_BC["TUE_B2"] = "";

                DR_BC["WED_T"] = (iM++).ToString();
                DR_BC["WED_B"] = "";
                DR_BC["WED_B2"] = "";

                DR_BC["THU_T"] = (iM++).ToString();
                DR_BC["THU_B"] = "";
                DR_BC["THU_B2"] = "";

                DR_BC["FRI_T"] = (iM++).ToString();
                DR_BC["FRI_B"] = "";
                DR_BC["FRI_B2"] = "";

                DR_BC["SAT_T"] = (iM++).ToString();
                DR_BC["SAT_B"] = "weekend";
                DR_BC["SAT_B2"] = "weekend";

                DT_BC.Rows.Add(DR_BC);
            }
        }
        if (iM > 0)
        {
            //設定最後一週的內容
            DataRow DR_BC = DT_BC.NewRow();

            if (iM <= int.Parse(IM_Last))
            {
                DR_BC["SUN_T"] = iM.ToString();
                DR_BC["SUN_B"] = "weekend";
                DR_BC["SUN_B2"] = "weekend";
                iM++;
            }
            else
            {
                DR_BC["SUN_T"] = "";
                DR_BC["SUN_B"] = "";
                DR_BC["SUN_B2"] = "";
            }

            if (iM <= int.Parse(IM_Last))
            {
                DR_BC["MON_T"] = iM.ToString();
                DR_BC["MON_B"] = "";
                DR_BC["MON_B2"] = "";
                iM++;
            }
            else
            {
                DR_BC["MON_T"] = "";
                DR_BC["MON_B"] = "";
                DR_BC["MON_B2"] = "";
            }

            if (iM <= int.Parse(IM_Last))
            {
                DR_BC["TUE_T"] = iM.ToString();
                DR_BC["TUE_B"] = "";
                DR_BC["TUE_B2"] = "";
                iM++;
            }
            else
            {
                DR_BC["TUE_T"] = "";
                DR_BC["TUE_B"] = "";
                DR_BC["TUE_B2"] = "";
            }

            if (iM <= int.Parse(IM_Last))
            {
                DR_BC["WED_T"] = iM.ToString();
                DR_BC["WED_B"] = "";
                DR_BC["WED_B2"] = "";
                iM++;
            }
            else
            {
                DR_BC["WED_T"] = "";
                DR_BC["WED_B"] = "";
                DR_BC["WED_B2"] = "";
            }

            if (iM <= int.Parse(IM_Last))
            {
                DR_BC["THU_T"] = iM.ToString();
                DR_BC["THU_B"] = "";
                DR_BC["THU_B2"] = "";
                iM++;
            }
            else
            {
                DR_BC["THU_T"] = "";
                DR_BC["THU_B"] = "";
                DR_BC["THU_B2"] = "";
            }

            if (iM <= int.Parse(IM_Last))
            {
                DR_BC["FRI_T"] = iM.ToString();
                DR_BC["FRI_B"] = "";
                DR_BC["FRI_B2"] = "";
                iM++;
            }
            else
            {
                DR_BC["FRI_T"] = "";
                DR_BC["FRI_B"] = "";
                DR_BC["FRI_B2"] = "";
            }

            if (iM <= int.Parse(IM_Last))
            {
                DR_BC["SAT_T"] = iM.ToString();
                DR_BC["SAT_B"] = "weekend";
                DR_BC["SAT_B2"] = "weekend";
                iM++;
            }
            else
            {
                DR_BC["SAT_T"] = "";
                DR_BC["SAT_B"] = "";
                DR_BC["SAT_B2"] = "";
            }

            DT_BC.Rows.Add(DR_BC);
        }
        for (int dayIndex = 0; dayIndex < holidays.Length; ++dayIndex)
        {
            test = holidays[dayIndex];
            if (DateTime.Parse(test).Year.ToString() == DateTime.Parse(IM_First).Year.ToString() && DateTime.Parse(test).Month.ToString() == DateTime.Parse(IM_First).Month.ToString())
            {
                for (int i = 0; i < DT_BC.Rows.Count; ++i)
                {
                    for (int j = 0; j <= 18; j += 3)
                    {
                        if (DT_BC.Rows[i][j].ToString() == DateTime.Parse(test).Day.ToString())
                        {
                            DT_BC.Rows[i][j + 1] = "holiday";
                            DT_BC.Rows[i][j + 2] = "holiday";
                        }
                    }
                }
            }
        }
        string sql;
        string connstr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+source+";Persist Security Info=True"; //建立連線字串
        OleDbConnection objCon = new OleDbConnection(connstr);  // establish connection 
        OleDbDataReader objDR;  // datareader
        objCon.Open(); // connection open  
        // sql query  
        sql = "select * from Calendar";
        OleDbCommand objCmd = new OleDbCommand(sql, objCon);
        objDR = objCmd.ExecuteReader();
        if (objDR.HasRows)
        {
            while (objDR.Read())
            {
                test = objDR["workingDay"].ToString();
                testAMorPM = objDR["AMorPM"].ToString();
                string name = objDR["studentName"].ToString();
                string cname = objDR["agentName"].ToString() + " (代)";
                bool changed = (bool)objDR["changed"];
                if (DateTime.Parse(test).Year.ToString() == DateTime.Parse(IM_First).Year.ToString() && DateTime.Parse(test).Month.ToString() == DateTime.Parse(IM_First).Month.ToString())
                {
                    for (int i = 0; i < DT_BC.Rows.Count; ++i)
                    {
                        for (int j = 0; j <= 18; j += 3)
                        {
                            if (DT_BC.Rows[i][j].ToString() == DateTime.Parse(test).Day.ToString())
                            {
                                int k = (testAMorPM == "上午" ? 1 : 2);
                                DT_BC.Rows[i][j + k] = (changed ? cname : name);
                            }
                        }
                    }
                }
            }
        }
        objCon.Close(); // connection close

        DL_BookingCalendar.DataSource = DT_BC;
        DL_BookingCalendar.DataBind();

    }

    protected void ImgBtn_NowMonth_Click(object sender, ImageClickEventArgs e)
    {
        ReloadCalendar(DateTime.Now.Date.ToString());
    }
    protected void ImgBtn_PreviousMonth_Click(object sender, ImageClickEventArgs e)
    {
        if (Calendar_L.Text != "")
        {
            //擷取目前頁面顯示的月份
            string DL_Month = Calendar_L.Text;
            DL_Month = DL_Month.Substring(0, 4) + "/"
                            + DL_Month.Replace("年", "").Replace("月", "").Substring(4) + "/1";
            //呼叫副程式顯示上個月
            ReloadCalendar(DateTime.Parse(DL_Month).AddMonths(-1).ToString());
        }
    }
    protected void ImgBtn_NextMonth_Click(object sender, ImageClickEventArgs e)
    {
        if (Calendar_L.Text != "")
        {
            //擷取目前頁面顯示的月份
            string DL_Month = Calendar_L.Text;
            DL_Month = DL_Month.Substring(0, 4) + "/"
                            + DL_Month.Replace("年", "").Replace("月", "").Substring(4) + "/1";
            //呼叫副程式顯示下個月
            ReloadCalendar(DateTime.Parse(DL_Month).AddMonths(+1).ToString());
        }
    }

    protected void ImgBtn_Print_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("PrintMyWorkSchedule.aspx?id='" + Request.QueryString["id"] + "'");
    }

    protected void ButtonSchedule_Click(object sender, EventArgs e)
    {
        TextBox inputDate = this.FindControl("inputDate") as TextBox;
        DropDownList ddlAMorPM = this.FindControl("ddlAMorPM") as DropDownList;
        string inputDate_string = inputDate.Text;
        string AMorPM_string = ddlAMorPM.Text;
        string sql;
        string connstr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + source + ";Persist Security Info=True"; //建立連線字串
        string[] holidays = new string[] { "2020/1/1", "2020/2/28", "2020/4/4", "2020/4/5", "2020/5/1", "2020/10/10" };
        bool holy = false;  // is holiday
        if (DateTime.Parse(inputDate_string) < DateTime.Today)
        {
            Response.Write("<script>alert('Past day! Please choose again.');</script>");
            holy = true;
        }
        else
        {
            for (int i = 0; i < holidays.Length; ++i)
            {
                if (DateTime.Parse(holidays[i]).Month == DateTime.Parse(inputDate_string).Month
                    && DateTime.Parse(holidays[i]).Day == DateTime.Parse(inputDate_string).Day)
                {
                    Response.Write("<script>alert('" + DateTime.Parse(inputDate_string).ToShortDateString() + " is holiday!');</script>");
                    holy = true;
                }
            }
            if (DateTime.Parse(inputDate_string).DayOfWeek.ToString() == "Saturday"
                || DateTime.Parse(inputDate_string).DayOfWeek.ToString() == "Sunday")
            {
                Response.Write("<script>alert('" + DateTime.Parse(inputDate_string).ToShortDateString() + " is weekend!');</script>");
                holy = true;
            }
            OleDbConnection con = new OleDbConnection(connstr);
            // establish connection  
            con.Open(); // connection open  
                        // sql query
            sql = "Select count(*) FROM Calendar WHERE workingDay = #" + DateTime.Parse(inputDate_string).ToShortDateString() + "# AND AMorPM = '" + AMorPM_string + "';";
            OleDbCommand cmd = new OleDbCommand(sql, con);
            int a = (int)cmd.ExecuteScalar();
            if (a > 0)
            {
                Response.Write("<script>alert('" + DateTime.Parse(inputDate_string).ToShortDateString() + " has already been chosen!');</script>");
                holy = true;
            }
            con.Close();
        }
        if (!holy)
        {
            OleDbConnection con = new OleDbConnection(connstr);
            // establish connection  
            con.Open(); // connection open 
            sql = "INSERT INTO Calendar( userid, studentname, workingday, amorpm, changed ) " +
                  "values('" + Request.QueryString["id"] + "', '" + Request.QueryString["name"] + "', '" +
                  DateTime.Parse(inputDate_string).ToShortDateString() + "', '" + AMorPM_string + "', '0' )";
            OleDbCommand cmd = new OleDbCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('" + DateTime.Parse(inputDate_string).ToShortDateString() + AMorPM_string + "');</script>");
            ReloadCalendar(DateTime.Parse(inputDate_string).ToString());
            con.Close();
        }
    }

    protected void MessageToOffice()
    {
        string connstr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + source + ";Persist Security Info=True"; //建立連線字串
        OleDbConnection con = new OleDbConnection(connstr);
        // establish connection  
        con.Open(); // connection open  
        string sql = "SELECT * FROM Account WHERE mode = 'Office';";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        OleDbDataReader objDR = cmd.ExecuteReader();
        cmd = new OleDbCommand(sql, con);
        objDR = cmd.ExecuteReader();
        List<string> strlist = new List<string>();
        if (objDR.HasRows)
        {
            while (objDR.Read())
            {
                strlist.Add((string)objDR["email"]);

            }            // msg.To.Add((string)objDR["email"]);
            // msg.To.Add("yang870313@gmail.com");
        }
        // https://ithelp.ithome.com.tw/articles/10190120
        // try
        // {
        System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
        foreach (string str in strlist)
        {
            msg.To.Add(str);
        }
        
        //msg.To.Add("b@b.com");可以發送給多人
        //msg.CC.Add("c@c.com");
        //msg.CC.Add("c@c.com");可以抄送副本給多人 
        //這裡可以隨便填，不是很重要
        msg.From = new MailAddress("dbmsnsysu@gmail.com", "DBMS_demo", System.Text.Encoding.UTF8);
        /* 上面3個參數分別是發件人地址（可以隨便寫），發件人姓名，編碼*/
        msg.Subject = "[Working_Scheduler] 值班更換代理人";//郵件標題
        msg.SubjectEncoding = System.Text.Encoding.UTF8;//郵件標題編碼
        msg.Body = tbTPName.Text + " will cover for me!" + System.Environment.NewLine + "Edit by " + Request.QueryString["name"]; //郵件內容
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
        con.Close();
    }

    protected void ButtonTemporaryPost_Click(object sender, EventArgs e)
    {
        TextBox inputDate = this.FindControl("inputDate") as TextBox;
        TextBox tbTPName = this.FindControl("tbTPName") as TextBox;
        DropDownList ddlAMorPM = this.FindControl("ddlAMorPM") as DropDownList;
        string inputDate_string = inputDate.Text;// DateTime.Parse(inputDate.Text).ToShortDateString();
        string AMorPM_string = ddlAMorPM.Text;
        string sql;
        string connstr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + source + ";Persist Security Info=True"; //建立連線字串
        OleDbConnection con = new OleDbConnection(connstr);
        // establish connection  
        con.Open(); // connection open  
        // sql query
        sql = "SELECT * FROM Calendar WHERE userID = '" + Request.QueryString["id"] + "' AND workingDay = #" + inputDate_string + "# AND AMorPM = '" + AMorPM_string + "';";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        OleDbDataReader objDR = cmd.ExecuteReader();
        if (DateTime.Parse(inputDate_string) < DateTime.Today)
        {
            Response.Write("<script>alert('Past day! Please choose again.');</script>");
        }
        else if (objDR.HasRows)
        {
            objDR.Read();
            if ( (bool)objDR["changed"] )
                Response.Write("<script>alert('Somebody has already filled in for you.');</script>");
            else
            {
                sql = "UPDATE Calendar SET changed = 1, agentName = '" + tbTPName.Text + "' WHERE changed = 0 AND userID = '" + Request.QueryString["id"] +
                      "' AND workingDay = #" + inputDate_string + "# AND AMorPM = '" + AMorPM_string + "';";
                cmd = new OleDbCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Got it!');</script>");
                ReloadCalendar(DateTime.Parse(inputDate_string).ToString());
                MessageToOffice();
            }
        }
        else
            Response.Write("<script>alert('The time you picked is not in your working schedule.');</script>");

        con.Close();
    }

    protected void ImgBtn_Logout_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

}
