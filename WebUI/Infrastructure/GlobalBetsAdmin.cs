using SRN.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;

/// <summary>
/// Summary description for GlobalBetsAdmin
/// </summary>
public class GlobalBetsAdmin
{
    #region sql stored constants
    private const int TEST = 101;
    private const int ALL_MOBILE_PAYMENTS = 1;
    private const int WEEKLYMOBILE_PAYMENTS = 2;
    private const int ALL_SMS = 3;
    private const int SENT_SMS = 4;
    private const int ALL_USERS = 5;
    private const int WEEKLYSMS = 6;
    private const int USER_BALANCE = 7;
    private const int TOTAL_USER_BALANCE = 8;
    private const int  UpdateDisplayDays = 46;
    //finacial report
    private const int USER_BALANCE_DATE = 9;
    private const int TOTAL_DEPOSITS_DATE = 10;
    private const int TOTAL_STAKES_DATE = 11;
    private const int EXPECTED_WIN_DATE = 12;
    private const int BANK_BALANCE_DATE = 13;
    private const int AllTRANSACTIONS = 53;

    private const int POST_GAME = 14;
    private const int CUSTOMER_DEPOSIT_REPORT = 15;
    private const int GLOBALBETS_ACCOUNT_REPORT = 16;
    private const int UGMART_ACCOUNT_REPORT = 17;
    private const int DisplayDays = 50;
    private const int ACTIVATE_TRANSACTION = 1;

    public const int ADD_TAX = 18;
    public const int ADD_OTHER_PAYMENT = 19;

    public const int MOBILE_MONEY_REQUEST = 20;
    public const int MOBILE_MONEY_PAID_REQUEST = 21;
    public const int RECEIPT_GAMES_CHECK = 22;
    public const int MATCH_NUMBER_FROM_SMS_CODE = 23;
    public const int USER_BET_RECEIPTS = 24;
    public const int SEARCH_PENDING_BETS = 25;
    public const int SEARCH_COMPLETE_BETS = 26;
    public const int CANCEL_BET_RECEIPT = 27;
    public const int REMOVE_BET_MATCH = 28;
    public const int REGISTER_NEW_USER = 29;
    public const int CANCEL_PAYMENT_REQUEST = 30;
    public const int SUPER_ADMIN_DETAILS = 31;
    public const int UPDATE_BETTING_LIMIT = 32;
    public const int UPDATE_RECEIPT_GAMES_LIMIT = 33;
    public const int UPDATE_BETTING_OPTIONS = 34;
    public const int UPDATE_BETTING_OPTIONS1 = 54;
    public const int ACTVATE_ACCOUNT = 35;
    public const int RECEIPT_BET_STAKE = 36;
    public const int ALL_COMPLETE_BETS = 37;
    public const int TOTAL_STAKES_BY_AMOUNT = 38;
    public const int TOTAL_WINS_BY_AMOUNT = 39;
    public const int OPENING_DEPOSITS_BY_DATE = 40;
    public const int DEPOSITS_BY_DATE = 41;
    public const int OPENING_PAYOUTS_BY_DATE = 42;
    public const int PAYOUTS_BY_DATE = 43;
    public const int CUSTOMER_BALANCE_BY_DATE = 44;
    public const int DeActivatedAccount = 45;
    public const int UPDATE_MINIMUM_BETOPTION_SIZE = 51;
    public const int SELECT_BETTING_OPTIONS = 52;
    public const int MTN = 1;
    public const int AIRTEL = 2;
    public const int WARID = 3;
    public const int ALL_NETWORKS = 0;

    public const int ALL = 0;
    public const int ONLINE = 1;
    public const int SMS = 2;

    public const int BETTING_MAX_LIMIT = 50000;
    public const int MINIMUM = 0;
    public const int MAXIMUM = 1;
    public static string CurrentBettingOptions = null;
    public const int ACTIVATED = 1;
    public const int DEACTIVATED = -1;
    #endregion

    public static string[] MONTH = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

    #region init
    public const string STORED_PROCEDURE = "NewSp";
    public const string STORED_PROCEDURE_1 = "Sp_gbea";
    public const string STORED_PROCEDURE_2 = "sp_Login";
    private static DBBridge dbBridge = DBBridge.getSharedInstance();
    private static Login log = new Login();
    public GlobalBetsAdmin()
    {
    }

    #endregion

    #region return dataset

