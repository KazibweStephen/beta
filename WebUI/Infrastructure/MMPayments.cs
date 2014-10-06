using System;
using System.Data;
using System.Data.SqlClient;
using SRN.DAL;
using System.Text;
using System.Net;

/// <summary>
/// Summary description for MMPayments
/// </summary>
public class MMPayments
{
    public MMPayments()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    #region variables
    Login users = new Login();
    DBBridge mybridge = new DBBridge();
    DBBridge objDBBridge = new DBBridge();
    public string setno = string.Empty;
    public string _Phoneno = string.Empty;
    public string _league = string.Empty;
    public string _mode = string.Empty;
    public string _username = string.Empty;
    public DateTime _stime = new DateTime();
    public string _transaction = string.Empty;
    public string _method = string.Empty;
    public string _serial = string.Empty;
    public string _controller = string.Empty;
    public double _balbefore = 0;
    public double _amount = 0;
    public string _message_id = string.Empty;
    public string _spname = "pay_epay";
    public string _spname1 = "NewRegModel";
    #endregion variables
    #region publicacessors
    public string username
    {
        set { _username = value; }
        get { return _username; }

    }
    public string messageid
    {
        set { _message_id = value; }
        get { return _message_id; }

    }
    public string phoneno
    {
        set { _Phoneno = value; }
        get { return _Phoneno; }

    }
    public string controller
    {
        set { _controller = value; }
        get { return _controller; }

    }
    public double amount
    {
        set { _amount = value; }
        get { return _amount; }

    }
    #endregion public accessors
    #region publicmethods
    public bool updatepayments()
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@phoneno", _Phoneno);
        param[1] = new SqlParameter("@messageid", _message_id);
        param[2] = new SqlParameter("@amount", _amount);
        param[3] = new SqlParameter("@username", _username);
        param[4] = new SqlParameter("@controller", _controller);
        int test = mybridge.ExecuteNonQuery(_spname, param);
        if (test <= 0)
        {
            test = mybridge.ExecuteNonQuery("pendingmoney", param);
            return false;
        }
        else if (test > 0)
        {
            return true;
        }

