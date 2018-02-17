<%@ Page Title="Boletines" Language="C#" MasterPageFile="~/pages/esqueleto.Master" AutoEventWireup="true" CodeBehind="boletines.aspx.cs" Inherits="Cuenca_conagua.pages.boletines" %>

<asp:Content ID="contentHead" ContentPlaceHolderID="head" runat="server">
    <script src="../js/activate_boletines_tab.js"></script>
</asp:Content>

<asp:Content ID="contentCuerpoContainer" ContentPlaceHolderID="cuerpoContainer" runat="server">
    <h4>Boletines</h4>

    <h4>VOLÚMENES MÁXIMOS DE EXTRACCIÓN DE AGUA SUPERFICIAL PARA LOS SISTEMAS 
        DE USUARIOS DE LA CUENCA LERMA CHAPALA
    </h4>

    <table id="boletinesTable" class="unformatted table-100 table-font-body" runat="server">
    </table>
</asp:Content>
