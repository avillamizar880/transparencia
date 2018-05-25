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


function fnEnviarCorreo(CodigoBPIN, idTipoAudiencia, asunto, numeroGrupo, destinatario) {
    var cuerpo = "";
    cuerpo = "CodigoBPIN=" + CodigoBPIN + "&destinatario=" + destinatario + "&idTipoAudiencia=" + idTipoAudiencia + "&numeroGrupo=" + numeroGrupo + "&asunto=" + asunto;
    ajaxPost("../../Views/General/EnvioCorreo_ajax", cuerpo, null, function (r) {
        var codigo_error = r.split("<||>")[0];
        var mensaje = r.split("<||>")[1];
        if (r.indexOf("<||>") != -1) {
            if (codigo_error == '0') {
                bootbox.alert("Correo enviado exitosamente!");

            } else {
                bootbox.alert(mensaje);
            }
        }
    }, function (r) {
        bootbox.alert(r.responseText);
    });

}

function cargaMenu(url, div) {
        var urlCompleta = "Views/" + url
        ajaxPost(urlCompleta, '', div, '', '');
  
}

function cargaMenuParams(url, div, params) {
    var urlCompleta = "Views/" + url
    ajaxPost(urlCompleta, { ParametroInicio: params }, div, '', '');
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
        win.focus();
    } else {
        $("#dialog").attr('title',"facebook");
        $("#dialog").html = " <p>Por favor permita los popups para este sitio y poder compartir el enlace en facebook</p>";
        $("#dialog").dialog();
    }
}

function fnFacebookInvitacion(url, CodigoBPIN, idTipoAudiencia, numeroGrupo) {
    var urlc = 'http://www.facebook.com/sharer.php?u=' + url + '?CodigoBPIN=' + CodigoBPIN + '&idTipoAudiencia=' + idTipoAudiencia + '&numeroGrupo=' + numeroGrupo
    fnFacebook(url);
}


function EliminarGrupoAuditor(bpinProyecto,idGrupo, idUsuario)
{
    bootbox.confirm({
        title: "Eliminar grupo auditor",
        message: "¿Está seguro que desea eliminar este GAC?",
        buttons: {
            confirm: {
                label: 'Eliminar'
            },
            cancel: {
                label: 'Cancelar'
            }
        },
        callback: function (result)
        {
            if (result == true)
            {
                if (idUsuario != "" && idUsuario != undefined)
                {
                    //usuario registrado en session
                    ajaxPost('../Views/GestionGAC/EliminarGac_ajax', { EliminarGac: idGrupo }, null, function (r)
                    {
                        if (r == "")
                        {
                                //accion exitosa
                                bootbox.alert("El gac seleccionado se eliminó satisfactoriamente.", function () {
                                    //recargar grupos
                                    obtGACProyecto(bpinProyecto, idUsuario);
                                });
                        }
                        else
                        {
                            var cod_error = r.split("<||>")[0];
                            var mensaje_error = r.split("<||>")[1];
                            bootbox.alert("Usted ya no pertenece al GAC");
                        }

                    }, function (e) {
                        bootbox.alert(e.responseText);
                    });
                }
                else //No se encuentra registrado
                {
                    bootbox.alert("Usted no cuenta con permiso para realizar esta operación en el sistema.\n Es posible que no se encuentre registrado en el sistema o su sesión a caducado.");
                }
            }
        }
    });
}



function fnVentanaSimple(url) {
    //poner un div para los mensajes en la pagina principal
    $("#dialog").attr('title',"Correo");
    $("#dialog").load(url).dialog();

}

function fnVentanaCorreo(url, CodigoBPIN, idTipoAudiencia, numeroGrupo) {
    //poner un div para los mensajes en la pagina principal
    //$.blockUI({
    //    message: "<h2>Enviando Correo</h2>",
    //    baseZ: 0
    //});
    //,
    //close: function (event, ui) { $.unblockUI(); }

    $("#dialog").attr('title', "Correo");
    $("#dialog").load(url + '?CodigoBPIN=' + CodigoBPIN + '&idTipoAudiencia=' + idTipoAudiencia + '&numeroGrupo=' + numeroGrupo).dialog(
         {
             height: 250, width: 440, closeOnEscape: true, modal:true
         }       );
   
}

