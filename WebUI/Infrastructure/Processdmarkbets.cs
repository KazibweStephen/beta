using System;
using System.Data;
using System.Net;
using System.Text;
using System.IO;
/// <summary>
/// Summary description for Processdmarkbets
/// </summary>
public class Processdmarkbets
{
	public Processdmarkbets()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region Variables

    AdminClass admin = new AdminClass();
    Login users = new Login();
    PhoneCustomer bt = new PhoneCustomer();
    Agentclass agent = new Agentclass();
    DataTable BetCustomer = new DataTable();
    DataTable CustomerBAL = new DataTable();
    DataTable _dt_Team = new DataTable();
    DataTable dt_matchcat = new DataTable();
    string _res = null;
    string _agentcustomer = null;
    string _agentmsg = null;
    string _apiusername1 = null;
    string _apipassword1 = null;
    string _Keyword = null;
    string _MatchCode = null;
    string _amount = null;
    string _result = null;
    string _Category = null;
    string _hldCategory = null;
    string _senderphone = null;
    string customernumber = null;
    string customerusername = null;
    string _sentmsg = null;
    string _position = null;
    string Test = null;
    string[] Arraymsg = new string[0];
    string _lowerKeyword = null;
    string _getsetno = null;
    string _nxtsetno = null;
    #endregion


