//$('.alphaNum').blur(function () {
//    if (this.value.match(/[^a-zA-Z0-9\sáéíóúñÁÉÍÓÚÑäëïöüÿÄËÏÖÜ]/g)) {
//        this.value = this.value.replace(/[^a-zA-Z0-9\sáéíóúñÁÉÍÓÚÑäëïöüÿÄËÏÖÜ]/g, '');
//    }
//});

//$('.alphaNumSinEspacio').blur(function () {
//    if (this.value.match(/[^a-zA-Z0-9\sáéíóúñÁÉÍÓÚÑäëïöüÿÄËÏÖÜ]/g)) {
//        this.value = this.value.replace(/[^a-zA-Z0-9\sáéíóúñÁÉÍÓÚÑäëïöüÿÄËÏÖÜ]/g, '');
//    }
//    var valor = this.value.replace(/[\s]/g, '');
//    this.value = valor;
//});

//$('.mayusc').css("text-transform", "uppercase").blur(function () {
//    this.value = this.value.toUpperCase();
//});
//$('.numeric').numeric({ decimal: false, negative: false });
//$('.numericDec').numeric({ decimal: ",", negative: false });

function encodeRFC5987ValueChars(str) {
    return encodeURIComponent(str).replace(/['()]/g, escape).replace(/\*/g, '%2A').replace(/%(?:7C|60|5E)/g, unescape);
}

//validación de correo electrónico
function validaEmail(cadena) {
    if (cadena.match(/^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$/)) {
        return true;
    } else {
        return false;
    }
}


function fnEnviarCorreo(cuerpo, asunto, destinatario) {
    var cuerpo = "";
    //if (tinymce)
    //{ tinymce.triggerSave(); }
    //alert(tinymce.get('#txtArea').getContent());
    alert(cuerpo);
    cuerpo = "cuerpo=" + cuerpo + "&destinatario=" + asunto + "&asunto=" + destinatario;
    ajaxPost("../../Views/General/EnvioCorreo", cuerpo, null, '', '');

}

function cargaMenu(url, div) {
        var urlCompleta = "Views/" + url
        ajaxPost(urlCompleta, '', div, '', '');
  
}

function goObtMenu(urlOpc) {
    var params = "";
    var capa = "dvPrincipal";
    var prePost = "";
    var posPost = "";
    var errorPost = "";
    //Si desea personalizar el menu se recomienda usar la urlOpc como caso y llenar las variables prePost, postPost y errorPost
    ajaxPost(urlOpc, params, capa, eval(posPost), eval(prePost), eval(errorPost));
}

function fnFacebook(url){
    var win = window.open(url, '_blank');
    if (win) {
        //Browser has allowed it to be opened
        win.focus();
    } else {
        //Browser has blocked it
        //alert('Por favor permita los popups para este sitio');

        //poner un div para los mensajes en la pagina principal
        $("#dialog").attr('title',"facebook");
        $("#dialog").html = " <p>Por favor permita los popups para este sitio y poder compartir el enlace en facebook</p>";
        $("#dialog").dialog();
    }
}

function fnVentanaSimple(url) {
    //poner un div para los mensajes en la pagina principal
    $("#dialog").attr('title',"Correo");
    $("#dialog").load(url).dialog();

}

function fnVentanaPdf(nombre) {
    //poner un div para los mensajes en la pagina principal

    var cuerpo = "";
    cuerpo = "nombre=" + nombre ;
    ajaxPost("/Views/General/CreatePDF", cuerpo, null, '', '');

    var win = window.open(url, '_blank');
    if (win) {
        //Browser has allowed it to be opened
        win.focus();
    } else {
        //Browser has blocked it
        //alert('Por favor permita los popups para este sitio');

        //poner un div para los mensajes en la pagina principal
        $("#dialog").attr('title',"Pdf");
        $("#dialog").html = " <p>Por favor permita los popups para este sitio y poder descargar el documento</p>";
        $("#dialog").dialog();
    }
}

//login usuario
function validaLogin() {
    var email = $("#userName").val();
    var clave = $("#pass").val();
    var params = {email:email,clave:clave}
    ajaxPost('/Views/Usuarios/validaLogin', params, null, function (r) {
        if (r.indexOf("<||>") != -1) {
        var estado = r.split("<||>")[0];
        var id_usuario = r.split("<||>")[1];
            if (estado == '1') {
                //habilita menús
                alert("@usuario_activo");
            } else {
                alert(mensRes);
            }
        }

         }, function (r) {
        alert(r.responseText);
    });
}

//redirecciona registro ciudadano
function nuevoUsuario() {
    goObtMenu('/Views/Usuarios/registroCiudadano', 'dvPrincipal');
}

//redirecciona recuperación contraseña
function olvidoClave() {
    goObtMenu('/Views/Usuarios/restablecerPassword');

}

//redirecciona cambio clave
function cambioClave() {
    goObtMenu('/Views/Usuarios/cambioClave');
}
