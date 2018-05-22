using AuditoriasCiudadanas.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AuditoriasCiudadanas.Controllers
{
    public class ComunicacionController:Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public string addForo(itemForos dataForo) {
            string outTxt = "";
            itemReturn objReturn = new itemReturn();
            string tema = dataForo.tema;
            string descripcion = dataForo.descripcion;
            string mensaje = dataForo.mensaje;
            int idUsuario = dataForo.idUsuario;
            objReturn= Models.clsComunicacion.crearForo(tema,descripcion, mensaje, idUsuario);
            AuditoriasCiudadanas.App_Code.funciones datos_func = new AuditoriasCiudadanas.App_Code.funciones();
            outTxt = datos_func.convertToJsonObj(objReturn);
            return outTxt;
        }
    }
}