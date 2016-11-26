using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AuditoriasCiudadanas.Controllers
{
    class MapaRegalias
    {


        public System.Data.DataTable Datos()
        {
            DataTable dtSalida = new DataTable();
            List<DataTable> X = Models.EjemploMapaRegalias.getListadoDeTiposDeFiscalizacion();
            foreach (DataTable dt in X)
            {
                if (dt.TableName == "DataTable0") { dtSalida = dt; }
            }

            return dtSalida;

        }

    }
}
