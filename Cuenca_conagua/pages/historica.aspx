<%@ Page Title="Histórica" Language="C#" MasterPageFile="~/pages/esqueleto.Master" AutoEventWireup="true" CodeBehind="historica.aspx.cs" Inherits="Cuenca_conagua.pages.historica" %>

<asp:Content ID="contentHead" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../css/my_charts.css" />
    <script src="../js/activate_historica_tab.js"></script>
    <script src="../js/jquery-3.1.0.min.js"></script>
    <script src="../js/Chart.min.js"></script>
    <script src="../js/pager_historica.js"></script>
    <script src="../js/chart_general.js"></script>
    <script src="../js/chart_precipitacion_media.js"></script>
    <script src="../js/chart_escurrimiento_anual.js"></script>
    <script src="../js/chart_volumenes.js"></script>
    <script src="../js/chart_lluvia_anual_estacion.js"></script>
    <script src="../js/chart_almacenamientos_principales.js"></script>
</asp:Content>

<asp:Content ID="contentCuerpoContainer" ContentPlaceHolderID="cuerpoContainer" runat="server">
    <aside class="lateral" runat="server">
        <h4>Información Histórica</h4>
        <a id="btnLluviaMediaAnual" class="btn btn-white btn-100">Lluvia media anual registrada en la cuenca</a>
        <a id="btnLluviaAnualEstacion" class="btn btn-white btn-100">Lluvia anual por estación</a>
        <a id="btnEscurrimiento" class="btn btn-white btn-100">Escurrimiento generado por ciclo</a>
        <a id="btnVolumenes" class="btn btn-white btn-100">Resumen de volúmenes autorizados y utilizados</a>
        <a id="bntAlmPrincipales" class="btn btn-white btn-100">Almacenamientos principales</a>
        <a id="btnAlmLagoChapala" class="btn btn-white btn-100">Almacenamiento del lago de Chapala</a>
    </aside>
    <section id="contPrecipitacionMedia" class="contenido">
        <%-- Esta etiqueda div se va a sustituir por un script --%>
        <div id="scrPrecAnual" class="hidden" runat="server"></div>
        <script>
            $('#cuerpoContainer_scrPrecAnual').contents().unwrap().wrap('<script/>');
        </script>
        <section id="precMedia">
            <div id="precChart" class="chart-area">
                <div class="chart-content">
                    <canvas id="grafica_pma" class="chart" width="500" height="300"></canvas>
                </div>
            </div>
            <div id="divChkAnual" class="form-control">
                <input id="chkAnual" type="checkbox" />
                Mostrar precipitación media anual
            </div>
            <div id="divChkMensual" class="form-control hidden">
                <input id="chkMensual" type="checkbox" />
                Mostrar precipitación media mensual
            </div>
            <select id="selCiclo" class="form-control hidden">
            </select>
            <div>
                <a id="btnChangePrecMensual" class="btn btn-green">Precipitación Mensual
                </a>
                <a id="btnChangePrecAnual" class="btn btn-green hidden">Precipitación Anual
                </a>
            </div>
        </section>
    </section>

    <section id="contLluviaAnualEstacion" class="contenido hidden">
        <%-- Esta etiqueda div se va a sustituir por un script --%>
        <div id="srcLluviaAnualEstacion" class="hidden" runat="server"></div>
        <script>
            $('#cuerpoContainer_srcLluviaAnualEstacion').contents().unwrap().wrap('<script/>');
        </script>
        <section id="lluviaAnual">
            <div id="lluviaAnualChart" class="chart-area">
                <div class="chart-content">
                    <canvas id="grafica_lae" class="chart" width="500" height="300"></canvas>
                </div>
            </div>
            <select id="selCicloLae" class="form-control">
            </select>
        </section>
    </section>

    <section id="contEscurrimiento" class="contenido hidden">
        <%-- Esta etiqueda div se va a sustituir por un script --%>
        <div id="scrEscurrimiento" class="hidden" runat="server"></div>
        <script>
            $('#cuerpoContainer_scrEscurrimiento').contents().unwrap().wrap('<script/>');
        </script>
        <section id="escuAnual">
            <div id="escuChart" class="chart-area">
                <div class="chart-content">
                    <canvas id="grafica_ea" class="chart" width="500" height="300"></canvas>
                </div>
            </div>
            <select id="selCicloEscu" class="form-control">
                <option value="0">Selecciona una subcuenca</option>
            </select>
            <div id="divChkEscAnual" class="form-control">
                <input id="chkEscAnual" type="checkbox" />
                Mostrar Escurrimiento Anual
            </div>
        </section>
    </section>
    <section id="contVolumenes" class="contenido hidden">
        <%-- Esta etiqueda div se va a sustituir por un script --%>
        <div id="scrVolumenes" class="hidden" runat="server"></div>
        <script>
            $('#cuerpoContainer_scrVolumenes').contents().unwrap().wrap('<script/>');
        </script>
        <section id="volumenes">
            <div id="volumenesChart" class="chart-area">
                <div class="chart-content">
                    <canvas id="grafica_vol" class="chart" width="500" height="300"></canvas>
                </div>
            </div>
            <br />
            <table id="tablaResumen" class="table-100 table-padded">
                <tr>
                    <th id="resId" rowspan="2">DR</th>
                    <th rowspan="2">Vol. máx (hm<sup>3</sup>)</th>
                    <th colspan="4">Volumen promedio (hm<sup>3</sup>)</th>
                    <th rowspan="2">Vol. aut / Vol. máx %</th>
                    <th rowspan="2">Vol. uti / Vol. máx, % </th>
                </tr>
                <tr>
                    <th>Autorizado</th>
                    <th>Asignado</th>
                    <th>Utilizado</th>
                    <th>Excedido</th>
                </tr>
                <tr>
                    <td id="colId">1</td>
                    <td id="colVolMax">2</td>
                    <td id="colVolAut">3</td>
                    <td id="colVolAsi">4</td>
                    <td id="colVolUti">5</td>
                    <td id="colVolExc">6</td>
                    <td id="colVolAuM">7</td>
                    <td id="colVolUtM">8</td>
                </tr>
            </table>
            <select id="selDr" class="form-control">
            </select>
            <select id="selPi" class="form-control hidden">
            </select>
            <div>
                <a id="btnChangeVolPi" class="btn btn-green">Volúmenes Pequeña Irrigación
                </a>
                <a id="btnChangeVolDr" class="btn btn-green hidden">Volúmenes Distritos de Riego
                </a>
            </div>
        </section>
    </section>
    <section id="contAlmPrincipales" class="contenido hidden">
        <%-- Esta etiqueda div se va a sustituir por un script --%>
        <div id="srcAlmacenamientosPrincipales" class="hidden" runat="server"></div>
        <script>
            $('#cuerpoContainer_srcAlmacenamientosPrincipales').contents().unwrap().wrap('<script/>');
        </script>
        <section id="almacenamientos">
            <div id="almacenamientosChart" class="chart-area">
                <div class="chart-content">
                    <canvas id="grafica_alm" class="chart" width="500" height="300"></canvas>
                </div>
            </div>

            <select id="selTipoGraficaAlm" class="form-control">
                <option value="almAnio">
                    Almacenamiento al 1° de noviembre presas principales
                </option>
                <option value="almAnioPorc">
                    Porcentaje de almacenamiento al 1° de noviembre presas principales
                </option>
                <option value="almPresa">
                    Almacenamiento al 1° de noviembre para cada presa
                </option>
            </select>

            <select id="selAnioAlm" class="form-control">
            </select>

            <select id="selPresaAlm" class="form-control">
            </select>
        </section>
    </section>
    <section id="contAlmLagoChapala" class="contenido hidden" runat="server">
        AlmacenamientoLagoChapala
    </section>
