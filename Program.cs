using CaixaEletronico.Aplicacao.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaixaEletronico.Aplicacao
{
    public class Program
    {
        public static void Main() {
            var decisao=0;
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
                decisao = Convert.ToInt32(Console.ReadLine());

                var numeroContaRecebido = "";
                var senhaContaRecebida = "";
                switch(decisao){
                    case 1:
                        var conta = AbrirConta();
                        listaContas.Add(conta);
                        Console.WriteLine($"Conta {conta.NumeroConta} Criada com Sucesso!");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Insira o numero da conta a ser excluida:");
                        var excluirConta = Console.ReadLine();
                        for (int i=0; i<listaContas.Capacity; i++)
                        {
                            if (listaContas[i].NumeroConta == excluirConta){
                                Console.WriteLine($"A conta {listaContas[i].NumeroConta} foi excluida com sucesso!");
                                listaContas.Remove(listaContas[i]);
                                Console.ReadLine();
                                break;
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Insira o numero da conta:");
                        numeroContaRecebido = Console.ReadLine();
                        for (int i = 0; i < listaContas.Capacity; i++)
                        {
                            if (listaContas[i].NumeroConta == numeroContaRecebido)
                            {
                                Console.WriteLine("Insira o nome a ser colocado no cartão:");
                                var nomeCartao = Console.ReadLine();
                                Console.WriteLine("digite uma senha para o cartão:");
                                var senhaCartao = Console.ReadLine();
                                listaContas[i].Cartao = new Cartao(nomeCartao, senhaCartao);
                                Console.WriteLine($"o cartão de numero {listaContas[i].Cartao.NumeroCartao} foi gerado com sucesso!");
                                Console.ReadLine();
                                break;
                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine("Insira o numero da conta:");
                        numeroContaRecebido = Console.ReadLine();
                        for (int i = 0; i < listaContas.Capacity; i++)
                        {
                            if (listaContas[i].NumeroConta == numeroContaRecebido)
                            {
                                Console.WriteLine("Insira a senha conta:");
                                senhaContaRecebida = Console.ReadLine();
                                if (listaContas[i].Senha == senhaContaRecebida)
                                {
                                    Console.WriteLine($"Saldo atual: R${listaContas[i].Saldo}");
                                    Console.ReadLine();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Senha Incorreta");
                                    Console.ReadLine();
                                    break;

                                }

                            }
                        }
                        break;

                    case 5:
                        Console.WriteLine("Insira o numero da conta:");
                        numeroContaRecebido = Console.ReadLine();
                        for (int i = 0; i < listaContas.Capacity; i++)
                        {
                            if (listaContas[i].NumeroConta == numeroContaRecebido)
                            {
                                Console.WriteLine("Insira a senha conta:");
                                senhaContaRecebida = Console.ReadLine();
                                if (listaContas[i].Senha == senhaContaRecebida)
                                {
                                    Console.WriteLine("Digite o valor a ser sacado:");
                                    var saque = Convert.ToDouble(Console.ReadLine());
                                    if((double)listaContas[i].Saldo >= saque)
                                    {
                                        listaContas[i].Saldo -= saque;
                                        Console.WriteLine("Saque realizado com sucesso!");
                                        Console.ReadLine();
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Saldo Insuficiente");
                                        Console.ReadLine();
                                        break;

                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Senha Incorreta");
                                    Console.ReadLine();
                                    break;

                                }

                            }
                        }
                        break;

                    case 6:
                        Console.WriteLine("Insira o numero da conta:");
                        numeroContaRecebido = Console.ReadLine();
                        for (int i = 0; i < listaContas.Capacity; i++)
                        {
                            if (listaContas[i].NumeroConta == numeroContaRecebido)
                            {
                                Console.WriteLine("Digite o valor a depositado:");
                                        listaContas[i].Saldo += Convert.ToInt64(Console.ReadLine());
                                        Console.WriteLine("Deposito realizado com sucesso!");
                                        Console.ReadLine();
                                        break;
                            }
                        }
                        break;
                        

                    case 7:
                        Console.WriteLine("Insira o numero da conta:");
                        numeroContaRecebido = Console.ReadLine();
                        for (int i = 0; i < listaContas.Capacity; i++)
                        {
                            if (listaContas[i].NumeroConta == numeroContaRecebido)
                            {
                                Console.WriteLine("Insira a senha conta:");
                                senhaContaRecebida = Console.ReadLine();
                                if (listaContas[i].Senha == senhaContaRecebida)
                                {
                                    Console.WriteLine("Digite o valor a ser transferido:");
                                    var transferir = Convert.ToDouble(Console.ReadLine());
                                    if ((double)listaContas[i].Saldo >= transferir)
                                    {
                                        Console.WriteLine("Insira o numero da conta a ser transferida:");
                                        var numeroConta2Recebido = Console.ReadLine();
                                        for (int j = 0; j < listaContas.Capacity; j++)
                                        {
                                            if (listaContas[j].NumeroConta == numeroConta2Recebido)
                                            {
                                                listaContas[i].Saldo -= transferir;
                                                listaContas[j].Saldo += transferir;
                                                Console.WriteLine("Transferencia realizado com sucesso!");
                                                Console.ReadLine();
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Saldo Insuficiente");
                                        Console.ReadLine();
                                        break;

                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Senha Incorreta");
                                    Console.ReadLine();
                                    break;

                                }
                                break;
                            }
                        }
                        break;

                    case 8:
                        Console.WriteLine("Insira o numero da conta:");
                        numeroContaRecebido = Console.ReadLine();
                        for (int i = 0; i < listaContas.Capacity; i++)
                        {
                            if (listaContas[i].NumeroConta == numeroContaRecebido)
                            {
                                Console.WriteLine("Insira a senha conta:");
                                senhaContaRecebida = Console.ReadLine();
                                if (listaContas[i].Senha == senhaContaRecebida)
                                {
                                    Console.WriteLine("Digite o 10 ultimos numeros do boleto a ser pago:");
                                    var boleto = (Convert.ToDouble(Console.ReadLine()) * 0.01);
                                    if ((double)listaContas[i].Saldo >= boleto)
                                    {
                                        listaContas[i].Saldo -= boleto;
                                        Console.WriteLine("boleto pago com sucesso!");
                                        Console.ReadLine();
                                        break;

                                    }
                                    else
                                    {
                                        Console.WriteLine("Saldo Insuficiente");
                                        Console.ReadLine();
                                        break;

                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Senha Incorreta");
                                    Console.ReadLine();
                                    break;

                                }

                            }
                        }
                        break;

                }
            } while (decisao != 0);

        }

        public static Conta AbrirConta()
        {

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
            return new Conta(senha, nome, cpf, new DateTime(ano, mes, dia), endereco, (Sexo)sexo);
        }
        
    }
}
