using System;
using System.Collections;
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

public partial class sr_Javne_nabavke : System.Web.UI.Page
{

    protected void Page_Load(Object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
            LoadData();

    }



    private void LoadData()
    {
        SqlConnection cn = new SqlConnection();
        cn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        cn.Open();

        SqlDataAdapter daNabavke = new SqlDataAdapter("SELECT ID,PIB,Narucilac,Naziv_postupka,Vrsta_postupka,Vrsta_predmeta,Procenjena_vrednost,Datum_objave,Rok_objave,Status FROM Nabavke WHERE (jezik_id='sr') ORDER BY ID DESC", cn);
        DataSet ds = new DataSet();
        daNabavke.Fill(ds, "Nabavke");
        
        SqlDataAdapter daDokumenti = new SqlDataAdapter("select * from Dokumenti", cn);
        daDokumenti.Fill(ds, "Dokumenti");

        cn.Close();


        DataRelation rel = new DataRelation("NabDokRel", ds.Tables["Nabavke"].Columns["ID"], ds.Tables["Dokumenti"].Columns["Nabavka_ID"]);
        ds.Relations.Add(rel);
        RepNab.DataSource = ds.Tables["Nabavke"].DefaultView;
        RepNab.DataBind(); 
    }

    
    public void ShowDocuments(Object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ((Repeater)e.Item.FindControl("RepDok")).DataSource = ((DataRowView)e.Item.DataItem).CreateChildView("NabDokRel");
            ((Repeater)e.Item.FindControl("RepDok")).DataBind();
        }
    }
}