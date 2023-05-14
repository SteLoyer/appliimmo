using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GestionImmobiliere.DataContext;
using GestionImmobiliere.Models;

namespace GestionImmobiliere.Controllers
{
    public class Rental_PaymentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Rental_File2/Create
        public ActionResult Create_Pay_List(int? id, [Bind(Include = "Town_property,Email_tenant,Phone_tenant,Id_rental_payment,Id_rental_file,Name_tenant,First_name_tenant,Adress_property,Rental_property,Charge_property,Payment_date,Amount_paid,Payment_method,Postal_code_property,Payment_ok")] Rental_Payment rental_payment)
        {

            if (ModelState.IsValid)
            {
                // Récupérer les enregistrements des deux tables
                var record1 = db.Rental_File.Find(id);

                // Si les enregistrements sont valides, les enregistrer dans la table 2
                if (record1 != null && rental_payment != null)
                {
                    // assigner les valeurs de table 1 aux colonnes de table 2
                    rental_payment.Name_tenant = record1.Name_tenant;
                    rental_payment.First_name_tenant = record1.First_name_tenant;
                    rental_payment.Id_rental_file = record1.Id_rental_file;
                    rental_payment.Phone_tenant = record1.Phone_tenant;
                    rental_payment.Email_tenant = record1.Email_tenant;
                    rental_payment.Adress_property = record1.Adress_property;
                    rental_payment.Postal_code_property = record1.Postal_code_property;
                    rental_payment.Town_property = record1.Town_property;
                    rental_payment.Rental_property = record1.Rental_property;
                    rental_payment.Charge_property = record1.Charge_property;
                    rental_payment.Phone_tenant = record1.Phone_tenant;


                    // Enregistrer les modifications
                    // db.Entry(data2).State = EntityState.Modified;
                    //db.SaveChanges();

                    db.Rental_Payment.Add(rental_payment);
                    db.SaveChanges();
                }
                return RedirectToAction("Edit_pay_file/" + rental_payment.Id_rental_payment);
            }

            return View(rental_payment);
        }





        // GET: Rental_File2/Edit_pay_file
        public ActionResult Edit_pay_file(int? id)
        {
            var record = db.Parameters.Find(1);




            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental_Payment rental_payment = db.Rental_Payment.Find(id);

            rental_payment.Payment_date = DateTime.Today; // définit la date actuelle pour Payment_date
            rental_payment.Agency_taxe = record.Agency_taxe;
            if (rental_payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = rental_payment.Id_rental_file;
            return View(rental_payment);
        }

        // POST: RentalFile/Edit_pay_file
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_pay_file([Bind(Include = "Town_property,Email_tenant,Phone_tenant,Id_rental_payment,Id_rental_file,Name_tenant,First_name_tenant,Adress_property,Rental_property,Charge_property,Payment_date,Amount_paid,Payment_method,Postal_code_property,Payment_ok,Agency_taxe")] Rental_Payment rental_payment)
        {
            if (ModelState.IsValid)
            {

                db.Entry(rental_payment).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.Id = rental_payment.Id_rental_file;
                return View(rental_payment);
                //return RedirectToAction("Index");
            }
            
            return View(rental_payment);
        }





        public ActionResult List_Payment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var rentalPayments = db.Rental_Payment.Where(rp => rp.Id_rental_file == id).ToList();

            if (rentalPayments == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = id;
            return View(rentalPayments.ToList());
        }


  

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendEmail(Rental_Payment model)
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
                message.To.Add(new MailAddress(model.Email_tenant)); //replace with valid value
                //message.To.Add(new MailAddress("loyer.ste@free.fr")); //Permet d'envoyer à plusieurs destinataires 
                //message.To.Add(new MailAddress("loyer.ste@free.fr")); //
                //message.Bcc.Add( new MailAddress ( " one@gmail.com " )); Permet d'envoyer à plusieurs destinataires, sans que les adresse apparaissent

                message.Subject = "Quitance de loyer";
                message.Body = string.Format(body, model.Name_tenant , model.Email_tenant,model.First_name_tenant);
                message.IsBodyHtml = true;
                //message.Attachments.Add(new Attachment(HttpContext.Server.MapPath("/content/documents/quittance-de-loyer.pdf")));
                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);

