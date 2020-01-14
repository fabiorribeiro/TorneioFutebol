﻿using System;
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

        // GET: Jogos/Definidos/5
        public ActionResult Definidos(int idTorneio)
        {
            Torneio torneio = db.Torneios.Find(idTorneio);

            return View(torneio);
        }


        // GET: Jogos/Create
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
