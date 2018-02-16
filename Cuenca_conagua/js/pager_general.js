// Este script cambia el contenido de la página de información general,
// dependiendo de la sección seleccionada.

$(document).ready(function () {
    var almacenamientos = $('#almacenamientos');
    var corrientes = $('#corrientes');
    var localizacion = $('#localizacion');
    var regionalizacion = $('#regionalizacion');
    var usuarios = $('#usuarios');
    var cuencas = $('#cuencas');
    var sections = [almacenamientos, corrientes, localizacion,
        regionalizacion, usuarios, cuencas];

    // Oculta todas las secciones de información de la página de información
    // general.
    function hideAll() {
        for (var i = 0; i < sections.length; i++) {
            sections[i].addClass('hidden');
        }
    }

    // Se ejecuta cuando se presiona el botón de la localización.
    $('#btnGralLocalizacion').click(function () {
        hideAll();
        localizacion.removeClass('hidden');
    });

    // Se ejecuta cuando se presiona el botón de la regionalización.
    $('#btnGralRegionalizacion').click(function () {
        hideAll();
        regionalizacion.removeClass('hidden');
    });


    // Se ejecuta cuando se presiona el botón de las cuencas.
    $('#btnGralCuencas').click(function () {
        hideAll();
        cuencas.removeClass('hidden');
    });

    // Se ejecuta cuando se presiona el botón de las corrientes.
    $('#btnGralCorrPrin').click(function () {
        hideAll();
        corrientes.removeClass('hidden');
    });

    // Se ejecuta cuando se presiona el botón de los almacenamientos.
    $('#btnGralAlmPrin').click(function () {
        hideAll();
        almacenamientos.removeClass('hidden');
    });

    // Se ejecuta cuando se presiona el botón de los usuarios.
    $('#btnGralUsuAgSup').click(function () {
        hideAll();
        usuarios.removeClass('hidden');
    });
});