using AuditoriasCiudadanas.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AuditoriasCiudadanas.Models
{
    public class clsNotificacionesProgramadas
    {
        /// <summary>
        /// notificacion mensual a auditores ciudadanos
        /// </summary>
        public static string RankingAuditores() {
            string email = "villamizardiana@gmail.com";
            int id_usuario = 145;
            //consulta ranking auditores
            List<DataTable> listaInfoRanking = new List<DataTable>();
            listaInfoRanking = Models.clsUsuarios.obtRankingD(id_usuario);
            DataTable dtRankingUsuarios = listaInfoRanking[1];
            //consulta auditores activos


            string outTxt = clsCorreosProgramados.RankingAuditores(email, id_usuario,dtRankingUsuarios);
            return outTxt;
        }

        public static string BuenasPracticas() {
            string email = "villamizardiana@gmail.com";
            //consultar email de técnicos auditores
            string outTxt = clsCorreosProgramados.BuenasPracticasPublicadas(email);
            return outTxt;
        }

        public static string experienciasGac()
        {
            string email = "villamizardiana@gmail.com";
            //consultar email de técnicos auditores
            string outTxt = clsCorreosProgramados.experienciasGacPublicadas(email);
            return outTxt;
        }
    }
}