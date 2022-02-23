<%@ Page Title="" Language="C#" MasterPageFile="~/bg/MasterPage.master" AutoEventWireup="true" CodeFile="Slika.aspx.cs" Inherits="bg_Slika" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">

       <div>   
            <table width="100%" align="center" style="margin-top: 10px;">
                 <tr>             
                    <td align="right" width="50%"">                      
                       <asp:Button ID="btnPredhodni" runat="server" Font-Bold="False" 
                           Font-Names="Arial" Text="&lt;&lt;" Width="40px" onclick="btnPredhodni_Click" />                                   
                    </td>
                    <td align="left" width="50%">                                        
                       <asp:Button ID="btnSledeci" runat="server" Text="&gt;&gt;" Width="40px" 
                               onclick="btnSledeci_Click" />                     
                    </td>
                </tr>  
            </table>                
            <table width="100%" align="left" style="margin-top: 10px;">
                <tr>
                    <td align="center"> 
                        <asp:TextBox ID="slikaID" runat="server" Width="69px" ReadOnly="True" 
                        style="display: none;" />
                        <asp:Image ID="imgSlika"  runat="server" align="center" border="1" hspace="10" 
                        ImageUrl='<%# "imgHandlerGallery.ashx?ID=" + Eval("ID") %>' Width="95%"/>
                        <asp:TextBox ID="rblJezik" runat="server" Width="69px" ReadOnly="True" 
                        style="display: none;" />                      
                    </td>                    
                </tr>
                <tr>
                    <td align="center" style="padding-top: 10px; padding-bottom: 10px;">
                        <asp:Label ID="txtOpis" runat="server" valign="middle" style="Font-Size: 20px; Color: #69c8ff;"></asp:Label>
                    </td>
                </tr>                                                      
            </table>
                                                 
            <p align="right" ><a class="menuLink" href="Galerija.aspx"> <<< назад ... </a></p>
                               
            <hr width="100%" />
    
        </div>    

    </form>

</asp:Content>

