using System;
using System.Collections.Generic;
using System.Text;

namespace CaixaEletronico.Aplicacao.Dominio
{
    public class Conta
    {
        public string Agencia { get { return "001"; } }
        public string NumeroConta { get; set; }
        public double Saldo { get; set; }
        public string Senha { get; set; }
        public Cartao Cartao { get; set; }
        public Cliente Cliente { get; set; }
        
        public Conta(string senha)
        {
            this.Saldo = 0;
            this.Senha = senha;
            var random = new Random();
            NumeroConta = random.Next(11111, 99999).ToString();

        }
        public Conta(string senha, string nome, string cpf, DateTime dataNascimento, string endereco, Sexo sexo)
        {
            this.Saldo = 0;
            this.Senha = senha;
            var random = new Random();
            NumeroConta = random.Next(11111, 99999).ToString();
            Cliente = new Cliente(nome, cpf, dataNascimento, endereco, sexo);
        }
    }
}
