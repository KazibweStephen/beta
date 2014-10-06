using System;
using System.Web.Services;
using System.Net;
using System.Text;

/// <summary>
/// Summary description for ProcessSet
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class ProcessSet : System.Web.Services.WebService {
    ProcessReciept pr = new ProcessReciept();
    Login log = new Login();
    public ProcessSet () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    [WebMethod]

    public string RecieveBet(int amount, string bets, decimal ttodd, string teller, string recieptid,string phone)
    {
        int resp = pr.extractbet(decimal.Parse(amount.ToString()), ttodd, bets, teller, recieptid,phone);
        if (resp == 100)
        {
            return "Successfull";
        }
        else if (resp == -1)
        {
            return "You have less betting credit on your account";
        }
        else
        {
            return "bet not succesfull,please try again";
        }

    }
    public string customersuccessmessage(decimal betmoney, int betid, decimal odd, string agentname)
    {
        StringBuilder clientreply = new StringBuilder();
        clientreply.Append("Expected+win+is+");
        clientreply.Append(Math.Round((betmoney * odd), 0).ToString());
        clientreply.Append("+Shs+for+BET+of+");
        clientreply.Append(betmoney.ToString());
        log.betId = betid;
        clientreply.Append("+Shs+placed+on+");
        clientreply.Append(log.displaygames(betid));
        clientreply.Append("+Set+Number+is+");
        clientreply.Append(betid.ToString().Trim());
        clientreply.Append(".+www.smsbet.ug");
        return clientreply.ToString();


    }

    public void sendcustomersms(string msg, string Destination_number)
    {
        HttpWebRequest RequesttosendSms = (HttpWebRequest)WebRequest.Create("https://secure.jolis.net/jc/sms/interface.php?command=sendsinglesms&username=globalbets&password=dewilos&destination=" + Destination_number + "&source=Globalbets&message=" + msg);
        RequesttosendSms.Headers.Add("username", "globalbets");
        RequesttosendSms.Headers.Add("password", "dewilos");
        RequesttosendSms.Headers.Add("Destination", Destination_number);
        RequesttosendSms.Headers.Add("source", "globalbets");
        RequesttosendSms.Headers.Add("content_type", "1");
        RequesttosendSms.Headers.Add("msg", msg);
        HttpWebResponse ResponsetosendSms = (HttpWebResponse)RequesttosendSms.GetResponse();
        //string result = (string)ResponsetosendSms.GetResponseHeader("DLRID");
    }
}

