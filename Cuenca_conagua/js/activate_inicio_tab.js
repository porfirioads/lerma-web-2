// Este script resalta el color de la pestaña inicio cuando se activa

function activateInicioTab() {
    //console.log('activateInicioTab');
    $('#menuInicio').addClass('active');
}

$(document).ready(function () {
    activateInicioTab();
});
