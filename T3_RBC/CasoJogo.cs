using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Ribbon.Primitives;

namespace T3_RBC
{
    public class CasoJogo
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
        public double SimAno { get; set; }

        public int ValMinAno {  get; set; }

        public int ValMaxAno { get; set; }
        public double SimGenero { get; set; }
        public double SimVendaNA { get; set; }
        public double SimVendaEU { get; set; }
        public double SimVendaJP { get; set; }
        public double SimVendaOutros { get; set; }
        public double SimVendaGlobal { get; set; }
        public double Similaridade { get; set; }

        public CasoJogo(JogoDTO jogo) 
        {
            Rank = jogo.Rank;
            Nome = jogo.Nome;
            Plataforma = jogo.Plataforma;
            Ano = jogo.Ano;
            Genero = jogo.Genero;
            Publicadora = jogo.Publicadora;
            VendasNA = jogo.VendasNA;
            VendasEU = jogo.VendasEU;
            VendasJP = jogo.VendasJP;
            VendasOutros = jogo.VendasOutros;
            VendasGlobal = jogo.VendasGlobal;
        }

        public void CalcularSimilaridade(JogoDTO entrada, Pesos pesos)
        {
            SimAno = CalcSimAno(entrada.Ano);

            SimGenero = CalcSimGenero(entrada.Genero);

            SimVendaNA = CalcSimNumerica(VendasNA, entrada.VendasNA, 0, 41.5);

            SimVendaEU = CalcSimNumerica(VendasEU, entrada.VendasEU, 0, 29);

            SimVendaJP = CalcSimNumerica(VendasJP, entrada.VendasJP, 0, 10.2);

            SimVendaOutros = CalcSimNumerica(VendasOutros, entrada.VendasOutros, 0, 10.6);

            SimVendaGlobal = CalcSimNumerica(VendasGlobal, entrada.VendasGlobal, 0.01, 82.74);

            Similaridade = Math.Round(SimAno * pesos.PesoAno + SimGenero * pesos.PesoGenero + SimVendaNA * pesos.PesoVendaNA + SimVendaEU * pesos.PesoVendaEU + 
                           SimVendaJP + pesos.PesoVendaJP + SimVendaOutros * pesos.PesoVendaOutros + SimVendaGlobal * pesos.PesoVendaGlobal, 2);

        }

        private double CalcSimNumerica(double n1, double n2, double nMin, double nMax)
        {
            return Math.Round(1 - (Math.Abs(n1 - n2) / (nMax - nMin)), 2);
        }

        private double CalcSimAno(int anoEntrada)
        {
            if (Ano == 0 || anoEntrada == 0) return 0;

            return CalcSimNumerica(Ano, anoEntrada, 1980, 2020);
        }

        private double CalcSimGenero(string generoEntrada)
        {
            return TabelaGeneros.SimGenero(Genero.Trim(), generoEntrada.Trim());
        }

    }
}
