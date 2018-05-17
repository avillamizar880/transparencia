using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace AuditoriasCiudadanas.Models
{
    public class clsNotificacion
    {
        static string cadTransparencia = ConfigurationManager.ConnectionStrings["Transparencia"].ConnectionString;

        public static List<DataTable> ObtNotificaciones(int IdUsuario, char Estado)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@idUsuario", SqlDbType.Int, IdUsuario, ParameterDirection.Input));
            parametros.Add(new PaParams("@estado", SqlDbType.Char, Estado, ParameterDirection.Input, 1));
            Data = DbManagement.getDatos("dbo.pa_obt_notificacion", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }
    }
}