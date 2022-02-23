<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_gallery_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 20%;
            height: 42px;
        }
        .style3
        {
            width: 80%;
            height: 42px;
        }
        .style4
        {
            width: 20%;
            height: 23px;
        }
        .style5
        {
            width: 80%;
            height: 23px;
        }
        .style14
        {
            width: 20%;
            height: 41px;
        }
        .style15
        {
            width: 80%;
            height: 41px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <form id="form1" runat="server">
        <p class="naslov">&nbsp;&nbsp;Aдминистративни панел за унос слика у галерију:</p>
    
        <table style="width:100%;" cellpadding="0" cellspacing="0" >
            <tr>
                <td class="style4">
                    <b>&nbsp;&nbsp; Слика&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; :</b>
                </td>
                <td align="left" class="style5" valign="middle">                   
                    <asp:FileUpload ID="FileUpload1" runat="server"  
                        BackColor="#99FF99" Font-Names="Arial" Font-Size="X-Small" Height="16px" 
                        Width="255px" />
                       &nbsp;&nbsp;&nbsp;&nbsp; ID:
                    <asp:TextBox ID="slikaID" runat="server" Width="69px" ReadOnly="True" 
                        style="position: relative; top: 2px; left: 0px; height: 17px" >
                    </asp:TextBox>                  
                       &nbsp;&nbsp;
                    <asp:Label ID="lblMessage" runat="server" valign="middle"></asp:Label>                   
                </td>
            </tr>
        
            <tr>
                <td class="style14">
                    <b>&nbsp;&nbsp; Опис слике&nbsp;&nbsp; 
                    :</b>
                </td>
                <td class="style15">
                    <asp:TextBox ID="txtOpis" runat="server" style="text-align: left" 
                        Width="464px" Font-Names="Arial" Font-Size="X-Small" Height="22px">
                    </asp:TextBox>
                </td>
            </tr>

            <tr>
                <td style="width:20%;">
                    <b>
                        <br />
                        &nbsp;&nbsp; Орјентација :
                            <asp:RadioButtonList ID="rblSlika" runat="server" Width="102px">
                                <asp:ListItem Value="h">Пејзаж</asp:ListItem>
                                <asp:ListItem Value="v">Портрет</asp:ListItem>
                            </asp:RadioButtonList>
                        <br />
                    </b>
                    <b>&nbsp;&nbsp; Jезик :<br />
                        <asp:RadioButtonList ID="rblJezik" runat="server" Height="49px" Width="103px">
                            <asp:ListItem Value="sr">Српски</asp:ListItem>
                            <asp:ListItem Value="bg">Бугарски</asp:ListItem>
                        </asp:RadioButtonList>
                    </b>
                </td>                                            
                <td style="width:80%;" align="center"> 
                    <asp:Image ID="imgSlika" runat="server" BorderStyle="None" Height="250px" 
                        BorderColor="White" ImageAlign="Middle"/>                     
                </td>
            </tr>

            <tr>
                <td class="style2">
                    <b>&nbsp;&nbsp;</b></td>
                <td align="center" class="style3">
                   <asp:Button ID="btnPrvi" runat="server" Font-Bold="False" Font-Names="Arial" 
                       style="text-align: left" Text=" I&lt;" Width="38px" 
                       onclick="btnPrvi_Click" />
                   <asp:Button ID="btnPredhodni" runat="server" Font-Bold="False" 
                       Font-Names="Arial" Text="&lt;&lt;" Width="40px" onclick="btnPredhodni_Click" />
                   <asp:Button ID="btnSledeci" runat="server" Text="&gt;&gt;" Width="32px" 
                           onclick="btnSledeci_Click" />
                   <asp:Button ID="btnZadnji" runat="server" Font-Names="Arial" Text="&gt;I" 
                       Width="35px" onclick="btnZadnji_Click" />    
                </td>
            </tr>

            <tr>
                <td style="width:20%;">
                    <b>&nbsp;&nbsp; </b>
                </td>
                <td style="width:60%;" align="center" height="50">
                    
                    <asp:Button ID="btnNovi" runat="server" BackColor="#66CCFF" Font-Size="X-Small" 
                       Height="26px" onclick="btnNovi_Click" Text="Нова слика" Width="90px" />

                    <asp:Button ID="btnUpload" runat="server" Text="Објави слику" 
                        Width="90px"  onclick="btnUpload_Click" Height="26px" BackColor="#FF66CC" 
                        ForeColor="Black" Font-Names="Arial" Font-Size="X-Small" />
          
                    <asp:Button ID="btnIzmeni" runat="server" BackColor="#FFFF66" Font-Names="Arial" 
                       Text="Промени слику" Font-Size="X-Small" Height="26px" 
                        onclick="btnIzmeni_Click" Width="90px"  />

                    <asp:Button ID="btnObrisi" runat="server" BackColor="#FF3300" 
                       Font-Names="Arial"  Text="Обриши слику" Font-Size="X-Small" Width="90px" 
                        Height="26px" onclick="btnObrisi_Click" />
                
                    <asp:Button ID="btnLogout" runat="server" BackColor="#00FF00" Font-Size="X-Small" 
                       Height="26px" onclick="btnLogout_Click" Text="Одјави се" Width="90px" />   
                </td>
                              
            </tr>

            <tr >
                <td colspan="2" bgcolor="#69c8ff" height="18">
                </td>
           </tr>

        </table>
    </form>

</asp:Content>

