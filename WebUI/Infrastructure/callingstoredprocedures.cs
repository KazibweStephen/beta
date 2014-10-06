using System;
using System.Data;
using System.Data.SqlClient;
using SRN.DAL;

/// <summary>
/// Summary description for callingstoredprocedures
/// </summary>
public class callingstoredprocedures
{
   DBBridge mybridge =new DBBridge();
   
	public callingstoredprocedures()
	{
		//
		// TODO: Add constructor logic here
		//
    }

    public string setno=string.Empty;
    public string _league = string.Empty;
    public string _mode = string.Empty;    
    public string _username= string.Empty;
    public DateTime _betdate = new DateTime();
    public double _betmoney = 0;
    public string _bet_type = string.Empty;
    public string _category = string.Empty;
    public string _champ = string.Empty;
    public string _setno = string.Empty;
    public string _matno = string.Empty;
    public string _host = string.Empty;
    public string _visitor = string.Empty;
    public string _oddname = string.Empty;
    public double _odd = 0;
    public double _ttmoney = 0;
    public double _ttmoneywin = 0;
    public double _ttmoneylose = 0;
    public DateTime _stime = new DateTime();
    public int _setsize = 0;
    public int _handhome = 0;
    public int _handaway = 0;
    public double _oddwin = 0;
    public double _oddlose = 0;
    public double _oddaway = 0;
    public double _odddraw = 0;
    public double _betID = 0;
    public double _setodd = 0;
    public string _transaction = string.Empty;
    public string _method = string.Empty;
    public string _serial = string.Empty;
    public double _balbefore = 0;
    public double _amount = 0;
    public string _flag = string.Empty;
    public double _balafter = 0;
    public string _phonenum = string.Empty;
    public string _status = string.Empty;
    public string _admin_e = string.Empty;
    public string _controller = string.Empty;
    public string _homecode = string.Empty;
    public string _awaycode = string.Empty;
    public string _drawcode = string.Empty;
    

#region Accessors_variables

    public string setnum
    {
        get 
        { 
            return setno; 
        }
        set 
        { 
            setno = value; 
        }
    }
    public string league
    {
        get
        {
            return _league;
        }
        set
        {
            _league = value;
        }
    }
    public string mode
    {
        get
        {
            return _mode;
        }
        set
        {
            _mode = value;
        }
    }
    public string username
    {
        get
        {
            return _username;
        }
        set
        {
            _username = value;
        }
    }
    public string status
    {
        get
        {
            return _status;
        }
        set
        {
            _status = value;
        }
    }
    public DateTime betdate
    {
        get
        {
            return _betdate;
        }
        set
        {
            _betdate = value;
        }
    }
    public double betmoney
    {
        get
        {
            return _betmoney;
        }
        set
        {
            _betmoney = value;
        }
    }
    public string bet_type
    {
        get
        {
            return _bet_type;
        }
        set
        {
            _bet_type = value;
        }
    }
    public string category
    {
        get
        {
            return _category;
        }
        set
        {
            _category = value;
        }
    }
    public string champ
    {
        get
        {
            return _champ;
        }
        set
        {
            _champ = value;
        }
    }
    public string matno
    {
        get
        {
            return _matno;
        }
        set
        {
            _matno = value;
        }
    }
    public string host
    {
        get
        {
            return _host;
        }
        set
        {
            _host = value;
        }
    }
    public string visitor
    {
        get
        {
            return _visitor;
        }
        set
        {
            _visitor = value;
        }
    }
    public string oddname
    {
        get
        {
            return _oddname;
        }
        set
        {
            _oddname = value;
        }
    }
    public double odd
    {
        get
        {
            return _odd;
        }
        set
        {
            _odd = value;
        }
    }
    public double ttmoney
    {
        get
        {
            return _ttmoney;
        }
        set
        {
            _ttmoney = value;
        }
    }
    public double ttmoneywin
    {
        get
        {
            return _ttmoneywin;
        }
        set
        {
            _ttmoneywin = value;
        }
    }
    public DateTime stime
    {
        get
        {
            return _stime;
        }
        set
        {
            _stime = value;
        }
    }
    public int handhome
    {
        get
        {
            return _handhome;
        }
        set
        {
            _handhome = value;
        }
    }
    public int handaway
    {
        get
        {
            return _handaway;
        }
        set
        {
            _handaway = value;
        }
    }
    public double oddwin
    {
        get
        {
            return _oddwin;
        }
        set
        {
            _oddwin = value;
        }
    }
    public double oddlose
    {
        get
        {
            return _oddlose;
        }
        set
        {
            _oddlose = value;
        }
    }
    public double oddaway
    {
        get
        {
            return _oddaway;
        }
        set
        {
            _oddaway = value;
        }
    }
    public double betID
    {
        get
        {
            return _betID;
        }
        set
        {
            _betID = value;
        }
    }
    public string transaction
    {
        get
        {
            return _transaction;
        }
        set
        {
            _transaction = value;
        }
    }
    public string method
    {
        get
        {
            return _method;
        }
        set
        {
            _method = value;
        }
    }
    public string serial
    {
        get
        {
            return _serial;
        }
        set
        {
            _serial = value;
        }
    }
    public string admin_e
    {
        get
        {
            return _admin_e;
        }
        set
        {
            _admin_e = value;
        }
    }
    public double balbefore
    {
        get
        {
            return _balbefore;
        }
        set
        {
            _balbefore = value;
        }
    }
    public double amount
    {
        get
        {
            return _amount;
        }
        set
        {
            _amount = value;
        }
    }
    public double balafter
    {
        get
        {
            return _balafter;
        }
        set
        {
            _balafter = value;
        }
    }
    public double setodd
    {
        get
        {
            return _setodd;
        }
        set
        {
            _setodd = value;
        }
    }
    public string phonenum
    {
        get
        {
            return _phonenum;
        }
        set
        {
            _phonenum = value;
        }
    }
    public int setsize
    {
        get
        {
            return _setsize;
        }
        set
        {
            _setsize = value;
        }
    }
    public string controller
    {
        get
        {
            return _controller;
        }
        set
        {
            _controller = value;
        }
    }
    public string flag
    {
        get
        {
            return _flag;
        }
        set
        {
            _flag = value;
        }
    }
    public string homecode
    {
        get
        {
            return _homecode;
        }
        set
        {
            _homecode = value;
        }
    }
    public string awaycode
    {
        get
        {
            return _awaycode;
        }
        set
        {
            _awaycode = value;
        }
    }
    public string drawcode
    {
        get
        {
            return _drawcode;
        }
        set
        {
            _drawcode = value;
        }
    }
    public double drawodd
    {
        get
        {
            return _odddraw;
        }
        set
        {
            _odddraw = value;
        }
    }




#endregion variables

