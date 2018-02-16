<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="general.aspx.cs" Inherits="Cuenca_conagua.pages.general" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>General</title>
    <link rel="stylesheet" href="../css/combined.css" />
    <link rel="icon" type="image/ico" href="../res/icons/conagua.ico" />
    <script src="../js/jquery-3.1.0.min.js"></script>
    <script src="../js/pager_general.js"></script>
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
                        <li><a href="general.aspx" class="active">General</a></li>
                        <li><a href="reglamentacion.aspx">Reglamentación</a></li>
                        <li><a href="boletines.aspx">Boletines</a></li>
                        <li><a href="historica.aspx">Histórica</a></li>
                        <li><a href="hidroclimatologica.aspx">Hidroclimatológica</a></li>
                        <li><a id="linkSubirDatos" runat="server" href="subir_datos.aspx">Subir datos</a></li>
                    </ul>
                </div>
            </div>
            <div id="cuerpo">
                <aside class="lateral" runat="server">
                    <h4>Información General</h4>
                    <a id="btnGralLocalizacion" class="btn btn-white">Localización</a>
                    <a id="btnGralRegionalizacion" class="btn btn-white">Regionalización</a>
                    <a id="btnGralCuencas" class="btn btn-white">Cuencas</a>
                    <a id="btnGralCorrPrin" class="btn btn-white">Corrientes Principales</a>
                    <a id="btnGralAlmPrin" class="btn btn-white">Almacenamientos Principales</a>
                    <a id="btnGralUsuAgSup" class="btn btn-white">Usuarios del Agua Superficial</a>
                </aside>

                <section id="localizacion" class="contenido" runat="server">
                    <h4>Localización de la cuenca Lerma-Chapala</h4>
                    <p>
                        La cuenca Lerma Chapala se encuentra en la parte centro del país,  está
                        limitada al norte y oeste por la cuenca del río Santiago, perteneciente a
                        la misma Región Hidrológica No. 12, al sur por la Región Hidrológica número
                        18, al este y noreste por la Región Hidrológica No. 26. Geográficamente
                        está comprendida entre los paralelos 19° 02´ 52´´ y 21° 34´ 10´´ de la
                        latitud norte y los meridianos 99° 17´ 48´´ y 103° 30´ 52´´ de longitud
                        oeste.
                    </p>
                    <figure>
                        <img class="img-max-100" src="../res/images/gral_localizacion.png" />
                        <figcaption>Localización de la zona hidrológica del río Lerma-Chapala
                        </figcaption>
                    </figure>
                </section>
                <section id="regionalizacion" class="contenido hidden" runat="server">
                    <h4>Regionalización de la Cuenca Lerma-Chapala</h4>
                    <p>
                        La cuenca comprende parcialmente los estados de Guanajuato, Jalisco,
    México, Michoacán y Querétaro, con una superficie total de 54,448.19 km²
    (DOF, 19-04-2010), considerando las cuencas cerradas de Pátzcuaro y
    Cuitzeo; la superficie de la cuenca principal o interconectada es de
    49,664.58 km².
                    </p>
                    <img class="img-max-100" src="../res/images/gral_regionalizacion_1.png" />
                    <p>
                        La cuenca se divide en 19 subcuencas, incluyendo las cuencas cerradas de
    Pátzcuaro y Cuitzeo.
                    </p>
                    <img class="img-max-100" src="../res/images/gral_regionalizacion_2.jpg" />
                    <h4>ZONA HIDROLÓGICA DEL RÍO LERMA-CHAPALA</h4>
                    <table>
                        <thead>
                            <tr>
                                <th colspan="2">CUENCAS</th>
                                <th colspan="5">PROYECCION: CÓNICA CONFORME DE LAMBERT (CCL)</th>
                            </tr>
                            <tr>
                                <th>Nombre oficial</th>
                                <th>Nombre común</th>
                                <th>Superficie oficial km<sup>2</sup></th>
                                <th>Superficie calculada  km<sup>2</sup></th>
                                <th>Perímetro km</th>
                                <th>Diferencia km<sup>2</sup></th>
                                <th>Diferencia en %</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Río La Laja 1</td>
                                <td>La Begoña</td>
                                <td>4,981.00</td>
                                <td>6,867.54</td>
                                <td>516.97</td>
                                <td>-1,886.54</td>
                                <td>-37.87</td>
                            </tr>
                            <tr>
                                <td>Río Turbio</td>
                                <td>Las Adjuntas</td>
                                <td>2,913.00</td>
                                <td>3,451.58</td>
                                <td>396.73</td>
                                <td>-538.58</td>
                                <td>-18.49</td>
                            </tr>
                            <tr>
                                <td>Río Lerma 5</td>
                                <td>Corrales</td>
                                <td>7,143.00</td>
                                <td>6,849.23</td>
                                <td>534.23</td>
                                <td>293.77</td>
                                <td>4.11</td>
                            </tr>
                            <tr>
                                <td>Río Querétaro</td>
                                <td>Ameche</td>
                                <td>2,255.00</td>
                                <td>2,355.60</td>
                                <td>288.42</td>
                                <td>-100.60</td>
                                <td>-4.46</td>
                            </tr>
                            <tr>
                                <td>Río Lerma 7</td>
                                <td>Chapala</td>
                                <td>6,644.00</td>
                                <td>6,306.15</td>
                                <td>568.82</td>
                                <td>337.85</td>
                                <td>5.09</td>
                            </tr>
                            <tr>
                                <td>Río La Laja 2</td>
                                <td>Pericos</td>
                                <td>2,415.00</td>
                                <td>2,600.10</td>
                                <td>353.99</td>
                                <td>-185.10</td>
                                <td>-7.66</td>
                            </tr>
                            <tr>
                                <td>Río Zula</td>
                                <td>Zula</td>
                                <td>2,098.00</td>
                                <td>2,125.36</td>
                                <td>278.63</td>
                                <td>-27.36</td>
                                <td>-1.30</td>
                            </tr>
                            <tr>
                                <td>Río Lerma 4</td>
                                <td>Salamanca</td>
                                <td>2,751.00</td>
                                <td>2,453.13</td>
                                <td>376.18</td>
                                <td>297.87</td>
                                <td>10.83</td>
                            </tr>
                            <tr>
                                <td>Río Lerma 6</td>
                                <td>Yurecuaro</td>
                                <td>2,023.00</td>
                                <td>2,034.62</td>
                                <td>257.50</td>
                                <td>-11.62</td>
                                <td>-0.57</td>
                            </tr>
                            <tr>
                                <td>Laguna de Yuriria</td>
                                <td>Yuriria</td>
                                <td>1,093.00</td>
                                <td>1,224.82</td>
                                <td>195.90</td>
                                <td>-131.82</td>
                                <td>-12.06</td>
                            </tr>
                            <tr>
                                <td>Río Lerma 3</td>
                                <td>Solís</td>
                                <td>2,895.00</td>
                                <td>2,982.48</td>
                                <td>368.34</td>
                                <td>-87.48</td>
                                <td>-3.02</td>
                            </tr>
                            <tr>
                                <td>Río Lerma 2</td>
                                <td>Tepuxtepec</td>
                                <td>2,623.00</td>
                                <td>2,597.03</td>
                                <td>392.24</td>
                                <td>25.97</td>
                                <td>0.99</td>
                            </tr>
                            <tr>
                                <td>Río Angulo</td>
                                <td>Angulo</td>
                                <td>2,064.00</td>
                                <td>2,046.71</td>
                                <td>280.09</td>
                                <td>17.29</td>
                                <td>0.84</td>
                            </tr>
                            <tr>
                                <td>Río Duero</td>
                                <td>Duero</td>
                                <td>2,198.00</td>
                                <td>2,803.16</td>
                                <td>270.70</td>
                                <td>-605.16</td>
                                <td>-27.53</td>
                            </tr>
                            <tr>
                                <td>Lago de Cuitzeo</td>
                                <td>Cuitzeo</td>
                                <td>3,675.00</td>
                                <td>3,865.73</td>
                                <td>325.85</td>
                                <td>-190.73</td>
                                <td>-5.19</td>
                            </tr>
                            <tr>
                                <td>Río Jaltepec</td>
                                <td>Tepetitlán</td>
                                <td>378.00</td>
                                <td>366.14</td>
                                <td>120.02</td>
                                <td>11.86</td>
                                <td>3.14</td>
                            </tr>
                            <tr>
                                <td>Lago de Pátzcuaro</td>
                                <td>Patzcuaro</td>
                                <td>1,096.00</td>
                                <td>917.88</td>
                                <td>153.76</td>
                                <td>178.12</td>
                                <td>16.25</td>
                            </tr>
                            <tr>
                                <td>Río Lerma 1</td>
                                <td>Alzate</td>
                                <td>2,137.00</td>
                                <td>2,076.55</td>
                                <td>252.53</td>
                                <td>60.45</td>
                                <td>2.83</td>
                            </tr>
                            <tr>
                                <td>Río La Gavia</td>
                                <td>Ramírez</td>
                                <td>505.00</td>
                                <td>524.38</td>
                                <td>116.02</td>
                                <td>-19.38</td>
                                <td>-3.84</td>
                            </tr>
                        </tbody>
                        <tfoot>
                            <tr>
                                <th></th>
                                <th></th>
                                <th>51,887.00</th>
                                <th>54,448.22</th>
                                <th></th>
                                <th></th>
                                <th></th>
                            </tr>
                        </tfoot>
                    </table>
                </section>
                <section id="cuencas" class="contenido" runat="server">
                    <h4>Cuencas</h4>
                    <a href="../res/images/cuenca_lc_con_nombres.png.png">
                        <img class="img-max-100" src="../res/images/cuenca_lc_con_nombres.png.png" />
                    </a>
                </section>
                <section id="corrientes" class="contenido hidden" runat="server">
                    <h4>CORRIENTES Y EMBALSES PRINCIPALES</h4>
                    <p>
                        El sistema hidrológico de esta zona está constituido por el río Lerma, que
                        es la corriente principal, de 708 kilómetros de longitud, con origen en la
                        Chignahuapan o laguna de Almoloya, al sureste de la ciudad de Toluca. En su
                        recorrido se integran como tributarios importantes los ríos La Gavia,
                        Jaltepec, Laja, Silao-Guanajuato, Turbio, Angulo y Duero, hasta descargar
                        al lago de Chapala, que es el vaso interior de mayores dimensiones del país
                        y en donde también descargan los ríos La Pasión y Zula.
                    </p>
                    <p>
                        El rio Lerma desemboca en el lago de Chapala, que es el más grande del
                        país, con una superficie de 1189 km2 y una capacidad máxima de 8125
                        millones de metros cúbicos.
                    </p>
                    <h4>Datos Hidrométricos</h4>
                    <p>
                        Los puntos de control se dividen en: ocho estaciones hidrométricas, siete 
                        presas, el lago de Chapala, la laguna de Yuriria.
                    </p>
                    <img class="img-max-100" src="../res/images/gral_corrientes.png" />
                </section>
                <section id="almacenamientos" class="contenido hidden" runat="server">
                    <h4>Almacenamientos Principales</h4>
                    <img class="img-max-100" src="../res/images/gral_almacenamientos.png" />
                </section>
                <section id="usuarios" class="contenido hidden" runat="server">
                    <h4>Usuarios del Agua Superficial</h4>
                    <p>
                        El principal uso del agua en la cuenca es el uso agrícola, que se conforma
    por ocho distritos de riego y una unidad de riego en cada una de las
    subcuencas en que se divide la cuenca a excepción de las subcuencas
    Yuriria y Salamanca, en donde no se cuenta con pequeña irrigación.
                    </p>
                    <p>
                        Un usuario más que se tiene en la cuenca es el agua potable de la ciudad de
    Guadalajara.
                    </p>
                    <img class="img-max-100" src="../res/images/gral_usuarios.png" />
                </section>
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
    <div id="finish" runat="server"></div>
</body>
</html>
