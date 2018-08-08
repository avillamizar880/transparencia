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

        public Models.ModelDataRecurso obtBuenasPracticas(int page) {
            int numPerPag = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["MaximumResultsPerPag"]);
            Models.ModelDataRecurso objReturn = new Models.ModelDataRecurso();
            DataTable detalle = new DataTable();
            DataTable source = new DataTable();
            List<DataTable> lst_source = Models.clsGestionGrupos.obtBuenasPracticas();
            if (lst_source.Count > 0)
            {
                source = lst_source[0];
                if (source.Rows.Count > 0)
                {
                    objReturn.totalNumber = Convert.ToInt16(source.Rows[0]["total_reg"].ToString());
                }
                else
                {
                    objReturn.totalNumber = 0;
                }

                objReturn.dtRecursos = source;
                objReturn.pagesNumber = page;
                objReturn.totalPages = (objReturn.totalNumber > numPerPag) ? ((objReturn.totalNumber - (objReturn.totalNumber % numPerPag)) / numPerPag) : 1;
                if ((objReturn.totalNumber >= numPerPag) && ((objReturn.totalNumber % numPerPag) > 0))
                {
                    objReturn.totalPages++;
                }


            }


            return objReturn;

        }

        public string obtBuenasPracticasById(int id_practica) {
            string outTxt = "";
            List<DataTable> listado = Models.clsGestionGrupos.obtBuenasPracticasById(id_practica);
            if (listado.Count > 1)
            {
                DataTable dtGeneral = listado[0];
                AuditoriasCiudadanas.App_Code.funciones datos_func = new AuditoriasCiudadanas.App_Code.funciones();
                outTxt = datos_func.convertToJson(dtGeneral);

            }
            return outTxt;

        }

        public string aprobarBuenasPracticas(int id_practica, int id_usuario) {
            string outTxt = "";
            outTxt = Models.clsGestionGrupos.aprobarBuenasPracticas(id_practica, id_usuario);
            return outTxt;
        }
    }
}