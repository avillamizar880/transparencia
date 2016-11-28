using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;

namespace AuditoriasCiudadanas.App_Code
{
    public class clsEmail
    {
        public string EnviarEmail(string cuenta_origen, string cuenta_destino,string asunto,string cuerpo) {
            string outEstado = "";
            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress(cuenta_destino));
            email.From = new MailAddress(cuenta_origen);
            email.Subject = asunto + "( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
            email.Body = cuerpo;
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "example.com";
            smtp.Port = 2525;
            smtp.EnableSsl = false;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("email_from@example.com", "contraseña");
            outEstado = "1";

            return outEstado;
        }
    }
}