function fnVentanaSimple(url, title) {
    //poner un div para los mensajes en la pagina principal
    $("#dialog").attr('title', title);
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
        var id_perfil = r.split("<||>")[2];
        var id_rol = r.split("<||>")[3];
        var nombre = r.split("<||>")[4].split(" ")[0];
        var estadoenc = r.split("<||>")[5].split(" ")[0];
        if (estado == '1') {
            $("#hdIdUsuario").val(id_usuario);
            //habilita menús
                $('#collapseLogin').attr('class', 'collapse');
                $('input[type=text],input[type=password]', $('#collapseLogin')).each(function (i, e) {
                    $(e).val("");
                });

                $(".LogIn").attr("menu",id_perfil);
                $(".LogIn").attr("nombre",nombre);
                validaSession();

                if (id_perfil == '1') {
                    $("#menuCiudadano").hide();
                    $("#menuAdmin").show();
                    //cargaMenu('Administracion/CategoriasAuditor', 'dvPrincipal');
                    goObtMenu('/Views/Administracion/CategoriasAuditor');
                    
                } else {
                    $("#menuAdmin").hide();
                    $("#menuCiudadano").show();
                    if (estadoenc != '1' && id_perfil=='2') {
                        goObtMenu('/Views/Caracterizacion/EncuestaParte1');
                    }else
                    {
                        var bpin = $("#hfidproyecto").val();
                        if (typeof bpin === 'undefined')
                        {
                            location.reload();
                        }
                        else
                        {
                            ajaxPost('../../Views/Proyectos/infoProyecto', { id_proyecto: bpin }, 'dvPrincipal', function (r) {
                                $(".detalleEncabezadoProy").show();
                            }, function (e) {
                                bootbox.alert(e.responseText);
                            });
                        }


                    }
                }
            } else {
            bootbox.alert("@Error: usuario no válido");
            }
        }

         }, function (r) {
             bootbox.alert(r.responseText);
    });
}


//redirecciona registro ciudadano
function nuevoUsuario() {
    goObtMenu('/Views/Usuarios/registroCiudadano');
}

//redirecciona recuperación contraseña
function olvidoClave() {
    ajaxPost('../Views/Usuarios/olvidoClave', null, 'dvPrincipal', function (r) {
          $('#collapseLogin').attr('class', 'collapse');


    }, function (e) {
        bootbox.alert(e.responseText);
    });


}

//redirecciona cambio clave
function cambioClave() {
    goObtMenu('/Views/Usuarios/cambioClave');
}

function CuentaUsu() {
    goObtMenu('/Views/Usuarios/perfilUsuario');
}


function actualizaDatos() {
    goObtMenu('/Views/Usuarios/actualizarDatos');

}

function validaSession() {
    if ($(".LogIn").attr("menu") == "X") {
        $("#menu-admin").hide();
        $("#menu-user").hide();
        $("#menu-tec").hide();
        $("#btnLogOut").hide();
        $("#brLogOut").hide();
    }
    else {
        $("#menu-user").show();
        $("#btnLogOut").show();
        $("#brLogOut").show();
        $("#btnLogIn").hide();
        $("#brLogIn").hide();
        $("#btnNewUsr").hide();
        if ($(".LogIn").attr("cantnotificaciones") != "0")
            $("#usrName").html($(".LogIn").attr("nombre") + " <span class=\"badge badge-primary\" >" + $(".LogIn").attr("cantnotificaciones") + "</span> " + "<span class=\"glyphicon glyphicon-menu-down\"></span>");
        else
            $("#usrName").html( $(".LogIn").attr("nombre") + "<span class=\"glyphicon glyphicon-menu-down\"></span>");
        $("#menu-admin").hide();
        $("#menu-tec").hide();

        //alert($(".LogIn").attr("menu"));
        if ($(".LogIn").attr("menu") == "1"){
            $("#menu-admin").show();
        }

        if ($(".LogIn").attr("menu") == "4") {
            $("#menu-tec").show();
        }

    
    }
}

function cambioAdmin() {
    $("#menuCiudadano").hide();
    $("#menuAdmin").show();
}

function cambioUser() {
    $("#menuCiudadano").show();
    $("#menuAdmin").hide();
}

function cerrarSesion() {
    goObtMenu('/Views/Usuarios/cerrarSesion');
}


function ifrmPDF(url) {
    $("#ifrmPDF").attr('src', url);
}


function resetearCampos(nomObj) {
    $('select,input[type=text],input[type=radio],textarea', $('#' + nomObj)).each(function (i, e) {
        var id_txt = $(e).attr("id");
        if (!$(e).hasClass('var_sesion')) {
            $(e).val("");
        }
    });

}

//abrir ventanas emergentes
function fnVentanaEmergente(url, titulo) {
    var win = window.open(url, '_blank');
    if (win) {
        win.focus();
    } else {
        $("#dialog").attr('title', titulo);
        $("#dialog").html = " <p>Por favor permita los popups para este sitio y poder abrir el enlace </p>";
        $("#dialog").dialog();
    }
}
