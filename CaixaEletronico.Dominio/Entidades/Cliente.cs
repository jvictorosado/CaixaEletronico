using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CaixaEletronico.Dominio.Entidades
{
  
    public class Cliente
    {
        public int ClienteId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        [Required]
        public string Endereco { get; set; }

        public Cliente(string nome, string cpf, DateTime dataNascimento, string endereco)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.DataNascimento = dataNascimento;
            this.Endereco = endereco;
        }



    }
}
