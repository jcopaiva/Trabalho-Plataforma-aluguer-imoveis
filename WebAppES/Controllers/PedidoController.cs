using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IpcaHomeModel;
using EntityState = System.Data.EntityState;

namespace WebAppES.Controllers
{
    public class PedidoController : Controller
    {
        private IpcaHomeEntities db = new IpcaHomeEntities();

        // GET: Pedido
        public ActionResult Index()
        {
            var pedido = db.Pedido.Include(p => p.AgenteImobiliaria).Include(p => p.Alojamento).Include(p => p.Estudante);
            return View(pedido.ToList());
        }

        // GET: Pedido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        [Authorize(Roles = "Admin, Estudante")]
        // GET: Pedido/Create
        public ActionResult Create()
        {
            ViewBag.AgenteImobiliariaID = new SelectList(db.AgenteImobiliaria, "ID", "ID");
            ViewBag.AlojamentoID = new SelectList(db.Alojamento, "ID", "disponibilidade");
            ViewBag.EstudanteID = new SelectList(db.Estudante, "ID", "universidade");
            return View();
        }

        // POST: Pedido/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Estudante")]
        public ActionResult Create([Bind(Include = "ID,AlojamentoID,EstudanteID,AgenteImobiliariaID")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Pedido.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AgenteImobiliariaID = new SelectList(db.AgenteImobiliaria, "ID", "ID", pedido.AgenteImobiliariaID);
            ViewBag.AlojamentoID = new SelectList(db.Alojamento, "ID", "disponibilidade", pedido.AlojamentoID);
            ViewBag.EstudanteID = new SelectList(db.Estudante, "ID", "universidade", pedido.EstudanteID);
            return View(pedido);
        }

        // GET: Pedido/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.AgenteImobiliariaID = new SelectList(db.AgenteImobiliaria, "ID", "ID", pedido.AgenteImobiliariaID);
            ViewBag.AlojamentoID = new SelectList(db.Alojamento, "ID", "disponibilidade", pedido.AlojamentoID);
            ViewBag.EstudanteID = new SelectList(db.Estudante, "ID", "universidade", pedido.EstudanteID);
            return View(pedido);
        }[Authorize(Roles = "Admin, Proprietario")]

        // POST: Pedido/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "ID,AlojamentoID,EstudanteID,AgenteImobiliariaID")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AgenteImobiliariaID = new SelectList(db.AgenteImobiliaria, "ID", "ID", pedido.AgenteImobiliariaID);
            ViewBag.AlojamentoID = new SelectList(db.Alojamento, "ID", "disponibilidade", pedido.AlojamentoID);
            ViewBag.EstudanteID = new SelectList(db.Estudante, "ID", "universidade", pedido.EstudanteID);
            return View(pedido);
        }

        // GET: Pedido/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedido.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedido/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = db.Pedido.Find(id);
            db.Pedido.Remove(pedido);
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
