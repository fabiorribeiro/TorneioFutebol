using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TorneioFutebol.Data;
using TorneioFutebol.Models;
using EntityState = System.Data.Entity.EntityState;

namespace TorneioFutebol.Controllers
{
    public class JogosController : Controller
    {
        private TorneioContext db = new TorneioContext();

        // GET: Jogos
        public ActionResult Index()
        {
            return View(db.Jogos.ToList());
        }

        // GET: Jogos/Definidos/5
        public ActionResult Definidos(int idTorneio)
        {
            Torneio torneio = db.Torneios.Find(idTorneio);

            return View(torneio);
        }


        // GET: Jogos/Definir/5
        public ActionResult Definir(int idTorneio)
        {
            Torneio torneio = db.Torneios.Find(idTorneio);
            return View(torneio.ProximoJogoADefinir());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Definir([Bind(Include = "idJogo,idTime1, idTime2")] Jogo jogo, int idTorneio)
        {
            if (ModelState.IsValid)
            {
                Torneio torneio = db.Torneios.Find(jogo.Torneio.Id);
                db.Entry(torneio).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(jogo);
        }



        // GET: Jogos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = db.Jogos.Find(id);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            return View(jogo);
        }

        // GET: Jogos/Create
        public ActionResult Create(int idTorneio)
        {
            Torneio torneio = db.Torneios.Find(idTorneio);
            return View(torneio);
        }

        // POST: Jogos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,idTimeVencedor")] Jogo jogo)
        {
            if (ModelState.IsValid)
            {
                db.Jogos.Add(jogo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jogo);
        }

        // GET: Jogos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = db.Jogos.Find(id);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            return View(jogo);
        }

        // POST: Jogos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,idTimeVencedor")] Jogo jogo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jogo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jogo);
        }

        // GET: Jogos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = db.Jogos.Find(id);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            return View(jogo);
        }

        // POST: Jogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jogo jogo = db.Jogos.Find(id);
            db.Jogos.Remove(jogo);
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
