using System;
using System.Data;
using SRN.DAL;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Agentclass
/// </summary>
public class Agentclass

{
    public Agentclass()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region Variables
    DBBridge objDBBridge = new DBBridge();
    callingstoredprocedures csp = new callingstoredprocedures();
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
    protected DateTime _DOT;
    protected DateTime _DOT2;
    protected DateTime _DOC;
    protected string _Bio = String.Empty;
    protected string _bettor = String.Empty;
    protected string _Degree = String.Empty;
    protected string _Photo = String.Empty;
    protected string _bettedmarches = String.Empty;
    protected string _username= String.Empty;
    protected string _agentusername = String.Empty;
    protected string _customerusername = String.Empty;
    protected string _agentphone = String.Empty;
    protected string _customerphone = String.Empty;
    protected string _recpt = String.Empty;
    protected string _choice = String.Empty;
    protected int _Status;
    protected int _Years;
    protected int _betid;
    protected double _balance;
    protected double _bought;
    protected double _betted;
    protected double _won;
    protected double _amount;
    protected double _betmoney;
    public double x = 0;
    public double setoddx = 0;
    const string _spName = "Sp_Agents";
    const string _spName1 = "smsagentbets";
    const string _spName2 = "Sp_Admin";
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

    public string customerusername
    {
        get { return _customerusername; }
        set { _customerusername= value; }
    }

    public string agentusername
    {
        get { return _agentusername; }
        set { _agentusername = value; }
    }
    public string agentphone
    {
        get { return _agentphone; }
        set { _agentphone= value; }
    }
    public string customerphoneno
    {
        get { return _customerphone; }
        set { _customerphone= value; }
    }
    public double betmoney
    {
        get { return _betmoney; }
        set { _betmoney = value; }

    }


    public string choice
    {
        get { return _choice; }
        set { _choice= value; }
    }
    public string bettor
    {
        get { return _bettor; }
        set { _bettor = value; }
    }
    public string Recieptno
    {
        get { return _recpt; }
        set { _recpt = value; }
    }
    public string username
    {
        get { return _username; }
        set { _username= value; }
    }
    public DateTime DOB
    {
        get { return _DOB; }
        set { _DOB = value; }
    }

