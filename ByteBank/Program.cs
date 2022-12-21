using System;
using System.Xml.Linq;
using System.Collections.Generic;
using ByteBank.Contas;
using ByteBank.Sistemas;
using System.ComponentModel.Design;
using System.Drawing;

namespace ByteBank
{
    public class Program
    {
        public static void ListarContas(List<Conta> contas)
        {
            foreach (Conta conta in contas)
            {
                Console.WriteLine("Titular: " + conta.Titular + ", CPF: " + conta.Cpf + ", Saldo: " + conta.Saldo);
            }
        }

        public static void ExcluirConta(List<Conta> contas, string cpf)
        {
            int index = contas.FindIndex(contas => contas.Cpf == cpf);
            if (index == -1)
            {
                Console.WriteLine();
                Console.WriteLine("Usuário não econtrado");
                Console.WriteLine();
                return;

            }
            else
            {
                contas.RemoveAt(index);
            }
        }

        static double VerificarSaldo(List<Conta> contas)
        {
            double saldo = 0.0;
            foreach (Conta conta in contas)
            {
                saldo += conta.Saldo;
            }

            return saldo;
        }

        public static void ChecarUsuario(List<Conta> contas, string cpf)
        {
            int index = contas.FindIndex(contas => contas.Cpf == cpf);
            Console.WriteLine($"Titular: {contas[index].Titular}");
            Console.WriteLine($"CPF: {contas[index].Cpf}");
            Console.WriteLine($"Saldo: {contas[index].Saldo}");
        }

        public static bool ValidarLogin(List<Conta> contas, string cpf, string senha)
        {
            int index = contas.FindIndex(contas => contas.Cpf == cpf);
            if (index >= 0 && contas[index].Cpf == cpf && contas[index].Senha == senha)
            {
                return true;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Login invalido");
                Console.WriteLine();
                return false;
            }

        }


        public static void Main(string[] args)
        {
            int option;
            List<Conta> contas = new List<Conta>();



            do
            {
                Sistema.ShowMenu();
                option = int.Parse(Console.ReadLine());

                Console.WriteLine("--------------");
                Console.WriteLine();

                switch (option)
                {
                    case 0:
                        Console.WriteLine("Estou encerrando o programa...");
                        break;
                    case 1:
                        Console.WriteLine("Informe o que é solicitado");
                        Console.Write("Informe o Titular da Conta: ");
                        string titular = Console.ReadLine();
                        Console.Write("Informe o cpf do Titular: ");
                        string cpf = Console.ReadLine();
                        Console.Write("Informe a senha da conta: ");
                        string senha = Console.ReadLine();
                        Conta conta = new Conta(titular, cpf, senha);
                        if (conta.check == true)
                        {
                            contas.Add(conta);
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Valores inválidos");
                            Console.WriteLine();
                        }

                        break;
                    case 2:
                        Console.WriteLine("Você solicitou Deletar");
                        Console.Write("Digite o nome do titular: ");
                        string nome = Console.ReadLine();
                        ExcluirConta(contas, nome);
                        break;
                    case 3:
                        Console.WriteLine("Contas cadastradas: ");
                        ListarContas(contas);
                        break;
                    case 4:
                        Console.Write("Informe o cpf a ser checado: ");
                        string cpfInformado = Console.ReadLine();
                        ChecarUsuario(contas, cpfInformado);
                        break;
                    case 5:
                        Console.WriteLine("Saldo do Banco: ");

                        Console.WriteLine("Saldo total: " + VerificarSaldo(contas));
                        break;
                    case 6:
                        Console.WriteLine("Para acessar informe o que se pede");
                        Console.Write("Cpf: ");
                        string cpfConta = Console.ReadLine();
                        Console.Write("Senha: ");
                        string senhaConta = Console.ReadLine();

                        if (ValidarLogin(contas, cpfConta, senhaConta) == true)
                        {
                            int optionMenu = 0;
                            do
                            {
                                Sistema.ShowMenuConta();
                                optionMenu = int.Parse(Console.ReadLine());

                                switch (optionMenu)
                                {
                                    case 0:
                                        Console.WriteLine("Voltando ao menu do Banco...");
                                        break;
                                    case 1:
                                        Console.WriteLine("Depositar");
                                        int index = contas.FindIndex(contas => contas.Cpf == cpfConta);
                                        if (index < 0)
                                        {
                                            Console.WriteLine("Conta inválida");
                                        }
                                        else
                                        {
                                            Console.Write("Digite o valor a ser depositado: ");
                                            double deposito = double.Parse(Console.ReadLine());
                                            contas[index].Depositar(deposito);
                                        }
                                        break;
                                    case 2:
                                        Console.WriteLine("Sacar");
                                        int indexSaque = contas.FindIndex(contas => contas.Cpf == cpfConta);
                                        if (indexSaque < 0)
                                        {
                                            Console.WriteLine("Conta inválida");
                                        }
                                        else
                                        {
                                            Console.Write("Digite o valor a ser depositado: ");
                                            double saque = double.Parse(Console.ReadLine());
                                            contas[indexSaque].Sacar(saque);
                                        }
                                        break;
                                    case 3:
                                        Console.WriteLine("Transferir");
                                        int indexRemetente = contas.FindIndex(contas => contas.Cpf == cpfConta);
                                        Console.Write("Digite o cpf do destino: ");
                                        string cpfDestino = Console.ReadLine();
                                        int indexDestino = contas.FindIndex(contas => contas.Cpf == cpfDestino);
                                        if (indexRemetente < 0 && indexDestino < 0)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("Operação inválida");
                                            Console.WriteLine("Cheque os dados e tente novamente mais tarde");
                                        }
                                        else
                                        {
                                            Console.Write("Digite o valor a ser depositado: ");
                                            double valor = double.Parse(Console.ReadLine());
                                            contas[indexRemetente].Sacar(valor);
                                            contas[indexDestino].Depositar(valor);
                                        }
                                        break;
                                }
                            } while (optionMenu != 0);


                        }

                        break;
                }
                Console.WriteLine("--------------");

            } while (option != 0);
        }


    }
}