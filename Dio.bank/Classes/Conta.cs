using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dio.bank
{
    class Conta
    {
        private String Nome { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private TipoConta TipoConta { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, String nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }
        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.Credito *-1))
            {
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }
            this.Saldo -= valorSaque;
            Console.WriteLine("Saldo atual da conta de {0} é de {1}", this.Nome, this.Saldo);
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("Saldo atual da conta de {0} é de {1}", this.Nome, this.Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            String retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Credito " + this.Credito + " | ";
            retorno += "Saldo " + this.Saldo;
            return retorno;
        }
    }
}
