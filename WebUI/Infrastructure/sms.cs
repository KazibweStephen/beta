using System;
using System.Data;
using System.Web.Services;
using SRN.BLL;

public struct Request
{
    public String apiusername;
    public String apipassword;
    public String transref;
    public String keyword;
    public String message;
    public String phoneno;
    public String metadata;
}
public struct Request_Bet
{
    public String apiusername;
    public String apipassword;
    public String transref;
    public String keyword;
    public String amount;
    public String message;
    public String phoneno;
    public String metadata;
}
public struct Response
{
    public String apiusername;
    public String apipassword;
    public String transref;
    public String status;
    public String returnmessage;
    public String metadata;
}
public struct Response_Bet
{
    public String apiusername;
    public String apipassword;
    public String transref;
    public String status;
    public String amount;
    public String returnmessage;
    public String metadata;
}
/// <summary>
/// <summary>
/// Summary description for sms
/// </summary>
[WebService(Namespace = "http://www.oscar.mobetty.com/oscar_api.php")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class sms : System.Web.Services.WebService
{
    readconn myreadconn = new readconn();
    callingstoredprocedures my_storedpro = new callingstoredprocedures();
    public sms()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    public Request requestres;
    public Response responseres;

    private void Assignvalues(String apiusername, String apipassword, String transref, String keyword, String message, String phoneno, String metadata)
    {
        if ((apiusername == "globalbets") && (apipassword == "dewilos"))
        {
            try
            {
                responseres = updateAccounts(apiusername, apipassword, transref, keyword, message, phoneno, metadata);
            }
            catch (Exception ex) { string error = ex.Message; }
        }
        else
        {
            responseres.apiusername = apiusername;
            responseres.apipassword = apipassword;
            responseres.transref = transref;
            responseres.status = "1";
            responseres.returnmessage = "Transaction Failed Token Issued:Incorrect Authentication";
            responseres.metadata = myreadconn.GetCurrentDate();

        }

    }
    private void processbet(String apiusername, String apipassword, String transref, String keyword, String message, String amount, String phoneno, String metadata)
    {
        if ((apiusername == "globalbets") && (apipassword == "dewilos"))
        {
            // responseres = updateAccountsBet(apiusername, apipassword, transref, keyword, message, amount, phoneno, metadata);
        }
        else
        {
            responseres.apiusername = apiusername;
            responseres.apipassword = apipassword;
            responseres.transref = transref;
            responseres.status = "1";
            responseres.returnmessage = "Transaction Failed Token Issued:Incorrect Authentication";
            responseres.metadata = myreadconn.GetCurrentDate();

        }
    }

    [WebMethod(Description = "Writes the Parameters for the Client Response.", EnableSession = false)]
    public Response Request(String apiusername, String apipassword, String transref, String keyword, String message, String phoneno, String metadata)
    {
        Assignvalues(apiusername, apipassword, transref, keyword, message, phoneno, metadata);

        Response ResponseData = new Response();

        ResponseData.apiusername = responseres.apiusername;
        ResponseData.apipassword = responseres.apipassword;
        ResponseData.transref = responseres.transref;
        ResponseData.status = responseres.status;
        ResponseData.returnmessage = responseres.returnmessage;
        ResponseData.metadata = responseres.metadata;

        return ResponseData;
    }

    public Response updateAccounts(String apiusername, String apipassword, String transref, String keyword, String message, String phoneno, String metadata)
    {
        String _process_status = null;
        String _general_fixturehandler = null;
        String _general_fixture = null;
        string _general_resultshandler = null;
        string _general_results = null;
        Response myresponse = new Response();

        String[] sentmessage = message.Split(' ');

        // getting the matches
        //=================================================================================

        if (keyword == "FIX")
        {
            DataTable matches = new DataTable();

            my_storedpro.league = sentmessage[0];
            my_storedpro.mode = sentmessage[1];

            matches = my_storedpro.fixture();
            if (matches.Rows.Count != 0)
            {

                foreach (DataRow dr in matches.Rows)
                {
                    _general_fixturehandler = dr["Match Code"].ToString() + " "
                     + dr["Home Team"].ToString() + " " + "vs" + " "
                     + dr["Away Team"].ToString() + " "
                     + dr["1"].ToString() + " "
                     + dr["X"].ToString() + " "
                     + dr["2"].ToString() + ",";

                    _general_fixture = _general_fixture + _general_fixturehandler;

                }

                myresponse.apiusername = apiusername;
                myresponse.apipassword = apipassword;
                myresponse.transref = transref;
                myresponse.status = "0: Success";
                myresponse.returnmessage = _general_fixture;
                myresponse.metadata = myreadconn.GetCurrentDate();

            }
            else
            {
                myresponse.apiusername = apiusername;
                myresponse.apipassword = apipassword;
                myresponse.transref = transref;
                myresponse.status = "0: Success";
                myresponse.returnmessage = "UNAVAIBLE MATCHES";
                myresponse.metadata = myreadconn.GetCurrentDate();
            }
        }
        else if (keyword == "BET")
        {
            DataTable matches = new DataTable();
            DataTable bet_matche = new DataTable();
            string msg = null;

            my_storedpro.matno = sentmessage[0];
            my_storedpro.oddname = sentmessage[1];
            my_storedpro.mode = sentmessage[2];
            my_storedpro.betmoney = Convert.ToDouble(sentmessage[3]);

            matches = my_storedpro.match();

            if (matches.Rows.Count > 0)
            {
                foreach (DataRow dr in matches.Rows)
                {
                    my_storedpro.bet_type = "Normal";
                    my_storedpro.username = phoneno;
                    my_storedpro.betdate = Convert.ToDateTime(myreadconn.GetCurrentDate());

                    my_storedpro.setnum = dr["Set Code"].ToString();
                    my_storedpro.champ = dr["League"].ToString();
                    my_storedpro.matno = dr["Match Code"].ToString();
                    my_storedpro.host = dr["Home Team"].ToString();
                    my_storedpro.visitor = dr["Away Team"].ToString();
                    my_storedpro.odd = Convert.ToDouble(dr["1"]);
                    my_storedpro.oddwin = Convert.ToDouble(dr["1"]);
                    my_storedpro.oddlose = Convert.ToDouble(dr["X"]);
                    my_storedpro.oddaway = Convert.ToDouble(dr["2"]);
                    my_storedpro.stime = Convert.ToDateTime(dr["Starting Time"]);

                    if (my_storedpro.mode == "Sure")
                    {
                        my_storedpro.handhome = Convert.ToInt32(dr["Handicap Home goals"]);
                        my_storedpro.handaway = Convert.ToInt32(dr["Handicap Away goals"]);
                    }
                    else
                    {
                        my_storedpro.handhome = 0;
                        my_storedpro.handaway = 0;
                    }
                }
                //getting the betting choice of category
                //*****************************************
                switch (my_storedpro.mode)
                {
                    case ("1X2"):
                        {
                            my_storedpro.category = "Straight Line";

                            if (my_storedpro.oddname == "1")
                            {
                                my_storedpro.oddname = "home";
                                my_storedpro.ttmoney = (my_storedpro.odd * my_storedpro.betmoney);
                            }
                            else if (my_storedpro.oddname == "2")
                            {
                                my_storedpro.oddname = "away";
                                my_storedpro.ttmoney = (my_storedpro.oddaway * my_storedpro.betmoney);
                            }
                            else if (my_storedpro.oddname == "3")
                            {
                                my_storedpro.oddname = "draw";
                                my_storedpro.ttmoney = (my_storedpro.oddlose * my_storedpro.betmoney);
                            }
                            //Saving the bet
                            //***********************************************
                            msg = my_storedpro.Customerbet();

                            if (msg == "Success")
                            {

                                myresponse.apiusername = apiusername;
                                myresponse.apipassword = apipassword;
                                myresponse.transref = transref;
                                myresponse.status = "0: Success";
                                myresponse.returnmessage = "SUCEESSFUL BET";
                                myresponse.metadata = myreadconn.GetCurrentDate();

                            }
                            else
                            {
                                myresponse.apiusername = apiusername;
                                myresponse.apipassword = apipassword;
                                myresponse.transref = transref;
                                myresponse.status = "0: Success";
                                myresponse.returnmessage = "UN SUCEESSFUL BET";
                                myresponse.metadata = myreadconn.GetCurrentDate();
                            }

                            break;
                        }
                    case ("Sure"):
                        {
                            my_storedpro.category = "Sure";

                            if (my_storedpro.oddname == "1")
                            {
                                my_storedpro.oddname = "home";
                                my_storedpro.ttmoney = (my_storedpro.oddwin * my_storedpro.betmoney);
                                my_storedpro.ttmoneywin = (my_storedpro.oddwin * my_storedpro.betmoney);

                                myreadconn.fillgames(my_storedpro.setnum, my_storedpro.matno);
                                myreadconn.sure_deal_putmoney(my_storedpro.setnum, my_storedpro.matno);
                            }
                            else if (my_storedpro.oddname == "2")
                            {
                                my_storedpro.oddname = "away";
                                my_storedpro.ttmoney = (my_storedpro.oddaway * my_storedpro.betmoney);
                                my_storedpro.ttmoneywin = (my_storedpro.oddwin * my_storedpro.betmoney);

                                myreadconn.fillgames(my_storedpro.setnum, my_storedpro.matno);
                                myreadconn.sure_deal_putmoney(my_storedpro.setnum, my_storedpro.matno);
                            }

                            //Saving the bet
                            //***********************************************
                            msg = my_storedpro.Customerbet();

                            if (msg == "Success")
                            {

                                myresponse.apiusername = apiusername;
                                myresponse.apipassword = apipassword;
                                myresponse.transref = transref;
                                myresponse.status = "0: Success";
                                myresponse.returnmessage = "SUCEESSFUL BET";
                                myresponse.metadata = myreadconn.GetCurrentDate();

                            }
                            else
                            {
                                myresponse.apiusername = apiusername;
                                myresponse.apipassword = apipassword;
                                myresponse.transref = transref;
                                myresponse.status = "0: Success";
                                myresponse.returnmessage = "UN SUCEESSFUL BET";
                                myresponse.metadata = myreadconn.GetCurrentDate();
                            }

                            break;
                        }
                }
            }
            else
            {
                myresponse.apiusername = apiusername;
                myresponse.apipassword = apipassword;
                myresponse.transref = transref;
                myresponse.status = "0: Success";
                myresponse.returnmessage = "UNKNOWN MATCH BETTED";
                myresponse.metadata = myreadconn.GetCurrentDate();
            }
        }
        else if (keyword == "RES")
        {
            DataTable matches = new DataTable();

            my_storedpro.league = sentmessage[0];
            my_storedpro.mode = sentmessage[1];

            matches = my_storedpro.results();
            if (matches.Rows.Count != 0)
            {
                foreach (DataRow dr in matches.Rows)
                {
                    _general_resultshandler = dr["Home Team"].ToString() + " "
                     + dr["Away Team"].ToString() + " "
                     + dr["Results"].ToString() + ",";

                    _general_results = _general_results + _general_resultshandler;

                }

                myresponse.apiusername = apiusername;
                myresponse.apipassword = apipassword;
                myresponse.transref = transref;
                myresponse.status = "0: Success";
                myresponse.returnmessage = _general_results;
                myresponse.metadata = myreadconn.GetCurrentDate();

            }
            else
            {
                myresponse.apiusername = apiusername;
                myresponse.apipassword = apipassword;
                myresponse.transref = transref;
                myresponse.status = "0: Success";
                myresponse.returnmessage = "UNAVAIBLE RESULTS";
                myresponse.metadata = myreadconn.GetCurrentDate();
            }
        }
        else
        {
            myresponse.apiusername = apiusername;
            myresponse.apipassword = apipassword;
            myresponse.transref = transref;
            myresponse.status = "1: UnSuccessful";
            myresponse.returnmessage = "UNKNOWN COMMAND:";
            myresponse.metadata = myreadconn.GetCurrentDate();
        }

        return myresponse;
    }
}


