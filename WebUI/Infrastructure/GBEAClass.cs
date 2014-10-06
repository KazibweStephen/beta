using System;
using System.Data;
using SRN.DAL;
using System.Data.SqlClient;

/// <summary>
/// Summary description for GBEAClass
/// </summary>
public class GBEAClass
{
	public GBEAClass()
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
    protected DateTime _DOT;
    protected DateTime _DOT2;
    protected DateTime _DOC;
    protected string _Bio = String.Empty;
    protected string _Degree = String.Empty;
    protected string _Photo = String.Empty;
    protected string _bettedmarches = String.Empty;
    protected string _username= String.Empty;
    protected string _recpt = String.Empty;
    protected string _category = String.Empty;
    protected string _oddname = String.Empty;
    protected string _host = String.Empty;
    protected string _visitor = String.Empty;
    protected int _Status;
    protected int _Years;
    protected double _balance;
    protected double _bought;
    protected double _betted;
    protected double _won;
    protected double _amount;
    protected double _setno;

    const string _spName = "Sp_gbea";

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
    public string host
    {
        get { return _host; }
        set { _host = value; }
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

    public string visitor
    {
        get { return _visitor; }
        set { _visitor = value; }
    }

    public string category
    {
        get { return _category; }
        set { _category = value; }
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

    public string oddname
    {
        get { return _oddname; }
        set { _oddname = value; }
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
    public double Setno
    {
        get { return _setno; }
        set { _setno = value; }
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

  

    
    public DataSet GetAgentBalance()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "AgentBalance");
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet GetAgentCustometBets()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "AgentBets");
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet GetGbeaDeposits()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "GbeaDeposits");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public string CountGetGbeaDeposits()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "CountDeposits");
       
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["gbcount"].ToString();
        }
        return cntEmp;
    }

    public string SumGetGbeaDeposits()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "SumDeposits");

        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["gbsum"].ToString();
        }
        return cntEmp;
    }
    public string SumGetGbeaWithdraws()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "SumWithdraws");

        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["gbsum"].ToString();
        }
        return cntEmp;
    }

    public string SumGetGbeaDepositsbd()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "SumGbeaDepositbd");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());

        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["gbsum"].ToString();
        }
        return cntEmp;
    }

    public string SumGetGbeaWithdrawsbd()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "SumGbeaWithdrawbd");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());

        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["gbsum"].ToString();
        }
        return cntEmp;
    }

    public string CountGetGbeaWithdraws()
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
            cntEmp = drEmployee["gbcount"].ToString();
        }
        return cntEmp;
    }

    public string SumBetbyMatch()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "SumBetbyMatch");
        param[1] = new SqlParameter("@setno",_setno);
        param[2] = new SqlParameter("@oddname", _oddname);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["matchmoney"].ToString();
            if (cntEmp == "") {
                cntEmp = "0";
            }
        }
        return cntEmp;
    }

    public DataSet GetGbeaDepositsBydate()
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Mode", "GbeaDepositsBydate");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public string CountGetGbeaDepositbd()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "CountGbeaDepositbd");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());

        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["gbcount"].ToString();
        }
        return cntEmp;
    }

    public string CountGetGbeaWithdrawsbd()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "CountGbeaWithdrawsbd");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());

        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["gbcount"].ToString();
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
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "Agentcustomerphone");
        param[1] = new SqlParameter("@recptno ",_recpt);
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet GetCustomerWins()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "CustomerWin");
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet  ViewBets()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "GetMatchnumber");
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet ViewBetsbymatchnos()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "Betsbymatchnos");
        param[1] = new SqlParameter("@matchno",_setno);
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet ViewBetsbyHomeTeam()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "BetsbyHomeTeam");
        param[1] = new SqlParameter("@host",_host);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet ViewBetsbyAwayTeam()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "BetsbyAwayTeam");
        param[1] = new SqlParameter("@visitor", _visitor);
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet SureDealMatch()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "GetSureDealMatch");
        param[1] = new SqlParameter("@setno", _setno);
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet StraightLineMatch()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "GetMatchbyno");
        param[1] = new SqlParameter("@setno", _setno);
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet SetsMatch()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "GetMatchbyno");
        param[1] = new SqlParameter("@setno", _setno);
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet GetSureDealBeter()
    {

        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "SureDealBetter");
        param[1] = new SqlParameter("@setno", _setno);

        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet Getbeter()
    {

        string cntEmp = "";
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "GetCategorybyno");
        param[1] = new SqlParameter("@setno", _setno);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["category"].ToString();
            switch (cntEmp)
            {
                case "Sure Deal":
                    return GetSureDealBeter();
                case "Straight Line":
                    return GetStraightLineBeter();
                case "Sets":
                    return GetSetBeter();


            }


        }
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet GetStraightLineBeter()
    {

        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "StraightLineBeter");
        param[1] = new SqlParameter("@setno", _setno);

        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet GetSetBeter()
    {

        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "GetBetter");
        param[1] = new SqlParameter("@setno", _setno);

        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet Getmatches()
    {
        string cntEmp = "";
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "GetCategorybyno");
        param[1] = new SqlParameter("@setno", _setno);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["category"].ToString();
            switch (cntEmp)
            {
                case "Sure Deal":
                    return SureDealMatch() ;
                case "Straight Line":
                    return StraightLineMatch() ;
                case "Sets":
                   return SetsMatch();


            }

            
        }
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
                if (words.Length == 10)
                {
                    no = words[9].ToString();
                }
            }
        }
        return no;

    }

     public DataSet WonBetsbd()
    {
        
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "AllWonBetbd");   
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
        return objDBBridge.ExecuteDataset(_spName, param);
    }

     public DataSet WonBetbyno()
     {

         SqlParameter[] param = new SqlParameter[3];
         param[0] = new SqlParameter("@Mode", "WonBetbyno");
         param[1] = new SqlParameter("@matchno", _setno);
         param[2] = new SqlParameter("@username", username);
       
         return objDBBridge.ExecuteDataset(_spName, param);
     }

     public DataSet WonBets()
     {

         SqlParameter[] param = new SqlParameter[1];
         param[0] = new SqlParameter("@Mode", "AllWonBet");

         return objDBBridge.ExecuteDataset(_spName, param);
     }

   


    public String Userdetails(String name,String detail)
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "Getcustomers");
        param[1] = new SqlParameter("@username",name);
       
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            switch (detail){
                case "usernames":
            cntEmp = drEmployee["names"].ToString();
            return cntEmp;
                case "phone":
            cntEmp = drEmployee["phone"].ToString();
            return cntEmp;
                case "location":
            cntEmp = drEmployee["address"].ToString();
            return cntEmp;
                case "email":
            cntEmp = drEmployee["email"].ToString();
            return cntEmp;
                case "joineddate":
            cntEmp = drEmployee["jdate"].ToString();
            return cntEmp;
                

        }
        }
        return cntEmp;
    }

    public String WonMatchnoDetails(String matno, String detail)
    {
        string cntEmp = "";
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "ByMatchno");
        param[1] = new SqlParameter("@matchno", matno);

        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            switch (detail)
            {
                case "host":
                    cntEmp = drEmployee["host"].ToString();
                    return cntEmp;
                case "visitor":
                    cntEmp = drEmployee["visitor"].ToString();
                    return cntEmp;
                case "oddname":
                    cntEmp = drEmployee["oddname"].ToString();
                    return cntEmp;
                case "odd":
                    cntEmp = drEmployee["odd"].ToString();
                    return cntEmp;
                case "setno":
                    cntEmp = drEmployee["setno"].ToString();
                    return cntEmp;
              


            }
        }
        return cntEmp;
    }
    public string SumAmmountPerSets()
    {
        string cntEmp = "0";
        SqlParameter[] param2 = new SqlParameter[2];
        param2[0] = new SqlParameter("@Mode", "SumAmmountPerSet");
        param2[1] = new SqlParameter("@setno", _setno);


        DataTable dtEmployeed = new DataTable();
        dtEmployeed = objDBBridge.ExecuteDataset(_spName, param2).Tables[0];
        if (dtEmployeed.Rows.Count != 0)
        {
            DataRow drEmployeed;
            drEmployeed = dtEmployeed.Rows[0];
            cntEmp = drEmployeed["bettedsum"].ToString();
           
        }
       return cntEmp ;

    }

    public string SumAmmountPerSet()
    {

        string cntEmp = "0", cntEmps="";
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "GetCategorybyno");
        param[1] = new SqlParameter("@setno", _setno);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmps = drEmployee["category"].ToString();
            if (cntEmps == "Straight Line")
            {
                SqlParameter[] param2 = new SqlParameter[2];
                param2[0] = new SqlParameter("@Mode", "SumAmmountPerSet");
                param2[1] = new SqlParameter("@setno", _setno);


                DataTable dtEmployeed = new DataTable();
                dtEmployeed = objDBBridge.ExecuteDataset(_spName, param2).Tables[0];
                if (dtEmployeed.Rows.Count != 0)
                {
                    DataRow drEmployeed;
                    drEmployeed = dtEmployeed.Rows[0];
                    cntEmp = drEmployeed["bettedsum"].ToString();
                  

                }
               
            }
            if (cntEmps == "Sure Deal")
            {
                SqlParameter[] param1 = new SqlParameter[2];
                param1[0] = new SqlParameter("@Mode", "SumSureDealAmmount");
                param1[1] = new SqlParameter("@setno", _setno);


                DataTable dtEmployees = new DataTable();
                dtEmployees = objDBBridge.ExecuteDataset(_spName, param1).Tables[0];
                if (dtEmployees.Rows.Count != 0)
                {
                    DataRow drEmployees;
                    drEmployees = dtEmployees.Rows[0];
                    cntEmp = drEmployees["bettedsum"].ToString();
                   

                }

               
            }
        }
       
        return cntEmp;
    }
    


    public string SumExpectedPayout()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "SumExpectedPayOut");
        param[1] = new SqlParameter("@setno", _setno);


        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["bettedsum"].ToString();
        }
        return cntEmp;
    }

    public string SumBetterPerGame()
    {

        string cntEmp = "";
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "GetCategorybyno");
        param[1] = new SqlParameter("@setno", _setno);
        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["category"].ToString();
            switch (cntEmp)
            {
                case "Sure Deal":
                    return SumSureDealBetterPerGame();
                case "Straight Line":
                    return SumStraightBetterPerGame();
               

            }


        }
        return cntEmp;
    }

    public string SumStraightBetterPerGame()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "SumBetterPerGame");
        param[1] = new SqlParameter("@setno", _setno);


        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["betters"].ToString();
        }
        return cntEmp;
    }

    public string SumSureDealBetterPerGame()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "SumSureDealBetter");
        param[1] = new SqlParameter("@setno", _setno);


        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["betters"].ToString();
        }
        return cntEmp;
    }
    

    public DataSet GetGbeaTransactions()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "GbeaTransactions");
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet GetGbeaTransactionsbydate()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "TransactionsBydate");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public string CountGbeaTransactions()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "CountGbeaTransactions");
       

        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["gbcount"].ToString();
        }
        return cntEmp;
    }


    public string CountGbeaTransactionsbd()
    {
        string cntEmp = "0";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "CountTransactionsbd");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());

        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            cntEmp = drEmployee["gbcount"].ToString();
        }
        return cntEmp;
    }

    public DataSet Transactionsbyperiod()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "AllTransactions");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet GetGbeaWithdraws()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "GbeaWithdraws");
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet GetGbeaWithdrawsbydate()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "GbeaWithdrawsBydate");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2.ToShortDateString());
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
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "Agentcustomerphone");
        param[1] = new SqlParameter("@recptno ", recno);
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

    public String  getRecieptno(string sformat)
    {
        String no = "";
        if (sformat != "")
        {
            string[] words = sformat.ToString().Split(' ');
           
            no = words[3].ToString();
           
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

   
    #endregion
}
