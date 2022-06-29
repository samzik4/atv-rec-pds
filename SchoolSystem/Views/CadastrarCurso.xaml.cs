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
    /// Lógica interna para CadastrarCurso.xaml
    /// </summary>
    public partial class CadastrarCurso : Window
    {
        private Curso _curso = new Curso();
        public CadastrarCurso()
        {
            InitializeComponent();
        }
        public CadastrarCurso(Curso curso)
        {
            InitializeComponent();
            _curso = curso;
            Loaded += CadastrarCurso_Loaded;
        }

        private void CadastrarCurso_Loaded(object sender, RoutedEventArgs e)
        {
            txtNome.Text = _curso.Nome;
            txtCargaHoraria.Text = _curso.CargaHoraria;
            cbTurno.Text = _curso.Turno;
            txtDescricao.Text = _curso.Descricao;
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            _curso.Nome = txtNome.Text;
            _curso.CargaHoraria = txtCargaHoraria.Text;
            _curso.Turno = cbTurno.Text;
            _curso.Descricao = txtDescricao.Text;

            try
            {
                var dao = new CursoDAO();

                if (_curso.Id > 0)
                {
                    dao.Update(_curso);
                    MessageBox.Show("Update realizado", "Atualização de Banco de Dados", MessageBoxButton.OK);
                }
                else
                {
                    dao.Insert(_curso);
                    MessageBox.Show("Insert realizado", "Atualização de Banco de Dados", MessageBoxButton.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Falha na atualização do Banco de Dados", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btSair_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
