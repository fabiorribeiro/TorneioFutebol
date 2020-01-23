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
    public class JogosController : Controller
    {
        private TorneioContext db = new TorneioContext();

        // GET: Jogos/Definidos/5
        public ActionResult Definidos(int idTorneio)
        {
            Torneio torneio = db.Torneios.Find(idTorneio);

            return View(torneio);
        }

        public ActionResult GerarResultado(int idTorneio, int rodada)
        {
            //db.Torneios.Include(T => T.Jogos).Include(T => T.Times).Load();
            Torneio torneio = db.Torneios.Find(idTorneio);

            torneio.GerarResultados(db, rodada);

            var parametro = new RouteValueDictionary();
            parametro.Add("idTorneio", idTorneio);

            return RedirectToAction("Gerenciar", parametro);
        }



        // GET: Jogos/Gerenciar
        public ActionResult Gerenciar(int idTorneio)
        {
            Torneio torneio = db.Torneios.Find(idTorneio);
            return View(torneio);
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
