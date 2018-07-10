// Este script maneja las gráficas los almacenamientos históricos de Chapala.

$(document).ready(function () {
    var values = [];
    var labels = [];
    var context = $('#grafica_almHistChapala').get(0).getContext('2d');
    var chart;

    // Inicia la carga de los datos para la creación de las gráficas de 
    // almacenamientos históricos de chapala.
    function start() {
        // Llena valores y etiquetas de la gráfica
        for (var i = 0; i < almHistoricosChapala.length; i++) {
            values.push(almHistoricosChapala[i].almacenamiento);
            labels.push(almHistoricosChapala[i].fecha);
        }
    }

    function crearGraficaAlmHistChapala() {
        clearCanvas();
        datasets = [];

        datasets.push(getLineDataSet('',
            values, "rgba(41, 81, 109, 1)",
            "rgba(18, 55, 82, 1)"));

        chart = new Chart(context, {
            type: 'bar',
            data: {
                labels: labels,
                datasets: datasets
            },
            options: getChartOptions([
                'Evolución del Lago de Chapala'
            ], "Almacenamiento (hm³)", "Fecha", "hm³", false, 0, 100)
        });
    }

    // Limpia el canvas.
    function clearCanvas() {
        if (chart != undefined) {
            chart.destroy();
        }
    }

    function waitForElement() {
        console.log('verificación almHistoricosChapala');

        if (typeof almHistoricosChapala !== "undefined") {
            start();
            crearGraficaAlmHistChapala();
            $('#almLagoChapalaSpinnerContainer').addClass('hidden');
        }
        else {
            setTimeout(waitForElement, 1000);
        }
    }

    waitForElement();
    
});

