using AuditoriasCiudadanas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuditoriasCiudadanas.Controllers
{
    public class NotificacionController : Controller
    {
        public List<EntityNotificacion> GetNotificaciones(int Idusuario, char Estado)
        {
            List<EntityNotificacion> mensajes = new List<EntityNotificacion>();

            var datatables = Models.clsNotificacion.ObtNotificaciones(Idusuario, Estado);

            datatables[0].Rows.Cast<System.Data.DataRow>()
                        .ToList()
                        .ForEach(n => mensajes.Add(
                            new EntityNotificacion()
                            {
                                IdNotificacion = (int)n["idNotificacion"],
                                IdUsuario = (int)n["idUsuario"],
                                Tipo = n["tipo"].ToString(),
                                Mensaje = n["mensaje"].ToString(),
                                Estado = n["estado"].ToString(),
                                FechaCreacion = (DateTime)n["fechaCreacion"],
                                Parametros = n["parametros"].ToString()
                            }));

            return mensajes;
        }
    }
}