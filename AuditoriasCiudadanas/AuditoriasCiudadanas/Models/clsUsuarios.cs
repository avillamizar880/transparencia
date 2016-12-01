using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

namespace AuditoriasCiudadanas.Models
{
    public class clsUsuarios
    {
        static string cadTransparencia = ConfigurationManager.ConnectionStrings["Transparencia"].ConnectionString;
        
        public static string insertarUsuario(string nombre,string email,
            string celular,string hash_clave,int idperfil,int id_departamento,int id_municipio)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@Nombre", SqlDbType.VarChar, "", ParameterDirection.Input,400));
            parametros.Add(new PaParams("@email", SqlDbType.VarChar, "", ParameterDirection.Input,200));
            parametros.Add(new PaParams("@Celular", SqlDbType.VarChar, "", ParameterDirection.Input,15));
            parametros.Add(new PaParams("@hash_clave", SqlDbType.VarChar, "", ParameterDirection.Input,200));
            parametros.Add(new PaParams("@puntaje", SqlDbType.VarChar, "", ParameterDirection.Input,200));
            parametros.Add(new PaParams("@IdPerfil", SqlDbType.Int, "", ParameterDirection.Input));
            parametros.Add(new PaParams("@Id_dep", SqlDbType.Int, "", ParameterDirection.Input));
            parametros.Add(new PaParams("@Id_munic", SqlDbType.Int, "", ParameterDirection.Input));
            parametros.Add(new PaParams("@IdUsuario", SqlDbType.VarChar, "", ParameterDirection.Output,100));
            Data = DbManagement.getDatos("dbo.pa_ins_usuario", CommandType.StoredProcedure, cadTransparencia, parametros);
            return "";
        }

        public static string cambiarClave(string id_usuario, string hash_clave_ant,string hash_clave_new) {
            string outTxt = "";
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@id_usuario", SqlDbType.VarChar, "", ParameterDirection.Input, 100));
            parametros.Add(new PaParams("@hash_clave", SqlDbType.VarChar, "", ParameterDirection.Input, 200));

            Data = DbManagement.getDatos("dbo.pa_upt_clave", CommandType.StoredProcedure, cadTransparencia, parametros);
            return outTxt;
        
        }

        public static string validaLogin(string email, string hash_clave) {
            string outTxt = "";
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@email", SqlDbType.VarChar, email, ParameterDirection.Input, 100));
            parametros.Add(new PaParams("@hash_clave", SqlDbType.VarChar, hash_clave, ParameterDirection.Input, 100));
            parametros.Add(new PaParams("@estado", SqlDbType.VarChar, "", ParameterDirection.Output));
            parametros.Add(new PaParams("@id_usuario", SqlDbType.VarChar, "", ParameterDirection.Output, 100));
            Data = DbManagement.getDatos("dbo.pa_upt_clave", CommandType.StoredProcedure, cadTransparencia, parametros);
            return outTxt;
        
        }
    }
}