<%@ Page Title="Minutas GOD" Language="C#" MasterPageFile="~/pages/esqueleto.Master" AutoEventWireup="true" CodeBehind="minutas.aspx.cs" Inherits="Cuenca_conagua.pages.minutas" %>

<asp:Content ID="contentHead" ContentPlaceHolderID="head" runat="server">
    <script src="../js/activate_minutas_tab.js"></script>
</asp:Content>

<asp:Content ID="contentCuerpoContainer" ContentPlaceHolderID="cuerpoContainer" runat="server">
    <h4>Minutas GOD</h4>

    <table id="minutasGodTable" runat="server"
        class="unformatted table-100 table-font-body">
    </table>
</asp:Content>
