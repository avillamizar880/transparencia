using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace AuditoriasCiudadanas.Controllers
{
    public class GeneralController
    {
        public DataTable listarDepartamentos() {
            DataTable dtInfo = new DataTable();
            dtInfo = Models.clsGeneral.listarDepartamentos()[0];
            return dtInfo;

        }

        public DataTable obtMunicipiosByDep(int id_departamento)
        {
            DataTable dtInfo = new DataTable();
            dtInfo = Models.clsGeneral.obtMunicipiosByDep(id_departamento)[0];
            return dtInfo;

        }
    }
}