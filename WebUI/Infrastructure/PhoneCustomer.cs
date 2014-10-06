using System;
using System.Data;
using SRN.DAL;
using System.Net;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

/// <summary>
/// Summary description for PhoneCustomer
/// </summary>
public class PhoneCustomer
{
	public PhoneCustomer()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region Variables
    DBBridge objDBBridge = new DBBridge();
    Login login = new Login();
    protected int _EmployeeId;
    public string goalServeID = "";
    protected string _Name = String.Empty;
    protected DateTime _DOB;
    protected string _Address = String.Empty;
    protected string _City = String.Empty;
    protected string _State = String.Empty;
    protected string _Zip = String.Empty;
    protected string _Phone = String.Empty;
    protected string _Mobile = String.Empty;
    protected string _Email = String.Empty;
    protected string _Designation = String.Empty;
    protected double _payback;
    protected int _DepartmentId;
    protected DateTime _DOJ;
    protected DateTime _DOC;
    protected DateTime _DOT;
    protected DateTime _DOT2;
    protected string _Bio = String.Empty;
    protected string _CancelMessage = String.Empty;
    protected string _paymentid = String.Empty;
    protected string _Degree = String.Empty;
    protected string _Photo = String.Empty;
    protected string _bettedmarches = String.Empty;
    protected string _username = String.Empty;
    protected string _loginName = String.Empty;
    protected string _firstName = String.Empty;
    protected string _securitycode = String.Empty;
    protected string _surname = String.Empty;
    protected string _email = String.Empty;
    protected int _loginId;
    protected int _betid;
    protected int _transid;
    protected DateTime _betdate;
    protected  double _phone;
    protected string _account=string.Empty;
    protected double _handhome;
    protected double _handaway;
    protected string _phone_no = String.Empty;
    protected string _transactions = String.Empty;
    protected string _password = String.Empty;
    protected string _league = String.Empty;
    protected string _matcode = String.Empty;
    protected string _visitor = String.Empty;
    protected string _away = String.Empty;
    protected string _matchno = String.Empty;
    protected string _bet_type = String.Empty;
    protected string _controller= String.Empty;
    public string trans_reason = String.Empty;
    protected string _choice = String.Empty;
    protected string _RecieptID = String.Empty;
    protected int _Status;
    protected int _TeamCode;
    protected int _Years;
    protected int _HomeScore;
    protected int _AwayScore;
    protected double _balance;
    protected double _bought;
    protected double _betted;
    protected double _won;
    protected  decimal _winshare;
    protected decimal _lossshare;
    protected decimal _winaway;
    protected decimal _lossaway;
    protected decimal _losshome;
    protected decimal _winhome;
    protected decimal _balbefore;
    protected decimal _balafter;
    protected string _headlines = String.Empty;
    protected int _rights;
    protected string _oddname = String.Empty;
    protected DateTime _stime;
    protected string _category = String.Empty;
    protected string _host = String.Empty;
    protected string _oddwin = String.Empty;
    protected string _serial = String.Empty;
    protected string _oddlose = String.Empty;
    protected int _hthomescore;
    protected int _htawayscore;
    protected string _home = String.Empty;
    protected string _champ = String.Empty;
    protected string _AgentIds = String.Empty;
    protected string _method = String.Empty;
    protected int _setno;
    protected int _setsize;
    protected int _matno;
    protected decimal _odd;
    protected double _totalammount;
    protected double _totalodd;
    protected int _year;
    protected decimal _betmoney;
    protected decimal _ammount;
    protected decimal _ttmoneywin;
    protected decimal _ttmoneylose;
    protected decimal _ammounts;
    protected int _winningReciepts;
    protected int _lostReciepts;

    const string _spName = "NewRegModel";
    const string _spName1 = "Sp_Admin";
    const string _spName2 = "NewSp";
    #endregion

    #region Class Property
    public int LoginId
    {
        get { return _loginId; }
        set { _loginId = value; }
    }
    public int BetId
    {
        get { return _betid; }
        set { _betid = value; }
    }
    public string RecieptId
    {
        get { return _RecieptID; }
        set { _RecieptID = value; }
    }
    public string Securitycode
    {
        set { _securitycode = value; }
        get { return _securitycode; }

    }
    public int status
    {
        get { return _Status; }
        set { _Status = value; }
    }
    public int setsize
    {
        get { return _setsize; }
        set {_setsize = value; }
    }
    public int winningReciepts
    {
        get { return _winningReciepts; }
        set { _winningReciepts = value; }
    }
    public int lostReciepts
    {
        get { return _lostReciepts; }
        set { _lostReciepts = value; }
    }
    public int HomeScore
    {
        get { return _HomeScore; }
        set { _HomeScore= value; }
    }
    public int AwayScore
    {
        get { return _AwayScore; }
        set { _AwayScore = value; }
    }
    public DateTime betdate
    {
        get { return _betdate; }
        set { _betdate = value; }
    }
    public string visitors
    {
        get { return _visitor; }
        set { _visitor = value; }
    }
    public string controller
    {
        get { return _controller; }
        set { _controller= value; }
    }
    public string host
    {
        get { return _host; }
        set { _host = value; }
    }

    public string AgentIds
    {
        get { return _AgentIds; }
        set { _AgentIds= value; }
    }
    public string CancelMessage
    {
        get { return _CancelMessage; }
        set { _CancelMessage = value; }
    }
    public string securitycode {
        get { return _securitycode; }
        set { _securitycode = value; }
    
    }

    public int trans_id {
        set { _transid = value; }
        get { return _transid; }
    
    }
    public string method
    {
        get { return _method; }
        set { _method = value; }
    }

    public int hthomescore
    {
        get { return _hthomescore; }
        set { _hthomescore = value; }
    }
    public int htawayscore
    {
        get { return _htawayscore; }
        set { _htawayscore= value; }
    }

    public string oddname
    {
        get { return _oddname; }
        set { _oddname= value; }
    }
    public string paymentid
    {
        get { return _paymentid; }
        set { _paymentid= value; }
    }
    public string transaction
    {
        get { return _transactions; }
        set { _transactions = value; }
    }
    public double payback {
        set { _payback = value; }
        get { return _payback; }
    
    }

    public string oddwin
    {
        get { return _oddwin; }
        set { _oddwin = value; }
    }
    public string oddlose
    {
        get { return _oddlose; }
        set { _oddlose = value; }
    }
    public string category
    {
        get { return _category; }
        set { _category = value; }
    }
    public string champ
    {
        get { return _champ; }
        set { _champ= value; }
    }
    public decimal odd
    {
        get { return _odd; }
        set { _odd = value; }
    }
    public double Phone
    {
        get { return _phone; }
        set { _phone = value; }
    }

    public string account
    {
        get { return _account; }
        set {_account= value; }
    }
    public double totalamount
    {
        get { return _totalammount; }
        set { _totalammount= value; }
    }

    public double handhome
    {
        get { return _handhome; }
        set { _handhome = value; }
    }
    public double handaway
    {
        get { return _handaway; }
        set { _handaway= value; }
    }
    public double totalodd
    {
        get { return _totalodd; }
        set { _totalodd = value; }
    }
    public string Phoneno
    {
        get { return _phone_no; }
        set { _phone_no = value; }
    }
    public string Serial
    {
        get { return _serial; }
        set {_serial = value; }
    }
    public decimal betmoney
    {
        get { return _betmoney; }
        set { _betmoney = value; }
    }
    public decimal ttotalwin
    {
        get { return _ttmoneywin; }
        set { _ttmoneywin= value; }
    }
    public decimal ttotallose
    {
        get { return _ttmoneylose; }
        set { _ttmoneylose = value; }
    }
    public decimal winshare
    {
        get { return _winshare; }
        set { _winshare = value; }
    }
    public decimal Ammount
    {
        get { return _ammount; }
        set { _ammount = value; }
    }

    public decimal balbefore
    {
        get { return _balbefore; }
        set { _balbefore = value; }
    }

    public decimal balafter
    {
        get { return _balafter; }
        set { _balafter = value; }
    }

    public decimal lossshare
    {
        get { return _lossshare; }
        set { _lossshare = value; }
    }

    public decimal winhome
    {
        get { return _winhome; }
        set { _winhome= value; }
    }
    public decimal losshome
    {
        get { return _losshome; }
        set { _losshome = value; }
    }
    public decimal lossaway
    {
        get { return _lossaway; }
        set { _lossaway = value; }
    }
    public decimal winaway
    {
        get { return _winaway; }
        set { _winaway = value; }
    }

