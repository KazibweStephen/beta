using System;
using System.Data;
using System.Drawing;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NewBet.gbl
{
    public partial class ViewOnLineBets : System.Web.UI.Page
    {
        AdminClass admin = new AdminClass();
        customers beta = new customers();
        Login log = new Login();
        PhoneCustomer bets = new PhoneCustomer();
        int cnt = 0, Count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    Session["adminsearchkey"] = "";
                    datePicker();
                    Session["selecteddate"] = DateTime.Today;
                    currentDate.Text = DateTime.Today.ToLongDateString();
                    Session["enddate"] = DateTime.Today.AddDays(1);
                    All();
                    smscount.Text = "" + gvParentGrid.Rows.Count;
                }
            }
        }
        protected void All()
        {

            admin.DOT = DateTime.Today;
            admin.DOT2 = DateTime.Today.AddDays(1);
            gvParentGrid.DataSource = admin.getbetidsbydateONLINE();
            gvParentGrid.DataBind();

        }

        protected void gvUserInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 0; i < gvParentGrid.Columns.Count; i++)
                {
                    e.Row.Cells[i].ToolTip = gvParentGrid.Columns[i].HeaderText;
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (TableCell gvcell in e.Row.Cells)
                {
                    gvcell.ToolTip = gvcell.Text;
                }
                GridView gv = (GridView)e.Row.FindControl("gvChildGrid");
                int bet_Id = Convert.ToInt32(e.Row.Cells[1].Text);
                int setsize = 1;
                try
                {
                    setsize = Convert.ToInt32(e.Row.Cells[5].Text);
                }
                catch (Exception exp) { };
                admin.betId = bet_Id;
                gv.DataSource = admin.getplayerbets();
                gv.DataBind();
                cnt++;
                Label lblpercent = (Label)e.Row.FindControl("lblPrediction");
                HtmlTable tblpercent = (HtmlTable)e.Row.FindControl("tblBar");
                decimal perc = 0;
                try
                {
                    perc = Math.Round(((Convert.ToDecimal(admin.getbetpredictions()) / setsize) * 100), 0);
                }
                catch (Exception exp)
                {

                }
                tblpercent.Width = perc.ToString() + "%";
                if (perc == 0)
                {
                    tblpercent.Visible = false;
                }
                else
                {
                    e.Row.CssClass = "TablePollResultFoot";
                }
                try
                {
                    lblpercent.Text = Math.Round(((Convert.ToDecimal(admin.getbetpredictions()) / setsize) * 100), 0).ToString();
                }
                catch (Exception exp)
                {

                }

                // perc = int.Parse(lblpercent.Text.ToString());       
                if (perc == 0)
                {
                    lblpercent.ForeColor = Color.Red;
                }
                else if (perc > 0 && perc <= 35)
                {
                    lblpercent.ForeColor = Color.Red;
                }
                else if (perc > 35 && perc <= 50)
                {
                    lblpercent.ForeColor = Color.Orange;
                }
                else if (perc > 50 && perc <= 70)
                {
                    lblpercent.ForeColor = Color.LightBlue;
                }
                else if (perc > 70 && perc <= 100)
                {
                    lblpercent.ForeColor = Color.Green;
                }
                else
                {
                    lblpercent.ForeColor = Color.RosyBrown;
                }


            }

            foreach (TableCell tc in e.Row.Cells)
            {
                tc.Attributes["style"] = "border-color:#CCCCCC";
            }
        }

        public string getstatus(string status)
        {
            int st = Convert.ToInt16(status);
            if (st == 1)
            {
                return "Waiting result";
            }
            else if (st == 2)
            {
                return "Won";
            }
            else if (st == -1)
            {
                return "postponed";
            }
            else if (st == 3)
            {
                return "Won Sh.0";
            }
            else if (st == 0)
            {
                return "Bet not Active";
            }
            else { return ""; }

        }

        protected void childbind(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && !String.IsNullOrEmpty(e.Row.Cells[0].Text))
            {
                string betType = e.Row.Cells[1].Text;
                string matno = e.Row.Cells[0].Text;
                string betChoice = e.Row.Cells[5].Text;
                TableCell oddCell = e.Row.Cells[6];
                DataSet dt = admin.getmatchodds(Convert.ToInt32(matno));

                if (betType.ToLower().Contains("straight"))
                {
                    if (betChoice.ToLower().Contains("home"))
                        e.Row.Cells[6].Text = dt.Tables[0].Rows[0]["oddhome"].ToString();
                    else if (betChoice.ToLower().Contains("draw"))
                        e.Row.Cells[6].Text = dt.Tables[0].Rows[0]["odddraw"].ToString();
                    else if (betChoice.ToLower().Contains("away"))
                        e.Row.Cells[6].Text = dt.Tables[0].Rows[0]["oddaway"].ToString();
                }
                else if (betType.ToLower().Contains("wire"))
                {
                    if (betChoice.ToLower().Contains("over"))
                        e.Row.Cells[6].Text = dt.Tables[0].Rows[0]["overodd"].ToString();
                    else if (betChoice.ToLower().Contains("under"))
                        e.Row.Cells[6].Text = dt.Tables[0].Rows[0]["underodd"].ToString();
                }
                else if (betType.ToLower().Contains("dc"))
                {
                    if (betChoice.ToLower().Contains("1x"))
                        e.Row.Cells[6].Text = dt.Tables[0].Rows[0]["DCHD"].ToString();
                    else if (betChoice.ToLower().Contains("x2") || betChoice.ToLower().Contains("2x"))
                        e.Row.Cells[6].Text = dt.Tables[0].Rows[0]["DCDA"].ToString();
                    else if (betChoice.ToLower().Contains("12"))
                        e.Row.Cells[6].Text = dt.Tables[0].Rows[0]["DCHA"].ToString();
                }

                else if (betType.ToLower().Contains("halftime"))
                {
                    if (betChoice.ToLower().Contains("home"))
                        e.Row.Cells[6].Text = dt.Tables[0].Rows[0]["HfHome"].ToString();
                    else if (betChoice.ToLower().Contains("draw"))
                        e.Row.Cells[6].Text = dt.Tables[0].Rows[0]["HfDraw"].ToString();
                    else if (betChoice.ToLower().Contains("away"))
                        e.Row.Cells[6].Text = dt.Tables[0].Rows[0]["HfAway"].ToString();
                }

                else if (betType.ToLower().Contains("hc"))
                {
                    if (betChoice.Contains("Home"))
                        e.Row.Cells[6].Text = dt.Tables[0].Rows[0]["Hchomeodd"].ToString();
                    else if (betChoice.Contains("Draw"))
                        e.Row.Cells[6].Text = dt.Tables[0].Rows[0]["Hcdrawodd"].ToString();
                    else if (betChoice.Contains("Away"))
                        e.Row.Cells[6].Text = dt.Tables[0].Rows[0]["Hcawayodd"].ToString();
                    e.Row.Cells[3].Text = e.Row.Cells[3].Text + " (HC Goals: " + dt.Tables[0].Rows[0]["Hchomegoals"].ToString() + ":" + dt.Tables[0].Rows[0]["Hcawaygoals"].ToString() + ")";
                }
                else if (betType.ToLower().Contains("oddeven"))
                {
                    if (betChoice.ToLower().Contains("odd"))
                        e.Row.Cells[6].Text = dt.Tables[0].Rows[0]["oddodd"].ToString();
                    else if (betChoice.ToLower().Contains("even"))
                        e.Row.Cells[6].Text = dt.Tables[0].Rows[0]["oddeven"].ToString();
                }
            }

        }



        public string getstatus(string status, string totalodd, string betmoney)
        {
            int st = 0;
            if (int.TryParse(status, out st))
            {
                st = Convert.ToInt16(status);

                if (st == 1)
                {
                    return "Waiting result";
                }
                else if (st == 2)
                {
                    try
                    {
                        decimal betmoneys = Convert.ToDecimal(betmoney);
                        decimal todd = Convert.ToDecimal(totalodd);
                        decimal tmoney = betmoneys * todd;
                        tmoney = Math.Round(tmoney, 0);
                        return "Won Sh." + tmoney.ToString();
                    }
                    catch (Exception e)
                    {
                        return "WON";
                    }
                }
                else if (st == -1)
                {
                    return "postponed";
                }
                else if (st == 3)
                {
                    return "Won Sh.0";
                }
                else if (st == 0)
                {
                    return "Bet not Active";
                }
                else { return ""; }
            }
            else
            {

                return status;
            }

        }
        public string getPrediction(string id, string size)
        {
            admin.betId = Convert.ToInt32(id);
            decimal pred = admin.SetPrediction();
            return pred.ToString();
        }
        public string getWin(string odd, int size)
        {
            decimal win = 0;
            if (decimal.TryParse(odd, out win))
            {
                decimal wins = win * size;
                return wins.ToString();
            }
            return "";
        }
        public string getpredictions(string oddname, string normal, string wire, string bettype)
        {
            bettype = bettype.Trim();
            if (bettype == "wire")
            {
                return wire;
            }
            else if (bettype == "Straight")
            {
                return normal;
            }
            else if (bettype == "dc")
            {

                return normal;
            }
            return "";
        }

        public string getphoto(string oddname, string normal, string wire, string bettype)
        {
            string pic = "~/images/InfoIcon.png";
            oddname = oddname.Trim().ToLower();
            bettype = bettype.Trim().ToLower();
            if ((!string.IsNullOrEmpty(oddname)) && (!string.IsNullOrEmpty(normal)))
            {
                if (bettype == "straight")
                {
                    if (oddname == normal.Trim().ToLower())
                    {
                        pic = "~/images/ok.png";
                    }
                    else
                    {
                        pic = "~/images/cancel.png";
                    }

                }
                else if (bettype == "wire")
                {
                    if (oddname == wire.Trim().ToLower())
                    {
                        pic = "~/images/ok.png";
                    }
                    else
                    {
                        pic = "~/images/cancel.png";
                    }
                }
                else if (bettype == "dc")
                {
                    if (oddname == "1x")
                    {

                        if ((normal.Trim().ToLower() == "draw") || (normal.Trim().ToLower() == "home") || (normal.Trim().ToLower() == "1x"))
                        {
                            pic = "~/images/ok.png";
                        }
                        else
                        {
                            pic = "~/images/cancel.png";
                        }
                    }
                    else if (oddname == "2x")
                    {

                        if ((normal.Trim().ToLower() == "draw") || (normal.Trim().ToLower() == "away") || (normal.Trim().ToLower() == "x2"))
                        {
                            pic = "~/images/ok.png";
                        }
                        else
                        {
                            pic = "~/images/cancel.png";
                        }
                    }
                    else if (oddname == "12")
                    {

                        if ((normal.Trim().ToLower() == "home") || (normal.Trim().ToLower() == "away"))
                        {
                            pic = "~/images/ok.png";
                        }
                        else
                        {
                            pic = "~/images/cancel.png";
                        }
                    }
                    else
                    {
                        pic = "~/images/cancel.png";
                    }

                }



                return pic;
            }
            return pic;
        }



        protected void gvParentGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvParentGrid.PageIndex = e.NewPageIndex;
            string keyword = Session["adminsearchkey"].ToString();
            if (keyword != null && keyword != "")
            {
                bindByKeyword(keyword);
                return;
            }
            DateTime startDate = (DateTime)Session["selecteddate"];
            DateTime endDate = (DateTime)Session["enddate"];
            bindByDate(startDate, endDate);
        }

        #region date navigation


        private void bindByDate(DateTime startDate, DateTime endDate)
        {
            admin.DOT = startDate;
            admin.DOT2 = endDate;
            gvParentGrid.DataSource = admin.getbetidsbydateONLINE();
            gvParentGrid.DataBind();
            smscount.Text = "" + gvParentGrid.Rows.Count;
        }

        private void datePicker()
        {
            DateTime today = DateTime.Today;
            startDay.DataSource = GlobalBetsAdmin.getDays(DateTime.Now.Month);
            startDay.DataBind();
            startMonth.DataSource = GlobalBetsAdmin.getMonths();
            startMonth.DataBind();
            startYear.DataSource = GlobalBetsAdmin.getYears();
            startYear.DataBind();

            endDay.DataSource = GlobalBetsAdmin.getDays(5);
            endDay.DataBind();
            endMonth.DataSource = GlobalBetsAdmin.getMonths();
            endMonth.DataBind();
            endYear.DataSource = GlobalBetsAdmin.getYears();
            endYear.DataBind();

            //change dates on dropdwon navigation
            startDay.SelectedValue = today.Day.ToString();
            startMonth.SelectedValue = GlobalBetsAdmin.MONTH[today.Month - 1];
            startYear.SelectedValue = today.Year.ToString();
            endDay.SelectedValue = today.Day.ToString();
            endMonth.SelectedValue = GlobalBetsAdmin.MONTH[today.Month - 1];
            endYear.SelectedValue = today.Year.ToString();
        }

        protected void navigateByDate_Click(object sender, EventArgs e)
        {
            string start = startYear.SelectedValue + "-" + GlobalBetsAdmin.getMonthSqlValue(startMonth.SelectedValue) + "-" + startDay.SelectedValue + " 00:00:00.000";
            string end = endYear.SelectedValue + "-" + GlobalBetsAdmin.getMonthSqlValue(endMonth.SelectedValue) + "-" + endDay.SelectedValue + " 23:59:59.999";
            DateTime startDate = Convert.ToDateTime(start);
            DateTime endDate = Convert.ToDateTime(end);
            if (endDate > DateTime.Today)
            {
                endDate = DateTime.Today.AddDays(1);
            }
            bindByDate(startDate, endDate);
            currentDate.Text = startDate.ToLongDateString() + " to " + endDate.ToLongDateString();
            Session["selecteddate"] = startDate;
            Session["enddate"] = endDate;
        }

        protected void startMonth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void endMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            string start = endYear.SelectedValue + "-" + GlobalBetsAdmin.getMonthSqlValue(endMonth.SelectedValue) + "-" + endDay.SelectedValue + " 00:00:00.000";
            DateTime startDate = Convert.ToDateTime(start);
            Session["selecteddate"] = startDate;
        }

        protected void startDay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void startYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void endDay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void endYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void today_Click(object sender, EventArgs e)
        {
            DateTime endDate = DateTime.Today.AddDays(1); ;
            DateTime startDate = DateTime.Today;
            currentDate.Text = DateTime.Today.ToLongDateString();
            //change dates on dropdwon navigation
            startDay.SelectedValue = startDate.Day.ToString();
            startMonth.SelectedValue = GlobalBetsAdmin.MONTH[startDate.Month - 1];
            startYear.SelectedValue = startDate.Year.ToString();
            endDay.SelectedValue = startDate.Day.ToString();
            endMonth.SelectedValue = GlobalBetsAdmin.MONTH[startDate.Month - 1];
            endYear.SelectedValue = startDate.Year.ToString();
            bindByDate(startDate, endDate);
            Session["selecteddate"] = startDate;
            Session["enddate"] = endDate;
        }

        protected void previusDay_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = (DateTime)Session["selecteddate"];
            DateTime startDate = selectedDate.AddDays(-1);
            DateTime endDate = startDate.AddDays(1);
            currentDate.Text = startDate.ToLongDateString();
            bindByDate(startDate, endDate);
            Session["selecteddate"] = startDate;
            Session["enddate"] = endDate;

            //change dates on dropdwon navigation
            startDay.SelectedValue = startDate.Day.ToString();
            startMonth.SelectedValue = GlobalBetsAdmin.MONTH[startDate.Month - 1];
            startYear.SelectedValue = startDate.Year.ToString();
            endDay.SelectedValue = startDate.Day.ToString();
            endMonth.SelectedValue = GlobalBetsAdmin.MONTH[startDate.Month - 1];
            endYear.SelectedValue = startDate.Year.ToString();
        }
        protected void nextDay_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = (DateTime)Session["selecteddate"];
            if (selectedDate >= DateTime.Today)
            {
                return;
            }
            DateTime startDate = selectedDate.AddDays(1);
            DateTime endDate = startDate.AddDays(1);
            bindByDate(startDate, endDate);
            currentDate.Text = startDate.ToLongDateString();
            Session["selecteddate"] = startDate;
            Session["enddate"] = endDate;

            //change dates on dropdwon navigation
            startDay.SelectedValue = startDate.Day.ToString();
            startMonth.SelectedValue = GlobalBetsAdmin.MONTH[startDate.Month - 1];
            startYear.SelectedValue = startDate.Year.ToString();
            endDay.SelectedValue = startDate.Day.ToString();
            endMonth.SelectedValue = GlobalBetsAdmin.MONTH[startDate.Month - 1];
            endYear.SelectedValue = startDate.Year.ToString();
        }
        #endregion

        #region search
        protected void search_Click(object sender, EventArgs e)
        {
            string keyword = searchtext.Text.ToString();
            Session["adminsearchkey"] = keyword;
            bindByKeyword(keyword);
            currentDate.Text = "Search Keyword: \"" + keyword + "\"";
            status.Text = gvParentGrid.Rows.Count + " rows returned.";
        }

        private void bindByKeyword(string keyword)
        {
            gvParentGrid.DataSource = GlobalBetsAdmin.searchCompleteBets(keyword, GlobalBetsAdmin.ONLINE);
            gvParentGrid.DataBind();
            smscount.Text = "" + gvParentGrid.Rows.Count;
        }

        #endregion
    }
}