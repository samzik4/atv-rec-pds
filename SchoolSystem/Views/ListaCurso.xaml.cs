﻿using System;
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
    /// Lógica interna para ListaCurso.xaml
    /// </summary>
    public partial class ListaCurso : Window
    {
        public ListaCurso()
        {
            InitializeComponent();
            Loaded += ListaCurso_Loaded;
        }

        public void ListaCurso_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }

        private void CarregarListagem()
        {
            try
            {
                var dao = new CursoDAO();
                List<Curso> listarCursos = dao.List();

                dataGridCurso.ItemsSource = listarCursos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Falha na listagem");
            }
        }

        private void Button_Remover_Click(object sender, RoutedEventArgs e)
        {
            var cursoSelecionado = dataGridCurso.SelectedItem as Curso;
            var resultado = MessageBox.Show($"Deseja excluir \"{cursoSelecionado}\"?", "Confirmação de Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (resultado == MessageBoxResult.Yes)
                {
                    var dao = new CursoDAO();
                    dao.Delete(cursoSelecionado);

                    MessageBox.Show("Registro Apagado!");
                }
                CarregarListagem();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void Button_Atualizar_Click(object sender, RoutedEventArgs e)
        {
            var cursoSelecionado = dataGridCurso.SelectedItem as Curso;
            var form = new CadastrarCurso(cursoSelecionado);
            form.ShowDialog();
        }
    }
}