    public DataTable setmatches()
    {
        DataSet mydataset = new DataSet();
     SqlParameter[] dtm = new SqlParameter[1];
     //dtm[0] = new SqlParameter("@setno", setno);
     //mybridge.ExecuteDataset("getsetmatches", dtm);

     DataTable dtmatches = new DataTable();
     dtmatches = mybridge.ExecuteDataset("getsetmatches", dtm).Tables[0];

     //if (dtmatches.Rows.Count != 0)
     //   {
     //       //DataRow drmatches;
            //dtmatches = dtmatches.Rows[0];

            return dtmatches;
        //}
    }

    public DataTable playedsetmatches()
    {
        DataSet mydataset = new DataSet();
        SqlParameter[] dtm = new SqlParameter[1];
        DataTable dtmatches = new DataTable();
        dtmatches = mybridge.ExecuteDataset("playedsetmatches", dtm).Tables[0];

        //if (dtmatches.Rows.Count != 0)
        //   {
        //       //DataRow drmatches;
        //dtmatches = dtmatches.Rows[0];

        return dtmatches;
        //}
    }

    public DataTable submitted_setmatches()
    {
        DataSet mydataset = new DataSet();
        SqlParameter[] dtm = new SqlParameter[1];
       
        DataTable dtmatches = new DataTable();
        dtmatches = mybridge.ExecuteDataset("submittedSets", dtm).Tables[0];

        return dtmatches;
        //}
    }
    public DataTable setresultmatches()
    {
        DataSet mydataset = new DataSet();
        SqlParameter[] dtm = new SqlParameter[1];
        //dtm[0] = new SqlParameter("@setno", setno);
        //mybridge.ExecuteDataset("getsetmatches", dtm);

        DataTable dtmatches = new DataTable();
        dtmatches = mybridge.ExecuteDataset("getsetmatches", dtm).Tables[0];

        //if (dtmatches.Rows.Count != 0)
        //   {
        //       //DataRow drmatches;
        //dtmatches = dtmatches.Rows[0];

        return dtmatches;
        //}
    }

    public DataTable fixture()
    {
       DataSet mydataset = new DataSet();
       DataTable dtmatches = new DataTable();

       try
       {
           SqlParameter[] dtm = new SqlParameter[2];
           dtm[0] = new SqlParameter("@league", _league.Trim());
           dtm[1] = new SqlParameter("@mode", _mode.Trim());
          
          // DataTable dtmatches = new DataTable();
           dtmatches = mybridge.ExecuteDataset("getfixtures", dtm).Tables[0];
       }
        catch (Exception ex)
       {
           String error = ex.Message;
       }
        return dtmatches;
    }

