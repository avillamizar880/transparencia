using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace AuditoriasCiudadanas.Controllers
{
    public class GeneralController
    {
        public DataTable listarDepartamentos()
        {
            DataTable dtInfo = new DataTable();
            dtInfo = Models.clsGeneral.listarDepartamentos()[0];
            return dtInfo;

        }

        public DataTable obtMunicipiosByDep(string id_departamento)
        {
            DataTable dtInfo = new DataTable();
            dtInfo = Models.clsGeneral.obtMunicipiosByDep(id_departamento)[0];
            return dtInfo;

        }

        public DataTable listaRoles()
        {
            DataTable dtInfo = new DataTable();
            dtInfo = Models.clsGeneral.listaRoles()[0];
            return dtInfo;

        }

        public DataTable obtMunicipios()
        {
            DataTable dtInfo = new DataTable();
            DataTable dt_aux = new DataTable("municipios");
            dt_aux.Columns.Add("id", typeof(String));
            dt_aux.Columns.Add("municipio", typeof(String));
            //dt_aux.Columns.Add("id_divipola", typeof(String));
            dtInfo = Models.clsGeneral.obtMunicipios()[0];
            foreach (DataRow fila in dtInfo.Rows)
            {
                DataRow fila_aux = dt_aux.NewRow();
                fila_aux["id"] = fila["id_munic"].ToString();
                fila_aux["municipio"] = fila["nom_municipio"].ToString() + "-" + fila["nom_departamento"].ToString();
                //fila_aux["id_divipola"] = fila["idDivipola"].ToString();
                dt_aux.Rows.Add(fila_aux);
            }
            return dt_aux;
        }

        public DataTable ObtParametroGeneral(string llave)
        {
            DataTable dtInfo = new DataTable();
            dtInfo = Models.clsGeneral.ObtParametroGeneral(llave)[0];

            return dtInfo;

        }
    }
}