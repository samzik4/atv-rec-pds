using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SchoolSystem.Database;
using MySql.Data.MySqlClient;
using SchoolSystem.Helpers;

namespace SchoolSystem.Models
{
    internal class EscolaDAO
    {
        private static Conexao _conn = new Conexao();
        public void Insert(Escola escola)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Insert into escola values " +
                    "(@nome, @razao, @cnpj, @inscricao, @tipo, @data_criacao, @responsavel, @resp_telefone, " +
                    "@email, @telefone, @rua, @numero, @bairro, @complemento, @cep, @cidade, @estado);";

                comando.Parameters.AddWithValue("@nome", escola.NomeFantasia);
                comando.Parameters.AddWithValue("@razao", escola.RazaoSocial);
                comando.Parameters.AddWithValue("@cnpj", escola.Cnpj);
                comando.Parameters.AddWithValue("@inscricao", escola.InscricaoEstadual);
                comando.Parameters.AddWithValue("@tipo", escola.Tipo);

                var data = escola.DataCriacao?.ToString("yyyy-MM-dd");

                comando.Parameters.AddWithValue("@data_criacao", escola.DataCriacao);
                comando.Parameters.AddWithValue("@responsavel", escola.Responsavel);
                comando.Parameters.AddWithValue("@resp_telefone", escola.ResponsavelTelefone);
                comando.Parameters.AddWithValue("@email", escola.Email);
                comando.Parameters.AddWithValue("@telefone", escola.Telefone);
                comando.Parameters.AddWithValue("@rua", escola.Rua);
                comando.Parameters.AddWithValue("@numero", escola.Numero);
                comando.Parameters.AddWithValue("@bairro", escola.Bairro);
                comando.Parameters.AddWithValue("@complemento", escola.Complemento);
                comando.Parameters.AddWithValue("cep", escola.Cep);
                comando.Parameters.AddWithValue("@cidade", escola.Cidade);
                comando.Parameters.AddWithValue("@estado", escola.Estado);

                var resultado = comando.ExecuteNonQuery();

                if (resultado > 0)
                {
                    MessageBox.Show("Registro Salvo!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Update(Escola escola)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Update escola set nome_fantasia_esc = @nomeFantasia, razao_social_esc = @razaoSocial, cnpj_esc = @cnpj, insc_estadual_esc = @inscricaoEst, tipo_esc = @tipo, data_criacao_esc = @data, responsavel_esc =@responsavel, responsavel_telefone_esc = @ResponsavelTelefone, telefone_esc = @telefone, " +
                    "email_esc = @email, rua_esc = @rua, bairro_esc = @bairro, numero_esc = @numero, cep_esc = @cep, complemento_esc = @complemento, cidade_esc = @cidade, estado_esc = @estado where id_esc = @id;";

                comando.Parameters.AddWithValue("@nomeFantasia", escola.NomeFantasia);
                comando.Parameters.AddWithValue("@razaoSocial", escola.RazaoSocial);
                comando.Parameters.AddWithValue("@cnpj", escola.Cnpj);
                comando.Parameters.AddWithValue("@inscricaoEst", escola.InscricaoEstadual);
                comando.Parameters.AddWithValue("@tipo", escola.Tipo);
                comando.Parameters.AddWithValue("@data", escola.DataCriacao);
                comando.Parameters.AddWithValue("@responsavelTelefone", escola.ResponsavelTelefone);
                comando.Parameters.AddWithValue("@responsavel", escola.Responsavel);
                comando.Parameters.AddWithValue("@telefone", escola.Telefone);
                comando.Parameters.AddWithValue("@email", escola.Email);
                comando.Parameters.AddWithValue("@rua", escola.Rua);
                comando.Parameters.AddWithValue("@bairro", escola.Bairro);
                comando.Parameters.AddWithValue("@numero", escola.Numero);
                comando.Parameters.AddWithValue("@cep", escola.Cep);
                comando.Parameters.AddWithValue("@complemento", escola.Complemento);
                comando.Parameters.AddWithValue("@cidade", escola.Cidade);
                comando.Parameters.AddWithValue("@estado", escola.Estado);
                comando.Parameters.AddWithValue("@id", escola.Id);
                var resultado = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<Escola> List()
        {
            try
            {
                //Conexao conn = new Conexao();

                var lista = new List<Escola>();
                var comando = _conn.Query();
                comando.CommandText = "select * from escola";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var escolaa = new Escola();
                    escolaa.Id = reader.GetInt32("id_esc");
                    escolaa.NomeFantasia = DAOhelper.GetString(reader, "nome_fantasia_esc");
                    escolaa.RazaoSocial = DAOhelper.GetString(reader, "razao_social_esc");
                    escolaa.Cnpj = DAOhelper.GetString(reader, "cnpj_esc");
                    escolaa.InscricaoEstadual = DAOhelper.GetString(reader, "insc_estadual_esc");
                    escolaa.SetTipo(DAOhelper.GetString(reader, "tipo_esc"));
                    escolaa.DataCriacao = DAOhelper.GetDateTime(reader, "data_criacao_esc");
                    escolaa.Responsavel = DAOhelper.GetString(reader, "responsavel_esc");
                    escolaa.ResponsavelTelefone = DAOhelper.GetString(reader, "responsavel_telefone_esc");
                    escolaa.Email = DAOhelper.GetString(reader, "email_esc");
                    escolaa.Telefone = DAOhelper.GetString(reader, "telefone_esc");
                    escolaa.Rua = DAOhelper.GetString(reader, "rua_esc");
                    escolaa.Numero = reader.GetString("numero_esc");
                    escolaa.Bairro = DAOhelper.GetString(reader, "bairro_esc");
                    escolaa.Complemento = DAOhelper.GetString(reader, "complemento_esc");
                    escolaa.Cep = DAOhelper.GetString(reader, "cep_esc");
                    escolaa.Cidade = DAOhelper.GetString(reader, "cidade_esc");
                    escolaa.Estado = DAOhelper.GetString(reader, "estado_esc");

                    lista.Add(escolaa);
                }
                //conn.Close();
                reader.Close();
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Escola escola)
        {
            try
            { 
                var comando = _conn.Query();

                comando.CommandText = "delete from escola where id_esc = @id";

                comando.Parameters.AddWithValue("@id", escola.Id);
                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Erro!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

