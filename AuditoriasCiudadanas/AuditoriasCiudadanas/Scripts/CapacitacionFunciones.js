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
                bootbox.alert("Enlace guardado exitosamente", function () {
                    reload_enlaces(1,volver_listado_admin('divInfoEnlace', 'divContEnlaces'));
                });
            } else {
                bootbox.alert(mensRes);
            }
        }
    }, function (r) {
        bootbox.alert(r.responseText);
    });

}

function modif_enlace_interes(params) {
    ajaxPost('../Views/Capacitacion/admin_enlaces_ajax', params, null, function (r) {
        if (r.indexOf("<||>") != -1) {
            var errRes = r.split("<||>")[0];
            var mensRes = r.split("<||>")[1];
            if (errRes == '0') {
                bootbox.alert("Modificacion realizada exitosamente", function () {
                    var pag_actual = $('#paginador').find(".pag_actual").text();
                    reload_enlaces(pag_actual,volver_listado_admin('divInfoEnlace', 'divContEnlaces'));
                    
                });
            } else {
                bootbox.alert(mensRes);
            }
        }
    }, function (r) {
        bootbox.alert(r.responseText);
    });

}

function listar_enlaces_interes(params, funEspecial) {
    $.ajax({
        type: "POST",
        url: '../Views/Capacitacion/list_informacion_ajax',
        data: params,
        traditional: true,
        cache: false,
        dataType: "json",
        success: function (result) {
            var tipoRecurso = result.Head.tipoRecurso;
            var totalNumber = result.Head.totalNumber;
            var totalPages = result.Head.totalPages;
            var pagina = result.Head.pagesNumber;
            var itemfila=2;
            var contfila = 0;
            var nom_contenedor="";
            var nom_padre = "";

            if (tipoRecurso == "3") {
                itemfila = 2;
                nom_contenedor = "paginador";
                nom_padre = "divPagFichas";
                //enlaces de interes
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
                dibujarPaginacion(pagina, totalNumber, totalPages, nom_contenedor, nom_padre, tipoRecurso);
                configuraEnlacesExternos();
            }
            if ((tipoRecurso.indexOf("1") > -1) || (tipoRecurso.indexOf("2") > -1)) {
                //guias y manuales
                itemfila = 3;
                nom_contenedor = "paginadorGuias";
                nom_padre = "divPagGuias";
                var outTxt = "<h2>Guías y Manuales</h2>";
                $.each(result.Head.dtRecursos, function (i, item) {
                    if (contfila == 0) {
                        outTxt += "<div class=\"row\">";
                    }
                    outTxt += "<div class=\"col-sm-4\">";
                    outTxt += "<div class=\"card card-block\">";
                    outTxt += "<a role=\"button\" enlace=\"" + item.rutaUrl + "\" class=\"card-link external\">";
                    outTxt += "<h4 class=\"card-title\"><span class=\"glyphicon glyphicon-save-file\"></span>" + item.titulo + "</h4>";
                    outTxt += "<p class=\"card-text\">" + item.descripcion + "</p>";
                    outTxt += "</a>";
                    outTxt += "</div></div>";
                    contfila += 1;
                    if (contfila == itemfila) {
                        outTxt += "</div>";
                        contfila = 0;
                    }
                });
                $("#tab_guias").html(outTxt);
                configuraEnlacesExternos();
                dibujarPaginacion(pagina, totalNumber, totalPages, nom_contenedor, nom_padre, tipoRecurso);
            }
            if (tipoRecurso == "4") {
                //videos institucionales
                itemfila = 2;
                nom_contenedor = "paginadorVideos";
                nom_padre = "divPagVideos";
                var outTxt = "<h2>Videos institucionales</h2>";
                $.each(result.Head.dtRecursos, function (i, item) {
                    if (contfila == 0) {
                        outTxt += "<div class=\"row\">";
                    }
                    outTxt += "<div class=\"col-sm-6\">";
                    outTxt += "<div class=\"thumbnail \">";
                    var new_ruta = "";
                    new_ruta = formatoVideo(item.rutaUrl);
                    outTxt += "<iframe id=\"player_\"" + i + "\" src=\"" + new_ruta + "\" width=\"399\" height=\"225\" style=\"border: 0;\" webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe>";
                    outTxt+="<div class=\"caption\">";
                    outTxt += "<h3><a role=\"button\" data-titulo=\"" + item.titulo + "\" data-src=\"" + new_ruta + "\" class=\"enlace_img\" role=\"button\" data-toggle=\"modal\" data-target=\"#myModal\">" + item.titulo + "</a></h3>";
                    outTxt+="<p>" + item.descripcion + "</p>";
                    outTxt+="</div>";
                    outTxt += "</div></div>";
                    contfila += 1;
                    if (contfila == itemfila) {
                        outTxt += "</div>";
                        contfila = 0;
                    }
                });
                $("#tab_videos").html(outTxt);
                configuraEnlacesExternos();
                $('.enlace_img').on('click', function (e) {
                    var url_video = $(this).attr("data-src");
                    var titulo_video = $(this).attr("data-titulo");
                    var str = "<iframe src=\"" + url_video + "\" width=\"854\" height=\"481\" style=\"border: 0;\" webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe>";
                    $("#myModalLabel").html(titulo_video);
                    $('#img-modal').html(str);
                });

                dibujarPaginacion(pagina, totalNumber, totalPages, nom_contenedor, nom_padre, tipoRecurso);
            }
            if (tipoRecurso == "5") {
                //capacitaciones
                itemfila = 2;

                //nom_contenedor = "paginadorVideos";
                //nom_padre = "divPagVideos";
                var outTxt = "<h2>Capacitaciones</h2>";
                $.each(result.Head.dtRecursos, function (i, item) {
                    if (contfila == 0) {
                        outTxt += "<div class=\"row\">";
                    }
                    outTxt += "<div class=\"col-sm-4\">";
                    outTxt += "<div class=\"thumbnail\">";
                    //outTxt += "<img src=\"img/thumbVideo.jpg\" alt=\"...\"/>";
                    outTxt += "<div class=\"caption\">";
                    outTxt += "<h3>" + item.TituloCapacitacion + "</h3>";
                    outTxt += "<p class=\"card-text\">" + item.DetalleCapacitacion + "</p>";
                    outTxt += "<div class=\"btn btn-default\"><a class=\"btn btn-primary\" role=\"button\" onclick=\"CursarCapt(" + item.idCap + ");\" title=\"Ver el contenido del curso\"><span class=\"glyphicon glyphicon-log-in\"></span> Cursar</a></div>";
                    outTxt += "</div></div></div>";
                    contfila += 1;
                    if (contfila == itemfila) {
                        outTxt += "</div>";
                        contfila = 0;
                    }
                });
                $("#tab_capacitaciones").html(outTxt);
                configuraEnlacesExternos();
            }
            //ejecutar funcion si existe
            if ($.isFunction(funEspecial)) {
                funEspecial();
            }

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            bootbox.alert(textStatus + ": " + XMLHttpRequest.responseText);
        }

    });
}

