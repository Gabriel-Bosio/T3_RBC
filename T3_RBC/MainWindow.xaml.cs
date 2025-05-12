using System.Windows;

namespace T3_RBC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<JogoDTO> todosJogos;
        private JogoDTO jogoSelecionado;
        private Pesos pesos;

        public MainWindow()
        {
            InitializeComponent();

            todosJogos = Leitor.LerCsv();
            pesos = new Pesos();

            GridPesos.ItemsSource = new List<Pesos> { pesos };
        }

        private void BtnEscolher_Click(object sender, RoutedEventArgs e)
        {
            var popup = new JanelaSelecao(todosJogos); // Janela que será criada
            if (popup.ShowDialog() == true && popup.Selecionado != null)
            {
                jogoSelecionado = popup.Selecionado;
                GridEntrada.ItemsSource = new List<JogoDTO> { jogoSelecionado };
            }
        }

        private void BtnCalcular_Click(object sender, RoutedEventArgs e)
        {
            if (jogoSelecionado == null)
            {
                MessageBox.Show("Selecione um jogo antes de calcular!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!TodosPesosValidos(pesos))
            {
                MessageBox.Show("Todos os pesos devem estar preenchidos corretamente!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            List<CasoJogo> resultados = new List<CasoJogo>();
            foreach (JogoDTO jogo in todosJogos)
            {
                if (jogo.Rank != jogoSelecionado.Rank)
                {
                    CasoJogo caso = new CasoJogo(jogo);
                    caso.CalcularSimilaridade(jogoSelecionado, pesos);
                    resultados.Add(caso);
                }
            }
            resultados = resultados.OrderByDescending(x => x.Similaridade).ToList();

            GridResultado.ItemsSource = resultados;
        }

        private bool TodosPesosValidos(Pesos p)
        {
            return p.PesoAno > 0 &&
                   p.PesoGenero > 0 &&
                   p.PesoVendaNA > 0 &&
                   p.PesoVendaEU > 0 &&
                   p.PesoVendaJP > 0 &&
                   p.PesoVendaOutros > 0 &&
                   p.PesoVendaGlobal > 0;
        }
    }
}