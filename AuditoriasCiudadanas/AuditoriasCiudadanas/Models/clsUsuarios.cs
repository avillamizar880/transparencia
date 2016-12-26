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
            string celular,string hash_clave,int id_perfil,string id_departamento,string id_municipio)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            string cod_error = "-1";
            string mensaje_error = "@ERROR";
            string outTxt = "";
            parametros.Add(new PaParams("@Nombre", SqlDbType.VarChar, nombre, ParameterDirection.Input,400));
            parametros.Add(new PaParams("@email", SqlDbType.VarChar, email, ParameterDirection.Input,200));
            parametros.Add(new PaParams("@Celular", SqlDbType.VarChar, celular, ParameterDirection.Input,15));
            parametros.Add(new PaParams("@hash_clave", SqlDbType.VarChar, hash_clave, ParameterDirection.Input,200));
            parametros.Add(new PaParams("@puntaje", SqlDbType.VarChar, "", ParameterDirection.Input,200));
            parametros.Add(new PaParams("@IdPerfil", SqlDbType.Int, id_perfil, ParameterDirection.Input));
            parametros.Add(new PaParams("@Id_dep", SqlDbType.VarChar, id_departamento, ParameterDirection.Input,15));
            parametros.Add(new PaParams("@Id_munic", SqlDbType.VarChar, id_municipio, ParameterDirection.Input,15));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_ins_usuario", CommandType.StoredProcedure, cadTransparencia, parametros);
            if (Data.Count > 1)
            {
                if (Data[1].Rows.Count > 0)
                {
                    cod_error = Data[1].Rows[0]["cod_error"].ToString();
                    mensaje_error = Data[1].Rows[0]["mensaje_error"].ToString();
                }
            }
            if (mensaje_error.ToUpper().IndexOf("UNIQUE KEY")>-1) {
                mensaje_error = "Esta cuenta ya existe";
            } 
            //Violation of UNIQUE KEY constraint 'AK_email'. Cannot insert duplicate key in object 'dbo.Usuario'.
            outTxt=cod_error + "<||>" + mensaje_error;
            return outTxt;
        }
        
        public static string cambiarClave(int id_usuario, string hash_clave_ant,string hash_clave_new) {
            string outTxt = "";
            string cod_error = "-1";
            string mensaje_error = "@ERROR";
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@id_usuario", SqlDbType.Int, id_usuario, ParameterDirection.Input));
            parametros.Add(new PaParams("@hash_clave", SqlDbType.VarChar, hash_clave_ant, ParameterDirection.Input, 200));
            parametros.Add(new PaParams("@hash_clave_ant", SqlDbType.VarChar, hash_clave_new, ParameterDirection.Input, 200));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_upd_clave", CommandType.StoredProcedure, cadTransparencia, parametros);
            if (Data.Count > 1 )
            {
                if (Data[1].Rows.Count > 0){
                            cod_error = Data[1].Rows[0]["cod_error"].ToString();
                            mensaje_error = Data[1].Rows[0]["mensaje_error"].ToString();
                 }
            }
            
            outTxt = cod_error + "<||>" + mensaje_error;
            return outTxt;
        
        }

        public static string validaLogin(string email, string hash_clave) {
            string outTxt = "";
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@email", SqlDbType.VarChar, email, ParameterDirection.Input, 100));
            parametros.Add(new PaParams("@hash_clave", SqlDbType.VarChar, hash_clave, ParameterDirection.Input, 100));
            parametros.Add(new PaParams("@estado", SqlDbType.Int, "", ParameterDirection.Output));
            parametros.Add(new PaParams("@id_usuario", SqlDbType.Int, "", ParameterDirection.Output));
            parametros.Add(new PaParams("@id_perfil", SqlDbType.Int, "", ParameterDirection.Output));
            parametros.Add(new PaParams("@id_rol", SqlDbType.VarChar, "", ParameterDirection.Output));

            Data = DbManagement.getDatos("dbo.pa_valida_login", CommandType.StoredProcedure, cadTransparencia, parametros);
            if (Data.Count > 1)
            {
                if (Data[1].Rows.Count > 0)
                {
                    outTxt = Data[1].Rows[0]["estado"].ToString() + "<||>" + Data[1].Rows[0]["id_usuario"].ToString() + "<||>" + Data[1].Rows[0]["id_perfil"].ToString() + "<||>" + Data[1].Rows[0]["id_rol"].ToString();
                }
            }
            else {
                outTxt = "-1<||>Error en validacion credenciales";
            }
            
            return outTxt;
        
        }

        public static string addGrupoAuditor(int id_usuario, int id_grupo, string bpinproyecto) {
            string outTxt = "";
            string cod_error = "-1";
            string mensaje_error = "@ERROR";
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@id_usuario", SqlDbType.Int, id_usuario, ParameterDirection.Input));
            parametros.Add(new PaParams("@id_grupo", SqlDbType.Int, id_grupo, ParameterDirection.Input));
            parametros.Add(new PaParams("@codigoBPIN", SqlDbType.VarChar, bpinproyecto, ParameterDirection.Input,15));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_ins_usu_gac", CommandType.StoredProcedure, cadTransparencia, parametros);
            if (Data.Count > 1)
            {
                if (Data[1].Rows.Count > 0)
                {
                    cod_error = Data[1].Rows[0]["cod_error"].ToString();
                    mensaje_error = Data[1].Rows[0]["mensaje_error"].ToString();
                }
            }
            outTxt= cod_error + "<||>" + mensaje_error;
            return outTxt;
        }

        public static string addSeguirProyecto(int id_usuario, string bpinproyecto)
        {
            string outTxt = "";
            string cod_error = "-1";
            string mensaje_error = "@ERROR";
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@id_usuario", SqlDbType.Int, id_usuario, ParameterDirection.Input));
            parametros.Add(new PaParams("@codigoBPIN", SqlDbType.VarChar, bpinproyecto, ParameterDirection.Input, 15));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_ins_seguir_proy", CommandType.StoredProcedure, cadTransparencia, parametros);
            if (Data.Count > 1)
            {
                if (Data[1].Rows.Count > 0)
                {
                    cod_error = Data[1].Rows[0]["cod_error"].ToString();
                    mensaje_error = Data[1].Rows[0]["mensaje_error"].ToString();
                }
            }
            outTxt = cod_error + "<||>" + mensaje_error;
            return outTxt;
        }
    }
}