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
using SchoolSystem.Models;

namespace SchoolSystem.Views
{
    /// <summary>
    /// Lógica interna para ListaEscola.xaml
    /// </summary>
    public partial class ListaEscola : Window
    {
        public ListaEscola()
        {
            InitializeComponent();
            Loaded += ListaEscola_Loaded;
        }

        public void ListaEscola_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }

        private void Button_Atualizar_Click(object sender, RoutedEventArgs e)
        {
            var escolaSelecionada = dataGridEscola.SelectedItem as Escola;

            var form = new Adicionar(escolaSelecionada);
            form.ShowDialog();
        }

        private void Button_Remover_Click(object sender, RoutedEventArgs e)
        {
            var escolaSelecionada = dataGridEscola.SelectedItem as Escola;

            var resultado = MessageBox.Show($"Deseja realmente excluir '{escolaSelecionada.NomeFantasia}' ?", "Confirmação de Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (resultado == MessageBoxResult.Yes)
                {
                    var dao = new EscolaDAO();
                    dao.Delete(escolaSelecionada);

                    MessageBox.Show("Registro Apagado!");
                }
                CarregarListagem();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CarregarListagem()
        {
            try
            {
                var dao = new EscolaDAO();
                List<Escola> listaEscolas = dao.List();

                dataGridEscola.ItemsSource = listaEscolas;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Falha na listagem");
            }
        }
    }
}
