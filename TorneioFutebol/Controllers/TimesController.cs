using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TorneioFutebol.Data;
using TorneioFutebol.Models;
using EntityState = System.Data.Entity.EntityState;

namespace TorneioFutebol.Controllers
{
    public class TimesController : Controller
    {
        private TorneioContext db = new TorneioContext();

        // GET: Times/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Time time = db.Times.Find(id);
            if (time == null)
            {
                return HttpNotFound();
            }
            return View(time);
        }

        // GET: Times/Create
        public ActionResult Create(int idTorneio)
        {
            ViewBag.torneio = db.Torneios.Find(idTorneio);
            return View() ;
        }

        // POST: Times/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Torneio_id")] Time time, int idTorneio)
        {
            if (ModelState.IsValid)
            {
                var timesTorneio = db.Torneios.Find(idTorneio).Times;
                if (timesTorneio.Count < 16)
                {
                    timesTorneio.Add(time);
                    db.SaveChanges();
                    var parametro = new RouteValueDictionary();
                    parametro.Add("id", idTorneio);
                    return RedirectToAction("Gerenciar", "Torneios", parametro);
                }
                else
                {
                    return View("Máximo de times cadastrados");
                }
            }

            return View();
        }

        // GET: Times/Edit/5
        public ActionResult Edit(int? id, int? idTorneio)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Time time = db.Times.Find(id);
            if (time == null)
            {
                return HttpNotFound();
            }
            return View(time);
        }

        // POST: Times/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome")] Time time, int idTorneio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(time).State = EntityState.Modified;
                db.SaveChanges();
                var parametro = new RouteValueDictionary();
                parametro.Add("id", idTorneio);
                return RedirectToAction("Gerenciar", "Torneios", parametro);
            }
            return View();
        }

        // GET: Times/Delete/5
        public ActionResult Delete(int? id, int? idTorneio)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Time time = db.Times.Find(id);
            if (time == null)
            {
                return HttpNotFound();
            }
            return View(time);
        }

        // POST: Times/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int idTorneio)
        {
            Time time = db.Times.Find(id);
            int torneioId = time.Torneio.Id;
            db.Times.Remove(time);
            db.SaveChanges();
            var parametro = new RouteValueDictionary();
            parametro.Add("id", idTorneio);
            return RedirectToAction("Gerenciar", "Torneios", parametro);
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
