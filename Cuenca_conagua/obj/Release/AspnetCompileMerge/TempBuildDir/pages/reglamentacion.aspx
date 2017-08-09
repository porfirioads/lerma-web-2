<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reglamentacion.aspx.cs" Inherits="Cuenca_conagua.pages.reglamentacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Boletines</title>
    <link rel="stylesheet" href="../css/combined.css" />
    <link rel="icon" type="image/ico" href="../res/icons/conagua.ico" />
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

                <div id="logotipo">
                    <img src="../res/images/semarnat.jpg" />
                </div>

                <div class="menu_principal">
                    <ul id="lista_menu" runat="server">
                        <li><a href="inicio.aspx">Inicio</a></li>
                        <li><a href="general.aspx">General</a></li>
                        <li><a href="reglamentacion.aspx" class="active">Reglamentación</a></li>
                        <li><a href="boletines.aspx">Boletines</a></li>
                        <li><a href="historica.aspx">Histórica</a></li>
                        <li><a href="hidroclimatologica.aspx">Hidroclimatológica</a></li>
                        <li><a id="linkSubirDatos" runat="server" href="subir_datos.aspx">Subir datos</a></li>
                    </ul>
                </div>
            </div>
            <div id="cuerpo">
                <h4>Documentos de reglamentación</h4>

                <table class="unformatted table-100 table-font-body">
                    <tr>
                        <td>
                            <a class="btn btn-white btn-100"
                                href="../res/docs_reglamentacion/1_acuerdo_1991.pdf">
                                <p>
                                    Acuerdo de Coordinación que celebran el 
                                    Ejecutivo Federal y los Ejecutivos de los 
                                    estados de Guanajuato, Jalisco, México, 
                                    Michoacán y Querétaro, para llevar a cabo 
                                    un programa de coordinación especial sobre 
                                    la disponibilidad, distribución y usos de 
                                    las aguas superficiales de propiedad 
                                    nacional de la cuenca Lerma-Chapala, 
                                    (Consejo de Cuenca, 1991).
                                </p>
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a class="btn btn-white btn-100"
                                href="../res/docs_reglamentacion/2_acuerdo_de_coordinación_2004.pdf">
                                <p>
                                    Acuerdo de Coordinación para la recuperación 
                                    y sustentabilidad de la cuenca 
                                    Lerma-Chapala, (SEMARNAT, 22 de marzo de 
                                    2004).
                                </p>
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a class="btn btn-white btn-100"
                                href="../res/docs_reglamentacion/3_convenio_2004.pdf">
                                <p>
                                    Convenio de Coordinación y Concertación que 
                                    celebran el Ejecutivo Federal y los 
                                    Ejecutivos de los estados de Guanajuato, 
                                    Jalisco, México, Michoacán y Querétaro, y 
                                    los representantes de los usuarios de los 
                                    Usos Público Urbano, Pecuario, Agrícola 
                                    Industrial, Acuícola y Servicios para llevar 
                                    a cabo el programa sobre la disponibilidad, 
                                    distribución y usos de las aguas 
                                    superficiales de propiedad nacional del área 
                                    geográfica Lerma-Chapala, (Consejo de 
                                    Cuenca, diciembre de 2004).
                                </p>
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a class="btn btn-white btn-100"
                                href="../res/docs_reglamentacion/4_decreto_2014.pdf">
                                <p>
                                    DECRETO por el que por causas de interés 
                                    público se suprimen las vedas existentes en 
                                    la subregión hidrológica Lerma-Chapala, y 
                                    se establece zona de veda en las 19 cuencas 
                                    hidrológicas que comprende dicha subregión 
                                    hidrológica, (DOF 8 de abril de 2014).
                                </p>
                            </a>
                        </td>
                    </tr>
                </table>
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
</html>
