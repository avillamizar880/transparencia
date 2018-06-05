using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Generic;

namespace AuditoriasCiudadanas.Views.Audiencias
{
    public partial class RegistrarFechaAud : App_Code.PageSession
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            NameValueCollection pColl = Request.Params;
            string id_usuario = "";
            if (pColl.AllKeys.Contains("id_usuario"))
            {
                id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
            }
            else
            {
                if (Session["idUsuario"] != null)
                {
                    id_usuario = Session["idUsuario"].ToString();
                }
            }
            hdIdUsuario.Value = id_usuario;
            //pa_listar_tipoaudiencia
            DataTable dt_tipo_audiencia = new DataTable();
            AuditoriasCiudadanas.Controllers.AudienciasController datos = new AuditoriasCiudadanas.Controllers.AudienciasController();
            dt_tipo_audiencia = datos.listarTipoAudiencias();
            addDll(ddlTipoAudiencia, dt_tipo_audiencia);
        }
        protected void addDll(DropDownList ddl, DataTable dt)
        {
            if (!ddl.ToolTip.Equals(""))
            {
                if (dt.Rows.Count > 0)
                {
                    DataTable dt_aux = new DataTable();
                    dt_aux = dt.Clone();
                    dt_aux.Rows.Add("0", ddl.ToolTip);
                    foreach (DataRow fila in dt.Rows)
                    {
                        dt_aux.ImportRow(fila);
                    }
                    ddl.DataSource = dt_aux;
                    ddl.DataBind();
                }
                else
                {
                    List<ListItem> datos = new List<ListItem>();
                    datos.Add(new ListItem(ddl.ToolTip, "0"));
                    ddl.Items.AddRange(datos.ToArray());
                }
            }
        }
    }
}