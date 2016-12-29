using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace AuditoriasCiudadanas.Controllers
{
    public class AudienciasController
    {
        public string insActaReuniones(string cod_bpin, DateTime fecha, string tema, string ruta_arc, int id_usuario,int id_lugar)
        {
            string outTxt = "";
            List<DataTable> listaInfo = new List<DataTable>();
            listaInfo = Models.clsAudiencias.insActaReuniones(cod_bpin, fecha, tema, ruta_arc, id_usuario,id_lugar);
            return outTxt;
        }

        public string insRegObservaciones(int id_audiencia, string info_clara, string info_completa, string comunidad_benef, string dudas, DateTime fecha_posterior_1, DateTime fecha_posterior_2, int id_usuario)
        {
            string outTxt = "";
            outTxt = Models.clsAudiencias.insRegObservaciones(id_audiencia,info_clara,info_completa,comunidad_benef,dudas,fecha_posterior_1,fecha_posterior_2,id_usuario);
            return outTxt;
        }

        public string insProponerFechaReuPrevias(string cod_bpin, DateTime fecha, int id_usuario)
        {
            string outTxt = "";
            outTxt = Models.clsAudiencias.insProponerFechaReuPrevias(cod_bpin,fecha,id_usuario);
            return outTxt;
        }
    }
}