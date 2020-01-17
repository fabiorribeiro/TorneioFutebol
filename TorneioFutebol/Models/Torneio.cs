using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
                List<int> jogosPorRodada = mapearJogosRodadas(TotalTimes);

                for (int i = 1; i < TotalTimes; i++)
                {
                    Jogo novoJogo = new Jogo()
                    {
                        Nome = $"Jogo {i}",
                        NumeroJogo = i,
                        Rodada = jogosPorRodada[i - 1]
                    };

                    Jogos.Add(novoJogo);
                    db.SaveChanges();
                }
                return true;
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

        private List<int> mapearJogosRodadas(int numTimes) {
            List<int> jogosRodadas = new List<int>();

            int numJogos = numTimes / 2;

            int rodada = 1;
            while (numJogos >= 1)
            {
                for (int j = 0; j < numJogos; j++)
                {
                    jogosRodadas.Add(rodada);
                }
                rodada++;
                numJogos = numJogos / 2;
            }

            return jogosRodadas;
        }

        public bool TimesCompletos()
        {
            return Times.Count == TotalTimes;
        }

        //public List<Jogo> JogosDisponiveis()
        //{
        //    List<Jogo> disponiveis = new List<Jogo>();

        //    foreach (var jogo in Jogos)
        //    {
        //        if (jogo.Time1 == null || jogo.Time2 == null)
        //        {
        //            disponiveis.Add(jogo);
        //        }
        //    }

        //    return disponiveis;
        //}

        public int Rodadas()
        {
            return (int)Math.Sqrt(TotalTimes);
        }
        
        public bool JogosCriados()
        {
            return Jogos.Count == TotalTimes - 1;
        }

        public bool JogosDefinidos()
        {
            bool definida = true;

            for (int i = 0; i < Jogos.Count; i++)
            {
                if (Jogos.ElementAt(i).Rodada > 1) break;

                if (Jogos.ElementAt(i).Time1 == null || Jogos.ElementAt(i).Time2 == null)
                {
                    definida = false;
                    break;
                }
            }
            

            return definida;
        }

        public List<Jogo> JogosPorRodada(int numRodada)
        {
            return Jogos.Where(j => j.Rodada == numRodada).ToList();
        }
    }
}