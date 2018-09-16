using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Data;

namespace AuditoriasCiudadanas.Views.Estadisticas
{
    public partial class infoEstadisticas : App_Code.PageSession
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
 
        protected void Page_Load(object sender, EventArgs e)
        {
            string outTxt = "";
            List<DataTable> lstCategorias = new List<DataTable>();
            DataTable dtGrupos = new DataTable();
            DataTable dtReportes = new DataTable();
            AuditoriasCiudadanas.Controllers.EstadisticasController datos_func = new AuditoriasCiudadanas.Controllers.EstadisticasController();
            lstCategorias = datos_func.obtCategorias();


            dtGrupos = lstCategorias[0];
            dtReportes = lstCategorias[1];
            addDll(ddlCategoria, dtGrupos);
            addDll(ddlTipoReporte, dtReportes);

            if (Session["idUsuario"] != null)
            {
                hdIdUsuario.Value = Session["idUsuario"].ToString();
            }
            AuditoriasCiudadanas.Controllers.EstadisticasController datos = new AuditoriasCiudadanas.Controllers.EstadisticasController();
            outTxt = "<script>" + datos.obtEstadisticas("all") + "</script>";
            Response.Write(outTxt);
        }

        protected void addDll(DropDownList ddl, DataTable dt)
        {
            if (!ddl.ToolTip.Equals(""))
            {
                List<ListItem> items = new List<ListItem>();
                if (dt.Rows.Count > 0)
                {
                    //DataTable dt_aux = new DataTable();
                    //dt_aux = dt.Clone();
                    //dt_aux.Rows.Add("0", ddl.ToolTip);
                    //foreach (DataRow fila in dt.Rows)
                    //{
                    //    dt_aux.ImportRow(fila);
                    //}
                    //ddl.DataSource = dt_aux;
                    //ddl.DataBind();
                  
                    
                    if (ddl.ID.Equals("ddlCategoria"))
                    {
                         items.Add(new ListItem(ddl.ToolTip, "0"));
                        foreach (DataRow fila in dt.Rows)
                        {
                            items.Add(new ListItem(fila["nom_grupo"].ToString(), fila["id_grupo_estadistica"].ToString()));
                        }
                    }
                    else {
                        ListItem itemTipo1 = new ListItem(ddl.ToolTip, "0");
                        itemTipo1.Attributes.Add("grupo", "0");
                        itemTipo1.Attributes.Add("filtros_fecha", "0");
                        items.Add(itemTipo1);

                        foreach (DataRow fila in dt.Rows)
                        {
                            ListItem itemTipo = new ListItem(fila["nom_tipo_estadistica"].ToString(),fila["id_tipo_estadistica"].ToString());
                            itemTipo.Attributes.Add("grupo", fila["id_grupo"].ToString());
                            itemTipo.Attributes.Add("filtros_fecha", fila["filtros_fecha"].ToString());
                            items.Add(itemTipo);
                        }
                    }
                    



                }
                else
                {
                    items.Add(new ListItem(ddl.ToolTip, "0"));
                    //ddl.Items.AddRange(items.ToArray());
                }
                ddl.Items.AddRange(items.ToArray());
            }
        }
    }
}