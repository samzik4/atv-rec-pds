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
using MySql.Data.MySqlClient;
using SchoolSystem.Models;


namespace SchoolSystem.Views
{
    /// <summary>
    /// Lógica interna para Adicionar.xaml
    /// </summary>
    public partial class Adicionar : Window
    {
        private Escola _escola = new Escola();
        public Adicionar()
        {
            InitializeComponent();
            Loaded += Adicionar_Loaded;
        }

        public Adicionar(Escola escola)
        {
            InitializeComponent();
            Loaded += Adicionar_Loaded;

            _escola = escola;
        }

        private void Adicionar_Loaded(object sender, RoutedEventArgs e)
        {
            txtNomeFantasia.Text = _escola.NomeFantasia;
            txtRazaoSocial.Text = _escola.RazaoSocial;
            txtCnpj.Text = _escola.Cnpj;
            txtInscricaoEstadual.Text = _escola.InscricaoEstadual;
            txtResponsavel.Text = _escola.Responsavel;
            txtTelefoneResp.Text = _escola.ResponsavelTelefone;
            txtTelefone.Text = _escola.Telefone;
            txtEmail.Text = _escola.Email;
            txtRua.Text = _escola.Rua;
            txtNumero.Text = _escola.Numero;
            txtBairro.Text = _escola.Bairro;
            txtCidade.Text = _escola.Cidade;
            txtComplemento.Text = _escola.Complemento;
            txtCep.Text = _escola.Cep;
            cbEstado.Text = _escola.Estado;

            dtDataCriacao.SelectedDate = _escola.DataCriacao;

            if (_escola.Tipo == "Pública")
            {
                rbPublico.IsChecked = true;
            }
            else
            {
                rbPrivado.IsChecked = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Escola escolaSelecionada = _escola;

            _escola.NomeFantasia = txtNomeFantasia.Text;
            _escola.RazaoSocial = txtRazaoSocial.Text;
            _escola.Cnpj = txtCnpj.Text;
            _escola.InscricaoEstadual = txtInscricaoEstadual.Text;
            _escola.Responsavel = txtResponsavel.Text;
            _escola.ResponsavelTelefone = txtTelefoneResp.Text;
            _escola.Email = txtEmail.Text;
            _escola.Telefone = txtTelefone.Text;
            _escola.Rua = txtRua.Text;
            _escola.Numero = txtNumero.Text;
            _escola.Bairro = txtBairro.Text;
            _escola.Complemento = txtComplemento.Text;
            _escola.Cep = txtCep.Text;
            _escola.Cidade = txtCidade.Text;
            _escola.Estado = cbEstado.Text;

            escolaSelecionada.DataCriacao = dtDataCriacao.SelectedDate;

            escolaSelecionada.SetTipo((bool)rbPublico.IsChecked);

            try
            {
                var dao = new EscolaDAO();

                if (escolaSelecionada.Id > 0)
                {
                    dao.Update(escolaSelecionada);
                    MessageBox.Show("Update concluído", "Atualização do Banco de Dados", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    dao.Insert(escolaSelecionada);
                    MessageBox.Show("Insert concluído", "Inserção do Banco de Dados", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch(Exception ex)
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











