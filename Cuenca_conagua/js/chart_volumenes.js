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
    var volPiOldLabels = ["P.I. Alto Lerma", "P. I. Río Querétaro",
        "P. I. Bajío", "P. I. Ángulo Duero", "P. I. Bajo Lerma"];
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
    var volPiOldAttributes = ['piAltoLerma', 'piRioQueretaro', 'piBajio',
        'piAnguloDuero', 'piBajoLerma'];
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
    var resumenPiOld;
    var tablaResumen = $('#tablaResumen');
    var tablaResumenGtAg = $('#tablaResumenGtAg');

    // Es el constructor del script
    function start() {
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

        calculateResumenPiOld();
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

    /**
     * Crea la gráfica de P.I. acuerdo 1991 para la P.I. seleccionada.
     */
    function crearGraficaPiOld() {
        clearCanvas();
        var datasets = [];
        var autorizadosValues = [];
        var utilizadosValues = [];
        var cicloLabels = [];
        var piIndex = selPi.val();

        for (var i = 0; i < volPiAutorizadosOld.length; i++) {
            autorizadosValues.push(volPiAutorizadosOld[i][volPiOldAttributes[piIndex]]);
            utilizadosValues.push(volPiUtilizadosOld[i][volPiOldAttributes[piIndex]]);
            cicloLabels.push(volPiUtilizadosOld[i].ciclo);
        }

        datasets.push(getBarDataSet('Autorizado', autorizadosValues,
            "rgba(41, 81, 109, 1)", "rgba(18, 55, 82, 1)"));
        datasets.push(getBarDataSet('Utilizado', utilizadosValues,
            "rgba(170, 60, 57, 1)", "rgba(128, 25, 22, 1)"));

        chart = new Chart(context, {
            type: 'bar',
            data: {
                labels: cicloLabels,
                datasets: datasets
            },
            options: getChartOptions(volPiOldLabels[piIndex],
                "Volumen (hm³)", "Ciclo", "hm³")
        });

        updateTablaPiOld();
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

    /**
     * Calcula los datos de la tabla de resumen de volúmenes P.I. acuerdo 1991.
     */
    function calculateResumenPiOld() {
        resumenPiOld = {};
        var volMaxPi = [241, 65, 523, 464, 157];

        for (var i = 0; i < volPiOldAttributes.length; i++) {
            resumenPiOld[volPiOldAttributes[i]] = {};
            var promAutorizado = 0;
            var promAsignado = '-';
            var promUtilizado = 0;
            var promExcedido = '-';
            var porcAutMax = 0;
            var porcUtiMax = 0;

            resumenPiOld[volPiOldAttributes[i]]['volMax'] = volMaxPi[i];

            for (var j = 0; j < volPiAutorizadosOld.length; j++) {
                var aut = volPiAutorizadosOld[j][volPiOldAttributes[i]];
                var uti = volPiUtilizadosOld[j][volPiOldAttributes[i]];
                promAutorizado += aut;
                promUtilizado += uti;
            }

            promAutorizado /= volPiAutorizadosOld.length;
            promUtilizado /= volPiUtilizadosOld.length;
            porcAutMax = promAutorizado * 100 / volMaxPi[i];
            porcUtiMax = promUtilizado * 100 / volMaxPi[i];
            resumenPiOld[volPiOldAttributes[i]]['promAutorizado'] = promAutorizado;
            resumenPiOld[volPiOldAttributes[i]]['promAsignado'] = promAsignado;
            resumenPiOld[volPiOldAttributes[i]]['promUtilizado'] = promUtilizado;
            resumenPiOld[volPiOldAttributes[i]]['promExcedido'] = promExcedido;
            resumenPiOld[volPiOldAttributes[i]]['porcAutMax'] = porcAutMax;
            resumenPiOld[volPiOldAttributes[i]]['porcUtiMax'] = porcUtiMax;
        }
    }

    /**
     * Actualiza la tabla de resumen de P.I. Old.
     */
    function updateTablaPiOld() {
        var index = selPi.val();
        var promAut = resumenPiOld[volPiOldAttributes[index]]['promAutorizado'];
        var promAsi = resumenPiOld[volPiOldAttributes[index]]['promAsignado'];
        var promUti = resumenPiOld[volPiOldAttributes[index]]['promUtilizado'];
        var promExc = resumenPiOld[volPiOldAttributes[index]]['promExcedido'];
        var porcAuM = resumenPiOld[volPiOldAttributes[index]]['porcAutMax'];
        var porcUtM = resumenPiOld[volPiOldAttributes[index]]['porcUtiMax'];
        var voluMax = resumenPiOld[volPiOldAttributes[index]]['volMax'];
        $('#resId').text("P.I.");
        $('#colId').text(volPiOldLabels[index]);
        $('#colVolMax').text(voluMax);
        $('#colVolAut').text(promAut.toFixed(2));
        $('#colVolAsi').text(promAsi);
        $('#colVolUti').text(promUti.toFixed(2));
        $('#colVolExc').text(promExc);
        $('#colVolAuM').text(porcAuM.toFixed(2));
        $('#colVolUtM').text(porcUtM.toFixed(2));
    }

    // Se ejecuta cuando se selecciona un elemento de la lista de D.R.
    selDr.change(function () {
        crearGraficaDr();
    });

    // Se ejecuta cuando se selecciona un elemento de la lista de P.I.
    selPi.change(function () {
        var tipoGrafica = selTipoGraficaVol.val();

        if (tipoGrafica === 'vol_pi_viejos') {
            crearGraficaPiOld();
        } else {
            crearGraficaPi();
        }
    });

    /**
     * Actualiza las opciones del comboBox de pequeña irrigación dependiendo
     * del si la gráfica es del acuerdo 1991 o convenio 2004.
     */
    function refreshSelPi() {
        var tipoGrafica = selTipoGraficaVol.val();
        var piLabels;
        
        if (tipoGrafica === 'vol_pi_viejos') {
            piLabels = volPiOldLabels;
        } else {
            piLabels = volPiLabels;
        }

        selPi.empty();

        for (var i = 0; i < piLabels.length; i++) {
            selPi.append('<option value="' + i + '">' + piLabels[i] + '</option>');
        }
    }

    // Cambia el tipo de gráfica al seleccionar uno del comboBox de tipos de
    // gráfica de volumen.
    selTipoGraficaVol.change(function () {
        console.log('Se hará gráfica [' + selTipoGraficaVol.val() + ']');

        var tipoGrafica = selTipoGraficaVol.val();

        if (tipoGrafica.startsWith('vol_dr')) {
            selPi.addClass('hidden');
            selDr.removeClass('hidden');
            selDr.trigger('change');
            tablaResumen.removeClass('hidden');
            tablaResumenGtAg.addClass('hidden');
        } else if (tipoGrafica.startsWith('vol_pi')) {
            selDr.addClass('hidden');
            selPi.removeClass('hidden');
            refreshSelPi();
            selPi.trigger('change');
            tablaResumen.removeClass('hidden');
            tablaResumenGtAg.addClass('hidden');
        } else if (tipoGrafica === 'vol_gt') {
            selDr.addClass('hidden');
            selPi.addClass('hidden');
            crearGraficaGt();
            tablaResumen.addClass('hidden');
            tablaResumenGtAg.removeClass('hidden');
        } else if (tipoGrafica === 'vol_ag') {
            selDr.addClass('hidden');
            selPi.addClass('hidden');
            crearGraficaAg();
            tablaResumen.addClass('hidden');
            tablaResumenGtAg.removeClass('hidden');
        }
    });

    /**
     * Crea la tabla de la generación tepuxtepec.
     */
    function crearGraficaGt() {
        clearCanvas();
        var cicloLabels = [];
        var asignadoValues = [];
        var autorizadoValues = [];
        var utilizadoValues = [];
        var datasets = [];

        for (var i = 0; i < volGtAsignados.length; i++) {
            cicloLabels.push(volGtAsignados[i].ciclo);
            asignadoValues.push(volGtAsignados[i].volumen);

            if (i < volGtAutorizados.length)
                autorizadoValues.push(volGtAutorizados[i].volumen);

            if (i < volGtUtilizados.length)
                utilizadoValues.push(volGtUtilizados[i].volumen);
        }
        
        datasets.push(getBarDataSet('Autorizado', autorizadoValues,
            "rgba(41, 81, 109, 1)", "rgba(18, 55, 82, 1)"));
        datasets.push(getBarDataSet('Asignado', asignadoValues,
            "rgba(170, 60, 57, 1)", "rgba(128, 25, 22, 1)"));
        datasets.push(getBarDataSet('Utilizado', utilizadoValues,
            "rgba(45, 134, 51, 1)", "rgba(17, 101, 22, 1)"));
        chart = new Chart(context, {
            type: 'bar',
            data: {
                labels: cicloLabels,
                datasets: datasets
            },
            options: getChartOptions('Generación Tepuxtepec',
                "Volumen (hm³)", "Ciclo", "hm³")
        });

        updateTablaGt();
    }

    /**
     * Actualiza la tabla de resumen para la tabla GT
     */
    function updateTablaGt() {
        tablaResumenGtAg.find('.colId').text('Generación Tepuxtepec');
        var volMax = 472;
        var volAsignadoProm = 0;
        var volAutorizadoProm = 0;
        var volUtilizadoProm = 0;
        var volExcedidoProm = 0;

        for (var i = 0; i < volGtAsignados.length; i++) {
            volAsignadoProm += volGtAsignados[i].volumen;
            
            if (i < volGtAutorizados.length)
                volAutorizadoProm += volGtAutorizados[i].volumen;

            if (i < volGtUtilizados.length)
                volUtilizadoProm += volGtUtilizados[i].volumen;

            if (i < volGtUtilizados.length && i < volGtAsignados.length) {
                var exTmp = volGtUtilizados[i] - volGtAsignados[i];
                volExcedidoProm += exTmp >= 0 ? exTmp : 0;
            }
        }
     
        volAsignadoProm = (volAsignadoProm / volGtAsignados.length).toFixed(2);
        volAutorizadoProm = (volAutorizadoProm / volGtAutorizados.length).toFixed(2);
        volUtilizadoProm = (volUtilizadoProm / volGtUtilizados.length).toFixed(2);
        volExcedidoProm = (volExcedidoProm / volGtUtilizados.length).toFixed(2);

        var volAuM = (volAutorizadoProm * 100 / volMax).toFixed(2);
        var volUtM = (volUtilizadoProm * 100 / volMax).toFixed(2);

        tablaResumenGtAg.find('.colVolMax').text(volMax);
        tablaResumenGtAg.find('.colVolAut').text(volAutorizadoProm);
        tablaResumenGtAg.find('.colVolAsi').text(volAsignadoProm);
        tablaResumenGtAg.find('.colVolUti').text(volUtilizadoProm);
        tablaResumenGtAg.find('.colVolExc').text(volExcedidoProm);
        tablaResumenGtAg.find('.colVolAuM').text(volAuM);
        tablaResumenGtAg.find('.colVolUtM').text(volUtM);
    }

    /**
     * Crea la tabla de la generación tepuxtepec.
     */
    function crearGraficaAg() {
        clearCanvas();
        var cicloLabels = [];
        var asignadoValues = [];
        var autorizadoValues = [];
        var utilizadoValues = [];
        var datasets = [];

        for (var i = 0; i < volAgAsignados.length; i++) {
            cicloLabels.push(volAgAsignados[i].ciclo);
            asignadoValues.push(volAgAsignados[i].volumen);

            if (i < volAgAutorizados.length)
                autorizadoValues.push(volAgAutorizados[i].volumen);

            if (i < volAgUtilizados.length)
                utilizadoValues.push(volAgUtilizados[i].volumen);
        }

        datasets.push(getBarDataSet('Autorizado', autorizadoValues,
            "rgba(41, 81, 109, 1)", "rgba(18, 55, 82, 1)"));
        datasets.push(getBarDataSet('Asignado', asignadoValues,
            "rgba(170, 60, 57, 1)", "rgba(128, 25, 22, 1)"));
        datasets.push(getBarDataSet('Utilizado', utilizadoValues,
            "rgba(45, 134, 51, 1)", "rgba(17, 101, 22, 1)"));
        chart = new Chart(context, {
            type: 'bar',
            data: {
                labels: cicloLabels,
                datasets: datasets
            },
            options: getChartOptions('Agua Potable Guadalajara',
                "Volumen (hm³)", "Ciclo", "hm³")
        });

        updateTablaAg();
    }

    /**
     * Actualiza la tabla de resumen para la tabla AG
     */
    function updateTablaAg() {
        tablaResumenGtAg.find('.colId').text('Agua potable Guadalajara');
        var volMax = 240;
        var volAsignadoProm = 0;
        var volAutorizadoProm = 0;
        var volUtilizadoProm = 0;
        var volExcedidoProm = 0;

        for (var i = 0; i < volAgAsignados.length; i++) {
            volAsignadoProm += volAgAsignados[i].volumen;

            if (i < volAgAutorizados.length)
                volAutorizadoProm += volAgAutorizados[i].volumen;

            if (i < volAgUtilizados.length)
                volUtilizadoProm += volAgUtilizados[i].volumen;

            if (i < volAgUtilizados.length && i < volAgAsignados.length) {
                var exTmp = volAgUtilizados[i] - volAgAsignados[i];
                volExcedidoProm += exTmp >= 0 ? exTmp : 0;
            }
        }

        volAsignadoProm = (volAsignadoProm / volAgAsignados.length).toFixed(2);
        volAutorizadoProm = (volAutorizadoProm / volAgAutorizados.length).toFixed(2);
        volUtilizadoProm = (volUtilizadoProm / volAgUtilizados.length).toFixed(2);
        volExcedidoProm = (volExcedidoProm / volAgUtilizados.length).toFixed(2);

        var volAuM = (volAutorizadoProm * 100 / volMax).toFixed(2);
        var volUtM = (volUtilizadoProm * 100 / volMax).toFixed(2);

        tablaResumenGtAg.find('.colVolMax').text(volMax);
        tablaResumenGtAg.find('.colVolAut').text(volAutorizadoProm);
        tablaResumenGtAg.find('.colVolAsi').text(volAsignadoProm);
        tablaResumenGtAg.find('.colVolUti').text(volUtilizadoProm);
        tablaResumenGtAg.find('.colVolExc').text(volExcedidoProm);
        tablaResumenGtAg.find('.colVolAuM').text(volAuM);
        tablaResumenGtAg.find('.colVolUtM').text(volUtM);
    }

    // Limpia el canvas.
    function clearCanvas() {
        if (chart != undefined) {
            chart.destroy();
        }
    }

    // Ejecución del script.
    start();
});