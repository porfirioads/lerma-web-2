// Este script maneja las gráficas de las lluvias anuales por estación.

$(document).ready(function () {
    var valuesPromHistorico;
    var valuesLluviaPorCiclo;
    var labelsCiclo;
    var labelsEstaciones = ['Celaya', 'Guanajuato', 'Irapuato', 'Las Adjuntas',
        'León', 'P. Peñuelitas', 'P. Solís', 'San Felipe', 'S. Luis de la Paz',
        'Yuriria', 'Chapala', 'El Fuerte', 'El Tule', 'Tizapán', 'Yurécuaro',
        'Atlacomulco', 'Toluca Rectoría', 'Chincua', 'Cuitzeo Au',
        'Melchor Ocampo', 'Morelia', 'Tepuxtepec', 'Zacapu', 'Zamora',
        'Querétaro Obs.'];
    var blueBackground = "rgba(41, 81, 109, 1)";
    var blueBorder = "rgba(18, 55, 82, 1)";
    var context = $('#grafica_lae').get(0).getContext('2d');
    var laeChartTitle = $('#laeChart > .chart-title');
    var selCicloLae = $('#selCicloLae');

    var chart;

    // Inicia la carga de los datos para la creación de la gráfica de 
    // lluvia anual por estación.
    function start() {
        labelsCiclo = [];
        valuesPromHistorico = [];

        // Llena los selects del ciclo
        for (var i = 0; i < regLluviaAnualEstacion.length; i++) {
            labelsCiclo.push(regLluviaAnualEstacion[i].ciclo);
            selCicloLae.append('<option value="' + i + '">' + labelsCiclo[i] +
                '</option>');
        }

        // Llena los valores de media histórica por estación
        var promedio;

        for (key in regLluviaAnualEstacion[0]) {
            if (key !== 'ciclo') {
                promedio = 0;

                for (var i = 0; i < regLluviaAnualEstacion.length; i++) {
                    promedio += regLluviaAnualEstacion[i][key];
                }

                promedio /= labelsCiclo.length;
                valuesPromHistorico.push(promedio);
            }
        }
    }

    // Se ejecuta cuando se selecciona un elemento de la lista de D.R.
    selCicloLae.change(function () {
        crearGraficaLae();
    });

    // Limpia el canvas.
    function clearCanvas() {
        if (chart != undefined) {
            chart.destroy();
        }
    }

    // Crea la gráfica de lluvia anual por estación dependiendo del ciclo 
    // seleccionado.
    function crearGraficaLae() {
        clearCanvas();
        datasets = [];
        valuesLluviaPorCiclo = [];

        datasets.push(getBarDataSet('Media histórica anual',
            valuesPromHistorico, "rgba(170, 60, 57, 1)",
            "rgba(128, 25, 22, 1)"));

        var cicloIndex = selCicloLae.val();
        var cicloName = 'Ciclo ' + regLluviaAnualEstacion[cicloIndex].ciclo;

        //console.log(regLluviaAnualEstacion);
        //console.log('index: ' + cicloIndex);
        //console.log(regLluviaAnualEstacion[cicloIndex]);

        for (key in regLluviaAnualEstacion[0]) {
            if (key !== 'ciclo') {
                valuesLluviaPorCiclo
                    .push(regLluviaAnualEstacion[cicloIndex][key]);
            }
        }

        datasets.push(getBarDataSet(cicloName, valuesLluviaPorCiclo,
            "rgba(41, 81, 109, 1)", "rgba(18, 55, 82, 1)"));

        //console.log('Prom histórico: ' + valuesPromHistorico);   
        //console.log(cicloName + ': ' + valuesLluviaPorCiclo);   

        chart = new Chart(context, {
            type: 'bar',
            data: {
                labels: labelsEstaciones,
                datasets: datasets
            },
            options: getChartOptions("Lluvia anual por estación",
                "Precipitación acumulada (mm)", "Ciclo", "mm")
        });
    }

    // Ejecución del script.
    start();
    crearGraficaLae();
});