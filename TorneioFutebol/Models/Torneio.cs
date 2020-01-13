using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public void CriarJogos()
        {
            TorneioContext db = new TorneioContext();

            for (int i = 1; i < TotalTimes; i++)
            {
                Jogo novoJogo = new Jogo()
                {
                    Nome = $"Jogo {i}"
                };
                db.Torneios.Find(Id).Jogos.Add(novoJogo);
                db.SaveChanges();
            }
        }

    public bool TimesCompletos()
        {
            return Times.Count == TotalTimes;
        }

        public List<Jogo> JogosDefinidos()
        {
            List<Jogo> definidos = new List<Jogo>();

            foreach (var jogo in Jogos)
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
                if (JogosDefinidos().Find(j => j.Time1 == time && j.Time2 == time) == null)
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