using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class fupdn_GetFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Get the file id from the query string
        int id = Convert.ToInt16(Request.QueryString["ID"]);

        // Get the file from the database
        DataTable file = GetAFile(id);
        DataRow row = file.Rows[0];

        string name = (string)row["Naziv"];
        string contentType = (string)row["Tip"];
        Byte[] data = (Byte[])row["Dokument"];

        // Send the file to the browser
        Response.AddHeader("Content-type", contentType);
        Response.AddHeader("Content-Disposition", "attachment; filename=" + name);
        Response.BinaryWrite(data);
        Response.Flush();
        Response.End();
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

            cmd.CommandText = "SELECT ID, Opis, Naziv, Tip, Velicina, Dokument, Nabavka_ID FROM Dokumenti "
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

    private static string GetConnectionString()
    {
        return ConfigurationManager.AppSettings["DBConnectionString"];
    }

    private static void OpenConnection(SqlConnection connection)
    {
        connection.ConnectionString = GetConnectionString();
        connection.Open();
    }
}