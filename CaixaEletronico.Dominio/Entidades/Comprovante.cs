using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace CaixaEletronico.Dominio.Entidades
{
    public class Comprovante
    {
        public int ComprovanteId { get; set; }
        [Required]
        public Guid Validacao { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        [ForeignKey("ContaId")]
        public int ContaId { get; set; }

        public Comprovante (int contaId , double valor)
        {
            Validacao = Guid.NewGuid();
            Data = DateTime.Now;
            Valor = valor;
            ContaId = contaId;
        }
    }
}
