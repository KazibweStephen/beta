using System;
using System.Data;
using System.Net;
using System.Text;
using System.IO;

public class Processdmarkbet
{
    public Processdmarkbet()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region Variables

    AdminClass admin = new AdminClass();
    public const string PROMO_KEYWORD = "reg";
    public const int AIRTEL = 0;
    public const string ADMIN_PHONE = "256752200600";
    public const int MAX_PAYMENT_REQUEST = 1000;
    public const int MTN = 1;
    public const int WARID = 2;
    private int networkType = MTN;
    float bettingLimit = 50000;
    int minNumberOfGames = 3;
    int maxNumberOfGames = 12;
    Login users = new Login();
    PhoneCustomer bt = new PhoneCustomer();
    Agentclass agent = new Agentclass();
    DataTable BetCustomer = new DataTable();
    DataTable CustomerBAL = new DataTable();
    DataTable _dt_Team = new DataTable();
    DataTable dt_matchcat = new DataTable();
    string _res = null;
    int phonetype = MTN;
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
        string res = "Request not processed";

        try
        {
            if (((apiusername1 == "globalbets") && (apipassword1 == "dewilos")) || ((apiusername1 == "globalbets") && (apipassword1 == "global2012")))
            {
                //bettingLimit = GlobalBetsAdmin.getBettingLimit(GlobalBetsAdmin.MAXIMUM);
                //minNumberOfGames = GlobalBetsAdmin.getReceiptGamesLimit(GlobalBetsAdmin.MINIMUM);
                //maxNumberOfGames = GlobalBetsAdmin.getReceiptGamesLimit(GlobalBetsAdmin.MAXIMUM);
                users.Message = recmsg;
                users.MessageId = msgid;
                users.Phoneno = users.resetphone(senderno.Trim());
                if (apipassword1 == "dewilos")
                {
                    users.source = "VASGARAGE";
                }
                else if (apipassword1 == "global2012")
                {
                    users.source = "DMARK";
                }

                #region VALID SMS
                if (users.recievedsms())
                {
                    string phoneno = users.resetphone(users.Phoneno);
                    users.Phoneno = phoneno;
                    if (phoneno[4] == '5')
                    {
                        networkType = AIRTEL;
                    }
                    else if (phoneno[4] == '0')
                    {
                        networkType = WARID;
                    }

                    #region REGISTERED USER
                    if (users.GetCustomerClient())
                    {
                        int activated = GlobalBetsAdmin.getCustomerStatus(users.Phoneno);
                        if(activated < 0){//use is blacklisted
                            res = "Your betting account is temporarily deactivated. An SMS will be sent to you on re-activation. Thanks!";
                            sendcustomersms(res, phoneno);
                            users.Message = res;
                            users.responsesms();
                            return res;
                        }
                        string keyword = users.keyword(recmsg).ToLowerInvariant();
                        #region KEYWORD = BET
                        if (keyword == "bet")
                        {
                            decimal balance = users.balance;
                            string username = users.Username;
                            string position = users.position;
                            string codes = "";
                            Arraymsg = users.splittoArray(recmsg);
                            int Arraylength = Arraymsg.Length;
                            if (Arraylength > 2)
                            {
                                if (users.validateamount(Arraymsg[Arraylength - 1]))
                                {
                                    if (balance >= Convert.ToDecimal(users.betmoney))
                                    {
                                        if (users.validateteamcodes(Arraymsg))
                                        {
                                            minNumberOfGames = users.validatesize(Arraymsg);
                                            if (Arraymsg.Length < (minNumberOfGames + 2))//minimum number of games=3
                                            {
                                                res = "Minimum number of games including "+users.MaximumSizeBetOpion(Arraymsg)+ " is "+ minNumberOfGames+" .Please add more games to your receipt. Thank you ! www.smsbet.ug";                                   
                                                sendcustomersms(res, phoneno);
                                                users.Message = res;
                                                users.responsesms();
                                                return res;
                                            }
                                            bt.betmoney = Convert.ToDecimal((Arraymsg[Arraylength - 1]));
                                            admin.Username = username;
                                            bt.BetId = admin.getbetid();
                                            bt.Username = username;
                                            if ((bt.betmoney >= 1000) && (bt.betmoney <= Convert.ToDecimal(bettingLimit)))//bet limit
                                            {
                                                //restrict similar receipt
                                                int[] gameNumbers = new int[Arraymsg.Length - 2];
                                                for (int i = 0; i < gameNumbers.Length; i++)
                                                {
                                                    gameNumbers[i] = GlobalBetsAdmin.getMatchNumber(Convert.ToInt32(Arraymsg[(i + 1)]));
                                                }
                                                string betid = GlobalBetsAdmin.ReceiptExists(users.getuser_info(senderno, Login.USERNAME), gameNumbers);
                                                if (betid != "")
                                                {
                                                    res = "Similar games already betted on; In Ticket Number:" + betid + ".  Please bet with a new combination of games! www.smsbet.ug";
                                                    sendcustomersms(res, phoneno);
                                                    users.Message = res;
                                                    users.responsesms();
                                                    return res;
                                                }
                                                //end restrict

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

                                                        #region successfull sms bet
                                                        if (ent > 0)
                                                        {
                                                            GlobalBetsAdmin.alertSuperAdmin(bt.betmoney, bt.Username);
                                                            res = successmessage(bt.betmoney, bt.BetId, bt.odd, balance);
                                                            sendcustomersms(res, phoneno);
                                                            {//account balance feedback
                                                                users.Username = phoneno;
                                                                users.getuser_info();
                                                                string msg = "Your SMS Bet account balance is UGX " + users.balance;
                                                                sendcustomersms(msg, phoneno);
                                                                res = res + " + " + msg;
                                                            }
                                                            users.Message = res;
                                                            users.responsesms();

                                                            //PROMO
                                                            GlobalBetsAdmin.creditReccommendUser(phoneno);
                                                            return res;
                                                        }
                                                        #endregion

                                                        else
                                                        {
                                                            bt.deletebetid();
                                                            res = "Bet unsuccessfull. Please make sure that the match number is not repeated.";
                                                            sendcustomersms(res, phoneno);
                                                            users.Message = res;
                                                            users.responsesms();
                                                            return res;

                                                        }
                                                    }
                                                    else
                                                    {
                                                        res = "Bet unsuccessfull. An error occured while processing your bet. Please try again shortly.";
                                                        sendcustomersms(res, phoneno);
                                                        users.Message = res;
                                                        users.responsesms();
                                                        return res;

                                                    }
                                                }
                                                else
                                                {

                                                    res = "Bet unsuccessfull. An error occured while processing your bet. Please try again shortly.";
                                                    sendcustomersms(res, phoneno);
                                                    users.Message = res;
                                                    users.responsesms();
                                                    return res;

                                                }
                                            }

                                            else if (bt.betmoney < 1000)
                                            {

                                                res = "Minimum bet amount is UGX 1000. Bet with an amout more than 1000. Thanks! www.smsbet.ug";
                                                users.Message = res;
                                                sendcustomersms(res, phoneno);
                                                users.responsesms();
                                                return res;

                                            }
                                            else if (bt.betmoney > Convert.ToDecimal(bettingLimit))
                                            {

                                                res = "Your bet amount is above our maximum limit. Maximum bet amount is UGX " + bettingLimit + ". Please bet again.Thanks! www.smsbet.ug";
                                                sendcustomersms(res, phoneno);
                                                users.Message = res;
                                                users.responsesms();
                                                return res;


                                            }
                                            else
                                            {
                                                res = "Sorry, the bet request you sent is not in a correct order. Please try again with the correct syntax e.g BET*577*887*644*2000.";
                                                sendcustomersms(res, phoneno);
                                                users.Message = res;
                                                users.responsesms();
                                               return res;

                                            }
                                        }
                                        else
                                        {
                                            res = "Bet unsuccessfull. Please resend with the correct syntax e.g BET*577*887*644*2000.Make sure that Match start TIME has not expired. Thanks!";
                                            codes = "";
                                            codes = users.getwrongcodes(Arraymsg).Trim();
                                            if (codes.Length > 4)
                                            {
                                                res = "Please BET again. " + codes + " Thanks! www.smsbet.ug";

                                            }
                                            else if (codes.Length > 0)
                                            {
                                                res = "Please BET again. " + codes + " Thanks! www.smsbet.ug";

                                            }
                                            else
                                            {

                                                res = "Some codes were not correct. Please resend with the correct syntax e.g BET*577*887*644*2000. Thanks! www.smsbet.ug";

                                            }
                                            sendcustomersms(res, phoneno);
                                            users.Message = res;
                                            users.responsesms();
                                            return res;
                                        }

                                    }
                                    else // insufficient credit, no bet
                                    {
                                        users.Username = users.getuser_info(senderno, Login.USERNAME);
                                        users.getuser_info();
                                        res = "Bet has not been accepted. You have less money in your betting account. Current balance is UGX " + users.balance;

                                        sendcustomersms(res, phoneno);
                                        users.Message = res;
                                        users.responsesms();
                                        return res;

                                    }

                                }
                                else
                                {
                                    res = "Sorry, the bet request you sent is not in a correct order. Please try again with the correct syntax e.g BET*577*887*644*2000. Send to " + (networkType == MTN ? "0800206666" : "6666") + ".";
                                    sendcustomersms(res, phoneno);
                                    users.Message = res;
                                    users.responsesms();
                                    return res;
                                }
                            }
                            else
                            {
                                string msg = "";//to send extra message
                                if (users.getfixmessage())
                                {
                                    res = users.Message;
                                }
                                else
                                {
                                    res = "To bet, Type BET*SMS Code*SMS Code*BET AMOUNT e.g BET*577*887*644*2000 and Send to " + (networkType == MTN ? "0800206666 All SMS is free!" : "6666.");
                                    msg = "Visit www.smsbet.ug for SMS betting codes. The SMS codes appear next to the match odds.";
                                    sendcustomersms(msg, phoneno);
                                }
                                sendcustomersms(res, phoneno);
                                if (msg != "")
                                    res = res + " + " + msg;
                                users.Message = res;
                                users.responsesms();
                                return res;
                            }

                        }

                        #endregion

                        #region KEYWORD UNSUB --inactive
                        else if (keyword.ToLower() == "unsub")
                        {
                            users.StopAlert();
                            res = "You have succesffully unsubscribed from HotBet Alerts. Thank you!";
                            sendcustomersms(res, phoneno);
                            return res;
                        }
                        #endregion

                        #region KEYWORD FIX
                        else if (keyword == "fix")
                        {

                            res = admin.SelectLeaguebyGame();
                            sendcustomersms(res, phoneno);
                            return res;
                        }
                        #endregion

                        #region KEYWORD AGENT
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
                                        if (Arraylength > 2)
                                        {
                                            if (users.validateamount(Arraymsg[Arraylength - 1]))
                                            {
                                                if ((Convert.ToDecimal((Arraymsg[Arraylength - 1])) >= 1000) && (Convert.ToDecimal((Arraymsg[Arraylength - 1])) <= Convert.ToDecimal(bettingLimit)))
                                                {
                                                    if (agentbalance > Convert.ToDecimal(users.betmoney))
                                                    {
                                                        if (users.validateagentteamcodes(Arraymsg))
                                                        {
                                                            bt.betmoney = Convert.ToDecimal((Arraymsg[Arraylength - 1]));
                                                            admin.Username = customerusername;
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

                                                                    if (agent.UpdateagentsmsAccounts())//successful bet
                                                                    {
                                                                        GlobalBetsAdmin.alertSuperAdmin(bt.betmoney, bt.Username);
                                                                        res = "Bet successfull";
                                                                        string customermessage = customersuccessmessage(Convert.ToDecimal(users.betmoney), bt.BetId, bt.odd, agent.agentphone);
                                                                        sendcustomersms(customermessage, customernumber);
                                                                        System.Threading.Thread.Sleep(100);
                                                                        string agentmessage = agentsuccessmsg(Convert.ToDecimal(users.betmoney), bt.BetId, agentbalance, bt.setsize, customerusername);
                                                                        sendcustomersms(agentmessage, senderno);
                                                                        return res;
                                                                    }
                                                                    else
                                                                    {

                                                                        res = "Bet unsuccessfull";
                                                                        sendcustomersms(res, phoneno);
                                                                        users.Message = res;
                                                                        users.responsesms();
                                                                        return res;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    bt.deletebetid();

                                                                    res = "Bet unsuccessfull, please make sure that the match is not repeated.";
                                                                    sendcustomersms(res, phoneno);
                                                                    users.Message = res;
                                                                    users.responsesms();
                                                                    return res;
                                                                }
                                                            }

                                                            else
                                                            {
                                                                res = "Bet unsuccessfull";
                                                                sendcustomersms(res, phoneno);
                                                                users.Message = res;
                                                                users.responsesms();
                                                                return res;
                                                            }

                                                        }
                                                        else
                                                        {
                                                            res = "Bet unsuccessfull. Please resend with the correct syntax e.g BET*577*887*644*2000.Make sure that Match start TIME has not expired. Thanks!";
                                                            res = Collapseplus(res);
                                                            sendcustomersms(res, phoneno);
                                                            users.Message = res;
                                                            users.responsesms();
                                                            return res;
                                                        }

                                                    }
                                                    else
                                                    {
                                                        res = Collapseplus(res);
                                                        sendcustomersms(res, phoneno);
                                                        users.Message = res;
                                                        users.responsesms();
                                                        return res;
                                                    }
                                                }
                                                else
                                                {
                                                    if (Convert.ToDecimal((Arraymsg[Arraylength - 1])) < 1000)
                                                    {
                                                        res = "Minimum bet amount is UGX 1000. Please try again with amount more than UGX 1000. Thanks!";
                                                        res = Collapseplus(res);
                                                        sendcustomersms(res, phoneno);
                                                        users.Message = res;
                                                        users.responsesms();
                                                        return res;
                                                    }
                                                    else
                                                    {
                                                        res = "Maximum bet amount is UGX " + bettingLimit + ". Please try again with less amount. Thanks!";
                                                        res = Collapseplus(res);
                                                        sendcustomersms(res, phoneno);
                                                        users.Message = res;
                                                        users.responsesms();
                                                        return res;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                res = "The bet amount is not correct. To bet for a customer write agent* the customer Phone Number*the Teamnumber*amount you want to BET";
                                                res = Collapseplus(res);
                                                sendcustomersms(res, senderno);
                                                users.Message = res;
                                                users.responsesms();
                                                return res;
                                            }

                                        }
                                        else
                                        {
                                            res = "To bet, write agent*the customer Phone Number*the Team SMS Number*amount you want to BET. And send to 0788102615. U can bet on upto " + maxNumberOfGames + " different games. call 0793993375 for help";
                                            res = Collapseplus(res);
                                            sendcustomersms(res, phoneno);
                                            users.Message = res;
                                            users.responsesms();
                                            return res;
                                        }
                                    }
                                    else
                                    {
                                        res = "This number is not Registered as Agent Number. call 0793993375 for help";
                                        res = Collapseplus(res);
                                        sendcustomersms(res, phoneno);
                                        users.Message = res;
                                        users.responsesms();
                                        return res;
                                    }
                                }
                                else
                                {
                                    res = "To bet, write agent*the customer Phone Number*the Teamnumber*amount you want to BET. And send to 0788102615. U can bet on upto " + maxNumberOfGames + " different games. call 0793993375 for help";
                                    res = Collapseplus(res);
                                    sendcustomersms(res, phoneno);
                                    users.Message = res;
                                    users.responsesms();
                                    return res;

                                }

                            }

