using System;
using System.Xml.Linq;
using System.Collections.Generic;

namespace ByteBank
{
    public class Program
    {
        static void ShowMenu()
        {
            Console.WriteLine("1 - Inserir novo usuário");
            Console.WriteLine("2 - Deletar um usuário");
            Console.WriteLine("3 - Listar todas as contas registradas");
            Console.WriteLine("4 - Detalhes de um usuário");
            Console.WriteLine("5 - Total armazenado no banco");
            Console.WriteLine("6 - Manipular a conta"); // Implementa as operações
            Console.WriteLine("0 - Para sair do programa");
            Console.Write("Digite a opção desejada: ");
        }

        static bool Logar(List<string> cpfs, List<string> titulares, List<string> senhas)
        {
            Console.Write("Informe o cpf da Conta: ");
            bool cpf = cpfs.Any(cpfs => cpfs == Console.ReadLine());
            Console.Write("Informe a senha: ");
            bool senha = senhas.Any(senhas => senhas == Console.ReadLine());

            if (cpf == true && senha == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
  
        static void Depositar(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.Write("Informe o cpf da Conta: ");
            int index = cpfs.FindIndex(cpfs => cpfs == Console.ReadLine());
            Console.Write("Informe o valor a depositar: ");
            double valor = double.Parse(Console.ReadLine());
            saldos[index] += valor;
            Console.WriteLine($"Saldo atual R$ {saldos[index]}");
        }
        static void Saque(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Write("Informe o cpf da Conta: ");
            int index = cpfs.FindIndex(cpfs => cpfs == Console.ReadLine());
            Console.Write("Informe o valor a sacar: ");
            double valor = double.Parse(Console.ReadLine());
            saldos[index] -= valor;
            Console.WriteLine($"Saldo atual R$ {saldos[index]}");
        }
        static void Transferencia(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos, double valor)
        {
            Console.Write("Informe o cpf da conta a receber: ");
            int index = cpfs.FindIndex(cpfs => cpfs == Console.ReadLine());
            saldos[index] += valor;
        }

        static void RegistrarNovoUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Write("Digite o cpf: ");
            cpfs.Add(Console.ReadLine());
            Console.Write("Digite o nome: ");
            titulares.Add(Console.ReadLine());
            Console.Write("Digite a senha: ");
            senhas.Add(Console.ReadLine());
            saldos.Add(0);
        }

        static void DeletarUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Write("Digite o cpf a ser removido: ");
            int index = cpfs.FindIndex(cpfs => cpfs == Console.ReadLine());
            
            
            cpfs.RemoveAt(index);
            titulares.RemoveAt(index);
            senhas.RemoveAt(index);
            saldos.RemoveAt(index);


        }

        static void ListarUsuarios(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            for (int i = 0; i < cpfs.Count; i++)
            {
                Console.WriteLine($"CPF = {cpfs[i]} | Titular = {titulares[i]} | Saldo = R${saldos[i]:F2}");
            }
        }

        static void GerarRelatorioDeConta(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.Write("Informe o cpf para localização: ");
            int index = cpfs.FindIndex(cpfs => cpfs == Console.ReadLine());
            Console.WriteLine(cpfs[index] + ", " + titulares[index] + ", " + saldos[index]);

        }

        static void ManipularConta(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            int option;
            int index = 0;
            do
            {
                Console.WriteLine("1 - Depositar");
                Console.WriteLine("2 - Transferir");
                Console.WriteLine("3 - Sacar");
                Console.WriteLine("0 - Para voltar ao menu principal");
                Console.Write("Digite a opção desejada: ");
                option = int.Parse(Console.ReadLine());

                Console.WriteLine("--------------");
                Console.WriteLine();

                switch (option != 0)
                {
                    case 0:
                        Console.WriteLine("Digite o valor a ser depositado: ");
                        double valor = double.Parse(Console.ReadLine());
                        //Depositar(cpfs, titulares, saldos, valor, index);
                        break;
                    case 1:
                        Console.WriteLine("Deveria estar inserindo um novo usuário!");
                        RegistrarNovoUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 2:
                        Console.WriteLine("Você solicitou Deletar");
                        DeletarUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 3:
                        Console.WriteLine("Informando detalhes do usuário...");
                        ListarUsuarios(cpfs, titulares, saldos);
                        break;
                }
                Console.WriteLine("--------------");
            } while (option != 0);
        }

        public static void Main(string[] args)
        {

            Console.WriteLine("Antes de começar a usar, vamos configurar alguns valores: ");
            Console.Write("Digite a quantidade de Usuários: ");
            int option;

            List<string> cpfs = new List<string>();
            List<string> titulares = new List<string>();
            List<string> senhas = new List<string>();
            List<double> saldos = new List<double>();



            do
            {
                ShowMenu();
                option = int.Parse(Console.ReadLine());

                Console.WriteLine("--------------");
                Console.WriteLine();

                switch (option)
                {
                    case 0:
                        Console.WriteLine("Estou encerrando o programa...");
                        break;
                    case 1:
                        Console.WriteLine("Deveria estar inserindo um novo usuário!");
                        RegistrarNovoUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 2:
                        Console.WriteLine("Você solicitou Deletar");
                        DeletarUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 3:
                        Console.WriteLine("Informando detalhes do usuário...");
                        ListarUsuarios(cpfs, titulares, saldos);
                        break;
                    case 4:
                        Console.WriteLine("Informando saldo...");
                        GerarRelatorioDeConta(cpfs, titulares, saldos);
                        break;
                    case 6:
                        bool check = Logar(cpfs, titulares, senhas);
                        if (check == true)
                        {
                           ManipularConta(cpfs, titulares, senhas, saldos);
                        }
                        else
                        {
                            Console.WriteLine("Login ou senha Invalidos !!!");
                        }
                        break;
                }
                Console.WriteLine("--------------");

            } while (option != 0);
        }


    }
}