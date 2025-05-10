using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace T3_RBC
{
    /// <summary>
    /// Lógica interna para JanelaSelecao.xaml
    /// </summary>
    public partial class JanelaSelecao : Window
    {
        public JogoDTO Selecionado { get; private set; }

        public JanelaSelecao(List<JogoDTO> listaJogos)
        {
            InitializeComponent();
            GridJogos.ItemsSource = listaJogos;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (GridJogos.SelectedItem is JogoDTO jogo)
            {
                Selecionado = jogo;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Selecione um jogo antes de confirmar!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
