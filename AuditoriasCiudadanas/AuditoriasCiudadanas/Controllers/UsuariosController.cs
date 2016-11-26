using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace AuditoriasCiudadanas.Controllers
{
    public class UsuariosController
    {
        public String DatosInsercion(string nombre, string email,
            string celular, string hash_clave, int idperfil, int id_departamento, int id_municipio)
        {
            String outTxt = "";
            outTxt= Models.clsUsuarios.insertarUsuario(nombre,email,celular,hash_clave,idperfil,id_departamento,id_municipio);
            return outTxt;
        }
    }
}