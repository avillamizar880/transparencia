using System;
using System.Collections.Generic;
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
    }
}