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

        public string addGrupoAuditor(int id_usuario, int id_grupo, string bpin_proyecto,string motivo) {
            string outTxt = "";
            outTxt = Models.clsUsuarios.addGrupoAuditor(id_usuario, id_grupo, bpin_proyecto,motivo);
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

        public DataTable obtDatosUsuario(int id_usuario) {
            DataTable dtInfo = new DataTable();
            dtInfo = Models.clsUsuarios.obtDatosUsuario(id_usuario)[0];
            return dtInfo;
        }

        public String updCodigoVerifica(int id_usuario, string hash_codigo)
        {
            String outTxt = "";
            outTxt = Models.clsUsuarios.updCodigoVerifica(id_usuario, hash_codigo);
            return outTxt;
        }

        public DataTable obtDatosUsuarioByHash(string hash_codigo)
        {
            DataTable dtInfo = new DataTable();
            dtInfo = Models.clsUsuarios.obtDatosUsuarioByHash(hash_codigo)[0];
            return dtInfo;
        }
    }
}