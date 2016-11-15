using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditoriasCiudadanas.Models
{
    public class PaParams
    {

        private string Param;
        private SqlDbType TipoParam;
        private object ValorParam;
        private ParameterDirection direccion;

        private int longitud;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Parametro">Nombre del parametro de la base de datos</param>
        /// <param name="TiposParametro">Tipo de dato</param>
        /// <param name="ValorParametro">Valor parametro</param>
        /// <param name="direction">Dirección (input u output)</param>
        /// <param name="longitud">Tamaño del parametro</param>
        /// <remarks></remarks>


        public PaParams(string Parametro, SqlDbType TiposParametro, object ValorParametro, ParameterDirection direction = ParameterDirection.InputOutput, int longitud = int.MaxValue)
        {
            this.Param = Parametro;
            this.TipoParam = TiposParametro;
            this.ValorParam = ValorParametro;
            this.direccion = direction;
            this.longitud = longitud;

        }

        public string getNombre()
        {
            return this.Param;
        }

        public SqlDbType getTipoDato()
        {
            return this.TipoParam;
        }

        public object getValor()
        {
            return this.ValorParam;
        }

        public object getLongitud()
        {
            return this.longitud;
        }

        public object getDireccion()
        {
            return this.direccion;
        }

        public object valor
        {
            set { ValorParam = value; }
        }
        
    }

}
