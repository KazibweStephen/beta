using System;
using System.Data;
using SRN.DAL;
using System.Text.RegularExpressions;
using System.Text;
using System.Net;
using System.Data.SqlClient;
/// <summary>
/// Summary description for Login
/// </summary>
public class Login
{
	 public Login()
        {
            
        }
        #region Variables
        DBBridge objDBBridge = new DBBridge();
        Agentclass clsagent = new Agentclass();
        public const int PHONENUMBER = 0;
        public const int USERNAME = 1;
        //MMPayments pays = new MMPayments();
        protected int _loginId;
        protected double _phone;
        protected String _phoneno = String.Empty;
        protected int _year;
        protected DateTime _DOB;
        protected DateTime _DOJ;
        protected int _totalsent;
        protected int _totalrecieved;
        protected int _status;
        protected DateTime _datesent;
        protected DateTime _daterecieved;
        protected string _msdid = String.Empty;
        protected string _loginName = String.Empty;
        protected string _staffid = String.Empty;
        protected string _firstName = String.Empty;
        protected string _resultmessage = String.Empty;
        protected string _surname = String.Empty;
        protected string _email = String.Empty;
        protected string _country = String.Empty;
        protected string _username = String.Empty;
        protected string _password = String.Empty;
      protected string _league = String.Empty;
     protected string _matcode = String.Empty;
     protected string _visitor = String.Empty;
     protected string _away = String.Empty;
     protected string _msg = String.Empty;
     protected string _address = String.Empty;
     protected string _gender = String.Empty;
     protected string _msgid = String.Empty;
     protected string _bet_type = String.Empty;
     protected string _AccBalance = String.Empty;
     protected string _position = String.Empty;
     protected string _source = String.Empty;
     protected string _reason = String.Empty;
       protected int _rights;
       protected decimal _balance;
       public double _betID = 0;
       public double _setodd = 0;
       public double _ttmoney= 0;
       public double _amount;
       public double _totalcharge;
       public double _AcBalance;
       public double _betmoney = 0;
       protected int _gameid;
       public int _betid;
       protected int _itemid;
       public int _mtid;
       protected string _refno;
       protected string _referenceid;
       protected string _response;
       public int _setsize;
        protected DataSet _dsLogin = new DataSet();
        const string _spName = "sp_Login";
        const string _spName1 = "NewRegModel";
        const string _spName2 = "pendingbet";
        const string _spmt = "SP_Mtcustomers";
        #endregion

        #region Class Property
        public int LoginId
        {
            get { return _loginId; }
            set { _loginId = value; }
        }
        public string msgid {
            get { return _msgid; }
            set { _msgid = value; }
        
        
        }
        public string staffid
        {
            set { _staffid = value; }
            get { return _staffid; }

        }
        public string refno
        {
            get { return _refno; }
            set { _refno = value; }


        }
        public int status {
            set {_status=value;}
            get {return _status;}
        
        
        }
        public string referenceid
        {
            get { return _referenceid; }
            set { _referenceid = value; }


        }
        public string response
        {
            get { return _response; }
            set { _response = value; }
        }

        public int itemId
        {
            get { return _itemid; }
            set { _itemid = value; }
        }
       public double amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

       public double setodd
       {
           get { return _setodd; }
           set { _setodd = value; }
       }
     
       public double acbalance
       {
           get { return _AcBalance; }
           set { _AcBalance = value; }
       }

