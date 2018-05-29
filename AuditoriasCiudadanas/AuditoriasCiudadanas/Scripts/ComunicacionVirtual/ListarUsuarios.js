$(function () {

    $("#txtBuscarUsuario").autocomplete({
        source: function (request, response) {
            $("#hfIdDestinatario").val("");
            $.ajax({
                url: "Chat/BuscarUsuarios",
                dataType: "json",
                type: "POST",
                data: {
                    name: request.term,
                    idUsuarioConsulta: $("#hfIdUsuario").val()
                },
                success: function (data) {
                    response(data);
                }
            });
        },
        minLength: 3,
        select: function (event, ui) {
            $("#hfIdDestinatario").val(ui.item.id + "*" + ui.item.value);
        },
        open: function () {
            $(this).removeClass("ui-corner-all").addClass("ui-corner-top");
        },
        close: function () {
            $(this).removeClass("ui-corner-top").addClass("ui-corner-all");
        }
    });

    $("#btnIrAChat").click(function () {
        if ($("#hfIdDestinatario").val() != "") {
            cargaMenuParams('Chat/ChatPrincipal', 'dvPrincipal', $("#hfIdDestinatario").val());
        }
        return false;
    });
});