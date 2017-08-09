// Este script controla el componente de subida de archivos del sistema.

Dropzone.options.fileUpload = {
    maxFiles: 1,
    accept: function (file, done) {
        done();
    },
    init: function () {
        var parent = this;
        this.on("maxfilesexceeded", function (file) {
            this.removeAllFiles();
            this.addFile(file);
        });
        this.on("addedfile", function (file) {
            if (!confirm("¿Seguro que deseas subir el archivo?")) {
                this.removeFile(file);
                return false;
            } else {
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
        });
        this.on("complete", function (file) {
            setTimeout(function () {
                parent.removeAllFiles();
                mostrarMensajeResultado(RES_EXITO, MSJ_EXITO);
            }, 2000);
        });
    }
};

// Constantes
var RES_ERROR = 0;
var RES_EXITO = 1;
var EXT_INVAL = '<strong>Debes subir un archivo de Excel (.xls o .xlsx).</strong>';
var NOM_INVAL = '<strong>El nombre del archivo debe ser el indicado en la lista.</strong>';
var MSJ_EXITO = '<strong>El archivo fue subido correctamente.</strong>';

// Determina si la extension del archivo es correcta.
function evaluarExtension(nombreArchivo) {
    return nombreArchivo.endsWith('.xls') || nombreArchivo.endsWith('.xlsx');
}

// Determina si el nombre de archivo es correcto.
function evaluarNombre(nombreArchivo) {
    var nombreCorrecto = $('#sel_tipo_archivo').val();
    return nombreArchivo.replace('.xlsx', '').replace('.xls', '') == nombreCorrecto;
}

// Muestra el mensaje correspondiente al resultado del intento de subir el archivo.
function mostrarMensajeResultado(resCode, mensaje) {
    var uploadResult = $('#uploadResult');
    if (resCode == RES_ERROR) {
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