    #region Public Methods
    public void gggg()
    {

    }
    public String[] messageArray()
    {

        return Arraymsg = _sentmsg.Split('*');
    }
    public String processmessage(string apiusername1, string apipassword1, String recmsg, string msgid, string senderno)
    {
        string res = "";
        try
        {
            if ((apiusername1 == "globalbets") && (apipassword1 == "dewilos"))
            {
                users.Message = recmsg;
                users.MessageId = msgid;
                users.Phoneno = senderno;
                users.source = "Jolis";
                if (users.recievedsms())
                {
                    string phoneno = users.resetphone(senderno);
                    users.Phoneno = phoneno;
                    if (users.GetCustomerClient())
                    {
                        string keyword = users.keyword(recmsg).ToLowerInvariant();
                        if (keyword == "bet")
                        {
                            decimal balance = users.balance;
                            string username = users.Username;
                            string position = users.position;
                            Arraymsg = users.splittoArray(recmsg);
                            int Arraylength = Arraymsg.Length;
                            if (Arraylength > 2)
                            {
                                if (users.validateamount(Arraymsg[Arraylength - 1]))
                                {
                                    if (balance > Convert.ToDecimal(users.betmoney))
                                    {
                                        if (users.validateteamcodes(Arraymsg))
                                        {
                                            bt.betmoney = Convert.ToDecimal((Arraymsg[Arraylength - 1]));
                                            bt.Username = username;
                                            admin.Username = username;
                                            bt.BetId = admin.getbetid();
                                          
                                            if (bt.insertbet(Arraymsg))
                                            {
                                                bt.odd = Convert.ToDecimal(bt.totalodd);
                                                bt.setsize = Arraylength - 2;
                                                bt.status = 1;
                                                int ent = bt.updateSetDetails();
                                                if (ent > 0)
                                                {
                                                    bt.method = "SMS betting";
                                                    ent = bt.UpdateBetAccount();
                                                    if (ent > 0)
                                                    {
                                                        res = successmessage(bt.betmoney, bt.BetId, bt.odd, balance);
                                                        sendcustomersmss(res, phoneno);
                                                        users.Message = res;
                                                        users.responsesms();
                                                        return res;
                                                    }
                                                    else
                                                    {
                                                        res = "bet+unsuccessfull";
                                                        sendcustomersmss(res, phoneno);
                                                        users.Message = res;
                                                        users.responsesms();
                                                        return res;

                                                    }
                                                }
                                                else
                                                {

                                                    res = "bet+unsuccessfull";
                                                    sendcustomersmss(res, phoneno);
                                                    users.Message = res;
                                                    users.responsesms();
                                                    return res;
                                                }
                                            }

                                            else
                                            {
                                                res = "bet+unsuccessfull";
                                                sendcustomersmss(res, senderno);
                                                users.Message = res;
                                                users.responsesms();
                                                return res;
                                            }

                                        }
                                        else
                                        {
                                            res = "Bet+unsuccessfull.+Some+of+the+codes+are+not+correct.+Please+resend+with+the+correct+codes+and+make+sure+that+Match+start+TIME+has+not+expired.Thanks";
                                            sendcustomersmss(res, phoneno);
                                            users.Message = res;
                                            users.responsesms();
                                            return res;
                                        }

                                    }
                                    else
                                    {
                                        if (users.validateteamcodes(Arraymsg))
                                        {
                                            bt.betmoney = Convert.ToDecimal((Arraymsg[Arraylength - 1]));
                                            admin.Username = phoneno;
                                            bt.BetId = admin.getbetid();
                                            bt.Username = username;
                                            if (bt.insertbet(Arraymsg))
                                            {
                                                bt.odd = Convert.ToDecimal(bt.totalodd);
                                                bt.setsize = Arraylength - 2;
                                                bt.status = 0;
                                                int ent = bt.updateSetDetails();
                                                if (ent > 0)
                                                {
                                                    res = "bet successfull";
                                                    res = storedsuccessmessage(bt.betmoney, bt.BetId, bt.odd,bt.Username);
                                                     sendcustomersmss(res, senderno);
                                                    users.Message = res;
                                                    users.responsesms();
                                                    return res;

                                                }
                                                else
                                                {

                                                    res = "bet+unsuccessfull";
                                                    sendcustomersmss(res, senderno);
                                                    users.Message = res;
                                                    users.responsesms();
                                                    return res;
                                                }
                                            }

                                            else
                                            {
                                                res = "bet+unsuccessfull";
                                                sendcustomersmss(res, senderno);
                                                users.Message = res;
                                                users.responsesms();
                                                return res;
                                            }

                                        }
                                        else
                                        {
                                            res = users.getwrongcodes(Arraymsg);
                                            res = "Bet+unsuccessfull.+Some+of+the+codes+are+not+correct.+Please+resend+with+the+correct+codes+and+make+sure+that+Match+start+TIME+has+not+expired.Thanks";
                                            sendcustomersmss(res, phoneno);
                                            users.Message = res;
                                            users.responsesms();
                                            return res;
                                        }
                                    }
                                }
                                else
                                {
                                    res = "The+bet+Amount+is+not+correct.Write BET*Selected Team SMS Number*The amount you want to bet.send to 0788162551";
                                    sendcustomersmss(res, phoneno);
                                    users.Message = res;
                                    users.responsesms();
                                    return res;
                                }

                            }
                            else
                            {
                                if (users.getfixmessage())
                                {

                                    res = users.Message;
                                    //res = res.Replace("6070", "0788162551");
                                }
                                else
                                {
                                    res = "To bet write BET*Selected Team SMS Number*The amount you want to bet.send to 6070";
                                }
                                // sendcustomersmss(res, phoneno);
                                res = Collapseplus(res);
                                sendcustomersmss(res, phoneno);
                                users.Message = res;
                                users.responsesms();
                                return res;

                            }
                        }
                        else if (keyword =="agent")
                        {
                            decimal agentbalance = users.balance;
                            string agentusername = users.Username;
                            string position = users.position;
                            Arraymsg = users.splittoArray(recmsg);
                            int Arraylength = Arraymsg.Length;
                            if (position == "Agent Admin")
                            {
                                if (agent.checkcustomerphone(Arraymsg[1]))
                                {
                                    customernumber = Arraymsg[1].Trim();
                                    customernumber = users.resetphone(customernumber);
                                    users.Phoneno = customernumber;
                                    users.InsertPhoneBetter();
                                    if (users.getCustomerDetails())
                                    {
                                        customerusername = users.Username;
                                        if (Arraylength > 3)
                                        {
                                            if (users.validateamount(Arraymsg[Arraylength - 1]))
                                            {
                                                if ((Convert.ToDecimal((Arraymsg[Arraylength - 1])) >= 1000) && (Convert.ToDecimal((Arraymsg[Arraylength - 1])) <= 50000))
                                                {
                                                    if (agentbalance > Convert.ToDecimal(users.betmoney))
                                                    {
                                                        if (users.validateagentteamcodes(Arraymsg))
                                                        {
                                                            bt.betmoney = Convert.ToDecimal((Arraymsg[Arraylength - 1]));
                                                            admin.Username = users.Username;
                                                            bt.BetId = admin.getbetid();
                                                            bt.Username = customerusername;
                                                            if (bt.insertagentbet(Arraymsg))
                                                            {

                                                                bt.odd = Convert.ToDecimal(bt.totalodd);
                                                                bt.setsize = Arraylength - 3;
                                                                bt.status = 1;
                                                                int ent = bt.updateSetDetails();
                                                                if (ent > 0)
                                                                {
                                                                    agent.betid = bt.BetId;
                                                                    agent.betted = users.betmoney;
                                                                    users.Username = customerusername;
                                                                    agent.agentphone = phoneno;
                                                                    agent.username = agentusername;
                                                                    agent.bettor = customerusername;

                                                                    if (agent.UpdateagentsmsAccounts())
                                                                    {
                                                                        res = "bet successfull";
                                                                        string customermessage = customersuccessmessage(Convert.ToDecimal(users.betmoney), bt.BetId, bt.odd, agent.agentphone);
                                                                        sendcustomersms(customermessage, customernumber);
                                                                        users.Message = res;
                                                                        users.responsesms();
                                                                        System.Threading.Thread.Sleep(50);
                                                                        string agentmessage = agentsuccessmsg(Convert.ToDecimal(users.betmoney), bt.BetId, agentbalance, bt.setsize, customerusername, bt.odd);
                                                                        sendcustomersmss(agentmessage, senderno);

                                                                        return res;
                                                                    }
                                                                    else
                                                                    {

                                                                        res = "bet+un+successfull";
                                                                        sendcustomersmss(res, senderno);
                                                                        users.Message = res;
                                                                        users.responsesms();
                                                                        return res;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    res = "bet+unsuccessfull";
                                                                    sendcustomersmss(res, senderno);
                                                                    users.Message = res;
                                                                    users.responsesms();
                                                                    return res;
                                                                }
                                                            }

                                                            else
                                                            {
                                                                res = "bet+unsuccessfull";
                                                                sendcustomersmss(res, senderno);
                                                                users.Message = res;
                                                                users.responsesms();
                                                                return res;
                                                            }

                                                        }
                                                        else
                                                        {
                                                            res = "Bet+unsuccessfull.+Some+of+the+codes+are+not+correct.+Please+resend+with+the+correct+codes+and+make+sure+that+Match+start+TIME+has+not+expired.Thanks";
                                                            sendcustomersmss(res, senderno);
                                                            users.Message = res;
                                                            users.responsesms();
                                                            return res;
                                                        }

                                                    }
                                                    else
                                                    {
                                                        res = "Your+BETTING+account+balance+is+low.+Send+MOBILE+money+to+0788162551.+Under+REASON+write+your+PHONE+NUMBER";
                                                        sendcustomersmss(res, senderno);
                                                        users.Message = res;
                                                        users.responsesms();
                                                        return res;
                                                    }
                                                }
                                                else
                                                {
                                                    if (Convert.ToDecimal((Arraymsg[Arraylength - 1])) < 1000)
                                                    {
                                                        res = "You+have+betted+with+less+money.+Minimum+bet+amount+is+1000.+Please+bet+again.Thanks";
                                                        sendcustomersmss(res, senderno);
                                                        users.Message = res;
                                                        users.responsesms();
                                                        return res;
                                                    }
                                                    else
                                                    {
                                                        res = "Your+bet+amount+is+above+our+maximum+limit.+Maximum+bet+amount+is+sh+50000.+Please+bet+again.Thanks";
                                                        sendcustomersmss(res, senderno);
                                                        users.Message = res;
                                                        users.responsesms();
                                                        return res;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                res = "The+bet+amount+is+not+correct.To+bet+for+a+customer+write+agent*+the+customer+Phone+Number*the+Teamnumber*amount+you+want+to+BET";
                                                sendcustomersmss(res, senderno);
                                                users.Message = res;
                                                users.responsesms();
                                                return res;
                                            }

                                        }
                                        else
                                        {
                                            res = "Minimum+setsize+is+1+games.+Please+bet+again.Thanks";
                                            sendcustomersmss(res, senderno);
                                            users.Message = res;
                                            users.responsesms();
                                            return res;
                                        }
                                    }
                                    else
                                    {
                                        res = "This+number+is+not+Registered+as+Agent+Number.+call+0789997800+for+help";
                                        sendcustomersmss(res, senderno);
                                        users.Message = res;
                                        users.responsesms();
                                        return res;
                                    }
                                }
                                else
                                {
                                    res = "To+bet+for+a+customer,+write+agent*+the+customer+Phone+Number*the+Teamnumber*Bet+Amount.+And+send+to+0788162551.+U+can+bet+on+upto+12+different+games.+call+0789997800+for+help";
                                    sendcustomersmss(res, senderno);
                                    users.Message = res;
                                    users.responsesms();
                                    return res;

                                }

                            }

                            else
                            {
                                res = "This+number+is+not+Registered+as+Agent+Number.+call+0789997800+for+help";
                                sendcustomersmss(res, senderno);
                                users.Message = res;
                                users.responsesms();
                                return res;
                            }

                        }
                        else if (keyword == "topup")
                        {
                            decimal agentbalance = users.balance;
                            string agentusername = users.Username;
                            string position = users.position;
                            double topupamount = 0;
                            agent.Phone = senderno;
                            Arraymsg = users.splittoArray(recmsg);
                            int Arraylength = Arraymsg.Length;
                            if (position == "Agent Admin")
                            {
                                if (Arraymsg.Length > 2)
                                {
                                    if (agent.checkcustomerphone(Arraymsg[1]))
                                    {
                                        customernumber = Arraymsg[1].Trim();
                                        customernumber = users.resetphone(customernumber);
                                        bool validamount = double.TryParse(Arraymsg[2], out topupamount);
                                        if (validamount)
                                        {
                                            if (topupamount >= 1000)
                                            {
                                                agent.agentusername = agentusername;
                                                agent.username = agentusername;
                                                agent.customerphoneno = customernumber;
                                                agentbalance = users.balance;
                                                agent.amount = topupamount;
                                                double balafter = Convert.ToDouble(agentbalance) - topupamount;
                                                int x = 0;
                                                if (Convert.ToDouble(agentbalance) > topupamount)
                                                {
                                                    try
                                                    {
                                                        x = agent.Topupcustomer();
                                                    }
                                                    catch (Exception err) { res = err.Message; }
                                                    if (x > 0)
                                                    {
                                                        string customermsg = "Your+betting+account+has+been+credited+with+shs.+" + topupamount.ToString() + ".+bet+on+today's+games";
                                                        sendcustomersmss(customermsg, customernumber); users.Message = res;
                                                        users.Message = customermsg;
                                                        users.responsesms();
                                                        System.Threading.Thread.Sleep(2000);
                                                        string agtmsg = res = "You+have+sent+sh+" + topupamount.ToString() + "+to+" + Arraymsg[1] + "+Your+balance+is+shs." + balafter.ToString() + ".+Thanks";
                                                        sendcustomersmss(agtmsg, senderno);

                                                        return res;
                                                    }
                                                    else
                                                    {

                                                        res = "Money+was+not+Sent.+Please+call+0789997800+for+help";
                                                        sendcustomersmss(res, senderno);
                                                        users.Message = res;
                                                        users.responsesms();

                                                        return res;
                                                    }

                                                }
                                                else
                                                {
                                                    res = "You+have+low+balance+on+your+account.+Send+MOBILE+money+to+0788162551.+Under+REASON+write+your+USERNAME";
                                                    sendcustomersmss(res, senderno);
                                                    users.Message = res;
                                                    users.responsesms();
                                                    return res;
                                                }
                                            }
                                            else
                                            {

                                                res = "The+minimum+topup+amount+is+shs.1000.Please+resend+the+topup+with+the+correct+amount";
                                                sendcustomersmss(res, senderno);
                                                users.Message = res;
                                                users.responsesms();
                                                return res;
                                            }
                                        }
                                        else
                                        {
                                            res = "Amount+is+not+in+a+correct+format.To+topup,+write+topup*+the+bettor's+Phone+Number*amount+you+want+to+topup.+And+send+to+0788162551";
                                            sendcustomersmss(res, senderno);
                                            users.Message = res;
                                            users.responsesms();
                                            return res;
                                        }
                                    }
                                    else
                                    {
                                        res = "The+bettor's+Phone+number+is+not+in+a+correct+format.To+topup,+write+topup*+the+Phone+Number*amount+you+want+to+topup.+And+send+to+0788162551";
                                        sendcustomersmss(res, senderno);
                                        users.Message = res;
                                        users.responsesms();
                                        return res;
                                    }
                                }
                                else
                                {

                                    res = "To+topup+a+bettor's+account+write+topup*bettor's+phonenumber*topup+amount+and+send+to+0788162551";
                                    sendcustomersmss(res, senderno);
                                    users.Message = res;
                                    users.responsesms();
                                    return res;
                                }
                            }
                            else
                            {

                                res = "This+number+is+not+Registered+as+Agent+Number.+call+0789997800+for+help";
                                sendcustomersmss(res, senderno);
                                users.Message = res;
                                users.responsesms();
                                return res;
                            }



                        }
                        else if ((keyword == "bal") || (keyword == "balance"))
                        {
                            string AccBalance;
                            DataTable GetBalance = new DataTable();
                            GetBalance = users.AccountBalance();
                            if (GetBalance.Rows.Count == 0)
                            {
                                int inserted = users.InsertPhoneBetter();
                                res = "No+previous+balance+record.+Your+Phone+number+has+been+activated+to+bet.+Send+MOBILE+money+to+0788162551.+Under+REASON+write+your+PHONE+NUMBER.";
                                sendcustomersmss(res, senderno);
                                users.Message = res;
                                users.responsesms();
                                return res;
                            }
                            else
                            {
                                DataRow drBalance;
                                drBalance = GetBalance.Rows[0];
                                AccBalance = drBalance["ammount_e"].ToString();
                                res = "Your+Bet+Account+balance+is+Sh.+" + AccBalance + ".+Please+bet+on+today's+games.+Thanks";
                                sendcustomersmss(res, senderno);
                                users.Message = res;
                                users.responsesms();
                                return res;
                            }




                        }
                        else if ((keyword == "result") || (keyword == "set"))
                        {


                            int setid = 0;
                            Arraymsg = users.splittoArray(recmsg);
                            int Arraylength = Arraymsg.Length;
                            string s = Arraymsg[1].Trim();
                            bool valid = int.TryParse(s, out setid);
                            if (valid)
                            {
                                users.betId = setid;


                                DataTable matches = new DataTable();
                                matches = users.displayresult(setid);
                                if (matches.Rows.Count == 0)
                                {
                                    res = "No+set+records+found.Please+make+sure+that+the+code+is+correct";
                                    users.Message = res;
                                    users.responsesms();
                                    return res;
                                }
                                else
                                {
                                    res = users.resultmessage;
                                    sendcustomersmss(res, phoneno);
                                    users.Message = res;
                                    users.responsesms();
                                    return res;


                                }

                            }
                            else
                            {

                                res = " No+records+for+set+code+" + Arraymsg[1];
                                users.Message = res;
                                users.responsesms();
                                return res;
                            }



                        }
                        else if ((keyword == "pay") || (keyword == "payme"))
                        {

                            double reqamount = 0, AcBalance;
                            decimal balance = users.balance;
                            AcBalance = Convert.ToDouble(balance);
                            Arraymsg = users.splittoArray(recmsg);
                            string s = Arraymsg[1].Trim();
                            bool valid = double.TryParse(s, out reqamount);
                            if (valid)
                            {
                                users.amount = reqamount;
                                if (AcBalance >= reqamount)
                                {
                                    int update = users.insertpaymentRequest();
                                    if (update > 0)
                                    {

                                        res = "Your+payment+request+of+sh.+" + reqamount.ToString() + "+has+been+recieved+and+Your+money+be+sent+to+you+shortly.Your+account+balance+is+sh." + (AcBalance - reqamount).ToString() + ".Thanks";
                                        sendcustomersmss(res, senderno);
                                        users.Message = res;
                                        users.responsesms();
                                        return res;
                                    }
                                    else
                                    {

                                        res = "Your+payment+request+of+sh.+" + reqamount.ToString() + "+has+not+been+processed.Please+call+0789997800+for+help";
                                        sendcustomersmss(res, senderno);
                                        users.Message = res;
                                        users.responsesms();
                                        return res;
                                    }
                                }
                                else
                                {
                                    res = "The+requested+amount+is+greater+your+account+balance.+Your+Account+balance+is+sh:+" + AcBalance.ToString() + ",+Requested+amount+is+sh." + reqamount.ToString() + ".+Request+not+processed";
                                    sendcustomersmss(res, senderno);
                                    users.Message = res;
                                    users.responsesms();
                                    return res;
                                }
                            }
                            else
                            {
                                res = " To+request+for+payment,+write+Pay*the+amount+you+are+requesting+.And+send+to+0788162551";
                                sendcustomersmss(res, senderno);
                                users.Message = res;
                                users.responsesms();
                                return res;
                            }
                        }
                        else
                        {
                            res = "Thank you. Log onto www.smsbet.ug for more games";
                            res = Collapseplus(res);
                            sendcustomersmss(res, senderno);
                            users.Message = res;
                            users.responsesms();
                            return res;

                        }
                    }
                    else
                    {

                        int inserted = users.InsertPhoneBetter();
                        string keyword = users.keyword(recmsg).ToLowerInvariant();
                        Arraymsg = users.splittoArray(recmsg);
                        int Arraylength = Arraymsg.Length;
                        if (keyword == "bet")
                        {
                            res = "Thanks 4 joining SMART BET alerts. This entitles u 2 BET using using your phone, get SMART BET alerts and RESULTS. SMS costs 220/=. Send STOP to 6070 to opt out";
                            res = Collapseplus(res);
                            sendcustomersmss(res, senderno);
                            if (Arraylength == 1)
                            {
                                res = "Your+Phone+number+has+been+activated+to+bet.+To+TOP+UP+your+Betting+account,+Send+MOBILE+money+to+0788162551.+Under+REASON+write+your+PHONE+NUMBER+.+Get+today's+games+and+ODDs+live+on+NTV+or+log+on+to+www.smsbet.ug";
                                if (users.getfixmessage())
                                {

                                    res = users.Message;
                                    //res = res.Replace("6070", "0788162551");
                                }
                                else
                                {
                                    res = "To bet write BET*Selected Team SMS Number*The amount you want to bet.send to 0788162551";
                                }
                                res = Collapseplus(res);
                                sendcustomersmss(res, senderno);
                                users.Message = res;
                                users.responsesms();
                                return res;
                            }
                            else if (Arraylength > 2)
                            {
                                if (users.validateamount(Arraymsg[Arraylength - 1]))
                                {
                                    if (users.validateteamcodes(Arraymsg))
                                    {
                                        bt.betmoney = Convert.ToDecimal((Arraymsg[Arraylength - 1]));
                                        admin.Username = phoneno;
                                        bt.BetId = admin.getbetid();
                                        bt.Username = phoneno;
                                        if (bt.insertbet(Arraymsg))
                                        {
                                            bt.odd = Convert.ToDecimal(bt.totalodd);
                                            bt.setsize = Arraylength - 2;
                                            bt.status = 0;
                                            int ent = bt.updateSetDetails();
                                            if (ent > 0)
                                            {
                                                res = "bet successfull"; 
                                                res = storedsuccessmessage(bt.betmoney, bt.BetId, bt.odd,phoneno);
                                                sendcustomersmss(res, senderno);
                                                users.Message = res;
                                                users.responsesms();
                                                return res;

                                            }
                                            else
                                            {

                                                res = "bet+unsuccessfull";
                                                sendcustomersmss(res, senderno);
                                                users.Message = res;
                                                users.responsesms();
                                                return res;
                                            }
                                        }

                                        else
                                        {
                                            res = "bet+unsuccessfull";
                                            sendcustomersmss(res, senderno);
                                            users.Message = res;
                                            users.responsesms();
                                            return res;
                                        }

                                    }
                                    else
                                    {
                                        res = "Bet+unsuccessfull.+Some+of+the+codes+are+not+correct.+Please+resend+with+the+correct+codes+and+make+sure+that+Match+start+TIME+has+not+expired.Thanks";
                                        if (users.getfixmessage())
                                        {
                                            res = Collapseplus(res);
                                        }
                                        sendcustomersmss(res, senderno);
                                        users.Message = res;
                                        users.responsesms();
                                        return res;
                                    }


                                }
                                else
                                {
                                    res = "The+amount+is+not+correct.+To+bet,+write+BET*+the+Team+Number*amount+you+want+to+BET.+And+send+to+0788162551.+U+can+bet+on+upto+12+different+games.+call+0789997800+for+help";
                                    if (users.getfixmessage())
                                    {

                                        res = users.Message;
                                        res = res.Replace("6070", "0788162551");
                                        res = Collapseplus(res);
                                    }
                                    sendcustomersmss(res, senderno);
                                    users.Message = res;
                                    users.responsesms();
                                    return res;
                                }
                            }

                            else
                            {
                                res = "Minimum+setsize+is+3+games.+To+bet,+write+BET*+the+Team+Number*amount+you+want+to+BET.+And+send+to+0788162551.+U+can+bet+on+upto+12+different+games.+call+0789997800+for+help";
                                if (users.getfixmessage())
                                {

                                    res = users.Message;
                                    //res = res.Replace("6070", "0788162551");
                                   
                                }
                                else
                                {
                                    res = "To bet write BET*Selected Team SMS Number*The amount you want to bet.send to 0788162551";
                                }
                                res = Collapseplus(res);
                                sendcustomersmss(res, senderno);
                                users.Message = res;
                                users.responsesms();
                                return res;

                            }
                        }
                        else
                        {
                            res = "Your+Phone+number+has+been+activated+to+bet.+To+TOP+UP+your+Betting+account,+Send+MOBILE+money+to+0788162551.+Under+REASON+write+your+PHONE+NUMBER+.+Get+today's+games+and+ODDs+live+on+NTV+or+log+on+to+www.smsbet.ug";
                            if (users.getfixmessage())
                            {

                                res = users.Message;
                               // res = res.Replace("6070", "0788162551");
                            }
                            else
                            {
                                res = "To bet write BET*Selected Team SMS Number*The amount you want to bet.send to 0788162551";
                            }
                            res = Collapseplus(res);
                            sendcustomersmss(res, senderno);
                            users.Message = res;
                            users.responsesms();
                            return res;
                        }
                    }

                }
            }
        }
        catch (Exception er)
        {
            return res;
        }
        return res;
    }

    public string validatearray(String[] array)
    {
        DataTable dtUser = new DataTable();
        dtUser = users.CustomerDetails().Tables[0];
        if (dtUser.Rows.Count == 0)
        {
            int inserted = users.InsertPhoneBetter();
            if (inserted > 0)
            {
                _res = "Your+Phone+number+has+been+activated+to+bet.+To+TOP+UP+your+Betting+account,+Send+MOBILE+money+to+0788162551.+Under+REASON+write+your+PHONE+NUMBER+.+Get+today's+games+and+ODDs+live+on+NTV+or+log+on+to+www.smsbet.ug";

            }
            else
            {
                _res = "To+bet,+write+BET*+the+Team+Number*amount+you+want+to+BET.+And+send+to+0788162551.+U+can+bet+on+upto+12+different+games.+call+0789997800+for+help";

            }
        }
        else
        {
            _res = "To+bet,+write+BET*+the+Team+Number*amount+you+want+to+BET.+And+send+to+0788162551.+U+can+bet+on+upto+12+different+games.+call+0789997800+for+help";

            return "";
        }
        return "";
    }
    public string successmessage(decimal betmoney, int betid, decimal odd, decimal AccBalance)
    {
        StringBuilder reply = new StringBuilder("");
        reply.Append("+Expected+");
        reply.Append("win+");
        reply.Append("is+");
        reply.Append("shs.");
        reply.Append(Math.Round((betmoney * odd), 0));
        reply.Append("+for+Shs+");
        reply.Append(betmoney.ToString());
        reply.Append("+placed+on+");
        reply.Append(users.displaygames(betid));  
        reply.Append(".SetNumber+is+");
        reply.Append(betid.ToString().Trim());
        reply.Append(".+Balance+is+sh.");
        reply.Append(Math.Round((AccBalance - betmoney), 0).ToString());
        reply.Append(".+Thanks");
        return reply.ToString();

    }
    public string storedsuccessmessage(decimal betmoney, int betid, decimal odd)
    {
        StringBuilder reply = new StringBuilder("");
        reply.Append("+Possible+");
        reply.Append("win+");
        reply.Append("is+");
        reply.Append("shs.");
        reply.Append(Math.Round((betmoney * odd), 0));
        reply.Append(".+Please+send+the+BET+Money+to+0788162551+using+MTN+Mobile+Money.");
        reply.Append(".In+space+for+REASON+write+your+PHONE+NUMBER.+Thanks.+www.smsbet.ug");
        return reply.ToString();

    }
    public string storedsuccessmessage(decimal betmoney, int betid, decimal odd,string username)
    {
        StringBuilder reply = new StringBuilder();
        reply.Append("+Possible+");
        reply.Append("win+");
        reply.Append("is+");
        reply.Append("shs.");
        reply.Append(Math.Round((betmoney * odd), 0));
        reply.Append(".+Please+send+the+BET+Money+to+0788162551+using+MTN+Mobile+Money.");
        reply.Append(".In+space+for+REASON+write+your+PHONE+NUMBER.+Thanks.+www.smsbet.ug");
        return reply.ToString();

    }
    public string customersuccessmessage(decimal betmoney, int betid, decimal odd, string agentnumber)
    {
        StringBuilder clientreply = new StringBuilder();
        clientreply.Append("Expected+win+is+sh.+");
        clientreply.Append(Math.Round((betmoney * odd), 0).ToString());
        clientreply.Append("+for+shs.");
        clientreply.Append(betmoney.ToString());
        users.betId = betid;
        clientreply.Append("+placed+on+");
        clientreply.Append(users.displaygames(betid));
        clientreply.Append("+Setcode+is+");
        clientreply.Append(betid.ToString().Trim());
        clientreply.Append(".+Thanks");
        return clientreply.ToString();

    }
    public string customerresultmessage(int betid)
    {

        StringBuilder clientreply = new StringBuilder(users.resultmessage);
        clientreply.Append(".+Thanks");
        return clientreply.ToString();

    }
    private string agentsuccessmsg(decimal betamount, int betid, decimal accbalance, int setsize, string better,decimal todd)
    {
        StringBuilder reply = new StringBuilder("");
        reply.Append("Expected+win+is+"+Math.Round((betamount*todd),0).ToString()+"+Shs.");
        reply.Append("Betted+");
        reply.Append(betamount.ToString());
        users.betId = betid;
        users.getbettedset_info();
        reply.Append("+Shs+on+");
        reply.Append(setsize.ToString());
        reply.Append("+game");
        if (setsize > 1)
        {
            reply.Append("s+");
        }
        reply.Append("+for+");
        reply.Append(better);
        reply.Append("+Setcode+is+");
        reply.Append(betid.ToString().Trim());
        reply.Append(".+Your+Balance+is+sh.");
        reply.Append(accbalance.ToString().Trim());
        reply.Append(".+Thanks");

        return reply.ToString();

    }
    public void sendcustomersms(string msg, string Destination_number)
    {
        /*
        HttpWebRequest RequesttosendSms = (HttpWebRequest)WebRequest.Create("https://secure.jolis.net/jc/sms/interface.php?command=sendsinglesms&username=globalbets&password=dewilos&destination=" + Destination_number + "&source=Globalbets&message=" + msg);
        RequesttosendSms.Headers.Add("username", "globalbets");
        RequesttosendSms.Headers.Add("password", "dewilos");
        RequesttosendSms.Headers.Add("destination", Destination_number);
        RequesttosendSms.Headers.Add("source", "globalbets");
        RequesttosendSms.Headers.Add("content_type", "1");
        RequesttosendSms.Headers.Add("msg", msg);
        HttpWebResponse ResponsetosendSms = (HttpWebResponse)RequesttosendSms.GetResponse();
        //string result = (string)ResponsetosendSms.GetResponseHeader("DLRID");
         * */
      
    }
    public void sendcustomersmss(string msg, string Destination_number)
    {
        msg = Collapsepluss(msg);
        HttpWebRequest RequesttosendSms = (HttpWebRequest)WebRequest.Create("http://api.dmarkmobile.com/http/blasta.php?spname=globalbets&sppass=global2012&type=xml&msg="+msg+"&numbers="+Destination_number+"");
        //HttpWebRequest RequesttosendSms = (HttpWebRequest)WebRequest.Create("http://api.dmarkmobile.com/http/blasta.php?spname=globalbets&sppass=global2012&type=xml&msg=" + msg + "&numbers=" + Destination_number);
        RequesttosendSms.Headers.Add("spname", "globalbets");
        RequesttosendSms.Headers.Add("sppass", "global2012");
        RequesttosendSms.Headers.Add("numbers", Destination_number);
        //RequesttosendSms.Headers.Add("msg", msg);
        HttpWebResponse ResponsetosendSms = (HttpWebResponse)RequesttosendSms.GetResponse();
        StreamReader srd = new StreamReader(ResponsetosendSms.GetResponseStream());
        string resulXmlFromWebService = srd.ReadToEnd();
        users.response = resulXmlFromWebService;
        users.saveresponse();
        //  return resulXmlFromWebService;
        //  string result = (string)ResponsetosendSms.GetResponseHeader("id");
    }
    public string Collapseplus(string invalue)
    {
        return invalue.Replace(" ", "+");
    }

    public string Collapsepluss(string invalue)
    {
        return invalue.Replace("+", "");
    }
    #endregion
}
