using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace AuditoriasCiudadanas.Controllers
{
    public class AudienciasController
    {
        public string insActaReuniones(int id_audiencia, string cod_bpin, DateTime fecha, string tema, string ruta_arc, int id_usuario,int id_lugar)
        {
            string outTxt = "";
            List<DataTable> listaInfo = new List<DataTable>();
            listaInfo = Models.clsAudiencias.insActaReuniones(id_audiencia, cod_bpin, fecha, tema, ruta_arc, id_usuario,id_lugar);
            return outTxt;
        }
    }
}