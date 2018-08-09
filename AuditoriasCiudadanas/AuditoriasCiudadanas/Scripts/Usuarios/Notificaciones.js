function AccionNotificacion(idNotificacion, Tipo, parametros) {

    ActualizaEstadoNotificacion(idNotificacion, "1");

    switch (Tipo) {
        default:
            verChat(parametros);
            break;
    }
}

function verChat(parametros) {
    cargaMenuParams(parametros.url, parametros.div, parametros.params);
}

function eliminarNotificacion(idNotificacion) {
    $.ajax({
        url: "Notificacion/ActualizaEstadoNotificacion",
        dataType: "json",
        type: "POST",
        data: {
            IdNotificacion: idNotificacion,
            Estado: "1"
        },
        success: function (data) {
            if (data.Mensaje == "@OK") {

                var cantNot = parseInt($(".LogIn").attr("cantnotificaciones"));
                $(".LogIn").attr("cantnotificaciones", cantNot - 1);

                if ($(".LogIn").attr("cantnotificaciones") != "0") {
                    $("#usrName").html($(".LogIn").attr("nombre") + " <span class=\"badge badge-primary\" >" + $(".LogIn").attr("cantnotificaciones") + "</span> " + "<span class=\"glyphicon glyphicon-menu-down\"></span>");
                }
                else
                    $("#usrName").html($(".LogIn").attr("nombre") + "<span class=\"glyphicon glyphicon-menu-down\"></span>");

                cargaMenu("Usuarios/notificaciones", "dvPrincipal");
            }
            else {
                bootbox.alert("Error actualizando notificación");
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus, errorThrown);
        }
    });
}

function ActualizaEstadoNotificacion(idNotificacion, estado) {
    $.ajax({
        url: "Notificacion/ActualizaEstadoNotificacion",
        dataType: "json",
        type: "POST",
        data: {
            IdNotificacion: idNotificacion,
            Estado: estado
        },
        success: function (data) {
            if (data.Mensaje == "@OK") {

                var cantNot = parseInt($(".LogIn").attr("cantnotificaciones"));
                $(".LogIn").attr("cantnotificaciones", cantNot - 1);

                if ($(".LogIn").attr("cantnotificaciones") != "0") {
                    $("#usrName").html($(".LogIn").attr("nombre") + " <span class=\"badge badge-primary\" >" + $(".LogIn").attr("cantnotificaciones") + "</span> " + "<span class=\"glyphicon glyphicon-menu-down\"></span>");
                }
                else
                    $("#usrName").html($(".LogIn").attr("nombre") + "<span class=\"glyphicon glyphicon-menu-down\"></span>");
            }
            else {
                bootbox.alert("Error actualizando notificación");
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus, errorThrown);
        }
    });
};

function ObtenerNotificaciones(idUsuario, pagina) {
    var nom_contenedor = "paginadorNotificaciones";
    var nom_padre = "divPagNotificaciones";
    $("#lblFiltradas").text("");
    $.ajax({
        url: "Notificacion/GetNotificaciones",
        dataType: "json",
        type: "POST",
        data: {
            IdUsuario: idUsuario,
            Estado: 0,
            page: pagina,
            texto: $("#txtBuscarNotificacion").val()
        },
        success: function (data) {
            if (data.length > 0) {
                var htmlContent = "";
                $.each(data, function () {
                    htmlContent += "<div class=\"list-group-item newsProfile\" > ";
                    htmlContent += "	<div class=\"col-md-2 blueBg text-center\" >" + this.TipoDescripcion + "</div>";
                    htmlContent += "	<div class=\"col-md-7\" > <a href = \"#\" onclick=\"AccionNotificacion(\'" + this.IdNotificacion + "\',\'" + this.Tipo + "\', " + this.Parametros.replace(/"/g, "'") + ");\" >" + this.Mensaje + "</a></div>";
                    htmlContent += "	<div class=\"col-md-2 text-center\" >" + this.FechaCreacionString + "</div>";
                    htmlContent += "	<div class=\"col-md-1 text-center\" ><a onclick=\"eliminarNotificacion(\'" + this.IdNotificacion + "\');\" role=\"button\"> <span class=\"glyphicon glyphicon-trash\"></span></a></div>";
                    htmlContent += "</div>";
                });

                $("#tbNotificaciones").html(htmlContent);

                var totalNumber = data[0].Total;
                if ($("#txtBuscarNotificacion").val() != "") $("#lblFiltradas").text(" Filtradas: " + totalNumber);
                var numPerPag = 10;
                var totalPages = (totalNumber > numPerPag) ? ((totalNumber - (totalNumber % numPerPag)) / numPerPag) : 1;
                if ((totalNumber >= numPerPag) && ((totalNumber % numPerPag) > 0)) {
                    totalPages++;
                }

                dibujarPaginacionNotificaciones(pagina, totalNumber, totalPages, nom_contenedor, nom_padre, idUsuario);
            }
            else {
                $("#tbNotificaciones").html("");
                $('#' + nom_contenedor + '').html("");
                if (pagina != 1) ObtenerNotificaciones(idUsuario, 1);
            }
            

        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus, errorThrown);
        }
    });
}

function dibujarPaginacionNotificaciones(actual, totalNumber, totalPag, nom_contenedor, nom_padre, IdUsuario) {
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
        pagina_actual = $(this).attr("data-page");
        ObtenerNotificaciones(IdUsuario, pagina_actual);
    });

}