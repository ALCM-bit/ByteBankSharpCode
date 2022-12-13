using System;
using System.Xml.Linq;

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

        static void RegistrarNovoUsuario(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.Write("Digite o cpf: ");
            cpfs.Add(Console.ReadLine());
            Console.Write("Digite o nome: ");
            titulares.Add(Console.ReadLine());

            saldos.Add(0);
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
                switch (option)
                {
                    case 0:
                        Console.WriteLine("Estou encerrando o programa...");
                        break;
                    case 1:
                        Console.WriteLine("Deveria estar inserindo um novo usuário!");
                        RegistrarNovoUsuario(cpfs, titulares, saldos);
                        break;
                    case 2:
                        Console.WriteLine("Você solicitou Deletar");
                        name = DeleteUser();
                        break;
                    case 3:
                        Console.WriteLine("Informando detalhes do usuário...");
                        break;
                    case 4:
                        Console.WriteLine("Informando saldo...");
                        break;
                }
                Console.WriteLine("--------------");

            } while (option != 0);
        }


    }
}