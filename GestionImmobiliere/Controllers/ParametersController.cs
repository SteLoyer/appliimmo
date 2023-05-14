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
    public class ParametersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Parameters
        public ActionResult Index()
        {
            return View(db.Parameters.ToList());
        }

        // GET: Parameters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parameters parameters = db.Parameters.Find(id);
            if (parameters == null)
            {
                return HttpNotFound();
            }
            return View(parameters);
        }

       
        // GET: Parameters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parameters parameters = db.Parameters.Find(id);
            if (parameters == null)
            {
                return HttpNotFound();
            }
            return View(parameters);
        }

        // POST: Parameters/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_parameters,Agency_taxe")] Parameters parameters)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parameters).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parameters);
        }

        // GET: Parameters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parameters parameters = db.Parameters.Find(id);
            if (parameters == null)
            {
                return HttpNotFound();
            }
            return View(parameters);
        }

        // POST: Parameters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parameters parameters = db.Parameters.Find(id);
            db.Parameters.Remove(parameters);
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
