<%@ Page Title="" Language="C#" MasterPageFile="~/bg/MasterPage.master" AutoEventWireup="true" CodeFile="Javne_nabavke.aspx.cs" Inherits="bg_Javne_nabavke" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Configuration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<form id="Form1" runat="server">

<p class="naslov"> Обществени поръчки </p>


<asp:Repeater runat="server" id="RepNab" onItemDataBound="ShowDocuments">
<ItemTemplate>

<hr width="100%" />

<p class="nadnaslov">Број набавке: <%# ((DataRowView)Container.DataItem)["ID"]%> <p/> 
<p class="tekst"><strong>ПИБ наручиоца: </strong><%# ((DataRowView)Container.DataItem)["PIB"]%> <p/>
<p class="tekst"><strong>Наручилац: </strong><%# ((DataRowView)Container.DataItem)["Narucilac"]%> <p/> 
<p class="tekst"><strong>Назив поступка: </strong><%# ((DataRowView)Container.DataItem)["Naziv_postupka"] %> </p>
<p class="tekst"><strong>Врста поступка: </strong><%# ((DataRowView)Container.DataItem)["Vrsta_postupka"]%> </p>
<p class="tekst"><strong>Врста предмета: </strong><%# ((DataRowView)Container.DataItem)["Vrsta_predmeta"]%> </p>
<p class="tekst"><strong>Процењена вредност: </strong><%# ((DataRowView)Container.DataItem)["Procenjena_vrednost"]%> </p>
<p class="tekst"><strong>Датум објаве: </strong><%# ((DataRowView)Container.DataItem)["Datum_objave"]%>, 
 <strong>Рок објаве: </strong><%# ((DataRowView)Container.DataItem)["Rok_objave"]%>, 
 <strong>Статус набавке: </strong><%# ((DataRowView)Container.DataItem)["Status"]%>
</p>

<asp:Repeater id="RepDok" runat="server">
<HeaderTemplate>
<table border="1" bordercolor="#3d6d91">
  <tr>
    <td><p class="tekst"><strong>Опис</strong></td>
    <td><p class="tekst"><strong>Назив</strong></td>
    <td><p class="tekst"><strong>Тип</strong></td>
    <td><p class="tekst"><strong>Величина</strong></td>
    <td><p class="tekst"><strong>Преузимање</strong></td>
   </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
    <td><p class="malecki"><%# ((DataRowView)Container.DataItem)["Opis"]%><p/></td>
    <td><p class="malecki"><%# ((DataRowView)Container.DataItem)["Naziv"]%><p/></td>
    <td><p class="malecki"><%# ((DataRowView)Container.DataItem)["Tip"]%><p/></td>
    <td><p class="malecki"><%# ((DataRowView)Container.DataItem)["Velicina"]%><p/></td>
    <td align="center"><strong><p class="malecki"><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("ID", "GetFile.aspx?ID={0}") %>' Text=" Преузми "></asp:HyperLink></p></strong></td>
  </tr>
  
</ItemTemplate>
<FooterTemplate>
</table>
</br>
</FooterTemplate>
</asp:Repeater>
</ItemTemplate>
</asp:Repeater>

<hr width="100%" />



      
</form>
</asp:Content>

