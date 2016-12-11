using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.General
{
    public partial class CreatePDF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                NameValueCollection pColl = Request.Params;
                //string nombre,string email,string celular,string hash_clave,int idperfil,int id_departamento,int id_municipio
                //HttpContext.Current.Request.RequestType
                if (pColl.AllKeys.Contains("nombre"))
                {


                    Controllers.PrintPDF pdf = new Controllers.PrintPDF();
                    pdf.htmlPDF(null, Request.PhysicalPath + "//"+ pColl.Get("nombre").ToString(), "<h1>basico</h1>");

                }
            }   

        }
    }
}