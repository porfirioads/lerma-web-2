// Este script maneja las gráficas los almacenamientos principales.

$(document).ready(function () {
    var valuesAlmEnPresas;
    var valuesAlmEnPresasPorc;
    var valuesAlmEnUnaPresa;
    var labelsPresas = ['Alzate', 'Ramírez', 'Tepetitlán', 'Tepuxtepec',
        'Solís', 'Yuriria', 'Allende', 'M. Ocampo', 'Purísima', 'Chapala'];

    var capsOperacion = {
        alzate: 35,
        ramirez: 21,
        tepetitlan: 68,
        tepuxtepec: 450,
        solis: 800,
        yuriria: 188,
        allende: 149,
        m_ocampo: 200,
        purisima: 110,
        chapala: 8124
    };

    var labelsAnios;
    var context = $('#grafica_alm').get(0).getContext('2d');
    var laeChartTitle = $('#laeChart > .chart-title');
    var selAnioAlm = $('#selAnioAlm');
    var selPresaAlm = $('#selPresaAlm');
    var selTipoGraficaAlm = $('#selTipoGraficaAlm');
    var chart;

    // Inicia la carga de los datos para la creación de las gráficas de 
    // almacenamientos principales.
    function start() {
        console.log('chart_almacenamientos_principales start()');
        labelsAnios = [];
        valuesAlmEnPresas = [];
        valuesAlmEnPresasPorc = [];
        valuesAlmEnUnaPresa = [];

        //console.log(regAlmacenamientosPrincipales);

        // Llena los selects del año
        for (var i = 0; i < regAlmacenamientosPrincipales.length; i++) {
            labelsAnios.push(regAlmacenamientosPrincipales[i].anio);
            var option = '<option value="' + i + '">' + labelsAnios[i] + '</option>';
            selAnioAlm.append(option);
        }

        // Llena los selects de presa
        for (var i = 0; i < labelsPresas.length; i++) {
            var option = '<option value="' + i + '">' + labelsPresas[i] + '</option>';
            selPresaAlm.append(option);
        }

        // Llena los valores de almacenamientos y de porcentajes
        for (var i = 0; i < regAlmacenamientosPrincipales.length; i++) {
            valuesAlmEnPresas.push([]);
            valuesAlmEnPresasPorc.push([]);

            for (key in regAlmacenamientosPrincipales[0]) {
                if (key !== 'anio') {
                    var almValue = regAlmacenamientosPrincipales[i][key];
                    var capValue = capsOperacion[key];
                    valuesAlmEnPresas[i].push(almValue);
                    valuesAlmEnPresasPorc[i].push(almValue / capValue * 100);
                }
            }
        }

        //console.log(valuesAlmEnPresas);
        //console.log(valuesAlmEnPresasPorc);
    }

    function crearGraficaAlmAnio() {
        clearCanvas();
        datasets = [];

        var index = selAnioAlm.val();

        var values = valuesAlmEnPresas[index].slice(0, -1);
        var labels = labelsPresas.slice(0, -1);
        var anio = '20' + labelsAnios[index].slice(4);

        console.log(anio);


        datasets.push(getBarDataSet('',
            values, "rgba(41, 81, 109, 1)",
            "rgba(18, 55, 82, 1)"));

        chart = new Chart(context, {
            type: 'bar',
            data: {
                labels: labels,
                datasets: datasets
            },
            options: getChartOptions([
                'Almacenamiento al 1° de noviembre de ' + anio,
                ' de las presas principales'
            ], "Volumen de almacenamiento", "Presa", "hm3", false)
        });

        console.log('crearGraficaAlmAnio() end');
    }

    function crearGraficaAlmAnioPorc() {

    }

    function crearGraficaAlmPresa() {

    }

    // Limpia el canvas.
    function clearCanvas() {
        if (chart != undefined) {
            chart.destroy();
        }
    }

    // Actualiza la gráfica por año al seleccionar uno del combobox.
    selAnioAlm.change(function () {
        var tipo = selTipoGraficaAlm.val();

        if (tipo === 'almAnio') {
            crearGraficaAlmAnio();
        } else if (tipo === 'almAnioPorc') {
            crearGraficaAlmAnioPorc();
        }
    });

    // Actualiza la gráfica por presa al seleccionar una del combobox.
    selPresaAlm.change(function () {
        crearGraficaAlmPresa();
    });

    // Muestra/oculta opciones y manda renderizar el tipo de gráfica 
    // seleccionado.
    selTipoGraficaAlm.change(function () {
        console.log('selTipoGraficaAlm.change()');

        var tipo = selTipoGraficaAlm.val();

        if (tipo === 'almAnio') {
            selAnioAlm.removeClass('hidden');
            selPresaAlm.addClass('hidden');
            crearGraficaAlmAnio();
        } else if (tipo === 'almAnioPorc') {
            selAnioAlm.removeClass('hidden');
            selPresaAlm.addClass('hidden');
            crearGraficaAlmAnioPorc();
        } else if (tipo === 'almPresa') {
            selAnioAlm.addClass('hidden');
            selPresaAlm.removeClass('hidden');
            crearGraficaAlmPresa();
        }
    });

    // Ejecución del script.
    start();
});