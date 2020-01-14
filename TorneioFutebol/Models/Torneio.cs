using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TorneioFutebol.Data;

namespace TorneioFutebol.Models
{
    public class Torneio
    {

        private TorneioContext db = new TorneioContext();

        public int Id { get; set; }
        public string Nome { get; set; }
        public int TotalTimes { get; set; }
        public virtual ICollection<Jogo> Jogos { get; set; }
        public virtual ICollection<Time> Times { get; set; }

        public bool CriarJogos(TorneioContext db)
        {
            if (Jogos.Count == 0)
            {
                for (int i = 1; i < TotalTimes; i++)
                {
                    Jogo novoJogo = new Jogo()
                    {
                        Nome = $"Jogo {i}",
                        NumeroJogo = i,
                    };

                    var numRodadas = Math.Sqrt(TotalTimes);

                    if (i <= (TotalTimes / 2))
                    {
                        novoJogo.Rodada = 1;
                    } 
                    else
                    {
                        novoJogo.Rodada = 2;
                    }

                    Jogos.Add(novoJogo);

                    //db.Torneios.Find(Id).Jogos.Add(novoJogo);
                    db.SaveChanges();
                }
            }

            return false;
        }

        public bool DefinirJogos(TorneioContext db)
        {
            if (Jogos.Count == TotalTimes - 1 && Times.Count == TotalTimes)
            {
                var times = Times.ToList();
                foreach (var jogo in Jogos)
                {
                    if (jogo.Rodada != 1) break;

                    jogo.Time1 = times[0];
                    times.RemoveAt(0);
                    jogo.Time2 = times[0];
                    times.RemoveAt(0);
                }

                db.Entry(this).State = EntityState.Modified;
                db.SaveChanges();
            }

            return true;
        }

    public bool TimesCompletos()
        {
            return Times.Count == TotalTimes;
        }

        public List<Jogo> JogosDefinidos(List<Jogo> jogos)
        {
            List<Jogo> definidos = new List<Jogo>();

            foreach (var jogo in jogos)
            {
                if (jogo.Time1 != null && jogo.Time2 != null)
                {
                    definidos.Add(jogo);
                }
            }

            return definidos;
        }

        public List<Jogo> JogosDisponiveis()
        {
            List<Jogo> disponiveis = new List<Jogo>();

            foreach (var jogo in Jogos)
            {
                if (jogo.Time1 == null || jogo.Time2 == null)
                {
                    disponiveis.Add(jogo);
                }
            }

            return disponiveis;
        }

        public List<Time> TimesDisponiveis()
        {
            List<Time> disponiveis = new List<Time>();

            foreach (var time in Times)
            {
                if (JogosDefinidos(null).Find(j => j.Time1 == time && j.Time2 == time) == null)
                {
                    disponiveis.Add(time);
                }
            }

            return disponiveis;
        }

        public Jogo ProximoJogoADefinir()
        {
            var jogosDisponiveis = JogosDisponiveis();
            if (jogosDisponiveis.Count > 0)
            {
                return jogosDisponiveis[0];
            }
            return null;
        }
    }
}