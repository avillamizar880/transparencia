using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuditoriasCiudadanas.Controllers
{
    public class EnlacesDNPController : Controller
    {
        public List<DataTable> ObtenerEnlacesDNP()
        {
            return Models.clsEnlacesDNP.ObtEnlacesDNP();
        }

        public ActionResult guardarEnlaceDNP(int id_enlace, int id_usuario, string enlace_url)
        {
            var Respuesta = Models.clsEnlacesDNP.GuardarEnlaceDNP(id_enlace, id_usuario, enlace_url);

            var splitRespuesta = Respuesta.Split(new string[] { "<||>" }, StringSplitOptions.None);
            var ObjRespuesta = new
            {
                Mensaje = splitRespuesta[1],
                Codigo = splitRespuesta[0]
            };

            return Json(ObjRespuesta);
        }
    }
}