using System;
using System.Data;
using SRN.DAL;
using System.Data.SqlClient;
public class AdminClass
{
    public AdminClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region Variables
    DBBridge objDBBridge = new DBBridge();
    public const int NORMAL_BET = 0;
    public const int WIRE_BET = 1;
    public const int DOUBLE_CHANCE_BET = 2;
    public const int HALF_TIME_BET = 3;
    public const int HANDICAP_BET = 4;
    public const int ODD_EVEN_BET = 5;
    public const string ALL_GAMES = "All Games";
    public static DataSet fixtureData;
    protected int _loginId;
    protected string _loginName = String.Empty;
    protected string _email = String.Empty;
    protected string _username = String.Empty;
    protected string _password = String.Empty;
    protected string _league = String.Empty;
    protected string _matcode = String.Empty;
    protected string _visitor = String.Empty;
    protected string _away = String.Empty;
    protected string _bet_type = String.Empty;
    protected string _hotnews = String.Empty;
    protected string _headlines = String.Empty;
    protected int _rights;
    protected DateTime _betdate;
    protected DateTime _stime;
    protected string _category = String.Empty;
    protected string _country = String.Empty;
    protected string _oddname = String.Empty;
    protected string _host = String.Empty;
    protected string _team = String.Empty;
    protected string _teamid = String.Empty;
    protected string _leagueid = String.Empty;
    protected string _sourceapi = string.Empty;
    protected int _setno;
    protected long _matno;
    protected int _odd;
    protected int _drawcode;
    protected int _awaycode;
    protected int _homecode;
    protected int _handhome;
    protected int _codeno;
    protected decimal _overodd;
    protected decimal _hfhomeodd;
    protected decimal _hfdrawodd;
    protected decimal _hfawayodd;
    protected decimal _oddodd;
    protected decimal _oddeven;
    protected decimal _dchdodd;
    protected decimal _dcdaodd;
    protected decimal _dchaodd;
    protected decimal _underodd;
    protected decimal _hchomeodd;
    protected decimal _hcawayodd;
    protected decimal _hcdrawodd;
    protected string _recieptid;
    protected int _homescore;
    protected int _awayscore;
    protected string _resultstatus;
    protected string _choice;
    protected string _smscode;
    protected string _normalprediction;
    protected string _wireprediction;
    protected int _handaway;
    protected int _betid;
    protected int _ttrow;
    protected double _oddaway;
    protected double _oddhome;
    protected double _odddraw;
    protected DateTime _DOT;
    protected DateTime _DOT2;
    protected int _HomeTeamForm;
    protected int _HomeTeamH2H;
    protected int _HomeTeamHomeForm;
    protected int _HomeTeamLeagueRating;
    protected int _HomeRecentGame;
    protected int _HomeGoalsScored;
    protected int _AwayTeamForm;
    protected int _AwayTeamH2H;
    protected int _AwayLeagueRating;
    protected int _awayAwayForm;
    protected int _AwayRecentGames;
    protected int _AwayGoalsScored;
    protected int _LeagueTeamNumber;
    protected DataSet _dsLogin = new DataSet();
    const string _spName = "Sp_Admin";
    const string _spName1 = "NewRegModel";
    #endregion

    #region Class Property
    public int LoginId
    {
        get { return _loginId; }
        set { _loginId = value; }
    }
    public int betId
    {
        get { return _betid; }
        set { _betid= value; }
    }
    public int codeno
    {
        get { return _codeno; }
        set { _codeno= value; }
    }
    public int setno
    {
        get { return _setno; }
        set { _setno = value; }
    }
    public int ttrow {
        get { return _ttrow; }
        set { _ttrow = value; }
    
    }
    public int odd
    {
        get { return _odd; }
        set { _odd = value; }
    }

  
    public decimal underodd
    {
        get { return _underodd; }
        set { _underodd = value; }
    }
    public decimal hfhomeodd
    {
        get { return _hfhomeodd; }
        set { _hfhomeodd = value; }
    }
    public decimal hfdrawodd
    {
        get { return _hfdrawodd; }
        set { _hfdrawodd = value; }
    }
    public decimal hfawayodd
    {
        get { return _hfawayodd; }
        set { _hfawayodd = value; }
    }
    public decimal dchdodd
    {
        get { return _dchdodd; }
        set { _dchdodd = value; }
    }
    public decimal dcdaodd
    {
        get { return _dcdaodd; }
        set { _dcdaodd= value; }
    }
    public decimal dchaodd
    {
        get { return _dchaodd; }
        set {_dchaodd = value; }
    }
    public decimal hchomeodd
    {
        get { return _hchomeodd; }
        set { _hchomeodd = value; }
    }
    public decimal hcdrawodd
    {
        get { return _hcdrawodd; }
        set { _hcdrawodd = value; }
    }
    public string sourceapi {
        set { _sourceapi = value; }
        get { return _sourceapi; }
    
    
    }
    public DateTime DOT
    {
        get { return _DOT; }
        set { _DOT = value; }
    }
    public DateTime DOT2
    {
        get { return _DOT2; }
        set { _DOT2 = value; }
    }

