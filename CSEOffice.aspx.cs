using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CSEOffice : System.Web.UI.Page
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

    protected void ButtonGetStudentData_Click(object sender, EventArgs e)
    {
        TextBox inputDate = this.FindControl("inputDate") as TextBox;
        string inputDate_string = inputDate.Text;
        Response.Redirect("ListStudentDetails.aspx?date="+inputDate_string);
    }
    protected void ImgBtn_Logout_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}