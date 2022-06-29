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

namespace SchoolSystem.Views
{
    /// <summary>
    /// Lógica interna para Cadastros.xaml
    /// </summary>
    public partial class Cadastros : Window
    {
        public Cadastros()
        {
            InitializeComponent();
        }

        private void btCadastrarEsc_Click(object sender, RoutedEventArgs e)
        {
            Adicionar add = new Adicionar();
            add.ShowDialog();
        }

        private void btListarEsc_Click(object sender, RoutedEventArgs e)
        {
            ListaEscola listEsc = new ListaEscola();
            listEsc.ShowDialog();
        }

        private void btCadastrarCur_Click(object sender, RoutedEventArgs e)
        {
            CadastrarCurso cadastroCur = new CadastrarCurso();
            cadastroCur.ShowDialog();
        }

        private void btListarCur_Click(object sender, RoutedEventArgs e)
        {
            ListaCurso listCur = new ListaCurso();
            listCur.ShowDialog();
        }
    }
}
