﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuditoriasCiudadanas.Models
{
    public class EntityNotificacion
    {
        public int IdNotificacion { get; set; }
        public int IdUsuario { get; set; }
        public string Tipo { get; set; }
        public string TipoDescripcion {
            get {
                switch (Tipo)
                {
                    case "1":
                        return "Mensaje";
                    case "2":
                        return "Foro";
                    case "3":
                        return "Noticia";
                    default:
                        return "Notificación";
                }
            }
        }
        public string Mensaje { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Parametros { get; set; }
    }
}