                            else
                            {
                                res = "This number is not Registered as Agent Number. call 0793993375 for help";
                                res = Collapseplus(res);
                                sendcustomersms(res, senderno);
                                users.Message = res;
                                users.responsesms();
                                return res;
                            }

                        }
                        #endregion

                        #region KEYWORD TOPUP
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
                                                        string customermsg = "Your betting account has been credited with UGX " + topupamount.ToString() + ". Bet on today's games.";
                                                        sendcustomersms(customermsg, Arraymsg[1].Trim());
                                                        System.Threading.Thread.Sleep(2000);
                                                        string agtmsg = res = "You have sent ugx" + topupamount.ToString() + "to" + Arraymsg[1] + ". Your balance is UGX " + balafter.ToString() + ". Thanks!";
                                                        sendcustomersms(agtmsg, senderno);
                                                        users.Message = res;
                                                        users.responsesms();
                                                        return res;
                                                    }
                                                    else
                                                    {

                                                        res = "Money was not sent. Please call 0793993375 for help.";
                                                        sendcustomersms(res, senderno);
                                                        users.Message = res;
                                                        users.responsesms();
                                                        return res;
                                                    }

                                                }
                                                else
                                                {

                                                    sendcustomersms(res, senderno);
                                                    users.Message = res;
                                                    users.responsesms();
                                                    return res;
                                                }
                                            }
                                            else
                                            {

                                                res = "The minimum topup amount is UGX 1000. Please resend the topup with the correct amount.";
                                                sendcustomersms(res, senderno);
                                                users.Message = res;
                                                users.responsesms();
                                                return res;
                                            }
                                        }
                                        else
                                        {
                                            res = "Amount is not in a correct format. To topup, write topup* the bettor's Phone Number*amount you want to topup. And send to 0788102615.";
                                            sendcustomersms(res, senderno);
                                            users.Message = res;
                                            users.responsesms();
                                            return res;
                                        }
                                    }
                                    else
                                    {
                                        res = "The customer's Phone number is not in a correct format. To topup, write topup* the Phone Number*amount you want to topup. And send to 0788102615.";
                                        sendcustomersms(res, senderno);
                                        users.Message = res;
                                        users.responsesms();
                                        return res;
                                    }
                                }
                                else
                                {

                                    res = "To topup a customers's account write topup*bettor's phonenumber*topup amount and send to 0788102615.";
                                    sendcustomersms(res, senderno);
                                    return res;
                                }
                            }
                            else
                            {

                                res = "This number is not Registered as Agent Number. Call 0793993375 for help.";
                                sendcustomersms(res, senderno);
                                users.Message = res;
                                users.responsesms();
                                return res;
                            }



                        }
                        #endregion

                        #region KEYWORD BAL
                        else if ((keyword == "bal") || (keyword == "balance"))
                        {
                            string AccBalance;
                            DataTable GetBalance = new DataTable();
                            GetBalance = users.AccountBalance();
                            if (GetBalance.Rows.Count == 0)
                            {
                                int inserted = users.InsertPhoneBetter();
                                res = "No previous balance record. Your Phone number has been activated to bet. Send MOBILE  money to 0788102615. Under REASON write your PHONE NUMBER.";
                                res = Collapseplus(res);
                                sendcustomersms(res, senderno);
                                users.Message = res;
                                users.responsesms();
                            }
                            else
                            {
                                DataRow drBalance;
                                drBalance = GetBalance.Rows[0];
                                AccBalance = drBalance["ammount_e"].ToString();
                                users.getfixmessage();
                                res = "Your Bet Account balance is UGX " + AccBalance + ".";
                                res = Collapseplus(res);
                                sendcustomersms(res, senderno);
                                users.Message = res;
                                users.responsesms();
                            }

                        }
                        #endregion

                        #region KEYWORD RESULT
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
                                    res = "No set records found. Please make sure that the code is correct. Thanks!";

                                    res = Collapseplus(res);
                                    sendcustomersms(res, phoneno);
                                    users.Message = res;
                                    users.responsesms();
                                    return res;
                                }
                                else
                                {
                                    res = users.resultmessage;
                                    res = Collapseplus(res);
                                    sendcustomersms(res, phoneno);
                                    users.Message = res;
                                    users.responsesms();
                                    return res;


                                }

                            }
                            else
                            {

                                res = " No records for set code " + Arraymsg[1];
                                res = Collapseplus(res);
                                sendcustomersms(res, phoneno);
                                return res;
                            }



                        }
                        #endregion

                        #region KEWYORD PAY
                        else if ((keyword == "pay") || (keyword == "payme" || (keyword == "withdraw")))
                        {

                            double reqamount = 0, AcBalance;
                            decimal balance = users.balance;
                            AcBalance = Convert.ToDouble(balance);
                            Arraymsg = users.splittoArray(recmsg);
                            string s = "";
                            try
                            {
                                s = Arraymsg[1].Trim();
                            }
                            catch (Exception e)
                            {
                                sendcustomersms("No withdraw amount was included in the message. To withdraw type PAY*amount e.g to withdraw 3000/=, type PAY*3000 and send to " + (networkType == MTN ? "0800206666" : "6666") + ". Thanks!", phoneno);
                            }
                            bool valid = double.TryParse(s, out reqamount);
                            if (valid)
                            {
                                users.amount = reqamount;
                                if (AcBalance >= reqamount)
                                {
                                    if (reqamount < MAX_PAYMENT_REQUEST)
                                    {
                                        res = "Your payment request of UGX " + reqamount.ToString() + " has not been processed. Minimum withdrawal amount is UGX 1000. Request an amount of atleast 1000/= Thanks! www.smsbet.ug";
                                        res = Collapseplus(res);
                                        sendcustomersms(res, senderno);
                                        users.Message = res;
                                        users.responsesms();
                                        return res;
                                    }
                                    if ((AcBalance - reqamount) < 1000)//minimnum ac balance
                                    {
                                        res = "Your payment request of UGX " + reqamount.ToString() + " has not been processed. Minimum betting account balance is UGX 1000. Thanks! www.smsbet.ug";
                                        res = Collapseplus(res);
                                        sendcustomersms(res, senderno);
                                        users.Message = res;
                                        users.responsesms();
                                        return res;
                                    }
                                    int update = users.insertpaymentRequest();
                                    if (update > 0)
                                    {

                                        res = "Your payment request of UGX " + reqamount.ToString() + " has been recieved and Your money will be sent to you shortly. Your account balance is UGX " + (AcBalance - reqamount).ToString() + ". For further payment inquiries, call 0793993375. Thanks!";
                                        string res2 = "New globalbets payment request of UGX " + reqamount.ToString() + " has been recieved from " + senderno + " (Username: " + users.getuser_info(senderno, Login.USERNAME) + ")";
                                        res = Collapseplus(res);
                                        sendcustomersms(res, senderno);
                                        sendcustomersms(res2, ADMIN_PHONE);
                                        users.Message = res;
                                        users.responsesms();
                                        return res;
                                    }
                                    else
                                    {

                                        res = "Your payment request of UGX " + reqamount.ToString() + " has not been processed. Please call 0793993375 for help.";
                                        res = Collapseplus(res);
                                        sendcustomersms(res, senderno);
                                        users.Message = res;
                                        users.responsesms();
                                        return res;
                                    }
                                }
                                else
                                {
                                    res = "The requested amount is greater than your account balance. Your Account balance is UGX " + AcBalance.ToString() + ", Requested amount is UGX " + reqamount.ToString() + ". Request not processed.";
                                    res = Collapseplus(res);
                                    sendcustomersms(res, senderno);
                                    users.Message = res;
                                    users.responsesms();
                                    return res;
                                }
                            }
                            else
                            {
                                res = " To request for payment, write Pay*the amount you are requesting. And send to " + (networkType == MTN ? "0800206666" : "6666") + ".";
                                res = Collapseplus(res);
                                sendcustomersms(res, senderno);
                                users.Message = res;
                                users.responsesms();
                                return res;
                            }
                        }
                        #endregion

                        #region PROMO KEYWORD
                        else if (keyword == PROMO_KEYWORD)
                        {
                            if (GlobalBetsAdmin.getBettingPromoStatus().ToLower() == "active")
                            {//promotion active
                                Arraymsg = users.splittoArray(recmsg);
                                string temp = "";
                                try
                                {
                                    temp = Arraymsg[1].Trim();
                                }
                                catch (Exception e)//no number included
                                {
                                    res = "No phone number suggestion was found. Send REG*PHONE NUMBER e.g. To suggest 0776334455, send REG*0776334455 to " + (networkType == MTN ? "0800206666" : "6666") + ". Thanks!";
                                    res = Collapseplus(res);
                                    sendcustomersms(res, senderno);
                                    users.Message = res;
                                    users.responsesms();
                                    return res;
                                }
                                if (temp.StartsWith("0") || temp.StartsWith("256"))
                                {
                                    string suggestedPhone = users.resetphone(temp);
                                    string userID = users.getuser_info(senderno, Login.USERNAME);
                                    string s_userID = users.getuser_info(suggestedPhone, Login.USERNAME);
                                    if (s_userID != "" && s_userID != null)//suggested number already registered
                                    {
                                        res = "The phone number you suggested is already registered with Globalbets. Suggest a different user. Send REG*PHONE NUMBER e.g. To suggest 0776334455, send REG*0776334455 to " + (networkType == MTN ? "0800206666" : "6666") + ". Thanks! www.smsbet.ug";
                                        res = Collapseplus(res);
                                        sendcustomersms(res, senderno);
                                        users.Message = res;
                                        users.responsesms();
                                        return res;
                                    }
                                    if (GlobalBetsAdmin.suggestedEntryExists(suggestedPhone))
                                    {//number already suggested by other user
                                        res = "The phone number you suggested was already suggested by another user. Suggest a different user. Send REG*PHONE NUMBER e.g. To suggest 0776334455, send REG*0776334455 to " + (networkType == MTN ? "0800206666" : "6666") + ". Thanks! www.smsbet.ug";
                                        res = Collapseplus(res);
                                        sendcustomersms(res, senderno);
                                        users.Message = res;
                                        users.responsesms();
                                        return res;
                                    }
                                    if (!GlobalBetsAdmin.promoEntryExists(userID, suggestedPhone))
                                    {//success
                                        GlobalBetsAdmin.saveSuggestedNumber(userID, suggestedPhone);
                                        res = "You successfully reccommended " + suggestedPhone + " to Globalbets. You will receive a bonus betting credit of UGX " + GlobalBetsAdmin.getBettingPromoCredit() + " after the user places their first bet. Thanks for choosing Globalbets! www.smsbet.ug";
                                        res = Collapseplus(res);
                                        sendcustomersms(res, senderno);
                                        users.Message = res;
                                        users.responsesms();
                                        return res;
                                    }
                                    else
                                    {//number alredy suggested.
                                        res = "The phone number you suggested was already suggested by you. Suggest a different user. Send REG*PHONE NUMBER e.g. To suggest 0776334455, send REG*0776334455 to " + (networkType == MTN ? "0800206666" : "6666") + ". Thanks!";
                                        res = Collapseplus(res);
                                        sendcustomersms(res, senderno);
                                        users.Message = res;
                                        users.responsesms();
                                        return res;
                                    }
                                }
                                else
                                {//invalid phone number
                                    res = "The phone number you suggested was not valid. Send REG*PHONE NUMBER e.g. To suggest 0776334455, send REG*0776334455 to " + (networkType == MTN ? "0800206666" : "6666") + ". Thanks!";
                                    res = Collapseplus(res);
                                    sendcustomersms(res, senderno);
                                    users.Message = res;
                                    users.responsesms();
                                    return res;
                                }
                            }
                            else
                            {
                                res = "This service not available at the moment. Continue betting with Globalbets! www.smsbet.ug";
                                res = Collapseplus(res);
                                sendcustomersms(res, senderno);
                                users.Message = res;
                                users.responsesms();
                                return res;
                            }
                        }
                        #endregion

                        #region INVALID KEYWORD
                        else
                        {
                            users.getfixmessage();
                            res = "Thank you. " + users.Message + ".";
                            res = Collapseplus(res);
                            sendcustomersms(res, senderno);
                            return res;

                        }
                        #endregion
                    }
                    #endregion


                    #region UNREGISTERED NUMBER
                    else
                    {
                        int inserted = users.InsertPhoneBetter();
                        string keyword = users.keyword(recmsg).ToLowerInvariant();
                        Arraymsg = users.splittoArray(recmsg);
                        int Arraylength = Arraymsg.Length;
                        if (keyword == "bet")
                        {
                            string res2 = "";
                            string res3 = "";
                            if (Arraylength == 1)
                            {
                                //res = "Thanks 4 joining SMART BET alerts. This entitles u 2 BET using using your phone, get SMART BET alerts and RESULTS. SMS costs 220/=. Send STOP to " + (networkType == MTN ? "0800206666" : "6666") + " to opt out";
                                //res = Collapseplus(res);
                                //sendcustomersms(res, senderno);
                                //users.AddtoalertList();
                                if (users.getfixmessage())
                                {

                                    res = users.Message;
                                }
                                else
                                {

                                }
                                res = Collapseplus(res);
                                //sendsmss(res, senderno);
                                res = "Thanks for joining SMS Bet. Bet using your phone and get results on phone. Visit www.smsbet.ug for more details.";

                                sendcustomersms(res, senderno);
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
                                                res = "Bet successfull";
                                                res = storedsuccessmessage(bt.betmoney, bt.BetId, bt.odd, phoneno);
                                                res = Collapseplus(res);
                                                sendcustomersms(res, phoneno);
                                                users.Message = res;
                                                users.responsesms();
                                                return res;
                                            }
                                            else
                                            {
                                                bt.deletebetid();

                                                res = "Sorry, the bet request you sent is not in a correct order. Please try again with the correct syntax e.g BET*577*887*644*2000.";
                                                sendcustomersms(res, phoneno);
                                                users.Message = res;
                                                users.responsesms();
                                                return res;

                                            }
                                        }

                                        else
                                        {
                                            res = "Sorry, the bet request you sent is not in a correct order. Please try again with the correct syntax e.g BET*577*887*644*2000.";
                                            sendcustomersms(res, phoneno);
                                            users.Message = res;
                                            users.responsesms();
                                            return res;

                                        }

                                    }
                                    else
                                    {
                                        res = "Bet unsuccessfull. Please resend with the correct syntax e.g BET*577*887*644*2000.Make sure that Match start TIME has not expired. Thanks!";
                                        sendcustomersms(res, phoneno);
                                        users.Message = res;
                                        users.responsesms();
                                        return res;

                                    }


                                }
                                else
                                {
                                    res = "The amount is not in correct order. To bet,write BET*the Team SMS Number*the amount you want to BET. Please try again with the correct syntax e.g BET*577*887*644*2000. Send to " + (networkType == MTN ? "0800206666" : "6666") + ".";
                                    sendcustomersms(res, phoneno);
                                    users.Message = res;
                                    users.responsesms();
                                    return res;


                                }
                            }

                            else
                            {

                                res = Collapseplus(res);
                                sendcustomersms(res, phoneno);
                                users.Message = res;
                                users.responsesms();
                                return res;

                            }
                        }
                        else if (keyword == "fix")
                        {

                            res = admin.SelectLeaguebyGame();
                            return res;
                        }
                        else
                        {

                            res = "Thank you. Log onto www.smsbet.ug for more games.";
                            res = Collapseplus(res);
                            sendcustomersms(res, phoneno);
                            users.Message = res;
                            users.responsesms();
                            return res;

                        }
                    }

                }
                    #endregion

                #endregion

                #region INVALID SMS
                else
                {
                    res = "Message ID  has already been used.";
                    return res;
                }
                #endregion

            }
            else
            {
                res = "SMS Bet is currently unavailable, we are sorry for the inconnvenience. Please try again shortly.";
                return res;

            }
        }
        catch (Exception er)
        {
            res = "Request not processed. Please try again shortly. Thank you. www.smsbet.ug";
            return er.ToString();
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

            }
            else
            {
                _res = "To bet, write BET*the Team Number amount you want to BET e.g BET*8777*578*433*2000. Send to " + (networkType == MTN ? "0800206666" : "6666") + ". You can bet on up to " + maxNumberOfGames + " different games.call 0793993375 for help";

            }
        }
        else
        {
            _res = "To bet, write BET* the Team Number*amount you want to BET e.g BET*8777*578*433*2000. Send to " + (networkType == MTN ? "0800206666" : "6666") + ".U can bet on up to " + maxNumberOfGames + " different games. Call 0793993375 for help.";

            return "";
        }
        return "";
    }
    public string successmessage(decimal betmoney, int betid, decimal odd, decimal AccBalance)
    {
        StringBuilder reply = new StringBuilder();
        reply.Append("Expected ");
        reply.Append(" win ");
        reply.Append("is");
        reply.Append(" UGX ");
        reply.Append(Math.Round((betmoney * odd), 0));
        reply.Append(" for UGX ");
        reply.Append(betmoney.ToString());
        reply.Append(" placed on ");
        reply.Append(Collapseplus(users.displaygames(betid)));

        reply.Append(". Setnumber is ");
        reply.Append(betid.ToString().Trim());
        reply.Append(". Balance is UGX ");
        reply.Append(Math.Round((AccBalance - betmoney), 0).ToString());
        reply.Append(". Thanks!");
        return reply.ToString();

    }

    public string Collapseplus(string invalue)
    {
        return invalue.Replace("+", " ");
    }
    public string storedsuccessmessage(decimal betmoney, int betid, decimal odd, string phone)
    {
        StringBuilder reply = new StringBuilder("Expected ");
        reply.Append("win ");
        reply.Append("is ");
        reply.Append("UGX ");
        reply.Append(Math.Round((betmoney * odd), 0));
        string _res = "";
        string res2 = "";
        string res3 = "";
        switch (networkType)
        {
            case MTN:
                _res = "Please credit account by: 1)From your phone, select the MTN Mobile Money Menu. 2)Select Pay Bill";
                res2 = "3) Select Pay For Goods and Services 3)Enter UGMART under Code 4) Enter the amount you want to deposit";
                res3 = "5) Enter SMSBET under REFERENCE 6) Confirm and enter  your Mobile Money PIN";

                break;
            case AIRTEL:
                _res = "Please credit account by: 1) Go to AIRTEL Mobile Money menu. 2) Send Money To Number 3)Enter UGMART under code 4) Enter the amount 5) Enter SMSBET under reference id 6) Confirm";
                break;
            case WARID:
                _res = "Please credit account by: 1) Go to AIRTEL Mobile Money menu. 2) Send Money To Number 3)Enter UGMART under code 4) Enter the amount 5) Enter SMSBET under reference id 6) Confirm";
                break;
            default:
                _res = "Please credit account by: 1) Go to Mobile Money menu. 2) Pay For Goods and Services 3)Enter UGMART under code 4) Enter the amount 5) Enter SMSBET under reference id 6) Confirm";
                break;
        }
        reply.Append(". " + _res + res2 + res3 + ". Thanks! www.smsbet.ug");
        return reply.ToString();

    }
    public string customersuccessmessage(decimal betmoney, int betid, decimal odd, string agentnumber)
    {

        StringBuilder clientreply = new StringBuilder();
        clientreply.Append("Expected win is UGX ");
        clientreply.Append(Math.Round((betmoney * odd), 0).ToString());
        clientreply.Append(". Betted UGX ");
        clientreply.Append(betmoney.ToString());
        clientreply.Append(" on ");
        clientreply.Append(users.displaygames(betid));
        clientreply.Append(" SetNumber is ");
        clientreply.Append(betid.ToString().Trim());
        clientreply.Append(". Thanks!");
        return clientreply.ToString();

    }
    public string customerresultmessage(int betid)
    {

        StringBuilder clientreply = new StringBuilder(users.resultmessage);
        clientreply.Append(". Thanks!");
        return clientreply.ToString();

    }
    private string agentsuccessmsg(decimal betamount, int betid, decimal accbalance, int setsize, string better)
    {
        StringBuilder reply = new StringBuilder("Betted UGX ");
        reply.Append(betamount.ToString());
        users.betId = betid;
        users.getbettedset_info();
        reply.Append(" on ");
        reply.Append(setsize.ToString());
        reply.Append(" game");
        if (setsize > 1)
        {
            reply.Append("s ");
        }
        reply.Append(" for ");
        reply.Append(better);
        reply.Append(" Setcode is ");
        reply.Append(betid.ToString().Trim());
        reply.Append(". Your Balance is UGX ");
        reply.Append(accbalance.ToString().Trim());
        reply.Append(". Thanks!");

        return reply.ToString();

    }
    public void sendcustomersms(string msg, string Destination_number)
    {
        try
        {
            HttpWebRequest RequesttosendSms = (HttpWebRequest)WebRequest.Create("http://sms.vasgarage.ug/api/sendsms/?msg=" + msg + "&phone=" + Destination_number);
            HttpWebResponse ResponsetosendSms = (HttpWebResponse)RequesttosendSms.GetResponse();
        }
        catch (Exception e) { }
    }
    public void sendsmss(string msg, string Destination_number)
    {
        WebRequest req = null;
        WebResponse rsp = null;
        try
        {
            string fileName = "~test.xml";
            string uri = "http://api.dmarkmobile.com/http/blasta.php?spname=globalbets&sppass=global2012&type=xml&msg=" + msg + "&numbers=" + Destination_number;
            req = WebRequest.Create(uri);
            //req.Proxy = WebProxy.GetDefaultProxy(); // Enable if using proxy
            req.Method = "POST";        // Post method
            req.ContentType = "xml";     // content type
            // Wrap the request stream with a text-based writer
            StreamWriter writer = new StreamWriter(req.GetRequestStream());
            // Write the XML text into the stream
            writer.WriteLine(this.GetTextFromXMLFile(fileName));
            writer.Close();
            // Send the data to the webserver
            rsp = req.GetResponse();

        }
        catch (WebException webEx)
        {

        }
        catch (Exception ex)
        {

        }
        finally
        {
            if (req != null) req.GetRequestStream().Close();
            if (rsp != null) rsp.GetResponseStream().Close();
        }
    }
    private string GetTextFromXMLFile(string file)
    {
        StreamReader reader = new StreamReader(file);
        string ret = reader.ReadToEnd();
        reader.Close();
        return ret;
    }
    public static string HttpPost(string msg, string Destination_number)
    {


        System.Net.WebRequest req = System.Net.WebRequest.Create("http://api.dmarkmobile.com/http/blasta.php?");
        req.Proxy = new System.Net.WebProxy();
        //Add these, as we're doing a POST 
        req.ContentType = "xml";
        req.Method = "POST";
        //We need to count how many bytes we're sending. 
        //Post'ed Faked Forms should be name=value&  
        byte[] bytes = System.Text.Encoding.ASCII.GetBytes("spname=globalbets&sppass=global2012&type=xml&msg=" + msg + "&numbers=" + Destination_number);
        req.ContentLength = bytes.Length;
        System.IO.Stream os = req.GetRequestStream();
        os.Write(bytes, 0, bytes.Length);
        //Push it out there  
        os.Close();
        System.Net.WebResponse resp = req.GetResponse();
        if (resp == null) return null;
        System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
        return sr.ReadToEnd().Trim();
    }





    #endregion
}

