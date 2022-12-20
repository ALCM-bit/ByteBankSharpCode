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
            this.Saldo += valor;

        }




    }
}