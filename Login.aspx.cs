using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ButtonLogin_Click1(object sender, EventArgs e)
    {
        //if (TextBoxUsername.Text == TextBoxPassword.Text)
        if ((TextBoxUsername.Text == "boris") && (TextBoxPassword.Text=="box0206"))
        {
            FormsAuthentication.RedirectFromLoginPage(
            TextBoxUsername.Text, false);
        }
        else
        {
            LabelErrorMessage.Text = "Invalid login!";
        }
    }
}