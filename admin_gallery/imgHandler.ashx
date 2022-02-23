<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

public class Handler : IHttpHandler {
    
public void ProcessRequest (HttpContext context) 
{
SqlConnection con = new SqlConnection();
con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;                      

// Create SQL Command 
SqlCommand cmd = new SqlCommand();
cmd.CommandText = "Select ID,Slika from Galerija where ID =@IID";
cmd.CommandType = System.Data.CommandType.Text; 
cmd.Connection = con;

SqlParameter ImageID = new SqlParameter("@IID", System.Data.SqlDbType.Int);
ImageID.Value = context.Request.QueryString["ID"];
cmd.Parameters.Add(ImageID);
con.Open();
SqlDataReader dReader = cmd.ExecuteReader();
dReader.Read();
context.Response.BinaryWrite((byte[])dReader["Slika"]);
dReader.Close();
con.Close();
}
    
     
    
  public bool IsReusable {
    get {
            return false;
        }
  }

}
