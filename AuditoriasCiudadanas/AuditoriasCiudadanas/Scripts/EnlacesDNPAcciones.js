$("#btnGuardarEnlaceDNP").bind("click", function () {
    var enlace_url = $("#txtURL").val();
    //validar campos obligatorios
    var formularioOK = true;
    var camposReq = "";
    $(".alert-danger").hide();
    $('.required', $('#divInfoEnlaceDNP')).each(function (i, e) {
        var id_txt = $(e).attr("for");
        if ($("#" + id_txt).val() == "" || $('#' + id_txt + ' option:selected').val() == "0") {
            camposReq += "[" + id_txt + "]";
            $("#error_" + id_txt).show();
            formularioOK = false;
        } else {
            $("#error_" + id_txt).hide();
        }
    });

    if (formularioOK == false) {
        if (camposReq != "") {
            bootbox.alert("Faltan campos obligatorios");
        }
    } else {
        if (isUrl(enlace_url)) {
            var params = {
                id_enlace: $("#ddlTipoEnlace option:selected").val(),
                id_usuario: $("#hdIdUsuario").val(),
                enlace_url: $("#txtURL").val()
            };
            modif_enlace_DNP(params);

        } else {
            bootbox.alert("Formato de enlace incorrecto");

        }
    }
});

$("#ddlTipoEnlace").change(function () {
    $("#txtURL").attr("placeholder", "");
    if ($("#ddlTipoEnlace option:selected").val() != 0) {
        var x = JSON.parse($("#hdDllContent").val());
        $.each(x, function (idx, obj) {
            if (obj.id_enlace == $("#ddlTipoEnlace option:selected").val()) {
                $("#txtURL").attr("placeholder", obj.enlace);
            }
        });
    }
});