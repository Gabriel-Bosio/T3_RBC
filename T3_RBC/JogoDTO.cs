using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace T3_RBC
{
    public class JogoDTO
    {
        public int Rank { get; set; }
        public string Nome { get; set; }
        public string Plataforma { get; set; }
        public int Ano { get; set; }
        public string Genero { get; set; }
        public string Publicadora { get; set; }
        public double VendasNA { get; set; }
        public double VendasEU { get; set; }
        public double VendasJP { get; set; }
        public double VendasOutros { get; set; }
        public double VendasGlobal { get; set; }
    }
}
