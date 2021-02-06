using CaixaEletronico.Dominio.Entidades;
using CaixaEletronico.Dominio.Infraestrutura.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CaixaEletronico.Aplicacao
{
    public class Program
    {
        public static void Main()
        {
            var contexto = new Contexto();
            var decisao = 9;
            var cartao = "";
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Menu:");
                    Console.WriteLine("1 - Abrir Conta");
                    Console.WriteLine("2 - Encerrar Conta");
                    Console.WriteLine("3 - Ver Extrato");
                    Console.WriteLine("4 - Sacar");
                    Console.WriteLine("5 - Depositar");
                    Console.WriteLine("6 - Transferir");
                    Console.WriteLine("7 - Pagamentos");
                    Console.WriteLine("0 - Encerrar");
                    Console.Write("Digite uma opção:");

                    decisao = Convert.ToInt32(Console.ReadLine());

                    var numeroContaRecebido = "";
                    var senhaContaRecebida = "";
                    Conta conta;

                    switch (decisao)
                    {
                        case 1:
                            Console.WriteLine("Insira seu nome:");
                            var nome = Console.ReadLine();
                            Console.WriteLine("Insira o seu CPF: ");
                            var cpf = Console.ReadLine();
                            Console.WriteLine("Insira a sua data de nascimento(dd/mm/aaaa):");
                            var dataNascimento = ConverteData(Console.ReadLine());
                            Console.WriteLine("Insira o seu Endereço: ");
                            var endereco = Console.ReadLine();
                            Console.WriteLine("Insira a senha desejada: ");
                            var senha = Console.ReadLine();
                            conta = new Conta(senha, nome, cpf, dataNascimento, endereco);
                            contexto.Contas.Add(conta);
                            contexto.SaveChanges();
                            Console.WriteLine($"Conta {conta.NumeroConta} Criada com Sucesso!");
                            Console.WriteLine("Insira o nome a ser colocado no cartão:");
                            var nomeCartao = Console.ReadLine();
                            Console.WriteLine("digite uma senha para o cartão:");
                            var senhaCartao = Console.ReadLine();
                            conta.Cartao = new Cartao(nomeCartao, senhaCartao);
                            contexto.Cartoes.Add(conta.Cartao);
                            contexto.SaveChanges();
                            Console.WriteLine($"o cartão de numero {conta.Cartao.NumeroCartao} foi gerado com sucesso!");
                            break;
                        case 2:
                            Console.WriteLine("Insira o numero do cartao:");
                            cartao = Console.ReadLine();
                            conta = ProcuraConta(contexto, cartao);
                            Console.WriteLine("Insira a senha conta:");
                            senhaContaRecebida = Console.ReadLine();
                            if (conta.Senha == senhaContaRecebida)
                            {
                               if (conta.Saldo == 0)
                                {
                                    contexto.Contas.Remove(conta);
                                    contexto.SaveChanges();
                                    Console.WriteLine($"A conta {conta.NumeroConta} foi excluida com sucesso!");
                                }
                                else
                                {
                                    Console.WriteLine($"A conta tem o saldo atual de: R${conta.Saldo}.Portanto não pode ser excluida");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Senha Incorreta");
                            }
                            break;

                        case 3:
                            Console.WriteLine("Insira o numero do cartao:");
                            cartao = Console.ReadLine();
                            conta = ProcuraConta(contexto, cartao);
                            Console.WriteLine("Insira a senha conta:");
                            senhaContaRecebida = Console.ReadLine();
                            if (conta.Senha == senhaContaRecebida)
                            {
                                Console.WriteLine($"Saldo atual: R${conta.Saldo}");
                                Console.WriteLine("Insira o periodo inicial no formato dd/mm/aaaa:");
                                var inicial = ConverteData(Console.ReadLine());
                                Console.WriteLine("Insira o periodo final no formato dd/mm/aaaa:");
                                var final = ConverteData(Console.ReadLine());
                                var lista = contexto.Comprovantes.Where(z => z.ContaId.Equals(conta.ContaId) && (z.Data.Date >= inicial && z.Data.Date <= final)).ToList();
                                foreach (var comprovante in lista)
                                {
                                    Console.WriteLine($"Data: {comprovante.Data} ---- Valor: R$ {comprovante.Valor.ToString("N2")} ---- Cod.Validador: {comprovante.Validacao}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Senha Incorreta");
                            }
                            break;


                        case 4:
                            Console.WriteLine("Insira o numero do cartao:");
                            cartao = Console.ReadLine();
                            conta = ProcuraConta(contexto, cartao);
                            Console.WriteLine("Insira a senha conta:");
                            senhaContaRecebida = Console.ReadLine();
                            if (conta.Senha == senhaContaRecebida)
                            {
                                Console.WriteLine("Digite o valor a ser sacado:");
                                var saque = Convert.ToDouble(Console.ReadLine());
                                if ((double)conta.Saldo >= saque)
                                {
                                    conta.Saldo -= saque;
                                    contexto.SaveChanges();
                                    Console.WriteLine("Saque realizado com sucesso!");
                                }
                                else
                                {
                                    Console.WriteLine("Saldo Insuficiente");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Senha Incorreta");
                            }
                            break;

                        case 5:
                            Console.WriteLine("Insira o numero da conta:");
                            numeroContaRecebido = Console.ReadLine();
                            conta = ProcuraContaPeloNum(contexto, numeroContaRecebido);
                            Console.WriteLine("Digite o valor a depositado:");
                            conta.Saldo += Convert.ToInt64(Console.ReadLine());
                            Console.WriteLine("Deposito realizado com sucesso!");
                            contexto.SaveChanges();
                            break;
                          

                        case 6:
                            Console.WriteLine("Insira o numero do cartao:");
                            cartao = Console.ReadLine();
                            conta = ProcuraConta(contexto, cartao);
                            Console.WriteLine("Insira a senha conta:");
                            senhaContaRecebida = Console.ReadLine();
                            if (conta.Senha == senhaContaRecebida)
                            {
                                Console.WriteLine("Digite o valor a ser transferido:");
                                var transferir = Convert.ToDouble(Console.ReadLine());
                                if ((double)conta.Saldo >= transferir)
                                {
                                    Console.WriteLine("Insira o numero da conta a ser transferida:");
                                    var numeroConta2Recebido = Console.ReadLine();
                                    var conta2 = ProcuraContaPeloNum(contexto, numeroConta2Recebido);
                                    conta.Saldo -= transferir;
                                    conta2.Saldo += transferir;
                                    contexto.SaveChanges();
                                    Console.WriteLine("Transferencia realizado com sucesso!");

                                }
                                else
                                {
                                    Console.WriteLine("Saldo Insuficiente");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Senha Incorreta");

                            }
                            break;

                        case 7:
                            Console.WriteLine("Insira o numero do cartao:");
                            cartao = Console.ReadLine();
                            conta = ProcuraConta(contexto, cartao);
                            Console.WriteLine("Insira a senha conta:");
                            senhaContaRecebida = Console.ReadLine();
                            if (conta.Senha == senhaContaRecebida)
                            {
                                Console.WriteLine("Digite os 10 ultimos numeros do boleto a ser pago:");
                                var boleto = (Convert.ToDouble(Console.ReadLine()) * 0.01);
                                if ((double)conta.Saldo >= boleto)
                                {
                                    conta.Saldo -= boleto;
                                    var comprovante = new Comprovante(conta.ContaId, boleto);
                                    contexto.Comprovantes.Add(comprovante);
                                    contexto.SaveChanges();
                                    Console.WriteLine("boleto pago com sucesso!");
                                    Console.WriteLine($"Codigo de Validação: {comprovante.Validacao}");
                                }
                                else
                                {
                                    Console.WriteLine("Saldo Insuficiente");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Senha Incorreta");
                            }
                            break;

                        case 0:
                            decisao = 0;
                            Console.WriteLine("Sistema Encerrado");
                            break;

                        default:
                            Console.WriteLine("Opção Inválida");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Inserções Inválidas");
                }
                Console.ReadLine();
            } while (decisao != 0);

        }

        public static Conta ProcuraConta(Contexto contexto, string numCartao)
        {
            var cartao = contexto.Cartoes.FirstOrDefault(i => i.NumeroCartao.Equals(numCartao));
            return contexto.Contas.FirstOrDefault(j => j.CartaoId.Equals(cartao.CartaoId));
        }

        public static Conta ProcuraContaPeloNum(Contexto contexto, string numConta)
        {
            return contexto.Contas.FirstOrDefault(j => j.NumeroConta.Equals(numConta));
        }


        public static DateTime ConverteData(string data)
        {
            var dataSplit = data.Split('/');
            return new DateTime(Convert.ToInt32(dataSplit[2]) , Convert.ToInt32(dataSplit[1]) , Convert.ToInt32(dataSplit[0]));
        }

    }
}
