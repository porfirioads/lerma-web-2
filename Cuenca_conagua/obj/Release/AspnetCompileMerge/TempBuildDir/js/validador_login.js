// Este script realiza la validación del login de un usuario, mostrando mensajes
// cuando hay errores o falta información por ser ingresada.

$(document).ready(function () {
    var txtUsuario = $('#txtUsuario');
    var txtPassword = $('#txtPassword');
    var divErrorUsuario = $('#divErrorUsuario');
    var divErrorPassword = $('#divErrorPassword');
    var divErrorLogin = $('#divErrorLogin');
    var btnIniciarSesion = $('#btnIniciarSesion');
    var formLogin = $('#formLogin');

    // Evento que ocurre antes de enviar el formulario para validar los datos
    formLogin.bind('submit', function (event) {
        var usuarioCorrecto = validarUsuarioEmpty();
        var passwordCorrecto = validarPasswordEmpty();
        if (!usuarioCorrecto || !passwordCorrecto) {
            return false;
        }
    });

    // Evento que ocurre cuando el elemento txtUsuario adquiere el foco.
    txtUsuario.focus(function () {
        txtUsuario.select();
        if (isVisible(divErrorUsuario)) {
            divErrorUsuario.toggle("fast");
        }
        if (isVisible(divErrorLogin)) {
            divErrorLogin.toggle("fast");
        }
    });

    // Evento que ocurre cuando el elemento txtUsuario pierde el foco.
    txtUsuario.blur(function () {
        validarUsuarioEmpty();
    });

    // Evento que ocurre cuando el elemento txtPassword adquiere el foco.
    txtPassword.focus(function () {
        txtPassword.select();
        if (isVisible(divErrorPassword)) {
            divErrorPassword.toggle("fast");
        }
        if (isVisible(divErrorLogin)) {
            divErrorLogin.toggle("fast");
        }
    });

    // Evento que ocurre cuando el elemento divErrorPassword pierde el foco.
    txtPassword.blur(function () {
        validarPasswordEmpty();
    });

    // Valida si el campo de usuario esta vacio.
    function validarUsuarioEmpty() {
        if (txtUsuario.val() == "") {
            if (!isVisible(divErrorUsuario)) {
                divErrorUsuario.toggle("fast");
            }
            return false;
        }
        return true;
    }

    // Valida si el campo de password esta vacio.
    function validarPasswordEmpty() {
        if (txtPassword.val() == "") {
            if (!isVisible(divErrorPassword)) {
                divErrorPassword.toggle("fast");
            }
            return false;
        }
        return true;
    }

    // Determina si un elemento esta visible o no.
    function isVisible(elemento) {
        return elemento.is(':visible');
    }
});