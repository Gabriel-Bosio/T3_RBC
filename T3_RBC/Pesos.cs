using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3_RBC
{
    public class Pesos
    {
        public double PesoAno { get; set; }
        public double PesoGenero { get; set; }
        public double PesoVendaNA { get; set; }
        public double PesoVendaEU { get; set; }
        public double PesoVendaJP { get; set; }
        public double PesoVendaOutros { get; set; }
        public double PesoVendaGlobal { get; set; }

        public Pesos() 
        {
            PesoAno = 2;
            PesoGenero = 4;
            PesoVendaNA = 0.5;
            PesoVendaEU = 0.5;
            PesoVendaJP = 0.5;
            PesoVendaOutros = 0.5;
            PesoVendaGlobal = 2;
        }
    }
}
