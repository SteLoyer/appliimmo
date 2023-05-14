using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionImmobiliere.DataContext;
using GestionImmobiliere.Models;

namespace GestionImmobiliere.Controllers
{
    public class LogementsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Logements
        public ActionResult Index()
        {
            return View(db.Logements.ToList());
        }

        // GET: Logements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logement logement = db.Logements.Find(id);
            if (logement == null)
            {
                return HttpNotFound();
            }
            return View(logement);
        }

        // GET: Logements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Logements/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_property,Adress_property,Complement_adress_property,Postal_code_property,Town_property,Type_property,Rental_property,Charge_property,Deposit_property,State_property,Id_owner")] Logement logement)
        {
            if (ModelState.IsValid)
            {
                logement.State_property = true;
                db.Logements.Add(logement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(logement);
        }

        // GET: Logements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logement logement = db.Logements.Find(id);
            if (logement == null)
            {
                return HttpNotFound();
            }
            return View(logement);
        }

        // POST: Logements/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_property,Adress_property,Complement_adress_property,Postal_code_property,Town_property,Type_property,Rental_property,Charge_property,Deposit_property,State_property,Id_owner")] Logement logement)
        {
            if (ModelState.IsValid)
            {
                
                db.Entry(logement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(logement);
        }

        // GET: Logements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logement logement = db.Logements.Find(id);
            if (logement == null)
            {
                return HttpNotFound();
            }
            return View(logement);
        }

        // POST: Logements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Logement logement = db.Logements.Find(id);
            db.Logements.Remove(logement);
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
