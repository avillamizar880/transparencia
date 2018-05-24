using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Data;

namespace AuditoriasCiudadanas.Views.Valoracion
{
   
    
    public partial class configuraEncuestas : App_Code.PageSession
    {
        
        
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string opc = "";
            string id_usuario = "";
            string bpin_proyecto = "";
            NameValueCollection pColl = Request.Params;

            if (pColl.AllKeys.Contains("id_usuario"))
            {
                id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
            }

            if (String.IsNullOrEmpty(id_usuario))
            {
                if (Session["idUsuario"] != null)
                {
                    hdIdUsuario.Value = Session["idUsuario"].ToString();
                }
            } 
            else {
                hdIdUsuario.Value = id_usuario;
            }
           
            if (pColl.AllKeys.Contains("opc"))
            {
                opc = Request.Params.GetValues("opc")[0].ToString();
            }

            if (pColl.AllKeys.Contains("bpin_proyecto"))
            {
                bpin_proyecto = Request.Params.GetValues("bpin_proyecto")[0].ToString();
            }

            hdOpcion.Value = opc;
            hdIdProyecto.Value = bpin_proyecto;
           
            AuditoriasCiudadanas.Controllers.ValoracionController datos = new AuditoriasCiudadanas.Controllers.ValoracionController();
            //evaluar si ya existe un cuestionario relacionado al proyecto
            if (!string.IsNullOrEmpty(bpin_proyecto))
            {
                DataTable dtCuestionario = datos.obtEvaluacionPosteriorBpin(bpin_proyecto);
                if (dtCuestionario.Rows.Count > 0)
                {
                    hdIdCuestionario.Value = dtCuestionario.Rows[0]["idCuestionario"].ToString().Trim();
                    txtTitulo.Value = dtCuestionario.Rows[0]["Titulo"].ToString().Trim();
                    txtDescripcion.Value = dtCuestionario.Rows[0]["Descripcion"].ToString().Trim();
                }

            }
            else
            {
                if (opc.Equals("2"))
                {
                    //evaluar si existe un cuestionario de ayuda configurado
                    string outTxt = datos.ObtIdCuestionarioAyuda();
                    if (!string.IsNullOrEmpty(outTxt))
                    {
                        string[] separador = new string[] { "<||>" };
                        string [] result = outTxt.Split(separador, StringSplitOptions.None);
                        if (result[0] != "0")
                        {
                            hdIdCuestionario.Value = result[0];
                            txtTitulo.Value = result[1];
                            txtDescripcion.Value = result[2];

                        }
                        
                    }
                }
            }


            DataTable dt_tipos = new DataTable();
            dt_tipos = datos.listarTipoCuestionario();
            addDll(ddlTipoCuestionario, dt_tipos);

            //if (!string.IsNullOrEmpty(opc)) {
            //    ddlTipoCuestionario.SelectedIndex = ddlTipoCuestionario.Items.IndexOf(ddlTipoCuestionario.Items.FindByText("2"));
            //    ddlTipoCuestionario.Enabled = false;
            //}
           
            //add rangos
            for (int i = 1; i <= 10; i++) {
                ddlEscalaInicial.Items.Add(i.ToString());
                ddlEscalaInicial.Disabled = true;
                ddlEscalaFinal.Items.Add(i.ToString());
            }
            ddlEscalaInicial.SelectedIndex = 0;
            ddlEscalaFinal.SelectedIndex = 4;
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
                    List<ListItem> items = new List<ListItem>();
                    items.Add(new ListItem(ddl.ToolTip, "0"));
                    ddl.Items.AddRange(items.ToArray());
                }
            }
        }
    }
}