using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ByteBank.Contas
{
    public class Conta
    {
        private string titular;
        public string Titular { 
            get { return titular; }
            private set 
            {
                if (Regex.IsMatch(value, @"^\d+$") == true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Valor invalido");
                    Console.WriteLine();
                    return;
                }
                else
                {
                    this.titular = value;
                }
            } 
        }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public double Saldo { get; private set; }

        public Conta(string titular, string cpf, string senha)
        {
            this.Titular = titular;
            this.Cpf = cpf;
            this.Senha = senha;
        }


        public void Depositar(double valor)
        {
            this.Saldo += valor;

        }

        public static void ListarContas(List<Conta> contas)
        {
            foreach (Conta conta in contas)
            {
                Console.WriteLine(conta.Titular + ", " + conta.Cpf + ", " + conta.Senha + ", " + conta.Saldo);
            }
        }

        
    }
}
