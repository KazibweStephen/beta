using System;
using System.Data;
using System.Net;
using System.Text;

public class Processbet
{
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
    public void gggg() {
  
    }
    public String[] messageArray() {

        return Arraymsg = _sentmsg.Split('*');
    }
    public String processmessage ( string apiusername1,string apipassword1 , String recmsg, string msgid,string senderno)
                {
                    string res = "System+Error+please+try+again";
                    try
                    {
                        if ((apiusername1 == "globalbets") && (apipassword1 == "dewilos"))
                        {
                            users.Message = recmsg;
                            users.MessageId = msgid;
                            users.source = "jolis";
                            users.Phoneno = senderno;
                            if (users.recievedsms())
                            {
                                res="message"+msgid+"recieved";
                             
                                string phoneno = users.resetphone(senderno);
                                users.Phoneno = phoneno;
                                
                               sendcustomersms(res+"11", phoneno);
                               return res;
                               //sendsms(res,res, phoneno);
                                /**
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
                                        if (Arraylength > 4)
                                        {
                                            if (users.validateamount(Arraymsg[Arraylength - 1]))
                                            {
                                                if (balance > Convert.ToDecimal(users.betmoney))
                                                {
                                                    if (users.validateteamcodes(Arraymsg))
                                                    {
                                                        bt.betmoney = Convert.ToDecimal((Arraymsg[Arraylength - 1]));
                                                        bt.BetId = admin.getbetid();
                                                        bt.Username = username;
                                                        if (bt.insertbet(Arraymsg))
                                                        {
                                                            bt.odd = Convert.ToDecimal(bt.totalodd);
                                                            bt.setsize = Arraylength - 2;
                                                            bt.status = 1;
                                                            int ent = bt.InsertSetDetails();
                                                            if (ent > 0)
                                                            {
                                                                bt.method = "SMS betting";
                                                                ent = bt.UpdateBetAccount();
                                                                if (ent > 0)
                                                                {
                                                                    res = successmessage(bt.betmoney, bt.BetId, bt.odd, balance);
                                                                    sendcustomersms(res, phoneno);
                                                                    return res;
                                                                }
                                                                else
                                                                {
                                                                    res = "bet+successfull";
                                                                    sendcustomersms(res, phoneno);
                                                                    return res;

                                                                }
                                                            }
                                                            else
                                                            {

                                                                res = "bet+unsuccessfull";
                                                                sendcustomersms(res, phoneno);
                                                                return res;
                                                            }
                                                        }

                                                        else
                                                        {
                                                            res = "bet+unsuccessfull";
                                                            sendcustomersms(res, senderno);
                                                            return res;
                                                        }

                                                    }
                                                    else
                                                    {
                                                        res = "Bet+unsuccessfull.+Some+of+the+codes+are+not+correct.+Please+resend+with+the+correct+codes+and+make+sure+that+Match+start+TIME+has+not+expired.Thanks";
                                                        sendcustomersms(res, phoneno);
                                                        return res;
                                                    }

                                                }
                                                else
                                                {
                                                    res = "Your+BETTING+account+balance+is+low.+Send+MOBILE+money+to+0788162551.+Under+REASON+write+your+PHONE+NUMBER";
                                                    sendcustomersms(res, phoneno);
                                                    return res;
                                                }
                                            }
                                            else
                                            {
                                                res = "The+bet+Amount+is+not+correct.";
                                                sendcustomersms(res, phoneno);
                                                return res;
                                            }

                                        }
                                        else
                                        {
                                            res = "Minimum+setsize+is+3+games.+Please+bet+again.Thanks";
                                            sendcustomersms(res, phoneno);
                                            return res;

                                        }
                                    }
                                    else if (keyword == "agent")
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
                                                    if (Arraylength > 5)
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
                                                                        bt.BetId = admin.getbetid();
                                                                        bt.Username = customerusername;
                                                                        if (bt.insertagentbet(Arraymsg))
                                                                        {

                                                                            bt.odd = Convert.ToDecimal(bt.totalodd);
                                                                            bt.setsize = Arraylength - 3;
                                                                            bt.status = 1;
                                                                            int ent = bt.InsertSetDetails();
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
                                                                                    System.Threading.Thread.Sleep(2000);
                                                                                    string agentmessage = agentsuccessmsg(Convert.ToDecimal(users.betmoney), bt.BetId, agentbalance, bt.setsize, customerusername);
                                                                                    sendcustomersms(agentmessage, customernumber);
                                                                                    return res;
                                                                                }
                                                                                else
                                                                                {

                                                                                    res = "bet+un+successfull";
                                                                                    sendcustomersms(res, senderno);
                                                                                    return res;
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                res = "bet+unsuccessfull";
                                                                                sendcustomersms(res, senderno);
                                                                                return res;
                                                                            }
                                                                        }

                                                                        else
                                                                        {
                                                                            res = "bet+unsuccessfull";
                                                                            sendcustomersms(res, senderno);
                                                                            return res;
                                                                        }

                                                                    }
                                                                    else
                                                                    {
                                                                        res = "Bet+unsuccessfull.+Some+of+the+codes+are+not+correct.+Please+resend+with+the+correct+codes+and+make+sure+that+Match+start+TIME+has+not+expired.Thanks";
                                                                        sendcustomersms(res, senderno);
                                                                        return res;
                                                                    }

                                                                }
                                                                else
                                                                {
                                                                    res = "Your+BETTING+account+balance+is+low.+Send+MOBILE+money+to+0788162551.+Under+REASON+write+your+PHONE+NUMBER";
                                                                    sendcustomersms(res, senderno);
                                                                    return res;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (Convert.ToDecimal((Arraymsg[Arraylength - 1])) < 1000)
                                                                {
                                                                    res = "You+have+betted+with+less+money.+Minimum+bet+amount+is+1000.+Please+bet+again.Thanks";
                                                                    sendcustomersms(res, senderno);
                                                                    return res;
                                                                }
                                                                else
                                                                {
                                                                    res = "Your+bet+amount+is+above+our+maximum+limit.+Maximum+bet+amount+is+sh+50000.+Please+bet+again.Thanks";
                                                                    sendcustomersms(res, senderno);
                                                                    return res;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            res = "The+bet+amount+is+not+correct.To+bet+for+a+customer+write+agent*+the+customer+Phone+Number*the+Teamnumber*amount+you+want+to+BET";
                                                            sendcustomersms(res, senderno);
                                                            return res;
                                                        }

                                                    }
                                                    else
                                                    {
                                                        res = "Minimum+setsize+is+3+games.+Please+bet+again.Thanks";
                                                        sendcustomersms(res, senderno);
                                                        return res;
                                                    }
                                                }
                                                else
                                                {
                                                    res = "This+number+is+not+Registered+as+Agent+Number.+call+0789997800+for+help";
                                                    sendcustomersms(res, senderno);
                                                    return res;
                                                }
                                            }
                                            else
                                            {
                                                res = "To+bet,+write+agent*+the+customer+Phone+Number*the+Teamnumber*amount+you+want+to+BET.+And+send+to+0788162551.+U+can+bet+on+upto+12+different+games.+call+0789997800+for+help";
                                                sendcustomersms(res, senderno);
                                                return res;

                                            }

                                        }

                                        else
                                        {
                                            res = "This+number+is+not+Registered+as+Agent+Number.+call+0789997800+for+help";
                                            sendcustomersms(res, senderno);
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
                                                            double BalAfter = Convert.ToDouble(agentbalance) - topupamount;
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
                                                                    sendcustomersms(customermsg, Arraymsg[1].Trim());
                                                                    System.Threading.Thread.Sleep(2000);
                                                                    string agtmsg = res = "You+have+sent+sh+" + topupamount.ToString() + "+to+" + Arraymsg[1] + "+Your+balance+is+shs." + BalAfter.ToString() + ".+Thanks";
                                                                    sendcustomersms(agtmsg, senderno);
                                                                    return res;
                                                                }
                                                                else
                                                                {

                                                                    res = "Money+was+not+Sent.+Please+call+0789997800+for+help";
                                                                    sendcustomersms(res, senderno);
                                                                    return res;
                                                                }

                                                            }
                                                            else
                                                            {
                                                                res = "You+have+low+balance+on+your+account.+Send+MOBILE+money+to+0788162551.+Under+REASON+write+your+USERNAME";
                                                                sendcustomersms(res, senderno);
                                                                return res;
                                                            }
                                                        }
                                                        else
                                                        {

                                                            res = "The+minimum+topup+amount+is+shs.1000.Please+resend+the+topup+with+the+correct+amount";
                                                            sendcustomersms(res, senderno);
                                                            return res;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        res = "Amount+is+not+in+a+correct+format.To+topup,+write+topup*+the+bettor's+Phone+Number*amount+you+want+to+topup.+And+send+to+0788162551";
                                                        sendcustomersms(res, senderno);
                                                        return res;
                                                    }
                                                }
                                                else
                                                {
                                                    res = "The+bettor's+Phone+number+is+not+in+a+correct+format.To+topup,+write+topup*+the+Phone+Number*amount+you+want+to+topup.+And+send+to+0788162551";
                                                    sendcustomersms(res, senderno);
                                                    return res;
                                                }
                                            }
                                            else
                                            {

                                                res = "To+topup+a+bettor's+account+write+topup*bettor's+phonenumber*topup+amount+and+send+to+0788162551";
                                                sendcustomersms(res, senderno);
                                                return res;
                                            }
                                        }
                                        else
                                        {

                                            res = "This+number+is+not+Registered+as+Agent+Number.+call+0789997800+for+help";
                                            sendcustomersms(res, senderno);
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
                                            }
                                            else
                                            {
                                                res = users.resultmessage;
                                                sendcustomersms(res, phoneno);
                                                return res;


                                            }

                                        }
                                        else
                                        {

                                            res = " No+records+for+set+code+" + Arraymsg[1];
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
                                                    sendcustomersms(res, senderno);
                                                    return res;
                                                }
                                                else
                                                {

                                                    res = "Your+payment+request+of+sh.+" + reqamount.ToString() + "+has+not+been+processed.Please+call+0789997800+for+help";
                                                    sendcustomersms(res, senderno);
                                                    return res;
                                                }
                                            }
                                            else
                                            {
                                                res = "The+requested+amount+is+greater+your+account+balance.+Your+Account+balance+is+sh:+" + AcBalance.ToString() + ",+Requested+amount+is+sh." + reqamount.ToString() + ".+Request+not+processed";
                                                sendcustomersms(res, senderno);
                                                return res;
                                            }
                                        }
                                        else
                                        {
                                            res = " To+request+for+payment,+write+Pay*the+amount+you+are+requesting+.And+send+to+0788162551";
                                            sendcustomersms(res, senderno);
                                            return res;
                                        }
                                    }
                                    else
                                    {
                                        res = "To+bet,+write+BET*+the+Team+Number*amount+you+want+to+BET.+And+send+to+0788162551.+U+can+bet+on+upto+12+different+games.+call+0789997800+for+help";
                                        sendcustomersms(res, senderno);
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
                                        if (Arraylength == 1)
                                        {
                                            res = "Your+Phone+number+has+been+activated+to+bet.+To+TOP+UP+your+Betting+account,+Send+MOBILE+money+to+0788162551.+Under+REASON+write+your+PHONE+NUMBER+.+Get+today's+games+and+ODDs+live+on+NTV+or+log+on+to+www.smsbet.ug";
                                            sendcustomersms(res, senderno);
                                            return res;
                                        }
                                        else if (Arraylength > 4)
                                        {
                                            if (users.validateamount(Arraymsg[Arraylength - 1]))
                                            {
                                                if (users.validateteamcodes(Arraymsg))
                                                {
                                                    bt.betmoney = Convert.ToDecimal((Arraymsg[Arraylength - 1]));
                                                    bt.BetId = admin.getbetid();
                                                    bt.Username = phoneno;
                                                    if (bt.insertbet(Arraymsg))
                                                    {
                                                        bt.odd = Convert.ToDecimal(bt.totalodd);
                                                        bt.setsize = Arraylength - 2;
                                                        bt.status = 0;
                                                        int ent = bt.InsertSetDetails();
                                                        if (ent > 0)
                                                        {
                                                            res = "bet successfull;";
                                                            res = storedsuccessmessage(bt.betmoney, bt.BetId, bt.odd);
                                                            sendcustomersms(res, senderno);
                                                            return res;

                                                        }
                                                        else
                                                        {

                                                            res = "bet+unsuccessfull";
                                                            sendcustomersms(res, senderno);
                                                            return res;
                                                        }
                                                    }

                                                    else
                                                    {
                                                        res = "bet+unsuccessfull";
                                                        sendcustomersms(res, senderno);
                                                        return res;
                                                    }

                                                }
                                                else
                                                {
                                                    res = "Bet+unsuccessfull.+Some+of+the+codes+are+not+correct.+Please+resend+with+the+correct+codes+and+make+sure+that+Match+start+TIME+has+not+expired.Thanks";
                                                    sendcustomersms(res, senderno);
                                                    return res;
                                                }


                                            }
                                            else
                                            {
                                                res = "The+amount+is+not+correct.+To+bet,+write+BET*+the+Team+Number*amount+you+want+to+BET.+And+send+to+0788162551.+U+can+bet+on+upto+12+different+games.+call+0789997800+for+help";

                                                sendcustomersms(res, senderno);
                                                return res;
                                            }
                                        }

                                        else
                                        {
                                            res = "Minimum+setsize+is+3+games.+To+bet,+write+BET*+the+Team+Number*amount+you+want+to+BET.+And+send+to+0788162551.+U+can+bet+on+upto+12+different+games.+call+0789997800+for+help";

                                            sendcustomersms(res, senderno);
                                            return res;

                                        }
                                    }
                                    else
                                    {
                                        res = "Your+Phone+number+has+been+activated+to+bet.+To+TOP+UP+your+Betting+account,+Send+MOBILE+money+to+0788162551.+Under+REASON+write+your+PHONE+NUMBER+.+Get+today's+games+and+ODDs+live+on+NTV+or+log+on+to+www.smsbet.ug";
                                        sendcustomersms(res, senderno);
                                        return res;
                                    }
                                }
                                **/

                            }
                        }
                    }
                    catch (Exception er) {
                        sendcustomersms(res, senderno);
                        return res;
                    }
                    return res;
                }

