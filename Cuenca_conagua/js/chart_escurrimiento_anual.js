// Este script maneja las gráficas del escurrimiento anual.

$(document).ready(function () {
    var grafica_ea = $('#grafica_ea');
    var selCicloEscu = $('#selCicloEscu');
    var chkEscAnual = $('#chkEscAnual');
    var chart;
    var escuAnualValues;
    var escuSubcuencaValues;
    var subcuencasLabels = ['Alzate', 'Ramirez', 'Tepetitlan', 'Tepuxtepec',
        'Solis', 'Begoña', 'Ameche', 'Pericos', 'Yuriria', 'Salamanca',
        'Adjuntas', 'Angulo', 'Corrales', 'Yurecuaro', 'Duero', 'Zula',
        'Chapala'];
    var subcuencasAtributes = ['alzate', 'ramirez', 'tepetitlan', 'tepuxtepec',
        'solis', 'begona', 'ameche', 'pericos', 'yuriria', 'salamanca',
        'adjuntas', 'angulo', 'corrales', 'yurecuaro', 'duero', 'zula',
        'chapala'];
    var ciclosLabels;
    var context = $('#grafica_ea').get(0).getContext('2d');

    // Realiza la configuracion inicial para la creacion de las graficas
    // del escurrimiento anual.
    function start() {
        escuAnualValues = [];
        ciclosLabels = [];
        refreshEscuSubcuencaValues();
        for (var i = 0; i < regEscurrimiento.length; i++) {
            escuAnualValues.push(regEscurrimiento[i].total);
            ciclosLabels.push(regEscurrimiento[i].ciclo);
        }
        for (var i = 0; i < subcuencasLabels.length; i++) {
            selCicloEscu.append('<option value="' + (i + 1) + '">'
                + subcuencasLabels[i] + '</option>');
        }
    }

    // Se ejecuta cuando se selecciona algun ciclo de la lista.
    selCicloEscu.change(function () {
        var index = selCicloEscu.val();
        if (index == 0) {
            chkEscAnual.prop('disabled', true);
        } else {
            chkEscAnual.prop('disabled', false);
        }
        //chkEscAnual.prop('checked');
        var anual = chkEscAnual.prop('disabled') || chkEscAnual.prop('checked');
        var subcuenca = index > 0;
        crearGraficaEscurrimientoAnual(anual, subcuenca);
    });

    // Se ejecuta cuando se activa o desactiva el checkbox del escurrimiento 
    // anual.
    chkEscAnual.change(function () {
        selCicloEscu.change();
    });

    // Limpia el canvas.
    function clearCanvas() {
        if (chart != undefined) {
            chart.destroy();
        }
    }

    // Actualiza los valores del escurrimiento para la subcuenca seleccionada.
    function refreshEscuSubcuencaValues() {
        escuSubcuencaValues = [];
        var index = selCicloEscu.val();
        if (index > 0) {
            for (var i = 0; i < regEscurrimiento.length; i++) {
                escuSubcuencaValues
                    .push(regEscurrimiento[i][subcuencasAtributes[index - 1]]);
            }
        }
    }

    // Crea la grafica para la precipitacion anual total, agregando o no el
    // escurrimiento anual para la subcuenca seleccionada dependiendo del
    // parametro booleano que se le pasa.
    function crearGraficaEscurrimientoAnual(anual, subcuenca) {
        clearCanvas();
        datasets = [];
        if (subcuenca) {
            var index = selCicloEscu.val();
            refreshEscuSubcuencaValues();
            datasets.push(getBarDataSet('Escurrimiento anual subcuenca '
                + subcuencasLabels[index - 1],
                escuSubcuencaValues, "rgba(170, 60, 57, 1)",
                "rgba(128, 25, 22, 1)"));
        }
        if (anual) {
            datasets.push(getBarDataSet('Escurrimiento anual cuenca Lerma-Chapala',
            escuAnualValues, "rgba(41, 81, 109, 1)", "rgba(18, 55, 82, 1)"));
        }
        chart = new Chart(context, {
            type: 'bar',
            data: {
                labels: ciclosLabels,
                datasets: datasets
            },
            options: getChartOptions("Escurrimiento Anual",
                "Escurrimiento (hm³)", "Ciclo", "hm³")
        });
    }

    // Ejecución del script
    start();
    crearGraficaEscurrimientoAnual(true, false);
});