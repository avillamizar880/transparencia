using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AuditoriasCiudadanas.Controllers
{
    public class GestionGruposController
    {
        public string addBuenasPracticas(string bpin_proy, string hecho,string descripcion, int id_usuario, int id_gac)
        {
            string outTxt = "";
            outTxt = Models.clsGestionGrupos.addBuenasPracticas(bpin_proy,hecho, descripcion, id_usuario, id_gac);
            return outTxt;
        }

        public string obtBuenasPracticas() {
            string outTxt = "";
            List<DataTable> listado = Models.clsGestionGrupos.obtBuenasPracticas();
            if (listado.Count > 1)
            {
                DataTable dtGeneral = listado[0];
                AuditoriasCiudadanas.App_Code.funciones datos_func = new AuditoriasCiudadanas.App_Code.funciones();
                outTxt = datos_func.convertToJson(dtGeneral);

            }
            return outTxt;

        }

        public string obtBuenasPracticasById(int id_practica) {
            string outTxt = "";
            return outTxt;

        }
    }
}