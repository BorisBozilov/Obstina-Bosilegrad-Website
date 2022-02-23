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


public partial class bg_Novini : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        string sSQL = "SELECT ID,Nadnaslov,Naslov,Podnaslov,Tekst,Slika,Opis FROM articles WHERE (jezik_id='bg') ORDER BY ID DESC";

        SqlCommand cmd = new SqlCommand(sSQL, con);
        con.Open();
        SqlDataReader dtrClient = cmd.ExecuteReader();
        rptList.DataSource = dtrClient;
        rptList.DataBind();
        con.Close();

    }
}