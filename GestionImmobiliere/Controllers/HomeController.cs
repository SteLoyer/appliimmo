
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionImmobiliere.Models;
using System.Net;
using System.Net.Mail;

using System.Threading.Tasks;



namespace SendEmail.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendEmail()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult SendEmailQuittance()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendEmailQuittance(Email model)
        {
            if (ModelState.IsValid)
            {
                // Code sans utiliser Web.config
                /* 
                    var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress(""));  // replace with valid value 
                message.From = new MailAddress("");  // replace with valid value
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "",  // replace with valid value
                        Password = ""  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.free.fr";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
                 */
                // Code en utilisant Web config

                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("")); //replace with valid value
                //message.To.Add(new MailAddress("loyer.ste@free.fr")); //Permet d'envoyer à plusieurs destinataires 
                //message.To.Add(new MailAddress("loyer.ste@free.fr")); //
                //message.Bcc.Add( new MailAddress ( " one@gmail.com " )); Permet d'envoyer à plusieurs destinataires, sans que les adresse apparaissent

                message.Subject = "Quitance de loyer";
                message.Body = string.Format(body, model.Name_Tenant, model.Email_tenant, model.Message);
                message.IsBodyHtml = true;
                message.Attachments.Add(new Attachment(HttpContext.Server.MapPath("/content/documents/quittance-de-loyer.pdf")));
                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendEmail(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                // Code sans utiliser Web.config
                /* 
                    var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress(""));  // replace with valid value 
                message.From = new MailAddress("");  // replace with valid value
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "",  // replace with valid value
                        Password = ""  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.free.fr";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
                 */
                // Code en utilisant Web config

                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("loyer.ste@free.fr")); //replace with valid value
                //message.To.Add(new MailAddress("loyer.ste@free.fr")); //Permet d'envoyer à plusieurs destinataires 
                //message.To.Add(new MailAddress("loyer.ste@free.fr")); //
                //message.Bcc.Add( new MailAddress ( " one@gmail.com " )); Permet d'envoyer à plusieurs destinataires, sans que les adresse apparaissent

                message.Subject = "Quitance de loyer";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;
                message.Attachments.Add(new Attachment(HttpContext.Server.MapPath("/content/documents/quittance-de-loyer.pdf")));
                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }

        public ActionResult Sent()
        {
            return View();
        }
    }
}