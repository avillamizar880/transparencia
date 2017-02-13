using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace AuditoriasCiudadanas.Controllers
{
    public class UsuariosController
    {
        public string formato(string cadena)
        {
            return HttpUtility.HtmlEncode(cadena).Replace("\r", " ").Replace("\n", " ");
        }

        public String ValidaLogin(string email, string hash_clave) {
            String outTxt = "";

            outTxt = Models.clsUsuarios.validaLogin(email, hash_clave);
            return outTxt;
        }
      

        public String DatosInsercion(string nombre, string email,
            string celular, string hash_clave, int idperfil, string id_departamento, string id_municipio)
        {
            String outTxt = "";
            outTxt= Models.clsUsuarios.insertarUsuario(nombre,email,celular,hash_clave,idperfil,id_departamento,id_municipio);
            return outTxt;
        }

        public String CambiarClave(int id_usuario, string hash_clave_ant,string hash_clave_new) {
            String outTxt = "";
            outTxt = Models.clsUsuarios.cambiarClave(id_usuario,hash_clave_ant,hash_clave_new);
            return outTxt;
        }

        public String validaPeriodoClave(string id_usuario) {
            String outTxt = "";
            return outTxt;
        }

        public string addGrupoAuditor(int id_usuario, int id_grupo, string bpin_proyecto,string motivo) {
            string outTxt = "";
            outTxt = Models.clsUsuarios.addGrupoAuditor(id_usuario, id_grupo, bpin_proyecto,motivo);
            return outTxt;
        }

        public String insercionOtros(string nombre, string email,
            string celular, string hash_clave, int idperfil)
        {
            String outTxt = "";
            outTxt = Models.clsUsuarios.insertarUsuario(nombre, email, celular, hash_clave, idperfil, "", "");
            return outTxt;
        }

        public string addSeguirProyecto(int id_usuario, string bpin_proyecto)
        {
            string outTxt = "";
            outTxt = Models.clsUsuarios.addSeguirProyecto(id_usuario,bpin_proyecto);
            return outTxt;
        }
        public string retirarseGrupoAuditor(int id_usuario, int id_grupo)
        {
            string outTxt = "";
            outTxt = Models.clsUsuarios.retirarseGrupoAuditor(id_usuario, id_grupo);
            return outTxt;
        }

        public DataTable obtDatosUsuario(int id_usuario) {
            DataTable dtInfo = new DataTable();
            dtInfo = Models.clsUsuarios.obtDatosUsuario(id_usuario)[0];
            return dtInfo;
        }

        public String updCodigoVerifica(int id_usuario, string hash_codigo)
        {
            String outTxt = "";
            outTxt = Models.clsUsuarios.updCodigoVerifica(id_usuario, hash_codigo);
            return outTxt;
        }

        public DataTable obtDatosUsuarioByHash(string hash_codigo)
        {
            DataTable dtInfo = new DataTable();
            dtInfo = Models.clsUsuarios.obtDatosUsuarioByHash(hash_codigo)[0];
            return dtInfo;
        }

        public string obtPerfilUsuario(int id_usuario)
        {
            String outTxt = "";

            List<DataTable> listaInfo = new List<DataTable>();
            listaInfo = Models.clsUsuarios.obtPerfilUsuario(id_usuario);
            DataTable dtDatos = listaInfo[0];
            DataTable dtProySigo = listaInfo[1];
            DataTable dtProyInterventor = listaInfo[2];
            DataTable dtProySupervisor = listaInfo[3];
            DataTable dtProyAuditor = listaInfo[4];

            int misproyectos = 0;
            String infoproyectos = "";
            String nombre = "";
            String email = "";
            String Celular = "";
            String ciudad = "";
            String depto = "";
            String tipoAuditor = "";
            String fecha = "";
            String Estado = "";
            String nom_perfil = "";

            if (dtDatos.Rows.Count > 0)
            {
                nombre = formato(dtDatos.Rows[0]["nombre"].ToString().Trim());
                email = formato(dtDatos.Rows[0]["email"].ToString().Trim());
                Celular = formato(dtDatos.Rows[0]["Celular"].ToString().Trim());
                ciudad = formato(dtDatos.Rows[0]["ciudad"].ToString().Trim());
                depto = formato(dtDatos.Rows[0]["depto"].ToString().Trim());
                tipoAuditor = formato(dtDatos.Rows[0]["tipoAuditor"].ToString().Trim());
                fecha = formato(dtDatos.Rows[0]["fecha"].ToString().Trim());
                Estado = formato(dtDatos.Rows[0]["Estado"].ToString().Trim());
                nom_perfil = formato(dtDatos.Rows[0]["nom_perfil"].ToString().Trim());

                String divotrosdatos = "";

                if (!(String.IsNullOrEmpty(nom_perfil)))
                {
                    divotrosdatos += "<div class=\"col-sm-6\"> <label for=\"txtnom_perfil\">Perfil:</label>";
                    divotrosdatos += "<input type =\"text\" class=\"form-control\" id=\"txtnom_perfil\" value=\"" + nom_perfil + "\" readonly>";
                    divotrosdatos += "</div >";
                }
                if (!(String.IsNullOrEmpty(tipoAuditor)))
                {
                    divotrosdatos += "<div class=\"col-sm-6\"> <label for=\"txttipoAuditor\">Tipo Auditor:</label>";
                    divotrosdatos += "<input type =\"text\" class=\"form-control\" id=\"txttipoAuditor\" value=\"" + tipoAuditor + "\" readonly>";
                    divotrosdatos += "</div >";
                }
                if (!(String.IsNullOrEmpty(fecha)))
                {
                    divotrosdatos += "<div class=\"col-sm-6\"> <label for=\"txtfecha\">Fecha de Creación:</label>";
                    divotrosdatos += "<input type =\"text\" class=\"form-control\" id=\"txtfecha\" value=\"" + fecha + "\" readonly>";
                    divotrosdatos += "</div >";
                }

                outTxt += "$(\"#divOtrosDatos\").html('" + divotrosdatos + "');";
            }

            String divtxtNombre = "<input type =\"text\" class=\"form-control\" id=\"txtNombre\" value=\"" + nombre  + "\" readonly>";
            outTxt += "$(\"#divtxtNombre\").html('" + divtxtNombre + "');";

            String divtxtEmail = " <input type =\"email\" class=\"form-control\" id=\"txtEmail\" value=\"" + email + "\" readonly>";
            outTxt += "$(\"#divtxtEmail\").html('" + divtxtEmail + "');";

            String divtxtCelular = "<input type =\"tel\" class=\"form-control\" id=\"txtCelular\" value=\"" + Celular + "\" readonly>";
            outTxt += "$(\"#divtxtCelular\").html('" + divtxtCelular + "');";

            String divtxtEstado = "<input type =\"text\" class=\"form-control\" id=\"txtEstado\" value=\"" + Estado + "\" readonly>";
            outTxt += "$(\"#divtxtEstado\").html('" + divtxtEstado + "');";

            String divtxtDepto = "<input type =\"text\" class=\"form-control\" id=\"txtDepto\" value=\"" + depto + "\" readonly>";
            outTxt += "$(\"#divtxtDepto\").html('" + divtxtDepto + "');";

            String divtxtCiudad = "<input type =\"text\" class=\"form-control\" id=\"txtCiudad\" value=\"" + ciudad + "\" readonly>";
            outTxt += "$(\"#divtxtCiudad\").html('" + divtxtCiudad + "');";
            //proyectos


            if (dtProySigo.Rows.Count > 0)
            {
                infoproyectos += "<h4> Proyectos que sigue </ h4>";
                infoproyectos += "<div class=\"alert alert-info\">";
                infoproyectos += "<div class=\"table-responsive\"><table class=\"table table-hover table-striped\"><thead><tr><th>Codigo BPIN</th><th>Objeto</th><th>Entidad Ejecutora</th></tr></thead><tbody >";
                for (int i = 0; i <= dtProySigo.Rows.Count - 1; i++)
                {
                    infoproyectos += "<tr>";
                    infoproyectos += "<td>" + formato(dtProySigo.Rows[i]["codigoBPIN"].ToString().Trim()) + "</td>";
                    infoproyectos += "<td>" + formato(dtProySigo.Rows[i]["Objeto"].ToString().Trim()) + "</td>";
                    infoproyectos += "<td>" + formato(dtProySigo.Rows[i]["NomEntidad"].ToString().Trim()) + "</td>";
                    infoproyectos += "</tr>";
                }
                infoproyectos += "</tbody></table></div></div>";
                infoproyectos += "</div>";
                misproyectos++;
            }

            if (dtProyInterventor.Rows.Count > 0)
            {
                infoproyectos += "<h4> Proyectos de los cuales es interventor </ h4>";
                infoproyectos += "<div class=\"alert alert-info\">";
                infoproyectos += "<div class=\"table-responsive\"><table class=\"table table-hover table-striped\"><thead><tr><th>Codigo BPIN</th><th>Objeto</th><th>Entidad Ejecutora</th></tr></thead><tbody >";
                for (int i = 0; i <= dtProyInterventor.Rows.Count - 1; i++)
                {
                    infoproyectos += "<tr>";
                    infoproyectos += "<td>" + formato(dtProyInterventor.Rows[i]["codigoBPIN"].ToString().Trim()) + "</td>";
                    infoproyectos += "<td>" + formato(dtProyInterventor.Rows[i]["Objeto"].ToString().Trim()) + "</td>";
                    infoproyectos += "<td>" + formato(dtProyInterventor.Rows[i]["NomEntidad"].ToString().Trim()) + "</td>";
                    infoproyectos += "</tr>";
                }
                infoproyectos += "</tbody></table></div></div>";
                infoproyectos += "</div>";
                misproyectos++;
            }

            if (dtProySupervisor.Rows.Count > 0)
            {
                infoproyectos += "<h4> Proyectos de los cuales es supervisor </ h4>";
                infoproyectos += "<div class=\"alert alert-info\">";
                infoproyectos += "<div class=\"table-responsive\"><table class=\"table table-hover table-striped\"><thead><tr><th>Codigo BPIN</th><th>Objeto</th><th>Entidad Ejecutora</th></tr></thead><tbody >";
                for (int i = 0; i <= dtProySupervisor.Rows.Count - 1; i++)
                {
                    infoproyectos += "<tr>";
                    infoproyectos += "<td>" + formato(dtProySupervisor.Rows[i]["codigoBPIN"].ToString().Trim()) + "</td>";
                    infoproyectos += "<td>" + formato(dtProySupervisor.Rows[i]["Objeto"].ToString().Trim()) + "</td>";
                    infoproyectos += "<td>" + formato(dtProySupervisor.Rows[i]["NomEntidad"].ToString().Trim()) + "</td>";
                    infoproyectos += "</tr>";
                }
                infoproyectos += "</tbody></table></div></div>";
                infoproyectos += "</div>";
                misproyectos++;
            }

            if (dtProyAuditor.Rows.Count > 0)
            {
                infoproyectos += "<h4> Proyectos de los cuales es auditor </ h4>";
                infoproyectos += "<div class=\"alert alert-info\">";
                infoproyectos += "<div class=\"table-responsive\"><table class=\"table table-hover table-striped\"><thead><tr><th>Codigo BPIN</th><th>Objeto</th><th>Entidad Ejecutora</th></tr></thead><tbody >";
                for (int i = 0; i <= dtProyAuditor.Rows.Count - 1; i++)
                {
                    infoproyectos += "<tr>";
                    infoproyectos += "<td>" + formato(dtProyAuditor.Rows[i]["codigoBPIN"].ToString().Trim()) + "</td>";
                    infoproyectos += "<td>" + formato(dtProyAuditor.Rows[i]["Objeto"].ToString().Trim()) + "</td>";
                    infoproyectos += "<td>" + formato(dtProyAuditor.Rows[i]["NomEntidad"].ToString().Trim()) + "</td>";
                    infoproyectos += "</tr>";
                }
                infoproyectos += "</tbody></table></div></div>";
                infoproyectos += "</div>";
                misproyectos++;
            }


            if (misproyectos == 0)
            {
                infoproyectos += "No tiene relación con proyectos aún";
            }

            outTxt += "$(\"#divProyectosAud\").html('" + infoproyectos + "');";

            return outTxt;
        }

        public String activarCuentaUsuario(int id_usuario)
        {
            String outTxt = "";
            outTxt = Models.clsUsuarios.activarCuentaUsuario(id_usuario);
            return outTxt;
        }

    }
}