$('.alphaNum').blur(function () {
    if (this.value.match(/[^a-zA-Z0-9\sáéíóúñÁÉÍÓÚÑäëïöüÿÄËÏÖÜ]/g)) {
        this.value = this.value.replace(/[^a-zA-Z0-9\sáéíóúñÁÉÍÓÚÑäëïöüÿÄËÏÖÜ]/g, '');
    }
});

$('.alphaNumSinEspacio').blur(function () {
    if (this.value.match(/[^a-zA-Z0-9\sáéíóúñÁÉÍÓÚÑäëïöüÿÄËÏÖÜ]/g)) {
        this.value = this.value.replace(/[^a-zA-Z0-9\sáéíóúñÁÉÍÓÚÑäëïöüÿÄËÏÖÜ]/g, '');
    }
    var valor = this.value.replace(/[\s]/g, '');
    this.value = valor;
});

$('.mayusc').css("text-transform", "uppercase").blur(function () {
    this.value = this.value.toUpperCase();
});
$('.numeric').numeric({ decimal: false, negative: false });
$('.numericDec').numeric({ decimal: ",", negative: false });

//validación de correo electrónico
function validaEmail(cadena) {
    if (cadena.match(/^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$/)) {
        return true;
    } else {
        return false;
    }
}

function cargaMenu(url, div) {
        var urlCompleta = "Views/" + url
        ajaxPost(urlCompleta, '', div, '', '');
  
}
