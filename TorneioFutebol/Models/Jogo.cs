using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TorneioFutebol.Models
{
    public class Jogo
    {
        public int id { get; set; }
        public int nome { get; set; }
        public Time time1 { get; set; }
        public Time time2 { get; set; }
        public int idTimeVencedor { get; set; }
    }
}