using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Timers;


/// <summary>
/// Summary description for timer3
/// </summary>
public struct timervalues
{
    public static Boolean _Status;
    public static int _no_reqcodes;
    public static Decimal _collect;
}
public class timer3
{
    public static timervalues requestval;
    private static System.Timers.Timer aTimer;
    public int _intvalue;

	public void timer()
	{
        // Normally, the timer is declared at the class level,
        // so that it stays in scope as long as it is needed.
        // If the timer is declared in a long-running method,  
        // KeepAlive must be used to prevent the JIT compiler 
        // from allowing aggressive garbage collection to occur 
        // before the method ends. You can experiment with this
        // by commenting out the class-level declaration and 
        // uncommenting the declaration below; then uncomment
        // the GC.KeepAlive(aTimer) at the end of the method.
        //System.Timers.Timer aTimer;

        // Create a timer with a ten second interval.
        aTimer = new System.Timers.Timer(10000);

        // Hook up the Elapsed event for the timer.
        aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

        // Set the Interval to 2 seconds (2000 milliseconds).
        aTimer.Interval = 10000;
        aTimer.Enabled = true;

        //Console.WriteLine("Press the Enter key to exit the program.");
        //Console.ReadLine();

        // If the timer is declared in a long-running method, use
        // KeepAlive to prevent garbage collection from occurring
        // before the method ends.
        //GC.KeepAlive(aTimer);

	}
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        int _code=0;
       //_code= checkrequests();

       // timervalues reqval = new timervalues();

       Decimal _no_requestcode = 0;
       int _no_code = 0;

       string myConnection = ConfigurationManager.ConnectionStrings["betConnectionString"].ConnectionString;
       SqlConnection conn = new SqlConnection(myConnection);

       try
       {
           conn.Open();
           SqlCommand cmd2 = new SqlCommand("SELECT count(request_code)AS Number FROM reqpayment WHERE (status='Incomplete')", conn);
           SqlDataReader reader = cmd2.ExecuteReader();
           while (reader.Read())
           {
               _no_requestcode = Convert.ToDecimal(reader["Number"].ToString());
           }
           if (_no_requestcode != 0)
           {

               _no_code = Convert.ToInt32(_no_requestcode);
           }
           conn.Close();
       }
       catch (Exception ex)
       {
           String error = ex.Message;
       }

       finally
       {
           conn.Close();
       }
      // _intvalue = _no_code;
       //return _no_code;       

        //Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
       //return _code;
    }

    //private static int checkrequests()
    //{
    //     // timervalues reqval = new timervalues();

    //      Decimal _no_requestcode = 0;
    //     int _no_code = 0;
         
    //    string myConnection = ConfigurationManager.ConnectionStrings["betConnectionString"].ConnectionString;
    //    SqlConnection conn = new SqlConnection(myConnection);
        
    //        try
    //        {
    //            conn.Open();
    //            SqlCommand cmd2 = new SqlCommand("SELECT count(request_code)AS Number FROM reqpayment WHERE (status='Incomplete')", conn);
    //            SqlDataReader reader = cmd2.ExecuteReader();
    //            while (reader.Read())
    //            {
    //                _no_requestcode = Convert.ToDecimal(reader["Number"].ToString());
    //            }
    //            if (_no_requestcode!=0) {

    //                _no_code = Convert.ToInt32(_no_requestcode);                
    //            }
    //            conn.Close();
    //        }
    //        catch (Exception ex)
    //        {             
    //            String error = ex.Message;
    //        }

    //        finally
    //        {
    //            conn.Close();
    //        }
    //        return _no_code;       
    //}

}
