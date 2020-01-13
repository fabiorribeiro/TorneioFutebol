using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TorneioFutebol.Models
{
    public class Time
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual Torneio Torneio { get; set; }
    }
}