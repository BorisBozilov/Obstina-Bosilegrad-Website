<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form id="LoginForm" method="post" runat="server">
 <div align="center">
 <table border="0" cellspacing="2" cellpadding="2">
    <tr>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    </tr>
    <tr>
    <td>
    Username :</td>
    <td>
    <asp:TextBox id="TextBoxUsername" runat="server" />
    </td>
    </tr>
    <tr>
    <td>Password :</td>
    <td>
    <asp:TextBox id="TextBoxPassword" runat="server" TextMode="Password" />
    </td>
    </tr>
    <tr>
    <td colspan="2">
    <asp:Button id="ButtonLogin"
    runat="server" Text="Login" onclick="ButtonLogin_Click1" />
    </td>
    </tr>
    <tr>
    <td colspan="2">
    <asp:Label id="LabelErrorMessage" runat="server" />
    </td>
    </tr>
 </table>
 </div>
</form>
</asp:Content>

