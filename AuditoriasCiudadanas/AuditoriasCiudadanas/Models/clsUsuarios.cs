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
            string celular,string hash_clave,int id_perfil,int id_departamento,int id_municipio)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            string cod_error = "-1";
            string mensaje_error = "@ERROR";
            parametros.Add(new PaParams("@IdUsuario", SqlDbType.Int, 0, ParameterDirection.Input));
            parametros.Add(new PaParams("@Nombre", SqlDbType.VarChar, nombre, ParameterDirection.Input,400));
            parametros.Add(new PaParams("@email", SqlDbType.VarChar, email, ParameterDirection.Input,200));
            parametros.Add(new PaParams("@Celular", SqlDbType.VarChar, celular, ParameterDirection.Input,15));
            parametros.Add(new PaParams("@hash_clave", SqlDbType.VarChar, hash_clave, ParameterDirection.Input,200));
            parametros.Add(new PaParams("@puntaje", SqlDbType.VarChar, "", ParameterDirection.Input,200));
            parametros.Add(new PaParams("@IdPerfil", SqlDbType.Int, id_perfil, ParameterDirection.Input));
            parametros.Add(new PaParams("@Id_dep", SqlDbType.Int, id_departamento, ParameterDirection.Input));
            parametros.Add(new PaParams("@Id_munic", SqlDbType.Int, id_municipio, ParameterDirection.Input));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_ins_usuario", CommandType.StoredProcedure, cadTransparencia, parametros);
           
            return cod_error + "<||>" + mensaje_error;
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