</asp:Content>

<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="historica.aspx.cs" Inherits="Cuenca_conagua.pages.historica" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Información Histórica</title>
    <link rel="icon" type="image/ico" href="../res/icons/conagua.ico" />
    <link rel="stylesheet" href="../css/combined.css" />
    <link rel="stylesheet" href="../css/my_charts.css" />
    <script src="../js/jquery-3.1.0.min.js"></script>
    <script src="../js/Chart.min.js"></script>
    <script src="../js/pager_historica.js"></script>
    <script src="../js/chart_general.js"></script>
    <script src="../js/chart_precipitacion_media.js"></script>
    <script src="../js/chart_escurrimiento_anual.js"></script>
    <script src="../js/chart_volumenes.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="cuerpo_principal">
            <div id="encabezado">
                <div id="barra_herramientas">
                    <div id="herramientas">
                        <a href="http://www.conagua.gob.mx/"
                            target="_self">Inicio</a>
                        | <a href="http://portaltransparencia.gob.mx/pot/directorio/begin.do?method=begin&amp;_idDependencia=16101"
                            rel="external">Directorio</a> | <a
                                href="http://www.conagua.gob.mx/home.aspx"
                                target="_self">English</a> | <a
                                    href="http://www.conagua.gob.mx/Mapadelsitio.aspx"
                                    target="_self">Mapa de Sitio</a> | <a
                                        href="http://www.conagua.gob.mx/Contenido.aspx?n1=7&amp;n2=81"
                                        target="_self">RSS</a>
                    </div>
                </div>

                <table class="table-logo-header">
                    <tr>
                        <td class="header-image">
                            <img src="../res/images/semarnat.jpg" />
                        </td>
                        <td class="header-title">
                            <h1>LERMA WEB 2</h1>
                        </td>
                    </tr>
                </table>

                <div class="menu_principal">
                    <ul id="lista_menu" runat="server">
                        <li><a href="inicio.aspx">Inicio</a></li>
                        <li><a href="general.aspx">General</a></li>
                        <li><a href="reglamentacion.aspx">Reglamentación</a></li>
                        <li><a href="boletines.aspx">Boletines</a></li>
                        <li><a href="historica.aspx" class="active">Histórica</a></li>
                        <li><a href="hidroclimatologica.aspx">Hidroclimatológica</a></li>
                        <li><a id="linkSubirDatos" runat="server" href="subir_datos.aspx">Subir datos</a></li>
                    </ul>
                </div>
            </div>
            <div id="cuerpo">
            </div>
            <div class="footer">
                <div style="border-top: 1px solid #dedede; border-bottom: 1px solid #dedede; font-family: 'Times New Roman', serif; font-size: 14px; color: #666666; text-align: center; padding: 14px 0px;">
                    CONAGUA - ALGUNOS DERECHOS RESERVADOS © 2012 - <a
                        href="PoliticaPrivacidad.aspx">POLÍTICAS DE PRIVACIDAD</a>
                </div>
                <div style="clear: both; width: 100%; border-top: 1px solid #dedede; margin-top: 1px;"></div>

                <div style="clear: both; margin-top: 48px; margin-bottom: 0px;">
                    <div id="social" style="width: 242px; float: left; height: 34px;">
                        <a href="http://twitter.com/conagua_mx" rel="external">
                            <img
                                src="../res/images/tw.png" style="margin-right: 6px;"
                                alt="Twitter conagua_mx" height="31" width="31"></a>
                        <a href="http://www.conagua.gob.mx/Contenido.aspx?n1=7&amp;n2=81">
                            <img src="../res/images/rs.png" alt="RSS Conagua"
                                height="31"
                                width="31">
                        </a>
                    </div>
                </div>

                <div style="clear: both; width: 100%;">

                    <div style="float: left; border-top: 1px solid #dedede; border-bottom: 1px solid #dedede; width: 353px; height: 1px; margin-top: 38px;">
                    </div>
                    <img src="../res/images/logoSEMARNAT_hoz.png"
                        style="float: left; margin: 0px 24px;" alt="SEMARNAT"
                        height="70" width="220">
                    <div style="float: left; border-top: 1px solid #dedede; border-bottom: 1px solid #dedede; width: 353px; height: 1px; margin-top: 38px;">
                    </div>
                    <div style="clear: both; width: 100%;"></div>
                </div>

                <div style="margin: 32px auto 42px auto; text-align: center; font-family: 'Times New Roman', serif; font-weight: lighter; font-size: 13px;">
                    <p style="color: #808080; line-height: 7px;">
                        Av. Insurgentes Sur #
                2416, Col. Copilco el Bajo, Deleg. Coyoacán
                    </p>
                    <p style="color: #808080; line-height: 7px;">
                        Ciudad de México CP.
                04340, Tel. (55) 5174-4000
                    </p>
                    <p style="color: #808080; line-height: 7px;">
                        <a
                            href="http://www.conagua.gob.mx/ContactanosMail.aspx?Id=webmaster@conagua.gob.mx"
                            style="text-decoration: none; color: #808080;">Comentarios
                sobre este Sitio de Internet</a>
                    </p>
                </div>
                <div style="clear: both; width: 100%;"></div>

            </div>
        </div>
    </form>
</body>
</html>--%>
