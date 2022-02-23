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

public partial class bg_Slika : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // btnBack.Attributes.Add("onClick", "javascript:history.back(); return false;");


            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // Create SQL Command 
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT ID,Opis,Slika,jezik_id FROM Galerija WHERE ID=@IID";
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = con;

            SqlParameter PageID = new SqlParameter("@IID", System.Data.SqlDbType.Int);
            PageID.Value = Request.QueryString["ID"];
            cmd.Parameters.Add(PageID);
            con.Open();

            SqlDataReader dtrClient = cmd.ExecuteReader();

            if (dtrClient.Read())
            {
                slikaID.Text = dtrClient["ID"].ToString();
                imgSlika.ImageUrl = "imgHandlerGallery.ashx?id=" + dtrClient["ID"].ToString();
                txtOpis.Text = dtrClient["Opis"].ToString();
                rblJezik.Text = dtrClient["jezik_id"].ToString();
            }

            con.Close();
        }
    }

    protected void btnPredhodni_Click(object sender, EventArgs e)
    {       
        // Create SQL Connection 
        SqlConnection myConnection = new SqlConnection();
        myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        // Create SQL Command 

        SqlCommand myCommand = new SqlCommand();
        myCommand.CommandText = "Select * from Galerija where ID=(select min(ID)from Galerija where ID>" + slikaID.Text.ToString() + " and jezik_id='bg')";
        myCommand.CommandType = CommandType.Text;
        myCommand.Connection = myConnection;

        SqlDataReader myReader = null;


        myConnection.Open();

        myReader = myCommand.ExecuteReader();
        if (myReader.Read())
        {
            slikaID.Text = myReader["ID"].ToString();
            txtOpis.Text = myReader["Opis"].ToString();
            imgSlika.ImageUrl = "imgHandlerGallery.ashx?id=" + myReader["ID"].ToString();
            rblJezik.Text = myReader["jezik_id"].ToString();
        }

        myConnection.Close();      
    }

    protected void btnSledeci_Click(object sender, EventArgs e)
    {

        // Create SQL Connection 
        SqlConnection myConnection = new SqlConnection();
        myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        // Create SQL Command 

        SqlCommand myCommand = new SqlCommand();     
        myCommand.CommandText = "Select * from Galerija where ID=(select max(ID)from Galerija where ID<" + slikaID.Text.ToString() + " and jezik_id='bg')";
        myCommand.CommandType = CommandType.Text;
        myCommand.Connection = myConnection;

        SqlDataReader myReader = null;


        myConnection.Open();

        myReader = myCommand.ExecuteReader();
        if (myReader.Read())
        {
            slikaID.Text = myReader["ID"].ToString();
            txtOpis.Text = myReader["Opis"].ToString();
            imgSlika.ImageUrl = "imgHandlerGallery.ashx?id=" + myReader["ID"].ToString();
            rblJezik.Text = myReader["jezik_id"].ToString();
        }

        myConnection.Close();

    }
}