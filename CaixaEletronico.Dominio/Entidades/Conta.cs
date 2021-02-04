using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CaixaEletronico.Dominio.Entidades
{
    public class Conta
    {
        public int ContaId { get; set; }
        [Required]
        public string Agencia { get { return "001"; } }
        [Required]
        public string NumeroConta { get; set; }
        public double Saldo { get; set; }
        [Required]
        public string Senha { get; set; }

        [ForeignKey("Cartao")]
        public int? CartaoId { get; set; }
        public Cartao Cartao { get; set; }
        [Required]
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public Conta(string senha)
        {
            this.Saldo = 0;
            this.Senha = senha;
            var random = new Random();
            NumeroConta = random.Next(11111, 99999).ToString();

        }
        public Conta(string senha, string nome, string cpf, DateTime dataNascimento, string endereco)
        {
            this.Saldo = 0;
            this.Senha = senha;
            var random = new Random();
            NumeroConta = random.Next(11111, 99999).ToString();
            Cliente = new Cliente(nome, cpf, dataNascimento, endereco);
        }
    }
}
