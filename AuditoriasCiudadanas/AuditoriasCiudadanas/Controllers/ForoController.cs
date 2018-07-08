using AuditoriasCiudadanas.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Hosting;
using System.Web.Mvc;

namespace AuditoriasCiudadanas.Controllers
{
    public class ForoController : Controller
    {

        public ActionResult BuscarRespuestas(int idForo, bool flag = false)
        {

            List<respuesta> respuestas = new List<respuesta>();

            if (idForo > 0)
            {
                List<DataTable> tabla = new List<DataTable>();
                if (flag)
                    tabla = clsForo.obtRespuestasCompletas(idForo);
                else
                    tabla = clsForo.obtRespuestas(idForo);

                if (tabla[0].Rows.Count > 0)
                {
                    tabla[0].Rows.Cast<System.Data.DataRow>()
                        .ToList()
                        .ForEach(n => respuestas.Add(

                            new respuesta()
                            {
                                idForoMensaje = n["idForoMensaje"].ToString(),
                                mensaje = n["mensaje"].ToString(),
                                fecha = ((DateTime)n["fechaCreacion"]).ToString("yyyy-MM-dd hh:mm tt"),
                                nombreUsuario = n["Nombre"].ToString()
                            }));
                }

            }

            return Json(respuestas);
        }

        public ActionResult guardarRespuesta(int IdForo, int IdUsuario, string Mensaje)
        {
            var Respuesta = Models.clsForo.addRespuesta(IdForo, IdUsuario, Mensaje);

            var splitRespuesta = Respuesta.Split(new string[] { "<||>" }, StringSplitOptions.None);
            var ObjRespuesta = new
            {
                Mensaje = splitRespuesta[1],
                Codigo = splitRespuesta[0],
                IdMensaje = splitRespuesta[2]
            };

            if (ObjRespuesta.Mensaje.Equals("@OK"))
            {
                string path = HostingEnvironment.MapPath("~/Templates/Mail/ForoRespuestaMail.html");
                string content = System.IO.File.ReadAllText(path);
                string link = WebConfigurationManager.AppSettings["dominio_app"] + "/login?params=" + Server.UrlEncode(App_Code.SafeParams.encode("Comunicacion/ForoDetalle|dvPrincipal|" + IdForo.ToString()));
                
                content = content.Replace("%URL%", link).Replace("%IMG%", WebConfigurationManager.AppSettings["dominio_app"] + "/Content/img/MailForo.gif");
                List<DataTable> listaInfo = new List<DataTable>();
                listaInfo = Models.clsEnvioCorreos.obtCuentaCorreo(1);
                DataTable dtConfig = listaInfo[0];
                if (dtConfig.Rows.Count >= 1)
                {
                    string outTxt = App_Code.CorreoUtilidad.envCorreoNet(content, splitRespuesta[3], null, null, "Respuesta en Tema de Foro - TPC", dtConfig);
                }

            }

            return Json(ObjRespuesta);
        }

        public ActionResult guardarTema(int IdUsuario, string Tema, string Descripcion)
        {
            var Respuesta = Models.clsForo.addTema(IdUsuario, Tema, Descripcion);

            var splitRespuesta = Respuesta.Split(new string[] { "<||>" }, StringSplitOptions.None);
            var ObjRespuesta = new
            {
                Mensaje = splitRespuesta[1],
                Codigo = splitRespuesta[0],
                IdForo = splitRespuesta[2]
            };

            return Json(ObjRespuesta);
        }

        public List<EntityForo> GetForos()
        {
            List<EntityForo> temas = new List<EntityForo>();

            var datatables = Models.clsForo.ObtForos();

            datatables[0].Rows.Cast<System.Data.DataRow>()
                        .ToList()
                        .ForEach(n => temas.Add(
                            new EntityForo()
                            {
                                IdForo = (int)n["idForo"],
                                Tema = n["tema"].ToString(),
                                Descripcion = n["descripcion"].ToString(),
                                FechaCreacion = (DateTime)n["fechaCreacion"],
                                IdUsuario = (int)n["IdUsuario"],
                                Nombre = n["Nombre"].ToString(),
                            }));

            return temas;
        }

        public List<EntityForo> GetForo(int idForo)
        {
            List<EntityForo> temas = new List<EntityForo>();

            var datatables = Models.clsForo.ObtForo(idForo);

            datatables[0].Rows.Cast<System.Data.DataRow>()
                        .ToList()
                        .ForEach(n => temas.Add(
                            new EntityForo()
                            {
                                IdForo = (int)n["idForo"],
                                Tema = n["tema"].ToString(),
                                Descripcion = n["descripcion"].ToString(),
                                FechaCreacion = (DateTime)n["fechaCreacion"],
                                IdUsuario = (int)n["IdUsuario"],
                                Nombre = n["Nombre"].ToString(),
                            }));

            return temas;
        }

        public ActionResult GetForoByString(string buscar)
        {
            List<EntityForo> temas = new List<EntityForo>();

            var datatables = Models.clsForo.ObtForo(buscar);

            datatables[0].Rows.Cast<System.Data.DataRow>()
                        .ToList()
                        .ForEach(n => temas.Add(
                            new EntityForo()
                            {
                                IdForo = (int)n["idForo"],
                                Tema = n["tema"].ToString(),
                                Descripcion = n["descripcion"].ToString(),
                                FechaCreacionStr = ((DateTime)n["fechaCreacion"]).ToString("yyyy-MM-dd hh:mm tt"),
                                IdUsuario = (int)n["IdUsuario"],
                                Nombre = n["Nombre"].ToString(),
                            }));

            return Json(temas);
        }
    }

    public class respuesta
    {
        public string idForoMensaje { get; set; }
        public string mensaje { get; set; }
        public string nombreUsuario { get; set; }
        public string fecha { get; set; }
    }
}