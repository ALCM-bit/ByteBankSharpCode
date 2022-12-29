using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace ByteBank.Contas
{
    public class Conta
    {
        private string titular;
        public string Titular { get; private set; }
        public string Cpf { get; private set; }
        public string Senha { get; private set; }
        public double Saldo { get; private set; }

        public bool check;

        public Conta(string titular, string cpf, string senha)
        {


            this.Titular = titular;
            this.Cpf = cpf;
            this.Senha = senha;
            check = true;


        }

        public static bool ValidarTitular(string titular)
        {
            if (Regex.IsMatch(titular, @"^\d+$") == true)
            {
                Console.WriteLine();
                Console.WriteLine("Titular inválido");
                Console.WriteLine();
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ValidarCpf(string cpf)
        {
            if (cpf.Length < 14)
            {

                Console.WriteLine();
                Console.WriteLine("CPF inválido");
                Console.WriteLine();
                return false;

            }
            else
            {
                return true;
            }

        }

        public static bool ValidarSenha(string senha)
        {
            if (senha.Length < 8)
            {
                Console.WriteLine();
                Console.WriteLine("Senha inválida");
                Console.WriteLine();
                return false;

            }
            else
            {
                return true;
            }
        }


        public void Depositar(double valor)
        {
            if (valor >= 0)
            {
                this.Saldo += valor;
                Console.WriteLine("Deposito realizado com sucesso");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Valores negativos não são aceitos");
                Console.WriteLine();
            }

        }

        public void Sacar(double valor)
        {
            if (valor >= 0)
            {
                if (this.Saldo >= valor)
                {
                    this.Saldo -= valor;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Valor guardado é insuficiente ");
                    Console.WriteLine();
                    return;
                }

            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Valores negativos não são aceitos ");
                Console.WriteLine();
                return;
            }


        }

    }
}