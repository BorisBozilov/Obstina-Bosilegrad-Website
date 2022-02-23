<%@ Page Title="" Language="C#" MasterPageFile="~/sr/MasterPage.master" AutoEventWireup="true" CodeFile="Mapa_sajta.aspx.cs" Inherits="sr_Mapa_Sajta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<form id="Form1" runat="server">

    <asp:TreeView ID="TreeView1" runat="server" 
    DataSourceID="SiteMapDataSource1" ImageSet="Arrows" ExpandDepth="3" 
        ForeColor="#003300">
        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="#003300" 
            HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
        <ParentNodeStyle Font-Bold="False" />
        <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" 
            HorizontalPadding="0px" VerticalPadding="0px" />
    </asp:TreeView>

    <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />

</form>

</asp:Content>
    
