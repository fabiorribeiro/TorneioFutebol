using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TorneioFutebol.Models;

namespace TorneioFutebol.Data
{
    public class TorneioContext: DbContext
    {
        public DbSet<Torneio> Torneios { get; set; }
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Time> Times { get; set; }

    }
}