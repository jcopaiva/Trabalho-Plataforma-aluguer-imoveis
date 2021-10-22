using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IpcaHomeModel;
using EntityState = System.Data.Entity.EntityState;

namespace WebAppES.Controllers
{
    public class AgenteImobiliariaController : Controller
    {
        private IpcaHomeEntities db = new IpcaHomeEntities();

        // GET: AgenteImobiliaria
        public ActionResult Index()
        {
            var agenteImobiliaria = db.AgenteImobiliaria.Include(a => a.Utilizador);
            return View(agenteImobiliaria.ToList());
        }

        // GET: AgenteImobiliaria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgenteImobiliaria agenteImobiliaria = db.AgenteImobiliaria.Find(id);
            if (agenteImobiliaria == null)
            {
                return HttpNotFound();
            }
            return View(agenteImobiliaria);
        }

        // GET: AgenteImobiliaria/Create
        public ActionResult Create()
        {
            ViewBag.UtilizadorID = new SelectList(db.Utilizador, "ID", "username");
            return View();
        }

        // POST: AgenteImobiliaria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UtilizadorID")] AgenteImobiliaria agenteImobiliaria)
        {
            if (ModelState.IsValid)
            {
                db.AgenteImobiliaria.Add(agenteImobiliaria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UtilizadorID = new SelectList(db.Utilizador, "ID", "username", agenteImobiliaria.UtilizadorID);
            return View(agenteImobiliaria);
        }

        // GET: AgenteImobiliaria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgenteImobiliaria agenteImobiliaria = db.AgenteImobiliaria.Find(id);
            if (agenteImobiliaria == null)
            {
                return HttpNotFound();
            }
            ViewBag.UtilizadorID = new SelectList(db.Utilizador, "ID", "username", agenteImobiliaria.UtilizadorID);
            return View(agenteImobiliaria);
        }

        // POST: AgenteImobiliaria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UtilizadorID")] AgenteImobiliaria agenteImobiliaria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agenteImobiliaria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UtilizadorID = new SelectList(db.Utilizador, "ID", "username", agenteImobiliaria.UtilizadorID);
            return View(agenteImobiliaria);
        }

        // GET: AgenteImobiliaria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgenteImobiliaria agenteImobiliaria = db.AgenteImobiliaria.Find(id);
            if (agenteImobiliaria == null)
            {
                return HttpNotFound();
            }
            return View(agenteImobiliaria);
        }

        // POST: AgenteImobiliaria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AgenteImobiliaria agenteImobiliaria = db.AgenteImobiliaria.Find(id);
            db.AgenteImobiliaria.Remove(agenteImobiliaria);
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
