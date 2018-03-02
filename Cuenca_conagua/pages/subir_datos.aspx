<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="subir_datos.aspx.cs" Inherits="Cuenca_conagua.pages.subir_datos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Subir información</title>
    <link rel="icon" type="image/ico" href="../res/icons/conagua.ico" />
    <link rel="stylesheet" href="../css/dropzone.css" />
    <link rel="stylesheet" href="../css/combined.css" />
    <script src="../js/jquery-3.1.0.min.js"></script>
    <script src="../js/dropzone.js"></script>
</head>
<body>
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
                    <li><a href="historica.aspx">Histórica</a></li>
                    <li><a href="hidroclimatologica.aspx">Hidroclimatológica</a></li>
                    <li><a href="subir_datos.aspx" class="active">Subir datos</a></li>
                </ul>
            </div>
        </div>
        <div id="cuerpo">
            <h1>Subir información</h1>
            <div id="divBienvenida" class="div-mensaje">
                Bienvenido <strong id="txtBienvenidaUsuario" runat="server"></strong>,
                ahora puedes subir la información que desees o bien, puedes
                <a class="link-page" runat="server" onserverclick="Logout">Cerrar sesión</a>.
            </div>

            <p id="txtBienvenido" runat="server"></p>

            <p><strong>Tipo de información:</strong></p>

            <select id="sel_tipo_archivo" class="form-control">
                <option value="Lluvia_media_anual">Precipitación media (Lluvia_media_anual.xlsx)</option>
                <option value="Escurrimiento_anual">Escurrimiento anual (Escurrimiento_anual.xlsx)</option>
                <option value="Volumenes_DR_PI">Volúmenes utilizados por DR y PI (Volumenes_DR_PI.xlsx)</option>
                <option value="Boletin">Boletín (*.pdf)</option>
                <option value="Reglamentación">Reglamentación (*.pdf)</option>
            </select>

            <br />

            <div id="uploadResult" class="div-mensaje hidden"></div>

            <div id="dropzone">
                <form id="fileUpload" runat="server" class="dropzone needsclick dz-clickable" action="subir_datos.aspx">
                    <asp:HiddenField ID="tipoArchivo" runat="server"></asp:HiddenField>

                    <div class="dz-message needsclick">
                        Arrastra los archivos aquí o haz click para subir
                    </div>

                    <script src="../js/upload_data.js"></script>
                </form>
            </div>
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
                            alt="Twitter conagua_mx" height="31" width="31" /></a>
                    <a href="http://www.conagua.gob.mx/Contenido.aspx?n1=7&amp;n2=81">
                        <img src="../res/images/rs.png" alt="RSS Conagua"
                            height="31"
                            width="31" />
                    </a>
                </div>
            </div>

            <div style="clear: both; width: 100%;">

                <div style="float: left; border-top: 1px solid #dedede; border-bottom: 1px solid #dedede; width: 353px; height: 1px; margin-top: 38px;">
                </div>
                <img src="../res/images/logoSEMARNAT_hoz.png"
                    style="float: left; margin: 0px 24px;" alt="SEMARNAT"
                    height="70" width="220" />
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
</body>
</html>
