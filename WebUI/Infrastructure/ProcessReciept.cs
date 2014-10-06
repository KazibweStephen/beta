using System;
using System.Data;
using System.Data.SqlClient;
using SRN.DAL;
using System.Net;
using System.Text;
/// <summary>
/// Summary description for ProcessReciept
/// </summary>
public class ProcessReciept
{
    public ProcessReciept()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region Variables
    DBBridge objDBBridge = new DBBridge();
    AdminClass admin = new AdminClass();
    Login users = new Login();
    Agentclass agent = new Agentclass();
    protected int _transid;
    protected DateTime _betdate;

    protected string _account = string.Empty;
    protected double _handhome;
    protected double _handaway;
    protected string _phone_no = String.Empty;
    protected string _transactions = String.Empty;
    protected string _league = String.Empty;
    protected string _matcode = String.Empty;
    protected string _visitor = String.Empty;
    protected string _away = String.Empty;
    protected string _matchno = String.Empty;
    protected string _oddname = String.Empty;
    protected string _username = String.Empty;
    protected DateTime _stime;
    protected string _category = String.Empty;
    protected string _host = String.Empty;
    protected string _serial = String.Empty;
    protected string _home = String.Empty;
    protected string _champ = String.Empty;
    protected string _AgentIds = String.Empty;
    protected string _RecieptID = String.Empty;
    protected string _method = String.Empty;
    protected string _customerID = String.Empty;
    protected string _security = String.Empty;
    protected string _securitycode = String.Empty;
    protected string _bettype = String.Empty;
    protected string _result = String.Empty;
    protected int _setsize;
    protected int _matno;
    protected int _status;
    protected DateTime _DOT;
    protected decimal _odd;
    protected double _totalodd;
    protected decimal _betmoney;


    const string _spName = "NewRegModel";
    const string _spName1 = "Sp_Admin";
    const string _spName2 = "NewSp";
    #endregion
    #region Class Property

