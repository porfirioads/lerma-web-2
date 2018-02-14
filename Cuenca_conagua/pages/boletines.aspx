<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="boletines.aspx.cs" Inherits="Cuenca_conagua.pages.boletines" %>

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
                        <li><a href="boletines.aspx" class="active">Boletines</a></li>
                        <li><a href="historica.aspx">Histórica</a></li>
                        <li><a href="hidroclimatologica.aspx">Hidroclimatológica</a></li>
                        <li><a id="linkSubirDatos" runat="server" href="subir_datos.aspx">Subir datos</a></li>
                    </ul>
                </div>
            </div>
            <div id="cuerpo">
                <h4>Boletines</h4>
                <h4>VOLÚMENES MÁXIMOS DE EXTRACCIÓN DE AGUA SUPERFICIAL PARA  
                    LOS SISTEMAS DE USUARIOS DE LA CUENCA LERMA CHAPALA
                </h4>

                <table class="unformatted table-100 table-font-body">
                    <tr>
                        <td>
                            <a class="btn btn-white btn-100" 
                                href="../res/boletines/LermaBoletin01_1992.pdf">
                                Boletín 1: Noviembre 1991 – Octubre 1992
                            </a>
                        </td>
                        <td>
                            <a class="btn btn-white btn-100" 
                                href="../res/boletines/LermaBoletin14_2005.pdf">
                                Boletín 14: Noviembre 2004 – Octubre 2005
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a class="btn btn-white btn-100" 
                                href="../res/boletines/LermaBoletin02_1993.pdf">
                                Boletín 2: Noviembre 1992 – Octubre 1993
                            </a>
                        </td>
                        <td>
                            <a class="btn btn-white btn-100" 
                                href="../res/boletines/LermaBoletin15_2006.pdf">
                                Boletín 15: Noviembre 2005 – Octubre 2006
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a class="btn btn-white btn-100" 
                                href="../res/boletines/LermaBoletin03_1994.pdf">
                                Boletín 3: Noviembre 1993 – Octubre 1994
                            </a>
                        </td>
                        <td>
                            <a class="btn btn-white btn-100" 
                                href="../res/boletines/LermaBoletin16_2007.pdf">
                                Boletín 16: Noviembre 2006 – Octubre 2007
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a class="btn btn-white btn-100" 
                                href="../res/boletines/LermaBoletin04_1995.pdf">
                                Boletín 4: Noviembre 1994 – Octubre 1995
                            </a>
                        </td>
                        <td>
                            <a class="btn btn-white btn-100" 
                                href="../res/boletines/LermaBoletin17_2007.pdf">
                                Boletín 17: Noviembre 2007 – Octubre 2008
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a class="btn btn-white btn-100" 
                                href="../res/boletines/LermaBoletin05_1996.pdf">
                                Boletín 5: Noviembre 1995 – Octubre 1996
                            </a>
                        </td>
                        <td>
                            <a class="btn btn-white btn-100" 
                                href="../res/boletines/LermaBoletin18_2009.pdf">
                                Boletín 18: Noviembre 2008 – Octubre 2009
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a class="btn btn-white btn-100" 
                                href="../res/boletines/LermaBoletin06_1997.pdf">
                                Boletín 6: Noviembre 1996 – Octubre 1997
                            </a>
                        </td>
                        <td>
                            <a class="btn btn-white btn-100" 
                                href="../res/boletines/LermaBoletin19_2010.pdf">
                                Boletín 19: Noviembre 2009 – Octubre 2010
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a class="btn btn-white btn-100" 
                                href="../res/boletines/LermaBoletin07_1998.pdf">
                                Boletín 7: Noviembre 1997 – Octubre 1998
                            </a>
                        </td>
                        <td>
                            <a class="btn btn-white btn-100" 
                                href="../res/boletines/LermaBoletin20_2011.pdf">
                                Boletín 20: Noviembre 2010 – Octubre 2011
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a class="btn btn-white btn-100" 
                                href="../res/boletines/LermaBoletin08_1999.pdf">
                                Boletín 8: Noviembre 1998 – Octubre 1999
                            </a>
                        </td>
                        <td>
                            <a class="btn btn-white btn-100" 
                                href="../res/boletines/LermaBoletin21_2012.pdf">
                                Boletín 21: Noviembre 2011 – Octubre 2012
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a class="btn btn-white btn-100" 
                                href="../res/boletines/LermaBoletin09_2000.pdf">
                                Boletín 9: Noviembre 1999 – Octubre 2000
                            </a>
                        </td>
                        <td>
                            <a class="btn btn-white btn-100" 
                                href="../res/boletines/LermaBoletin22_2013.pdf">
                                Boletín 22: Noviembre 2012 – Octubre 2013
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a class="btn btn-white btn-100" 
                                href="../res/boletines/LermaBoletin10_2001.pdf">
                                Boletín 10: Noviembre 2000 – Octubre 2001
                            </a>
                        </td>
                        <td>
                            <a class="btn btn-white btn-100" 
                                href="../res/boletines/LermaBoletin23_2014.pdf">
                                Boletín 23: Noviembre 2013 – Octubre 2014
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a class="btn btn-white btn-100" 
                                href="../res/boletines/LermaBoletin11_2002.pdf">
                                Boletín 11: Noviembre 2001 – Octubre 2002
                            </a>
                        </td>
                        <td>
                            <a class="btn btn-white btn-100" 
                                href="../res/boletines/LermaBoletin24_2015.pdf">
                                Boletín 24: Noviembre 2014 – Octubre 2015
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a class="btn btn-white btn-100" 
                                href="../res/boletines/LermaBoletin12_2003.pdf">
                                Boletín 12: Noviembre 2002 – Octubre 2003
                            </a>
                        </td>
                        <td>
                            <a class="btn btn-white btn-100" 
                                href="../res/boletines/LermaBoletin25_2016.pdf">
                                Boletín 25: Noviembre 2015 – Octubre 2016
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a class="btn btn-white btn-100" 
                                href="../res/boletines/LermaBoletin13_2004.pdf">
                                Boletín 13: Noviembre 2003 – Octubre 2004
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
