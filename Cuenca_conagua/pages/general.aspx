<%@ Page Title="General" Language="C#" MasterPageFile="~/pages/esqueleto.Master" AutoEventWireup="true" CodeBehind="general.aspx.cs" Inherits="Cuenca_conagua.pages.general" %>

<asp:Content ID="contentHead" ContentPlaceHolderID="head" runat="server">
    <script src="../js/pager_general.js"></script>
    <script src="../js/activate_general_tab.js"></script>
    <script src="../js/jquery.rwdImageMaps.min.js"></script>
    <script src="../js/almacenamientosMap.js"></script>
</asp:Content>

<asp:Content ID="contentCuerpoContainer" ContentPlaceHolderID="cuerpoContainer" runat="server">
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
    <section id="cuencas" class="contenido hidden" runat="server">
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
        <img id="imgAlmacenamientos" 
            src="../res/images/gral_almacenamientos.png" width="1179" 
            height="628" usemap="#mapAlmacenamientos" alt/>

        <map name="mapAlmacenamientos" id="mapAlmacenamientos">
            <area shape="poly" coords="1036, 516, 1064, 482, 1095, 516" 
                title="Presa José Antonio Álzate" alt="alt" href="#" id="areaJAA"/>

            <area shape="poly" coords="997, 513, 1023, 478, 1042, 500, 1033, 511" 
                title="Presa Ignacio Ramírez" alt="alt" href="#" id="areaIR"/>

            <area shape="poly" coords="944, 479, 974, 439, 1003, 469" 
                title="Presa Tepetitlán" alt="alt" href="#" id="areaTepetitlan"/>

            <area shape="poly" coords="875, 377, 906, 346, 931, 376" 
                title="Presa Tepuxtepec" alt="alt" href="#" id="areaTepuxtepec"/>

            <area shape="poly" coords="760, 372, 788, 341, 817, 372" 
                title="Presa Solís" alt="alt" href="#" id="areaSolis"/>

            <area shape="poly" coords="706, 193, 734, 162, 762, 193" 
                title="Presa Ignacio Allende" alt="alt" href="#" id="areaIA"/>

            <area shape="poly" coords="644, 316, 673, 284, 701, 316" 
                title="Laguna de Yuriria" alt="alt" href="#" id="areaLDY"/>

            <area shape="poly" coords="488, 356, 498, 342, 506, 357" 
                title="Presa Melchor Ocampo" alt="alt" href="#" id="areaPMO"/>

            <area shape="poly" coords="112, 328, 139, 296, 169, 328" 
                title="Lago de Chapala" alt="alt" href="#" id="areaChapala"/>

            <area shape="poly" coords="802, 229, 802, 252, 828, 252, 828, 229" 
                title="Estación hidrométrica Ameche" alt="alt" href="#" id="areaEHA"/>

            <area shape="poly" coords="675, 238, 675, 261, 702, 238, 675, 238" 
                title="Estación hidrométrica Pericos" alt="alt" href="#" id="areaEHP"/>

            <area shape="poly" coords="634, 223, 661, 223, 661, 246, 634, 246" 
                title="Estación hidrométrica Salamanca" alt="alt" href="#" id="areaEHS"/>

            <area shape="poly" coords="455, 195, 482, 195, 482, 219, 455, 219" 
                title="Estación hidrométrica Adjuntas" alt="alt" href="#" id="areaEHAS"/>

            <area shape="poly" coords="479, 312, 507, 312, 507, 335, 479, 335" 
                title="Estación hidrométrica Corrales" alt="alt" href="#" id="areaEHC"/>

            <area shape="poly" coords="350, 278, 378, 278, 378, 302, 350, 302" 
                title="Estación hidrométrica Yurécuaro" alt="alt" href="#" id="areaEHY"/>

            <area shape="poly" coords="" 
                title="Estación hidrométrica Estanzuela" alt="alt" href="#" id="areaEHE"/>

            <area shape="poly" coords="" 
                title="Estación hidrométrica Zula" alt="alt" href="#" id="areaEHZ"/>
        </map>

        <div id="areaJAAInfo" class="containerAlmacenamientos hidden">
            <table class="full-table">
                <tr>
                    <th colspan="2">
                        Presa José Antonio Álzate
                    </th>
                </tr>
                <tr>
                    <td>
                        <strong>Corriente:</strong> Río Lerma
                        <br />
                        <strong>Estado:</strong> Edo. De México
                        <br />
                        <strong>Uso principal:</strong> Irrigación y control de avenidas
                        <br />
                        <strong>Clave BANDAS:</strong> 210JAA
                    </td>
                    <td>
                        <strong>Elevaciones:</strong>
                        <br />
                        NAME: 2566.92 msnm
                        <br />
                        NAMO: 2565.56 msnm
                        <br />
                        <strong>Volumen:</strong>
                        <br />
                        NAME: 52.5 hm<sup>3</sup>
                        <br />
                        NAMO: 35.9 hm<sup>3</sup>
                    </td>
                </tr>
            </table>
        </div>

        <div id="areaIRInfo" class="containerAlmacenamientos hidden">
            <table class="full-table">
                <tr>
                    <th colspan="2">
                        Presa Ignacio Ramírez
                    </th>
                </tr>
                <tr>
                    <td>
                        <strong>Corriente:</strong> Río La Gavia
                        <br />
                        <strong>Estado:</strong> Edo. De México
                        <br />
                        <strong>Uso principal:</strong> Irrigación y control de avenidas
                        <br />
                        <strong>Clave BANDAS:</strong> 195IRA
                    </td>
                    <td>
                        <strong>Elevaciones:</strong>
                        <br />
                        NAME: 2550.48 msnm
                        <br />
                        NAMO: 2548.4 msnm
                        <br />
                        <strong>Volumen:</strong>
                        <br />
                        NAME: 36.3 hm<sup>3</sup>
                        <br />
                        NAMO: 20.5 hm<sup>3</sup>
                    </td>
                </tr>
            </table>
        </div>

        <div id="areaTepetitlanInfo" class="containerAlmacenamientos hidden">
            <table class="full-table">
                <tr>
                    <th colspan="2">
                        Presa Tepetitlán
                    </th>
                </tr>
                <tr>
                    <td>
                        <strong>Corriente:</strong> Río Jaltepec
                        <br />
                        <strong>Estado:</strong> Edo. De México
                        <br />
                        <strong>Uso principal:</strong> Irrigación y control de avenidas
                        <br />
                        <strong>Clave BANDAS:</strong> 435TPN
                    </td>
                    <td>
                        <strong>Elevaciones:</strong>
                        <br />
                        NAME: 2594.46 msnm
                        <br />
                        NAMO: 2592.02 msnm
                        <br />
                        <strong>Volumen:</strong>
                        <br />
                        NAME: 92.1 hm<sup>3</sup>
                        <br />
                        NAMO: 57.62 hm<sup>3</sup>
                    </td>
                </tr>
            </table>
        </div>

        <div id="areaTepuxtepecInfo" class="containerAlmacenamientos hidden">
            <table class="full-table">
                <tr>
                    <th colspan="2">
                        Presa Tepuxtepec
                    </th>
                </tr>
                <tr>
                    <td>
                        <strong>Corriente:</strong> Río Lerma
                        <br />
                        <strong>Estado:</strong> Michoacán
                        <br />
                        <strong>Uso principal:</strong> Irrigación, Generación hidroeléctrica y control de avenidas
                        <br />
                        <strong>Clave BANDAS:</strong> 440TPX
                    </td>
                    <td>
                        <strong>Elevaciones:</strong>
                        <br />
                        NAME: 2350 msnm
                        <br />
                        NAMO: 2346.54 msnm
                        <br />
                        <strong>Volumen:</strong>
                        <br />
                        NAME: 537.7 hm<sup>3</sup>
                        <br />
                        NAMO: 425 hm<sup>3</sup>
                    </td>
                </tr>
            </table>
        </div>

        <div id="areaSolisInfo" class="containerAlmacenamientos hidden">
            <table class="full-table">
                <tr>
                    <th colspan="2">
                        Presa Solís
                    </th>
                </tr>
                <tr>
                    <td>
                        <strong>Corriente:</strong> Río Lerma
                        <br />
                        <strong>Estado:</strong> Guanajuato
                        <br />
                        <strong>Uso principal:</strong> Irrigación y control de avenidas
                        <br />
                        <strong>Clave BANDAS:</strong> 410SOL
                    </td>
                    <td>
                        <strong>Elevaciones:</strong>
                        <br />
                        NAME: 1898.7 msnm
                        <br />
                        NAMO: 1892.93 msnm
                        <br />
                        <strong>Volumen:</strong>
                        <br />
                        NAME: 1071.02 hm<sup>3</sup>
                        <br />
                        NAMO: 728.28 hm<sup>3</sup>
                    </td>
                </tr>
            </table>
        </div>

        <div id="areaIAInfo" class="containerAlmacenamientos hidden">
            <table class="full-table">
                <tr>
                    <th colspan="2">
                        Presa Ignacio Allende
                    </th>
                </tr>
                <tr>
                    <td>
                        <strong>Corriente:</strong> Río La Laja
                        <br />
                        <strong>Estado:</strong> Guanajuato
                        <br />
                        <strong>Uso principal:</strong> Irrigación y control de avenidas
                        <br />
                        <strong>Clave BANDAS:</strong> 410SOL
                        <br />
                        <strong>Batimetría:</strong> autorizada en 2017
                    </td>
                    <td>
                        <strong>Elevaciones:</strong>
                        <br />
                        NAME: 1832.65 msnm
                        <br />
                        NAMO: 1828.75 msnm
                        <br />
                        <strong>Volumen:</strong>
                        <br />
                        NAME: 221.69 hm<sup>3</sup>
                        <br />
                        NAMO: 125.115 hm<sup>3</sup>
                    </td>
                </tr>
            </table>
        </div>

        <div id="areaLDYInfo" class="containerAlmacenamientos hidden">
            <table class="full-table">
                <tr>
                    <th colspan="2">
                        Laguna de Yuriria
                    </th>
                </tr>
                <tr>
                    <td>
                        <strong>Corriente:</strong> Río Lerma
                        <br />
                        <strong>Estado:</strong> Guanajuato
                        <br />
                        <strong>Uso principal:</strong> Irrigación y control de avenidas
                        <br />
                        <strong>Clave BANDAS:</strong> 270LYU
                    </td>
                    <td>
                        <strong>Elevaciones:</strong>
                        <br />
                        NAME: 1731.4 msnm
                        <br />
                        NAMO: msnm
                        <br />
                        <strong>Volumen:</strong>
                        <br />
                        NAME: 325.20 hm<sup>3</sup>
                        <br />
                        NAMO: 188.0 hm<sup>3</sup>
                    </td>
                </tr>
            </table>
        </div>

        <div id="areaPMOInfo" class="containerAlmacenamientos hidden">
            <table class="full-table">
                <tr>
                    <th colspan="2">
                        Presa Melchor Ocampo
                    </th>
                </tr>
                <tr>
                    <td>
                        <strong>Corriente:</strong> Río Angulo
                        <br />
                        <strong>Estado:</strong> Michoacán
                        <br />
                        <strong>Uso principal:</strong> Irrigación y control de avenidas
                        <br />
                        <strong>Clave BANDAS:</strong> 322MOC
                    </td>
                    <td>
                        <strong>Elevaciones:</strong>
                        <br />
                        NAME: 1714.41 msnm
                        <br />
                        NAMO: 1711.9 msnm
                        <br />
                        <strong>Volumen:</strong>
                        <br />
                        NAME: 253 hm<sup>3</sup>
                        <br />
                        NAMO: 200 hm<sup>3</sup>
                    </td>
                </tr>
            </table>
        </div>

        <div id="areaChapalaInfo" class="containerAlmacenamientos hidden">
            <table class="full-table">
                <tr>
                    <th colspan="2">
                        Lago de Chapala 
                    </th>
                </tr>
                <tr>
                    <td>
                        <strong>Corriente:</strong> Río Lerma
                        <br />
                        <strong>Estado:</strong> Jalisco
                        <br />
                        <strong>Uso principal:</strong> Irrigación y agua potable
                        <br />
                        <strong>Clave BANDAS:</strong> 245LCH
                    </td>
                    <td>
                        <strong>Elevaciones:</strong>
                        <br />
                        NAME: msnm
                        <br />
                        NAMO: 1524.04 msnm
                        <br />
                        <strong>Volumen:</strong>
                        <br />
                        NAME: hm<sup>3</sup>
                        <br />
                        NAMO: 8124.9 hm<sup>3</sup>
                    </td>
                </tr>
            </table>
        </div>

        <div id="areaEHAInfo" class="containerAlmacenamientos hidden">
            <table class="full-table">
                <tr>
                    <th colspan="2">
                        Estación hidrométrica Ameche 
                    </th>
                </tr>
                <tr>
                    <td>
                        <strong>Corriente:</strong> Río Querétaro
                        <br />
                        <strong>Estado:</strong> Guanajuato
                        <br />
                        <strong>Clave BANDAS:</strong> 12718
                    </td>
                </tr>
            </table>
        </div>

        <div id="areaEHPInfo" class="containerAlmacenamientos hidden">
            <table class="full-table">
                <tr>
                    <th colspan="2">
                        Estación hidrométrica Pericos
                    </th>
                </tr>
                <tr>
                    <td>
                        <strong>Corriente:</strong> Río Querétaro
                        <br />
                        <strong>Estado:</strong> Guanajuato
                        <br />
                        <strong>Clave BANDAS:</strong> 12238
                    </td>
                </tr>
            </table>
        </div>
        
        <div id="areaEHSInfo" class="containerAlmacenamientos hidden">
            <table class="full-table">
                <tr>
                    <th colspan="2">
                        Estación hidrométrica Salamanca
                    </th>
                </tr>
                <tr>
                    <td>
                        <strong>Corriente:</strong> Río Lerma
                        <br />
                        <strong>Estado:</strong> Guanajuato
                        <br />
                        <strong>Clave BANDAS:</strong> 12352
                    </td>
                </tr>
            </table>
        </div>

        <div id="areaEHASInfo" class="containerAlmacenamientos hidden">
            <table class="full-table">
                <tr>
                    <th colspan="2">
                        Estación hidrométrica Adjuntas
                    </th>
                </tr>
                <tr>
                    <td>
                        <strong>Corriente:</strong> Río Turbio
                        <br />
                        <strong>Estado:</strong> Guanajuato
                        <br />
                        <strong>Clave BANDAS:</strong> 12391
                    </td>
                </tr>
            </table>
        </div>

        <div id="areaEHCInfo" class="containerAlmacenamientos hidden">
            <table class="full-table">
                <tr>
                    <th colspan="2">
                        Estación hidrométrica Corrales
                    </th>
                </tr>
                <tr>
                    <td>
                        <strong>Corriente:</strong> Río Lerma
                        <br />
                        <strong>Estado:</strong> Michoacán
                        <br />
                        <strong>Clave BANDAS:</strong> 12233
                    </td>
                </tr>
            </table>
        </div>

        <div id="areaEHYInfo" class="containerAlmacenamientos hidden">
            <table class="full-table">
                <tr>
                    <th colspan="2">
                        Estación hidrométrica Yurécuaro
                    </th>
                </tr>
                <tr>
                    <td>
                        <strong>Corriente:</strong> Río Lerma
                        <br />
                        <strong>Estado:</strong> Michoacán
                        <br />
                        <strong>Clave BANDAS:</strong> 12526
                    </td>
                </tr>
            </table>
        </div>

        <div id="areaEHEInfo" class="containerAlmacenamientos hidden">
            <table class="full-table">
                <tr>
                    <th colspan="2">
                        Estación hidrométrica Estanzuela
                    </th>
                </tr>
                <tr>
                    <td>
                        <strong>Corriente:</strong> Río Duero
                        <br />
                        <strong>Estado:</strong> Michoacán
                        <br />
                        <strong>Clave BANDAS:</strong> 12310
                    </td>
                </tr>
            </table>
        </div>

        <div id="areaEHZInfo" class="containerAlmacenamientos hidden">
            <table class="full-table">
                <tr>
                    <th colspan="2">
                        Estación hidrométrica Zula
                    </th>
                </tr>
                <tr>
                    <td>
                        <strong>Corriente:</strong> Río Ocotlán
                        <br />
                        <strong>Estado:</strong> Jalisco
                        <br />
                        <strong>Clave BANDAS:</strong> 12937
                    </td>
                </tr>
            </table>
        </div>
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

        <img id="imgUsuarios" 
            src="../res/images/gral_usuarios.png" width="1163" 
            height="653" usemap="#mapUsuarios" alt/>

        <map name="mapUsuarios" id="mapUsuarios">
            <area shape="poly" coords="736, 323, 849, 321, 849, 366, 736, 366" 
                title="Distrito de Riego 011" alt="alt" 
                href="../uploaded_files/usuarios_agua_superficial/DR 011.pdf"
                target="_blank"
                id="areaDR011"/>

            <area shape="poly" coords="168, 279, 281, 279, 281, 323, 168, 323" 
                title="Distrito de Riego 013" alt="alt" 
                href="../uploaded_files/usuarios_agua_superficial/DR 013.pdf"
                target="_blank"
                id="areaDR013"/>

            <area shape="poly" coords="142, 420, 255, 420, 255, 466, 142, 466" 
                title="Distrito de Riego 024" alt="alt" 
                href="../uploaded_files/usuarios_agua_superficial/DR 024.pdf" 
                target="_blank"
                id="areaDR024"/>

            <area shape="poly" coords="972, 374, 1081, 374, 1081, 417, 972, 417" 
                title="Distrito de Riego 033" alt="alt" 
                href="../uploaded_files/usuarios_agua_superficial/DR 033.pdf"
                target="_blank"
                id="areaDR033"/>

            <area shape="poly" coords="798, 491, 911, 491, 911, 534, 798, 534" 
                title="Distrito de Riego 045" alt="alt" 
                href="../uploaded_files/usuarios_agua_superficial/DR 045.pdf"
                target="_blank"
                id="areaDR045"/>

            <area shape="poly" coords="330, 439, 446, 439, 446, 482, 330, 482" 
                title="Distrito de Riego 061" alt="alt" 
                href="../uploaded_files/usuarios_agua_superficial/DR 061.pdf"
                target="_blank"
                id="areaDR061"/>

            <area shape="poly" coords="713, 183, 827, 183, 827, 228, 713, 226" 
                title="Distrito de Riego 085" alt="alt" 
                href="../uploaded_files/usuarios_agua_superficial/DR 085.pdf"
                target="_blank"
                id="areaDR085"/>

            <area shape="poly" coords="387, 279, 499, 279, 500, 323, 387, 323" 
                title="Distrito de Riego 087" alt="alt" 
                href="../uploaded_files/usuarios_agua_superficial/DR 087.pdf"
                target="_blank"
                id="areaDR087"/>
        </map>

        <a class="btn btn-green"
            href="../uploaded_files/usuarios_agua_superficial/RESUMEN TITULOS DE CONCESION_DR.xls">
            Resumen Títulos de Concesión
        </a>
    </section>
</asp:Content>

<asp:Content ID="contentFooterScripts" ContentPlaceHolderID="footerScripts" runat="server">
</asp:Content>
