// Este script tiene funciones de uso general para todos los scripts que generan
// gráficas, en general sirven para obtener las opciones y datasets que se pasan
// como parámetros a los métodos de la construcción de las gráficas.

// Obtiene las opciones de configuración comunes a todos las gráficas.
getChartOptions = function (chartTitle, yTitle, xTitle, unidad) {
    return {
        tooltips: {
            mode: 'label',
            callbacks: {
                label: function (tooltipItem, data) {
                    return tooltipItem.yLabel.toFixed(3) + ' ' + unidad;
                }
            }
        },
        title: {
            display: true,
            text: chartTitle,
            fontSize: 22
        },
        scales: {
            yAxes: [{
                scaleLabel: {
                    display: true,
                    labelString: yTitle,
                    fontSize: 15
                },
                ticks: {
                    suggestedMin: 0,
                    beginAtZero: true
                }
            }],
            xAxes: [{
                scaleLabel: {
                    display: true,
                    labelString: xTitle,
                    fontSize: 13
                },
                ticks: {
                    autoSkip: false
                }
            }]
        }
    }
};

// Obtiene el dataset para una gráfica de barras, recibiendo como parámetros
// sus características de valores y formato.
getBarDataSet = function (label, data, backgroundColor, borderColor) {
    return {
        type: 'bar',
        label: label,
        data: data,
        backgroundColor: backgroundColor,
        borderWidth: 2,
        borderColor: borderColor
    };
}

// Obtiene el dataset para una gráfica lineal, recibiendo como parámetros
// sus características de valores y formato.
getLineDataSet = function (label, data, pointColor, borderColor) {
    return {
        type: 'line',
        label: label,
        data: data,
        backgroundColor: "rgba(0,0,0,0)",
        borderWidth: 2,
        pointBackgroundColor: pointColor,
        borderColor: borderColor
    };
}