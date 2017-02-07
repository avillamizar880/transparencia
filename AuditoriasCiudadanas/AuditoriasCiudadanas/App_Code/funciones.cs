using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.IO; 


namespace AuditoriasCiudadanas.App_Code
{
    public class funciones
    {
        public string SHA256Encripta(string input)
        {
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = provider.ComputeHash(inputBytes);

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                output.Append(hashedBytes[i].ToString("x2").ToLower());

            return output.ToString();
        }

      
        public string convertToJson(DataTable dt)
        {
            dt.TableName = "tabla";
            string JSONresult;
            JSONresult = "{\"Head\":" + JsonConvert.SerializeObject(dt) + "}";
            return JSONresult;
        }

        public string converToJson_Linq(DataTable dt)
        {
            var lst = dt.AsEnumerable()
            .Select(r => r.Table.Columns.Cast<DataColumn>()
                .Select(c => new KeyValuePair<string, object>(c.ColumnName, r[c.Ordinal])
               ).ToDictionary(z => z.Key, z => z.Value)
            ).ToList();
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Serialize(lst);

        }
    }
}