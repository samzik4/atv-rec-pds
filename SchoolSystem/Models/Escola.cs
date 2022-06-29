using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models
{
    public class Escola
    {
        public int Id { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public DateTime ? DataCriacao { get; set; }
        public string Responsavel { get; set; }
        public string ResponsavelTelefone { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        private string _tipo;

        public string Tipo => _tipo;

        public void SetTipo(bool t)
        {
            if (t)
                _tipo = "Público";
            else
                _tipo = "Privado";
        }
        public void SetTipo(string tipo) 
        {
            this._tipo = tipo;
        }
    }
}
