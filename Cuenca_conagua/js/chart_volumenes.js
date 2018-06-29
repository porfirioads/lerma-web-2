// Este script maneja las gráficas de los volúmenes D.R. y P.I. (autorizados,
// asignados y utilizados).

$(document).ready(function () {
    var context = $('#grafica_vol').get(0).getContext('2d');
    var volDrAsignadoValues;
    var volDrAutorizadoValues;
    var volDrUtilizadoValues;
    var volPiAsignadoValues;
    var volPiAutorizadoValues;
    var volPiUtilizadoValues;
    var volDrLabels = ['DR033', 'DR045', 'DR011', 'DR085', 'DR087', 'DR022',
        'DR061', 'DR024', 'DR013'];
    var volPiLabels = ['P.I. Alzate', 'P.I. Ramirez', 'P.I. Tepetitlan',
        'P.I. Tepuxtepec', 'P.I. Solis', 'P.I. La Begoña', 'P.I. Queretaro',
        'P.I. Pericos', 'P.I. Adjuntas', 'P.I. Angulo', 'P.I. Corrales',
        'P.I. Yurecuaro', 'P.I. Duero', 'P.I. Zula', 'P.I. Chapala'];
    var volMaxDr = [90, 90, 955, 110, 232, 8, 200, 170, 150];
    var volMaxPi = [30, 30, 30, 26, 128, 53, 112, 14, 182, 60, 113, 198, 50,
        78, 137];
    var cicloDrLabels;
    var cicloPiLabels;
    var volDrAttributes = ['dr033', 'dr045', 'dr011', 'dr085', 'dr087', 'dr022',
        'dr061', 'dr024', 'dr013'];
    var volPiAttributes = ['piAlzate', 'piRamirez', 'piTepetitlan',
        'piTepuxtepec', 'piSolis', 'piBegona', 'piQueretaro', 'piPericos',
        'piAdjuntas', 'piAngulo', 'piCorrales', 'piYurecuaro', 'piDuero',
        'piZula', 'piChapala'];
    var selDr = $('#selDr');
    var selPi = $('#selPi');
    var selTipoGraficaVol = $('#selTipoGraficaVol');
    var tablaResumen = $('#tablaResumen');
    var chart;
    var drAdicional;
    var drExcedido;
    var piAdicional;
    var piExcedido;
    var resumenDr;
    var resumenPi;

    // Es el constructor del script
    function start() {
        console.log('start() ' + selTipoGraficaVol.val());

        var tipoGrafica = selTipoGraficaVol.val();

        if (tipoGrafica === 'vol_dr_actual') {
            volDrAsignados = volDrAsignadosActual;
            volDrAutorizados = volDrAutorizadosActual;
            volDrUtilizados = volDrUtilizadosActual;
        } else if (tipoGrafica === 'vol_dr_viejos') {
            volDrAsignados = volDrAsignadosOld;
            volDrAutorizados = volDrAutorizadosOld;
            volDrUtilizados = volDrUtilizadosOld;
        }

        console.log('DR_DATA ' + JSON.stringify({
            drAsignados: volDrAsignados,
            drAutorizados: volDrAutorizados,
            drUtilizados: volDrUtilizados
        }, null, 4));

        cicloDrLabels = [];
        for (var i = 0; i < volDrAsignados.length; i++) {
            cicloDrLabels.push(volDrAsignados[i].ciclo);
        }
        cicloPiLabels = [];
        for (var i = 0; i < volPiAsignados.length; i++) {
            cicloPiLabels.push(volPiAsignados[i].ciclo);
        }
        for (var i = 0; i < volDrLabels.length; i++) {
            selDr.append('<option value="' + i + '">' + volDrLabels[i] + '</option>');
        }
        for (var i = 0; i < volPiLabels.length; i++) {
            selPi.append('<option value="' + i + '">' + volPiLabels[i] + '</option>');
        }
        excedidosDr = [];
        for (var i = 0; i < volDrAsignados.length; i++) {
            excedidosDr.push({});
            for (var j = 0; j < volDrAttributes.length; j++) {
                var ex = volDrUtilizados[i][volDrAttributes[j]]
                    - volDrAsignados[i][volDrAttributes[j]];
                excedidosDr[i][volDrAttributes[j]] = ex >= 0 ? ex : 0;
            }
        }
        excedidosPi = [];
        for (var i = 0; i < volPiAsignados.length; i++) {
            excedidosPi.push({});
            for (var j = 0; j < volPiAttributes.length; j++) {
                var ex = volPiUtilizados[i][volPiAttributes[j]]
                    - volPiAsignados[i][volPiAttributes[j]];
                excedidosPi[i][volPiAttributes[j]] = ex >= 0 ? ex : 0;
            }
        }
        resumenDr = {};
        for (var i = 0; i < volDrAttributes.length; i++) {
            resumenDr[volDrAttributes[i]] = {};
            var promAutorizado = 0;
            var promAsignado = 0;
            var promUtilizado = 0;
            var promExcedido = 0;
            var porcAutMax = 0;
            var porcUtiMax = 0;
            resumenDr[volDrAttributes[i]]['volMax'] = volMaxDr[i];
            for (var j = 0; j < volDrAutorizados.length; j++) {
                var aut = volDrAutorizados[j][volDrAttributes[i]];
                var asi = volDrAsignados[j][volDrAttributes[i]];
                var uti = volDrUtilizados[j][volDrAttributes[i]];
                var exc = excedidosDr[j][volDrAttributes[i]];
                promAutorizado += aut;
                promAsignado += asi;
                promUtilizado += uti;
                promExcedido += exc;
            }
            promAutorizado /= volDrAutorizados.length;
            promAsignado /= volDrAsignados.length;
            promUtilizado /= volDrUtilizados.length;
            promExcedido /= excedidosDr.length;
            porcAutMax = promAutorizado * 100 / volMaxDr[i];
            porcUtiMax = promUtilizado * 100 / volMaxDr[i];
            resumenDr[volDrAttributes[i]]['promAutorizado'] = promAutorizado;
            resumenDr[volDrAttributes[i]]['promAsignado'] = promAsignado;
            resumenDr[volDrAttributes[i]]['promUtilizado'] = promUtilizado;
            resumenDr[volDrAttributes[i]]['promExcedido'] = promExcedido;
            resumenDr[volDrAttributes[i]]['porcAutMax'] = porcAutMax;
            resumenDr[volDrAttributes[i]]['porcUtiMax'] = porcUtiMax;
        }
        //console.log('------------------------------');
        resumenPi = {};
        for (var i = 0; i < volPiAttributes.length; i++) {
            resumenPi[volPiAttributes[i]] = {};
            var promAutorizado = 0;
            var promAsignado = 0;
            var promUtilizado = 0;
            var promExcedido = 0;
            var porcAutMax = 0;
            var porcUtiMax = 0;
            resumenPi[volPiAttributes[i]]['volMax'] = volMaxPi[i];
            for (var j = 0; j < volPiAutorizados.length; j++) {
                var aut = volPiAutorizados[j][volPiAttributes[i]];
                var asi = volPiAsignados[j][volPiAttributes[i]];
                var uti = volPiUtilizados[j][volPiAttributes[i]];
                var exc = excedidosPi[j][volPiAttributes[i]];
                promAutorizado += aut;
                promAsignado += asi;
                promUtilizado += uti;
                promExcedido += exc;
            }
            promAutorizado /= volPiAutorizados.length;
            promAsignado /= volPiAsignados.length;
            promUtilizado /= volPiUtilizados.length;
            promExcedido /= excedidosPi.length;
            porcAutMax = promAutorizado * 100 / volMaxPi[i];
            porcUtiMax = promUtilizado * 100 / volMaxPi[i];
            resumenPi[volPiAttributes[i]]['promAutorizado'] = promAutorizado;
            resumenPi[volPiAttributes[i]]['promAsignado'] = promAsignado;
            resumenPi[volPiAttributes[i]]['promUtilizado'] = promUtilizado;
            resumenPi[volPiAttributes[i]]['promExcedido'] = promExcedido;
            resumenPi[volPiAttributes[i]]['porcAutMax'] = porcAutMax;
            resumenPi[volPiAttributes[i]]['porcUtiMax'] = porcUtiMax;
        }
    }

    // Modifica una cadena para hacer que su longitud mínima sea la especificada,
    // rellenando los espacios vacíos con el caracter pasado como parámetro.
    function strPad(cadena, longitud, sustitucion) {
        var o = cadena.toString();
        if (!sustitucion) { sustitucion = '0'; }
        while (o.length < longitud) {
            o = sustitucion + o;
        }
        return o;
    };

    // Actualiza los valores de los volumenes dr, segun el dr seleccionado.
    function refreshDrValues() {
        var index = selDr.val();
        volDrAsignadoValues = [];
        volDrAutorizadoValues = [];
        volDrUtilizadoValues = [];
        for (var i = 0; i < volDrAsignados.length; i++) {
            volDrAsignadoValues.push(volDrAsignados[i][volDrAttributes[index]]);
            volDrAutorizadoValues.push(volDrAutorizados[i][volDrAttributes[index]]);
            volDrUtilizadoValues.push(volDrUtilizados[i][volDrAttributes[index]]);
        }
    }

    // Actualiza los valores de los volumenes pi, segun el pi seleccionado.
    function refreshPiValues() {
        var index = selPi.val();
        volPiAsignadoValues = [];
        volPiAutorizadoValues = [];
        volPiUtilizadoValues = [];
        for (var i = 0; i < volPiAsignados.length; i++) {
            volPiAsignadoValues.push(volPiAsignados[i][volPiAttributes[index]]);
            volPiAutorizadoValues.push(volPiAutorizados[i][volPiAttributes[index]]);
            volPiUtilizadoValues.push(volPiUtilizados[i][volPiAttributes[index]]);
        }
    }

    // Crea la grafica de P.I. para la P.I. seleccionada.
    function crearGraficaPi() {
        clearCanvas();
        refreshPiValues();
        var datasets = [];
        datasets.push(getBarDataSet('Autorizado', volPiAutorizadoValues,
            "rgba(41, 81, 109, 1)", "rgba(18, 55, 82, 1)"));
        datasets.push(getBarDataSet('Asignado', volPiAsignadoValues,
            "rgba(170, 60, 57, 1)", "rgba(128, 25, 22, 1)"));
        datasets.push(getBarDataSet('Utilizado', volPiUtilizadoValues,
            "rgba(45, 134, 51, 1)", "rgba(17, 101, 22, 1)"));
        chart = new Chart(context, {
            type: 'bar',
            data: {
                labels: cicloPiLabels,
                datasets: datasets
            },
            options: getChartOptions(volPiLabels[selPi.val()],
                "Volumen (hm³)", "Ciclo", "hm³")
        });

        updateTablaPi();
    }

    // Crea la grafica de D.R. para el D.R. seleccionado.
    function crearGraficaDr() {
        clearCanvas();
        start();
        refreshDrValues();
        var datasets = [];
        datasets.push(getBarDataSet('Autorizado', volDrAutorizadoValues,
            "rgba(41, 81, 109, 1)", "rgba(18, 55, 82, 1)"));
        datasets.push(getBarDataSet('Asignado', volDrAsignadoValues,
            "rgba(170, 60, 57, 1)", "rgba(128, 25, 22, 1)"));
        datasets.push(getBarDataSet('Utilizado', volDrUtilizadoValues,
            "rgba(45, 134, 51, 1)", "rgba(17, 101, 22, 1)"));
        chart = new Chart(context, {
            type: 'bar',
            data: {
                labels: cicloDrLabels,
                datasets: datasets
            },
            options: getChartOptions(volDrLabels[selDr.val()],
                "Volumen (hm³)", "Ciclo", "hm³")
        });
        updateTablaDr();
    }

    // Acualiza la tabla de resumen de D.R.
    function updateTablaDr() {
        var index = selDr.val();
        var promAut = resumenDr[volDrAttributes[index]]['promAutorizado'];
        var promAsi = resumenDr[volDrAttributes[index]]['promAsignado'];
        var promUti = resumenDr[volDrAttributes[index]]['promUtilizado'];
        var promExc = resumenDr[volDrAttributes[index]]['promExcedido'];
        var porcAuM = resumenDr[volDrAttributes[index]]['porcAutMax'];
        var porcUtM = resumenDr[volDrAttributes[index]]['porcUtiMax'];
        var voluMax = resumenDr[volDrAttributes[index]]['volMax'];
        $('#resId').text("D.R.");
        $('#colId').text(volDrLabels[index]);
        $('#colVolMax').text(voluMax);
        $('#colVolAut').text(promAut.toFixed(2));
        $('#colVolAsi').text(promAsi.toFixed(2));
        $('#colVolUti').text(promUti.toFixed(2));
        $('#colVolExc').text(promExc.toFixed(2));
        $('#colVolAuM').text(porcAuM.toFixed(2));
        $('#colVolUtM').text(porcUtM.toFixed(2));
    }

    // Acualiza la tabla de resumen de P.I.
    function updateTablaPi() {
        var index = selPi.val();
        var promAut = resumenPi[volPiAttributes[index]]['promAutorizado'];
        var promAsi = resumenPi[volPiAttributes[index]]['promAsignado'];
        var promUti = resumenPi[volPiAttributes[index]]['promUtilizado'];
        var promExc = resumenPi[volPiAttributes[index]]['promExcedido'];
        var porcAuM = resumenPi[volPiAttributes[index]]['porcAutMax'];
        var porcUtM = resumenPi[volPiAttributes[index]]['porcUtiMax'];
        var voluMax = resumenPi[volPiAttributes[index]]['volMax'];
        $('#resId').text("P.I.");
        $('#colId').text(volPiLabels[index]);
        $('#colVolMax').text(voluMax);
        $('#colVolAut').text(promAut.toFixed(2));
        $('#colVolAsi').text(promAsi.toFixed(2));
        $('#colVolUti').text(promUti.toFixed(2));
        $('#colVolExc').text(promExc.toFixed(2));
        $('#colVolAuM').text(porcAuM.toFixed(2));
        $('#colVolUtM').text(porcUtM.toFixed(2));
    }

    // Se ejecuta cuando se selecciona un elemento de la lista de D.R.
    selDr.change(function () {
        console.log('selDr.change()');
        crearGraficaDr();
    });

    // Se ejecuta cuando se selecciona un elemento de la lista de P.I.
    selPi.change(function () {
        console.log('selPi.change()');
        crearGraficaPi();
    });

    // Cambia el tipo de gráfica al seleccionar uno del comboBox de tipos de
    // gráfica de volumen.
    selTipoGraficaVol.change(function () {
        console.log('Se hará gráfica [' + selTipoGraficaVol.val() + ']');

        var tipoGrafica = selTipoGraficaVol.val();

        if (tipoGrafica === 'vol_dr_viejos') {
            selPi.addClass('hidden');
            selDr.removeClass('hidden');
            selDr.trigger('change');
        } else if (tipoGrafica === 'vol_pi_viejos') {
            selDr.addClass('hidden');
            selPi.removeClass('hidden');
            //selPi.trigger('change');
        } else if (tipoGrafica === 'vol_dr_actual') {
            selPi.addClass('hidden');
            selDr.removeClass('hidden');
            selDr.trigger('change');
        } else if (tipoGrafica === 'vol_pi_actual') {
            selDr.addClass('hidden');
            selPi.removeClass('hidden');
            selPi.trigger('change');
        } else if (tipoGrafica === 'vol_gt') {

        } else if (tipoGrafica === 'vol_ag') {

        }
    });

    // Limpia el canvas.
    function clearCanvas() {
        if (chart != undefined) {
            chart.destroy();
        }
    }

    // Ejecución del script.
    start();
});