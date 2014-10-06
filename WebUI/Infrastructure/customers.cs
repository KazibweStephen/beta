using System;
using System.Data;
using SRN.DAL;
using System.Data.SqlClient;


/// <summary>
/// Summary description for customers
/// </summary>
public class customers
{
	public customers()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region Variables
    DBBridge objDBBridge = new DBBridge();
    protected int _EmployeeId;
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
    protected int _DepartmentId;
    protected DateTime _DOJ;
    protected DateTime _DOC;
    protected DateTime _DOT;
    protected DateTime _DOT2;
    protected string _Bio = String.Empty;
    protected string _Degree = String.Empty;
    protected string _Photo = String.Empty;
    protected string _bettedmarches = String.Empty;
    protected string _username= String.Empty;
    protected int _betid;
    protected int _Status;
    protected int _Years;
    protected double _balance;
    protected double _bought;
    protected double _betted;
    protected double _won;
   
    const string _spName = "sp_customers";
    const string _spName2 = "NewRegModel";

    #endregion

    #region Class Property
    public int EmployeeId
    {
        get { return _EmployeeId; }
        set { _EmployeeId = value; }
    }

    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }
    public string username
    {
        get { return _username; }
        set { _username= value; }
    }
    public int betid {
        set { _betid = value; }
        get{return _betid;}
    
    
    }
    public DateTime DOB
    {
        get { return _DOB; }
        set { _DOB = value; }
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
    public string Address
    {
        get { return _Address; }
        set { _Address = value; }
    }
    public string City
    {
        get { return _City; }
        set { _City = value; }
    }
    public string State
    {
        get { return _State; }
        set { _State = value; }
    }
    public string Zip
    {
        get { return _Zip; }
        set { _Zip = value; }
    }
    public string Phone
    {
        get { return _Phone; }
        set { _Phone = value; }
    }
    public string Mobile
    {
        get { return _Mobile; }
        set { _Mobile = value; }
    }
    public string Email
    {
        get { return _Email; }
        set { _Email = value; }
    }
    public string Designation
    {
        get { return _Designation; }
        set { _Designation = value; }
    }
    public int DepartmentId
    {
        get { return _DepartmentId; }
        set { _DepartmentId = value; }
    }
    public DateTime DOJ
    {
        get { return _DOJ; }
        set { _DOJ = value; }
    }
    public DateTime DOC
    {
        get { return _DOC; }
        set { _DOC = value; }
    }
    public string Bio
    {
        get { return _Bio; }
        set { _Bio = value; }
    }
    public string Degree
    {
        get { return _Degree; }
        set { _Degree = value; }
    }
    public string Photo
    {
        get { return _Photo; }
        set { _Photo = value; }
    }
    public int Status
    {
        get { return _Status; }
        set { _Status = value; }
    }
    public int Years
    {
        get { return _Years; }
        set { _Years = value; }
    }
    public double balance 
    {
        get { return _balance; }
        set { _balance = value; }
    }
    public double won
    {
        get { return _won; }
        set { _won= value; }
    }
    public double betted
    {
        get { return _betted; }
        set { _betted= value; }
    }
    public string bettedmarches 
    {
        get { return _bettedmarches; }
        set {_bettedmarches = value; }
    }
    #endregion

    #region Public Methods

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
        param[1] = new SqlParameter("@username",_username);
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
    public string TransCountbd()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "DepositsCount");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);
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
    public DataSet GetCustomerDepositsBydate()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "CustomerDepositsBydate");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet GetBettedmarches()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "BettedMarches");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet GetBettedmarchesBydate()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "BettedMarchesBydate");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet GetCustomerBettings()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "CustomerBetting");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public string CountBetting()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "CountBetting");

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
    public string OverallTotalBets()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "Overallbettings");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["total"].ToString();
        }
        return cntEmp;
    }
    public string CountBettingbd()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "CountBettingBydate");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);
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
    
    public string TotalBetting()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "TotalBetting");
        
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["Total"].ToString();
        }
        return cntEmp;
    }
    public string TotalDeposits()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "TotalDeposits");

        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["Total"].ToString();
        }
        return cntEmp;
    }
    public string TotalBettingbd()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "TotalBettingbd");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["Total"].ToString();
        }
        return cntEmp;
    }
    public string TotalWithdrawals()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "TotalWithdraws");

        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["Total"].ToString();
        }
        return cntEmp;
    }
    public string TotalWithdrawalsbd()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "TotalWithdrawsbd");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["Total"].ToString();
        }
        return cntEmp;
    }
    public string TotalDepositsbd()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "TotalDepostbd");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["Total"].ToString();
        }
        return cntEmp;
    }
    public DataSet GetCustomerBettingsBydate()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "CustomerBettingBydate");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet GetCustomerWins()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "CustomerWin");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public string CountWins()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "CountWin");

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
    public DataSet GetCustomerWinsBydate()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "CustomerWinBydate");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2",_DOT2);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public string CountWinsbd()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "CountWinBydate");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);
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
    public DataSet GetAllUserTransactions()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "UserTransactions");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public String  UserTransactionsCount()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[1];
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
    public String AllUserTransactionsCount()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "CountAllTransactions");

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
    public String AllUserTransactionsCountbd()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "CountAllTransactionsbd");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);

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
    public DataSet GetAllUserTransactionsBydate()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "UserTransactionsBydate");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public String UserTransactionsCountbd()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "CountTransactionsBydate");

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
    public DataSet GetCustomerWithdraws()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "CustomerWithdraws");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public String CountWithdraws()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "CountWithdraws");

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
    public String CountWithdrawsbd()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "CountWithdrawsbd");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);

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
    public DataSet GetCustomerWithdrawsBydate()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "CustomerWithdrawsBydate");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);
        return objDBBridge.ExecuteDataset(_spName, param);
    }  
    public string EmployeeCount()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "EmpCount");
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["EmpCount"].ToString();
        }
        return cntEmp;
    }
    public string Getopeningbalance()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Mode", "OpeningBalance");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
        param[3] = new SqlParameter("@username", _username);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["balance"].ToString();
        }
        return cntEmp;
    }
    public double newpurchase()
    {
        double credit= 0;
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Mode", "NewPurchase");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
        param[3] = new SqlParameter("@username", _username);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset("purchase", param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            credit = Convert.ToDouble(drEmployee["balance"]);
        }
        return credit;
    }
    public double WonCredit()
    {
        double credit = 0;
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Mode", "NewPurchase");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
        param[3] = new SqlParameter("@username", _username);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset("WonCredit", param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            credit = Convert.ToDouble(drEmployee["balance"]);
        }
        return credit;
    }
    public string getbetpoint()
    {
        string betpoint ="",method="";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "getbetpoint");
        param[1] = new SqlParameter("@betid", _betid);
        param[2] = new SqlParameter("@username", _username.Trim());
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            betpoint = (drEmployee["betpoint"]).ToString().Trim();
             method= (drEmployee["method"]).ToString().Trim().ToUpper();
             if ((method == "ONLINE BETTING"))
             {

                 betpoint = "Self online Bet";
             }
             else if ((method == "SMS BETTING"))
             {

                 betpoint = "Self sms Bet";
             }
             else if ((method == "BET THROUGH ONLINE AGENT"))
             {
                 betpoint = "Agent" + betpoint + " ONLINE";

             }
             else if ((method == "BET THROUGH SMS AGENT"))
             {

                 betpoint = "Agent" + betpoint + " Through SMS";
             }
             else {
                 betpoint = (drEmployee["method"]).ToString();
             
             }


        }
        return betpoint;
    }
    public int TotalWonCredits()
    {
        double credit = 0;
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "TotalWonCredits");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
       
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            credit = Convert.ToDouble(drEmployee["balance"]);
        }
        return (int)credit;
    }
    public double BetMoney()
    {
        double credit = 0;
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Mode", "bets");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
        param[3] = new SqlParameter("@username", _username);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset("bets", param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            credit = Convert.ToDouble(drEmployee["balance"]);
        }
        return credit;
    }
    public double depositbyperiods()
    {
        double credit = 0;
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "TotalDepostbd");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            credit = Convert.ToDouble(drEmployee["Total"]);
        }
        return credit;
    }

    public double TotalRequestsmade()
    {
        double credit = 0;
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "SumMadeRequests");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            credit = Convert.ToDouble(drEmployee["Total"]);
        }
        return credit;
    }
    public double TotalRequestsAccepted()
    {
        double credit = 0;
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "SumAcceptedReqs");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            credit = Convert.ToDouble(drEmployee["Total"]);
        }
        return credit;
    }

    public double TotalRequestsDenied()
    {
        double credit = 0;
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "SumDeniedReqs");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            credit = Convert.ToDouble(drEmployee["Total"]);
        }
        return credit;
    }
    public double TotalMobilePayments()
    {
        double credit = 0;
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "TMobilePayments");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            credit = Convert.ToDouble(drEmployee["Total"]);
        }
        return credit;
    }
    public double TotalBetMoney()
    {
        double credit = 0;
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "TotalBetting");
       
       
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            credit = Convert.ToDouble(drEmployee["Total"]);
        }
        return credit;
    }

    public DataSet getDailyReport(DateTime date, DateTime end)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "dailyreport");
        param[1] = new SqlParameter("@DOT", date);
		param[2] = new SqlParameter("@DOT2", end);
        return objDBBridge.ExecuteDataset(_spName2, param);
    }
    public DataSet getDayReport(DateTime date, DateTime end)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "dayreport");
        param[1] = new SqlParameter("@DOT", date);
        param[2] = new SqlParameter("@DOT2", end);
        return objDBBridge.ExecuteDataset(_spName2, param);
    }

    public DataSet getWeekReport(DateTime startdate, DateTime enddate)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "weeklyreport");
        param[1] = new SqlParameter("@DOT", startdate);
        param[2] = new SqlParameter("@DOT2", enddate);
        return objDBBridge.ExecuteDataset(_spName2, param);
    }

    public double TotalBetMoneybd()
    {
        double credit = 0;
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "TotalBettingbd");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());

        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            credit = Convert.ToDouble(drEmployee["Total"]);
        }
        return credit;
    }
    public double betsusingaccountmoney()
    {
        double credit = 0;
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "betsusingaccountmoney");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());

        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            credit = Convert.ToDouble(drEmployee["Total"]);
        }
        return credit;
    }
    
    public string ClosingBalance()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Mode", "ClosingBalance");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
        param[3] = new SqlParameter("@username", _username);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["balance"].ToString();
        }
        return cntEmp;
    }
    public string sentpayments()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Mode", "MadePayments");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
        param[3] = new SqlParameter("@username", _username);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["balance"].ToString();
        }
        return cntEmp;
    }
    public string AcceptedRequest()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Mode", "AcceptedRequest");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
        param[3] = new SqlParameter("@username", _username);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["balance"].ToString();
        }
        return cntEmp;
    }
    public string DeniedRequest()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Mode", "DeniedRequest");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
        param[3] = new SqlParameter("@username", _username);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["balance"].ToString();
        }
        return cntEmp;
    }
    public string PaymentRequest()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Mode", "PaymentRequest");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
        param[3] = new SqlParameter("@username", _username);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["paymentsRequest"].ToString();
        }
        return cntEmp;
    }

   
   
    public DataSet customersalesbd1()
    {

        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Mode", "Customerpurchasesbd");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
        param[3] = new SqlParameter("@username", _username);

        return objDBBridge.ExecuteDataset(_spName, param);

    }
    public DataSet customersales1()
    {

        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "Customerpurchases");
        param[1] = new SqlParameter("@username", _username);

        return objDBBridge.ExecuteDataset(_spName, param);

    }
    public DataSet GetCustomerMarch1()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "customermatch");
        param[1] = new SqlParameter("@username ", username);
        param[2] = new SqlParameter("@DOT ", _DOT);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet GetCustomerMarch2()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "CustomerSureDeal");
        param[1] = new SqlParameter("@username ", username);
        param[2] = new SqlParameter("@DOT ", _DOT);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet GetMatchbyReciept()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "SureDealMatch");
        param[1] = new SqlParameter("@username ", username);
        
        return objDBBridge.ExecuteDataset(_spName, param);
    }
     public DataSet GetMatchbyReciepts()
    {
        SqlParameter[] param = new SqlParameter[1];
     
        param[0] = new SqlParameter("@recptno", username);

        return objDBBridge.ExecuteDataset("AgentBets", param);
    }
     public String Customerphone(String rcpno)
     {
         String agentname = "";
        
         SqlParameter[] param = new SqlParameter[1];

         param[0] = new SqlParameter("@recptno ", rcpno);
         DataTable dtEmployee = new DataTable();
         dtEmployee = objDBBridge.ExecuteDataset("AgentBets", param).Tables[0];
         if (dtEmployee.Rows.Count != 0)
         {
             DataRow drEmployee;
             drEmployee = dtEmployee.Rows[0];
             agentname = drEmployee["phone"].ToString();

         }

         return agentname;
     }
    public DataSet customermatch()
    {

        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "GetMarchbyName");
        param[1] = new SqlParameter("@username", _username);
        return objDBBridge.ExecuteDataset(_spName, param);

    }
    public DataSet Agentsalesbd1()
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Mode", "AgentsalesBydate1");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@username", _username);

        return objDBBridge.ExecuteDataset(_spName, param);

    }
    public String getMatchno(string sformat)
    {
        String no = "";
        if (sformat != "")
        {
            string[] words = sformat.ToString().Split(' ');
            if (words.Length > 3)
            {
                if (words.Length == 9)
                {
                    no = words[8].ToString();
                }
                if (words.Length==10)
                {
                    no = words[9].ToString();
                }
            }
        }
        return no;

    }
    public string Totalbetors()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "Totalbetors");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
       
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["Total"].ToString();
        }
        return cntEmp;
    }

    public string Uniquebetorsperperiod()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "Activebetors");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["Total"].ToString();
        }
        return cntEmp;
    }
    public string Newbetorsperperiod()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "Newbetorsperperiod");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
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

    public string TopupandBetforCustomers()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "TopupandBetforCustomers");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["Total"].ToString();
        }
        return cntEmp;
    }

    public string MobileMoneyDepostbd()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "MobileMoneyDepostbd");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["Total"].ToString();
        }
        return cntEmp;
    }
    public string CountTotalBetBydate()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "CountTotalBetBydate");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
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
    public string sumbettingamountBydate()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "sumbettingsamountbd");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["total"].ToString();
        }
        return cntEmp;
    }
    
    
    
    #endregion
}
