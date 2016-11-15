using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace AuditoriasCiudadanas.Models
{

    static public class EjemploMapaRegalias
    {
         static string cadMapaRegalias = ConfigurationManager.ConnectionStrings["MapaRegalias"].ConnectionString;

        static public  List<DataTable> getListadoDeTiposDeFiscalizacion() 
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            //parametros.Add(new PaParams("@PTOPE", SqlDbType.Int, valoPar(0), ParameterDirection.Input));
            //parametros.Add(new PaParams("@PROWID", SqlDbType.BigInt, valoPar(1), ParameterDirection.Input));
            //parametros.Add(new PaParams("@PREGIONAL", SqlDbType.VarChar, valoPar(2), ParameterDirection.Input, 2));
            //parametros.Add(new PaParams("@PSUCURSAL", SqlDbType.VarChar, valoPar(3), ParameterDirection.Input, 2));
            //parametros.Add(new PaParams("@PTLIST", SqlDbType.VarChar, valoPar(4), ParameterDirection.Input, 1));
            //parametros.Add(new PaParams("@PCODIUSU", SqlDbType.VarChar, valoPar(5), ParameterDirection.Input, 20));
            //parametros.Add(new PaParams("@PESTA", SqlDbType.VarChar, valoPar(6), ParameterDirection.Input, 2));
            //parametros.Add(new PaParams("@PTIPOSOL", SqlDbType.BigInt, valoPar(7), ParameterDirection.Input));
            //parametros.Add(new PaParams("@PNIT", SqlDbType.VarChar, valoPar(8), ParameterDirection.Input, 20));
            //parametros.Add(new PaParams("@MSG_ERR", SqlDbType.VarChar, null, ParameterDirection.Output, 200));
            //parametros.Add(new PaParams("@TOTAL_REG", SqlDbType.BigInt, null, ParameterDirection.Output, 18));
            Data = DbManagement.getDatos("dbo.ObtenerListadoDeTiposDeFiscalizacion", CommandType.StoredProcedure, cadMapaRegalias, parametros);
            return Data;
        }



    }
}
