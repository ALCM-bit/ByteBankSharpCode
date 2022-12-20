using System;
using System.Xml.Linq;
using System.Collections.Generic;
using ByteBank.Contas;
using ByteBank.Sistemas;

namespace ByteBank
{
    public class Program
    {

        //static bool Logar(List<string> cpfs, List<string> titulares, List<string> senhas)
        //{
        //    Console.Write("Informe o cpf da Conta: ");
        //    string pesquisar = Console.ReadLine();
        //    bool cpf = cpfs.Any(cpfs => cpfs == pesquisar);
        //    Console.Write("Informe a senha: ");
        //    string pegarSenha = Console.ReadLine();
        //    bool senha = senhas.Any(senhas => senhas == pegarSenha);

        //    if (cpf == true && senha == true)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //static void GerarRelatorio(List<double> saldos)
        //{
        //    double total = 0;
        //    for (int i = 0; i < saldos.Count; i++)
        //    {
        //        total+= saldos[i];
        //    }

        //    Console.WriteLine($"Total do Banco: {total}");

        //}

        //static void Depositar(List<string> cpfs, List<string> titulares, List<double> saldos)
        //{
        //    Console.Write("Informe o cpf da Conta: ");
        //    string cpf = Console.ReadLine();
        //    int index = cpfs.FindIndex(cpfs => cpfs == cpf);
        //    Console.Write("Informe o valor a depositar: ");
        //    double valor = double.Parse(Console.ReadLine());
        //    saldos[index] += valor;
        //    Console.WriteLine($"Saldo atual R$ {saldos[index]}");
        //}
        //static void Sacar(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        //{
        //    Console.Write("Informe o cpf da Conta: ");
        //    string cpf = Console.ReadLine();
        //    int index = cpfs.FindIndex(cpfs => cpfs == cpf);
        //    Console.Write("Informe o valor a sacar: ");
        //    double valor = double.Parse(Console.ReadLine());
        //    saldos[index] -= valor;
        //    Console.WriteLine($"Saldo atual R$ {saldos[index]}");
        //}
        //static void Transferir(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos, double valor)
        //{
        //    Console.Write("Informe seu cpf: ");
        //    string cpf1 = Console.ReadLine();
        //    int index = cpfs.FindIndex(cpfs => cpfs == cpf1);
        //    Console.Write("Informe o cpf da conta a receber: ");
        //    string cpf2 = Console.ReadLine();
        //    int index2 = cpfs.FindIndex(cpfs => cpfs == cpf2);
        //    saldos[index2] += valor;
        //    saldos[index] -= valor;
        //}

        //static void RegistrarNovoUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        //{
        //    Console.Write("Digite o cpf: ");
        //    cpfs.Add(Console.ReadLine());
        //    Console.Write("Digite o nome: ");
        //    titulares.Add(Console.ReadLine());
        //    Console.Write("Digite a senha: ");
        //    senhas.Add(Console.ReadLine());
        //    saldos.Add(0);
        //}

        //static void DeletarUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        //{
        //    Console.Write("Digite o cpf a ser removido: ");
        //    string cpf = Console.ReadLine();
        //    int index = cpfs.FindIndex(cpfs => cpfs == cpf);
        //    cpfs.RemoveAt(index);
        //    titulares.RemoveAt(index);
        //    senhas.RemoveAt(index);
        //    saldos.RemoveAt(index);


        //}

        //static void ListarUsuarios(List<string> cpfs, List<string> titulares, List<double> saldos)
        //{
        //    for (int i = 0; i < cpfs.Count; i++)
        //    {
        //        Console.WriteLine($"CPF = {cpfs[i]} | Titular = {titulares[i]} | Saldo = R${saldos[i]:F2}");
        //    }
        //}

        //static void GerarRelatorioDeConta(List<string> cpfs, List<string> titulares, List<double> saldos)
        //{
        //    Console.Write("Informe o cpf para localização: ");
        //    string cpf = Console.ReadLine();
        //    int index = cpfs.FindIndex(cpfs => cpfs == cpf);
        //    Console.WriteLine($"CPF = {cpfs[index]} | Titular = {titulares[index]} | Saldo = R${saldos[index]:F2}");

        //}

        //static void ManipularConta(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        //{
        //    int option;
        //    do
        //    {
        //        Console.WriteLine("1 - Depositar");
        //        Console.WriteLine("2 - Sacar");
        //        Console.WriteLine("3 - Transferir");
        //        Console.WriteLine("0 - Para voltar ao menu principal");
        //        Console.Write("Digite a opção desejada: ");
        //        option = int.Parse(Console.ReadLine());

        //        Console.WriteLine("--------------");
        //        Console.WriteLine();

        //        switch (option)
        //        {
        //            case 1:
        //                Console.WriteLine("Depositar ");
        //                Depositar(cpfs, titulares, saldos);
        //                break;
        //            case 2:
        //                Console.WriteLine("Sacar");
        //                Sacar(cpfs, titulares, senhas, saldos);
        //                break;
        //            case 3:
        //                Console.WriteLine("Transferir");
        //                Console.Write("Insira o valor da transferencia: ");
        //                double valorTransferir = double.Parse(Console.ReadLine());
        //                Transferir(cpfs, titulares, senhas, saldos, valorTransferir);
        //                break;

        //        }
        //        Console.WriteLine("--------------");
        //    } while (option != 0);
        //}

        public static void ListarContas(List<Conta> contas)
        {
            foreach (Conta conta in contas)
            {
                Console.WriteLine(conta.Titular + ", " + conta.Cpf + ", " + conta.Senha + ", " + conta.Saldo);
            }
        }

        public static void ExcluirConta(List<Conta> contas, string nome)
        {
            int index = contas.FindIndex(contas => contas.Titular == nome);
            contas.RemoveAt(index);

        }

        public static void Main(string[] args)
        {

            Console.WriteLine("Antes de começar a usar, vamos configurar alguns valores: ");
            Console.Write("Digite a quantidade de Usuários: ");
            int option;

            //List<string> cpfs = new List<string>();
            //List<string> titulares = new List<string>();
            //List<string> senhas = new List<string>();
            //List<double> saldos = new List<double>();
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
                        Console.WriteLine("Informando saldo...");
                        //GerarRelatorioDeConta(cpfs, titulares, saldos);
                        break;
                    case 5:
                        Console.WriteLine("Informando saldo total do Banco");
                        //GerarRelatorio(saldos);
                        break;
                    case 6:
                        //bool check = Logar(cpfs, titulares, senhas);
                        //if (check == true)
                        //{
                        //ManipularConta(cpfs, titulares, senhas, saldos);
                        //}
                        //else
                        //{
                        //Console.WriteLine("Login ou senha Invalidos !!!");
                        //}
                        break;
                }
                Console.WriteLine("--------------");

            } while (option != 0);
        }


    }
}