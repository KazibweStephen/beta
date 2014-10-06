using System.Web.Services;

/// <summary>
/// Summary description for ProcessInputs
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class ProcessInputs : System.Web.Services.WebService {
    /*
    PhoneCustomer better = new PhoneCustomer();
    Login users = new Login();
    public ProcessInputs () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

     [WebMethod]
    public string InsertBet(String Phone, String Bet, String MC1, String MC2, String MC3, String MC4, String MC5, String MC6, String MC7, String MC8, String MC9, String MC10, String MC11, String MC12,string Amount)    
    {
        try
        {
            users.Phoneno = Phone;
            string[] codes = { MC1, MC2, MC3, MC4, MC5, MC6, MC7, MC8, MC9, MC9, MC10, MC11, MC12 };
            DataTable dtUser = new DataTable();
            dtUser = users.CustomerDetails().Tables[0];
            if (dtUser.Rows.Count == 0)
            {
                int inserted = users.InsertPhoneBetter();
                if (inserted > 0)
                {
                    return "Your phone has been activated to bet,Please TOP UP your account by sending mobile money to 0788162551. Under REASON type your phone number";
                }
                else
                {
                    return "Please try again";
                }
            }
            else
            {
                if ((Bet == "bet")&&(Amount!=""))
                {
                    if (Convert.ToDecimal( Amount) > 1000)
                    {
                        if ((Convert.ToDecimal(Amount)) > better.Phonebetterbalance())
                        {
                            foreach (String mat in codes)
                            {
                                if ((mat != null) && (mat != ""))
                                {
                                    better.Phoneno = Phone;
                                    better.TeamCode = Convert.ToInt32(mat);
                                    better.betmoney = Convert.ToDecimal(Amount);
                                    better.betdate = DateTime.Now;
                                    better.Phonesetsbet();
                                }
                            }
                            return "Betting successful";
                        }
                        else {
                            return "Your balance is insuffucient to make this bet ";
                        }

                    }
                    else {

                        return "Minimum bet is sh. 1000";
                    }
                }
                else if ((Bet == "bet") && ((Amount== "")||(Amount==null)))
                {
                    return "Please insert Amount";
                }
                else {
                    return "Invalid key words were sent ";
                
                
                }

            }
        }
        catch (Exception ex) {

            return ex.Message;
        }
    
    }
     * */
}

