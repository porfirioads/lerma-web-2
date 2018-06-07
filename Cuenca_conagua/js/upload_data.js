// Este script controla el componente de subida de archivos del sistema.

var maxFilesExceeded = false;
var uploadAllowed = false;
var maxFiles = 100;

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
                //parent.removeAllFiles();
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

    console.log('sel_tipo_archivo change', tipo);

    var tipoArchivo = $('#tipoArchivo');

    if (tipo === 'Boletin') {
        tipoArchivo.val('boletin');
    } else if (tipo === 'Reglamentación') {
        tipoArchivo.val('reglamentacion');
    } else if (tipo === 'Lluvia_media_anual' || tipo === 'Escurrimiento_anual'
        || tipo === 'Volumenes_DR_PI' || tipo === 'Lluva_anual_estación') {
        tipoArchivo.val('datos');
    } else if (tipo === 'Archivo_calculo') {
        tipoArchivo.val('archivo_calculo');
    } else if (tipo === 'Presentación_covi') {
        tipoArchivo.val('presentacion_covi');
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

    if (nombreCorrecto === "Boletin"
        || nombreCorrecto === "Reglamentación") {
        return nombreArchivo.endsWith('.pdf');
    } else if (nombreCorrecto === "Archivo_calculo") {
        return nombreArchivo.endsWith('.xls') || nombreArchivo.endsWith('.xlsx');
    } else if (nombreCorrecto === "Presentación_covi") {
        return nombreArchivo.endsWith('.ppt') || nombreArchivo.endsWith('.pptx');
    } else {
        return nombreArchivo.endsWith('.xls') || nombreArchivo.endsWith('.xlsx');
    }
}

// Determina si el nombre de archivo es correcto.
function evaluarNombre(nombreArchivo) {
    var nombreCorrecto = $('#sel_tipo_archivo').val();

    if (nombreCorrecto === "Boletin"
        || nombreCorrecto === "Reglamentación"
        || nombreCorrecto === "Archivo_calculo"
        || nombreCorrecto === "Presentación_covi") {
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
        .replace('.pdf', '');
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