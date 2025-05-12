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
        public JogoDTO Caso { get; set; }
        public double SimAno { get; set; }
        public double SimGenero { get; set; }
        public double SimVendaNA { get; set; }
        public double SimVendaEU { get; set; }
        public double SimVendaJP { get; set; }
        public double SimVendaOutros { get; set; }
        public double SimVendaGlobal { get; set; }
        public double Similaridade { get; set; }

        public CasoJogo(JogoDTO jogo) 
        {
            Caso = jogo;
        }

        public void CalcularSimilaridade(JogoDTO entrada, Pesos pesos)
        {
            SimAno = CalcSimAno(entrada.Ano);
            SimGenero = CalcSimGenero(entrada.Genero);
            SimVendaNA = CalcSimNumerica(Caso.VendasNA, entrada.VendasNA, 0, 41.5);
            SimVendaEU = CalcSimNumerica(Caso.VendasEU, entrada.VendasEU, 0, 29);
            SimVendaJP = CalcSimNumerica(Caso.VendasJP, entrada.VendasJP, 0, 10.2);
            SimVendaOutros = CalcSimNumerica(Caso.VendasOutros, entrada.VendasOutros, 0, 10.6);
            SimVendaGlobal = CalcSimNumerica(Caso.VendasGlobal, entrada.VendasGlobal, 0.01, 82.74);

            Similaridade = (SimAno * pesos.PesoAno + SimGenero * pesos.PesoGenero + SimVendaNA * pesos.PesoVendaNA + SimVendaEU * pesos.PesoVendaEU +
                           SimVendaJP + pesos.PesoVendaJP + SimVendaOutros * pesos.PesoVendaOutros + SimVendaGlobal * pesos.PesoVendaGlobal)
                           / (pesos.PesoAno + pesos.PesoGenero + pesos.PesoVendaNA + pesos.PesoVendaEU + pesos.PesoVendaJP + pesos.PesoVendaOutros + pesos.PesoVendaGlobal);

            SimAno = Math.Round(SimAno, 2);
            SimGenero = Math.Round(SimGenero, 2);           
            SimVendaNA = Math.Round(SimVendaNA, 2);          
            SimVendaEU = Math.Round(SimVendaEU, 2);          
            SimVendaJP = Math.Round(SimVendaJP, 2);            
            SimVendaOutros = Math.Round(SimVendaOutros, 2);            
            SimVendaGlobal = Math.Round( SimVendaGlobal, 2);
            Similaridade = Math.Round(Similaridade, 2);

            
        }

        private double CalcSimNumerica(double n1, double n2, double nMin, double nMax)
        {
            return 1 - (Math.Abs(n1 - n2) / (nMax - nMin));
        }

        private double CalcSimAno(int anoEntrada)
        {
            if (Caso.Ano == 0 || anoEntrada == 0) return 0;

            return CalcSimNumerica(Caso.Ano, anoEntrada, 1980, 2020);
        }

        private double CalcSimGenero(string generoEntrada)
        {
            return TabelaGeneros.SimGenero(Caso.Genero.Trim(), generoEntrada.Trim());
        }

    }
}