    public string Customerbet()    
    {
        DataSet mydataset = new DataSet();
        DataTable dtmatches = new DataTable();
        string msg = null;

        try
        {
            SqlParameter[] dtm = new SqlParameter[22];

            //dtm[0] = new SqlParameter("@league", _league.Trim());
            dtm[0] = new SqlParameter("@username", _username.Trim());
            dtm[1] = new SqlParameter("@setno", setno.Trim());
            dtm[2] = new SqlParameter("@mode", _mode.Trim());
            dtm[3] = new SqlParameter("@betdate", _betdate);
            dtm[4] = new SqlParameter("@betmoney", _betmoney);
            dtm[5] = new SqlParameter("@bet_type", _bet_type.Trim());
            dtm[6] = new SqlParameter("@category", _category.Trim());
            dtm[7] = new SqlParameter("@champ", _champ.Trim());
            dtm[8] = new SqlParameter("@MatchNo", _matno.Trim());
            dtm[9] = new SqlParameter("@host", _host.Trim());
            dtm[10] = new SqlParameter("@visitor", _visitor.Trim());
            dtm[11] = new SqlParameter("@oddname", _oddname.Trim());
            dtm[12] = new SqlParameter("@odd", _odd);
            dtm[13] = new SqlParameter("@ttmoney", _ttmoney);            
            dtm[14] = new SqlParameter("@StartTime", _stime);
            dtm[15] = new SqlParameter("@handhome", _handhome);
            dtm[16] = new SqlParameter("@handaway", _handaway);
            dtm[17] = new SqlParameter("@oddwin", _oddwin);
            dtm[18] = new SqlParameter("@oddlose", _oddlose);
            dtm[19] = new SqlParameter("@ttmoneywin", _ttmoneywin);
            dtm[20] = new SqlParameter("@phonenum", _phonenum);

            //dtm[21] = new SqlParameter("@mode", mode.Trim());
            // DataTable dtmatches = new DataTable();
            try
            {
                mybridge.ExecuteDataset("smsbets", dtm);
                msg = "Success";
            }
            catch(Exception ex)
            {
                msg = "Un Successful";
                string error=ex.Message;
            }
        }
        catch (Exception ex)
        {
            String error = ex.Message;
        }
        return msg;
    }
    public DataTable match()
    {
        DataSet mydataset = new DataSet();
        DataTable dtmatches = new DataTable();

        try
        {
            SqlParameter[] dtm = new SqlParameter[2];
            dtm[0] = new SqlParameter("@MatchNo", _matno.Trim());
            dtm[1] = new SqlParameter("@mode", _mode.Trim());

            // DataTable dtmatches = new DataTable();
            dtmatches = mybridge.ExecuteDataset("get_singlematch", dtm).Tables[0];
        }
        catch (Exception ex)
        {
            String error = ex.Message;
        }
        return dtmatches;
    }
    public DataTable results()
    {
        DataSet mydataset = new DataSet();
        DataTable dtmatches = new DataTable();

        try
        {
            SqlParameter[] dtm = new SqlParameter[2];
            dtm[0] = new SqlParameter("@league", _league.Trim());
            dtm[1] = new SqlParameter("@mode", _mode.Trim());

            // DataTable dtmatches = new DataTable();
            dtmatches = mybridge.ExecuteDataset("getresults", dtm).Tables[0];
        }
        catch (Exception ex)
        {
            String error = ex.Message;
        }
        return dtmatches;
    }
    public string Updatesetsbet()
    {
        string res = null;     
        try
        {
            SqlParameter[] dtm = new SqlParameter[2];           
            dtm[0] = new SqlParameter("@ttmoney",_ttmoney);            
            dtm[1] = new SqlParameter("@betID",_betID);

            mybridge.ExecuteDataset("Update_sets_bets", dtm);
            res="success";
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "un successful";
        }
        return res;
    }
    public string setsbet()
    {
        string res = null;
        try
        {
            SqlParameter[] dtm = new SqlParameter[14];                      
            dtm[0] = new SqlParameter("@username", _username.Trim());
            dtm[1] = new SqlParameter("@betmoney", _betmoney);
            dtm[2] = new SqlParameter("@category", _category.Trim());
            dtm[3] = new SqlParameter("@champ", _champ.Trim());
            dtm[4] = new SqlParameter("@setno", setno.Trim());
            dtm[5] = new SqlParameter("@MatchNo", _matno.Trim());            
            dtm[6] = new SqlParameter("@visitor", _visitor.Trim());
            dtm[7] = new SqlParameter("@oddname", _oddname.Trim());
            dtm[8] = new SqlParameter("@odd", _odd);
            dtm[9] = new SqlParameter("@ttmoney", _ttmoney);
            dtm[10] = new SqlParameter("@StartTime", _stime);
            dtm[11] = new SqlParameter("@betID", _betID);
            dtm[12] = new SqlParameter("@betdate", _betdate);
            dtm[13] = new SqlParameter("@host", _host.Trim());
            //dtm[13] = new SqlParameter("@host", _host.Trim());
            //dtm[14] = new SqlParameter("@phonenum", _phonenum);

            mybridge.ExecuteDataset("clientsetsbet", dtm);
            res = "success";

        }
        catch (Exception ex)
        {
            String error = ex.Message;
           // mybridge.ExecuteDataset("deleteclientsetsbet", dtm);
            res = "failed";
        }
        return res;
    }
    public string deleteclientsetsbet()
    {
        DataTable dtmatches = new DataTable();
        string res = null;
        try
        {
            SqlParameter[] dtm = new SqlParameter[1];
            dtm[0] = new SqlParameter("@betID", _betID);

            //dtmatches = mybridge.ExecuteDataset("deleteclientsetsbet", dtm).Tables[0];
            mybridge.ExecuteDataset("deleteclientsetsbet", dtm);
            res = "success";
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "failed";
        }
        return res;
    }
    public string Updateclientsmssetsbet()
    {
        DataTable dtmatches = new DataTable();
        string res = null;
        try
        {
            SqlParameter[] dtm = new SqlParameter[5];
            dtm[0] = new SqlParameter("@betID", _betID);
            dtm[1] = new SqlParameter("@username", _username.Trim());
            dtm[2] = new SqlParameter("@amount", _betmoney);
            dtm[3] = new SqlParameter("@ttmoney", _ttmoney);
            dtm[4] = new SqlParameter("@setodd", _setodd);

            //dtmatches = mybridge.ExecuteDataset("deleteclientsetsbet", dtm).Tables[0];
            mybridge.ExecuteDataset("Updateclientsmssetsbet", dtm);
            res = "success";
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "failed";
        }
        return res;
    }
    public string UpdateclientsmsAccounts()
    {
        DataTable dtmatches = new DataTable();
        string res = null;
        try
        {
            SqlParameter[] dtm = new SqlParameter[3];
            dtm[0] = new SqlParameter("@username", _username.Trim());
            dtm[1] = new SqlParameter("@amount", _betmoney);
            dtm[2] = new SqlParameter("@betID", _betID);  

            //dtmatches = mybridge.ExecuteDataset("deleteclientsetsbet", dtm).Tables[0];
            mybridge.ExecuteDataset("UpdateclientsmsAccounts", dtm);
            res = "success";
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "failed";
        }
        return res;
    }
    public string Agent_setsbet()
    {
        string res = null;
        try
        {
            SqlParameter[] dtm = new SqlParameter[15];
            dtm[0] = new SqlParameter("@username", _username.Trim());
            dtm[1] = new SqlParameter("@betmoney", _betmoney);
            dtm[2] = new SqlParameter("@category", _category.Trim());
            dtm[3] = new SqlParameter("@champ", _champ.Trim());
            dtm[4] = new SqlParameter("@setno", setno.Trim());
            dtm[5] = new SqlParameter("@MatchNo", _matno.Trim());
            dtm[6] = new SqlParameter("@visitor", _visitor.Trim());
            dtm[7] = new SqlParameter("@oddname", _oddname.Trim());
            dtm[8] = new SqlParameter("@odd", _odd);
            dtm[9] = new SqlParameter("@ttmoney", _ttmoney);
            dtm[10] = new SqlParameter("@StartTime", _stime);
            dtm[11] = new SqlParameter("@betID", _betID);
            dtm[12] = new SqlParameter("@betdate", _betdate);
            dtm[13] = new SqlParameter("@host", _host.Trim());           
            dtm[14] = new SqlParameter("@phonenum", _phonenum);
            //dtm[13] = new SqlParameter("@host", _);

            mybridge.ExecuteDataset("Agent_clientsetsbet", dtm);
            res = "success";

        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "un successful";
        }
        return res;
    }
    public string insertset()
    {
        string res = null;
        try
        {
            SqlParameter[] dtm = new SqlParameter[7];

            dtm[0] = new SqlParameter("@username", _username.Trim());
            dtm[1] = new SqlParameter("@betmoney", _betmoney);
            dtm[2] = new SqlParameter("@betdate", _betdate);
            dtm[3] = new SqlParameter("@setodd", _setodd);
            dtm[4] = new SqlParameter("@betID", _betID);
            dtm[5] = new SqlParameter("@setsize", _setsize);
            dtm[6] = new SqlParameter("@status", _status); 
            mybridge.ExecuteDataset("createsets", dtm);
            res = "success";
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "un successful";
        }
        return res;
    }
    public string Agent_insertset()
    {
        string res = null;
        try
        {
            SqlParameter[] dtm = new SqlParameter[7];

            dtm[0] = new SqlParameter("@username", _username.Trim());
            dtm[1] = new SqlParameter("@betmoney", _betmoney);
            dtm[2] = new SqlParameter("@betdate", _betdate);
            dtm[3] = new SqlParameter("@setodd", _setodd);
            dtm[4] = new SqlParameter("@betID", _betID);
            dtm[5] = new SqlParameter("@phonenum", _phonenum);
            dtm[6] = new SqlParameter("@setsize", _setsize);  

            mybridge.ExecuteDataset("Agent_createsets", dtm);
            res = "success";
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "un successful";
        }
        return res;
    }
    public string maketransactionupdateAccount()
    {
        string res = null;
        try
        {
            SqlParameter[] dtm = new SqlParameter[9];
            dtm[0] = new SqlParameter("@account", _username.Trim());
            dtm[1] = new SqlParameter("@transaction", _transaction);
            dtm[2] = new SqlParameter("@method", _method.Trim());
            dtm[3] = new SqlParameter("@betdate", _betdate);
            dtm[4] = new SqlParameter("@serial", _serial.Trim());
            dtm[5] = new SqlParameter("@balbefore", _balbefore);
            dtm[6] = new SqlParameter("@amount", _amount); 
            dtm[7] = new SqlParameter("@BalAfter", _balafter);
            dtm[8] = new SqlParameter("@admin_e", _admin_e);

            mybridge.ExecuteDataset("maketransaction_updateAccount", dtm);
            res = "success";

        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "un successful";
        }
        return res;
    }
    public DataTable bettedSetClient()
    {
        DataTable dtmatches = new DataTable();
        string res = null;
        try
        {
            SqlParameter[] dtm = new SqlParameter[1];            
            dtm[0] = new SqlParameter("@username", _username.Trim());

            dtmatches = mybridge.ExecuteDataset("Agent_clientsSets", dtm).Tables[0];
            res = "success";
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "un successful";
        }
        return dtmatches;
    }

