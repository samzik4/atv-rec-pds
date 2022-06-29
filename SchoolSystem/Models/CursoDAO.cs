using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using SchoolSystem.Database;
using SchoolSystem.Helpers;
using MySql.Data.MySqlClient;

namespace SchoolSystem.Models
{
    class CursoDAO
    {
        private Conexao conn = new Conexao();
        public void Insert(Curso curso)
        {
            try
            {
                var comando = conn.Query();
                comando.CommandText = "Insert into curso values (null, @nome, @cargaHoraria, @turno, @descricao)";

                comando.Parameters.AddWithValue("@nome", curso.Nome);
                comando.Parameters.AddWithValue("@cargaHoraria", curso.CargaHoraria);
                comando.Parameters.AddWithValue("@turno", curso.Turno);
                comando.Parameters.AddWithValue("@descricao", curso.Descricao);
                
                var resultado = comando.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Curso> List()
        {
            try
            {
                Conexao conn = new Conexao();

                var lista = new List<Curso>();
                var command = conn.Query();
                command.CommandText = "select * from curso";

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var curso = new Curso();

                    curso.Id = reader.GetInt32("id_cur");
                    curso.Nome = DAOhelper.GetString(reader, "nome_cur");
                    curso.CargaHoraria = DAOhelper.GetString(reader, "carga_horaria_cur");
                    curso.Turno = DAOhelper.GetString(reader, "turno_cur");
                    curso.Descricao = DAOhelper.GetString(reader, "descricao_cur");

                    lista.Add(curso);
                }
                conn.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Curso curso)
        {
            try
            {
                var comando = conn.Query();
                comando.CommandText = "Update curso set nome_cur = @nome, carga_horaria_cur = @cargaHoraria, turno_cur = @turno, descricao_cur = @descricao where id_cur = @id";

                comando.Parameters.AddWithValue("@nome", curso.Nome);
                comando.Parameters.AddWithValue("@cargaHoraria", curso.CargaHoraria);
                comando.Parameters.AddWithValue("@turno", curso.Turno);
                comando.Parameters.AddWithValue("@descricao", curso.Descricao);
                comando.Parameters.AddWithValue("@id", curso.Id);
                var resultado = comando.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Curso curso)
        {
            try
            { 
                Conexao conn = new Conexao();
                var comando = conn.Query();

                comando.CommandText = "delete from curso where id_cur = @id";

                comando.Parameters.AddWithValue("@id", curso.Id);
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
