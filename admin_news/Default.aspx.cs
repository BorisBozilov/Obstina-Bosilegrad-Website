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
            // Create SQL Connection 
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // Create SQL Command 

            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = "Select * from Vesti where ID=(select max(ID)from Vesti)";
            myCommand.CommandType = CommandType.Text;
            myCommand.Connection = myConnection;

            SqlDataReader myReader = null;




            myConnection.Open();

            myReader = myCommand.ExecuteReader();
            if (myReader.Read())
            {
                txtID.Text = myReader["ID"].ToString();
                txtNadnaslov.Text = myReader["Nadnaslov"].ToString();
                txtNaslov.Text = myReader["Naslov"].ToString();
                txtNaslov.Text = myReader["Naslov"].ToString();
                txtPodnaslov.Text = myReader["Podnaslov"].ToString();
                txtTekst.Text = myReader["Tekst"].ToString();
                txtOpis.Text = myReader["Opis"].ToString();
                imgSlika.ImageUrl = "imgHandler.ashx?id=" + myReader["ID"].ToString();
                rblJezik.SelectedValue = myReader["jezik_id"].ToString();
                rblSlika.SelectedValue = myReader["orjent_slike"].ToString();
 

            }

            myConnection.Close();
        }
 
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string strNadnaslov = txtNadnaslov.Text.ToString();
        string strNaslov = txtNaslov.Text.ToString();
        string strPodnaslov = txtPodnaslov.Text.ToString();
        string strTekst = txtTekst.Text.ToString();
        string strOpis = txtOpis.Text.ToString();
        string strJezik_id = rblJezik.SelectedValue.ToString();
        string strOrjent_slike = rblSlika.SelectedValue.ToString();



        if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.FileName != "")
        {
            string strExtension = System.IO.Path.GetExtension(FileUpload1.FileName);
            if ((strExtension.ToUpper() == ".JPG") | (strExtension.ToUpper() == ".GIF"))
            {
                // Resize Image Before Uploading to DataBase
                System.Drawing.Image imageToBeResized = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);
                int imageHeight = imageToBeResized.Height;
                int imageWidth = imageToBeResized.Width;
                //int maxHeight = 240;
                int maxWidth = 320;
                imageHeight = (imageHeight * maxWidth) / imageWidth;
                imageWidth = maxWidth;

                //if (imageHeight > maxHeight)
                //{
                //    imageWidth = (imageWidth * maxHeight) / imageHeight;
                //    imageHeight = maxHeight;
                //}

                Bitmap bitmap = new Bitmap(imageToBeResized, imageWidth, imageHeight);
                System.IO.MemoryStream stream = new MemoryStream();
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                stream.Position = 0;
                byte[] image = new byte[stream.Length + 1];
                stream.Read(image, 0, image.Length);



                // Create SQL Connection 
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                // Create SQL Command 

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Vesti(Nadnaslov,Naslov,Podnaslov,Tekst,Opis,Slika,orjent_slike,jezik_id) OUTPUT INSERTED.ID VALUES(@Nadnaslov,@Naslov,@Podnaslov,@Tekst,@Opis,@Slika,@orjent_slike,@jezik_id )";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                SqlParameter Nadnaslov = new SqlParameter("@Nadnaslov", SqlDbType.NVarChar, 255);
                Nadnaslov.Value = strNadnaslov.ToString();
                cmd.Parameters.Add(Nadnaslov);

                SqlParameter Naslov = new SqlParameter("@Naslov", SqlDbType.NVarChar, 255);
                Naslov.Value = strNaslov.ToString();
                cmd.Parameters.Add(Naslov);

                SqlParameter Podnaslov = new SqlParameter("@Podnaslov", SqlDbType.NText, 0);
                Podnaslov.Value = strPodnaslov.ToString();
                cmd.Parameters.Add(Podnaslov);

                SqlParameter Tekst = new SqlParameter("@Tekst", SqlDbType.NText, 0);
                Tekst.Value = strTekst.ToString();
                cmd.Parameters.Add(Tekst);


                SqlParameter Opis = new SqlParameter("@Opis", SqlDbType.NVarChar, 255);
                Opis.Value = strOpis.ToString();
                cmd.Parameters.Add(Opis);

                SqlParameter UploadedImage = new SqlParameter("@Slika", SqlDbType.Image, image.Length);
                UploadedImage.Value = image;
                cmd.Parameters.Add(UploadedImage);

                SqlParameter Jezik_id = new SqlParameter("@Jezik_id", SqlDbType.NVarChar, 2);
                Jezik_id.Value = rblJezik.SelectedValue.ToString();
                cmd.Parameters.Add(Jezik_id);

                SqlParameter Orjent_slike = new SqlParameter("@Orjent_slike", SqlDbType.NVarChar, 1);
                Orjent_slike.Value = rblSlika.SelectedValue.ToString();
                cmd.Parameters.Add(Orjent_slike);


                con.Open();
                //int result = cmd.ExecuteNonQuery();
                Int32 newId = (Int32)cmd.ExecuteScalar();
                con.Close();
                //if (result > 0) lblMessage.Text = "File Uploaded";
                imgSlika.ImageUrl = "imgHandler.ashx?id=" + newId.ToString();
                txtID.Text = newId.ToString();

            }
        }
    }


    protected void btnPrvi_Click(object sender, EventArgs e)
    {

        // Create SQL Connection 
        SqlConnection myConnection = new SqlConnection();
        myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        // Create SQL Command 

        SqlCommand myCommand = new SqlCommand();
        myCommand.CommandText = "Select * from Vesti where ID=(select min(ID)from Vesti)";
        myCommand.CommandType = CommandType.Text;
        myCommand.Connection = myConnection;

        SqlDataReader myReader = null;


        myConnection.Open();

        myReader = myCommand.ExecuteReader();
        if (myReader.Read())
        {
            txtID.Text = myReader["ID"].ToString();
            txtNadnaslov.Text = myReader["Nadnaslov"].ToString();
            txtNaslov.Text = myReader["Naslov"].ToString();
            txtNaslov.Text = myReader["Naslov"].ToString();
            txtPodnaslov.Text = myReader["Podnaslov"].ToString();
            txtTekst.Text = myReader["Tekst"].ToString();
            txtOpis.Text = myReader["Opis"].ToString();
            imgSlika.ImageUrl = "imgHandler.ashx?id=" + myReader["ID"].ToString();
            rblJezik.SelectedValue = myReader["jezik_id"].ToString();
            rblSlika.SelectedValue = myReader["orjent_slike"].ToString();

        }

        myConnection.Close();

    }
    protected void btnZadnji_Click(object sender, EventArgs e)
    {
        {

            // Create SQL Connection 
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            // Create SQL Command 

            SqlCommand myCommand = new SqlCommand();
            myCommand.CommandText = "Select * from Vesti where ID=(select max(ID)from Vesti)";
            myCommand.CommandType = CommandType.Text;
            myCommand.Connection = myConnection;

            SqlDataReader myReader = null;


            myConnection.Open();

            myReader = myCommand.ExecuteReader();
            if (myReader.Read())
            {
                txtID.Text = myReader["ID"].ToString();
                txtNadnaslov.Text = myReader["Nadnaslov"].ToString();
                txtNaslov.Text = myReader["Naslov"].ToString();
                txtNaslov.Text = myReader["Naslov"].ToString();
                txtPodnaslov.Text = myReader["Podnaslov"].ToString();
                txtTekst.Text = myReader["Tekst"].ToString();
                txtOpis.Text = myReader["Opis"].ToString();
                imgSlika.ImageUrl = "imgHandler.ashx?id=" + myReader["ID"].ToString();
                rblJezik.SelectedValue = myReader["jezik_id"].ToString();
                rblSlika.SelectedValue = myReader["orjent_slike"].ToString();
  
            }

            myConnection.Close();

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
            myCommand.CommandText = "Select * from Vesti where ID=(select max(ID)from Vesti where ID<" + txtID.Text.ToString() + ")";
            myCommand.CommandType = CommandType.Text;
            myCommand.Connection = myConnection;

            SqlDataReader myReader = null;


            myConnection.Open();

            myReader = myCommand.ExecuteReader();
            if (myReader.Read())
            {
                txtID.Text = myReader["ID"].ToString();
                txtNadnaslov.Text = myReader["Nadnaslov"].ToString();
                txtNaslov.Text = myReader["Naslov"].ToString();
                txtNaslov.Text = myReader["Naslov"].ToString();
                txtPodnaslov.Text = myReader["Podnaslov"].ToString();
                txtTekst.Text = myReader["Tekst"].ToString();
                txtOpis.Text = myReader["Opis"].ToString();
                imgSlika.ImageUrl = "imgHandler.ashx?id=" + myReader["ID"].ToString();
                rblJezik.SelectedValue = myReader["jezik_id"].ToString();
                rblSlika.SelectedValue = myReader["orjent_slike"].ToString();
 
            }

            myConnection.Close();

        }
    }
    protected void btnSledeci_Click(object sender, EventArgs e)
    {

        // Create SQL Connection 
        SqlConnection myConnection = new SqlConnection();
        myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        // Create SQL Command 

        SqlCommand myCommand = new SqlCommand();
        myCommand.CommandText = "Select * from Vesti where ID=(select min(ID)from Vesti where ID>" + txtID.Text.ToString() + ")";

        myCommand.CommandType = CommandType.Text;
        myCommand.Connection = myConnection;

        SqlDataReader myReader = null;


        myConnection.Open();

        myReader = myCommand.ExecuteReader();
        if (myReader.Read())
        {
            txtID.Text = myReader["ID"].ToString();
            txtNadnaslov.Text = myReader["Nadnaslov"].ToString();
            txtNaslov.Text = myReader["Naslov"].ToString();
            txtNaslov.Text = myReader["Naslov"].ToString();
            txtPodnaslov.Text = myReader["Podnaslov"].ToString();
            txtTekst.Text = myReader["Tekst"].ToString();
            txtOpis.Text = myReader["Opis"].ToString();
            imgSlika.ImageUrl = "imgHandler.ashx?id=" + myReader["ID"].ToString();
            rblJezik.SelectedValue = myReader["jezik_id"].ToString();
            rblSlika.SelectedValue = myReader["orjent_slike"].ToString();

        }

        myConnection.Close();

    }

    protected void btnIzmeni_Click(object sender, EventArgs e)
    {
        {
            string strNadnaslov = txtNadnaslov.Text.ToString();
            string strNaslov = txtNaslov.Text.ToString();
            string strPodnaslov = txtPodnaslov.Text.ToString();
            string strTekst = txtTekst.Text.ToString();
            string strOpis = txtOpis.Text.ToString();

            if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.FileName != "")
            {
                string strExtension = System.IO.Path.GetExtension(FileUpload1.FileName);
                if ((strExtension.ToUpper() == ".JPG") | (strExtension.ToUpper() == ".GIF"))
                {
                    // Resize Image Before Uploading to DataBase
                    System.Drawing.Image imageToBeResized = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);
                    int imageHeight = imageToBeResized.Height;
                    int imageWidth = imageToBeResized.Width;
                    //int maxHeight = 240;
                    int maxWidth = 640;
                    imageHeight = (imageHeight * maxWidth) / imageWidth;
                    imageWidth = maxWidth;

                    //if (imageHeight > maxHeight)
                    //{
                    //    imageWidth = (imageWidth * maxHeight) / imageHeight;
                    //    imageHeight = maxHeight;
                    //}

                    Bitmap bitmap = new Bitmap(imageToBeResized, imageWidth, imageHeight);
                    System.IO.MemoryStream stream = new MemoryStream();
                    bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    stream.Position = 0;
                    byte[] image = new byte[stream.Length + 1];
                    stream.Read(image, 0, image.Length);



                    // Create SQL Connection 
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                    // Create SQL Command 

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "UPDATE Vesti SET Nadnaslov=@Nadnaslov, Naslov=@Naslov, Podnaslov=@Podnaslov, Tekst=@Tekst, Opis=@Opis, Slika=@Slika, Orjent_slike=@Orjent_slike, Jezik_id=@Jezik_id  WHERE ID=" + txtID.Text.ToString();
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    SqlParameter Nadnaslov = new SqlParameter("@Nadnaslov", SqlDbType.NVarChar, 255);
                    Nadnaslov.Value = strNadnaslov.ToString();
                    cmd.Parameters.Add(Nadnaslov);

                    SqlParameter Naslov = new SqlParameter("@Naslov", SqlDbType.NVarChar, 255);
                    Naslov.Value = strNaslov.ToString();
                    cmd.Parameters.Add(Naslov);

                    SqlParameter Podnaslov = new SqlParameter("@Podnaslov", SqlDbType.NText, 0);
                    Podnaslov.Value = strPodnaslov.ToString();
                    cmd.Parameters.Add(Podnaslov);

                    SqlParameter Tekst = new SqlParameter("@Tekst", SqlDbType.NText, 0);
                    Tekst.Value = strTekst.ToString();
                    cmd.Parameters.Add(Tekst);


                    SqlParameter Opis = new SqlParameter("@Opis", SqlDbType.NVarChar, 255);
                    Opis.Value = strOpis.ToString();
                    cmd.Parameters.Add(Opis);

                    SqlParameter UploadedImage = new SqlParameter("@Slika", SqlDbType.Image, image.Length);
                    UploadedImage.Value = image;
                    cmd.Parameters.Add(UploadedImage);

                    SqlParameter Jezik_id = new SqlParameter("@Jezik_id", SqlDbType.NVarChar, 2);
                    Jezik_id.Value = rblJezik.SelectedValue.ToString();
                    cmd.Parameters.Add(Jezik_id);

                    SqlParameter Orjent_slike = new SqlParameter("@Orjent_slike", SqlDbType.NVarChar, 1);
                    Orjent_slike.Value = rblSlika.SelectedValue.ToString();
                    cmd.Parameters.Add(Orjent_slike);


                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    //if (result > 0) lblMessage.Text = "File Uploaded";
                    imgSlika.ImageUrl = "imgHandler.ashx?id=" + txtID.Text.ToString();

                }
            }
            else
            {
                // Create SQL Connection 
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                // Create SQL Command 

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE Vesti SET Nadnaslov=@Nadnaslov, Naslov=@Naslov, Podnaslov=@Podnaslov, Tekst=@Tekst, Opis=@Opis, Orjent_slike=@Orjent_slike, Jezik_id=@Jezik_id  WHERE ID=" + txtID.Text.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                SqlParameter Nadnaslov = new SqlParameter("@Nadnaslov", SqlDbType.NVarChar, 255);
                Nadnaslov.Value = strNadnaslov.ToString();
                cmd.Parameters.Add(Nadnaslov);

                SqlParameter Naslov = new SqlParameter("@Naslov", SqlDbType.NVarChar, 255);
                Naslov.Value = strNaslov.ToString();
                cmd.Parameters.Add(Naslov);

                SqlParameter Podnaslov = new SqlParameter("@Podnaslov", SqlDbType.NText, 0);
                Podnaslov.Value = strPodnaslov.ToString();
                cmd.Parameters.Add(Podnaslov);

                SqlParameter Tekst = new SqlParameter("@Tekst", SqlDbType.NText, 0);
                Tekst.Value = strTekst.ToString();
                cmd.Parameters.Add(Tekst);

                SqlParameter Opis = new SqlParameter("@Opis", SqlDbType.NVarChar, 255);
                Opis.Value = strOpis.ToString();
                cmd.Parameters.Add(Opis);

                SqlParameter Jezik_id = new SqlParameter("@Jezik_id", SqlDbType.NVarChar, 2);
                Jezik_id.Value = rblJezik.SelectedValue.ToString();
                cmd.Parameters.Add(Jezik_id);

                SqlParameter Orjent_slike = new SqlParameter("@Orjent_slike", SqlDbType.NVarChar, 1);
                Orjent_slike.Value = rblSlika.SelectedValue.ToString();
                cmd.Parameters.Add(Orjent_slike);


                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();
                //imgSlika.ImageUrl = "imgHandler.ashx?id=" + txtID.Text.ToString();


            }
        }

    }
    protected void btnObrisi_Click(object sender, EventArgs e)
    {

        // Create SQL Connection 
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        // Create SQL Command 

        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "DELETE from Vesti WHERE ID=" + txtID.Text.ToString();
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
        myCommand.CommandText = "Select * from Vesti where ID=(select max(ID)from Vesti where ID<" + txtID.Text.ToString() + ")";
        myCommand.CommandType = CommandType.Text;
        myCommand.Connection = myConnection;

        SqlDataReader myReader = null;


        myConnection.Open();

        myReader = myCommand.ExecuteReader();
        if (myReader.Read())
        {
            txtID.Text = myReader["ID"].ToString();
            txtNadnaslov.Text = myReader["Nadnaslov"].ToString();
            txtNaslov.Text = myReader["Naslov"].ToString();
            txtNaslov.Text = myReader["Naslov"].ToString();
            txtPodnaslov.Text = myReader["Podnaslov"].ToString();
            txtTekst.Text = myReader["Tekst"].ToString();
            txtOpis.Text = myReader["Opis"].ToString();
            imgSlika.ImageUrl = "imgHandler.ashx?id=" + myReader["ID"].ToString();
            rblJezik.SelectedValue = myReader["jezik_id"].ToString();
            rblSlika.SelectedValue = myReader["orjent_slike"].ToString();
        }

        myConnection.Close();


    }


    protected void btnNovi_Click(object sender, EventArgs e)
    {
        txtID.Text = "";
        txtNadnaslov.Text = "";
        txtNaslov.Text = "";
        txtNaslov.Text = "";
        txtPodnaslov.Text = "";
        txtTekst.Text = "";
        txtOpis.Text = "";
        imgSlika.ImageUrl = "";
        rblJezik.SelectedValue = "sr";
        rblSlika.SelectedValue = "h";

    }

    //protected void btnLogout_Click(object sender, EventArgs e)
    //{
    //    FormsAuthentication.SignOut();
    //    Response.Redirect("~/admin_news/Default.aspx");

    //}


    protected void btnLogout_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("~/Admin_panel.aspx");

    }



}