    public decimal hcawayodd
    {
        get { return _hcawayodd; }
        set { _hcawayodd= value; }
    }
    public decimal oddodd
    {
        get { return _oddodd; }
        set { _oddodd= value; }
    }
    public decimal oddeven
    {
        get { return _oddeven; }
        set { _oddeven = value; }
    }
    public decimal overodd
    {
        get { return _overodd; }
        set { _overodd = value; }
    
    }
    protected int homescore {
        get { return _homescore; }
        set { _homescore = value; }
    
    }
    protected int awayscore {
        get { return _awayscore; }
        set { _awayscore = value; }
    
    }
    public int handhome
    {
        get { return  _handhome; }
        set { _handhome= value; }
    }
    public int handaway
    {
        get { return _handaway; }
        set { _handaway= value; }
    }
    public int awaycode
    {
        get { return _awaycode; }
        set { _awaycode = value; }
    }
    public int homecode
    {
        get { return _homecode; }
        set { _homecode = value; }
    }
    public int drawcode
    {
        get { return _drawcode; }
        set { _drawcode = value; }
    }
    public double oddhome
    {
        get { return _oddhome; }
        set { _oddhome= value; }
    }
    public double oddaway
    {
        get { return _oddaway; }
        set {_oddaway = value; }
    }
    public double odddraw
    {
        get { return _odddraw; }
        set { _odddraw = value; }
    }
    public long matno
    {
        get { return _matno; }
        set { _matno = value; }
    }
    public string LoginName
    {
        get { return _loginName; }
        set { _loginName = value; }
    }
    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }
    public string team
    {
        get { return _team; }
        set { _team = value; }
    }
    public string teamid
    {
        get { return _teamid; }
        set { _teamid = value; }
    }
    public string leagueid
    {
        get { return _leagueid; }
        set { _leagueid = value; }
    }
    public string headlines
    {
        get { return _headlines; }
        set { _headlines = value; }
    }
    public string smscodes
    {
        get { return _smscode; }
        set { _smscode = value; }
    }
    public string choice
    {
        get { return _choice; }
        set { _choice = value; }
    }
    public string hotnews
    {
        get { return _hotnews; }
        set { _hotnews = value; }
    }
    public string normalprediction
    {
        get { return _normalprediction; }
        set { _normalprediction = value; }
    }
    public string wireprediction
    {
        get { return _wireprediction; }
        set { _wireprediction = value; }
    }
    public string Username
    {
        get { return _username; }
        set { _username = value; }
    }

    public string RecieptId
    {
        get { return _recieptid; }
        set { _recieptid = value; }
    }
    public DateTime stime
    {
        get { return _stime; }
        set { _stime = value; }
    }
    public DateTime betdate
    {
        get { return _betdate; }
        set { _betdate = value; }
    }
    public string Password
    {
        get { return _password; }
        set { _password = value; }
    }
    public int Rights
    {
        get { return _rights; }
        set { _rights = value; }
    }
    public DataSet dsLogin
    {
        get { return _dsLogin; }
        set { _dsLogin = value; }
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
    public string category
    {
        get { return _category; }
        set { _category = value; }
    }
    public string country
    {
        get { return _country; }
        set { _country = value; }
    }
    public string league
    {
        get { return _league; }
        set { _league = value; }
    }
    public string bettype
    {
        get { return _bet_type; }
        set { _bet_type = value; }
    }
    public int LeagueTeamNumber
    {
        get { return _LeagueTeamNumber; }
        set { _LeagueTeamNumber = value; }
    }


    public int HomeTeamForm
    {
        get { return _HomeTeamForm; }
        set { _HomeTeamForm = value; }
    }
    public int HomeTeamH2H
    {
        get { return _HomeTeamH2H; }
        set { _HomeTeamH2H = value; }
    }
 
   
    public int HomeTeamHomeForm
    {
        get { return _HomeTeamHomeForm; }
        set { _HomeTeamHomeForm = value; }
    }
    public int HomeTeamLeagueRating
    {
        get { return _HomeTeamLeagueRating; }
        set { _HomeTeamLeagueRating = value; }
    }
    public int HomeRecentGame
    {
        get { return _HomeRecentGame; }
        set { _HomeRecentGame = value; }
    }
    public int HomeGoalsScored
    {
        get { return _HomeGoalsScored; }
        set { _HomeGoalsScored = value; }
    }
    public int AwayTeamForm
    {
        get { return _AwayTeamForm; }
        set { _AwayTeamForm = value; }
    }
    public int AwayTeamH2H
    {
        get { return _AwayTeamH2H; }
        set { _AwayTeamH2H = value; }
    }
    public int AwayLeagueRating
    {
        get { return _AwayLeagueRating; }
        set { _AwayLeagueRating = value; }
    }

    public int awayAwayForm
    {
        get { return _awayAwayForm; }
        set { _awayAwayForm = value; }
    }
    public int AwayRecentGames
    {
        get { return _AwayRecentGames; }
        set { _AwayRecentGames = value; }
    }
    public int AwayGoalsScored
    {
        get { return _AwayGoalsScored; }
        set { _AwayGoalsScored = value; }
    }
 

 
    #endregion

    #region Public Methods

    public int Insert()
    {
        SqlParameter[] param = new SqlParameter[6];
        param[0] = new SqlParameter("@Mode", "Insert");
        param[1] = new SqlParameter("@LoginName", _loginName);
        param[2] = new SqlParameter("@Email", _email);
        param[3] = new SqlParameter("@Username", _username);
        param[4] = new SqlParameter("@Password", _password);
        param[5] = new SqlParameter("@Rights", _rights);
        return objDBBridge.ExecuteNonQuery(_spName, param);
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
    public int Delete()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "Delete");
        param[1] = new SqlParameter("@LoginId", _loginId.ToString());
        return objDBBridge.ExecuteNonQuery(_spName, param);
    }
    public DataSet getallsms() {
        SqlParameter[] par = new SqlParameter[3];
        par[0] = new SqlParameter("@mode", "ViewAllSms");
        par[1] = new SqlParameter("Dot",_DOT.ToShortDateString());
        par[2] = new SqlParameter("Dot2",_DOT2);
        return objDBBridge.ExecuteDataset(_spName, par); 
    }
    public DataSet getallsmsbyapi()
    {
        SqlParameter[] par = new SqlParameter[4];
        par[0] = new SqlParameter("@mode", "ViewAllSmsbyapi");
        par[1] = new SqlParameter("@Dot", _DOT.ToShortDateString());
        par[2] = new SqlParameter("@Dot2", _DOT2);
        par[3] = new SqlParameter("@sourceapi",_sourceapi );
        return objDBBridge.ExecuteDataset(_spName, par);
    }
	
	public DataSet getMM(string msgid)
    {
        SqlParameter[] par = new SqlParameter[2];
        par[0] = new SqlParameter("@Mode", "getMM");
		par[1] = new SqlParameter("@username", msgid);
        return objDBBridge.ExecuteDataset(_spName, par);
    }
	
    public int countsmsbyapi()
    {
        int totalsms = 0;
        SqlParameter[] par = new SqlParameter[4];
        par[0] = new SqlParameter("@mode", "CountSmsbyapi");
        par[1] = new SqlParameter("@Dot", _DOT.ToShortDateString());
        par[2] = new SqlParameter("@Dot2", _DOT2);
        par[3] = new SqlParameter("@sourceapi", _sourceapi);
        DataTable dt = new DataTable();
        dt= objDBBridge.ExecuteDataset(_spName, par).Tables[0];
        if (dt.Rows.Count > 0) { 
            DataRow dr;
            dr=dt.Rows[0];
            totalsms =Convert.ToInt32( dr["totalsms"]);
        }
        return totalsms;
    }
    public DataSet PendingPayments()
    {
        SqlParameter[] par = new SqlParameter[1];
        par[0] = new SqlParameter("@mode", "PendingPayment");    
        return objDBBridge.ExecuteDataset(_spName, par);
    }
    public DataSet getmobilemoneysms()
    {
        SqlParameter[] par = new SqlParameter[3];
        par[0] = new SqlParameter("@mode", "ViewmmSms");
        par[1] = new SqlParameter("Dot", _DOT.ToShortDateString());
        par[2] = new SqlParameter("Dot2", _DOT2);
        return objDBBridge.ExecuteDataset(_spName, par);
    }
    public int DeleteLeague()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "Deleteleague");
        param[1] = new SqlParameter("@LeagueId",_leagueid);
        return objDBBridge.ExecuteNonQuery(_spName, param);
    }

    public DataSet SelectAll()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "View");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet ViewSure()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "Viewsure");
        return objDBBridge.ExecuteDataset(_spName, param);       
    }
    public DataSet Comments()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "Comments");
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet getplayerbetids()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Username", _username);
        param[1] = new SqlParameter("@Mode", "getplayerbetids");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet SortPendingbets(string Sort)
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@DOT", DOT.ToShortDateString());
        param[1] = new SqlParameter("@DOT2", DOT2.ToShortDateString());
        param[2] = new SqlParameter("@Mode", "getsortedPendingBets");
        param[3] = new SqlParameter("@Sort", Sort);
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet getagentbetids()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Username", _username);
        param[1] = new SqlParameter("@Mode", "getagentbetids");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet getallagentbetids()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "getallagentbetids");
        param[1] = new SqlParameter("@dot", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@dot2", _DOT2);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet AdminTransactionsbd()
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@username", _username);
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2);
        param[3] = new SqlParameter("@Mode", "AdminTransactionsbd");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet GetAllAdminTransactions()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@username", _username);
        param[1] = new SqlParameter("@mode", "AdminTransactions");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet getsummaryagentbets()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "getallagentbetsbydate");
        param[1] = new SqlParameter("@dot", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@dot2", _DOT2);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet getsummaryagentbetsPending()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "getallagentbetsbydate");
        param[1] = new SqlParameter("@dot", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@dot2", _DOT2);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet getgamedetails()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@MatchNo", _matno);
        param[1] = new SqlParameter("@Mode", "Gamedetails");
    
        return objDBBridge.ExecuteDataset(_spName1, param);
    }

    /*
     * search matches byt keyword.
     * @param keyword the text to search database against
     * @param betType the type of bet e.g AdminClass.NORMAL_BET
     */
    public DataSet search(string keyword, int betType)
    {
        string mode = "search";
        switch(betType)
        {
            case NORMAL_BET:
                mode = "search";
                break;
            case WIRE_BET:
                mode = "searchwire";
                break;
            case DOUBLE_CHANCE_BET:
                mode = "searchdc";
                break;
            case HALF_TIME_BET:
                mode = "searchht";
                break;
            case HANDICAP_BET:
                mode = "searchhc";
                break;
            case ODD_EVEN_BET:
                mode = "searchevenodd";
                break;
        }

        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@keyword", keyword);
        param[1] = new SqlParameter("@Mode", mode);
        return objDBBridge.ExecuteDataset(_spName1, param);
    }

    public int  getgamedetailsbytype()
    {
        int counts = 0;
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@MatchNo", _matno);
        param[1] = new SqlParameter("@bet_type", _bet_type);
        param[2] = new SqlParameter("@Mode", "Gamedetailsbyodd");
        param[3] = new SqlParameter("@oddname", _choice);
        DataTable dt = new DataTable();
        dt = objDBBridge.ExecuteDataset(_spName1, param).Tables[0];
        DataRow dr;
        if (dt.Rows.Count > 0) {
            dr = dt.Rows[0];
           counts=Convert.ToInt32(dr["counts"]);      
        }
        return counts;
    }
    public DataSet getbetsbyteam()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "getbetsbyteam");
        param[1] = new SqlParameter("@dot", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@dot2", _DOT2);
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public int InsertLeague(string league, string country)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "Insert_League");
        param[1] = new SqlParameter("@league", league);
        param[2] = new SqlParameter("@country", country);

        return objDBBridge.ExecuteNonQuery(_spName, param);
    }

    public int InsertMatch(string goalserveID)
    {
        SqlParameter[] param = new SqlParameter[26];
        param[0] = new SqlParameter("@bet_type", _bet_type);
        param[1] = new SqlParameter("@champ", _league);
        param[2] = new SqlParameter("@MatchNo", _matno);
        param[3] = new SqlParameter("@host", _host);
        param[4] = new SqlParameter("@visitor", _visitor);
        param[5] = new SqlParameter("@StartTime", _stime);
        param[6] = new SqlParameter("@oddhome", _oddhome);
        param[7] = new SqlParameter("@oddaway", _oddaway); ;
        param[8] = new SqlParameter("@odddraw", _odddraw);
        param[9] = new SqlParameter("@underodd", _underodd);
        param[10] = new SqlParameter("@overodd", _overodd);
        param[11] = new SqlParameter("@setno", _setno);
        param[12] = new SqlParameter("@dchd", _dchdodd);
        param[13] = new SqlParameter("@dcda", _dcdaodd); ;
        param[14] = new SqlParameter("@dcha", _dchaodd);
        param[15] = new SqlParameter("@oddodd", _oddodd.ToString());
        param[16] = new SqlParameter("@oddeven", _oddeven.ToString());
        param[17] = new SqlParameter("@hfhome", _hfhomeodd);
        param[18] = new SqlParameter("@hfdraw", _hfdrawodd);
        param[19] = new SqlParameter("@hfaway", _hfawayodd);
        param[20] = new SqlParameter("@hchomegoals", _handhome);
        param[21] = new SqlParameter("@hcawaygoals", _handaway);
        param[22] = new SqlParameter("@hchomeodd", _hchomeodd);
        param[23] = new SqlParameter("@hcdrawodd", _hcdrawodd);
        param[24] = new SqlParameter("@hcawayodd", _hcawayodd);
        param[25] = new SqlParameter("@goalserveID", goalserveID);
        return objDBBridge.ExecuteNonQuery("InsertGame_GoalServe", param);
    }

    public DataSet getGoalServeGame(string goalserveID)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "matchbygoalserveID");
        param[1] = new SqlParameter("@goalserveID", "goalserveID");
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet getagentbetidbd()
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Username", _username);
        param[1] = new SqlParameter("@Mode", "getagentbetidbd");
        param[2] = new SqlParameter("Dot", _DOT.ToShortDateString());
        param[3] = new SqlParameter("Dot2", _DOT2);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
   
    public DataSet getagentbetidset()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@betid",_betid);
        param[1] = new SqlParameter("@Mode", "getagentbetidset");
       
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet getmatchodds(int _matchno)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@_matchno", _matchno);
        param[1] = new SqlParameter("@Mode", "matchodds");
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet getRecieptDetail()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@betid", _recieptid);
        param[1] = new SqlParameter("@Mode", "getagentbetidset");

        return objDBBridge.ExecuteDataset(_spName, param);
    }
   
    public DataSet getbetidsbydate()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[1] = new SqlParameter("@DOT2", _DOT2);
        param[2] = new SqlParameter("@Mode", "getbetidsbydate");
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet getbetidsbydateSMS()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[1] = new SqlParameter("@DOT2", _DOT2);
        param[2] = new SqlParameter("@Mode", "getbetidsbydateSMS");
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet getbetidsbydateONLINE()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[1] = new SqlParameter("@DOT2", _DOT2);
        param[2] = new SqlParameter("@Mode", "getbetidsbydateONLINE");
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet getAllPendingbets()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@DOT", DOT);
        param[1] = new SqlParameter("@DOT2", DOT2);
        param[2] = new SqlParameter("@Mode", "getAllPendingBets");
        return objDBBridge.ExecuteDataset("PendingBets", param);
    }
	
	public DataSet getAllCompletebets()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Dot", DOT);
        param[1] = new SqlParameter("@Dot2", DOT2);
        param[2] = new SqlParameter("@Mode", "getAllCompleteBets");
        return objDBBridge.ExecuteDataset(_spName, param);
    }


    public DataSet getbetidsbydateSMSPending()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[1] = new SqlParameter("@DOT2", _DOT2);
        param[2] = new SqlParameter("@Mode", "getbetidsbydateSMSPending");
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet getbetidsbydateONLINEPending()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[1] = new SqlParameter("@DOT2", _DOT2);
        param[2] = new SqlParameter("@Mode", "getbetidsbydateONLINEPending");
        return objDBBridge.ExecuteDataset(_spName, param);
    }


    public DataSet getplayerbets()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@betid",_betid);
        param[1] = new SqlParameter("@Mode", "getplayerbets");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public int getbetpredictions()
    {
        int win = 0;
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@betid", _betid);
        param[1] = new SqlParameter("@Mode", "getplayerbets");
        DataTable dt = new DataTable();
       dt=objDBBridge.ExecuteDataset(_spName, param).Tables[0];
       if (dt.Rows.Count > 0) {
           for (int i = 0; i < dt.Rows.Count; i++)
           {
               DataRow drLogin;
               drLogin = dt.Rows[i];
              _bet_type= drLogin["bet_type"].ToString().Trim().ToLower();
              _wireprediction = drLogin["wireprediction"].ToString().Trim();
              _normalprediction = drLogin["normalprediction"].ToString().Trim();
               _oddname = drLogin["oddname"].ToString().Trim().ToLower();
               if (_bet_type == "straight") {
                   if (_oddname == _normalprediction) {

                       win += 1;
                   }
               }
               if (_bet_type == "dc")
               {
                   if (_oddname == "1x") {
                       if ((_normalprediction == "home") || (_normalprediction == "draw")) {
                           win += 1;
                       }                 
                   }
                   if (_oddname == "2x")
                   {
                       if ((_normalprediction == "draw") || (_normalprediction == "away"))
                       {
                           win += 1;
                       }
                   }
                   if (_oddname == "12")
                   {
                       if ((_normalprediction == "home") || (_normalprediction == "away"))
                       {
                           win += 1;
                       }
                   }
                   
               }
               if (_bet_type == "wire")
               {
                   if (_oddname ==_wireprediction)
                   {

                       win += 1;
                   }
               }
           }
       }
       return win;
    }
    public DataSet getrecieptbets()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@betid", _recieptid);
        param[1] = new SqlParameter("@Mode", "getplayerbets");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet getallagentbetsbydate()
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@betid", _betid);
        param[1] = new SqlParameter("@Mode", "getallagentbetsbydate");
        param[2] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[3] = new SqlParameter("@DOT2", _DOT2);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public string SelectLeaguebyGame()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "Leaguegame");
        DataTable dt = new DataTable();
        dt = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        string LeagueTeams = "";
        if(dt.Rows.Count!=0){
            for (int i = 0; i < dt.Rows.Count;i++)
            {
                DataRow dr;
                dr = dt.Rows[i];
                LeagueTeams += dr[1].ToString()+";";

            }
        }
        return LeagueTeams;
    }
    
    public void SelectById()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "ViewByID");
        param[1] = new SqlParameter("@LoginId", _loginId.ToString());
        DataTable dtUser = new DataTable();
        dtUser = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtUser.Rows.Count != 0)
        {
            DataRow drLogin;
            drLogin = dtUser.Rows[0];
            _loginName = drLogin["LoginName"].ToString();
            _email = drLogin["Email"].ToString();
            _username = drLogin["Username"].ToString();
            _password = drLogin["Password"].ToString();
            _rights = Convert.ToInt32(drLogin["Rights"].ToString());
        }
    }
    public int  Selecttotalbets()
    {
        int total = 0;
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "countbetidsbydate");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2);
        DataTable dtUser = new DataTable();
        dtUser = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtUser.Rows.Count != 0)
        {
            DataRow drLogin;
            drLogin = dtUser.Rows[0];
            total= Convert.ToInt32(drLogin["totalbets"]);
       
        }
        return total;
    }
    public int SetPrediction()
    {
        int total = 0;
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "SetPrediction");
        param[1] = new SqlParameter("@betid",_betid);
   
        DataTable dtUser = new DataTable();
        dtUser = objDBBridge.ExecuteDataset(_spName1, param).Tables[0];
        if (dtUser.Rows.Count != 0)
        {
            DataRow drLogin;
            drLogin = dtUser.Rows[0];
            total = Convert.ToInt32(drLogin["correct"]);

        }
        return total;
    }
    public int getSetPrediction()
    {
        int total = 0;
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "SetPrediction");
        param[1] = new SqlParameter("@betid", _betid);

        DataTable dtUser = new DataTable();
        dtUser = objDBBridge.ExecuteDataset(_spName1, param).Tables[0];
        if (dtUser.Rows.Count != 0)
        {
            DataRow drLogin;
            drLogin = dtUser.Rows[0];
            total = Convert.ToInt32(drLogin["correct"]);

        }
        return total;
    }
    public void News()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "headline");

        DataTable dtUser = new DataTable();
        dtUser = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtUser.Rows.Count != 0)
        {
            DataRow drLogin;
            drLogin = dtUser.Rows[0];
            _hotnews = drLogin["news"].ToString();
            _headlines = drLogin["headline"].ToString();

        }
    }




    public DataTable ValidateLogin()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "ChkLogin");
        param[1] = new SqlParameter("@Username", _username);
        param[2] = new SqlParameter("@Password", _password);
        return objDBBridge.ExecuteDataset(_spName, param).Tables[0];
    }
    public DataSet matchesbyleague()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "gamebyleague");
        param[1] = new SqlParameter("@league", league);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataTable checkuser()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "ChkLogin");
        param[1] = new SqlParameter("@Username", _username);
        return objDBBridge.ExecuteDataset(_spName, param).Tables[0];
    }
    public int InsertBetresults()
    {
        SqlParameter[] param = new SqlParameter[9];
        param[0] = new SqlParameter("@Mode", "betresults1");
        param[1] = new SqlParameter("@category", _category);
        param[2] = new SqlParameter("@Email", _email);
        param[3] = new SqlParameter("@MatchNo", _matno);
        param[4] = new SqlParameter("@host", _host);
        param[5] = new SqlParameter("@visitor", _visitor);
        param[6] = new SqlParameter("@odd", _odd);
        param[7] = new SqlParameter("@oddname", _oddname);
        param[8] = new SqlParameter("@StartTime", _stime);
        return objDBBridge.ExecuteNonQuery(_spName, param);
    }
    public int InsertMatch()
    {
        SqlParameter[] param = new SqlParameter[27];
        param[0] = new SqlParameter("@Mode", "InsertGame");
        param[1] = new SqlParameter("@bet_type", _bet_type);
        param[2] = new SqlParameter("@champ", _league);
        param[3] = new SqlParameter("@MatchNo", _matno);
        param[4] = new SqlParameter("@host", _host);
        param[5] = new SqlParameter("@visitor", _visitor);    
        param[6] = new SqlParameter("@StartTime", _stime);
        param[7] = new SqlParameter("@sttime", _stime);
        param[8] = new SqlParameter("@oddhome",_oddhome);
        param[9] = new SqlParameter("@oddaway", _oddaway); ;
        param[10] = new SqlParameter("@odddraw", _odddraw);
        param[11] = new SqlParameter("@underodd", _underodd);
        param[12] = new SqlParameter("@overodd", _overodd);
        param[13] = new SqlParameter("@setno", _setno);
         param[14] = new SqlParameter("@dchd",_dchdodd);
        param[15] = new SqlParameter("@dcda", _dcdaodd); ;
        param[16] = new SqlParameter("@dcha", _dchaodd);
        param[17] = new SqlParameter("@oddodd", _oddodd.ToString());
        param[18] = new SqlParameter("@oddeven", _oddeven.ToString());
         param[19] = new SqlParameter("@hfhome", _hfhomeodd);
         param[20] = new SqlParameter("@hfdraw", _hfdrawodd);
        param[21] = new SqlParameter("@hfaway", _hfawayodd);
        param[22] = new SqlParameter("@hchomegoals", _handhome);
        param[23] = new SqlParameter("@hcawaygoals", _handaway);
        param[24] = new SqlParameter("@hchomeodd", _hchomeodd);
        param[25] = new SqlParameter("@hcdrawodd", _hcdrawodd);
        param[26] = new SqlParameter("@hcawayodd",_hcawayodd);
        return objDBBridge.ExecuteNonQuery(_spName, param);
    }
    public int InsertAnalysis()
    {
        SqlParameter[] param = new SqlParameter[17];
        param[0] = new SqlParameter("@Mode", "InsertAnalysisData");
        param[1] = new SqlParameter("@HomeTeamForm", _HomeTeamForm);
        param[2] = new SqlParameter("@HomeTeamH2H", _HomeTeamH2H);
        param[3] = new SqlParameter("@MatchNo", _matno);
        param[4] = new SqlParameter("@HomeTeamHomeForm", _HomeTeamHomeForm);
        param[5] = new SqlParameter("@HomeTeamLeagueRating", _HomeTeamLeagueRating);
        param[6] = new SqlParameter("@HomeRecentGame", _HomeRecentGame);
        param[7] = new SqlParameter("@HomeGoalsScored", _HomeGoalsScored);
        param[8] = new SqlParameter("@AwayTeamForm", _AwayTeamForm);
        param[9] = new SqlParameter("@AwayTeamH2H", _AwayTeamH2H);
        param[10] = new SqlParameter("@AwayLeagueRating",_AwayLeagueRating);
        param[11] = new SqlParameter("@awayAwayForm", _awayAwayForm);
        param[12] = new SqlParameter("@AwayRecentGames", _AwayRecentGames);
        param[13] = new SqlParameter("@AwayGoalsScored", _AwayGoalsScored);
        param[14] = new SqlParameter("@NormalPrediction", getNormalPrediction());
        param[15] = new SqlParameter("@WirePrediction", getWirePrediction());
        param[16] = new SqlParameter("@LeagueTeamNumber",_LeagueTeamNumber);
        return objDBBridge.ExecuteNonQuery(_spName, param);
    }
    public int UpdateAnalysis()
    {
        SqlParameter[] param = new SqlParameter[17];
        param[0] = new SqlParameter("@Mode", "UpdateAnalysisData");
        param[1] = new SqlParameter("@HomeTeamForm", _HomeTeamForm);
        param[2] = new SqlParameter("@HomeTeamH2H", _HomeTeamH2H);
        param[3] = new SqlParameter("@MatchNo", _matno);
        param[4] = new SqlParameter("@HomeTeamHomeForm", _HomeTeamHomeForm);
        param[5] = new SqlParameter("@HomeTeamLeagueRating", _HomeTeamLeagueRating);
        param[6] = new SqlParameter("@HomeRecentGame", _HomeRecentGame);
        param[7] = new SqlParameter("@HomeGoalsScored", _HomeGoalsScored);
        param[8] = new SqlParameter("@AwayTeamForm", _AwayTeamForm);
        param[9] = new SqlParameter("@AwayTeamH2H", _AwayTeamH2H);
        param[10] = new SqlParameter("@AwayLeagueRating", _AwayLeagueRating);
        param[11] = new SqlParameter("@awayAwayForm", _awayAwayForm);
        param[12] = new SqlParameter("@AwayRecentGames", _AwayRecentGames);
        param[13] = new SqlParameter("@AwayGoalsScored", _AwayGoalsScored);
        param[14] = new SqlParameter("@NormalPrediction", getNormalPrediction());
        param[15] = new SqlParameter("@WirePrediction", getWirePrediction());
        param[16] = new SqlParameter("@LeagueTeamNumber", _LeagueTeamNumber);
        return objDBBridge.ExecuteNonQuery(_spName, param);
    }
	
	public decimal getVariance(int matno){
		decimal variance=-1;
		if(getAnalysisDetails(matno)){
			string prediction="";
			decimal hometeamtotal = 0, awayteamtotal = 0;
			decimal homerating, awayrating = 0;
			hometeamtotal = _HomeTeamForm + HomeTeamHomeForm + HomeTeamH2H;
			awayteamtotal = _awayAwayForm + AwayTeamH2H + AwayTeamForm;
			if ((_LeagueTeamNumber != 0) && (_HomeTeamLeagueRating != 0) && (_AwayLeagueRating != 0)) {
				homerating = ((_LeagueTeamNumber - _HomeTeamLeagueRating) / (_LeagueTeamNumber - 2))*100;
				awayrating = ((_LeagueTeamNumber - _AwayLeagueRating) / (_LeagueTeamNumber - 2))*100;
				hometeamtotal = hometeamtotal + homerating;
				awayteamtotal = awayteamtotal + awayrating;
			}
			//(([HomeTeamForm]+[HomeH2H]+[HomeHomeForm]+[HomeLeagueRating]) - ([AwayTeamForm]+[AwayH2H]+[AwayAwayForm]+[AwayLeagueRating]) )
			variance = hometeamtotal - awayteamtotal;
		}
		return variance;
	}
	
    private string getNormalPrediction() {
        string prediction="";
        decimal hometeamtotal = 0, awayteamtotal = 0,variance=0;
        decimal homerating, awayrating = 0;
        hometeamtotal = _HomeTeamForm + HomeTeamHomeForm + HomeTeamH2H;
        awayteamtotal = _awayAwayForm + AwayTeamH2H + AwayTeamForm;
        if ((_LeagueTeamNumber != 0) && (_HomeTeamLeagueRating != 0) && (_AwayLeagueRating != 0)) {
            homerating = ((_LeagueTeamNumber - _HomeTeamLeagueRating) / (_LeagueTeamNumber - 2))*100;
            awayrating = ((_LeagueTeamNumber - _AwayLeagueRating) / (_LeagueTeamNumber - 2))*100;
            hometeamtotal = hometeamtotal + homerating;
            awayteamtotal = awayteamtotal + awayrating;
        }
		//(([HomeTeamForm]+[HomeH2H]+[HomeHomeForm]+[HomeLeagueRating]) - ([AwayTeamForm]+[AwayH2H]+[AwayAwayForm]+[AwayLeagueRating]) )
        variance = hometeamtotal - awayteamtotal;
        if (variance >= 10) {
            prediction = "home";
        }
        if ((variance >= 6)&&(variance < 10))
        {

            prediction = "1x";
        }
        if ((variance >= -5) && (variance < 6))
        {

            prediction = "Draw";
        }
        if ((variance >= -10) && (variance < -5))
        {

            prediction = "x2";
        }
        else if (variance < -10)
        {

            prediction = "away";
        }
        
       return prediction;
    
    }
    public string getWirePrediction() {
        string prediction;
        double avghomegoals = _HomeGoalsScored / _HomeRecentGame;
        double avgawaygoals = _AwayGoalsScored / _AwayRecentGames;
        double avggoals = (avgawaygoals + avghomegoals)/2;
        if (avggoals >= 3)
        {
            prediction = "over";
        }
        else if (avggoals <3)
        {
            prediction = "under";
        }
        else {
            prediction = "nobet";
        }
        return prediction;
    
    }
    public int updatematch()
    {
        SqlParameter[] param = new SqlParameter[27];
        param[0] = new SqlParameter("@Mode", "updategame");
        param[1] = new SqlParameter("@bet_type", _bet_type);
        param[2] = new SqlParameter("@champ", _league);
        param[3] = new SqlParameter("@MatchNo", _matno);
        param[4] = new SqlParameter("@host", _host);
        param[5] = new SqlParameter("@visitor", _visitor);
        param[6] = new SqlParameter("@StartTime", _stime);
        param[7] = new SqlParameter("@sttime", _stime);
        param[8] = new SqlParameter("@oddhome", _oddhome);
        param[9] = new SqlParameter("@oddaway", _oddaway); ;
        param[10] = new SqlParameter("@odddraw", _odddraw);
        param[11] = new SqlParameter("@underodd", _underodd);
        param[12] = new SqlParameter("@overodd", _overodd);
        param[13] = new SqlParameter("@setno", _setno);
        param[14] = new SqlParameter("@dchd", _dchdodd);
        param[15] = new SqlParameter("@dcda", _dcdaodd); ;
        param[16] = new SqlParameter("@dcha", _dchaodd);
        param[17] = new SqlParameter("@oddodd", _oddodd.ToString());
        param[18] = new SqlParameter("@oddeven", _oddeven.ToString());
        param[19] = new SqlParameter("@hfhome", _hfhomeodd);
        param[20] = new SqlParameter("@hfdraw", _hfdrawodd);
        param[21] = new SqlParameter("@hfaway", _hfawayodd);
        param[22] = new SqlParameter("@hchomegoals", _handhome);
        param[23] = new SqlParameter("@hcawaygoals", _handaway);
        param[24] = new SqlParameter("@hchomeodd", _hchomeodd);
        param[25] = new SqlParameter("@hcdrawodd", _hcdrawodd);
        param[26] = new SqlParameter("@hcawayodd", _hcawayodd);
        return objDBBridge.ExecuteNonQuery(_spName, param);
    }
    public int saveTeamcodes()
    {
        
            SqlParameter[] dtm = new SqlParameter[11];

            dtm[0] = new SqlParameter("@league", _league);
            dtm[1] = new SqlParameter("@MatchCode", _matno);
            dtm[2] = new SqlParameter("@home", _host);
            dtm[3] = new SqlParameter("@away", _visitor);
            dtm[4] = new SqlParameter("@homeodd", _oddhome);
            dtm[5] = new SqlParameter("@awayodd", _oddaway);
            dtm[6] = new SqlParameter("@drawodd", _odddraw);
            dtm[7] = new SqlParameter("@homecode", _homecode);
            dtm[8] = new SqlParameter("@awaycode", _awaycode);
            dtm[9] = new SqlParameter("@drawcode", _drawcode);
            dtm[10] = new SqlParameter("@startTime", _stime);
            return objDBBridge.ExecuteNonQuery("SaveTeamcode", dtm);
            
        
       
    }

    public DataSet activeGames()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "testmatch");
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public int savesmscodes()
    {

        SqlParameter[] dtm = new SqlParameter[5];
        dtm[0] = new SqlParameter("@MatchNo", _matno);
        dtm[1] = new SqlParameter("@bet_type",_bet_type);
        dtm[2] = new SqlParameter("@choice", _choice);
        dtm[3] = new SqlParameter("@Teamcode", _smscode);
        dtm[4] = new SqlParameter("@mode","Insertsmscode");
        return objDBBridge.ExecuteNonQuery(_spName, dtm);


    }
    public int updatesmscodes()
    {
        return objDBBridge.ExecuteNonQuery("GenerateSmsCode");
    }
    public int InsertLeague()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "Insert_League");
        param[1] = new SqlParameter("@league", _league);
        param[2] = new SqlParameter("@country", _country);

        return objDBBridge.ExecuteNonQuery(_spName, param);
    }

    public int UpdateLeague()
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Mode", "Update_League");
        param[1] = new SqlParameter("@league", _league);
        param[2] = new SqlParameter("@country", _country);
        param[3] = new SqlParameter("@LeagueId", _leagueid);
        return objDBBridge.ExecuteNonQuery(_spName, param);
    }

    public DataSet Selectleague()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "Select_League");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet fixtures()
    {
        if (fixtureData == null)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Mode", "fixtures");
            fixtureData = new DBBridge().ExecuteDataset(_spName1, param);
        }
        return fixtureData;
    }

    public DataSet Selectbetmatches()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "Selectbetmatches");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet SelectNormalSmsOdd()
    {
        return objDBBridge.ExecuteDataset("SmsNormalOdds");
    }

    public DataSet Selectbetmatches(string country)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "Selectbetmatches_country");
        param[1] = new SqlParameter("@current_country", country);
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    /*
     * search matches by country name.
     * @param country the country name to search database against
     * @param betType the type of bet e.g AdminClass.NORMAL_BET
     */
    public DataSet searchByCountry(string country, int betType)
    {
        string mode = "c_normal";
        switch (betType)
        {
            case NORMAL_BET:
                mode = "c_normal";
                break;
            case WIRE_BET:
                mode = "c_wire";
                break;
            case DOUBLE_CHANCE_BET:
                mode = "c_dc";
                break;
            case HALF_TIME_BET:
                mode = "c_ht";
                break;
            case HANDICAP_BET:
                mode = "c_hc";
                break;
            case ODD_EVEN_BET:
                mode = "c_evenodd";
                break;
        }

        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@current_country", country);
        param[1] = new SqlParameter("@Mode", mode);
        return objDBBridge.ExecuteDataset(_spName1, param);
    }

    public DataSet SelectbetmatchesLeague(string league)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "Selectbetmatches_league");
        param[1] = new SqlParameter("@current_league", league);
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet SelectAllCountries()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "Selectallcountries");
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet SelectTopLeagues()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "Selecttopleagues");
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet AdminSelectbetmatches()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "AdminSelectmatches");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet Selectallbetmatches()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "Selectallbetmatches");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet playedmatches()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "playedgame");
        param[1] = new SqlParameter("@DOT", DOT);
        param[2] = new SqlParameter("@DOT2", DOT2);
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet postmatches()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "postgame");
        param[1] = new SqlParameter("@DOT", DOT);
        param[2] = new SqlParameter("@DOT2", DOT2);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet GameCancelingList()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "GameCancelingList");
        param[1] = new SqlParameter("@DOT", DOT);
        param[2] = new SqlParameter("@DOT2", DOT2);
        return objDBBridge.ExecuteDataset(_spName1, param);
    }

    public DataSet playedmatchesbyleague()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "playedgamebyleague");
        param[1] = new SqlParameter("@league",league);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet Activematchesbyleague()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "gamebyleague");
        param[1] = new SqlParameter("@league", league);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet AdminViewmatches()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "Viewgames");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
  
    public DataSet unapprovedmatches()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "All");
        return objDBBridge.ExecuteDataset("unapprovedgames", param);
    }
    public DataSet unApprovedMatchesByDate()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "ByDate");
        param[1] = new SqlParameter("@Dot", _DOT);
        param[2] = new SqlParameter("@Dot2",_DOT2);
        return objDBBridge.ExecuteDataset("unapprovedgames", param);
    }

    public DataSet matchesresult()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "gameresults");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2);
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet matchresults()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "getresults");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet Selectwire()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "Selectwire");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet Selectevenodd()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "Selectevenodd");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet Selectdc()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "Selectdc");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet Selectdcd()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@TotalRows", _ttrow);
        return objDBBridge.ExecuteDataset("spx_GetCustomers",param);
    }
    public DataSet Selecthc()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "Selecthc");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet Selectallgame()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "Selectallgame");
        param[1] = new SqlParameter("@DOT", DOT);
        param[2] = new SqlParameter("@DOT2", DOT2);
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet Selectallgame(string keyword)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "Selectallgamebykeyword");
        param[1] = new SqlParameter("@keyword", keyword);
        return objDBBridge.ExecuteDataset(_spName, param);
    }

    public DataSet Selectht()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "Selectht");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet SelectTeams()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "SelectTeams");
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public DataSet SelectTeamsbyTournament()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "TeamsbyTournament");
        param[1] = new SqlParameter("@league",_leagueid);
        return objDBBridge.ExecuteDataset(_spName, param);
    }
    public int AddTeams()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "AddTeams");
        param[1] = new SqlParameter("@league", _league);
        param[2] = new SqlParameter("@team", _team);

        return objDBBridge.ExecuteNonQuery(_spName, param);
    }

    public int UpdateTeams()
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Mode", "UpdateTeams");
        param[1] = new SqlParameter("@league", _league);
        param[2] = new SqlParameter("@team", _team);
        param[3] = new SqlParameter("@teamid", _teamid);
        return objDBBridge.ExecuteNonQuery(_spName, param);
    }
    public int DeleteTeams()
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Mode", "DeleteTeams");
        param[1] = new SqlParameter("@league", _league);
        param[2] = new SqlParameter("@team", _team);
        return objDBBridge.ExecuteNonQuery(_spName, param);
    }
    public int TeamCode()
    {
        int maxcode = 0;
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "TeamCode"); 
        DataTable dtUser = new DataTable();
        dtUser = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtUser.Rows.Count != 0)
        {
            DataRow drLogin;
            drLogin = dtUser.Rows[0];
            maxcode = Convert.ToInt16(drLogin["code"]);
        }
        return maxcode;
    }
    public int agenttotalbetsbd()
    {
        int totalbets = 0;
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Mode", "getagenttotals");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2);
        param[3] = new SqlParameter("@username", _username);
        DataTable dtUser = new DataTable();
        dtUser = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtUser.Rows.Count != 0)
        {
            DataRow drLogin;
            drLogin = dtUser.Rows[0];
            totalbets= Convert.ToInt16(drLogin["totalbets"]);
        }
        return totalbets;
    }

    public int allagenttotalbetsbd()
    {
        int totalbets = 0;
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Mode", "getallagenttotals");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2);
        param[3] = new SqlParameter("@username", _username);
        DataTable dtUser = new DataTable();
        dtUser = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtUser.Rows.Count != 0)
        {
            DataRow drLogin;
            drLogin = dtUser.Rows[0];
            totalbets = Convert.ToInt16(drLogin["totalbets"]);
        }
        return totalbets;
    }
    public decimal allagenttotalbetamount()
    {
        decimal totalbetamount = 0;
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Mode", "getallagenttotals");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2);
        param[3] = new SqlParameter("@username", _username);
        DataTable dtUser = new DataTable();
        dtUser = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtUser.Rows.Count != 0)
        {
            DataRow drLogin;
            drLogin = dtUser.Rows[0];
            totalbetamount = Convert.ToDecimal(drLogin["betamount"]);
        }
        return totalbetamount;
    }

    public decimal agenttotalbetamount()
    {
        decimal totalbetamount = 0;
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Mode", "getagenttotals");
        param[1] = new SqlParameter("@DOT", _DOT.ToShortDateString());
        param[2] = new SqlParameter("@DOT2", _DOT2);
        param[3] = new SqlParameter("@username", _username);
        DataTable dtUser = new DataTable();
        dtUser = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtUser.Rows.Count != 0)
        {
            DataRow drLogin;
            drLogin = dtUser.Rows[0];
            totalbetamount = Convert.ToDecimal(drLogin["betamount"]);
        }
        return totalbetamount;
    }


    public int getbetid()
    {
        int maxcode = 0;
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Mode", "getbetid");
        param[1] = new SqlParameter("@username", _username);
        param[2] = new SqlParameter("@betid", _recieptid);
        param[3] = new SqlParameter("@setno", gensetno());
        maxcode = objDBBridge.ExecuteNonQuery(_spName, param);
        return maxcode;
    }
    public int getbetno()
    {
        int maxcode = 0;
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@username", _username);
        DataTable dt = new DataTable();
        dt = objDBBridge.ExecuteDataset("getbetno", param).Tables[0];
        DataRow dr;
        if (dt.Rows.Count > 0)
        {
            dr = dt.Rows[0];

            maxcode = Convert.ToInt32(dr["betid"]);
        }
        return maxcode;
    }
    public int ResetTeamCode()
    {
        int maxcode = TeamCode();
        if ((maxcode < 99999) && (maxcode > 100))
        {
            return maxcode;
        }
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "ResetTeamCode");
        DataTable dtUser = new DataTable();
        dtUser = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtUser.Rows.Count != 0)
        {
            DataRow drLogin;
            drLogin = dtUser.Rows[0];
            maxcode = Convert.ToInt32(drLogin["code"]);
        }
        return maxcode;
    }
    public int setTeamCode()
    {
        int maxcode = 0;
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "SetTeamCode");
        param[1] = new SqlParameter("@currentcode", _codeno);
        return objDBBridge.ExecuteNonQuery(_spName,param);     
    }
    public int gensetno() {
        string tdate = DateTime.Today.ToShortDateString(),yr,mm,dd;
        string[] dateitems = tdate.Split('/');
        mm= dateitems[0];
        if (mm.Length == 1) mm = "0" + mm;
        dd = dateitems[1];
        if (dd.Length == 1) dd = "0" + dd;
        yr = dateitems[2].Substring(2);
        String sitems =  yr+mm+dd;
        return _setno = Convert.ToInt32(sitems);
    }
    public int getMatchnumber()
    {
        int maxmatno = 0;
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Mode", "Getmatno");
        DataTable dtUser = new DataTable();
        dtUser = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtUser.Rows.Count != 0)
        {
            DataRow drLogin;
            drLogin = dtUser.Rows[0];
            maxmatno = Convert.ToInt32(drLogin["matchno"]);
        }
        return maxmatno;
    }
    public int getTeamscode()
    {
        int maxmatno = 0;
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Mode", "getTeamscode");
        param[1] = new SqlParameter("@choice",_choice);
        param[2] = new SqlParameter("@MatchNo",_matno);
        param[3] = new SqlParameter("@bet_type",_bet_type);
        DataTable dtUser = new DataTable();
        dtUser = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtUser.Rows.Count != 0)
        {
            DataRow drLogin;
            drLogin = dtUser.Rows[0];
            maxmatno = Convert.ToInt32(drLogin["code"]);
        }
        return maxmatno;
    }
    public Boolean getAnalysisDetails()
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "MatchAnalysisData");
        param[1] = new SqlParameter("@MatchNo", _matno);
        DataTable dtUser = new DataTable();
        dtUser = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtUser.Rows.Count != 0)
        {
            DataRow drLogin;
            drLogin = dtUser.Rows[0];
            _league = drLogin["champ"].ToString();
            _host = drLogin["host"].ToString();
            _visitor = drLogin["visitor"].ToString();
            _HomeTeamForm = Convert.ToInt16(drLogin["HomeTeamForm"]);
            _HomeTeamH2H = Convert.ToInt16(drLogin["HomeH2H"]);
            _HomeTeamHomeForm = Convert.ToInt32(drLogin["HomeHomeForm"]);
            _HomeTeamLeagueRating = Convert.ToInt16(drLogin["HomeLeagueRating"]);
            _HomeRecentGame = Convert.ToInt16(drLogin["HomeRecentGames"]);
            _HomeGoalsScored = Convert.ToInt16(drLogin["HomegoalsScored"]);
            _AwayTeamForm = Convert.ToInt16(drLogin["AwayTeamForm"]);
           _AwayTeamH2H = Convert.ToInt16(drLogin["AwayH2H"]);
           _awayAwayForm = Convert.ToInt16(drLogin["AwayAwayForm"]);
            _AwayLeagueRating= Convert.ToInt16(drLogin["AwayLeagueRating"]);
            _AwayRecentGames= Convert.ToInt16(drLogin["AwayRecentGames"]);
            _AwayGoalsScored = Convert.ToInt16(drLogin["AwayGoalsScored"]);
            _LeagueTeamNumber = Convert.ToInt16(drLogin["LeagueTeamNumber"]);
             _normalprediction = (drLogin["NormalPrediction"]).ToString();
            _wireprediction = (drLogin["WirePrediction"]).ToString();
            return true;
        }
        return false;
    }	
	public Boolean getAnalysisDetails(int matno)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "MatchAnalysisData");
        param[1] = new SqlParameter("@MatchNo", matno);
        DataTable dtUser = new DataTable();
        dtUser = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtUser.Rows.Count != 0)
        {
            DataRow drLogin;
            drLogin = dtUser.Rows[0];
            _league = drLogin["champ"].ToString();
            _host = drLogin["host"].ToString();
            _visitor = drLogin["visitor"].ToString();
            _HomeTeamForm = Convert.ToInt16(drLogin["HomeTeamForm"]);
            _HomeTeamH2H = Convert.ToInt16(drLogin["HomeH2H"]);
            _HomeTeamHomeForm = Convert.ToInt32(drLogin["HomeHomeForm"]);
            _HomeTeamLeagueRating = Convert.ToInt16(drLogin["HomeLeagueRating"]);
            _HomeRecentGame = Convert.ToInt16(drLogin["HomeRecentGames"]);
            _HomeGoalsScored = Convert.ToInt16(drLogin["HomegoalsScored"]);
            _AwayTeamForm = Convert.ToInt16(drLogin["AwayTeamForm"]);
           _AwayTeamH2H = Convert.ToInt16(drLogin["AwayH2H"]);
           _awayAwayForm = Convert.ToInt16(drLogin["AwayAwayForm"]);
            _AwayLeagueRating= Convert.ToInt16(drLogin["AwayLeagueRating"]);
            _AwayRecentGames= Convert.ToInt16(drLogin["AwayRecentGames"]);
            _AwayGoalsScored = Convert.ToInt16(drLogin["AwayGoalsScored"]);
            _LeagueTeamNumber = Convert.ToInt16(drLogin["LeagueTeamNumber"]);
             _normalprediction = (drLogin["NormalPrediction"]).ToString();
            _wireprediction = (drLogin["WirePrediction"]).ToString();
            return true;
        }
        return false;
    }	
    public int getmatdetails()
    {
        int maxmatno = 0;
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "getmatch");
        param[1] = new SqlParameter("@MatchNo", _matno);     
        DataTable dtUser = new DataTable();
        dtUser = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtUser.Rows.Count != 0)
        {
            DataRow drLogin;
            drLogin = dtUser.Rows[0];
            _league = drLogin["champ"].ToString();
            _host=drLogin["host"].ToString();
            _visitor=drLogin["visitor"].ToString();
            _stime = Convert.ToDateTime(drLogin["StartTime"]);
            _oddhome = Convert.ToDouble(drLogin["oddhome"]);
            _odddraw = Convert.ToDouble(drLogin["odddraw"]);
            _oddaway = Convert.ToDouble(drLogin["oddaway"]);
            _hfawayodd = Convert.ToDecimal(drLogin["hfaway"]);
            _hfdrawodd = Convert.ToDecimal(drLogin["hfdraw"]);
            _hfhomeodd = Convert.ToDecimal(drLogin["hfhome"]);
            _underodd = Convert.ToDecimal(drLogin["underodd"]);
            _overodd = Convert.ToDecimal(drLogin["overodd"]);
            _dchaodd = Convert.ToDecimal(drLogin["dcha"]);
            _dchdodd = Convert.ToDecimal(drLogin["dchd"]);
            _dcdaodd = Convert.ToDecimal(drLogin["dcda"]);
            _oddodd = Convert.ToDecimal(drLogin["oddodd"]);
            _oddeven = Convert.ToDecimal(drLogin["oddeven"]);
            _hcawayodd = Convert.ToDecimal(drLogin["hcawayodd"]);
            _hcdrawodd = Convert.ToDecimal(drLogin["hcdrawodd"]);
            _hchomeodd = Convert.ToDecimal(drLogin["hchomeodd"]);
            _handhome = Convert.ToInt16(drLogin["hchomegoals"]);
            _handaway = Convert.ToInt16(drLogin["hcawaygoals"]);
        }
        return maxmatno;
    }
    public int getleaguename()
    {
        int maxmatno = 0;
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Mode", "getleaguename");
        param[1] = new SqlParameter("@leagueId", _league);

        DataTable dtUser = new DataTable();
        dtUser = objDBBridge.ExecuteDataset(_spName, param).Tables[0];
        if (dtUser.Rows.Count != 0)
        {
            DataRow drLogin;
            drLogin = dtUser.Rows[0];
            _league = drLogin["league"].ToString();
            _leagueid = drLogin["leagueid"].ToString();        
        }
        return maxmatno;
    }

    #endregion
}