    public DataTable bettedSetClientsearch(DateTime from, DateTime upto)
    {
        DataTable dtmatches = new DataTable();
        string res = null;
        try
        {
            SqlParameter[] dtm = new SqlParameter[2];
            dtm[0] = new SqlParameter("@from", from);
            dtm[1] = new SqlParameter("@upto", upto);

            dtmatches = mybridge.ExecuteDataset("Search_clientsSets", dtm).Tables[0];
            res = "success";
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "un successful";
        }
        return dtmatches;
    }
    public DataTable getbettedSets()
    {
        DataTable dtmatches = new DataTable();
        string res = null;
        try
        {
            SqlParameter[] dtm = new SqlParameter[2];
            dtm[0] = new SqlParameter("@betID", _betID);
            dtm[1] = new SqlParameter("@username", _username.Trim());


            dtmatches = mybridge.ExecuteDataset("getClientsSetsBets", dtm).Tables[0];
            res = "success";

        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "un successful";
        }
        return dtmatches;
    }
    public DataTable bettedSetClientinset()
    {
        DataTable dtmatches = new DataTable();
        string res = null;
        try
        {
            SqlParameter[] dtm = new SqlParameter[2];
            dtm[0] = new SqlParameter("@username", _username.Trim());
            dtm[1] = new SqlParameter("@betID", _betID);

            dtmatches = mybridge.ExecuteDataset("clients_games_in_Sets", dtm).Tables[0];
            res = "success";
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "un successful";
        }
        return dtmatches;
    }
    public DataTable bettedSetClientinsetAll()
    {
        DataTable dtmatches = new DataTable();
        string res = null;
        try
        {
            SqlParameter[] dtm = new SqlParameter[2];
            dtm[0] = new SqlParameter("@username", _username.Trim());
            dtm[1] = new SqlParameter("@betID", _betID);

            dtmatches = mybridge.ExecuteDataset("clients_games_in_ALLSets", dtm).Tables[0];
            res = "success";
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "un successful";
        }
        return dtmatches;
    }
    public string Admin_submitset()
    {
        string res = null;
        try
        {
            SqlParameter[] dtm = new SqlParameter[11];
           
            dtm[0] = new SqlParameter("@username",_username.Trim());
            dtm[1] = new SqlParameter("@betdate",_betdate);
            dtm[2] = new SqlParameter("@category",_category);
            dtm[3] = new SqlParameter("@setno",_setno);
            dtm[4] = new SqlParameter("@MatchNo",_matno);
            dtm[5] = new SqlParameter("@host",_host);
            dtm[6] = new SqlParameter("@visitor",_visitor);
            dtm[7] = new SqlParameter("@oddname",_oddname);
            dtm[8] = new SqlParameter("@odd",_odd);
            dtm[9] = new SqlParameter("@StartTime",_stime);
            dtm[10] = new SqlParameter("@champ", _champ.Trim());

            mybridge.ExecuteDataset("setsresults", dtm);
            res = "success";
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "un successful";
        }
        return res;
    }

