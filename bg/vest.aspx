<%@ Page  Title="" Language="C#" MasterPageFile="~/bg/MasterPage.master" AutoEventWireup="true" CodeFile="vest.aspx.cs" Inherits="bg_vest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <form id="form1" runat="server">
   
   <asp:Repeater  ID="rptList" runat="server">
     
       
     <ItemTemplate>

       <div>
            <p class="nadnaslov"><%# Eval("Nadnaslov").ToString()%></p>
            <p class="naslov"><%# Eval("Naslov").ToString()%></p>
            

            <table width="100" align="left" >
              <tr>
                <td> 
                    <asp:Image ID="Image1"  runat="server" align="left" border="1" hspace="10" 
                    ImageUrl='<%# "imgHandler.ashx?ID=" + Eval("ID") %>' Height="200" />
                </td> 
              </tr>
              <tr>
                <td> 
                   <p class="jezik" style="font-style: italic; color: #008080;" align="center"><%# Eval("Opis").ToString()%></p>
                </td> 
              </tr>             
            </table>

            <p class="podnaslov"><%# Eval("Podnaslov").ToString()%></p>
            <p class="tekst"><%# Eval("Tekst").ToString()%></p>
           
                        
            <p align="right" ><a class="menuLink" href="javascript: history.go(-1)"> <<< назад ... </a></p>
                                
            <hr width="100%" />
   
        </div> 

     </ItemTemplate>
      
   </asp:Repeater>

</form>
</asp:Content>

