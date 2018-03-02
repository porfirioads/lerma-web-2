<%@ Page Title="Reglamentación" Language="C#" MasterPageFile="~/pages/esqueleto.Master" AutoEventWireup="true" CodeBehind="reglamentacion.aspx.cs" Inherits="Cuenca_conagua.pages.reglamentacion" %>

<asp:Content ID="contentHead" ContentPlaceHolderID="head" runat="server">
    <script src="../js/activate_reglamentacion_tab.js"></script>
</asp:Content>

<asp:Content ID="contentCuerpoContainer" ContentPlaceHolderID="cuerpoContainer" runat="server">
    <h4>Documentos de reglamentación</h4>

    <table id="reglamentacionTable" runat="server"
        class="unformatted table-100 table-font-body">
    </table>
</asp:Content>