    public static DataSet AllMobilePAyments(DateTime start, DateTime end)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", ALL_MOBILE_PAYMENTS);
        param[1] = new SqlParameter("@startDate", start);
        param[2] = new SqlParameter("@endDate", end);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }

    public static DataSet AllMobilePAyments()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@query", ALL_MOBILE_PAYMENTS);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }

    public static DataSet getMobilePAyments(DateTime start, DateTime end, int network)
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@query", ALL_MOBILE_PAYMENTS);
        param[1] = new SqlParameter("@startDate", start);
        param[2] = new SqlParameter("@endDate", end);
        param[3] = new SqlParameter("@network", network);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }

    public static DataSet getMobilePAyments(int network, string keyword)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", ALL_MOBILE_PAYMENTS);
        param[1] = new SqlParameter("@searchkeyword", keyword);
        param[2] = new SqlParameter("@network", network);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }

    public static string TotalUserBalance()
    {
        string total = "0";
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@query", TOTAL_USER_BALANCE);
        DataTable dataTable = dbBridge.ExecuteDataset(STORED_PROCEDURE, param).Tables[0];
        if (dataTable.Rows.Count > 0)
        {
            DataRow dataRow;
            dataRow = dataTable.Rows[0];
            total = (dataRow["total"]).ToString();
        }
        return total;
    }


    public static DataSet UserBalance()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@query", USER_BALANCE);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }
   
    public static DataSet UserBalance(string username)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@query", USER_BALANCE);
        param[1] = new SqlParameter("@username", username);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }
    public static DataSet DeActivatedAccounts()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@query", DeActivatedAccount);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }
    public static DataSet DeActivatedAccounts(string username)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@query", DeActivatedAccount);
        param[1] = new SqlParameter("@username", username);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }
    public static DataSet getPostPonedGames(DateTime start, DateTime end)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", POST_GAME);
        param[1] = new SqlParameter("@startDate", start);
        param[2] = new SqlParameter("@endDate", end);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }

    #region finacial report
    public static string getTotalBankBalance(DateTime end)
    {
        string total = "";
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@query", BANK_BALANCE_DATE);
        param[1] = new SqlParameter("@endDate", end);
        DataTable dataTable = dbBridge.ExecuteDataset(STORED_PROCEDURE, param).Tables[0];
        if (dataTable.Rows.Count > 0)
        {
            DataRow dataRow;
            dataRow = dataTable.Rows[0];
            total = (dataRow["total"]).ToString();
        }
        return total;
    }

    public static string getTotalExpectedWin(DateTime start, DateTime end)
    {
        string total = "";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", EXPECTED_WIN_DATE);
        param[1] = new SqlParameter("@startDate", start);
        param[2] = new SqlParameter("@enddate", end);
        DataTable dataTable = dbBridge.ExecuteDataset(STORED_PROCEDURE, param).Tables[0];
        if (dataTable.Rows.Count > 0)
        {
            DataRow dataRow;
            dataRow = dataTable.Rows[0];
            total = (dataRow["total"]).ToString();
        }
        return total;
    }

    public static string getTotalDeposits(DateTime start, DateTime end)
    {
        string total = "";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", EXPECTED_WIN_DATE);
        param[1] = new SqlParameter("@startDate", start);
        param[2] = new SqlParameter("@enddate", end);
        DataTable dataTable = dbBridge.ExecuteDataset(STORED_PROCEDURE, param).Tables[0];
        if (dataTable.Rows.Count > 0)
        {
            DataRow dataRow;
            dataRow = dataTable.Rows[0];
            total = (dataRow["total"]).ToString();
        }
        return total;
    }
    public static string getUsersAccountBalance(DateTime end)
    {
        string total = "";
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@query", USER_BALANCE_DATE);
        param[1] = new SqlParameter("@endDate", end);
        DataTable dataTable = dbBridge.ExecuteDataset(STORED_PROCEDURE, param).Tables[0];
        if (dataTable.Rows.Count > 0)
        {
            DataRow dataRow;
            dataRow = dataTable.Rows[0];
            total = (dataRow["total"]).ToString();
        }
        return total;
    }

    public static string getTotalStake(DateTime start, DateTime end)
    {
        string total = "";
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", EXPECTED_WIN_DATE);
        param[1] = new SqlParameter("@startDate", start);
        param[2] = new SqlParameter("@enddate", end);
        DataTable dataTable = dbBridge.ExecuteDataset(STORED_PROCEDURE, param).Tables[0];
        if (dataTable.Rows.Count > 0)
        {
            DataRow dataRow;
            dataRow = dataTable.Rows[0];
            total = (dataRow["total"]).ToString();
        }
        return total;
    }
    public static DataSet getAllTransactions(DateTime start, DateTime end)// select all transactions for analysis
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", AllTRANSACTIONS);
        param[1] = new SqlParameter("@dot", start);
        param[2] = new SqlParameter("@dot2", end);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }

    #endregion

    public static DataSet WeeeklyMobilePAyments()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@query", WEEKLYMOBILE_PAYMENTS);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }

    public static DataSet WeeeklySMS()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@query", WEEKLYSMS);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }

    public static DataSet AllSMS()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@query", ALL_SMS);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }

    public static DataSet AllSMS(DateTime start, DateTime end)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", ALL_SMS);
        param[1] = new SqlParameter("@startDate", start);
        param[2] = new SqlParameter("@endDate", end);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }
    public static DataSet AllSMS(string keyword)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@query", ALL_SMS);
        param[1] = new SqlParameter("@searchkeyword", keyword);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }

    public static DataSet AllSentSMS()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@query", SENT_SMS);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }

    public static DataSet AllSentSMS(DateTime start, DateTime end)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", SENT_SMS);
        param[1] = new SqlParameter("@startDate", start);
        param[2] = new SqlParameter("@endDate", end);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }

    public static DataSet AllSentSMS(string keyword)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@query", SENT_SMS);
        param[1] = new SqlParameter("@searchkeyword", keyword);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }

    public static DataSet AllUsers()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@query", ALL_USERS);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }
    public static DataSet AllUsers(string keyword)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@query", ALL_USERS);
        param[1] = new SqlParameter("@searchkeyword", keyword);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }

    public static DataSet CustomerDepositsReport(DateTime start, DateTime end)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", CUSTOMER_DEPOSIT_REPORT);
        param[1] = new SqlParameter("@DOT", start);
        param[2] = new SqlParameter("@DOT2", end);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }

    public static DataSet GlobalbetsAccountReport(DateTime start, DateTime end)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", GLOBALBETS_ACCOUNT_REPORT);
        param[1] = new SqlParameter("@DOT", start.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", end);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }
    public static DataSet GlobalbetsMonthlyBetReport(DateTime start, DateTime end)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query",47 );
        param[1] = new SqlParameter("@DOT", start.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", end);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }
    public static DataSet GlobalbetsMonthlyPayOutReport(DateTime start,DateTime end)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", 48);
        param[1] = new SqlParameter("@DOT", start.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", end);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }
    public static DataSet GlobalbetsMonthlyDepositReport(DateTime start, DateTime end)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", 49);
        param[1] = new SqlParameter("@DOT", start.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", end);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }
    public static DataSet UGMARTAccountReport(DateTime start, DateTime end)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", UGMART_ACCOUNT_REPORT);
        param[1] = new SqlParameter("@DOT", start);
        param[2] = new SqlParameter("@DOT2", end);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }

    public static DataSet getPayoutRequests(DateTime start, DateTime end, int network)
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@query", MOBILE_MONEY_REQUEST);
        param[1] = new SqlParameter("@DOT", start);
        param[2] = new SqlParameter("@DOT2", end);
        param[3] = new SqlParameter("@network", network);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }

    public static DataSet getCompletePayoutRequests(DateTime start, DateTime end, int network)
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@query", MOBILE_MONEY_PAID_REQUEST);
        param[1] = new SqlParameter("@DOT", start);
        param[2] = new SqlParameter("@DOT2", end);
        param[3] = new SqlParameter("@network", network);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }

    //search
    public static DataSet getCompletePayoutRequests(int network, string keyword)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", MOBILE_MONEY_PAID_REQUEST);
        param[1] = new SqlParameter("@network", network);
        param[2] = new SqlParameter("@searchkeyword", keyword);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }

    #region daily stmt
    public static int getOpeningDepositsByDate(DateTime date)
    {
        int total = 0;
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@query", OPENING_DEPOSITS_BY_DATE);
        param[1] = new SqlParameter("@startDate", date);
        DataTable dataTable = dbBridge.ExecuteDataset(STORED_PROCEDURE, param).Tables[0];
        if (dataTable.Rows.Count > 0)
        {
            DataRow dataRow;
            dataRow = dataTable.Rows[0];
            total = Convert.ToInt32((dataRow["value"]).ToString());
        }
        return total;
    }

    public static int getDepositsByDate(DateTime date)
    {
        int total = 0;
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@query", DEPOSITS_BY_DATE);
        param[1] = new SqlParameter("@startDate", date);
        DataTable dataTable = dbBridge.ExecuteDataset(STORED_PROCEDURE, param).Tables[0];
        if (dataTable.Rows.Count > 0)
        {
            DataRow dataRow;
            dataRow = dataTable.Rows[0];
            total = Convert.ToInt32((dataRow["value"]).ToString());
        }
        return total;
    }

    public static int getOpeningPayoutsByDate(DateTime date)
    {
        int total = 0;
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@query", OPENING_PAYOUTS_BY_DATE);
        param[1] = new SqlParameter("@startDate", date);
        DataTable dataTable = dbBridge.ExecuteDataset(STORED_PROCEDURE, param).Tables[0];
        if (dataTable.Rows.Count > 0)
        {
            DataRow dataRow;
            dataRow = dataTable.Rows[0];
            total = Convert.ToInt32((dataRow["value"]).ToString());
        }
        return total;
    }

    public static int getPayoutsByDate(DateTime date)
    {
        int total = 0;
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@query", PAYOUTS_BY_DATE);
        param[1] = new SqlParameter("@startDate", date);
        DataTable dataTable = dbBridge.ExecuteDataset(STORED_PROCEDURE, param).Tables[0];
        if (dataTable.Rows.Count > 0)
        {
            DataRow dataRow;
            dataRow = dataTable.Rows[0];
            total = Convert.ToInt32((dataRow["value"]).ToString());
        }
        return total;
    }

    #endregion

    #region monthly stmt
    public static int getOpeningDepositsByMonth(DateTime date)
    {
        int total = 0;
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", OPENING_DEPOSITS_BY_DATE);
        param[1] = new SqlParameter("@startDate", date);
        param[2] = new SqlParameter("@type", 1);
        DataTable dataTable = dbBridge.ExecuteDataset(STORED_PROCEDURE, param).Tables[0];
        if (dataTable.Rows.Count > 0)
        {
            DataRow dataRow;
            dataRow = dataTable.Rows[0];
            total = Convert.ToInt32((dataRow["value"]).ToString());
        }
        return total;
    }

    public static int getDepositsByMonth(DateTime date)
    {
        int total = 0;
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", DEPOSITS_BY_DATE);
        param[1] = new SqlParameter("@startDate", date);
        param[2] = new SqlParameter("@type", 1);
        DataTable dataTable = dbBridge.ExecuteDataset(STORED_PROCEDURE, param).Tables[0];
        if (dataTable.Rows.Count > 0)
        {
            DataRow dataRow;
            dataRow = dataTable.Rows[0];
            total = Convert.ToInt32((dataRow["value"]).ToString());
        }
        return total;
    }

    public static int getOpeningPayoutsByMonth(DateTime date)
    {
        int total = 0;
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", OPENING_PAYOUTS_BY_DATE);
        param[1] = new SqlParameter("@startDate", date);
        param[2] = new SqlParameter("@type", 1);
        DataTable dataTable = dbBridge.ExecuteDataset(STORED_PROCEDURE, param).Tables[0];
        if (dataTable.Rows.Count > 0)
        {
            DataRow dataRow;
            dataRow = dataTable.Rows[0];
            total = Convert.ToInt32((dataRow["value"]).ToString());
        }
        return total;
    }

    public static int getPayoutsByMonth(DateTime date)
    {
        int total = 0;
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", PAYOUTS_BY_DATE);
        param[1] = new SqlParameter("@startDate", date);
        param[2] = new SqlParameter("@type", 1);
        DataTable dataTable = dbBridge.ExecuteDataset(STORED_PROCEDURE, param).Tables[0];
        if (dataTable.Rows.Count > 0)
        {
            DataRow dataRow;
            dataRow = dataTable.Rows[0];
            total = Convert.ToInt32((dataRow["value"]).ToString());
        }
        return total;
    }

    #endregion

    public static int getCustomerBalanceByDate(DateTime date)
    {
        int total = 0;
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@query", CUSTOMER_BALANCE_BY_DATE);
        param[1] = new SqlParameter("@startDate", date);
        DataTable dataTable = dbBridge.ExecuteDataset(STORED_PROCEDURE, param).Tables[0];
        if (dataTable.Rows.Count > 0)
        {
            DataRow dataRow;
            dataRow = dataTable.Rows[0];
            total = Convert.ToInt32((dataRow["value"]).ToString());
        }
        return total;
    }
    #endregion
    #region betting functions



    //alert on bet stake > BETTING_MAX_LIMIT
    public static void alertSuperAdmin(decimal stake, string username)
    {
        if (stake >= BETTING_MAX_LIMIT)//alert super admins
        {
            DataTable dt = GlobalBetsAdmin.SuperAdmninDetails().Tables[0];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string adminMsg = "GBEAL Alert: " + username + " has placed a bet of UGX " + stake + ".";
                    string phoneno = row["phone"].ToString();
                    GlobalBetsAdmin.SendVasMessage(adminMsg, phoneno);
                }
            }
        }
    }

    //alert on change in maximum stake
    public static void alertSuperAdmin(float newStake, string username, int type)
    {
        DataTable dt = GlobalBetsAdmin.SuperAdmninDetails().Tables[0];
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                string adminMsg = "";
                switch (type)
                {
                    case UPDATE_BETTING_LIMIT:
                        adminMsg = "GBEAL Alert: The maximum betting stake has been changed to UGX " + newStake + " by " + username;
                        break;
                }
                string phoneno = row["phone"].ToString();
                GlobalBetsAdmin.SendVasMessage(adminMsg, phoneno);
            }
        }
    }

    //alert on change in maximum stake with message
    public static void alertSuperAdmin(float newStake, string username, int type, string msg)
    {
        DataTable dt = GlobalBetsAdmin.SuperAdmninDetails().Tables[0];
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                string adminMsg = "";
                switch (type)
                {
                    case UPDATE_BETTING_LIMIT:
                        adminMsg = "GBEAL Alert: The " + msg + " has been changed to UGX " + newStake + " by " + username;
                        break;
                }
                string phoneno = row["phone"].ToString();
                GlobalBetsAdmin.SendVasMessage(adminMsg, phoneno);
            }
        }
    }

    //alert on change in maximum stake with message
    public static void alertSuperAdmin(string adminMsg)
    {
        DataTable dt = GlobalBetsAdmin.SuperAdmninDetails().Tables[0];
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                adminMsg = "GBEAL Alert: "+ adminMsg;
                string phoneno = row["phone"].ToString();
                GlobalBetsAdmin.SendVasMessage(adminMsg, phoneno);
            }
        }
    }

    public static DataSet searchPendingBets(string keyword)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@query", SEARCH_PENDING_BETS);
        param[1] = new SqlParameter("@searchkeyword", keyword);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }

    public static string totalStakesbyAmount(DateTime start, DateTime end, decimal lower, decimal upper)
    {
        string stake = "0";
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@query", TOTAL_STAKES_BY_AMOUNT);
        param[1] = new SqlParameter("@dot", start);
        param[2] = new SqlParameter("@dot2", end);
        param[3] = new SqlParameter("@lowerlimit", lower);
        param[4] = new SqlParameter("@upperlimit", upper);
        DataTable dataTable = dbBridge.ExecuteDataset(STORED_PROCEDURE, param).Tables[0];
        if (dataTable.Rows.Count > 0)
        {
            DataRow dataRow;
            dataRow = dataTable.Rows[0];
            {
                stake = (dataRow[0]).ToString();
            }
        }
        return stake;
    }

    public static string totalWinsbyAmount(DateTime start, DateTime end, decimal lower, decimal upper)
    {
        string stake = "0";
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@query", TOTAL_WINS_BY_AMOUNT);
        param[1] = new SqlParameter("@dot", start);
        param[2] = new SqlParameter("@dot2", end);
        param[3] = new SqlParameter("@lowerlimit", lower);
        param[4] = new SqlParameter("@upperlimit", upper);
        DataTable dataTable = dbBridge.ExecuteDataset(STORED_PROCEDURE, param).Tables[0];
        if (dataTable.Rows.Count > 0)
        {
            DataRow dataRow;
            dataRow = dataTable.Rows[0];
            {
                stake = (dataRow[0]).ToString();
            }
        }
        return stake;
    }

    public static DataSet allCompleteBetsReport(DateTime start, DateTime end)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", ALL_COMPLETE_BETS);
        param[1] = new SqlParameter("@dot", start);
        param[2] = new SqlParameter("@dot2", end);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }

    public static DataSet allCompleteBetsReport(string keyword)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@query", ALL_COMPLETE_BETS);
        param[1] = new SqlParameter("@dot", keyword);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }

    public static DataSet searchPendingBets(string keyword, int type)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", SEARCH_PENDING_BETS);
        param[1] = new SqlParameter("@searchkeyword", keyword);
        param[2] = new SqlParameter("@type", type);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }

    public static DataSet searchCompleteBets(string keyword)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@query", SEARCH_COMPLETE_BETS);
        param[1] = new SqlParameter("@searchkeyword", keyword);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }

    public static DataSet searchCompleteBets(string keyword, int type)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", SEARCH_COMPLETE_BETS);
        param[1] = new SqlParameter("@searchkeyword", keyword);
        param[2] = new SqlParameter("@type", type);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }

    public static DataSet getUserBetReceiptsToday(string username)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@query", USER_BET_RECEIPTS);
        param[1] = new SqlParameter("@username", username);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }


    public static int getMatchNumber(int smscode)
    {
        int matno = 0;
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@query", MATCH_NUMBER_FROM_SMS_CODE);
        param[1] = new SqlParameter("@smscode", smscode);
        DataTable dataTable = dbBridge.ExecuteDataset(STORED_PROCEDURE, param).Tables[0];
        if (dataTable.Rows.Count > 0)
        {
            DataRow dataRow;
            dataRow = dataTable.Rows[0];
            try
            {
                matno = Convert.ToInt32((dataRow["MatchCode"]).ToString());
            }
            catch (Exception e)
            {

            }
        }
        return matno;
    }




    /*
     * returns true if a ticket exists for a user with the same games
     * */
    public static string ReceiptExists(string username, int[] gameNumbers)
    {
        DataTable bets = getUserBetReceiptsToday(username).Tables[0];
        if (bets.Rows.Count <= 0)
        {
            return "";
        }
        for (int num = 0; num < bets.Rows.Count; num++)
        {

            DataRow dataRow;
            dataRow = bets.Rows[num];
            int receiptid = Convert.ToInt16((dataRow["betid"]).ToString());
            string[] gameParam = new string[12];
            for (int i = 0; i < gameParam.Length; i++)
            {
                gameParam[i] = "@game" + (i + 1);
            }
            SqlParameter[] param = new SqlParameter[16];
            int count = 0;
            param[++count] = new SqlParameter("@query", RECEIPT_GAMES_CHECK);
            for (int i = 0; i < gameNumbers.Length; i++)
            {
                param[++count] = new SqlParameter(gameParam[i], gameNumbers[i]);
            }
            param[++count] = new SqlParameter("@username", username);
            param[++count] = new SqlParameter("@receiptid", receiptid);
            DataTable dt = dbBridge.ExecuteDataset(STORED_PROCEDURE, param).Tables[0];
            if (dt.Rows.Count == gameNumbers.Length)
            {
                DataRow dr;
                dr = dt.Rows[0];
                string betid = (dataRow["betid"]).ToString();
                return betid;
            }
        }
        return "";
    }

    public static int updateBettingLimit(float amount, int type)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", UPDATE_BETTING_LIMIT);
        param[1] = new SqlParameter("@amount", amount);
        param[2] = new SqlParameter("@type", type);
        return dbBridge.ExecuteNonQuery(STORED_PROCEDURE, param);
    }
    public static  int updateMinimumRecieptSize( string option, int type,int size)
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@query", UPDATE_MINIMUM_BETOPTION_SIZE);
        param[1] = new SqlParameter("@lowerlimit", size);
        param[2] = new SqlParameter("@type", type);
        param[3] = new SqlParameter("@tran_type", option);
        return dbBridge.ExecuteNonQuery(STORED_PROCEDURE, param);
    }
    public static float getBettingLimit(int type)
    {
        float limit = 50000;
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@query", UPDATE_BETTING_LIMIT);
        param[1] = new SqlParameter("@type", type);
        DataTable dataTable = dbBridge.ExecuteDataset(STORED_PROCEDURE, param).Tables[0];
        if (dataTable.Rows.Count > 0)
        {
            DataRow dataRow;
            dataRow = dataTable.Rows[0];
            try
            {
                limit = Convert.ToInt32((dataRow["limit"]).ToString());
            }
            catch (Exception e)
            {
                limit = 50000;
            }
        }
        return limit;
    }


    public static int updateReceiptGamesLimit(int value, int type)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", UPDATE_RECEIPT_GAMES_LIMIT);
        param[1] = new SqlParameter("@amount", value);
        param[2] = new SqlParameter("@type", type);
        return dbBridge.ExecuteNonQuery(STORED_PROCEDURE, param);
    }

    public static int getReceiptGamesLimit(int type)
    {
        int limit = 3;
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@query", UPDATE_RECEIPT_GAMES_LIMIT);
        param[1] = new SqlParameter("@type", type);
        DataTable dataTable = dbBridge.ExecuteDataset(STORED_PROCEDURE, param).Tables[0];
        if (dataTable.Rows.Count > 0)
        {
            DataRow dataRow;
            dataRow = dataTable.Rows[0];
            try
            {
                limit = Convert.ToInt32((dataRow["limit"]).ToString());
            }
            catch (Exception e)
            {
                limit = 50000;
            }
        }
        return limit;
    }

    public static int updateBettingOptions(string newValue)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@query", UPDATE_BETTING_OPTIONS);
        param[1] = new SqlParameter("@serial", newValue);
        return dbBridge.ExecuteNonQuery(STORED_PROCEDURE, param);
    }
    public static int updateBettingOptions(List<betoption> betoptions )
    {

        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", UPDATE_BETTING_OPTIONS1);
        int exec = 0;
        foreach (betoption option in betoptions)
        {
            param[1] = new SqlParameter("@type", option.optionid);
            param[2] = new SqlParameter("@betoptionstatus", option.status);
            exec += dbBridge.ExecuteNonQuery(STORED_PROCEDURE, param);
        }
        return exec;
    }

    public static string getBettingOptions()
    {
        string value = "";
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@query", UPDATE_BETTING_OPTIONS);
        DataTable dataTable = dbBridge.ExecuteDataset(STORED_PROCEDURE, param).Tables[0];
        if (dataTable.Rows.Count > 0)
        {
            DataRow dataRow;
            dataRow = dataTable.Rows[0];
            value = (dataRow["serial"]).ToString();
        }
        return value;
    }

    public static string getCurrentBettingOptions()
    {
        if (CurrentBettingOptions == null || CurrentBettingOptions == "")
        {
            CurrentBettingOptions = getBettingOptions();
        }
        return CurrentBettingOptions;
    }

    public static bool isActivated(int bettingType)
    {
        betoption bettingOption = BetOptions().Where(x => x.optionid ==(bettingType+1)).Single();
       return bettingOption.status;
        //switch (bettingType)
        //{
        //    case AdminClass.NORMAL_BET:
        //        if (bettingOption[AdminClass.NORMAL_BET] == '1')
        //        {
        //            return true;
        //        }
        //        break;
        //    case AdminClass.WIRE_BET:
        //        if (bettingOption[AdminClass.NORMAL_BET] == '1')
        //        {
        //            return true;
        //        }
        //        break;
        //    case AdminClass.DOUBLE_CHANCE_BET:
        //        if (bettingOption[AdminClass.DOUBLE_CHANCE_BET] == '1')
        //        {
        //            return true;
        //        }
        //        break;
        //    case AdminClass.HALF_TIME_BET:
        //        if (bettingOption[AdminClass.HALF_TIME_BET] == '1')
        //        {
        //            return true;
        //        }
        //        break;
        //    case AdminClass.HANDICAP_BET:
        //        if (bettingOption[AdminClass.HANDICAP_BET] == '1')
        //        {
        //            return true;
        //        }
        //        break;
        //    case AdminClass.ODD_EVEN_BET:
        //        if (bettingOption[AdminClass.ODD_EVEN_BET] == '1')
        //        {
        //            return true;
        //        }
        //        break;
        //}

        //return false;
    }
    public static List<betoption> BetOptions()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@query", SELECT_BETTING_OPTIONS);
        DataTable dataTable = dbBridge.ExecuteDataset(STORED_PROCEDURE, param).Tables[0];
        List<betoption> opt = null;
        if (dataTable.Rows.Count == 6)
        {         
              opt=new List<betoption>{
              new betoption{ minimumSize= Convert.ToInt16(dataTable.Rows[0].ItemArray[2]), optionid= Convert.ToInt16(dataTable.Rows[0].ItemArray[1]), status=Convert.ToBoolean (dataTable.Rows[0].ItemArray[3]), optionname= (dataTable.Rows[0].ItemArray[0]).ToString()} ,
              new betoption{ minimumSize= Convert.ToInt16(dataTable.Rows[1].ItemArray[2]), optionid= Convert.ToInt16(dataTable.Rows[1].ItemArray[1]), status=Convert.ToBoolean (dataTable.Rows[1].ItemArray[3]), optionname= (dataTable.Rows[1].ItemArray[0]).ToString()} ,
              new betoption{ minimumSize= Convert.ToInt16(dataTable.Rows[2].ItemArray[2]), optionid= Convert.ToInt16(dataTable.Rows[2].ItemArray[1]), status=Convert.ToBoolean (dataTable.Rows[2].ItemArray[3]), optionname= (dataTable.Rows[2].ItemArray[0]).ToString()} ,
              new betoption{ minimumSize= Convert.ToInt16(dataTable.Rows[3].ItemArray[2]), optionid= Convert.ToInt16(dataTable.Rows[3].ItemArray[1]), status=Convert.ToBoolean (dataTable.Rows[3].ItemArray[3]), optionname= (dataTable.Rows[3].ItemArray[0]).ToString()} ,
              new betoption{ minimumSize= Convert.ToInt16(dataTable.Rows[4].ItemArray[2]), optionid= Convert.ToInt16(dataTable.Rows[4].ItemArray[1]), status=Convert.ToBoolean (dataTable.Rows[4].ItemArray[3]), optionname= (dataTable.Rows[4].ItemArray[0]).ToString()} ,
              new betoption{ minimumSize= Convert.ToInt16(dataTable.Rows[5].ItemArray[2]), optionid= Convert.ToInt16(dataTable.Rows[5].ItemArray[1]), status=Convert.ToBoolean (dataTable.Rows[5].ItemArray[3]), optionname= (dataTable.Rows[5].ItemArray[0]).ToString()}               
              };
        }
        return opt;
    }
    #endregion
    #region update

    public static int AddAccountPayments(string username, int amount, int type, DateTime startDate, DateTime endDate)
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@query", type);
        param[1] = new SqlParameter("@username", username);
        param[2] = new SqlParameter("@amount", amount);
        param[3] = new SqlParameter("@DOT", startDate);
        param[4] = new SqlParameter("@DOT2", endDate);
        return dbBridge.ExecuteNonQuery(STORED_PROCEDURE, param);
    }


    public static int updateTotalOdd(int betid, float totalodd)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", TEST);
        param[1] = new SqlParameter("@betid", betid);
        param[2] = new SqlParameter("@totalodd", totalodd);
        return dbBridge.ExecuteNonQuery(STORED_PROCEDURE, param);
    }

    public static int cancelBetReceipt(int betid, string username)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", CANCEL_BET_RECEIPT);
        param[1] = new SqlParameter("@betid", betid);
        param[2] = new SqlParameter("@username", username);
        return dbBridge.ExecuteNonQuery(STORED_PROCEDURE, param);
    }

    public static int RemoveBetMatch(int betid, int matno, float totalOdd)
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@query", REMOVE_BET_MATCH);
        param[1] = new SqlParameter("@betid", betid);
        param[2] = new SqlParameter("@matchno", matno);
        param[3] = new SqlParameter("@setodd", totalOdd);
        return dbBridge.ExecuteNonQuery(STORED_PROCEDURE, param);
    }

    #endregion
    #region users

    public static int activateAccount(string username, int activateStatus)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", ACTVATE_ACCOUNT);
        param[1] = new SqlParameter("@username", username);
        param[2] = new SqlParameter("@activated", activateStatus);
        return dbBridge.ExecuteNonQuery(STORED_PROCEDURE, param);
    }
    public static int activateTransaction(int TransId , int activateStatus)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", ACTIVATE_TRANSACTION);
        param[1] = new SqlParameter("@TransId", TransId);
        param[2] = new SqlParameter("@GameStatus", activateStatus);
        return dbBridge.ExecuteNonQuery(STORED_PROCEDURE_1, param);
    }

    public static int getCustomerStatus(string username)
    {
        int value = 1;
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@query", ACTVATE_ACCOUNT);
        param[1] = new SqlParameter("@username", username);
        DataTable dataTable = dbBridge.ExecuteDataset(STORED_PROCEDURE, param).Tables[0];
        if (dataTable.Rows.Count > 0)
        {
            DataRow dataRow = dataTable.Rows[0];
            value = Convert.ToInt32((dataRow["activated"]).ToString());
        }
        return value;
    }

    public static string getBetStake(string betid)
    {
        string value = "0";
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@query", RECEIPT_BET_STAKE);
        param[1] = new SqlParameter("@betid", Convert.ToInt64(betid));
        DataTable dataTable = dbBridge.ExecuteDataset(STORED_PROCEDURE, param).Tables[0];
        if (dataTable.Rows.Count > 0)
        {
            DataRow dataRow = dataTable.Rows[0];
            value = (dataRow["stake"]).ToString();
        }
        return value;
    }

    public static int NewUser(string phone, string password)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", REGISTER_NEW_USER);
        param[1] = new SqlParameter("@username", phone);
        param[2] = new SqlParameter("@password", password);
        return dbBridge.ExecuteNonQuery(STORED_PROCEDURE, param);
    }


    public static int CancelPaymentRequest(int reqID, string username)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", CANCEL_PAYMENT_REQUEST);
        param[1] = new SqlParameter("@reqid", reqID);
        param[2] = new SqlParameter("@username", username);
        return dbBridge.ExecuteNonQuery(STORED_PROCEDURE, param);
    }

    public static DataSet SuperAdmninDetails()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@query", SUPER_ADMIN_DETAILS);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE, param);
    }
    #endregion
    #region datetime
    public static string[] getMonths()
    {
        return MONTH;
    }
    public static string getMonth(int mon)
    {
     
        return MONTH[mon-1];
    }

    public static string getMonthSqlValue(string month)
    {
        string[] m = getMonths();
        int i = 0;
        foreach (string s in m)
        {
            if (s == month)
            {
                i++;
                break;
            }
            i++;
        }
        if (i < 10)
            return "0" + i;
        else
            return "" + i;
    }

    public static int getMonthIndex(string month)
    {
        string[] m = getMonths();
        int i = 0;
        foreach (string s in m)
        {
            if (s == month)
            {
                return i;
            }
            i++;
        }
        return i;
    }

    public static string[] getYears()
    {
        DateTime date = DateTime.Today;
        return new string[] { date.AddYears(-1).Year.ToString(), date.Year.ToString() };
    }

    public static string[] getDays(int month)
    {
        int count = 31;
        /*
        if (month == 2)
        {
            count = 28;
            if (DateTime.IsLeapYear(year)) {
                count = 29;
            }
        }*/
         if ((month % 2 != 0 && month <= 6) || (month % 2 == 0 && month > 6))
        {
            count = 31;//TODO
        }
        string[] days = new string[count];
        for (int i = 0; i < count; i++)
        {
            days[i] = "" + (i + 1);
        }
        return days;
    }

    #endregion
    #region misc

    //TODO refine method
    public static DateTime getEndOfWeek()
    {
        DateTime endofweek = DateTime.Today;

        if (endofweek.DayOfWeek.ToString().ToLower() == "sunday")
        {
            return endofweek;
        }
        if (endofweek.DayOfWeek.ToString().ToLower() == "saturday")
        {
            return endofweek.AddDays(1);
        }
        if (endofweek.DayOfWeek.ToString().ToLower() == "friday")
        {
            return endofweek.AddDays(2);
        }
        if (endofweek.DayOfWeek.ToString().ToLower() == "thursday")
        {
            return endofweek.AddDays(3);
        }
        if (endofweek.DayOfWeek.ToString().ToLower() == "wednesday")
        {
            return endofweek.AddDays(4);
        }
        if (endofweek.DayOfWeek.ToString().ToLower() == "tuesday")
        {
            return endofweek.AddDays(5);
        }
        if (endofweek.DayOfWeek.ToString().ToLower() == "monday")
        {
            return endofweek.AddDays(6);
        }
        return endofweek;
    }
    public static DateTime getEndOfWeek(DateTime currentDate)
    {
        DateTime endofweek = currentDate;

        if (endofweek.DayOfWeek.ToString().ToLower() == "sunday")
        {
            return endofweek;
        }
        if (endofweek.DayOfWeek.ToString().ToLower() == "saturday")
        {
            return endofweek.AddDays(1);
        }
        if (endofweek.DayOfWeek.ToString().ToLower() == "friday")
        {
            return endofweek.AddDays(2);
        }
        if (endofweek.DayOfWeek.ToString().ToLower() == "thursday")
        {
            return endofweek.AddDays(3);
        }
        if (endofweek.DayOfWeek.ToString().ToLower() == "wednesday")
        {
            return endofweek.AddDays(4);
        }
        if (endofweek.DayOfWeek.ToString().ToLower() == "tuesday")
        {
            return endofweek.AddDays(5);
        }
        if (endofweek.DayOfWeek.ToString().ToLower() == "monday")
        {
            return endofweek.AddDays(6);
        }
        return endofweek;
    }
    public static string commaSeparate(string figure)
    {

        //reverse number
        char[] array = figure.ToCharArray();
        Array.Reverse(array);
        figure = new String(array);

        string text = "";
        //add commas foreach 3 characters from the right
        for (int i = figure.Length - 1; i >= 0; i--)
        {
            if (i % 3 == 0 && i != 0)
            {
                text = text + figure[i] + ",";
            }
            else
            {
                text = text + figure[i];
            }
        }

        return text;
    }

    public static bool SendVasMessage(string msg, string Destination_number)
    {
        try
        {
            log.Phoneno = Destination_number;
            log.Message = msg;
            log.MessageId = "GBEAL-SYSTEM" + DateTime.Now.ToString();
            log.source = "GBEAL-SYSTEM";
            log.recievedsms();//save outgoing message
            HttpWebRequest RequesttosendSms = (HttpWebRequest)WebRequest.Create("http://sms.vasgarage.ug/api/sendsms/?msg=" + msg + "&phone=" + Destination_number);
            HttpWebResponse ResponsetosendSms = (HttpWebResponse)RequesttosendSms.GetResponse();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    #endregion
    #region promo
    public static int saveSuggestedNumber(string userID, string phone)
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@query", SAVE_SUGGESTED_NUMBER);
        param[1] = new SqlParameter("@Mode", "null");
        param[2] = new SqlParameter("@userID", userID);
        param[3] = new SqlParameter("@suggestedPhone", phone);
        param[4] = new SqlParameter("@credit", getBettingPromoCredit());
        return dbBridge.ExecuteNonQuery(STORED_PROCEDURE_2, param);
    }

    public static int updatePromoBonus(string bonus, string activated)
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@query", UPDATE_PROMO_BONUS);
        param[1] = new SqlParameter("@Mode", "null");
        param[2] = new SqlParameter("@bonus", bonus);
        param[3] = new SqlParameter("@activated", activated);
        return dbBridge.ExecuteNonQuery(STORED_PROCEDURE_2, param);
    }

    public static decimal getBettingPromoCredit()
    {
        decimal value = 0;
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@query", BETTING_PROMO_CREDIT);
        DataTable dataTable = dbBridge.ExecuteDataset(STORED_PROCEDURE_2, param).Tables[0];
        if (dataTable.Rows.Count > 0)
        {
            DataRow dataRow = dataTable.Rows[0];
            value = Convert.ToDecimal((dataRow["credit"]).ToString());
        }
        return value;
    }

    public static string getBettingPromoStatus()
    {
        string value = "";
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@query", BETTING_PROMO_STATUS);
        DataTable dataTable = dbBridge.ExecuteDataset(STORED_PROCEDURE_2, param).Tables[0];
        if (dataTable.Rows.Count > 0)
        {
            DataRow dataRow = dataTable.Rows[0];
            value = (dataRow["value"]).ToString();
        }
        return value;
    }


    public static bool promoEntryExists(string userID, string phone)
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@query", CHECK_PROMO_ENTRY);
        param[1] = new SqlParameter("@Mode", null);
        param[2] = new SqlParameter("@userID", userID);
        param[3] = new SqlParameter("@suggestedPhone", phone);
        DataTable data = dbBridge.ExecuteDataset(STORED_PROCEDURE_2, param).Tables[0];
        if(data.Rows.Count > 0){
            return true;
        }
        return false;
    }

    public static bool suggestedEntryExists(string phone)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", CHECK_PROMO_SUGGESTED_NUMBER);
        param[1] = new SqlParameter("@Mode", null);
        param[2] = new SqlParameter("@suggestedPhone", phone);
        DataTable data = dbBridge.ExecuteDataset(STORED_PROCEDURE_2, param).Tables[0];
        if (data.Rows.Count > 0)
        {
            return true;
        }
        return false;
    }

    public static bool creditReccommendUser(string phone)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", CREDIT_RECCOMMEND_USER);
        param[1] = new SqlParameter("@Mode", null);
        param[2] = new SqlParameter("@suggestedPhone", phone);
        DataTable dataTable = dbBridge.ExecuteDataset(STORED_PROCEDURE_2, param).Tables[0];
        if (dataTable.Rows.Count > 0)
        {//send notification message...
            DataRow dataRow = dataTable.Rows[0];
            string p = (dataRow["phone"]).ToString();
            string cash = (dataRow["credit"]).ToString();
            string msg = "The user ("+phone+") you reccommended to Globalbets has placed their first bet. You have received a bonus betting credit of UGX "+cash+" for this! www.trustbets.ug";
            GlobalBetsAdmin.SendVasMessage(msg, p);
            return true;
        }
        return false;
    }


    public static void creditReccommendUser(DataTable dataTable)
    {
        string bettingBonus = ""+GlobalBetsAdmin.getBettingPromoCredit();
        foreach (DataRow row in dataTable.Rows)
        {

            int id = Convert.ToInt32((row["id"]).ToString());
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@query", CREDIT_RECCOMMEND_USER);
            param[1] = new SqlParameter("@Mode", null);
            param[2] = new SqlParameter("@id", id);
            int check = dbBridge.ExecuteNonQuery(STORED_PROCEDURE_2, param);
            if(check > 0){
                string msg = "Your betting account has been credited with a bonus of UGX "+bettingBonus;
                GlobalBetsAdmin.SendVasMessage(msg, row["phone"].ToString());
            }
        }
    }


    public static DataSet getPendingPromoCredit(DateTime startDate, DateTime endDate)
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@query", PENDING_PROMO_DATA);
        param[1] = new SqlParameter("@Mode", null);
        param[2] = new SqlParameter("@startDate", startDate);
        param[3] = new SqlParameter("@endDate", endDate);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE_2, param);
    }

    public static DataSet getPendingPromoCredit(string keyword)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", PENDING_PROMO_DATA);
        param[1] = new SqlParameter("@Mode", null);
        param[2] = new SqlParameter("@searchkeyword", keyword);
        return dbBridge.ExecuteDataset(STORED_PROCEDURE_2, param);
    }

    public static  int updateDisplayDays(int Days,string username)
    {
        
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@query", UpdateDisplayDays);
        param[1] = new SqlParameter("@Days", Days);
        param[2] = new SqlParameter("@controller",username);
        return dbBridge.ExecuteNonQuery(STORED_PROCEDURE, param);
    }

    public static int GetDisplayDays()
    {
        int days = 0;
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@query", DisplayDays);
        DataTable dt= dbBridge.ExecuteDataset(STORED_PROCEDURE, param).Tables[0];
        if (dt.Rows.Count > 0) {
         DataRow dr;
         dr = dt.Rows[0];
         days = Convert.ToInt16(dr["displaydays"]);    
         }
        return days; 
    }
    public static int GetSize(List<betoption> qry, int id)
    {
        int size = 0;
        for (int x = 0; x < qry.ToArray().Length; x++)
        {
            if (x == id - 1)
            {
                size = qry[x].minimumSize;
                return size;
            }
        }
            return size;
    }
    public static betoption Getoption(List<betoption> qry, int id)
    {
        betoption  betOption= null;
        for (int x = 0; x < qry.ToArray().Length; x++)
        {
            if (x == id - 1)
            {
                betOption = qry[x];
                return betOption;
            }
        }
        return betOption;
    }
    public class betoption {

        public bool status{get;set;}
        public int minimumSize { get; set; }
        public string optionname { get; set; }
        public int optionid { get; set; }
      
    
    }
    public static DataTable ProfitReport(DateTime StartDate, DateTime Enddate)
    {
 
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@startDate", StartDate);
        param[1] = new SqlParameter("@endDate", Enddate);
        DataTable dataTable = dbBridge.ExecuteDataset("MonthlyReport", param).Tables[0];
        return dataTable;
    }

    private const int SAVE_SUGGESTED_NUMBER = 1;
    private const int BETTING_PROMO_CREDIT = 2;
    private const int CHECK_PROMO_ENTRY = 3;
    private const int CHECK_PROMO_SUGGESTED_NUMBER = 4;
    private const int BETTING_PROMO_STATUS = 5;
    private const int PENDING_PROMO_DATA = 6;
    private const int CREDIT_RECCOMMEND_USER = 7;
    private const int UPDATE_PROMO_BONUS = 8;
    #endregion  
}