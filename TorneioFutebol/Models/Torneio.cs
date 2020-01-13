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
        public virtual ICollection<Jogo> Jogos { get; set; }
        public virtual ICollection<Time> Times { get; set; }

        public bool adicionarTime(Time time, int idTorneio)
        {
            try
            {
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}