    public DataTable Approve_submitset()
    {
        string res = null;
        DataTable dtmatches = new DataTable();
        try
        {
            SqlParameter[] dtm = new SqlParameter[9];

            dtm[0] = new SqlParameter("@username", _username); 
            dtm[1] = new SqlParameter("@betdate", _betdate);          
            dtm[2] = new SqlParameter("@MatchNo", _matno);
            dtm[3] = new SqlParameter("@host", _host);
            dtm[4] = new SqlParameter("@visitor", _visitor);
            dtm[5] = new SqlParameter("@oddname", _oddname);
            dtm[6] = new SqlParameter("@odd", _odd);
            dtm[7] = new SqlParameter("@StartTime", _stime);
            dtm[8] = new SqlParameter("@league", _champ.Trim());

            dtmatches = mybridge.ExecuteDataset("Approved_set", dtm).Tables[0];
            //mybridge.ExecuteDataset("Approved_sets", dtm);
            res = "success";
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "un successful";
        }
        return dtmatches;
    }

    public DataTable getApprovedset()
    {
        DataTable dtmatches = new DataTable();
        string res = null;
        try
        {
            SqlParameter[] dtm = new SqlParameter[1];
            dtm[0] = new SqlParameter("@MatchNo", matno.Trim());

            dtmatches = mybridge.ExecuteDataset("SelectApproved_set", dtm).Tables[0];
            res = "success";
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "un successful";
        }
        return dtmatches;
    }
    public string givenmane_set()
    {
        string res = null;
        try
        {
            SqlParameter[] dtm = new SqlParameter[7];
            
            dtm[0] = new SqlParameter("@controller", _username.Trim());
            dtm[1] = new SqlParameter("@betID", _betID);
            dtm[2] = new SqlParameter("@MatchNo", _matno.Trim());
            dtm[3] = new SqlParameter("@oddname", _oddname.Trim());
            dtm[4] = new SqlParameter("@host", _host.Trim());
            dtm[5] = new SqlParameter("@visitor", _visitor.Trim());
            dtm[6] = new SqlParameter("@odd", _odd);
           
            mybridge.ExecuteDataset("givenow", dtm);
            res = "success";
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "un successful";
        }
        return res;
    }
    //public string give_now()
    //{
    //    string res = null;
    //    DataTable dt = new DataTable();
    //    try
    //    {
    //        SqlParameter[] dtm = new SqlParameter[9];

