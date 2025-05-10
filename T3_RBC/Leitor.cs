using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3_RBC
{
    internal static class Leitor
    {
        public static List<JogoDTO> LerCsv()
        {
            var jogos = new List<JogoDTO>();

            using (TextFieldParser parser = new TextFieldParser(".\\..\\..\\..\\video_games_sales.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                // Pula o cabeçalho
                if (!parser.EndOfData)
                    parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[] colunas = parser.ReadFields();

                    if (colunas.Length < 11)
                        continue;

                    jogos.Add(new JogoDTO
                    {
                        Rank = int.TryParse(colunas[0], out int rank) ? rank : 0,
                        Nome = colunas[1],
                        Plataforma = colunas[2],
                        Ano = colunas[3] == "N/A" ? 0 : int.TryParse(colunas[3], out int ano) ? ano : 0,
                        Genero = colunas[4],
                        Publicadora = colunas[5],
                        VendasNA = ParseDouble(colunas[6]),
                        VendasEU = ParseDouble(colunas[7]),
                        VendasJP = ParseDouble(colunas[8]),
                        VendasOutros = ParseDouble(colunas[9]),
                        VendasGlobal = ParseDouble(colunas[10])
                    });
                }
            }

            return jogos;
        }

        private static double ParseDouble(string valor)
        {
            // Garante que o ponto seja aceito como separador decimal
            return double.TryParse(valor, NumberStyles.Any, CultureInfo.InvariantCulture, out var resultado)
                ? resultado
                : 0.0;
        }
    }
}
