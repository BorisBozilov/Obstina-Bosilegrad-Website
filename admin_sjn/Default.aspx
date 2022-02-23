<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 32%;
            height: 42px;
        }
        .style8
        {
            width: 32%;
            height: 25px;
            font-size: smaller;
        }
        .style16
        {
            width: 13%;
        }
        .style18
        {
            width: 79%;
            height: 18px;
        }
        .style23
        {
            width: 13%;
            height: 42px;
        }
        .GridViewStyle
        {
            text-align: left;
        }
        #filMyFile
        {
            width: 463px;
            margin-left: 0px;
        }
        .style24
        {
            width: 79%;
            height: 42px;
        }
        .style25
    {
        width: 32%;
        font-size: smaller;
    }
    .style26
    {
        width: 79%;
    }
        </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <form id="form1" runat="server">

<p class="naslov">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Административни панел за јавнe набавкe:</p>
    
 


   
    <table style="width:465px;" cellpadding="0" cellspacing="0">

    
              
       <tr>
            <td class="style8">
                    <b>ID набавке :</b></td>
            
            <td class="style18">
                    <asp:TextBox ID="txtID_Nabavke" runat="server" Width="167px" Font-Bold="True" 
                        Font-Names="Times New Roman" Font-Size="Medium" Height="25px"></asp:TextBox>
                </td>
 
        </tr>


        <tr>
            <td class="style8">
                    <b>&nbsp; ПИБ Наручиоца :</b></td>
            
            <td class="style18">
                    <asp:TextBox ID="txtPIB_Narucioca" runat="server" Width="169px" Font-Bold="True" 
                        Font-Names="Times New Roman" Font-Size="Medium" Height="25px"></asp:TextBox>
                </td>
 
        </tr>

        <tr>
            <td class="style8">
                    <b>&nbsp;Наручилац&nbsp;:</b></td>
            
            <td class="style18">
                    <asp:TextBox ID="txtNarucilac" runat="server" Width="465px" Font-Bold="True" 
                        Font-Names="Times New Roman" Font-Size="Medium" Height="25px"></asp:TextBox>
                </td>
 
        </tr>

       <tr>
            <td class="style8">
                    <strong>Назив набавке (поступка) :</strong></td>
            
            <td class="style18">
                    <asp:TextBox ID="txtNaziv_postupka" runat="server" Width="465px" Font-Bold="True" 
                        Font-Names="Times New Roman" Font-Size="Small" Height="59px" 
                        TextMode="MultiLine"></asp:TextBox>
            </td>
 
        </tr>
        <tr>
            <td class="style8">
                    <b>&nbsp;&nbsp; Врста постука &nbsp;:</b></td>
            
            <td class="style18">
                    <asp:TextBox ID="txtVrsta_postupka" runat="server" Width="465px" Font-Bold="True" 
                        Font-Names="Times New Roman" Font-Size="Small" Height="25px"></asp:TextBox>
            </td>
 
        </tr>   
        
        <tr>
            <td class="style8">
                    <b>&nbsp;&nbsp; Врста предмета&nbsp; :</b></td>
            
            <td class="style18">
                    <asp:TextBox ID="txtVrsta_predmeta" runat="server" Width="465px" Font-Bold="True" 
                        Font-Names="Times New Roman" Font-Size="Small" Height="25px"></asp:TextBox>
            </td>
 
        </tr>   
        
        <tr>
        <td class="style8">
                 <b>Процењена&nbsp; вредност &nbsp; :</b></td>
            
        <td class="style18">
                  <asp:TextBox ID="txtProcenjena_vrednost" runat="server" Width="150px" Font-Bold="True" 
                        Font-Names="Times New Roman" Font-Size="Medium" Height="25px"></asp:TextBox>
        </td>
        </tr>              
        
        <tr>
        <td class="style8">
                 <b>Датум&nbsp;&nbsp;&nbsp;&nbsp; објаве&nbsp; :</b></td>
            
        <td class="style18">
                  <asp:TextBox ID="txtDatum_objave" runat="server" Width="150px" Font-Bold="True" 
                        Font-Names="Times New Roman" Font-Size="Medium" Height="25px"></asp:TextBox>
        </td>
        </tr>    
                
       
        <tr>
        <td class="style8">
                 <b>Krajnji rok&nbsp; :</b></td>
            
        <td class="style18">
                  <asp:TextBox ID="txtRok_objave" runat="server" Width="150px" Font-Bold="True" 
                        Font-Names="Times New Roman" Font-Size="Medium" Height="25px"></asp:TextBox>
        </td>
        </tr>    
 
         <tr>
        <td class="style25">
                 <b>Статус</b><b style="top: 1px"> објаве :</b></td>
            
        <td class="style26">
                  <asp:TextBox ID="txtStatus_objave" runat="server" Width="150px" Font-Bold="True" 
                        Font-Names="Times New Roman" Font-Size="Medium" Height="25px"></asp:TextBox>
                  <br />
        </td>
        </tr>  
              
        <tr>
           <td class="style2">
                    &nbsp;Опис документа:</td>
            <td class="style24">
                    <asp:TextBox ID="txtOpis" runat="server" Width="500px" Height="39px" 
                        TextMode="MultiLine"></asp:TextBox>
                    </td>
         </tr>
        </table>
       
       <table style="width:578px; margin-right: 8px;" cellpadding="0" 
        cellspacing="0">
        <tr>
          
            <td >
                &nbsp;

                
                <div style="width: 572px">
                    <div style="clear: both; width: 100%">
                        <input id="filMyFile" type="file" runat="server" align="left" maxlength="60" 
                            size="60" />
                        <asp:Button ID="btnUpload" Text="Upload File" runat="server" 
                            onclick="btnUpload_Click" />
                    </div>
                    <div style="margin-top: 5px; clear: both">
                        <asp:GridView ID="gvFiles" CssClass="GridViewStyle"
                            AutoGenerateColumns="true" runat="server" DataKeyNames="ID" 
                            Font-Size="X-Small">
                            <FooterStyle CssClass="GridViewFooterStyle" />
                            <RowStyle CssClass="GridViewRowStyle" />    
                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                            <PagerStyle CssClass="GridViewPagerStyle" />
                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" runat="server"
                                            NavigateUrl='<%# Eval("ID", "GetFile.aspx?ID={0}") %>'
                                            Text="Download"></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                             </Columns>
                        </asp:GridView>
                        <asp:Label ID="lblID" runat="server" Text="Документ ID:"></asp:Label>
                &nbsp;<asp:TextBox ID="txtID" runat="server" Width="39px"></asp:TextBox>
                        <asp:Button ID="btnDelFile" runat="server" onclick="btnDelFile_Click" 
                            Text="Обриши документ" Width="134px" />
                    </div>
                </div>

                </td>
 
        </tr>



        <tr>
           
            <td align="center" class="style23">
     
           <asp:Button ID="btnPrvi" runat="server" Font-Bold="False" Font-Names="Arial" 
               style="text-align: left" Text="     I&lt;" Width="60px" 
               onclick="btnPrvi_Click" />
           
           <asp:Button ID="btnPredhodni" runat="server" Font-Bold="False" Font-Names="Arial" 
                Text="&lt;&lt;" Width="60px"
                onclick="btnPredhodni_Click" />
          
           <asp:Button ID="btnSledeci" runat="server" Text="&gt;&gt;" Width="60px" 
                onclick="btnSledeci_Click" />
     
           <asp:Button ID="btnZadnji" runat="server" Font-Names="Arial" Text="&gt;I" Width="60px" 
                onclick="btnZadnji_Click" />
     
            </td>
 
        </tr>
        <tr>
           
            <td align="center" height="50" class="style16">
                    
                <asp:Button ID="btnNovi" runat="server" BackColor="#66CCFF" Font-Size="X-Small" 
                   Height="26px" onclick="btnNovi_Click" Text="Нова набавка" Width="120px" />

  
               <asp:Button ID="btnIzmeni" runat="server" BackColor="#FFFF66" Font-Names="Arial" 
                   Text="Сачувај измене" Font-Size="X-Small" Height="26px" 
                    onclick="btnIzmeni_Click" Width="120px"  />

                 <asp:Button ID="btnObrisi" runat="server" BackColor="#FF3300" 
                   Font-Names="Arial"  Text="Обриши набавку" Font-Size="X-Small" Width="120px" 
                    Height="26px" onclick="btnObrisi_Click" />
                
                <asp:Button ID="btnLogout" runat="server" BackColor="#00FF00" Font-Size="X-Small" 
                   Height="26px" onclick="btnLogout_Click" Text="Одјави се" Width="120px" />

     
            </td>
                              
            </tr>

           <tr >
            <td colspan="2" bgcolor="#69c8ff" height="18" align="center">
            </td>
           </tr>
    </table>
</form>



</asp:Content>

