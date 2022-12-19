using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Contas
{
    public class Conta
    {
        public string Titular { get; set; }
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
