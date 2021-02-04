using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CaixaEletronico.Dominio.Entidades
{
    public class Cartao
    {
        public int CartaoId { get; set; }
        [Required]
        public string NomeCliente {get; set; }
        [Required]
        public string NumeroCartao {get; set; }
        public DateTime Validade {get; set; }
        [Required]
        public string Cvc {get; set; }
        [Required]
        public string Senha {get; set; }
        public double Limite {get; set; }

        public Cartao(string nomeCliente, string senha)
        {
            this.NomeCliente = nomeCliente;
            this.Senha = senha;

            var random = new Random();

            var bloco1 = random.Next(1111, 9999).ToString();
            var bloco2 = random.Next(1111, 9999).ToString();
            var bloco3 = random.Next(1111, 9999).ToString();
            var bloco4 = random.Next(1111, 9999).ToString();
            NumeroCartao = bloco1 + bloco2 + bloco3 + bloco4;

            Cvc = random.Next(111, 999).ToString();

            Validade = DateTime.Today.AddYears(4);

            Limite = 0;



        }
    }
}
