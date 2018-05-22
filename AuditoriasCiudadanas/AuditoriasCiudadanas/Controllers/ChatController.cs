using AuditoriasCiudadanas.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuditoriasCiudadanas.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BuscarUsuarios(string name)
        {

            List<usuario> usuarios = new List<usuario>();

            if (!string.IsNullOrEmpty(name))
            {
                var tabla = clsUsuarios.obtDatosUsuarioByName(name);

                if (tabla[0].Rows.Count > 0)
                {
                    tabla[0].Rows.Cast<System.Data.DataRow>()
                        .ToList()
                        .ForEach(n => usuarios.Add(
                            new usuario()
                            {
                                id = n["IdUsuario"].ToString(),
                                value = n["Nombre"].ToString()
                            }));
                }

            }

            return Json(usuarios);
        }

        public ActionResult guardarMensaje(int IdRemitente, int IdDestinatario, string Mensaje)
        {
            var Respuesta = Models.clsChat.addMensaje(IdRemitente, IdDestinatario, Mensaje);

            var splitRespuesta = Respuesta.Split(new string[] { "<||>" }, StringSplitOptions.None);
            var ObjRespuesta = new
            {
                Mensaje = splitRespuesta[1],
                Codigo = splitRespuesta[0]
            };

            return Json(ObjRespuesta);
        }

        public List<EntityMensaje> GetMensajes(int IdRemitente, int IdDestinatario)
        {
            List<EntityMensaje> mensajes = new List<EntityMensaje>();

            var datatables = Models.clsChat.ObtMensajes(IdRemitente, IdDestinatario);

            datatables[0].Rows.Cast<System.Data.DataRow>()
                        .ToList()
                        .ForEach(n => mensajes.Add(
                            new EntityMensaje()
                            {
                                IdChat = (int)n["idChat"],
                                IdRemitente = (int)n["idRemitente"],
                                IdDestinatario = (int)n["idDestinatario"],
                                Mensaje = n["mensaje"].ToString(),
                                Estado = n["estado"].ToString(),
                                FechaCreacion = (DateTime) n["fechaCreacion"],
                            }));

            return mensajes;
        }
    }

    public class usuario
    {
        public string id { get; set; }
        public string value { get; set; }
    }
}