using AuditoriasCiudadanas.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Usuarios
{
    public partial class notificaciones : System.Web.UI.Page
    {
        public string idUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["idUsuario"] != null)
                {

                    idUsuario = (string)Session["idUsuario"];
                    cargarNotifaciones(int.Parse(idUsuario));
                    
                    AuditoriasCiudadanas.Controllers.UsuariosController datos = new AuditoriasCiudadanas.Controllers.UsuariosController();

                    List<DataTable> rta = datos.obtPerfilUsuarioTablas(int.Parse(idUsuario));
                    NombreUsuario.Text = rta[0].Rows[0]["Nombre"].ToString();

                    string sigueTxt = "No sigue proyectos.";
                    int sigue = rta[1].Rows.Count;
                    if (sigue > 0) sigueTxt = "Sigue " + sigue.ToString() + " proyectos.";
                    lblSigue.Text = sigueTxt;

                    if (rta[4].Rows.Count > 0) LblEsAC.Text = " Es auditor ciudadano.";

                    //Diamantes y Estrellas
                    int CantProyectosDiaStar = rta[5].Rows.Count;

                    AuditoriasCiudadanas.Controllers.GeneralController datosX = new AuditoriasCiudadanas.Controllers.GeneralController();
                    DataTable fuente_info = datosX.ObtParametroGeneral("cant_estrellas_x_diamante");
                    int estrellas_x_diamantes = 999;
                    if (fuente_info.Rows.Count > 0)
                    {
                        estrellas_x_diamantes = (int)fuente_info.Rows[0]["ValNum"];

                    }

                    int diamantes = CantProyectosDiaStar / estrellas_x_diamantes;
                    int estrellas = CantProyectosDiaStar % estrellas_x_diamantes;


                    for (int i = 0; i < diamantes; i++)
                    {
                        SPDiamantes.InnerHtml += "<i class=\"fa fa-diamond fa-spin\" title=\"5 proyectos exitosos\"></i>";
                    }
                    for (int i = 0; i < estrellas; i++)
                    {
                        SPDiamantes.InnerHtml += "<i class=\"fa fa-star-o fa-spin\" title=\"1 proyectos exitoso\"></i>";
                    }

                    lblRanking.Text = datos.obtRankingUsuario(int.Parse(idUsuario)).ToString();
                }
            }
        }

        private void cargarNotifaciones(int idUsuario)
        {
            divNoNotificaciones.Visible = false;
            AuditoriasCiudadanas.Controllers.NotificacionController Datos = new AuditoriasCiudadanas.Controllers.NotificacionController();
            int cantidadNot = Datos.GetNotificacionesCount(idUsuario, '0');

            StringBuilder cadenaMensajes = new StringBuilder();

            if ( cantidadNot == 0)
            {
                divNoNotificaciones.Visible = true;
                pNotificaciones.Visible = false;
                tbNotificaciones.Visible = false;
            }
            lblCantNot.Text = cantidadNot.ToString();
            tbNotificaciones.InnerHtml = cadenaMensajes.ToString();

        }
    }
}