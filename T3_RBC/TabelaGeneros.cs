using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3_RBC
{
    public static class TabelaGeneros
    {
        private static string[] Generos = { "Action", "Adventure", "Fighting", "Misc", "Platform", "Puzzle", "Racing", "Role-Playing", "Shooter", "Simulation", "Sports", "Strategy"};

        private static double[][] Sims = new double[][]
        {
            new double[] {1, 0.8, 0.8, 0.4, 0.4, 0, 0.4, 0.6, 0.8, 0.4, 0.4, 0.2},
            new double[] {0.8, 1, 0.6, 0.4, 0.6, 0.4, 0.2, 0.8, 0.4, 0.2, 0, 0},
            new double[] {0.8, 0.6, 1, 0.4, 0.4, 0, 0, 0.6, 0.8, 0.4, 0.2, 0.4},
            new double[] {0.4, 0.4, 0.4, 0.6, 0.4, 0.4, 0.4, 0.4, 0.4, 0.4, 0.4, 0.4},
            new double[] {0.4, 0.6, 0.4, 0.4, 1, 0.6, 0, 0, 0.2, 0, 0, 0.6},
            new double[] {0, 0.4, 0, 0.4, 0.6, 1, 0, 0.6, 0, 0.2, 0, 0.6},
            new double[] {0.4, 0.2, 0, 0.4, 0, 0, 1, 0, 0, 0.4, 0.8, 0.6},
            new double[] {0.6, 0.8, 0.6, 0.4, 0, 0.6, 0, 1, 0.4, 0.2, 0, 0.6},
            new double[] {0.8, 0.4, 0.8, 0.4, 0.2, 0, 0, 0.4, 1, 0.6, 0.6, 0.4},
            new double[] {0.4, 0.2, 0.4, 0.4, 0, 0.2, 0.4, 0.2, 0.6, 1, 0.4, 0.2},
            new double[] {0.4, 0, 0.4, 0.4, 0, 0, 0.8, 0, 0.6, 0.4, 1, 0.8},
            new double[] {0.2, 0, 0.4, 0.4, 0.6, 0.6, 0.6, 0.6, 0.4, 0.2, 0.8, 1}
        };

        public static double SimGenero(string g1, string g2)
        {
            int p1 = Array.IndexOf(Generos, g1);
            int p2 = Array.IndexOf(Generos, g2);

            if(p1 != -1 && p2 != -1)
            {
                return Sims[p1][p2];
            }
            return 0;
        }
    }
}
