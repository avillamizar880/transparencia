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
        public ActionResult ActualizaEstadoNotificacion(int IdNotificacion, string Estado)
        {
            var Respuesta = Models.clsNotificacion.ActualizaEstadoNotificacion(IdNotificacion, Estado);

            var splitRespuesta = Respuesta.Split(new string[] { "<||>" }, StringSplitOptions.None);
            var ObjRespuesta = new
            {
                Mensaje = splitRespuesta[1],
                Codigo = splitRespuesta[0]
            };

            if (ObjRespuesta.Mensaje.Equals("@OK") && (int)Session["cantNotificaciones"] != 0)
            {
                Session["cantNotificaciones"] = (int)Session["cantNotificaciones"] - 1;
            }

            return Json(ObjRespuesta);
        }

        public List<EntityNotificacion> GetNotificaciones(int Idusuario, char Estado)
        {
            List<EntityNotificacion> mensajes = new List<EntityNotificacion>();

            var datatables = Models.clsNotificacion.ObtNotificaciones(Idusuario, Estado, '0');

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

        public int GetNotificacionesCount(int Idusuario, char Estado)
        {
            List<EntityNotificacion> mensajes = new List<EntityNotificacion>();

            var datatables = Models.clsNotificacion.ObtNotificaciones(Idusuario, Estado, '1');

            try
            {
                System.Data.DataRow datarow = datatables[0].Rows.Cast<System.Data.DataRow>()
                           .ToList()
                           .FirstOrDefault();

                return (int)datarow["total"];
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}