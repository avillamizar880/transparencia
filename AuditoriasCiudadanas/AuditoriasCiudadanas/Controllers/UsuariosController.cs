using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace AuditoriasCiudadanas.Controllers
{
    public class UsuariosController
    {
        public String ValidaLogin(string email, string hash_clave) {
            String outTxt = "";

            outTxt = Models.clsUsuarios.validaLogin(email, hash_clave);
            return outTxt;
        }
      

        public String DatosInsercion(string nombre, string email,
            string celular, string hash_clave, int idperfil, string id_departamento, string id_municipio)
        {
            String outTxt = "";
            outTxt= Models.clsUsuarios.insertarUsuario(nombre,email,celular,hash_clave,idperfil,id_departamento,id_municipio);
            return outTxt;
        }

        public String CambiarClave(int id_usuario, string hash_clave_ant,string hash_clave_new) {
            String outTxt = "";
            outTxt = Models.clsUsuarios.cambiarClave(id_usuario,hash_clave_ant,hash_clave_new);
            return outTxt;
        }

        public String validaPeriodoClave(string id_usuario) {
            String outTxt = "";
            return outTxt;
        }

        public string addGrupoAuditor(int id_usuario, int id_grupo, string bpin_proyecto) {
            string outTxt = "";
            outTxt = Models.clsUsuarios.addGrupoAuditor(id_usuario, id_grupo, bpin_proyecto);
            return outTxt;
        }

        public String insercionOtros(string nombre, string email,
            string celular, string hash_clave, int idperfil)
        {
            String outTxt = "";
            outTxt = Models.clsUsuarios.insertarUsuario(nombre, email, celular, hash_clave, idperfil, "", "");
            return outTxt;
        }

        public string addSeguirProyecto(int id_usuario, string bpin_proyecto)
        {
            string outTxt = "";
            outTxt = Models.clsUsuarios.addSeguirProyecto(id_usuario,bpin_proyecto);
            return outTxt;
        }
        public string retirarseGrupoAuditor(int id_usuario, int id_grupo)
        {
            string outTxt = "";
            outTxt = Models.clsUsuarios.retirarseGrupoAuditor(id_usuario, id_grupo);
            return outTxt;
        }

    }
}