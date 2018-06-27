// Este script muestra/oculta las secciones de la página de información
// histórica de acuerdo al botón de la sección seleccionada.

$(document).ready(function () {
    var contPrecipitacionMedia = $('#contPrecipitacionMedia');
    var contLluviaAnualEstacion = $('#contLluviaAnualEstacion');
    var contEscurrimiento = $('#contEscurrimiento');
    var contVolumenes = $('#contVolumenes');
    var contAlmPrincipales = $('#contAlmPrincipales');
    var contAlmLagoChapala = $('#contAlmLagoChapala');
    var contAlmLagoChapala = $('#contAlmLagoChapala');
    var btnLluviaMediaAnual = $('#btnLluviaMediaAnual');
    var btnEscurrimiento = $('#btnEscurrimiento');
    var btnVolumenes = $('#btnVolumenes');
    var bntAlmPrincipales = $('#bntAlmPrincipales');
    var btnAlmLagoChapala = $('#btnAlmLagoChapala');
    var btnLluviaAnualEstacion = $('#btnLluviaAnualEstacion');
    var contenedores = [contPrecipitacionMedia, contEscurrimiento,
        contVolumenes, contAlmPrincipales, contAlmLagoChapala,
        contLluviaAnualEstacion, contAlmLagoChapala];
    var selTipoGraficaAlm = $('#selTipoGraficaAlm');
    var selCicloLae = $('#selCicloLae');
    var selTipoGraficaVol = $('#selTipoGraficaVol');

    // Visualiza el contenedor de la precipitacion media.
    btnLluviaMediaAnual.click(function () {
        var btnChangePrecAnual = $('#btnChangePrecAnual');
        hideAll();
        contPrecipitacionMedia.removeClass('hidden');
        btnChangePrecAnual.click();
    });

    // visualiza el contenedor de la lluvia anual por estación
    btnLluviaAnualEstacion.click(function () {
        hideAll();
        contLluviaAnualEstacion.removeClass('hidden');
        selCicloLae.trigger('change');
    });

    // Visualiza el contenedor del escurrimiento.
    btnEscurrimiento.click(function () {
        var selCicloEscu = $('#selCicloEscu');
        var chkEscAnual = $('#chkEscAnual');
        hideAll();
        $('#selCicloEscu option')[0].selected = true;
        contEscurrimiento.removeClass('hidden');
        chkEscAnual.prop('checked', true);
        chkEscAnual.prop('disabled', true);
        selCicloEscu.change();
    });

    // Visualiza el contenedor de los volumenes.
    btnVolumenes.click(function () {
        hideAll();
        contVolumenes.removeClass('hidden');
        selTipoGraficaVol.trigger('change');
    });

    // Visualiza el contenedor de los almacenamientos principales.
    bntAlmPrincipales.click(function () {
        hideAll();
        contAlmPrincipales.removeClass('hidden');
        selTipoGraficaAlm.trigger('change');
    });

    // Visualiza el contenedor del almacenamiento lago chapala.
    btnAlmLagoChapala.click(function () {
        hideAll();
        contAlmLagoChapala.removeClass('hidden');
    });

    // Oculta todos los contenedores
    function hideAll() {
        for (var i = 0; i < contenedores.length; i++) {
            contenedores[i].addClass('hidden');
        }
    }
});