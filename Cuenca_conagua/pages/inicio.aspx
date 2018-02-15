<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inicio.aspx.cs"
    Inherits="Cuenca_conagua.pages.inicio" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CONACUA Cuenca</title>
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
                        <li><a href="inicio.aspx" class="active">Inicio</a></li>
                        <li><a href="general.aspx">General</a></li>
                        <li><a href="reglamentacion.aspx">Reglamentación</a></li>
                        <li><a href="boletines.aspx">Boletines</a></li>
                        <li><a href="historica.aspx">Histórica</a></li>
                        <li><a href="hidroclimatologica.aspx">Hidroclimatológica</a></li>
                        <li><a id="linkSubirDatos" runat="server" href="subir_datos.aspx">Subir datos</a></li>
                    </ul>
                </div>
            </div>
            <div id="cuerpo">
                <h4>Información General de la Cuenca Lerma-Chapala</h4>
                    <p>
                        La cuenca Lerma-Chapala es una de las más importantes de México. La región
    se considera como un factor determinante en la dinámica socioeconómica del
    país, con valores superiores a la media nacional en densidad demográfica,
    producción industrial y agrícola per cápita, además de localizarse el vaso
    natural interior de mayores dimensiones del país y tercero en Latinoamérica:
    el lago de Chapala. Sin embargo, el desarrollo alcanzado ha traído consigo
    una problemática variada y compleja del sector hídrico, existiendo una
    fuerte competencia por el agua entre los diferentes sectores usuarios y
    entidades federativas.
                    </p>
                    <p>
                        El desequilibrio entre la oferta y la demanda del agua es producto del
    incremento sostenido de las extracciones principalmente de riego, el uso
    más importante en la región. En los años setenta, como resultado de un
    periodo húmedo favorable, se ampliaron las zonas de riego que, sin tener
    derecho al servicio, se convirtieron en demandantes del recurso. Esta
    situación fue propiciada y alentada por el impulso que se brindó en aquella
    época a la utilización de aguas excedentes. A la par con el crecimiento de
    las zonas de riego, no se previó una política de operación de la
    infraestructura hidráulica acorde con la situación y que fuera funcional
    tanto para épocas de abundancia como de escasez, CCES, 1991.
                    </p>
                    <p>
                        A finales de la década de los ochenta se agrava el problema debido a una
    disminución en la precipitación. Para dar respuesta a la problemática
    expuesta, el 13 de abril de 1989, los Ejecutivos Federal y de los estados
    de Guanajuato, Jalisco, México, Michoacán y Querétaro, firmaron un Acuerdo
    de Coordinación, a fin de llevar a cabo el programa de ordenamiento de los
    aprovechamientos hidráulicos y el saneamiento de la cuenca Lerma-Chapala.
    Para dar seguimiento y vigilar el cumplimiento del programa antes señalado,
    el 1 de septiembre de 1989, se constituyó un <strong>Consejo Consultivo
        dando origen al primer Consejo de Cuenca en México, el Lerma Chapala
    </strong>, del cual se han derivado experiencias importantes como la
    mitigación de los problemas entre usuarios agrícolas a través de un Acuerdo
    de Distribución de Aguas Superficiales firmado en 1991, y el avance en
    materia de saneamiento de aguas residuales municipales de la región Lerma y
    del lago de Chapala.
                    </p>
                    <p>
                        No obstante la aplicación del acuerdo de distribución firmado en 1991, un
    nuevo periodo de lluvias por debajo de la media, fue la causa principal del
    descenso de los niveles del lago de Chapala, reportándose en julio de 2002
    el almacenamiento más bajo registrado en los últimos 50 años. Esto
    incrementó la presión para formular nuevas reglas para la asignación del
    agua superficial con el fin de restablecer efectivamente el equilibrio de
    la cuenca y la recuperación del lago.
                    </p>
                    <p>
                        Para analizar de forma integral la problemática, proponer soluciones, se
    desarrollaron dos modelos complementarios: un modelo dinámico de simulación
    Lerma y un modelo de optimización Simop, utilizados para evaluar y explorar
    el efecto de diversas alternativas de solución para el manejo del agua ante
    posibles escenarios hidrológicos futuros, (IMTA, 2003).
                    </p>
                    <p>
                        En este proceso de búsqueda de alternativas que permitieran enfrentar los
    problemas de disponibilidad de agua, se han realizado varios esfuerzos,
    entre los que destaca el proceso de negociación de la distribución del agua
    superficial entre la Comisión Nacional del Agua (Conagua), los
    representantes de los usuarios y niveles de gobierno involucrados. Los
    análisis de alternativas se realizaron en el seno del Grupo de Ordenamiento
    y Distribución, GOD, integrado por especialistas representantes de Conagua,
    de cada uno de los estados que integran la cuenca así como de los
    diferentes usos del agua, a través de consensos.
                    </p>
                    <p>
                        Como resultado de los trabajos realizados, se elaboró un nuevo algoritmo
    consensuado para distribuir el agua superficial de la cuenca, el cual se
    utilizó para el nuevo convenio de distribución del agua superficial en la
    cuenca, denominado “Convenio de Coordinación y Concertación que celebraron
    los Estados de Guanajuato, Jalisco, México, Michoacán y Querétaro, así como
    los representantes de los usuarios de los usos público urbano, pecuario,
    agrícola, industrial, acuícola y servicios, para llevar a cabo el Programa
    sobre la Disponibilidad, Distribución y Usos de las Aguas Superficiales de
    Propiedad Nacional del Área Geográfica Lerma-Chapala”.El nuevo convenio de
    distribución del agua superficial se firmó el 14 de diciembre de 2004 y fue
    publicado en el diario Oficial de la Federación el 8 de abril de 2014 como
    Decreto de aplicación obligatoria.
                    </p>
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
