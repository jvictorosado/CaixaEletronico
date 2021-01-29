using CaixaEletronico.Aplicacao.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaixaEletronico.Aplicacao
{
    public class Program
    {
        public static void Main()
        {
            var decisao = 0;
            var listaContas = new List<Conta>();
            do
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("1 - Abrir Conta");
                Console.WriteLine("2 - Encerrar Conta");
                Console.WriteLine("3 - Gerar Cartão");
                Console.WriteLine("4 - Ver Extrato");
                Console.WriteLine("5 - Sacar");
                Console.WriteLine("6 - Depositar");
                Console.WriteLine("7 - Transferir");
                Console.WriteLine("8 - Pagamentos");
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
                            Console.WriteLine("Insira a sua data de nascimento(dd/mm/yyyy):");
                            var dataNascimento = Console.ReadLine();
                            var dataNascimentoSplit = dataNascimento.Split('/');
                            var ano = Convert.ToInt32(dataNascimentoSplit[2]);
                            var mes = Convert.ToInt32(dataNascimentoSplit[1]);
                            var dia = Convert.ToInt32(dataNascimentoSplit[0]);
                            Console.WriteLine("Insira o seu Endereço: ");
                            var endereco = Console.ReadLine();
                            Console.WriteLine("Insira a senha desejada: ");
                            var senha = Console.ReadLine();
                            Console.WriteLine("sexo: (1 - Masculino, 2 - Feminino, 3 - Outros)");
                            var sexo = Convert.ToInt32(Console.ReadLine());
                            conta =  new Conta(senha, nome, cpf, new DateTime(ano, mes, dia), endereco, (Sexo)sexo);
                        listaContas.Add(conta);
                        Console.WriteLine($"Conta {conta.NumeroConta} Criada com Sucesso!");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Insira o numero da conta a ser excluida:");
                        var excluirConta = Console.ReadLine();
                        conta = ProcuraConta(listaContas, excluirConta);
                        Console.WriteLine($"A conta {conta.NumeroConta} foi excluida com sucesso!");
                        listaContas.Remove(conta);
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Insira o numero da conta:");
                        numeroContaRecebido = Console.ReadLine();
                        conta = ProcuraConta(listaContas, numeroContaRecebido);
                        Console.WriteLine("Insira o nome a ser colocado no cartão:");
                        var nomeCartao = Console.ReadLine();
                        Console.WriteLine("digite uma senha para o cartão:");
                        var senhaCartao = Console.ReadLine();
                        conta.Cartao = new Cartao(nomeCartao, senhaCartao);
                        Console.WriteLine($"o cartão de numero {conta.Cartao.NumeroCartao} foi gerado com sucesso!");
                        Console.ReadLine();
                        break;

                    case 4:
                        Console.WriteLine("Insira o numero da conta:");
                        numeroContaRecebido = Console.ReadLine();
                        conta = ProcuraConta(listaContas, numeroContaRecebido);
                        Console.WriteLine("Insira a senha conta:");
                        senhaContaRecebida = Console.ReadLine();
                        if (conta.Senha == senhaContaRecebida)
                        {
                            Console.WriteLine($"Saldo atual: R${conta.Saldo}");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Senha Incorreta");
                            Console.ReadLine();
                        }
                        break;


                    case 5:
                        Console.WriteLine("Insira o numero da conta:");
                        numeroContaRecebido = Console.ReadLine();
                        conta = ProcuraConta(listaContas, numeroContaRecebido);
                        Console.WriteLine("Insira a senha conta:");
                        senhaContaRecebida = Console.ReadLine();
                        if (conta.Senha == senhaContaRecebida)
                        {
                            Console.WriteLine("Digite o valor a ser sacado:");
                            var saque = Convert.ToDouble(Console.ReadLine());
                            if ((double)conta.Saldo >= saque)
                            {
                                conta.Saldo -= saque;
                                Console.WriteLine("Saque realizado com sucesso!");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Saldo Insuficiente");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Senha Incorreta");
                            Console.ReadLine();
                        }
                        break;

                    case 6:
                        Console.WriteLine("Insira o numero da conta:");
                        numeroContaRecebido = Console.ReadLine();
                        conta = ProcuraConta(listaContas, numeroContaRecebido);
                        Console.WriteLine("Digite o valor a depositado:");
                                conta.Saldo += Convert.ToInt64(Console.ReadLine());
                                Console.WriteLine("Deposito realizado com sucesso!");
                                Console.ReadLine();
                        break;


                    case 7:
                        Console.WriteLine("Insira o numero da conta:");
                        numeroContaRecebido = Console.ReadLine();
                        conta = ProcuraConta(listaContas, numeroContaRecebido);
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
                                        var conta2 = ProcuraConta(listaContas, numeroConta2Recebido);
                                        conta.Saldo -= transferir;
                                        conta2.Saldo += transferir;
                                        Console.WriteLine("Transferencia realizado com sucesso!");
                                        Console.ReadLine();
                                
                                    }
                                    else
                                    {
                                        Console.WriteLine("Saldo Insuficiente");
                                        Console.ReadLine();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Senha Incorreta");
                                    Console.ReadLine();

                                }
                                break;

                    case 8:
                        Console.WriteLine("Insira o numero da conta:");
                        numeroContaRecebido = Console.ReadLine();
                        conta = ProcuraConta(listaContas, numeroContaRecebido);
                        Console.WriteLine("Insira a senha conta:");
                                senhaContaRecebida = Console.ReadLine();
                                if (conta.Senha == senhaContaRecebida)
                                {
                                    Console.WriteLine("Digite o 10 ultimos numeros do boleto a ser pago:");
                                    var boleto = (Convert.ToDouble(Console.ReadLine()) * 0.01);
                                    if ((double)conta.Saldo >= boleto)
                                    {
                                        conta.Saldo -= boleto;
                                        Console.WriteLine("boleto pago com sucesso!");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Saldo Insuficiente");
                                        Console.ReadLine();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Senha Incorreta");
                                    Console.ReadLine();
                                }
                        break;

                }
            } while (decisao != 0);

        }


        public static Conta ProcuraConta(List<Conta> listaContas, string conta)
        {
            for (int i = 0; i < listaContas.Count; i++)
            {
                if (listaContas[i].NumeroConta == conta)
                {
                    return listaContas[i];
                }
            }
            return null;
        }

    }
}
