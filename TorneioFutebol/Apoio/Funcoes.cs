using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TorneioFutebol.Data;
using TorneioFutebol.Models;

namespace TorneioFutebol.Apoio
{
    public static class Funcoes
    {
        public static bool DefinirJogos(Torneio torneio, TorneioContext db)
        {
            if (torneio.Times.Count != torneio.TotalTimes)
            {
                return false;
            }
            else
            {
                var times = torneio.Times.ToList();

                for (int i = 1; i < torneio.TotalTimes; i++)
                {
                    Jogo novoJogo = new Jogo() { Nome = $"Jogo {i}" };
                    if (i <= (torneio.TotalTimes / 2))
                    {
                        novoJogo.Time1 = times[i];
                        novoJogo.Time2 = times[i + (torneio.TotalTimes / 2)];
                    }
                    //TorneioContext db = new TorneioContext();
                    //db.Torneios.Find(torneio.Id).Jogos.Add(novoJogo);
                    torneio.Jogos.Add(novoJogo);
                    db.SaveChanges();
                }
                return true;
            }
        }

    }
}