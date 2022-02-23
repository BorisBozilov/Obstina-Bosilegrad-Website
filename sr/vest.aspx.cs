using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing;

public partial class sr_vest : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
 
       // btnBack.Attributes.Add("onClick", "javascript:history.back(); return false;");

    
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;                      

        // Create SQL Command 
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT ID,Nadnaslov,Naslov,Podnaslov,Tekst,Slika,Opis FROM Vesti WHERE ID =@IID";
        cmd.CommandType = System.Data.CommandType.Text; 
        cmd.Connection = con;

        SqlParameter PageID = new SqlParameter("@IID", System.Data.SqlDbType.Int);
        PageID.Value = Request.QueryString["ID"];
        cmd.Parameters.Add(PageID);
        con.Open();
       
        SqlDataReader dtrClient = cmd.ExecuteReader();
        rptList.DataSource = dtrClient;
        rptList.DataBind();
        con.Close();
        
    }

     // <a href="javascript: history.go(-1)">Back</a>
  
}

