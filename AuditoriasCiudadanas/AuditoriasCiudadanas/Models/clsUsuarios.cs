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
            string idUsuario = "";
            parametros.Add(new PaParams("@Nombre", SqlDbType.VarChar, nombre, ParameterDirection.Input,400));
            parametros.Add(new PaParams("@email", SqlDbType.VarChar, email, ParameterDirection.Input,200));
            parametros.Add(new PaParams("@Celular", SqlDbType.VarChar, celular, ParameterDirection.Input,15));
            parametros.Add(new PaParams("@hash_clave", SqlDbType.VarChar, hash_clave, ParameterDirection.Input,200));
            parametros.Add(new PaParams("@puntaje", SqlDbType.VarChar, "", ParameterDirection.Input,200));
            parametros.Add(new PaParams("@IdPerfil", SqlDbType.Int, id_perfil, ParameterDirection.Input));
            parametros.Add(new PaParams("@Id_dep", SqlDbType.VarChar, id_departamento, ParameterDirection.Input,15));
            parametros.Add(new PaParams("@Id_munic", SqlDbType.VarChar, id_municipio, ParameterDirection.Input,15));
            parametros.Add(new PaParams("@idUsuario", SqlDbType.Int, idUsuario, ParameterDirection.Output));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_ins_usuario", CommandType.StoredProcedure, cadTransparencia, parametros);
            if (Data.Count > 1)
            {
                if (Data[1].Rows.Count > 0)
                {
                    cod_error = Data[1].Rows[0]["cod_error"].ToString();
                    mensaje_error = Data[1].Rows[0]["mensaje_error"].ToString();
                    if (cod_error.Equals("0")) {
                        idUsuario = Data[1].Rows[0]["idUsuario"].ToString();
                    }
                }
            }
            if (mensaje_error.ToUpper().IndexOf("UNIQUE KEY")>-1) {
                mensaje_error = "Esta cuenta ya existe";
            } 
            //Violation of UNIQUE KEY constraint 'AK_email'. Cannot insert duplicate key in object 'dbo.Usuario'.
            outTxt=cod_error + "<||>" + mensaje_error + "<||>" + idUsuario;
            return outTxt;
        }
        
        public static string cambiarClave(int id_usuario, string hash_clave_ant,string hash_clave_new) {
            string outTxt = "";
            string cod_error = "-1";
            string mensaje_error = "@ERROR";
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@id_usuario", SqlDbType.Int, id_usuario, ParameterDirection.Input));
            parametros.Add(new PaParams("@hash_clave", SqlDbType.VarChar, hash_clave_new, ParameterDirection.Input, 200));
            parametros.Add(new PaParams("@hash_clave_ant", SqlDbType.VarChar, hash_clave_ant, ParameterDirection.Input, 200));
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
            parametros.Add(new PaParams("@nombre", SqlDbType.VarChar, "", ParameterDirection.Output));
            parametros.Add(new PaParams("@estadoencuesta", SqlDbType.VarChar, "", ParameterDirection.Output));

            Data = DbManagement.getDatos("dbo.pa_valida_login", CommandType.StoredProcedure, cadTransparencia, parametros);
            if (Data.Count > 1)
            {
                if (Data[1].Rows.Count > 0)
                {
                    outTxt = Data[1].Rows[0]["estado"].ToString() + "<||>" + Data[1].Rows[0]["id_usuario"].ToString() + "<||>" + Data[1].Rows[0]["id_perfil"].ToString() + "<||>" + Data[1].Rows[0]["id_rol"].ToString() + "<||>" + Data[1].Rows[0]["nombre"].ToString() + "<||>" + Data[1].Rows[0]["estadoencuesta"].ToString();
                }
            }
            else {
                outTxt = "-1<||>Error en validacion credenciales";
            }
            
            return outTxt;
        
        }

        public static string addGrupoAuditor(int id_usuario, int id_grupo, string bpinproyecto,string motivo) {
            string outTxt = "";
            string cod_error = "-1";
            string mensaje_error = "@ERROR";
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@id_usuario", SqlDbType.Int, id_usuario, ParameterDirection.Input));
            if (id_grupo <= 0){
                parametros.Add(new PaParams("@id_grupo", SqlDbType.Int, System.DBNull.Value, ParameterDirection.Input));
            }
            else {
                parametros.Add(new PaParams("@id_grupo", SqlDbType.Int, id_grupo, ParameterDirection.Input));
            }
            parametros.Add(new PaParams("@codigoBPIN", SqlDbType.VarChar, bpinproyecto, ParameterDirection.Input,15));
            parametros.Add(new PaParams("@motivocreacion", SqlDbType.VarChar, motivo, ParameterDirection.Input, 500));
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

        public static string delSeguirProyecto(int id_usuario, string bpinproyecto)
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
            Data = DbManagement.getDatos("dbo.pa_del_seguir_proy", CommandType.StoredProcedure, cadTransparencia, parametros);
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

        public static string retirarseGrupoAuditor(int id_usuario, int id_grupo)
        {
            string outTxt = "";
            string cod_error = "-1";
            string mensaje_error = "@ERROR";
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@id_usuario", SqlDbType.Int, id_usuario, ParameterDirection.Input));
            parametros.Add(new PaParams("@id_grupo", SqlDbType.Int, id_grupo, ParameterDirection.Input));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_del_usu_gac", CommandType.StoredProcedure, cadTransparencia, parametros);
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
        
        public static List<DataTable> obtDatosUsuario(int id_usuario) {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@id_usuario", SqlDbType.Int, id_usuario, ParameterDirection.Input));
            Data = DbManagement.getDatos("dbo.pa_obt_usuario", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }

        public static List<DataTable> obtDatosUsuarioByHash(string hash_codigo)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@hash_codigo", SqlDbType.VarChar, hash_codigo, ParameterDirection.Input,64));
            Data = DbManagement.getDatos("dbo.pa_obt_usuario_hash", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }

        public static List<DataTable> obtDatosUsuarioByName(string nombre, int idUsuarioConsulta)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@nombre", SqlDbType.VarChar, nombre, ParameterDirection.Input));
            parametros.Add(new PaParams("@idUsuarioConsulta", SqlDbType.Int, idUsuarioConsulta, ParameterDirection.Input));
            Data = DbManagement.getDatos("dbo.pa_obt_usuario_x_nombre", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }

        public static string updCodigoVerifica(int id_usuario, string hash_codigo)
        {
            string outTxt = "";
            string cod_error = "-1";
            string mensaje_error = "@ERROR";
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@Id_Usuario", SqlDbType.Int, id_usuario, ParameterDirection.Input));
            parametros.Add(new PaParams("@hash_codigo", SqlDbType.VarChar, hash_codigo, ParameterDirection.Input, 200));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_upd_cod_verificacion", CommandType.StoredProcedure, cadTransparencia, parametros);
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

        

    public static List<DataTable> obtPerfilUsuario(int id_usuario)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@id_usuario", SqlDbType.Int, id_usuario, ParameterDirection.Input));
            Data = DbManagement.getDatos("dbo.pa_obt_perfil", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }

        public static List<DataTable> obtRankingD(int id_usuario)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@id_usuario", SqlDbType.Int, id_usuario, ParameterDirection.Input));
            Data = DbManagement.getDatos("dbo.pa_obt_ranking", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }

        public static string activarCuentaUsuario(int id_usuario) {
        string outTxt = "";
        string cod_error = "-1";
        string mensaje_error = "@ERROR";
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        parametros.Add(new PaParams("@id_usuario", SqlDbType.Int, id_usuario, ParameterDirection.Input));
        parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
        parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
        Data = DbManagement.getDatos("dbo.pa_valida_registro", CommandType.StoredProcedure, cadTransparencia, parametros);
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


    public static string validaEmail(string email)
    {
        string outTxt = "";
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        parametros.Add(new PaParams("@email", SqlDbType.VarChar, email, ParameterDirection.Input, 100));
        parametros.Add(new PaParams("@id_usuario", SqlDbType.Int, "", ParameterDirection.Output));
        parametros.Add(new PaParams("@cod_verifica", SqlDbType.VarChar, "", ParameterDirection.Output));
        Data = DbManagement.getDatos("dbo.pa_valida_email", CommandType.StoredProcedure, cadTransparencia, parametros);
        if (Data.Count > 1)
        {
            if (Data[1].Rows.Count > 0)
            {
                outTxt = Data[1].Rows[0]["id_usuario"].ToString() + "<||>" + Data[1].Rows[0]["cod_verifica"].ToString();
            }
        }
        else
        {
            outTxt = "-1<||>Error en validacion credenciales";
        }

        return outTxt;

    }

    public static string cambiarClaveOlvido(int id_usuario, string hash_clave_new)
    {
        string outTxt = "";
        string cod_error = "-1";
        string mensaje_error = "@ERROR";
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        parametros.Add(new PaParams("@id_usuario", SqlDbType.Int, id_usuario, ParameterDirection.Input));
        parametros.Add(new PaParams("@hash_clave", SqlDbType.VarChar, hash_clave_new, ParameterDirection.Input, 200));
        parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
        parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
        Data = DbManagement.getDatos("dbo.pa_upd_clave_olvido", CommandType.StoredProcedure, cadTransparencia, parametros);
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

    public static string actualizarDatosUsu(int id_usuario, string nombre,string divipola,string celular)
    {
        string outTxt = "";
        string cod_error = "-1";
        string mensaje_error = "@ERROR";
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        parametros.Add(new PaParams("@idUsuario", SqlDbType.Int, id_usuario, ParameterDirection.Input));
        parametros.Add(new PaParams("@nombre", SqlDbType.VarChar, nombre, ParameterDirection.Input, 400));
        parametros.Add(new PaParams("@celular", SqlDbType.VarChar, celular, ParameterDirection.Input, 15));
        parametros.Add(new PaParams("@divipola", SqlDbType.VarChar, divipola, ParameterDirection.Input, 15));
        parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
        parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
        Data = DbManagement.getDatos("dbo.pa_upd_info_usuario", CommandType.StoredProcedure, cadTransparencia, parametros);
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