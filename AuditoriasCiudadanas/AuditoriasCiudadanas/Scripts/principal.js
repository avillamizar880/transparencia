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

////validación de correo electrónico
//function validaEmail(cadena) {
//    if (cadena.match(/^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$/)) {
//        return true;
//    } else {
//        return false;
//    }
//}


function fnEnviarCorreo() {
    var cuerpo = "";
    cuerpo = "cuerpo=" + $("#txtArea").val() + "&destinatario=" + $("#txtDestinatario").val() + "&asunto=" + $("#txtAsunto").val();
    ajaxPost("Views/General/EnvioCorreo.aspx", cuerpo, null, '', '');

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
        $("<div id='dialog' title='Facebook'>  <p>Por favor permita los popups para este sitio y poder compartir el enlace en facebook</p></div>").dialog();
    }
}

function fnVentanaSimple(url) {
//poner un div para los mensajes en la pagina principal
    $("<div id='dialog' title='Correo'></div>").load(url).dialog();

}