using System;
using System.Collections.Generic;
using System.Text;

namespace CaixaEletronico.Aplicacao.Dominio
{
    public enum Sexo
    {
        Masculino = 1,
        Feminino = 2,
        Outros = 3
    }
    public class Cliente
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public Sexo Sexo { get; set; }

        public Cliente(string nome, string cpf, DateTime dataNascimento, string endereco, Sexo sexo)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.DataNascimento = dataNascimento;
            this.Endereco = endereco;
            this.Sexo = sexo;
        }



    }
}
