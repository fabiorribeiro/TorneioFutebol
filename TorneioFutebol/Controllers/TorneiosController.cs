using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TorneioFutebol.Apoio;
using TorneioFutebol.Data;
using TorneioFutebol.Models;

namespace TorneioFutebol.Controllers
{
    public class TorneiosController : Controller
    {
        private TorneioContext db = new TorneioContext();

        // GET: Torneios
        public ActionResult Index()
        {
            return View(db.Torneios.ToList());
        }

        // GET: Torneios/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,TotalTimes")] Torneio torneio)
        {
            if (ModelState.IsValid)
            {
                db.Torneios.Add(torneio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(torneio);
        }

        // GET: Torneios/Gerenciar/5
        public ActionResult Gerenciar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Torneio torneio = db.Torneios.Find(id);
            if (torneio == null)
            {
                return HttpNotFound();
            }
            return View(torneio);
        }

        // GET: Torneios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Torneio torneio = db.Torneios.Find(id);
            if (torneio == null)
            {
                return HttpNotFound();
            }
            return View(torneio);
        }

        // POST: Torneios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,TotalTimes")] Torneio torneio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(torneio).State = EntityState.Modified;
                db.SaveChanges();

                db.Torneios.Include(T => T.Times).Include(T => T.Jogos).Load();
                torneio.CriarJogos(db);

                var parametro = new RouteValueDictionary();
                parametro.Add("id", torneio.Id);
                return RedirectToAction("Gerenciar", parametro);
            }
            return View();
        }

        // GET: Torneios/Definir
        public ActionResult Definir(int idTorneio)
        {
            Torneio torneio = db.Torneios.Find(idTorneio);
            if (torneio == null)
            {
                return HttpNotFound();
            }

            torneio.DefinirJogos(db);
            var parametro = new RouteValueDictionary();
            parametro.Add("idTorneio", idTorneio);
            return RedirectToAction("Gerenciar", "Jogos", parametro);
        }


        // GET: Torneios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Torneio torneio = db.Torneios.Find(id);
            if (torneio == null)
            {
                return HttpNotFound();
            }
            return View(torneio);
        }

        // POST: Torneios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Torneio torneio = db.Torneios.Find(id);
            db.Torneios.Remove(torneio);
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
