// Este script controla el componente de subida de archivos del sistema.

var maxFilesExceeded = false;
var uploadAllowed = false;
var maxFiles = 100;

var uploadLabels = [
    {
        optionValue: 'Lluvia_media_anual',
        optionLabel: 'Precipitación media (Lluvia_media_anual.csv)',
        fileExtension: '.csv'
    },
    {
        optionValue: 'Escurrimiento_anual',
        optionLabel: 'Escurrimiento anual (Escurrimiento_anual.csv)',
        fileExtension: '.csv'
    },
    {
        optionValue: 'Lluvia_anual_estación',
        optionLabel: 'Lluvia anual por estación (Lluvia_anual_estación.csv)',
        fileExtension: '.csv'
    },
    {
        optionValue: 'Almacenamientos_principales',
        optionLabel: 'Almacenamientos principales (Almacenamientos_principales.csv)',
        fileExtension: '.csv'
    },
    {
        optionValue: 'Almacenamiento_histórico_chapala',
        optionLabel: 'Almacenamiento histórico Chapala (Almacenamiento_histórico_chapala.csv)',
        fileExtension: '.csv'
    },
    {
        optionValue: 'Volumen_ag_asignado',
        optionLabel: 'Volumen Agua Guadalajara Asignado (Volumen_ag_asignado.csv)',
        fileExtension: '.csv'
    },
    {
        optionValue: 'Volumen_ag_autorizado',
        optionLabel: 'Volumen Agua Guadalajara Autorizado (Volumen_ag_autorizado.csv)',
        fileExtension: '.csv'
    },
    {
        optionValue: 'Volumen_ag_utilizado',
        optionLabel: 'Volumen Agua Guadalajara Utilizado (Volumen_ag_utilizado.csv)',
        fileExtension: '.csv'
    },
    {
        optionValue: 'Volumen_gt_asignado',
        optionLabel: 'Volumen Generación Tepuxtepec Asignado (Volumen_gt_asignado.csv)',
        fileExtension: '.csv'
    },
    {
        optionValue: 'Volumen_gt_autorizado',
        optionLabel: 'Volumen Generación Tepuxtepec Autorizado (Volumen_gt_autorizado.csv)',
        fileExtension: '.csv'
    },
    {
        optionValue: 'Volumen_gt_utilizado',
        optionLabel: 'Volumen Generación Tepuxtepec Utilizado (Volumen_gt_utilizado.csv)',
        fileExtension: '.csv'
    },
    {
        optionValue: 'Volumen_dr_asignado',
        optionLabel: 'Volumen Distrito de Riego Asignado (Volumen_dr_asignado.csv)',
        fileExtension: '.csv'
    },
    {
        optionValue: 'Volumen_dr_autorizado',
        optionLabel: 'Volumen Distrito de Riego Autorizado (Volumen_dr_autorizado.csv)',
        fileExtension: '.csv'
    },
    {
        optionValue: 'Volumen_dr_utilizado',
        optionLabel: 'Volumen Distrito de Riego Utilizado (Volumen_dr_utilizado.csv)',
        fileExtension: '.csv'
    },
    {
        optionValue: 'Volumen_pi_asignado',
        optionLabel: 'Volumen Pequeña Irrigación Asignado (Volumen_pi_asignado.csv)',
        fileExtension: '.csv'
    },
    {
        optionValue: 'Volumen_pi_autorizado',
        optionLabel: 'Volumen Pequeña Irrigación Autorizado (Volumen_pi_autorizado.csv)',
        fileExtension: '.csv'
    },
    {
        optionValue: 'Volumen_pi_utilizado',
        optionLabel: 'Volumen Pequeña Irrigación Utilizado (Volumen_pi_utilizado.csv)',
        fileExtension: '.csv'
    },
    {
        optionValue: 'Volumen_pi_1991_autorizado',
        optionLabel: 'Volumen Pequeña Irrigación Acuerdo 1991 Autorizado (Volumen_pi_autorizado.csv)',
        fileExtension: '.csv'
    },
    {
        optionValue: 'Volumen_pi_1991_utilizado',
        optionLabel: 'Volumen Pequeña Irrigación Acuerdo 1991 Utilizado (Volumen_pi_utilizado.csv)',
        fileExtension: '.csv'
    },
    {
        optionValue: 'Boletin',
        optionLabel: 'Boletín (*.pdf)',
        fileExtension: '.pdf'
    },
    {
        optionValue: 'Reglamentación',
        optionLabel: 'Reglamentación (*.pdf)',
        fileExtension: '.csv'
    },
    {
        optionValue: 'Archivo_calculo',
        optionLabel: 'Archivo de cálculo (*.xls, *.xlsx)',
        fileExtension: '.csv'
    },
    {
        optionValue: 'Presentación_covi',
        optionLabel: 'Presentación COVI (*.ppt, *.pptx)',
        fileExtension: '.csv'
    },
    {
        optionValue: 'Minuta_god',
        optionLabel: 'Minutas GOD (*.zip)',
        fileExtension: '.csv'
    }
];

function start() {
    var selTipoArchivo = $('#sel_tipo_archivo');

    for (var i = 0; i < uploadLabels.length; i++) {
        selTipoArchivo.append('<option value="' + uploadLabels[i].optionValue +
            '">' + uploadLabels[i].optionLabel + '</option>');
    }
}