    public string Securitycode
    {
        set { _securitycode = value; }
        get { return _securitycode; }

    }
    public String Result
    {
        get { return _result; }
        set { _result = value; }

    }
    public int status
    {
        get { return _status; }
        set { _status = value; }
    }
    public int setsize
    {
        get { return _setsize; }
        set { _setsize = value; }
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

    public string host
    {
        get { return _host; }
        set { _host = value; }
    }
    public string RecieptId
    {
        get { return _RecieptID; }
        set { _RecieptID = value; }
    }
    public string AgentIds
    {
        get { return _AgentIds; }
        set { _AgentIds = value; }
    }

    public int trans_id
    {
        set { _transid = value; }
        get { return _transid; }

    }
    public string method
    {
        get { return _method; }
        set { _method = value; }
    }


    public string category
    {
        get { return _category; }
        set { _category = value; }
    }
    public string champ
    {
        get { return _champ; }
        set { _champ = value; }
    }
    public string username
    {
        get { return _username; }
        set { _username = value; }
    }
    public decimal odd
    {
        get { return _odd; }
        set { _odd = value; }
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
        set { _serial = value; }
    }
    public decimal betmoney
    {
        get { return _betmoney; }
        set { _betmoney = value; }
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
        get { return _bettype; }
        set { _bettype = value; }
    }
    public string matchno
    {
        get { return _matchno; }
        set { _matchno = value; }
    }


    public DateTime DOT
    {
        get { return _DOT; }
        set { _DOT = value; }
    }

    public DateTime StarrtTime
    {
        get { return _stime; }
        set { _stime = value; }
    }
    #endregion
    #region Class Methods

    public int extractbet(decimal stake, decimal oddsum, string matchinfo, string skyteller, string recieptnumber, string phone)
    {
        int ret = 0;
        if (agent.checkcustomerphone(phone))
        {
            string customerusername = insertuser(phone);
        }
        if (!string.IsNullOrEmpty(recieptnumber))
        {
            users.Username = skyteller;
            users.getuser_info();
            if (users.balance >= stake)
            {
                //phone = users.resetphone(phone);
                //ret = admin.getbetid();
                admin.Username = skyteller;
                _username = skyteller;
                _phone_no = phone;
                _customerID = users.getuser_info(phone, Login.USERNAME);
                //  int betid = admin.getbetid();
                admin.RecieptId = recieptnumber;
                _RecieptID = recieptnumber;

      
                _RecieptID = recieptnumber;
                ret = admin.getbetid();
                int games = 0;

                _setsize = setsize;
                _betmoney = stake;
                int count = 0;
                string[] matchdata = splittoArray(matchinfo.Trim());
                if (matchdata.Length > 0)
                {
                    for (int i = 0; i < matchdata.Length; i++)
                    {
                        string mtcinfo = matchdata[i];
                        string[] playerchoice = SplitGameData(matchdata[i]);

                        if (playerchoice.Length == 3)
                        {

                            _matchno = playerchoice[0].Trim();
                            _bettype = playerchoice[1].Trim();
                            _oddname = playerchoice[2].Trim();

                            if ((!string.IsNullOrEmpty(_matchno)) && (!string.IsNullOrEmpty(_bettype)) && (!string.IsNullOrEmpty(_oddname)))
                            {

                                InsertPlayerBet();
                                count++;
                            }
                            else
                            {
                                return 0;

                            }
                        }
                    }
                    if (count > 0)
                    {
                        _setsize = count;
                        _status = 1;
                        _odd = oddsum;
                        count = updateSetDetails();
                        _AgentIds = skyteller;
                        if (count > 0)
                        {
                            if (UpdateagentonlineAccounts())
                            {
                                //successfull bet, send customer message.
                                //decimal win = Math.Round((stake * oddsum), 0);
                                //string msg = "You successfully betted through Agent: "+skyteller+". Your Receipt No. is "+recieptnumber+". Expected win is UGX "+win+". Thanks! www.trustbets.ug";
                                // string customermessage = customersuccessmessage(stake, Convert.ToInt32(recieptnumber), oddsum, recieptnumber);
                                //PhoneCustomer.SendVasMessage(customermessage, phone);
                                count = 100;/*
                                    if (checkint())
                                    {
                                        string customermessage = customersuccessmessage(stake, Convert.ToInt32(recieptnumber), oddsum, recieptnumber);
                                        sendcustomersms(customermessage, users.resetphone(users.resetphone(phone)));
                                    }
                                    return count;
                                                 * */
                            }
                        }

                    }
                }

                return count;

            }
            else
            {

                return -1;


            }
        }

        return ret;
    }
    public string[] splittoArray(String message)
    {
        String[] smsarray = message.Split(',');
        return smsarray;
    }
    public string[] SplitGameData(String message)
    {
        String[] smsarray = message.Split('*');
        return smsarray;
    }

    public int InsertPlayerBet()
    {
        SqlParameter[] param = new SqlParameter[10];
        param[0] = new SqlParameter("@Mode", "insertbet");
        param[1] = new SqlParameter("@betdate", DateTime.Now);
        param[2] = new SqlParameter("@betmoney", _betmoney);
        param[3] = new SqlParameter("@bet_type", _bettype);
        param[5] = new SqlParameter("@MatchNo", _matchno);
        param[6] = new SqlParameter("@oddname", _oddname);
        param[7] = new SqlParameter("@betid", _RecieptID.Trim());
        param[8] = new SqlParameter("@username", _username);
        param[9] = new SqlParameter("@setno", _matchno);
        return objDBBridge.ExecuteNonQuery(_spName, param);
    }
    /*
    public int InsertPlayerBet()
    {
        SqlParameter[] param = new SqlParameter[10];
        param[0] = new SqlParameter("@Mode", "insertbet");
        param[1] = new SqlParameter("@username", _username);
        param[2] = new SqlParameter("@betdate", _betdate);
        param[3] = new SqlParameter("@betmoney", _betmoney);
        param[4] = new SqlParameter("@bet_type", _bet_type);
        param[5] = new SqlParameter("@setno", _setno);
        param[6] = new SqlParameter("@MatchNo", _matchno);
        param[7] = new SqlParameter("@oddname", _oddname);
        param[8] = new SqlParameter("@betid", _betid);
        param[9] = new SqlParameter("@category", _category);
        return objDBBridge.ExecuteNonQuery(_spName, param);
    }
     * */
    public int updateSetDetails()
    {
        SqlParameter[] param = new SqlParameter[8];
        param[0] = new SqlParameter("@Mode", "updateSetDetails");
        param[1] = new SqlParameter("@betdate", DateTime.Now);
        param[2] = new SqlParameter("@betmoney", _betmoney);
        param[3] = new SqlParameter("@setsize", _setsize);
        param[4] = new SqlParameter("@setodd", _odd);
        param[5] = new SqlParameter("@betid", _RecieptID.Trim());
        param[6] = new SqlParameter("@status", _status);
        param[7] = new SqlParameter("@username", _username);
        return objDBBridge.ExecuteNonQuery(_spName, param);
    }

    public bool UpdateagentonlineAccounts()
    {
        DataTable dtmatches = new DataTable();
        bool res = false;
        try
        {
            SqlParameter[] dtm = new SqlParameter[5];
            dtm[0] = new SqlParameter("@username", _AgentIds);
            dtm[1] = new SqlParameter("@bettor", username);
            dtm[2] = new SqlParameter("@amount", _betmoney);
            dtm[3] = new SqlParameter("@betid", _RecieptID);
            dtm[4] = new SqlParameter("@customerID", _customerID);

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
    #endregion
    public string insertuser(string customerphone)
    {
        string customerusername = "";
        string customernumber = customerphone;
        customernumber = users.resetphone(customernumber);
        users.Phoneno = customernumber;
        users.InsertPhoneBetter();
        if (users.getCustomerDetails())
        {
            customerusername = users.Username;
        }
        return customerusername;

    }
    public string customersuccessmessage(decimal betmoney, int betid, decimal odd, string agentname)
    {
        StringBuilder clientreply = new StringBuilder();
        clientreply.Append("Expected+win+is+");
        clientreply.Append(Math.Round((betmoney * odd), 0).ToString());
        clientreply.Append("+Shs+for+BET+of+");
        clientreply.Append(betmoney.ToString());
        users.Username = agentname;
        users.betId = betid;
        clientreply.Append("+Shs");
        clientreply.Append(users.displaygames(betid));
        clientreply.Append("+Set+Number+is+");
        clientreply.Append(betid.ToString().Trim());
        clientreply.Append(".+www.trustbets.ug");
        return clientreply.ToString();
    }
    public bool checkint()
    {

        WebClient client = new WebClient();
        byte[] datasize = null;
        try
        {
            datasize = client.DownloadData("http://www.google.com");
        }
        catch (Exception ex)
        {
        }
        if (datasize != null && datasize.Length > 0)
            return true;
        else
            return false;

    }
    public void sendcustomersms(string msg, string Destination_number)
    {
        //HttpWebRequest RequesttosendSms = (HttpWebRequest)WebRequest.Create("https://secure.jolis.net/jc/sms/interface.php?command=sendsinglesms&username=globalbets&password=dewilos&destination=" + Destination_number + "&source=Globalbets&message=" + msg);
        //RequesttosendSms.Headers.Add("username", "globalbets");
        //RequesttosendSms.Headers.Add("password", "dewilos");
        //RequesttosendSms.Headers.Add("Destination", Destination_number);
        //RequesttosendSms.Headers.Add("source", "globalbets");
        //RequesttosendSms.Headers.Add("content_type", "1");
        //RequesttosendSms.Headers.Add("msg", msg);
        //HttpWebResponse ResponsetosendSms = (HttpWebResponse)RequesttosendSms.GetResponse();
        //string result = (string)ResponsetosendSms.GetResponseHeader("DLRID");
    }

}