    //        dtm[0] = new SqlParameter("@controller", _username.Trim());
    //        dtm[1] = new SqlParameter("@betID", _betID);
    //        dtm[2] = new SqlParameter("@MatchNo", _matno.Trim());
    //        dtm[3] = new SqlParameter("@oddname", _oddname.Trim());
    //        dtm[4] = new SqlParameter("@host", _host.Trim());
    //        dtm[5] = new SqlParameter("@visitor", _visitor.Trim());
    //        dtm[6] = new SqlParameter("@odd", _odd);
    //        dtm[7] = new SqlParameter("@username", _username.Trim());
    //        dtm[8] = new SqlParameter("@betdate", _betdate);

    //        mybridge.ExecuteDataset("give_now", dtm);
    //        res = "success";
    //    }
    //    catch (Exception ex)
    //    {
    //        String error = ex.Message;
    //        res = "un successful";
    //    }
    //    return res;
    //}
    public string denysetresult()
    {
        string res = null;
        try
        {
            SqlParameter[] dtm = new SqlParameter[1];
                       
            dtm[0] = new SqlParameter("@MatchNo", _matno.Trim());

            mybridge.ExecuteDataset("deny_set_results", dtm);
            res = "success";
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "failed";
        }
        return res;
    }
    public string epay()
    {
        DataTable dt = new DataTable();
        string res = null;
        string users = null;

        try
        {
            SqlParameter[] dtm = new SqlParameter[5];

            dtm[0] = new SqlParameter("@username", _username.Trim());
            dtm[1] = new SqlParameter("@balbefore", balbefore);
            dtm[2] = new SqlParameter("@amount", _amount);
            dtm[3] = new SqlParameter("@serial", _serial.Trim());
            dtm[4] = new SqlParameter("@controller", _controller);
            //dtm[2] = new SqlParameter("@serial", _serial.Trim());

            dt = mybridge.ExecuteDataset("pay_epay", dtm).Tables[0];
            int no = dt.Rows.Count;
            if (no == 0) {
                res = "failed";
               return mybridge.ExecuteNonQuery("",dtm).ToString();
            }
   

          
            else
            {
                res = "failed";
            }
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "failed";
        }
        return res;
    }
    public string epaysms()
    {
        DataTable dt = new DataTable();
        string res = null;
        string users = null;

        try
        {
            SqlParameter[] dtm = new SqlParameter[6];

            dtm[0] = new SqlParameter("@username", _username.Trim());
            dtm[1] = new SqlParameter("@balbefore", balbefore);
            dtm[2] = new SqlParameter("@amount", _amount);
            dtm[3] = new SqlParameter("@serial", _serial.Trim());
            dtm[4] = new SqlParameter("@controller", _controller);
            dtm[5] = new SqlParameter("@transcation", "Withdraw betmoney " + _amount.ToString());

            dt = mybridge.ExecuteDataset("pay_sms", dtm).Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                users = dr["userID"].ToString();
            }

            if (users.Length != 0)
            {
                res = "success";
            }
            else
            {
                res = "failed";
            }
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "failed";
        }
        return res;
    }
    public DataTable GetCustomerClient()
    {
        DataTable dtmatches = new DataTable();
        string res = null;
        try
        {
            SqlParameter[] dtm = new SqlParameter[1];
            dtm[0] = new SqlParameter("@PhoneNo", _phonenum.Trim());

            dtmatches = mybridge.ExecuteDataset("GetCustomerClient", dtm).Tables[0];
            res = "success";
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "Failed";
        }
        return dtmatches;
    }
    public DataTable GetCustomerBAL()
    {
        DataTable dtmatches = new DataTable();
        string res = null;
        try
        {
            SqlParameter[] dtm = new SqlParameter[1];
            dtm[0] = new SqlParameter("@username", _username.Trim());

            dtmatches = mybridge.ExecuteDataset("GetCustomerBAL", dtm).Tables[0];
            res = "success";
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "failed";
        }
        return dtmatches;
    }
    public DataTable Approved_sets()
    {
        string res = null;
        DataTable dtmatches = new DataTable();
        try
        {
            SqlParameter[] dtm = new SqlParameter[9];
                      
            dtm[0] = new SqlParameter("@username", _username);
            dtm[1] = new SqlParameter("@league ", _champ);
            dtm[2] = new SqlParameter("@MatchNo", _matno);
            dtm[3] = new SqlParameter("@host", _host);
            dtm[4] = new SqlParameter("@visitor", _visitor);
            dtm[5] = new SqlParameter("@oddname", _oddname);
            dtm[6] = new SqlParameter("@odd", _odd);           
            dtm[7] = new SqlParameter("@betdate", DateTime.Now);
            dtm[8] = new SqlParameter("@StartTime", _stime);
            
            dtmatches = mybridge.ExecuteDataset("Approved_set", dtm).Tables[0];
            //mybridge.ExecuteDataset("Approved_sets", dtm);
            res = "success";
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "un successful";
        }
        return dtmatches;
    }
    public DataTable Getbetted_sets()
    {
        string res = null;
        DataTable dtmatches = new DataTable();
        try
        {
            SqlParameter[] dtm = new SqlParameter[1];
            dtm[0] = new SqlParameter("@MatchNo", _matno);

            dtmatches = mybridge.ExecuteDataset("Getbetted_sets").Tables[0];
            //mybridge.ExecuteDataset("Approved_sets", dtm);
            res = "success";
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "un successful";
        }
        return dtmatches;
    }


    public DataTable GetApproved_match()
    {
        string res = null;
        DataTable dtmatches = new DataTable();
        try
        {
            SqlParameter[] dtm = new SqlParameter[1];

            dtm[0] = new SqlParameter("@MatchNo", _matno);

            dtmatches = mybridge.ExecuteDataset("GetApproved_match", dtm).Tables[0];
            //mybridge.ExecuteDataset("Approved_sets", dtm);
            res = "success";
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "un successful";
        }
        return dtmatches;
    }

    public DataTable GetsomevaluesfromClientsSet()
    {
        string res = null;
        DataTable dtmatches = new DataTable();
        try
        {
            SqlParameter[] dtm = new SqlParameter[2];

            dtm[0] = new SqlParameter("@username", _username);
            dtm[1] = new SqlParameter("@betID", _betID);
           

            dtmatches = mybridge.ExecuteDataset("GetsomevaluesfromClientsSet", dtm).Tables[0];
            //mybridge.ExecuteDataset("Approved_sets", dtm);
            res = "success";
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "un successful";
        }
        return dtmatches;
    }

    public DataTable Getstruegames()
    {
        string res = null;
        DataTable dtmatches = new DataTable();
        try
        {
            SqlParameter[] dtm = new SqlParameter[3];

            dtm[0] = new SqlParameter("@username", _username);
            dtm[1] = new SqlParameter("@betID", _betID);
            dtm[2] = new SqlParameter("@betdate", _betdate);


            dtmatches = mybridge.ExecuteDataset("Getstruegames", dtm).Tables[0];
            //mybridge.ExecuteDataset("Approved_sets", dtm);
            res = "success";
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "un successful";
        }
        return dtmatches;
    }
    public DataTable Getsmsmatches ()
    {
        string res = null;
        DataTable dtmatches = new DataTable();
        try
        {
            SqlParameter[] dtm = new SqlParameter[1];

            dtm[0] = new SqlParameter("@MatchNo", _matno);
            
            dtmatches = mybridge.ExecuteDataset("Getsmsmatches", dtm).Tables[0];
            //mybridge.ExecuteDataset("Approved_sets", dtm);
            res = "success";
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "un successful";
        }
        return dtmatches;
    }

    public DataTable TestifTeamscodeExist(string TeamCode)
    {
        string res = null;
        DataTable dtmatches = new DataTable();
        try
        {
            SqlParameter[] dtm = new SqlParameter[1];

            dtm[0] = new SqlParameter("@TeamCode", TeamCode.Trim());

            dtmatches = mybridge.ExecuteDataset("TestifTeamscodeExist", dtm).Tables[0];
            //mybridge.ExecuteDataset("Approved_sets", dtm);
            res = "success";
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "un successful";
        }
        return dtmatches;
    }



    //[]GetsomevaluesfromClientsSet
    //public string denysetresult()
    //{
    //    string res = null;
    //    try
    //    {
    //        SqlParameter[] dtm = new SqlParameter[1];

    //        dtm[0] = new SqlParameter("@MatchNo", _matno.Trim());

    //        mybridge.ExecuteDataset("deny_set_results", dtm);
    //        res = "success";
    //    }
    //    catch (Exception ex)
    //    {
    //        String error = ex.Message;
    //        res = "un successful";
    //    }
    //    return res;
    //}
    public string SaveApproved_set()
    {
        string res = null;
        DataTable dtmatches = new DataTable();
        try
        {
            SqlParameter[] dtm = new SqlParameter[5];

            dtm[0] = new SqlParameter("@oddname", _oddname);
            dtm[1] = new SqlParameter("@username", _username);
            dtm[2] = new SqlParameter("@MatchNo", _matno);
            dtm[3] = new SqlParameter("@betID", _betID);
            dtm[4] = new SqlParameter("@flag", _flag);

             mybridge.ExecuteDataset("SaveApproved_set", dtm);
            //mybridge.ExecuteDataset("Approved_sets", dtm);
            res = "success";
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "un successful";
        }
        return res;
    }
    public string put_cash_set()
    {
        string res = null;
        DataTable dtmatches = new DataTable();
        try
        {
            SqlParameter[] dtm = new SqlParameter[5];
         
            dtm[0] = new SqlParameter("@username", _username);            
            dtm[1] = new SqlParameter("@betID", _betID);
            dtm[2] = new SqlParameter("@betdate", _betdate);

           // mybridge.ExecuteDataset("put_cash_set", dtm);
            //mybridge.ExecuteDataset("Approved_sets", dtm);
            res = "success";
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "un successful";
        }
        return res;
    }
    public string give_now()
    {
        string res = null;
        DataTable dtmatches = new DataTable();
        try
        {
            SqlParameter[] dtm = new SqlParameter[16];
            
            dtm[0] = new SqlParameter("@username", _username);
            dtm[1] = new SqlParameter("@betID", _betID);
            dtm[2] = new SqlParameter("@MatchNo", _matno);
            dtm[3] = new SqlParameter("@oddname", _oddname);
            dtm[4] = new SqlParameter("@host", _host);
            dtm[5] = new SqlParameter("@visitor", _visitor);
            dtm[6] = new SqlParameter("@ttmoney", _ttmoney);
            dtm[7] = new SqlParameter("@odd", _odd);
            dtm[8] = new SqlParameter("@phonenum", _phonenum);
            dtm[9] = new SqlParameter("@wonmessage", "You have won shs " + _ttmoney + " from sets bets No " + _betID);
            dtm[10] = new SqlParameter("@losemessage", "You have won shs 0 from sets bets No " + _betID);
            dtm[11] = new SqlParameter("@betdate", _betdate);            
            dtm[12] = new SqlParameter("@betmoney", _betmoney);
            dtm[13] = new SqlParameter("@setodd", _setodd);
            dtm[14] = new SqlParameter("@setsize", _setsize);
            dtm[15] = new SqlParameter("@controller", _username);

            mybridge.ExecuteDataset("give_now", dtm);
            //mybridge.ExecuteDataset("Approved_sets", dtm);
            res = "success";
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "un successful";
        }
        return res;
    }
    public DataTable getdetailsmatchessets()
    {
        DataTable dtmatches = new DataTable();
        string res = null;
        try
        {
            SqlParameter[] dtm = new SqlParameter[1];
            dtm[0] = new SqlParameter("@MatchNo", matno);

            dtmatches = mybridge.ExecuteDataset("getdetailsmatchessets", dtm).Tables[0];
            res = "success";
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "un successful";
        }
        return dtmatches;
    }
    public DataTable saveTeamcodes()
    {
        DataTable dtmatches = new DataTable();
        string res = null;
        try
        {
            SqlParameter[] dtm = new SqlParameter[11];
            
            dtm[0] = new SqlParameter("@league", _champ);
            dtm[1] = new SqlParameter("@MatchCode", _matno);
            dtm[2] = new SqlParameter("@home", _host);
            dtm[3] = new SqlParameter("@away", _visitor);
            dtm[4] = new SqlParameter("@homeodd", _odd);
            dtm[5] = new SqlParameter("@awayodd", _oddaway);
            dtm[6] = new SqlParameter("@drawodd", _odddraw);
            dtm[7] = new SqlParameter("@homecode", _homecode);
            dtm[8] = new SqlParameter("@awaycode", _awaycode);
            dtm[9] = new SqlParameter("@drawcode", _drawcode);
            dtm[10] = new SqlParameter("@startTime", _stime);

            dtmatches = mybridge.ExecuteDataset("SaveTeamcode", dtm).Tables[0];
            res = "success";
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "un successful";
        }
        return dtmatches;
    }
    public DataTable GetTeamscode()
    {
        DataTable dtmatches = new DataTable();
        string res = null;
        try
        {

            dtmatches = mybridge.ExecuteDataset("GetTeamscode").Tables[0];
            res = "success";
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "un successful";
        }
        return dtmatches;
    }

    public DataTable deleteteamcode()
    {
        string res = null;
        DataTable dtmatches = new DataTable();
        try
        {
            SqlParameter[] dtm = new SqlParameter[1];

            dtm[0] = new SqlParameter("@MatchNo", _matno);

            dtmatches = mybridge.ExecuteDataset("deleteteamcode", dtm).Tables[0];
            //mybridge.ExecuteDataset("Approved_sets", dtm);
            
            res = "success";
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "un successful";
        }
        return dtmatches;
    }

    public DataTable getmatchbettedon()
    {
        DataTable dtmatches = new DataTable();
        string res = null;
        try
        {
            SqlParameter[] dtm = new SqlParameter[1];
            dtm[0] = new SqlParameter("@MatchNo", matno);

            dtmatches = mybridge.ExecuteDataset("getmatchbettedon", dtm).Tables[0];
            res = "success";
        }
        catch (Exception ex)
        {
            String error = ex.Message;
            res = "un successful";
        }
        return dtmatches;
    }
    //public string epay()
    //{
    //    DataTable dt = new DataTable();
    //    string res = null;
    //    string users = null;

    //    try
    //    {
    //        SqlParameter[] dtm = new SqlParameter[5];

    //        dtm[0] = new SqlParameter("@username", _username.Trim());
    //        dtm[1] = new SqlParameter("@balbefore", balbefore);
    //        dtm[2] = new SqlParameter("@amount", _amount);
    //        dtm[3] = new SqlParameter("@serial", _serial.Trim());
    //        dtm[4] = new SqlParameter("@controller", _controller);
    //        //dtm[2] = new SqlParameter("@serial", _serial.Trim());

    //        dt = mybridge.ExecuteDataset("pay_epay", dtm).Tables[0];

    //        foreach (DataRow dr in dt.Rows)
    //        {
    //            users = dr["userID"].ToString();
    //        }

    //        if (users.Length != 0)
    //        {
    //            res = "success";
    //        }
    //        else
    //        {
    //            res = "failed";
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        String error = ex.Message;
    //        res = "failed";
    //    }
    //    return res;
    //}
}
