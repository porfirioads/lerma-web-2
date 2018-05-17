<%@ Page Title="" Language="C#" MasterPageFile="~/pages/esqueleto.Master"
    AutoEventWireup="true" CodeBehind="default.aspx.cs"
    Inherits="Cuenca_conagua.pages._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cuerpoContainer" runat="server">
    <p class="very-big-text">
        LERMA WEB 2
    </p>

    <p class="lerma-general-info">
        Información hidrológica y del uso del agua utilizando la política de
        distribución del agua superficial de la cuenca Lerma Chapala aprobada
        en el 2004
    </p>

    <br />
    <br />

    <p class="medium-text">
        Estados que comprenden la cuenca Lerma Chapala
    </p>

    <br />

    <table class="full-table blue-big-text table-no-border">
        <tr>
            <td>Edo. de México</td>
            <td>Michoacán</td>
            <td>Querétaro</td>
            <td>Guanajuato</td>
            <td>Jalisco</td>
        </tr>
    </table>

    <div class="align-right blue-text">
        <br />
        <br />
        <p>Administrado por:</p>
        <p>Universidad Autónoma de Zacatecas</p>
        <p>Dr. Ruperto Ortiz Gómez</p>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footerScripts" runat="server">
</asp:Content>