start();

Dropzone.options.fileUpload = {
    maxFiles: maxFiles,

    accept: function (file, done) {
        done();
    },

    init: function () {
        var parent = this;

        this.on("maxfilesexceeded", function (file) {
            console.log('maxfilesexceeded: ' + file.name);
            mostrarMensajeResultado(RES_ERROR, MSG_MAX_FILES);
            maxFilesExceeded = true;
            return false;
        });

        this.on("addedfile", function (file) {
            if (!maxFilesExceeded) {
                if (!uploadAllowed && !confirm("¿Seguro que deseas subir el archivo?")) {
                    this.removeFile(file);
                    return false;
                } else {
                    uploadAllowed = true;

                    if (!evaluarExtension(file.name)) {
                        mostrarMensajeResultado(RES_ERROR, EXT_INVAL);
                        this.removeFile(file);
                        return false;
                    } else if (!evaluarNombre(file.name)) {
                        mostrarMensajeResultado(RES_ERROR, NOM_INVAL);
                        this.removeFile(file);
                        return false;
                    }
                }
            }
        });

        this.on("complete", function (file) {
            setTimeout(function () {
                mostrarMensajeResultado(RES_EXITO, MSJ_EXITO);
                maxFilesExceeded = false;
            }, 2000);
        });
    }
};

$(document).ready(function () {
    updateTipoArchivo();
});

// Establece el tipo de archivo a subir dependiendo del valor del select
$('#sel_tipo_archivo').change(function () {
    updateTipoArchivo();
});

function updateTipoArchivo() {
    var tipo = $('#sel_tipo_archivo').val();

    uploadAllowed = false;
    maxFilesExceeded = false;

    var tipoArchivo = $('#tipoArchivo');

    if (tipo === 'Boletin') {
        tipoArchivo.val('boletin');
    } else if (tipo === 'Reglamentación') {
        tipoArchivo.val('reglamentacion');
    } else if (tipo === 'Archivo_calculo') {
        tipoArchivo.val('archivo_calculo');
    } else if (tipo === 'Presentación_covi') {
        tipoArchivo.val('presentacion_covi');
    } else if (tipo === 'Minuta_god') {
        tipoArchivo.val('minuta_god');
    } else {
        tipoArchivo.val('datos');
    }
}

// Constantes
var RES_ERROR = 0;
var RES_EXITO = 1;
var EXT_INVAL = '<strong>Debes subir un archivo con la extensión esperada.</strong>';
var NOM_INVAL = '<strong>El nombre del archivo debe ser el indicado en la lista.</strong>';
var MSJ_EXITO = '<strong>El archivo fue subido correctamente.</strong>';
var MSJ_MAX_FILES = '<strong>Puedes subir máximo ' + maxFiles + ' archivos</strong>';

// Determina si la extension del archivo es correcta.
function evaluarExtension(nombreArchivo) {
    var nombreCorrecto = $('#sel_tipo_archivo').val();

    console.log(nombreCorrecto);

    if (nombreCorrecto === "Boletin"
        || nombreCorrecto === "Reglamentación") {
        return nombreArchivo.endsWith('.pdf');
    } else if (nombreCorrecto === "Archivo_calculo") {
        return nombreArchivo.endsWith('.xls') || nombreArchivo.endsWith('.xlsx');
    } else if (nombreCorrecto === "Presentación_covi") {
        return nombreArchivo.endsWith('.ppt') || nombreArchivo.endsWith('.pptx');
    } else if (nombreCorrecto === 'Minuta_god') {
        return nombreArchivo.endsWith('.zip');
    } else {
        return nombreArchivo.endsWith('.csv');
    }
}

// Determina si el nombre de archivo es correcto.
function evaluarNombre(nombreArchivo) {
    var nombreCorrecto = $('#sel_tipo_archivo').val();

    if (nombreCorrecto === "Boletin"
        || nombreCorrecto === "Reglamentación"
        || nombreCorrecto === "Archivo_calculo"
        || nombreCorrecto === "Presentación_covi"
        || nombreCorrecto === 'Minuta_god') {
        // Devuelve true si se trata de un archivo donde no se requiere 
        // coincidencia en el nombre
        return true;
    } else {
        // Aquí sí se evalúa que el nombre sea el esperado
        return removeFileExtension(nombreArchivo) === nombreCorrecto;
    }
}

// Elimina la extensión de un archivo conocido
function removeFileExtension(nombreArchivo) {
    return nombreArchivo
        .replace('.xlsx', '')
        .replace('.xls', '')
        .replace('.pdf', '')
        .replace('.zip', '')
        .replace('.csv', '');
}

// Muestra el mensaje correspondiente al resultado del intento de subir el archivo.
function mostrarMensajeResultado(resCode, mensaje) {
    var uploadResult = $('#uploadResult');

    if (resCode === RES_ERROR) {
        uploadResult.addClass('div-error');
    } else {
        uploadResult.addClass('div-exito');
    }

    uploadResult.html(mensaje);
    uploadResult.removeClass('hidden');

    setTimeout(function () {
        uploadResult.addClass('hidden');
        uploadResult.removeClass('div-exito');
        uploadResult.removeClass('div-error');
    }, 3000);
}