        public string LoginName
        {
            get { return _loginName; }
            set { _loginName = value; }
        }
        public string source
        {
            get { return _source; }
            set { _source = value; }
        }
        public string resultmessage
        {
            get { return _resultmessage; }
            set { _resultmessage= value; }
        }
        public string position
        {
            get { return _position; }
            set { _position= value; }
        }
        public decimal balance {
            get { return _balance; }
            set { _balance = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string gender
        {
            get { return _gender; }
            set { _gender= value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public string Message
        {
            get { return _msg; }
            set { _msg= value; }
        }

        public string MessageId
        {
            get { return _msgid; }
            set { _msgid = value; }
        }
        public string reason
        {
            get { return _reason; }
            set { _reason = value; }
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
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public int totalsent {
            set { _totalsent = value; }
            get { return _totalsent; }
        
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string Phoneno
        {
            get { return _phoneno; }
            set { _phoneno = value; }
        }

        public string Accbalance
        {
            get { return _AccBalance; }
            set { _AccBalance = value; }
        }

        public int Rights
        {
            get { return _rights; }
            set { _rights = value; }
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
        public DateTime DOB
        {
            get { return _DOB; }
            set { _DOB = value; }
        }
        public DateTime datesent
        {
            get { return _datesent; }
            set { _datesent= value; }
        }
        public DateTime daterecieved
        {
            get { return _daterecieved; }
            set { _daterecieved= value; }
        }
        public double betmoney
        {
            get { return _betmoney; }
            set { _betmoney= value; }
        }
        public double ttmoney
        {
            get { return _ttmoney; }
            set { _ttmoney = value; }
        }
        public double AcBalance
        {
            get { return _AcBalance; }
            set {_AcBalance= value; }
        }
        public double totalcharge
        {
            get { return _totalcharge; }
            set { _totalcharge = value; }
        }
        public int setsize
        {
            get { return _setsize; }
            set { _setsize= value; }
        }
        public int totalrecieved
        {
            get { return _totalrecieved; }
            set { _totalrecieved = value; }
        }
        public int betId
        {
            get { return _betid; }
            set { _betid = value; }
        }
        public int gameid {
            get { return _gameid; }
            set { _gameid = value; }
        
        }
        public int mtid
        {
            get { return _mtid; }
            set { _mtid = value; }
        }


        public DataSet dsLogin
        {
            get { return _dsLogin; }
            set { _dsLogin = value; }
        }
        #endregion

        #region Public Methods

        public int Insert()
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@Mode", "InsertUser");
            param[1] = new SqlParameter("@LoginName", _loginName);
            param[2] = new SqlParameter("@Email", _email);
            param[3] = new SqlParameter("@Username", _username);
            param[4] = new SqlParameter("@Password", _password);
            param[5] = new SqlParameter("@Rights", _rights);
            return objDBBridge.ExecuteNonQuery(_spName, param);
        }
        public int validatesize(String[] arrayitem)  //Test if reciecipt has doublechance /halftie and handcap
        {
            int correct = 1;
            for (int i = 1; i < arrayitem.Length - 1; i++)
            {
                int size=clsagent.TestBetType(Convert.ToInt16(arrayitem[i]));

                if (size>correct)
                {
                    correct = size;
                   // return correct;
                }
            }

            return correct;
        }
        public string MaximumSizeBetOpion(String[] arrayitem)  //Test if reciecipt has doublechance /halftie and handcap
        {
            int correct = 1;
            string betoptionname = "";
            GlobalBetsAdmin.betoption betoption = null;
            for (int i = 1; i < arrayitem.Length - 1; i++)
            {
                betoption = clsagent.GetBetType(Convert.ToInt16(arrayitem[i]));
                int size =  betoption.minimumSize;
                if (size > correct)
                {
                    correct = size;
                    betoptionname = betoption.optionname;
                    if (betoptionname == "oe") {
                        betoptionname = "oddeven";
                    }
                    // return correct;
                }
            }

            return betoptionname;
        }
        public int InsertNewUser()
        {
            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@Mode", "Adduser");
            param[1] = new SqlParameter("@pnumber", _phoneno);
            param[2] = new SqlParameter("@fname",_firstName);
            param[3] = new SqlParameter("@sname", _surname);
            param[4] = new SqlParameter("@dob",_DOB);
            param[5] = new SqlParameter("@email",_email);
            param[6] = new SqlParameter("@position", _position);
            param[7] = new SqlParameter("@gender",_gender);
            param[8] = new SqlParameter("@address ", _address);
            param[9] = new SqlParameter("@Password", _password);
            param[10] = new SqlParameter("@username", _username);
            return objDBBridge.ExecuteNonQuery(_spName, param);
        }
        public bool getAdminDetails()
        {
            bool ret = false;
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "UserDetails");
            param[1] = new SqlParameter("@username", _username);
            DataTable customername = new DataTable();
            customername = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
            if (customername.Rows.Count == 1)
            {
                DataRow reader;
                reader = customername.Rows[0];
                _username = reader["username"].ToString();
                _firstName = reader["fname"].ToString();
                _surname = reader["sname"].ToString();
                _DOB = Convert.ToDateTime(reader["dob"]);
                _gender = reader["gender"].ToString();
                _address = reader["paddress"].ToString();
                _phoneno = reader["pnumber"].ToString();
                _staffid = reader["staffid"].ToString();
                _email = reader["eaddress"].ToString();
                _position = reader["position"].ToString();
                _password = reader["password"].ToString();

                ret = true;
            }
            return ret;
        }

        public int InsertPhoneBetter()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "InsertPhoneBetter");
            param[1] = new SqlParameter("@phoneno", _phoneno);        
            return objDBBridge.ExecuteNonQuery(_spName1, param);
        }
        public void PayoutBalance()
        {

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@username", _username);
            param[1] = new SqlParameter("@mode", "getpayout");
            DataTable dtDepartment = new DataTable();
            dtDepartment = objDBBridge.ExecuteDataset(_spName1, param).Tables[0];
            if (dtDepartment.Rows.Count != 0)
            {
                DataRow drDepartment;
                drDepartment = dtDepartment.Rows[0];
                _balance = Convert.ToDecimal(drDepartment["payout"]);

            }
        }

        public int AddtoalertList()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "insertcustomer");
            param[1] = new SqlParameter("@phoneno", _phoneno);
            return objDBBridge.ExecuteNonQuery(_spmt, param);
        }
        public int StopAlert()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "stopsms");
            param[1] = new SqlParameter("@phoneno", _phoneno);
            return objDBBridge.ExecuteNonQuery(_spmt, param);
        }
        public int insertmtrecord()
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@Mode", "insertmtrecord");
            param[1] = new SqlParameter("@mtid", _mtid);
            param[2] = new SqlParameter("@datesent",_datesent);
            param[3] = new SqlParameter("@refno", _refno);
            param[4] = new SqlParameter("@totalsent", _totalsent);
            return objDBBridge.ExecuteNonQuery(_spmt, param);
        }
        public int updatequeerecord()
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Mode", "updatesentmt");
            param[1] = new SqlParameter("@mtid", _mtid);
            param[2] = new SqlParameter("@referenceid",_referenceid);
            param[3] = new SqlParameter("@response", _response);
            return objDBBridge.ExecuteNonQuery(_spmt, param);
        }
        public int updateCompleteMT()
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@Mode", "updatecompletemt");
            param[1] = new SqlParameter("@totalsent", _totalsent);
            param[2] = new SqlParameter("@totalcharge", _totalcharge);
            param[3] = new SqlParameter("@referenceid", _referenceid);
            param[4] = new SqlParameter("@response", _response);
            param[5] = new SqlParameter("@totalrecieved", _totalrecieved);
            return objDBBridge.ExecuteNonQuery(_spmt, param);
        }
        public int completemtTransaction()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "completemtTransaction");
            param[1] = new SqlParameter("@mtid",_mtid);
            return objDBBridge.ExecuteNonQuery(_spmt, param);
        }
        public int saveresponse()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "saveresponse");
            param[1] = new SqlParameter("@response",_response);
            return objDBBridge.ExecuteNonQuery(_spmt, param);
        }
    
        public int updateresponse()
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Mode", "updateresponse");     
            param[1] = new SqlParameter("@referenceid", _referenceid);
            param[2] = new SqlParameter("@response", _response);
       
            return objDBBridge.ExecuteNonQuery(_spmt, param);
        }
        public int updatemtid()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "updatemtid");
            param[1] = new SqlParameter("@msgid", _mtid);
          
            return objDBBridge.ExecuteNonQuery(_spmt, param);
        }
        public int insertmtitem()
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@Mode", "insertmtphonerecord");
            param[1] = new SqlParameter("@mtid", _mtid);
            param[2] = new SqlParameter("@phoneno", _phoneno);
            param[3] = new SqlParameter("@itemid", _itemid);
            param[4] = new SqlParameter("@refno", _refno);
            return objDBBridge.ExecuteNonQuery(_spmt, param);
        }
        public int updatebilledphone()
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@Mode", "updatebilledphone");
            param[1] = new SqlParameter("@mtid", _mtid);
            param[2] = new SqlParameter("@phoneno", _phoneno);
            param[3] = new SqlParameter("@response", _response);
            param[4] = new SqlParameter("@daterecieved",_daterecieved);
            param[5] = new SqlParameter("@status", _status);
            return objDBBridge.ExecuteNonQuery(_spmt, param);
        }
        public int InsertNewBetter()
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@Mode", "InsertNewBetter");
            param[1] = new SqlParameter("@phoneno", _phoneno);
            param[2] = new SqlParameter("@amount", _amount);
            param[3] = new SqlParameter("@username",_username);
            param[4] = new SqlParameter("@comment", _msg);
            param[5] = new SqlParameter("@id", _msgid);
            return objDBBridge.ExecuteNonQuery(_spName1, param);
        }
        public int Update()
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@Mode", "Update");
            param[1] = new SqlParameter("@LoginName", _loginName);
            param[2] = new SqlParameter("@Email", _email);
            param[3] = new SqlParameter("@Username", _username);
            param[4] = new SqlParameter("@Password", _password);
            param[5] = new SqlParameter("@Rights", _rights);
            param[6] = new SqlParameter("@LoginId", _loginId);
            return objDBBridge.ExecuteNonQuery(_spName, param);
        } 
        public DataSet  ViewSure()
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Mode", "Viewsure");
            return objDBBridge.ExecuteDataset(_spName, param);
        }
        public DataSet getphonenos()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "getphonenos");
            param[1] = new SqlParameter("@mtid", _mtid);
            return objDBBridge.ExecuteDataset(_spmt, param);
        }
        public DataSet getphonenosbymt()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "getphonenosbymt");
            param[1] = new SqlParameter("@mtid", _mtid);
            return objDBBridge.ExecuteDataset(_spmt, param);
        }
        public DataSet CustomerDetails()
        {
           SqlParameter[] param = new SqlParameter[2];
           param[0] = new SqlParameter("@Mode", "SearchCustomer");
           param[1] = new SqlParameter("@phoneno", _phoneno);
            return objDBBridge.ExecuteDataset(_spName1, param);
        }
        public bool getCustomerDetails()
        {
            bool ret = false;
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "SearchCustomer");
            param[1] = new SqlParameter("@phoneno", _phoneno);
            DataTable customername = new DataTable();
            customername=objDBBridge.ExecuteDataset(_spName1, param).Tables[0];
            if (customername.Rows.Count == 1)
            {
                DataRow customerusename;
                customerusename = customername.Rows[0];
                _username = customerusename["username"].ToString();
                ret = true;
            }
            return ret;
        }
        public int getmaxitemid()
        {
            _itemid = 0;
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Mode", "getmaxitemid");
            DataTable customername = new DataTable();
            customername = objDBBridge.ExecuteDataset(_spmt, param).Tables[0];
            if (customername.Rows.Count>0)
            {
                DataRow customerusename;
                customerusename = customername.Rows[0];
                _itemid =Convert.ToInt32( customerusename["msgid"]);
             
            }
            return _itemid;
        } 
        public DataTable ValidateLogin()
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Mode", "ChkLogin");
            param[1] = new SqlParameter("@Username", _username);
            param[2] = new SqlParameter("@Password", _password);
            return objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        }
        public DataTable AccountBalance()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "AccountBalance");
            param[1] = new SqlParameter("@phoneno", _phoneno);
            return objDBBridge.ExecuteDataset(_spName1, param).Tables[0];


        }
        public DataTable forgotpwd()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "forgotpwd");
            param[1] = new SqlParameter("@Email", _email);
            return objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        }

        public int updatePassword(string password, string email, string phone)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Mode", "update_pass");
            param[1] = new SqlParameter("@Email", email);
            param[2] = new SqlParameter("@pnumber", phone);
            param[3] = new SqlParameter("@Password", password);
            return objDBBridge.ExecuteNonQuery(_spName, param);
        }

        public decimal getBalance()
        {
            decimal bal = 0;
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "AccountBalance");
            param[1] = new SqlParameter("@phoneno", _phoneno);
            DataTable GetBalances = new DataTable();
            GetBalances = objDBBridge.ExecuteDataset(_spName1, param).Tables[0];
            if (GetBalances.Rows.Count > 0)
            {
                DataRow drBalance;
                drBalance = GetBalances.Rows[0];
                bal=Convert.ToDecimal(drBalance["ammount_e"]);
            }
            return bal;

        }    
        public DataTable PhoneCustomerList()
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Mode", "PhoneCustomers");
            return objDBBridge.ExecuteDataset(_spName1, param).Tables[0];
        }
        public DataTable customersetmatches()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "customersetmatches");
            param[1] = new SqlParameter("@betID", _betid);
            return objDBBridge.ExecuteDataset(_spName2, param).Tables[0];
        }
        public void getbettedset_info()
        {
           
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@username", _username);
            param[1] = new SqlParameter("@betID", _betid);       
            DataTable dtDepartment = new DataTable();
            dtDepartment = objDBBridge.ExecuteDataset("getbettedset", param).Tables[0];
            if (dtDepartment.Rows.Count != 0)
            {
                DataRow drDepartment;
                drDepartment = dtDepartment.Rows[0];
                _betmoney = Convert.ToDouble (drDepartment["betmoney"]);
                _setodd= Convert.ToDouble( drDepartment["setodd"]);
                _betID = Convert.ToDouble( drDepartment["betId"]);
                _setsize = Convert.ToInt16( drDepartment["setsize"]);
                _ttmoney =Convert.ToDouble( Math.Round( Convert.ToDecimal (_setodd * _betmoney),0));
            }
        }
        public void getsetgames()
        {

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@username", _username);
            param[1] = new SqlParameter("@betID", _betid);
            DataTable dtDepartment = new DataTable();
            dtDepartment = objDBBridge.ExecuteDataset("getbettedset", param).Tables[0];
            if (dtDepartment.Rows.Count != 0)
            {
                DataRow drDepartment;
                drDepartment = dtDepartment.Rows[0];
                _betmoney = Convert.ToDouble(drDepartment["betmoney"]);
                _setodd = Convert.ToDouble(drDepartment["setodd"]);
                _betID = Convert.ToDouble(drDepartment["betId"]);
                _setsize = Convert.ToInt16(drDepartment["setsize"]);
                _ttmoney = Convert.ToDouble(Math.Round(Convert.ToDecimal(_setodd * _betmoney), 0));
            }
        }

        public void getuser_info()
        {
            
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@username", _username);
            param[1] = new SqlParameter("@mode", "getuser");
            DataTable dtDepartment = new DataTable();
            dtDepartment = objDBBridge.ExecuteDataset(_spName1, param).Tables[0];
            if (dtDepartment.Rows.Count != 0)
            {
                DataRow drDepartment;
                drDepartment = dtDepartment.Rows[0];
                try
                {
                    _balance = Convert.ToDecimal(drDepartment["ammount_e"]);
                }
                catch (Exception exp) { _balance = 0; }
                _firstName = (drDepartment["fname"]).ToString();
                _phoneno = (drDepartment["pnumber"]).ToString();
            }
        }

        /*
         * @param userTag the currently known user attribute
         * @param value PHONENUMBER for pnumber or USERNAME for username
         *@return tag the user's attribute
         */
        public string getuser_info(string userTag, int value)
        {
            string tag = "";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@username", userTag);
            param[1] = new SqlParameter("@mode", "getuser");
            DataTable dataTable = new DataTable();
            dataTable = objDBBridge.ExecuteDataset(_spName1, param).Tables[0];
            if (dataTable.Rows.Count > 0)
            {
                DataRow dataRow;
                dataRow = dataTable.Rows[0];
                if(value == PHONENUMBER)
                    tag = (dataRow["pnumber"]).ToString();
                else if (value == USERNAME)
                    tag = (dataRow["username"]).ToString();
            }
            return tag;
        }

        public string test()
        {
            DataTable dtmatches = new DataTable();
            string res = "";
            try
            {
                SqlParameter[] dtm = new SqlParameter[5];
                dtm[0] = new SqlParameter("@username", "felix.agent");
                dtm[1] = new SqlParameter("@bettor", "felix.agent");
                dtm[2] = new SqlParameter("@amount", "1000");
                dtm[3] = new SqlParameter("@betid", "2279");
                dtm[4] = new SqlParameter("@customerID", "mrtnxperia");

                int x = objDBBridge.ExecuteNonQuery("UpdateagentonlineAccounts", dtm);
                if (x > 0) { res = "boom"; }
            }
            catch (Exception ex)
            {
                res = ex.ToString();
            }
            return res;
        }


        public void pendingbet()
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@phoneno", _phoneno);
            param[1] = new SqlParameter("@betinfo", _msg);
            param[2] = new SqlParameter("@mode", "insertinfo");
            
            objDBBridge.ExecuteDataset(_spName2, param);
            
        }
        public DataTable getpendingset_info()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@phoneno", _phoneno);
            param[1] = new SqlParameter("@mode", "getpending");
            DataTable dtDepartment = new DataTable();
            return objDBBridge.ExecuteDataset(_spName2, param).Tables[0];
           
        }
        public int updateroles()
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@username", _username);
            param[1] = new SqlParameter("@position", _position);
            param[2] = new SqlParameter("@mode", "updateroles");
            int X = objDBBridge.ExecuteNonQuery(_spName, param);
            return X;
        }
        public int CreateAccount()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "CreatePayout");
            param[1] = new SqlParameter("@username", _username);
            return objDBBridge.ExecuteNonQuery(_spName, param);
        }
        public int CreateBetAccount()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "CreateBetAccount");
            param[1] = new SqlParameter("@username", _username);
            return objDBBridge.ExecuteNonQuery(_spName, param);
        }
        public DataSet Allusers()
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Mode", "Allusers");
            return objDBBridge.ExecuteDataset(_spName, param);
        }
        public DataSet usersbyposition()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Mode", "usersbytype");
            param[1] = new SqlParameter("@position", _position);
            return objDBBridge.ExecuteDataset(_spName, param);
        }
        public DataTable getpendingbet_info()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@phoneno", _phoneno);
            param[1] = new SqlParameter("@mode", "getpendingbet");
            DataTable dtDepartment = new DataTable();
            return objDBBridge.ExecuteDataset(_spName2, param).Tables[0];

        }
        public bool getpendingset()
        {
            bool enablebet = false;
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@phoneno", _phoneno);
            param[1] = new SqlParameter("@mode", "getpendingset");
            DataTable dtDepartment = new DataTable();
            DataRow dr;
            dtDepartment= objDBBridge.ExecuteDataset(_spName2, param).Tables[0];
            if (dtDepartment.Rows.Count > 0)
            {
                int totalbets = dtDepartment.Rows.Count;
                for (int i=0; i < totalbets; i++)
                {
                    dr = dtDepartment.Rows[i];
                    SqlParameter[] par = new SqlParameter[4];
                    par[0] = new SqlParameter("@username", dr["username"].ToString());
                    par[1] = new SqlParameter("@betid", Convert.ToInt32(dr["betid"]));
                    par[2] = new SqlParameter("@amount", Convert.ToDouble(dr["betmoney"]));
                    par[3] = new SqlParameter("@method", "deposit after bet");
                    int ret = objDBBridge.ExecuteNonQuery("LateDeposit", par);
                    if (ret > 0)
                    {
                        _betid = Convert.ToInt32(dr["betid"]);
                        _betmoney = Convert.ToDouble(dr["betmoney"]);
                        _setodd = Convert.ToDouble(dr["setodd"]);
                        _setsize = Convert.ToInt32(dr["setsize"]);
                       _msg =successmessage(Convert.ToDecimal(_betmoney), _betid, Convert.ToDecimal(_setodd), getBalance(), _phoneno);
                      sendcustomersms(_msg, _phoneno);
                        
                    }
                }
                return true;
            }
            return enablebet;


        }
        public DataTable getpendingcustomer()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@phoneno", _phoneno);
            param[1] = new SqlParameter("@mode", "getpendingcustomer");
            DataTable dtDepartment = new DataTable();
            return objDBBridge.ExecuteDataset(_spName2, param).Tables[0];

        }
        public DataTable getWaitingRequests()
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@mode", "WaitingRequest");
            DataTable dtDepartment = new DataTable();
            return objDBBridge.ExecuteDataset(_spmt, param).Tables[0];

        }
        public DataTable getCompleteRequests()
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@mode", "CompleteRequest");
            DataTable dtDepartment = new DataTable();
            return objDBBridge.ExecuteDataset(_spmt, param).Tables[0];

        }
        public bool getpendinggames(int size)
        {
            bool truebet = false;
            int sizecompare = 0;
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@phoneno", _phoneno);
            param[1] = new SqlParameter("@mode", "getpendinggames");
            param[2] = new SqlParameter("@betID", _betid);

            DataTable dtDepartment = new DataTable();
            dtDepartment=objDBBridge.ExecuteDataset(_spName2, param).Tables[0];
            DataRow dr;
            if (dtDepartment.Rows.Count != 0)
            {
                dr = dtDepartment.Rows[0];
                sizecompare = Convert.ToInt16(dr["counts"]);
                if (sizecompare == size)
                {
                    return true;
                }
                
            }
            return truebet;

        }
        public int updatependinggames() {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@phoneno", _phoneno);
            param[1] = new SqlParameter("@mode", "updatependinggames");
            param[2] = new SqlParameter("@betID",_betid);
            return objDBBridge.ExecuteNonQuery(_spName2, param);
        
        }
        public void deletependingset_info()
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@phoneno", _phoneno);
            param[1] = new SqlParameter("@mode", "deletepending");
            DataTable dtDepartment = new DataTable();
            objDBBridge.ExecuteDataset(_spName2, param);

        }
        public bool recievedsms()
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@phoneno", _phoneno);
            param[1] = new SqlParameter("@message", _msg);
            param[2] = new SqlParameter("@messageId", _msgid);
            param[3] = new SqlParameter("@mode", "insertsms");
            param[4] = new SqlParameter("@sourceapi", _source);
           int X= objDBBridge.ExecuteNonQuery(_spName2, param);
           if (X > 0) { return true; }
           else {
               return false;
           }
        }
        public int responsesms()
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@phoneno", _phoneno);
            param[1] = new SqlParameter("@response", _msg);
            param[2] = new SqlParameter("@messageId", _msgid);
            param[3] = new SqlParameter("@mode", "betreponse");
            param[4] = new SqlParameter("@sourceapi", _source);
            int X = objDBBridge.ExecuteNonQuery(_spName2, param);
            return X;
        }
        public int mmresponsesms()
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@phoneno", _phoneno);
            param[1] = new SqlParameter("@response", _msg);
            param[2] = new SqlParameter("@messageId", _msgid);
            param[3] = new SqlParameter("@mode", "mmreponse");
            param[4] = new SqlParameter("@sourceapi", _source);
            int X = objDBBridge.ExecuteNonQuery(_spName2, param);
            return X;
        }
        public bool recievedmmsms()
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@phoneno", _phoneno);
            param[1] = new SqlParameter("@message", _msg);
            param[2] = new SqlParameter("@messageId", _msgid);
            param[3] = new SqlParameter("@mode", "insertmmsms");
            param[4] = new SqlParameter("@sourceapi", _source);
            param[5] = new SqlParameter("@reason", _reason);
            int X = objDBBridge.ExecuteNonQuery(_spName2, param);
            if (X > 0) { return true; }
            else
            {
                return false;
            }
        }
        private string RandomString(int size) {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            { 
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch); 
            }
            return builder.ToString(); 
        }      
    public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    public int insertpaymentRequest()
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@mobileno", _phoneno);
        param[1] = new SqlParameter("@serial",RandomString(7)+RandomNumber(10, 100).ToString());
        param[2] = new SqlParameter("@account",_username);
        param[3] = new SqlParameter("@ammountreq",_amount);
        return objDBBridge.ExecuteNonQuery("paymentrequest", param);
    }
    public string displaymatches(int SetId)
   {
       string message="",match ="", home, away, choice, odd, win=null, betmoney=null;
       betId = SetId;
       getbettedset_info();
       DataTable matches = new DataTable();
       matches = customersetmatches();
       if (matches.Rows.Count == 0)
       {

           // Label1.Text= "Invalid username or password!";
       message = "No+set+records+found.";
       }
       else
       {
           int rows = matches.Rows.Count - 1;

           for (int i = 0; i <= rows; i++)
           {
               home = CollapseSpaces(matches.Rows[i].ItemArray[0].ToString().Trim());
               away = CollapseSpaces(matches.Rows[i].ItemArray[1].ToString().Trim());
               choice = matches.Rows[i].ItemArray[2].ToString().Trim();
               odd = matches.Rows[i].ItemArray[3].ToString().Trim();
               betmoney = matches.Rows[i].ItemArray[4].ToString().Trim();
               win = matches.Rows[i].ItemArray[5].ToString().Trim();

               if (choice == "Away")
               {

                   match += home + "+vs+" + away + "+Away(" + odd + "),+";
               }
               else if (choice == "Home")
               {
                   match += home + "+vs+" + away + "+Home(" + odd + "),+";

               }
               else if (choice == "Draw")
               {

                   match += home + "+vs+" + away + "+Draw(" + odd + "),+";

               }
           }

        message =match.Trim();
       }


       return message;
   }

    public DataTable displayresult(int SetId) {
        string message = "", match = "", home, away, choice, odd, win = null, betmoney = null;
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@username", _username);
        param[1] = new SqlParameter("@mode", "getsetresults");
        param[2] = new SqlParameter("@betID", SetId);

        DataTable matches = new DataTable();
        matches = objDBBridge.ExecuteDataset(_spName1, param).Tables[0];
        DataRow dr;
        if (matches.Rows.Count > 0) {
             dr=matches.Rows[0];
            _ttmoney =Convert.ToDouble(Math.Round( (Convert.ToDecimal(dr["betmoney"]) * Convert.ToDecimal(dr["setodd"])),0));
           int status=Convert.ToInt16(dr["status"]);

            int rows = matches.Rows.Count - 1;
            int matchstatus=0,resultstatus=0;
            string scores;
            for (int i = 0; i <= rows; i++)
            {
                dr = matches.Rows[i];
                home = CollapseSpaces(dr["host"].ToString());
                away = CollapseSpaces(dr["visitor"].ToString());
                matchstatus = Convert.ToInt16(dr["matchstatus"]);
                resultstatus = Convert.ToInt16(dr["ResultStatus"]);
                if (resultstatus == 2)
                {
                    switch (matchstatus)
                    {
                        case 2:
                            match += home + " " + CollapseSpaces(dr["scores"].ToString()) + away + "+Successfull+";
                            break;
                        case 3:
                            match += home + " " + CollapseSpaces(dr["scores"].ToString()) + away + "+unSuccessfull+";

                            break;
                        case -1:
                            match += home + "+vs+" + away + "+match+postponed+";
                            break;
                        default:
                            match += "";
                            break;

                    }

                }
                else if (resultstatus == 1)
                {
                    switch (matchstatus)
                    {
                        case 2:
                            match += home + "+vs+" + away + "+waiting+for+result+";
                            break;

                        case -1:
                            match += home + "+vs+" + away + "+match+postponed+";
                            break;
                        default:
                            match += "";
                            break;

                    }

                }
                else {
                    match += "";
                }
            }
            if (status == 2) {

                _resultmessage = "Congratulations.You+got+sh+" + _ttmoney.ToString() + "Score:" + match;
            }
            else if (status == 3)
            {

                _resultmessage = "Scores+for+betid" + betId.ToString()+":+"+match+".set+unsuccessfull";
            }
            else if (status == 1)
            {

                _resultmessage = "Scores+for+betid" + betId.ToString() + ":+" + match + ".Please+wait+for+all+the+results";
            }
           else if (status == -1)
            {

                _resultmessage = "Scores+for+betid" + betId.ToString() + ":+" + match + ".Please+wait+for+all+the+results";
            }
        
        }
        return matches;

    }
    public string displayresultstatus(int SetId)
    {
        string message = "", match = "", home, away, choice, odd, win = null, betmoney = null;
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@username", _username);
        param[1] = new SqlParameter("@mode", "getsetresults");
        param[2] = new SqlParameter("@betID", SetId);

        DataTable matches = new DataTable();
        matches = objDBBridge.ExecuteDataset(_spName1, param).Tables[0];
        DataRow dr;
        if (matches.Rows.Count > 0)
        {
            dr = matches.Rows[0];
            _ttmoney = Convert.ToDouble(Math.Round((Convert.ToDecimal(dr["betmoney"]) * Convert.ToDecimal(dr["setodd"])), 0));
            int status = Convert.ToInt16(dr["status"]);

            int rows = matches.Rows.Count - 1;
            int matchstatus = 0, resultstatus = 0;
            string scores;
            for (int i = 0; i <= rows; i++)
            {
                dr = matches.Rows[i];
                home = CollapseSpaces(dr["host"].ToString());
                away = CollapseSpaces(dr["visitor"].ToString());
                matchstatus = Convert.ToInt16(dr["matchstatus"]);
                resultstatus = Convert.ToInt16(dr["ResultStatus"]);
                if (resultstatus == 2)
                {
                    switch (matchstatus)
                    {
                        case 2:
                            match += home + " " + CollapseSpaces(dr["scores"].ToString()) + away + "+Successfull+";
                            break;
                        case 3:
                            match += home + " " + CollapseSpaces(dr["scores"].ToString()) + away + "+unSuccessfull+";

                            break;
                        case -1:
                            match += home + "+vs+" + away + "+match+postponed+";
                            break;
                        default:
                            match += "";
                            break;

                    }

                }
                else if (resultstatus == 1)
                {
                    switch (matchstatus)
                    {
                        case 2:
                            match += home + "+vs+" + away + "+waiting+for+result+";
                            break;

                        case -1:
                            match += home + "+vs+" + away + "+match+postponed+";
                            break;
                        default:
                            match += "";
                            break;

                    }

                }
                else
                {
                    match += "";
                }
            }
            if (status == 2)
            {

                _resultmessage = "Congratulations.You+got+sh+" + _ttmoney.ToString() + "Score:" + match;
            }
            else if (status == 3)
            {

                _resultmessage = "Scores+for+betid" + betId.ToString() + ":+" + match + ".set+unsuccessfull";
            }
            else if (status == 1)
            {

                _resultmessage = "Scores+for+betid" + betId.ToString() + ":+" + match + ".Please+wait+for+all+the+results";
            }
            else if (status == -1)
            {

                _resultmessage = "Scores+for+betid" + betId.ToString() + ":+" + match + ".Please+wait+for+all+the+results";
            }

        }
        return _resultmessage;

    }
    public string displaygames(int SetId)
    {
        string message = "", match = "", home, away, choice, odd, win = null, betmoney = null;
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@username", _username);
        param[1] = new SqlParameter("@Mode", "getsetgames");
        param[2] = new SqlParameter("@betid", SetId);

        DataTable matches = new DataTable();
        matches= objDBBridge.ExecuteDataset(_spName1, param).Tables[0];
        DataRow dr;
        if (matches.Rows.Count == 0)
        {
            // Label1.Text= "Invalid username or password!";
            //message = "No+set+records+found.";
			message = ";";
            return message;
        }
        else
        {
            dr=matches.Rows[0];
            _ttmoney =Convert.ToDouble(Math.Round( (Convert.ToDecimal(dr["betmoney"]) * Convert.ToDecimal(dr["setodd"])),0));
            int rows = matches.Rows.Count - 1;

            for (int i = 0; i <= rows; i++)
            {
                dr = matches.Rows[i];
                home = CollapseSpaces(dr["host"].ToString());
                away = CollapseSpaces(dr["visitor"].ToString());
                choice = CollapseSpaces(dr["oddname"].ToString());
                _bet_type = CollapseSpaces(dr["bet_type"].ToString());
                if (_bet_type.ToLowerInvariant() == "straight")
                {
                    switch (choice.ToLower())
                    {
                        case "home":
                            match += home + "+vs+" + away + "+Home(" + CollapseSpaces(dr["oddhome"].ToString()) + "),+";
                            break;
                        case "draw":
                            match += home + "+vs+" + away + "+Draw(" + CollapseSpaces(dr["odddraw"].ToString()) + "),+";

                            break;
                        case "away":
                            match += home + "+vs+" + away + "+Away(" + CollapseSpaces(dr["oddaway"].ToString()) + "),+";
                            break;
                        default:
                            match += "";
                            break;

                    }

                }
                else if (_bet_type.ToLowerInvariant() == "wire")
                {
                    switch (choice.ToLower())
                    {
                        case "under":
                            match += home + "+vs+" + away + "+Under(" + CollapseSpaces(dr["underodd"].ToString()) + "),+";
                            break;
                        case "over":
                            match += home + "+vs+" + away + "+over(" + CollapseSpaces(dr["overodd"].ToString()) + "),+";
                            break;
                    }

                }
                else if (_bet_type.ToLowerInvariant() == "hc")
                {
                    switch (choice.ToLower())
                    {
                        case "home":
                          
                            match += home + "+vs+" + away + "+HandcapHome(" + CollapseSpaces(dr["hchomeodd"].ToString()) + "),+";
                            break;
                        case "draw":
                            match += home + "+vs+" + away + "+Handcapdraw(" + CollapseSpaces(dr["hcdrawodd"].ToString()) + "),+";
                            break;
                        case "away":
                            match += home + "+vs+" + away + "+HandcapAway(" + CollapseSpaces(dr["hcawayodd"].ToString()) + "),+";
                            break;                      
                    }
                 
                }
                if (_bet_type.ToLowerInvariant() == "dc")
                {
                    switch (choice.ToLower())
                    {
                        case "1x":
                            match += home + "+vs+" + away + "+1x(" + CollapseSpaces(dr["dchd"].ToString()) + "),+";
                            break;
                        case "x2":
                            match += home + "+vs+" + away + "+x2(" + CollapseSpaces(dr["dcda"].ToString()) + "),+";
                            break;
                        case "12":
                            match += home + "+vs+" + away + "+12(" + CollapseSpaces(dr["dcha"].ToString()) + "),+";
                            break;


                    }


                }
                if (_bet_type.ToLowerInvariant() == "halftime")
                {
                    switch (choice.ToLower())
                    {
                        case "home":
                            match += home + "+vs+" + away + "+HalfTimeHome(" + CollapseSpaces(dr["hfhome"].ToString()) + "),+";
                            break;
                        case "draw":
                            match += home + "+vs+" + away + "+HalfTimeDraw(" + CollapseSpaces(dr["hfdraw"].ToString()) + "),+";

                            break;
                        case "away":
                            match += home + "+vs+" + away + "+HalfTimeAway(" + CollapseSpaces(dr["hfaway"].ToString()) + "),+";
                            break;
                        default:
                            match += "";
                            break;

                    }

                }

               
            }
            message = match.Trim();

        }
        return message;
    }

    public DataTable displaysetgames(int SetId)
    {
        string message = "", match = "", home, away, choice, odd, win = null, betmoney = null;
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@username", _username);
        param[1] = new SqlParameter("@mode", "recieptgame");
        param[2] = new SqlParameter("@betID", SetId);

        DataTable matches = new DataTable();
        matches = objDBBridge.ExecuteDataset(_spName1, param).Tables[0];
        int x = matches.Rows.Count;
        return matches;
    }
    public DataTable displaysetgamebyid(int SetId)
    {
        string message = "", match = "", home, away, choice, odd, win = null, betmoney = null;
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@username", _username);
        param[1] = new SqlParameter("@mode", "recieptgamebyid");
        param[2] = new SqlParameter("@betID", SetId);
        param[3] = new SqlParameter("@gameid", _gameid);
        DataTable matches = new DataTable();
        matches = objDBBridge.ExecuteDataset(_spName1, param).Tables[0];
        int x = matches.Rows.Count;
        return matches;
    }
    public string CollapseSpaces(string value)
    {
        return Regex.Replace(value, @"\s+", "");
    }
    public string[] splittoArray(String message) { 
     String[] smsarray=message.Split('*');
     if (smsarray == null)
     {
         smsarray = new string[] { message };
     }
     return smsarray;
    }
    public bool GetCustomerClient()
    {
        DataTable dtcustomer = new DataTable();
        bool result = false;
        try
        {
            SqlParameter[] dtm = new SqlParameter[2];
            dtm[0] = new SqlParameter("@PhoneNo", _phoneno);
            dtm[1] = new SqlParameter("@Mode","SearchCustomer");
            dtcustomer = objDBBridge.ExecuteDataset(_spName1, dtm).Tables[0];
            if (dtcustomer.Rows.Count != 0) {
                DataRow drcustomer;
                drcustomer = dtcustomer.Rows[0];
               _username = drcustomer["username"].ToString();
                _phoneno= drcustomer["pnumber"].ToString();
                _position = drcustomer["position"].ToString();
                _balance = Convert.ToDecimal(drcustomer["ammount_e"]);
                result = true;
            }
        }
        catch (Exception ex)
        {
            result = false;
        }
        return result;
    }
    public bool GetCustomerBalance()
    {
        DataTable dtcustomer = new DataTable();
        bool result = false;
        try
        {
            dtcustomer = AccountBalance();
            if (dtcustomer.Rows.Count != 0)
            {
                DataRow drBalance;
                drBalance = dtcustomer.Rows[0];
                _AccBalance = drBalance["ammount_e"].ToString();
                _AcBalance = Convert.ToDouble(drBalance["ammount_e"]);
                result = true;
            }
        }
        catch (Exception ex)
        {
            result = false;
        }
        return result;
    }
    public string getbetid()
    {
        string betno = "0";
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "GetBetNos");

        DataTable dtEmployee = new DataTable();
        dtEmployee = objDBBridge.ExecuteDataset(_spName1, param).Tables[0];
        if (dtEmployee.Rows.Count != 0)
        {
            DataRow drEmployee;
            drEmployee = dtEmployee.Rows[0];
            betno = drEmployee["betid"].ToString();
        }
        return betno;
    }
    public string resetphone(String senderphone)
    {
        senderphone = senderphone.Trim();
        if (senderphone.Substring(0, 3) != "256")
        {
            if (senderphone.StartsWith("0"))
            {
                senderphone = "256" + senderphone.Substring(1);

            }
            else if (senderphone.StartsWith("+256"))
            {
                senderphone =  senderphone.Substring(1);            
            
            }

        }
        return senderphone;

    }
    public string resetphone(String senderphone,string code)
    {
        if (senderphone.Substring(0, 3) != code)
        {
            if (senderphone.StartsWith("0"))
            {
                senderphone = code + senderphone.Substring(1);
            }

        }
        return senderphone;
    }
    public bool validatearray(String [] array) {

        return true;
    }
    public String keyword(string smsmsg)
    {
        string keyword = smsmsg;
        string[] messagearray = smsmsg.Split('*');
        if (messagearray != null)
            keyword = messagearray[0].Trim();
        return keyword;
    }
   
     public bool validateamount(String arrayitem)
    {
        double btamount;
        string s =arrayitem;
        if (double.TryParse(s, out btamount))
        {

            _betmoney = btamount;
            return true;
        }
        else {

            return false;
        }

    }
     public bool validateteamcodes(String [] arrayitem)
     {
         bool correct = false;
         for (int i = 1; i < arrayitem.Length-1; i++)
         {

             correct = clsagent.TestifTeamscodeExist( Convert.ToInt16(arrayitem[i]));
             if (correct == false)
             {
                 return correct;
             }
         }

         return correct;
     }
     public string getwrongcodes(String[] arrayitem)
     {
         string codes = "";
         bool correct = false;
		 int count = 0;
         for (int i = 1; i < arrayitem.Length - 1; i++)
         {

             correct = clsagent.TestifTeamscodeExist(Convert.ToInt16(arrayitem[i]));
             if (correct == false)
             {
                 codes += arrayitem[i]+",";
				 count ++;
             }
         }
		 if(count == 1){
			return "Code "+codes+" was not correct or has already began.";
		 }
		 else{
			return "Codes "+codes+" were not correct or have already began.";
		}
     }
     public bool validateagentteamcodes(String[] arrayitem)
     {
         bool correct = false;
         for (int i = 2; i < arrayitem.Length - 1; i++)
         {

             correct = clsagent.TestifTeamscodeExist(Convert.ToInt16(arrayitem[i]));
             if (correct == false)
             {
                 return correct;
             }
         }

         return correct;
     }

     public int GetNextSetNo()
     {
         int setno = 0;
         try
         {
             
             DataTable dtDepartment = new DataTable();
             dtDepartment = objDBBridge.ExecuteDataset("GetNextSetNo").Tables[0];
             if (dtDepartment.Rows.Count != 0)
             {
                 DataRow drDepartment;
                 drDepartment = dtDepartment.Rows[0];
                 setno = Convert.ToInt16(drDepartment["NxtSetNo"]);

             }
         }
         catch (Exception er) {  }

       return setno;
     }

     public bool insertset()
     {
         bool res = false;
         try
         {
             SqlParameter[] dtm = new SqlParameter[6];
             dtm[0] = new SqlParameter("@username", _username);
             dtm[1] = new SqlParameter("@betmoney", _betmoney);
             dtm[2] = new SqlParameter("@betdate", DateTime.Now);
             dtm[3] = new SqlParameter("@setodd", _setodd);
             dtm[4] = new SqlParameter("@betID", _betID);
             dtm[5] = new SqlParameter("@setsize", _setsize);
             int x=objDBBridge.ExecuteNonQuery("createsets", dtm);
             if (x > 0)
             {
                 res = true;
             }
             else {
                 res = false;
             }
             
         }
         catch (Exception ex)
         {
            res=false;
         }
         return res;
     }
     public int fixmessage() {
         SqlParameter[] par = new SqlParameter[4];
         par[0] = new SqlParameter("@username", _username);
         par[1] = new SqlParameter("@date",_DOJ);
         par[2] = new SqlParameter("@message",_msg);
         par[3] = new SqlParameter("@mode","fixmessage");
         return   objDBBridge.ExecuteNonQuery(_spName2, par);
     }
     public bool getfixmessage() {
         bool msgstate = false;
         SqlParameter[] par = new SqlParameter[1];
         par[0] = new SqlParameter("@mode","getfixmessage");
         DataTable dt = new DataTable(); 
        dt= objDBBridge.ExecuteDataset(_spName2, par).Tables[0];
         DataRow dr;
         if (dt.Rows.Count > 0) {
             dr = dt.Rows[0];
             _msg = dr["message"].ToString();
             msgstate = true;
             return msgstate;
         
         }
         return msgstate;


     
     
     }
     public DataSet getfixmessages()
     {
    
         SqlParameter[] par = new SqlParameter[1];
         par[0] = new SqlParameter("@mode", "getfixmessage");
        return objDBBridge.ExecuteDataset(_spName2, par);

     }
     public DataSet mtnumbers()
     {

         SqlParameter[] par = new SqlParameter[1];
         par[0] = new SqlParameter("@mode", "getphones");
         return objDBBridge.ExecuteDataset(_spmt, par);




     }
     public int countmtnumbers()
     {
         int num = 0;
         SqlParameter[] par = new SqlParameter[1];
         par[0] = new SqlParameter("@mode", "countphones");
         DataTable dt=new DataTable();
         dt = objDBBridge.ExecuteDataset(_spmt, par).Tables[0];
         DataRow dr;
         if (dt.Rows.Count > 0) {
             dr = dt.Rows[0];
             num = Convert.ToInt32(dr["number"]);

         }
         return num;



     }
     public string successmessage(decimal betmoney, int betid, decimal odd, decimal AccBalance, string sender)
     {
         StringBuilder reply = new StringBuilder();
         reply.Append("Possible+");
         reply.Append("win+");
         reply.Append("is+");
         reply.Append("shs.");
         reply.Append(Math.Round((betmoney * odd), 0));
         reply.Append("+for+shs.");
         reply.Append(betmoney.ToString());
         reply.Append("+placed+on+");
         _username = sender;
         reply.Append(displaygames(betid));
         reply.Append("SetNumber+is+");
         reply.Append(betid.ToString().Trim());
         reply.Append(".+Balance+is+sh.");
         reply.Append(Math.Round((AccBalance - betmoney), 0).ToString());
         reply.Append(".+Thanks");
         return reply.ToString();

     }
     public void sendcustomersms(string msg, string Destination_number)
     {
         // Response.Redirect("Testpaypage.aspx?reply=" + msg);
         //https://secure.jolis.net/jc/sms/interface.php?command=sendsinglesms&username=globalbets&password=dewilos&destination=2567782896512&source=Globalbets&message=Whats+up?

         //Response.Redirect("https://secure.jolis.net/jc/sms/interface.php?command=sendsinglesms&username=globalbets&password=dewilos&destination="+Destination_number+"&source=Globalbets&message="+msg);
         
                 HttpWebRequest RequesttosendSms = (HttpWebRequest)WebRequest.Create("https://secure.jolis.net/jc/sms/interface.php?command=sendsinglesms&username=globalbets&password=dewilos&destination=" + Destination_number + "&source=Globalbets&message=" + msg);
                 RequesttosendSms.Headers.Add("username", "globalbets");
                 RequesttosendSms.Headers.Add("password", "dewilos");
                 RequesttosendSms.Headers.Add("Destination", Destination_number);
                 RequesttosendSms.Headers.Add("source", "globalbets");
                 RequesttosendSms.Headers.Add("content_type", "1");
                 RequesttosendSms.Headers.Add("msg", msg);
                 HttpWebResponse ResponsetosendSms = (HttpWebResponse)RequesttosendSms.GetResponse();
                 //string result = (string)ResponsetosendSms.GetResponseHeader("DLRID");
        
     }
        #endregion
}
