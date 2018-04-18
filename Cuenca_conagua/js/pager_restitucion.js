// Este script cambia el contenido de la página de restitución de 
// escurrimientos dependiendo de la subsección seleccionada

$(document).ready(function () {
    console.log('pager_restitucion');

    var contArchivosCalculo = $('#contArchivosCalculo');
    var contPresentacionCovi = $('#contPresentacionCovi');
    var btnArchivosCalculo = $('#btnArchivosCalculo');
    var btnPresentacionCovi = $('#btnPresentacionCovi');

    function hideAllSections() {
        $('.contenido').addClass('hidden');
    }

    btnArchivosCalculo.click(function () {
        hideAllSections();
        contArchivosCalculo.removeClass('hidden');
    });

    btnPresentacionCovi.click(function () {
        hideAllSections();
        contPresentacionCovi.removeClass('hidden');
    });
});