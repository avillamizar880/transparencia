using System;
using System.Web;

namespace AuditoriasCiudadanas.Controllers
{
    public class CapacitacionController
    {
        public string addRecursoMultimedia(int tipo_recurso, string titulo, string descripcion, string ruta, int id_usuario)
        {
            string outTxt = "";
            outTxt = Models.clsCapacitacion.addRecursoMultimedia(tipo_recurso, titulo, descripcion, ruta, id_usuario);
            return outTxt;
        }

        public string delRecursoMultimedia(int id_usuario,int id_recurso)
        {
            string outTxt = "";
            outTxt = Models.clsCapacitacion.delRecursoMultimedia(id_recurso, id_usuario);
            return outTxt;
        }

        public string modRecursoMultimedia(int id_recurso, string titulo, string descripcion, string ruta, int id_usuario) {
            string outTxt = "";
            outTxt = Models.clsCapacitacion.delRecursoMultimedia(id_recurso, id_usuario);
            return outTxt;
        }
    }
}