     public string validatearray  (String [] array)
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
         StringBuilder reply = new StringBuilder("Betted+shs.");
         reply.Append(betmoney.ToString());
         reply.Append("+on+");
         reply.Append(users.displaygames(betid));
         reply.Append("+Possible+");
         reply.Append("win+");
         reply.Append("is+");
         reply.Append("shs.");
         reply.Append(Math.Round((betmoney*odd),0));
         reply.Append(".+Setcode+is+");
         reply.Append(betid.ToString().Trim());
         reply.Append(".+Balance+is+sh.");
         reply.Append(Math.Round((AccBalance-betmoney),0).ToString());
         reply.Append(".+Thanks");
         return reply.ToString();
     
     }
     public string storedsuccessmessage(decimal betmoney, int betid, decimal odd)
     {
         StringBuilder reply = new StringBuilder("Betted+shs.");
         reply.Append(betmoney.ToString());
         reply.Append("+on+");
         reply.Append(users.displaymatches(betid));
         reply.Append("+Possible+");
         reply.Append("win+");
         reply.Append("is+");
         reply.Append("shs.");
         reply.Append(Math.Round((betmoney * odd), 0));
         reply.Append(".+Setcode+is+");
         reply.Append(betid.ToString().Trim());
         reply.Append(".+Send+mobile+money+0788162551+activate+your+bet.");
         reply.Append(".+Thanks");
         return reply.ToString();

     }
     public string customersuccessmessage(decimal betmoney, int betid, decimal odd, string agentnumber)
     {
         StringBuilder clientreply = new StringBuilder("Betted+shs.");
         clientreply.Append(betmoney.ToString());
         users.betId = betid;
         clientreply.Append("+on+");
         clientreply.Append(users.displaygames(betid));
         clientreply.Append("+Setcode+is+");
         clientreply.Append(betid.ToString().Trim());
         clientreply.Append(".+Expected+win+is+sh.+");
         clientreply.Append(Math.Round((betmoney*odd),0).ToString());
         clientreply.Append(".+Thanks");
        return clientreply.ToString();

     }
     public string customerresultmessage( int betid)
     {  
         
         StringBuilder clientreply = new StringBuilder(users.resultmessage);
         clientreply.Append(".+Thanks");
         return clientreply.ToString();

     }
     private string agentsuccessmsg(decimal betamount,int betid, decimal accbalance,int setsize,string better) {
         StringBuilder reply = new StringBuilder("Betted+shs.");
         reply.Append(betamount.ToString());
         users.betId = betid;
         users.getbettedset_info(); 
         reply.Append("+on+");
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
     public void sendsms(String url, string msg, string Destination_number)
     {
         // Response.Redirect("smstest.aspx?reply=" + msg);
         //https://secure.jolis.net/jc/sms/interface.php?command=sendsinglesms&username=globalbets&password=dewilos&destination=2567782896512&source=Globalbets&message=Whats+up?
          
        // Response.Redirect("https://secure.jolis.net/jc/sms/interface.php?command=sendsinglesms&username=globalbets&password=dewilos&destination=" + Destination_number + "&source=Globalbets&message=" + msg);

         //HttpWebRequest RequesttosendSms = (HttpWebRequest)WebRequest.Create(url);
         ////RequesttosendSms.Headers.Add("", "");
         //RequesttosendSms.Headers.Add("username", "globalbets");
         //RequesttosendSms.Headers.Add("password", "dewillos");
         //RequesttosendSms.Headers.Add("Destination", Destination_number);
         //RequesttosendSms.Headers.Add("source", "Globalbets");
         //RequesttosendSms.Headers.Add("command", "sendsinglesms");        
         //RequesttosendSms.Headers.Add("content_type", "1");
         //RequesttosendSms.Headers.Add("msg", msg);
         //HttpWebResponse ResponsetosendSms = (HttpWebResponse)RequesttosendSms.GetResponse();
         //string result = (string)ResponsetosendSms.GetResponseHeader("result");
     }

    #endregion
}
