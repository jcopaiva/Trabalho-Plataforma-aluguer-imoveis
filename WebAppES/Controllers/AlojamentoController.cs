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
    public class AlojamentoController : Controller
    {
        private IpcaHomeEntities db = new IpcaHomeEntities();

        // GET: Alojamento
        [Authorize]
        public ActionResult Index()
        {
            var alojamento = db.Alojamento.Include(a => a.AgenteImobiliaria).Include(a => a.Estudante).Include(a => a.Proprietario).Include(a => a.Localização);
            return View(alojamento.ToList());
        }

        // GET: Alojamento/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alojamento alojamento = db.Alojamento.Find(id);
            if (alojamento == null)
            {
                return HttpNotFound();
            }
            return View(alojamento);
        }

        // GET: Alojamento/Create
        [Authorize(Roles = "Admin, Proprietario")]
        public ActionResult Create()
        {
            ViewBag.AgenteImobiliariaID = new SelectList(db.AgenteImobiliaria, "ID", "ID");
            ViewBag.EstudanteID = new SelectList(db.Estudante, "ID", "universidade");
            ViewBag.ProprietárioID = new SelectList(db.Proprietario, "ID", "ID");
            ViewBag.LocalizaçãoID = new SelectList(db.Localização, "ID", "rua");
            return View();
        }

        // POST: Alojamento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Proprietario")]
        public ActionResult Create([Bind(Include = "ID,ProprietárioID,EstudanteID,AgenteImobiliariaID,LocalizaçãoID,disponibilidade,informacoes,restricoes,avaliacao,historico")] Alojamento alojamento)
        {
            if (ModelState.IsValid)
            {
                db.Alojamento.Add(alojamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AgenteImobiliariaID = new SelectList(db.AgenteImobiliaria, "ID", "ID", alojamento.AgenteImobiliariaID);
            ViewBag.EstudanteID = new SelectList(db.Estudante, "ID", "universidade", alojamento.EstudanteID);
            ViewBag.ProprietárioID = new SelectList(db.Proprietario, "ID", "ID", alojamento.ProprietárioID);
            ViewBag.LocalizaçãoID = new SelectList(db.Localização, "ID", "rua", alojamento.LocalizaçãoID);
            return View(alojamento);
        }

        // GET: Alojamento/Edit/5
        [Authorize(Roles = "Admin, Proprietario")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alojamento alojamento = db.Alojamento.Find(id);
            if (alojamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.AgenteImobiliariaID = new SelectList(db.AgenteImobiliaria, "ID", "ID", alojamento.AgenteImobiliariaID);
            ViewBag.EstudanteID = new SelectList(db.Estudante, "ID", "universidade", alojamento.EstudanteID);
            ViewBag.ProprietárioID = new SelectList(db.Proprietario, "ID", "ID", alojamento.ProprietárioID);
            ViewBag.LocalizaçãoID = new SelectList(db.Localização, "ID", "rua", alojamento.LocalizaçãoID);
            return View(alojamento);
        }

        // POST: Alojamento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Proprietario")]
        public ActionResult Edit([Bind(Include = "ID,ProprietárioID,EstudanteID,AgenteImobiliariaID,LocalizaçãoID,disponibilidade,informacoes,restricoes,avaliacao,historico")] Alojamento alojamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alojamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AgenteImobiliariaID = new SelectList(db.AgenteImobiliaria, "ID", "ID", alojamento.AgenteImobiliariaID);
            ViewBag.EstudanteID = new SelectList(db.Estudante, "ID", "universidade", alojamento.EstudanteID);
            ViewBag.ProprietárioID = new SelectList(db.Proprietario, "ID", "ID", alojamento.ProprietárioID);
            ViewBag.LocalizaçãoID = new SelectList(db.Localização, "ID", "rua", alojamento.LocalizaçãoID);
            return View(alojamento);
        }

        // GET: Alojamento/Delete/5
        [Authorize(Roles = "Admin, Proprietario")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alojamento alojamento = db.Alojamento.Find(id);
            if (alojamento == null)
            {
                return HttpNotFound();
            }
            return View(alojamento);
        }

        // POST: Alojamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Proprietario")]
        public ActionResult DeleteConfirmed(int id)
        {
            Alojamento alojamento = db.Alojamento.Find(id);
            db.Alojamento.Remove(alojamento);
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
