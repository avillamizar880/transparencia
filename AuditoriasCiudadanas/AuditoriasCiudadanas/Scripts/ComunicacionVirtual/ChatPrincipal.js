$(function () {
    $('#bs-example-navbar-collapse-1 .navbar-nav').find('li.active').removeClass('active');
    $('#liEspacioVirtual').addClass('active');

    var fechaActual = function () {
        var d = new Date();

        var month = d.getMonth() + 1;
        var day = d.getDate();
        var hour = d.getHours();
        var minutes = d.getMinutes();

        var p = 'am';
        if (hour == 12) {
            p = 'pm';
        }
        else if (hour > 11) {
            p = 'pm';
            hour -= 12;
        }
        else if (hour == 0) {
            hour == 12;
        }

        return d.getFullYear() + '/' +
            (month < 10 ? '0' : '') + month + '/' +
            (day < 10 ? '0' : '') + day + ' ' +
            (hour < 10 ? '0' : '') + hour + ':' + (minutes < 10 ? '0' : '') + minutes + ' ' + p;
    };

    $("#btnEnviarMensaje").click(
        function () {
            if ($("#txtMensaje").val() != "") {

                $.ajax({
                    url: "Chat/guardarMensaje",
                    dataType: "json",
                    type: "POST",
                    data: {
                        IdRemitente: $("#hdnIdRemitente").val(),
                        IdDestinatario: $("#hdnIdDestinatario").val(),
                        Mensaje: $("#txtMensaje").val()
                    },
                    success: function (data) {
                        if (data.Mensaje == "@OK") {
                            chat.server.send($("#txtMensaje").val(), $("#hdnIdDestinatario").val());
                            var output = fechaActual();
                            $("#divMessageHistory").append(
                                '<div class="msgContainer dirLrtl usermsg"><div class="media"><div class="media-right media-middle">'
                                + '<a href="#"><span class="glyphicon glyphicon-user"></span></a></div><div class="media-body">'
                                + '<small>' + output + '</small>'
                                + '<p>' + $("#txtMensaje").val() + '</p>'
                                + '</div></div></div>');
                            $('#divMessageHistory').scrollTop($('#divMessageHistory').prop("scrollHeight"));
                            $("#txtMensaje").val('');
                        }
                        else {
                            bootbox.alert("Error guardando mensaje");
                        }
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        console.log(textStatus, errorThrown);
                    }
                });
            }

            return false;
        }
    );

    $('#divMessageHistory').scrollTop($('#divMessageHistory').prop("scrollHeight"));

});