<%@ Page Title="" Language="C#" MasterPageFile="~/bg/MasterPage.master" AutoEventWireup="true" CodeFile="PagedRepeater.aspx.cs" Inherits="bg_PagedRepeater" %>

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
            <p class="nadnaslov"><%# Eval("Nadnaslov").ToString()%></p>
            <p class="naslov"><%# Eval("Naslov").ToString()%></p>
            

            <table width="50" align="left" >
              <tr>
                <td> 
                    <asp:Image ID="Image1"  runat="server" align="left" border="1" hspace="10" 
                    ImageUrl='<%# "imgHandler.ashx?ID=" + Eval("ID") %>' Height="100" />
                </td> 
              </tr>
              <tr>
                <td> 
                   <p class="jezik" style="font-style: italic; color: #008080;" align="center"><%# Eval("Opis").ToString()%></p>
                </td> 
              </tr>             
            </table>

            <p class="podnaslov"><%# Eval("Podnaslov").ToString()%></p>
            
            <p align="right" ><a class="menuLink" href='<%# "vest.aspx?ID=" + Eval("ID") %>'>целият текст ...</a></p>
                      
            <br />
            <hr width="100%" />
      
        </div>
 
      </ItemTemplate>
      </asp:Repeater>
      


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

