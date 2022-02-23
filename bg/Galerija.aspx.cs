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

public partial class bg_Galerija : System.Web.UI.Page
{
    public int PageNumber
    {
        get
        {
            if (ViewState["PageNumber"] != null)
                return Convert.ToInt32(ViewState["PageNumber"]);
            else
                return 0;
        }
        set
        {
            ViewState["PageNumber"] = value;
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        rptPages1.ItemCommand +=
           new RepeaterCommandEventHandler(rptPages_ItemCommand);
        rptPages2.ItemCommand +=
            new RepeaterCommandEventHandler(rptPages_ItemCommand);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            LoadData();
    }

    private void LoadData()
    {
        SqlConnection cn = new SqlConnection();
        cn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        cn.Open();


        SqlDataAdapter da = new SqlDataAdapter("SELECT ID,Slika,Opis FROM Galerija WHERE (jezik_id='bg') ORDER BY ID DESC", cn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        cn.Close();

        PagedDataSource pgitems = new PagedDataSource();
        DataView dv = new DataView(dt);
        pgitems.DataSource = dv;

        pgitems.AllowPaging = true;
        pgitems.PageSize = 10;
        pgitems.CurrentPageIndex = PageNumber;

        if (pgitems.PageCount > 1)
        {
            rptPages1.Visible = true;
            rptPages2.Visible = true;
            ArrayList pages = new ArrayList();
            for (int i = 0; i < pgitems.PageCount; i++)
                pages.Add((i + 1).ToString());
            rptPages1.DataSource = pages;
            rptPages1.DataBind();
            rptPages2.DataSource = pages;
            rptPages2.DataBind();

        }
        else
        {
            rptPages1.Visible = false;
            rptPages2.Visible = false;
        }


        rptItems.DataSource = pgitems;
        rptItems.DataBind();


    }

    void rptPages_ItemCommand(object source,
                              RepeaterCommandEventArgs e)
    {
        PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
        LoadData();
    }
}