    public string LoginName
    {
        get { return _loginName; }
        set { _loginName = value; }
    }

    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }
    public string Matchcode
    {
        get { return _matcode; }
        set { _matcode= value; }
    }
    public string Away
    {
        get { return _away; }
        set { _away = value; }
    }
    public string Home
    {
        get { return _home; }
        set { _home = value; }
    }
    public string Bettype
    {
        get { return _bet_type; }
        set { _bet_type= value; }
    }
    public string matchno
    {
        get { return _matchno; }
        set { _matchno = value; }
    }

    public string Username
    {
        get { return _username; }
        set { _username = value; }
    }
    public string Firstname
    {
        get { return _firstName; }
        set { _firstName = value; }
    }
    public string Surname
    {
        get { return _surname; }
        set { _surname = value; }
    }

    public string Password
    {
        get { return _password; }
        set { _password = value; }
    }

    public int Rights
    {
        get { return _rights; }
        set { _rights = value; }
    }
    public int setno
    {
        get { return _setno; }
        set { _setno = value; }
    }

    public int TeamCode
    {
        get { return _TeamCode; }
        set { _TeamCode= value; }
    }
    public int Year
    {
        get { return _year; }
        set { _year = value; }
    }

    public DateTime DOJ
    {
        get { return _DOJ; }
        set { _DOJ = value; }
    }

    public DateTime DOT
    {
        get { return _DOT; }
        set { _DOT = value; }
    }
    public DateTime DOT2
    {
        get { return _DOT2; }
        set { _DOT2 = value; }
    }
    public DateTime StarrtTime
    {
        get { return _stime; }
        set { _stime= value; }
    }

   
    #endregion

    #region Class Methods
    public DataSet GetCustomerBalance()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "CustomerBalance");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet SearchCustomerBalance()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "SearchBalance");
        param[1] = new SqlParameter("@username", _username);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public static void SendVasMessage(string msg, string Destination_number)
    {
        try
        {
            //HttpWebRequest RequesttosendSms = (HttpWebRequest)WebRequest.Create("http://sms.vasgarage.ug/api/sendsms/?msg=" + msg + "&phone=" + Destination_number);
            //RequesttosendSms.Headers.Add("Destination", Destination_number);
            //RequesttosendSms.Headers.Add("msg", msg);
            //HttpWebResponse ResponsetosendSms = (HttpWebResponse)RequesttosendSms.GetResponse();
        }
        catch (Exception e) { }
    }
    public static bool VasMessageException(string msg, string Destination_number)
    {
        try
        {
            //HttpWebRequest RequesttosendSms = (HttpWebRequest)WebRequest.Create("http://sms.vasgarage.ug/api/sendsms/?msg=" + msg + "&phone=" + Destination_number);
            //RequesttosendSms.Headers.Add("Destination", Destination_number);
            //RequesttosendSms.Headers.Add("msg", msg);
            //HttpWebResponse ResponsetosendSms = (HttpWebResponse)RequesttosendSms.GetResponse();
            return true;
        }
        catch (Exception e) {
            return false;
        }
    }
    public DataSet Straightlinegame()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "Straightlinegame");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet GetCustomerBalanceBydate()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "CustomerBalanceBydate");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet GetCustomerDeposits()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "CustomerTransactions");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet PayWinners()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "paydailywinners");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet PayPendingWinners()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "pendingpayrequests");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet PaidRequests()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "completedpayrequests");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public int InsertHalfTimeScoresGoalServe()
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@Mode", "HalfTimeScoresGoalServe");
        param[1] = new SqlParameter("@username", _username);
        param[2] = new SqlParameter("@goalServeID", goalServeID);
        param[3] = new SqlParameter("@hthomescore", _hthomescore);
        param[4] = new SqlParameter("@htawayscore", _htawayscore);
        return objDBBridge.ExecuteNonQuery(_spName, param);
    }
    public int InsertScoresGoalServe()
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@goalServeID", goalServeID);
        param[1] = new SqlParameter("@HomeScore", _HomeScore);
        param[2] = new SqlParameter("@AwayScore", _AwayScore);
        param[3] = new SqlParameter("@hthomescore", _hthomescore);
        param[4] = new SqlParameter("@htawayscore", _htawayscore);
        return objDBBridge.ExecuteNonQuery("EnterScoresGoalServe", param);
    }
    public int ApproveWin()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@TransId", _transid);
        param[1] = new SqlParameter("@controller", _controller);
        param[2] = new SqlParameter("@username", _username);
        int pay = objDBBridge.ExecuteNonQuery("ApproveWin", param);
        if (pay > 0)
        {
            sendwinmessage();
            return 1;
        }
        return 0;
    }
    public DataSet ApprovedWinnersByDate()///select approved winners
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Mode", "ApprovedWinners");
        param[1] = new SqlParameter("@dot", _DOT);
        param[2] = new SqlParameter("@dot2", _DOT2);
        return objDBBridge.ExecuteDataset(_spName1, param);

    }
    public DataSet SelectWinners()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "SelectWinners");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet PaidWinnersbd()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "paidwinners");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet PaidWinsbd()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "paidwins");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet ApprovedPayments()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "AprovedPayments");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet Paybacks()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "paypayback");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet Winnerstocsv()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "exporttocsv");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public int DisableRecieptGame()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "CancelRecieptGame");
        param[1] = new SqlParameter("@MatchNo", _matchno);
        param[2] = new SqlParameter("@betid", _betid);
        DataTable dt = new DataTable();
        dt = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        int opt = 0, exec = 0, canceledreciepts = 0, canceledoodds = 0;
        if (dt.Rows.Count == 1)
        {


            for (int rowNo = 0; rowNo < dt.Rows.Count; rowNo++)
            {
                opt += 1;
                _betid = Convert.ToInt32(dt.Rows[rowNo].ItemArray[2]);
                _username = (dt.Rows[rowNo].ItemArray[3]).ToString();
                _betmoney = Convert.ToDecimal(dt.Rows[rowNo].ItemArray[4]);
                _bet_type = (dt.Rows[rowNo].ItemArray[5]).ToString();
                _oddname = (dt.Rows[rowNo].ItemArray[6]).ToString();
                _setsize = Convert.ToInt16(dt.Rows[rowNo].ItemArray[7]);
                if (_setsize == 1)
                {
                    exec = RefundBetMoney();
                    if (exec > 0)
                    {
                        canceledreciepts += 1;
                        Login log = new Login();
                        log.Username = _username;
                        log.getuser_info();
                        sendsms("" + getMatchTeams(_matchno) + " has been removed from your ticket, no. " + _betid + " due to erroneous odds (Match No: " + _matchno, log.Phoneno);
                    }
                }
                else if (_setsize > 1)
                {
                    exec = CancelSetGame();
                    if (exec > 0)
                    {
                        canceledoodds += 1;
                        Login log = new Login();
                        log.Username = _username;
                        log.getuser_info();
                        sendsms("" + getMatchTeams(_matchno) + " has been removed from your ticket (ReceiptNo: " + _betid + " due to erroneous odds (MatchNo: " + _matchno + ")", log.Phoneno);
                    }
                }
            }
        }
        int wins = GetWinners().Rows.Count;
        int loser = GetLosers().Rows.Count;
        if (wins > 0)
        {
            _CancelMessage = canceledreciepts.ToString() + " reciepts were cancelled and " + canceledoodds.ToString() + " reciepts have been reduced by one game and " + wins.ToString() + " winners approved.";

        }
        else
        {
            _CancelMessage = canceledreciepts.ToString() + " reciepts were cancelled and " + canceledoodds.ToString() + " reciepts have been reduced by one game.";
        }
        return exec;
    }
    public DataSet payRequestsToCSV()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "exportpayrequeststocsv");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet paybacktocsv()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "paybacktocsv");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public string TransCount()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "CountTransactions");

        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["Counts"].ToString();
        }
        return cntEmp;
    }
    public int GetReciept()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@SecurityCode", _securitycode);
        param[1] = new SqlParameter("@Betid", _RecieptID);
        param[2] = new SqlParameter("@mode", "RecieptSerial");
        DataTable dt = new DataTable();
        dt = objDBBridge.ExecuteDataset(_spName1, param).Tables[0];
        if (dt.Rows.Count > 0)
        {
            DataRow drEmployee;
            drEmployee = dt.Rows[0];
            _Status = Convert.ToInt32(drEmployee["status"]);
            return _Status;

        }
        return -11;
    }
    public double getbalance()
    {
        double cntEmp =0;
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "getbalance");
        param[1] = new SqlParameter("@Phoneno", _phone_no);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = Convert.ToDouble(drEmployee["ammount_e"]);
        }
        return cntEmp;
    }
    public void GetPhoneBetter()
    {
        
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "GetPhoneUser");
        param[1] = new SqlParameter("@Phoneno", _phone_no);

        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
           _phone = Convert.ToDouble( drEmployee["PHONE"]);
           _firstName = drEmployee["FIRSTNAME"].ToString();
           _surname = drEmployee["SURNAME"].ToString();
           _Years =Convert.ToInt32( drEmployee["YOB"]);
           _ammount = Convert.ToInt32(drEmployee["ammount_e"]);
        }
       
    }
    public DataTable SureDealMatches()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "SureDealMatches");
        return objDBBridge.ExecuteDataset(_spName, param).Tables[0];
    }
    public int payrequest(int reqid)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@reqid", Convert.ToInt16(reqid));
        param[1] = new SqlParameter("@Mode", "RemovePaymentRequest");
        return objDBBridge.ExecuteNonQuery(_spName1, param);
    }
    public int approvepayment()
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@TransId", _transid);
        param[1] = new SqlParameter("@controller", _controller);
        return objDBBridge.ExecuteNonQuery("Approvepayment", param);
    }
    public DataTable StraightlineMatches()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "Straightlinegame");
        return objDBBridge.ExecuteDataset(_spName, param).Tables[0];
    }
    public DataTable GameAnalysis()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "GameAnalysis");
        param[1] = new SqlParameter("@DOT",_DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);
        return objDBBridge.ExecuteDataset(_spName, param).Tables[0];
    }
    public DataTable GameAnalysisData()
    {// (([HomeTeamForm]+[HomeH2H]+[HomeHomeForm]+[HomeLeagueRating])-([AwayTeamForm]+[AwayH2H]+[AwayAwayForm]+[AwayLeagueRating]) )
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "GameAnalysisData");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);
        return objDBBridge.ExecuteDataset(_spName1, param).Tables[0];
    }
    public DataTable CancelRequests()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "cancelrequests");
        return objDBBridge.ExecuteDataset(_spName2, param).Tables[0];
    }
    public DataTable selectpayback()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "selectpayback");
        return objDBBridge.ExecuteDataset(_spName, param).Tables[0];
    }
    public int InsertBetresults()
    {
        SqlParameter[] param = new SqlParameter[10];
        param[0] = new SqlParameter("@Mode", "betresults1");
        param[1] = new SqlParameter("@category", _category);
        param[2] = new SqlParameter("@Email", _email);
        param[3] = new SqlParameter("@MatchNo", _matno);
        param[4] = new SqlParameter("@host", _host);
        param[5] = new SqlParameter("@visitor", _visitor);
        param[6] = new SqlParameter("@odd", _odd);
        param[7] = new SqlParameter("@oddname", _oddname);
        param[8] = new SqlParameter("@StartTime", _stime);
        param[9] = new SqlParameter("@vs", "Vs");
        return objDBBridge.ExecuteNonQuery(_spName, param);
    }
    public int Insertstmt()
    {
        SqlParameter[] param = new SqlParameter[10];
        param[0] = new SqlParameter("@Mode", "InsertStmt"); 
       param[1] = new SqlParameter("@phoneno",_phone_no);
        param[2] = new SqlParameter("@transcation", _transactions);
       param[3] = new SqlParameter("@method","Site Access");
       param[4] = new SqlParameter("@controller",_phone_no);
       param[5] = new SqlParameter("@betdate", _DOT);
      param[6] = new SqlParameter("@serial", _serial);
      param[7] = new SqlParameter("@balbefore",_balbefore);
      param[8] = new SqlParameter("@ammount",_betmoney);
      param[9] = new SqlParameter("@BalAfter",balafter);
        return objDBBridge.ExecuteNonQuery(_spName, param);
    }
    public int UpdateAccount()
    {
        SqlParameter[] param = new SqlParameter[5];
         param[0] = new SqlParameter("@Mode", "UpdateDeposits");    
         param[1] = new SqlParameter("@Phoneno", _phone_no);
         param[2] = new SqlParameter("@date_e",_DOT);
         param[3] = new SqlParameter("@ammount", _ammount);
         param[4] = new SqlParameter("@admin_e", _username); 
        return objDBBridge.ExecuteNonQuery(_spName, param);
    }
    public int madepaymentbd()
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@mode", "ApprovedPaymentsbd");
        param[1] = new SqlParameter("@dot", _DOT);
        param[2] = new SqlParameter("@dot2", _DOT2);
        return objDBBridge.ExecuteNonQuery(_spName1, param);
    }
    public int Updatepayback()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "updatepayback");
        param[1] = new SqlParameter("@payback", _payback);
        param[2] = new SqlParameter("@username", _username);
        return objDBBridge.ExecuteNonQuery(_spName, param);
    }
    public int setpayback()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "controlpayback");
        param[1] = new SqlParameter("@status",_Status);
        param[2] = new SqlParameter("@username", _username);
        return objDBBridge.ExecuteNonQuery(_spName, param);
    }
    public int UpdateBetterAccount()
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@Mode", "UpdateBetter");
        param[1] = new SqlParameter("@Phoneno", _phone_no);
        param[2] = new SqlParameter("@betdate", _DOT);
        param[3] = new SqlParameter("@ammount", _ammount);
        param[4] = new SqlParameter("@admin_e", _phone_no);
        return objDBBridge.ExecuteNonQuery(_spName, param);
    } 
    public int InitialDeposits()
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@Mode", "InitialDeposit");
        param[1] = new SqlParameter("@Amount", _ammount);
        param[2] = new SqlParameter("@DOJ", _DOJ);
        param[3] = new SqlParameter("@Phoneno", _phone_no);
        param[4] = new SqlParameter("@AgentName", _AgentIds);
       
        return objDBBridge.ExecuteNonQuery(_spName, param);
    }
    public int UpdateBetAccount()
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@amount", _betmoney);
        param[1] = new SqlParameter("@username",_username);
        param[2] = new SqlParameter("@betID",_betid);
        param[3] = new SqlParameter("@method", _method);
        return objDBBridge.ExecuteNonQuery("UpdateBetAccount", param);
    }
    public int UpdateAgentBetAccount()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@amount", _betmoney);
        param[1] = new SqlParameter("@username", _username);
        param[2] = new SqlParameter("@betID", _betid);
        return objDBBridge.ExecuteNonQuery("UpdateBetAccount", param);
    }
    public int InsertSureDealBet()
    {
        SqlParameter[] param = new SqlParameter[18];
        param[0] = new SqlParameter("@Mode", "SureDealBets");
        param[1] = new SqlParameter("@username", _username);
        param[2] = new SqlParameter("@betdate",_betdate);
        param[3] = new SqlParameter("@betmoney", _betmoney);
        param[4] = new SqlParameter("@bet_type", _bet_type);
        param[5] = new SqlParameter("@category", _category);
        param[6] = new SqlParameter("@champ", _champ);
        param[7] = new SqlParameter("@setno", _setno);
        param[8] = new SqlParameter("@MatchNo",_matchno);
        param[9] = new SqlParameter("@host", _host);
        param[10] = new SqlParameter("@vs", "Vs");
        param[11] = new SqlParameter("@visitor", _visitor);
        param[12] = new SqlParameter("@oddname", _oddname);
        param[13] = new SqlParameter("@oddwin", _oddwin);
        param[14] = new SqlParameter("@oddlose", _oddlose);  
        param[15] = new SqlParameter("@StartTime", _stime);
        param[16] = new SqlParameter("@handhome", 0);
        param[17] = new SqlParameter("@handaway", 0);
        return objDBBridge.ExecuteNonQuery(_spName, param);
    }
    public int InsertStraightlineBet()
    {
        SqlParameter[] param = new SqlParameter[17];
        param[0] = new SqlParameter("@Mode", "Straightlinebet");
        param[1] = new SqlParameter("@username", _username);
        param[2] = new SqlParameter("@betdate", _betdate);
        param[3] = new SqlParameter("@betmoney", _ammount);
        param[4] = new SqlParameter("@bet_type", _bet_type);
        param[5] = new SqlParameter("@category", "Straight Line");
        param[6] = new SqlParameter("@champ", _champ);
        param[7] = new SqlParameter("@setno", _setno);
        param[8] = new SqlParameter("@MatchNo", _matchno);
        param[9] = new SqlParameter("@host", _host);
        param[10] = new SqlParameter("@visitor", _visitor);
        param[11] = new SqlParameter("@odd", _odd);
        param[12] = new SqlParameter("@oddname", _oddname);
        param[13] = new SqlParameter("@ttmoneywin", _ttmoneywin);
        param[14] = new SqlParameter("@StartTime", _stime);
        param[15] = new SqlParameter("@handhome", 0);
        param[16] = new SqlParameter("@handaway", 0);
        return objDBBridge.ExecuteNonQuery(_spName, param);
    }
    public int InsertPlayerBet()
    {
        SqlParameter[] param = new SqlParameter[10];
        param[0] = new SqlParameter("@Mode", "insertbet");
        param[1] = new SqlParameter("@username", _username);
        param[2] = new SqlParameter("@betdate", _betdate);
        param[3] = new SqlParameter("@betmoney",_betmoney);
        param[4] = new SqlParameter("@bet_type", _bet_type);
        param[5] = new SqlParameter("@setno", _setno);
        param[6] = new SqlParameter("@MatchNo", Convert.ToInt32(_matchno));
        param[7] = new SqlParameter("@oddname", _oddname);
        param[8] = new SqlParameter("@betid", _betid);
        param[9] = new SqlParameter("@category", _category);
        return objDBBridge.ExecuteNonQuery(_spName, param);
    }
    public int InsertsmsBet()
    {
        SqlParameter[] param = new SqlParameter[10];
        param[0] = new SqlParameter("@Mode", "insertbet");
        param[1] = new SqlParameter("@username", _username);
        param[2] = new SqlParameter("@betdate",DateTime.Now);
        param[3] = new SqlParameter("@betmoney", _betmoney);
        param[4] = new SqlParameter("@bet_type", _bet_type);
        param[5] = new SqlParameter("@setno", _setno);
        param[6] = new SqlParameter("@MatchNo", Convert.ToInt32(_matchno));
        param[7] = new SqlParameter("@oddname", _oddname);
        param[8] = new SqlParameter("@betid", _betid);
        param[9] = new SqlParameter("@category", _category);
        return objDBBridge.ExecuteNonQuery(_spName, param);
    }
    public bool insertbet(String[] arrayitem)
    {
        bool correct = false;
        double ttodd =1;
        _category = "Sms Player Bet";
        for (int i = 1; i < arrayitem.Length - 1; i++)
        {

           ttodd *= insertmatch(Convert.ToInt32(arrayitem[i]));
           correct = true;
           if (ttodd == 0) {
               return false;
           }

        }
        _totalodd = ttodd;

        return correct;
    }
    public DataSet Getwonrecieptbd()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "getwonrecieptbyid");
        param[1] = new SqlParameter("@betid", _RecieptID);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public bool insertagentbet(String[] arrayitem)
    {
        bool correct = false;
        double ttodd = 1;
        _category = "Sms Agent Bet";
        for (int i = 2; i < arrayitem.Length - 1; i++)
        {
            ttodd *= insertmatch(Convert.ToInt32(arrayitem[i]));
            correct = true;
            if (ttodd == 0)
            {
                return false;
            }
        }
        _totalodd = ttodd;
        return correct;
    }
     public double insertmatch(int smscode)
    {
        double sodd = 0;
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@TeamCode", smscode);
        param[1] = new SqlParameter("@mode", "TestTeamscode");
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName1, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow dr;
            dr = dtEmployee.Rows[0];
            _matchno = dr["MatchNo"].ToString();
            _bet_type = dr["bettype"].ToString();
            _choice = dr["choice"].ToString();
            
            if (_bet_type.ToLowerInvariant() == "straight")
            {
                switch (_choice)
                {
                    case "home":
                        sodd = Convert.ToDouble(dr["oddhome"]);
                        _oddname = "home";
                        break;
                    case "draw":
                        sodd = Convert.ToDouble(dr["odddraw"]);
                        _oddname = "draw";
                        break;
                    case "away":
                        _oddname = "away";
                        sodd = Convert.ToDouble(dr["oddaway"]);
                        break;
                    default:
                        sodd = 0;
                        break;

                }
                InsertsmsBet();


            }
          else  if (_bet_type.ToLowerInvariant() == "wire")
            {
                switch (_choice)
                {
                    case "under":
                        sodd = Convert.ToDouble(dr["underodd"]);
                        _oddname = "under";
                        break;
                    case "over":
                        sodd = Convert.ToDouble(dr["overodd"]);
                        _oddname = "over";
                        break;

                    default:
                        sodd = 0;
                        return sodd;
                        break;
                }
                InsertsmsBet();
            }
            else if (_bet_type.ToLowerInvariant() == "oddeven")
            {
                switch (_choice)
                {
                    case "even":
                        sodd = Convert.ToDouble(dr["oddeven"]);
                        _oddname = "even";
                        break;
                    case "odd":
                        sodd = Convert.ToDouble(dr["oddodd"]);
                        _oddname = "odd";
                        break;

                    default:
                        sodd = 0;
                        return sodd;
                        break;
                }
                InsertsmsBet();
            }
            else if (_bet_type.ToLowerInvariant() == "hc")
            {
                switch (_choice)
                {
                    case "hchome":
                        sodd = Convert.ToDouble(dr["hchomeodd"]);
                        _oddname = "home";
                        break;
                    case "hcdraw":
                        sodd = Convert.ToDouble(dr["hcdrawodd"]);
                        _oddname = "draw";
                        break;
                    case "hcaway":
                        sodd = Convert.ToDouble(dr["hcawayodd"]);
                        _oddname = "away";
                        break;

                    default:
                        sodd = 0;
                        return sodd;
                        break;
                }
                InsertsmsBet();
            }
            else if (_bet_type.ToLowerInvariant() == "dc")
            {
                switch (_choice)
                {
                    case "1x":
                        sodd = Convert.ToDouble(dr["dchd"]);
                        _oddname = "1x";
                        break;
                    case "x2":
                        sodd = Convert.ToDouble(dr["dcda"]);
                        _oddname = "x2";
                        break;
                    case "12":
                        sodd = Convert.ToDouble(dr["dcha"]);
                        _oddname = "12";
                        break;

                    default:
                        sodd = 0;
                        return sodd;
                        break;
                }
                InsertsmsBet();
            }
            else if (_bet_type.ToLowerInvariant() == "halftime")
            {
                switch (_choice)
                {
                    case "home":
                        sodd = Convert.ToDouble(dr["hfhome"]);
                        _oddname = "home";
                        break;
                    case "draw":
                        sodd = Convert.ToDouble(dr["hfdraw"]);
                        _oddname = "draw";
                        break;
                    case "away":
                        sodd = Convert.ToDouble(dr["hfaway"]);
                        _oddname = "away";
                        break;

                    default:
                        sodd = 0;
                        return sodd;
                        break;
                }
                InsertsmsBet();
            }
        }
            return sodd;
        
    }
    public int InsertScores()
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@Mode", "EnterScores");
        param[1] = new SqlParameter("@username", _username);
        param[2] = new SqlParameter("@MatchNo", _matchno);
        param[3] = new SqlParameter("@HomeScore", _HomeScore);
        param[4] = new SqlParameter("@AwayScore", _AwayScore);
        return objDBBridge.ExecuteNonQuery(_spName, param);
    }
    public int InsertHalfTimeScores()
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@Mode", "HalfTimeScores");
        param[1] = new SqlParameter("@username", _username);
        param[2] = new SqlParameter("@MatchNo", _matchno);
        param[3] = new SqlParameter("@hthomescore", _hthomescore);
        param[4] = new SqlParameter("@htawayscore", _htawayscore);
        return objDBBridge.ExecuteNonQuery(_spName, param);
    }   
    public int EndSet()
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Mode", "EndSet");
        param[1] = new SqlParameter("@status", _Status);
        param[2] = new SqlParameter("@username", _username);
        param[3] = new SqlParameter("@betid",_betid);
        return objDBBridge.ExecuteNonQuery(_spName1, param);
    }
    public int Addwins(String mode)
    {
        int exec = 0;
        SqlParameter[] parameter = new SqlParameter[5];
        parameter[0] = new SqlParameter("@username", _username);
        parameter[1] = new SqlParameter("@betid", _betid);
        parameter[2] = new SqlParameter("@controller", _controller);
        parameter[3] = new SqlParameter("@MatchNo", _matchno);
        parameter[4] = new SqlParameter("@mode", mode);
        exec = objDBBridge.ExecuteNonQuery("updatesetdetails", parameter);
        return exec;
    }
    public int ApproveScores()
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@Mode", "ApproveScores");
        param[1] = new SqlParameter("@username", _username);
        param[2] = new SqlParameter("@MatchNo", _matchno);
        DataTable dt = new DataTable();
        dt = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        int opt = 0, exec = 0;
        _winningReciepts = 0;
        _lostReciepts = 0;
        if (dt.Rows.Count > 0)
        {
            for (int rowNo = 0; rowNo < dt.Rows.Count; rowNo++)
            {
                opt += 1;
                _betid = Convert.ToInt32(dt.Rows[rowNo].ItemArray[2]);
                _username = (dt.Rows[rowNo].ItemArray[3]).ToString();
                _oddname = (dt.Rows[rowNo].ItemArray[4]).ToString();
                _bet_type = (dt.Rows[rowNo].ItemArray[6]).ToString().Trim();
                _HomeScore = Convert.ToInt32(dt.Rows[rowNo].ItemArray[7]);
                _AwayScore = Convert.ToInt32(dt.Rows[rowNo].ItemArray[8]);
                _hthomescore = Convert.ToInt32(dt.Rows[rowNo].ItemArray[9]);
                _htawayscore = Convert.ToInt32(dt.Rows[rowNo].ItemArray[10]);
                string hchomegoals = (dt.Rows[rowNo].ItemArray[11]).ToString();
                string hcawaygoals = (dt.Rows[rowNo].ItemArray[12]).ToString();
                string winodd = "", winodd1 = "", winodd2 = "";
                if (_bet_type.ToLowerInvariant().Contains("straight"))
                {
                    if (_HomeScore == _AwayScore)
                    {
                        winodd = "draw";
                    }
                    else if (_HomeScore > _AwayScore)
                    {
                        winodd = "home";
                    }
                    else if (_HomeScore < _AwayScore)
                    {
                        winodd = "away";
                    }
                    else
                    {
                        winodd = "";
                    }
                    if (oddname.ToLowerInvariant() == winodd)
                    {
                        exec = Addwins("AddWin");
                        if (exec == 4) {
                            _winningReciepts += 1;
                        }
                    }
                    else
                    {
                        exec = Addwins("addlose");
                        if (exec == 2)
                        {
                            _lostReciepts += 1;
                        }
                    }
                }
                else if (_bet_type.ToLowerInvariant().Contains("wire"))
                {
                    int totalscore = _HomeScore + _AwayScore;
                    if (totalscore < 2.5)
                    {
                        winodd = "under";
                    }
                    else if (totalscore > 2.5)
                    {
                        winodd = "over";

                    }
                    else
                    {

                    }
                    if (oddname.ToLowerInvariant() == winodd)
                    {
                        if (exec == 4)
                        {
                            _winningReciepts += 1;
                        }
                    }
                    else
                    {

                        exec = Addwins("Addlose");
                    }
                }
                else if (_bet_type.ToLowerInvariant().Contains("dc"))
                {

                    if (_HomeScore > AwayScore)
                    {

                        winodd1 = "1x";
                        winodd2 = "12";
                    }
                    else if (_AwayScore > _HomeScore)
                    {

                        winodd1 = "2x";
                        winodd2 = "12";
                    }
                    else if ((_HomeScore == _AwayScore))
                    {

                        winodd1 = "1x";
                        winodd2 = "2x";
                    }
                    else
                    {

                    }
                    if ((oddname.ToLower() == winodd1) || (oddname.ToLower() == winodd2))
                    {
                        exec = Addwins("Addwin");
                        if (exec == 4)
                        {
                            _winningReciepts += 1;
                        }
                    }
                    else
                    {
                        exec = Addwins("Addlose");

                    }

                }
                else if (_bet_type.ToLower().Contains("halftime"))
                {
                        int hthostscore = Convert.ToInt16(_hthomescore);
                        int htvisitorscore = Convert.ToInt16(_htawayscore);

                        if (hthostscore > htvisitorscore)
                        {

                            winodd = "home";
                        }
                        else if (htvisitorscore == hthostscore)
                        {
                            winodd = "draw";

                        }
                        else if (htvisitorscore > hthostscore)
                        {
                            winodd = "away";

                        }
                        else
                        {
                            winodd = "";
                        }
                 
                    if (oddname.ToLower() == winodd)
                    {
                        exec = Addwins("Addwin");
                        if (exec == 4)
                        {
                            _winningReciepts += 1;
                        }
                    }
                    else
                    {
                        exec = Addwins("Addlose");

                    }


                }
                else if (_bet_type.ToLower().Contains("hc"))
                {
                    if ((hchomegoals != "") && (hchomegoals != null) && (hcawaygoals != "") && (hcawaygoals != null))
                    {

                        _HomeScore = Convert.ToInt16(hchomegoals) + _HomeScore;
                        _AwayScore = Convert.ToInt16(hcawaygoals) + _AwayScore;
                        if (_AwayScore > _HomeScore)
                        {
                            winodd = "away";
                        }
                        else if (_AwayScore < _HomeScore)
                        {
                            winodd = "home";
                        }
                        else if (_AwayScore == _HomeScore)
                        {
                            winodd = "draw";
                        }
                        else
                        {
                            winodd = "";
                        }

                    }
                    else
                    {

                        winodd = "";
                    }
                    if (oddname.ToLower() == winodd)
                    {
                        exec = Addwins("Addwin");
                        if (exec == 4)
                        {
                            _winningReciepts += 1;
                        }
                    }
                    else
                    {
                        exec = Addwins("Addlose");

                    }


                }
                else if (_bet_type.ToLower().Contains("oddeven"))
                {

                    int totalscore = _HomeScore + _AwayScore;
                    if (totalscore % 2 == 0)
                    {
                        winodd = "even";

                    }
                    else if (totalscore % 2 != 0)
                    {
                        winodd = "odd";

                    }
                    else
                    {

                        winodd = "";
                    }
                    if (oddname.ToLower() == winodd)
                    {
                        exec = Addwins("Addwin");
                        if (exec == 4)
                        {
                            _winningReciepts += 1;
                        }
                    }
                    else
                    {
                        exec = Addwins("Addlose");

                    }


                }
            }


        }
        return exec;
    }
    public DataTable GetWinners()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "Select_Winners");
        DataTable dt = new DataTable();
        dt = objDBBridge.ExecuteDataset(_spName1, param).Tables[0];
        /*
         int opt = 0, exec=0;
         if (dt.Rows.Count > 0)
         {
             for (int rowNo = 0; rowNo < dt.Rows.Count; rowNo++)
             {
                 opt += 1;
                 _betid = Convert.ToInt32(dt.Rows[rowNo].ItemArray[1]);
                 _username = (dt.Rows[rowNo].ItemArray[0]).ToString().Trim();
                 //TODO returning setodd as null for postponed games
                 try
                 {
                     _odd = Convert.ToDecimal(dt.Rows[rowNo].ItemArray[3]);
                 }
                 catch (Exception exp)
                 {
                     _odd = 1;
                 }
                 _betmoney = Convert.ToDecimal(dt.Rows[rowNo].ItemArray[2]);
                 _ttmoneywin = _odd * _betmoney;
                 if (string.IsNullOrEmpty(_username))
                 {
                     _username = _betid.ToString();
                 }
                // exec = PayWinner();
                 if (exec > 0)
                 {
                     _Status = 2;
                     exec = EndSet();
                 }
             }
             //sendwinmessage();
         }
         else {
             //sendlosersmessage();
         }
         **/
        return dt;
    }
    public DataTable GetMMRequests()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "Select_MM_Requests");
        DataTable dt = new DataTable();
        dt = objDBBridge.ExecuteDataset(_spName1, param).Tables[0];
        return dt;
    }
    public string GetRequestTotal()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "requestpaytotal");
        DataTable dt = new DataTable();
        dt = objDBBridge.ExecuteDataset(_spName1, param).Tables[0];
        return dt.Rows[0]["total"].ToString();
    }
    public DataTable GetApprovedMMRequests()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "Select_Approved_Requests");
        DataTable dt = new DataTable();
        dt = objDBBridge.ExecuteDataset(_spName1, param).Tables[0];
        return dt;
    }
    public DataTable GetLosers()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "Select_Losers");
        DataTable dt = new DataTable();
        dt = objDBBridge.ExecuteDataset(_spName1, param).Tables[0];
        int opt = 0, exec = 0;
        if (dt.Rows.Count > 0)
        {
            for (int rowNo = 0; rowNo < dt.Rows.Count; rowNo++)
            {
                opt += 1;
                _betid = Convert.ToInt32(dt.Rows[rowNo].ItemArray[1]);
                _username = (dt.Rows[rowNo].ItemArray[0]).ToString();
                _payback= Convert.ToDouble(dt.Rows[rowNo].ItemArray[4]);
                _betmoney = Convert.ToDecimal(dt.Rows[rowNo].ItemArray[2]);
               
                if (_payback > 0) {
                    _ttmoneywin =( _betmoney*Convert.ToDecimal( _payback)) / 100;
                   // exec = PayLosers();  //SUREDEAL PAYBACK            
                }
                    _Status = 3;
                    exec = EndSet();
            }
        }
        return dt;
    }
    public int disablegame()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "PostponeGame");
        param[1] = new SqlParameter("@username", _username);
        param[2] = new SqlParameter("@MatchNo", _matchno);
        DataTable dt = new DataTable();
        dt = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        int opt = 0, exec = 0, canceledreciepts = 0, canceledoodds = 0;
        if (dt.Rows.Count > 0)
        {
            for (int rowNo = 0; rowNo < dt.Rows.Count; rowNo++)
            {
                opt += 1;
                _betid =Convert.ToInt32(dt.Rows[rowNo].ItemArray[2]);
                _username = (dt.Rows[rowNo].ItemArray[3]).ToString();
                _betmoney = Convert.ToDecimal(dt.Rows[rowNo].ItemArray[4]);
                _bet_type = (dt.Rows[rowNo].ItemArray[5]).ToString();
                _oddname = (dt.Rows[rowNo].ItemArray[6]).ToString();
                _setsize = Convert.ToInt16(dt.Rows[rowNo].ItemArray[7]);
                if (_setsize == 1)
                {
                    exec = RefundBetMoney();
                    if (exec > 0)
                    {
                        canceledreciepts += 1;
                        Login log = new Login();
                        log.Username = _username;
                        log.getuser_info();
                        sendsms("" + getMatchTeams(_matchno) + " has been removed from your ticket, no. " + _betid + " due to erroneous odds (Match No: " + _matchno, log.Phoneno);
                    }
                }
                else if (_setsize > 1)
                {
                    exec = CancelSetGame();
                    if (exec > 0)
                    {
                        canceledoodds += 1;
                        Login log = new Login();
                        log.Username = _username;
                        log.getuser_info();
                        sendsms("" + getMatchTeams(_matchno) + " has been removed from your ticket (ReceiptNo: " + _betid + " due to erroneous odds (MatchNo: " + _matchno+")", log.Phoneno);
                    }
                }
            }
        }
        int wins = GetWinners().Rows.Count;
        int loser = GetLosers().Rows.Count;
        if (wins > 0)
        {
            _CancelMessage = canceledreciepts.ToString() + " reciepts were cancelled and " + canceledoodds.ToString() + " reciepts have been reduced by one game and " + wins.ToString() + " winners approved.";

        }
        else
        {
            _CancelMessage = canceledreciepts.ToString() + " reciepts were cancelled and " + canceledoodds.ToString() + " reciepts have been reduced by one game.";
        }
        return exec;
    }
    public int postponegame()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "PostponeGame");
        param[1] = new SqlParameter("@username", _username);
        param[2] = new SqlParameter("@MatchNo", _matchno);
        DataTable dt = new DataTable();
        dt = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        int opt = 0, exec = 0, canceledreciepts = 0, canceledoodds = 0;
        if (dt.Rows.Count > 0)
        {
            for (int rowNo = 0; rowNo < dt.Rows.Count; rowNo++)
            {
                opt += 1;
                _betid = Convert.ToInt32(dt.Rows[rowNo].ItemArray[2]);
                _username = (dt.Rows[rowNo].ItemArray[3]).ToString();
                _betmoney = Convert.ToDecimal(dt.Rows[rowNo].ItemArray[4]);
                _bet_type = (dt.Rows[rowNo].ItemArray[5]).ToString();
                _oddname = (dt.Rows[rowNo].ItemArray[6]).ToString();
                _setsize = Convert.ToInt16(dt.Rows[rowNo].ItemArray[7]);
                if (_setsize == 1)
                {
                    exec = RefundBetMoney();
                    if (exec > 0)
                    {
                        canceledreciepts += 1;
                        Login log = new Login();
                        log.Username = _username;
                        log.getuser_info();
						string res = "" + getMatchTeams(_matchno) + " has been postponed or cancelled and effectively removed from your ticket (ReceiptNo: " + _betid + ", (MatchNo: " + _matchno + "). Thank you!";
                        sendsms(res, log.Phoneno); 
						log.Phoneno = log.Phoneno;
						log.Message = res;
						log.MessageId = "GBEAL-SYSTEM"+DateTime.Now.ToString();
						log.source = "GBEAL-SYSTEM";
                        log.recievedsms();
                    }
                }
                else if (_setsize > 1)
                {
                    exec = CancelSetGame();
                    if (exec > 0)
                    {
                        canceledoodds += 1;
                        Login log = new Login();
                        log.Username = _username;
                        log.getuser_info();
                        string res = "" + getMatchTeams(_matchno) + " has been postponed or cancelled and effectively removed from your ticket (ReceiptNo: " + _betid + ", (MatchNo: " + _matchno + "). Thank you!";
                        sendsms(res, log.Phoneno); 
						log.Phoneno = log.Phoneno;
						log.Message = res;
						log.MessageId = "GBEAL-SYSTEM"+DateTime.Now.ToString();
						log.source = "GBEAL-SYSTEM";
                        log.recievedsms();
                    }
                }
            }
        }
        int wins = GetWinners().Rows.Count;
        int loser = GetLosers().Rows.Count;
        if (wins > 0)
        {
            _CancelMessage = canceledreciepts.ToString() + " reciepts were canceled and " + canceledoodds.ToString() + " reciepts have been reduced their setsize by one game and " + wins.ToString() + " winners approved";

        }
        else
        {
            _CancelMessage = canceledreciepts.ToString() + " reciepts were canceled and " + canceledoodds.ToString() + " reciepts have been reduced their setsize by one game";
        }
        return exec;
    }
    public int CancelGame()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "CancelGame");
        param[1] = new SqlParameter("@username", _username);
        param[2] = new SqlParameter("@MatchNo", _matchno);
       return  objDBBridge.ExecuteNonQuery(_spName, param);
    }
    public int postponeErrorGame()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "PostponeGame");
        param[1] = new SqlParameter("@username", _username);
        param[2] = new SqlParameter("@MatchNo", _matchno);
        DataTable dt = new DataTable();
        dt = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        int opt = 0, exec = 0, canceledreciepts = 0, canceledoodds = 0;
        if (dt.Rows.Count > 0)
        {
            for (int rowNo = 0; rowNo < dt.Rows.Count; rowNo++)
            {
                opt += 1;
                _betid = Convert.ToInt32(dt.Rows[rowNo].ItemArray[2]);
                _username = (dt.Rows[rowNo].ItemArray[3]).ToString();
                _betmoney = Convert.ToDecimal(dt.Rows[rowNo].ItemArray[4]);
                _bet_type = (dt.Rows[rowNo].ItemArray[5]).ToString();
                _oddname = (dt.Rows[rowNo].ItemArray[6]).ToString();
                _setsize = Convert.ToInt16(dt.Rows[rowNo].ItemArray[7]);
                if (_setsize == 1)
                {
                    exec = RefundBetMoney();
                    if (exec > 0)
                    {
                        canceledreciepts += 1;
                        Login log = new Login();
                        log.Username = _username;
                        log.getuser_info();
                        string res = "" + getMatchTeams(_matchno) + " has been removed from your ticket (ReceiptNo: " + _betid + " due to erroneous odds (MatchNo: " + _matchno + ")";
                        sendsms(res, log.Phoneno);
                        log.Phoneno = log.Phoneno;
                        log.Message = res;
                        log.MessageId = "GBEAL-SYSTEM" + DateTime.Now.ToString();
                        log.source = "GBEAL-SYSTEM";
                        log.recievedsms();
                    }
                }
                else if (_setsize > 1)
                {
                    exec = CancelSetGame();
                    if (exec > 0)
                    {
                        canceledoodds += 1;
                        Login log = new Login();
                        log.Username = _username;
                        log.getuser_info();
                        string res = "" + getMatchTeams(_matchno) + " has been removed from your ticket (ReceiptNo: " + _betid + " due to erroneous odds (MatchNo: " + _matchno + ")";
                        sendsms(res, log.Phoneno);
                        log.Phoneno = log.Phoneno;
                        log.Message = res;
                        log.MessageId = "GBEAL-SYSTEM" + DateTime.Now.ToString();
                        log.source = "GBEAL-SYSTEM";
                        log.recievedsms();
                    }
                }
            }
        }
        int wins = GetWinners().Rows.Count;
        int loser = GetLosers().Rows.Count;
        if (wins > 0)
        {
            _CancelMessage = canceledreciepts.ToString() + " reciepts were canceled and " + canceledoodds.ToString() + " reciepts have been reduced their setsize by one game and " + wins.ToString() + " winners approved";

        }
        else
        {
            _CancelMessage = canceledreciepts.ToString() + " reciepts were canceled and " + canceledoodds.ToString() + " reciepts have been reduced their setsize by one game";
        }
        return exec;
    }
    public string getoddname(string btype, string bchoice)
    {
        switch (btype.Trim().ToLower())
        {
            case "wire":
                if (bchoice.ToLower() == "over")
                {
                    _oddname = "overodd";
                    break;
                }
                else if (bchoice.ToLower() == "under")
                {
                    _oddname = "underodd";
                    break;
                }
                break;
            case "straight":
                if (bchoice.ToLower() == "home")
                {
                    _oddname = "oddhome";
                    break;
                }
                else if (bchoice.ToLower() == "draw")
                {
                    _oddname = "odddraw";
                    break;
                }
                else if (bchoice.ToLower() == "away")
                {
                    _oddname = "oddaway";
                    break;
                }
                break;
            case "halftime":
                if (bchoice.ToLower() == "home")
                {
                    _oddname = "hfhome";
                    break;
                }
                else if (bchoice.ToLower() == "draw")
                {
                    _oddname = "hfdraw";
                    break;
                }
                else if (bchoice.ToLower() == "away")
                {
                    _oddname = "hfaway";
                    break;
                }
                break;
            case "hc":
                if (bchoice.ToLower() == "1")
                {
                    _oddname = "hchomeodd";
                    break;
                }
                else if (bchoice.ToLower() == "x")
                {
                    _oddname = "hcdrawodd";
                    break;
                }
                else if (bchoice.ToLower() == "2")
                {
                    _oddname = "hcawayodd";
                    break;
                }
                break;
            case "dc":
                if (bchoice.ToLower() == "1x")
                {
                    _oddname = "dchd";
                    break;
                }
                else if (bchoice.ToLower() == "x2")
                {
                    _oddname = "dcda";
                    break;
                }
                else if (bchoice.ToLower() == "12")
                {
                    _oddname = "dcha";
                    break;
                }
                break;

            case "oddeven":
                if (bchoice.ToLower() == "odd")
                {
                    _oddname = "oddodd";
                    break;
                }
                else if (bchoice.ToLower() == "even")
                {
                    _oddname = "oddeven";
                    break;
                }

                break;
            case "bts":
                if (bchoice.ToLower() == "yes")
                {
                    _oddname = "btsy";
                    break;
                }
                else if (bchoice.ToLower() == "no")
                {
                    _oddname = "btsn";
                    break;
                }

                break;
            default:
                _oddname = "";
                break;

        }
        return _oddname;
    }
    public int CancelSetGame()
    {
        SqlParameter[] param = new SqlParameter[6];
        param[1] = new SqlParameter("@amount", _betmoney);
        param[2] = new SqlParameter("@betid", _betid);
        param[3] = new SqlParameter("@MatchNo", _matchno);
        param[4] = new SqlParameter("@controller", _controller);
        param[5] = new SqlParameter("@oddname", getoddname(_bet_type, _oddname));
        return objDBBridge.ExecuteNonQuery("cancelgame", param);
    }
    public int PayWinner()
    {
        SqlParameter[] param = new SqlParameter[4]; 
        param[0] = new SqlParameter("@username", _username);
        param[1] = new SqlParameter("@amount", _ttmoneywin);
        param[2] = new SqlParameter("@betid", _betid);
        param[3] = new SqlParameter("@controller",_controller);
        return objDBBridge.ExecuteNonQuery("PayWinners", param);
    }
    public int Insertuserdeposit()
    {
        string phone = login.getuser_info(_username, Login.PHONENUMBER);
        if (phone == "" || phone == null)
            phone = _username;
        SqlParameter[] param = new SqlParameter[6];
        param[0] = new SqlParameter("@username", _username);
        param[1] = new SqlParameter("@amount", _ammount);
        param[2] = new SqlParameter("@messageid", _paymentid);
        param[3] = new SqlParameter("@controller", _controller);
        param[4] = new SqlParameter("@transaction", trans_reason);
        param[5] = new SqlParameter("@phone", phone);
        return objDBBridge.ExecuteNonQuery("updateaccount", param);
    }
    public int Insertpayoutpayment()
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@username", _username.Trim());
        param[1] = new SqlParameter("@amount", _ammount);
        param[2] = new SqlParameter("@messageid", _paymentid);
        param[3] = new SqlParameter("@controller", _controller);
        return objDBBridge.ExecuteNonQuery("updateaccount", param);
    }
    public int CancelReciept()
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@betid", _betid);
        param[1] = new SqlParameter("@reason", _CancelMessage);
        param[2] = new SqlParameter("@messageid", _paymentid);
        param[3] = new SqlParameter("@controller", _controller);
        return objDBBridge.ExecuteNonQuery("CancelReciept", param);
    }
    public int PayLosers()
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@username", _username);
        param[1] = new SqlParameter("@amount", _ttmoneywin);
        param[2] = new SqlParameter("@betid", _betid);
        param[3] = new SqlParameter("@controller", _controller);
        return objDBBridge.ExecuteNonQuery("PayLosers", param);
    }
    public int PayReciept()
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@username", _username);
        param[1] = new SqlParameter("@amount", _ammount);
        param[2] = new SqlParameter("@betid", _RecieptID);
        param[3] = new SqlParameter("@controller", _username);
        return objDBBridge.ExecuteNonQuery("PayReciept", param);
    }
    public int GetPaymentStatus()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@SecurityCode", _securitycode);
        param[1] = new SqlParameter("@Betid", _RecieptID);
        param[2] = new SqlParameter("@mode", "GetwonSet");
        DataTable dt = new DataTable();
        dt = objDBBridge.ExecuteDataset(_spName1, param).Tables[0];
        if (dt.Rows.Count > 0)
        {
            DataRow drEmployee;
            drEmployee = dt.Rows[0];
            _Status = Convert.ToInt32(drEmployee["paymentstatus"]);
            _betmoney = Convert.ToDecimal(drEmployee["betmoney"]);
            _ttmoneywin = Convert.ToDecimal(drEmployee["wonamount"]);
            _odd = Convert.ToDecimal(drEmployee["setodd"]);
            _betdate = Convert.ToDateTime(drEmployee["betdate"]);
            return _Status;

        }
        return 0;
    }
    public int RefundBetMoney()
    {
        SqlParameter[] param = new SqlParameter[6];
        param[0] = new SqlParameter("@username", _username);
        param[1] = new SqlParameter("@amount", _betmoney);
        param[2] = new SqlParameter("@betid", _betid);
        param[3] = new SqlParameter("@MatchNo", _matchno);
        param[4] = new SqlParameter("@controller", _controller);
        param[5] = new SqlParameter("@oddname", getoddname(_bet_type, _oddname));
        return objDBBridge.ExecuteNonQuery("RefundBetMoney", param);
    }
    public int CancelRequest()
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@username", _username);
        param[1] = new SqlParameter("@betid", _betid);
        param[2] = new SqlParameter("@Reason", _CancelMessage);
        param[3] = new SqlParameter("@controller", _controller);
        return objDBBridge.ExecuteNonQuery("CancelRequest", param);
    }
    public int CancelReciepts()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@username", _username);
        param[1] = new SqlParameter("@betid", _betid);
        param[2] = new SqlParameter("@controller", _controller);
        return objDBBridge.ExecuteNonQuery("CancelReciepts", param);
    }
    public void sendwinmessage() {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@username", _username);
        param[1] = new SqlParameter("@betid", _betid);
        param[2] = new SqlParameter("@Mode", "getresults");
        DataTable dt = new DataTable();
        dt = objDBBridge.ExecuteDataset(_spName1, param).Tables[0];
        int opt = 0, exec = 0;
        string result = "";
        _Phone = login.getuser_info(_username, Login.PHONENUMBER);
        if (dt.Rows.Count > 0)
        {
            DataRow drEmployee;
            for (int rowNo = 0; rowNo < dt.Rows.Count; rowNo++)
            {
                drEmployee = dt.Rows[rowNo];
                _Phone = CollapseSpaces(drEmployee["phone"].ToString());
                result += CollapseSpaces(drEmployee["host"].ToString());
                result += "+";
                result += CollapseSpaces(drEmployee["score"].ToString());
                result += "+";
                result += CollapseSpaces(drEmployee["visitor"].ToString());
                result += ",+";
            }
        }
        string msg = "Congratulations!+You+have+won+sh." + ttotalwin.ToString() + "+From+set+"+BetId.ToString() + ".+Match+Scores:+" +result+"Thanks";
        sendsms(msg, _Phone);
    
    }
    public void sendlosersmessage()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@username", _username);
        param[1] = new SqlParameter("@betid", _betid);
        param[2] = new SqlParameter("@Mode", "getresults");
        DataTable dt = new DataTable();
        dt = objDBBridge.ExecuteDataset(_spName1, param).Tables[0];
        int opt = 0, exec = 0;
        string result = "";
        _Phone = login.getuser_info(_username, Login.PHONENUMBER);
        if (dt.Rows.Count > 0)
        {
            DataRow drEmployee;

            for (int rowNo = 0; rowNo < dt.Rows.Count; rowNo++)
            {
                drEmployee = dt.Rows[rowNo];
                _Phone = CollapseSpaces(drEmployee["phone"].ToString());

                result += CollapseSpaces(drEmployee["host"].ToString());
                result += "+";
                result += CollapseSpaces(drEmployee["score"].ToString());
                result += "+";
                result += CollapseSpaces(drEmployee["visitor"].ToString());
                result += ",+";
            }
        }
        string msg = "Results+for+set+"+ BetId.ToString()+":+"+result+"Bet+again!+www.globalbets.ug";
       sendsms(msg, _Phone);
    }
    public string getMatchTeams(string matchno) {
        SqlParameter[] param = new SqlParameter[3];
        param[1] = new SqlParameter("@_matchno", matchno);
        param[2] = new SqlParameter("@Mode", "getmatchteams");
        DataTable dt = new DataTable();
        dt = objDBBridge.ExecuteDataset(_spName1, param).Tables[0];
        if (dt.Rows.Count > 0)
        {
            return dt.Rows[0]["game"].ToString();
        }
        else 
            return "";
    }
    public int InsertSetDetails()
    {
        SqlParameter[] param = new SqlParameter[8];
        param[0] = new SqlParameter("@Mode", "insertSetDetails");
        param[1] = new SqlParameter("@username", _username);
        param[2] = new SqlParameter("@betdate", DateTime.Now);
        param[3] = new SqlParameter("@betmoney", _betmoney);
        param[4] = new SqlParameter("@setsize", _setsize);
        param[5] = new SqlParameter("@setodd", _odd);
        param[6] = new SqlParameter("@betid", _betid);
        param[7] = new SqlParameter("@status", _Status);
        return objDBBridge.ExecuteNonQuery(_spName, param);
    }
    public int updateSetDetails()
    {
        SqlParameter[] param = new SqlParameter[8];
        param[0] = new SqlParameter("@Mode", "updateSetDetails");
        param[1] = new SqlParameter("@username", _username);
        param[2] = new SqlParameter("@betdate", DateTime.Now);
        param[3] = new SqlParameter("@betmoney", _betmoney);
        param[4] = new SqlParameter("@setsize", _setsize);
        param[5] = new SqlParameter("@setodd", _odd);
        param[6] = new SqlParameter("@betid", _betid);
        param[7] = new SqlParameter("@status", _Status);
        return objDBBridge.ExecuteNonQuery(_spName, param);
    }
    public int deletebetid()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", " deletebetid");
        param[1] = new SqlParameter("@betid", _betid);
        return objDBBridge.ExecuteNonQuery(_spName,param);

   }
    public string CollapseSpaces(string value)
    {
        return Regex.Replace(value, @"\s+", "");
    }
    public void sendsms(string msg, string Destination_number)
    {
        try
        {
            HttpWebRequest RequesttosendSms = (HttpWebRequest)WebRequest.Create("http://sms.vasgarage.ug/api/sendsms/?msg=" + msg + "&phone=" + Destination_number);
            RequesttosendSms.Headers.Add("Destination", Destination_number);
            RequesttosendSms.Headers.Add("msg", msg);
            HttpWebResponse ResponsetosendSms = (HttpWebResponse)RequesttosendSms.GetResponse();
        }catch(Exception e){}
    }	
    public decimal getbetmoney()
    {
        decimal x = 0;
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Mode", "betmoney");
        param[1] = new SqlParameter("@setno", _setno);
        param[2] = new SqlParameter("@MatchNo", _matchno);
        param[3] = new SqlParameter("@oddname", _oddname);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            x =  Convert.ToDecimal( drEmployee["sm"]);
        }
        return x;
    }
    public int getbetcount()
    {
        int x = 0;
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Mode", "betmoney");
        param[1] = new SqlParameter("@setno", _setno);
        param[2] = new SqlParameter("@MatchNo", _matchno);
        param[3] = new SqlParameter("@oddname", _oddname);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            x = Convert.ToInt32(drEmployee["ct"]);
        }
        return x;
    }
    public decimal sharedwin()
    {
        decimal x = 0;
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "share");
        param[1] = new SqlParameter("@setno", _setno);
        param[2] = new SqlParameter("@MatchNo", _matchno);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            _winshare = Convert.ToDecimal(drEmployee["winshare"]);
            _lossshare = Convert.ToDecimal(drEmployee["loseshare"]);
            x = _winshare;
        }
        return x;
    }
    public decimal getmaxodd()
    {
        decimal x = 0;
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "maxandminodd");
        param[1] = new SqlParameter("@setno", _setno);
        param[2] = new SqlParameter("@MatchNo", _matno);
       
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            x  = Convert.ToDecimal(drEmployee["max_odd_home"]);
            
           
        }
        return x;
    }
    public decimal getminodd()
    {
        decimal x = 0;
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "maxandminodd");
        param[1] = new SqlParameter("@setno", _setno);
        param[2] = new SqlParameter("@MatchNo", _matno);

        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
           
           x = Convert.ToDecimal(drEmployee["min_odd_home"]);
           
        }
        return x;
    }
    public decimal sharedloss()
    {
        decimal x = 0;
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "share");
        param[1] = new SqlParameter("@setno", _setno);
        param[2] = new SqlParameter("@MatchNo",_matchno);
       
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            _winshare = Convert.ToDecimal(drEmployee["winshare"]);
            _lossshare = Convert.ToDecimal(drEmployee["loseshare"]);
            x = _lossshare;
        }
        return x;
    }
    public double getfromaccount()
    {
       double x = 0;
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "total_ammount");
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            x = Convert.ToDouble(drEmployee["total_ammount"]);         
        }
        return x;
    }
     public void putmoney()
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Mode", "putmoney");
        param[1] = new SqlParameter("@setno",_setno );
        param[2] = new SqlParameter("@betmoney",_betmoney);
        param[3] = new SqlParameter("@oddwin",_oddwin);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
        //    cntEmp = drEmployee["paymentsRequest"].ToString();
        }
        //return cntEmp;
    }
     public void UpdateSetbetmatches()
     {
         SqlParameter[] param = new SqlParameter[4];
         param[0] = new SqlParameter("@Mode", "UpdateSetbetmatches");
         param[1] = new SqlParameter("@setno", _setno);
         param[2] = new SqlParameter("@betmoney", _betmoney);
         param[3] = new SqlParameter("@oddwin", _oddwin);
         param[4] = new SqlParameter("@username", _username);
      objDBBridge.ExecuteDataset(_spName, param);
        
     }
     public void updatebetmatch4()
     {
        
         SqlParameter[] param = new SqlParameter[4];
         param[0] = new SqlParameter("@Mode", "updatebetmatch4");
         param[1] = new SqlParameter("@setno", _setno);
         param[2] = new SqlParameter("@betmoney", _betmoney);
         param[3] = new SqlParameter("@oddwin", _oddwin);
         param[4] = new SqlParameter("@username", _username);
        objDBBridge.ExecuteDataset(_spName, param);
       
       
     }
     public int Updatebetmatches1()
    {
        SqlParameter[] param = new SqlParameter[10];
        param[1] = new SqlParameter("@username", _username);
        param[2] = new SqlParameter("@betdate", _betdate);
        param[3] = new SqlParameter("@betmoney", _betmoney);
        param[4] = new SqlParameter("@bet_type", _bet_type);
        param[5] = new SqlParameter("@category", _category);
        param[6] = new SqlParameter("@champ", _champ);
        param[7] = new SqlParameter("@setno", _setno);
        param[8] = new SqlParameter("@MatchNo", _matchno);
        param[9] = new SqlParameter("@host", _host);
        param[10] = new SqlParameter("@vs", "Vs");
        param[11] = new SqlParameter("@visitor", _visitor);
        param[12] = new SqlParameter("@oddname", _oddname);
        param[13] = new SqlParameter("@oddwin", _oddwin);
        param[14] = new SqlParameter("@oddlose", _oddlose);
        param[15] = new SqlParameter("@StartTime", _stime);
        return objDBBridge.ExecuteNonQuery(_spName, param);
    }
     public int Updatebetmatches()
     {
         SqlParameter[] param = new SqlParameter[10];   
         param[11] = new SqlParameter("@visitor", _visitor);
         param[12] = new SqlParameter("@oddname", _oddname);
         param[13] = new SqlParameter("@oddwin", _oddwin);
         param[14] = new SqlParameter("@oddlose", _oddlose);
         param[15] = new SqlParameter("@StartTime", _stime);
         return objDBBridge.ExecuteNonQuery(_spName, param);
     }
     public int updatewinhome()
     {
         SqlParameter[] param = new SqlParameter[4];
         param[0] = new SqlParameter("@mode", "updatewinhome");
         param[1] = new SqlParameter("@setno", _setno);
         param[2] = new SqlParameter("@MatchNo", _matchno);
         param[3] = new SqlParameter("@winhome", _winhome);
         return objDBBridge.ExecuteNonQuery(_spName, param);
     }
     public int updatelossaway()
     {
         SqlParameter[] param = new SqlParameter[4];
         param[0] = new SqlParameter("@mode", "updatelossaway");
         param[1] = new SqlParameter("@setno", _setno);
         param[2] = new SqlParameter("@MatchNo", _matchno);
         param[3] = new SqlParameter("@lossaway", _lossaway);
         return objDBBridge.ExecuteNonQuery(_spName, param);
     }
     public int makemmpayment()
     {
         SqlParameter[] param = new SqlParameter[1];
        
         param[0] = new SqlParameter("@TransId", _transid);
         return objDBBridge.ExecuteNonQuery("makepayment", param);
     }
     public int AgentDirectpayment()
     {
         SqlParameter[] param = new SqlParameter[2];

         param[0] = new SqlParameter("@TransId", _transid);
         param[1] = new SqlParameter("@username", _username);

         return objDBBridge.ExecuteNonQuery("agentpayment", param);
     }
     public DataSet approvepayments()
     {
         SqlParameter[] param = new SqlParameter[1];

         param[0] = new SqlParameter("@Mode", "ApprovedPayments");
         return objDBBridge.ExecuteDataset(_spName1, param);

     }
     public int Paycustomer()
     {
         SqlParameter[] param = new SqlParameter[1];

         param[0] = new SqlParameter("@TransId", _transid);
         return objDBBridge.ExecuteNonQuery("makepayment", param);
     }
     public int makepaybackpayment()
     {
         SqlParameter[] param = new SqlParameter[1];

         param[0] = new SqlParameter("@TransId", _transid);
         return objDBBridge.ExecuteNonQuery("paybackpayment", param);
     }
     public int exportedwinners()
     {
         SqlParameter[] param = new SqlParameter[1];

         param[0] = new SqlParameter("@mode", "exportedwins");
         return objDBBridge.ExecuteNonQuery(_spName, param);
     }
     public int exportedpayback()
     {
         SqlParameter[] param = new SqlParameter[1];

         param[0] = new SqlParameter("@mode", "exportedpayback");
         return objDBBridge.ExecuteNonQuery(_spName, param);
     }
     public int updatesetoddlose()
     {
         SqlParameter[] param = new SqlParameter[4];
         param[0] = new SqlParameter("@mode", "  updatesetoddlose");
         param[1] = new SqlParameter("@setno", _setno);
         param[2] = new SqlParameter("@MatchNo", _matchno);
         param[3] = new SqlParameter("@oddlose", _oddlose);
         param[4] = new SqlParameter("@oddname", _oddname);
         return objDBBridge.ExecuteNonQuery(_spName, param);
     }
     public int updatesetoddwin()
     {
         SqlParameter[] param = new SqlParameter[4];
         param[0] = new SqlParameter("@mode", " updatesetoddwin");
         param[1] = new SqlParameter("@setno", _setno);
         param[2] = new SqlParameter("@MatchNo", _matchno);
         param[3] = new SqlParameter("@oddwin", _oddwin);
         param[4] = new SqlParameter("@oddname", _oddname);
         return objDBBridge.ExecuteNonQuery(_spName, param);
     }
     public int Phonesetsbet()
     {      
             SqlParameter[] param = new SqlParameter[6];
             param[0] = new SqlParameter("@Phoneno", _phone_no);
             param[1] = new SqlParameter("@betmoney", _betmoney);
             param[2] = new SqlParameter("@category", _category);
             param[3] = new SqlParameter("@TeamCode", _TeamCode);       
             param[4] = new SqlParameter("@betdate", _betdate);
             param[5] = new SqlParameter("@Mode", "PhoneSets");
             return objDBBridge.ExecuteNonQuery(_spName, param);
         }
     public decimal Phonebetterbalance() {
         decimal x = 0;
         SqlParameter[] param = new SqlParameter[2];
         param[0] = new SqlParameter("@Mode", "getbalance");
         param[1] = new SqlParameter("@phoneno", _phone_no);
         DataTable dtEmployee = new DataTable();
         dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
         if (dtEmployee.Rows.Count != 0)
         {
             DataRow drEmployee;
             drEmployee = dtEmployee.Rows[0];
             x = Convert.ToDecimal(drEmployee["ammount_e"]);
         }
         return x;
     
     
     }     
    #endregion

}
