using AuditoriasCiudadanas.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        public ActionResult addForo(itemForos dataForo) {
            List<usuario> usuarios = new List<usuario>();
            string titulo = dataForo.tema;
            return Json(usuarios);
        }
    }
}