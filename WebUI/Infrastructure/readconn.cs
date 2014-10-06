using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Text;

/// <summary>
/// Summary description for readconn
/// </summary>
namespace SRN.BLL
{
    public class readconn
    {
        // Getting the date 
  //=================================================================================================================
        public string GetCurrentDate()
    {
        string month = DateTime.Now.ToString("MMMM");
        string year = DateTime.Now.Year.ToString();
        string dates = DateTime.Today.Day.ToString();
        string hour = DateTime.Now.Hour.ToString();
        string mins = DateTime.Now.Minute.ToString();
        string secs = DateTime.Now.Second.ToString();

        //string mins1 = DateTime.Now.Hour.ToString();

        string datevalue = month + " " + dates + ", " + year + " " + hour + ":" + mins + ":" + secs;

        return datevalue;
    }
 //=================================================================================================================
  //=========================================================================================

        public SqlConnection realreadconn()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["betConnectionString"].ConnectionString);
            return conn;       
                  
        }
        //=========================================================================================
        
        public int insertfunc(String sqlstmt, SqlConnection myconn)
        {
            //Method for insertion Sql
            int x = 0;
            try
            {
                myconn.Open();


                SqlCommand cmd = new SqlCommand(sqlstmt, myconn);
                cmd.Connection = myconn;
                cmd.ExecuteNonQuery();

                myconn.Close();

            }
            catch (Exception ex)
            {
                String error = ex.Message;
                x = 1;
            }
            finally
            {
                myconn.Close();
            }
                   
            return x;
        }
        //=========================================================================================
        
        public int deletefunc(String sqlstmt, SqlConnection myconn)
        {
            //Method for Delete 
 
            int x = 0;
            try
            {
                myconn.Open();

                SqlCommand cmd = new SqlCommand(sqlstmt, myconn);
                cmd.Connection = myconn;
                cmd.ExecuteNonQuery();

                myconn.Close();

            }
            catch (Exception ex)
            {
                String error = ex.Message;
                x = 1;
            }
            return x;
        }
        //=========================================================================================
        
        public DataTable selecttogrid(String sqlstmt, SqlConnection myconn)
        {
            //This Method return a datatable in any searched Table

            DataTable myDataTable = new DataTable();
            try
            {
                myconn.Open();

                SqlCommand cmd = new SqlCommand(sqlstmt, myconn);
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter   mySqlAdapter = new SqlDataAdapter(cmd);
                DataSet myDataSet = new DataSet();
                mySqlAdapter.Fill(myDataSet);
                myDataTable = myDataSet.Tables[0];
                              
                myconn.Close();
            }
            catch (Exception ex)
            {
                String error = ex.Message;
            }
            return myDataTable;
        }
        //=========================================================================================
        
        public string GetNextRecNo(SqlConnection myconn)
        {
            //This method gets the next Number

            string varNxtNo;
                       
            DataSet ds = new DataSet();
            //SqlCommand cmd = new SqlCommand("SELECT distinct BrandCode,BrandName FROM [Brands]", connect);
            SqlCommand cmd = new SqlCommand("SELECT distinct NxtLoanNo FROM [DBControl]", myconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "DBControl");

            myconn.Open();
            cmd.ExecuteNonQuery();

            varNxtNo = ds.Tables["DBControl"].Rows[0][0].ToString();

            myconn.Close();
                        
            return varNxtNo;
        }
        //=========================================================================================
        
        public string EditNextRecNo(string varNxtNo, SqlConnection myconn)
        {
            //Edits where the other number/Next number will go

            SqlCommand cmd = new SqlCommand("UPDATE [DBControl] SET [NxtSetNo] = '" +
                Convert.ToString((Convert.ToInt32(varNxtNo)) + 1) +
                "' WHERE [NxtSetNo] = '" + varNxtNo + "'", myconn);

            myconn.Open();
            cmd.ExecuteNonQuery();
            myconn.Close();

            //Convert Next Number from string to int, add 1 to it, then back to sting and return it.
            return Convert.ToString(Convert.ToInt32(varNxtNo));
        }
        //=========================================================================================

        public string ReadName(string strSQL, SqlConnection myconn)
        {
            string varDesc;
                     
            DataSet ds = new DataSet();

            SqlCommand cmd = new SqlCommand(strSQL, myconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds, "Description");
            myconn.Open();
            cmd.ExecuteNonQuery();

            try
            {
                varDesc = (ds.Tables["Description"].Rows[0][0]).ToString().Trim();
            }
            catch
            {
                varDesc = "";
            }

            myconn.Close();

            return varDesc;
        }
        //=============================================================================================================
        //=============================================================================================================
        // //Insert the summary details for straightline match
        public void insert_match_summary_straightline(SqlConnection myconn, String matchno, String setnum)
        {
            String _matchresult = null;
            String _matchleague = null;
            String _matchcategory = "StraightLine";
            String _matchtype = null;
            String _home = null;
            String _away = null;
            String _homeodd = null;
            String _awayodd = null;
            String _drawodd = null;

            Decimal _totalbettors = 0;
            Decimal _betpatternhome = 0;
            Decimal _betpatternaway = 0;
            Decimal _betpatterndraw = 0;            
            Double _totalmoney = 0.0;
            Double _totalmoneyhome = 0.0;
            Double _grossmoneyhome = 0.0;
            Double _netwinpayouthome = 0.0;
            Double _netrevenuehome = 0.0;
            Double _grossmoneyaway = 0.0; 
            Double _totalmoneyaway = 0.0;
            Double _netwinpayoutaway = 0.0;
            Double _netrevenueaway = 0.0;
            Double _grossmoneydraw = 0.0;
            Double _totalmoneydraw = 0.0;
            Double _netwinpayoutdraw = 0.0;
            Double _netrevenuedraw = 0.0;
           

            Double _revenuehome = 0.0;
            Double _revenueaway = 0.0;
            Double _revenuedraw = 0.0;
            Double _finalrevenue = 0.0;

            //containers
            Double _totalmoneyholder = 0.0;
            Double _totalmoneyhomeholder = 0.0;
            Double _grossmoneyhomeholder = 0.0;
            Double _totalmoneyawayholder = 0.0;
            Double _grossmoneyawayholder = 0.0;
            Double _totalmoneydrawholder = 0.0;
            Double _grossmoneydrawholder = 0.0;

            string my_date = DateTime.Now.ToString();

            //DateTime mdate = DateTime.Now;
            int results = 0;

            //getting the number of total bettors on the specific match 
            try
            { 
                myconn.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT COUNT(username) AS NumberOfCustomers FROM setbetmatches1 WHERE (MatchNo ='" + matchno + "' AND setno='" + setnum + "')", myconn);
                SqlDataReader reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    //Assign to your strings here
                    _totalbettors = Convert.ToDecimal(reader["NumberOfCustomers"].ToString());

                }
                myconn.Close();
                               
            }
            catch (Exception ex)
            {
                String error = ex.Message;
            }
            finally
            {
                myconn.Close();
            }

            //getting the number of total bettors who betted for home on  specific match 
            try
            {
                myconn.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT COUNT(username) AS NumberOfhomebetters FROM setbetmatches1 WHERE (MatchNo ='" + matchno + "' AND setno='" + setnum + "' AND oddname ='home')", myconn);
                SqlDataReader reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    //Assign to your strings here
                    _betpatternhome = Convert.ToDecimal(reader["NumberOfhomebetters"].ToString());

                }
                myconn.Close();

            }
            catch (Exception ex)
            {
                String error = ex.Message;
            }
            finally
            {
                myconn.Close();
            }
            //getting the number of total bettors who betted for Away on  specific match 
            try
            {
                myconn.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT COUNT(username) AS NumberOfawaybetters FROM setbetmatches1 WHERE (MatchNo ='" + matchno + "' AND setno='" + setnum + "' AND oddname ='away')", myconn);
                SqlDataReader reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    //Assign to your strings here
                    _betpatternaway = Convert.ToDecimal(reader["NumberOfawaybetters"].ToString());

                }
                myconn.Close();

            }
            catch (Exception ex)
            {
                String error = ex.Message;
            }
            finally
            {
                myconn.Close();
            }
            //getting the number of total bettors who betted for Draw on  specific match 
            try
            {
                myconn.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT COUNT(username) AS NumberOfdrawbetters FROM setbetmatches1 WHERE (MatchNo ='" + matchno + "' AND setno='" + setnum + "' AND oddname ='draw')", myconn);
                SqlDataReader reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    //Assign to your strings here
                    _betpatterndraw = Convert.ToDecimal(reader["NumberOfdrawbetters"].ToString());

                }
                myconn.Close();

            }
            catch (Exception ex)
            {
                String error = ex.Message;
            }
            finally
            {
                myconn.Close();
            }
            //getting the other Details for the match 
            try
            {
                myconn.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT champ,host,visitor,oddhome,oddaway,odddraw,type FROM betmatch1 WHERE (MatchNo ='" + matchno + "')", myconn);
                SqlDataReader reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    //Assign to your strings here

                     _matchleague = reader["champ"].ToString(); 
                     //_matchcategory =  reader["oddname"].ToString();
                     _matchtype = reader["type"].ToString();
                     _home = reader["host"].ToString();
                     _away = reader["visitor"].ToString();
                     _homeodd = reader["oddhome"].ToString();
                     _awayodd = reader["oddaway"].ToString();
                     _drawodd = reader["odddraw"].ToString();

                }
                myconn.Close();

            }
            catch (Exception ex)
            {
                String error = ex.Message;
            }
            finally
            {
                myconn.Close();
            }
            //getting the Result of a specific match 
            try
            {
                myconn.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT oddname FROM betresults2 WHERE (MatchNo ='" + matchno + "'AND setno='" + setnum + "')", myconn);
                SqlDataReader reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    //Assign to your strings here 
                    _matchresult = reader["oddname"].ToString();                   

                }
                myconn.Close();

            }
            catch (Exception ex)
            {
                String error = ex.Message;
            }
            finally
            {
                myconn.Close();
            }
            //getting the Total money collected of a specific match 
            try
            {
                myconn.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT betmoney AS totalmoney FROM setbetmatches1 WHERE (MatchNo ='" + matchno + "'AND setno='" + setnum + "')", myconn);
                SqlDataReader reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    //Assign to your strings here
                    _totalmoneyholder = Convert.ToDouble(reader["totalmoney"].ToString());
                    _totalmoney =_totalmoneyholder + _totalmoney;
                }
                myconn.Close();

            }
            catch (Exception ex)
            {
                String error = ex.Message;
            }
            finally
            {
                myconn.Close();
            }
            //getting the Total money collected for the home bets of a specific match 
            try
            {
                myconn.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT betmoney AS totalmoneyhome FROM setbetmatches1 WHERE (MatchNo ='" + matchno + "'AND setno='" + setnum + "'AND oddname ='home')", myconn);
                SqlDataReader reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    //Assign to your strings here
                    _totalmoneyhomeholder = Convert.ToDouble(reader["totalmoneyhome"].ToString());
                    _totalmoneyhome =_totalmoneyhomeholder + _totalmoneyhome;
                }
                myconn.Close();

            }
            catch (Exception ex)
            {
                String error = ex.Message;
            }
            finally
            {
                myconn.Close();
            }
            //getting the gross money Payout for the home bets of a specific match 
            try
            {
                myconn.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT ttmoney AS grossmoney FROM setbetmatches1 WHERE (MatchNo ='" + matchno + "'AND setno='" + setnum + "'AND oddname ='home')", myconn);
                SqlDataReader reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    //Assign to your strings here
                    _grossmoneyhomeholder = Convert.ToDouble(reader["grossmoney"].ToString());
                    _grossmoneyhome =_grossmoneyhomeholder + _grossmoneyhome;

                }
                myconn.Close();

            }
            catch (Exception ex)
            {
                String error = ex.Message;
            }
            finally
            {
                myconn.Close();
            }
           _netwinpayouthome = _grossmoneyhome - _totalmoneyhome;
           _netrevenuehome = _totalmoney - _grossmoneyhome;

           //getting the Total money collected for the away bets of a specific match 
           try
           {
               myconn.Open();
               SqlCommand cmd2 = new SqlCommand("SELECT betmoney AS totalmoneyaway FROM setbetmatches1 WHERE (MatchNo ='" + matchno + "'AND setno='" + setnum + "'AND oddname ='away')", myconn);
               SqlDataReader reader = cmd2.ExecuteReader();
               while (reader.Read())
               {
                   //Assign to your strings here
                   _totalmoneyawayholder = Convert.ToDouble(reader["totalmoneyaway"].ToString());
                   _totalmoneyaway = _totalmoneyawayholder + _totalmoneyaway;
               }
               myconn.Close();

           }
           catch (Exception ex)
           {
               String error = ex.Message;
           }
           finally
           {
               myconn.Close();
           }
           //getting the gross money Payout for the Away bets of a specific match 
           try
           {
               myconn.Open();
               SqlCommand cmd2 = new SqlCommand("SELECT ttmoney AS grossmoneyaway FROM setbetmatches1 WHERE (MatchNo ='" + matchno + "'AND setno='" + setnum + "'AND oddname ='away')", myconn);
               SqlDataReader reader = cmd2.ExecuteReader();
               while (reader.Read())
               {
                   //Assign to your strings here
                   _grossmoneyawayholder = Convert.ToDouble(reader["grossmoneyaway"].ToString());
                   _grossmoneyaway = _grossmoneyawayholder + _grossmoneyaway;
               }
               myconn.Close();

           }
           catch (Exception ex)
           {
               String error = ex.Message;
           }
           finally
           {
               myconn.Close();
           }
           _netwinpayoutaway = _grossmoneyaway - _totalmoneyaway;
           _netrevenueaway = _totalmoney - _grossmoneyaway;

           //getting the Total money collected for the draw bets of a specific match 
           try
           {
               myconn.Open();
               SqlCommand cmd2 = new SqlCommand("SELECT betmoney AS totalmoneydraw FROM setbetmatches1 WHERE (MatchNo ='" + matchno + "'AND setno='" + setnum + "'AND oddname ='draw')", myconn);
               SqlDataReader reader = cmd2.ExecuteReader();
               while (reader.Read())
               {
                   //Assign to your strings here
                   _totalmoneydrawholder = Convert.ToDouble(reader["totalmoneydraw"].ToString());
                   _totalmoneydraw =_totalmoneydrawholder + _totalmoneydraw;
               }
               myconn.Close();

           }
           catch (Exception ex)
           {
               String error = ex.Message;
           }
           finally
           {
               myconn.Close();
           }
           //getting the gross money Payout for the Draw bets of a specific match 
           try
           {
               myconn.Open();
               SqlCommand cmd2 = new SqlCommand("SELECT ttmoney AS grossmoneydraw FROM setbetmatches1 WHERE (MatchNo ='" + matchno + "'AND setno='" + setnum + "'AND oddname ='draw')", myconn);
               SqlDataReader reader = cmd2.ExecuteReader();
               while (reader.Read())
               {
                   //Assign to your strings here
                   _grossmoneydrawholder = Convert.ToDouble(reader["grossmoneydraw"].ToString());
                   _grossmoneydraw =_grossmoneydrawholder + _grossmoneydraw;
               }
               myconn.Close();

           }
           catch (Exception ex)
           {
               String error = ex.Message;
           }
           finally
           {
               myconn.Close();
           }
           _netwinpayoutdraw = _grossmoneydraw - _totalmoneydraw;
           _netrevenuedraw = _totalmoney - _grossmoneydraw;

            // store the calculations in the Summary Table
           try
           {
               //myconn.Open();

               String sql2 = "insert into SummaryTable(date_e,MatchNo,league,betcategory,bettype,home,away,homeodds," +
               "awayodds,drawodds,totalbettors,betpatternHome,betpatternAway,betpatternDraw,result," +
               "totalBetvalSupporters,totalBetvalHome,netwinpayoutHome,grosspayoutHome,netrevenueHome,totalBetvalAway,"+
               "netwinpayoutAway,grosspayoutAway,netrevenueAway,totalBetvalDraw,netwinpayoutDraw,grosspayoutDraw,"+
               "netrevenueDraw,revenueHome,revenueAway,revenueDraw,finalrevenue)values('" + my_date + "','" + matchno + "','" + _matchleague +
               "','" + _matchcategory + "','" + _matchtype + "','" + _home + "','" + _away + "','" + _homeodd +
               "','" + _awayodd + "','" + _drawodd + "','" + _totalbettors + "','" + _betpatternhome + "','" + _betpatternaway + "','" + _betpatterndraw +
               "','" + _matchresult + "','" + _totalmoney + "','" + _totalmoneyhome + "','" + _netwinpayouthome + "','" + _grossmoneyhome +
               "','" + _netrevenuehome + "','" + _totalmoneyaway + "','" + _netwinpayoutaway + "','" + _grossmoneyaway +
               "','" + _netrevenueaway + "','" + _totalmoneydraw + "','" + _netwinpayoutdraw + "','" + _grossmoneydraw +
               "','" + _netrevenuedraw + "','" + _revenuehome + "','" + _revenueaway + "','" + _revenuedraw + "','" + _finalrevenue + "')";
              
               results = insertfunc(sql2, myconn);
               
               myconn.Close();

           }
           catch (Exception ex)
           {
               String error = ex.Message;
           }
           finally
           {
               myconn.Close();
           }

        }

        //=============================================================================================================
        //=============================================================================================================
        //Insert the summary details for suredeal match
        public void insert_match_summary_suredeal(SqlConnection myconn, String matchno, String setnum)
        {
            String _matchresult = null;
            String _matchleague = null;
            String _matchcategory = "Suredeal";
            String _matchtype = null;
            String _home = null;
            String _away = null;
            String _homeodd = null;
            String _awayodd = null;
            String _drawodd = null;

            Decimal _totalbettors = 0;
            Decimal _betpatternhome = 0;
            Decimal _betpatternaway = 0;
            Decimal _betpatterndraw = 0;
            Double _totalmoney = 0.0;
            Double _totalmoneyhome = 0.0;
            Double _grossmoneyhome = 0.0;
            Double _netwinpayouthome = 0.0;
            Double _netrevenuehome = 0.0;
            Double _grossmoneyaway = 0.0;
            Double _totalmoneyaway = 0.0;
            Double _netwinpayoutaway = 0.0;
            Double _netrevenueaway = 0.0;
            Double _grossmoneydraw = 0.0;
            Double _totalmoneydraw = 0.0;
            Double _netwinpayoutdraw = 0.0;
            Double _netrevenuedraw = 0.0;
            Double _losehome = 0.0;
            Double _loseaway = 0.0;

            Double _revenuehome = 0.0;
            Double _revenueaway = 0.0;
            Double _revenuedraw = 0.0;

            Double _finalrevenue = 0.0;

            //containers
            Double _totalmoneyholder = 0.0;
            Double _totalmoneyhomeholder = 0.0;
            Double _grossmoneyhomeholder = 0.0;
            Double _losehomeholder = 0.0;
            Double _totalmoneyawayholder = 0.0;
            Double _grossmoneyawayholder = 0.0;
            Double _loseawayholder = 0.0;

            string my_date = DateTime.Now.ToString();

            //DateTime mdate = DateTime.Now;
            int results = 0;

            //getting the number of total bettors on the specific match 
            try
            {
                myconn.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT COUNT(username) AS NumberOfCustomers FROM setbetmatches3 WHERE (MatchNo ='" + matchno + "'AND setno='" + setnum + "' AND setno='" + setnum + "'  AND username <> 'Administrator' AND username <> 'Administrator1')", myconn);
                SqlDataReader reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    //Assign to your strings here
                    _totalbettors = Convert.ToDecimal(reader["NumberOfCustomers"].ToString());

                }
                myconn.Close();

            }
            catch (Exception ex)
            {
                String error = ex.Message;
            }
            finally
            {
                myconn.Close();
            }

            //getting the number of total bettors who betted for home on  specific match 
            try
            {
                myconn.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT COUNT(username) AS NumberOfhomebetters FROM setbetmatches3 WHERE (MatchNo ='" + matchno + "' AND setno='" + setnum + "' AND oddname ='home'  AND username <> 'Administrator' AND username <> 'Administrator1')", myconn);
                SqlDataReader reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    //Assign to your strings here
                    _betpatternhome = Convert.ToDecimal(reader["NumberOfhomebetters"].ToString());

                }
                myconn.Close();

            }
            catch (Exception ex)
            {
                String error = ex.Message;
            }
            finally
            {
                myconn.Close();
            }
            //getting the number of total bettors who betted for Away on  specific match 
            try
            {
                myconn.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT COUNT(username) AS NumberOfawaybetters FROM setbetmatches3 WHERE (MatchNo ='" + matchno + "'AND setno='" + setnum + "' AND oddname ='away'  AND username <> 'Administrator' AND username <> 'Administrator1')", myconn);
                SqlDataReader reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    //Assign to your strings here
                    _betpatternaway = Convert.ToDecimal(reader["NumberOfawaybetters"].ToString());

                }
                myconn.Close();

            }
            catch (Exception ex)
            {
                String error = ex.Message;
            }
            finally
            {
                myconn.Close();
            }
            //getting the number of total bettors who betted for Draw on  specific match 
            try
            {
                myconn.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT COUNT(username) AS NumberOfdrawbetters FROM setbetmatches3 WHERE (MatchNo ='" + matchno + "'AND setno='" + setnum + "' AND oddname ='draw'  AND username <> 'Administrator' AND username <> 'Administrator1')", myconn);
                SqlDataReader reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    //Assign to your strings here
                    _betpatterndraw = Convert.ToDecimal(reader["NumberOfdrawbetters"].ToString());

                }
                myconn.Close();

            }
            catch (Exception ex)
            {
                String error = ex.Message;
            }
            finally
            {
                myconn.Close();
            }
            //getting the other Details for the match 
            try
            {
                myconn.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT champ,host,visitor,winhome,winaway,loseaway,type FROM betmatch4 WHERE (MatchNo ='" + matchno.Trim() + "')", myconn);
                SqlDataReader reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    //Assign to your strings here

                    _matchleague = reader["champ"].ToString();
                    //_matchcategory = reader["oddname"].ToString();
                    _matchtype = reader["type"].ToString();
                    _home = reader["host"].ToString();
                    _away = reader["visitor"].ToString();
                    _homeodd = reader["winhome"].ToString();
                    _awayodd = reader["winaway"].ToString();
                    _drawodd = reader["loseaway"].ToString();

                }
                myconn.Close();

            }
            catch (Exception ex)
            {
                String error = ex.Message;
            }
            finally
            {
                myconn.Close();
            }
            //getting the Result of a specific match 
            try
            {
                myconn.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT oddname FROM betresults4 WHERE (MatchNo ='" + matchno + "'AND setno='" + setnum + "'  AND username <> 'Administrator' AND username <> 'Administrator1')", myconn);
                SqlDataReader reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    //Assign to your strings here 
                    _matchresult = reader["oddname"].ToString();

                }
                myconn.Close();

            }
            catch (Exception ex)
            {
                String error = ex.Message;
            }
            finally
            {
                myconn.Close();
            }
            //getting the Total money collected of a specific match 
            try
            {
                myconn.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT betmoney AS totalmoney FROM setbetmatches3 WHERE (MatchNo ='" + matchno + "'AND setno='" + setnum + "'  AND username <> 'Administrator' AND username <> 'Administrator1')", myconn);
                SqlDataReader reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    //Assign to your strings here
                    _totalmoneyholder = Convert.ToDouble(reader["totalmoney"].ToString());
                    _totalmoney =_totalmoneyholder + _totalmoney;
                }
                myconn.Close();

            }
            catch (Exception ex)
            {
                String error = ex.Message;
            }
            finally
            {
                myconn.Close();
            }
            //getting the Total money collected for the home bets of a specific match 
            try
            {
                myconn.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT betmoney AS totalmoneyhome FROM setbetmatches3 WHERE (MatchNo ='" + matchno + "'AND setno='" + setnum + "'AND oddname ='home'  AND username <> 'Administrator' AND username <> 'Administrator1')", myconn);
                SqlDataReader reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    //Assign to your strings here
                    _totalmoneyhomeholder = Convert.ToDouble(reader["totalmoneyhome"].ToString());
                    _totalmoneyhome =_totalmoneyhomeholder + _totalmoneyhome;
                }
                myconn.Close();

            }
            catch (Exception ex)
            {
                String error = ex.Message;
            }
            finally
            {
                myconn.Close();
            }
            //getting the gross money Payout for the home bets of a specific match 
            try
            {
                myconn.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT ttmoneywin AS grossmoney FROM setbetmatches3 WHERE (MatchNo ='" + matchno + "'AND setno='" + setnum + "'AND oddname ='home'  AND username <> 'Administrator' AND username <> 'Administrator1')", myconn);
                SqlDataReader reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    //Assign to your strings here
                    _grossmoneyhomeholder = Convert.ToDouble(reader["grossmoney"].ToString());
                    _grossmoneyhome =_grossmoneyhomeholder + _grossmoneyhome;
                }
                myconn.Close();

            }
            catch (Exception ex)
            {
                String error = ex.Message;
            }
            finally
            {
                myconn.Close();
            }
            //getting the gross money Payout for the other bets of a specific match 
            try
            {
                myconn.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT ttmoneylose AS grossmoneylose FROM setbetmatches3 WHERE (MatchNo ='" + matchno + "'AND setno='" + setnum + "'AND oddname <> 'home'  AND username <> 'Administrator' AND username <> 'Administrator1')", myconn);
                SqlDataReader reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    //Assign to your strings here
                    _losehomeholder = Convert.ToDouble(reader["grossmoneylose"].ToString());
                    _losehome =_losehomeholder + _losehome;
                    
                }
                myconn.Close();

            }
            catch (Exception ex)
            {
                String error = ex.Message;
            }
            finally
            {
                myconn.Close();
            }
            _netwinpayouthome = (_grossmoneyhome + _losehome) - _totalmoney;
            _netrevenuehome = _totalmoney - (_grossmoneyhome + _losehome);
            
            //getting the total money paid out to betters if home won
            _grossmoneyhome = _grossmoneyhome + _losehome;

            //getting the Total money collected for the away bets of a specific match 
            try
            {
                myconn.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT betmoney AS totalmoneyaway FROM setbetmatches3 WHERE (MatchNo ='" + matchno + "'AND setno='" + setnum + "'AND oddname ='away'  AND username <> 'Administrator' AND username <> 'Administrator1')", myconn);
                SqlDataReader reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    //Assign to your strings here
                    _totalmoneyawayholder = Convert.ToDouble(reader["totalmoneyaway"].ToString());
                    _totalmoneyaway =_totalmoneyawayholder + _totalmoneyaway;
                }
                myconn.Close();

            }
            catch (Exception ex)
            {
                String error = ex.Message;
            }
            finally
            {
                myconn.Close();
            }
            //getting the gross money Payout for the Away bets of a specific match 
            try
            {
                myconn.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT ttmoneywin AS grossmoneyaway FROM setbetmatches3 WHERE (MatchNo ='" + matchno + "'AND setno='" + setnum + "'AND oddname ='away'  AND username <> 'Administrator' AND username <> 'Administrator1')", myconn);
                SqlDataReader reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    //Assign to your strings here
                    _grossmoneyawayholder = Convert.ToDouble(reader["grossmoneyaway"].ToString());
                    _grossmoneyaway =_grossmoneyawayholder + _grossmoneyaway;
                }
                myconn.Close();

            }
            catch (Exception ex)
            {
                String error = ex.Message;
            }
            finally
            {
                myconn.Close();
            }
            //getting the gross money Payout for the other bets of a specific match 
            try
            {
                myconn.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT ttmoneylose AS grossmoneyaway FROM setbetmatches3 WHERE (MatchNo ='" + matchno + "'AND setno='" + setnum + "'AND oddname <>'away'  AND username <> 'Administrator' AND username <> 'Administrator1')", myconn);
                SqlDataReader reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    //Assign to your strings here
                    _loseawayholder = Convert.ToDouble(reader["grossmoneyaway"].ToString());
                    _loseaway =_loseawayholder + _loseaway;
                }
                myconn.Close();

            }
            catch (Exception ex)
            {
                String error = ex.Message;
            }
            finally
            {
                myconn.Close();
            }
            _netwinpayoutaway = (_grossmoneyaway + _loseaway) - _totalmoney;
            _netrevenueaway = _totalmoney - (_grossmoneyaway + _loseaway);

            //getting the total money paid out to betters if Away won
            _grossmoneyaway = _grossmoneyaway + _loseaway;


            ////getting the Total money collected for the draw bets of a specific match 
            //try
            //{
            //    myconn.Open();
            //    SqlCommand cmd2 = new SqlCommand("SELECT SUM(betmoney) AS totalmoneydraw FROM setbetmatches3 WHERE (MatchNo ='" + matchno + "'AND setno='" + setnum + "'AND oddname ='draw'  AND username <> 'Administrator' AND username <> 'Administrator1')", myconn);
            //    SqlDataReader reader = cmd2.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        //Assign to your strings here
            //        _totalmoneydraw = Convert.ToDouble(reader["totalmoneydraw"].ToString());
            //    }
            //    myconn.Close();

            //}
            //catch (Exception ex)
            //{
            //    String error = ex.Message;
            //}
            //finally
            //{
            //    myconn.Close();
            //}
            ////getting the gross money Payout for the Draw bets of a specific match 
            //try
            //{
            //    myconn.Open();
            //    SqlCommand cmd2 = new SqlCommand("SELECT SUM(ttmoneylose) AS grossmoneydraw FROM setbetmatches3 WHERE (MatchNo ='" + matchno + "'AND setno='" + setnum + "'AND oddname ='draw' AND username <> 'Administrator' AND username <> 'Administrator1')", myconn);
            //    SqlDataReader reader = cmd2.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        //Assign to your strings here
            //        _grossmoneydraw = Convert.ToDouble(reader["grossmoneydraw"].ToString());
            //    }
            //    myconn.Close();

            //}
            //catch (Exception ex)
            //{
            //    String error = ex.Message;
            //}
            //finally
            //{
            //    myconn.Close();
            //}
            //_netwinpayoutdraw = _grossmoneydraw - _totalmoneydraw;
            //_netrevenuedraw = _totalmoney - _grossmoneydraw;

            // store the calculations in the Summary Table
            try
            {
               // myconn.Open();

                String sql2 = "insert into SummaryTable(date_e,MatchNo,league,betcategory,bettype,home,away,homeodds," +
                "awayodds,drawodds,totalbettors,betpatternHome,betpatternAway,betpatternDraw,result," +
                "totalBetvalSupporters,totalBetvalHome,netwinpayoutHome,grosspayoutHome,netrevenueHome,totalBetvalAway," +
                "netwinpayoutAway,grosspayoutAway,netrevenueAway,totalBetvalDraw,netwinpayoutDraw,grosspayoutDraw," +
                "netrevenueDraw,revenueHome,revenueAway,revenueDraw,finalrevenue)values('" + my_date + "','" + matchno + "','" + _matchleague +
                "','" + _matchcategory + "','" + _matchtype + "','" + _home + "','" + _away + "','" + _homeodd +
                "','" + _awayodd + "','" + _drawodd + "','" + _totalbettors + "','" + _betpatternhome + "','" + _betpatternaway + "','" + _betpatterndraw +
                "','" + _matchresult + "','" + _totalmoney + "','" + _totalmoneyhome + "','" + _netwinpayouthome + "','" + _grossmoneyhome +
                "','" + _netrevenuehome + "','" + _totalmoneyaway + "','" + _netwinpayoutaway + "','" + _grossmoneyaway +
                "','" + _netrevenueaway + "','" + _totalmoneydraw + "','" + _netwinpayoutdraw + "','" + _grossmoneydraw +
                "','" + _netrevenuedraw + "','" + _revenuehome + "','" + _revenueaway + "','" + _revenuedraw + "','" + _finalrevenue + "')";

                results = insertfunc(sql2, myconn);

                myconn.Close();

            }
            catch (Exception ex)
            {
                String error = ex.Message;
            }
            finally
            {
                myconn.Close();
            }

        }
        //=============================================================================================================
        //=============================================================================================================

        public void insertlogfile(String notes, SqlConnection myconn, String username)
        {

            try
            {                
                String _name = null;
                DateTime mdate = DateTime.Now;
                int results = 0;

                myconn.Open();
                SqlCommand cmd2 = new SqlCommand("Select CompleteName From users where (UserName = '" + username + "');", myconn);
                SqlDataReader reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    //Assign to your strings here
                    _name = reader["CompleteName"].ToString();

                }
                myconn.Close();

                String sql1 = "insert into logfile(userID,Date,Notes)values('" + _name + "','" + mdate + "','" + notes + "')";
                results = insertfunc(sql1, myconn);
            }
            catch (Exception ex)
            {
                String error = ex.Message;
            }
            finally
            {
                myconn.Close();
            }
            
        }
        //=========================================================================================

        public void betpayments(String transaction,SqlConnection myconn, String Account, Double Amount, String Number)
        {
            String nwdate = null;
            nwdate = Convert.ToString(DateTime.Now);

            Double amount_e1y = 0, _total_amount = 0, _mane=0,_accountbal=0;

            int b4 = 0, baf = 0, btmney = 0;

            // Checking the balance on ones's Account .
            //==================================================================================================================

            try
            {
                myconn.Open();
               
                string query2 = "SELECT ammount_e FROM deposits WHERE (userID Like '" + Account + "' )";
                SqlCommand cmd1 = new SqlCommand(query2, myconn);
               
                SqlDataReader reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                    _total_amount = Convert.ToDouble(reader["ammount_e"].ToString());
                }
                cmd1.Connection = myconn;
                myconn.Close();
            }
            catch (Exception ex)
            {
                String error = ex.Message;
            }
            finally
            {
                myconn.Close();
            }

            _accountbal = _total_amount - Amount;

            // Updating one's Account with the Balance After Subtracting the Won Money .
            //==================================================================================================================
           
            try
            {
                myconn.Open();
                SqlCommand cmd2 = new SqlCommand("UPDATE  deposits SET date_e=@date_e,ammount_e=@ammount_e,admin_e=@admin_e WHERE (userID Like @userID )", myconn);

                cmd2.Parameters.AddWithValue("@ammount_e", _accountbal);
                cmd2.Parameters.AddWithValue("@admin_e", "Bet Account");
                cmd2.Parameters.AddWithValue("@date_e", nwdate);
                cmd2.Parameters.AddWithValue("@userID", Account);

                cmd2.Connection = myconn;
                cmd2.ExecuteNonQuery();
                myconn.Close();
            }
            catch (Exception ex)
            {
                String error = ex.Message;
            }
            finally
            {
                myconn.Close();
            }

            // Making a notification of how won money has been withdrawn from one's account and sent to his/her Mobile Number.
            //==================================================================================================================

            try
            {

                myconn.Open();

                SqlCommand cmd1 = new SqlCommand("insert into stmts(account, transcation,method,controller,StatetmentDate,serial, balbefore,ammount,BalAfter)values(@account, @transcation,@method,@controller,@StatetmentDate,@serial, @balbefore,@ammount,@BalAfter)", myconn);

                cmd1.Parameters.AddWithValue("@account", Account);
                cmd1.Parameters.AddWithValue("@transcation", Amount + " Ugx Withdrawn and sent to Number " + Number);
                cmd1.Parameters.AddWithValue("@method", "Site Access");
                cmd1.Parameters.AddWithValue("@controller", "Adiministrator");
                cmd1.Parameters.AddWithValue("@StatetmentDate", nwdate);
                cmd1.Parameters.AddWithValue("@serial", "Global 1x2");
                cmd1.Parameters.AddWithValue("@balbefore", _total_amount);
                cmd1.Parameters.AddWithValue("@ammount", Amount);
                cmd1.Parameters.AddWithValue("@BalAfter", _accountbal);

                cmd1.Connection = myconn;
                cmd1.ExecuteNonQuery();
                myconn.Close();
            }
            catch (Exception ex)
            {
                String error = ex.Message;
            }
            finally
            {
                myconn.Close();
            }
                       
            // Update the table where Payment came from. To know whether the payment was made successfully.
            //===============================================================================================

            try
            {
                myconn.Open();
                SqlCommand cmd2 = new SqlCommand("UPDATE  won_payments SET status=@status WHERE (transactions Like @transactions)", myconn);

                cmd2.Parameters.AddWithValue("@status", "Paid");
                cmd2.Parameters.AddWithValue("@transactions", transaction);
               
                cmd2.Connection = myconn;
                cmd2.ExecuteNonQuery();
                myconn.Close();
            }
            catch (Exception ex)
            {
                String error = ex.Message;
            }
            finally
            {
                myconn.Close();
            }

        }   
  //=============================================================================================================
   //=============================================================================================================
        //Delete the client payments 
        public void DeletePayments(StringCollection sc, SqlConnection conn)
        {
            //SqlConnection conn = new SqlConnection(GetConnectionString());
            StringBuilder sb = new StringBuilder(string.Empty);

            foreach (string item in sc)
            {
                const string sqlStatement = "DELETE FROM won_payments WHERE transactions";
                sb.AppendFormat("{0}='{1}'; ", sqlStatement, item);

                //Delete_Customer(item, conn);
            }
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Deletion Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }
        }
        //betting with the Sure deal
        //=================================================================================================
        public void sure_deal_putmoney(String settno, String mattno)
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
                string error = ex.Message;
            }
            finally
            {
                conn.Close();
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
                    string error = ex.Message;
                }
                finally
                {
                    conn.Close();
                }

            }
        }
        //looking at the Away side winning
        //==========================================================================================================

        public void sure_deal_away(Decimal ttAmmount, Double percent, Double percent1, String settno, String mattno)
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
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            finally
            {
                conn.Close();
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
            catch (Exception ex)
            {
                string error = ex.Message;
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
            catch (Exception ex)
            {
                string error = ex.Message;
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
            catch (Exception ex)
            {
                string error = ex.Message;
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
                cmd0.Parameters.AddWithValue("@oddname", "away");

                cmd0.Connection = conn;
                cmd0.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            finally
            {
                conn.Close();
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
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
        //looking at the Home side winning
        //==========================================================================================================

        public void sure_deal(Decimal ttAmmount, Double percent, Double percent1, String settno, String mattno)
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
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            finally
            {
                conn.Close();
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
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            finally
            {
                conn.Close();
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
            catch (Exception ex)
            {
                string error = ex.Message;
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
            catch (Exception ex)
            {
                string error = ex.Message;
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
            catch (Exception ex)
            {
                string error = ex.Message;
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
            catch (Exception ex)
            {
                string error = ex.Message;
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
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
        //looking at calling Matches 1 by 1
        //==========================================================================================================

        public void fillgames(String settno, String mattno)
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
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            finally
            {
                conn.Close();
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
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            finally
            {
                conn.Close();
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
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            while (j >= 1)
            {
                sure_deal_away(maneItems[k], percent, percent1, settno, mattno);
                k++; j--;
            }

        }
        //=========================================================================================

        public string GetNextSetNo(SqlConnection myconn)
        {
            //This method gets the next Number

            string varNxtNo;

            DataSet ds = new DataSet();
            //SqlCommand cmd = new SqlCommand("SELECT distinct BrandCode,BrandName FROM [Brands]", connect);
            SqlCommand cmd = new SqlCommand("SELECT distinct NxtSetNo FROM [DBControl]", myconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "DBControl");

            myconn.Open();
            cmd.ExecuteNonQuery();

            varNxtNo = ds.Tables["DBControl"].Rows[0][0].ToString();

            myconn.Close();

            return varNxtNo;
        }
        //=========================================================================================
        public string EditNextMobileSerial(string varNxtNo, SqlConnection myconn)
        {
            //Edits where the other number/Next number will go

            SqlCommand cmd = new SqlCommand("UPDATE [DBControl] SET [NxtSerialMobile] = '" +
                Convert.ToString((Convert.ToInt32(varNxtNo)) + 1) +
                "' WHERE [NxtSerialMobile] = '" + varNxtNo + "'", myconn);

            myconn.Open();
            cmd.ExecuteNonQuery();
            myconn.Close();

            //Convert Next Number from string to int, add 1 to it, then back to sting and return it.
            return Convert.ToString(Convert.ToInt32(varNxtNo));
        }
        public string GetNextMobileSerial(SqlConnection myconn)
        {
            //This method gets the next Number

            string varNxtNo;

            DataSet ds = new DataSet();
            //SqlCommand cmd = new SqlCommand("SELECT distinct BrandCode,BrandName FROM [Brands]", connect);
            SqlCommand cmd = new SqlCommand("SELECT distinct NxtSerialMobile FROM [DBControl]", myconn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "DBControl");

            myconn.Open();
            cmd.ExecuteNonQuery();

            varNxtNo = ds.Tables["DBControl"].Rows[0][0].ToString();

            myconn.Close();

            return varNxtNo;
        }
    }
           
    //=============================================================================================================
    //============================================================================================================= 
   
}

