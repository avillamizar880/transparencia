using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace AuditoriasCiudadanas.Controllers
{
    public class ValoracionController
    {
        public DataTable listarTipoCuestionario() {
            DataTable datos = new DataTable("datos");
            List<DataTable> l_datos = Models.clsValoracion.listaTipoCuestionario();
            if (l_datos.Count > 0) { 
                datos = l_datos[0];
            }
            
            return datos;
        }
        
        public string CrearCuestionario(int id_tipo, string titulo, string descripcion, int id_usuario) {
            string outTxt = "";
            outTxt = Models.clsValoracion.crearCuestionario(id_tipo, titulo, descripcion, id_usuario);
            return outTxt;
        }

        public string insPregunta(string xml_info)
        {
            string outTxt = "";
            outTxt = Models.clsValoracion.insPregunta(xml_info);
            return outTxt;
        }
    }
}