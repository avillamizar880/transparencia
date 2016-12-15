using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;

namespace AuditoriasCiudadanas.Controllers
{
    public class CorreoController
    {
        public static string salidaXML(DataTable dt)
        {
            StringBuilder strxml = new StringBuilder();
            string nomb_colum = "";
            strxml.Append("<ROOT>");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    strxml.Append("<ROW>");
                    foreach (DataColumn dc in dt.Columns)
                    {
                        nomb_colum = dc.ColumnName;
                        strxml.Append("<" + nomb_colum + ">" + (dr[nomb_colum] == null ? "" : dr[nomb_colum]) + "</" + nomb_colum + ">");
                    }
                    strxml.Append("</ROW>");
                }
            }
            strxml.Append("</ROOT>");
            return strxml.ToString();
        }
   
    public static string envCorreoNet(string cuerpo, string corrEnv, string adj1, string adj2, string asunto, bool ConfirmDelete = true)
    {
        string functionReturnValue = null;
        string msgerrr = "";
        string[] vecCorreos = null;
        MailMessage mMailMessage = new MailMessage();
        try
        {
            mMailMessage.From = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["usercorreo"], "Correo Masivo NO RESPONDER");
            vecCorreos = corrEnv.Split(';');
            for (int i = 0; i <= vecCorreos.Length - 1; i++)
            {
                if ((!string.IsNullOrEmpty(vecCorreos[i].ToString().Trim())))
                {
                    if ((valMail(vecCorreos[i].ToString().Trim())))
                    {
                        mMailMessage.To.Add(new MailAddress(vecCorreos[i].ToString().Trim()));
                    }
                }
            }

            mMailMessage.Subject = asunto;
            mMailMessage.Body = cuerpo;
            mMailMessage.IsBodyHtml = true;
            mMailMessage.Priority = MailPriority.Normal;

            if ((!string.IsNullOrEmpty(adj1)))
            {
                Attachment oAttch = new Attachment(adj1, "application/pdf");
                mMailMessage.Attachments.Add(oAttch);
            }
            if ((!string.IsNullOrEmpty(adj2)))
            {
                Attachment oAttch2 = new Attachment(adj2, "application/pdf");
                mMailMessage.Attachments.Add(oAttch2);
            }

            Configuration configurationFile = WebConfigurationManager.OpenWebConfiguration("~/");
            MailSettingsSectionGroup mailSettings = (MailSettingsSectionGroup)configurationFile.GetSectionGroup("system.net/mailSettings");
            int port = 0;
            string host = "";
            string password = "";
            string username = "";

            if (mailSettings != null)
            {
                port = mailSettings.Smtp.Network.Port;
                host = mailSettings.Smtp.Network.Host;
                password = mailSettings.Smtp.Network.Password;
                username = mailSettings.Smtp.Network.UserName;

            }            SmtpClient mSmtpClient = new SmtpClient(host,port);


                mSmtpClient.UseDefaultCredentials = false;
           
            //mSmtpClient.Host = host;
            //mSmtpClient.Port = port;
            mSmtpClient.EnableSsl = true;
                mSmtpClient.Credentials = new System.Net.NetworkCredential(username, password);
                mSmtpClient.Send(mMailMessage);

            msgerrr = "Envío realizado con éxito a los correos " + corrEnv;
        }
        catch (Exception ex)
        {
            msgerrr = "No se envío los adjuntos a los correos " + corrEnv + " <br/>" + ex.Message;
            //insertar log de errores
        }
        finally
        {
            mMailMessage.Dispose();
        }

        try
        {
            if ((!string.IsNullOrEmpty(adj1) & ConfirmDelete))
            {
                FileInfo fileA = new FileInfo(adj1);
                fileA.Delete();
            }
            if ((!string.IsNullOrEmpty(adj2) & ConfirmDelete))
            {
                FileInfo fileB = new FileInfo(adj2);
                fileB.Delete();
            }

        }
        catch (Exception ex)
        {
            //Log de errores
        }
        finally
        {
            functionReturnValue = msgerrr;
        }
        return functionReturnValue;


    }
    public static  bool valMail(string sMail)
    {
        // retorna true o false   
        return Regex.IsMatch(sMail, "^([\\w-]+\\.)*?[\\w-]+@[\\w-]+\\.([\\w-]+\\.)*?[\\w]+$");
        //"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$")
    }

    public static string envCorreoNetMS(string cuerpo, string corrEnv, MemoryStream adj1, string nadj1, MemoryStream adj2, string nadj2, string asunto)
    {
        string functionReturnValue = null;
        string msgerrr = "";
        string[] vecCorreos = null;
        MailMessage mMailMessage = new MailMessage();
        try
        {
            mMailMessage.From = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["usercorreo"], "Correo Masivo NO RESPONDER");
            vecCorreos = corrEnv.Split(';');
            for (int i = 0; i <= vecCorreos.Length - 1; i++)
            {
                if ((!string.IsNullOrEmpty(vecCorreos[i].ToString().Trim())))
                {
                    if ((valMail(vecCorreos[i].ToString().Trim())))
                    {
                        mMailMessage.To.Add(new MailAddress(vecCorreos[i].ToString().Trim()));
                    }
                }
            }

            mMailMessage.Subject = asunto;
            mMailMessage.Body = cuerpo;
            mMailMessage.IsBodyHtml = true;
            mMailMessage.Priority = MailPriority.Normal;
            if ((adj1 != null))
            {
                adj1 = new MemoryStream(adj1.ToArray());
                Attachment oAttch = new Attachment(adj1, nadj1);
                mMailMessage.Attachments.Add(oAttch);
            }
            if ((adj2 != null && !string.IsNullOrEmpty(nadj2)))
            {
                adj2 = new MemoryStream(adj1.ToArray());
                Attachment oAttch = new Attachment(adj2, nadj2);
                mMailMessage.Attachments.Add(oAttch);
            }

            Configuration configurationFile = WebConfigurationManager.OpenWebConfiguration("~/");
            MailSettingsSectionGroup mailSettings = (MailSettingsSectionGroup)configurationFile.GetSectionGroup("system.net/mailSettings");
            int port = 0;
            string host = "";
            string password = "";
            string username = "";

            if (mailSettings != null)
            {
                port = mailSettings.Smtp.Network.Port;
                host = mailSettings.Smtp.Network.Host;
                password = mailSettings.Smtp.Network.Password;
                username = mailSettings.Smtp.Network.UserName;

            }

            SmtpClient mSmtpClient = new SmtpClient();
            mSmtpClient.Credentials = new System.Net.NetworkCredential(username, password, "positivainfo.com");
            mSmtpClient.Host = host;
            mSmtpClient.Port = port;
            mSmtpClient.EnableSsl = true;
            mSmtpClient.Send(mMailMessage);

            msgerrr = "Envío realizado con éxito a los correos " + corrEnv;
        }
        catch (Exception ex)
        {
            msgerrr = "No se envío los adjuntos a los correos " + corrEnv + " <br/>" + ex.Message.ToString();
        }
        finally
        {
            mMailMessage.Dispose();
        }


        return functionReturnValue;
    }


    static int calcedad(string fechnac, int diaval, int mesval, int anoval)
    {
        int dianac = 0;
        int mesnac = 0;
        int anonac = 0;
        int calc_edad;

        string[] vecfechnac = Regex.Split(fechnac, "/");
        if ((vecfechnac.GetUpperBound(0) > 0))
        {
            dianac = int.Parse(vecfechnac[0]);
            mesnac = int.Parse(vecfechnac[1]);
            anonac = int.Parse(vecfechnac[2]);
        }

        calc_edad = 0;
        if ((mesnac > mesval))
        {
            calc_edad = (anoval - (anonac - 1));
        }
        else if (((mesval == mesnac) && (dianac > diaval)))
        {
            calc_edad = (anoval - (anonac - 1));
        }
        else
        {
            calc_edad = (anoval - anonac);
        }

        return calc_edad;


    }

    static string ultimoDiaCal(int mesVa, int anoVa)
    {
        string diaVa = "30";

        if (((mesVa == 1)
                    || ((mesVa == 3)
                    || ((mesVa == 5)
                    || ((mesVa == 7)
                    || ((mesVa == 8)
                    || ((mesVa == 10)
                    || (mesVa == 12))))))))
        {
            diaVa = "31";
        }
        else if (((mesVa == 2)
                    && ((anoVa % 4)
                    == 0)))
        {
            diaVa = "29";
        }
        else if (((mesVa == 4)
                    || ((mesVa == 6)
                    || ((mesVa == 9)
                    || (mesVa == 11)))))
        {
            diaVa = "30";
        }
        else
        {
            diaVa = "28";
        }


        return diaVa;

    }


    }
}