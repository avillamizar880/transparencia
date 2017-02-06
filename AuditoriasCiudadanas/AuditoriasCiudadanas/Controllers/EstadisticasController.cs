using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AuditoriasCiudadanas.Controllers
{
    public class EstadisticasController
    {
        public string formato(string cadena)
        {
            return HttpUtility.HtmlEncode(cadena).Replace("\r", " ").Replace("\n", " ");
        }

        public string formato_anyo(string cadena)
        {
            string cad_aux = cadena;
            if (!string.IsNullOrEmpty(cadena))
            {
                DateTime dt = Convert.ToDateTime(cadena);
                cad_aux = dt.ToString("yyyy",
                        CultureInfo.CreateSpecificCulture("es-co"));
            }

            return cad_aux;

        }

        public string obtEstadisticas(String opcion)
        {
            String outTxt = "";

            List<DataTable> listaInfo = new List<DataTable>();
            listaInfo = Models.clsEstadisticas.obtEstadisticas(opcion);
            DataTable dtGacXLocal = listaInfo[0];
            DataTable dtAudXLocal = listaInfo[1];
            DataTable dtProyectosGac = listaInfo[2];
            DataTable dtGACXTiempo = listaInfo[3];
            DataTable dtProyectosAud = listaInfo[4];
            DataTable dtAsistentes = listaInfo[5];
            DataTable dtHallazgos = listaInfo[6];


            return outTxt;
        }
    }
}