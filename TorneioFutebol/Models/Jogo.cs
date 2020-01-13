using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TorneioFutebol.Models
{
    public class Jogo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual Time Time1 { get; set; }
        public virtual Time Time2 { get; set; }
        public int IdTimeVencedor { get; set; }
        public virtual Torneio Torneio { get; set; }
    }
}