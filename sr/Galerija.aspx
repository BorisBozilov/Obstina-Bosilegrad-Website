<%@ Page Title="" Language="C#" MasterPageFile="~/sr/MasterPage.master" AutoEventWireup="true" CodeFile="Galerija.aspx.cs" Inherits="sr_Galerija" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<form id="Form1" runat="server">
      
      <asp:Repeater ID="rptPages1" Runat="server">
      <HeaderTemplate>
      <table cellpadding="0" cellspacing="0" border="0">
      <tr>
       <td>
         <p class="tekst">Страница:
          </HeaderTemplate>
          <ItemTemplate>
            <asp:LinkButton ID="btnPage1"
                CommandName="Page"
                CommandArgument="<%#
                Container.DataItem %>"
                CssClass="text"
                Runat="server"><%# Container.DataItem %>
             </asp:LinkButton>
          </ItemTemplate>
         <FooterTemplate>
         </p>
       </td>
      </tr>
      </table>
      </FooterTemplate>
      </asp:Repeater>
     

      <hr width="100%" />


      <asp:Repeater ID="rptItems" runat="server">
      <HeaderTemplate>
      </HeaderTemplate>
      <ItemTemplate>
       <div>        
            <table width="50%" align="left" >
              <tr>
                <td>
                    <a class="menuLink" href='<%# "Slika.aspx?ID=" + Eval("ID") %>'> 
                        <asp:Image ID="Image1"  runat="server" align="center" border="1" hspace="5" 
                        ImageUrl='<%# "imgHandlerGallery.ashx?ID=" + Eval("ID") %>' Height="150" Width="95%"/>
                    </a>                 
                </td> 
              </tr>
              <tr>
                <td> 
                   <p class="jezik" style="font-style: italic; color: #008080;" align="center"><%# Eval("Opis").ToString()%></p>
                </td> 
              </tr>             
            </table>
                    
            <!--<p align="right" ><a class="menuLink" href='<%# "Slika.aspx?ID=" + Eval("ID") %>'> .... опширније >>></a></p>-->                                
        </div>
 
      </ItemTemplate>
      </asp:Repeater>

      
      <hr width="100%" />


      <asp:Repeater ID="rptPages2" Runat="server">
      <HeaderTemplate>
      <table cellpadding="0" cellspacing="0" border="0">
      <tr>
       <td>
         <p class="tekst">Страница:
          </HeaderTemplate>
          <ItemTemplate>
            <asp:LinkButton ID="btnPage2"
                CommandName="Page"
                CommandArgument="<%#
                Container.DataItem %>"
                CssClass="text"
                Runat="server"><%# Container.DataItem %>
             </asp:LinkButton>
          </ItemTemplate>
         <FooterTemplate>
         </p>
       </td>
      </tr>
      </table>
      </FooterTemplate>
      </asp:Repeater>   
      
 
 
    
</form>

</asp:Content>