function formatoVideo(urlvideo) {
    var new_ruta = urlvideo;
    //correcto:www.youtube.com/embed/XQEBzauVIlA
    //https://youtu.be/sHjTnUeL27Y
    //https://www.youtube.com/watch?v=htDM02v3nUg
    if (urlvideo.indexOf("youtu.be") > -1) {
        new_ruta = urlvideo.replace("youtu.be", "youtube.com");
        if (new_ruta.indexOf("watch") > -1) {
            new_ruta = new_ruta.replace("watch?v=", "embed/");
        } else {
            var pos = new_ruta.lastIndexOf("/");
            new_ruta = new_ruta.substring(0,pos) + "/embed/" + new_ruta.substring(pos + 1);
        }
        
    }

    if (urlvideo.indexOf("youtube") > -1 && urlvideo.indexOf("watch") > -1) {
        new_ruta = urlvideo.replace("watch?v=", "embed/");
    }

    //url cliente https://vimeo.com/channels/41579/149197074
    //correcto: https://player.vimeo.com/video/215912238
    if (urlvideo.indexOf("vimeo") > -1) {
        var pos = new_ruta.lastIndexOf("/");
        new_ruta = new_ruta = "https://player.vimeo.com/video/" + new_ruta.substring(pos + 1);
    }

    if (urlvideo.indexOf("&") > -1) {
        var pos = urlvideo.indexOf("&");
        new_ruta = new_ruta.substring(1, pos);
    }

    return new_ruta;

}

