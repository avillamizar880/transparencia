$("#btnCrearEnlace").bind("click", function () {
    var enlace_url = $("#txtEnlace").val();
    //validar campos obligatorios
    var formularioOK = true;
    var camposReq = "";
    $(".alert-danger").hide();
    $('.required', $('#divInfoEnlace')).each(function (i, e) {
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
                    opc:"ADD",
                    id_usuario: $("#hdIdUsuario").val(),
                    titulo: $("#txtTitulo").val(),
                    desc: $("#txtDescripcion").val(),
                    enlace_url: $("#txtEnlace").val()
                };
                crear_enlace_interes(params);
            } else {
                bootbox.alert("Formato de enlace incorrecto");

            }

    }

   
});