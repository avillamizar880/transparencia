using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuditoriasCiudadanas.Controllers
{
    public class VerificacionController
    {
        public string CrearCuestionario(int id_tipo, string titulo, string descripcion, int id_usuario) {
            string outTxt = "";
            outTxt = Models.clsVerificacion.crearCuestionario(id_tipo, titulo, descripcion, id_usuario);
            return outTxt;
        }
    }
}