        else { return false; }

    }

    /*
         * No multiple payments when same transaction is re-sent by UGMART API
         * @return true if transaction ID was logged before.
         */
    private bool CheckMMPayment(string messageID)
    {
        bool check = false;
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "checkMMPayment");
        param[1] = new SqlParameter("@MessageID", messageID);
        DataTable data = new DataTable();
        data = objDBBridge.ExecuteDataset(_spname1, param).Tables[0];
        if (data.Rows.Count > 0)
        {
            check = true;
        }
        return check;
    }

    public string sendpayment(String apiusername, String apipassword, String amount, String sender, String reason, string msgid)
    {
        string result = null, message = "No message";
        users.Phoneno = sender;
        if ((reason.ToLower() == "global")||(reason.ToLower() == "smsbet"))
        {
            users.source = "UGMART_API";
        }
        else
        {
            return "INVALID PAYMENT";
        }
        if (CheckMMPayment(msgid))
        {
            return msgid + " transaction ID already logged.";
        }
        users.msgid = msgid;
        users.Message = amount;
        if ((reason.ToLower() == "global")||(reason.ToLower() == "smsbet"))
        {
            users.reason = reason = sender;
        }
        else { users.reason = sender; }
        users.recievedmmsms();



        try
        {
            if ((apiusername == "globalbets") && (apipassword == "dewilos"))
            {
               
                if (reason.Substring(0, 3) != "256")
                {
                    if (reason.StartsWith("0"))
                    {
                        reason = "256" + reason.Substring(1);

                    }
                }
                if (sender.Substring(0, 3) != "256")
                {
                    if (sender.StartsWith("0"))
                    {
                        sender = "256" + sender.Substring(1);

                    }
                }

                users.Phoneno = sender;
                users.msgid = msgid;
                users.Message = amount;
                if ((reason.ToLower() == "global")||(reason.ToLower() == "smsbet"))
                {
                    users.reason = reason = sender;
                    users.source = "UGMART_API";
                }
                else { users.reason = sender; }

                _amount = Convert.ToDouble(amount);
                _Phoneno = sender;
                _message_id = msgid;
                _username = sender;
                _controller = users.source;
                users.Phoneno = _Phoneno;

                try
                {
                    SqlParameter[] param = new SqlParameter[2];
                    param[0] = new SqlParameter("@Mode", "getusernamedeposit");
                    param[1] = new SqlParameter("@userphonenumber", sender);
                    DataTable dtDepartment = new DataTable();
                    dtDepartment = objDBBridge.ExecuteDataset("Sp_Admin", param).Tables[0];
                    if (dtDepartment.Rows.Count != 0)
                    {
                        DataRow drDepartment;
                        drDepartment = dtDepartment.Rows[0];
                        _username = drDepartment["username"].ToString();
                    }
                }
                catch (Exception eee) { }

                if (updatepayments())
                {
                    if (users.getpendingset())
                    {
                        message = "";
                        message = successmessage(Convert.ToDecimal(users.betmoney), users.betId, Convert.ToDecimal(users.setodd), Convert.ToDecimal(amount), sender);
                        sendcustomersms(message, sender);
                        users.Message = message;
                        users.mmresponsesms();
                        return message;

                    }
                    else
                    {
                        users.getfixmessage();
                        {
                            users.Username = sender;
                            users.getuser_info();
                        }
                        message = "Your+Globalbets+betting+account+has+been+topped+up+with+UGX+" + amount + ".+Your+betting+account+balance+is+UGX"+(users.balance+amount)+".+Start+betting+now.+www.smsbet.ug";
                        sendcustomersms(message, sender);
                        users.Message = message;
                        users.mmresponsesms();
                        return message;

                    }


                }
                else
                { // register new user
                    SqlParameter[] param = new SqlParameter[6];
                    param[0] = new SqlParameter("@username", _username);
                    param[1] = new SqlParameter("@amount", Convert.ToDecimal(amount));
                    param[2] = new SqlParameter("@messageid", messageid);
                    param[3] = new SqlParameter("@controller", "UGMART_API");
                    param[4] = new SqlParameter("@transaction", "Deposited money through Mobile money");
                    param[5] = new SqlParameter("@phone", sender);
                    int check = objDBBridge.ExecuteNonQuery("updateaccount", param);
                    if (check > 0)
                    {
                        {
                            users.Username = sender;
                            users.getuser_info();
                        }
                        string msg = "Thanks for joining SMS Bet. Bet using your phone and get results on phone. Visit www.smsbet.ug for more details.";
                        message = "Your+Globalbets+betting+account+has+been+topped+up+with+UGX+" + amount + ".+Your+betting+account+balance+is+UGX" + (users.balance+amount) + ".+Start+betting+now.+www.smsbet.ug";
                        sendcustomersms(msg, sender);
                        sendcustomersms(message, sender);
                        users.Message = msg;
                        users.responsesms();
                        users.Message = message;
                        users.responsesms();
                    }
                    else {
                        string msg = "Something went wrong! Your account has not been credited. Please try again. Call 0793993375 for help or Visit www.smsbet.ug for more details.";
                        sendcustomersms(msg, sender);
                        users.Message = msg;
                        users.responsesms();
                    }
                    return message;


                }


            }
            else
            {
                result = "Your account has not been credited. Please try again. Visit www.smsbet.ug for more details.";
            }
        }
        catch (Exception ex)
        {
            string error = ex.Message;
            result = "Your account has not been credited. Please try again shortly. Visit www.smsbet.ug for more details.";
        }
        return result;
    }
    public string Collapseplus(string invalue)
    {
        return invalue.Replace(" ", "+");
    }
    public void sendcustomersms(string msg, string Destination_number)
    {
        try
        {
            HttpWebRequest RequesttosendSms = (HttpWebRequest)WebRequest.Create("http://sms.vasgarage.ug/api/sendsms/?msg=" + msg + "&phone=" + Destination_number);
            RequesttosendSms.Headers.Add("Destination", Destination_number);
            RequesttosendSms.Headers.Add("msg", msg);
            HttpWebResponse ResponsetosendSms = (HttpWebResponse)RequesttosendSms.GetResponse();
        }catch(Exception e){}
    }
    public string successmessage(decimal betmoney, int betid, decimal odd, decimal AccBalance, string sender)
    {
        StringBuilder reply = new StringBuilder();
        reply.Append("Bet activated.+Possible+");
        reply.Append("win+");
        reply.Append("is+");
        reply.Append("UGX");
        reply.Append(Math.Round((betmoney * odd), 0));
        reply.Append("+for+UGX");
        reply.Append(betmoney.ToString());
        reply.Append("+placed+on+");
        users.Username = sender;
        reply.Append(users.displaygames(betid));
        reply.Append("SetNumber+is+");
        reply.Append(betid.ToString().Trim());
        reply.Append(".+Balance+is+UGX");
        reply.Append(Math.Round((AccBalance - betmoney), 0).ToString());
        reply.Append(".+Thanks");
        return reply.ToString();

    }

    #endregion publicmethods

}