    public DateTime DOT
    {
        get { return _DOT; }
        set { _DOT= value; }
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
    
    public DateTime DOT2
    {
        get { return _DOT2; }
        set { _DOT2 = value; }
    }
    public string Bio
    {
        get { return _Bio; }
        set { _Bio = value; }
    }
   
    
    public int Status
    {
        get { return _Status; }
        set { _Status = value; }
    }

    public int betid
    {
        get { return _betid; }
        set { _betid= value; }
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
    public double amount
    {
        get { return _amount; }
        set { _amount = value; }
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

   
  
    public int Delete()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "Delete");
        param[1] = new SqlParameter("@EmployeeId", _EmployeeId);
        return objDBBridge.ExecuteNonQuery(_spName, param);
    }
    public DataSet Select()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "ViewActive");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public string TellerTotalBalance()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "TellerTotalBalance");
        param[1] = new SqlParameter("@username", _username);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            _betmoney = Convert.ToDouble(drEmployee["betbalance"]);
            _amount = Convert.ToDouble(drEmployee["payout"]);
            _balance = Convert.ToDouble(drEmployee["balance"]);
        }
        return cntEmp;
    }
    public DataSet SelectAgents()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "SelectAgents");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet GetAgentBalance()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "AgentBalance");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet SearchAgent()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "SearchAgents");
        param[1] = new SqlParameter("@username",_username);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet GetAgentCustometBets()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "AgentBets");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public string CountAgentCustometBets()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "CountAgentBets");
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["agentcount"].ToString();
        }
        return cntEmp;
    }
    public string SumAgentCustomerBets()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "SumAgentBets");
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["ammount"].ToString();
        }
        return cntEmp;
    }
    public string SumAgentCustomerBetsbd()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "SumAgentBetsbd");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["ammount"].ToString();
        }
        return cntEmp;
    }
    public string SumAgentDepositsbd()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "SumAgentDepositsbd");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["agentsum"].ToString();
        }
        return cntEmp;
    }
    public string SumAgentMMDepositsbd()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "SumAgentMMDepositsbd");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["agentsum"].ToString();
        }
        return cntEmp;
    }
    public string SumAgentDeposits()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "SumAgentDeposits");
      
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["agentsum"].ToString();
        }
        return cntEmp;
    }
    public string CountAgentCustometBetsbd()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "CountAgentBetsbd");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["agentcount"].ToString();
        }
        return cntEmp;
    }
    public DataSet GetAgentDeposits()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "AgentDeposits");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public string CountAgentDeposits()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "CountAgentDeposits");
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["agentcount"].ToString();
        }
        return cntEmp;
    }
    public string TotalAgentSales1()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "TotalAmmountsales");
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
    public string TotalAgentSales1bd()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "TotalAmmountsalesbd");
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
    public string CountAgentDepositsbd()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "CountAgentDepositsbd");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["agentcount"].ToString();
        }
        return cntEmp;
    }
    public DataSet GetBettedmarches()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "BettedMarches");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet GetCustomerBettings()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "CustomerBetting");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet GetAgentCustomerMarch()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@recptno ",_recpt);
        return objDBBridge.ExecuteDataset("AgentBets", param);
    }
    public DataSet GetAgentCustomerMarch1()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "customerreciept");
        param[1] = new SqlParameter("@recptno ", _recpt);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet GetCustomerWins()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "CustomerWin");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet GetAllUserTransactions()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "AllUserTransactions");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet GetAgentSales()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "Agentsales");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public string CountAgentSales()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "CountAgentsales");
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["agentcount"].ToString();
        }
        return cntEmp;
    }
    public DataSet GetAgentBalanceBydate()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "AgentBalanceBydate");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet GetAgentCustometBetsBydate()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "AgentBetsBydate");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet AllAgentTransaction()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "AgentTransaction");
        param[1] = new SqlParameter("@username", _username);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet TellerTransactionsbd()
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@username", _username);
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2);
        param[3] = new SqlParameter("@Mode", "TellerTransactionsbd");
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet GetAllTellerTransactions()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@username", _username);
        param[1] = new SqlParameter("@mode", "TellerTransactions");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet GetAgentDepositsBydate()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "AgentDepositsBydate");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet GetBettedmarchesBydate()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "BettedMarches");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet GetCustomerBettingsBydate()
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Mode", "CustomerBettingBydate");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet GetAgentCustomerMarchBydate()
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Mode", "AgentcustomerphoneBydate");
        param[1] = new SqlParameter("@recptno ", _recpt);
        param[2] = new SqlParameter("@DOT", _DOT);
        param[3] = new SqlParameter("@DOT2", _DOT2);
        return objDBBridge.ExecuteDataset(_spName, param);
    }  
    public DataSet GetCustomerWinsBydate()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "CustomerWinBydate");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet GetAllUserTransactionsBydate()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "AllUserTransactionsBydate");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet GetAgentSalesBydate()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "AgentsalesBydate");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public string CountAgentSalesBydate()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "CountAgentsalesbd");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["agentcount"].ToString();
        }
        return cntEmp;
    }
    public string Getopeningbalance()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Mode", "OpeningBalance");
        param[1] = new SqlParameter("@DOT", _DOT);
        param[2] = new SqlParameter("@DOT2", _DOT2);
        param[3] = new SqlParameter("@username",_username);
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
    public DataSet Birthday()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "Birthday");
        return objDBBridge.ExecuteDataset(_spName, param);
    } 
    public String  AgentCustomer()
    {
        String agentname = "";
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Mode", "Agentcustomer");
        param[1] = new SqlParameter("@transdate",_DOT);
        param[2] = new SqlParameter("@agentname",_Name);
        param[3] = new SqlParameter("@amount",_amount);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            agentname = drEmployee["customer"].ToString();
           
        }
        return agentname;
    }
    public String Customerphone(String rcpno)
    {
        String agentname = "";
        String recno = getRecieptno(rcpno);
        SqlParameter[] param = new SqlParameter[1];
       
        param[0] = new SqlParameter("@recptno ", recno);
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
    public String Customerphones(String rcpno)
    {
        String agentname = "";
        
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "Agentcustomerphone");
        param[1] = new SqlParameter("@recptno ", rcpno);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            agentname = drEmployee["phone"].ToString();

        }
        return agentname;
    }
    public String Reciept(String rcpno)
    {
        String agentname = "";
        String recno = getRecieptno(rcpno);
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "Agentcustomerphone");
        param[1] = new SqlParameter("@recptno ", recno);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            agentname = drEmployee["username"].ToString();

        }
        return agentname;
    }
    public String Reciepts(String rcpno)
    {
        String agentname = "";
        String recno = getRecieptno(rcpno);
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "Agentcustomerphone");
        param[1] = new SqlParameter("@recptno ", recno);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            agentname = drEmployee["phone_rcpt"].ToString();

        }
        return agentname;
    }  
    public String  getRecieptno(string sformat)
    {
        String no = "";
        if (sformat != "")
        {
            string[] words = sformat.ToString().Split(' ');
            if (words.Length > 3)
            {
                no = words[3].ToString();
            }
        }
        return no;

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
    public string openingbalance()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Mode", "AOpeningBalance");
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
    public string ClosingBalance()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Mode", "AClosingBalance");
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
        double credit = 0;
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Mode", "NewPurchases");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
        param[3] = new SqlParameter("@username", _username);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            credit = Convert.ToDouble(drEmployee["purchased"]);
        }
        return credit;
    }
    public double Totalnewpurchase()
    {
        double credit = 0;
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "TotalNewPurchases");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
       
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            credit = Convert.ToDouble(drEmployee["purchased"]);
        }
        return credit;
    }
    public double TotalSoldStock()
    {
        double credit = 0;
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "TotalNewSales");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
       
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            credit = Convert.ToDouble(drEmployee["purchased"]);
        }
        return credit;
    }    
    public double SoldStock()
    {
        double credit = 0;
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Mode", "SoldStocks");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
        param[3] = new SqlParameter("@username", _username);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            credit = Convert.ToDouble(drEmployee["sold"]);
        }
        return credit;
    }
    public DataSet Agentsalesbd1()
    {
       
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Mode", "AgentsalesBydate1");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
        param[3] = new SqlParameter("@username", _username);

        return objDBBridge.ExecuteDataset(_spName, param);
      
    }
    public DataSet Agentsales1()
    {

        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "Agentsales1"); 
        param[1] = new SqlParameter("@username", _username);

        return objDBBridge.ExecuteDataset(_spName, param);

    }
    public String Customeraccount()
    {
        String agentname = "";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "DestinationAccount");
        param[1] = new SqlParameter("@DOT",_DOT);
        param[2] = new SqlParameter("@ID ",_EmployeeId);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            agentname = drEmployee["destination"].ToString();

        }
        return agentname;
    }
    public DataTable phoneagent() {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "getagent");
        param[1] = new SqlParameter("@PhoneNo", _Phone);
        return objDBBridge.ExecuteDataset(_spName1, param).Tables[0];
    
    }
    public double agentbalance() {
      double bal = 0;
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@username", _username);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset("GetCustomerBAL", param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            bal = Convert.ToDouble(drEmployee["ammount_e"]);
        }
        return bal;   
    
    }
    public double Agenttopupandbets()
    {
      double bal = 0;
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "topupandbets");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            bal = Convert.ToDouble(drEmployee["sold"]);
        }
        return bal;   
    
    }

    public double Agenttopup()
    {
        double bal = 0;
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "Agenttopup");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            bal = Convert.ToDouble(drEmployee["sold"]);
        }
        return bal;

    }
    public double betforcustomers()
    {
        double bal = 0;
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "betforcustomers");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            bal = Convert.ToDouble(drEmployee["sold"]);
        }
        return bal;

    }
    public double totalmobilemoney()
    {
      double bal = 0;
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "totalmobilemoney");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            bal = Convert.ToDouble(drEmployee["sold"]);
        }
        return bal;   
    
    }
    public double CollectionsfromAgents()
    {
      double bal = 0;
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode","CollectionsfromAgents");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            bal = Convert.ToDouble(drEmployee["ammount"]);
        }
        return bal;   
    
    }
    public bool checkcustomerphone(string phoneno){
        bool correct = false;
        if ((phoneno.Length > 8)&&(phoneno.Length<11)) {
            correct = true;      
        }

        return correct;
}
    public bool TestifTeamscodeExist(int betids)
    {
        bool correct = false;
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@TeamCode", betids);
        param[1] = new SqlParameter("@mode", "TestTeamscode");
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName2, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow dr;
            dr = dtEmployee.Rows[0];
            ///test whether the game is activated
            string bettype = dr["Bettype"].ToString().ToLower().Trim();
            return TestIfGameIsActivated(bettype);
        }
        return correct;
    }

    public int TestBetType(int betids) // Test  for doublechance halftime and and handicap to increase minimum recieptsize
    {
        int correct = 3;
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@TeamCode", betids);
        param[1] = new SqlParameter("@mode", "TestTeamscode");
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName2, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow dr;
            dr = dtEmployee.Rows[0];
            string bettype;
            bettype = dr["bettype"].ToString().Trim().ToLower();
         
            switch (bettype){            
                case "straight":
                    return GlobalBetsAdmin.GetSize(GlobalBetsAdmin.BetOptions(), 1);
                case "wire":
                    return GlobalBetsAdmin.GetSize(GlobalBetsAdmin.BetOptions(), 2);
                case "dc":
                    return GlobalBetsAdmin.GetSize(GlobalBetsAdmin.BetOptions(), 3);
                case "hc":
                    return GlobalBetsAdmin.GetSize(GlobalBetsAdmin.BetOptions(), 4);
                case "halftime": 
                    return GlobalBetsAdmin.GetSize(GlobalBetsAdmin.BetOptions(), 5);
                case "oddeven":
                    return GlobalBetsAdmin.GetSize(GlobalBetsAdmin.BetOptions(), 6);       
            }
        }
        return correct;
    }
    public GlobalBetsAdmin.betoption GetBetType(int betids) // Test  for doublechance halftime and and handicap to increase minimum recieptsize
    {
        GlobalBetsAdmin.betoption betoption = null;
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@TeamCode", betids);
        param[1] = new SqlParameter("@mode", "TestTeamscode");
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName2, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow dr;
            dr = dtEmployee.Rows[0];
            string bettype;
            bettype = dr["bettype"].ToString().Trim().ToLower();

            switch (bettype)
            {
                case "straight":
                    return GlobalBetsAdmin.Getoption(GlobalBetsAdmin.BetOptions(), 1);
                case "wire":
                    return GlobalBetsAdmin.Getoption(GlobalBetsAdmin.BetOptions(), 2);
                case "dc":
                    return GlobalBetsAdmin.Getoption(GlobalBetsAdmin.BetOptions(), 3);
                case "hc":
                    return GlobalBetsAdmin.Getoption(GlobalBetsAdmin.BetOptions(), 4);
                case "halftime":
                    return GlobalBetsAdmin.Getoption(GlobalBetsAdmin.BetOptions(), 5);
                case "oddeven":
                    return GlobalBetsAdmin.Getoption(GlobalBetsAdmin.BetOptions(), 6);
            }
        }
        return betoption;
    }
    public bool TestIfGameIsActivated(string bettype)
    {
        switch (bettype)
        {
            case "straight":
                if (GlobalBetsAdmin.isActivated(0))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            case "wire":
                if (GlobalBetsAdmin.isActivated(1))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            case "dc":
                if (GlobalBetsAdmin.isActivated(2))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            case "halftime":
                if (GlobalBetsAdmin.isActivated(3))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case "oddeven":
                if (GlobalBetsAdmin.isActivated(5))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case "hc":
                if (GlobalBetsAdmin.isActivated(4))
                    return true; return false;


            //end testing whether the game is activated

        }
        return false;


    }

    public double getmatch(int betids)
    {
        double result =0;
        string matchcode = null;
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@TeamCode", betids);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset("TestifTeamscodeExist", param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            choice = betids.ToString();
            DataRow dr;
            dr = dtEmployee.Rows[0];

            string oddname = null;
            matchcode = dr["MATCH CODE"].ToString().Trim();

            if (choice == dr["HOME CODE"].ToString().Trim())
            {
                oddname = "Home";
                result = Betsubmit(matchcode, oddname, _amount.ToString());

            }
            else if (choice == dr["AWAY CODE"].ToString().Trim())
            {
                oddname = "Away";
                result = Betsubmit(matchcode, oddname, _amount.ToString());

            }
            else if (choice == dr["DRAW CODE"].ToString().Trim())
            {
                oddname = "Draw";
                result = Betsubmit(matchcode, oddname, _amount.ToString());

            }
        }
        else {

            result = 0;
        }
         
        return result;

    }

  

    private double Betsubmit(string matchcode, string oddname, string amount)
    {
        bool results = false;
        double matodd = 1;
       DataTable dt_match = new DataTable();
      SqlParameter[] param = new SqlParameter[1];
      param[0] = new SqlParameter("@MatchNo", matchcode);
        dt_match  = objDBBridge.ExecuteDataset("getmatchbettedon", param).Tables[0];
        if (dt_match.Rows.Count != 0)
        {
             DataRow dr;
            dr=   dt_match.Rows[0];
           
             

              SqlParameter[] dtm = new SqlParameter[14];
              dtm[0] = new SqlParameter("@username", _username.Trim());
              dtm[1] = new SqlParameter("@betmoney",_amount);
              dtm[2] = new SqlParameter("@category", "Sets");
              dtm[3] = new SqlParameter("@champ", dr["LEAGUE"]);
              dtm[4] = new SqlParameter("@setno", dr["SETCODE"]);
              dtm[5] = new SqlParameter("@MatchNo", matchcode);
              dtm[6] = new SqlParameter("@visitor", dr["AWAY TEAM"]);
              dtm[7] = new SqlParameter("@oddname", oddname.Trim());
              dtm[8] = new SqlParameter("@ttmoney",0);
              dtm[9] = new SqlParameter("@StartTime", dr["START TIME"]);
              dtm[10] = new SqlParameter("@betID", _betid);
              dtm[11] = new SqlParameter("@betdate",DateTime.Now);
              dtm[12] = new SqlParameter("@host", dr["HOME TEAM"]);
              if (oddname == "Home")
              {
                  dtm[13] = new SqlParameter("@odd", dr["HOME CODE"]);
                  x = double.Parse(dr["HOME CODE"].ToString());

              }
              else if (oddname == "Away")
              {
                  dtm[13] = new SqlParameter("@odd", dr["AWAY ODD"]);
                  x = double.Parse(dr["AWAY ODD"].ToString());
             

              }
              else if (oddname == "Draw")
              {
                  x = x * double.Parse(dr["DRAW ODD"].ToString());
                  dtm[13] = new SqlParameter("@odd", dr["DRAW ODD"]);
              }
              else
              {
                  return 0;
              }        
            int rest=objDBBridge.ExecuteNonQuery("clientsetsbet", dtm);
                if (rest==0)
                {
                    csp.deleteclientsetsbet();
                    matodd = 0;
                }
                else
                {
                   // csp.Updateclientsmssetsbet();
                    matodd = x;

                }
            }
      
        return matodd;
        }


    public int Topupcustomer()
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Mode", "topup");
        param[1] = new SqlParameter("@agentname", _agentusername);
        param[2] = new SqlParameter("@amount", _amount);
        param[3] = new SqlParameter("@customerphone", _customerphone);

        return objDBBridge.ExecuteNonQuery("topup", param);
    }

    public bool UpdateagentsmsAccounts()
    {
        DataTable dtmatches = new DataTable();
        bool res = false;
        try
        {
            SqlParameter[] dtm = new SqlParameter[4];
            dtm[0] = new SqlParameter("@username", _username.Trim());
            dtm[1] = new SqlParameter("@bettor", _bettor);
            dtm[2] = new SqlParameter("@amount", _betted);
            dtm[3] = new SqlParameter("@betID", _betid);
            int x = objDBBridge.ExecuteNonQuery("UpdateagentsmsAccounts", dtm);
            if (x > 0) { res = true; }
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = false;
        }
        return res;
    }
    public bool UpdateagentonlineAccounts()
    {
        DataTable dtmatches = new DataTable();
        bool res = false;
        try
        {
            SqlParameter[] dtm = new SqlParameter[4];
            dtm[0] = new SqlParameter("@username", _username.Trim());
            dtm[1] = new SqlParameter("@bettor", _bettor);
            dtm[2] = new SqlParameter("@amount", _betted);
            dtm[3] = new SqlParameter("@betID", _betid);
            int x = objDBBridge.ExecuteNonQuery("UpdateagentonlineAccounts", dtm);
            if (x > 0) { res = true; }
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = false;
        }
        return res;
    }
    public bool AdminBetting()
    {
        DataTable dtmatches = new DataTable();
        bool res = false;
        try
        {
            SqlParameter[] dtm = new SqlParameter[4];
            dtm[0] = new SqlParameter("@username", _username.Trim());
            dtm[1] = new SqlParameter("@bettor", _bettor);
            dtm[2] = new SqlParameter("@amount", _betted);
            dtm[3] = new SqlParameter("@betID", _betid);
            int x = objDBBridge.ExecuteNonQuery("AdminBetting", dtm);
            if (x > 0) { res = true;
            if (x == 5) {
                _Status = 1;
            }
            if (x == 4)
            {
                _Status = 1;
            }
            }
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = false;
        }
        return res;
    }

    public bool UpdateclientsmsAccounts()
    {
        DataTable dtmatches = new DataTable();
       bool res = false;
        try
        {
            SqlParameter[] dtm = new SqlParameter[3];
            dtm[0] = new SqlParameter("@username", _username);
            dtm[1] = new SqlParameter("@amount", _betmoney);
            dtm[2] = new SqlParameter("@betID",_betid);
            int rest = objDBBridge.ExecuteNonQuery("UpdateclientsmsAccounts", dtm);
            if (rest > 1) { res = true; }
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = false;
        }
        return res;
    }
       
    #endregion

   
}