function dibujarPaginacion(actual, totalNumber, totalPag,nom_contenedor,nom_padre,tipo_recurso) {
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
         contenidopreview = '<li><a id="page_left" data-page=' + Number(inicio-cant_por_linea) +' aria-label="Previous"><span aria-hidden="true">&laquo;</span></a></li>';
    }

    for (var i = inicio; i <= fin; i++) {
        if (i == pag_actual) {
            contenidoPaginas += '<li data-page=' + i + '>' + '<a class="pag_actual">' + i + '</a></li>';
        } else {
              contenidoPaginas += '<li role="button" class="page_left" data-page=' + i + '>' + '<a href="#">' + i + '</a></li>';
        }
    }

    if (pag_actual < totalPag) {
        if ((totalPag - pag_actual) >= cant_por_linea) {
            contenidoNext = '<li><a id="page_right" data-page=' + Number(fin + 1) + ' aria-label="Next"><span aria-hidden="true">&raquo;</span></a></li>';
        }
    }


    if (totalPag > 1) {
        $('#' + nom_padre + '').show();
        $('#' + nom_contenedor + '').html("");
        $('#' + nom_contenedor + '').html(contenidopreview + contenidoPaginas + contenidoNext);
    } else $('#' + nom_padre + '').hide();


    $('#page_right,#page_left,.page_left').bind('click', function () {
        debugger
        pagina_actual = $(this).attr("data-page");
        var params = {
            pagina: pagina_actual,
            tipo: tipo_recurso
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
                bootbox.alert("Video guardado exitosamente", function () {
                    reload_videos(1, volver_listado_admin('divInfoEnlace', 'divContVideos'));
                });
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



function CrearEvaluacion(idcapacita) {
    ajaxPost('../Views/Valoracion/configuraEncuestas?opc=3', { idcapacitacion: idcapacita }, 'divCodPlantilla', function (r) {
        cargaPlantillasEva();
    }, function (e) {
        bootbox.alert(e.responseText);
    });

}

function cargaPlantillasEva() {
    $("#divInfoRecursos").slideUp(function () {
        $("#divPlantillasProy").slideDown(function () {
           // $(".detalleEncabezadoProy").hide();
             $("#divPlantillasProy").show();

        });
    });
}

function volver_listado_capacitacion() {
    $("#divInfoRecursos").slideDown(function () {
        $("#divPlantillasProy").slideUp(function () {
            $("#divPlantillasProy").hide();
        });
    });

}

function list_recursos_admin(params) {
    $.ajax({
        type: "POST",
        url: '../Views/Capacitacion/list_informacion_ajax',
        data: params,
        traditional: true,
        cache: false,
        dataType: "json",
        success: function (result) {
            var tipoRecurso = result.Head.tipoRecurso;
            var totalNumber = result.Head.totalNumber;
            var totalPages = result.Head.totalPages;
            var pagina = result.Head.pagesNumber;
            var itemfila=2;
            var contfila = 0;
            var nom_contenedor="";
            var nom_padre = "";

            if (tipoRecurso == "3") {
                itemfila = 3;
                nom_contenedor = "paginador";
                nom_padre = "divPagEnlaces";
                //enlaces de interes
                var outTxt = "";
            
                $.each(result.Head.dtRecursos, function (i, item) {
                    if (contfila == 0) {
                        outTxt += "<div class=\"row\">";
                    }
                    outTxt += "<div class=\"col-md-4\">";
                    outTxt += "<div class=\"panel panel-capacitacion\">";
                    outTxt += "<div class=\"panel-heading\">" + item.titulo + "</div>";
                    outTxt += "<div class=\"panel-body\">";
                    outTxt += "<div style=\"display:block;\">" +item.descripcion + "</div>";
                    outTxt += "<a href=\"#\" enlace=\"" + item.rutaUrl + "\" class=\"btn btn-info external\"> Ver enlace</a>";
                    outTxt += "</div>";
                    outTxt += "<div class=\"panel-footer\">";
                    outTxt += "<a role=\"button\" onclick=\"editar_enlace('" + item.idRecurso + "')\" class=\"btn btn-default\"> <span class=\"glyphicon glyphicon-edit\"></span> Editar</a>";
                    outTxt += "<a role=\"button\" onclick=\"eliminar_enlace('" + item.idRecurso + "')\" class=\"btn btn-default\"> <span class=\"glyphicon glyphicon-trash\"></span> Eliminar</a>";
                    outTxt += "</div>";
                    outTxt += "</div>";
                    outTxt += "</div>";


                       contfila += 1;
                       if (contfila == itemfila) {
                           outTxt += "</div>";
                           contfila = 0;
                        }
                });
                $("#divListadoEnlaces").html(outTxt);
                dibujarPagAdminRecursos(pagina, totalNumber, totalPages, nom_contenedor, nom_padre, tipoRecurso);
                configuraEnlacesExternos();
            }
            if ((tipoRecurso.indexOf("1") > -1) || (tipoRecurso.indexOf("2") > -1)) {
                //guias y manuales
                itemfila = 3;
                nom_contenedor = "paginadorGuias";
                nom_padre = "divPagGuias";
                var outTxt = "<h2>Guías y Manuales</h2>";
                $.each(result.Head.dtRecursos, function (i, item) {
                    if (contfila == 0) {
                        outTxt += "<div class=\"row\">";
                    }
                    outTxt += "<div class=\"col-sm-4\">";
                    outTxt += "<div class=\"card card-block\">";
                    outTxt += "<a role=\"button\" enlace=\"" + item.rutaUrl + "\" class=\"card-link external\">";
                    outTxt += "<h4 class=\"card-title\"><span class=\"glyphicon glyphicon-save-file\"></span>" + item.titulo + "</h4>";
                    outTxt += "<p class=\"card-text\">" + item.descripcion + "</p>";
                    outTxt += "</a>";
                    outTxt += "</div></div>";
                    contfila += 1;
                    if (contfila == itemfila) {
                        outTxt += "</div>";
                        contfila = 0;
                    }
                });
                $("#tab_guias").html(outTxt);
                configuraEnlacesExternos();
                dibujarPagAdminRecursos(pagina, totalNumber, totalPages, nom_contenedor, nom_padre, tipoRecurso);
            }
            if (tipoRecurso == "4") {
                //videos institucionales
                itemfila = 3;
                nom_contenedor = "paginador";
                nom_padre = "divPagVideos";
                var outTxt = "";
                $.each(result.Head.dtRecursos, function (i, item) {
                    if (contfila == 0) {
                        outTxt += "<div class=\"row\">";
                    }
                        outTxt += "<div class=\"col-md-4\">";
                        outTxt += "<div class=\"panel panel-capacitacion\">";
                        outTxt += "<div class=\"panel-heading\">" + item.titulo +"</div>";
                        outTxt += "<div class=\"panel-body\">";
                        outTxt += "<div class=\"videoContainer\">";
                        var new_ruta = "";
                        new_ruta = formatoVideo(item.rutaUrl);
                        outTxt += "<iframe id=\"player_\"" + i + "\" src=\"" + new_ruta + "\" width=\"326\" height=\"147\" data-src=\"" + new_ruta + "\" class=\"enlace_img\" style=\"border: 0;\" data-toggle=\"modal\" data-target=\"#myModal\" webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe>";
                        outTxt += "</div>";
                        outTxt += "<span>" + item.descripcion + "</span>";
                        outTxt += "<a role=\"button\" data-titulo=\"" + item.titulo + "\" data-src=\"" + new_ruta + "\" class=\"enlace_img\" role=\"button\" data-toggle=\"modal\" data-target=\"#myModal\"> [Ampliar] </a>";
                        outTxt += "</div>";
                        outTxt += "<div class=\"panel-footer\">";
                        outTxt += "<a role=\"button\" onclick=\"editar_video('" + item.idRecurso + "')\" class=\"btn btn-default\"> <span class=\"glyphicon glyphicon-edit\"></span> Editar</a>";
                        outTxt += "<a role=\"button\" onclick=\"eliminar_video('" + item.idRecurso + "')\" class=\"btn btn-default\"> <span class=\"glyphicon glyphicon-trash\"></span> Eliminar</a>";
                        outTxt += "</div>";
                        outTxt += "</div>";
                        outTxt += "</div>";


                    contfila += 1;
                    if (contfila == itemfila) {
                        outTxt += "</div>";
                        contfila = 0;
                    }
                });
                $("#divListadoVideos").html(outTxt);
                configuraEnlacesExternos();
                $('.enlace_img').on('click', function (e) {
                    var url_video = $(this).attr("data-src");
                    var titulo_video = $(this).attr("data-titulo");
                    var str = "<iframe src=\"" + url_video + "\" width=\"854\" height=\"481\" style=\"border: 0;\" webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe>";
                    $("#myModalLabel").html(titulo_video);
                    $('#img-modal').html(str);
                });

                dibujarPagAdminRecursos(pagina, totalNumber, totalPages, nom_contenedor, nom_padre, tipoRecurso);
            }


        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            bootbox.alert(textStatus + ": " + XMLHttpRequest.responseText);
        }

    });
}

function cargaPlantillasAdmin(objOcultar,objMostrar) {
    $("#" + objOcultar).slideUp(function () {
        $("#" + objMostrar).slideDown(function () {

            $("#" + objMostrar).show();

        });
    });
}

function volver_listado_admin(objOcultar, objMostrar) {
    $("#" + objMostrar).slideDown(function () {
        $("#" + objOcultar).slideUp(function () {
            $("#" + objOcultar).hide();
        });
    });

}

function editar_enlace(id_recurso) {
    $("#hdIdRecurso").val(id_recurso);
    var params = {
        id_recurso: id_recurso,
        opc:"OBT"
    };
    $.ajax({
        type: "POST",
        url: '../Views/Capacitacion/admin_enlaces_ajax',
        data: params,
        traditional: true,
        cache: false,
        dataType: "json",
        success: function (result) {
            debugger
            if (result.Head.length > 0) {
                var encabezado = result.Head[0];
                $("#txtTitulo").val(encabezado[0].titulo);
                $("#txtDescripcion").val(encabezado[0].descripcion);
                $("#txtEnlace").val(encabezado[0].rutaUrl);
                cargaPlantillasAdmin("divContEnlaces", "divInfoEnlace");

            }

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            bootbox.alert(textStatus + ": " + XMLHttpRequest.responseText);
        }

    });

    //modif_enlace_interes(params);
}

function reload_enlaces(pag_actual, funEspecial) {
    var pagina = 1;
    if (pag_actual > 0 && pag_actual != undefined) {
        pagina = pag_actual;
    }
    var params = {
        pagina: pagina,
        tipo: "3"
    };
    list_recursos_admin(params, funEspecial);
}

function dibujarPagAdminRecursos(actual, totalNumber, totalPag, nom_contenedor, nom_padre, tipo_recurso) {
    debugger
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
        contenidopreview = '<li><a id="page_left" data-page=' + Number(inicio - cant_por_linea) + ' aria-label="Previous"><span aria-hidden="true">&laquo;</span></a></li>';
    }

    for (var i = inicio; i <= fin; i++) {
        if (i == pag_actual) {
            contenidoPaginas += '<li data-page=' + i + '>' + '<a class="pag_actual">' + i + '</a></li>';
        } else {
            contenidoPaginas += '<li role="button" class="page_left" data-page=' + i + '>' + '<a href="#">' + i + '</a></li>';
        }
    }

    if (pag_actual < totalPag) {
        if ((totalPag - pag_actual) >= cant_por_linea) {
            contenidoNext = '<li><a id="page_right" data-page=' + Number(fin + 1) + ' aria-label="Next"><span aria-hidden="true">&raquo;</span></a></li>';
        }
    }


    if (totalPag > 1) {
        $('#' + nom_padre + '').show();
        $('#' + nom_contenedor + '').html("");
        $('#' + nom_contenedor + '').html(contenidopreview + contenidoPaginas + contenidoNext);
    } else $('#' + nom_padre + '').hide();


    $('#page_right,#page_left,.page_left').bind('click', function () {
        debugger
        pagina_actual = $(this).attr("data-page");
        var params = {
            pagina: pagina_actual,
            tipo: tipo_recurso
        };
        list_recursos_admin(params);
    });

}

function eliminar_enlace(id_recurso) {
    var params = {
        id_recurso: id_recurso,
        opc: "DEL",
        id_usuario: $("#hdIdUsuario").val()
    }

    bootbox.confirm({
        title: "Confirmar Eliminación",
        message: "¿Esta seguro de eliminar el enlace de interés?",
        buttons: {
            confirm: {
                label: 'Eliminar'
            },
            cancel: {
                label: 'Cancelar'
            }
        },
        callback: function (result) {
            if (result == true) {
                ajaxPost('../Views/Capacitacion/admin_enlaces_ajax', params, null, function (r) {
                    if (r.indexOf("<||>") != -1) {
                        var errRes = r.split("<||>")[0];
                        var mensRes = r.split("<||>")[1];
                        if (errRes == '0') {
                            bootbox.alert("Eliminación realizada exitosamente", function () {
                                var pag_actual = $('#paginador').find(".pag_actual").text();
                                if (pag_actual == "" || pag_actual == undefined) {
                                    //unica pagina
                                    pag_actual = 1;
                                }
                                if (cant_elem == 1) {
                                    if (pag_actual > 1) {
                                        pag_actual = Number(pag_actual - 1);
                                    } else {
                                        pag_actual = 1;
                                    }
                                }

                                reload_enlaces(pag_actual,volver_listado_admin('divInfoEnlace', 'divContEnlaces'));
                            });
                           
                        } else {
                            bootbox.alert(mensRes);
                        }
                    }
                }, function (r) {
                    bootbox.alert(r.responseText);
                });
            }
        }
    });


}

function reload_videos(pag_actual, funEspecial) {
    var pagina = 1;
    if (pag_actual > 0 && pag_actual != undefined) {
        pagina = pag_actual;
    }
    var params = {
        pagina: pagina,
        tipo: "4"
    };
    list_recursos_admin(params, funEspecial);
}

function inicializarDatos(idContenedor, funEspecial) {
    var objContenedor = $('#' + idContenedor);
    $('input[type=text]', objContenedor).val('');
    $('input[type=checkbox]', objContenedor).attr('checked', false);
    $('input[type=radio]', objContenedor).attr('checked', false);
    $('select', objContenedor).val('');
    $('.txt_asterisco', objContenedor).remove();
    if ($.isFunction(funEspecial)) {
        funEspecial();
    }
}

function eliminar_video(id_recurso) {
    var cant_elem = $(".videoContainer").length;
    var params = {
        id_recurso: id_recurso,
        opc: "DEL",
        id_usuario: $("#hdIdUsuario").val()
    }

    bootbox.confirm({
        title: "Confirmar Eliminación",
        message: "¿Esta seguro de eliminar el video instructivo?",
        buttons: {
            confirm: {
                label: 'Eliminar'
            },
            cancel: {
                label: 'Cancelar'
            }
        },
        callback: function (result) {
            if (result == true) {
                ajaxPost('../Views/Capacitacion/admin_enlaces_ajax', params, null, function (r) {
                    if (r.indexOf("<||>") != -1) {
                        var errRes = r.split("<||>")[0];
                        var mensRes = r.split("<||>")[1];
                        if (errRes == '0') {
                            bootbox.alert("Eliminación realizada exitosamente", function () {
                                var pag_actual = $('#paginador').find(".pag_actual").text();
                                if (pag_actual == "" || pag_actual == undefined) {
                                    pag_actual = 1;
                                }
                                if (cant_elem == 1) {
                                    if (pag_actual > 1) {
                                        pag_actual = Number(pag_actual - 1);
                                    } else {
                                        pag_actual = 1;
                                    }
                                }
                                reload_videos(pag_actual, volver_listado_admin('divInfoEnlace', 'divContVideos'));
                            });

                        } else {
                            bootbox.alert(mensRes);
                        }
                    }
                }, function (r) {
                    bootbox.alert(r.responseText);
                });
            }
        }
    });


}

function editar_video(id_recurso) {
    $("#hdIdRecurso").val(id_recurso);
    var params = {
        id_recurso: id_recurso,
        opc: "OBT"
    };
    $.ajax({
        type: "POST",
        url: '../Views/Capacitacion/admin_enlaces_ajax',
        data: params,
        traditional: true,
        cache: false,
        dataType: "json",
        success: function (result) {
            debugger
            if (result.Head.length > 0) {
                var encabezado = result.Head[0];
                $("#txtTitulo").val(encabezado[0].titulo);
                $("#txtDescripcion").val(encabezado[0].descripcion);
                $("#txtEnlace").val(encabezado[0].rutaUrl);
                cargaPlantillasAdmin("divContVideos", "divInfoEnlace");

            }

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            bootbox.alert(textStatus + ": " + XMLHttpRequest.responseText);
        }

    });

    //modif_enlace_interes(params);
}

function modif_videos_instructivos(params) {
    ajaxPost('../Views/Capacitacion/admin_enlaces_ajax', params, null, function (r) {
        if (r.indexOf("<||>") != -1) {
            var errRes = r.split("<||>")[0];
            var mensRes = r.split("<||>")[1];
            if (errRes == '0') {
                bootbox.alert("Modificacion realizada exitosamente", function () {
                    var pag_actual = $('#paginador').find(".pag_actual").text();
                    reload_enlaces(pag_actual, volver_listado_admin('divInfoEnlace', 'divContVideos'));

                });
            } else {
                bootbox.alert(mensRes);
            }
        }
    }, function (r) {
        bootbox.alert(r.responseText);
    });

}

// AND


function crear_temacapacitacion(params) {
    ajaxPost('../Views/Capacitacion/admin_temacapacitacion_ajax', params, null, function (r) {
        if (r.indexOf("<||>") != -1) {
            var errRes = r.split("<||>")[0];
            var mensRes = r.split("<||>")[1];
            if (errRes == '0') {
                bootbox.alert("Tema de capacitación guardado exitosamente");
                volverTemasCap();
            } else {
                bootbox.alert(mensRes);
            }
        }
    }, function (r) {
        bootbox.alert(r.responseText);
    });

}

function crear_recursocapacitacion(params) {
    ajaxPost('../Views/Capacitacion/admin_recursoscapacitacion_ajax', params, null, function (r) {
        if (r.indexOf("<||>") != -1) {
            var errRes = r.split("<||>")[0];
            var mensRes = r.split("<||>")[1];
            if (errRes == '0') {
                bootbox.alert("Recurso de capacitación guardado exitosamente");
                volverRecursosCap();
            } else {
                bootbox.alert(mensRes);
            }
        }
    }, function (r) {
        bootbox.alert(r.responseText);
    });

}
function volverTemasCap() {
    $("#datosTCap").show();
    $("#crearTCap").hide();
    $("#datosTCap").slideDown(function () {
        CargarDatosTemaCapacitacion();
    });
}

function volverRecursosCap() {
    $("#datosRCap").show();
    $("#crearRCap").hide();
    $("#datosRCap").slideDown(function () {
        CargarDatosCapacitacion();
    });
}

function CargarDatosTemaCapacitacion() {
    $("#crearTCap").hide();
        $.ajax({
            type: "POST",
            url: '../Views/Capacitacion/admin_temacapacitacion_ajax', data: {opc: 'LIST' },
            traditional: true,
            cache: false,
            dataType: "json",
            beforeSend: function () {
                waitblockUIParam('Cargando datos...');
            },
            success: function (result) {
                var datasource = '';
                if (result != null && result != "") {
                
                    for (var i = 0; i < result.Head.length; i++) {
                        var texto = "Eliminar";
                        datasource += '<div class="panel panel-capacitacion">'+
                                    '<div class="panel-heading">'+
                                    '<div class="col-md-10">' + result.Head[i].TituloCapacitacion + '</div>'+
                                    '<div class="col-md-2 text-right"><a class="btn btn-primary" role="button" onclick="EditarTema(\'' + result.Head[i].idCap + '\');" title="Editar título, descripción o recursos asociados a la capacitación"> <span class="glyphicon glyphicon-edit"></span></a>' +
                                    '<a class="btn btn-primary" role="button"  onclick="EliminarTema(\'' + result.Head[i].idCap + '\');" title="Eliminar el tema de capacitación, solo quedará registro en la base de datos"> <span class="glyphicon glyphicon-trash"></span></a></div>' +
                                    '</div>'+
                                    '<div class="panel-body">'+
                                    '<p>' + result.Head[i].DetalleCapacitacion + '</p>' +
                                    '</div>'+
                                    '</div>';
                    }
                }
                $("#datosTCap").html(datasource);
                $('#TituloPagina').html('Listado de temas');
                unblockUI();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("error");
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }

        });
}


function EditarTema(id_cap) {
    ajaxPost('../Views/Capacitacion/admin_recursoscapacitacion', { id_cap: id_cap }, 'dvPrincipal', function (r) {
    }, function (e) {
        bootbox.alert(e.responseText);
    });
}

function EliminarTema(idcap) {
    var params = {
        opc: "DEL",
        id_usuario: $("#hdIdUsuario").val(),
        id_cap: idcap,
    };
    bootbox.confirm({
        title: "Confirmar Eliminación",
        message: "Esta seguro de eliminar la capacitación y los recursos relacionados?",
        buttons: {
            confirm: {
                label: 'Eliminar'
            },
            cancel: {
                label: 'Cancelar'
            }
        },
        callback: function (result) {
            if (result == true) {
                ajaxPost('../Views/Capacitacion/admin_temacapacitacion_ajax', params, null, function (r) {
                    if (r.indexOf("<||>") != -1) {
                        var errRes = r.split("<||>")[0];
                        var mensRes = r.split("<||>")[1];
                        if (errRes == '0') {
                            bootbox.alert("Eliminación realizada exitosamente");
                            volverTemasCap();
                        } else {
                            bootbox.alert(mensRes);
                        }
                    }
                }, function (r) {
                    bootbox.alert(r.responseText);
                });
            }
        }
    });
   

}


function EliminarRecurso(idRcap) {
    var params = {
        opc: "DEL",
        id_usuario: $("#hdIdUsuario").val(),
        id_Rcap: idRcap,
    };
    bootbox.confirm({
        title: "Confirmar Eliminación",
        message: "Esta seguro de eliminar el recurso de capacitación?",
        buttons: {
            confirm: {
                label: 'Eliminar'
            },
            cancel: {
                label: 'Cancelar'
            }
        },
        callback: function (result) {
            if (result == true) {
                ajaxPost('../Views/Capacitacion/admin_recursoscapacitacion_ajax', params, null, function (r) {
                    if (r.indexOf("<||>") != -1) {
                        var errRes = r.split("<||>")[0];
                        var mensRes = r.split("<||>")[1];
                        if (errRes == '0') {
                            bootbox.alert("Eliminación realizada exitosamente");
                            volverRecursosCap();
                        } else {
                            bootbox.alert(mensRes);
                        }
                    }
                }, function (r) {
                    bootbox.alert(r.responseText);
                });
            }
        }
    });


}


function CargarDatosCapacitacion() {
    $("#crearRCap").hide();

    var id_cap= $("#hdIdCap").val();

    ajaxPost('../../Views/Capacitacion/admin_recursoscapacitacion_ajax', { opc: 'LIST' , id_cap: id_cap }, null, function (r) {
        var datosEvalProyecto = r;
        eval(datosEvalProyecto);
    }, function (e) {
        bootbox.alert(e.responseText);
    });
}

function CargarDatosModulos() {

    var id_cap = $("#hdIdCap").val();

    ajaxPost('../../Views/Capacitacion/list_capacitacion_ajax', { opc: 'LIST', id_cap: id_cap }, null, function (r) {
        var datosEvalProyecto = r;
        eval(datosEvalProyecto);
    }, function (e) {
        bootbox.alert(e.responseText);
    });
}

function editar_temacapacitacion(params) {
    ajaxPost('../Views/Capacitacion/admin_temacapacitacion_ajax', params, null, function (r) {
        if (r.indexOf("<||>") != -1) {
            var errRes = r.split("<||>")[0];
            var mensRes = r.split("<||>")[1];
            if (errRes == '0') {
                bootbox.alert("Tema de capacitación editado exitosamente");
            } else {
                bootbox.alert(mensRes);
            }
        }
    }, function (r) {
        bootbox.alert(r.responseText);
    });

}

function CursarCapt(id_cap) {
    ajaxPost('../Views/Capacitacion/list_capacitacion', { id_cap: id_cap }, 'dvPrincipal', function (r) {
    }, function (e) {
        bootbox.alert(e.responseText);
    });
}