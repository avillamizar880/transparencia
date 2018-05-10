function isUrl(s) {
    var regexp = /(ftp|http|https):\/\/(\w+:{0,1}\w*@)?(\S+)(:[0-9]+)?(\/|\/([\w#!:.?+=&%@!\-\/]))?/
    return regexp.test(s);
}


function crear_enlace_interes(params) {
    ajaxPost('../Views/Capacitacion/admin_enlaces_ajax', params, null, function (r) {
        if (r.indexOf("<||>") != -1) {
            var errRes = r.split("<||>")[0];
            var mensRes = r.split("<||>")[1];
            if (errRes == '0') {
                bootbox.alert("Enlace guardado exitosamente");
            } else {
                bootbox.alert(mensRes);
            }
        }
    }, function (r) {
        bootbox.alert(r.responseText);
    });

}

function modif_enlace_interes(params) {


}

function listar_enlaces_interes(params) {
    var prueba = "";
    $.ajax({
        type: "POST",
        url: '../Views/Capacitacion/list_informacion_ajax',
        data: params,
        traditional: true,
        cache: false,
        dataType: "json",
        success: function (result) {
            var totalNumber = result.Head.totalNumber;
            var totalPages = result.Head.totalPages;
            var pagina = result.Head.pagesNumber;
            var itemfila=2;
            var contfila=0;
            var outTxt = "<h2>Enlaces de Interés</h2>";
            
            $.each(result.Head.dtRecursos, function (i, item) {
                if (contfila == 0) {
                    outTxt += "<div class=\"row\">";
                }
                   outTxt += "<div class=\"col-sm-6\">";
                   outTxt += "<div class=\"card card-block\">";
                   outTxt += "<a role=\"button\" enlace=\"" + item.rutaUrl + "\" class=\"card-link external\">";
                   outTxt += "<h4 class=\"card-title\"><span class=\"glyphicon glyphicon-new-window\"></span>" + item.titulo + "</h4>";
                   outTxt += "<p class=\"card-text\">" + item.descripcion + "</p>";
                   outTxt += "</a>";
                   outTxt += "</div></div>";
                   contfila += 1;
                   if (contfila == itemfila) {
                       outTxt += "</div>";
                       contfila = 0;
                    }
            });
            $("#tab_enlaces").html(outTxt);
            dibujarPaginacion(pagina, totalNumber, totalPages);
            configuraEnlacesExternos();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            bootbox.alert(textStatus + ": " + XMLHttpRequest.responseText);
        }

    });
}

function dibujarPaginacion(actual, totalNumber, totalPag) {
    var pag_actual = parseInt(actual);
    var pagesHTML = '';
    var cant_por_linea = 10;
    var contenidopreview = "";
    var contenidoPaginas = "";
    var contenidoNext = "";

    //calculos
    var cociente = Math.floor(pag_actual / cant_por_linea);
    var residuo = pag_actual % cant_por_linea;
    var inicio = 1;
    if (residuo == 0) {
        inicio = (pag_actual - cant_por_linea) + 1;
    } else {
        inicio = (cociente * cant_por_linea) + 1;
    }

    var fin = inicio + (cant_por_linea - 1);
    if (totalPag < cant_por_linea) {
        fin = totalPag;
    }

    if (pag_actual > cant_por_linea && totalPag >= cant_por_linea) {
         contenidopreview = '<li><a id="page_left" data-page=' + inicio-cant_por_linea +' aria-label="Previous"><span aria-hidden="true">&laquo;</span></a></li>';
    }

    for (var i = inicio; i <= fin; i++) {
        if (i == pag_actual) {
            contenidoPaginas += '<li data-page=' + i + '>' + '<a class="pag_actual">' + i + '</a></li>';
        } else {
              contenidoPaginas += '<li role="button" class="page_left" data-page=' + i + '>' + '<a href="#">' + i + '</a></li>';
        }
    }

    if (pag_actual < totalPag) {
        if ((totalPag - pag_actual) > cant_por_linea) {
            contenidoNext = '<li><a id="page_right" data-page=' + fin + 1 + ' aria-label="Next"><span aria-hidden="true">&raquo;</span></a></li>';
        }
    }


    if (totalPag > 1) {
        $("#divPagFichas").show();
        $("#paginador").html("");
        $("#paginador").html(contenidopreview + contenidoPaginas + contenidoNext);
    } else $("#divPagFichas").hide();


    $('#page_right,#page_left,.page_left').bind('click', function () {
        pagina_actual = $(this).attr("data-page");
        var params = {
            pagina: pagina_actual,
            tipo: "3"
        };
        listar_enlaces_interes(params);
    });

}

function configuraEnlacesExternos() {
    $("a.external").bind('click', function () {
        var url = $(this).attr("enlace");
        var win = window.open(url, '_blank');
        if (win) {
            win.focus();
        } else {
            $("#dialog").attr('title', "Enlace Interes");
            $("#dialog").html = " <p>Por favor permita los popups para este sitio y poder abrir el enlace </p>";
            $("#dialog").dialog();
        }

    });

}

function crear_videos_institucionales(params) {
    ajaxPost('../Views/Capacitacion/admin_enlaces_ajax', params, null, function (r) {
        if (r.indexOf("<||>") != -1) {
            var errRes = r.split("<||>")[0];
            var mensRes = r.split("<||>")[1];
            if (errRes == '0') {
                bootbox.alert("Video guardado exitosamente");
            } else {
                bootbox.alert(mensRes);
            }
        }
    }, function (r) {
        bootbox.alert(r.responseText);
    });

}

function crear_guias() {
    var opc = "";
    var rutaImagen = $("#btnNewAdjuntoCompromiso-1").val().split("\\");
    if (rutaImagen == "") {
        bootbox.alert("Debe adjuntar un archivo .pdf");

    } else {
        $("#btnNewAdjuntoCompromiso-1").fileinput("upload");
    }
}

function validarCamposObligatorios(divcontenedor) {
    //validar campos obligatorios
    var formularioOK = true;
    var camposReq = "";
    $(".alert-danger").hide();
    $('.required', $('#' + divcontenedor + '')).each(function (i, e) {
        var id_txt = $(e).attr("for");
        if ($("#" + id_txt).val() == "" || $('#' + id_txt + ' option:selected').val() == "0") {
            camposReq += "[" + id_txt + "]";
            $("#error_" + id_txt).show();
            formularioOK = false;
        } else {
            $("#error_" + id_txt).hide();
        }
    });
    return formularioOK;

}