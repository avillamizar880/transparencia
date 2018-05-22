function validaObligatorios(divcontenedor) {
    var formularioOK = true;
    var camposReq = "";
    $(".alert-danger").hide();
    var nom_contenedor = "#" + divcontenedor;
    $('.required', $(nom_contenedor)).each(function (i, e) {
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
