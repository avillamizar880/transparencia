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