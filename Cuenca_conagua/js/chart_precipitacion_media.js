// Este script maneja las gráficas de la precipitación media anual y mensual.

$(document).ready(function () {
    var precAnualValues;
    var precAnualMediaValues;
    var precMensualValues;
    var precMensualMediaValues;
    var labelsCiclo;
    var labelsMensual = ['Nov', 'Dic', 'Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
        'Jul', 'Ago', 'Sep', 'Oct'];
    var blueBackground = "rgba(41, 81, 109, 1)";
    var blueBorder = "rgba(18, 55, 82, 1)";
    var context = $('#grafica_pma').get(0).getContext('2d');
    var precChartTitle = $('#precChart > .chart-title');
    var chkAnual = $('#chkAnual');
    var chkMensual = $('#chkMensual');
    var divChkAnual = $('#divChkAnual');
    var divChkMensual = $('#divChkMensual');
    var selCiclo = $('#selCiclo');
    var btnChangePrecMensual = $('#btnChangePrecMensual');
    var btnChangePrecAnual = $('#btnChangePrecAnual');
    var chart;
    var ciclosIgnorados = 13;

    // Inicia la carga de los datos para la creacion de las graficas de 
    // precipitacion.
    function start() {
        labelsCiclo = [];
        precAnualValues = [];
        precAnualMediaValues = [];
        precMensualValues = [];
        precMensualMediaValues = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
        media = 0;

        // Calcula media anual y llega arreglo de valores

        for (var i = 0; i < regPrecipitacion.length; i++) {
            labelsCiclo.push(regPrecipitacion[i].ciclo);
            precAnualValues.push(regPrecipitacion[i].total);
            media += precAnualValues[i];
        }

        media /= precAnualValues.length;

        for (var i = ciclosIgnorados; i < regPrecipitacion.length; i++) {
            precAnualMediaValues.push(media);
        }

        for (var i = ciclosIgnorados; i < regPrecipitacion.length; i++) {
            selCiclo.append('<option value="' + i + '">' + labelsCiclo[i] + '</option>');

            for (var j = 0; j < 12; j++) {
                precMensualMediaValues[j]
                    += regPrecipitacion[i][labelsMensual[j].toLowerCase()];
            }
        }

        for (var i = 0; i < 12; i++) {
            precMensualMediaValues[i] /= (regPrecipitacion.length - ciclosIgnorados);
        }

        refreshDataSetMensual();
    }

    // Se ejecuta cuando el checkbox para mostrar la media anual es presionado.
    chkAnual.change(function () {
        if (chkAnual.prop('checked')) {
            crearGraficaPrecAnual(true);
        } else {
            crearGraficaPrecAnual(false);
        }
    });

    // Ejecutado cuando el checkbox para mostrar la media mensual es presionado.
    chkMensual.change(function () {
        if (chkMensual.prop('checked')) {
            crearGraficaPrecMensual(true);
        } else {
            crearGraficaPrecMensual(false);
        }
    });

    // Se ejecuta cuando se presiona el boton para cambiar al modo de 
    // precipitacion mensual.
    btnChangePrecMensual.click(function () {
        var lastIndex = $('#selCiclo > option').last().val();
        $('#selCiclo option')[lastIndex - ciclosIgnorados].selected = true;
        divChkAnual.addClass('hidden');
        divChkMensual.removeClass('hidden');
        btnChangePrecMensual.addClass('hidden');
        btnChangePrecAnual.removeClass('hidden');
        selCiclo.removeClass('hidden');
        chkMensual.prop('checked', false);
        chkMensual.change();
    });

    // Se ejecuta cuando se presiona el boton para cambiar al modo de 
    // precipitacion anual.
    btnChangePrecAnual.click(function () {
        divChkAnual.removeClass('hidden');
        divChkMensual.addClass('hidden');
        btnChangePrecMensual.removeClass('hidden');
        btnChangePrecAnual.addClass('hidden');
        selCiclo.addClass('hidden');
        chkAnual.prop('checked', false);
        chkAnual.change();
    });

    // Se ejecuta cuando cambia el ciclo seleccionado en la grafica de 
    // precipitacion mensual.
    selCiclo.change(function () {
        chkMensual.change();
    });

    // Limpia el canvas.
    function clearCanvas() {
        if (chart != undefined) {
            chart.destroy();
        }
    }

    // Crea la grafica de la precipitacion anual, recibiendo como parametro un
    // booleano que determina si se debe agregar la media anual a la grafica.
    function crearGraficaPrecAnual(media) {
        clearCanvas();
        datasets = [];
        if (media) {
            datasets.push(getLineDataSet('Precipitación media anual',
                precAnualMediaValues, "rgba(170, 60, 57, 1)",
                "rgba(128, 25, 22, 1)"));
        }
        datasets.push(getBarDataSet('Precipitación anual', precAnualValues,
            "rgba(41, 81, 109, 1)", "rgba(18, 55, 82, 1)"));
        chart = new Chart(context, {
            type: 'bar',
            data: {
                labels: labelsCiclo,
                datasets: datasets
            },
            options: getChartOptions("Precipitación Media Anual",
                "Precipitación (mm)", "Ciclo", "mm")
        });
    }

    // Crea la grafica de la precipitacion mensual, recibiendo como parametro un
    // booleano que determina si se debe agregar la media mensual a la grafica.
    function crearGraficaPrecMensual(media) {
        clearCanvas();
        refreshDataSetMensual();
        datasets = [];
        if (media) {
            datasets.push(getBarDataSet('Precipitación media mensual',
                precMensualMediaValues, "rgba(170, 60, 57, 1)",
                "rgba(128, 25, 22, 1)"));
        }
        datasets.push(getBarDataSet('Precipitación mensual', precMensualValues,
            "rgba(41, 81, 109, 1)", "rgba(18, 55, 82, 1)"));
        chart = new Chart(context, {
            type: 'bar',
            data: {
                labels: labelsMensual,
                datasets: datasets
            },
            options: getChartOptions("Precipitación Mensual",
                "Precipitación (mm)", "Mes", "mm")
        });
    }

    // Actualiza los valores de precipitacion mensual para el ciclo 
    // seleccionado.
    function refreshDataSetMensual() {
        var regIndex = selCiclo.val();
        precMensualValues = [];
        precMensualValues.push(regPrecipitacion[regIndex].nov);
        precMensualValues.push(regPrecipitacion[regIndex].dic);
        precMensualValues.push(regPrecipitacion[regIndex].ene);
        precMensualValues.push(regPrecipitacion[regIndex].feb);
        precMensualValues.push(regPrecipitacion[regIndex].mar);
        precMensualValues.push(regPrecipitacion[regIndex].abr);
        precMensualValues.push(regPrecipitacion[regIndex].may);
        precMensualValues.push(regPrecipitacion[regIndex].jun);
        precMensualValues.push(regPrecipitacion[regIndex].jul);
        precMensualValues.push(regPrecipitacion[regIndex].ago);
        precMensualValues.push(regPrecipitacion[regIndex].sep);
        precMensualValues.push(regPrecipitacion[regIndex].oct);
    }

    // Ejecución del script.
    start();
    crearGraficaPrecAnual(false);
});