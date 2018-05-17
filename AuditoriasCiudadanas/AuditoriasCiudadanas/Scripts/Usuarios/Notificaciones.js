function AccionNotificacion(idNotificacion, Tipo, parametros) {

    ActualizaEstadoNotificacion(idNotificacion);

    switch (Tipo) {
        case '1':
            verChat(parametros);
            break;
        default:
            break;
    }
}

function verChat(parametros) {
    cargaMenuParams(parametros.url, parametros.div, parametros.params);
}

function ActualizaEstadoNotificacion(idNotificacion) {
    alert(idNotificacion);
};