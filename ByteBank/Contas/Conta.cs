using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ByteBank.Contas
{
    public class Conta
    {
        private string titular;
        public string Titular { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public double Saldo { get; private set; }

        public bool check;

        public Conta(string titular, string cpf, string senha)
        {
            if (Regex.IsMatch(titular, @"^\d+$") == true)
            {
                check = false;
                return;
            }
            else
            {
                this.Titular = titular;
            }

            this.Cpf = cpf;
            this.Senha = senha;
            check = true;
        }


        public void Depositar(double valor)
        {
            if (valor >= 0)
            {
                this.Saldo += valor;
                Console.WriteLine("Saque realizado com sucesso");
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