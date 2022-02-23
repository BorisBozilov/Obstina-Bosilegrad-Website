using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing;

public partial class admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // initiate 
            txtID_Nabavke.Text = "1";
            
            // Create SQL Connection 
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // Create SQL Command 

            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = "Select * from Nabavke where ID=(select max(ID)from Nabavke)";
            myCommand.CommandType = CommandType.Text;
            myCommand.Connection = myConnection;

            SqlDataReader myReader = null;


            

            myConnection.Open();

            myReader = myCommand.ExecuteReader();
            if (myReader.Read())
            {
                
                txtID_Nabavke.Text = myReader["ID"].ToString();
                txtPIB_Narucioca.Text = myReader["PIB"].ToString();
                txtNarucilac.Text = myReader["Narucilac"].ToString();
                txtNaziv_postupka.Text = myReader["Naziv_postupka"].ToString();
                txtVrsta_postupka.Text = myReader["Vrsta_postupka"].ToString();
                txtVrsta_predmeta.Text = myReader["Vrsta_predmeta"].ToString();
                txtProcenjena_vrednost.Text = myReader["Procenjena_vrednost"].ToString();
                txtDatum_objave.Text = myReader["Datum_objave"].ToString();
                txtRok_objave.Text = myReader["Rok_objave"].ToString();
                txtStatus_objave.Text = myReader["Status"].ToString();   

              }

            myConnection.Close();


            int curID = int.Parse(txtID_Nabavke.Text.ToString());

            DataTable fileList = GetFileList(curID);
            gvFiles.DataSource = fileList;
            gvFiles.DataBind();             
        
        }
 
    }

   


    protected void btnPrvi_Click(object sender, EventArgs e)
    {

        // Create SQL Connection 
        SqlConnection myConnection = new SqlConnection();
        myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        // Create SQL Command 

        SqlCommand myCommand = new SqlCommand();
        myCommand.CommandText = "Select * from Nabavke where ID=(select min(ID)from Nabavke)";
        myCommand.CommandType = CommandType.Text;
        myCommand.Connection = myConnection;

        SqlDataReader myReader = null;


        myConnection.Open();

        myReader = myCommand.ExecuteReader();
        if (myReader.Read())
        {
            txtID_Nabavke.Text = myReader["ID"].ToString();
            txtPIB_Narucioca.Text = myReader["PIB"].ToString();
            txtNarucilac.Text = myReader["Narucilac"].ToString();
            txtNaziv_postupka.Text = myReader["Naziv_postupka"].ToString();
            txtVrsta_postupka.Text = myReader["Vrsta_postupka"].ToString();
            txtVrsta_predmeta.Text = myReader["Vrsta_predmeta"].ToString();
            txtProcenjena_vrednost.Text = myReader["Procenjena_vrednost"].ToString();
            txtDatum_objave.Text = myReader["Datum_objave"].ToString();
            txtRok_objave.Text = myReader["Rok_objave"].ToString();
            txtStatus_objave.Text = myReader["Status"].ToString();
        }

        myConnection.Close();



        int curID = int.Parse(txtID_Nabavke.Text.ToString());

        DataTable fileList = GetFileList(curID);
        gvFiles.DataSource = fileList;
        gvFiles.DataBind();  

    }
    protected void btnZadnji_Click(object sender, EventArgs e)
    {
        {

            // Create SQL Connection 
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // Create SQL Command 

            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = "Select * from Nabavke where ID=(select max(ID)from Nabavke)";
            myCommand.CommandType = CommandType.Text;
            myCommand.Connection = myConnection;

            SqlDataReader myReader = null;


            myConnection.Open();

            myReader = myCommand.ExecuteReader();
            if (myReader.Read())
            {
                txtID_Nabavke.Text = myReader["ID"].ToString();
                txtPIB_Narucioca.Text = myReader["PIB"].ToString();
                txtNarucilac.Text = myReader["Narucilac"].ToString();
                txtNaziv_postupka.Text = myReader["Naziv_postupka"].ToString();
                txtVrsta_postupka.Text = myReader["Vrsta_postupka"].ToString();
                txtVrsta_predmeta.Text = myReader["Vrsta_predmeta"].ToString();
                txtProcenjena_vrednost.Text = myReader["Procenjena_vrednost"].ToString();
                txtDatum_objave.Text = myReader["Datum_objave"].ToString();
                txtRok_objave.Text = myReader["Rok_objave"].ToString();
                txtStatus_objave.Text = myReader["Status"].ToString();
            }

            myConnection.Close();



            int curID = int.Parse(txtID_Nabavke.Text.ToString());

            DataTable fileList = GetFileList(curID);
            gvFiles.DataSource = fileList;
            gvFiles.DataBind();  

        }
    }
    protected void btnPredhodni_Click(object sender, EventArgs e)
    {
        {


            // Create SQL Connection 
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // Create SQL Command 

            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = "Select * from Nabavke where ID=(select max(ID)from Nabavke where ID<" + txtID_Nabavke.Text.ToString() + ")";
            myCommand.CommandType = CommandType.Text;
            myCommand.Connection = myConnection;

            SqlDataReader myReader = null;


            myConnection.Open();

            myReader = myCommand.ExecuteReader();
            if (myReader.Read())
            {
                txtID_Nabavke.Text = myReader["ID"].ToString();
                txtPIB_Narucioca.Text = myReader["PIB"].ToString();
                txtNarucilac.Text = myReader["Narucilac"].ToString();
                txtNaziv_postupka.Text = myReader["Naziv_postupka"].ToString();
                txtVrsta_postupka.Text = myReader["Vrsta_postupka"].ToString();
                txtVrsta_predmeta.Text = myReader["Vrsta_predmeta"].ToString();
                txtProcenjena_vrednost.Text = myReader["Procenjena_vrednost"].ToString();
                txtDatum_objave.Text = myReader["Datum_objave"].ToString();
                txtRok_objave.Text = myReader["Rok_objave"].ToString();
                txtStatus_objave.Text = myReader["Status"].ToString();
            }

            myConnection.Close();



            int curID = int.Parse(txtID_Nabavke.Text.ToString());

            DataTable fileList = GetFileList(curID);
            gvFiles.DataSource = fileList;
            gvFiles.DataBind();  

        }
    }
    protected void btnSledeci_Click(object sender, EventArgs e)
    {

        // Create SQL Connection 
        SqlConnection myConnection = new SqlConnection();
        myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        // Create SQL Command 

        SqlCommand myCommand = new SqlCommand();
        myCommand.CommandText = "Select * from Nabavke where ID=(select min(ID)from Nabavke where ID>" + txtID_Nabavke.Text.ToString() + ")";

        myCommand.CommandType = CommandType.Text;
        myCommand.Connection = myConnection;

        SqlDataReader myReader = null;


        myConnection.Open();

        myReader = myCommand.ExecuteReader();
        if (myReader.Read())
        {
            txtID_Nabavke.Text = myReader["ID"].ToString();
            txtPIB_Narucioca.Text = myReader["PIB"].ToString();
            txtNarucilac.Text = myReader["Narucilac"].ToString();
            txtNaziv_postupka.Text = myReader["Naziv_postupka"].ToString();
            txtVrsta_postupka.Text = myReader["Vrsta_postupka"].ToString();
            txtVrsta_predmeta.Text = myReader["Vrsta_predmeta"].ToString();
            txtProcenjena_vrednost.Text = myReader["Procenjena_vrednost"].ToString();
            txtDatum_objave.Text = myReader["Datum_objave"].ToString();
            txtRok_objave.Text = myReader["Rok_objave"].ToString();
            txtStatus_objave.Text = myReader["Status"].ToString();
        }

        myConnection.Close();



        int curID = int.Parse(txtID_Nabavke.Text.ToString());

        DataTable fileList = GetFileList(curID);
        gvFiles.DataSource = fileList;
        gvFiles.DataBind();  
    
    
    
    }

 
 


    protected void btnNovi_Click(object sender, EventArgs e)
    {

        txtPIB_Narucioca.Text = "";
        txtNarucilac.Text = "";
        txtNaziv_postupka.Text = "";
        txtVrsta_postupka.Text = "";
        txtVrsta_predmeta.Text = "";
        txtProcenjena_vrednost.Text = "";
        txtDatum_objave.Text = "";
        txtRok_objave.Text = "";
        txtStatus_objave.Text = "";



        string strID_Nabavke = txtID_Nabavke.Text.ToString();
        string strPIB_Narucioca = txtPIB_Narucioca.Text.ToString();
        string strNarucilac = txtNarucilac.Text.ToString();
        string strNaziv_postupka = txtNaziv_postupka.Text.ToString();
        string strVrsta_postupka = txtVrsta_postupka.Text.ToString();
        string strVrsta_predmeta = txtVrsta_predmeta.Text.ToString();
        string strProcenjena_vrednost = txtProcenjena_vrednost.Text.ToString();
        string strDatum_objave = txtDatum_objave.Text.ToString();
        string strRok_objave = txtRok_objave.Text.ToString();
        string strStatus_objave = txtStatus_objave.Text.ToString();


        // Create SQL Connection 
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        // Create SQL Command 
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "INSERT INTO Nabavke(PIB,Narucilac,Naziv_postupka,Vrsta_postupka,Vrsta_predmeta,Datum_objave,Rok_objave,Status) OUTPUT INSERTED.ID VALUES(@PIB,@Narucilac,@Naziv_postupka,@Vrsta_postupka,@Vrsta_predmeta,@Datum_objave,@Rok_objave,@Status )";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;

        SqlParameter PIB = new SqlParameter("@PIB", SqlDbType.NChar, 10);
        PIB.Value = strPIB_Narucioca.ToString();
        cmd.Parameters.Add(PIB);

        SqlParameter Narucilac = new SqlParameter("@Narucilac", SqlDbType.NVarChar, 100);
        Narucilac.Value = strNarucilac.ToString();
        cmd.Parameters.Add(Narucilac);

        SqlParameter Naziv_postupka = new SqlParameter("@Naziv_postupka", SqlDbType.NVarChar, 200);
        Naziv_postupka.Value = strNaziv_postupka.ToString();
        cmd.Parameters.Add(Naziv_postupka);

        SqlParameter Vrsta_postupka = new SqlParameter("@Vrsta_postupka", SqlDbType.NVarChar, 100);
        Vrsta_postupka.Value = strVrsta_postupka.ToString();
        cmd.Parameters.Add(Vrsta_postupka);

        SqlParameter Vrsta_predmeta = new SqlParameter("@Vrsta_predmeta", SqlDbType.NVarChar, 100);
        Vrsta_predmeta.Value = strVrsta_predmeta.ToString();
        cmd.Parameters.Add(Vrsta_predmeta);
        
        //SqlParameter Procenjena_vrednost = new SqlParameter("@Procenjena_vrednost", SqlDbType.Decimal);
        //Procenjena_vrednost.SourceColumn = "Procenjena_vrednost";
        //Procenjena_vrednost.Precision = 12;
        //Procenjena_vrednost.Scale = 2;     
        //Procenjena_vrednost.Value = strProcenjena_vrednost.ToString();
        //cmd.Parameters.Add(Procenjena_vrednost);


        SqlParameter Datum_objave = new SqlParameter("@Datum_objave", SqlDbType.NChar, 10);
        Datum_objave.Value = strDatum_objave.ToString();
        cmd.Parameters.Add(Datum_objave);

        SqlParameter Rok_objave = new SqlParameter("@Rok_objave", SqlDbType.NChar, 10);
        Rok_objave.Value = strRok_objave.ToString();
        cmd.Parameters.Add(Rok_objave);

        SqlParameter Status = new SqlParameter("@Status", SqlDbType.NChar, 20);
        Status.Value = strStatus_objave.ToString();
        cmd.Parameters.Add(Status);

        con.Open();
        //int result = cmd.ExecuteNonQuery();
        Int32 newId = (Int32)cmd.ExecuteScalar();
        con.Close();
        //if (result > 0) lblMessage.Text = "File Uploaded";
        //txtID_Nabavke.Text = newId.ToString(); 

        

        txtID_Nabavke.Text = newId.ToString();

        
        int curID = int.Parse(txtID_Nabavke.Text.ToString());

        DataTable fileList = GetFileList(curID);
        gvFiles.DataSource = fileList;
        gvFiles.DataBind(); 

    }


    protected void btnIzmeni_Click(object sender, EventArgs e)
    {


        string strID_Nabavke = txtID_Nabavke.Text.ToString();
        string strPIB_Narucioca = txtPIB_Narucioca.Text.ToString();
        string strNarucilac = txtNarucilac.Text.ToString();
        string strNaziv_postupka = txtNaziv_postupka.Text.ToString();
        string strVrsta_postupka = txtVrsta_postupka.Text.ToString();
        string strVrsta_predmeta = txtVrsta_predmeta.Text.ToString();
        string strProcenjena_vrednost = txtProcenjena_vrednost.Text.ToString();
        string strDatum_objave = txtDatum_objave.Text.ToString();
        string strRok_objave = txtRok_objave.Text.ToString();
        string strStatus_objave = txtStatus_objave.Text.ToString();



        // Create SQL Connection 
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        // Create SQL Command 

        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "UPDATE Nabavke SET PIB=@PIB, Narucilac=@Narucilac, Naziv_postupka=@Naziv_postupka, Vrsta_postupka=@Vrsta_postupka, Vrsta_predmeta=@Vrsta_predmeta, Datum_objave=@Datum_objave, Rok_objave=@Rok_objave, Status=@Status  WHERE ID=" + txtID_Nabavke.Text.ToString();
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;

        SqlParameter PIB = new SqlParameter("@PIB", SqlDbType.NChar, 10);
        PIB.Value = strPIB_Narucioca.ToString();
        cmd.Parameters.Add(PIB);

        SqlParameter Narucilac = new SqlParameter("@Narucilac", SqlDbType.NVarChar, 100);
        Narucilac.Value = strNarucilac.ToString();
        cmd.Parameters.Add(Narucilac);

        SqlParameter Naziv_postupka = new SqlParameter("@Naziv_postupka", SqlDbType.NVarChar, 200);
        Naziv_postupka.Value = strNaziv_postupka.ToString();
        cmd.Parameters.Add(Naziv_postupka);

        SqlParameter Vrsta_postupka = new SqlParameter("@Vrsta_postupka", SqlDbType.NVarChar, 100);
        Vrsta_postupka.Value = strVrsta_postupka.ToString();
        cmd.Parameters.Add(Vrsta_postupka);

        SqlParameter Vrsta_predmeta = new SqlParameter("@Vrsta_predmeta", SqlDbType.NVarChar, 100);
        Vrsta_predmeta.Value = strVrsta_predmeta.ToString();
        cmd.Parameters.Add(Vrsta_predmeta);

        //SqlParameter Procenjena_vrednost = new SqlParameter("@Procenjena_vrednost", SqlDbType.Decimal);
        //Procenjena_vrednost.SourceColumn = "Procenjena_vrednost";
        //Procenjena_vrednost.Precision = 12;
        //Procenjena_vrednost.Scale = 2;
        //Procenjena_vrednost.Value = strProcenjena_vrednost.ToString();
        //cmd.Parameters.Add(Procenjena_vrednost);

        SqlParameter Datum_objave = new SqlParameter("@Datum_objave", SqlDbType.NChar, 10);
        Datum_objave.Value = strDatum_objave.ToString();
        cmd.Parameters.Add(Datum_objave);

        SqlParameter Rok_objave = new SqlParameter("@Rok_objave", SqlDbType.NChar, 10);
        Rok_objave.Value = strRok_objave.ToString();
        cmd.Parameters.Add(Rok_objave);

        SqlParameter Status = new SqlParameter("@Status", SqlDbType.NChar, 20);
        Status.Value = strStatus_objave.ToString();
        cmd.Parameters.Add(Status);


        con.Open();
        int result = cmd.ExecuteNonQuery();
        con.Close();


    }
  
    
    


    protected void btnObrisi_Click(object sender, EventArgs e)
    {

        // Create SQL Connection 
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        // Create SQL Command 

        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "DELETE from Nabavke WHERE ID=" + txtID_Nabavke.Text.ToString();
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;

        con.Open();
        int result = cmd.ExecuteNonQuery();
        con.Close();


        // Create SQL Connection 
        SqlConnection myConnection = new SqlConnection();
        myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        // Create SQL Command 

        SqlCommand myCommand = new SqlCommand();
        myCommand.CommandText = "Select * from Nabavke where ID=(select max(ID)from Nabavke where ID<" + txtID_Nabavke.Text.ToString() + ")";
        myCommand.CommandType = CommandType.Text;
        myCommand.Connection = myConnection;

        SqlDataReader myReader = null;


        myConnection.Open();

        myReader = myCommand.ExecuteReader();
        if (myReader.Read())
        {
            txtID_Nabavke.Text = myReader["ID"].ToString();
            txtPIB_Narucioca.Text = myReader["PIB"].ToString();
            txtNarucilac.Text = myReader["Narucilac"].ToString();
            txtNaziv_postupka.Text = myReader["Naziv_postupka"].ToString();
            txtVrsta_postupka.Text = myReader["Vrsta_postupka"].ToString();
            txtVrsta_predmeta.Text = myReader["Vrsta_predmeta"].ToString();
            txtProcenjena_vrednost.Text = myReader["Procenjena_vrednost"].ToString();
            txtDatum_objave.Text = myReader["Datum_objave"].ToString();
            txtRok_objave.Text = myReader["Rok_objave"].ToString();
            txtStatus_objave.Text = myReader["Status"].ToString();
        }

        myConnection.Close();


    }  
    
    
        
  
  

    
    //protected void btnLogout_Click(object sender, EventArgs e)
    //{
    //    FormsAuthentication.SignOut();
    //    Response.Redirect("~/admin_sjn/Default.aspx");

    //}

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("~/Admin_panel.aspx");

    }





    public static string GetConnectionString()
    {
        return ConfigurationManager.AppSettings["DBConnectionString"];
    }

    public static void OpenConnection(SqlConnection connection)
    {
        connection.ConnectionString = GetConnectionString();
        connection.Open();
    }

    // Get the list of the files in the database
    public static DataTable GetFileList(int curID)
    {
        DataTable fileList = new DataTable();
        using (SqlConnection connection = new SqlConnection())
        {
            OpenConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandTimeout = 0;

            cmd.CommandText = "SELECT ID, Opis, Naziv, Tip, Velicina FROM Dokumenti WHERE Nabavka_ID=" + curID.ToString();
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.SelectCommand = cmd;
            adapter.Fill(fileList);

            connection.Close();
        }

        return fileList;
    }

    // Save a file into the database
    public static void SaveFile(string descript, string name, string contentType,
        int size, byte[] data, int procurID)
    {
        using (SqlConnection connection = new SqlConnection())
        {
            OpenConnection(connection);
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandTimeout = 0;

            string commandText = "INSERT INTO Dokumenti VALUES(@Opis, @Naziv, @Tip, @Velicina, @Dokument, @Nabavka_ID)";
            cmd.CommandText = commandText;
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@Opis", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@Naziv", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@Tip", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@Velicina", SqlDbType.Int);
            cmd.Parameters.Add("@Dokument", SqlDbType.VarBinary);
            cmd.Parameters.Add("@Nabavka_ID", SqlDbType.Int);

            cmd.Parameters["@Opis"].Value = descript;
            cmd.Parameters["@Naziv"].Value = name;
            cmd.Parameters["@Tip"].Value = contentType;
            cmd.Parameters["@Velicina"].Value = size;
            cmd.Parameters["@Dokument"].Value = data;
            cmd.Parameters["@Nabavka_ID"].Value = procurID;
            
            
            cmd.ExecuteNonQuery();

            connection.Close();
        }
    }

    // Get a file from the database by ID
    public static DataTable GetAFile(int id)
    {
        DataTable file = new DataTable();
        using (SqlConnection connection = new SqlConnection())
        {
            OpenConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandTimeout = 0;

            cmd.CommandText = "SELECT ID, Naziv, Tip, Velicina, Data FROM Dokumenti "
                + "WHERE ID=@ID";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();

            cmd.Parameters.Add("@ID", SqlDbType.Int);
            cmd.Parameters["@ID"].Value = id;

            adapter.SelectCommand = cmd;
            adapter.Fill(file);


            connection.Close();
        }

        return file;
    }



    protected void btnUpload_Click(object sender, EventArgs e)
    {
        // Although I put only one http file control on the aspx page,
        // the following code can handle multiple file controls in a single aspx page.
        // HttpFileCollection files = Request.Files;
        // foreach (string fileTagName in files)
        // {
            //HttpPostedFile file = Request.Files[fileTagName];
            HttpPostedFile file = filMyFile.PostedFile;

            if (file.ContentLength > 0)
            {
                // Due to the limit of the max for a int type, the largest file can be
                // uploaded is 2147483647, which is very large anyway.
                int size = file.ContentLength;
                string descript = txtOpis.Text;
                string name = file.FileName;
                int position = name.LastIndexOf("\\");
                name = name.Substring(position + 1);
                string contentType = file.ContentType;
                byte[] fileData = new byte[size];
                file.InputStream.Read(fileData, 0, size);

                SaveFile(descript, name, contentType, size, fileData, int.Parse(txtID_Nabavke.Text));
            }


            int curID = int.Parse(txtID_Nabavke.Text.ToString());

            DataTable fileList = GetFileList(curID);
            gvFiles.DataSource = fileList;
            gvFiles.DataBind();  
   
    }



    protected void btnDelFile_Click(object sender, EventArgs e)
    {
        // Delete a file from the database by ID

        // Create SQL Connection 
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;


        // Create SQL Command     
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "DELETE from Dokumenti WHERE ID=" + txtID.Text.ToString();
        //txtCommand.Text = "DELETE from Dokumenti WHERE ID=" + txtID.Text.ToString();
        //txtCommand.DataBind();
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;

        con.Open();
        int result = cmd.ExecuteNonQuery();
        con.Close();
        //txtResult.Text = result.ToString();


        int curID = int.Parse(txtID_Nabavke.Text.ToString());

        DataTable fileList = GetFileList(curID);
        gvFiles.DataSource = fileList;
        gvFiles.DataBind();

    }




}