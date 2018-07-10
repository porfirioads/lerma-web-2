/*
Este script maneja las cajas de información mostradas al pasar el mouse
encima de las áreas encontradas sobre el mapa de almacenamientos principales,
en la pestaña "General".
*/

$(document).ready(function () {
    // Determina si la caja se seguirá mostrando aún después de que el mouse
    // ya no esté en el área
    var fixedInfo = false;

    /*
    Accede a cada elemento area dentro del mapa para asignarle listeners a
    diferentes eventos
    */
    $('#mapAlmacenamientos area').each(function () {
        /*
        Muestra la caja de información correspondiente al pasar el mouse sobre
        una área dentro del mapa
        */
        $(this).mouseover(function (e) {
            fixedInfo = false;
            hideAllContainters();
            var areaId = $(this).attr('id');
            $('#' + areaId + 'Info').removeClass('hidden');
        });

        /*
        Oculta la caja de información actualmente mostrada cuando el mouse sale
        dentro del área en el mapa
        */
        $(this).mouseout(function (e) {
            if (!fixedInfo) {
                hideAllContainters();
            }
        });

        /*
        Fija la caja de información cuando se hace click sobre el área en el
        mapa para que no se oculte aún cuando el mouse sale del área
        */
        $(this).click(function (e) {
            fixedInfo = true;
        })
    });

    function hideAllContainters() {
        $('.containerAlmacenamientos').addClass('hidden');
    }
});