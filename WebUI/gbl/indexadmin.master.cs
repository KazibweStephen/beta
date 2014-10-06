using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;


public partial class MasterPage : System.Web.UI.MasterPage
{ 
   
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
        Response.Cache.SetNoStore();  
        if (!IsPostBack)
        {
           
                           
            }
        }


    
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session["username"] = null;
        Response.Redirect("../globalbets.aspx");
    }

    protected void tmrUpdate_Tick(object sender, EventArgs e)
    {
       // int _noreq=0;
       // _noreq=noreq();
        
       //lbnocode.Text = "You have "+_noreq.ToString()+" requests for Cash Payments";
    }


    int noreq() { 
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
        return _no_code;
    }
    
    
    }


