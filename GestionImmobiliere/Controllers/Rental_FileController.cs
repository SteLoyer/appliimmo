using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using GestionImmobiliere.DataContext;
using GestionImmobiliere.Models;

namespace GestionImmobiliere.Controllers
{
    public class Rental_FileController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // POST: Rental_File2/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Bail([Bind(Include = "Id_rental_file,Id_tenant,Id_logement,Name_tenant,First_name_tenant,Email_tenant,Phone_tenant,Adress_property,Postal_code_property,Town_property,Rental_property,Date_of_rental,Charge_property,Deposit_property,Lease_report,Date_lease_report")] Rental_File rental_File)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rental_File).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rental_File);
        }

      



        // GET: Rental_File2/Edit/5
        public ActionResult Bail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental_File rental_File = db.Rental_File.Find(id);
            if (rental_File == null)
            {
                return HttpNotFound();
            }
            return View(rental_File);
        }
        public ActionResult Save_Logement_RentalFile(int? id)
        {
            // Récupérer les enregistrements des deux tables
            var record1 = db.Logements.Find(id);

            // Mettre à jour l'état du logement 
            // record1.State_property = false;
            //db.Logements.Add(record1);
            record1.State_property = false;
            db.Entry(record1).State = EntityState.Modified;
            db.SaveChanges();
            // Utilisez l'ID pour récupérer les détails de l'objet souhaité
            int rentalFileId = (int)Session["RentalFileId"];
            var data2 = db.Rental_File.Find(rentalFileId);

            // Si les enregistrements sont valides, les enregistrer dans la table 2
            if (record1 != null && data2 != null)
            {
                // assigner les valeurs de table 1 aux colonnes de table 2
                data2.Adress_property = record1.Adress_property;
                data2.Postal_code_property = record1.Postal_code_property;
                data2.Town_property = record1.Town_property;
                data2.Rental_property = record1.Rental_property;
                data2.Charge_property = record1.Charge_property;
                data2.Deposit_property = record1.Deposit_property;
               


                // Enregistrer les modifications
                db.Entry(data2).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Edit2/" + rentalFileId);
        }
        public ActionResult Save_Tenant_RentalFile(int? id)
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

            return RedirectToAction("Edit2/"+rentalFileId);
        }


        // POST: RentalFile/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit2([Bind(Include = "Id_rental_file,Id_tenant,Id_logement,Name_tenant,First_name_tenant,Email_tenant,Phone_tenant,Adress_property,Postal_code_property,Town_property,Rental_property,Date_of_rental,Charge_property,Deposit_property,Lease_report,Date_lease_report")] Rental_File rental_File)
        {
            if (ModelState.IsValid)
            {

                db.Entry(rental_File).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rental_File);
        }






        public ActionResult SaveData5(int? id)
        {
            // Récupérer les enregistrements des deux tables
            var record1 = db.Tenants.Find(id);

            // Utilisez l'ID pour récupérer les détails de l'objet souhaité
            int RentalFileId = (int)Session["RentalFileId"];
            var data2 = db.Rental_File.Find(RentalFileId);

            // Si les enregistrements sont valides, les enregistrer dans la table 2
            if (record1 != null && data2 != null)
            {
                var dataToSave = new Rental_File
                {// assigner les valeurs de table 1 aux colonnes de table 2
                    Name_tenant = record1.Name_tenant,
                    First_name_tenant = record1.First_name_tenant,
                };

                // Ajouter la nouvelle ligne à la table 2 et enregistrer les modifications
                db.Entry(dataToSave).State = EntityState.Added;
                db.SaveChanges();

                // Mettre à jour la valeur de la session avec la nouvelle valeur Id_rental_file
                Session["RentalFileId"] = dataToSave.Id_rental_file;

                // Mettre à jour la valeur de RentalFileId avec la nouvelle valeur Id_rental_file
                RentalFileId = dataToSave.Id_rental_file;

                // Mettre à jour la ligne existante dans la table 2 avec les nouvelles données
                data2.Name_tenant = record1.Name_tenant;
                data2.First_name_tenant = record1.First_name_tenant;
                db.Entry(data2).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


        // GET: Rental_File2/Create
        public ActionResult Create1([Bind(Include = "Id_rental_file")] Rental_File rental_File1)
        {
            if (ModelState.IsValid)
            {
                db.Rental_File.Add(rental_File1);
                db.SaveChanges();
                return RedirectToAction("Edit2/"+rental_File1.Id_rental_file);
            }

            return View(rental_File1);
        }

        // POST: Rental_File2/Create2
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create2([Bind(Include = "Id_rental_file,Id_tenant,Id_logement,Name_tenant,First_name_tenant,Email_tenant,Phone_tenant,Adress_property,Postal_code_property,Town_property,Rental_property,Date_of_rental,Charge_property,Deposit_property,Lease_report,Date_lease_report")] Rental_File rental_File)
        {
            if (ModelState.IsValid)
            {
                db.Rental_File.Add(rental_File);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rental_File);
        }

        // GET: Rental_File2
        public ActionResult Index_Tenant(int id)
        {
            // Stocker l'id dans une variable de session
            Session["RentalFileId"] = id;

            return View(db.Tenants.ToList());
        }

        // GET: Rental_File2
        public ActionResult Index_Logement(int id)
        {
            // Stocker l'id dans une variable de session
            Session["RentalFileId"] = id;

            return View(db.Logements.ToList());
        }

        // GET: Rental_File2/Edit/5
        public ActionResult SaveTenant(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental_File rental_File = db.Rental_File.Find(id);
            if (rental_File == null)
            {
                return HttpNotFound();
            }
            return View(rental_File);
        }




        // GET: Rental_File2
        public ActionResult Index()
        {
            return View(db.Rental_File.ToList());
        }

        // GET: Rental_File2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental_File rental_File = db.Rental_File.Find(id);
            if (rental_File == null)
            {
                return HttpNotFound();
            }
            return View(rental_File);
        }

        // GET: Rental_File2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rental_File2/Create
       [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_logement")] Rental_File rental_File)
        {
            if (ModelState.IsValid)
            {
                db.Rental_File.Add(rental_File);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rental_File);
        }

        // GET: Rental_File2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental_File rental_File = db.Rental_File.Find(id);
            if (rental_File == null)
            {
                return HttpNotFound();
            }
            return View(rental_File);
        }

        // GET: Rental_File2/Edit/5
        public ActionResult Edit2(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental_File rental_File = db.Rental_File.Find(id);
            if (rental_File == null)
            {
                return HttpNotFound();
            }
            return View(rental_File);
        }

        // POST: Rental_File2/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_rental_file,Id_tenant,Id_logement,Name_tenant,First_name_tenant,Email_tenant,Phone_tenant,Adress_property,Postal_code_property,Town_property,Rental_property,Date_of_rental")] Rental_File rental_File)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rental_File).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rental_File);
        }

        // GET: Rental_File2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental_File rental_File = db.Rental_File.Find(id);
            if (rental_File == null)
            {
                return HttpNotFound();
            }
            return View(rental_File);
        }

        // POST: Rental_File2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Rental_File rental_File = db.Rental_File.Find(id);
            db.Rental_File.Remove(rental_File);
            db.SaveChanges();
            return RedirectToAction("Index");
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
