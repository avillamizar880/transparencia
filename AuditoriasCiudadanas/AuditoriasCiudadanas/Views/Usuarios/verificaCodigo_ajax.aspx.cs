using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;

namespace AuditoriasCiudadanas.Views.Usuarios
{
    public partial class verificaCodigo_ajax : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string codigo = "";
            string id_usuario = "";
            int id_usuario_aux = 0;
            string outTxt = "";
            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                //string nombre,string email,string celular,string hash_clave,int idperfil,int id_departamento,int id_municipio
                NameValueCollection pColl = Request.Form;
                if (pColl.AllKeys.Contains("id_usuario"))
                {
                    id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
                    if (!string.IsNullOrEmpty(id_usuario))
                        id_usuario_aux = Convert.ToInt16(id_usuario);
                }

                if (pColl.AllKeys.Contains("codigo"))
                {
                    codigo = Request.Params.GetValues("codigo")[0].ToString();
                }
                AuditoriasCiudadanas.Controllers.UsuariosController datos = new AuditoriasCiudadanas.Controllers.UsuariosController();
                DataTable dtInfo = datos.obtDatosUsuario(id_usuario_aux);
                if (dtInfo.Rows.Count > 0)
                {
                    string email = dtInfo.Rows[0]["email"].ToString().Trim();
                    string codigo_verifica = dtInfo.Rows[0]["cod_verifica"].ToString().Trim();
                    if (codigo_verifica.Substring(0, 6) == (codigo.Trim()))
                    {
                        outTxt = "0<||>";
                    }
                    else
                    {
                        outTxt = "-1<||>Código no coincide";
                    }

                }

               
            }

            Response.Write(outTxt);
        }

    }
}