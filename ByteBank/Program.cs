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
                Console.WriteLine("Titular: " + conta.Titular + ",\nCPF: " + conta.Cpf + ",\nSaldo: " + conta.Saldo
                    + "\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
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
                Console.WriteLine("Conta Removida");
                Console.WriteLine();
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
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch
                {
                    option = 8;
                }
                
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
                        bool checkTitular = Conta.ValidarTitular(titular);
                        while (checkTitular == false)
                        {
                          Console.Write("Informe o Titular da Conta (números são inválidos neste campo): ");
                          titular = Console.ReadLine();
                          checkTitular = Conta.ValidarTitular(titular);
                        }
                        Console.Write("Informe o cpf do Titular: ");
                        string cpf = Console.ReadLine();
                        bool checkCpf = Conta.ValidarCpf(cpf);
                        while (checkCpf == false)
                        {
                            Console.Write("Informe o cpf do Titular (minimo 11 caracteres sem pontuação): ");
                            cpf = Console.ReadLine();
                            checkCpf = Conta.ValidarCpf(cpf);
                        }
                        Console.Write("Informe a senha da conta: ");
                        string senha = Console.ReadLine();
                        bool checkSenha = Conta.ValidarSenha(senha);
                        while (checkSenha == false)
                        {
                            Console.Write("Informe a senha da conta (Minimo 9 caracteres): ");
                            senha = Console.ReadLine();
                            checkSenha = Conta.ValidarCpf(cpf);
                        }
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
                        Console.Write("Digite o cpf da conta ser deletado: ");
                        string nome = Console.ReadLine();
                        ExcluirConta(contas, nome);
                        break;
                    case 3:
                        Console.WriteLine("Contas cadastradas: ");
                        ListarContas(contas);
                        Console.WriteLine("Tecle ENTER para sair ");
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Write("Informe o cpf a ser checado: ");
                        try
                        {
                            string cpfInformado = Console.ReadLine();
                            ChecarUsuario(contas, cpfInformado);
                            Console.WriteLine("Tecle ENTER para sair ");
                            Console.ReadLine();
                        }
                        catch
                        {
                            Console.WriteLine("Valor inválido");
                            Console.WriteLine("Tecle ENTER para sair ");
                            Console.ReadLine();
                        }
                        break;
                    case 5:
                        Console.WriteLine("Saldo do Banco: ");
                        Console.WriteLine("Saldo total: " + VerificarSaldo(contas));
                        Console.WriteLine("Tecle ENTER para sair ");
                        Console.ReadLine();
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
                                try
                                {
                                   optionMenu = int.Parse(Console.ReadLine());
                                }
                                catch
                                {
                                    optionMenu = 8;
                                }
                                
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
                                            try
                                            {
                                              Console.Write("Digite o valor a ser Depositado: ");
                                              double deposito = double.Parse(Console.ReadLine());
                                              contas[index].Depositar(deposito);
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Valor Inválido");
                                            }
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
                                            try
                                            {


                                                Console.Write("Digite o valor a ser Sacado: ");
                                                double saque = double.Parse(Console.ReadLine());
                                                contas[indexSaque].Sacar(saque);
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Valor Inválido");
                                            }
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
                                            try
                                            {
                                                Console.Write("Digite o valor a ser Transferido: ");
                                                double valor = double.Parse(Console.ReadLine());
                                                contas[indexRemetente].Sacar(valor);
                                                contas[indexDestino].Depositar(valor);
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Valor Inválido");
                                            }
                                        }
                                        break;
                                    default:
                                        Console.WriteLine();
                                        Console.WriteLine("Opção inválida");
                                        Console.WriteLine();
                                        break;
                                }
                            } while (optionMenu != 0);


                        }
                        else
                        {
                            Console.WriteLine("Login Inválido");
                            Console.WriteLine("Aperte ENTER para sair");
                            Console.ReadLine();
                        }

                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Opção inválida");
                        Console.WriteLine("Aprete ENTER para sair");
                        Console.ReadLine();
                        Console.WriteLine();
                        break;
                }
                Console.WriteLine("--------------");

            } while (option != 0);
        }


    }
}