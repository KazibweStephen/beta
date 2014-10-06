using System;
using System.Data;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using SRN.BLL;

public struct RequestResponseepay
{
    public String Status;
    public String TransID;   
}

/// <summary>
/// Summary description for epay
/// </summary>
[WebService(Namespace = "http://secure.jolis.net/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class epay : System.Web.Services.WebService {

    public RequestResponseepay request;

    readconn myreadconn = new readconn();
    callingstoredprocedures my_storedpro = new callingstoredprocedures();
    public epay () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    
     [WebMethod(Description = "Writes the Parameters for the Client Response.", EnableSession = false)]
    public string sendpayment(String apiusername, String apipassword, String amount, String sender, String reason)
    {
        DataTable dt = new DataTable();
        string result = null;
        string holdserial = null;

        SqlConnection mycoon=myreadconn.realreadconn();

        my_storedpro.username = reason.Trim();
        my_storedpro.amount = double.Parse(amount);
        my_storedpro.controller = sender.Trim();
        my_storedpro.balbefore = double.Parse(get_bal(reason.Trim()).ToString());

        holdserial = myreadconn.GetNextMobileSerial(mycoon);

        my_storedpro.serial = (holdserial.Trim() + sender.Trim()).Trim();

        myreadconn.EditNextMobileSerial(holdserial, mycoon);
         
        if ((apiusername == "globalbets") && (apipassword == "dewilos"))
        {
            result = my_storedpro.epay();
                        
        }
        return result + "|" + my_storedpro.serial;
    }

     Decimal get_bal(String ppp)
     {
         SqlConnection conn = null;
         conn = new SqlConnection(ConfigurationManager.ConnectionStrings["betConnectionString"].ConnectionString.ToString());

         Decimal amount_e1 = 0;
         try
         {
             conn.Open();
             //checking up money on one's Account

             SqlCommand cmd8 = new SqlCommand("select ammount_e from deposits WHERE (userID = @userID )", conn);
             cmd8.Parameters.AddWithValue("@userID", ppp);

             SqlDataReader reader1 = cmd8.ExecuteReader();
             while (reader1.Read())
             {
                 //Assign to your textbox here 
                 amount_e1 = Convert.ToDecimal(reader1["ammount_e"].ToString());
             }
             cmd8.Connection = conn;
             conn.Close();

         }
         catch
         {
             //result.Text = "Error Occured, Please try Again!!!";
         }

         return (amount_e1);

     }

}

