using System;
using System.ComponentModel;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;


    public struct RequestResponse
    {
        public String Status;
        public String TransID;
        public String Amount;
        public String ReferenceField;
        public String MSISDN;
        public String Message;
    }
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    /// 
    [WebService(Namespace = "http://www.zain.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        public RequestResponse requestres;

        private void Assignvalues(String username, String password, String transID, String amount, String referenceField, String MSISDN, String MerchantAMN)
        {
            
                String _response = null,_msg=null;

                if ((username == "globalbets") && (password == "dewilos"))
                {

                 updateAccounts(username,password,transID,amount, referenceField, MSISDN, MerchantAMN);
                _response = requestres.Status;
                _msg = requestres.Message;

                if (_response == "Success")
                {
                    requestres.Status = "0";
                    requestres.TransID = transID;
                    requestres.Amount = amount;
                    requestres.ReferenceField = referenceField;
                    requestres.MSISDN = MSISDN;
                    requestres.Message = _msg;
                }
                else
                {
                    requestres.Status = "1";
                    requestres.TransID = transID;
                    requestres.Amount = amount;
                    requestres.ReferenceField = referenceField;
                    requestres.MSISDN = MSISDN;
                    requestres.Message = _msg;
                }
            }else{
                requestres.Status = "1";
                requestres.TransID = transID;
                requestres.Amount = amount;
                requestres.ReferenceField = referenceField;
                requestres.MSISDN = MSISDN;
                requestres.Message = "Transaction Failed Token Issued:Incorrect Authentication";
                
                }         

        }
        public void update_own_account(String username, String transID, String amount, String referenceField, String MSISDN, String MerchantAMN)
        {

            Decimal _cashbal = 0;
            int _cashbala = 0, _Amount = 0;
            DateTime date = DateTime.Now;
            Decimal _ammount = 0;
            String _user = null, _process = "error", msg = null;
            String _msg = null;

            System.Configuration.Configuration rootWebConfig =
                                         System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("//template046");
            System.Configuration.ConnectionStringSettings connString;

            if (0 < rootWebConfig.ConnectionStrings.ConnectionStrings.Count)
            {

                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["betConnectionString"];

                if (null != connString)
                {

                    String con1 = connString.ConnectionString;
                    SqlConnection conn = new SqlConnection(con1);
                    try
                    {
                        conn.Open();

                        SqlCommand cmd1 = new SqlCommand("select username,pnumber from users Where (pnumber = @pnumber)", conn);
                        cmd1.Parameters.AddWithValue("@pnumber", MSISDN);
                        SqlDataReader reader = cmd1.ExecuteReader();
                        while (reader.Read())
                        {
                            //Assign to your strings here
                            _user = reader["username"].ToString();
                        }
                        conn.Close();

                        if (_user != null)
                        {
                            _process = "Success";
                           _msg = "Transaction suceeded Token Issued";
                        }
                        else
                        {
                            _process = "Failed";
                            _msg = "Invalid Username";
                        }
                    }
                    catch (Exception ex)
                    {
                        string error = ex.Message;
                        _process = error;
                    }

                    try
                    {
                        conn.Open();

                        SqlCommand cmd1 = new SqlCommand("select ammount_e from deposits Where (userID = @userID)", conn);
                        cmd1.Parameters.AddWithValue("@userID", _user);
                        SqlDataReader reader = cmd1.ExecuteReader();
                        while (reader.Read())
                        {
                            //Assign to your strings here
                            _cashbal = Convert.ToDecimal(reader["ammount_e"]);

                        }
                        conn.Close();
                        _process = "Success";
                        _msg = "Transaction suceeded Token Issued";
                    }
                    catch (Exception ex)
                    {
                        string error = ex.Message;
                        _msg = error;
                    }

                    // Test the ammount Sent........

                    if ((amount != "") && (_user != null))
                    {
                        if (_cashbal != 0)
                        {
                            _cashbala = Convert.ToInt32(_cashbal);
                        }
                        //Start the process
                        _ammount = Convert.ToDecimal(amount);
                        _Amount = Convert.ToInt32(_ammount);
                        _cashbala = _cashbala + _Amount;

                        try
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("UPDATE deposits SET ammount_e=@ammount_e,date_e=@date_e WHERE (userID=@userID)", conn);
                            cmd.Parameters.AddWithValue("@userID", _user);
                            cmd.Parameters.AddWithValue("@ammount_e", _cashbala);
                            cmd.Parameters.AddWithValue("@date_e", date);

                            cmd.Connection = conn;
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            _process = "Success";
                            _msg = "Transaction suceeded Token Issued";
                        }
                        catch (Exception ex)
                        {
                            string error = ex.Message;
                            _msg = error;
                        }
                        try
                        {
                            conn.Open();
                            SqlCommand cmd1 = new SqlCommand("insert into stmts(account, transcation,method,controller,StatetmentDate,serial, balbefore,ammount,BalAfter)values(@account, @transcation,@method,@controller,@StatetmentDate,@serial, @balbefore,@ammount,@BalAfter)", conn);

                            cmd1.Parameters.AddWithValue("@account", _user);
                            cmd1.Parameters.AddWithValue("@transcation", "Deposite" + " " + _Amount + " " + "on my Account");
                            cmd1.Parameters.AddWithValue("@method", "ZAP");
                            cmd1.Parameters.AddWithValue("@controller", MSISDN);
                            cmd1.Parameters.AddWithValue("@StatetmentDate", date);
                            cmd1.Parameters.AddWithValue("@serial", transID);
                            cmd1.Parameters.AddWithValue("@balbefore", _cashbal);
                            cmd1.Parameters.AddWithValue("@ammount", _Amount);
                            cmd1.Parameters.AddWithValue("@BalAfter", _cashbala);

                            cmd1.Connection = conn;
                            cmd1.ExecuteNonQuery();
                            conn.Close();
                            _process = "Success";
                            _msg = "Transaction suceeded Token Issued";
                        }
                        catch (Exception ex)
                        {
                            string error = ex.Message;
                            _msg = error;

                        }
                    }
                    else
                    {
                        _process = "Failed";
                        _msg = "Invalid Username Token Issued";
                    }
                }
                else
                {

                    string error = "Database Connection Failed";
                    _process = error;
                }
                requestres.Status = _process;
                requestres.Message = _msg;
            }
        }
        public void update_someone_account(String username, String transID, String amount, String referenceField, String MSISDN, String MerchantAMN)
        {

            Decimal _cashbal = 0;
            int _cashbala = 0, _Amount = 0;
            String _process = null;
            DateTime date = DateTime.Now;
            Decimal _ammount = 0;
            requestres.Status = "error";
            String _usernn=null;
            String _msg = null;

            System.Configuration.Configuration rootWebConfig =
                                         System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("//template046");
            System.Configuration.ConnectionStringSettings connString;

            if (0 < rootWebConfig.ConnectionStrings.ConnectionStrings.Count)
            {

                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["betConnectionString"];

                if (null != connString)
                {

                    String con1 = connString.ConnectionString;
                    SqlConnection conn = new SqlConnection(con1);

                    try
                    {
                        conn.Open();

                        SqlCommand cmd1 = new SqlCommand("select userID,ammount_e from deposits Where (userID = @userID)", conn);
                        cmd1.Parameters.AddWithValue("@userID", username);
                        SqlDataReader reader = cmd1.ExecuteReader();
                        while (reader.Read())
                        {
                            //Assign to your strings here
                            _cashbal = Convert.ToDecimal(reader["ammount_e"]);
                             _usernn = reader["userID"].ToString();
                        }
                        conn.Close();

                        if (_usernn != null)
                        {
                            _process = "Success";
                            _msg = "Transaction suceeded Token Issued";
                        }
                        else
                        {
                            _process = "Failed";
                            _msg = "Invalid Username Token Issued";
                        }
                    }
                    catch (Exception ex)
                    {
                        string error = ex.Message;
                        _msg = error;
                    }

                    // Test the ammount Sent........

                    if ((amount != "")&&(_usernn!=null))
                    {
                        if (_cashbal != 0)
                        {
                            _cashbala = Convert.ToInt32(_cashbal);
                        }
                        //Start the process
                        _ammount = Convert.ToDecimal(amount);
                        _Amount = Convert.ToInt32(_ammount);
                        _cashbala = _cashbala + _Amount;

                        try
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("UPDATE deposits SET ammount_e=@ammount_e,date_e=@date_e WHERE (userID= @userID)", conn);
                            cmd.Parameters.AddWithValue("@userID", username);
                            cmd.Parameters.AddWithValue("@ammount_e", _cashbala);
                            cmd.Parameters.AddWithValue("@date_e", date);

                            cmd.Connection = conn;
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            _process = "Success";
                            _msg = "Transaction suceeded Token Issued";
                        }
                        catch (Exception ex)
                        {
                            string error = ex.Message;
                            _msg = error;
                        }
                        try
                        {
                            conn.Open();
                            SqlCommand cmd1 = new SqlCommand("insert into stmts(account, transcation,method,controller,StatetmentDate,serial, balbefore,ammount,BalAfter)values(@account, @transcation,@method,@controller,@StatetmentDate,@serial, @balbefore,@ammount,@BalAfter)", conn);

                            cmd1.Parameters.AddWithValue("@account", username);
                            cmd1.Parameters.AddWithValue("@transcation", "Deposite" + " " + _Amount + " " + "on my Account");
                            cmd1.Parameters.AddWithValue("@method", "ZAP");
                            cmd1.Parameters.AddWithValue("@controller", MSISDN);
                            cmd1.Parameters.AddWithValue("@StatetmentDate", date);
                            cmd1.Parameters.AddWithValue("@serial", transID);
                            cmd1.Parameters.AddWithValue("@balbefore", _cashbal);
                            cmd1.Parameters.AddWithValue("@ammount", _Amount);
                            cmd1.Parameters.AddWithValue("@BalAfter", _cashbala);

                            cmd1.Connection = conn;
                            cmd1.ExecuteNonQuery();
                            conn.Close();
                            _process = "Success";
                            _msg = "Transaction suceeded Token Issued";
                        }
                        catch (Exception ex)
                        {
                            string error = ex.Message;
                            _msg = error;

                        }
                    }
                    else
                    {
                        _process = "Failed";
                        _msg = "Invalid Username Token Issued";
                    }
                }
                else
                {
                    _msg = "Database Connection Failed";
                    
                }
                requestres.Status = _process;
                requestres.Message = _msg;
            }
        }
        public void bet_with_phone(String user, String matchno, String amount, String MSISDN, String result)
        {
            String _msg = null;
            String _process = null;
            String _category = "Sure Deal";
            String _category1 = "Straight Line";
            String _user = null;
            String _champ = null;
            String _setno = null;
            String _matno = null;
            String _host = null;
            String _vs = null;
            String _visitor = null;
            String _winhome = null;
            String _losehome = null;
            String _winaway = null;
            String _loseaway = null;
            String _oddhome = null;
            String _oddaway = null;
            String _odddraw = null;
            DateTime _date2de = DateTime.Now;
            DateTime _stime = new DateTime();
            Decimal mney = 0;

            System.Configuration.Configuration rootWebConfig =
                                        System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("//template046");
            System.Configuration.ConnectionStringSettings connString;

            if (0 < rootWebConfig.ConnectionStrings.ConnectionStrings.Count)
            {

                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["betConnectionString"];

                if (null != connString)
                {

                    String con1 = connString.ConnectionString;
                    SqlConnection conn = new SqlConnection(con1);

                    try
                    {
                        conn.Open();

                        SqlCommand cmd1 = new SqlCommand("select username,pnumber from users Where (pnumber = @pnumber)", conn);
                        cmd1.Parameters.AddWithValue("@pnumber", MSISDN);
                        SqlDataReader reader = cmd1.ExecuteReader();
                        while (reader.Read())
                        {
                            //Assign to your strings here
                            _user = reader["username"].ToString();
                        }
                        conn.Close();

                        if (_user != null)
                        {
                            _process = "Success";
                            _msg = "Bet Received.Thank you";
                        }
                        else
                        {
                            _user = MSISDN;
                            //_msg = "Invalid Username";
                        }
                    }
                    catch (Exception ex)
                    {
                        string error = ex.Message;
                        _process = error;
                    }

                    try
                    {
                        conn.Open();

                        SqlCommand cmd1 = new SqlCommand("select champ,setno,MatchNo,host,vs,visitor,winhome,losehome,winaway,loseaway,StartTime from betmatch4 Where (MatchNo = @MatchNo)", conn);
                        cmd1.Parameters.AddWithValue("@MatchNo", matchno);
                        SqlDataReader reader = cmd1.ExecuteReader();
                        while (reader.Read())
                        {
                            //Assign to your strings here
                            // _category = reader["category"].ToString();
                            _champ = reader["champ"].ToString();
                            _setno = reader["setno"].ToString();
                            _matno = reader["MatchNo"].ToString();
                            _host = reader["host"].ToString();
                            _vs = reader["vs"].ToString();
                            _visitor = reader["visitor"].ToString();
                            _winhome = reader["winhome"].ToString();
                            _losehome = reader["losehome"].ToString();
                            _winaway = reader["winaway"].ToString();
                            _loseaway = reader["loseaway"].ToString();
                            _stime = Convert.ToDateTime(reader["StartTime"]);

                            if (_matno != null)
                            {

                                _process = "Success";
                                _msg = "Bet Received.Thank you";
                            }
                            else
                            {
                                _process = "Failed";
                                _msg = "Invalid Match code";
                            }

                        }
                        conn.Close();

                    }
                    catch (Exception ex)
                    {
                        string error = ex.Message;
                        _msg = "Duplicate Bet";
                    }

                    if (_matno != null)
                    {
                        mney = Convert.ToDecimal(amount.ToString());
                        if (result == "1")
                        {

                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("insert into setbetmatches3(username, betdate,betmoney,category,champ,setno, MatchNo,host,vs,visitor,oddname,oddwin,oddlose,StartTime,phone)values(@username, @betdate,@betmoney,@category,@champ,@setno,@MatchNo,@host,@vs,@visitor,@oddname,@oddwin,@oddlose,@StartTime,@phone)", conn);

                                cmd.Parameters.AddWithValue("@username", _user);
                                cmd.Parameters.AddWithValue("@betdate", _date2de);
                                cmd.Parameters.AddWithValue("@betmoney", amount);
                                cmd.Parameters.AddWithValue("@category", _category);
                                cmd.Parameters.AddWithValue("@champ", _champ);
                                cmd.Parameters.AddWithValue("@setno", _setno);
                                cmd.Parameters.AddWithValue("@MatchNo", matchno);
                                cmd.Parameters.AddWithValue("@host", _host);
                                cmd.Parameters.AddWithValue("@vs", _vs);
                                cmd.Parameters.AddWithValue("@visitor", _visitor);
                                cmd.Parameters.AddWithValue("@oddname", "home");
                                cmd.Parameters.AddWithValue("@oddwin", _winhome);
                                cmd.Parameters.AddWithValue("@oddlose", _losehome);
                                cmd.Parameters.AddWithValue("@StartTime", _stime);
                                cmd.Parameters.AddWithValue("@phone", MSISDN);

                                cmd.Connection = conn;
                                cmd.ExecuteNonQuery();
                                conn.Close();

                                _process = "Success";
                                _msg = "Bet Received.Thank you";
                            }
                            catch (Exception ex)
                            {
                                string error = ex.Message;
                                _msg = "Duplicate Bet";
                                _process = "Failed";
                            }
                        }
                        else if (result == "2")
                        {
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("insert into setbetmatches3(username, betdate,betmoney,category,champ,setno, MatchNo,host,vs,visitor,oddname,oddwin,oddlose,StartTime,phone)values(@username, @betdate,@betmoney,@category,@champ,@setno,@MatchNo,@host,@vs,@visitor,@oddname,@oddwin,@oddlose,@StartTime,@phone)", conn);

                                cmd.Parameters.AddWithValue("@username", _user);
                                cmd.Parameters.AddWithValue("@betdate", _date2de);
                                cmd.Parameters.AddWithValue("@betmoney", amount);
                                cmd.Parameters.AddWithValue("@category", _category);
                                cmd.Parameters.AddWithValue("@champ", _champ);
                                cmd.Parameters.AddWithValue("@setno", _setno);
                                cmd.Parameters.AddWithValue("@MatchNo", matchno);
                                cmd.Parameters.AddWithValue("@host", _host);
                                cmd.Parameters.AddWithValue("@vs", _vs);
                                cmd.Parameters.AddWithValue("@visitor", _visitor);
                                cmd.Parameters.AddWithValue("@oddname", "away");
                                cmd.Parameters.AddWithValue("@oddwin", _winaway);
                                cmd.Parameters.AddWithValue("@oddlose", _loseaway);
                                cmd.Parameters.AddWithValue("@StartTime", _stime);
                                cmd.Parameters.AddWithValue("@phone", MSISDN);

                                cmd.Connection = conn;
                                cmd.ExecuteNonQuery();
                                conn.Close();

                                _process = "Success";
                                _msg = "Bet Received.Thank you";
                            }
                            catch (Exception ex)
                            {
                                string error = ex.Message;
                                _msg = "Duplicate Bet";
                                _process = "Failed";
                            }

                        }
                        if (_process == "Success")
                        {
                            putinaccount(_user, mney, _category);
                            fillgames(_setno, matchno);
                            sure_deal_putmoney(_setno, matchno);
                        }

                    }//.......................................................
                    else
                    {
                        try
                        {
                            conn.Open();

                            SqlCommand cmd1 = new SqlCommand("select champ,setno,MatchNo,host,vs,visitor,StartTime,oddhome,oddaway,odddraw from  betmatch1 Where (MatchNo = @MatchNo)", conn);
                            cmd1.Parameters.AddWithValue("@MatchNo", matchno);
                            SqlDataReader reader = cmd1.ExecuteReader();
                            while (reader.Read())
                            {
                                //Assign to your strings here
                                // _category = reader["category"].ToString();
                                _champ = reader["champ"].ToString();
                                _setno = reader["setno"].ToString();
                                _matno = reader["MatchNo"].ToString();
                                _host = reader["host"].ToString();
                                _vs = reader["vs"].ToString();
                                _visitor = reader["visitor"].ToString();
                                _oddhome = reader["oddhome"].ToString();
                                _oddaway = reader["oddaway"].ToString();
                                _odddraw = reader["odddraw"].ToString();
                                _stime = Convert.ToDateTime(reader["StartTime"]);

                            }
                            conn.Close();
                            if (_matno != null)
                            {

                                _process = "Success";
                                _msg = "Transaction suceeded Token Issued";
                            }
                            else
                            {
                                _process = "Failed";
                                _msg = "Invalid Match code";
                            }
                        }
                        catch (Exception ex)
                        {
                            string error = ex.Message;
                            _process = error;
                        }
                        if (_matno != null)
                        {
                          Decimal _ttmon2hand=0;
                            mney = Convert.ToDecimal(amount.ToString());
       
                            if (result == "1")
                            {
                                 _ttmon2hand = Convert.ToDecimal(_oddhome.ToString());

                                 _ttmon2hand = ((_ttmon2hand / 100) * mney);
                                 _ttmon2hand = Math.Round(_ttmon2hand, 2);

                                try
                                {
                                    conn.Open();
                                    SqlCommand cmd = new SqlCommand("insert into setbetmatches1(username, betdate,betmoney,champ,category,setno,MatchNo,host,vs,visitor,oddname,odd,ttmoney,StartTime,phone)values(@username, @betdate,@betmoney,@champ,@category,@setno,@MatchNo,@host,@vs,@visitor,@oddname,@odd,@ttmoney,@StartTime,@phone)", conn);

                                    cmd.Parameters.AddWithValue("@username", _user);
                                    cmd.Parameters.AddWithValue("@betdate", _date2de);
                                    cmd.Parameters.AddWithValue("@betmoney", amount);
                                    cmd.Parameters.AddWithValue("@champ", _champ);
                                    cmd.Parameters.AddWithValue("@category", _category1);
                                    cmd.Parameters.AddWithValue("@setno", _setno);
                                    cmd.Parameters.AddWithValue("@MatchNo", matchno);
                                    cmd.Parameters.AddWithValue("@host", _host);
                                    cmd.Parameters.AddWithValue("@vs", _vs);
                                    cmd.Parameters.AddWithValue("@visitor", _visitor);
                                    cmd.Parameters.AddWithValue("@oddname", "home");
                                    cmd.Parameters.AddWithValue("@odd", _oddhome);
                                    cmd.Parameters.AddWithValue("@ttmoney", _ttmon2hand);
                                    cmd.Parameters.AddWithValue("@StartTime", _stime);
                                    cmd.Parameters.AddWithValue("@phone", MSISDN);

                                    cmd.Connection = conn;
                                    cmd.ExecuteNonQuery();
                                    conn.Close();

                                    _process = "Success";
                                    _msg = "Bet Received.Thank you";
                                }
                                catch (Exception ex)
                                {
                                    string error = ex.Message;
                                    _msg = "Duplicate Bet";
                                    _process = "Failed";
                                }
                            }
                            else if (result == "2")
                            {
                                _ttmon2hand = Convert.ToDecimal(_oddaway.ToString());

                                _ttmon2hand = ((_ttmon2hand / 100) * mney);
                                _ttmon2hand = Math.Round(_ttmon2hand, 2);
                                try
                                {
                                    conn.Open();
                                    SqlCommand cmd = new SqlCommand("insert into setbetmatches1(username, betdate,betmoney,champ,category,setno,MatchNo,host,vs,visitor,oddname,odd,ttmoney,StartTime,phone)values(@username, @betdate,@betmoney,@champ,@category,@setno,@MatchNo,@host,@vs,@visitor,@oddname,@odd,@ttmoney,@StartTime,@phone)", conn);

                                    cmd.Parameters.AddWithValue("@username", _user);
                                    cmd.Parameters.AddWithValue("@betdate", _date2de);
                                    cmd.Parameters.AddWithValue("@betmoney", amount);
                                    cmd.Parameters.AddWithValue("@champ", _champ);
                                    cmd.Parameters.AddWithValue("@category", _category1);
                                    cmd.Parameters.AddWithValue("@setno", _setno);
                                    cmd.Parameters.AddWithValue("@MatchNo", matchno);
                                    cmd.Parameters.AddWithValue("@host", _host);
                                    cmd.Parameters.AddWithValue("@vs", _vs);
                                    cmd.Parameters.AddWithValue("@visitor", _visitor);
                                    cmd.Parameters.AddWithValue("@oddname", "away");
                                    cmd.Parameters.AddWithValue("@odd", _oddaway);
                                    cmd.Parameters.AddWithValue("@ttmoney", _ttmon2hand);
                                    cmd.Parameters.AddWithValue("@StartTime", _stime);
                                    cmd.Parameters.AddWithValue("@phone", MSISDN);

                                    cmd.Connection = conn;
                                    cmd.ExecuteNonQuery();
                                    conn.Close();

                                    _process = "Success";
                                    _msg = "Transaction suceeded Token Issued";
                                }
                                catch (Exception ex)
                                {
                                    string error = ex.Message;
                                    _msg = "Duplicate Bet";
                                    _process = "Failed";
                                }

                            }
                            else if (result == "3")
                            {
                                _ttmon2hand = Convert.ToDecimal(_odddraw.ToString());

                                _ttmon2hand = ((_ttmon2hand / 100) * mney);
                                _ttmon2hand = Math.Round(_ttmon2hand, 2);
                                try
                                {
                                    conn.Open();
                                    SqlCommand cmd = new SqlCommand("insert into setbetmatches1(username, betdate,betmoney,champ,category,setno,MatchNo,host,vs,visitor,oddname,odd,ttmoney,StartTime,phone)values(@username, @betdate,@betmoney,@champ,@category,@setno,@MatchNo,@host,@vs,@visitor,@oddname,@odd,@ttmoney,@StartTime,@phone)", conn);

                                    cmd.Parameters.AddWithValue("@username", _user);
                                    cmd.Parameters.AddWithValue("@betdate", _date2de);
                                    cmd.Parameters.AddWithValue("@betmoney", amount);
                                    cmd.Parameters.AddWithValue("@champ", _champ);
                                    cmd.Parameters.AddWithValue("@category", _category1);
                                    cmd.Parameters.AddWithValue("@setno", _setno);
                                    cmd.Parameters.AddWithValue("@MatchNo", matchno);
                                    cmd.Parameters.AddWithValue("@host", _host);
                                    cmd.Parameters.AddWithValue("@vs", _vs);
                                    cmd.Parameters.AddWithValue("@visitor", _visitor);
                                    cmd.Parameters.AddWithValue("@oddname", "draw");
                                    cmd.Parameters.AddWithValue("@odd", _odddraw);
                                    cmd.Parameters.AddWithValue("@ttmoney", _ttmon2hand);
                                    cmd.Parameters.AddWithValue("@StartTime", _stime);
                                    cmd.Parameters.AddWithValue("@phone", MSISDN);

                                    cmd.Connection = conn;
                                    cmd.ExecuteNonQuery();
                                    conn.Close();

                                    _process = "Success";
                                    _msg = "Bet Received.Thank you";
                                }
                                catch (Exception ex)
                                {
                                    string error = ex.Message;
                                    _msg = "Duplicate Bet";
                                    _process = "Failed";
                                }
                            }
                            else
                            {
                                _process = "Failed";
                                _msg = "Unknown Match Result";
                            }
                            if (_process == "Success")
                            {
                                putinaccount(_user, mney, _category1);
                                //fillgames(_setno, matchno);
                            }
                        }
                        else
                        {
                            _process = "Failed";
                            _msg = "Unknown Match Code";
                        }
                    }
                }
                else
                {
                    string error = "Database Connection Failed";
                    _process = error;
                }

                requestres.Status = _process;
                requestres.Message = _msg;
            }
        }
        void putinaccount(String usernn, Decimal mney,String category)
        {
            DateTime nwdate = new DateTime();
            nwdate = DateTime.Now;
            Decimal amount_e1y = 0, total_ammountbet = 0;
            int b4 = 0, baf = 0, btmney = 0;
            SqlConnection conn = null;

            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["betConnectionString"].ConnectionString.ToString());

            try
            {
                conn.Open();
                //checking up money on one's Account

                SqlCommand cmd8 = new SqlCommand("select total_ammount from bet_account WHERE (account Like @account )", conn);
                cmd8.Parameters.AddWithValue("@account", "Bet Account");

                SqlDataReader reader1 = cmd8.ExecuteReader();
                while (reader1.Read())
                {
                    //Assign to your textbox here 
                    total_ammountbet = Convert.ToDecimal(reader1["total_ammount"].ToString());
                }
                cmd8.Connection = conn;
                conn.Close();

            }
            catch
            {

                //result.Text = "Error Occured, Please try Again!!!";
            }
            amount_e1y = total_ammountbet + mney;

            b4 = Convert.ToInt32(total_ammountbet);
            baf = Convert.ToInt32(amount_e1y);
            btmney = Convert.ToInt32(mney);
            try
            {
                conn.Open();
                //checking up money on one's Account

                SqlCommand cmd1 = new SqlCommand("insert into stmts(account, transcation,method,controller,StatetmentDate,serial, balbefore,ammount,BalAfter)values(@account, @transcation,@method,@controller,@StatetmentDate,@serial, @balbefore,@ammount,@BalAfter)", conn);

                cmd1.Parameters.AddWithValue("@account", "Bet Account");
                cmd1.Parameters.AddWithValue("@transcation", "Deposite bet Money" + " " + btmney);
                cmd1.Parameters.AddWithValue("@method", "Site Access");
                cmd1.Parameters.AddWithValue("@controller", usernn);
                cmd1.Parameters.AddWithValue("@StatetmentDate", nwdate);
                cmd1.Parameters.AddWithValue("@serial", category+" "+"Bet Matches");
                cmd1.Parameters.AddWithValue("@balbefore", b4);
                cmd1.Parameters.AddWithValue("@ammount", btmney);
                cmd1.Parameters.AddWithValue("@BalAfter", baf);

                cmd1.Connection = conn;
                cmd1.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                //result.Text = "Error Occured, Please try Again!!!";
            }
            try
            {
                conn.Open();
                SqlCommand cmd2 = new SqlCommand("UPDATE bet_account SET last_date=@last_date,total_ammount=@total_ammount WHERE (account Like @account )", conn);

                cmd2.Parameters.AddWithValue("@account", "Bet Account");
                cmd2.Parameters.AddWithValue("@last_date", nwdate);
                cmd2.Parameters.AddWithValue("@total_ammount", baf);

                cmd2.Connection = conn;
                cmd2.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                //result.Text = "Error Occured, Please try Again!!!";
            }

        }
        void sure_deal_putmoney(String settno, String mattno)
        {
            Decimal[] maneItems = new Decimal[1000000];
            Decimal[] oddwinItems = new Decimal[1000000];
            Decimal[] oddloseItems = new Decimal[1000000];
            String[] userItems = new String[1000000];

            int i = 0;

            SqlConnection conn = null;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["betConnectionString"].ConnectionString.ToString());
            try
            {
                conn.Open();
                //checking up money on one's Account
                string query3 = "select username,betmoney,oddwin,oddlose from setbetmatches3 WHERE (setno Like @setno AND MatchNo Like @MatchNo)";
                SqlCommand cmd8 = new SqlCommand(query3, conn);
                cmd8.Parameters.AddWithValue("@setno", settno);
                cmd8.Parameters.AddWithValue("@MatchNo", mattno);


                SqlDataReader reader1 = cmd8.ExecuteReader();
                while (reader1.Read())
                {
                    //Assign to your textbox here 
                    userItems[i] = reader1["username"].ToString();
                    maneItems[i] = Convert.ToDecimal(reader1["betmoney"].ToString());
                    oddwinItems[i] = Convert.ToDecimal(reader1["oddwin"].ToString());
                    oddloseItems[i] = Convert.ToDecimal(reader1["oddlose"].ToString());
                    i++;
                }
                cmd8.Connection = conn;
                conn.Close();
            }
            catch (Exception ex)
            {
                String result = ex.Message;
            }
            for (int j = 0; (maneItems[j] != 0) && (userItems[j] != null); j++)
            {
                Double oddwin = 0.0;
                Double oddlose = 0.0;
                Double maneitemi = 0.0;

                maneitemi = Convert.ToDouble(maneItems[j]);
                oddwin = Convert.ToDouble(oddwinItems[j]);
                oddlose = Convert.ToDouble(oddloseItems[j]);

                Decimal _ttmoney_win = 0;
                Decimal _ttmoney_lose = 0;

                _ttmoney_win = Convert.ToDecimal(maneitemi * oddwin);
                _ttmoney_lose = Convert.ToDecimal(maneitemi * oddlose);

                try
                {
                    conn.Open();
                    //checking up money on one's Account
                    String query = "UPDATE setbetmatches3 SET ttmoneywin = @ttmoneywin,ttmoneylose=@ttmoneylose WHERE (setno Like @setno AND MatchNo Like @MatchNo AND username Like @username AND betmoney Like @betmoney) ";
                    SqlCommand cmd0 = new SqlCommand(query, conn);
                    cmd0.Parameters.AddWithValue("@setno", settno);
                    cmd0.Parameters.AddWithValue("@MatchNo", mattno);
                    cmd0.Parameters.AddWithValue("@username", userItems[j]);
                    cmd0.Parameters.AddWithValue("@ttmoneywin", _ttmoney_win);
                    cmd0.Parameters.AddWithValue("@ttmoneylose", _ttmoney_lose);
                    cmd0.Parameters.AddWithValue("@betmoney", maneItems[j].ToString());

                    cmd0.Connection = conn;
                    cmd0.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    String result = ex.Message;
                }
            }
        }

        void sure_deal_away(Decimal ttAmmount, Double percent, Double percent1, String settno, String mattno)
        {
            Decimal[] maneItems = new Decimal[1000000];
            Decimal[] maniItems = new Decimal[1000000];
            int i = 0, j = 0, m = 0, n = 0;
            Decimal amm1 = 0;
            Double winhldamm1 = 0.0;
            Double losehldamm1 = 0.0;

            Double _maxodd = 0.0;
            Double _minodd = 0.0;

            Decimal ttbetmoney = 0, ttbetmoney1 = 0, wait2 = 0;
            int ttmone = 0, ttmone1 = 0;

            SqlConnection conn = null;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["betConnectionString"].ConnectionString.ToString());
            try
            {
                conn.Open();
                //checking up money on one's Account
                string query3 = "select betmoney from setbetmatches3 WHERE (setno Like @setno AND MatchNo Like @MatchNo AND oddname Like @oddname)";
                SqlCommand cmd8 = new SqlCommand(query3, conn);
                cmd8.Parameters.AddWithValue("@setno", settno);
                cmd8.Parameters.AddWithValue("@MatchNo", mattno);
                cmd8.Parameters.AddWithValue("@oddname", "home");

                SqlDataReader reader1 = cmd8.ExecuteReader();
                while (reader1.Read())
                {
                    //Assign to your textbox here 
                    maneItems[i] = Convert.ToDecimal(reader1["betmoney"].ToString());
                    ttbetmoney = ttbetmoney + maneItems[i];
                    i++; j++;
                }
                cmd8.Connection = conn;
                conn.Close();
            }
            catch
            {
                //result.Text = "Error Occured, Please try Again!!!";
            }

            try
            {
                conn.Open();
                //checking up money on one's Account
                string query3 = "select betmoney from setbetmatches3 WHERE (setno Like @setno AND MatchNo Like @MatchNo AND oddname Like @oddname)";
                SqlCommand cmd8 = new SqlCommand(query3, conn);
                cmd8.Parameters.AddWithValue("@setno", settno);
                cmd8.Parameters.AddWithValue("@MatchNo", mattno);
                cmd8.Parameters.AddWithValue("@oddname", "away");

                SqlDataReader reader1 = cmd8.ExecuteReader();
                while (reader1.Read())
                {
                    //Assign to your textbox here 
                    maniItems[m] = Convert.ToDecimal(reader1["betmoney"].ToString());
                    ttbetmoney1 = ttbetmoney1 + maniItems[m];
                    m++; n++;
                }
                cmd8.Connection = conn;
                conn.Close();
            }
            catch
            {
                //result.Text = "Error Occured, Please try Again!!!";
            }
            finally
            {
                conn.Close();
            }

            //Get the maximum and minimum odds

            try
            {
                conn.Open();
                //checking up money on one's Account
                string query3 = "select max_odd_away,min_odd_away from betmatch4 WHERE (setno Like @setno AND MatchNo Like @MatchNo)";
                SqlCommand cmd8 = new SqlCommand(query3, conn);
                cmd8.Parameters.AddWithValue("@setno", settno);
                cmd8.Parameters.AddWithValue("@MatchNo", mattno);

                SqlDataReader reader1 = cmd8.ExecuteReader();
                while (reader1.Read())
                {
                    //Assign to your textbox here 
                    _maxodd = Convert.ToDouble(reader1["max_odd_away"].ToString());
                    _minodd = Convert.ToDouble(reader1["min_odd_away"].ToString());
                }
                cmd8.Connection = conn;
                conn.Close();
            }
            catch
            {
                //result.Text = "Error Occured, Please try Again!!!";
            }
            finally
            {
                conn.Close();
            }

            Decimal hldpercent = 0;
            Decimal hldpercent1 = 0;
            hldpercent = Convert.ToDecimal(percent);
            hldpercent1 = Convert.ToDecimal(percent1);


            wait2 = ((ttAmmount / ttbetmoney1) * ((hldpercent / 100) * ttbetmoney)) + ttAmmount;
            //amm1 = (wait2 / ttAmmount) * 100;
            //ttmone = Convert.ToInt32(amm1);

            winhldamm1 = Convert.ToDouble(wait2 / ttAmmount);
            winhldamm1 = Math.Round(winhldamm1, 2);
            if (winhldamm1 >= _maxodd)
            {

                winhldamm1 = _maxodd;
            }
            if (winhldamm1 <= _minodd)
            {

                winhldamm1 = _minodd;
            }
            try
            {
                conn.Open();
                //checking up money on one's Account
                String query = "UPDATE betmatch4 SET winaway = @winaway WHERE(setno Like @setno AND MatchNo Like @MatchNo) ";
                SqlCommand cmd0 = new SqlCommand(query, conn);
                cmd0.Parameters.AddWithValue("@setno", settno);
                cmd0.Parameters.AddWithValue("@MatchNo", mattno);
                cmd0.Parameters.AddWithValue("@winaway", winhldamm1.ToString());
                //cmd8.Parameters.AddWithValue("@oddname", "away");

                cmd0.Connection = conn;
                cmd0.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                //result.Text = "Error Occured, Please try Again!!!";
            }
            try
            {
                conn.Open();
                //checking up money on one's Account
                String query = "UPDATE setbetmatches3 SET oddwin = @oddwin WHERE(setno Like @setno AND MatchNo Like @MatchNo AND oddname Like @oddname) ";
                SqlCommand cmd0 = new SqlCommand(query, conn);
                cmd0.Parameters.AddWithValue("@setno", settno);
                cmd0.Parameters.AddWithValue("@MatchNo", mattno);
                cmd0.Parameters.AddWithValue("@oddwin", winhldamm1.ToString());
                cmd0.Parameters.AddWithValue("@oddname", "away");

                cmd0.Connection = conn;
                cmd0.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                //result.Text = "Error Occured, Please try Again!!!";
            }

            //On the side of lossing ccccc
            wait2 = (ttAmmount * (hldpercent1 / 100));
            // amm1 = (wait2 / ttAmmount) * 100;
            // ttmone1 = Convert.ToInt32(amm1);

            losehldamm1 = Convert.ToDouble(wait2 / ttAmmount);
            losehldamm1 = Math.Round(losehldamm1, 2);

            try
            {
                conn.Open();
                //checking up money on one's Account
                String query = "UPDATE betmatch4 SET losehome = @losehome WHERE(setno Like @setno AND MatchNo Like @MatchNo) ";
                SqlCommand cmd0 = new SqlCommand(query, conn);
                cmd0.Parameters.AddWithValue("@setno", settno);
                cmd0.Parameters.AddWithValue("@MatchNo", mattno);
                cmd0.Parameters.AddWithValue("@losehome", losehldamm1.ToString());
                //cmd8.Parameters.AddWithValue("@oddname", "away");

                cmd0.Connection = conn;
                cmd0.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                //result.Text = "Error Occured, Please try Again!!!";
            }
            try
            {
                conn.Open();
                //checking up money on one's Account
                String query = "UPDATE setbetmatches3 SET oddlose = @oddlose WHERE(setno Like @setno AND MatchNo Like @MatchNo AND oddname Like @oddname) ";
                SqlCommand cmd0 = new SqlCommand(query, conn);
                cmd0.Parameters.AddWithValue("@setno", settno);
                cmd0.Parameters.AddWithValue("@MatchNo", mattno);
                cmd0.Parameters.AddWithValue("@oddlose", losehldamm1.ToString());
                cmd0.Parameters.AddWithValue("@oddname", "away");

                cmd0.Connection = conn;
                cmd0.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                //result.Text = "Error Occured, Please try Again!!!";
            }
            finally
            {
                conn.Close();
            }




        }
        void sure_deal(Decimal ttAmmount, Double percent, Double percent1, String settno, String mattno)
        {
            Decimal[] maneItems = new Decimal[1000000];
            Decimal[] maniItems = new Decimal[1000000];
            int i = 0, j = 0, m = 0, n = 0;
            Decimal amm1 = 0;
            Double winhldamm1 = 0.0;
            Double losehldamm1 = 0.0;

            Double _maxodd = 0.0;
            Double _minodd = 0.0;

            Decimal ttbetmoney = 0, ttbetmoney1 = 0, wait2 = 0;

            int ttmone = 0, ttmone1 = 0;

            SqlConnection conn = null;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["betConnectionString"].ConnectionString.ToString());
            try
            {
                conn.Open();
                //checking up money on one's Account
                string query3 = "select betmoney from setbetmatches3 WHERE (setno Like @setno AND MatchNo Like @MatchNo AND oddname Like @oddname)";
                SqlCommand cmd8 = new SqlCommand(query3, conn);
                cmd8.Parameters.AddWithValue("@setno", settno);
                cmd8.Parameters.AddWithValue("@MatchNo", mattno);
                cmd8.Parameters.AddWithValue("@oddname", "away");

                SqlDataReader reader1 = cmd8.ExecuteReader();
                while (reader1.Read())
                {
                    //Assign to your textbox here 
                    maneItems[i] = Convert.ToDecimal(reader1["betmoney"].ToString());
                    ttbetmoney = ttbetmoney + maneItems[i];
                    i++; j++;
                }
                cmd8.Connection = conn;
                conn.Close();
            }
            catch
            {
                //result.Text = "Error Occured, Please try Again!!!";
            }

            try
            {
                conn.Open();
                //checking up money on one's Account
                string query3 = "select betmoney from setbetmatches3 WHERE (setno Like @setno AND MatchNo Like @MatchNo AND oddname Like @oddname)";
                SqlCommand cmd8 = new SqlCommand(query3, conn);
                cmd8.Parameters.AddWithValue("@setno", settno);
                cmd8.Parameters.AddWithValue("@MatchNo", mattno);
                cmd8.Parameters.AddWithValue("@oddname", "home");

                SqlDataReader reader1 = cmd8.ExecuteReader();
                while (reader1.Read())
                {
                    //Assign to your textbox here 
                    maniItems[m] = Convert.ToDecimal(reader1["betmoney"].ToString());
                    ttbetmoney1 = ttbetmoney1 + maniItems[m];
                    m++; n++;
                }
                cmd8.Connection = conn;
                conn.Close();
            }
            catch
            {
                //result.Text = "Error Occured, Please try Again!!!";
            }

            //Get the minimum and maximum odds. 
            try
            {
                conn.Open();
                //checking up money on one's Account
                string query3 = "select max_odd_home,min_odd_home from betmatch4 WHERE (setno Like @setno AND MatchNo Like @MatchNo)";
                SqlCommand cmd8 = new SqlCommand(query3, conn);
                cmd8.Parameters.AddWithValue("@setno", settno);
                cmd8.Parameters.AddWithValue("@MatchNo", mattno);

                SqlDataReader reader1 = cmd8.ExecuteReader();
                while (reader1.Read())
                {
                    //Assign to your textbox here 
                    _maxodd = Convert.ToDouble(reader1["max_odd_home"].ToString());
                    _minodd = Convert.ToDouble(reader1["min_odd_home"].ToString());
                }
                cmd8.Connection = conn;
                conn.Close();
            }
            catch
            {
                //result.Text = "Error Occured, Please try Again!!!";
            }
            finally
            {
                conn.Close();
            }

            Decimal hldpercent = 0;
            Decimal hldpercent1 = 0;
            hldpercent = Convert.ToDecimal(percent);
            hldpercent1 = Convert.ToDecimal(percent1);

            wait2 = (ttAmmount / ttbetmoney1) * ((hldpercent / 100) * ttbetmoney) + ttAmmount;
            //amm1 = (wait2 / ttAmmount) * 100;
            //ttmone = Convert.ToInt32(amm1);

            winhldamm1 = Convert.ToDouble(wait2 / ttAmmount);
            winhldamm1 = Math.Round(winhldamm1, 2);
            if (winhldamm1 >= _maxodd)
            {
                winhldamm1 = _maxodd;
            }
            if (winhldamm1 <= _minodd)
            {
                winhldamm1 = _minodd;
            }
            try
            {
                conn.Open();
                //checking up money on one's Account
                String query = "UPDATE betmatch4 SET winhome = @winhome WHERE(setno Like @setno AND MatchNo Like @MatchNo) ";
                SqlCommand cmd0 = new SqlCommand(query, conn);
                cmd0.Parameters.AddWithValue("@setno", settno);
                cmd0.Parameters.AddWithValue("@MatchNo", mattno);
                cmd0.Parameters.AddWithValue("@winhome", winhldamm1.ToString());
                //cmd0.Parameters.AddWithValue("@oddname", "away");

                cmd0.Connection = conn;
                cmd0.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                //result.Text = "Error Occured, Please try Again!!!";
            }
            finally
            {
                conn.Close();
            }

            try
            {
                conn.Open();
                //checking up money on one's Account
                String query = "UPDATE setbetmatches3 SET oddwin = @oddwin WHERE(setno Like @setno AND MatchNo Like @MatchNo AND oddname Like @oddname) ";
                SqlCommand cmd0 = new SqlCommand(query, conn);
                cmd0.Parameters.AddWithValue("@setno", settno);
                cmd0.Parameters.AddWithValue("@MatchNo", mattno);
                cmd0.Parameters.AddWithValue("@oddwin", winhldamm1.ToString());
                cmd0.Parameters.AddWithValue("@oddname", "home");

                cmd0.Connection = conn;
                cmd0.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                //result.Text = "Error Occured, Please try Again!!!";
            }
            finally
            {
                conn.Close();
            }

            //On the side of lossing vvvv
            wait2 = ttAmmount * (hldpercent1 / 100);
            //amm1 = (wait2 / ttAmmount) * 100;
            //ttmone1 = Convert.ToInt32(amm1);

            losehldamm1 = Convert.ToDouble(wait2 / ttAmmount);
            losehldamm1 = Math.Round(losehldamm1, 2);

            try
            {
                conn.Open();
                //checking up money on one's Account
                String query = "UPDATE betmatch4 SET loseaway = @loseaway WHERE(setno Like @setno AND MatchNo Like @MatchNo) ";
                SqlCommand cmd0 = new SqlCommand(query, conn);
                cmd0.Parameters.AddWithValue("@setno", settno);
                cmd0.Parameters.AddWithValue("@MatchNo", mattno);
                cmd0.Parameters.AddWithValue("@loseaway", losehldamm1.ToString());
                //cmd8.Parameters.AddWithValue("@oddname", "away");

                cmd0.Connection = conn;
                cmd0.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                //result.Text = "Error Occured, Please try Again!!!";
            }
            finally
            {
                conn.Close();
            }

            try
            {
                conn.Open();
                //checking up money on one's Account
                String query = "UPDATE setbetmatches3 SET oddlose = @oddlose WHERE(setno Like @setno AND MatchNo Like @MatchNo AND oddname Like @oddname) ";
                SqlCommand cmd0 = new SqlCommand(query, conn);
                cmd0.Parameters.AddWithValue("@setno", settno);
                cmd0.Parameters.AddWithValue("@MatchNo", mattno);
                cmd0.Parameters.AddWithValue("@oddlose", losehldamm1.ToString());
                cmd0.Parameters.AddWithValue("@oddname", "home");

                cmd0.Connection = conn;
                cmd0.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                //result.Text = "Error Occured, Please try Again!!!";
            }
            finally
            {
                conn.Close();
            }

        }

        void fillgames(String settno, String mattno)
        {
            Decimal ttbetmoney = 0, ttbetmoneyother = 0;
            Double percent = 0, percent1 = 0;
            Decimal[] maneItems = new Decimal[1000];
            Decimal[] maniItems = new Decimal[1000];
            int i = 0, j = 0, k = 0;
            SqlConnection conn = null;
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["betConnectionString"].ConnectionString.ToString());
            try
            {
                conn.Open();
                //checking up money on one's Account
                string query3 = "select betmoney from setbetmatches3 WHERE (setno Like @setno AND MatchNo Like @MatchNo AND oddname Like @oddname )";
                SqlCommand cmd8 = new SqlCommand(query3, conn);
                cmd8.Parameters.AddWithValue("@setno", settno);
                cmd8.Parameters.AddWithValue("@MatchNo", mattno);
                cmd8.Parameters.AddWithValue("@oddname", "home");

                SqlDataReader reader1 = cmd8.ExecuteReader();
                while (reader1.Read())
                {
                    //Assign to your textbox here 
                    maneItems[i] = Convert.ToDecimal(reader1["betmoney"].ToString());
                    ttbetmoney = ttbetmoney + maneItems[i];
                    i++; j++;
                }
                cmd8.Connection = conn;
                conn.Close();
            }
            catch
            {
                //result.Text = "Error Occured, Please try Again!!!";
            }
            try
            {
                conn.Open();
                //checking up money on one's Account
                string query3 = "select winshare,loseshare from betmatch4 WHERE (setno Like @setno AND MatchNo Like @MatchNo )";
                SqlCommand cmd8 = new SqlCommand(query3, conn);
                cmd8.Parameters.AddWithValue("@setno", settno);
                cmd8.Parameters.AddWithValue("@MatchNo", mattno);
                //cmd8.Parameters.AddWithValue("@oddname", "away");

                SqlDataReader reader1 = cmd8.ExecuteReader();
                while (reader1.Read())
                {
                    //Assign to your textbox here 
                    percent = Convert.ToDouble(reader1["winshare"].ToString());
                    percent1 = Convert.ToDouble(reader1["loseshare"].ToString());
                }
                cmd8.Connection = conn;
                conn.Close();
            }
            catch
            {
                //result.Text = "Error Occured, Please try Again!!!";
            }
            while (j >= 1)
            {
                sure_deal(maneItems[k], percent, percent1, settno, mattno);
                k++; j--;
            }
            //Fill games on other Side
            i = 0; j = 0; k = 0;
            try
            {
                conn.Open();
                //checking up money on one's Account
                string query3 = "select betmoney from setbetmatches3 WHERE (setno Like @setno AND MatchNo Like @MatchNo AND oddname Like @oddname )";
                SqlCommand cmd8 = new SqlCommand(query3, conn);
                cmd8.Parameters.AddWithValue("@setno", settno);
                cmd8.Parameters.AddWithValue("@MatchNo", mattno);
                cmd8.Parameters.AddWithValue("@oddname", "away");

                SqlDataReader reader1 = cmd8.ExecuteReader();
                while (reader1.Read())
                {
                    //Assign to your textbox here 
                    maneItems[i] = Convert.ToDecimal(reader1["betmoney"].ToString());
                    ttbetmoney = ttbetmoneyother + maneItems[i];
                    i++; j++;
                }
                cmd8.Connection = conn;
                conn.Close();
            }
            catch
            {
                //result.Text = "Error Occured, Please try Again!!!";
            }
            while (j >= 1)
            {
                sure_deal_away(maneItems[k], percent, percent1, settno, mattno);
                k++; j--;
            }

        }



        //******************************************************************************************************************************
        //Method that Manipulates the Bets with the Agent
        //******************************************************************************************************************************
        
        
        
        
        // Code with the the former key Commands;Topup,Update and Bet
        public void updateAccounts(String username, String password, String transID, String amount, String referenceField, String MSISDN, String MerchantAMN)
        {
            String _process_status = null;

            Char _referencetest = 'a';
            String _testfinal_reference = null;
            String _testusername = null;
            String _testmatch = null;
            String _testresult = null;
            String _testmatchempty = null;
            String _testmobile = null;

            Char[] ch = referenceField.ToCharArray();

            for (int i = 0; i < referenceField.Length; i++)
            {

                _referencetest = ch[i];
                _testmatchempty = "" + _referencetest;

                if (_testmatchempty != " ")
                {
                    _testfinal_reference = _testfinal_reference + _referencetest;
                }

                else
                    break;

            }
            _testfinal_reference.Trim();

            switch (_testfinal_reference)
            {
                case "TOPUP":
                    {
                        if (referenceField == "TOPUP")
                        {

                            // put code to update phone account
                            update_own_account(username, transID, amount, referenceField, MSISDN, MerchantAMN);
                        }
                        else
                        {
                            // getting the username

                            for (int i = 6; i < referenceField.Length; i++)
                            {
                                _referencetest = ch[i];

                                _testmatchempty = "" + _referencetest;

                                if (_testmatchempty != " ")
                                {
                                    _testusername = _testusername + _referencetest;
                                }
                                else
                                    break;
                            }
                            _testusername.ToLower();
                            _testusername.Trim();

                            update_someone_account(_testusername, transID, amount, referenceField, MSISDN, MerchantAMN);
                        }

                        break;
                    }
                case "BET":
                    {
                        // getting the Match code

                        int i = 4;
                        // Char emptychar = '\0';

                        for (; (i < referenceField.Length); i++)
                        {
                            _referencetest = ch[i];
                            _testmatchempty = "" + _referencetest;
                            if (_testmatchempty != " ")
                            {
                                _testmatch = _testmatch + _referencetest;

                            }
                            else
                                break;
                        }
                        _testmatch.Trim();
                        i++;

                        for (; (i < referenceField.Length); i++)
                        {
                            _referencetest = ch[i];
                            _testmatchempty = "" + _referencetest;

                            if (_testmatchempty != " ")
                            {
                                _testresult = _testresult + _referencetest;
                            }
                            else
                                break;

                        }
                        _testresult.Trim();

                        bet_with_phone(MSISDN, _testmatch, amount, MSISDN, _testresult);

                        break;
                    }
                case"FOR":{

                    int i = 4;
                    // Char emptychar = '\0';

                    for (; (i < referenceField.Length); i++)
                    {
                        _referencetest = ch[i];
                        _testmatchempty = "" + _referencetest;
                        if (_testmatchempty != " ")
                        {
                            _testmobile = _testmobile + _referencetest;

                        }
                        else
                            break;
                    }
                    _testmobile.Trim();

                    i++;

                    for (; (i < referenceField.Length); i++)
                    {
                        _referencetest = ch[i];
                        _testmatchempty = "" + _referencetest;
                        if (_testmatchempty != " ")
                        {
                            _testmatch = _testmatch + _referencetest;

                        }
                        else
                            break;
                    }
                    _testmatch.Trim();
                    i++;

                    for (; (i < referenceField.Length); i++)
                    {
                        _referencetest = ch[i];
                        _testmatchempty = "" + _referencetest;

                        if (_testmatchempty != " ")
                        {
                            _testresult = _testresult + _referencetest;
                        }
                        else
                            break;

                    }
                    _testresult.Trim();

                    search_for_the_agent(_testmobile, _testmatch, amount, MSISDN, _testresult); 
                    }
                    break;
            }

            _process_status = requestres.Status;
        }
        //public void updateAccounts(String username, String password, String transID, String amount, String referenceField, String MSISDN, String MerchantAMN)
        //{
        //    String _process_status = null;

        //    Char _referencetest = 'a';
        //    String _testfinal_reference = null;
        //    String _testusername = null;
        //    String _testmatch = null;
        //    String _testresult = null;
        //    String _testmatchempty = null;

        //    Char[] ch = referenceField.ToCharArray();

        //    for (int i = 0; i < referenceField.Length; i++)
        //    {

        //        _referencetest = ch[i];
        //        _testmatchempty = "" + _referencetest;

        //        if ((_testmatchempty != "*")&& (_testmatchempty != "#"))
        //        {
        //            _testfinal_reference = _testfinal_reference + _referencetest;

        //        }else if ((_testmatchempty == "*") && (i == 0)) { 

        //        }
        //        else
        //            break;

        //    }
        //    _testfinal_reference.Trim();

        //    switch (_testfinal_reference)
        //    {
        //        case "200":
        //            {
        //                if (referenceField == "*200#")
        //                {

        //                    // put code to update phone account
        //                    update_own_account(username, transID, amount, referenceField, MSISDN, MerchantAMN);
        //                }
        //                else
        //                {
                            
        //                }

        //                break;
        //            }
        //        case "300": {
        //            // getting the username

        //            for (int i = 5; i < referenceField.Length; i++)
        //            {
        //                _referencetest = ch[i];

        //                _testmatchempty = "" + _referencetest;

        //                if ((_testmatchempty != "*") && (_testmatchempty != "#"))
        //                {
        //                    _testusername = _testusername + _referencetest;
        //                }
        //                else
        //                    break;
        //            }
        //            _testusername.ToLower();
        //            _testusername.Trim();

        //            update_someone_account(_testusername, transID, amount, referenceField, MSISDN, MerchantAMN);

        //            break;
                
        //        }


        //        case "100":
        //            {
        //                // getting the Match code

        //                int i = 5;
        //                // Char emptychar = '\0';

        //                for (; (i < referenceField.Length); i++)
        //                {
        //                    _referencetest = ch[i];
        //                    _testmatchempty = "" + _referencetest;
        //                    if ((_testmatchempty != "*") && (_testmatchempty != "#"))
        //                    {
        //                        _testmatch = _testmatch + _referencetest;

        //                    }
        //                    else
        //                        break;
        //                }
        //                _testmatch.Trim();
        //                i++;

        //                for (; (i < referenceField.Length); i++)
        //                {
        //                    _referencetest = ch[i];
        //                    _testmatchempty = "" + _referencetest;

        //                    if ((_testmatchempty != "*") && (_testmatchempty != "#"))
        //                    {
        //                        _testresult = _testresult + _referencetest;
        //                    }
        //                    else
        //                        break;

        //                }
        //                _testresult.Trim();

        //                bet_with_phone(MSISDN, _testmatch, amount, MSISDN, _testresult);
        //            }
        //            break;
        //    }

        //    if (requestres.Message == null)
        //    {
        //        requestres.Message = "UNKNOWN COMMAND Token Issued";
        //    _process_status = requestres.GameStatus;

        //    }else{
        //        _process_status = requestres.GameStatus;
        //    }
        //}

        [WebMethod(Description = "Writes the Parameters for the Client Response.", EnableSession = false)]
        public RequestResponse requestToken(String APIusername, String APIpassword, String transID, String amount, String referenceField, String MSISDN, String MerchantAMN)
        {
            //APIusername = "globalbets";
            //APIpassword = "dewilos";

            Assignvalues(APIusername, APIpassword, transID, amount, referenceField, MSISDN, MerchantAMN);
            RequestResponse ResponseData = new RequestResponse();
            ResponseData.Status = requestres.Status;
            ResponseData.TransID = requestres.TransID;
            ResponseData.Amount = requestres.Amount;
            ResponseData.ReferenceField = requestres.ReferenceField;
            ResponseData.MSISDN = requestres.MSISDN;
            ResponseData.Message = requestres.Message;


            return ResponseData;
        }
        public void search_for_the_agent(String user, String matchno, String amount, String MSISDN, String result)
        {
            String _msg = null;
            String _process = null;
            String _category = "Sure Deal";
            String _category1 = "Straight Line";
            String _user = null;
            String _champ = null;
            String _setno = null;
            String _matno = null;
            String _host = null;
            String _vs = null;
            String _visitor = null;
            String _winhome = null;
            String _losehome = null;
            String _winaway = null;
            String _loseaway = null;
            String _oddhome = null;
            String _oddaway = null;
            String _odddraw = null;
            DateTime _date2de = DateTime.Now;
            DateTime _stime = new DateTime();
            Decimal mney = 0;

            
         System.Configuration.Configuration rootWebConfig =
                                         System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("//template046");
            System.Configuration.ConnectionStringSettings connString;

            if (0 < rootWebConfig.ConnectionStrings.ConnectionStrings.Count)
            {

                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["betConnectionString"];

                if (null != connString)
                {

                    String con1 = connString.ConnectionString;
                    SqlConnection conn = new SqlConnection(con1);
                    try
                    {
                        conn.Open();

                        SqlCommand cmd1 = new SqlCommand("select username,pnumber from users Where ((pnumber = @pnumber)AND(position = @position))", conn);
                        cmd1.Parameters.AddWithValue("@pnumber", MSISDN);
                        cmd1.Parameters.AddWithValue("@position", "Phone Agent");
                        SqlDataReader reader = cmd1.ExecuteReader();
                        while (reader.Read())
                        {
                            //Assign to your strings here
                            _user = reader["username"].ToString();
                        }
                       conn.Close();
                                               
                    }
                    catch (Exception ex)
                    {
                        string error = ex.Message;
                        _process = error;
                    }
                    if (_user != null) {
                        try
                        {
                            conn.Open();

                            SqlCommand cmd1 = new SqlCommand("select champ,setno,MatchNo,host,vs,visitor,winhome,losehome,winaway,loseaway,StartTime from betmatch4 Where (MatchNo = @MatchNo)", conn);
                            cmd1.Parameters.AddWithValue("@MatchNo", matchno);
                            SqlDataReader reader = cmd1.ExecuteReader();
                            while (reader.Read())
                            {
                                //Assign to your strings here
                                // _category = reader["category"].ToString();
                                _champ = reader["champ"].ToString();
                                _setno = reader["setno"].ToString();
                                _matno = reader["MatchNo"].ToString();
                                _host = reader["host"].ToString();
                                _vs = reader["vs"].ToString();
                                _visitor = reader["visitor"].ToString();
                                _winhome = reader["winhome"].ToString();
                                _losehome = reader["losehome"].ToString();
                                _winaway = reader["winaway"].ToString();
                                _loseaway = reader["loseaway"].ToString();
                                _stime = Convert.ToDateTime(reader["StartTime"]);

                                if (_matno != null)
                                {

                                    _process = "Success";
                                    _msg = "Bet Received.Thank you";
                                }
                                else
                                {
                                    _process = "Failed";
                                    _msg = "Invalid Match code";
                                }

                            }
                            conn.Close();

                        }
                        catch (Exception ex)
                        {
                            string error = ex.Message;
                            _msg = "Duplicate Bet";
                        }
                        if (_matno != null)
                        {
                            mney = Convert.ToDecimal(amount.ToString());
                            if (result == "1")
                            {

                                try
                                {
                                    conn.Open();
                                    SqlCommand cmd = new SqlCommand("insert into setbetmatches3(username, betdate,betmoney,category,champ,setno, MatchNo,host,vs,visitor,oddname,oddwin,oddlose,StartTime,phone)values(@username, @betdate,@betmoney,@category,@champ,@setno,@MatchNo,@host,@vs,@visitor,@oddname,@oddwin,@oddlose,@StartTime,@phone)", conn);

                                    cmd.Parameters.AddWithValue("@username", user);
                                    cmd.Parameters.AddWithValue("@betdate", _date2de);
                                    cmd.Parameters.AddWithValue("@betmoney", amount);
                                    cmd.Parameters.AddWithValue("@category", _category);
                                    cmd.Parameters.AddWithValue("@champ", _champ);
                                    cmd.Parameters.AddWithValue("@setno", _setno);
                                    cmd.Parameters.AddWithValue("@MatchNo", matchno);
                                    cmd.Parameters.AddWithValue("@host", _host);
                                    cmd.Parameters.AddWithValue("@vs", _vs);
                                    cmd.Parameters.AddWithValue("@visitor", _visitor);
                                    cmd.Parameters.AddWithValue("@oddname", "home");
                                    cmd.Parameters.AddWithValue("@oddwin", _winhome);
                                    cmd.Parameters.AddWithValue("@oddlose", _losehome);
                                    cmd.Parameters.AddWithValue("@StartTime", _stime);
                                    cmd.Parameters.AddWithValue("@phone", user);

                                    cmd.Connection = conn;
                                    cmd.ExecuteNonQuery();
                                    conn.Close();

                                    _process = "Success";
                                    _msg = "Bet Received.Thank you";
                                }
                                catch (Exception ex)
                                {
                                    string error = ex.Message;
                                    _msg = "Duplicate Bet";
                                    _process = "Failed";
                                }
                            }
                            else if (result == "2")
                            {
                                try
                                {
                                    conn.Open();
                                    SqlCommand cmd = new SqlCommand("insert into setbetmatches3(username, betdate,betmoney,category,champ,setno, MatchNo,host,vs,visitor,oddname,oddwin,oddlose,StartTime,phone)values(@username, @betdate,@betmoney,@category,@champ,@setno,@MatchNo,@host,@vs,@visitor,@oddname,@oddwin,@oddlose,@StartTime,@phone)", conn);

                                    cmd.Parameters.AddWithValue("@username", user);
                                    cmd.Parameters.AddWithValue("@betdate", _date2de);
                                    cmd.Parameters.AddWithValue("@betmoney", amount);
                                    cmd.Parameters.AddWithValue("@category", _category);
                                    cmd.Parameters.AddWithValue("@champ", _champ);
                                    cmd.Parameters.AddWithValue("@setno", _setno);
                                    cmd.Parameters.AddWithValue("@MatchNo", matchno);
                                    cmd.Parameters.AddWithValue("@host", _host);
                                    cmd.Parameters.AddWithValue("@vs", _vs);
                                    cmd.Parameters.AddWithValue("@visitor", _visitor);
                                    cmd.Parameters.AddWithValue("@oddname", "away");
                                    cmd.Parameters.AddWithValue("@oddwin", _winaway);
                                    cmd.Parameters.AddWithValue("@oddlose", _loseaway);
                                    cmd.Parameters.AddWithValue("@StartTime", _stime);
                                    cmd.Parameters.AddWithValue("@phone", user);

                                    cmd.Connection = conn;
                                    cmd.ExecuteNonQuery();
                                    conn.Close();

                                    _process = "Success";
                                    _msg = "Bet Received.Thank you";
                                }
                                catch (Exception ex)
                                {
                                    string error = ex.Message;
                                    _msg = "Duplicate Bet";
                                    _process = "Failed";
                                }

                            }
                            if (_process == "Success")
                            {
                                putinaccount(_user, mney, _category);
                                fillgames(_setno, matchno);
                                sure_deal_putmoney(_setno, matchno);
                            }

                        }
                        else
                        {
                            try
                            {
                                conn.Open();

                                SqlCommand cmd1 = new SqlCommand("select champ,setno,MatchNo,host,vs,visitor,StartTime,oddhome,oddaway,odddraw from  betmatch1 Where (MatchNo = @MatchNo)", conn);
                                cmd1.Parameters.AddWithValue("@MatchNo", matchno);
                                SqlDataReader reader = cmd1.ExecuteReader();
                                while (reader.Read())
                                {
                                    //Assign to your strings here
                                    // _category = reader["category"].ToString();
                                    _champ = reader["champ"].ToString();
                                    _setno = reader["setno"].ToString();
                                    _matno = reader["MatchNo"].ToString();
                                    _host = reader["host"].ToString();
                                    _vs = reader["vs"].ToString();
                                    _visitor = reader["visitor"].ToString();
                                    _oddhome = reader["oddhome"].ToString();
                                    _oddaway = reader["oddaway"].ToString();
                                    _odddraw = reader["odddraw"].ToString();
                                    _stime = Convert.ToDateTime(reader["StartTime"]);

                                }
                                conn.Close();
                                if (_matno != null)
                                {

                                    _process = "Success";
                                    _msg = "Transaction suceeded Token Issued";
                                }
                                else
                                {
                                    _process = "Failed";
                                    _msg = "Invalid Match code";
                                }
                            }
                            catch (Exception ex)
                            {
                                string error = ex.Message;
                                _process = error;
                            }
                            if (_matno != null)
                            {
                                Decimal _ttmon2hand = 0;
                                mney = Convert.ToDecimal(amount.ToString());

                                if (result == "1")
                                {
                                    _ttmon2hand = Convert.ToDecimal(_oddhome.ToString());

                                    _ttmon2hand = ((_ttmon2hand / 100) * mney);
                                    _ttmon2hand = Math.Round(_ttmon2hand, 2);

                                    try
                                    {
                                        conn.Open();
                                        SqlCommand cmd = new SqlCommand("insert into setbetmatches1(username, betdate,betmoney,champ,category,setno,MatchNo,host,vs,visitor,oddname,odd,ttmoney,StartTime,phone)values(@username, @betdate,@betmoney,@champ,@category,@setno,@MatchNo,@host,@vs,@visitor,@oddname,@odd,@ttmoney,@StartTime,@phone)", conn);

                                        cmd.Parameters.AddWithValue("@username", user);
                                        cmd.Parameters.AddWithValue("@betdate", _date2de);
                                        cmd.Parameters.AddWithValue("@betmoney", amount);
                                        cmd.Parameters.AddWithValue("@champ", _champ);
                                        cmd.Parameters.AddWithValue("@category", _category1);
                                        cmd.Parameters.AddWithValue("@setno", _setno);
                                        cmd.Parameters.AddWithValue("@MatchNo", matchno);
                                        cmd.Parameters.AddWithValue("@host", _host);
                                        cmd.Parameters.AddWithValue("@vs", _vs);
                                        cmd.Parameters.AddWithValue("@visitor", _visitor);
                                        cmd.Parameters.AddWithValue("@oddname", "home");
                                        cmd.Parameters.AddWithValue("@odd", _oddhome);
                                        cmd.Parameters.AddWithValue("@ttmoney", _ttmon2hand);
                                        cmd.Parameters.AddWithValue("@StartTime", _stime);
                                        cmd.Parameters.AddWithValue("@phone", user);

                                        cmd.Connection = conn;
                                        cmd.ExecuteNonQuery();
                                        conn.Close();

                                        _process = "Success";
                                        _msg = "Bet Received.Thank you";
                                    }
                                    catch (Exception ex)
                                    {
                                        string error = ex.Message;
                                        _msg = "Duplicate Bet";
                                        _process = "Failed";
                                    }
                                }
                                else if (result == "2")
                                {
                                    _ttmon2hand = Convert.ToDecimal(_oddaway.ToString());

                                    _ttmon2hand = ((_ttmon2hand / 100) * mney);
                                    _ttmon2hand = Math.Round(_ttmon2hand, 2);
                                    try
                                    {
                                        conn.Open();
                                        SqlCommand cmd = new SqlCommand("insert into setbetmatches1(username, betdate,betmoney,champ,category,setno,MatchNo,host,vs,visitor,oddname,odd,ttmoney,StartTime,phone)values(@username, @betdate,@betmoney,@champ,@category,@setno,@MatchNo,@host,@vs,@visitor,@oddname,@odd,@ttmoney,@StartTime,@phone)", conn);

                                        cmd.Parameters.AddWithValue("@username", user);
                                        cmd.Parameters.AddWithValue("@betdate", _date2de);
                                        cmd.Parameters.AddWithValue("@betmoney", amount);
                                        cmd.Parameters.AddWithValue("@champ", _champ);
                                        cmd.Parameters.AddWithValue("@category", _category1);
                                        cmd.Parameters.AddWithValue("@setno", _setno);
                                        cmd.Parameters.AddWithValue("@MatchNo", matchno);
                                        cmd.Parameters.AddWithValue("@host", _host);
                                        cmd.Parameters.AddWithValue("@vs", _vs);
                                        cmd.Parameters.AddWithValue("@visitor", _visitor);
                                        cmd.Parameters.AddWithValue("@oddname", "away");
                                        cmd.Parameters.AddWithValue("@odd", _oddaway);
                                        cmd.Parameters.AddWithValue("@ttmoney", _ttmon2hand);
                                        cmd.Parameters.AddWithValue("@StartTime", _stime);
                                        cmd.Parameters.AddWithValue("@phone", user);

                                        cmd.Connection = conn;
                                        cmd.ExecuteNonQuery();
                                        conn.Close();

                                        _process = "Success";
                                        _msg = "Bet Received.Thank you";
                                    }
                                    catch (Exception ex)
                                    {
                                        string error = ex.Message;
                                        _msg = "Duplicate Bet";
                                        _process = "Failed";
                                    }

                                }
                                else if (result == "3")
                                {
                                    _ttmon2hand = Convert.ToDecimal(_odddraw.ToString());

                                    _ttmon2hand = ((_ttmon2hand / 100) * mney);
                                    _ttmon2hand = Math.Round(_ttmon2hand, 2);
                                    try
                                    {
                                        conn.Open();
                                        SqlCommand cmd = new SqlCommand("insert into setbetmatches1(username, betdate,betmoney,champ,category,setno,MatchNo,host,vs,visitor,oddname,odd,ttmoney,StartTime,phone)values(@username, @betdate,@betmoney,@champ,@category,@setno,@MatchNo,@host,@vs,@visitor,@oddname,@odd,@ttmoney,@StartTime,@phone)", conn);

                                        cmd.Parameters.AddWithValue("@username", user);
                                        cmd.Parameters.AddWithValue("@betdate", _date2de);
                                        cmd.Parameters.AddWithValue("@betmoney", amount);
                                        cmd.Parameters.AddWithValue("@champ", _champ);
                                        cmd.Parameters.AddWithValue("@category", _category1);
                                        cmd.Parameters.AddWithValue("@setno", _setno);
                                        cmd.Parameters.AddWithValue("@MatchNo", matchno);
                                        cmd.Parameters.AddWithValue("@host", _host);
                                        cmd.Parameters.AddWithValue("@vs", _vs);
                                        cmd.Parameters.AddWithValue("@visitor", _visitor);
                                        cmd.Parameters.AddWithValue("@oddname", "draw");
                                        cmd.Parameters.AddWithValue("@odd", _odddraw);
                                        cmd.Parameters.AddWithValue("@ttmoney", _ttmon2hand);
                                        cmd.Parameters.AddWithValue("@StartTime", _stime);
                                        cmd.Parameters.AddWithValue("@phone", user);

                                        cmd.Connection = conn;
                                        cmd.ExecuteNonQuery();
                                        conn.Close();

                                        _process = "Success";
                                        _msg = "Bet Received.Thank you for choosing SMS Bet";
                                    }
                                    catch (Exception ex)
                                    {
                                        string error = ex.Message;
                                        _msg = "You have already betted on this match. P'se select another match";
                                        _process = "Failed";
                                    }
                                }
                                else
                                {
                                    _process = "Failed";
                                    _msg = "Wrong match result code entered.P'se enter 1 for home Team or 2 for Away Team or 3 for Draw";
                                }
                                if (_process == "Success")
                                {
                                    putinaccount(_user, mney, _category1);
                                    //fillgames(_setno, matchno);
                                }
                            }
                            else
                            {
                                _process = "Failed";
                                _msg = "Unknown Match Code";
                            }
                        }
                    
                    }

                }
                else
                {
                    string error = "Database Connection Failed";
                    _process = error;
                }

                requestres.Status = _process;
                requestres.Message = _msg;
            }
        
        
        
        }

    }