                    return View("SentEmail");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendQuittance(Rental_Payment model)
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

                //var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress(model.Email_tenant)); //replace with valid value
                //message.To.Add(new MailAddress("loyer.ste@free.fr")); //Permet d'envoyer à plusieurs destinataires 
                //message.To.Add(new MailAddress("loyer.ste@free.fr")); //
                //message.Bcc.Add( new MailAddress ( " one@gmail.com " )); Permet d'envoyer à plusieurs destinataires, sans que les adresse apparaissent

                message.Subject = "Quitance de loyer";
               // message.Body = string.Format(body, model.Name_tenant, model.Email_tenant, model.First_name_tenant);
                message.IsBodyHtml = true;
                message.Attachments.Add(new Attachment(HttpContext.Server.MapPath("/content/documents/quittance-de-loyer.pdf")));
                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);

                    return View("SentQuittance");
                }
            }
            return View(model);
        }

        public ActionResult Save_RentalFile(int? id)
        {
            // Récupérer les enregistrements des deux tables
            var record1 = db.Tenants.Find(id);

            // Utilisez l'ID pour récupérer les détails de l'objet souhaité
            int rentalFileId = (int)Session["RentalFileId"];
            var data2 = db.Rental_File.Find(rentalFileId);

            // Si les enregistrements sont valides, les enregistrer dans la table 2
            if (record1 != null && data2 != null)
            {
                // assigner les valeurs de table 1 aux colonnes de table 2
                data2.Name_tenant = record1.Name_tenant;
                data2.First_name_tenant = record1.First_name_tenant;
                data2.Email_tenant = record1.Email_tenant;
                data2.Phone_tenant = record1.Phone_tenant;


                // Enregistrer les modifications
                db.Entry(data2).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Save_RentalFile/" + rentalFileId);
        }

        // GET: Rental_File2/Edit/5
        public ActionResult Edit2(int? id)
        {
            var record = db.Parameters.Find(1);




            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental_Payment rental_payment = db.Rental_Payment.Find(id);

            rental_payment.Payment_date = DateTime.Today; // définit la date actuelle pour Payment_date
            rental_payment.Agency_taxe = record.Agency_taxe;
            if (rental_payment == null)
            {
                return HttpNotFound();
            }
            return View(rental_payment);
        }

        // POST: RentalFile/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit2([Bind(Include = "Town_property,Email_tenant,Phone_tenant,Id_rental_payment,Id_rental_file,Name_tenant,First_name_tenant,Adress_property,Rental_property,Charge_property,Payment_date,Amount_paid,Payment_method,Postal_code_property,Payment_ok,Agency_taxe")] Rental_Payment rental_payment)
        {
            if (ModelState.IsValid)
            {

                db.Entry(rental_payment).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.Id = rental_payment.Id_rental_file;
                return View(rental_payment);
               //return RedirectToAction("Index");
            }
            return View(rental_payment);
        }

        

        // GET: Rental_File2/Create
        public ActionResult Create1(int? id,[Bind(Include = "Town_property,Email_tenant,Phone_tenant,Id_rental_payment,Id_rental_file,Name_tenant,First_name_tenant,Adress_property,Rental_property,Charge_property,Payment_date,Amount_paid,Payment_method,Postal_code_property,Payment_ok")] Rental_Payment rental_payment)
        { 
           
            if (ModelState.IsValid)
            {
                // Récupérer les enregistrements des deux tables
                var record1 = db.Rental_File.Find(id);

                // Si les enregistrements sont valides, les enregistrer dans la table 2
                if (record1 != null && rental_payment != null)
                {
                    // assigner les valeurs de table 1 aux colonnes de table 2
                    rental_payment.Name_tenant = record1.Name_tenant;
                    rental_payment.First_name_tenant = record1.First_name_tenant;
                    rental_payment.Id_rental_file = record1.Id_rental_file;
                    rental_payment.Phone_tenant = record1.Phone_tenant;
                    rental_payment.Email_tenant = record1.Email_tenant;
                    rental_payment.Adress_property = record1.Adress_property;
                    rental_payment.Postal_code_property = record1.Postal_code_property;
                    rental_payment.Town_property = record1.Town_property;
                    rental_payment.Rental_property = record1.Rental_property;
                    rental_payment.Charge_property = record1.Charge_property;
                    rental_payment.Phone_tenant = record1.Phone_tenant;
                   

                    // Enregistrer les modifications
                    // db.Entry(data2).State = EntityState.Modified;
                    //db.SaveChanges();

                    db.Rental_Payment.Add(rental_payment);
                    db.SaveChanges();
                }
                return RedirectToAction("Edit2/" + rental_payment.Id_rental_payment);
            }

                return View(rental_payment);
        }
      
        // GET: Rental_File2
        public ActionResult ChooseRentalFile()
        {
           return View(db.Rental_File.ToList());
        }

       
       


       
        public ActionResult ChooseRentalFile1()
        {  // Récupérer la liste des Id_rental_file et Name à partir de la table Rental_File
            var rentalFiles = db.Rental_File.Select(r => new { r.Id_rental_file, r.Name_tenant,r.First_name_tenant }).ToList();

            // Envoyer la liste à la vue Create de Rental_Payment
            ViewBag.RentalFiles = new SelectList(rentalFiles, "Id_rental_file", "Id_rental_file", "First_name_tenant");
                      
            // Retourner la vue Create de Rental_Payment
            return View();

        }
      
        public ActionResult Index()
        {
            var rentalFileIds = db.Rental_File.Select(rf => rf.Id_rental_file).Distinct().ToList();
            var rentalFileNames = db.Rental_File.Select(rf => rf.Name_tenant).Distinct().ToList();

            ViewBag.RentalFiles = rentalFileIds;
            // ViewBag.RentalFileIds = rentalFileIds;
            ViewBag.rentalFileNames = rentalFileNames;

            return View(db.Rental_Payment.ToList());
        }












        // GET: Rental_Payment
        public ActionResult Index_save()
        {
            return View(db.Rental_Payment.ToList());
        }

        // GET: Rental_Payment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental_Payment rental_Payment = db.Rental_Payment.Find(id);
            if (rental_Payment == null)
            {
                return HttpNotFound();
            }
            return View(rental_Payment);
        }
        // GET: Rental_Payment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental_Payment rental_Payment = db.Rental_Payment.Find(id);
            if (rental_Payment == null)
            {
                return HttpNotFound();
            }
            return View(rental_Payment);
        }

        // POST: Rental_Payment/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_rental_payment,Id_rental_file,Name_tenant,First_name_tenant,Adress_property,Rental_property,Charge_property,Payment_date,Amount_paid,Payment_method")] Rental_Payment rental_Payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rental_Payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rental_Payment);
        }
        // GET: Rental_Payment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental_Payment rental_Payment = db.Rental_Payment.Find(id);
            if (rental_Payment == null)
            {
                return HttpNotFound();
            }
            return View(rental_Payment);
        }

        // POST: Rental_Payment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rental_Payment rental_Payment = db.Rental_Payment.Find(id);
            db.Rental_Payment.Remove(rental_Payment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Rental_Payment/Del_Pay_File
        public ActionResult Del_Pay_File(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental_Payment rental_Payment = db.Rental_Payment.Find(id);
            if (rental_Payment == null)
            {
                return HttpNotFound();
            }
            return View(rental_Payment);
        }

        // POST: Rental_Payment/Del_Pay_File
        [HttpPost, ActionName("Del_Pay_File")]
        [ValidateAntiForgeryToken]
        public ActionResult Del_Pay_FileConfirmed(int id)
        {
            Rental_Payment rental_Payment = db.Rental_Payment.Find(id);
            db.Rental_Payment.Remove(rental_Payment);
            db.SaveChanges();
            return RedirectToAction("List_Payment/" + rental_Payment.Id_rental_file);
        }
      

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
