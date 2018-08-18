using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Generic;

namespace AuditoriasCiudadanas.Views.Usuarios
{
    public partial class actualizarDatos : App_Code.PageSession
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }

        public string formato(string cadena)
        {
            return HttpUtility.HtmlEncode(cadena).Replace("\r", " ").Replace("\n", " ");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string id_usuario = "";
            string nombre = "";
            string email = "";
            string celular = "";
            string ciudad = "";
            string depto = "";
            string estado = "";
            string nom_perfil = "";

            NameValueCollection pColl = Request.Params;

            if (Session["idUsuario"] != null)
            {
                id_usuario = Session["idUsuario"].ToString();
            }
            if (pColl.AllKeys.Contains("id_usuario"))
            {
                id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
            }

            DataTable dt_departamento = new DataTable();
            DataTable dt_municipio = new DataTable();
            AuditoriasCiudadanas.Controllers.GeneralController datos = new AuditoriasCiudadanas.Controllers.GeneralController();
            dt_departamento = datos.listarDepartamentos();
            //dt_municipio = datos.obtMunicipios();
            addDll(ddlDepartamento, dt_departamento);
            //addDll(ddlMunicipio, dt_municipio);

            hdIdUsuario.Value = id_usuario;
            int idusuario = Convert.ToInt16(id_usuario);
            AuditoriasCiudadanas.Controllers.UsuariosController datos_usu = new AuditoriasCiudadanas.Controllers.UsuariosController();
            DataTable dtDatos = datos_usu.obtPerfilUsuarioTabla(idusuario);
            if (dtDatos.Rows.Count > 0)
            {
                nombre = dtDatos.Rows[0]["nombre"].ToString().Trim();
                email = dtDatos.Rows[0]["email"].ToString().Trim();
                celular = dtDatos.Rows[0]["Celular"].ToString().Trim();
                ciudad = dtDatos.Rows[0]["codigoCiudad"].ToString().Trim();
                depto = dtDatos.Rows[0]["codigoDepto"].ToString().Trim();
                estado = dtDatos.Rows[0]["Estado"].ToString().Trim();
                nom_perfil = dtDatos.Rows[0]["nom_perfil"].ToString().Trim();
            }

            txtNombre.Value = nombre;
            txtEmail.Value = email;
            txtCelular.Value = celular;
            txtEstado.Value = estado;
            ddlDepartamento.SelectedValue = depto;
            hdCodMunicipio.Value = ciudad;
            //ddlMunicipio.SelectedValue = depto + ciudad;
            //Response.Write(outTxt);

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